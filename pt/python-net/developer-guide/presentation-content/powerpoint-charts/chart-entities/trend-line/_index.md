---
title: Adicionar linhas de tendência a gráficos de apresentação em Python
linktitle: Linha de Tendência
type: docs
url: /pt/python-net/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos PowerPoint e OpenDocument com Aspose.Slides para Python via .NET — um guia prático e exemplos de código para melhorar a precisão das previsões e envolver o seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linha de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um breve FAQ sobre valores de projeção de linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar linha de tendência**
Aspose.Slides for Python via .NET fornece uma API simples para gerenciar diferentes linhas de tendência de gráficos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (este exemplo usa ChartType.CLUSTERED_COLUMN).
1. Adicione uma linha de tendência exponencial para a série 1 do gráfico.
1. Adicione uma linha de tendência linear para a série 1 do gráfico.
1. Adicione uma linha de tendência logarítmica para a série 2 do gráfico.
1. Adicione uma linha de tendência de média móvel para a série 2 do gráfico.
1. Adicione uma linha de tendência polinomial para a série 3 do gráfico.
1. Adicione uma linha de tendência de potência para a série 3 do gráfico.
1. Grave a apresentação modificada em um arquivo PPTX.

O código a seguir é usado para criar um gráfico com linhas de tendência.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Criando apresentação vazia
with slides.Presentation() as pres:

    # Criando um gráfico de colunas agrupadas
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Adicionando linha de tendência exponencial para a série 1 do gráfico
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Adicionando linha de tendência linear para a série 1 do gráfico
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Adicionando linha de tendência logarítmica para a série 2 do gráfico
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Adicionando linha de tendência de média móvel para a série 2 do gráfico
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Adicionando linha de tendência polinomial para a série 3 do gráfico
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Adicionando linha de tendência de potência para a série 3 do gráfico
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Salvando apresentação
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Adicionar linha personalizada**
Aspose.Slides for Python via .NET fornece uma API simples para adicionar linhas personalizadas em um gráfico. Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Crie um novo gráfico usando o método AddChart exposto pelo objeto Shapes
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes
- Defina a Cor das linhas da forma.
- Grave a apresentação modificada como um arquivo PPTX

O código a seguir é usado para criar um gráfico com linhas personalizadas.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O que significam 'forward' e 'backward' em uma linha de tendência?**

Eles são os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades do eixo; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Um método também está disponível para [exportar uma imagem do próprio gráfico](/slides/pt/python-net/create-shape-thumbnails/).