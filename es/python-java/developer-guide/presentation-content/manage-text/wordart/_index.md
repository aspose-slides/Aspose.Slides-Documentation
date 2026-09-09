---
title: Crear y aplicar efectos WordArt en Python mediante Java
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
description: "Crear y personalizar efectos WordArt en Aspose.Slides para Python mediante Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Python mediante Java."
---
## **Visión general**

Los efectos WordArt le permiten añadir texto visualmente atractivo y estilizado a sus presentaciones de PowerPoint. Con Aspose.Slides, los desarrolladores pueden crear, personalizar y gestionar WordArt de forma programática al igual que en Microsoft PowerPoint, sin necesidad de que Office esté instalado. Este artículo ofrece una visión general del trabajo con WordArt, incluyendo cómo aplicar transformaciones de texto, estilos de relleno, contornos, sombras y otras opciones de formato para que el contenido de su presentación sea más expresivo y atractivo. WordArt le permite tratar el texto como un objeto gráfico. Consiste en efectos o modificaciones especiales aplicadas al texto para hacerlo más atractivo o visible.

## **Crear una plantilla WordArt sencilla y aplicarla al texto**

**Usando Aspose.Slides**

Primero, creamos texto sencillo usando este código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
A continuación, aumentamos el tamaño de la fuente para que el efecto sea más perceptible:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Usando Microsoft PowerPoint**

Vaya al menú de efectos WordArt en Microsoft PowerPoint:

![Menú de efectos WordArt en PowerPoint](image-20200930113926-1.png)

En el menú de la derecha, puede elegir un efecto WordArt predefinido. En el menú de la izquierda, puede especificar la configuración para un WordArt nuevo.

Estos son algunos de los parámetros u opciones disponibles:

