---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for Java 16.1.0
linktitle: Aspose.Slides para Java 16.1.0
type: docs
weight: 200
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides for Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ou [removidos](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) classes, métodos, propriedades etc., e outras alterações introduzidas na API do Aspose.Slides for Java 16.1.0.

{{% /alert %}} 
## **Alterações da API Pública**


#### **Métodos getRotationAngle() e setRotationAngle() foram adicionados às interfaces IChartTextBlockFormat e ITextFrameFormat**
Os métodos getRotationAngle() e setRotationAngle() foram adicionados às interfaces com.aspose.slides.IChartTextBlockFormat e com.aspose.slides.ITextFrameFormat.
Eles fornecem acesso à rotação personalizada que está sendo aplicada ao texto dentro da caixa delimitadora.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);
```