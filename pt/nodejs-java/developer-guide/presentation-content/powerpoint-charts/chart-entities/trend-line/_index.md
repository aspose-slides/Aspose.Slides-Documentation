---
title: Adicionar linhas de tendência a gráficos de apresentação em JavaScript
linktitle: Linha de Tendência
type: docs
url: /pt/nodejs-java/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com JavaScript e Aspose.Slides para Node.js via Java — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando o Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um pequeno FAQ sobre os valores de projeção da linha de tendência ‘forward’ e ‘backward’ e se as linhas de tendência são preservadas ao exportar para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar linha de tendência**

Use [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) para adicionar uma linha de tendência a uma série de gráfico, selecionando seu tipo com [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). O exemplo cria um gráfico de colunas agrupadas com dados padrão e adiciona duas linhas de tendência a cada uma de suas três séries.

A linha de tendência exponencial oculta sua equação e o valor de R‑quadrado por meio de [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), enquanto a linha de tendência linear está em vermelho. A linha de tendência logarítmica usa [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) para um rótulo personalizado. A média móvel usa um [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) de três pontos de dados e um [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) personalizado.

A linha de tendência polinomial tem um [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) de três e estende uma categoria para a frente através de [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). A linha de tendência de potência estende uma categoria para trás através de [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Definir intercepto da linha de tendência**

Use [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) para fixar o valor Y de uma linha de tendência em X = 0. Esta configuração é suportada para linhas de tendência linear, exponencial e polinomial.

Por exemplo, um modelo de custo de produção pode precisar começar com custos fixos conhecidos de 100, mesmo quando medições em volumes de produção diferentes de zero sugerem uma linha de base diferente. Para uma linha de tendência linear, fixar o intercepto restringe a equação `y = ax + b` para `b = 100`; a inclinação é ajustada aos dados sob essa restrição. Isso não simplesmente move uma linha já ajustada. As configurações de cruzamento de eixos controlam onde os eixos do gráfico se encontram, não os coeficientes da linha de tendência ajustada.

O exemplo a seguir cria um gráfico de dispersão (XY) com volumes de produção de 1 a 4 e custos de 170, 200, 230 e 260. Ele salva o gráfico com o intercepto automático padrão, define o intercepto para 100 e salva um segundo PPTX. Os dois arquivos diferem apenas na configuração do intercepto. A linha de tendência exibe sua equação e se estende de volta a X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Com cálculo automático, esses dados produzem `y = 30x + 140`. Definir o intercepto para 100, em vez disso, produz aproximadamente `y = 43.33x + 100`: o valor ajustado em zero corresponde à linha de base conhecida, enquanto a linha não passa mais por todos os pontos de dados.

| Intercepto automático | Intercepto fixo de 100 |
| --- | --- |
| ![Linha de tendência linear com intercepto calculado automaticamente de 140](intercept-automatic.png) | ![Linha de tendência linear com intercepto fixo de 100](intercept-fixed.png) |

Ambas as imagens usam os mesmos dados e escalas dos eixos. As linhas de tendência são estendidas de volta a X = 0 para mostrar seus interceptos.

Por padrão, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) retorna `NaN`, que representa um intercepto não especificado em vez de zero. O intercepto é então calculado automaticamente a partir dos dados.

## **Adicionar linha personalizada**

Uma linha personalizada é uma forma desenhada sobre o gráfico, e não uma linha de tendência calculada a partir dos dados da série. Este exemplo usa [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) para adicionar uma linha horizontal ao slide sobre o gráfico. A posição da linha é especificada em coordenadas do slide, medida em pontos, de modo que começa na borda esquerda do gráfico e fica a meio caminho verticalmente do gráfico. Sua largura corresponde à largura do gráfico. O [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) atribui à linha uma cor vermelha sólida.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **FAQ**

**O que significam 'forward' e 'backward' em uma linha de tendência?**

Eles são os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades dos eixos; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) ou [SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/nodejs-java/create-shape-thumbnails/) itself.