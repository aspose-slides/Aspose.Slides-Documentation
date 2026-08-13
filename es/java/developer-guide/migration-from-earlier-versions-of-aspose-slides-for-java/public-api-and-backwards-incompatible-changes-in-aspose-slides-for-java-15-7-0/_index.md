---
title: Cambios en la API pública e incompatibles retroactivos en Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides for Java para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás que se han [added](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) o [removed](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) y otros cambios introducidos con la API de Aspose.Slides for Java 15.7.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha añadido el enum com.aspose.slides.ImagePixelFormat**
Se ha añadido el enum com.aspose.slides.ImagePixelFormat para especificar el formato de píxel de las imágenes generadas.
#### **Se ha añadido el método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
Este método devuelve un color automático del punto de datos basado en el índice de serie, el índice del punto de datos, parentSeriesGroup, los valores de isColorVaried y el estilo del gráfico. Este color se usa por defecto si fillType es igual a NotDefined.
#### **Se han añadido los métodos getPixelFormat() y setPixelFormat(int) a com.aspose.slides.ITiffOptions**
Se han añadido los métodos getPixelFormat() y setPixelFormat(/ImagePixelFormat/int) a com.aspose.slides.ITiffOptions y com.aspose.slides.TiffOptions para especificar el formato de píxel de las imágenes TIFF generadas.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```