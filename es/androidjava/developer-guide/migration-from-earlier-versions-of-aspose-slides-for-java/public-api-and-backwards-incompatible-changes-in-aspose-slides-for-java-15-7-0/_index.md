---
title: API Pública y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 15.7.0
type: docs
weight: 150
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) o [eliminadas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para Java 15.7.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se ha añadido el Enum com.aspose.slides.ImagePixelFormat**
Se ha añadido el Enum com.aspose.slides.ImagePixelFormat para especificar el formato de píxeles para las imágenes generadas.
#### **Se ha añadido el método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
Este método devuelve un color automático del punto de datos basado en el índice de la serie, el índice del punto de datos, parentSeriesGroup, valores isColorVaried y el estilo del gráfico. Este color se utiliza por defecto si fillType es igual a NotDefined.
#### **Se han añadido los métodos getPixelFormat(), setPixelFormat(int) a com.aspose.slides.ITiffOptions**
Se han añadido los métodos getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) a com.aspose.slides.ITiffOptions y com.aspose.slides.TiffOptions para especificar el formato de píxeles para las imágenes TIFF generadas.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```