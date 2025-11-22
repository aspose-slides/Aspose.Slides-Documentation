---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en Python
linktitle: Créer ou mettre à jour un graphique
type: docs
weight: 10
url: /fr/python-net/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique en nuage de points
- graphique circulaire
- graphique en courbes
- graphique en carte d'arbre
- graphique boursier
- graphique à boîte et moustaches
- graphique en entonnoir
- graphique en rayons
- graphique à histogramme
- graphique radar
- graphique multicatégorie
- présentation PowerPoint
- Python
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET. Il couvre l'ajout, la mise en forme et la modification de graphiques dans les présentations avec des exemples de code pratiques en Python."
---

## **Vue d’ensemble**

Cet article fournit un guide complet sur la création et la personnalisation de graphiques avec Aspose.Slides for Python via .NET. Vous apprendrez à ajouter programmatiquement un graphique à une diapositive, le remplir avec des données et appliquer diverses options de mise en forme pour répondre à vos exigences de conception spécifiques. Tout au long de l’article, des exemples de code détaillés illustrent chaque étape, de l’initialisation de la présentation et de l’objet graphique à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une solide compréhension de l’intégration de la génération dynamique de graphiques dans vos applications, simplifiant le processus de création de présentations basées sur les données.

## **Créer un graphique**

Les graphiques aident les gens à visualiser rapidement les données et à obtenir des insights qui ne sont pas immédiatement évidents dans un tableau ou une feuille de calcul.

**Pourquoi créer des graphiques ?**

Avec les graphiques, vous pouvez :

* agrandir, condenser ou résumer de grandes quantités de données sur une seule diapositive ;
* révéler des motifs et des tendances dans les données ;
* déduire la direction et l’élan des données dans le temps ou par rapport à une unité de mesure spécifique ;
* repérer les valeurs aberrantes, erreurs et données incohérentes ;
* communiquer ou présenter des données complexes.

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insert*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques classiques (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="primary" %}} 
Utilisez l’énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) du namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Les valeurs de cette énumération correspondent à différents types de graphiques.
{{% /alert %}} 

### **Créer des graphiques à colonnes groupées**

Cette section explique comment créer des graphiques à colonnes groupées avec Aspose.Slides for Python via .NET. Vous apprendrez à initialiser une présentation, ajouter un graphique et personnaliser ses éléments tels que le titre, les données, les séries, les catégories et le style. Suivez les étapes ci‑dessous pour voir comment un graphique à colonnes groupées standard est généré :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec certaines données et spécifiez le type `ChartType.CLUSTERED_COLUMN`.  
1. Ajoutez un titre au graphique.  
1. Accédez à la feuille de données du graphique.  
1. Supprimez toutes les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Appliquez une couleur de remplissage aux séries.  
1. Ajoutez des libellés aux séries.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique à colonnes groupées :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec ses données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Définir le titre du graphique.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Configurer la première série pour afficher les valeurs.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Définir l'index de la feuille de données du graphique.
    worksheet_index = 0

    # Obtenir le classeur de données du graphique.
    workbook = chart.chart_data.chart_data_workbook

    # Supprimer les séries et catégories générées par défaut.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Ajouter de nouvelles séries.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Ajouter de nouvelles catégories.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Obtenir la première série du graphique.
    series = chart.chart_data.series[0]

    # Remplir les données de la série.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Définir la couleur de remplissage pour la série.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Obtenir la deuxième série du graphique.
    series = chart.chart_data.series[1]

    # Remplir les données de la série.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Définir la couleur de remplissage pour la série.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Définir la première étiquette pour afficher le nom de la catégorie.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Définir la série pour afficher la valeur de la troisième étiquette.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Enregistrer la présentation sur le disque en tant que fichier PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```



Le résultat :

![Le graphique à colonnes groupées](clustered_column_chart.png)

### **Créer des graphiques en nuage de points**

Les graphiques en nuage de points (aussi appelés scatter plots ou graphiques x‑y) sont souvent utilisés pour rechercher des motifs ou démontrer des corrélations entre deux variables.

Utilisez un graphique en nuage de points lorsque :

* Vous avez des données numériques appariées.  
* Vous avez deux variables qui se combinent bien.  
* Vous souhaitez déterminer si les deux variables sont liées.  
* Vous avez une variable indépendante avec plusieurs valeurs pour une variable dépendante.

Ce code Python montre comment créer un graphique en nuage de points avec une série de marqueurs différents :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Créer le graphique en nuage de points par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Définir l'index de la feuille de données du graphique.
    worksheet_index = 0

    # Obtenir le classeur de données du graphique.
    workbook = chart.chart_data.chart_data_workbook

    # Supprimer les séries par défaut.
    chart.chart_data.series.clear()

    # Ajouter de nouvelles séries.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Obtenir la première série du graphique.
    series = chart.chart_data.series[0]

    # Ajouter un nouveau point (1:3) à la série.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Ajouter un nouveau point (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Modifier le type de série.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Modifier le marqueur de la série du graphique.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Obtenir la deuxième série du graphique.
    series = chart.chart_data.series[1]

    # Ajouter un nouveau point (5:2) à la série du graphique.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Ajouter un nouveau point (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Ajouter un nouveau point (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Ajouter un nouveau point (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Modifier le marqueur de la série du graphique.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique en nuage de points](scatter_chart.png)

