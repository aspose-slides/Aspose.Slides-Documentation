---
title: Personalizar Gráficos 3D em Apresentações Usando Python
linktitle: Gráfico 3D
type: docs
url: /pt/python-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos 3D no Aspose.Slides para Python via Java, com suporte a arquivos PPT e PPTX — impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições de [Rotation3D](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotation3d/) como [setRotationX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotation3d/#setDepthPercents) e [setRightAngleAxes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Ele demonstra como criar uma apresentação, adicionar um gráfico 3D com dados padrão, aplicar as definições de visualização 3D necessárias e salvar a apresentação modificada como um arquivo PPTX.

## **Definir rotação X, rotação Y e profundidade de um gráfico 3D**
Aspose.Slides for Python via Java fornece uma API simples para definir essas propriedades. O exemplo a seguir mostra como definir a rotação X, a rotação Y e a profundidade de um gráfico 3D.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina as propriedades de rotação 3D.
1. Grave a apresentação modificada em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicione um gráfico com dados padrão.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Defina o índice da planilha de dados do gráfico.
    default_worksheet_index = 0

    # Obtenha a pasta de trabalho de dados do gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Adicione séries.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Adicione categorias.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Defina as propriedades de rotação 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Acesse a segunda série do gráfico.
    series = chart.getChartData().getSeries().get_Item(1)

    # Preencha os dados da série.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Salve a apresentação.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, além de tipos 3D relacionados expostos pela classe [ChartType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/). Para obter uma lista exata e atualizada, consulte os membros de [ChartType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem rasterizada de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [chart API](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) ou [renderizar o slide inteiro](/slides/pt/python-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização pixel‑perfect ou deseja incorporar o gráfico em documentos, painéis ou páginas web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize em um tamanho de saída adequado (resolução e dimensões) para corresponder ao dispositivo de exibição ou impressão alvo.