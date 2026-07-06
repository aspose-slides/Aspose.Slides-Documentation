---
title: افزودن قاب‌های تصویر به ارائه‌ها با Python
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/python-net/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستری
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قاب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET اضافه کنید. روند کار خود را ساده‌سازی کنید و طراحی اسلایدها را بهبود ببخشید."
---
## **معرفی**

قاب‌های تصویر در Aspose.Slides برای Python به شما امکان می‌دهند تا تصاویر رستر و برداری را به عنوان اشکال بومی اسلاید قرار داده و مدیریت کنید. می‌توانید تصاویر را از فایل‌ها یا جریان‌ها وارد کنید، موقعیت و اندازه آن‌ها را با مختصات دقیق تنظیم کنید، چرخش اعمال کنید، شفافیت را تنظیم کنید و ترتیب z را همراه با سایر اشکال کنترل کنید. API همچنین از برش، حفظ نسبت عرض به ارتفاع، تنظیم حاشیه‌ها و افکت‌ها، و جایگزین کردن تصویر زیرین بدون بازسازی طرح پشتیبانی می‌کند. چون قاب‌های تصویر همانند اشکال معمولی رفتار می‌کنند، می‌توانید انیمیشن‌ها، پیوندهای ابرمتنی و متن Alt اضافه کنید که ساخت ارائه‌های بصری غنی و دسترس‌پذیر را ساده می‌سازد.

## **ایجاد قاب‌های تصویر**

این بخش نشان می‌دهد چگونه با ایجاد یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) تصویر را در اسلاید وارد کنید. خواهید آموخت چگونه تصویر را بارگذاری کنید، دقیقاً روی اسلاید قرار دهید و اندازه و قالب‌بندی آن را کنترل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی را با استفاده از اندیس آن دریافت کنید.
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ارائه ایجاد کنید. این تصویر برای پر کردن شکل استفاده می‌شود.
4. عرض و ارتفاع قاب را مشخص کنید.
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با آن اندازه با استفاده از متد [add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) ایجاد کنید.
6. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا فایل PPTX را نمایان کند.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # تصویر را به ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # یک قاب تصویر با اندازه تصویر اضافه کنید.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # ارائه را به عنوان PPTX ذخیره کنید.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

قاب‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه را از تصاویر ایجاد کنید. هنگامی که قاب‌های تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات I/O را برای تبدیل تصاویر از یک فرمت به فرمت دیگر کنترل کنید. ممکن است بخواهید این صفحات را مشاهده کنید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/python-net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-png/); تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-svg/); تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **ایجاد قاب‌های تصویر با مقیاس نسبی**

این بخش نشان می‌دهد چگونه تصویر را با ابعاد ثابت قرار داده، سپس مقیاس‌دهی مبتنی بر درصد را به‌صورت جداگانه بر عرض و ارتفاع آن اعمال کنید. چون درصدها ممکن است متفاوت باشند، نسبت ابعاد می‌تواند تغییر کند. مقیاس‌دهی نسبی به ابعاد اصلی تصویر انجام می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی را با استفاده از اندیس آن دریافت کنید.
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ارائه ایجاد کنید.
4. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) به اسلاید اضافه کنید.
5. عرض و ارتفاع نسبی قاب تصویر را تنظیم کنید.
6. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل PPTX را نشان دهد.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # یک قاب تصویر به اسلاید اضافه کنید.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # عرض و ارتفاع مقیاس نسبی را تنظیم کنید.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # ارائه را ذخیره کنید.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج تصاویر رستری از قاب‌های تصویر**

می‌توانید تصاویر رستری را از اشیای [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در قالب PNG ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

هنگامی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای Python via .NET به شما امکان می‌دهد تا تصاویر برداری اصلی را با تمام دقت استخراج کنید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) زیرین محتوای SVG دارد یا نه، و سپس آن تصویر را در قالب SVG بومی روی دیسک یا جریان ذخیره کنید.

کد مثال زیر نشان می‌دهد چگونه یک تصویر SVG را از قاب تصویر استخراج کنید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **دریافت شفافیت تصویر**

