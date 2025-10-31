---
title: Crear miniaturas de formas de presentación en Python
linktitle: Miniaturas de Forma
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
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas PowerPoint y OpenDocument con Aspose.Slides for Python via .NET – cree y exporte fácilmente miniaturas de presentaciones."
---

## **Introducción**

Aspose.Slides for Python via .NET se utiliza para crear archivos de presentación en los que cada página es una diapositiva. Puedes ver estas diapositivas en Microsoft PowerPoint abriendo el archivo de presentación. Sin embargo, a veces los desarrolladores necesitan ver imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides puede generar imágenes en miniatura de las formas de las diapositivas. Este artículo explica cómo usar esta función.

## **Generar miniaturas de forma a partir de diapositivas**

Cuando necesitas una vista previa de un objeto específico en lugar de toda la diapositiva, puedes renderizar una miniatura para una forma individual. Aspose.Slides te permite exportar cualquier forma a una imagen, facilitando la creación de vistas previas ligeras, íconos o recursos para procesamiento posterior.

Para generar una miniatura a partir de cualquier forma:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtén una referencia a una diapositiva por su ID o índice.
1. Obtén una referencia a una forma en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma.
1. Guarda la imagen en miniatura en el formato deseado.

El ejemplo a continuación genera una miniatura de forma.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para abrir el archivo de presentación.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crear una imagen con la escala predeterminada.
    with shape.get_image() as thumbnail:
        # Guardar la imagen en disco en formato PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generar miniaturas con un factor de escala personalizado**

Esta sección muestra cómo generar miniaturas de forma con un factor de escala definido por el usuario en Aspose.Slides. Controlando la escala, puedes ajustar finamente el tamaño de la miniatura para vistas previas, exportaciones o pantallas de alta DPI.

Para generar una miniatura de cualquier forma en una diapositiva:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtén una diapositiva por su ID o índice.
1. Obtén la forma objetivo en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma con la escala especificada.
1. Guarda la imagen en miniatura en el formato deseado.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanciar la clase Presentation para abrir el archivo de presentación.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crear una imagen con la escala definida.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Guardar la imagen en disco en formato PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generar miniaturas usando los límites de apariencia de una forma**

Esta sección muestra cómo generar una miniatura dentro de los límites de apariencia de una forma. Tiene en cuenta todos los efectos de la forma. La miniatura generada está restringida por los límites de la diapositiva.

Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtén una diapositiva por su ID o índice.
1. Obtén la forma objetivo en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma con los límites especificados.
1. Guarda la imagen en miniatura en el formato de imagen deseado.

El ejemplo a continuación crea una miniatura con límites definidos por el usuario.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanciar la clase Presentation para abrir el archivo de presentación.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Crear una imagen de forma con los límites de apariencia.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Guardar la imagen en disco en formato PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), y otros. Las formas también pueden ser [exportadas como SVG vectorial](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites SHAPE y APPEARANCE al renderizar una miniatura?**

`SHAPE` usa la geometría de la forma; `APPEARANCE` tiene en cuenta los [efectos visuales](/slides/es/python-net/shape-effect/) (sombras, resplandores, etc.).

**¿Qué sucede si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la marca oculta afecta la visualización de la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas de grupo, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), y [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Las fuentes instaladas en el sistema afectan la calidad de las miniaturas para formas de texto?**

Sí. Debe [proporcionar las fuentes requeridas](/slides/es/python-net/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/python-net/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.