---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از پایتون از طریق جاوا"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/python-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت نوردهی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای پایتون از طریق جاوا تبدیل کنید—در عرض ثانیه‌ها اسلایدهای چشم‌نوازی و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/python-java/shape-formatting/#gradient-fill) یا خطوط حاشیه متفاوت هستند. با استفاده از افکت‌های پاورپوینت می‌توانید بازتاب‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، نوردهی شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

پاورپوینت شش افکت را فراهم می‌کند که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که خوب به نظر می‌آیند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمون یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Python via Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تار شدن آنها را برای مطابقت با طراحی ارائه‌تان سفارشی کنید.

### **اعمال سایه بیرونی**

از یک سایه بیرونی استفاده کنید تا یک کارت یا پنل در برابر پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این حس را ایجاد می‌کند که شکل از اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع تار شدن آن را برای هماهنگی با نورپردازی و سبک قالب‌تان تنظیم کنید.

این کد پایتون نشان می‌دهد چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) را به یک مستطیل اعمال کنید:

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

![اثر سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از یک سایه داخلی استفاده کنید تا به کارت یا پنل ظاهری درونی بدهید. یک سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که یک سایه داخلی لبه‌های داخلی آن را سایه‌دار می‌کند.

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه بازگردانده‌شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تار شدن، لبه‌های نرم‌تری تولید می‌کند.

این مثال پایتون یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه است، فاصله‌اش ۷ پوینت و شعاع تار شدنش ۶ پوینت می‌باشد:

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

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر قالب افکت شکل فراخوانی کنید.

## **اعمال افکت بازتاب**

برای اعمال یک افکت بازتاب در Aspose.Slides for Python via Java، می‌توانید بازتابی شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهر براق و پیشرفته به اشکال ارتقاء می‌دهد. پیاده‌سازی آن ساده است و با کد کوتاهی می‌توانید به‌سرعت این افکت را روی چندین عنصر برای طراحی یکدست اعمال کنید.

این کد پایتون نشان می‌دهد چگونه [اثر بازتاب](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) را به یک شکل اعمال کنید:

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

![اثر بازتاب](reflection_effect.png)

## **اعمال افکت نوردهی**

برای اعمال یک افکت نوردهی به یک شکل در Aspose.Slides for Python via Java، می‌توانید هالی نرم و روشن در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن اشکال کمک کرده و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن آسان است و با کد کم می‌توانید ظاهر کلی اسلایدهای خود را بهبود بخشید.

این کد پایتون نشان می‌دهد چگونه [اثر نوردهی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) را به یک شکل اعمال کنید:

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

![اثر نوردهی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال یک افکت لبه‌های نرم در Aspose.Slides for Python via Java، می‌توانید انتقال صاف و تاری به اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف‌تر و پالایش‌شده اضافه می‌کند که برای طراحی‌هایی که نیاز به ظاهر ملایم‌تر دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مطلوب را بر روی اشکال مختلف در ارائه خود اعمال کنید.

این کد پایتون نشان می‌دهد چگونه [اثر لبه‌های نرم](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) را به یک شکل اعمال کنید:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **سؤالات متداول**

**آیا می‌توانم چندین افکت را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و نوردهی را بر روی یک شکل ترکیب کنید تا ظاهر دینامیک‌تری به وجود آید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را به اشکال مختلفی از جملهٔ اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به اشکال گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را به اشکال گروه‌بندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.