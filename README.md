# graph_components_umbraco_navigation_block
Graph Umbraco Components Navigation block

Installation steps:
1. Install Configs loader https://github.com/graphuk/graph_components_umbraco_config_loader
2. Copy the folder 'Navigation' to 'Components'
3. Use it: @Html.Action("Index", "NavigationSurface")

Default settings:
In the NavigationConfig you can find two fields: HomePageAlias and HideFromNavigationPropertyAlias
HomePageAlias - alias of your document type
HideFromNavigationPropertyAlias - property to hide from navigation