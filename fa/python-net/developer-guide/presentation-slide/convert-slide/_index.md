---
title: تبدیل اسلایدهای PowerPoint به تصویر در Python
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/python-net/convert-slide/
keywords:
- تبدیل اسلاید
- تبدیل اسلاید به تصویر
- صادر کردن اسلاید به عنوان تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدهای PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای Python از طریق .NET به فرمت‌های مختلف تبدیل کنید. به راحتی اسلایدهای PPTX و ODP را به BMP، PNG، JPEG، TIFF و سایر فرمت‌ها با نتایج با کیفیت بالا صادر کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد به آسانی اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های مختلف تصویری تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و دیگران.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل موردنظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از موارد زیر انتخاب کنید:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/)، یا
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد `get_image` از کلاس [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) تولید کنید.

در Aspose.Slides برای Python از طریق .NET، کلاس [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) یک کلاس است که به شما امکان کار با تصاویری را می‌دهد که بر پایه داده‌های پیکسلی تعریف شده‌اند. می‌توانید از یک نمونه از این کلاس برای ذخیره‌سازی تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در قالب PNG**

می‌توانید یک اسلاید را به یک شی بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌طور جایگزین، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در قالب JPEG یا هر قالب دلخواه دیگری ذخیره کنید.

این کد پایتون نشان می‌دهد چگونه اولین اسلاید یک ارائه را به شی بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # اسلاید اول ارائه را به بیت‌مپ تبدیل کنید.
    with presentation.slides[0].get_image() as image:
        # تصویر را در قالب PNG ذخیره کنید.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

شاید نیاز به دریافت تصویری با اندازه‌ای خاص داشته باشید. با استفاده از یک overload از متد [get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)، می‌توانید یک اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد چگونه این کار را انجام دهید:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # اسلاید اول ارائه را به بیت‌مپ با اندازهٔ مشخص تبدیل کنید.
    with presentation.slides[0].get_image(image_size) as image:
        # تصویر را در قالب JPEG ذخیره کنید.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو کلاس—[TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/)—را فراهم می‌کند که به شما امکان کنترل رندرینگ اسلایدهای ارائه به تصاویر را می‌دهد. هر دو کلاس شامل ویژگی `slides_layout_options` هستند که به شما اجازه می‌دهد رندرینگ یادداشت‌ها و نظرات روی یک اسلاید را هنگام تبدیل به تصویر پیکربندی کنید.

با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر خروجی مشخص کنید.

این کد پایتون نشان می‌دهد چگونه یک اسلاید حاوی یادداشت‌ها و نظرات را تبدیل کنید:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # موقعیت یادداشت‌ها را تنظیم کنید.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # موقعیت نظرات را تنظیم کنید.
    notes_comments_options.comments_area_width = 500                                       # عرض ناحیه نظرات را تنظیم کنید.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # رنگ ناحیه نظرات را تنظیم کنید.

    # گزینه‌های رندرینگ را ایجاد کنید.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # اسلاید اول ارائه را به تصویر تبدیل کنید.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # تصویر را در قالب GIF ذخیره کنید.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، ویژگی [notes_position](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) نمی‌تواند روی `BOTTOM_FULL` تنظیم شود (برای مشخص کردن موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بیش از حد بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد. 
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) کنترل بیشتری بر روی تصویر TIFF خروجی فراهم می‌کند، به‌طوری که می‌توانید پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد پایتون یک فرآیند تبدیل را نشان می‌دهد که در آن از گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# یک فایل ارائه را بارگذاری کنید.
with slides.Presentation("sample.pptx") as presentation:
    # اولین اسلاید را از ارائه دریافت کنید.
    slide = presentation.slides[0]

    # تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # اندازه تصویر را تنظیم کنید.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # فرمت پیکسلی را تنظیم کنید (سیاه و سفید).
    options.dpi_x = 300                                                        # وضوح افقی را تنظیم کنید.
    options.dpi_y = 300                                                        # وضوح عمودی را تنظیم کنید.

    # اسلاید را با گزینه‌های مشخص به تصویر تبدیل کنید.
    with slide.get_image(options) as image:
        # تصویر را در قالب TIFF ذخیره کنید.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌طور مؤثری کل ارائه را به یک سری تصاویر تبدیل نمایید.

این کد نمونه نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را در پایتون به تصاویر تبدیل کنید:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # ارائه را به صورت اسلاید به اسلاید به تصاویر رندر کنید.
    for i, slide in enumerate(presentation.slides):
        # کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if slide.hidden:
            continue

        # اسلاید را به تصویر تبدیل کنید.
        with slide.get_image(scale_x, scale_y) as image:
            # تصویر را در قالب JPEG ذخیره کنید.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **پرسش‌های متداول**

**آیا Aspose.Slides از رندرینگ اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `get_image` فقط تصویر ایستایی از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا اسلایدهای مخفی می‌توانند به‌عنوان تصویر صادر شوند؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به عنوان تصویر، رندرینگ سایه‌ها، شفافیت و سایر افکت‌های گرافیکی را پشتیبانی می‌کند.