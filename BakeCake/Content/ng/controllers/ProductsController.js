angular.module('app').controller('ProductsController', [
    '$scope',
    '$location',
    '$http',
    function (
        $scope,
        $location,
        $http
    ) {


        $scope.products = [];

        $http.get('/api/products').then(function (response) {
            $scope.products = response.data;
        }, function () {
            alert('error');
        })

    }
])