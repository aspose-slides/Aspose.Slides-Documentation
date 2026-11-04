---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از Python از طریق Java
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/python-java/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت درخشش
- افکت لبه‌های نرم
- فرمت افکت
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای Python از طریق Java تبدیل کنید — در عرض چند ثانیه اسلایدهای برجسته و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته شدن یک شکل استفاده شوند، با [پرکننده‌ها](/slides/fa/python-java/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، نوردهی شکل را پخش کنید و غیره.

![افکت شکل](shape-effect.png)

PowerPoint شش افکت را ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده است که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک preset، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Python via Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو کردن آن‌ها را مطابق با طرح ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی استفاده کنید تا یک کارت یا پنل در برابر پس‌زمینه اسلاید برجسته شود. سایه خارج از لبه‌های شکل گسترش می‌یابد و حس ارتفاع شکل نسبت به اسلاید را ایجاد می‌کند. رنگ، جهت، فاصله و شعاع محو کردن آن را مطابق با نورپردازی و سبک قالب خود تنظیم کنید.

این کد Python نشان می‌دهد چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر روی یک مستطیل اعمال کنید:

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

![افکت سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهر فرو رفته بدهید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که سایه داخلی داخل لبه‌های شکل را تاریک می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایه‌ای که توسط [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) برگردانده می‌شود را پیکربندی کنید. مقادیر بزرگتر شعاع محو، لبه‌های نرم‌تری تولید می‌کند.

این مثال Python یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه، فاصله آن ۷ پوینت و شعاع محو ۶ پوینت است:

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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides for Python via Java، می‌توانید بازتابی شبیه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با افزودن ظاهر صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده‌ای انجام می‌شود و امکان اعمال سریع بر روی عناصر متعدد برای طراحی یکنواخت را فراهم می‌کند.

این کد Python نشان می‌دهد چگونه [اثر بازتاب](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) را بر روی یک شکل اعمال کنید:

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

![افکت بازتاب](reflection_effect.png)

## **اعمال افکت درخشش**

برای اعمال افکت درخشش به یک شکل در Aspose.Slides for Python via Java، می‌توانید هاله‌ای نرم و روشن دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کمترین کد امکان‌پذیر است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Python نشان می‌دهد چگونه [اثر درخشش](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) را بر روی یک شکل اعمال کنید:

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

![افکت درخشش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for Python via Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ملایم‌تر و صیقلی‌تری می‌بخشد که برای طراحی‌هایی که به ظاهری ملایم و نرم نیاز دارند مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مطلوب را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد Python نشان می‌دهد چگونه [اثر لبه‌های نرم](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر روی یک شکل اعمال کنید:

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

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت محو شدن**

از محو شدن شکل برای نرم کردن پرکننده و خط مرزی شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر محو شدن قوی‌تری تولید می‌کند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) محدوده قابل مشاهده اثر را کنترل می‌کند. با `False`، محو شدن به حدود رنگ‌آمیخته اولیه، شامل خط مرزی، محدود می‌شود. با `True`، محو شدن می‌تواند از این حدود فراتر رود. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل در تمام موارد استفاده می‌کند. ردیف بالایی از `grow = False` استفاده می‌کند؛ ردیف پایین از `grow = True`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 پوینت، با رشد غیرفعال و فعال](shape_blur_comparison.png)

این مثال Python یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، محو 5 پوینتی اعمال می‌کند و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) آن را به 15 پوینت ارتقا می‌دهد. هر دو حالت محو شده را ذخیره می‌کند، سپس با فراخوانی [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) شکل را بدون محو ذخیره می‌کند.

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

محو شدن شکل هم پرکننده و هم خط مرزی را به‌صورت مشترک تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو شدن سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوی تصویر عمل می‌کنند؛ این مثال محو را مستقیم بر فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشش را بر روی یک شکل ترکیب کنید تا ظاهر دینامیک‌تری به دست آورید.

**کدام اشکال می‌توانم افکت‌ها را به آن‌ها اعمال کنم؟**

می‌توانید افکت‌ها را به انواع اشکال از جمله شکل‌های خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به شکل‌های گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.