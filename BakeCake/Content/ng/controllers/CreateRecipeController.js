angular.module('app').controller('CreateRecipeController', [
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


        $scope.recipe = {
            RecipeProducts: []
        };
        $scope.products = [];
        $scope.addedProducts = [];
        $scope.newProduct = {};

        $scope.createRecipe = function () {
            $http.post('/api/recipes', $scope.recipe).then(function (response) {
                $ngBootbox.alert('Przepis został dodany');
                $location.path("/recipes");
            }, function () {
                $ngBootbox.alert('Wystąpił błąd podczas dodawania przepisu');
            })
        }


        $http.get('/api/products').then(function (response) {
            $scope.products = response.data;
        }, function () {
            $ngBootbox.alert('Wystąpił błąd podczas pobierania listy produktów');
        })
         
        $scope.getProductByName = function (name) {
            return $scope.products.find(function (product) {
                return product.Name === name;
            })
        }

        $scope.addProduct = function () {
            var element = {};
            var product = $scope.getProductByName($scope.newProduct.Name);
            element.Weight = $scope.newProduct.Weight;
            element.Name = $scope.newProduct.Name;
            element.newPrice = product.Price * element.Weight / product.Weight;
            $scope.recipe.RecipeProducts.push(element);
            $scope.newProduct.Weight = 0;
            $scope.newProduct.Name = null;
        }

    }
])