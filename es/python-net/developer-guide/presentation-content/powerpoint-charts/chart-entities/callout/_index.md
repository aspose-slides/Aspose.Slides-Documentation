---
title: Gestionar Comentarios emergentes en Gráficos de Presentación con Python
linktitle: Comentario emergente
type: docs
url: /es/python-net/callout/
keywords:
- comentario emergente de gráfico
- usar comentario emergente
- etiqueta de datos
- formato de etiqueta
- Python
- Aspose.Slides
description: "Crear y dar estilo a los comentarios emergentes en Aspose.Slides para Python .NET con ejemplos de código concisos, compatibles con PPT, PPTX y ODP para automatizar flujos de trabajo de presentaciones."
---

## **Uso de Comentarios emergentes**
Se ha añadido la nueva propiedad **show_label_as_data_callout** a la clase **DataLabelFormat**, la cual determina si la etiqueta de datos de un gráfico se mostrará como comentario emergente o como etiqueta de datos. En el ejemplo que se muestra a continuación, hemos configurado los Comentarios emergentes.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Comentario emergente para gráfico de anillo**
Aspose.Slides for Python a través de .NET ofrece soporte para establecer la forma del comentario emergente de la etiqueta de datos de una serie en un gráfico de anillo. A continuación se muestra un ejemplo.
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


## **Preguntas frecuentes**

**¿Se conservan los comentarios emergentes al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Los comentarios emergentes forman parte de la representación del gráfico, por lo que al exportar a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/es/python-net/export-to-html5/), [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/), o [imágenes rasterizadas](/slides/es/python-net/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Funcionan las fuentes personalizadas en los comentarios emergentes y se puede conservar su apariencia al exportar?**

Sí. Aspose.Slides soporta la [inclusión de fuentes](/slides/es/python-net/embedded-font/) en la presentación y controla la inclusión de fuentes durante exportaciones como [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), garantizando que los comentarios emergentes tengan el mismo aspecto en diferentes sistemas.