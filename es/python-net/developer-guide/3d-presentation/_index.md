---
title: Presentación 3D
type: docs
weight: 232
url: /es/python-net/3d-presentation/
keywords:
- 3D
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusión 3D
- degradado 3D
- texto 3D
- presentación de PowerPoint
- Python
- Aspose.Slides para Python a través de .NET
description: "Presentación de PowerPoint 3D en Python"
---


## Visión general
¿Cómo sueles crear una presentación de PowerPoint 3D?
Microsoft PowerPoint permite crear presentaciones 3D en términos de que podemos añadir modelos 3D allí, aplicar efectos 3D en formas, 
crear texto 3D, subir gráficos 3D a la presentación, crear animaciones 3D de PowerPoint. 

Crear efectos 3D tiene un gran impacto en la mejora de tu presentación a una presentación 3D, y puede ser la implementación más fácil de una presentación 3D. 
Desde la versión 20.9 de Aspose.Slides, se ha añadido un **motor 3D multiplataforma**. El nuevo motor 3D permite 
exportar y rasterizar formas y texto con efectos 3D. En las versiones anteriores, 
las formas de las diapositivas con efectos 3D aplicados se renderizaban de manera plana. Pero, ahora es posible 
renderizar formas con un **3D completo**.
Además, ahora es posible crear formas con efectos 3D a través de la API pública de Slides.

En la API de Aspose.Slides, para hacer que 
una forma se convierta en una forma 3D de PowerPoint, utiliza la propiedad [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), 
que hereda las características de la interfaz [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
y [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): establece el bisel en la forma, define el tipo de bisel (por ejemplo, Ángulo, Círculo, Suave), define la altura y el ancho del bisel.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): se utiliza para imitar movimientos de cámara alrededor del objeto. En otras palabras, al establecer la rotación de la cámara, zoom y otras propiedades, puedes interactuar con tus 
formas como si fueran el modelo 3D en PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
y [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): establece propiedades de contorno para hacer que la forma se vea como una forma 3D de PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
y [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): se utilizan para hacer que la forma sea tridimensional, lo que significa convertir una forma 2D en una forma 3D, 
ajustando su profundidad o extruyéndola.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): puede crear un efecto de luz en una forma 3D. La lógica de esta propiedad está relacionada con la cámara, puedes establecer la rotación de la luz 
en relación con la forma 3D y elegir el tipo de luz.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): establecer el tipo de material de la forma 3D puede dar un efecto más realista. La propiedad proporciona un conjunto de materiales predefinidos, como: 
Metal, Plástico, Polvo, Mate, etc.  

Todas las características 3D se pueden aplicar tanto a formas como a texto. Vamos a ver cómo acceder a las propiedades mencionadas anteriormente y luego examinarlas en detalles paso a paso:
```py 
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

La miniatura renderizada se ve así:

![todo:image_alt_text](img_01_01.png)

## Rotación 3D
Es posible rotar formas 3D de PowerPoint en un plano 3D, lo que aporta más interactividad. Para rotar una forma 3D en PowerPoint, normalmente utilizas el siguiente menú:

![todo:image_alt_text](img_02_01.png)

En la API de Aspose.Slides, la rotación de formas 3D se puede gestionar utilizando la propiedad [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... establecer otros parámetros de la escena 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## Profundidad 3D y Extrusión
Para aportar la tercera dimensión a tu forma y convertirla en una forma 3D, utiliza las propiedades [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
y [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... establecer otros parámetros de la escena 3D

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

Normalmente, utilizas el menú de Profundidad en PowerPoint para establecer la profundidad de la forma 3D de PowerPoint:

![todo:image_alt_text](img_02_02.png)


## Degradado 3D
El degradado se puede utilizar para llenar el color de la forma 3D de PowerPoint. Vamos a crear una forma con color de relleno degradado y aplicar un efecto 3D en ella:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "Degradado 3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Y aquí está el resultado:

![todo:image_alt_text](img_02_03.png)

Además de un color de relleno degradado, es posible llenar formas con una imagen:
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... configuración 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


Así es como se ve:

![todo:image_alt_text](img_02_04.png)

## Texto 3D (WordArt)
Aspose.Slides permite aplicar 3D al texto también. Para crear un texto 3D, es posible utilizar el efecto de transformación de WordArt:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "Texto 3D"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # configuración del efecto de transformación "Arco hacia arriba"
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Aquí está el resultado:

![todo:image_alt_text](img_02_05.png)


## No soportado - Próximamente
Las siguientes características 3D de PowerPoint no están soportadas aún: 
- Bisel
- Material
- Contorno
- Iluminación

Continuamos mejorando nuestro motor 3D, y estas características son objeto de una futura implementación.