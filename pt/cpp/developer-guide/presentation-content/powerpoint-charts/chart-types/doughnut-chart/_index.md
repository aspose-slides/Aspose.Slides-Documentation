---
title: Personalizar Gráficos de Rosquinha em Apresentações Usando C++
linktitle: Gráfico de Rosquinha
type: docs
weight: 30
url: /pt/cpp/doughnut-chart/
keywords:
- gráfico de rosquinha
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosquinha no Aspose.Slides para C++, suportando formatos do PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosquinha no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do buraco central e salvando a apresentação. Ele se concentra no método `set_DoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico no código.

## **Especificar o Espaço Central em um Gráfico de Rosquinha**
Para especificar o tamanho do buraco em um gráfico de rosquinha, siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Adicionar um gráfico de rosquinha ao slide.
- Especificar o tamanho do buraco em um gráfico de rosquinha.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do buraco em um gráfico de rosquinha.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Perguntas Frequentes**

**Posso criar uma rosquinha multinível com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosquinha — cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosquinha "explodido" (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) e uma propriedade de explosão nos pontos de dados; é possível separar fatias individuais.

**Como obter uma imagem de um gráfico de rosquinha (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderiz‑lo para uma [imagem raster](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) ou exportar o gráfico para uma [imagem SVG](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/).