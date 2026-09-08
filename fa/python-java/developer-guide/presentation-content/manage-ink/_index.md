---
title: مدیریت اشیای جوهر ارائه در پایتون از طریق جاوا
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/python-java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیابی جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- خروجی جوهر
- رندرینگ جوهر
- پنهان کردن جوهر
- InkOptions
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "مدیریت اشیای جوهر PowerPoint، ویرایش ردیابی‌ها و ویژگی‌های قلم، و کنترل ظاهر جوهر در طول خروجی PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای پایتون از طریق جاوا."
---
## **معرفی**

PowerPoint یک ویژگی جوهر (Ink) ارائه می‌دهد که به شما امکان می‌دهد خطوط آزاد رسم کنید. می‌توانید از جوهر برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها، و جلب توجه به موارد خاص در یک اسلاید استفاده کنید.

Aspose.Slides انواع مورد نیاز برای کار با اشیای جوهر را فراهم می‌کند. برای مثال، کلاس [Ink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ink/) نمایانگر یک شیء جوهر در یک اسلاید است.

## **تفاوت بین اشیای معمولی و اشیای جوهر**

اشیای موجود در اسلاید PowerPoint معمولاً توسط اشیای Shape نمایانده می‌شوند. در ساده‌ترین فرم، یک Shape یک محفظه است که ناحیهٔ خود شیء (قاب آن) را به همراه ویژگی‌هایی مانند اندازهٔ محفظه، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر، به [Shape Layout Format](/slides/fa/python-java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما هنگامی که PowerPoint با یک شیء جوهر سروکار دارد، تمام ویژگی‌های قاب شیء (محفظه) به جز اندازهٔ آن را نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه توسط متدهای استاندارد [Shape.getWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getWidth) و [Shape.getHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getHeight) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیابی جوهر (Ink Traces)**

یک ردیابی جوهر عنصری پایه‌ای است که برای ثبت مسیر قلم هنگام نوشتن جوهر دیجیتال استفاده می‌شود. یک ردیابی مجموعه‌ای از نقاط متصل به هم را ذخیره می‌کند.

ساده‌ترین فرم رمزگذاری، مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مشابه زیر تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم برای رسم**

یک قلم (Brush) برای رسم خطوطی که نقاط یک ردیابی جوهر را به هم وصل می‌کند، استفاده می‌شود. قلم دارای رنگ و اندازهٔ خود است که توسط متدهای [InkBrush.getColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkbrush/#getColor) و [InkBrush.getSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkbrush/#getSize) نمایان می‌شود.

### **تنظیم رنگ قلم جوهر**

این کد Python نشان می‌دهد چگونه رنگ یک قلم جوهر تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **تنظیم اندازه قلم جوهر**

این کد Python نشان می‌دهد چگونه اندازهٔ یک قلم جوهر تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

به‌ طور کلی، عرض و ارتفاع یک قلم یکسان نیستند، بنابراین PowerPoint اندازهٔ قلم را نمایش نمی‌دهد (بخش مربوطه خاکستری می‌شود). وقتی عرض و ارتفاع قلم برابر شوند، PowerPoint اندازهٔ آن را به این شکل نشان می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ قلم‌ها را درنظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (نگاه کنید به تصویر قبلی).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ قلم ردیابی‌های آن درنظر گرفته شود. در اینجا، شیء هدف (ردیابی متن دستی) به اندازهٔ محفظه (قاب) مقیاس داده شده است. وقتی اندازهٔ محفظه تغییر می‌کند، اندازهٔ قلم ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیای متنی دارد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر در هنگام خروجی و رندرینگ**

Aspose.Slides کلاس [InkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/) را برای کنترل نحوهٔ نمایش اشیای جوهر در خروجی‌های صادرشده یا رندر شده فراهم می‌کند. می‌توانید از ویژگی‌های آن برای پنهان کردن کامل جوهر یا تغییر نحوهٔ تفسیر عملیات ماسک قلم جوهر استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندر برای چندین نوع خروجی در دسترس هستند:

| خروجی | ویژگی گزینهٔ جوهر |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| تصویر اسلاید | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/#getInkOptions) |

متدهای زیر [InkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/) همان دو تنظیم را افشا می‌کنند:

- [getHideInk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#getHideInk) تعیین می‌کند آیا اشیای جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `False` است.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) تعیین می‌کند آیا یک عملیات ماسک به عنوان شفافیت تفسیر شود وقتی یک قلم جوهر رندر می‌شود. مقدار پیش‌فرض آن `True` است؛ برای استفاده از عملیات ROP به جای آن، متد [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) را با `False` فراخوانی کنید.

### **پنهان کردن اشیای جوهر در خروجی PDF**

به‌طور پیش‌فرض، اشیای جوهر در طول خروجی‌گیری قابل مشاهده هستند. برای ایجاد خروجی پاک بدون حاشیه‌نویسی‌های دستی یا سایر محتوای جوهر، متد [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#setHideInk) را با `True` فراخوانی کنید.

مثال Python زیر یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیای جوهر را مخفی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **پنهان کردن اشیای جوهر هنگام رندرینگ اسلاید به عنوان تصویر**

برای مخفی کردن اشیای جوهر هنگام رندر اسلایدها به عنوان تصاویر bitmap، [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/#getInkOptions) را پیکربندی کنید و گزینه‌های رندر را به [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) پاس بدهید.

مثال Python زیر اولین اسلاید را به عنوان تصویر PNG بدون اشیای جوهر رندر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **کنترل رندرینگ ماسک جوهر**

تنظیم [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) نحوهٔ تفسیر عملیات ماسک را هنگام رندر کردن قلم‌های جوهر تعیین می‌کند. مقدار پیش‌فرض `True` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP به جای آن، متد [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) را با `False` فراخوانی کنید.

مثال Python زیر یک اسلاید را به SVG صادر می‌کند و از رندرینگ مبتنی بر ROP برای عملیات ماسک جوهر استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

همین تنظیم می‌تواند از طریق [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#getInkOptions) هنگام خروجی‌گیری یک ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب مخفی کردن یا حفظ جوهر**

زمانی که نیاز به نسخهٔ پاک یک ارائه حاشیه‌نویسی‌شده برای توزیع بدون علامت‌های بازبینی دارید، در طول خروجی‌گیری متد [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#setHideInk) را با `True` فراخوانی کنید.

وقتی حاشیه‌نویسی‌های جوهر بخشی از محتوای مورد نظر هستند (مانند نظرات بازبینی، یادداشت‌های دستی، برجسته‌سازی‌ها یا نقاشی‌هایی که باید در نتیجهٔ خروجی قابل مشاهده بمانند)، ویژگی [InkOptions.getHideInk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#getHideInk) را با مقدار پیش‌فرض `False` رها کنید. این امکان به برنامه‌ها اجازه می‌دهد تا خروجی‌های بازبینی و نهایی جداگانه را از همان ارائه بدون تغییر اشیای جوهر منبع تولید کنند.

## **سوالات متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**

بله. ردیابی را از طریق [Ink.getTraces](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ink/#getTraces) دریافت کنید، سپس [InkTrace.getBrush](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inktrace/#getBrush) آن را تغییر دهید. برای تغییر رنگ قلم از [InkBrush.setColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkbrush/#setColor) و برای تغییر اندازهٔ آن از [InkBrush.setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkbrush/#setSize) استفاده کنید.

**آیا مخفی کردن جوهر باعث تغییر ارائهٔ منبع می‌شود؟**

خیر. فراخوانی [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/inkoptions/#setHideInk) فقط بر نتیجهٔ رندر یا خروجی تأثیر می‌گذارد؛ اشیای جوهر در ارائهٔ منبع حذف یا تغییر نمی‌یابند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر bitmap اسلاید از طریق گزینه‌های خروجی یا رندر مربوطه که در بالا نشان داده شد، پیکربندی کنید.

**مطالعهٔ بیشتر**

* برای آشنایی با اشکال به صورت کلی، بخش [PowerPoint Shapes](/slides/fa/python-java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](/slides/fa/python-java/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) نگاه کنید.
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](/slides/fa/python-java/convert-powerpoint-to-html/) مراجعه کنید.
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](/slides/fa/python-java/render-a-slide-as-an-svg-image/) نگاه کنید.
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](/slides/fa/python-java/convert-powerpoint-to-tiff/) مراجعه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](/slides/fa/python-java/convert-slide/) نگاه کنید.