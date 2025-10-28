---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en Python
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique Treemap
- graphique Sunburst
- point de données
- couleur d'étiquette
- couleur de branche
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment gérer les points de données dans les graphiques Treemap et Sunburst avec Aspose.Slides pour Python via .NET, compatible avec les formats PowerPoint et OpenDocument."
---

## **Introduction**

Parmi les autres types de graphiques PowerPoint, il existe deux graphiques hiérarchiques — **Treemap** et **Sunburst** (également appelés Graphique Sunburst, Diagramme Sunburst, Graphique radial, Diagramme radial ou Graphique à secteurs multi‑niveaux). Ces graphiques affichent des données hiérarchiques organisées comme un arbre — des feuilles jusqu’au sommet d’une branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides pour Python via .NET vous permet de formater les points de données des graphiques Sunburst et Treemap en Python.

Voici un graphique Sunburst où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent des points de données hiérarchiques :

![Sunburst chart example](sunburst_example.png)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Voir aussi" %}}
- [**Créer des graphiques Sunburst**](/slides/fr/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Si vous devez formater les points de données du graphique, utilisez les API suivantes :

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) et la propriété [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Elles donnent accès au formatage des points de données dans les graphiques Treemap et Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) est utilisé pour accéder aux catégories à plusieurs niveaux ; il représente un conteneur d’objets [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). Il s’agit essentiellement d’un wrapper autour de [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) avec des propriétés supplémentaires spécifiques aux points de données. Le type [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) expose deux propriétés—[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) et [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)—qui donnent accès aux paramètres correspondants.

## **Afficher les valeurs des points de données**

Cette section montre comment afficher la valeur pour chaque point de données dans les graphiques Treemap et Sunburst. Vous verrez comment activer les étiquettes de valeur pour les points sélectionnés.

Afficher la valeur du point de données « Leaf 4 » :

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Définir les étiquettes et les couleurs des points de données**

Cette section montre comment définir des étiquettes et des couleurs personnalisées pour chaque point de données dans les graphiques Treemap et Sunburst. Vous apprendrez comment accéder à un point de données spécifique, lui attribuer une étiquette et appliquer un remplissage uni pour mettre en évidence les nœuds importants.

Définir l’étiquette du point de données « Branch 1 » pour afficher le nom de la série (« Series1 ») au lieu du nom de la catégorie, puis définir la couleur du texte en jaune :

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Définir les couleurs de branche pour les points de données**

Utilisez les couleurs de branche pour contrôler la façon dont les nœuds parents et enfants sont regroupés visuellement dans les graphiques Treemap et Sunburst. Cette section montre comment définir une couleur de branche personnalisée pour un point de données spécifique afin de mettre en évidence des sous‑arbres importants et d’améliorer la lisibilité du graphique.

Modifier la couleur de la branche « Stem 4 » :

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**Puis-je changer l'ordre (tri) des segments dans Sunburst/Treemap ?**

Non. PowerPoint trie les segments automatiquement (généralement par valeurs décroissantes, dans le sens des aiguilles d’une montre). Aspose.Slides reflète ce comportement : vous ne pouvez pas changer l'ordre directement ; vous devez le réaliser en pré‑traitant les données.

**Comment le thème de la présentation influence-t-il les couleurs des segments et des étiquettes ?**

Les couleurs du graphique héritent du [thème/palette](/slides/fr/python-net/presentation-theme/) de la présentation, sauf si vous définissez explicitement les remplissages ou les polices. Pour des résultats cohérents, verrouillez les remplissages solides et le formatage du texte aux niveaux requis.

**L'exportation vers PDF/PNG conservera-t-elle les couleurs de branche personnalisées et les paramètres d'étiquette ?**

Oui. Lors de l'exportation de la présentation, les paramètres du graphique (remplissages, étiquettes) sont conservés dans les formats de sortie parce qu'Aspose.Slides rend le graphique avec le formatage appliqué.

**Puis-je calculer les coordonnées réelles d'une étiquette/élément pour placer une superposition personnalisée sur le graphique ?**

Oui. Après que la mise en page du graphique a été validée, `actual_x`/`actual_y` sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), ce qui facilite le positionnement précis des superpositions.