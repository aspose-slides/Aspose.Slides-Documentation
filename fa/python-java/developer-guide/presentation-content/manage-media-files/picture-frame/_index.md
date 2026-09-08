---
title: مدیریت فریم‌های تصویر در ارائه‌ها با استفاده از پایتون
linktitle: فریم تصویر
type: docs
weight: 10
url: /fa/python-java/picture-frame/
keywords:
- فریم تصویر
- اضافه کردن فریم تصویر
- ایجاد فریم تصویر
- تصویر جاسازی‌شده
- تصویر لینک‌شده
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی فریم تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد، قالب‌بندی، لینک، برش، استخراج و فشرده‌سازی فریم‌های تصویری در ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا."
---
## **بررسی کلی**

یک Picture Frame یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نشان می‌دهد به صورت اشیاء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) تصویرهای جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/) خود مدیریت می‌کند، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیٔ [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) بازگردانده‌شده را نگه دارید و هنگام ایجاد Picture Frame از همان منبع تصویر استفاده کنید.

Picture Frame می‌تواند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را شامل شود. همچنین می‌تواند به تصاویر لینک‌شده اشاره کند به جای این‌که بایت‌های تصویر را در ارائه ذخیره کند. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین مفید است که پیش از اعمال قالب‌بندی یا بهینه‌سازی تصمیم بگیرید تصویر چگونه ذخیره شود.

## **اضافه کردن و قالب‌بندی تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک Picture Frame با استفاده از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) ایجاد کنید. تصویر بخشی از بسته‌ی ارائه می‌شود، بنابراین زمانی که ارائه به کامپیوتر دیگری منتقل شود، خودبسته باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، یک فریم با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌نماید:

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

Picture Frame هندسه‌ی نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز هنگام برش یا فشرده‌سازی تصویر در آینده مهم می‌شود.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی فریم را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) در دسترس قرار می‌دهد. مقدار `1.0` معادل 100٪ اندازه‌ی تصویر اصلی است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز داشته باشد نسبت به اندازه‌ی تصویر منبع حفظ شود به جای محاسبهٔ ابعاد نهایی به صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ تصویر جاسازی‌شده را بازنمونه‌گیری یا فشرده‌سازی نمی‌کند.

## **تصاویر جاسازی‌شده و لینک‌شده**

یک Picture جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین امن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شدنی است. یک Picture لینک‌شده موقعیت خارجی را از طریق متد [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#setLinkPathLong) ذخیره می‌کند به جای اینکه داده‌های تصویر را به همان روش درون‌پوشه کند.

تصاویر لینک‌شده می‌توانند حجم داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر لینک‌شده ممکن است همان‌گونه که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اعتمادتر هستند.

### **اضافه کردن تصویر لینک‌شده**

مثال زیر یک Picture Frame ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال تنها به لینک کردن تصویر می‌پردازد؛ لینک کردن ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل خارجی عمدی باشد. آن‌ها را صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ بزرگ‌تر خود‑کامل.

## **استخراج تصاویر از Picture Frameها**

قبل از استخراج یک تصویر از یک ارائه موجود، اطمینان حاصل کنید که شکل واقعی یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) است و حاوی تصویر جاسازی‌شده می‌باشد. Picture Frameهای لینک‌شده ممکن است بایت‌های تصویری که بتوان آن‌ها را به همان روش استخراج کرد نداشته باشند.

### **استخراج تصویر رستر**

API جدید تصویر مستقیماً با تصاویر رستر کار می‌کند و نیازی به wrapper قدیمی Java ندارد. مثال زیر اولین تصویر رستر جاسازی‌شده در یک اسلاید را پیدا می‌کند و به صورت PNG ذخیره می‌نماید:

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

ذخیره تصویر رستر، تصویر استخراج‌شده را به قالب خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند به‌جای یک فایل رستر تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، شیٔ [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) یک شیٔ [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) را در اختیار می‌گذارد. این امکان را می‌دهد که داده‌های SVG را مستقیماً بازیابی کنید به‌جای اینکه ابتدا تصویر را رستر کنید.

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

نگه‌داشتن محتوای SVG به صورت SVG، منبع برداری را داخل ارائه حفظ می‌کند. صادرات رستر مانند PNG یا JPEG مجبورند آن محتوای برداری را به پیکسل تبدیل کنند. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان رونوشت بیتی‑به‑بیتی از SVG اصلی در نظر گرفته شوند؛ برای استفاده از منبع برداری اصلی، دادهٔ [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/#getSvgData) جاسازی‌شده را به کار ببرید.

## **برش تصویر**

برش تعیین می‌کند که کدام بخش از تصویر داخل فریم قابل مشاهده باشد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/) به صورت درصدی از ابعاد تصویر منبع بیان می‌شوند. برش در ابتدا پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر به‌صورت ایمن یک Picture Frame را پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

