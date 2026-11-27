---
title: Применение эффектов форм в презентациях с использованием Python через Java
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/python-java/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов форм, используя Aspose.Slides for Python via Java — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заполнения](/slides/ru/python-java/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создавать убедительные отражения на форме, распространять сияние формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые сочетания эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это сочетания двух и более эффектов, которые известны как удачные. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках хорошего сочетания.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via Java поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы карточка или панель выделялись на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот пример кода на Python показывает, как применить [эффект внешней тени](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

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

#### **Контролировать направление тени при вращении формы**

По умолчанию внешняя тень вращается вместе с формой. Чтобы формы с разными поворотами выглядели освещёнными из одного и того же направления, вызовите [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) с параметром `False` и используйте [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection), чтобы задать теням одинаковое направление.

В примере создаются две голубые стрелки с серыми тенями, смещёнными на 42 пункта вправо (0°). Затем слайд дублируется и обе стрелки вращаются на 90° по часовой стрелке.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

На втором слайде левая стрелка отбрасывает тень вниз, а правая стрелка по‑прежнему отбрасывает тень вправо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после вращения на 90°. Оба теневых эффекта начинаются справа. После вращения тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленный вид. Внешняя тень выходит за пределы формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние стороны её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Более большие значения радиуса размытия дают более мягкие края.

Этот пример кода на Python создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов формы.

### **Применить, изменить и удалить предустановленную тень**

Вызовите [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), затем используйте [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) для выбора [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Чтобы переключать стили, изменяйте предустановку у той же формы. Вызовите [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect), чтобы удалить тень, сохранив заливку и контур.

В примере прямоугольник клонируется на каждом этапе, чтобы можно было сравнить все четыре состояния рядом на одном слайде. Обе тени смещены на 10 пунктов. Направление 225° располагает первую тень выше и слева от прямоугольника. Направление 45° располагает вторую тень ниже и справа.

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

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![Тень сверху слева](preset_shadow_top_left.png) | ![Тень снизу справа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Python via Java, можно добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более изысканный и аккуратный вид. Его легко реализовать с помощью простого кода, обеспечивая быструю настройку на нескольких элементах для согласованного дизайна.

Этот пример кода на Python показывает, как применить [эффект отражения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) к форме:

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

Чтобы применить эффект свечения к форме в Aspose.Slides for Python via Java, можно добавить мягкое светящееся сияние вокруг формы, регулируя свойства, такие как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий внешний вид слайдов.

Этот пример кода на Python показывает, как применить [эффект свечения](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) к форме:

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

Чтобы применить эффект мягких краёв в Aspose.Slides for Python via Java, можно создать плавный размытый переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеален для дизайнов, требующих нежного, более мягкого внешнего вида. Вы можете легко настраивать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в презентации.

Этот пример кода на Python показывает, как применить [эффект мягких краёв](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

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

Используйте размытие формы, чтобы смягчить заливку и контур формы, при этом оставляя её редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не меняет внешний вид.

Параметр [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При `False` размытие ограничивается исходными нарисованными границами, включая контур. При `True` размытие может выходить за эти границы. Ни один из параметров не изменяет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы на протяжении всего примера. В верхней строке используется `grow = False`; в нижней — `grow = True`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, с отключённым и включённым ростом](shape_blur_comparison.png)

Этот пример кода на Python создаёт оранжевый прямоугольник с темно‑синим контуром, применяет размытие на 5 пунктов, а затем обновляет его до размытия на 15 пунктов, вызвав [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) ещё раз. Он сохраняет оба состояния размытия, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняет форму без размытия.

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

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краёв размывает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффектов формы без преобразования формы в изображение.

## **Вопросы и ответы**

**Можно ли применить несколько эффектов к одной форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Вы можете применять эффекты к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и другие.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.