---
title: Personalizar Gráficos de Rosca em Apresentações Usando C++
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/cpp/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do orifício
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para C++, suportando formatos do PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do seu orifício central e salvando a apresentação. Ele foca no método `set_DoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico no código.

## **Especificar o Espaço Central em um Gráfico de Rosca**
Para especificar o tamanho do orifício em um gráfico de rosca, siga os passos abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Adicionar um gráfico de rosca no slide.
- Especificar o tamanho do orifício no gráfico de rosca.
- Salvar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do orifício no gráfico de rosca.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Perguntas Frequentes**

**Posso criar uma rosca de múltiplos níveis com vários anéis?**

Sim. Adicione várias séries a um único gráfico de rosca — cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca "explodido" (fatias separadas) é suportado?**

Sim. Existe um [chart type](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) Exploded Doughnut e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá-lo para uma [imagem raster](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) ou exportar o gráfico para uma [imagem SVG](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/).