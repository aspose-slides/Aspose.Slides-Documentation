---
title: Créer des graphiques de présentation PowerPoint en Python
linktitle: Créer un graphique
type: docs
weight: 10
url: /fr/python-net/create-chart/
keywords: "Créer un graphique, graphique éparpillé, graphique à secteurs, graphique en arbre, graphique boursier, graphique en boîte et moustaches, graphique histogramme, graphique en entonnoir, graphique en éclat, graphique multicatégorie, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer un graphique dans une présentation PowerPoint en Python"
---

## **Créer un Graphique**

Les graphiques aident les gens à visualiser rapidement les données et à obtenir des informations qui peuvent ne pas être immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi Créer des Graphiques ?**

En utilisant des graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d'une présentation
* exposer des modèles et des tendances dans les données
* déduire la direction et l'élan des données au fil du temps ou par rapport à une unité de mesure spécifique
* repérer des valeurs aberrantes, des aberrations, des écarts, des erreurs, des données nonsensiques, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction d'insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. En utilisant Aspose.Slides, vous pouvez créer des graphiques réguliers (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit l'énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) sous l'espace de noms [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Les membres de cette énumération correspondent à différents types de graphiques.

{{% /alert %}} 

### **Créer des Graphiques Normaux**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données et spécifiez le type de graphique de votre choix.
1. Ajoutez un titre pour le graphique.
1. Accédez à la feuille de calcul des données du graphique.
1. Effacez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Ajoutez une couleur de remplissage pour les séries de graphiques.
1. Ajoutez des étiquettes pour les séries de graphiques.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un graphique normal :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation() as pres:

    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Ajouter un graphique avec des données par défaut
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # Définir le titre du graphique
    chart.chart_title.add_text_frame_for_overriding("Titre Exemple")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Définir la première série pour afficher les valeurs
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Définir l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtenir la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Supprimer les séries et catégories générées par défaut
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # Ajouter de nouvelles séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.type)

    # Ajouter de nouvelles catégories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Catégorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Catégorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Catégorie 3"))

    # Prendre la première série de graphiques
    series = chart.chart_data.series[0]

    # Maintenant, peupler les données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Définir la couleur de remplissage pour la série
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # Prendre la deuxième série de graphiques
    series = chart.chart_data.series[1]

    # Maintenant, peupler les données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Définir la couleur de remplissage pour la série
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # La première étiquette affichera le nom de la catégorie
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # Afficher la valeur pour la troisième étiquette
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # Enregistrer la présentation avec le graphique
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des Graphiques Éparpillés**
Les graphiques éparpillés (également connus sous le nom de graphiques éparpillés ou graphiques x-y) sont souvent utilisés pour rechercher des motifs ou démontrer des corrélations entre deux variables.

Vous pourriez vouloir utiliser un graphique éparpillé lorsque 

* vous avez des données numériques appariées
* vous avez 2 variables qui s'aparient bien ensemble
* vous souhaitez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui a plusieurs valeurs pour une variable dépendante

Ce code Python vous montre comment créer des graphiques éparpillés avec une série de marqueurs différente : 

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # Créez le graphique par défaut
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # Obtenez l'index de la feuille de données du graphique par défaut
    defaultWorksheetIndex = 0

    # Obtenez la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Supprimer la série de démonstration
    chart.chart_data.series.clear()

    # Ajouter de nouvelles séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "Série 2"), chart.type)

    # Prenez la première série de graphiques
    series = chart.chart_data.series[0]

    # Ajoutez un nouveau point (1:3) ici.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # Ajoutez un nouveau point (2:10)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # Modifiez le type de série
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Changer le marqueur de la série graphique
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Prenez la deuxième série de graphiques
    series = chart.chart_data.series[1]

    # Ajoutez un nouveau point (5:2) ici.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # Ajoutez un nouveau point (3:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # Ajoutez un nouveau point (2:2)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # Ajoutez un nouveau point (5:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # Changer le marqueur de la série graphique
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques à Secteurs**

