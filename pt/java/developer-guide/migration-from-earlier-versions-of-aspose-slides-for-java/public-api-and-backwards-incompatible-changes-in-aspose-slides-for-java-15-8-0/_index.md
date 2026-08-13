---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações que quebram compatibilidade no Aspose.Slides for Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e afins [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ou [removidos](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), e outras alterações introduzidas na API do Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Métodos getDoughnutHoleSize(), setDoughnutHoleSize(byte) foram adicionados ao IChartSeries e ChartSeries**
Especifica o tamanho do furo em um gráfico de rosca.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```