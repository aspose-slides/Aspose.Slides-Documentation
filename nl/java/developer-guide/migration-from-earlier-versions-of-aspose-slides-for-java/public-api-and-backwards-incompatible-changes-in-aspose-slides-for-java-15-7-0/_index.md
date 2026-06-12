---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.7.0
linktitle: Aspose.Slides voor Java 15.7.0
type: docs
weight: 150
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentaties soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) of [verwijderde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Enum com.aspose.slides.ImagePixelFormat is toegevoegd**
Enum com.aspose.slides.ImagePixelFormat is toegevoegd om het pixelformaat voor de gegenereerde afbeeldingen op te geven.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() methode is toegevoegd**
Deze methode retourneert een automatische kleur voor het datumpunt op basis van de serië-index, datumpunt-index, parentSeriesGroup, isColorVaried-waarden en de diagramstijl. Deze kleur wordt standaard gebruikt als fillType gelijk is aan NotDefined.
#### **Methoden getPixelFormat(), setPixelFormat(int) zijn toegevoegd aan com.aspose.slides.ITiffOptions**
Methoden getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) zijn toegevoegd aan com.aspose.slides.ITiffOptions en com.aspose.slides.TiffOptions om het pixelformaat voor de gegenereerde TIFF-afbeeldingen op te geven.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```