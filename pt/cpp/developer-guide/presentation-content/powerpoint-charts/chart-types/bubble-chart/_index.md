---
title: Personalizar Gráficos de Bolhas em Apresentações Usando C++
linktitle: Gráfico de Bolhas
type: docs
url: /pt/cpp/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com Aspose.Slides para C++ e melhore sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele cobre duas opções específicas de personalização: dimensionar o tamanho das bolhas através do método `set_BubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados através do método `set_BubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar o dimensionamento do tamanho e mudar a representação do tamanho da bolha para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3-D”, observa que os limites práticos de gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico através do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento do Tamanho do Gráfico de Bolhas**
Aspose.Slides for C++ fornece suporte ao dimensionamento do tamanho de gráficos de bolhas. Em Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale** propriedades foram adicionadas. A seguir, um exemplo de amostra é apresentado. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
O novo método **get_BubbleSizeRepresentation()** foi adicionado às classes **IChartSeries** e **ChartSeries**. **BubbleSizeRepresentation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Consequentemente, o enum **BubbleSizeRepresentationType** foi adicionado para especificar as possíveis formas de representar dados como tamanhos de gráficos de bolhas. O código de exemplo é apresentado abaixo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **Perguntas frequentes**

**Um “gráfico de bolhas com efeito 3-D” é suportado e como ele difere de um gráfico regular?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3-D”. Ele aplica estilo 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na enumeração [tipo de gráfico](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo mecanismo Aspose.Slides. Para formatos raster/vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, antisserrilhamento), portanto escolha DPI suficiente para impressão.