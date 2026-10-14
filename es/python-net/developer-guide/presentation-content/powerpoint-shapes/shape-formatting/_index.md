---
title: Formatear formas de PowerPoint en Python
linktitle: Formato de forma
type: docs
weight: 20
url: /es/python-net/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de boceto
- línea de forma de boceto
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- representación en blanco y negro de forma
- representación en escala de grises de forma
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en Python usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes darles formato modificando o aplicando efectos a sus contornos. Además, puedes dar formato a las formas especificando configuraciones que controlan cómo se rellenan sus interiores.

![formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para Python proporciona clases y propiedades que te permiten dar formato a las formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los pasos siguientes describen el procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) de la forma.
1. Establece el ancho de la línea.
1. Establece el [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) de la forma.
1. Establece el color de línea para la forma.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código Python muestra cómo dar formato a un `AutoShape` rectangular:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Rectángulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Eliminar el relleno de la forma rectangular para que solo sus líneas sean visibles.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Aplicar formato a las líneas del rectángulo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Establecer el color de la línea del rectángulo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Guardar el archivo PPTX en disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Usa [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) para acceder a la configuración de la línea, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) para acceder a la configuración del boceto, y [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

El siguiente código Python muestra cómo aplicar un efecto [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Acceder al formato de línea de la forma y su formato de boceto.
    sketch_format = shape.line_format.sketch_format

    # Aplicar un efecto de boceto.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Leer el efecto de boceto asignado directamente a la forma.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eliminar el efecto de boceto.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

El valor devuelto por `SketchFormat.sketch_type` representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, usa [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), accede a la propiedad `sketch_format` del objeto devuelto y lee su propiedad `sketch_type`. El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza la configuración **Redondo**. Sin embargo, si estás dibujando una forma con ángulos agudos, puede que prefieras la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código Python muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) utilizando los ajustes de tipo de unión Miter, Bevel y Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

	# Obtener la primera diapositiva.
	slide = presentation.slides[0]

	# Añadir tres formas automáticas del tipo Rectángulo.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Establecer el color de relleno de cada forma rectangular.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Establecer el ancho de la línea.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Establecer el color de la línea de cada rectángulo.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Establecer el estilo de unión.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Añadir texto a cada rectángulo.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Guardar el archivo PPTX en disco.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno degradado**

En PowerPoint, el Relleno Degradado es una opción de formato que permite aplicar una transición continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `GRADIENT`.
1. Añade tus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección `gradient_stops` expuesta por la clase [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código Python muestra cómo aplicar un efecto de relleno degradado a una elipse:

```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Elipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplicar formato de degradado a la elipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Establecer la dirección del degradado.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Añadir dos paradas de degradado.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Guardar el archivo PPTX en disco.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/es/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puedes seleccionar un estilo de renderizado sin modificar el relleno degradado almacenado en la presentación.

## **Relleno de patrón**

En PowerPoint, el Relleno de Patrón es una opción de formato que permite aplicar un diseño bicolor —como puntos, rayas, tramas cruzadas o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el aspecto visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `PATTERN`.
1. Elige un estilo de patrón entre las opciones predefinidas.
1. Establece el [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) del patrón.
1. Establece el [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) del patrón.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código Python muestra cómo aplicar un relleno de patrón a un rectángulo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Rectángulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Establecer el tipo de relleno a Patrón.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Establecer el estilo de patrón.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Establecer los colores de fondo y primer plano del patrón.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Guardar el archivo PPTX en disco.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Relleno de Imagen es una opción de formato que permite insertar una imagen dentro de una forma, utilizándola efectivamente como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `PICTURE`.
1. Establece el modo de relleno de imagen a `TILE` (o cualquier otro modo preferido).
1. Crea un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) a partir de la imagen que deseas usar.
1. Asigna esta imagen a la propiedad `picture.image` del `picture_fill_format` de la forma.
1. Guarda la presentación modificada como un archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen del loto](lotus.png)

El siguiente código Python muestra cómo rellenar una forma con la imagen:

```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Rectángulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Establecer el tipo de relleno a Imagen.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Establecer el modo de relleno de imagen.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Cargar una imagen y añadirla a los recursos de la presentación.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Establecer la imagen.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Guardar el archivo PPTX en disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Imagen de mosaico como textura**

Si deseas establecer una imagen de mosaico como textura y personalizar el comportamiento del mosaico, puedes usar las siguientes propiedades de la clase [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Define el modo de relleno de imagen —`TILE` o `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Define el desplazamiento horizontal del mosaico (en puntos) respecto al origen de la forma.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Define el desplazamiento vertical del mosaico (en puntos) respecto al origen de la forma.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Define la escala horizontal del mosaico como porcentaje.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Define la escala vertical del mosaico como porcentaje.

El siguiente fragmento de código muestra cómo añadir una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de mosaico:

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    first_slide = presentation.slides[0]

    # Añadir una forma automática rectangular.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Establecer el tipo de relleno de la forma a Imagen.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Cargar la imagen y añadirla a los recursos de la presentación.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Asignar la imagen a la forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configurar el modo de relleno de imagen y las propiedades de mosaico.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Guardar el archivo PPTX en disco.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Relleno de Color Sólido es una opción de formato que rellena una forma con un único color uniforme. Este fondo liso se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `SOLID`.
1. Asigna el color de relleno que prefieras a la forma.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código Python muestra cómo aplicar un relleno de color sólido a un rectángulo en una diapositiva de PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Rectángulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Establecer el tipo de relleno a Sólido.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Establecer el color de relleno.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Guardar el archivo PPTX en disco.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno de color sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia mayor hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa del color utilizado para el relleno. Así es como se hace:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el tipo de relleno a `SOLID`.
1. Usa `Color.from_argb` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guarda la presentación.

El siguiente código Python muestra cómo aplicar un color de relleno transparente a un rectángulo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]
    
    # Añadir una forma automática rectangular sólida.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Añadir una forma automática rectangular transparente sobre la forma sólida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece la propiedad `rotation` de la forma al ángulo deseado.
1. Guarda la presentación.

El siguiente código Python muestra cómo rotar una forma 5 grados:

```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una forma automática del tipo Rectángulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Rotar la forma 5 grados.
    shape.rotation = 5

    # Guardar el archivo PPTX en disco.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Para agregar efectos de bisel 3D a una forma, sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Configura el [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guarda la presentación.

El siguiente código Python muestra cómo aplicar efectos de bisel 3D a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Añadir una forma a la diapositiva.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Establecer las propiedades ThreeDFormat de la forma.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Guardar la presentación como un archivo PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) y el [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) de la forma para definir la rotación 3D.
1. Guarda la presentación.

El siguiente código Python muestra cómo aplicar efectos de rotación 3D a una forma:

```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Guardar la presentación como un archivo PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar la representación en blanco y negro de las formas**

La propiedad [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí sola y no modifica el relleno, la línea u otro formato de la forma en modo color normal.

Utiliza un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `AUTOMATIC` permite que la aplicación de renderizado elija la conversión, `GRAY` y `LIGHT_GRAY` utilizan colores gris, `BLACK_WHITE` usa solo negro y blanco, `BLACK` y `WHITE` forzan un único color, `COLOR` conserva el color normal y `HIDDEN` omite la forma en modo blanco y negro. `NOT_DEFINED` indica que no se ha asignado ningún modo a nivel de forma.

El siguiente código Python crea una forma coloreada y hace que aparezca gris en modo de visualización blanco y negro:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Mantener el relleno naranja en modo color, pero representar la forma con color gris en modo blanco y negro.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza el color gris porque su modo está configurado a `GRAY`. Esto permite conservar una diapositiva a todo color mientras se define una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código Python muestra cómo restablecer el formato de una diapositiva y revertir la posición, el tamaño y el formato de todas las formas con marcadores de posición en la [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) a sus valores predeterminados:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿El formato de la forma afecta al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de la forma como colores, efectos y degradados se almacenan como metadatos y prácticamente no añaden tamaño adicional.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para poder agruparlas?**

Compara las propiedades clave de formato de cada forma —relleno, línea y ajustes de efectos. Si todos los valores correspondientes coinciden, trata sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Almacena formas de muestra con los estilos deseados en una presentación de diapositivas plantilla o en un archivo de plantilla .POTX. Cuando crees una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.