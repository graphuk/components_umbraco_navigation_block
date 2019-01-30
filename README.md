# Graph Umbraco Components - Navigation block

## Installation steps:
1. Copy the folder 'Navigation' to 'Components' (for manual installation only, otherwise use Stamp tool)
2. Use it: @Html.Action("Index", "NavigationSurface")

## Settings
There are four fields in the NavigationConfig:
* HomePageId - set id of the homepage
* HideFromNavigationPropertyAlias - alias of the property which can be used to hide node from navigation
* NavigationDeepLevel - deep level of the navigation
* NavigationCacheKey - the key used to reference navigation model in the cache