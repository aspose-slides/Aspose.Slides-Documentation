---
title: "افزودن اشکال خط به ارائه‌ها در پایتون از طریق جاوا"
linktitle: "خط"
type: docs
weight: 50
url: /fa/python-java/line/
keywords:
- "خط"
- "ایجاد خط"
- "افزودن خط"
- "خط ساده"
- "پیکربندی خط"
- "سفارشی‌سازی خط"
- "سبک نقطه‌دار"
- "سر پیکان"
- "PowerPoint"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید. ویژگی‌ها، متدها و مثال‌ها را کشف کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خط را به صورت برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه خطی را سفارشی کنید تا به صورت پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خط به اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. مثال‌ها بر روی تنظیمات عملی فرمت‌بندی خط مانند سبک، عرض، الگوی نقطه‌دار، گزینه‌های سرپیکان و رنگ پر رنگ متمرکز هستند.

## **ایجاد یک خط ساده**

برای افزودن یک خط ساده به اسلاید انتخاب‌شدهٔ ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) از شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) یک شکل خط اضافه کنید.
- ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر یک خط را به اولین اسلاید ارائه اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# یک نمونه از کلاس Presentation که فایل PPTX را نمایندگی می‌کند.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل خط.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # نوشتن فایل PPTX بر روی دیسک.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ایجاد یک خط به‌صورت پیکان**

Aspose.Slides برای Python از طریق Java همچنین به توسعه‌دهندگان امکان می‌دهد تا خصوصیات خط را طوری تنظیم کنند که ظاهر به‌تری داشته باشد. برای تنظیم خط به‌صورت پیکان، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) از شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) یک شکل خط اضافه کنید.
- [line style](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linestyle/) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای Python از طریق Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- [dash style](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linedashstyle/) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای Python از طریق Java تنظیم کنید.
- [arrowhead style](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linearrowheadstyle/) و [length](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linearrowheadlength/) را در ابتدای خط تنظیم کنید.
- [arrowhead style](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linearrowheadstyle/) و [length](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linearrowheadlength/) را در انتهای خط تنظیم کنید.
- ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# یک نمونه از کلاس Presentation که فایل PPTX را نمایندگی می‌کند.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل خط.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # اعمال قالب‌بندی بر روی خط.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # نوشتن فایل PPTX بر روی دیسک.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم یک خط عادی را به کانکتور تبدیل کنم تا به اشکال «چسبیده» شود؟**

خیر. یک خط عادی (یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/)) به‌صورت خودکار به کانکتور تبدیل نمی‌شود. برای اینکه به اشکال چسبیده شود، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/python-java/aspose.slides/connector/) و APIهای مرتبط [/slides/fa/python-java/connector/] استفاده کنید.

**اگر ویژگی‌های یک خط از تم به ارث برده شده باشد و تعیین مقادیر نهایی دشوار باشد، باید چه کار کنم؟**

[ویژگی‌های مؤثر](/slides/fa/python-java/shape-effective-properties/) خط و پر آن را بخوانید—این‌ها پیشاپیش ارث‌بری و سبک‌های تم را در نظر گرفته‌اند.

**آیا می‌توانم خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال دارای [lock objects](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#getAutoShapeLock) هستند که به شما اجازه می‌دهند عملیات ویرایشی را [غیرمجاز کنید](/slides/fa/python-java/applying-protection-to-presentation/).