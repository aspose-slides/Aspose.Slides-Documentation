---
title: Exportar gráfico
type: docs
weight: 90
url: /es/nodejs-java/export-chart/
---

## **Obtener imagen del gráfico**
Aspose.Slides for Node.js via Java proporciona soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse como SVG usando el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala - la biblioteca admite renderizar objetos con dimensiones/escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda se ven incorrectas después de la exportación?**

[Cargue las fuentes requeridas](/slides/es/nodejs-java/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) para que la renderización del gráfico conserve métricas y apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El motor de renderizado de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar las capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la [API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[documentación](/slides/es/nodejs-java/convert-powerpoint/) para destinos de salida ([PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), etc.) y opciones de renderizado relacionadas.