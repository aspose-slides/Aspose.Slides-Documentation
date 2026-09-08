---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از Python
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/python-java/image/
keywords:
- افزودن تصویر
- افزودن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر لینک‌شده
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- SVG به اشکال
- منابع SVG خارجی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه تصاویر رستری و SVG را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java اضافه، بازاستفاده، لینک‌گذاری، جایگزینی و مدیریت کنید."
---
## **معرفی**

Aspose.Slides برای Python از طریق Java راه‌های متعددی برای کار با تصاویر ارائه می‌دهد و هر یک کاربرد متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، آن را در یک چارچوب تصویر نمایش دهید، به عنوان پس‌زمینهٔ اسلاید استفاده کنید، به تصویر خارجی لینک بدهید، منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر منابع تصویر و نحوهٔ استفاده از آن‌ها در یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و سایر قالب‌بندی‌هایی که بر یک چارچوب تصویر فردی اعمال می‌شود، به [قاب تصویر](/slides/fa/python-java/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر به‌طور نزدیک مرتبط هستند اما قابل تعویض نیستند:

- مجموعه تصویر ارائه ([presentation image collection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/)) تصاویر استفاده‌شده در ارائه را ذخیره می‌کند. برای افزودن داده‌های تصویر و دریافت منبع [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) از [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) استفاده کنید.
- یک [قاب تصویر](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) شکل (shape)‌ای است که تصویری را بر روی اسلاید، طرح‌بندی یا مستر نمایش می‌دهد. برای قرار دادن منبع تصویر در یک اسلاید از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) استفاده کنید.
- پس‌زمینهٔ اسلاید از یک تصویر به‌عنوان بخشی از پرکردن اسلاید استفاده می‌کند نه به‌عنوان یک شکل. بنابراین رفتار مشابه قاب تصویر ندارد.
- [PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) منبع یک تصویر را جایگزین می‌کند. اگر چند عنصر ارائه از آن منبع استفاده کنند، همهٔ آنها از جایگزین استفاده می‌کنند.
- تبدیل SVG به اشکال، اشکال قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

به‌این‌ترتیب یک جریان کاری معمولی عبارت است از: افزودن داده‌های تصویر به مجموعه تصویر، دریافت یک [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/)، و سپس استفاده از آن منبع در یک یا چند قاب تصویر یا پرکردن.

## **افزودن تصویر توکار**

برای درج یک تصویر محلی، فایل را بارگذاری کنید، آن را به مجموعه تصویر اضافه کنید و چارچوب تصویری ایجاد کنید که از [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) بازگردانده‌شده استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصویری که به این شکل اضافه می‌شود درون ارائه توکار است، بنابراین فایل خروجی به موجود بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

زمانی که یک تصویر از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را دانلود کنید، به مجموعه تصویر ارائه اضافه کنید و از منبع تصویر بازگردانده‌شده به همان شیوهٔ تصویر محلی استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در برنامه‌های طولانی‌مدت، به‌جای ایجاد مکرر زیرساخت‌های شبکه‌ای غیرضروری، از یک کلاینت HTTP یا استراتژی مدیریت اتصال مناسب برای برنامه استفاده کنید. همچنین هنگامیکه منبع قابل اعتماد نیست، URLهای خارجی، اندازهٔ پاسخ‌ها و انواع محتوا را اعتبارسنجی کنید.

## **بازاستفاده از تصاویر در اسلایدها**

اگر یک تصویر چندین بار مورد نیاز باشد، یکبار آن را به ارائه اضافه کنید و هنگام ایجاد چارچوب‌های تصویر اضافی از [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) بازگردانده‌شده استفاده کنید. این کار از بارگذاری مکرر داده‌های منبع جلوگیری می‌کند و رابطهٔ بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌کند.

برای گرافیک‌هایی که باید به‌صورت خودکار در بسیاری از اسلایدها ظاهر شوند، مانند لوگوی شرکت، در نظر بگیرید که چارچوب تصویر را بر روی یک [مستر اسلاید](/slides/fa/python-java/slide-master/) یا طرح‌بندی قرار دهید به‌جای افزودن یک شکل معادل به هر اسلاید.

## **استفاده از تصویر به‌عنوان پس‌زمینهٔ اسلاید**

