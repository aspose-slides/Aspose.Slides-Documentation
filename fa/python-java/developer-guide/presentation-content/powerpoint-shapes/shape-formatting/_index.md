---
title: قالب‌بندی اشکال پاورپوینت در پایتون از طریق جاوا
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌کشی
- خط طرح‌کشی شکل
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‌سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برجسته‌سازی ۳‌بعدی
- افکت چرخش ۳‌بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال پاورپوینت را در پایتون از طریق جاوا با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT, PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها بر روی خطوط مرزی‌شان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پر کردن داخلی آنها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای پایتون از طریق جاوا کلاس‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهند اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides، می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر این روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [خط](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب [خط‌چین](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک مستطیل [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) را قالب‌بندی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # تنظیم رنگ پر کردن برای شکل مستطیل.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # اعمال قالب‌بندی به خطوط مستطیل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # تنظیم رنگ خط مستطیل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های طرح‌کشی به خطوط شکل**

یک افکت طرح‌کشی باعث می‌شود خط یک شکل شبیه به دستی رسم شده به نظر برسد. برای دسترسی به تنظیمات خط از [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) استفاده کنید، برای دسترسی به تنظیمات طرح‌کشی از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) استفاده کنید، و برای انتخاب مقدار از شمارش [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) از [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه افکت [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) را اعمال کنید، مقدار اختصاص داده‌شده به‌صورت صریح را بخوانید، و افکت را با [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # دسترسی به قالب خط شکل و قالب طرح‌کشی آن.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # اعمال یک افکت طرح‌کشی.
    sketch_format.setSketchType(LineSketchType.Curved)

    # خواندن افکت طرح‌کشی اختصاص داده شده مستقیم به شکل.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # حذف افکت طرح‌کشی.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

مقدار بازگردانده شده توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) نمایانگر تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید مستر یا اسلاید چیدمان به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) استفاده کنید، به `LineFormatEffectiveData.getSketchFormat` دسترسی پیدا کنید و `SketchFormatEffectiveData.getSketchType` را بخوانید. مقدار مؤثر قالب‌بندی را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه نوع اتصال آورده شده است:

* گرد
* میتر
* شیاردار

به‌طور پیش‌فرض، وقتی پاورپوینت دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) به هم متصل می‌کند، از تنظیم **گرد** استفاده می‌کند. اما اگر شکل را با زوایای تیز می‌کشید، ممکن است گزینه **میتر** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد پایتون زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال میتر، شیاردار و گرد ایجاد شدند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن سه auto shape از نوع Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # تنظیم رنگ پر کردن برای هر شکل مستطیل.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # تنظیم عرض خط.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # تنظیم رنگ برای خط هر مستطیل.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # تنظیم سبک اتصال.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # افزودن متن به هر مستطیل.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پر کردن گرادیان**

در پاورپوینت، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به عنوان مثال، می‌توانید دو یا چند رنگ را به گونه‌ای اعمال کنید که یکی به تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد علاقه خود را با موقعیت‌های تعریف‌شده با استفاده از متد [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) از مجموعه‌ی توقف‌های گرادیان که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # افزودن دو توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادرشده نسبت به آن در پاورپوینت متفاوت به نظر برسد، به [Choose a Gradient Rendering Style](/slides/fa/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ انتخاب کنید بدون این‌که پر کردن گرادیان ذخیره‌شده در ارائه تغییر کند.

## **پر کردن الگو**

در پاورپوینت، پر کردن الگو یک گزینه قالب‌بندی است که به شما اجازه می‌دهد طراحی دو رنگی—مانند نقطه‌ها، خط‌های راه‌راه، الگوهای متقاطع یا الگوهای شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را تعیین کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. رنگ پس‌زمینهٔ الگو را با استفاده از [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) تنظیم کنید.
1. رنگ پیش‌زمینهٔ الگو را با استفاده از [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) تنظیم کنید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تنظیم نوع پر کردن به Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # تنظیم رنگ پس‌زمینه و پیش‌زمینهٔ الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در پاورپوینت، پر کردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل درج کنید و به‌صورت مؤثر از تصویر به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دیگری که ترجیح می‌دهید) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `SlidesPicture.setImage` منتقل کنید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم که تصویر زیر را دارد:

