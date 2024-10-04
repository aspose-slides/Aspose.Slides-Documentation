---
title: Obtener el Fondo Completo de la Diapositiva de Presentación como una Imagen
type: docs
weight: 95
url: /python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de diapositiva
- fondo a una imagen
- PowerPoint
- PPT
- PPTX
- presentación de PowerPoint
- Python
- Aspose.Slides para Python
---

En las presentaciones de PowerPoint, el fondo de la diapositiva puede consistir en muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/python-net/presentation-background/), el fondo final puede ser influenciado por el tema de presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides para Python no proporciona un método simple para extraer el fondo completo de la diapositiva de presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Cargar la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener el tamaño de la diapositiva de la presentación.
1. Seleccionar una diapositiva.
1. Crear una presentación temporal.
1. Establecer el mismo tamaño de diapositiva en la presentación temporal.
1. Clonar la diapositiva seleccionada en la presentación temporal.
1. Eliminar las formas de la diapositiva clonada.
1. Convertir la diapositiva clonada en una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de presentación como una imagen.
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