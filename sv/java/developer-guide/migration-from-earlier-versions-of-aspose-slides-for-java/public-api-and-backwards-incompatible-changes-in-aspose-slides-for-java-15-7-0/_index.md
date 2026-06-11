---
title: Offentliga API- och bakåt inkompatibla förändringar i Aspose.Slides för Java 15.7.0
linktitle: Aspose.Slides för Java 15.7.0
type: docs
weight: 150
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migration
- gammalkod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="primary" %}} 
Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för Java 15.7.0 API.
{{% /alert %}} 
## **Offentliga API-ändringar**
#### **Enum com.aspose.slides.ImagePixelFormat har lagts till**
Enum com.aspose.slides.ImagePixelFormat har lagts till för att ange pixelformat för de genererade bilderna.
#### **Metoden com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() har lagts till**
Denna metod returnerar en automatisk färg för datapunkten baserat på seriens index, datapunktens index, parentSeriesGroup, isColorVaried-värden och diagramstilen. Denna färg används som standard om fillType är lika med NotDefined.
#### **Metoderna getPixelFormat(), setPixelFormat(int) har lagts till i com.aspose.slides.ITiffOptions**
Metoderna getPixelFormat() och setPixelFormat(/ImagePixelFormat/int) har lagts till i com.aspose.slides.ITiffOptions och com.aspose.slides.TiffOptions för att ange pixelformat för de genererade TIFF-bilderna.
``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```