Aspose.Slides به شما اجازه می‌دهد شفافیت اعمال شده به یک تصویر را بازیابی کنید. این کد پایتون این عملیات را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
تمام افکت‌های اعمال شده به تصاویر را می‌توانید در [aspose.slides.effects](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/) پیدا کنید.
{{% /alert %}}

## **دریافت روشنایی و کنتراست تصویر**

Aspose.Slides به شما اجازه می‌دهد روشنایی و کنتراست اعمال شده به یک تصویر را بازیابی کنید. کلاس [Luminance](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/luminance/) این افکت تبدیل تصویر را نشان می‌دهد.

این کد پایتون نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **قاب‌بندی قالب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را ارائه می‌دهد که می‌توانید بر روی یک قاب تصویر اعمال کنید. با این گزینه‌ها می‌توانید قاب تصویر را برای برآورده کردن نیازهای خاص تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی را با استفاده از اندیس آن دریافت کنید.
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ارائه ایجاد کنید. این تصویر برای پر کردن شکل استفاده می‌شود.
4. عرض و ارتفاع قاب را مشخص کنید.
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با آن اندازه با استفاده از متد [add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) اسلاید ایجاد کنید.
6. رنگ خط قاب تصویر را تنظیم کنید.
7. عرض خط قاب تصویر را تنظیم کنید.
8. قاب تصویر را با مقدار مثبت (ساعتگرد) یا منفی (پادساعتگرد) چرخش دهید.
9. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل PPTX را نمایان کند.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # یک قاب تصویر با اندازه تصویر اضافه کنید.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # قالب‌بندی را برای قاب تصویر اعمال کنید.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # ارائه را به صورت PPTX ذخیره کنید.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose یک ابزار رایگان به نام [Collage Maker](https://products.aspose.app/slides/fa/collage) ارائه داده است. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG دارید، یا می‌خواهید [شبکه‌های عکسی](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید، می‌توانید از این سرویس استفاده کنید.
{{% /alert %}}

## **افزودن تصاویر به‌عنوان پیوندها**

برای نگه داشتن فایل‌های ارائه کوچک، می‌توانید تصاویر یا ویدیوها را به‌عنوان پیوندها اضافه کنید به‌جای این‌که فایل‌ها را مستقیماً در ارائه جاسازی کنید. کد پایتون زیر نشان می‌دهد چگونه یک تصویر و یک ویدیو را در یک جای‌دار (placeholder) وارد کنید:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **برش تصاویر**

در این بخش می‌آموزید چگونه ناحیه قابل مشاهده یک تصویر را داخل قاب تصویر بدون تغییر فایل منبع برش دهید. همچنین روش پایه‌ای برای اعمال حاشیه‌های برش جهت ایجاد ترکیب‌بندی تمیز و متمرکز مستقیم بر روی اسلاید را یاد می‌گیرید.

کد پایتون زیر نشان می‌دهد چگونه یک تصویر را در اسلاید برش دهید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # یک قاب تصویر به اسلاید اضافه کنید.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # تصویر را برش دهید (مقدار درصدی).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # نتیجه را ذخیره کنید.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف نواحی برش‌خورده تصاویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر در قاب را حذف کنید، از متد [delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) استفاده کنید. این متد تصویر برش خورده را باز می‌گرداند، یا تصویر اصلی اگر نیازی به برش نباشد.

کد پایتون زیر این عملیات را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # قاب تصویر را از اولین اسلاید دریافت کنید.
    picture_frame = slides.shape[0]

    # قاب تصویر را از اولین اسلاید دریافت کنید.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # نتیجه را ذخیره کنید.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

متد [delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) تصویر برش خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، می‌تواند اندازه ارائه را کاهش دهد؛ در غیر این صورت تعداد تصاویر در ارائه نهایی ممکن است افزایش یابد.

در طول برش، این متد فایل‌های متافایل WMF/EMF را به تصویر رستری PNG تبدیل می‌کند.
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [PictureFillFormat.compress_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/compress_image/) یک تصویر را در ارائه فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را دارد.