Les graphiques à secteurs sont mieux utilisés pour montrer la relation partie-tout dans les données, en particulier lorsque les données contiennent des étiquettes catégoriques avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou étiquettes, vous pourriez vouloir envisager d'utiliser un graphique à barres à la place.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.PIE`).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Ajoutez de nouveaux points pour les graphiques et ajoutez des couleurs personnalisées pour les secteurs du graphique à secteurs.
1. Définissez des étiquettes pour les séries.
1. Définissez les lignes de repère pour les étiquettes des séries.
1. Définissez l'angle de rotation pour les secteurs du graphique à secteurs.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique à secteurs :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation() as presentation:

    # Accéder à la première diapositive
    slide = presentation.slides[0]

    # Ajouter un graphique avec des données par défaut
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Définir le Titre du graphique
    chart.chart_title.add_text_frame_for_overriding("Titre Exemple")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Définir la première série pour afficher les valeurs
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Définir l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtenir la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Supprimer les séries et catégories générées par défaut
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Ajouter de nouvelles catégories
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Premier Trimestre"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2ème Trimestre"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3ème Trimestre"))

    # Ajouter une nouvelle série
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Série 1"), chart.type)

    # Maintenant, peupler les données de série
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Ne fonctionne pas dans la nouvelle version
    # Ajouter de nouveaux points et définir la couleur du secteur
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # Définir la bordure du Secteur
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Définir la bordure du Secteur
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Définir la bordure du Secteur
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Créer des étiquettes personnalisées pour chacune des catégories pour la nouvelle série
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # Affichage des Lignes de Repère pour le Graphique
    series.labels.default_data_label_format.show_leader_lines = True

    # Définir l'angle de rotation pour les secteurs du graphique à secteurs
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Enregistrer la présentation avec le graphique
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques Linéaires**

