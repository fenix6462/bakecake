angular.module('app').config([
    '$routeProvider',
    '$locationProvider',
    function (
        $routeProvider,
        $locationProvider
    ) {

        $locationProvider.html5Mode(true).hashPrefix('');

        $routeProvider
            .when("/", {
                templateUrl: "app/Recipes/Index",
                controller: "RecipesController"
            })
            .when("/recipes", {
                templateUrl: "app/Recipes/Index",
                controller: "RecipesController"
            })
            .when("/recipes/create", {
                templateUrl: "app/Recipes/Create",
                controller: "CreateRecipeController"
            })
            .when("/recipes/:id", {
                templateUrl: "app/Recipes/Details",
            })
            .when("/products", {
                templateUrl: "app/Products/Index",
                controller: "ProductsController"
            })
            .when("/products/create", {
                templateUrl: "app/Products/Create",
                controller: "CreateProductController"
            })
            .when("/products/:id", {
                templateUrl: "app/Products/Details"
            })
            .when("/error404", {
                templateUrl: "app/Home/Error404"
            })
            .otherwise({
                redirectTo: '/'
            });

    }]);