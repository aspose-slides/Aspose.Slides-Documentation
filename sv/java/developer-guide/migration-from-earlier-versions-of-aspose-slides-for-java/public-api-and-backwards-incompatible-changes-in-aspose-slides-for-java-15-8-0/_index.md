---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 15.8.0
linktitle: Aspose.Slides för Java 15.8.0
type: docs
weight: 160
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint-PPT, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}} 
Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) klasser, metoder, egenskaper med mera och andra förändringar som införts med Aspose.Slides för Java 15.8.0 API.
{{% /alert %}} 
## **Offentliga API-ändringar**
#### **Metoderna getDoughnutHoleSize(), setDoughnutHoleSize(byte) har lagts till i IChartSeries och ChartSeries**
Anger storleken på hålet i ett munkdiagram.
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```