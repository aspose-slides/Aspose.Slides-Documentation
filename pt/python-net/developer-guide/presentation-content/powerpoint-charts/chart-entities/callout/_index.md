---
title: Gerenciar Callouts em Gráficos de Apresentação com Python
linktitle: Callout
type: docs
url: /pt/python-net/callout/
keywords:
- callout de gráfico
- usar callout
- rótulo de dados
- formato de rótulo
- Python
- Aspose.Slides
description: "Crie e estilize callouts no Aspose.Slides para Python .NET com exemplos de código concisos, compatíveis com PPT, PPTX e ODP para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com callouts para rótulos de dados de gráfico no Aspose.Slides. Ele mostra como usar a propriedade `show_label_as_data_callout` para exibir os rótulos como callouts, como configurar as configurações de rótulo relacionadas a callouts para um gráfico de rosca e observa que os callouts e sua aparência são preservados quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando Callouts**
A nova propriedade **show_label_as_data_callout** foi adicionada à classe **DataLabelFormat**, que determina se o rótulo de dados do gráfico especificado será exibido como callout de dados ou como rótulo de dados. No exemplo abaixo, definimos os Callouts.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Callout para Gráfico de Rosca**
O Aspose.Slides for Python via .NET oferece suporte para definir a forma de callout do rótulo de dados da série em um gráfico de Rosca. A seguir, um exemplo de amostra é apresentado.

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

**Os callouts são preservados ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. Os callouts fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/python-net/export-to-html5/), [SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/python-net/convert-powerpoint-to-png/), eles são preservados juntamente com a formatação do slide.

**Fontes personalizadas funcionam em callouts e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides suporta [incorporação de fontes](/slides/pt/python-net/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), garantindo que os callouts mantenham a mesma aparência em diferentes sistemas.