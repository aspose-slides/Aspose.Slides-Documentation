---
title: Personalizar Gráficos de Rosca em Apresentações no Android
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/androidjava/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para Android via Java, com suporte a formatos PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do seu buraco central e salvando a apresentação. Ele foca no método `setDoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico por código.

Ele também inclui uma breve FAQ que cobre cenários relacionados a gráficos de rosca, como usar múltiplas séries para criar vários anéis, trabalhar com gráficos de rosca explodidos e exportar um gráfico como imagem raster ou SVG.

## **Especificar o espaço central em um gráfico de rosca**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java agora suporta a especificação do tamanho do buraco em um gráfico de rosca. Neste tópico, veremos com um exemplo como especificar o tamanho do buraco em um gráfico de rosca.

{{% /alert %}} 

Para especificar o tamanho do buraco em um gráfico de rosca, siga as etapas abaixo:

1. Instanciar o objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
2. Adicionar um gráfico de rosca ao slide.
3. Especificar o tamanho do buraco no gráfico de rosca.
4. Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do buraco no gráfico de rosca.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Grave a apresentação no disco
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso criar uma rosca de vários níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca — cada série se torna um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca "explodido" (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá-lo para uma [imagem raster](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ou exportar o gráfico para uma [imagem SVG](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).