![تصویر لوتوس](lotus.png)

کد پایتون زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # تنظیم نوع پر کردن به Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # تنظیم حالت پر کردن تصویر.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # تنظیم تصویر.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): ترازبندی کاشی‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به صورت افقی، عمودی یا هر دو برعکس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (بر حسب نقاط) را از مبدای شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (بر حسب نقاط) را از مبدای شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصدی تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصدی تعریف می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    first_slide = presentation.getSlides().get_Item(0)

    # افزودن یک rectangle auto shape.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # تنظیم نوع پر کردن شکل به Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # بارگذاری تصویر و افزودن آن به منابع ارائه.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # اختصاص تصویر به شکل.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ ثابت**

در پاورپوینت، پر کردن رنگ ثابت یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگویی اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تنظیم نوع پر کردن به Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # تنظیم رنگ پر کردن.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، وقتی یک پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار بیشتر شفافیت باعث می‌شود شکل شفاف‌تر باشد و پس‌زمینه یا اشیای زیرین به‌صورت جزئی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار alpha در رنگ مورد استفاده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. از [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape مستطیل صلب.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # افزودن یک auto shape مستطیل شفاف بر بالای شکل صلب.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # ذخیره فایل PPTX روی دیسک.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت بچرخانید. این می‌تواند هنگام قرار دادن عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل روی اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک auto shape از نوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # چرخاندن شکل به اندازهٔ 5 درجه.
    shape.setRotation(5)

    # ذخیرهٔ فایل PPTX روی دیسک.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجسته‌سازی ۳‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی ۳‌بعدی را بر روی اشکال با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) آنها اعمال کنید.

برای افزودن افکت‌های برجسته‌سازی ۳‌بعدی به یک شکل، این مراحل را دنبال کنید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) را ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# ایجاد یک نمونه از کلاس Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل به اسلاید.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![افکت برجسته‌سازی ۳‌بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش ۳‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش ۳‌بعدی را بر روی اشکال با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) آنها اعمال کنید.

برای اعمال چرخش ۳‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به یک اسلاید بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) و [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) برای تعریف چرخش ۳‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# ایجاد یک نمونه از کلاس Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # ذخیرهٔ ارائه به عنوان فایل PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![افکت چرخش ۳‌بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‌سفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) تعیین می‌کند که یک شکل فرد هنگام مشاهده یا پردازش ارائه در حالت سیاه‌سفید چگونه رندر شود. این متد به تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و قالب‌بندی‌های پر کردن، خط یا سایر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار از کلاس [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار مورد نظر استفاده کنید. به‌عنوان مثال، `Automatic` به برنامه رندر اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به کار می‌برد، `Black` و `White` یک رنگ را اجباری می‌کنند، `Color` رنگ عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‌شکلی تعیین نشده است.

کد پایتون زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‌سفید به‌صورت خاکستری نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # پر رنگ نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه-سفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در حالت رنگ عادی، مستطیل پر رنگ نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‌سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این به شما اجازه می‌دهد اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد پایتون زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با جای‌گیرها در [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض بازگردانید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # بازنشانی هر شکلی در اسلاید که دارای جای‌گیر در چیدمان است.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**آیا قالب‌بندی شکل بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت حداقلی. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پر کردن، خط و افکت‌ها—را مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک‌های آنها را یکسان در نظر بگیرید و به‌صورت منطقی آن اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. اشکال نمونه با سبک‌های مورد نظر را در یک مجموعه اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کپی کنید و قالب‌بندی آنها را در هر جایی که لازم است دوباره اعمال کنید.