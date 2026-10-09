---
title: Применение эффектов формы в презентациях с использованием Python через Java
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
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов формы, используя Aspose.Slides for Python via Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить объект, но они отличаются от [заливки](/slides/ru/python-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения объекта, распространять его сияние и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к объектам. Вы можете применить один или несколько эффектов к объекту.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые известны своим хорошим внешним видом. Таким образом, выбрав предустановку, вам не придется тратить время на тестирование или сочетание разных эффектов, чтобы найти удачную комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), позволяющие применять те же эффекты к объектам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via Java поддерживает внешние и внутренние тени для объектов. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы границ объекта, создавая впечатление, что объект поднят над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии с освещением и стилем вашего шаблона.

Этот код на Python демонстрирует, как применить [эффект внешней тени](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное изображение. Внешняя тень выходит за пределы объекта и делает его выглядящим приподнятым, а внутренняя тень затемняет внутренние стороны его границ.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Большие значения радиуса размытия создают более мягкие края.

Этот пример на Python создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, её расстояние — 7 пунктов, а радиус размытия — 6 пунктов:

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

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов объекта.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Python via Java, вы можете добавить зеркальное отражение к объектам, регулируя параметры такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая объектам более изысканный и отполированный вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для единообразного дизайна.

Этот код на Python демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) к объекту:

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

Чтобы применить эффект свечения к объекту в Aspose.Slides for Python via Java, вы можете добавить мягкое светящееся сияние вокруг объектов, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить объекты и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот код на Python демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) к объекту:

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

## **Применить эффект мягких краев**

Чтобы применить эффект мягких краев в Aspose.Slides for Python via Java, вы можете создать плавный, размытый переход по краям объекта. Этот эффект придаёт более утончённый и изящный вид, идеален для дизайнов, требующих нежного, более мягкого внешнего вида. Вы можете легко настраивать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных объектов в вашей презентации.

Этот код на Python демонстрирует, как применить [эффект мягких краев](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) к объекту:

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

![Эффект мягких краев](soft_edges_effect.png)

## **Часто задаваемые вопросы**

**Можно ли применить несколько эффектов к одному объекту?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одном объекте, чтобы создать более динамичное изображение.

**К каким объектам можно применять эффекты?**

Эффекты можно применять к различным объектам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, объекты OLE и другие.

**Можно ли применять эффекты к сгруппированным объектам?**

Да, вы можете применять эффекты к сгруппированным объектам. Эффект будет применён ко всей группе.