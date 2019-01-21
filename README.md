# graph_components_umbraco_navigation_block
Graph Umbraco Components Navigation block

Installation steps:
1. Copy the folder 'Navigation' to 'Components'
2. Use it: @Html.Action("Index", "NavigationSurface")

Default settings:
In the NavigationConfig you can find two fields: HomePageAlias and HideFromNavigationPropertyAlias
HomePageAlias - alias of your document type
HideFromNavigationPropertyAlias - property to hide from navigation