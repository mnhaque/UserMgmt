authenticationApp.controller('RegisterCtrl', ['$scope', 'commonAPIService','$location',
    function ($scope, commonAPIService, $location) {
        var _this = this;
        $scope.countries = {
            'USA': {
                'Alabama': ['Montgomery', 'Birmingham'],
                'California': ['Sacramento', 'Fremont'],
                'Illinois': ['Springfield', 'Chicago']
            },
            'India': {
                'Maharashtra': ['Pune', 'Mumbai', 'Nagpur', 'Akola'],
                'Madhya Pradesh': ['Indore', 'Bhopal', 'Jabalpur'],
                'Rajasthan': ['Jaipur', 'Ajmer', 'Jodhpur']
            },
            'Australia': {
                'New South Wales': ['Sydney'],
                'Victoria': ['Melbourne']
            }
        };

        $scope.GetSelectedCountry = function () {
            $scope.strCountry = $scope.countries[$scope.selectedCounrty];
        };
        $scope.GetSelectedState = function () {
            $scope.strState = $scope.countries[$scope.selectedCounrty][$scope.selectedState];
        };
        _this.submit = function () {
            
            var user = {
                'FirstName': $scope.firstName,
                'Email': $scope.email,
                'MiddleName': $scope.middleName,
                'LastName': $scope.lastName,
                'Country': $scope.selectedCounrty,
                'State': $scope.selectedState,
                'AcceptedTnC': $scope.accetTnc,
                'Password': $scope.password
            };
            var promise = commonAPIService.commonAPICall('POST', 'http://localhost:51426/api/Users/Register', user);
            promise.then(function (result) {
              if (result.success) {
                  $location.path('/home');
              } else {
                  $scope.error = result.error.data;
              }
            });
        };
    }
]);