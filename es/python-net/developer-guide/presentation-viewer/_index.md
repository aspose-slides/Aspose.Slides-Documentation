---
title: Crear un visor de presentaciones en Python
linktitle: Visor de presentaciones
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
description: "Aprenda a crear un visor de presentaciones personalizado en Python usando Aspose.Slides. Visualice fácilmente archivos PowerPoint (PPTX, PPT) y OpenDocument (ODP) sin Microsoft PowerPoint ni otro software de oficina."
---

## **Visión general**

Aspose.Slides para Python se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, los desarrolladores a veces necesitan ver las diapositivas como imágenes en su visor de imágenes preferido o utilizarlas en un visor de presentaciones personalizado. En esos casos, Aspose.Slides permite exportar diapositivas individuales como imágenes. Este artículo explica cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Abra un flujo de archivo.
4. Guarde la diapositiva como una imagen SVG en el flujo de archivo.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Crear una miniatura de diapositiva**

Aspose.Slides le ayuda a generar imágenes miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Cree una imagen miniatura de la diapositiva referenciada con la escala deseada.
4. Guarde la imagen miniatura en el formato de imagen que prefiera.

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

## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Genere una imagen miniatura de la diapositiva referenciada con las dimensiones especificadas.
4. Guarde la imagen miniatura en el formato de imagen que prefiera.

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

## **Crear una miniatura de diapositiva con notas del presentador**

Para generar una miniatura de una diapositiva con notas del presentador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) .
2. Utilice la propiedad `RenderingOptions.slides_layout_options` para establecer la posición de las notas del presentador.
3. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
4. Obtenga una referencia a la diapositiva por su índice.
5. Genere una imagen miniatura de la diapositiva referenciada usando las opciones de renderizado.
6. Guarde la imagen miniatura en el formato de imagen que prefiera.

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

## **Ejemplo en vivo**

Pruebe la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web ASP.NET?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como [images](/slides/es/python-net/convert-powerpoint-to-png/) o [HTML](/slides/es/python-net/convert-powerpoint-to-html/) y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor .NET personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una [image](/slides/es/python-net/convert-powerpoint-to-png/) (por ejemplo, PNG o SVG) o convertirla a [HTML](/slides/es/python-net/convert-powerpoint-to-html/) usando Aspose.Slides, y luego mostrar el resultado dentro de un control de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida (lazy‑loading) o el renderizado bajo demanda de las diapositivas. Esto implica generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.