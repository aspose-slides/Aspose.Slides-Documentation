---
title: Применить эффекты форм в презентациях с использованием Python через Java
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
description: "Трансформируйте свои файлы PPT и PPTX с помощью продвинутых эффектов форм, используя Aspose.Slides for Python via Java — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить форму, но они отличаются от [заполнений](/slides/ru/python-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, растягивать свечение формы и т.д.

![Shape effect](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, известные хорошим внешним видом. Таким образом, выбирая предустановку, вам не придется тратить время на тестирование или комбинирование различных эффектов в поисках подходящей комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via Java поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краев формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код на Python демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

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

![Shadow effect](shadow_effect.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленную форму. Внешняя тень выступает за пределы формы и создаёт эффект подъёма, в то время как внутренняя тень затемняет внутренние границы.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Более большие значения радиуса размытия дают более мягкие края.

Этот пример на Python создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов формы.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Python via Java, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, делая формы более отполированными и изысканными. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для единообразного дизайна.

Этот код на Python демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) к форме:

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

![Reflection effect](reflection_effect.png)

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for Python via Java, вы можете добавить мягкое светящееся сияние вокруг форм, настраивая такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашей презентации. Его легко реализовать с минимальным количеством кода, улучшая общий вид ваших слайдов.

Этот код на Python демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) к форме:

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

![Glow effect](glow_effect.png)

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Python via Java, вы можете создать плавный размытый переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого появления. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

Этот код на Python демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

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

![Soft edges effect](soft_edges_effect.png)

## **Применить эффект размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, сохраняя её редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не изменяет внешний вид.

Параметр [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При `False` размытие ограничивается исходными нарисованными границами, включая контур. При `True` размытие может выходить за эти границы. Ни один из параметров не изменяет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы. В верхнем ряду `grow = False`; в нижнем ряду `grow = True`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Этот пример на Python создаёт оранжевый прямоугольник с тёмно‑синей окантовкой, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия радиусом 15 пунктов, снова вызывая [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Он сохраняет оба состояния размытия, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняет форму без размытия.

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

Размытие формы влияет одновременно на заливку и контур. Эффект мягких краёв смягчает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображений работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Могу ли я применить несколько эффектов к одной и той же форме?**  
Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный внешний вид.

**К каким формам я могу применять эффекты?**  
Вы можете применять эффекты к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Могу ли я применять эффекты к сгруппированным формам?**  
Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.