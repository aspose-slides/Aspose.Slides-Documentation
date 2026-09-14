---
title: تبدیل اسلایدهای ارائه به تصاویر در پایتون
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/python-java/convert-slide/
keywords:
- تبدیل اسلاید
- صدور اسلاید
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

Aspose.Slides for Python via Java می‌تواند اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویر رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) پیکربندی کنید.
4. متد [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) را فراخوانی کنید. این متد یک شیء تصویر بازمی‌گرداند.
5. تصویر را ذخیره کنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل اسلاید به تصویر PNG**

ساده‌ترین روش تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء تصویر حاصل می‌تواند در حافظه پردازش شود یا در فایلی ذخیره گردد.

مثال زیر اسلاید اول را رندر کرده و به‌عنوان تصویر PNG ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از overload متد [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) که یک مقدار [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) می‌گیرد استفاده کنید تا اسلاید را با ابعاد پیکسلی دقیق رندر کنید.

مثال زیر یک تصویر JPEG به اندازه ۱۸۲۰ × ۱۰۴۰ ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل اسلایدها با یادداشت‌ها و کامنت‌ها به تصاویر**

به‌طور پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا کامنت‌ها نیستند. برای کنترل مکان نمایش یادداشت‌ها و کامنت‌ها، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) را به متد [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) پاس دهید.

مثال زیر یادداشت‌های کوتاه شده را زیر اسلاید و کامنت‌ها را به سمت راست آن قرار می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
برای تبدیل اسلاید به تصویر، مقدار [BottomFull](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomFull) را به متد [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) پاس ندهید. یادداشت‌ها می‌توانند بیش از اندازه تصویر ثابت متنی داشته باشند. به‌جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomTruncated) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) به شما امکان کنترل اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را می‌دهد.

مثال زیر اسلاید اول را به‌عنوان تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ و وضوح ۳۰۰ DPI رندر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
پشتیبانی از TIFF در نسخه‌های جاوا قبل از JDK 9 تضمین نمی‌شود.
{{% /alert %}}

## **تبدیل تمام اسلایدها به تصاویر**

از مجموعه اسلایدها عبور کنید تا تمام ارائه به‌صورت مجموعه‌ای از تصاویر تبدیل شود. اسلایدهای مخفی نیز گنجانده می‌شوند مگر این‌که صراحتاً از پردازش آن‌ها صرف‌نظر کنید.

مثال زیر هر اسلاید را به‌عنوان تصویر JPEG با ضریب مقیاس افقی و عمودی برابر با ۲ رندر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های برداری باید با Microsoft Office یا برنامه‌های دیگر ویندوزی که از متافایل‌های ویندوز پشتیبانی می‌کنند، تبادل شوند. برخلاف تصویر پیکسلی، EMF می‌تواند عملیات رسم برداری را حفظ کند که بدون افت وضوح مقیاس می‌شوند. با این حال، EMF عمدتاً یک فرمت سازگاری برای برنامه‌های دارای پشتیبانی از متافایل ویندوز است و نه یک فرمت تبادل جهانی. علاوه بر این، محتوای پیچیده اسلاید، مانند تصاویر بیت‌مپ و برخی افکت‌ها، ممکن است به‌صورت عناصر رستر شده داخل بستهٔ متافایل برداری ذخیره شوند.

### **صدور اسلاید به EMF**

متد [Slide.writeAsEmf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) یک [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) را به‌صورت یک جریان هدف در فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری کرده، اسلاید اول را انتخاب می‌کند و آن را به‌عنوان یک جریان فایل EMF می‌نویسد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

صاحب جریان پاس داده شده به [Slide.writeAsEmf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) مسئول بستن آن است، همان‌طور که در بالا نشان داده شد.

### **تبدیل تصویر SVG به EMF و افزودن آن به یک ارائه**

از [SvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) برای تبدیل محتویات SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه شوند و با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) را از مارکاپ SVG ایجاد می‌کند، آن را به یک EMF در حافظه تبدیل می‌کند، متافایل را در اسلاید اول قرار می‌دهد و ارائه را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) مالکیت جریان مقصد را بر عهده نمی‌گیرد. یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین پیش از فراخوانی [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) نیازی به بازنشانی موقعیت نیست. آرایه بایت بازگردانده‌شده پس از بسته شدن جریان همچنان معتبر است.

تولید EMF بر روی سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides for Python via Java و پیکربندی JDK در دسترس است، اما رندرینگ می‌تواند بسته به وجود یا عدم وجود فونت‌ها یا وابستگی‌های گرافیکی در پلتفرم‌ها متفاوت باشد. فونت‌های استفاده‌شده در محتویات منبع را نصب کنید یا جایگزین‌های مناسب تنظیم کنید، الزامات [پلتفرم](/slides/fa/python-java/system-requirements/) را برای Aspose.Slides for Python via Java دنبال کنید و نتیجه را در برنامهٔ مصرف‌کننده EMF هدف اعتبارسنجی کنید. برنامه‌های لینوکس و macOS اغلب پشتیبانی محدودی یا ناسازگاری در نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندر رنگی ایموجی**

{{% alert title="Note" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی استفاده‌شده در ارائه باید نصب شده و در سیستمی که تبدیل انجام می‌شود در دسترس باشند. برای مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سؤال‌های متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر. متد [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را صادر نمی‌نماید.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند مانند اسلایدهای عادی رندر شوند. آن‌ها را در حلقه پردازش گنجانده باشید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.