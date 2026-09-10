---
title: Personalizar eixos de gráfico em apresentações usando Python
linktitle: Eixo de gráfico
type: docs
url: /pt/python-java/chart-axis/
keywords:
- eixo de gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Descubra como usar o Aspose.Slides para Python via Java para personalizar eixos de gráfico em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos no Aspose.Slides. Ele mostra como obter valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal em gráficos de linhas, alterar o tipo de eixo de categoria, definir o formato de data para valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e definir a unidade de exibição do eixo de valores.

## **Obter os valores máximos no eixo vertical de um gráfico**

Aspose.Slides for Python via Java permite obter os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Obtenha o valor máximo real no eixo.
1. Obtenha o valor mínimo real no eixo.
1. Obtenha a unidade principal real do eixo.
1. Obtenha a unidade secundária real do eixo.
1. Obtenha a escala da unidade principal real do eixo.
1. Obtenha a escala da unidade secundária real do eixo.

Este código de exemplo—uma implementação das etapas acima—mostra como obter os valores necessários em Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Salva a apresentação
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trocar os Dados entre Eixos**

Aspose.Slides permite trocar rapidamente os dados entre eixos—os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa.

Este código Python mostra como realizar a troca de dados entre eixos em um gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Carrega os dados padrão do gráfico na planilha — switchRowColumn transpõe a planilha,
    # então ela deve ser preenchida primeiro
    workbook = chart.getChartData().getChartDataWorkbook()

    # Troca linhas e colunas
    chart.getChartData().switchRowColumn()

    # Salva a apresentação
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desativar o Eixo Vertical para Gráficos de Linha**

Este código Python mostra como ocultar o eixo vertical em um gráfico de linha:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desativar o Eixo Horizontal para Gráficos de Linha**

Este código mostra como ocultar o eixo horizontal em um gráfico de linha:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alterar o Eixo de Categoria**

Usando o método [setCategoryAxisType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#setCategoryAxisType), você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Definir o Formato de Data para Valores do Eixo de Categoria**

Aspose.Slides for Python via Java permite definir o formato de data para um valor do eixo de categoria. A operação é demonstrada neste código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir um Ângulo de Rotação para o Título de um Eixo de Gráfico**

Aspose.Slides for Python via Java permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**

Aspose.Slides for Python via Java permite definir a posição do eixo em um eixo de categoria ou valor. Este código Python mostra como realizar a tarefa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir a Unidade de Exibição em um Eixo de Valor de Gráfico**

Aspose.Slides for Python via Java permite definir a unidade de exibição de um eixo de valor de gráfico. O eixo então escala seus rótulos de marcação por essa unidade: com [DisplayUnitType.Millions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/displayunittype/#Millions), um eixo que vai até 60.000.000 é rotulado de 0 a 60. Este código Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Como definir o valor no qual um eixo cruza o outro (cruzamento de eixo)?**

Os eixos fornecem uma [crossing setting](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#setCrossType): você pode escolher cruzar em zero, no valor máximo da categoria/valor ou em um valor numérico específico. Isso é útil para mover o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posicionar as marcas de marcação em relação ao eixo (cruzamento, fora, dentro)?**

Defina a [tick mark position](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#setMajorTickMark) para "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.