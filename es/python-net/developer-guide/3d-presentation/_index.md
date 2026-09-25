---
title: Crear efectos 3D en presentaciones utilizando Python
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
## **Visión general**

Aspose.Slides for Python via .NET puede crear, editar, conservar y renderizar el formato 3D al estilo de PowerPoint para formas y texto. Este artículo cubre los efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos de degradado o de imagen, y texto 3D.

{{% alert color="info" title="Note" %}}
Este artículo trata de los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza la propiedad [Shape.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/three_d_format/) para aplicar formato 3D a una forma. La propiedad expone [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/), que controla la escena 3D para esa forma.

Para texto, utiliza la propiedad [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Las propiedades más importantes son:

| Propiedad | Qué controla | Cuándo usarla |
|---|---|---|
| [camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/camera/) | Punto de vista, tipo de cámara preestablecida, rotación, zoom y perspectiva. | Rotar el objeto en espacio 3D o coincidir con un preset de rotación 3D de PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/light_rig/) | Preset de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [material](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/material/) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [extrusion_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_color/) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color de los lados con el relleno frontal. |
| [depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/depth/) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad para formas o texto, especialmente junto con los ajustes de bisel y material. |
| [bevel_top](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/bevel_top/) y [bevel_bottom](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordes elevados o redondeados en las caras frontal y posterior. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [contour_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/contour_color/) y [contour_width](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/contour_width/) | Contorno alrededor del objeto 3D. | Resaltar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.  
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean legibles.  
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.  
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados, y la altura de extrusión es de 100 puntos. El ejemplo renderiza la diapositiva a una imagen PNG a doble tamaño y guarda la presentación como PPTX.

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

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel de Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces a través de la API de cámara.

![Panel de rotación 3D de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, accede a la cámara mediante [ThreeDFormat.camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/camera/). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z en 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Utiliza la cámara cuando necesitas cambiar cómo el observador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D usado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad define este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color y altura de extrusión](img_02_02.png)

Establece [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) para el grosor y [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_color/) para el color de los lados. Este ejemplo da al rectángulo una extrusión de 100 puntos con lados morados y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

La propiedad [ThreeDFormat.depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/depth/) define la profundidad de una forma 3D. La propiedad [extrusion_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/extrusion_height/) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Usar degradados o rellenos de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un degradado azul‑a‑naranja a la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 marcan el inicio y el fin del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se renderiza a una imagen PNG a doble tamaño:

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

![Rectángulo 3D renderizado con un relleno degradado azul‑a‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añade la imagen a la presentación y asígnala al relleno de la forma. Este ejemplo requiere un archivo existente llamado "image.jpg" en el directorio de trabajo. Estira la foto para rellenar el rectángulo, aplica una extrusión de 150 puntos y establece la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

La foto se renderiza en la cara frontal, mientras que la extrusión se renderiza como la superficie lateral 3D:

![Rectángulo 3D renderizado con un relleno de foto en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja‑blanco, aplica un arco ascendente y configura los ajustes 3D mediante [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz está en grados. El relleno y el contorno de la forma están ocultos para que solo sea visible el texto. El ejemplo renderiza una imagen PNG a doble tamaño de diapositiva y guarda la presentación como PPTX:

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

![Texto 3D renderizado con una transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para mantener el texto legible mientras se conserva la apariencia 3D de una forma, establece [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/keep_text_flat/) a través de [TextFrame.text_frame_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/text_frame_format/). Cuando el valor es `True`, el texto permanece fuera de la escena 3D. Cuando es `False`, el texto participa en la escena y sigue la orientación 3D.

Esta configuración no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [Shape.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/three_d_format/). También difiere de la rotación ordinaria. [Shape.rotation](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/rotation/) rota la forma en el plano de la diapositiva, mientras que [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/rotation_angle/) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autónomo crea un rectángulo azul con texto y lo clona al lado del original. Ambas formas tienen el mismo formato 3D; solo difiere la configuración del texto: `False` a la izquierda y `True` a la derecha. Los ángulos de cámara están en grados y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y renderiza la diapositiva de comparación a PNG a doble tamaño.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

A la izquierda, el texto sigue la orientación 3D. A la derecha, permanece plano y es más fácil de leer. Ambos rectángulos conservan la misma extrusión visible y orientación 3D.

![Rectángulos 3D lado a lado: keep_text_flat es False a la izquierda y True a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderizas diapositivas a [PNG](/slides/es/python-net/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/python-net/convert-powerpoint-to-html/), o generas fotogramas para la [conversión de vídeo](/slides/es/python-net/convert-powerpoint-to-video/).

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.  
- La apariencia final depende de la combinación de cámara, rig de luz, material, extrusión, relleno y escala de la diapositiva.  
- Si necesitas inspeccionar valores de formato heredados o basados en el tema, lee las [propiedades efectivas de la forma](/slides/es/python-net/shape-effective-properties/).  
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza los efectos 3D de PowerPoint para formas y texto. No hace que las imágenes, PDFs o páginas HTML exportadas sean escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint cuando el formato lo admite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D separado insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto regular de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre los efectos 3D.

**¿Qué ajustes son necesarios para una forma 3D visible?**

Como mínimo, define una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura un rig de luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Usa [Shape.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/three_d_format/) para el cuerpo de la forma y [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides renderiza los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales 3D después de aplicar herencia y ajustes de tema?**

Sí. Usa las API de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/python-net/shape-effective-properties/) para leer la cámara, rig de luz, bisel y valores 3D relacionados finales.