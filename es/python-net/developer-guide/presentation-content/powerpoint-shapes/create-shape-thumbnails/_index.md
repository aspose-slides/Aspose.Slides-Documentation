---
title: Crear miniaturas de formas de presentación en Python
linktitle: Miniaturas de forma
type: docs
weight: 70
url: /es/python-net/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Genere miniaturas de alta calidad de formas a partir de diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET: cree y exporte fácilmente miniaturas de presentaciones."
---

## **Introducción**

Aspose.Slides para Python vía .NET se utiliza para crear archivos de presentación en los que cada página es una diapositiva. Puede ver estas diapositivas en Microsoft PowerPoint abriendo el archivo de presentación. Sin embargo, a veces los desarrolladores necesitan ver imágenes de shapes por separado en un visor de imágenes. En esos casos, Aspose.Slides puede generar imágenes en miniatura de los shapes de una diapositiva. Este artículo explica cómo usar esta función.

## **Generar miniaturas de shape a partir de diapositivas**

Cuando necesita una vista previa de un objeto específico en lugar de toda la diapositiva, puede renderizar una miniatura para un shape individual. Aspose.Slides le permite exportar cualquier shape a una imagen, facilitando la creación de vistas previas ligeras, íconos o recursos para procesamiento posterior.

Para generar una miniatura a partir de cualquier shape:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva por su ID o índice.
1. Obtenga una referencia a un shape en esa diapositiva.
1. Renderice la imagen en miniatura del shape.
1. Guarde la imagen en miniatura en el formato deseado.

El ejemplo a continuación genera una miniatura de shape.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create a image with the default scale.
    with shape.get_image() as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generar miniaturas con un factor de escala personalizado**

Esta sección muestra cómo generar miniaturas de shape con un factor de escala definido por el usuario en Aspose.Slides. Al controlar la escala, puede ajustar finamente el tamaño de la miniatura para vistas previas, exportaciones o pantallas de alta densidad de píxeles.

Para generar una miniatura para cualquier shape en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una diapositiva por su ID o índice.
1. Obtenga el shape objetivo en esa diapositiva.
1. Renderice la imagen en miniatura del shape con la escala especificada.
1. Guarde la imagen en miniatura en el formato deseado.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create an image with the defined scale.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generar miniaturas usando los límites de apariencia de un shape**

Esta sección muestra cómo generar una miniatura dentro de los límites de apariencia de un shape. Tiene en cuenta todos los efectos del shape. La miniatura generada está restringida por los límites de la diapositiva.

Para generar una miniatura de cualquier shape de diapositiva dentro de los límites de su apariencia:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una diapositiva por su ID o índice.
1. Obtenga el shape objetivo en esa diapositiva.
1. Renderice la imagen en miniatura del shape con los límites especificados.
1. Guarde la imagen en miniatura en el formato de imagen deseado.

El ejemplo a continuación crea una miniatura con límites definidos por el usuario.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Create an appearance-bounds shape image.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de shapes?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), y otros. Los shapes también pueden ser [exportados como SVG vectorial](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) guardando el contenido del shape como SVG.

**¿Cuál es la diferencia entre los límites SHAPE y APPEARANCE al renderizar una miniatura?**

`SHAPE` utiliza la geometría del shape; `APPEARANCE` tiene en cuenta los [efectos visuales](/slides/es/python-net/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si un shape está marcado como oculto? ¿Se seguirá renderizando como miniatura?**

Un shape oculto sigue formando parte del modelo y puede renderizarse; la bandera de oculto afecta la visualización en la presentación, pero no impide generar la imagen del shape.

**¿Se admiten shapes de grupo, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), y [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas de shapes de texto?**

Sí. Debe [proporcionar las fuentes requeridas](/slides/es/python-net/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/python-net/font-substitution/)) para evitar sustituciones no deseadas y el reflujo del texto.