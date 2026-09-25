---
title: Crear y aplicar efectos WordArt en Python vía Java
linktitle: WordArt
type: docs
weight: 110
url: /es/python-java/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto de sombra
- efecto de reflexión
- efecto de resplandor
- transformación WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crea y personaliza efectos WordArt en Aspose.Slides para Python vía Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Python vía Java."
---
## **Visión general**

Los efectos de WordArt le permiten dar estilo al texto con rellenos, contornos, sombras, reflejos, resplandor, transformaciones y formato 3D. Este artículo explica cómo crear y personalizar estos efectos en presentaciones de PowerPoint usando Aspose.Slides for Python via Java, sin que Microsoft Office esté instalado.

## **Crear una plantilla WordArt sencilla y aplicarla al texto**

Los ejemplos siguientes crean un estilo WordArt sencillo estableciendo el texto, la tipografía, el relleno de patrón y el contorno.

Cada ejemplo crea una nueva presentación y añade un rectángulo a su primera diapositiva; no se necesita ningún archivo de entrada. El primer ejemplo establece el texto a "Aspose.Slides". La posición y dimensiones de la forma se miden en puntos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Establezca la tipografía a Arial Black a 36 puntos para que el formato sea más visible:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Aplique un patrón [SmallGrid](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternstyle/#SmallGrid) con un primer plano naranja oscuro y un fondo blanco, y añada un contorno de texto negro con un ancho de 1 punto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

El texto resultante:

![La plantilla WordArt sencilla](WordArt_template.png)

## **Aplicar otros efectos WordArt**

Los ejemplos siguientes demuestran cómo aplicar sombras, reflejos, resplandor, transformaciones y efectos 3D al texto.

### **Aplicar efectos de sombra externa**

Una sombra externa añade profundidad colocando una sombra detrás del texto. Puede personalizar su color, dirección, distancia, radio de desenfoque, escala y sesgo.

Este ejemplo llama a [enableOuterShadowEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) y establece una sombra negra con un radio de desenfoque de 4 puntos, una dirección de 230 grados y una distancia de 30 puntos. Los valores de escala de 100 conservan el tamaño de la sombra, mientras que el sesgo horizontal la inclina 20 grados. La transformación alfa fija su opacidad al 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

El texto resultante:

![El efecto de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Cuando se utilizan sombras externas y predefinidas juntas, solo se aplica la sombra externa.
- Si se utilizan sombras externas e internas simultáneamente, el efecto resultante depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013 el efecto se duplica, mientras que en PowerPoint 2007 solo se aplica la sombra externa.
{{% /alert %}}

### **Aplicar efectos de reflexión**

Una reflexión crea una copia espejo del texto. Ajuste su posición, escala, desenfoque y opacidad para controlar su apariencia.

Este ejemplo llama a [enableReflectionEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/effectformat/#enableReflectionEffect) e invierte la reflexión verticalmente con una escala de -100 %. Usa un radio de desenfoque de 0.5 puntos y una distancia de 4.72 puntos. La opacidad disminuye del 60 % al 0,9 % entre las posiciones 0 % y 60 % a lo largo de la reflexión:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

El texto resultante:

![El efecto de reflexión](reflection_effect.png)

### **Aplicar efectos de resplandor**

Un resplandor añade un contorno coloreado suave alrededor del texto. Ajuste su color, opacidad y radio para controlar el efecto.

Este ejemplo llama a [enableGlowEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/effectformat/#enableGlowEffect) y aplica un resplandor rojo con un 54 % de opacidad y un radio de 7 puntos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

El texto resultante:

![El efecto de resplandor](glow_effect.png)

### **Aplicar transformaciones WordArt**

Las transformaciones WordArt doblan, estiran o deforman un bloque de texto.

Establezca [setTransform](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTransform) a [ArchUpPour](https://reference.aspose.com/slides/es/python-java/aspose.slides/textshapetype/#ArchUpPour) para curvar todo el marco de texto hacia arriba:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

El texto resultante:

![La transformación WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java proporciona un conjunto de [tipos de transformación](https://reference.aspose.com/slides/es/python-java/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar efectos 3D a formas y texto**

Puede aplicar efectos 3D a una forma o a su texto. Los biseles, la extrusión, la iluminación y la configuración de la cámara controlan la apariencia resultante.

El ejemplo siguiente usa [ThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/) para añadir biseles circulares, extrusión naranja y un contorno rojo oscuro al rectángulo. Las dimensiones del bisel, la altura de la extrusión, el ancho y la profundidad del contorno se miden en puntos. Un material plástico, iluminación equilibrada girada 40 ° alrededor del eje Z y una cámara en perspectiva definen su aspecto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

La forma resultante:

![El efecto 3D de la forma](shape_3D_effect.png)

Este ejemplo aplica un formato 3D similar al texto mediante [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getThreeDFormat). Biseles más pequeños modelan los bordes de las letras, mientras que la extrusión y la iluminación dan profundidad al texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

El texto resultante:

![El efecto 3D del texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
La aplicación de efectos 3D al texto o a sus formas —y la interacción entre estos efectos— está regida por reglas específicas. Considere una escena que involucre tanto el texto como la forma que lo contiene. Un efecto 3D incluye la representación 3D del objeto y la escena en la que se sitúa.

- Si una escena está definida tanto para la forma como para el texto, la escena de la forma tiene prioridad y se ignora la escena del texto.
- Si la forma no tiene su propia escena pero sí una representación 3D, se usa la escena del texto.
- Si la forma no tiene ningún efecto 3D, se trata como plana y el efecto 3D se aplica solo al texto.

Estos comportamientos están relacionados con los métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getLightRig) y [ThreeDFormat.getCamera](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Para mantener el texto plano y legible mientras conserva el formato 3D de su forma, consulte [Keep Text Flat on a 3D Shape](/slides/es/python-java/3d-presentation/) para comparar ambas configuraciones y obtener un ejemplo completo en Python.

## **Preguntas frecuentes**

**¿Puedo usar los efectos WordArt con diferentes tipografías o scripts (p. ej., árabe, chino)?**

Sí, Aspose.Slides for Python via Java admite Unicode y funciona con todas las tipografías y scripts principales. Los efectos WordArt como sombra, relleno y contorno se pueden aplicar independientemente del idioma, aunque la disponibilidad de la tipografía y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos WordArt a los elementos del patrón de diapositivas?**

Sí, puede aplicar efectos WordArt a las formas de las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos WordArt afectan el tamaño del archivo de la presentación?**

Levemente. Los efectos WordArt como sombras, resplandores y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos WordArt sin guardar la presentación?**

Sí, puede renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage), o renderizar formas individuales mediante [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.