چون دادهٔ تصویر مخفی هنوز موجود است، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان نواحی برش‌خورده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

متد [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این کار می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات باز‑برش در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط فریم‌های دیگری نیز استفاده شود، آن فریم‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌خورده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد، نتیجهٔ برش‌خورده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

متد [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#compressImage) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی تصویر تغییر اندازه یا برش داده شد `True` و وقتی تغییری لازم نبود `False` برمی‌گرداند.

هنگام نیاز به وضوح هدف استاندارد، می‌توانید از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturescompression/) استفاده کنید:

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

در صورت نیاز به هدف خاص، می‌توان مقدار DPI مثبت سفارشی را به جای مقدار پیش‌تعریف‌شده پاس داد.

فشرده‌سازی مخصوص تصاویر رستر است. محتوای SVG و متا‑فایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به‌یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌خوردهٔ حذف‌شده را نمی‌توان از ارائه بهینه‌شده بازیافت کرد. وضوح هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً دیده یا صادر می‌شود انتخاب کنید، نه بر پایهٔ کمترین DPI به‌صورت سراسری.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک جریان کاری کامل شامل روشنایی، کنتراست، تبدیلات رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتب، بازرسی، حذف و تأیید دو‑طرفه، به بخش [Image Transform Effects](/slides/fa/python-java/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسهٔ Picture Frame**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframelock/) تعیین می‌کنند کدام عملیات ویرایشی برای یک Picture Frame غیرفعال باشد. برای مثال، متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل Picture Frame اعمال می‌شود. این امر تصویر منبع را مجبور به بازنمونه‌گیری یا تغییر دائمی به همان نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر به صورت Stretch باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/) مستطیل پر کردن را نسبت به جعبهٔ مرزبندی Picture Frame تعریف می‌کنند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی می‌سازند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش از تصویر منبع قابل مشاهده باشد؛ در حالی که stretch‑offset مستطیلی را تغییر می‌دهد که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود.

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

از stretch‑offset برای جایگاه‌دهی پر کردن استفاده کنید. از ویژگی‌های برش وقتی هدف مخفی کردن لبه‌های تصویر منبع است استفاده کنید.

## **نگهداری، حجم فایل و ملاحظات صادرات**

معامله‌های اصلی زمانی ساده‌تر مدیریت می‌شوند که ذخیرهٔ تصویر و قالب‌بندی فریم تصویر جداگانه بررسی شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر در سمت سرور قابل اعتمادترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌شده** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی برش‌خورده صریحاً حذف یا در زمان فشرده‌سازی حذف نشوند، جاسازی‌شده می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را به‌طور قابل‌توجهی برای تصاویر رستر بزرگ کاهش دهد، اما وضوح منبع را از دست می‌دهد. باید پس از دانستن اندازهٔ نهایی مورد استفاده در اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی حفظ بردار مهم است. هنگام نیاز به منبع برداری، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید رستر همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) موجود استفاده کنند به جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و دیاگرام‌ها را به‌صورت محتویات برداری نگه دارید، عکاسی‌ها را بر اساس اندازهٔ نمایش واقعی فشرده کنید، پیکسل‌های برش‌خورده را تنها زمانی حذف کنید که ویرایش بعدی لازم نباشد و از لینک‌های خارجی صرف‌نظر کنید مگر این که مدیریت وابستگی بخشی از طرح استقرار باشد.

## **سؤال‌های متداول**

**تفاوت بین Picture Frame و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) نمایانگر منبع تصویری است که با ارائه مرتبط است. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی یا لینک کنم؟**

تصاویر را زمانی جاسازی کنید که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود. فقط زمانی تصاویر را لینک کنید که حفظ فایل‌های تصویر خارج از PPTX هدفمند باشد و موقعیت‌های خارجی به‌طور قابل اعتماد نگهداری شوند.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را نمی‌کند. تنظیمات عادی برش فقط بخش‌های تصویر منبع را مخفی می‌کند ولی پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم می‌توانید از [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) یا فشرده‌سازی تصویر با حذف نواحی برش‌خورده استفاده کنید زمانی که می‌توانید این پیکسل‌ها را برای همیشه از بین ببرید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازیابی کرد؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده دادهٔ تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا بعداً ممکن است لازم باشد، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**تصاویر SVG چگونه باید مدیریت شوند؟**

هنگامی که حفظ وفاداری برداری مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید شیٔ [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به قالب رستر مثل PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از کست‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص Picture Frame، نوع شکل را بررسی کنید. یک بررسی `isinstance` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) از کست‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که فاقد Picture Frame هستند را به‌درستی مدیریت کند.