![Opciones de formato WordArt](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el relleno de patrón [PatternStyle.SmallGrid](https://reference.aspose.com/slides/es/python-java/aspose.slides/patternstyle/#SmallGrid) al texto y añadimos un contorno negro al texto usando este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

El texto resultante:

![Texto con relleno de patrón y contorno negro](image-20200930114108-4.png)

## **Aplicar otros efectos WordArt**

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puede aplicar estos efectos al texto, a un bloque de texto, a una forma o a un elemento similar:

![Efectos de texto y forma en PowerPoint](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse al texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; el efecto Borde suave puede aplicarse a una forma (aún tiene efecto cuando no se establece ningún efecto Formato 3D).

### **Aplicar efectos de sombra**

El siguiente código Python aplica un efecto de sombra solo al texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

La API de Aspose.Slides admite tres tipos de sombras: [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/innershadow/) y [PresetShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/presetshadow/).

Con [PresetShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/presetshadow/) puede aplicar una sombra al texto usando valores predefinidos.

**Usando Microsoft PowerPoint**

En PowerPoint, puede usar un tipo de sombra. He aquí un ejemplo:

![Ajustes de sombra en PowerPoint](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides permite aplicar dos tipos de sombras a la vez: [InnerShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/innershadow/) y [PresetShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/presetshadow/).

**Notas:**

- Cuando se usan conjuntamente [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/) y [PresetShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/presetshadow/), solo se aplica el efecto [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/).
- Si se utilizan simultáneamente [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/) y [InnerShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/innershadow/), el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013 el efecto se duplica. Pero en PowerPoint 2007 se aplica el efecto [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/).

### **Aplicar reflexión al texto**

Añadimos una reflexión al texto mediante este fragmento de código en Python a través de Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Aplicar un efecto de resplandor al texto**

Aplicamos el efecto de resplandor al texto para que brille o destaque usando este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

El resultado de la operación:

![Texto con efecto de resplandor](image-20200930114621-7.png)

{{% alert color="info" title="Nota" %}}
Puede cambiar los parámetros de sombra, reflexión y resplandor. Las propiedades de los efectos se establecen en cada parte del texto por separado.
{{% /alert %}}

### **Usar transformaciones en WordArt**

Utilice [TextFrameFormat.setTransform](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTransform) para transformar todo el bloque de texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

El resultado:

![Texto con transformación de arco](image-20200930114712-8.png)

{{% alert color="info" title="Nota" %}}
Tanto Microsoft PowerPoint como Aspose.Slides para Python a través de Java proporcionan un número determinado de tipos de transformación predefinidos.
{{% /alert %}}

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, vaya a: **Formato** -> **Efecto de texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utilice la enumeración [TextShapeType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textshapetype/).

### **Aplicar efectos 3D a texto y formas**

Aplicamos un efecto 3D a una forma de texto con este fragmento de código de ejemplo:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

El texto y su forma resultantes:

![Forma de texto con efectos 3D](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código Python:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

El resultado de la operación:

![Texto con efectos 3D](image-20200930114905-10.png)

{{% alert color="info" title="Nota" %}}
La aplicación de efectos 3D al texto o a sus formas y la interacción entre efectos se basa en ciertas reglas.

Considere una escena para el texto y la forma que contiene ese texto. El efecto 3D contiene una representación de objeto 3D y la escena en la que se coloca el objeto.

- Cuando la escena se define tanto para la forma como para el texto, la escena de la forma tiene prioridad; la escena del texto se ignora.
- Cuando la forma no tiene su propia escena pero sí una representación 3D, se utiliza la escena del texto.
- En caso contrario—cuando la forma originalmente no tiene efecto 3D—la forma permanece plana y el efecto 3D se aplica solo al texto.

Estas reglas se relacionan con los métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getLightRig) y [ThreeDFormat.getCamera](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Aplicar efectos de sombra externa al texto**

Aspose.Slides para Python a través de Java proporciona las clases [OuterShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/outershadow/) y [InnerShadow](https://reference.aspose.com/slides/es/python-java/aspose.slides/innershadow/) que permiten aplicar efectos de sombra al texto en un [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/). Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga la referencia a una diapositiva mediante su índice.
3. Añada una forma rectangular a la diapositiva.
4. Acceda al marco de texto asociado a la forma.
5. Desactive el relleno de la forma.
6. Active el efecto de sombra externa.
7. Establezca el radio de difuminado de la sombra.
8. Defina la dirección de la sombra.
9. Establezca la distancia de la sombra.
10. Alinee la sombra a la esquina superior izquierda.
11. Defina el color de la sombra como negro.
12. Grabe la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de muestra en Python a través de Java—una implementación de los pasos anteriores—le muestra cómo aplicar el efecto de sombra externa al texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Obtener referencia de la diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Añadir una AutoShape del tipo Rectángulo
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Añadir TextFrame al rectángulo
    auto_shape.addTextFrame("Aspose TextBox")

    # Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Añadir sombra externa y establecer todos los parámetros necesarios
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Guardar la presentación en disco
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aplicar efecto de sombra interna a formas**

Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga la referencia de la diapositiva.
3. Añada una forma rectangular.
4. Active el efecto de sombra interna.
5. Defina todos los parámetros necesarios.
6. Establezca el tipo de color de la sombra para usar un color temático.
7. Defina el color temático.
8. Grabe la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de muestra (basado en los pasos anteriores) le muestra cómo aplicar el efecto de sombra interna al texto dentro de una forma en Python a través de Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Obtener referencia de la diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Añadir una AutoShape del tipo Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Añadir TextFrame al Rectangle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Activar InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Establecer todos los parámetros necesarios
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Establecer ColorType como Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Establecer Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Guardar la presentación
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo usar los efectos WordArt con fuentes o escrituras diferentes (por ejemplo, árabe, chino)?**

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de la fuente y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos WordArt a elementos del patrón de diapositivas?**

Sí, puede aplicar efectos WordArt a formas en diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos WordArt afectan al tamaño del archivo de la presentación?**

Un poco. Los efectos WordArt como sombras, resplandores y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos WordArt sin guardar la presentación?**

Sí, puede renderizar diapositivas que contengan WordArt a imágenes (por ejemplo, PNG, JPEG) mediante [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) o [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.