---
title: Personalizar Gráficos de Bolhas em Apresentações Usando JavaScript
linktitle: Gráfico de Bolhas
type: docs
url: /pt/nodejs-java/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com JavaScript e Aspose.Slides para Node.js via Java para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele abrange duas opções específicas de personalização: dimensionar o tamanho das bolhas através do método `setBubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados através do método `setBubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar a escala de tamanho e mudar a representação do tamanho da bolha para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3-D”, observa que os limites práticos do gráfico dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico através do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento de Tamanho de Gráfico de Bolhas**

O Aspose.Slides para Node.js via Java oferece suporte ao dimensionamento do tamanho do gráfico de bolhas. No Aspose.Slides para Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) e [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) métodos foram adicionados. A seguir, um exemplo de amostra é apresentado.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**

Os métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) foram adicionados a [ChartSeries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartSeriesGroup) e classes relacionadas. **BubbleSizeRepresentation** especifica como os valores de tamanho da bolha são representados no gráfico de bolhas. Os valores possíveis são: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Consequentemente, o enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BubbleSizeRepresentationType) foi adicionado para especificar as maneiras possíveis de representar dados como tamanhos de gráfico de bolhas. Um exemplo de código é fornecido abaixo.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Um "gráfico de bolhas com efeito 3-D" é suportado, e como ele difere de um regular?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3-D”. Ele aplica estilo 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na enumeração [chart type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há um limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para garantir legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo motor do Aspose.Slides. Para formatos raster/vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, anti‑aliasing), portanto escolha um DPI adequado para impressão.