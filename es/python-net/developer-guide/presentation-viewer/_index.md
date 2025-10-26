---
title: Crear un visor de presentaciones en Python
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/python-net/developer-guide/presentation-viewer/
keywords:
- vista de presentación
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

## **Visión general**

Aspose.Slides for Python se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, los desarrolladores a veces pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o utilizarlas en un visor de presentaciones personalizado. En esos casos, Aspose.Slides permite exportar diapositivas individuales como imágenes. Este artículo explica cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de una presentación con Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.  
1. Obtenga una referencia a la diapositiva por su índice.  
1. Abra un flujo de archivo.  
1. Guarde la diapositiva como una imagen SVG en el flujo de archivo.  

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Crear una imagen miniatura de una diapositiva**

Aspose.Slides le ayuda a generar imágenes miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.  
1. Obtenga una referencia a la diapositiva por su índice.  
1. Cree una imagen miniatura de la diapositiva referenciada con la escala deseada.  
1. Guarde la imagen miniatura en el formato de imagen que prefiera.  

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

Para crear una imagen miniatura de una diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.  
1. Obtenga una referencia a la diapositiva por su índice.  
1. Genere una imagen miniatura de la diapositiva referenciada con las dimensiones especificadas.  
1. Guarde la imagen miniatura en el formato de imagen que prefiera.  

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

1. Cree una instancia de la [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) clase.  
1. Use la propiedad `RenderingOptions.slides_layout_options` para establecer la posición de las notas del presentador.  
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.  
1. Obtenga una referencia a la diapositiva por su índice.  
1. Genere una imagen miniatura de la diapositiva referenciada usando las opciones de renderizado.  
1. Guarde la imagen miniatura en el formato de imagen que prefiera.  

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

[![Visor de PowerPoint en línea](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web ASP.NET?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como [images](/slides/es/python-net/convert-powerpoint-to-png/) o [HTML](/slides/es/python-net/convert-powerpoint-to-html/) y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor forma de mostrar diapositivas dentro de un visor .NET personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una [image](/slides/es/python-net/convert-powerpoint-to-png/) (por ejemplo, PNG o SVG) o convertirla a [HTML](/slides/es/python-net/convert-powerpoint-to-html/) usando Aspose.Slides, y luego mostrar el resultado dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga perezosa o el renderizado bajo demanda de las diapositivas. Esto significa generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.