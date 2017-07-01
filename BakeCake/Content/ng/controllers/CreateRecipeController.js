angular.module('app').controller('CreateRecipeController', [
    '$scope',
    '$location',
    '$http',
    function (
        $scope,
        $location,
        $http
    ) {


        $scope.recipe = {};
        $scope.products = [];
        $scope.addedProducts = [];
        $scope.newProduct = {};

        $scope.createRecipe = function () {
            $http.post('/api/recipes', $scope.recipe).then(function (response) {
                alert('Przepis został dodany');
            }, function () {
                alert('Przepis nie został dodany');
            })
        }


        $http.get('/api/products').then(function (response) {
            $scope.products = response.data;
        }, function () {
            alert('error');
            })

        $scope.getProductById = function (id) {
            return $scope.products.find(function (product) {
                return product.Id == id;
            })
        }

        $scope.addProduct = function () {
            var product = $scope.getProductById($scope.newProduct.Id);
            debugger;
        }

    }
])