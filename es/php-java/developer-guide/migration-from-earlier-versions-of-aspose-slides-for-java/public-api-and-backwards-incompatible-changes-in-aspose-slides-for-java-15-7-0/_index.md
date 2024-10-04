---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP a través de Java 15.7.0
type: docs
weight: 150
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [agregadas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) o [eliminadas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para PHP a través de Java 15.7.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha añadido el Enum com.aspose.slides.ImagePixelFormat**
Se ha añadido el Enum com.aspose.slides.ImagePixelFormat para especificar el formato de píxel de las imágenes generadas.
#### **Se ha añadido el método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
Este método devuelve un color automático del punto de datos basado en el índice de la serie, el índice del punto de datos, parentSeriesGroup, valores isColorVaried y estilo del gráfico. Este color se utiliza por defecto si fillType es igual a NotDefined.
#### **Se han añadido los métodos getPixelFormat(), setPixelFormat(int) a com.aspose.slides.ITiffOptions**
Se han añadido los métodos getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) a com.aspose.slides.ITiffOptions y com.aspose.slides.TiffOptions para especificar el formato de píxel de las imágenes TIFF generadas.

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);

```