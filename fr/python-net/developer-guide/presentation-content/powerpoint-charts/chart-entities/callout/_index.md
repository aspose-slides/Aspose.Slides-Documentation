---
title: Gérer les callouts dans les graphiques de présentation avec Python
linktitle: Appel
type: docs
url: /fr/python-net/callout/
keywords:
- callout de graphique
- utiliser le callout
- étiquette de données
- format d'étiquette
- Python
- Aspose.Slides
description: "Créer et styliser des callouts dans Aspose.Slides pour Python .NET avec des exemples de code concis, compatibles avec PPT, PPTX et ODP pour automatiser les flux de travail de présentation."
---

## **Utilisation des callouts**
La nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, ce qui détermine si l'étiquette de données d'un graphique spécifié sera affichée comme callout ou comme étiquette de données. Dans l'exemple ci-dessous, nous avons configuré les callouts.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le callout pour le graphique anneau**
Aspose.Slides for Python via .NET prend en charge la définition de la forme du callout d'étiquette de données de série pour un graphique anneau. L'exemple suivant est fourni.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Les callouts sont-ils conservés lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les callouts font partie du rendu du graphique, donc lors de l’exportation vers [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/python-net/export-to-html5/), [SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/), ou [images raster](/slides/fr/python-net/convert-powerpoint-to-png/), ils sont conservés avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent-elles dans les callouts, et leur apparence peut-elle être préservée à l’exportation ?**

Oui. Aspose.Slides prend en charge [l’incorporation de polices](/slides/fr/python-net/embedded-font/) dans la présentation et contrôle l’incorporation des polices lors des exportations telles que [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), garantissant que les callouts conservent le même aspect sur différents systèmes.