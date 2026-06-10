---
title: Nyilvános API és visszafelé kompatibilitást felborító változások az Aspose.Slides for Java 15.7.0-ban
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Aspose.Slides for Java nyilvános API frissítéseinek és törő változásainak áttekintése a PowerPoint PPT, PPTX és ODP prezentációs megoldások zökkenőmentes migrálásához."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) vagy [eltávolított](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for Java 15.7.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **Az com.aspose.slides.ImagePixelFormat enum hozzá lett adva**
Az com.aspose.slides.ImagePixelFormat enum hozzá lett adva a generált képek pixelformátumának megadásához.
#### **A com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() metódus hozzá lett adva**
Ez a metódus automatikus színt ad vissza az adatponthoz a sorozat-index, adatpont-index, parentSeriesGroup, isColorVaried értékek és diagram stílus alapján. Ez a szín lesz alapértelmezésként használva, ha a fillType egyenlő a NotDefined értékkel.
#### **A getPixelFormat() és a setPixelFormat(int) metódusok hozzá lettek adva a com.aspose.slides.ITiffOptions-hoz**
A getPixelFormat() és a setPixelFormat(/ImagePixelFormat/int) metódusok hozzá lettek adva a com.aspose.slides.ITiffOptions és a com.aspose.slides.TiffOptions osztályokhoz, a generált TIFF képek pixelformátumának megadásához.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```