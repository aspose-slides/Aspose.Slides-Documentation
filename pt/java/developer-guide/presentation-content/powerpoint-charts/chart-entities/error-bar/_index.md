---
title: Personalizar Barras de Erro em Gráficos de Apresentação Usando Java
linktitle: Barra de Erro
type: docs
url: /pt/java/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como adicionar e personalizar barras de erro em gráficos com Aspose.Slides para Java—otimize visualizações de dados em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barra de erro X e Y e aplicar diferentes tipos de valor, como fixos, percentuais e valores personalizados.

Também demonstra como atribuir valores de barra de erro personalizados para pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados, e onde encontrar as classes e enumerações de referência da API relacionadas.

## **Adicionar barras de erro**
O Aspose.Slides for Java oferece uma API simples para gerenciar valores de barra de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção [**DataPoints**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartSeriesCollection) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Adicione um gráfico de bolha no slide desejado.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
1. Defina os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Criando um gráfico de bolha
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adicionando barras de erro e definindo seu formato
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Salvando a apresentação
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar valores personalizados de barra de erro**
O Aspose.Slides for Java oferece uma API simples para gerenciar valores personalizados de barra de erro. O código de exemplo se aplica quando a propriedade [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IErrorBarsFormat#getValue--) é igual a **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção [**DataPoints**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartSeriesCollection) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Adicione um gráfico de bolha no slide desejado.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
1. Acesse os pontos de dados individuais da série de gráfico e defina os valores da barra de erro para cada ponto de dados da série.
1. Defina os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Criando um gráfico de bolha
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adicionando barras de erro personalizadas e definindo seu formato
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Acessando o ponto de dados da série do gráfico e definindo valores das barras de erro para
    // ponto individual
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Definindo barras de erro para os pontos da série do gráfico
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Salvando a apresentação
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão juntamente com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobrepuserem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e classes para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/errorbarsformat/) e as classes relacionadas [ErrorBarType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/errorbarvaluetype/).