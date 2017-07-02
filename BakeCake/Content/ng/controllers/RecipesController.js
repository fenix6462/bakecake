angular.module('app').controller('RecipesController', [
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


        $scope.isRecipesFetchInProgress = true;
        $scope.recipes = [];

        $http.get('/api/recipes').then(function (response) {
            $scope.recipes = response.data;
            $scope.isRecipesFetchInProgress = false;
        }, function () {
            $ngBootbox.alert('Wystąpił błąd podczas ładowania przepisów');
            $scope.isRecipesFetchInProgress = false;
        })

        $scope.deleteRecipe = function (recipe) {
            recipe.isDeletingInProgress = true;
            var recipeIndex = $scope.recipes.indexOf(recipe);
            $http.delete('/api/recipes/' + recipe.Id).then(function (response) {
                $scope.recipes.splice(recipeIndex, 1);
                recipe.isDeletingInProgress = false;
            }, function () {
                $ngBootbox.alert('Wystąpił błąd podczas usuwania przepisu');
                recipe.isDeletingInProgress = false;
            })
        }

    }
])