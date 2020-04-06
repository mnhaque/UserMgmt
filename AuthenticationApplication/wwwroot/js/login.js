authenticationApp.controller('LoginCtrl', ['$scope', 'commonAPIService', '$window', function ($scope, commonAPIService, $window) {
        var _this = this; 
    _this.submit = function () {
        var promise = commonAPIService.commonAPICall('GET', 'http://localhost:51426/api/Users/Login?userName=' + $scope.email + '&pwd=' + $scope.password);
            promise.then(function (result) {
                if (result.success) {
                    $window.location.href = 'http://localhost:51426/Home/Welcome?name=' + result.data.firstName + '&lastName=' + result.data.lastName;
                } else {
                    $scope.invalidCredentials = true;
                }
            });
        }
    }
]);