### **Créer des graphiques circulaires**

Les graphiques circulaires sont idéaux pour illustrer la relation partie‑à‑tout dans des données, notamment lorsque les données contiennent des libellés catégoriels avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou libellés, il peut être préférable d’utiliser un graphique à barres.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.PIE`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Ajoutez de nouveaux points au graphique et appliquez des couleurs personnalisées aux secteurs du graphique circulaire.  
1. Définissez les libellés pour les séries.  
1. Activez les lignes de repère pour les libellés des séries.  
1. Définissez l’angle de rotation du graphique circulaire.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique circulaire :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter un graphique avec ses données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Définir le titre du graphique.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Définir la première série pour afficher les valeurs.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Définir l'index de la feuille de données du graphique.
    worksheet_index = 0

    # Obtenir le classeur de données du graphique.
    workbook = chart.chart_data.chart_data_workbook

    # Supprimer les séries et catégories générées par défaut.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Ajouter de nouvelles catégories.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Ajouter de nouvelles séries.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Remplir les données de la série.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Définir la couleur du secteur.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Définir la bordure du secteur.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Définir la bordure du secteur.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Définir la bordure du secteur.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Créer des libellés personnalisés pour chaque catégorie de la nouvelle série.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Définir la série pour afficher les lignes de repère pour le graphique.
    series.labels.default_data_label_format.show_leader_lines = True

    # Définir l'angle de rotation des secteurs du graphique circulaire.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Enregistrer la présentation sur le disque en tant que fichier PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique circulaire](pie_chart.png)

### **Créer des graphiques en courbes**

Les graphiques en courbes (ou graphiques linéaires) sont idéaux pour montrer l’évolution d’une valeur dans le temps. Avec un graphique en courbes, vous pouvez comparer de grandes quantités de données, suivre les changements et les tendances, mettre en évidence des anomalies dans les séries, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.LINE`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique en courbes :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


Par défaut, les points d’un graphique en courbes sont reliés par des lignes droites continues. Si vous préférez des tirets, spécifiez le type de tiret souhaité comme suit :
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


Le résultat :

![Le graphique en courbes](line_chart.png)

### **Créer des graphiques en carte d’arbre**

Les graphiques en carte d’arbre sont idéaux pour les données commerciales lorsque vous souhaitez afficher la taille relative des catégories et attirer rapidement l’attention sur les éléments qui contribuent le plus dans chaque catégorie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.TREEMAP`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique en carte d’arbre :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Branche 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Branche 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique en carte d’arbre](treemap_chart.png)

### **Créer des graphiques boursiers**

Les graphiques boursiers affichent des données financières telles que les prix d’ouverture, haut, bas et clôture, aidant à analyser les tendances du marché et la volatilité. Ils offrent des informations essentielles sur la performance des actions, facilitant les décisions éclairées des investisseurs et des analystes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.OPEN_HIGH_LOW_CLOSE`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Spécifiez le format HiLowLines.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique boursier :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique boursier](stock_chart.png)

### **Créer des graphiques à boîte et moustaches**

Les graphiques à boîte et moustaches affichent la distribution des données en résumant des mesures statistiques clés, telles que la médiane, les quartiles et les valeurs aberrantes potentielles. Ils sont très utiles en analyse exploratoire et en études statistiques pour comprendre rapidement la variabilité des données et identifier d’éventuelles anomalies.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.BOX_AND_WHISKER`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique à boîte et moustaches :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **Créer des graphiques en entonnoir**

Les graphiques en entonnoir servent à visualiser des processus comportant des étapes séquentielles, où le volume de données diminue à chaque étape. Ils sont particulièrement utiles pour analyser les taux de conversion, identifier les goulots d’étranglement et suivre l’efficacité des processus de vente ou de marketing.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.FUNNEL`.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique en entonnoir :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique en entonnoir](funnel_chart.png)

### **Créer des graphiques en rayons**

