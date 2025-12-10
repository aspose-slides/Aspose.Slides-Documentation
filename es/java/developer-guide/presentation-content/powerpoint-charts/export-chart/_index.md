---
title: Exportar gráficos de presentación en Java
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/java/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo exportar gráficos de presentación con Aspose.Slides para Java, admitiendo los formatos PPT y PPTX, y agilice la generación de informes en cualquier flujo de trabajo."
---

## **Obtener una Imagen de Gráfico**
Aspose.Slides for Java ofrece soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen ráster?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG usando el [shape-to-SVG saving method](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imágenes que permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala especificadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda aparecen incorrectas después de la exportación?**

[Cargue las fuentes requeridas](/slides/es/java/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) para que la renderización del gráfico preserve las métricas y la apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El renderizador de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar las capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentación](/slides/es/java/convert-powerpoint/) para los destinos de salida ([PDF](/slides/es/java/convert-powerpoint-to-pdf/), [SVG](/slides/es/java/render-a-slide-as-an-svg-image/), [XPS](/slides/es/java/convert-powerpoint-to-xps/), [HTML](/slides/es/java/convert-powerpoint-to-html/), etc.) y las opciones de renderizado relacionadas.