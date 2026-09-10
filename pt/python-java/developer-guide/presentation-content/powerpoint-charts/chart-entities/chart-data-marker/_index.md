---
title: Gerenciar Marcadores de Dados de Gráfico em Apresentações Usando Python
linktitle: Marcador de Dados
type: docs
url: /pt/python-java/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como personalizar marcadores de dados de gráfico no Aspose.Slides para Python via Java, aumentando o impacto das apresentações nos formatos PPT e PPTX com exemplos claros de código Python."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráfico no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimentos de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que os formatos padrão de marcadores estão disponíveis por meio da enumeração [MarkerStyleType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markerstyletype/) e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir opções de marcadores de gráfico**
Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de uma série específica. Para definir as opções de marcadores de gráfico, siga estas etapas:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Criar o gráfico padrão.
- Definir as imagens.
- Acessar a primeira série do gráfico.
- Adicionar novos pontos de dados.
- Salvar a apresentação no disco.

O exemplo a seguir define opções de marcadores de gráfico no nível do ponto de dados.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Crie uma apresentação vazia.
presentation = Presentation()
try:
    # Acesse o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Criando o gráfico padrão
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Obtenha o índice da planilha de dados do gráfico padrão.
    default_worksheet_index = 0

    # Obtenha a pasta de trabalho de dados do gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Exclua a série de demonstração
    chart.getChartData().getSeries().clear()

    # Adicione nova série
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Carregue a primeira imagem.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Carregue a segunda imagem.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Acesse a primeira série do gráfico.
    series = chart.getChartData().getSeries().get_Item(0)

    # Adicione pontos de dados.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Altere o tamanho do marcador da série do gráfico.
    series.getMarker().setSize(15)

    # Salve a apresentação com o gráfico
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Quais formatos de marcador estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, losango, triângulo etc.); a lista é definida pela classe [MarkerStyleType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/python-java/convert-powerpoint-to-png/) ou salvar [formas como SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.