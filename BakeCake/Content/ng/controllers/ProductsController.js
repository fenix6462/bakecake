angular.module('app').controller('ProductsController', [
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


        $scope.isProductsFetchInProgress = true;
        $scope.products = [];

        $http.get('/api/products').then(function (response) {
            $scope.products = response.data;
            $scope.isProductsFetchInProgress = false;
        }, function () {
            $ngBootbox.alert('Wystąpił błąd podczas ładowania produktów');
            $scope.isProductsFetchInProgress = false;
        })

        $scope.deleteProduct = function (product) {
            product.isDeletingInProgress = true;
            var productIndex = $scope.products.indexOf(product);
            $http.delete('/api/products/' + product.Id).then(function (response) {
                $scope.products.splice(productIndex, 1);
                product.isDeletingInProgress = false;
            }, function () {
                $ngBootbox.alert('Wystąpił błąd podczas usuwania produktu');
                product.isDeletingInProgress = false;
            })
        }

        $scope.save = function (product) {
            product.isSavingInProgress = true;
            $http.put('/api/products/' + product.Id, product).then(function (response) {
                product.isSavingInProgress = false;
                product = response.data;
            }, function () {
                $ngBootbox.alert('Wystąpił błąd podczas edycji produktu');
                product.isSavingInProgress = false;
            })
        }

    }
])