---
title: Personalizar Gráficos de Rosca em Apresentações Usando Java
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/java/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides for Java, suportando formatos do PowerPoint para apresentações dinâmicas."
---
## **Visão Geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do seu orifício central e salvando a apresentação. Ele foca no método `setDoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico em código.

Também inclui um FAQ breve que cobre cenários relacionados a gráficos de rosca, como usar várias séries para criar múltiplos anéis, trabalhar com gráficos de rosca explodidos e exportar um gráfico como imagem raster ou SVG.

## **Especificar o Espaço Central em um Gráfico de Rosca**
{{% alert color="primary" %}} 

Aspose.Slides for Java agora suporta a especificação do tamanho do orifício em um gráfico de rosca. Neste tópico, veremos com um exemplo como especificar o tamanho do orifício em um gráfico de rosca.

{{% /alert %}} 

Para especificar o tamanho do orifício em um gráfico de rosca, siga as etapas abaixo:

1. Instanciar o objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Adicionar gráfico de rosca ao slide.
1. Especificar o tamanho do buraco em um gráfico de rosca.
1. Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do orifício em um gráfico de rosca.

```java
// Criar uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Gravar a apresentação no disco
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso criar uma rosca de vários níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca—cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca “explodido” (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut[chart type](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá‑lo para uma [raster image](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-) ou exportar o gráfico para uma [SVG image](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).