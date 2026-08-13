---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.7.0-ban
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és a töréspont változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [added](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) vagy [removed](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for Java 15.7.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Public API Changes**
#### **Enum com.aspose.slides.ImagePixelFormat has been added**
Enum com.aspose.slides.ImagePixelFormat has been added for specifying pixel format for the generated images.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
This method returns an automatic color of data point based on series index, data point index, parentSeriesGroup, isColorVaried values and chart style. This color is used by default if fillType equals NotDefined.
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to com.aspose.slides.ITiffOptions**
Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) have been added to com.aspose.slides.ITiffOptions and com.aspose.slides.TiffOptions for specifying pixel format for the generated TIFF images.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```