Les graphiques linéaires (également connus sous le nom de graphiques linéaires) sont mieux utilisés dans des situations où vous souhaitez démontrer des changements de valeur au fil du temps. En utilisant un graphique linéaire, vous pouvez comparer de nombreuses données à la fois, suivre les changements et les tendances au fil du temps, mettre en évidence des anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Line`).
1. Accédez aux données du graphique [IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/).
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique en ligne : 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Par défaut, les points sur un graphique linéaire sont reliés par des lignes continues droites. Si vous voulez que les points soient reliés par des tirets à la place, vous pouvez spécifier votre type de tiret préféré de cette manière : 

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **Créer des Graphiques en Arbre**

Les graphiques en arbre sont mieux utilisés pour les données de vente lorsque vous souhaitez montrer la taille relative des catégories de données et (en même temps) attirer rapidement l'attention sur les éléments qui contribuent de manière significative à chaque catégorie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.TREEMAP`).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique en arbre :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branche 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Feuille1"))
    leaf.grouping_levels.set_grouping_item(1, "Tige1")
    leaf.grouping_levels.set_grouping_item(2, "Branche1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Feuille2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Feuille3"))
    leaf.grouping_levels.set_grouping_item(1, "Tige2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Feuille4"))


    #branche 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Feuille5"))
    leaf.grouping_levels.set_grouping_item(1, "Tige3")
    leaf.grouping_levels.set_grouping_item(2, "Branche2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Feuille6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Feuille7"))
    leaf.grouping_levels.set_grouping_item(1, "Tige4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Feuille8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des Graphiques Boursiers**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.OPEN_HIGH_LOW_CLOSE).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Spécifiez le format HiLowLines.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Code Python d'exemple utilisé pour créer un graphique boursier :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "Ouvert"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "Haut"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "Bas"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "Fermé"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des Graphiques en Boîte et Moustaches**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.BOX_AND_WHISKER).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique en boîte et moustaches :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Catégorie 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des Graphiques en Entonnoir**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.Funnel).
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique en entonnoir :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Catégorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Catégorie 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Catégorie 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Catégorie 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Catégorie 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Catégorie 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques en Éclat**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.SUNBURST`).
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique en éclat :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branche 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Feuille1"))
    leaf.grouping_levels.set_grouping_item(1, "Tige1")
    leaf.grouping_levels.set_grouping_item(2, "Branche1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Feuille2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Feuille3"))
    leaf.grouping_levels.set_grouping_item(1, "Tige2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Feuille4"))

    #branche 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Feuille5"))
    leaf.grouping_levels.set_grouping_item(1, "Tige3")
    leaf.grouping_levels.set_grouping_item(2, "Branche2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Feuille6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Feuille7"))
    leaf.grouping_levels.set_grouping_item(1, "Tige4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Feuille8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des Graphiques Histogrammes**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index. 
1. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré (dans ce cas, `ChartType.HISTOGRAM`).
1. Accédez aux données du graphique `IChartDataWorkbook`.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique histogramme :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques Radar**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtenez une référence de diapositive par son index. 
1. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré (`ChartType.RADAR` dans ce cas).
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique radar :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques Multicatégorie**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.ClusteredColumn).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment créer un graphique multicatégorie :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Groupe1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Groupe2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Groupe3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Groupe4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # Ajouter des Séries
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "Série 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # Enregistrer la présentation avec le graphique
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques Cartes**

Un graphique de carte est une visualisation d'une zone contenant des données. Les graphiques de carte sont particulièrement utiles pour comparer des données ou des valeurs à travers des régions géographiques.

Ce code Python vous montre comment créer un graphique de carte :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Créer des Graphiques de Combinaison**

Un graphique de combinaison (ou graphique combo) est un graphique qui combine deux ou plusieurs graphiques sur un seul graphique. Un tel graphique vous permet de mettre en évidence, de comparer ou de passer en revue les différences entre deux (ou plusieurs) ensembles de données. De cette manière, vous voyez la relation (le cas échéant) entre les ensembles de données. 

![combination-chart-ppt](combination-chart-ppt.png)

Ce code Python vous montre comment créer un graphique de combinaison dans PowerPoint :

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Série 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Série 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Catégorie 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Catégorie 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Catégorie 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Série 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Série 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **Mettre à Jour les Graphiques**

1. Instancier une classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui représente la présentation contenant le graphique.
2. Obtenez une référence de diapositive par son index.
3. Parcourez toutes les formes pour trouver le graphique désiré.
4. Accédez à la feuille de calcul des données du graphique.
5. Modifiez les données de la série de graphique en changeant les valeurs de la série.
6. Ajoutez une nouvelle série et peuplez les données dans celle-ci.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment mettre à jour un graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Ajouter un graphique avec des données par défaut
    chart = sld.shapes[0]

    # Définir l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtenir la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook


    # Modifier le Nom de la Catégorie du graphique
    fact.get_cell(defaultWorksheetIndex, 1, 0, "Catégorie Modifiée 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "Catégorie Modifiée 2")


    # Prendre la première série de graphiques
    series = chart.chart_data.series[0]

    # Maintenant mettre à jour les données de la série
    fact.get_cell(defaultWorksheetIndex, 0, 1, "Nouvelle_Série1")# Modifier le nom de la série
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # Prendre la deuxième série de graphiques
    series = chart.chart_data.series[1]

    # Maintenant mettre à jour les données de la série
    fact.get_cell(defaultWorksheetIndex, 0, 2, "Nouvelle_Série2")# Modifier le nom de la série
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # Maintenant, Ajouter une nouvelle série
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "Série 3"), chart.type)

    # Prendre la 3ème série de graphiques
    series = chart.chart_data.series[2]

    # Maintenant peupler les données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # Enregistrer la présentation avec le graphique
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Plage de Données pour les Graphiques**

1. Instancier une classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui représente la présentation contenant le graphique.
2. Obtenez une référence de diapositive par son index.
3. Parcourez toutes les formes pour trouver le graphique désiré.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment définir la plage de données pour un graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Accéder à la première diapositive et ajouter un graphique avec des données par défaut
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **Utiliser des Marqueurs par Défaut dans les Graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série de graphique obtient automatiquement différents symboles de marqueur par défaut.

Ce code Python vous montre comment définir automatiquement un marqueur de série dans un graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Série 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "Série 2"), chart.type)
    #Prendre la deuxième série de graphiques
    series2 = chart.chart_data.series[1]

    #Maintenant peupler les données de la série
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```