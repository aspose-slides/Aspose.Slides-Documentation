---
title: Customizar Gráficos de Pizza em Apresentações Usando Python via Java
linktitle: Gráfico de Pizza
type: docs
url: /pt/python-java/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos de pizza em Python via Java com Aspose.Slides, exportáveis para PowerPoint, impulsionando sua narrativa de dados em segundos."
---
## **Visão Geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de segundo gráfico para os tipos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias em um gráfico de pizza padrão.

Os exemplos concentram‑se em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Segundo Gráfico para Gráficos Pie of Pie e Bar of Pie**

Aspose.Slides for Python via Java oferece suporte a opções de segundo gráfico para os tipos Pie of Pie e Bar of Pie. Esta seção demonstra como especificar essas opções usando Aspose.Slides. Siga estas etapas:

1. Instancie um objeto [Apresentação](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Adicione um gráfico ao slide.
1. Especifique as opções de segundo gráfico do gráfico.
1. Grave a apresentação no disco.

O exemplo a seguir define diferentes propriedades de um gráfico Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Criar uma instância da classe Presentation.
presentation = Presentation()
try:
    # Adicionar um gráfico ao slide.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Definir diferentes propriedades.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Gravar a apresentação no disco.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

Aspose.Slides for Python via Java fornece uma API simples para definir cores automáticas das fatias de um gráfico de pizza. O exemplo abaixo demonstra como aplicar essas configurações.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina o título do gráfico.
1. Defina o índice da planilha de dados do gráfico.
1. Obtenha o workbook de dados do gráfico.
1. Exclua as séries e categorias padrão.
1. Adicione novas categorias.
1. Adicione uma nova série.
1. Configure a nova série para exibir valores.

Grave a apresentação modificada em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Criar uma instância da classe Presentation.
presentation = Presentation()
try:
    # Adicionar um gráfico com dados padrão.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Definir o título do gráfico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Definir o índice da planilha de dados do gráfico.
    default_worksheet_index = 0

    # Obter o workbook de dados do gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Excluir as séries e categorias padrão.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Adicionar novas categorias.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Adicionar uma nova série.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Preencher os dados da série.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Definir a nova série para exibir valores.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/) um segundo gráfico para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) (como PNG) sem a apresentação completa.