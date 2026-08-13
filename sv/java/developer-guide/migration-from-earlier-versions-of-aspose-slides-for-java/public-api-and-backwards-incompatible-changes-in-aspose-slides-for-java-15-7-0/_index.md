---
title: Offentligt API och bakåt oförenliga ändringar i Aspose.Slides för Java 15.7.0
linktitle: Aspose.Slides för Java 15.7.0
type: docs
weight: 150
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammalt tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) klasser, metoder, egenskaper med mera, samt andra ändringar som införts med Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
#### **Enum com.aspose.slides.ImagePixelFormat har lagts till**
Enum com.aspose.slides.ImagePixelFormat har lagts till för att ange pixelformat för de genererade bilderna.
#### **Metoden com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() har lagts till**
Denna metod returnerar en automatisk färg för datapunkten baserat på serieindex, datapunktindex, parentSeriesGroup, isColorVaried‑värden och diagramstil. Denna färg används som standard om fillType är lika med NotDefined.
#### **Metoderna getPixelFormat(), setPixelFormat(int) har lagts till i com.aspose.slides.ITiffOptions**
Metoderna getPixelFormat() och setPixelFormat(/ImagePixelFormat/int) har lagts till i com.aspose.slides.ITiffOptions och com.aspose.slides.TiffOptions för att ange pixelformat för de genererade TIFF‑bilderna.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```