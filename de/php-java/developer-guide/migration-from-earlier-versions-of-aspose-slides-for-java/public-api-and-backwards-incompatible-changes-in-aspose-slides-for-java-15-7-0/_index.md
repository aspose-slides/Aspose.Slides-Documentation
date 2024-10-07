---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 15.7.0
type: docs
weight: 150
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) oder [entfernten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) Klassen, Methoden, Eigenschaften usw. und andere Änderungen auf, die mit der Aspose.Slides für PHP über Java 15.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Enum com.aspose.slides.ImagePixelFormat wurde hinzugefügt**
Enum com.aspose.slides.ImagePixelFormat wurde hinzugefügt, um das Pixel-Format für die generierten Bilder anzugeben.
#### **Die Methode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() wurde hinzugefügt**
Diese Methode gibt eine automatische Farbe des Datenpunkts basierend auf dem Serienindex, dem Datenpunktindex, der übergeordnetenSerieGruppe, isColorVaried-Werten und dem Diagrammstil zurück. Diese Farbe wird standardmäßig verwendet, wenn fillType gleich NotDefined ist.
#### **Die Methoden getPixelFormat(), setPixelFormat(int) wurden zu com.aspose.slides.ITiffOptions hinzugefügt**
Die Methoden getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) wurden zu com.aspose.slides.ITiffOptions und com.aspose.slides.TiffOptions hinzugefügt, um das Pixel-Format für die generierten TIFF-Bilder anzugeben.

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);
```