angular.module('app').controller('AppController', [
    '$scope',
    '$location',
    function (
        $scope,
        $location
    ) {

        $scope.isActive = function (route) {
            return route === $location.path();
        }

    }
])