تصویر پس‌زمینه به پرکردن اسلاید اختصاص می‌یابد؛ به‌عنوان شکل چارچوب تصویر اضافه نمی‌شود. این زمانی مفید است که تصویر باید کل پس‌زمینهٔ اسلاید را پوشش دهد و نباید مانند یک شیء اسلاید معمولی دستکاری شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای گزینه‌های بیشتر پس‌زمینه، شامل پس‌زمینه‌های مستر و طرح‌بندی، به [پس‌زمینهٔ ارائه](/slides/fa/python-java/presentation-background/) مراجعه کنید.

## **تصاویر توکار و تصاویر لینک‌شده**

تصاویر توکار و لینک‌شده تعادل‌های متفاوتی در زمینهٔ قابلیت حمل و اندازهٔ فایل دارند:

- **تصویر توکار:** داده‌های تصویر درون ارائه ذخیره می‌شوند. ارائه خودکفا است، اما اندازهٔ فایل شامل داده‌های تصویر می‌شود.
- **تصویر لینک‌شده:** ارائه مسیری یا URL به تصویر خارجی را ذخیره می‌کند. این می‌تواند اندازهٔ ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه قابل دسترسی باقی بماند.

یک تصویر لینک‌شده می‌تواند با اختصاص مسیر یا URL خارجی از طریق [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#setLinkPathLong) به‌جای توکار کردن داده‌های تصویر ایجاد شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

از تصاویر لینک‌شده فقط زمانی استفاده کنید که محیط استقرار بتواند به‌صورت قابل اعتماد به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید به‌صورت آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر توکار معمولاً ایمن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکون‌ها، نمودارها و گرافیک‌های دیگری که باید بدون افت جزئیات همانند تصاویر رستری مقیاس‌پذیر باشند، مفید است. Aspose.Slides هر دو به‌عنوان منبع تصویر و به‌عنوان منبعی برای اشکال قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) ایجاد کنید، آن را به مجموعه تصویر اضافه کنید و منبع تصویر حاصل را در یک چارچوب تصویر قرار دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصاویر، سبک‌نامه‌ها یا قلم‌های خارجی اشاره کند. برای این موارد، [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) سازنده‌هایی ارائه می‌دهد که یک [ExternalResourceResolver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/externalresourceresolver/) و یک URI پایه را می‌پذیرند. این رزولور می‌تواند URI نسبی را به URI مطلق مجاز تبدیل کند و یک جریان برای منبع درخواست‌شده برگرداند.

رزولور منابع خارجی را هنگام پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به سند خودکفا بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را در خود SVG توکار کنید، مثلا با استفاده از URIهای `data:` برای تصاویر لینک‌شده.

وقتی فایل‌های SVG از منابع غیرقابل اعتماد می‌آیند، طرح‌ها، مکان‌های فایل و میزبان‌هایی را که رزولور می‌تواند به آن‌ها دسترسی داشته باشد محدود کنید. رزولورهای شبکه همچنین باید محدودیت‌های زمان انتظار، اندازهٔ پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به اشکال قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کند، مشابه فرمان مربوطه در PowerPoint.

![منوی بازشو PowerPoint](img_01_01.png)

از overload [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addGroupShape) که یک [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) می‌پذیرد برای انجام تبدیل استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

از تبدیل SVG به اشکال استفاده کنید وقتی که عناصر برداری جداگانه نیاز به ویرایش به‌عنوان اشکال PowerPoint دارند. اگر SVG فقط نیاز به نمایش داشته باشد، نگه‌دارندهٔ آن به‌عنوان تصویر ساده‌تر است و از ایجاد اشکال جداگانهٔ متعدد جلوگیری می‌کند.

## **جایگزینی منبع تصویر موجود**

زمانی که می‌خواهید منبع تصویر موجود را جایگزین کنید، از [PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) استفاده کنید. این به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر چندین چارچوب تصویر، پس‌زمینه، مستر یا طرح‌بندی از یک منبع تصویر استفاده کنند، جایگزینی آن منبع تمام موارد استفاده را به‌روز می‌کند. اگر فقط یک چارچوب تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، تصویر متفاوتی به آن چارچوب اختصاص دهید.

[PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) همچنین overloadهایی ارائه می‌دهد که یک آرایه بایت یا یک [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) دیگر را می‌پذیرند.

## **راهنمایی‌های عملی مدیریت تصویر**

### **کنترل اندازهٔ ارائه**

