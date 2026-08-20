---
title: مدیریت قاب‌های تصویر در ارائه‌ها با Python
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
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها با Aspose.Slides برای Python از طریق .NET ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید."
---
## **مرور کلی**

یک قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد به‌صورت اشیاء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) خود می‌داند، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، اثرات تصویری و سایر تنظیمات سطح‑قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) بازگشتی را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را در خود داشته باشند. همچنین می‌توانند به تصاویر پیوندی اشاره کنند به‌جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. انتخاب بین این دو بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی تعیین کنید تصویر باید چگونه ذخیره شود.

## **افزودن و قالب‌بندی تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و با استفاده از [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) یک قاب تصویر بسازید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به رایانهٔ دیگر خود‑محتوی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد بومی تصویر ایجاد می‌کند و قالب‌بندی خطوط و چرخش را اعمال می‌نماید:

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

قاب تصویر هندسهٔ نمایش‌داده‌شده را کنترل می‌کند؛ تغییر اندازهٔ قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییری نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً بخواهید تصویر را برش یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) ویژگی‌های [relative_scale_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/relative_scale_width/) و [relative_scale_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/relative_scale_height/) را برای قاب فراهم می‌کند. مقدار `1.0` با 100٪ اندازهٔ تصویر اصلی متناظر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز به حفظ نسبت به اندازهٔ تصویر منبع داشته باشد به‌جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ اما تصویر جاسازی‌شده را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شدنی ایمن‌ترین گزینه است. یک تصویر پیوندی مسیر مکان خارجی را از طریق لینک [Picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/) ذخیره می‌کند به‌جای جاسازی داده‌های تصویر به همان روش.

تصاویر پیوندی می‌توانند حجم دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را می‌گذارد یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل منتقل شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل‌اعتمادترند.

### **افزودن تصویر پیوندی**

مثال زیر یک قاب تصویر می‌سازد و آن را به یک فایل تصویر محلی اشاره می‌کند. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک جریان کار رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از پیوندها زمانی استفاده کنید که مدیریت فایل خارجی مقصود باشد. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به یک ارائهٔ خود‑محتوی بزرگتر.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، اطمینان حاصل کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) است و شامل یک تصویر جاسازی‌شده می‌باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری نداشته باشند که بتوان به همان روش استخراج کرد.

### **استخراج تصویر رستر**

API تصویر مدرن مستقیم از [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) استفاده می‌کند. مثال زیر اولین تصویر رستر جاسازی‌شده روی یک اسلاید را پیدا کرده و به صورت PNG ذخیره می‌کند:

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

ذخیره‌سازی از طریق [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) تصویر استخراج‌شده را به قالب خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شدهٔ ذخیره‌شده در ارائه نیاز داشته باشید نه به فایل رستری تبدیل‌شده، به‌جای آن از ویژگی [PPImage.binary_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/binary_data/) استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) را فاش می‌کند. این امکان را می‌دهد که داده‌های SVG را به‌صورت مستقیم بدست آورید نه اینکه ابتدا تصویر را رستر کنید.

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

نگه‌داشتن محتوای SVG به‌صورت SVG، منبع برداری را داخل ارائه حفظ می‌کند. صادرات رستری مانند PNG یا JPEG مجبور است آن محتوای برداری را به پیکسل تبدیل کند. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان نسخه بایت‌به‌بایت از SVG جاسازی‌شده در نظر گرفته شوند؛ وقتی به منبع برداری اصلی نیاز دارید، از [SvgImage.svg_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/svg_data/) جاسازی‌شده استفاده کنید.

## **برش تصویر**

برش مشخص می‌کند کدام بخش تصویر در داخل قاب قابل مشاهده است. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش در ابتدا پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل‌نمایش را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

از آنجا که داده‌های تصویر مخفی هنوز موجود‌اند، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توانید ناحیه‌های برش‌خورده را همان‌طور که در بخش بعدی توضیح داده شده است، به‌صورت فیزیکی حذف کنید.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) داده‌های تصویر خارج از مستطیل برش جاری را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، ولی یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «باز‑برش» در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش خورده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد نتیجهٔ برش‌شده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/compress_image/) وضوح تصویر رستر را نسبت به اندازهٔ نمایش تصویر کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی تصویر تغییر اندازه یا برش داده شد `True` برمی‌گرداند و وقتی تغییری لازم نباشد `False`.

هنگامیکه هدف رزولوشن استاندارد کافی است، از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/picturescompression/) استفاده کنید:

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

