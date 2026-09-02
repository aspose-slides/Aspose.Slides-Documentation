---
title: تبدیل اسلایدهای ارائه به تصاویر در پایتون
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/python-net/convert-slide/
keywords:
- تبدیل اسلاید
- صادر کردن اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌های تصویری در پایتون با Aspose.Slides تبدیل کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق .NET می‌تواند اسلایدهای جداگانه‌ی ارائه‌های PowerPoint و OpenDocument را به‌صورت فرمت‌های PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویری رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را انجام دهید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) تنظیم کنید.
4. متد [Slide.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برمی‌گرداند.
5. متد [IImage.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/) را فراخوانی کنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش شود یا در فایلی ذخیره گردد.

مثال زیر به زبان Python اولین اسلاید را رندر کرده و به عنوان تصویر PNG ذخیره می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از overload متد [Slide.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) که یک مقدار [Size](https://reference.aspose.com/slides/fa/python-net/aspose.pydrawing/size/) می‌پذیرد، برای رندر کردن اسلاید با ابعاد پیکسل دقیق استفاده کنید.

مثال زیر تصویر JPEG به ابعاد ۱۸۲۰ × ۱۰۴۰ پیکسل ایجاد می‌کند:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

به‌صورت پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. برای کنترل مکان نمایش یادداشت‌ها و نظرات، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) را به ویژگی [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) اختصاص دهید.

مثال زیر یادداشت‌های کوتاه‌شده را زیر اسلاید و نظرات را در سمت راست آن قرار می‌دهد:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
برای تبدیل اسلاید به تصویر، ویژگی [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) را روی [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notespositions/) تنظیم نکنید. یادداشت‌ها می‌توانند متن بیشتری نسبت به اندازه ثابت تصویر داشته باشند. به جای آن از [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) به شما اجازه می‌دهد تا اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را کنترل کنید.

مثال زیر اولین اسلاید را به عنوان تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ پیکسل و ۳۰۰ DPI رندر می‌کند:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **تبدیل تمام اسلایدها به تصاویر**

از طریق مجموعه اسلایدها حلقه بزنید تا تمام ارائه به مجموعه‌ای از تصاویر تبدیل شود. اسلایدهای مخفی نیز گنجانده می‌شوند مگر اینکه به‌صراحت آنها را نادیده بگیرید.

مثال زیر هر اسلاید را به عنوان تصویر JPEG با مقیاس افقی و عمودی ۲ رندر می‌کند:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های مبتنی بر بردار باید با Microsoft Office یا سایر برنامه‌های ویندوزی که از متافایل‌های ویندوزی پشتیبانی می‌کنند، مبادله شود. برخلاف تصویر مبتنی بر پیکسل، یک EMF می‌تواند عملیات رسم برداری را حفظ کند که بدون از دست دادن وضوح قابل مقیاس‌گذاری است. اما EMF عمدتاً یک قالب سازگاری برای برنامه‌هایی است که از متافایل ویندوزی پشتیبانی می‌کنند و نه یک قالب تبادل عمومی. علاوه بر این، محتوای پیچیده اسلاید، مانند تصاویر بیت‌مپ و برخی افکت‌ها، ممکن است به‌صورت عناصر رستری در داخل ظرف متافایل برداری ذخیره شوند.

### **صادر کردن یک اسلاید به EMF**

متد [Slide.write_as_emf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/write_as_emf/) یک [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) را به یک جریان هدف به فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اولین اسلاید را انتخاب می‌کند و آن را به یک جریان فایل EMF می‌نویسد:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

صاحب جریان (caller) که به [Slide.write_as_emf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/write_as_emf/) پاس داده می‌شود، مسئول بسته شدن آن است. Aspose.Slides در موقعیت جاری جریان می‌نویسد و جریان را باز می‌گذارد.

### **تبدیل یک تصویر SVG به EMF و افزودن آن به ارائه**

از [SvgImage.write_as_emf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/write_as_emf/) برای تبدیل محتوای SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [ImageCollection.add_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/add_image/) به ارائه اضافه شوند و با [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) از علامت‌گذاری SVG ایجاد می‌کند، آن را به یک EMF در حافظه تبدیل می‌کند، متافایل را بر روی اولین اسلاید درج می‌کند و ارائه را ذخیره می‌نماید:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/write_as_emf/) مالکیت جریان مقصد را بر عهده نمی‌گیرد. پس از نوشتن، موقعیت جریان در انتهای داده‌های تولیدی قرار دارد. برای دریافت تمام بافر irrespective از موقعیت جاری جریان، همان‌طور که در بالا نشان داده شد، متد `getvalue` را فراخوانی کنید. تا زمانی که داده‌ها خوانده شوند، جریان را باز نگه دارید و پس از آن آن را ببندید.

تولید EMF در سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides برای Python از طریق .NET قابل دسترس است، اما رندرینگ ممکن است بین سکوها متفاوت باشد وقتی فونت‌ها یا وابستگی‌های گرافیکی بومی در دسترس نیستند. فونت‌های مورد استفاده در محتوای منبع را نصب کنید یا جایگزین‌های مناسب تنظیم کنید، [پلتفرم‌نیازمندی‌ها](/slides/fa/python-net/system-requirements/) Aspose.Slides را دنبال کنید و نتیجه را در برنامه مصرف‌کننده EMF هدف تأیید نمایید. برنامه‌های لینوکس و macOS غالباً پشتیبانی محدود یا ناسازگاری برای نمایش و ویرایش متافایل‌های ویندوزی دارند.

## **رندرینگ ایموجی‌های رنگی**

{{% alert title="Note" color="info" %}}
برای رندرینگ صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی مورد استفاده در ارائه باید نصب شده و در سیستمی که تبدیل را انجام می‌دهد، در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides رندرینگ اسلایدها با انیمیشن‌ها را پشتیبانی می‌کند؟**

خیر. متد [Slide.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را صادر نمی‌سازد.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی رندر شوند. آنها را در حلقه پردازش، همان‌طور که در مثال بالا نشان داده شد، بگنجانید.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.