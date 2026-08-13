---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.8.0
linktitle: Aspose.Slides voor Java 15.8.0
type: docs
weight: 160
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migratie
- verouderde code
- moderne code
- traditionele aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}}

Deze pagina toont alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) of [removed](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Methoden getDoughnutHoleSize(), setDoughnutHoleSize(byte) zijn toegevoegd aan IChartSeries en ChartSeries**
Specificeert de grootte van het gat in een donutgrafiek.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```