تصاویر رستری بزرگ می‌توانند اندازهٔ ارائه را بی‌دلیل زیاد کنند. از تصاویر منبع با ابعاد مناسب برای اندازهٔ نمایش موردنظر استفاده کنید، در صورت امکان منابع تصویر مشترک را بازاستفاده کنید و از توکار کردن نسخه‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که پیش از این در چارچوب‌های تصویر قرار گرفته‌اند، [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#compressImage) می‌تواند داده‌های تصویر را بر اساس وضوح انتخابی و تنظیمات برش کاهش دهد. این پردازش چارچوب تصویر است نه مدیریت مجموعه تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [قاب تصویر](/slides/fa/python-java/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای توکار و لینک‌شده**

توکار کردن ارائه را قابل حمل می‌کند زیرا تمام داده‌های تصویری مورد نیاز با فایل همراه هستند. لینک کردن می‌تواند اندازهٔ فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. از لینک‌ها فقط زمانی استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **بازاستفاده از برند مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی مکرر، از یک منبع تصویر استفاده کنید و آن را بازاستفاده کنید. اگر گرافیک متعلق به طراحی ارائه باشد نه محتوای اسلاید، آن را بر روی یک مستر یا طرح‌بندی قرار دهید تا توسط اسلایدهای مربوطه به ارث برسد.

### **حفظ قابلیت حمل منابع SVG**

یک SVG خودکفا جابجایی و رندر کردن ثابت‌تری نسبت به SVGی که به فایل‌ها یا منابع شبکه‌ای خارجی وابسته است دارد. در صورت امکان، منابع مورد نیاز را پیش از وارد کردن SVG توکار کنید. تبدیل SVG به اشکال فقط زمانی انجام شود که عناصر برداری جداگانه نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر مدرن چندپلتفرمی**

برای کدهای جدید Python از طریق Java، از اشیاء تصویر چندپلتفرمی Aspose.Slides و APIهای [Images](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/) به‌جای API عمومی قدیمی مبتنی بر `java.awt.image.BufferedImage` استفاده کنید. برای راهنمایی مهاجرت به [API مدرن](/slides/fa/python-java/modern-api/) مراجعه کنید.

قالب‌های WMF و EMF نیاز به توجه خاص دارند. وقتی این قالب‌ها از طریق یک شیء تصویر چندپلتفرمی عبور می‌کنند، [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) متافایل را قبل از درج به یک نمایش PNG رستری تبدیل می‌کند. اگر حفظ داده‌های متافایل مهم باشد، به‌جای آن از overload مبتنی بر جریان [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) استفاده کنید. تولید محتوای EMF از صفحه‌گسترده‌ها یا محصولات دیگر یک گردش کار ادغامی جداگانه است و خارج از محدودهٔ این مقاله می‌باشد.

## **پرسش‌های متداول**

**فرق بین مجموعه تصویر و قاب تصویر چیست؟**

مجموعه تصویر منابع تصویری قابل بازاستفاده را ذخیره می‌کند. یک قاب تصویر شکل اسلایدی است که یکی از آن منابع را نمایش می‌دهد و قالب‌بندی‌های مختص تصویر مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین روش برای جایگزینی لوگوی یکسان در همه‌جا چیست؟**

اگر لوگو قبلاً به‌عنوان یک منبع تصویر مشترک است، آن منبع را با [PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو بر روی یک مستر یا طرح‌بندی نیز می‌تواند محتوای اسلایدهای تکراری را کاهش دهد.

**چرا یک تصویر لینک‌شده در کامپیوتر دیگر ناپدید می‌شود؟**

یک تصویر لینک‌شده به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر لینک‌شده ممکن است در دسترس نباشد. هنگامی که ارائه باید خودکفا باشد، تصویر را توکار کنید.

**آیا می‌توان یک SVG درج‌شده را به‌عنوان اشکال PowerPoint ویرایش کرد؟**

بله. SVG را با [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addGroupShape) تبدیل کنید؛ گروه حاصل شامل اشکال قابل ویرایش اسلاید است نه یک تصویر SVG.

**چگونه می‌توانم ارائه‌هایی با تعداد زیاد تصویر را کوچکتر نگه دارم؟**

منابع تصویر مشترک را بازاستفاده کنید، از منابع رستری بزرگ غیرضروری خودداری کنید، در صورت لزوم تصاویر رستری مناسب را فشرده کنید، برندینگ مکرر را بر روی مسترها یا طرح‌بندی‌ها نگه دارید و فقط زمانی از تصاویر لینک‌شده استفاده کنید که وابستگی خارجی قابل قبول باشد.