---
title: Personalizar leyendas de gráficos en presentaciones con Python
linktitle: Leyenda de gráfico
type: docs
url: /es/python-net/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Python vía .NET para optimizar presentaciones de PowerPoint y OpenDocument con un formato de leyenda adaptado."
---

## **Descripción general**

Aspose.Slides para Python brinda control total sobre las leyendas de los gráficos, lo que permite que las etiquetas de datos sean claras y listas para presentaciones. Puedes mostrar u ocultar la leyenda, elegir su posición en la diapositiva y ajustar el diseño para evitar superposiciones con el área del gráfico. La API permite estilizar texto y marcadores, afinar el relleno y el fondo, y formatear bordes y rellenos para que coincidan con tu tema. Los desarrolladores también pueden acceder a entradas individuales de la leyenda para renombrarlas o filtrarlas, asegurando que solo se muestren las series más relevantes. Con estas capacidades, tus gráficos permanecen legibles, consistentes y alineados con los estándares de diseño de tu presentación.

## **Posicionamiento de la leyenda**

Con Aspose.Slides, puedes controlar rápidamente dónde aparece la leyenda del gráfico y cómo se adapta al diseño de tu diapositiva. Aprende a colocar la leyenda con precisión.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva.
1. Agrega un gráfico a la diapositiva.
1. Establece las propiedades de la leyenda.
1. Guarda la presentación como archivo PPTX.

En el ejemplo a continuación, establecemos la posición y el tamaño de la leyenda del gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el tamaño de fuente de la leyenda**

La leyenda de un gráfico debe ser tan legible como los datos que explica. Esta sección muestra cómo ajustar el tamaño de fuente de la leyenda para que coincida con la tipografía de tu presentación y mejore la accesibilidad.

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Crea un gráfico.
1. Establece el tamaño de fuente.
1. Guarda la presentación en disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el tamaño de fuente para una entrada de la leyenda**

Aspose.Slides te permite afinar la apariencia de las leyendas de los gráficos formateando entradas individuales. El ejemplo a continuación muestra cómo seleccionar un elemento específico de la leyenda y establecer sus propiedades sin modificar el resto de la leyenda.

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Crea un gráfico.
1. Accede a una entrada de la leyenda.
1. Establece las propiedades de la entrada.
1. Guarda la presentación en disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico reserve automáticamente espacio para ella en lugar de superponerse?**

Sí. Usa el modo sin superposición ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); en este caso, el área del gráfico se reducirá para dar cabida a la leyenda.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezcas colores, rellenos o fuentes explícitos para la leyenda o su texto. De esta manera heredarán el tema y se actualizarán correctamente cuando cambie el diseño.