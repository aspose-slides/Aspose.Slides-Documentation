---
title: Aplicar efectos de forma en presentaciones usando Python via Java
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/python-java/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de brillo
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para Python via Java—crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Mientras que los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/python-java/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el brillo de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o varios efectos a una forma.

Algunas combinaciones de efectos lucen mejor que otras. Por este motivo, PowerPoint proporciona opciones bajo **Preset**. Las opciones Preset son combinaciones de dos o más efectos que se sabe que quedan bien. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) que permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides for Python via Java admite sombras exteriores e interiores para las formas. Puedes personalizar su color, dirección, distancia y radio de difuminado para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra exterior**

Utiliza una sombra exterior para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de difuminado para que coincidan con la iluminación y el estilo de tu plantilla.

Este código Python muestra cómo aplicar el [efecto de sombra exterior](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rectángulo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interior**

Al reproducir el estilo visual de una plantilla, utiliza una sombra interior para dar a una tarjeta o panel una apariencia hundida. Una sombra exterior se extiende fuera de la forma y hace que parezca elevada, mientras que una sombra interior sombrea el interior de sus bordes.

Llama a [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), luego configura la sombra devuelta por [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Valores mayores del radio de difuminado producen bordes más suaves.

Este ejemplo Python crea una tarjeta azul claro con una sombra interior gris oscuro y la guarda como archivo PPTX. La dirección de la sombra es de 225 grados, su distancia es de 7 puntos y su radio de difuminado es de 6 puntos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Rectángulo azul claro con una sombra interior](inner_shadow_effect.png)

Para eliminar la sombra interior, llama a [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) en el formato de efectos de la forma.

### **Aplicar, cambiar y eliminar una sombra preset**

Llama a [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), luego usa [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) para seleccionar un [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Para cambiar de estilo, modifica el preset en la misma forma. Llama a [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) para eliminar la sombra manteniendo el relleno y el contorno.

El ejemplo clona el rectángulo en cada etapa para que puedas comparar los cuatro estados lado a lado en una sola diapositiva. Ambas sombras se desplazan 10 puntos. Una dirección de 225° coloca la primera sombra arriba y a la izquierda del rectángulo. Una dirección de 45° coloca la segunda debajo y a la derecha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Original | Primer preset | Segundo preset | Después de eliminar |
| :---: | :---: | :---: | :---: |
| ![Sin sombra](preset_shadow_original.png) | ![SombraDropSuperiorIzquierda](preset_shadow_top_left.png) | ![SombraDropInferiorDerecha](preset_shadow_bottom_right.png) | ![Sin sombra después de eliminar](preset_shadow_removed.png) |

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides for Python via Java, puedes añadir una reflexión tipo espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, lo que permite una aplicación rápida en varios elementos para un diseño coherente.

Este código Python muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de brillo**

Para aplicar un efecto de brillo a una forma en Aspose.Slides for Python via Java, puedes añadir una aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y aporta un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con código mínimo, mejorando el aspecto general de tus diapositivas.

Este código Python muestra cómo aplicar el [efecto de brillo](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efecto de brillo](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides for Python via Java, puedes crear una transición difusa y suave alrededor de los bordes de una forma. Este efecto aporta una apariencia más sutil y refinada, perfecta para diseños que requieren una estética delicada. Puedes ajustar fácilmente parámetros como el radio para lograr el efecto deseado en diversas formas de tu presentación.

Este código Python muestra cómo aplicar el [efecto de bordes suaves](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Utiliza el desenfoque de forma para suavizar el relleno y el contorno de una forma sin dejar de ser editable. Llama a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, siendo los valores mayores los que producen un desenfoque más fuerte. Un radio de cero deja el aspecto sin cambios.

La configuración [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) controla los límites visibles del efecto. Con `False`, el desenfoque se recorta a los límites pintados originales, incluidos el contorno. Con `True`, el desenfoque puede extenderse más allá de esos límites. Ninguna configuración altera la posición o dimensiones de la forma.

La comparación a continuación usa el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior usa `grow = False`; la fila inferior usa `grow = True`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo Python crea un rectángulo naranja con un contorno azul oscuro, le aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando nuevamente a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Guarda ambos estados desenfocados, luego llama a [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) y guarda la forma sin desenfoque.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El desenfoque de forma afecta conjuntamente al relleno y al contorno. Un efecto de bordes suaves desvanece los bordes de la forma, mientras que el desenfoque de sombra suaviza sólo la sombra. Los efectos de transformación de imagen operan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla en una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y brillo, en una única forma para crear una apariencia más dinámica.

**¿A qué tipos de forma puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.