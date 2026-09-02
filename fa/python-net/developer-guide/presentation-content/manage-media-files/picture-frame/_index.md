---
title: مدیریت قاب‌های تصویر در ارائه‌ها با پایتون
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/python-net/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- تصویر جاسازی‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌شده
- فشرده‌سازی تصویر
- StretchOffset
- فرمت‌بندی قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، فرمت‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید با Aspose.Slides برای پایتون در .NET."
---
## **بررسی کلی**

یک قاب تصویر (Picture Frame) یک شکل اسلایدی است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد دو شیء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) خود در اختیار دارد، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) موقعیت، اندازه، فرمت خط، چرخش، برش، افکت‌های تصویر و دیگر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یکبار نمایش داده شود. تصویر را یکبار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) بازگشتی را نگه دارید و هنگام ایجاد قاب‌های تصویر از همان منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستری مانند PNG یا JPEG و همچنین تصاویر برداری SVG باشند. آن‌ها می‌توانند به تصاویر پیوندی (linked) اشاره کنند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین پیش از اعمال فرمت‌بندی یا بهینه‌سازی، تعیین نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و فرمت‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و با [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) یک قاب تصویر ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگر، خودکفا می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر می‌سازد و فرمت خط و چرخش را اعمال می‌نماید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

قاب تصویر هندسه نمایش‌یافته را کنترل می‌کند؛ تغییر اندازه قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تفکیک هنگام برش یا فشرده‌سازی تصویر در آینده مهم می‌شود.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) مقادیر [relative_scale_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/relative_scale_width/) و [relative_scale_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/relative_scale_height/) را برای قاب ارائه می‌دهد. مقدار `1.0` معادل 100٪ اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک گردش کار نیاز به حفظ نسبت به اندازه تصویر منبع داشته باشد به جای محاسبه ابعاد نهایی به صورت دستی.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ بایت‌های تصویر جاسازی‌شده را بازنمونه‌برداری یا فشرده‌سازی نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شدنی است. یک تصویر پیوندی مسیر خارجی را از طریق لینک [Picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/) ذخیره می‌کند، نه داده‌های تصویر را درون همان فایل.

تصاویر پیوندی می‌توانند حجم داده تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، قابل دسترسی بماند. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نشان داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌ترند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک گردش کار رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

از پیوندها زمانی استفاده کنید که مدیریت فایل خارجی عمدی باشد. فقط به عنوان جایگزینی برای فشرده‌سازی از آن‌ها استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید از یک ارائه خودکفا بزرگتر است.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، اطمینان حاصل کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) است و شامل یک تصویر جاسازی‌شده می‌شود. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که می‌توان به همان شکل استخراج کرد، نداشته باشند.

### **استخراج یک تصویر رستری**

API تصویر مدرن مستقیماً از [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) استفاده می‌کند. مثال زیر اولین تصویر رستری جاسازی‌شده در یک اسلاید را پیدا می‌کند و به صورت PNG ذخیره می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

ذخیره‌سازی از طریق [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) تصویر استخراج‌شده را به فرمت خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند به جای فایل رستری تبدیل‌شده نیاز دارید، به جای آن از ویژگی [PPImage.binary_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/binary_data/) استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) را در اختیار می‌گذارد. این امکان را می‌دهد که داده‌های SVG را مستقیماً دریافت کنید به جای اینکه ابتدا تصویر را rasterize کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

نگه‌داشتن محتوای SVG به صورت SVG منبع برداری را داخل ارائه حفظ می‌کند. صادرات به فرمت‌های رستری مانند PNG یا JPEG لزوماً محتوای برداری را به پیکسل تبدیل می‌کند. صادرات اسلاید به PDF یا SVG نیز عملیاتی رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان یک کپی بایت‑به‑بایت از SVG جاسازی‌شده اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از [SvgImage.svg_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/svg_data/) جاسازی‌شده استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند که کدام بخش از تصویر در داخل قاب قابل رؤیت باشد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) به صورت درصدی از ابعاد تصویر منبع هستند. برش اولیه بایت‌های پنهان تصویر جاسازی‌شده را حذف نمی‌کند؛ فقط ناحیه قابل رؤیت را تغییر می‌دهد.

مثال زیر یک قاب تصویر را با اطمینان پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

چون داده‌های تصویر پنهان هنوز موجود هستند، برش می‌تواند بعدها بدون از دست رفتن پیکسل‌های اصلی تغییر کند. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، می‌توان نواحی برش شده را به صورت فیزیکی همان‌طور که در بخش بعدی توضیح داده شده حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) داده‌های تصویری خارج از مستطیل برش فعلی را حذف و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «حذف برش» در دسترس نیستند.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویری دیگر نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این متد نتیجه را به PNG rasterize می‌کند.

