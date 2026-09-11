---
title: Crear miniaturas de formas de presentación en Python vía Java
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/python-java/create-shape-thumbnails/
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
- Java
- Aspose.Slides
description: "Genere miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para Python vía Java – cree y exporte fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides for Python via Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for Python via Java les ayuda a generar imágenes en miniatura de las formas de la diapositiva.

Este artículo explica cómo generar miniaturas de formas de diferentes maneras:

- Generar una miniatura de una forma dentro de una diapositiva.
- Generar una miniatura de una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de una forma dentro de los límites de la apariencia de la forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for Python via Java, haga lo siguiente:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Obtener una referencia a una diapositiva usando su ID o índice.
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) de una forma en la diapositiva referenciada con la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma a partir de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instanciar una clase Presentation que representa el archivo de presentación.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crear una imagen a escala completa.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Guardar la imagen en disco en formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Generar una miniatura con un factor de escala definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides for Python via Java, haga lo siguiente:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Obtener una referencia a una diapositiva usando su ID o índice.
1. [Obtener la imagen en miniatura de la forma](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) de una forma en la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código muestra cómo generar una miniatura de forma basada en un factor de escala definido:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instanciar una clase Presentation que representa el archivo de presentación.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crear una imagen escalada con un factor de 2 en ambas direcciones.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Guardar la imagen en disco en formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Crear una miniatura de forma basada en los límites de la apariencia**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva dentro de los límites de su apariencia, haga lo siguiente:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
1. Obtener una referencia a una diapositiva usando su ID o índice.
1. Obtener la imagen en miniatura de una forma en la diapositiva referenciada usando sus límites de apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este fragmento de código se basa en los pasos anteriores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instanciar una clase Presentation que representa el archivo de presentación.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crear una imagen a escala completa.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Guardar la imagen en disco en formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Obtener los límites visuales reales de una forma**

Las propiedades de marco de [Forma](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) —sus métodos [getX](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getWidth) y [getHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getHeight)— describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado a los ejes diferente. La rotación, los contornos, las puntas de flecha, la disposición y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden modificar el área ocupada.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getVisualBounds) para calcular esa área ocupada sin crear una imagen. El método devuelve un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordenadas de diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

El siguiente ejemplo obtiene y compara los límites del marco y los límites visuales:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

El mismo [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) puede usarse para alinear formas cercanas a su borde izquierdo, derecho, superior o inferior; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas grupales, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape.getVisualBounds](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getVisualBounds) cuando necesite coordenadas para el diseño o la validación y no requiera un mapa de bits. Utilice [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapethumbnailbounds/#Shape) dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapethumbnailbounds/#Appearance) la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getVisualBounds) solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **Preguntas frecuentes**

**¿Qué formatos de imagen pueden usarse al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#writeAsSvgToBytes) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/python-java/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas grupales, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Forma](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) (incluyendo [GroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/), y [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/)) puede guardarse como miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes requeridas](/slides/es/python-java/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/python-java/font-substitution/)) para evitar sustituciones no deseadas y reflujo del texto.