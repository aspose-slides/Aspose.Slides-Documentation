---
title: Crear un Visor de Presentaciones en Python
linktitle: Visor de Presentaciones
type: docs
weight: 50
url: /es/python-net/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aprenda cómo crear un visor de presentaciones personalizado en Python usando Aspose.Slides. Visualice fácilmente archivos PowerPoint (PPTX, PPT) y OpenDocument (ODP) sin Microsoft PowerPoint u otro software de oficina."
---

## **Descripción general**

Aspose.Slides for Python se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores necesitan ver las diapositivas como imágenes en su visor de imágenes preferido o utilizarlas en un visor de presentaciones personalizado. En esos casos, Aspose.Slides permite exportar diapositivas individuales como imágenes. Este artículo explica cómo hacerlo.

## **Generar una Imagen SVG a partir de una Diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Abrir un flujo de archivo.
4. Guardar la diapositiva como una imagen SVG en el flujo de archivo.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Crear una Imagen Miniatura de una Diapositiva**

Aspose.Slides le ayuda a generar imágenes miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Crear una imagen miniatura de la diapositiva referenciada a la escala deseada.
4. Guardar la imagen miniatura en el formato de imagen que prefiera.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Crear una Miniatura de Diapositiva con Dimensiones Definidas por el Usuario**

Para crear una imagen miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Generar una imagen miniatura de la diapositiva referenciada con las dimensiones especificadas.
4. Guardar la imagen miniatura en el formato de imagen que prefiera.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Crear una Miniatura de Diapositiva con Notas del Ponente**

Para generar una miniatura de una diapositiva con notas del ponente usando Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
2. Utilizar la propiedad `RenderingOptions.slides_layout_options` para establecer la posición de las notas del ponente.
3. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
4. Obtener una referencia a la diapositiva por su índice.
5. Generar una imagen miniatura de la diapositiva referenciada usando las opciones de renderizado.
6. Guardar la imagen miniatura en el formato de imagen que prefiera.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Ejemplo en Vivo**

Pruebe la aplicación gratuita [**Visor de Aspose.Slides**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

[![Visor de PowerPoint en línea](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web ASP.NET?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como [imágenes](/slides/es/python-net/convert-powerpoint-to-png/) o [HTML](/slides/es/python-net/convert-powerpoint-to-html/) y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor .NET personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una [imagen](/slides/es/python-net/convert-powerpoint-to-png/) (por ejemplo, PNG o SVG) o convertirla a [HTML](/slides/es/python-net/convert-powerpoint-to-html/) usando Aspose.Slides, y luego mostrar el resultado dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida o el renderizado bajo demanda de las diapositivas. Esto implica generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.