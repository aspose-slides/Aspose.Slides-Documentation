---
title: Crear efectos 3D en presentaciones usando Python
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/python-java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en Python mediante Java con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides for Python via Java puede crear, editar, conservar y renderizar el formato 3D estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, degradados o rellenos de imagen, y texto 3D.

{{% alert color="info" title="Nota" %}}
Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

Instala el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides`, inicia la JVM si es necesario y, a continuación, importa la API. El ejemplo de relleno con imagen requiere un archivo `image.jpg` en el directorio de trabajo.

## **Conceptos de formato 3D**

Usa [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat) para aplicar formato 3D a una forma. El objeto de formato devuelto controla la escena 3D para esa forma.

Para texto, usa [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los miembros de API más importantes son:

| Miembro API | Qué controla | Cuándo usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getCamera) | Punto de vista, tipo de cámara predefinido, rotación, zoom y perspectiva. | Girar el objeto en el espacio 3D o coincidir con un preajuste de rotación 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getLightRig) | Preajuste de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getMaterial) y [setMaterial](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setMaterial) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getExtrusionHeight) y [setExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [getExtrusionColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getExtrusionColor) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color lateral con el relleno frontal. |
| [getDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getDepth) y [setDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setDepth) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad de formas o texto, especialmente junto con biseles y material. |
| [getBevelTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getBevelTop) y [getBevelBottom](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getBevelBottom) | Biseles elevados o redondeados en las caras frontal y trasera. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [getContourColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getContourWidth) y [setContourWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setContourWidth) | Contorno alrededor del objeto 3D. | Realzar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma generalmente necesita cuatro tipos de configuraciones antes de que parezca convincentemente 3D:

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal, aplica formato 3D, guarda la presentación como PPTX y renderiza la diapositiva a una imagen PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo azul 3D renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel **Rotación 3‑D**. Los valores de rotación X, Y y Z corresponden a la rotación que estableces a través de la API de cámara.

![Panel Rotación 3‑D de PowerPoint con valores X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, establece el tipo de cámara y la rotación mediante el formato 3D devuelto por [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Usa la cámara cuando necesites cambiar cómo el observador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva; cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Establece la altura de extrusión para el grosor y el color de extrusión para el color lateral:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Utiliza la configuración de profundidad cuando necesites trabajar directamente con el valor de profundidad de PowerPoint o combinar profundidad con bisel, material y efectos de texto. En muchos escenarios de formas, la altura de extrusión es la configuración más clara porque expresa directamente la extrusión visible.

## **Usar rellenos degradados o de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un relleno degradado a la forma y un color de extrusión más oscuro a los lados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

La salida renderizada mantiene el degradado en la cara frontal y renderiza la extrusión por separado:

![Rectángulo 3D renderizado con un degradado azul‑a‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añade la imagen a la presentación y asígnala al relleno de la forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

La imagen se renderiza en la cara frontal, mientras que la extrusión se renderiza como la superficie lateral 3D:

![Rectángulo 3D renderizado con foto en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de una forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos similares a WordArt donde las letras mismas necesitan extrusión, material, iluminación y configuraciones de cámara.

El siguiente ejemplo crea texto con un relleno de patrón, aplica una transformación WordArt y configura los ajustes 3D en [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El texto se renderiza como letras 3D curvadas y extruidas:

![Texto 3D renderizado con transformación WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto ocurre al renderizar diapositivas a PNG, exportar a PDF, exportar a HTML o generar fotogramas para conversión de vídeo.

Ten en cuenta los siguientes puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede girarse por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, rig de luz, material, extrusión, relleno y escala de la diapositiva.
- Si necesitas inspeccionar valores de formato heredados o basados en el tema, usa la API de formato efectivo.
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint cuando el formato lo permite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo trata sobre efectos 3D.

**¿Qué configuraciones son necesarias para una forma 3D visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también se recomienda establecer un rig de luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Usa [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat) para el cuerpo de la forma y [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides renderiza los efectos 3D al generar imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para conversión de vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores 3D finales después de aplicar herencia y ajustes de tema?**

Sí. Usa [ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getEffective) para leer la cámara final, rig de luz, bisel y valores 3D relacionados.