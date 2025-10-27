---
title: Crear presentaciones 3D en Python
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentation
- 3D rotation
- 3D depth
- 3D extrusion
- 3D gradient
- 3D text
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Genere presentaciones 3D interactivas en Python con Aspose.Slides sin esfuerzo. Exporte rápidamente a formatos PowerPoint y OpenDocument para un uso versátil."
---

## **Resumen**

¿Cómo suele crear una presentación 3D en PowerPoint? Microsoft PowerPoint le permite añadir modelos 3D, aplicar efectos 3D a formas, crear texto 3D, insertar gráficos 3D y construir animaciones 3D.

Crear efectos 3D tiene un gran impacto y a menudo es la forma más sencilla de convertir una presentación estándar en una presentación 3D. Desde Aspose.Slides 20.9, se ha añadido un nuevo **motor 3D multiplataforma**. Este motor permite exportar y rasterizar formas y texto con efectos 3D. En versiones anteriores, las formas con efectos 3D se renderizaban planas; ahora pueden renderizarse con **3D completo**. También puede crear formas con efectos 3D a través de la API de Aspose.Slides.

En la API de Aspose.Slides, para convertir una forma en una forma 3D de PowerPoint, utilice la propiedad [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/), que expone los miembros de la clase [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) y [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): establezca biseles, elija un tipo de bisel (p. ej., Angle, Circle, SoftRound) y defina la altura y anchura del bisel.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): simule el movimiento de la cámara alrededor del objeto; ajustando la rotación, el zoom y otras propiedades de la cámara, podrá manipular formas como modelos 3D en PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) y [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): establezca propiedades de contorno para que una forma parezca un objeto 3D de PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/), [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) y [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): haga que una forma sea tridimensional estableciendo su profundidad o extruyéndola.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): cree efectos de iluminación en una forma 3D; al igual que con la cámara, puede establecer la rotación de la luz respecto a la forma 3D y elegir un tipo de luz.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): seleccione un material para que la forma 3D resulte más realista. Los materiales predefinidos incluyen Metal, Plastic, Powder, Matte, entre otros.

Todas las funciones 3D pueden aplicarse tanto a formas como a texto. Las secciones siguientes muestran cómo acceder a estas propiedades y examinarlas paso a paso.

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

## **Rotación 3D**

Puede rotar formas 3D de PowerPoint en el espacio tridimensional para añadir interactividad. Para rotar una forma 3D en PowerPoint, use el siguiente menú:

![todo:image_alt_text](img_02_01.png)

En la API de Aspose.Slides, controla la rotación 3D de una forma mediante la propiedad [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **Profundidad y Extrusión 3D**

Para añadir una tercera dimensión a su forma y hacerla realmente 3D, utilice las propiedades [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) y [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

En PowerPoint, normalmente se usa el menú **Depth** para establecer la profundidad de una forma 3D:

![todo:image_alt_text](img_02_02.png)

## **Degradado 3D**

Un degradado puede usarse para rellenar una forma 3D de PowerPoint. Creemos una forma con relleno degradado y apliquemos un efecto 3D:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
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

Y este es el resultado:

![todo:image_alt_text](img_02_03.png)

Además de los rellenos degradados, puede rellenar formas con una imagen:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... setup 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Así es como se ve:

![todo:image_alt_text](img_02_04.png)

## **Texto 3D (WordArt)**

Aspose.Slides le permite aplicar efectos 3D también al texto. Para crear texto 3D, puede usar el efecto de transformación WordArt:

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
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # setup "Arch Up" WordArt transform effect
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

Este es el resultado:

![todo:image_alt_text](img_02_05.png)

## **Preguntas frecuentes**

**¿Se conservarán los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a formatos compatibles ([imágenes](/slides/es/python-net/convert-powerpoint-to-png/), [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores “efectivos” (finales) de los parámetros 3D que tengan en cuenta temas, herencia, etc.?**

Sí. Slides ofrece API para [leer valores efectivos](/slides/es/python-net/shape-effective-properties/) (incluidos los de 3D: iluminación, biseles, etc.) de modo que pueda ver la configuración final aplicada.

**¿Los efectos 3D funcionan al convertir una presentación a video?**

Sí. Al [generar fotogramas para el video](/slides/es/python-net/convert-powerpoint-to-video/), los efectos 3D se renderizan de la misma forma que en las [imágenes exportadas](/slides/es/python-net/convert-powerpoint-to-png/).