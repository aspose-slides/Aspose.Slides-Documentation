---
title: Personalizar eixos de gráfico em apresentações usando JavaScript
linktitle: Eixo de Gráfico
type: docs
url: /pt/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como usar JavaScript com Aspose.Slides para Node.js via Java para personalizar eixos de gráficos em apresentações do PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos no Aspose.Slides. Ele mostra como obter os valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal para gráficos de linhas, alterar o tipo de eixo de categoria, definir o formato de data para os valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obtendo os valores máximos no eixo vertical em gráficos**

O Aspose.Slides para Node.js via Java permite obter os valores mínimo e máximo em um eixo vertical. Siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Obtenha o valor máximo real no eixo.
5. Obtenha o valor mínimo real no eixo.
6. Obtenha a unidade principal real do eixo.
7. Obtenha a unidade secundária real do eixo.
8. Obtenha a escala da unidade principal real do eixo.
9. Obtenha a escala da unidade secundária real do eixo.

Este código de exemplo — uma implementação dos passos acima — mostra como obter os valores necessários em JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Salva a apresentação
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Troca de dados entre eixos**

O Aspose.Slides permite trocar rapidamente os dados entre os eixos — os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa.

Este código JavaScript mostra como executar a troca de dados entre eixos em um gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Troca linhas e colunas
    chart.getChartData().switchRowColumn();
    // Salva a apresentação
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Desativando o eixo vertical para gráficos de linhas**

Este código JavaScript mostra como ocultar o eixo vertical em um gráfico de linhas:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Desativando o eixo horizontal para gráficos de linhas**

Este código mostra como ocultar o eixo horizontal em um gráfico de linhas:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterando o eixo de categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em JavaScript demonstra a operação:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Definindo o formato de data para o valor do eixo de categoria**

O Aspose.Slides para Node.js via Java permite definir o formato de data para um valor de eixo de categoria. A operação é demonstrada neste código JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Definindo o ângulo de rotação para o título do eixo do gráfico**

O Aspose.Slides para Node.js via Java permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definindo a posição do eixo em um eixo de categoria ou de valor**

O Aspose.Slides para Node.js via Java permite definir a posição do eixo em um eixo de categoria ou de valor. Este código JavaScript mostra como executar a tarefa:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ativando o rótulo de unidade de exibição no eixo de valores do gráfico**

O Aspose.Slides para Node.js via Java permite configurar um gráfico para exibir um rótulo de unidade no seu eixo de valores. Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento de eixos)?**

Os eixos oferecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/axis/setcrosstype/): você pode escolher cruzar em zero, no valor máximo de categoria/valor ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posicionar os rótulos de marcações em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/axis/setmajortickmark/) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.