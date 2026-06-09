---
title: Gerenciar marcadores de dados de gráfico em apresentações com Python
linktitle: Marcador de Dados
type: docs
url: /pt/python-net/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a personalizar marcadores de dados de gráfico no Aspose.Slides, aumentando o impacto da apresentação nos formatos PPT, PPTX e ODP com exemplos de código claros."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráficos no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimento de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que formas de marcadores padrão estão disponíveis através da enumeração `MarkerStyleType` e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir opções de marcadores de gráfico**
Os marcadores podem ser definidos nos pontos de dados de um gráfico dentro de séries específicas. Para definir as opções de marcadores de gráfico, siga os passos abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
- Criar o gráfico padrão.
- Definir a imagem.
- Obter a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcadores de gráfico no nível dos pontos de dados.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crie uma instância da classe Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Criando o gráfico padrão
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Obtendo o índice da planilha de dados padrão do gráfico
    defaultWorksheetIndex = 0

    # Obtendo a planilha de dados do gráfico
    fact = chart.chart_data.chart_data_workbook

    # Excluir série de demonstração
    chart.chart_data.series.clear()

    # Adicionar nova série
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Definir a imagem
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Definir a imagem
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Obtém a primeira série do gráfico
    series = chart.chart_data.series[0]

    # Adicionar novo ponto (1:3) aqui.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Alterando o marcador da série do gráfico
    series.marker.size = 15

    # Gravar a apresentação no disco
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quais formas de marcadores estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, diamante, triângulo, etc.); a lista é definida pela enumeração [MarkerStyleType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visualizações personalizadas.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/python-net/convert-powerpoint-to-png/) ou salvar [formas como SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.