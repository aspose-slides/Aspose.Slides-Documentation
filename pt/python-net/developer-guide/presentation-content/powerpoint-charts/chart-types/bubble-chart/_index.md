---
title: Personalizar Gráficos de Bolhas em Apresentações com Python
linktitle: Gráfico de Bolhas
type: docs
url: /pt/python-net/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint e OpenDocument com Aspose.Slides for Python via .NET para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele cobre duas opções específicas de personalização: dimensionamento dos tamanhos das bolhas através da propriedade `bubble_size_scale` e controle de como os valores de tamanho das bolhas são representados através da propriedade `bubble_size_representation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar o dimensionamento de tamanho e mudar a representação do tamanho da bolha para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3‑D”, observa que os limites práticos dos gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico por meio do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento do Tamanho do Gráfico de Bolhas**
Aspose.Slides for Python via .NET fornece suporte ao dimensionamento de tamanho de gráficos de bolhas. Em Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** e **ChartSeriesGroup.bubble_size_scale** foram adicionadas. Abaixo está um exemplo de amostra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
A propriedade **bubble_size_representation** foi adicionada às classes ChartSeries e ChartSeriesGroup. **bubble_size_representation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: **BubbleSizeRepresentationType.AREA** e **BubbleSizeRepresentationType.WIDTH**. Consequentemente, o enum **BubbleSizeRepresentationType** foi adicionado para especificar as maneiras possíveis de representar dados como tamanhos de gráfico de bolhas. Código de exemplo é fornecido abaixo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Um “gráfico de bolhas com efeito 3‑D” é suportado e como ele difere de um gráfico normal?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3‑D”. Ele aplica estilo 3‑D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na enumeração [tipo de gráfico](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há um limite rígido ao nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para legibilidade e velocidade de renderização.

**Como a exportação afeta a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo motor Aspose.Slides. Para formatos raster ou vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, antialiasing), portanto escolha DPI suficiente para impressão.