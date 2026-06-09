---
title: Personalizar Barras de Erro em Gráficos de Apresentação com Python
linktitle: Barra de Erro
type: docs
url: /pt/python-net/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a adicionar e personalizar barras de erro em gráficos com Aspose.Slides for Python via .NET—otimize visualizações de dados em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barra de erro X e Y e aplicar diferentes tipos de valor, como fixo, percentual e valores personalizados.

Ele também demonstra como atribuir valores personalizados de barra de erro a pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas rápidas sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados e onde encontrar as classes e enums de referência da API relacionados.

## **Adicionar Barra de Erro**
Aspose.Slides for Python via .NET fornece uma API simples para gerenciar valores de barras de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Definindo valores e formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Criando apresentação vazia
with slides.Presentation() as presentation:
    # Criando um gráfico de bolhas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Adicionando barras de erro e definindo seu formato
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Salvando a apresentação
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Adicionar Valor de Barra de Erro Personalizado**
Aspose.Slides for Python via .NET fornece uma API simples para gerenciar valores personalizados de barras de erro. O código de exemplo se aplica quando a propriedade **IErrorBarsFormat.ValueType** é igual a **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Acesse os pontos de dados individuais da série do gráfico e defina os valores da Barra de Erro para cada ponto de dados da série.
1. Definindo valores e formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Criando apresentação vazia
with slides.Presentation() as presentation:
    # Criando um gráfico de bolhas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Adicionando barras de erro personalizadas e definindo seu formato
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Acessando ponto de dados da série do gráfico e definindo valores de barras de erro para ponto individual
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Definindo barras de erro para os pontos da série do gráfico
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Salvando a apresentação
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão juntamente com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobrepuserem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e enums para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/errorbarsformat/) e os enums relacionados [ErrorBarType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/errorbarvaluetype/).