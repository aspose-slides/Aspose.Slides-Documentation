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
- "افکت تابناکی"
- "افکت لبه نرم"
- "قالب افکت"
- "PowerPoint"
- "ارائه"
- "پایتون"
- "جاوا"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفتهٔ شکل با استفاده از Aspose.Slides برای Python از طریق Java تبدیل کنید—در چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکردن‌ها](/slides/fa/python-java/shape-formatting/#gradient-fill) یا خط‌چین‌ها تفاوت دارند. با استفاده از افکت‌های PowerPoint، می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش یک شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت نسبت به دیگران بهتر به نظر می‌آیند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** ارائه می‌دهد. گزینه‌های Preset ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف وقت برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Python از طریق Java از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو آن‌ها را متناسب با طراحی ارائه خود تنظیم کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی استفاده کنید تا یک کارت یا پنل در مقابل پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این تصور را می‌دهد که شکل بالای اسلاید قرار گرفته است. رنگ، جهت، فاصله و شعاع محو آن را متناسب با نوردهی و استایل قالب خود تنظیم کنید.

این کد Python نشان می‌دهد چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) را بر یک مستطیل اعمال کنیم:

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

#### **کنترل جهت سایه هنگام چرخش یک شکل**

به‌طور پیش‌فرض، سایه بیرونی همراه با شکل می‌چرخد. برای این‌که اشکالی با چرخش‌های مختلف به‌نظر برسند که از همان جهت نوردهی شده‌اند، با مقدار `False` به متد [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) فراخوانی کنید و از متد [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) برای دادن همان جهت به سایه‌ها استفاده کنید.

مثال دو پیکان آبی با سایه‌های خاکستری که ۴۲ نقطه به سمت راست (0°) جابجا شده‌اند ایجاد می‌کند. سپس اسلاید را تکثیر می‌کند و هر دو پیکان را ۹۰° ساعتگرد می‌چرخاند.

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

در اسلاید دوم، پیکان چپ سایه‌اش را به سمت پایین می‌اندازد، در حالی که پیکان راست همچنان سایه‌اش را به سمت راست می‌اندازد. جهت تنظیم‌شده برای هر دو سایه 0° باقی می‌ماند.

![رندر PowerPoint قبل و بعد از یک چرخش 90°. هر دو سایه از سمت راست شروع می‌شوند. پس از چرخش، سایه زیر پیکان چپ حرکت می‌کند و در سمت راست پیکان راست می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی استایل بصری یک قالب، از سایه داخلی استفاده کنید تا یک کارت یا پنل ظاهر فرو رفته بگیرد. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که سایه داخلی لبه‌های داخلی را سایه‌دار می‌کند.

متد [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) را فراخوانی کنید، سپس سایهٔ بازگردانده‌شده توسط [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) را تنظیم کنید. مقادیر بزرگتر شعاع محو لبه‌های نرم‌تری تولید می‌کند.

این مثال Python یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به‌عنوان فایل PPTX ذخیره می‌شود. جهت سایه ۲۲۵ درجه است، فاصلهٔ آن ۷ نقطه و شعاع محو ۶ نقطه است:

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

برای حذف سایهٔ داخلی، متد [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) را بر فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم شده**

متد [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) را فراخوانی کنید، سپس از [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک، پیش‌تنظیم را بر همان شکل تغییر دهید. برای حذف سایه در حالی که پرکردن و خط‌چین حفظ می‌شوند، متد [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) را فراخوانی کنید.

مثال مستطیل را در هر مرحله تکثیر می‌کند تا بتوانید چهار حالت را به‌صورت کنار هم در یک اسلاید مقایسه کنید. هر دو سایه ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° اولین سایه را بالای مستطیل و سمت چپ آن قرار می‌دهد. جهت ۴۵° دومین سایه را زیر و سمت راست مستطیل می‌گذارد.

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

| **اصلی** | **پیش‌تنظیم اول** | **پیش‌تنظیم دوم** | **پس از حذف** |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایه بالاچپ](preset_shadow_top_left.png) | ![سایه پایینراست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Python از طریق Java، می‌توانید انعکاس شبیه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم نمایید. این افکت ظاهر ارائه‌های شما را با دادن ظاهری صیقلی و شیک به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده است و امکان اعمال سریع بر عناصر متعدد برای داشتن طراحی یکدست را فراهم می‌کند.

این کد Python نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) را بر یک شکل اعمال کنیم:

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

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت تابناکی**

برای اعمال افکت تابناکی بر یک شکل در Aspose.Slides برای Python از طریق Java، می‌توانید هاله‌ای نرم و روشن به اطراف شکل اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه امکان‌پذیر است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Python نشان می‌دهد چگونه [افکت تابناکی](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) را بر یک شکل اعمال کنیم:

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

![افکت تابناکی](glow_effect.png)

## **اعمال افکت لبه نرم**

برای اعمال افکت لبه نرم در Aspose.Slides برای Python از طریق Java، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر زیرکانه‌تر و تصفیه‌شده‌ای می‌آورد که برای طرح‌های نیازمند ظاهر ملایم و نرم مناسب است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر اشکال مختلف در ارائه خود به‌دست آورید.

این کد Python نشان می‌دهد چگونه [افکت لبه نرم](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) را بر یک شکل اعمال کنیم:

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

![افکت لبه نرم](soft_edges_effect.png)

## **اعمال افکت محو**

از محو کردن شکل برای نرم کردن پرکردن و خط‌چین شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) را بر فرمت افکت شکل فراخوانی کنید. شعاع بر حسب نقاط (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر محو قوی‌تری تولید می‌کنند. شعاع صفر ظاهر شکل را تغییر نمی‌دهد.

تنظیم [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) مرزهای قابل مشاهدهٔ افکت را کنترل می‌کند. با `False`، محو به مرزهای رنگ‌شدهٔ اصلی محدود می‌شود، از جمله خط‌چین. با `True`، محو می‌تواند از این مرزها فراتر رود. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسهٔ زیر از همان پرکردن، خط‌چین و ابعاد شکل برای تمام نمونه‌ها استفاده می‌کند. ردیف بالا `grow = False` را به‌کار می‌برد؛ ردیف پایین `grow = True`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال Python یک مستطیل نارنجی با خط‌چین آبی تیره ایجاد می‌کند، محو ۵ نقطه‌ای اعمال می‌کند و سپس با فراخوانی دوباره [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) به محو ۱۵ نقطه می‌رسد. هر دو حالت محو را ذخیره می‌کند، سپس متد [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) را فراخوانی می‌کند و شکل بدون محو را ذخیره می‌نماید.

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

محو شکل هم‌زمان پرکردن و خط‌چین را تحت تاثیر قرار می‌دهد. افکت لبه نرم لبه‌های شکل را محو می‌کند، در حالی که محو سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال محو را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون اینکه شکل را به تصویر تبدیل کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابناکی را بر یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد کنید.

**به کدام اشکال می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر انواع شکل‌ها از جمله شکل‌های خودکار، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر اشکال گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر اشکال گروه‌بندی‌شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.