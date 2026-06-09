---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides para Java 16.1.0
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
description: "Revisar atualizações da API pública e alterações que quebram compatibilidade no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e afins [adicionadas](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ou [removidas](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), e outras alterações introduzidas com a API do Aspose.Slides for Java 16.1.0.

{{% /alert %}} 
## **Alterações da API Pública**


#### **Métodos getRotationAngle() e setRotationAngle() foram adicionados às interfaces IChartTextBlockFormat e ITextFrameFormat**

Os métodos getRotationAngle() e setRotationAngle() foram adicionados às interfaces com.aspose.slides.IChartTextBlockFormat e com.aspose.slides.ITextFrameFormat. Eles permitem o acesso à rotação personalizada que está sendo aplicada ao texto dentro da caixa delimitadora.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```