به‌جای مقدار enum می‌توان یک مقدار DPI مثبت سفارشی را نیز ارسال کرد وقتی هدف خاصی مدنظر باشد.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتوای SVG و متافایل توسط این جریان کار فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به‌یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌خورده حذف‌شده قابل بازیابی از ارائهٔ بهینه‌شده نیستند. رزولوشن هدف را بر پایهٔ بزرگ‌ترین سایزی که تصویر واقعاً مشاهده یا صادر می‌شود تعیین کنید، نه اینکه کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **بازرسی اثرات تصویر**

اثرات تصویر بر روی تصویری که توسط قاب استفاده می‌شود ذخیره می‌شوند. مجموعهٔ تبدیل تصویر می‌تواند شامل اثراتی مانند **AlphaModulateFixed** برای شفافیت و **Luminance** برای روشنایی و کنتراست باشد. مثال زیر به‌صورت ایمن هر دو نوع اثر را از اولین قاب تصویر روی یک اسلاید می‌خواند:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/alphamodulatefixed/) و [Luminance](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/luminance/) نحوهٔ رندر تصویر در قاب را تغییر می‌دهند؛ بایت‌های تصویر جاسازی‌شدهٔ اصلی را بازنویسی نمی‌کنند.

## **قفل‌کردن هندسهٔ قاب تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/) مشخص می‌کنند کدام عملیات ویرایشی برای یک قاب تصویر غیرفعال باشد. برای مثال، ویژگی [aspect_ratio_locked](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این قفل باعث نمی‌شود تصویر منبع بازنمونه‌گیری یا به‌طور دائمی به همان نسبت ابعاد تبدیل شود.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر به‌صورت کشش (stretch) باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) مستطیل پر را نسبت به جعبه مرزی قاب تصویر تعریف می‌کنند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی می‌سازند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش تصویر منبع قابل مشاهده است؛ در حالی که stretch‑offset مستطیلی را تغییر می‌دهد که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود.

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

از stretch‑offset برای قرار دادن پر کردن استفاده کنید. برای مخفی‌کردن لبه‌های تصویر منبع از ویژگی‌های برش استفاده کنید.

## **نکات مربوط به ذخیره‌سازی، حجم فایل و خروجی**

معادله‌های اصلی هنگام جداسازی ذخیره‌سازی تصویر و قالب‌بندی قاب‑تصویر آسان‌تر مدیریت می‌شوند:

- **تصاویر جاسازی‌شده** ارائه را خودمحتوی می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور قابل‌اعتمادترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بستهٔ فایل را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی برش‌خورده صراحتاً حذف یا در زمان فشرده‌سازی حذف نشوند،嵐ا جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را قربانی می‌کند. باید پس از دانستن اندازهٔ نهایی روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی حفظ وکتور مهم است. وقتی به منبع وکتور خود نیاز دارید، SVG جاسازی‌شده را مستقیماً استخراج کنید. صادرات اسلاید به رستر همواره اسلاید رندرشده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** باید در صورت امکان از منبع موجود [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) استفاده کنند به‌جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً وقتی مؤثرترین است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازهٔ نمایش واقعی فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی خودداری کنید مگر این‌که مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **سوالات متداول**

**تفاوت بین یک قاب تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) نمایانگر منبع تصویری است که به ارائه مربوط می‌شود. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) شکل‌ایی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح‑قاب مانند اندازه، چرخش، مقادیر برش، اثرات و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی کنم یا پیوند دهم؟**

تصاویر را زمانی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، جاسازی کنید. فقط در صورتی که نگهداری فایل‌های تصویر خارج از PPTX هدفمند باشد و مکان‌های خارجی به‌صورت قابل‌اعتماد نگهداری شوند، از پیوند استفاده کنید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این‌کار را انجام نمی‌دهد. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند ولی پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم می‌توانید از [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) یا فشرده‌سازی تصویر با حذف نواحی برش‌خورده استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازیابی کرد؟**

خیر. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌های تصویر را از بین می‌برد. اگر در آینده به ویرایش با وضوح بالا نیاز دارید، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG برخورد کرد؟**

زمانی که اهمیت حفظ وکتور وجود دارد، محتوا را به‌صورت SVG نگه دارید. می‌توانید [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به قالب رستر مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناایمن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. استفاده از `isinstance(shape, slides.PictureFrame)` تبدیل‌های نامعتبر را جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که قاب تصویری ندارند به‌درستی مدیریت کند.