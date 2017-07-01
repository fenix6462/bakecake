angular.module('app').controller('CreateProductController', [
    '$scope',
    '$location',
    '$http',
    function (
        $scope,
        $location,
        $http
    ) {


        $scope.product = {};

        $scope.createProduct = function () {
            $http.post('/api/products', $scope.product).then(function (response) {
                alert('Produkt został dodany');
            }, function () {
                alert('Produkt nie został dodany');
            })
        }

    }
])