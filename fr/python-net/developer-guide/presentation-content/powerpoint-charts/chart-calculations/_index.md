---
title: Calculs de Graphiques
type: docs
weight: 50
url: /fr/python-net/chart-calculations/
keywords: "Calculs de graphiques, éléments de graphique, position des éléments, valeurs de graphique Python, Aspose.Slides pour Python via .NET"
description: "Calculs et valeurs de graphiques PowerPoint en Python"
---

## **Calculer les Valeurs Réelles des Éléments de Graphique**
Aspose.Slides pour Python via .NET fournit une API simple pour obtenir ces propriétés. Cela vous aidera à calculer les valeurs réelles des éléments de graphique. Les valeurs réelles comprennent la position des éléments qui implémentent l'interface IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) et les valeurs réelles des axes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **Calculer la Position Réelle des Éléments de Graphique Parent**
Aspose.Slides pour Python via .NET fournit une API simple pour obtenir ces propriétés. Les propriétés de IActualLayout fournissent des informations sur la position réelle de l'élément de graphique parent. Il est nécessaire d'appeler la méthode IChart.ValidateChartLayout() au préalable pour remplir les propriétés avec les valeurs réelles.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **Masquer les Informations d'un Graphique**
Ce sujet vous aide à comprendre comment masquer des informations d'un graphique. En utilisant Aspose.Slides pour Python via .NET, vous pouvez masquer **Titre, Axe Vertical, Axe Horizontal** et **Lignes de Grille** d'un graphique. L'exemple de code ci-dessous montre comment utiliser ces propriétés.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Masquer le Titre du graphique
    chart.has_title = False

    # Masquer l'axe des valeurs
    chart.axes.vertical_axis.is_visible = False

    # Visibilité de l'Axe des Catégories
    chart.axes.horizontal_axis.is_visible = False

    # Masquer la Légende
    chart.has_legend = False

    # Masquer les Lignes de Grille Principales
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Définir la couleur de la ligne de la série
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```