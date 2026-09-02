---
title: تبدیل اسلایدهای PowerPoint به تصاویر در پایتون
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/python-net/convert-slide/
keywords:
- تبدیل اسلاید
- تبدیل اسلاید به تصویر
- صدور اسلاید به عنوان تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدهای PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای Python از طریق .NET به فرمت‌های مختلف تبدیل کنید. اسلایدهای PPTX و ODP را به‌راحتی به BMP، PNG، JPEG، TIFF و دیگر فرمت‌ها با نتایج با کیفیت بالا صادر کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد به‌راحتی اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های مختلف تصویری تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و موارد دیگر.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از انتخاب کنید:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) یا
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/)
2. تصویر اسلاید را با صدا زدن متد `get_image` از کلاس [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) تولید کنید.

در Aspose.Slides برای Python از طریق .NET، کلاس [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) یک کلاس است که به شما امکان کار با تصاویری را می‌دهد که توسط داده‌های پیکسل تعریف شده‌اند. می‌توانید از یک نمونه از این کلاس برای ذخیره تصاویر در طیف گسترده‌ای از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شی بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌علاوه، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در فرمت JPEG یا هر فرمت دلخواه دیگری ذخیره کنید.

این کد پایتون نشان می‌دهد چگونه اسلاید اول یک ارائه را به شی بیت‌مپ تبدیل کرده و سپس تصویر را در فرمت PNG ذخیره کنید:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # تبدیل اولین اسلاید در ارائه به بیت‌مپ.
    with presentation.slides[0].get_image() as image:
        # ذخیره تصویر در فرمت PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویر با اندازه خاصی به‌دست آورید. با استفاده از یک overload از متد [get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) می‌توانید یک اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این نمونه کد نشان می‌دهد چگونه این کار را انجام دهید:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # تبدیل اولین اسلاید در ارائه به بیت‌مپ با اندازه مشخص.
    with presentation.slides[0].get_image(image_size) as image:
        # ذخیره تصویر در فرمت JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو کلاس — [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/) — ارائه می‌دهد که به شما امکان کنترل رندر اسلایدهای ارائه به تصاویر را می‌دهد. هر دو کلاس شامل ویژگی `slides_layout_options` هستند که به شما امکان پیکربندی رندر یادداشت‌ها و نظرات روی اسلاید هنگام تبدیل به تصویر را می‌دهد.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر خروجی تعیین کنید.

این کد پایتون نشان می‌دهد چگونه اسلایدی با یادداشت‌ها و نظرات را تبدیل کنید:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # تعیین موقعیت یادداشت‌ها.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # تعیین موقعیت نظرات.
    notes_comments_options.comments_area_width = 500                                       # تعیین عرض ناحیه نظرات.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # تعیین رنگ ناحیه نظرات.

    # ایجاد گزینه‌های رندر.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # تبدیل اولین اسلاید ارائه به تصویر.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # ذخیره تصویر در فرمت GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، ویژگی [notes_position](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) نمی‌تواند به مقدار `BOTTOM_FULL` تنظیم شود (برای تعیین موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بیش از اندازه بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند؛ به‌طوری که می‌توانید پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد پایتون نشان می‌دهد یک فرآیند تبدیل که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‌سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شوند:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# بارگذاری یک فایل ارائه.
with slides.Presentation("sample.pptx") as presentation:
    # دریافت اولین اسلاید از ارائه.
    slide = presentation.slides[0]

    # پیکربندی تنظیمات تصویر خروجی TIFF.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # تعیین اندازه تصویر.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # تعیین فرمت پیکسل (سیاه و سفید).
    options.dpi_x = 300                                                        # تعیین وضوح افقی.
    options.dpi_y = 300                                                        # تعیین وضوح عمودی.

    # تبدیل اسلاید به تصویر با گزینه‌های مشخص شده.
    with slide.get_image(options) as image:
        # ذخیره تصویر در فرمت TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید، به‌طوری که کل ارائه به مجموعه‌ای از تصاویر تبدیل می‌شود.

این نمونه کد نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را به تصاویر در پایتون تبدیل کنید:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # رندر ارائه به تصاویر به صورت اسلاید به اسلاید.
    for i, slide in enumerate(presentation.slides):
        # کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if slide.hidden:
            continue

        # تبدیل اسلاید به تصویر.
        with slide.get_image(scale_x, scale_y) as image:
            # ذخیره تصویر در فرمت JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **رندر ایموجی‌های رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی مورد استفاده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب شده و در دسترس باشند. به عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی نمایش داده شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `get_image` تنها یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به‌عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. تنها کافی است مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به‌صورت تصویر، از رندر سایه‌ها، شفافی‌ها و سایر اثرات گرافیکی پشتیبانی می‌کند.