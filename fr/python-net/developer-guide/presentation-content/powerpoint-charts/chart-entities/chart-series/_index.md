---
title: Séries de Graphiques
type: docs
url: /python-net/chart-series/
keywords: "Séries de graphiques, couleur de série, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Séries de graphiques dans des présentations PowerPoint en Python"
---

Une série est une ligne ou une colonne de nombres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le Chevauchement des Séries de Graphiques**

Avec la propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/), vous pouvez spécifier à quel point les barres et les colonnes doivent se chevaucher dans un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent : c'est une projection de la propriété de groupe appropriée. Par conséquent, cette propriété est en lecture seule.

Utilisez la propriété lisible/écrivable `parent_series_group.overlap` pour définir votre valeur préférée pour `overlap`.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série de graphiques.
1. Accédez au `parent_series_group` de la série de graphiques et définissez votre valeur de chevauchement préférée pour la série.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python vous montre comment définir le chevauchement pour une série de graphiques :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Ajoute un graphique
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Définit le chevauchement de la série
        series[0].parent_series_group.overlap = -30

    # Écrit le fichier de présentation sur le disque
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer la Couleur de la Série**
Aspose.Slides pour Python via .NET vous permet de changer la couleur d'une série de cette manière :

1. Créez une instance de la classe `Presentation`.
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrez la présentation modifiée.

Ce code Python vous montre comment changer la couleur d'une série :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[1]
    
    point.explosion = 30
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer la Couleur de la Catégorie de la Série**
Aspose.Slides pour Python via .NET vous permet de changer la couleur de la catégorie d'une série de cette manière :

1. Créez une instance de la classe `Presentation`.
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de la série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrez la présentation modifiée.

Ce code en Python vous montre comment changer la couleur d'une catégorie de série :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[0]
    
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer le Nom de la Série** 

Par défaut, les noms de légende pour un graphique sont les contenus des cellules au-dessus de chaque colonne ou ligne de données.

Dans notre exemple (image d'exemple), 

* les colonnes sont *Série 1, Série 2,* et *Série 3*;
* les lignes sont *Catégorie 1, Catégorie 2, Catégorie 3,* et *Catégorie 4.* 

Aspose.Slides pour Python via .NET vous permet de mettre à jour ou de changer un nom de série dans ses données de graphique et sa légende. 

Ce code Python vous montre comment changer le nom d'une série dans ses données de graphique `ChartDataWorkbook`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "Nouveau nom"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

Ce code Python vous montre comment changer un nom de série dans sa légende par le biais de `Series` :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "Nouveau nom"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **Définir la Couleur de Remplissage des Séries de Graphiques**

Aspose.Slides pour Python via .NET vous permet de définir la couleur de remplissage automatique pour les séries de graphiques à l'intérieur d'une zone de tracé de cette manière :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.CLUSTERED_COLUMN`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur Automatique.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Python vous montre comment définir la couleur de remplissage automatique pour une série de graphiques :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Crée un graphique à colonnes groupées
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Définit le format de remplissage de la série sur automatique
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Écrit le fichier de présentation sur le disque
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les Couleurs de Remplissage Inversées des Séries de Graphiques**
Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphiques à l'intérieur d'une zone de tracé de cette manière :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.CLUSTERED_COLUMN`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur inversée.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Python démontre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Ajoute de nouvelles séries et catégories
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Série 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Catégorie 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Catégorie 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Catégorie 3"))

    # Prend la première série de graphique et remplit ses données de série.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les Séries à Inverser Lorsque la Valeur est Négative**
Aspose.Slides vous permet de définir des inversions grâce aux propriétés `ChartDataPoint.invert_if_negative`. Lorsqu'une inversion est définie à l'aide des propriétés, le point de données inverse ses couleurs lorsqu'il reçoit une valeur négative.

Ce code Python démontre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    chart.chart_data.series.clear()

    series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

    series[0].invert_if_negative = False

    series[0].data_points[2].invert_if_negative = True

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Effacer les Données de Points de Données Spécifiques**
Aspose.Slides pour Python via .NET vous permet d'effacer les données de `data_points` pour une série de graphiques spécifique de cette manière :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive par son index.
3. Obtenez la référence d'un graphique par son index.
4. Itérez à travers tous les `data_points` du graphique et définissez `x_value` et `y_value` sur null.
5. Effacez tous les `data_points` pour des séries de graphiques spécifiques.
6. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Python démontre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Largeur de Gaps de la Série**
Aspose.Slides pour Python via .NET vous permet de définir la largeur de gaps d'une série grâce à la propriété **`gap_width`** de cette manière :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n'importe quelle série de graphiques.
1. Définissez la propriété `gap_width`.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code en Python vous montre comment définir la largeur de gap d'une série :

```py
# Crée une présentation vide 
with slides.Presentation() as presentation:

    # Accède à la première diapositive de la présentation
    slide = presentation.slides[0]

    # Ajoute un graphique avec des données par défaut
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Définit l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtient la feuille de travail des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Ajoute des séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.type)

    # Ajoute des Catégories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Catégorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Catégorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Catégorie 3"))

    # Prend la deuxième série de graphique
    series = chart.chart_data.series[1]

    # Remplit les données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Définit la valeur de GapWidth
    series.parent_series_group.gap_width = 50

    # Sauvegarde la présentation sur le disque
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```