این عملکرد اندازه و وضوح تصویر را مشابه گزینه **Picture Format → Compress Pictures → Resolution** در PowerPoint تنظیم می‌کند.

نمونه‌های پایتون زیر نشان می‌دهند چگونه یک تصویر را با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش فشرده کنید:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # نتیجه فشرده‌سازی را بررسی کنید.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

یا به‌صورت مستقیم با مقدار DPI سفارشی:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # تصویر را به 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

این متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی اندازه فایل حذف شوند.
اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، همان‌طور که PowerPoint با JPEGهای با وضوح بالا رفتار می‌کند.
{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید شکلی که شامل تصویر است پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، ویژگی [aspect_ratio_locked](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) را بر روی `True` تنظیم کنید.

کد پایتون زیر نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # نسبت ابعاد را هنگام تغییر اندازه قفل کنید.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند، نه نسبت ابعاد تصویر داخل آن.
{{% /alert %}}

## **استفاده از ویژگی‌های Stretch Offset**

با استفاده از ویژگی‌های `stretch_offset_left`، `stretch_offset_top`، `stretch_offset_right` و `stretch_offset_bottom` در کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) می‌توانید یک مستطیل پرکننده تعریف کنید.

هنگامی که کشش برای یک تصویر مشخص می‌شود، مستطیل منبع مقیاس‌بندی می‌شود تا در مستطیل پرکننده جای بگیرد. هر لبه از مستطیل پرکننده توسط یک درصد از لبه متناظر جعبه محدوده شکل تعریف می‌شود. درصد مثبت مقدار تو رفتگی داخلی و درصد منفی مقدار برون‌رفتگی را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجعی به یک اسلاید با اندیس آن به‌دست آورید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی اضافه کنید.
4. نوع پرکردن شکل را تنظیم کنید.
5. حالت پرکردن تصویر شکل را تنظیم کنید.
6. یک تصویر بارگذاری کنید.
7. تصویر را برای پرکردن شکل اختصاص دهید.
8. افست‌های تصویر را نسبت به لبه‌های متناظر جعبه محدوده شکل مشخص کنید.
9. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه از ویژگی‌های Stretch Offset استفاده کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل PPTX را نمایان می‌کند.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # یک AutoShape مستطیل اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # نوع پر کردن شکل را تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # حالت پر کردن تصویر شکل را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تصویر را بارگذاری کرده و به ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # تصویر را برای پر کردن شکل اختصاص دهید.
    shape.fill_format.picture_fill_format.picture.image = image

    # افست‌های تصویر را نسبت به لبه‌های متناظر جعبه محدوده شکل تعیین کنید.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose مبدل‌های رایگان — [JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — را فراهم می‌کند که به سرعت می‌توانید ارائه‌ها را از تصاویر ایجاد کنید.
{{% /alert %}}

## **سؤال‌های متداول**

**چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**

Aspose.Slides هم تصاویر رستری (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) اختصاص می‌یابد، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد PPTX دارد؟**

جاسازی تصاویر بزرگ باعث افزایش حجم فایل و مصرف حافظه می‌شود؛ پیوند دادن تصاویر به کاهش حجم ارائه کمک می‌کند اما فایل‌های خارجی باید در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت پیوند را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویری را از جابه‌جایی/تغییر اندازه تصادفی قفل کنم؟**

از [shape locks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/picture_frame_lock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن جابه‌جایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقاله جداگانهٔ [پروtection](/slides/fa/python-net/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال از جمله [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا دقت برداری SVG هنگام صادرات ارائه به PDF/تصاویر حفظ می‌شود؟**

Aspose.Slides اجازه می‌دهد SVG را از یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) به‌عنوان بردار اصلی استخراج کنید. هنگام [صادرات به PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) یا [فرمت‌های رستری](/slides/fa/python-net/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به رستر تبدیل شود؛ اما استخراج SVG تأیید می‌کند که SVG اصلی به‌عنوان بردار ذخیره شده است.