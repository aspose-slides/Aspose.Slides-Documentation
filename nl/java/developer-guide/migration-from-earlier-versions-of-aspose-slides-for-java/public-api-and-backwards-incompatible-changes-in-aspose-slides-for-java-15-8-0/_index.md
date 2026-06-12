---
title: Publieke API en Achterwaarts Incompatibele Wijzigingen in Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk openbare API-updates en breaking changes in Aspose.Slides for Java om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 
Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) of [verwijderd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for Java 15.8.0 API.
{{% /alert %}} 
## **Publieke API-wijzigingen**
#### **Methoden getDoughnutHoleSize(), setDoughnutHoleSize(byte) zijn toegevoegd aan IChartSeries en ChartSeries**
Specificeert de grootte van het gat in een donutgrafiek.
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```