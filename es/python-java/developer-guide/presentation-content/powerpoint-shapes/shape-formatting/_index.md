---
title: Formatear formas de PowerPoint en Python mediante Java
linktitle: Formato de forma
type: docs
weight: 20
url: /es/python-java/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de boceto
- línea de forma bocetada
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- representación de forma en blanco y negro
- representación de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en Python mediante Java usando Aspose.Slides: establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes formatearlas modificando o aplicando efectos a sus contornos. Además, puedes formatear las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![Formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java proporciona clases y métodos que permiten formatear formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formatear líneas**

Con Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [line style](https://reference.aspose.com/slides/es/python-java/aspose.slides/linestyle/) de la forma.
1. Establecer el ancho de la línea.
1. Establecer el [dash style](https://reference.aspose.com/slides/es/python-java/aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de la línea para la forma.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código muestra cómo formatear un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo rectángulo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Establecer el color de relleno para la forma rectángulo.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Aplicar formato a las líneas del rectángulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Establecer el color de la línea del rectángulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Guardar el archivo PPTX en disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de la forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utiliza [Shape.getLineFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getLineFormat) para acceder a la configuración de la línea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/lineformat/#getSketchFormat) para acceder a la configuración del boceto y [SketchFormat.setSketchType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sketchformat/#setSketchType) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/es/python-java/aspose.slides/linesketchtype/).

El siguiente código Python muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/es/python-java/aspose.slides/linesketchtype/#Curved), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None_](https://reference.aspose.com/slides/es/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Acceder al formato de línea de la forma y a su formato de boceto.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Aplicar un efecto de boceto.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Leer el efecto de boceto asignado directamente a la forma.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eliminar el efecto de boceto.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

El valor devuelto por [SketchFormat.getSketchType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sketchformat/#getSketchType) representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utiliza [LineFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/lineformat/#getEffective), accede a `LineFormatEffectiveData.getSketchFormat` y lee `SketchFormatEffectiveData.getSketchType`. El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formatear estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (como en la esquina de una forma), utiliza la configuración **Redondo**. Sin embargo, si estás dibujando una forma con ángulos agudos, puede que prefieras la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código Python muestra cómo se crearon tres rectángulos (como se ve en la imagen anterior) utilizando las configuraciones de tipo de unión Miter, Bevel y Round:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # Instanciar la clase Presentation que representa un archivo de presentación.
    presentation = Presentation()
    try:
        # Obtener la primera diapositiva.
        slide = presentation.getSlides().get_Item(0)

        # Añadir tres auto formas del tipo Rectangle.
        miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
        bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
        round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

        # Establecer el color de relleno para cada forma rectangular.
        miter_shape.getFillFormat().setFillType(FillType.Solid)
        miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        bevel_shape.getFillFormat().setFillType(FillType.Solid)
        bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        round_shape.getFillFormat().setFillType(FillType.Solid)
        round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        # Establecer el ancho de la línea.
        miter_shape.getLineFormat().setWidth(15)
        bevel_shape.getLineFormat().setWidth(15)
        round_shape.getLineFormat().setWidth(15)

        # Establecer el color de la línea de cada rectángulo.
        miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

        # Establecer el estilo de unión.
        miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
        round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

        # Añadir texto a cada rectángulo.
        miter_shape.getTextFrame().setText("Miter Join Style")
        bevel_shape.getTextFrame().setText("Bevel Join Style")
        round_shape.getTextFrame().setText("Round Join Style")

        # Guardar el archivo PPTX en disco.
        presentation.save("join_styles.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Relleno degradado**

En PowerPoint, Relleno degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de forma que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) de la forma a `Gradient`.
1. Añadir tus dos colores preferidos con posiciones definidas usando el método [addPresetColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/gradientstopcollection/#addPresetColor) de la colección de paradas de degradado expuesta por la clase [GradientFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/gradientformat/).
1. Guardar la presentación modificada como archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Aplicar formato de degradado al elipse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Establecer la dirección del degradado.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Añadir dos paradas de degradado.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Guardar el archivo PPTX en disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

## **Relleno de patrón**

En PowerPoint, Relleno de patrón es una opción de formato que permite aplicar un diseño de dos colores —como puntos, rayas, tramados o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el aspecto visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, aún puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) de la forma a `Pattern`.
1. Seleccionar un estilo de patrón entre las opciones predefinidas.
1. Establecer el [Background Color](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternformat/#getBackColor) del patrón.
1. Establecer el [Foreground Color](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternformat/#getForeColor) del patrón.
1. Guardar la presentación modificada como archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Establecer el tipo de relleno a Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Establecer el estilo del patrón.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Establecer los colores de fondo y primer plano del patrón.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Guardar el archivo PPTX en disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma, utilizando efectivamente la imagen como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) a partir de la imagen que deseas usar.
1. Pasar la imagen al método `SlidesPicture.setImage`.
1. Guardar la presentación modificada como archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen del loto](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Establecer el tipo de relleno a Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Establecer el modo de relleno de imagen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Cargar una imagen y añadirla a los recursos de la presentación.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Establecer la imagen.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Guardar el archivo PPTX en disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Imagen en mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la clase [PictureFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Establece el modo de relleno de la imagen —`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileFlip): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [setTileOffsetX](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Establece la compensación horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Establece la compensación vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileScaleX): Define la escala horizontal del mosaico como porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#setTileScaleY): Define la escala vertical del mosaico como porcentaje.

El siguiente ejemplo de código muestra cómo agregar una forma rectangular con un relleno de imagen en mosaico y configurar las opciones del mosaico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    first_slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma rectangular.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Establecer el tipo de relleno de la forma a Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Cargar la imagen y añadirla a los recursos de la presentación.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Asignar la imagen a la forma.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configurar el modo de relleno de imagen y las propiedades del mosaico.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Guardar el archivo PPTX en disco.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, Relleno de color sólido es una opción de formato que rellena una forma con un único color uniforme. Este color de fondo plano se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno que prefieras a la forma.
1. Guardar la presentación modificada como archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Establecer el tipo de relleno a Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Establecer el color de relleno.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Guardar el archivo PPTX en disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno sólido, degradado, de imagen o de textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo u objetos subyacentes se vean parcialmente.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa en el color usado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) a `Solid`.
1. Usar [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma automática rectangular sólida.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Añadir una forma automática rectangular transparente sobre la forma sólida.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Guardar el archivo PPTX en disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con necesidades específicas de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer la propiedad de rotación de la forma al ángulo deseado.
1. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanciar la clase Presentation que representa un archivo de presentación.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una auto forma del tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Rotar la forma en 5 grados.
    shape.setRotation(5)

    # Guardar el archivo PPTX en disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/).

Para agregar efectos de bisel 3D a una forma, sigue estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma a la diapositiva.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Establecer las propiedades ThreeDFormat de la forma.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Guardar la presentación como archivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva.
1. Utilizar los métodos [setCameraType](https://reference.aspose.com/slides/es/python-java/aspose.slides/camera/#setCameraType) y [setLightType](https://reference.aspose.com/slides/es/python-java/aspose.slides/lightrig/#setLightType) para definir la rotación 3D.
1. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Guardar la presentación como archivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar la renderización en blanco y negro para las formas**

El método [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setBlackWhiteMode) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo, y no cambia el relleno, la línea u otro formato de la forma en modo de color normal.

Utiliza un valor de la clase [BlackWhiteMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan tonos de gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` preserva el color normal y `Hidden` omite la forma en modo blanco y negro. `NotDefined` significa que no se ha asignado ningún modo a nivel de forma.

El siguiente código Python crea una forma coloreada y hace que aparezca gris en modo de visualización blanco y negro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Mantener el relleno naranja en modo color, pero representar la forma con color gris en modo blanco y negro.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza un tono gris porque su modo está configurado a `Gray`. Esto permite conservar una diapositiva a todo color mientras se define una apariencia distinta para la impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código Python muestra cómo restablecer el formato de una diapositiva y revertir la posición, tamaño y formato de todas las formas con marcadores de posición en la [LayoutSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/) a sus valores predeterminados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿El formato de la forma afecta al tamaño final del archivo de la presentación?**

Solo de manera mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de forma como colores, efectos y degradados se almacenan como metadatos y prácticamente no añaden tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que comparten un formato idéntico para poder agruparlas?**

Compara las principales propiedades de formato de cada forma —relleno, línea y ajustes de efecto. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión posterior de estilos.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una plantilla de diapositivas o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.