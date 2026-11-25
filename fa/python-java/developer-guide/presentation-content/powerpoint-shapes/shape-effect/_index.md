---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از Python از طریق Java"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/python-java/shape-effect/
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت انعکاس"
- "افکت تابش"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "ارائه"
- "Python"
- "Java"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای Python از طریق Java تبدیل کنید—در چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکننده‌ها](/slides/fa/python-java/shape-formatting/#gradient-fill) یا خطوط دور متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید و غیره.

![Shape effect](shape-effect.png)

PowerPoint شش افکت را فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که معلوم است زیبا به نظر می‌رسند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به از دست دادن زمان در آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و روش‌هایی را تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Python از طریق Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته‌کردن یک کارت یا پنل نسبت به پس‌زمینهٔ اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و احساسی می‌دهد که شکل بالای اسلاید بلند شده است. رنگ، جهت، فاصله و شعاع تاری آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد Python نشان می‌دهد چگونه افکت [افکت سایه بیرونی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) را روی یک مستطیل اعمال کنید:
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

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفته یک کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بلند نشان می‌دهد، در حالی که سایه داخلی داخل لبه‌های آن را سایه‌دار می‌کند.

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Larger blur radius values produce softer edges.

این مثال Python یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به عنوان فایل PPTX ذخیره می‌نماید. جهت سایه ۲۲۵ درجه است، فاصله آن ۷ پوینت و شعاع تاری ۶ پوینت می‌باشد:
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

برای حذف سایه داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر روی قالب افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف یک سایه پیش‌تنظیم**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) را فراخوانی کنید، سپس از [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک‌ها، پیش‌تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط دور حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) را فراخوانی کنید.

این مثال مستطیل را در هر مرحله کلون می‌کند تا بتوانید چهار وضعیت را به‌ طور کنار هم در یک اسلاید مقایسه کنید. هر دو سایه ۱۰ پوینت جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای مستطیل و به سمت چپ قرار می‌دهد. جهت ۴۵° سایه دوم را زیر مستطیل و به سمت راست قرار می‌دهد.
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

| اصل | پیش‌تنظیم اول | پیش‌تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Python از طریق Java، می‌توانید انعکاسی شبیه آیینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیچیده به اشکال ارتقاء می‌دهد. با کد ساده قابل پیاده‌سازی است و امکان اعمال سریع در چندین عنصر برای یک طراحی یکنواخت را فراهم می‌کند.

این کد Python نشان می‌دهد چگونه افکت [افکت انعکاس](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) را بر یک شکل اعمال کنید:
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

## **اعمال افکت تابش**

برای اعمال افکت تابش بر یک شکل در Aspose.Slides برای Python از طریق Java، می‌توانید هاله‌ای نرم و درخشانی در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن اشکال کمک می‌کند و یک عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. با کمترین کد قابل پیاده‌سازی است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Python نشان می‌دهد چگونه افکت [افکت تابش](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) را بر یک شکل اعمال کنید:
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

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Python از طریق Java، می‌توانید انتقالی صاف و تاریک در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تری می‌دهد که برای طرح‌هایی که نیاز به ظاهر ملایم و نرم دارند، مناسب است. می‌توانید به‌ راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد Python نشان می‌دهد چگونه افکت [افکت لبه‌های نرم](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر یک شکل اعمال کنید:
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

## **اعمال افکت تاری**

از تاری شکل برای نرم‌کردن پرکننده و خط دور یک شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) را بر روی قالب افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید، مقادیر بزرگ‌تر تاری قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) مرزهای قابل‌مشاهدهٔ افکت را کنترل می‌کند. با `False`، تار به مرزهای اولیهٔ نقاشی شده، از جمله خط دور، محدود می‌شود. با `True`، تار می‌تواند فراتر از آن مرزها گسترش یابد. هیچ کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسهٔ زیر در تمام طول از همان پرکننده، خط دور و ابعاد شکل استفاده می‌کند. ردیف بالایی از `grow = False` استفاده می‌کند؛ ردیف پایین از `grow = True`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

این مثال Python یک مستطیل نارنجی با خط دور آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌نماید و سپس با فراخوانی مجدد [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) به تاری ۱۵ پوینتی به‌روزرسانی می‌گردد. هر دو حالت تاری را ذخیره می‌کند، سپس [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) را فراخوانی کرده و شکل بدون تاری را ذخیره می‌کند.
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

تاری شکل همزمان بر پرکننده و خط دور اثر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر کار می‌کنند؛ این مثال تاری را مستقیماً بر قالب افکت شکل اعمال می‌کند بدون اینکه شکل به تصویر تبدیل شود.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلف مانند سایه، انعکاس و تابش را بر یک شکل ترکیب کنید تا ظاهر پویاتری به دست آورید.

**به چه اشکالی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی اشکال مختلفی اعمال کنید، از جمله اشکال اتوماتیک، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.