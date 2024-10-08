---
title: Étiquette de Données du Graphique
type: docs
url: /fr/python-net/chart-data-label/
keywords: "Étiquette de données du graphique, distance de l'étiquette, Python, Aspose.Slides pour Python via .NET"
description: "Définir l'étiquette de données du graphique PowerPoint et la distance en Python"
---

Les étiquettes de données sur un graphique montrent des détails sur les séries de données du graphique ou des points de données individuels. Elles permettent aux lecteurs d'identifier rapidement les séries de données et rendent également les graphiques plus faciles à comprendre.

## **Définir la Précision des Données dans les Étiquettes de Données du Graphique**

Ce code Python vous montre comment définir la précision des données dans une étiquette de données de graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
	chart.has_data_table = True
	chart.chart_data.series[0].number_format_of_values = "#,##0.00"

	pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Afficher le Pourcentage comme Étiquettes**
Aspose.Slides pour Python via .NET vous permet de définir des étiquettes de pourcentage sur des graphiques affichés. Ce code Python démontre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# Sauvegarde la présentation contenant le graphique
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le Signe de Pourcentage avec les Étiquettes de Données du Graphique**
Ce code Python vous montre comment définir le signe de pourcentage pour une étiquette de données de graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation
with slides.Presentation() as presentation:

    # Obtient la référence d'un diapositive par son index
    slide = presentation.slides[0]

    # Crée le graphique PercentsStackedColumn sur une diapositive
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # Définit NumberFormatLinkedToSource sur faux
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # Obtient la feuille de calcul des données du graphique
    workbook = chart.chart_data.chart_data_workbook

    # Ajoute de nouvelles séries
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # Définit la couleur de remplissage de la série
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Définit les propriétés LabelFormat
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Ajoute de nouvelles séries
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # Définit le type et la couleur de remplissage
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Écrit la présentation sur le disque
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Distance de l'Étiquette par Rapport à l'Axe**
Ce code Python vous montre comment définir la distance de l'étiquette par rapport à un axe de catégorie lorsque vous travaillez avec un graphique tracé à partir des axes :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

	# Crée une instance de la classe Presentation
with slides.Presentation() as presentation:
    # Obtient la référence d'une diapositive
    sld = presentation.slides[0]
    
    # Crée un graphique sur la diapositive
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Définit la distance de l'étiquette par rapport à un axe
    ch.axes.horizontal_axis.label_offset = 500

    # Écrit la présentation sur le disque
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster la Position de l'Étiquette**

Lorsque vous créez un graphique qui ne dépend d'aucun axe, comme un graphique à secteurs, les étiquettes de données du graphique peuvent se retrouver trop près de son bord. Dans ce cas, vous devez ajuster la position de l'étiquette de données afin que les lignes de leader s'affichent clairement.

Ce code Python vous montre comment ajuster la position de l'étiquette sur un graphique à secteurs :

```python
import aspose.slides as slides


with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 200, 200)

    series = chart.chart_data.series
    label = series[0].labels[0]

    label.data_label_format.show_value = True
    label.data_label_format.position = slides.charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![graphique-pie-étiquette-ajustée](pie-chart-adjusted-label.png)