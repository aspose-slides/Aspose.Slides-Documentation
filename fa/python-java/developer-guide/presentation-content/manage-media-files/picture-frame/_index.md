---
title: مدیریت فریم‌های تصویر در ارائه‌ها با استفاده از پایتون
linktitle: فریم تصویر
type: docs
weight: 10
url: /fa/python-java/picture-frame/
keywords:
- فریم تصویر
- افزودن فریم تصویر
- ایجاد فریم تصویر
- تصویر جاسازی‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی فریم تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی فریم‌های تصویر در ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا."
---
## **مروری کلی**

یک PictureFrame یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیاء جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/) خود مالکیت می‌کند، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) برگشتی را نگه دارید و هنگام ایجاد PictureFrameها از آن منبع تصویر استفاده کنید.

PictureFrameها می‌توانند تصاویر رستری مانند PNG یا JPEG و تصاویر برداری SVG را شامل شوند. همچنین می‌توانند به تصاویر پیوندی ارجاع دهند به جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین قبل از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری درباره نحوه ذخیره تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک PictureFrame با استفاده از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین وقتی به کامپیوتر دیگری منتقل می‌شود، ارائه به‌صورت خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، فریمی با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PictureFrame هندسه نمایش داده شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تفکیک زمانی مهم می‌شود که بعداً تصویر برش یا فشرده شود.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی فریم را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) افشا می‌کند. مقدار `1.0` معادل 100٪ اندازه اصلی تصویر است. مقیاس نسبی وقتی مفید است که یک گردش کار نیاز داشته باشد رابطه‌ای با اندازه تصویر منبع حفظ شود به جای محاسبه دستی ابعاد نهایی.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ این کار بازنمونه‌برداری یا فشرده‌سازی تصویر جاسازی‌شده را انجام نمی‌دهد.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شده محسوب می‌شود. یک تصویر پیوندی مسیر خارجی را از طریق متد [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#setLinkPathLong) ذخیره می‌کند به جای این‌که داده‌های تصویر را به همان شکل جاسازی کند.

تصاویر پیوندی می‌توانند حجم داده‌های تصویری ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است مطابق انتظار نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، آرشیو شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌تر هستند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک PictureFrame ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدئو یک گردش کار رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

از پیوندها وقتی مدیریت فایل‌های خارجی مقصود است استفاده کنید. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر از یک ارائه بزرگتر و خودکفا مفید است.

## **استخراج تصاویر از PictureFrameها**

قبل از استخراج یک تصویر از یک ارائه موجود، اطمینان حاصل کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) است و یک تصویر جاسازی‌شده دارد. PictureFrameهای پیوندی ممکن است بایت‌های تصویری که بتوان به همان روش استخراج کرد را نداشته باشند.

### **استخراج تصویر رستری**

API تصویر مدرن به‌صورت مستقیم با تصاویر رستری کار می‌کند و نیازی به wrapper تصویر قدیمی Java نیست. مثال زیر اولین تصویر رستر جاسازی‌شده روی یک اسلاید را پیدا می‌کند و به صورت PNG ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

ذخیره تصویر رستری تصویر استخراج‌شده را به فرمت خروجی مورد درخواست تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده ذخیره‌شده در ارائه نیاز دارید نه به فایل رستری تبدیل‌شده، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) را نمایان می‌کند. این امکان را می‌دهد که داده‌های SVG را به‌صورت مستقیم بازیابی کنید به‌جای این‌که ابتدا تصویر را رستر کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

نگه‌داشتن محتوای SVG به صورت SVG وفاداری بردار را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG ناگزیر این محتوای برداری را به پیکسل تبدیل می‌کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک کپی بایت‑به‑بایت از SVG اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/#getSvgData) استفاده کنید.

## **برش یک تصویر**

برش تعیین می‌کند که کدام بخش از تصویر در داخل فریم قابل مشاهده باشد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه بیتی‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک PictureFrame را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

از آنجا که داده‌های تصویر مخفی هنوز موجود هستند، می‌توانید بعداً برش را بدون از دست دادن پیکسل‌های اصلی تغییر دهید. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، نواحی برش‌خورده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) داده‌های تصویر خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عمل برش‌برداری (uncrop) در دسترس نیستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط PictureFrameهای دیگر نیز استفاده شود، آن فریم‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌خورده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجه برش‌خورده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستری**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#compressImage) وضوح تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. این می‌تواند در همان عملیات نواحی برش‌خورده را نیز حذف کند. این متد زمانی `True` بر می‌گرداند که تصویر تغییر اندازه یا برش داده شده باشد و زمانی `False` که نیازی به تغییر نبوده است.

