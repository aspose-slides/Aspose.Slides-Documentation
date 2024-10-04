---
title: Formato de Forma
type: docs
weight: 20
url: /python-net/shape-formatting/
keywords: "Formato de forma, formato de líneas, formato de estilos de unión, relleno de degradado, relleno de patrón, relleno de imagen, relleno de color sólido, rotar formas, efectos de bisel 3d, efecto de rotación 3d, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Formato de forma en presentación de PowerPoint en Python"
---

En PowerPoint, puedes agregar formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes formatear las formas modificando o aplicando ciertos efectos a sus líneas constitutivas. Además, puedes formatear las formas especificando configuraciones que determinan cómo se llenan (el área dentro de ellas).

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides para Python a través de .NET** proporciona interfaces y propiedades que te permiten formatear formas basadas en opciones conocidas en PowerPoint.

## **Formato de Líneas**

Usando Aspose.Slides, puedes especificar tu estilo de línea preferido para una forma. Estos pasos describen un procedimiento para ello:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece un color para las líneas de la forma.
5. Establece el ancho para las líneas de la forma.
6. Establece el [estilo de línea](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) para la línea de la forma.
7. Establece el [estilo de guiones](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) para la línea de la forma.
8. Escribe la presentación modificada como un archivo PPTX.

