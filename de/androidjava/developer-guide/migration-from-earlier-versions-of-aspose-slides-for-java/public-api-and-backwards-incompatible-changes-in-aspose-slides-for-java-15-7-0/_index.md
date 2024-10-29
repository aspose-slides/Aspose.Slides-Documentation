---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.7.0
type: docs
weight: 150
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) oder [entfernten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für Java 15.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Enum com.aspose.slides.ImagePixelFormat wurde hinzugefügt**
Enum com.aspose.slides.ImagePixelFormat wurde hinzugefügt, um das Pixel-Format für die erzeugten Bilder festzulegen.
#### **Die Methode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() wurde hinzugefügt**
Diese Methode gibt eine automatische Farbe des Datenpunkts basierend auf dem Serien-Index, dem Datenpunkt-Index, der parentSeriesGroup, den isColorVaried-Werten und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn fillType gleich NotDefined ist.
#### **Methoden getPixelFormat(), setPixelFormat(int) wurden zu com.aspose.slides.ITiffOptions hinzugefügt**
Methoden getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) wurden zu com.aspose.slides.ITiffOptions und com.aspose.slides.TiffOptions hinzugefügt, um das Pixel-Format für die erzeugten TIFF-Bilder festzulegen.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```