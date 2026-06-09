---
title: Personalizar gráficos de rosca em apresentações em .NET
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/net/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para .NET, suportando formatos PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do buraco central e salvando a apresentação. Ele foca na configuração `DoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico em código.

Também inclui uma breve FAQ que cobre cenários relacionados a gráficos de rosca, como usar várias séries para criar múltiplos anéis, trabalhar com gráficos de rosca explodidos e exportar um gráfico como imagem raster ou SVG.

## **Especificar o espaço central em um gráfico de rosca**
Para especificar o tamanho do buraco em um gráfico de rosca, siga os passos abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Adicionar um gráfico de rosca ao slide.
- Especificar o tamanho do buraco no gráfico de rosca.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do buraco no gráfico de rosca.

```c#
// Crie uma instância da classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Grava a apresentação no disco
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso criar uma rosca de múltiplos níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca — cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca "explodido" (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderiz‑lo para uma [raster image](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) ou exportar o gráfico para uma [SVG image](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/).