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
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en Python vía Java con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides for Python via Java puede crear, editar, preservar y renderizar el formato 3D estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos de degradado o imagen, y texto 3D.

{{% alert color="info" title="Note" %}}
Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exporta una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Use el método [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat) para aplicar formato 3D a una forma. El método devuelve [ThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/), que controla la escena 3D para esa forma.

Para texto, use el método [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los miembros de API más importantes son:

| Miembro API | Qué controla | Cuándo usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getCamera) | Punto de vista, tipo de cámara predefinida, rotación, zoom y perspectiva. | Rotar el objeto en espacio 3D o coincidir con un preset de rotación 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getLightRig) | Preset de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getMaterial) y [setMaterial](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setMaterial) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, más suave, brillante o metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getExtrusionHeight) y [setExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Cuán lejos la forma se extiende hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [getExtrusionColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getExtrusionColor) | Color de los laterales extruidos. | Hacer visible la profundidad o coordinar el color del lateral con el relleno frontal. |
| [getDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getDepth) y [setDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setDepth) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad para formas o texto, especialmente junto con los ajustes de bisel y material. |
| [getBevelTop](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getBevelTop) y [getBevelBottom](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getBevelBottom) | Bordes elevados o redondeados en las caras frontal y trasera. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [getContourColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getContourColor) y [getContourWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getContourWidth) y [setContourWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setContourWidth) | Contorno alrededor del objeto 3D. | Destacar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de ajustes antes de parecer convincentemente 3D:

- Configuración de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuración de luz, porque la iluminación hace que las caras y los laterales sean legibles.
- Configuración de material, porque la superficie afecta cómo se renderiza la luz.
- Configuración de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados, y la altura de extrusión es de 100 puntos. El ejemplo renderiza la diapositiva a una imagen PNG al doble de sus dimensiones predeterminadas y guarda la presentación como PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel de Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que establece a través de la API de cámara.

![Panel de rotación 3D de PowerPoint con valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, acceda a la cámara mediante [ThreeDFormat.getCamera](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getCamera). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z a 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

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

Utilice la cámara cuando necesite cambiar cómo el observador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D usado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Use [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setExtrusionHeight) para establecer el grosor y [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getExtrusionColor) para acceder al color lateral. Este ejemplo da a un rectángulo una extrusión de 100 puntos con lados púrpuras y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

El método [ThreeDFormat.setDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setDepth) establece la profundidad de una forma 3D. El método [setExtrusionHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#setExtrusionHeight) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Usar rellenos de degradado o imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puede aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un degradado azul‑a‑naranja a la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 marcan el inicio y fin del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se renderiza a una imagen PNG al doble de sus dimensiones predeterminadas:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

![Rectángulo 3D renderizado con un relleno de degradado azul a naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añada la imagen a la presentación y asígnela al relleno de la forma. Este ejemplo requiere un archivo existente llamado "image.jpg" en el directorio de trabajo. Estira la foto para llenar el rectángulo, aplica una extrusión de 150 puntos y establece la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

La foto se renderiza en la cara frontal, mientras que la extrusión se renderiza como la superficie lateral 3D:

![Rectángulo 3D renderizado con un relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja y blanco, aplica un arco ascendente y configura los ajustes 3D mediante [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz en grados. El relleno y contorno de la forma se ocultan para que solo el texto sea visible. El ejemplo renderiza una imagen PNG al doble de las dimensiones predeterminadas de la diapositiva y guarda la presentación como PPTX:

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

![Texto 3D renderizado con una transformación arqueada de WordArt, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para mantener el texto legible mientras se preserva la apariencia 3D de una forma, llame a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setKeepTextFlat) a través de [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getTextFrameFormat). Cuando el valor es `True`, el texto permanece fuera de la escena 3D. Cuando es `False`, el texto participa en la escena y sigue su orientación 3D.

Este ajuste no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat). También es diferente de la rotación ordinaria. [Shape.setRotation](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setRotation) rota la forma en el plano de la diapositiva, mientras que [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setRotationAngle) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autocontenido crea un rectángulo azul con texto y lo clona al lado del original. Ambas formas tienen el mismo formato 3D; solo difiere el ajuste de texto: `False` a la izquierda y `True` a la derecha. Los ángulos de cámara están en grados y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y renderiza la diapositiva comparativa a PNG al doble de sus dimensiones predeterminadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

A la izquierda, el texto sigue la orientación 3D. A la derecha, permanece plano y más fácil de leer. Ambos rectángulos conservan la misma extrusión visible y orientación 3D.

![Rectángulos 3D lado a lado: el texto sigue la orientación 3D a la izquierda y permanece plano a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderiza diapositivas a [PNG](/slides/es/python-java/convert-powerpoint-to-png/), exporta a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), exporta a [HTML](/slides/es/python-java/convert-powerpoint-to-html/), o genera fotogramas para [video conversion](/slides/es/python-java/convert-powerpoint-to-video/).

Tenga en cuenta los siguientes puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede rotarse por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, luz, material, extrusión, relleno y escalado de la diapositiva.
- Si necesita inspeccionar valores de formato heredados o basados en temas, lea las [effective shape properties](/slides/es/python-java/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza los efectos 3D de PowerPoint para formas y texto. No hace que las imágenes, PDFs o páginas HTML exportadas sean escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D permanece editable en PowerPoint donde el formato lo permite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo trata sobre efectos 3D.

**¿Qué ajustes son necesarios para una forma 3D visible?**

Como mínimo, establezca una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configure una luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Use [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getThreeDFormat) para el cuerpo de la forma y [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de video?**

Sí. Aspose.Slides renderiza los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas utilizados para la conversión a video. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales de 3D después de aplicar herencia y ajustes de tema?**

Sí. Use las APIs de formato efectivo descritas en [Shape Effective Properties](/slides/es/python-java/shape-effective-properties/) para leer la cámara final, luz, bisel y valores 3D relacionados.