---
title: API Público y Cambios Incompatibles hacia Atrás en Aspose.Slides para Java 15.7.0
type: docs
weight: 150
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc., [agregados](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) o [eliminados](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) y otros cambios introducidos con la API Aspose.Slides para Java 15.7.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Enum com.aspose.slides.ImagePixelFormat ha sido agregado**
El enum com.aspose.slides.ImagePixelFormat ha sido agregado para especificar el formato de píxel para las imágenes generadas.
#### **El método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() ha sido agregado**
Este método retorna un color automático del punto de datos basado en el índice de la serie, el índice del punto de datos, parentSeriesGroup, valores isColorVaried y el estilo del gráfico. Este color se utiliza por defecto si fillType es igual a NotDefined.
#### **Los métodos getPixelFormat(), setPixelFormat(int) han sido agregados a com.aspose.slides.ITiffOptions**
Los métodos getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) han sido agregados a com.aspose.slides.ITiffOptions y com.aspose.slides.TiffOptions para especificar el formato de píxel para las imágenes TIFF generadas.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```