angular.module('app').controller('RecipesController', [
    '$scope',
    '$location',
    '$http',
    function (
        $scope,
        $location,
        $http
    ) {


        $scope.recipes = [];

        $http.get('/api/recipes').then(function (response) {
            $scope.recipes = response.data;
            console.log($scope.recipes);
        }, function () {
            alert('error');
        })

    }
])