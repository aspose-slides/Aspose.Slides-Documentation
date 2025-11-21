---
title: Obtener todo el fondo de la diapositiva de una presentación como una imagen
linktitle: Fondo completo de la diapositiva
type: docs
weight: 95
url: /es/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de la diapositiva
- fondo final
- fondo a imagen
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrae fondos completos de diapositivas como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python vía .NET, optimizando flujos de trabajo visuales."
---

## **Obtener todo el fondo de la diapositiva**

En presentaciones de PowerPoint, el fondo de la diapositiva puede constar de muchos elementos. Además de la imagen establecida como [slide background](/slides/es/python-net/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides para Python no proporciona un método sencillo para extraer todo el fondo de una diapositiva de la presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Carga la presentación usando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén el tamaño de la diapositiva de la presentación.
1. Selecciona una diapositiva.
1. Crea una presentación temporal.
1. Establece el mismo tamaño de diapositiva en la presentación temporal.
1. Clona la diapositiva seleccionada en la presentación temporal.
1. Elimina las formas de la diapositiva clonada.
1. Convierte la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae todo el fondo de la diapositiva de la presentación como una imagen.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```


## **FAQ**

**¿Se conservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides renderiza degradados, imágenes y texturas definidos en la diapositiva, el diseño o la maestra. Si necesitas aislar el aspecto de maestras heredadas, [set an own background](/slides/es/python-net/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puedes [add a watermark](/slides/es/python-net/watermark/) como forma o imagen en una [copy of the slide](/slides/es/python-net/clone-slides/) de trabajo (colocada detrás del resto del contenido) y luego exportar. Esto te permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestra específica sin asociarlo a una diapositiva existente?**

Sí. Accede a la maestra o diseño deseado, aplícalo a una [temporary slide](/slides/es/python-net/clone-slides/) con el tamaño requerido y exporta esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están completamente disponibles con una [valid license](/slides/es/python-net/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Activa la licencia una vez por proceso antes de ejecutar exportaciones por lotes.