---
title: Personalizar gráficos de bolhas em apresentações usando C++
linktitle: Gráfico de bolhas
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
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com Aspose.Slides para C++ para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele aborda duas opções de personalização específicas: dimensionar o tamanho das bolhas usando o método `set_BubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados usando o método `set_BubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar o dimensionamento de tamanho e alterar a representação do tamanho das bolhas para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3-D”, observa que os limites práticos dos gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico através do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento do tamanho do gráfico de bolhas**
Aspose.Slides for C++ oferece suporte ao dimensionamento do tamanho dos gráficos de bolhas. Em Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale** foram adicionadas propriedades. A seguir, um exemplo de código.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representar dados como tamanhos de gráfico de bolhas**
Um novo método **get_BubbleSizeRepresentation()** foi adicionado às classes **IChartSeries** e **ChartSeries**. **BubbleSizeRepresentation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Consequentemente, o enum **BubbleSizeRepresentationType** foi adicionado para especificar as maneiras possíveis de representar os dados como tamanhos de gráfico de bolhas. O código de exemplo está abaixo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Um “gráfico de bolhas com efeito 3-D” é suportado e como ele difere de um gráfico regular?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3-D”. Ele aplica estilo 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na enumeração [tipo de gráfico](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há um limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para garantir legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é feita pelo motor do Aspose.Slides. Para formatos raster/vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, antialiasing), portanto escolha um DPI adequado para impressão.