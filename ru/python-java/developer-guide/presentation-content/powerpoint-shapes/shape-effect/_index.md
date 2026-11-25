---
title: Применение эффектов фигур в презентациях с помощью Python через Java
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/python-java/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides for Python via Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить форму, но они отличаются от [заливки](/slides/ru/python-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать реалистичные отражения формы, распространять её сияние и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбрав предустановку, вам не придется тратить время на тестирование или комбинацию различных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) , которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via Java поддерживает внешние и внутренние тени для фигур. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы границ формы, создавая ощущение, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии с освещением и стилем вашего шаблона.

This Python code shows how to apply the [внешний эффект тени](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) to a rectangle:

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

![Эффект тени](shadow_effect.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное изображение. Внешняя тень выходит за пределы формы и делает её выглядящей поднятой, тогда как внутренняя тень затемняет внутренние стороны её краёв.

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Larger blur radius values produce softer edges.

This Python example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file. The shadow direction is 225 degrees, its distance is 7 points, and its blur radius is 6 points:

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

![Светло-голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

To remove the inner shadow, call [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) on the shape's effect format.

### **Применить, изменить и удалить предустановленную тень**

Call [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), then use [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) to select a [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). To switch styles, change the preset on the same shape. Call [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) to remove the shadow while preserving the fill and outline.

The example clones the rectangle at each stage so you can compare all four states side by side on one slide. Both shadows are offset by 10 points. A direction of 225° places the first shadow above and to the left of the rectangle. A direction of 45° places the second below and to the right.

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

| Исходный | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![Тень сверху слева](preset_shadow_top_left.png) | ![Тень снизу справа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Python via Java, вы можете добавить зеркальное отражение к формам, настраивая такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая формам более отполированный и изысканный вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять его к нескольким элементам для согласованного дизайна.

This Python code shows how to apply the [эффект отражения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) to a shape:

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

![Эффект отражения](reflection_effect.png)

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for Python via Java, вы можете добавить мягкое светящееся сияние вокруг форм, настраивая такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий вид ваших слайдов.

This Python code shows how to apply the [эффект свечения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) to a shape:

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

![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Python via Java, вы можете создать плавный размытый переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеальный для дизайна, требующего нежного, более мягкого отображения. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

This Python code shows how to apply the [эффект мягких краёв](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) to a shape:

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

![Эффект мягких краёв](soft_edges_effect.png)

## **Применить эффект размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, сохраняя её редактируемой. Call [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) on the shape's effect format. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не изменяет внешний вид.

The [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) setting controls the visible bounds of the effect. With `False`, the blur is clipped to the original painted bounds, including the outline. With `True`, the blur can extend beyond those bounds. Neither setting changes the shape's position or dimensions.

The comparison below uses the same fill, outline, and shape dimensions throughout. The top row uses `grow = False`; the bottom row uses `grow = True`.

![Исходный прямоугольник с различными радиусами размытия 5 и 15 пунктов, с отключённым и включённым ростом](shape_blur_comparison.png)

This Python example creates an orange rectangle with a dark blue outline, applies a 5-point blur, and then updates it to a 15-point blur by calling [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) again. It saves both blurred states, then calls [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) and saves the shape without blur.

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

Shape blur affects the fill and outline together. A soft edges effect fades the shape's edges, while shadow blur softens only the shadow. Image transformation effects operate on image content; this example applies blur directly to the shape's effect format without converting the shape to an image.

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, для одной формы, чтобы создать более динамичный внешний вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.