angular.module('app').controller('AppController', [
    '$scope',
    '$location',
    function (
        $scope,
        $location
    ) {

        $scope.isActive = function (route) {
            console.log($location.path());
            return route === $location.path();
        }

    }
])