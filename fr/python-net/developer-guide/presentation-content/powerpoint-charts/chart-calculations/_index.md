---
title: Optimiser les calculs de graphiques pour les présentations en Python
linktitle: Calculs de graphiques
type: docs
weight: 50
url: /fr/python-net/chart-calculations/
keywords:
- calculs de graphiques
- éléments de graphique
- position de l'élément
- position réelle
- élément enfant
- élément parent
- valeurs de graphique
- valeur réelle
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Comprendre les calculs de graphiques, les mises à jour de données et le contrôle de précision dans Aspose.Slides pour Python via .NET pour PPT, PPTX et ODP, avec des exemples de code pratiques."
---

## **Calculer les valeurs réelles des éléments du graphique**
Aspose.Slides for Python via .NET fournit une API simple pour obtenir ces propriétés. Cela vous aide à calculer les valeurs réelles des éléments du graphique. Les valeurs réelles comprennent la position des éléments qui héritent de la classe [IActualLayout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) et les valeurs réelles des axes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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


## **Calculer la position réelle des éléments graphiques parents**
Aspose.Slides for Python via .NET fournit une API simple pour obtenir ces propriétés. Les propriétés de IActualLayout fournissent des informations sur la position réelle de l'élément graphique parent. Il est nécessaire d'appeler la méthode IChart.ValidateChartLayout() au préalable pour remplir les propriétés avec les valeurs réelles.
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


## **Masquer les informations du graphique**
Ce sujet vous aide à comprendre comment masquer des informations du graphique. En utilisant Aspose.Slides for Python via .NET, vous pouvez masquer le **Titre, Axe vertical, Axe horizontal** et les **Lignes de grille** du graphique. L'exemple de code ci‑dessous montre comment utiliser ces propriétés.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Masquage du titre du graphique
    chart.has_title = False

    # Masquage de l'axe des valeurs
    chart.axes.vertical_axis.is_visible = False

    # Visibilité de l'axe des catégories
    chart.axes.horizontal_axis.is_visible = False

    # Masquage de la légende
    chart.has_legend = False

    # Masquage des lignes de grille majeures
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


## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous connectez ou actualisez la source externe, les formules et les valeurs sont prises à partir de ce classeur, et le graphique reflète les mises à jour pendant les opérations d'ouverture/édition. L'API vous permet de [specify the external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) le chemin et de gérer les données liées.

**Can I compute and display trendlines without implementing regression myself?**

Oui. Les [Trendlines](/slides/fr/python-net/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n'avez donc pas besoin d'implémenter vos propres calculs.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Oui. Chaque graphique peut pointer vers son propre [external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), ou vous pouvez créer/remplacer un classeur externe par graphique indépendamment des autres.