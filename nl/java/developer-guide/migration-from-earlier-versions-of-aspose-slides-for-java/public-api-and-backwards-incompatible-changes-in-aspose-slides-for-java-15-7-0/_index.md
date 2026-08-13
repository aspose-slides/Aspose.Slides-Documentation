---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de publieke API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint-PPT, PPTX- en ODP-presentatie-oplossingen soepel te migreren."
---
{{% alert color="info" %}}

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) of [verwijderd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for Java 15.7.0 API.

{{% /alert %}}
## **Wijzigingen in de publieke API**
#### **Enum com.aspose.slides.ImagePixelFormat is toegevoegd**
Enum com.aspose.slides.ImagePixelFormat is toegevoegd om het pixelformaat van de gegenereerde afbeeldingen op te geven.
#### **Methode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() is toegevoegd**
Deze methode retourneert een automatische kleur van het datapunt op basis van seriesindex, datapuntindex, parentSeriesGroup, isColorVaried‑waarden en diagramstijl. Deze kleur wordt standaard gebruikt als fillType gelijk is aan NotDefined.
#### **Methoden getPixelFormat() en setPixelFormat(int) zijn toegevoegd aan com.aspose.slides.ITiffOptions**
Methoden getPixelFormat() en setPixelFormat(/ImagePixelFormat/int) zijn toegevoegd aan com.aspose.slides.ITiffOptions en com.aspose.slides.TiffOptions om het pixelformaat van de gegenereerde TIFF‑afbeeldingen op te geven.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```