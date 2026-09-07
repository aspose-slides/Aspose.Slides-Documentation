---
title: تبدیل PPT و PPTX به JPG در Python
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/python-java/convert-powerpoint-to-jpg/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- PowerPoint به JPG
- PPT به JPG
- PPTX به JPG
- ذخیره اسلاید به عنوان JPG
- صادرات PPT به JPG
- صادرات PPTX به JPG
- پایتون
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint (PPT، PPTX) را به تصاویر JPG در Python از طریق Java تبدیل کنید. ابعاد سفارشی تصویر را تنظیم کنید و یادداشت‌ها و نظرات را با Aspose.Slides رندر کنید."
---
## **معرفی**

Aspose.Slides for Python via Java به شما امکان می‌دهد ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) را به تصاویر JPEG تبدیل کنید. می‌توانید هر اسلاید یا اسلایدهای انتخابی را صادر کرده و برای ایجاد تصاویر بندانگشتی، ساخت یک نماینده ارائه، یا جاسازی پیش‌نمایش اسلایدها در وب‌سایت یا برنامه استفاده کنید.

## **تبدیل PowerPoint PPT/PPTX به JPG**

1. ارائه را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدها را با استفاده از [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) بازیابی کنید.
3. با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) و مقیاس‌های افقی و عمودی، هر اسلاید را رندر کنید.
4. هر تصویر رندر شده را به صورت JPEG با استفاده از [ImageFormat.Jpeg](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/#Jpeg) ذخیره کنید، سپس منابع تصویر را آزاد کنید.

{{% alert color="info" title="Note" %}}
صادر کردن به JPG برای هر اسلاید یک تصویر جداگانه ایجاد می‌کند. تصویر رندر شده را ذخیره کنید نه اینکه ارائه را مستقیماً به فرمت تصویر ذخیره کنید.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint PPT/PPTX به JPG با ابعاد سفارشی**

مقامات افقی و عمودی را از ابعاد پیکسلی موردنظر و اندازه اصلی اسلاید محاسبه کنید، سپس آن‌ها را به [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) بدهید. مثال زیر تصویری با ابعاد ۱۲۰۰ × ۸۰۰ برای هر اسلاید هدف‌گذاری می‌کند.

استفاده از مقیاس‌های متفاوت می‌تواند اسلاید را کشیده کند. برای حفظ نسبت تصویر، همان مقیاس را برای هر دو محور استفاده کنید؛ عرض و ارتفاع حاصل سپس از نسبت‌های اصلی اسلاید تبعیت می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصویر**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) برای پیکربندی یادداشت‌ها و نظرات استفاده کنید و طرح‌بندی را از طریق [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) اعمال کنید. این مثال یادداشت‌ها را در پایین قرار می‌دهد، یادداشت‌هایی که جا نمی‌شوند را کوتاه می‌کند و نظرات را در سمت راست در ناحیه‌ای به عرض ۲۰۰ پیکسل نشان می‌دهد. هر اسلاید رندر شده را به عنوان تصویر JPG ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم چندین اسلاید یا ارائه را به JPG تبدیل کنم؟**  
بله. مثال‌ها تمام اسلایدها را حلقه می‌زنند و برای هر اسلاید یک JPG ذخیره می‌کنند. برای پردازش چندین ارائه، تبدیل را برای هر فایل ورودی تکرار کنید و از پوشه‌های خروجی جداگانه یا نام‌های فایل منحصر به فرد استفاده کنید تا از بازنویسی تصاویر جلوگیری شود.

**آیا نمودارها، SmartArt، جدول‌ها و اشکال در تصاویر گنجانده می‌شوند؟**  
این اشیاء به عنوان بخشی از اسلاید رندر می‌شوند. فونت‌های استفاده شده در ارائه را در محیط تبدیل در دسترس قرار دهید تا تفاوت‌های ناشی از جایگزینی فونت کاهش یابد.

**چگونه می‌توانم مصرف حافظه را هنگام صادر کردن ارائه‌های بزرگ کاهش دهم؟**  
تصاویر را به‌صورت تک‌تک پردازش کنید، پس از ذخیره هر تصویر آن را آزاد کنید و از ابعاد خروجی غیرضروری بزرگ خودداری کنید. نیازهای حافظه وابسته به محتوای اسلاید و اندازه تصویر هستند.

## **موارد مرتبط**

- [تبدیل PowerPoint به PNG](/slides/fa/python-java/convert-powerpoint-to-png/).
- [رندر یک اسلاید به عنوان تصویر SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/).