## **فشرده‌سازی تصاویر رستری**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/compress_image/) وضوح تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌شده را در همان عملیات حذف کند. متد زمانی که تصویر تغییر اندازه یا برش داده شده باشد `True` و زمانی که نیازی به تغییر نبوده است `False` برمی‌گرداند.

زمانی که یک وضوح هدف استاندارد کافی است، می‌توان از مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/picturescompression/) استفاده کرد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

یک مقدار DPI مثبت سفارشی می‌تواند به جای مقدار enum در صورت نیاز به هدف خاص پاس داده شود.

فشرده‌سازی برای تصاویر رستری هدف‌گذاری شده است. محتوای SVG و متافایل توسط این کارکرد فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌شده حذف شده را نمی‌توان از ارائه بهینه‌شده بازیابی کرد. هدف وضوح را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا صادر می‌شود تعیین کنید، نه بر پایه پایین‌ترین DPI به‌صورت سراسری.

## **مدیریت اثرات تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ، تاری، اثرات آلفا، زنجیره‌های مرتب، بازرسی، حذف و تأیید دور‌دور، به [Image Transform Effects](/slides/fa/python-net/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسه قاب تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/) تعیین می‌کند که کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال شوند. به عنوان مثال، ویژگی [aspect_ratio_locked](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) نسبت‌های شکل را هنگام تغییر اندازه حفظ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

قفل به شکل قاب تصویر اعمال می‌شود. این باعث نمی‌شود که تصویر منبع بازنمونه‌برداری یا به‌صورت دائمی به همان نسبت ابعاد تغییر کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر به صورت stretch باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) مستطیل پر را نسبت به جعبه مرزی قاب تصویر تعریف می‌کند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند که کدام بخش از تصویر منبع قابل رؤیت باشد؛ stretch‑offsetها مستطیلی را که پر شدن تصویر قابل رؤیت در آن کشیده می‌شود، تغییر می‌دهند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

از stretch‑offsetها برای موقعیت‌بندی پر استفاده کنید. برای مخفی‌سازی لبه‌های تصویر منبع از ویژگی‌های برش استفاده کنید.

## **نگه‌داری، حجم فایل و ملاحظات صادرات**

مزایای اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و فرمت‌بندی قاب تصویر جداگانه در نظر گرفته شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صریحاً حذف یا در طول فشرده‌سازی حذف نشوند، درون تصویر جاسازی‌شده باقی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از تعیین اندازه نهایی تصویر روی اسلاید انجام شود.
- **تصاویر SVG** باید به صورت SVG باقی بمانند وقتی حفظ بردار مهم است. هنگامی که به خود منبع برداری نیاز دارید، SVG جاسازی‌شده را مستقیماً استخراج کنید. صادرات اسلاید به صورت raster همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** هنگامی که ممکن است، از یک منبع [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) موجود استفاده کنید به جای بارگذاری مکرر همان فایل در گردش کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر حسب اندازه نمایش واقعی فشرده کنید، پیکسل‌های برش‌شده را فقط زمانی حذف کنید که ویرایش‌های بعدی لازم نیست و از پیوندهای خارجی صرف‌نظر کنید مگر اینکه مدیریت وابستگی بخشی از طرح استقرار باشد.

## **سوالات متداول**

**فرق بین یک قاب تصویر و یک منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و فرمت‌بندی سطح قاب مانند اندازه، چرخش, مقادیر برش, افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی کنم یا پیوند دهم؟**

تصاویر را وقتی که ارائه باید قابل حمل، بایگانی یا رندر بدون دسترسی به منابع خارجی باشد، جاسازی کنید. تصاویر را فقط وقتی پیوند دهید که نگهداری فایل‌های تصویری خارج از PPTX عمدی باشد و بتوان مکان‌های خارجی را به‌صورت قابل اعتماد مدیریت کرد.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خ خود به‌خود نه. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم، از [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) یا فشرده‌سازی تصویر همراه با حذف نواحی برش‌شده استفاده کنید وقتی می‌توان این پیکسل‌ها را به‌صورت دائم حذف کرد.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی وضوح رستری ذخیره‌شده را کاهش می‌دهد و حذف نواحی برش‌شده داده‌های تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا در آینده ممکن است لازم باشد، تصویر اصلی را خارج از ارائه نگه دارید.

**تصاویر SVG چگونه باید مدیریت شوند؟**

وقتی وفاداری برداری مهم است، محتوای SVG را به صورت SVG نگه دارید. می‌توانید [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به فرمت‌های رستری مانند PNG یا JPEG، SVG را به بخشی از تصویر اسلاید تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. استفاده از `isinstance(shape, slides.PictureFrame)` از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که شامل قاب تصویر نیستند را به‌درستی مدیریت کند.