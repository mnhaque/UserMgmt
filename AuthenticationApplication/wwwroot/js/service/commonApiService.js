authenticationApp.service('commonAPIService', ['$q', '$http',
    function ($q, $http) {
        var _this = this;
        _this.commonAPICall = function (type, url, data) {
            var deferredObject = $q.defer();
            $http({
                method: type,
                url: url,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: data,
                cache: false
            }).then(function (response) {
                if (response.data) {
                    deferredObject.resolve({
                        success: true,
                        data: response.data,
                        status: status
                    });
                } else {
                    deferredObject.resolve({
                        success: false,
                        status: status
                    });
                }
            }, function (error) {
                deferredObject.resolve({
                    success: false,
                    status: status,
                    error: error
                });
            });
            return deferredObject.promise;
        }
    }
]);