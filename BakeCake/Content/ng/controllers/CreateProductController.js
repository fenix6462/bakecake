angular.module('app').controller('CreateProductController', [
    '$scope',
    '$location',
    '$http',
    '$ngBootbox',
    function (
        $scope,
        $location,
        $http,
        $ngBootbox
    ) {


        $scope.product = {};
        $scope.isCreatingInProgress = false;

        $scope.createProduct = function () {
            $scope.isCreatingInProgress = true;
            $http.post('/api/products', $scope.product).then(function (response) {
                $scope.isCreatingInProgress = false;
                $ngBootbox.alert('Produkt został dodany');
                $location.path("/products");
            }, function () {
                $scope.isCreatingInProgress = false;
                $ngBootbox.alert('Wystąpił błąd podczas dodawania produktu');
            })
        }

    }
])