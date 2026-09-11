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
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов форм, используя Aspose.Slides для Python через Java — создавайте яркие, профессиональные слайды за считанные секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заливок](/slides/ru/python-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создать убедительные отражения на форме, распространить свечение формы и т. д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме. 

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset представляют собой комбинации двух и более эффектов, которые, как известно, хорошо сочетаются. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование различных эффектов, чтобы найти хорошее сочетание.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот код на Python показывает, как применить внешний эффект тени ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) к прямоугольнику:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Применить эффект отражения**

Этот код на Python показывает, как применить эффект отражения к форме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Применить эффект свечения**

Этот код на Python показывает, как применить эффект свечения к форме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Применить эффект мягких краёв**

Этот код на Python показывает, как применить эффект мягких краёв к форме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.