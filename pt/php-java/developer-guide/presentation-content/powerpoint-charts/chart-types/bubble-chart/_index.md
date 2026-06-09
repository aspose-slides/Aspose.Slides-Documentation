---
title: Personalize gráficos de bolhas em apresentações usando PHP
linktitle: Gráfico de Bolhas
type: docs
url: /pt/php-java/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com Aspose.Slides para PHP via Java para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele cobre duas opções específicas de personalização: dimensionar o tamanho das bolhas através do método `setBubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados através do método `setBubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar a escala de tamanho e mudar a representação do tamanho da bolha para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bolha com 3-D”, observa que os limites práticos de gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico através do mecanismo de renderização do Aspose.Slides.

## **Escala de Tamanho do Gráfico de Bolhas**
Aspose.Slides for PHP via Java fornece suporte para a escala de tamanho de gráfico de bolhas. Em Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) e [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) foram adicionados. A seguir, exemplo de código.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
Os métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) foram adicionados às classes [ChartSeries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriesgroup/) e classes relacionadas. **BubbleSizeRepresentation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Consequentemente, o enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/BubbleSizeRepresentationType) foi adicionado para especificar as formas possíveis de representar dados como tamanhos de gráfico de bolhas. O código de exemplo é apresentado abaixo.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Um “gráfico de bolhas com efeito 3-D” é suportado e como ele difere de um normal?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3-D”. Ele aplica estilo 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na classe de [chart type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo mecanismo Aspose.Slides. Para formatos raster ou vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, anti‑aliasing), portanto escolha um DPI suficiente para impressão.