Este código Python demuestra una operación donde formateamos un rectángulo `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Agrega una forma autoshape rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Establece el color de relleno para la forma rectángulo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Aplica algún formato a las líneas del rectángulo
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Establece el color para la línea del rectángulo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Escribe el archivo PPTX en disco
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **Formato de Estilos de Unión**

Estas son las 3 opciones de tipo de unión:

* Redondeada
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (o la esquina de una forma), utiliza la configuración **Redondeada**. Sin embargo, si buscas dibujar una forma con ángulos muy agudos, puede que desees seleccionar **Inglete**.

![join-style-powerpoint](join-style-powerpoint.png)

Este código Python demuestra una operación donde se crearon 3 rectángulos (la imagen de arriba) con las configuraciones de tipo de unión Inglete, Bisel y Redondeada:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
	# Obtiene la primera diapositiva
	sld = pres.slides[0]

	# Agrega 3 formas autoshape rectángulo
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# Establece el color de relleno para la forma rectángulo
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# Establece el ancho de la línea
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# Establece el color para la línea del rectángulo
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Establece el Estilo de Unión
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Agrega texto a cada rectángulo
	shp1.text_frame.text = "Este es el estilo de unión Inglete"
	shp2.text_frame.text = "Este es el estilo de unión Bisel"
	shp3.text_frame.text = "Este es el estilo de unión Redondeada"

	# Escribe el archivo PPTX en disco
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno de Degradado**
En PowerPoint, Relleno de Degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores en una configuración donde un color se desvanece gradualmente y cambia a otro color.

Así es como usas Aspose.Slides para aplicar un relleno de degradado a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `Degradado`.
5. Agrega tus 2 colores preferidos con posiciones definidas utilizando los métodos `Add` expuestos por la colección `GradientStops` asociada a la clase `GradientFormat`.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Python demuestra una operación donde se utilizó el efecto de relleno de degradado en una elipse:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo de presentación
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Agrega una forma autoshape elipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Aplica el formato de degradado a la elipse
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Establece la dirección del degradado
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Agrega 2 Paradas de Degradado
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Escribe el archivo PPTX en disco
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno de Patrón**
En PowerPoint, Relleno de Patrón es una opción de formato que permite aplicar un diseño de dos colores compuesto por puntos, rayas, tramas o cuadros a una forma. Además, tienes la opción de seleccionar tus colores preferidos para el primer plano y el fondo de tu patrón.

Aspose.Slides proporciona más de 45 estilos predefinidos que se pueden utilizar para formatear formas y enriquecer presentaciones. Incluso después de elegir un patrón predefinido, aún puedes especificar los colores que el patrón debe contener.

Así es como usas Aspose.Slides para aplicar un relleno de patrón a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `Patrón`.
5. Establece tu estilo de patrón preferido para la forma.
6. Establece el Color de Fondo para el [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. Establece el Color de Primer Plano para el [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. Escribe la presentación modificada como un archivo PPTX.

Este código Python demuestra una operación donde se utilizó un relleno de patrón para embellecer un rectángulo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo de presentación
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Agrega una forma autoshape rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Establece el tipo de relleno a Patrón
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Establece el estilo del patrón
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Establece los colores de fondo y primer plano del patrón
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Escribe el archivo PPTX en disco
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno de Imagen**
En PowerPoint, Relleno de Imagen es una opción de formato que permite colocar una imagen dentro de una forma. Esencialmente, puedes usar una imagen como fondo de la forma.

Así es como usas Aspose.Slides para llenar una forma con una imagen:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `Imagen`.
5. Establece el Modo de Relleno de Imagen a Azulejo.
6. Crea un objeto `IPPImage` utilizando la imagen que se utilizará para llenar la forma.
7. Establece la propiedad `Picture.Image` del objeto `PictureFillFormat` al `IPPImage` que fue creado recientemente.
8. Escribe la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo llenar una forma con una imagen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Agrega una forma autoshape rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Establece el tipo de relleno a Imagen
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Establece el modo de relleno de imagen
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Establece la imagen
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # Escribe el archivo PPTX en disco
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno de Color Sólido**
En PowerPoint, Relleno de Color Sólido es una opción de formato que permite llenar una forma con un solo color. El color elegido es típicamente un color plano. El color se aplica como fondo de la forma sin efectos especiales o modificaciones.

Así es como usas Aspose.Slides para aplicar un relleno de color sólido a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la forma a `Sólido`.
5. Establece tu color preferido para la forma.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo aplicar el relleno de color sólido a una caja en PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Obtiene la primera diapositiva
    slide = presentation.slides[0]

    # Agrega una forma autoshape rectángulo
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Establece el tipo de relleno a Sólido
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Establece el color para el rectángulo
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Escribe el archivo PPTX en disco
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Transparencia**

En PowerPoint, cuando llenas formas con colores sólidos, degradados, imágenes o texturas, puedes especificar el nivel de transparencia que determina la opacidad de un relleno. De esta manera, por ejemplo, si estableces un bajo nivel de transparencia, el objeto de la diapositiva o el fondo detrás (de la forma) se muestra.

Aspose.Slides te permite establecer el nivel de transparencia para una forma de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Usa `Color.FromArgb` con el componente alfa establecido.
5. Guarda el objeto como un archivo de PowerPoint.

Este código Python demuestra el proceso:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Agrega una forma sólida
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # Agrega una forma transparente sobre la sólida
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rotar Formas**
Aspose.Slides te permite rotar una forma agregada a una diapositiva de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Rota la forma por los grados necesarios.
5. Escribe la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo rotar una forma 90 grados:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Agrega una forma autoshape rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Rota la forma 90 grados
    shp.rotation = 90

    # Escribe el archivo PPTX en disco
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Efectos de Bisel 3D**
Aspose.Slides para Python a través de .NET te permite agregar efectos de bisel 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Establece tus parámetros preferidos para las propiedades de [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la forma.
5. Escribe la presentación a disco.

Este código Python te muestra cómo agregar efectos de bisel 3D a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea una instancia de la clase Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Agrega una forma a la diapositiva
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Establece las propiedades de ThreeDFormat de la forma
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Escribe la presentación como un archivo PPTX
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Efecto de Rotación 3D**
Aspose.Slides te permite aplicar efectos de rotación 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) a la diapositiva.
4. Especifica tus figuras preferidas para CameraType y LightType.
5. Escribe la presentación a disco.

Este código Python te muestra cómo aplicar efectos de rotación 3D a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea una instancia de la clase Presentation
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **Restablecer Formato**

Este código Python te muestra cómo restablecer el formato en una diapositiva y revertir la posición, tamaño y formato de cada forma que tiene un marcador en [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) a sus valores predeterminados:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # cada forma en la diapositiva que tiene un marcador en el diseño será revertida
        slide.reset()
```