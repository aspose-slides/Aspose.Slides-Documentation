---
title: Exportar gráficos de presentación en C++
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/cpp/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo exportar gráficos de presentación con Aspose.Slides para C++, compatible con los formatos PPT y PPTX, y agilice la generación de informes en cualquier flujo de trabajo."
---

## **Obtener una imagen de gráfico**
Aspose.Slides for C++ proporciona soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra.
```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG usando el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda se ven incorrectas después de la exportación?**

[Cargue las fuentes requeridas](/slides/es/cpp/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) para que la renderización del gráfico preserve las métricas y la apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El motor de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar las capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la sección de exportación de la [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[documentación](/slides/es/cpp/convert-powerpoint/) para los destinos de salida ([PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/es/cpp/convert-powerpoint-to-xps/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/), etc.) y las opciones de renderizado relacionadas.