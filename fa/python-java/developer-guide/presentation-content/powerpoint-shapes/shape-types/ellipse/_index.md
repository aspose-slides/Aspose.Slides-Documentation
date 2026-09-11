---
title: اضافه کردن بیضی‌ها به ارائه‌ها در Python با استفاده از Java
linktitle: بیضی
type: docs
weight: 30
url: /fa/python-java/ellipse/
keywords:
- بیضی
- شکل
- اضافه کردن بیضی
- ایجاد بیضی
- کشیدن بیضی
- بیضی قالب‌بندی‌شده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه شکل‌های بیضی را در Aspose.Slides برای Python با استفاده از Java در ارائه‌های PPT و PPTX ایجاد، قالب‌بندی و دستکاری کنید—نمونه‌های کد Python نیز گنجانده شده است."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان اشکال بیضی را به اسلایدهای PowerPoint با استفاده از Aspose.Slides اضافه کرد. این مقاله به ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده، و ذخیره‌سازی ارائه به‌روز شده به عنوان فایل PPTX می‌پردازد. همچنین به سؤالات مرتبط مانند کار با موقعیت و اندازه بیضی، کنترل ترتیب لایه‌ها، و اعمال افکت‌های انیمیشن اشاره می‌کند.

## **ایجاد یک بیضی**

برای اضافه کردن یک بیضی ساده به اسلاید انتخاب‌شده ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک ارجاع به اسلاید را بر اساس اندیس آن دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) از شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/)، یک بیضی اضافه کنید.
- ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

مثال زیر یک بیضی را به اولین اسلاید اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# نمونه‌سازی کلاس Presentation که فایل PPTX را نمایندگی می‌کند.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل بیضی.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # نوشتن فایل PPTX بر روی دیسک.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ایجاد یک بیضی قالب‌بندی‌شده**

برای اضافه کردن یک بیضی قالب‌بندی‌شده به اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک ارجاع به اسلاید را بر اساس اندیس آن دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) از شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/)، یک بیضی اضافه کنید.
- نوع پر کردن بیضی را به حالت solid تنظیم کنید.
- رنگ پر کردن بیضی را با استفاده از [getSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getSolidFillColor) روی شیء [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) تنظیم کنید.
- رنگ حاشیهٔ بیضی را تنظیم کنید.
- عرض حاشیهٔ بیضی را تنظیم کنید.
- ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

مثال زیر یک بیضی قالب‌بندی‌شده را به اولین اسلاید ارائه اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که فایل PPTX را نمایندگی می‌کند.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل بیضی.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # قالب‌بندی پر رنگ بیضی.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # قالب‌بندی خط مرزی بیضی.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # نوشتن فایل PPTX بر روی دیسک.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**چگونه می‌توان موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کرد؟**

مختصات و اندازه‌ها معمولاً به **نقطه** (points) مشخص می‌شوند. برای نتایج قابل پیش‌بینی، محاسبات خود را بر پایهٔ اندازهٔ اسلاید انجام داده و میلی‌متر یا اینچ مورد نیاز را پیش از اختصاص مقادیر به نقاط تبدیل کنید.

**چگونه می‌توان یک بیضی را بالای یا زیر اشیای دیگر قرار داد (کنترل ترتیب لایه‌ها)؟**

ترتیب رسم شیء را با آوردن آن به جلو یا ارسال به عقب تنظیم کنید. این کار باعث می‌شود بیضی بر روی دیگر اشیاء همپوشانی داشته باشد یا اشیاء زیرین را نمایش دهد.

**چگونه می‌توان ظهور یا تأکید یک بیضی را انیمیت کرد؟**

[اعمال](/slides/fa/python-java/shape-animation/) افکت‌های ورود، تأکید یا خروج را به شکل اعمال کنید و محرک‌ها و زمان‌بندی را پیکربندی کنید تا زمان و نحوه پخش انیمیشن را تنظیم کنید.