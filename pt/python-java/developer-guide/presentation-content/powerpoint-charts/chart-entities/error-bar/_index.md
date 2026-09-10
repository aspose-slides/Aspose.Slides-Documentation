---
title: Personalizar Barras de Erro em Gráficos de Apresentação Usando Python
linktitle: Barra de Erro
type: docs
url: /pt/python-java/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como adicionar e personalizar barras de erro em gráficos com Aspose.Slides for Python via Java - otimize visualizações de dados em apresentações PowerPoint."
---
## **Visão Geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando o Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições das barras de erro X e Y e aplicar diferentes tipos de valor, como fixo, percentual e valores personalizados.

Ele também demonstra como atribuir valores personalizados de barra de erro a pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados e onde encontrar as classes e enumerações relacionadas na referência da API.

## **Adicionar Barras de Erro**

Aspose.Slides for Python via Java fornece uma API simples para gerenciar valores de barras de erro. O código de exemplo a seguir usa tipos de valor fixo e percentual.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) classe.
1. Adicione um gráfico de bolhas ao slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Defina os valores e a formatação da barra de erro.
1. Grave a apresentação modificada em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    # Crie um gráfico de bolhas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Adicione barras de erro e defina sua formatação.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Salve a apresentação.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar Valores Personalizados de Barra de Erro**

Aspose.Slides for Python via Java fornece uma API simples para gerenciar valores personalizados de barra de erro. O código de exemplo a seguir se aplica quando [getValueType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/errorbarsformat/#getValueType) retorna [ErrorBarValueType.Custom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/errorbarvaluetype/#Custom). Para especificar um valor, use [getErrorBarsCustomValues](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) para um ponto de dados específico na coleção retornada pelo método da série [getDataPoints](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getDataPoints).

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) classe.
1. Adicione um gráfico de bolhas ao slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Acesse os pontos de dados individuais na série do gráfico e defina seus valores de barra de erro.
1. Defina os valores e a formatação da barra de erro.
1. Grave a apresentação modificada em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    # Crie um gráfico de bolhas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Adicione barras de erro personalizadas e defina sua formatação.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Acesse os pontos de dados da série do gráfico e configure suas fontes de valores de barra de erro.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Defina os valores de barra de erro para os pontos de dados da série do gráfico.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Salve a apresentação.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão junto com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobrepuserem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e classes para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/errorbarsformat/) e as classes relacionadas [ErrorBarType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/errorbarvaluetype/).