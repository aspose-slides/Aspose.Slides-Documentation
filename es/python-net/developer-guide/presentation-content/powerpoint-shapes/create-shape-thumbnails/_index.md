---
title: Crear miniaturas de formas de presentación en Python
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/python-net/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas PowerPoint y OpenDocument con Aspose.Slides for Python via .NET – cree y exporte fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides for Python via .NET se utiliza para crear archivos de presentación en los que cada página es una diapositiva. Puedes ver estas diapositivas en Microsoft PowerPoint abriendo el archivo de presentación. Sin embargo, a veces los desarrolladores necesitan ver imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides puede generar imágenes en miniatura para las formas de la diapositiva. Este artículo explica cómo usar esta característica.

## **Generar miniaturas de forma a partir de diapositivas**

Cuando necesitas una vista previa de un objeto específico en lugar de toda la diapositiva, puedes renderizar una miniatura para una forma individual. Aspose.Slides te permite exportar cualquier forma a una imagen, lo que facilita crear vistas previas ligeras, íconos o recursos para el procesamiento posterior.

Para generar una miniatura a partir de cualquier forma:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su ID o índice.
1. Obtén una referencia a una forma en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma.
1. Guarda la imagen en miniatura en el formato deseado.

El siguiente ejemplo genera una miniatura de forma.

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

Esta sección muestra cómo generar miniaturas de forma con un factor de escala definido por el usuario en Aspose.Slides. Al controlar la escala, puedes ajustar finamente el tamaño de la miniatura para adaptarse a vistas previas, exportaciones o pantallas de alta densidad de píxeles (DPI).

Para generar una miniatura de cualquier forma en una diapositiva:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtén una diapositiva por su ID o índice.
1. Obtén la forma objetivo en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma con la escala especificada.
1. Guarda la imagen en miniatura en el formato deseado.

El siguiente ejemplo genera una miniatura con un factor de escala definido por el usuario.

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

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtén una diapositiva por su ID o índice.
1. Obtén la forma objetivo en esa diapositiva.
1. Renderiza la imagen en miniatura de la forma con los límites especificados.
1. Guarda la imagen en miniatura en el formato de imagen deseado.

El siguiente ejemplo crea una miniatura con límites definidos por el usuario.

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

## **Obtener los límites visuales reales de una forma**

Las propiedades del marco de una [Forma](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) —`Shape.x`, `Shape.y`, `Shape.width` y `Shape.height`— describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado con los ejes diferente. La rotación, los contornos, las puntas de flecha, la disposición y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden cambiar el área ocupada.

Utiliza [Shape.get_visual_bounds](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_visual_bounds/) para calcular esa área ocupada sin crear una imagen. El método devuelve un rectángulo de punto flotante en coordenadas de la diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

El siguiente ejemplo obtiene y compara los límites del marco y los visuales:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

El mismo rectángulo puede usarse para alinear formas cercanas a su borde `left`, `right`, `top` o `bottom`; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas agrupadas, donde el marco almacenado puede no representar el resultado renderizado completo.

Utiliza [Shape.get_visual_bounds](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_visual_bounds/) cuando necesitas coordenadas para el diseño o validación y no necesitas un mapa de bits. Utiliza [Shape.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/) cuando necesitas renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que `ShapeThumbnailBounds.APPEARANCE` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, `Shape.get_visual_bounds` solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/python-net/aspose.slides/imageformat/), y otros. Las formas también pueden ser [exportadas como SVG vectorial](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/write_as_svg/).

**¿Cuál es la diferencia entre los límites SHAPE y APPEARANCE al renderizar una miniatura?**

`SHAPE` utiliza la geometría de la forma; `APPEARANCE` tiene en cuenta los [efectos visuales](/slides/es/python-net/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera de oculto afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Forma](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/), y [SmartArt](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**

Sí. Debes [proporcionar las fuentes necesarias](/slides/es/python-net/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/python-net/font-substitution/)) para evitar sustituciones indeseadas y reflujo del texto.