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
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Python mediante .NET para optimizar presentaciones de PowerPoint y OpenDocument con un formato de leyenda a medida."
---

## **Visión general**

Aspose.Slides para Python ofrece control total sobre las leyendas de los gráficos para que pueda hacer que las etiquetas de datos sean claras y listas para la presentación. Puede mostrar u ocultar la leyenda, elegir su posición en la diapositiva y ajustar el diseño para evitar solapamientos con el área del gráfico. La API le permite dar estilo al texto y a los marcadores, ajustar el relleno y el fondo, y formatear bordes y rellenos para que coincidan con su tema. Los desarrolladores también pueden acceder a entradas individuales de la leyenda para renombrarlas o filtrarlas, garantizando que solo se muestren las series más relevantes. Con estas capacidades, sus gráficos permanecen legibles, consistentes y alineados con los estándares de diseño de la presentación.

## **Posicionamiento de la leyenda**

Usando Aspose.Slides, puede controlar rápidamente dónde aparece la leyenda del gráfico y cómo se ajusta al diseño de su diapositiva. Aprenda a colocar la leyenda con precisión.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva.
3. Agregar un gráfico a la diapositiva.
4. Establecer las propiedades de la leyenda.
5. Guardar la presentación como un archivo PPTX.

En el ejemplo a continuación, establecemos la posición y el tamaño de la leyenda del gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener una referencia a la diapositiva.
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas a la diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Establecer las propiedades de la leyenda.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Guardar la presentación en disco.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el tamaño de fuente de la leyenda**

La leyenda de un gráfico debe ser tan legible como los datos que explica. Esta sección muestra cómo ajustar el tamaño de fuente de la leyenda para que coincida con la tipografía de su presentación y mejore la accesibilidad.

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear un gráfico.
3. Establecer el tamaño de fuente.
4. Guardar la presentación en disco.

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

Aspose.Slides le permite afinar la apariencia de las leyendas de los gráficos formateando entradas individuales. El ejemplo a continuación muestra cómo dirigirse a un elemento específico de la leyenda y establecer sus propiedades sin cambiar el resto de la leyenda.

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Crear un gráfico.
3. Acceder a una entrada de la leyenda.
4. Establecer las propiedades de la entrada.
5. Guardar la presentación en disco.

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

Sí. Use el modo sin superposición ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo consigo que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores/rellenos/fuentes explícitos para la leyenda o su texto. Entonces heredarán del tema y se actualizarán correctamente cuando cambie el diseño.