Les graphiques en rayons visualisent des données hiérarchiques en affichant les niveaux sous forme d’anneaux concentriques. Ils illustrent les relations partie‑à‑tout et sont idéaux pour représenter des catégories imbriquées de façon claire et compacte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.SUNBURST`.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique en rayons :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Branche 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Branche 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique en rayons](sunburst_chart.png)

### **Créer des graphiques à histogramme**

Les graphiques à histogramme représentent la distribution de données numériques en regroupant les valeurs en intervalles. Ils permettent d’identifier des motifs tels que la fréquence, l’asymétrie et l’étendue, ainsi que de détecter des valeurs aberrantes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec certaines données et spécifiez le type `ChartType.HISTOGRAM`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique à histogramme :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique à histogramme](histogram_chart.png)

### **Créer des graphiques radar**

Les graphiques radar affichent des données multivariées en deux dimensions, permettant une comparaison facile de plusieurs variables simultanément. Ils sont particulièrement utiles pour identifier des motifs, forces et faiblesses sur plusieurs indicateurs de performance.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec certaines données et spécifiez le type `ChartType.RADAR`.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique radar :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique radar](radar_chart.png)

### **Créer des graphiques multi‑catégories**

Les graphiques multi‑catégories affichent des données impliquant plusieurs regroupements catégoriels, vous permettant de comparer des valeurs sur plusieurs dimensions simultanément. Ils sont particulièrement utiles pour analyser les tendances et relations dans des ensembles de données complexes et multi‑niveaux.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Ajoutez un graphique avec les données par défaut et spécifiez le type `ChartType.CLUSTERED_COLUMN`.  
1. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. Supprimez les séries et catégories par défaut.  
1. Ajoutez de nouvelles séries et catégories.  
1. Ajoutez de nouvelles données de graphique pour les séries.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment créer un graphique multi‑catégorie :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Ajouter une série.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Enregistrer la présentation avec le graphique.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique multi‑catégorie](multi_category_chart.png)

### **Créer des graphiques cartographiques**

Les graphiques cartographiques visualisent des données géographiques en associant les informations à des emplacements spécifiques (pays, États, villes). Ils sont utiles pour analyser les tendances régionales, les données démographiques et les répartitions spatiales de manière claire et attrayante.

Ce code Python montre comment créer un graphique cartographique :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le graphique cartographique](map_chart.png)

### **Créer des graphiques combinés**

Un graphique combiné (ou combo) regroupe deux types de graphiques ou plus dans un même diagramme. Ce type de graphique vous permet de mettre en évidence, comparer ou analyser les différences entre plusieurs ensembles de données, facilitant l’identification des relations entre eux.

![Le graphique combiné](combination_chart.png)

Ce code Python montre comment créer un graphique combiné dans une présentation PowerPoint :
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

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

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **Mettre à jour les graphiques**

Aspose.Slides for Python via .NET vous permet de mettre à jour les graphiques PowerPoint en modifiant les données, la mise en forme et le style. Cette fonctionnalité simplifie la mise à jour des présentations avec du contenu dynamique et garantit que les graphiques reflètent fidèlement les données et les normes visuelles actuelles.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui représente la présentation contenant le graphique.  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Parcourez toutes les formes pour trouver le graphique.  
1. Accédez à la feuille de données du graphique.  
1. Modifiez les séries de données du graphique en changeant les valeurs des séries.  
1. Ajoutez une nouvelle série et remplissez‑la avec des données.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment mettre à jour un graphique :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Définir l'index de la feuille de données du graphique.
            worksheet_index = 0

            # Obtenir le classeur de données du graphique.
            workbook = chart.chart_data.chart_data_workbook

            # Modifier les noms des catégories du graphique.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Obtenir la première série du graphique.
            series = chart.chart_data.series[0]

            # Mettre à jour les données de la série.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Modification du nom de la série.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Obtenir la deuxième série du graphique.
            series = chart.chart_data.series[1]

            # Mettre à jour les données de la série.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Modification du nom de la série.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Ajouter une nouvelle série.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Remplir les données de la série.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Enregistrer la présentation avec le graphique.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la plage de données pour les graphiques**

Aspose.Slides for Python via .NET offre la flexibilité de définir une plage de données spécifique d’une feuille de calcul comme source pour les données du graphique. Ainsi, vous pouvez mapper directement une portion de votre feuille aux séries et catégories du graphique, ce qui facilite la mise à jour et la synchronisation avec les dernières modifications de données.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui représente la présentation contenant le graphique.  
1. Obtenez une référence à une diapositive à l’aide de son index.  
1. Parcourez toutes les formes pour trouver le graphique.  
1. Accédez aux données du graphique et définissez la plage.  
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python montre comment définir la plage de données d’un graphique :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **Utiliser des marqueurs par défaut dans les graphiques**

Lorsque vous utilisez des marqueurs par défaut, chaque série du graphique reçoit automatiquement un symbole de marqueur différent.

Ce code Python montre comment définir automatiquement un marqueur de série de graphique :
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Remplir les données de la série.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides for Python via .NET ?**

Aspose.Slides for Python via .NET prend en charge un large éventail de types de graphiques, notamment les graphiques à barres, en lignes, circulaires, en aires, en nuage de points, à histogramme, radar et bien d’autres. Cette flexibilité vous permet de choisir le type le plus adapté à vos besoins de visualisation.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), récupérez la diapositive souhaitée à l’aide de son index, puis appelez la méthode d’ajout de graphique en précisant le type de graphique et les données initiales. Le graphique est alors intégré directement à votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Ainsi, le graphique est rafraîchi programmatiquement avec les dernières informations.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides for Python via .NET offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres éléments de mise en forme pour adapter l’apparence du graphique à vos exigences de conception spécifiques.