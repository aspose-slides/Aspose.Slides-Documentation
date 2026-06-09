---
title: Personalizar Barras de Erro em Gráficos de Apresentação Usando JavaScript
linktitle: Barra de Erro
type: docs
url: /pt/nodejs-java/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como adicionar e personalizar barras de erro em gráficos com JavaScript e Aspose.Slides para Node.js via Java—otimize as visualizações de dados em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barra de erro X e Y e aplicar diferentes tipos de valor, como fixo, percentual e valores personalizados.

Ele também demonstra como atribuir valores de barra de erro personalizados para pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados, e onde encontrar as classes e enumerações de referência da API relacionadas.

## **Adicionar barra de erro**

Aspose.Slides for Node.js via Java fornece uma API simples para gerenciar valores de barra de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dado específico na coleção [**DataPoints**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesCollection) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Defina os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Criando um gráfico de bolhas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Adicionando barras de erro e definindo seu formato
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Salvando a apresentação
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar valor de barra de erro personalizada**

Aspose.Slides for Node.js via Java fornece uma API simples para gerenciar valores de barra de erro personalizados. O código de exemplo se aplica quando a propriedade [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) é igual a **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dado específico na coleção [**DataPoints**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesCollection) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato da barra de erro Y.
1. Acesse os pontos de dados individuais da série do gráfico e defina os valores da barra de erro para cada ponto de dados da série.
1. Defina os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Criando um gráfico de bolhas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Adicionando barras de erro personalizadas e definindo seu formato
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Acessando o ponto de dados da série do gráfico e definindo valores de barras de erro para
    // ponto individual
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Definindo barras de erro para os pontos da série do gráfico
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Salvando a apresentação
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão junto com o resto da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobreporem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e enums para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/errorbarsformat/) e os enums relacionados [ErrorBarType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/errorbarvaluetype/).