هنگامی که یک وضوح هدف استاندارد کافی است، از مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturescompression/) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

یک مقدار DPI مثبت سفارشی می‌تواند به‌جای مقدار پیش‌تعریف‌شده پاس داده شود زمانی که هدف خاصی مورد نیاز باشد.

فشرده‌سازی برای تصاویر رستری در نظر گرفته شده است. محتواهای SVG و متافایل توسط این کار جریان فشرده‌سازی رستری کاهش نمی‌یابند. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌خورده حذف‌شده نمی‌توانند از ارائه بهینه‌شده بازیابی شوند. به جای اعمال پایین‌ترین DPI به‌صورت سراسری، یک وضوح هدف بر اساس بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا صادر خواهد شد انتخاب کنید.

## **مدیریت اثرات تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ، تاری، اثرات آلفا، زنجیره‌های مرتب‌شده، بازرسی، حذف و تأیید دور‌دور، به [Image Transform Effects](/slides/fa/python-java/image-transform-effects/) مراجعه کنید.

## **قفل‌گذاری هندسه PictureFrame**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframelock/) تعیین می‌کنند که کدام عملیات‌های ویرایشی برای یک PictureFrame غیرفعال هستند. به عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قفل بر شکل PictureFrame اعمال می‌شود. این به این معنا نیست که تصویر منبع بازنمونه‌برداری یا به‌طور دائمی به همان نسبت ابعاد تبدیل شود.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر به حالت stretch است، مقادیر stretch‑offset بر روی [PictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/) مستطیل پر کردن را نسبت به جعبه محدد PictureFrame تعریف می‌کنند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه بیرونی ایجاد می‌نمایند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده است؛ در حالی که stretch‑offsetها مستطیلی را که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود تغییر می‌دهند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

از stretch‑offsetها برای موقعیت‌گذاری پر کردن استفاده کنید. از ویژگی‌های برش زمانی استفاده کنید که هدف مخفی کردن لبه‌های تصویر منبع باشد.

## **نگهداری، حجم فایل و ملاحظات خروجی**

معامله‌های اصلی زمانی آسان‌تر می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی PictureFrame جداگانه مدیریت شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌ها وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده به‌صورت صریح حذف یا در طول فشرده‌سازی حذف نشوند، جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری بزرگ به‌طور قابل‌توجهی کاهش دهد، اما وضوح منبع را از دست می‌دهد. این کار باید پس از تعیین اندازه نهایی تصویر روی اسلاید اعمال شود.
- **تصاویر SVG** باید زمانی که حفظ وکتور مهم است به صورت SVG باقی بمانند. وقتی به منبع برداری واقعی نیاز دارید، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) موجود استفاده کنند به جای بارگذاری مکرر همان فایل در گردش کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‑صورت انتخابی انجام شود: لوگوها و نمودارها را به‌صورت محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازه نمایش واقعی فشرده کنید، پیکسل‌های برش‌خورده را فقط وقتی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی صرفاً وقتی که مدیریت وابستگی بخشی از طرح استقرار باشد، اجتناب کنید.

## **سوالات متداول**

**تفاوت بین PictureFrame و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم مانند اندازه، چرخش, مقادیر برش, افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی کنم یا پیوند دهم؟**

تصاویر را زمانی که ارائه باید قابل حمل، بایگانی یا رندر بدون دسترسی به منابع خارجی باشد، جاسازی کنید. تصاویر را فقط زمانی پیوند دهید که نگهداری فایل‌های تصویری خارج از PPTX هدفمند باشد و مسیرهای خارجی به‌طور قابل اعتماد حفظ شوند.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را انجام نمی‌دهد. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را حفظ می‌کند. برای کاهش حجم از [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) یا فشرده‌سازی تصویر همراه با حذف نواحی برش استفاده کنید وقتی می‌توانید این پیکسل‌ها را برای همیشه حذف کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستری ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌ها را از بین می‌برد. اگر بعداً به ویرایش با وضوح بالا نیاز باشد، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

وقتی اهمیت وفاداری بردار وجود دارد، محتوای SVG را به‌صورت SVG نگه دارید. [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) جاسازی‌شده می‌تواند به‌صورت مستقیم استخراج شود. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از castهای ناایمن هنگام خواندن اسلایدهای موجود اجتناب کرد؟**

قبل از استفاده از اعضای خاص PictureFrame، نوع شکل را بررسی کنید. یک بررسی `isinstance` نسبت به [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) از castهای نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که شامل PictureFrame نیستند را به‌درستی مدیریت کند.