---
title: Personalizar Gráficos de Bolhas em Apresentações no Android
linktitle: Gráfico de Bolhas
type: docs
url: /pt/androidjava/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com Aspose.Slides para Android via Java para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele aborda duas opções específicas de personalização: dimensionar o tamanho das bolhas por meio do método `setBubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados por meio do método `setBubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar o dimensionamento do tamanho e alterar a representação do tamanho da bolha para usar a largura. O artigo também inclui uma breve seção de Perguntas Frequentes que esclarece o suporte ao tipo de gráfico “Bubble with 3‑D”, observa que os limites práticos dos gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico por meio do mecanismo de renderização Aspose.Slides.

## **Dimensionamento do Tamanho do Gráfico de Bolhas**
O Aspose.Slides for Android via Java oferece suporte ao dimensionamento do tamanho de gráficos de bolhas. No Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) e [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) foram adicionados. A seguir, um exemplo de amostra é apresentado. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
Métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) foram adicionados às interfaces [IChartSeries](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartSeriesGroup) e às classes relacionadas. **BubbleSizeRepresentation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Consequentemente, o enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/BubbleSizeRepresentationType) foi adicionado para especificar as maneiras possíveis de representar os dados como tamanhos de gráfico de bolhas. Um código de exemplo é apresentado abaixo.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Um “gráfico de bolhas com efeito 3‑D” é suportado e como ele difere de um regular?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3‑D”. Ele aplica estilo 3‑D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na classe [chart type](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há um limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para garantir legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é feita pelo mecanismo Aspose.Slides. Para formatos raster/vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, anti‑aliasing), portanto escolha DPI suficiente para impressão.