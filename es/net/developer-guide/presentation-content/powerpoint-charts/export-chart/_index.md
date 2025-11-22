---
title: Exportar gráfico
type: docs
weight: 90
url: /es/net/export-chart/
keywords:
- gráfico
- imagen de gráfico
- extraer imagen de gráfico
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides for .NET
description: "Obtener imágenes de gráficos de presentaciones de PowerPoint en C# o .NET"
---

## **Obtener imagen del gráfico**
Aspose.Slides for .NET ofrece soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra.
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG mediante el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda se ven incorrectas después de la exportación?**

[Cargue las fuentes necesarias](/slides/es/net/custom-font/) a través de [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) para que el renderizado del gráfico preserve las métricas y la apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El renderizador de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar capacidades de renderizado/exportación disponibles más allá de imágenes de gráficos?**

Consulte la sección de exportación de la [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentación](/slides/es/net/convert-powerpoint/) para destinos de salida ([PDF](/slides/es/net/convert-powerpoint-to-pdf/), [SVG](/slides/es/net/render-a-slide-as-an-svg-image/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [HTML](/slides/es/net/convert-powerpoint-to-html/), etc.) y opciones de renderizado relacionadas.