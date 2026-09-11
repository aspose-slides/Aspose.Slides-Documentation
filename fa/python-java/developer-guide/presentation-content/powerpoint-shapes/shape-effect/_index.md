---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از Python از طریق Java
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/python-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفتهٔ شکل با Aspose.Slides برای Python از طریق Java تغییر دهید—در عرض چند ثانیه اسلایدهای جذاب و حرفه‌ای ایجاد کنید."
---
## **Introduction**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، متفاوت از [fills](/slides/fa/python-java/shape-formatting/#gradient-fill) یا خطوط حاشیه هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های واقعی بر روی یک شکل ایجاد کنید، درخشندگی شکل را پخش کنید و غیره.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.  
* ترکیب‌های مختلفی از افکت‌ها وجود دارد که برخی بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** فراهم می‌کند. گزینه‌های Preset در واقع ترکیبی از دو یا چند افکت هستند که شناخته‌شده‌اند که نتایج خوبی می‌دهند. به این ترتیب، با انتخاب یک preset نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **Apply a Shadow Effect**

این کد Python نشان می‌دهد چگونه افکت سایه خارجی ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) را به یک مستطیل اعمال کنید:

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

## **Apply a Reflection Effect**

این کد Python نشان می‌دهد چگونه افکت انعکاس را به یک شکل اعمال کنید:

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

## **Apply a Glow Effect**

این کد Python نشان می‌دهد چگونه افکت درخشندگی را به یک شکل اعمال کنید:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

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

## **Apply a Soft Edges Effect**

این کد Python نشان می‌دهد چگونه افکت لبه‌های نرم را به یک شکل اعمال کنید:

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

**Can I apply multiple effects to the same shape?**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری به دست آورید.

**What shapes can I apply effects to?**

می‌توانید افکت‌ها را بر روی انواع مختلفی از اشکال اعمال کنید، از جمله autoshapes، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و غیره.

**Can I apply effects to grouped shapes?**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. افکت بر روی کل گروه اعمال می‌شود.