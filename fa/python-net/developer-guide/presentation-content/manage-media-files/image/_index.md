---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با Python
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/python-net/image/
keywords:
- افزودن تصویر
- افزودن عکس
- جایگزینی تصویر
- مجموعه تصویر
- فریم تصویر
- تصویر لینک‌شده
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- تبدیل SVG به شکل‌ها
- منابع SVG خارجی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه تصاویر رستر و SVG را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides for Python via .NET اضافه، دوباره استفاده، لینک، جایگزین و مدیریت کنید."
---
## **معرفی**

Aspose.Slides for Python via .NET چندین روش برای کار با تصاویر ارائه می‌دهد و هر کدام هدف متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، آن را در یک فریم تصویر نمایش دهید، به عنوان پس‌زمینه اسلاید استفاده کنید، به یک تصویر خارجی لینک دهید، منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به شکل‌های قابل ویرایش تبدیل کنید.

این مقاله بر روی منابع تصویر و نحوه استفاده از آنها در یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و سایر قالب‌بندی‌های اعمال‌شده به یک فریم تصویر منفرد، به [فریم تصویر](/slides/fa/python-net/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

- مجموعه تصویر ارائه ([presentation image collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/)) تصویرهای استفاده‌شده در ارائه را ذخیره می‌کند. برای افزودن داده‌های تصویر و دریافت یک منبع [IPPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/)، از [ImageCollection.add_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/add_image/) استفاده کنید.
- یک [picture frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipictureframe/) شکلی است که تصویر را بر روی اسلاید، چیدمان یا مستر نمایش می‌دهد. برای قرار دادن منبع تصویر بر روی اسلاید از [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) استفاده کنید.
- پس‌زمینه اسلاید از یک تصویر به عنوان بخشی از پر کردن اسلاید استفاده می‌کند نه به عنوان یک شکل. بنابراین رفتار مشابه فریم تصویر ندارد.
- متد [IPPImage.replace_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/replace_image/) یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر در ارائه از آن منبع استفاده کنند، همه از جایگزین استفاده می‌کنند.
- تبدیل SVG به شکل‌ها، شکل‌های قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

بنابراین یک جریان کاری معمولی به این صورت است: داده‌های تصویر را به مجموعه تصویر اضافه کنید، یک [IPPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/) دریافت کنید و سپس آن منبع را در یک یا چند فریم تصویر یا پر کردن استفاده کنید.

## **افزودن تصویر جاسازی‌شده**

برای درج یک تصویر محلی، فایل را بخوانید، داده‌های آن را به مجموعه تصویر اضافه کنید و یک فریم تصویر ایجاد کنید که از `IPPImage` برگشتی استفاده می‌کند.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

تصویری که به این روش اضافه می‌شود در ارائه جاسازی می‌شود، بنابراین فایل نهایی به در دسترس بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

زمانی که یک تصویر از طریق HTTP یا HTTPS در دسترس است، بایت‌های آن را دانلود کنید، به مجموعه تصویر ارائه اضافه کنید و منبع تصویر برگشتی را به همان شیوه‌ای که برای تصویر محلی استفاده می‌شود، به کار ببرید.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

در برنامه‌های طولانی‌مدت، به جای ایجاد اتصال جدید برای هر درخواست، از یک کلاینت HTTP یا استخر اتصال به‌صورت مناسب استفاده کنید. همچنین هنگام عدم اطمینان به منبع، URLهای remote، اندازه پاسخ‌ها و نوع محتوا را اعتبارسنجی کنید.

## **استفاده مجدد از تصاویر در اسلایدها**

اگر همان تصویر بیش از یک بار نیاز باشد، یک‌بار آن را به ارائه اضافه کنید و هنگام ایجاد فریم‌های تصویر اضافی، [IPPImage] برگشتی را مجدداً استفاده کنید. این کار از بارگذاری مکرر داده‌های منبع جلوگیری می‌کند و رابطه بین منبع تصویر مشترک و استفاده‌های آن را به‌وضوح نشان می‌دهد.

برای گرافیک‌هایی که باید به‌صورت خودکار در اسلایدهای متعدد ظاهر شوند، مانند لوگوی شرکت، بهتر است فریم تصویر را روی یک [slide master](/slides/fa/python-net/slide-master/) یا چیدمان قرار دهید به جای افزودن یک شکل معادل به هر اسلاید.

## **استفاده از تصویر به‌عنوان پس‌زمینه اسلاید**

یک تصویر پس‌زمینه به پر کردن اسلاید اختصاص می‌دهد؛ آن به‌عنوان شکل فریم تصویر اضافه نمی‌شود. این مورد زمانی مفید است که تصویر باید تمام پس‌زمینه اسلاید را پوشش دهد و نباید مانند یک شیء معمولی اسلاید دستکاری شود.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

برای گزینه‌های پس‌زمینه اضافی، از جمله پس‌زمینه‌های مستر و چیدمان، به [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید.

## **تصاویر جاسازی‌شده و لینک‌شده**

تصاویر جاسازی‌شده و لینک‌شده تعادل‌های متفاوتی در خصوص قابل حمل بودن و حجم فایل دارند:
- **تصویر جاسازی‌شده:** داده‌های تصویر داخل ارائه ذخیره می‌شوند. ارائه خودکفا است، اما حجم فایل شامل داده‌های تصویر نیز می‌شود.
- **تصویر لینک‌شده:** ارائه مسیر یا URL یک تصویر خارجی را ذخیره می‌کند. این می‌تواند حجم ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه در دسترس باشد.

یک تصویر لینک‌شده می‌تواند با اختصاص مسیر یا URL خارجی از طریق [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/fa/python-net/aspose.slides/islidespicture/link_path_long/) به‌جای جاسازی داده‌های تصویر ایجاد شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

از تصاویر لینک‌شده فقط زمانی استفاده کنید که محیط استقرار بتواند به‌طور قابل اعتماد به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید به‌صورت آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر جاسازی‌شده معمولاً ایمن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکون‌ها، نمودارها و گرافیک‌های دیگری که باید بدون از دست دادن جزئیات به‌صورت مقیاس‌پذیر باشند، مفید است. Aspose.Slides از SVG هم به‌عنوان منبع تصویر و هم به‌عنوان منبعی برای شکل‌های قابل ویرایش اسلاید پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) ایجاد کنید، آن را به مجموعه تصویر اضافه کنید و منبع تصویر حاصل را در یک فریم تصویر قرار دهید.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **تبدیل SVG به شکل‌های قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از شکل‌های قابل ویرایش اسلاید تبدیل کند، مشابه فرمان مربوط در PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

از اورلود [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_group_shape/) که یک [ISvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/isvgimage/) را می‌پذیرد، برای انجام تبدیل استفاده کنید.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

زمانی که عناصر برداری فردی نیاز به ویرایش به‌عنوان شکل‌های PowerPoint دارند، از تبدیل SVG به شکل‌ها استفاده کنید. اگر SVG فقط برای نمایش نیاز است، نگه داشتن آن به‌عنوان تصویر ساده‌تر است و از ایجاد شکل‌های جداگانه متعدد جلوگیری می‌کند.

## **جایگزینی منبع تصویر موجود**

هنگامی که می‌خواهید یک منبع تصویر موجود را جایگزین کنید، از [IPPImage.replace_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/replace_image/) استفاده کنید. این کار به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

اگر چندین فریم تصویر، پس‌زمینه، مستر یا چیدمان از همان منبع تصویر استفاده کنند، جایگزینی آن منبع تمام آن‌ها را به‌روز می‌کند. اگر فقط یک فریم تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، تصویر متفاوتی به آن فریم اختصاص دهید.

`replace_image` همچنین اورلودهایی دارد که یک [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) یا یک [IPPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/) دیگر را می‌پذیرند.

## **راهنمای عملی مدیریت تصویر**

### **کنترل حجم ارائه**

تصاویر رستری بزرگ می‌توانند حجم ارائه را بی‌دلیل افزایش دهند. از تصاویر منبعی با ابعاد متناسب با اندازه نمایش موردنظر استفاده کنید، در صورت امکان منابع تصویر مشترک را مجدداً به‌کار ببرید و از جاسازی کپی‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که پیش‌تر در فریم‌های تصویر قرار داده شده‌اند، می‌توانید با استفاده از [PictureFillFormat.compress_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/compress_image/) داده‌های تصویر را بر اساس وضوح و تنظیمات برش انتخابی کاهش دهید. این پردازش مربوط به فریم تصویر است و نه مدیریت مجموعه تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [Picture Frame](/slides/fa/python-net/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای جاسازی‌شده و لینک‌شده**

جاسازی ارائه را قابل حمل می‌کند زیرا تمام داده‌های تصویر موردنیاز همراه فایل هستند. لینک کردن می‌تواند حجم فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. از لینک‌ها تنها زمانی استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **استفاده مجدد از برند مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، از یک منبع تصویر استفاده کنید و آن را مجدداً به‌کار ببرید. اگر گرافیک متعلق به طراحی ارائه باشد نه محتوای اسلاید، آن را بر روی مستر یا چیدمان قرار دهید تا توسط اسلایدهای مربوط به‌ارث‌بری شود.

### **حفظ قابلیت حمل منابع SVG**

یک SVG مستقل به‌راحتی قابل جابجایی و رندر شدن به‌صورت یکسان نسبت به SVGی که به فایل‌ها یا منابع شبکه‌ای خارجی وابسته است، می‌باشد. در صورت امکان، منابع لازم را پیش از وارد کردن SVG جاسازی کنید. تبدیل SVG به شکل‌ها تنها زمانی انجام شود که عناصر برداری فردی نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر مدرن چند‌پلتفرمی**

برای کدهای جدید Python via .NET، از APIهای Aspose.Slides [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/images/) به‌جای APIهای منسوخ‌شده `aspose.pydrawing.Image` یا `aspose.pydrawing.Bitmap` استفاده کنید. برای راهنمایی مهاجرت به [Modern API](/slides/fa/python-net/modern-api/) مراجعه کنید.

فرمت‌های WMF و EMF نیاز به ملاحظات خاصی دارند. وقتی این فرمت‌ها از طریق یک [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) عبور می‌کنند، [ImageCollection.add_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/add_image/) قبل از درج، متافایل را به یک نمایه PNG رستری تبدیل می‌کند. اگر حفظ داده‌های متافایل مهم است، به‌جای آن از اورلود مبتنی بر جریان [ImageCollection.add_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/add_image/) استفاده کنید. تولید محتوای EMF از صفحات گسترده یا محصولات دیگر یک جریان ادغام جداگانه است و خارج از حوزه این مقاله می‌باشد.

## **سوالات متداول**

**فرق بین مجموعه تصویر و فریم تصویر چیست؟**

مجموعه تصویر منابع تصویری قابل استفاده مجدد را ذخیره می‌کند. فریم تصویر یک شکل اسلاید است که یکی از این منابع را نمایش می‌دهد و قالب‌بندی خاصی مانند برش و افکت‌ها را ارائه می‌دهد.

**بهترین راه برای جایگزینی لوگوی یکسان در همه جا چیست؟**

اگر لوگو به‌عنوان یک منبع تصویر مشترک موجود است، آن منبع را با استفاده از [IPPImage.replace_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ippimage/replace_image/) جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو بر روی یک مستر یا چیدمان نیز می‌تواند محتوای تکراری اسلایدها را کاهش دهد.

**چرا یک تصویر لینک‌شده در کامپیوتر دیگر ناپدید می‌شود؟**

یک تصویر لینک‌شده به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر لینک‌شده ممکن است در دسترس نباشد. زمانی که ارائه باید خودکفا باشد، تصویر را جاسازی کنید.

**آیا می‌توان SVG درج‌شده را به‌عنوان شکل‌های PowerPoint ویرایش کرد؟**

بله. SVG را با استفاده از [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_group_shape/) تبدیل کنید؛ گروه حاصل شامل شکل‌های قابل ویرایش اسلاید است نه یک تصویر SVG.

**چگونه می‌توانم ارائه‌هایی با تعداد زیاد تصویر را کوچک نگه دارم؟**

از منابع تصویر مشترک استفاده کنید، از منابع رستری بزرگ بی‌دلیل خودداری کنید، در صورت لزوم تصاویر رستری مناسب را فشرده کنید، برندینگ تکراری را بر روی مسترها یا چیدمان‌ها نگه دارید و فقط وقتی وابستگی خارجی قابل قبول باشد، از تصاویر لینک‌شده استفاده کنید.