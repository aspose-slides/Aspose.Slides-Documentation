---
title: Exportar gráficos de presentación en Android
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/androidjava/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo exportar gráficos de presentación con Aspose.Slides para Android mediante Java, compatible con los formatos PPT y PPTX, y simplifique la generación de informes en cualquier flujo de trabajo."
---

## **Obtener una imagen de gráfico**
Aspose.Slides para Android a través de Java ofrece soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo.
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


## **Preguntas frecuentes**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido se puede guardar en SVG usando el [shape-to-SVG saving method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda aparecen incorrectas después de la exportación?**

[Cargue las fuentes requeridas](/slides/es/androidjava/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) para que el renderizado del gráfico preserve métricas y apariencia del texto.

**¿La exportación respeta el tema, estilos y efectos de PowerPoint?**

Sí. El renderizador de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se preserva la apariencia del gráfico.

**¿Dónde puedo encontrar capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la [API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[documentación](/slides/es/androidjava/convert-powerpoint/) para destinos de salida ([PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/es/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), etc.) y las opciones de renderizado relacionadas.