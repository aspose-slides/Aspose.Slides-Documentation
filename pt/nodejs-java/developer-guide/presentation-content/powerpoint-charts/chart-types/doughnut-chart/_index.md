---
title: Personalizar Gráficos de Rosca em Apresentações Usando JavaScript
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/nodejs-java/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do furo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca com JavaScript e Aspose.Slides para Node.js, suportando formatos PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho de seu furo central e salvando a apresentação. Ele foca no método `setDoughnutHoleSize` e demonstra os passos básicos necessários para personalizar esse tipo de gráfico em código.

Também inclui um pequeno FAQ cobrindo cenários relacionados a gráficos de rosca, como usar várias séries para criar vários anéis, trabalhar com gráficos de rosca “explodidos” e exportar um gráfico como imagem raster ou SVG.

## **Alterar espaço central no gráfico de rosca**

Para especificar o tamanho do furo em um gráfico de rosca, siga os passos abaixo:

1. Instanciar o objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
2. Adicionar um gráfico de rosca ao slide.
3. Especificar o tamanho do furo em um gráfico de rosca.
4. Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do furo em um gráfico de rosca.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Grave a apresentação no disco
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso criar uma rosca de vários níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca—cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca "explodido" (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá-lo para uma [raster image](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) ou exportar o gráfico para uma [SVG image](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/).