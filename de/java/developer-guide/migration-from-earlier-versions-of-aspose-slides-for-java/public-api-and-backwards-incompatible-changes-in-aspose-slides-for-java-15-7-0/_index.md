---
title: "Öffentliche API- und Abwärtsinkompatible Änderungen in Aspose.Slides für Java 15.7.0"
linktitle: "Aspose.Slides für Java 15.7.0"
type: docs
weight: 150
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- Migration
- Altcode
- Moderner Code
- Altansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die öffentlichen API‑Aktualisierungen und Breaking Changes in Aspose.Slides für Java, um Ihre PowerPoint‑PPT, PPTX und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) oder [entfernt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for Java 15.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Enum com.aspose.slides.ImagePixelFormat has been added**
Enum com.aspose.slides.ImagePixelFormat wurde hinzugefügt, um das Pixel-Format für die erzeugten Bilder festzulegen.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() method has been added**
Methode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() wurde hinzugefügt. Diese Methode gibt eine automatische Farbe des Datenpunkts zurück, basierend auf dem Serienindex, dem Datenpunktindex, parentSeriesGroup, isColorVaried‑Werten und dem Diagrammstil. Diese Farbe wird standardmäßig verwendet, wenn fillType den Wert NotDefined hat.
#### **Methods getPixelFormat(), setPixelFormat(int) have been added to com.aspose.slides.ITiffOptions**
Methoden getPixelFormat(), setPixelFormat(int) wurden zu com.aspose.slides.ITiffOptions hinzugefügt. Methoden getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) wurden zu com.aspose.slides.ITiffOptions und com.aspose.slides.TiffOptions hinzugefügt, um das Pixel-Format für die erzeugten TIFF‑Bilder festzulegen.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```