---
title: Crear efectos 3D en presentaciones usando Python
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusión 3D
- degradado 3D
- texto 3D
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en Python con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Descripción general**

Aspose.Slides for Python via .NET puede crear, editar, preservar y renderizar formato 3D estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos degradados o de imagen, y texto 3D.

{{% alert color="primary" %}}
Este artículo trata de los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza la propiedad [Shape.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/three_d_format/) para aplicar formato 3D a una forma. La propiedad expone [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/), que controla la escena 3D para esa forma.

Para texto, utiliza la propiedad [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Las propiedades más importantes son:

| Propiedad | Qué controla | Cuándo usarlo |
|---|---|---|
| [camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/camera/) | Punto de vista, tipo de cámara predefinido, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un ajuste predefinido de rotación 3D de PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/light_rig/) | Configuración de luz predefinida, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [material](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/material/) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) | Cuán lejos se extiende la forma desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [extrusion_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_color/) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color lateral con el relleno frontal. |
| [depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/depth/) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad de formas o texto, especialmente junto con biseles y material. |
| [bevel_top](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/bevel_top/) y [bevel_bottom](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordes elevados o redondeados en las caras frontal y posterior. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [contour_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/contour_color/) y [contour_width](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/contour_width/) | Contorno alrededor del objeto 3D. | Resaltar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de ajustes antes de que parezca convincentemente 3D:

- Ajustes de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Ajustes de luz, porque la iluminación permite que las caras y los lados sean perceptibles.
- Ajustes de material, porque la superficie afecta cómo se renderiza la luz.
- Ajustes de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal, aplica formato 3D, guarda la presentación como PPTX y renderiza la diapositiva a una imagen PNG.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces a través de la API de cámara.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

En Aspose.Slides, establece el tipo de cámara y la rotación mediante [ThreeDFormat.camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Utiliza la cámara cuando necesites cambiar la forma en que el observador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad define este grosor visible, y el control de color define el color de las caras laterales.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Establece [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) para el grosor y [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_color/) para el color lateral:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Utiliza [ThreeDFormat.depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/depth/) cuando necesites trabajar directamente con el valor de profundidad de PowerPoint o combinar profundidad con bisel, material y efectos de texto. En muchos escenarios de forma, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) es el ajuste más claro porque expresa directamente la extrusión visible.

## **Usar rellenos degradados o de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un relleno degradado a la forma y un color de extrusión más oscuro a los lados:

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
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

La salida renderizada mantiene el degradado en la cara frontal y renderiza la extrusión por separado:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Para usar un relleno de imagen, añade la imagen a la presentación y asígnala al relleno de la forma:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

La imagen se renderiza en la cara frontal, mientras que la extrusión se renderiza como la superficie lateral 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las letras mismas necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un relleno de patrón, aplica una transformación WordArt y configura los ajustes 3D en [TextFrameFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/):

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

El texto se renderiza como letras 3D curvadas y extruidas:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides preserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto ocurre cuando renderizas diapositivas a [PNG](/slides/es/python-net/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/python-net/convert-powerpoint-to-html/), o generas fotogramas para [video conversion](/slides/es/python-net/convert-powerpoint-to-video/).

Ten en cuenta estos puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el observador después de la exportación.
- La apariencia final depende de la combinación de cámara, rig de luz, material, extrusión, relleno y escala de la diapositiva.
- Si necesitas inspeccionar los valores de formato heredados o basados en el tema, lee las [effective shape properties](/slides/es/python-net/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el observador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint donde el formato lo permite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre efectos 3D.

**¿Qué ajustes son necesarios para que una forma 3D sea visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura un rig de luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Usa [Shape.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/three_d_format/) para el cuerpo de la forma y [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides renderiza los efectos 3D al generar imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales 3D después de que se apliquen la herencia y los ajustes del tema?**

Sí. Utiliza las API de formato efectivo descritas en [Shape Effective Properties](/slides/es/python-net/shape-effective-properties/) para leer la cámara final, rig de luz, bisel y los valores 3D relacionados.