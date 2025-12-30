---
title: Exportar gráficos de presentación en PHP
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/php-java/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a exportar gráficos de presentación con Aspose.Slides para PHP a través de Java, con soporte para formatos PPT y PPTX, y agilice la generación de informes en cualquier flujo de trabajo."
---

## **Obtener una imagen de gráfico**
Aspose.Slides para PHP a través de Java ofrece soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra.  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG mediante el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones o escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda se ven incorrectas tras la exportación?**

[Cargue las fuentes requeridas](/slides/es/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) para que el renderizado del gráfico conserve métricas y apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El renderizador de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la [API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[documentación](/slides/es/php-java/convert-powerpoint/) para destinos de salida ([PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/es/php-java/convert-powerpoint-to-xps/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/), etc.) y opciones de renderizado relacionadas.