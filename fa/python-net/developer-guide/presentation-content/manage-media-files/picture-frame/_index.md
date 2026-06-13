---
title: اضافه کردن قاب‌های تصویر به ارائه‌ها با پایتون
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
- تصویر رستر
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
description: اضافه کردن قاب‌های تصویر به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET. کار فرآیند خود را بهینه‌سازی کنید و طراحی اسلایدها را ارتقا دهید.
---
## **Introduction**

قاب‌های تصویر در Aspose.Slides برای Python به شما امکان می‌دهند تا تصاویر رستر و برداری را به عنوان اشکال بومی اسلاید قرار داده و مدیریت کنید. می‌توانید تصاویر را از فایل‌ها یا جریان‌ها وارد کنید، با مختصات دقیق موقعیت‌دهی و تغییر اندازه دهید، چرخش اعمال کنید، شفافیت را تنظیم کنید و ترتیب لایه‌ای را کنار سایر اشکال کنترل کنید. API همچنین از برش، حفظ نسبت ابعاد، تنظیم حاشیه‌ها و افکت‌ها، و جایگزینی تصویر زیرین بدون بازسازی طرح پشتیبانی می‌کند. از آنجا که قاب‌های تصویر مانند اشکال عادی رفتار می‌کنند، می‌توانید انیمیشن‌ها، پیوندها و متن جایگزین (alt text) اضافه کنید که ساخت ارائه‌های بصری غنی و قابل دسترس را آسان می‌سازد.

## **Create Picture Frames**

این بخش نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید با ایجاد یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با Aspose.Slides برای Python. شما یاد خواهید گرفت چگونه تصویر را بارگذاری کنید، آن را دقیقاً بر روی اسلاید قرار دهید و اندازه و قالب‌بندی آن را کنترل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. اسلایدی را بر اساس شاخص آن دریافت کنید.  
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ارائه ایجاد کنید. این تصویر برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع قاب را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با آن اندازه با استفاده از متد [add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) ایجاد کنید.  
6. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی یک فایل PPTX ایجاد کنید.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # تصویر را به ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # یک قاب تصویر با اندازه تصویر اضافه کنید.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # ارائه را به‌صورت PPTX ذخیره کنید.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
قاب‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه را از تصاویر ایجاد کنید. وقتی قاب‌های تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر کنترل کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/python-net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-png/); تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-svg/); تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Create Picture Frames with Relative Scale**

این بخش نشان می‌دهد چگونه یک تصویر را با اندازه ثابت قرار داده و سپس مقیاس‌گذاری مبتنی بر درصد را به طور مستقل بر عرض و ارتفاع آن اعمال کنید. از آنجا که درصدها ممکن است متفاوت باشند، نسبت ابعاد می‌تواند تغییر کند. مقیاس‌گذاری نسبت به ابعاد اصلی تصویر انجام می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. اسلایدی را بر اساس شاخص آن دریافت کنید.  
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ایجاد کنید.  
4. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) به اسلاید اضافه کنید.  
5. عرض و ارتفاع نسبی قاب تصویر را تنظیم کنید.  
6. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک قاب تصویر با مقیاس‌گذاری نسبی ایجاد کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی یک فایل PPTX ایجاد کنید.
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

## **Extract Raster Images from Picture Frames**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) استخراج کرده و در فرمت‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در فرمت PNG ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extract SVG Images from Picture Frames**

هنگامی که یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد تصویر برداری اصلی را با تمام جزئیات بازیابی کنید. با پیمایش مجموعه اشکال اسلاید می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) زیرین محتوای SVG دارد و سپس آن تصویر را به صورت SVG بومی روی دیسک یا در یک جریان ذخیره کنید.

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

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

## **Get Image Transparency**

Aspose.Slides به شما امکان می‌دهد اثر شفافیتی که بر روی یک تصویر اعمال شده است را بازیابی کنید. این کد پایتون عمل را نمایش می‌دهد:

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
تمام افکت‌های اعمال شده به تصاویر را می‌توانید در [aspose.slides.effects](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/) بیابید.
{{% /alert %}}

## **Picture Frame Formatting**

Aspose.Slides گزینه‌های فرمت‌بندی متعددی را برای یک قاب تصویر ارائه می‌دهد. با این گزینه‌ها می‌توانید یک قاب تصویر را مطابق نیازهای خاص تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. اسلایدی را بر اساس شاخص آن دریافت کنید.  
3. یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را با افزودن تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) ایجاد کنید. این تصویر برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع قاب را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با آن اندازه با استفاده از متد [add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) اسلاید ایجاد کنید.  
6. رنگ خط قاب تصویر را تنظیم کنید.  
7. عرض خط قاب تصویر را تنظیم کنید.  
8. قاب تصویر را با مقدار مثبت (ساعتگرد) یا منفی (پادساعتگرد) چرخش دهید.  
9. ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر فرایند فرمت‌بندی قاب تصویر را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation برای نمایندگی یک فایل PPTX ایجاد کنید.
with slides.Presentation() as presentation:
    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # یک قاب تصویر با اندازه تصویر اضافه کنید.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # قالب‌بندی را بر روی قاب تصویر اعمال کنید.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # ارائه را به‌صورت PPTX ذخیره کنید.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose یک ابزار رایگان به نام [Collage Maker](https://products.aspose.app/slides/fa/collage) ارائه داده است. اگر نیاز به ترکیب تصاویر JPG/JPEG یا PNG، یا ایجاد شبکه‌های عکس دارید، می‌توانید از این سرویس استفاده کنید.
{{% /alert %}}

## **Add Images as Links**

برای حفظ کوچک بودن فایل‌های ارائه می‌توانید به جای درج مستقیم فایل‌ها، تصاویر یا ویدیوها را از طریق پیوندها اضافه کنید. کد پایتون زیر نشان می‌دهد چگونه یک تصویر و یک ویدیو را در یک مکان‌نگهدار (placeholder) وارد کنید:

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

## **Crop Images**

در این بخش یاد می‌گیرید چگونه ناحیه قابل مشاهده یک تصویر را درون یک قاب تصویر برش دهید بدون اینکه فایل منبع تغییر کند. همچنین روش پایه‌ای اعمال حاشیه‌های برش برای ایجاد ترکیبی تمیز و متمرکز مستقیماً بر روی اسلاید را می‌آموزید.

کد پایتون زیر نشان می‌دهد چگونه یک تصویر را در اسلاید برش دهید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # یک قاب تصویر به اسلید اضافه کنید.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # تصویر را برش دهید (مقدارهای درصدی).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # نتیجه را ذخیره کنید.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Delete Cropped Areas of Images**

اگر می‌خواهید نواحی برش‌خورده یک تصویر در یک قاب را حذف کنید، از متد [delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) استفاده کنید. این متد تصویر برش‌خورده یا در صورت عدم نیاز به برش، تصویر اصلی را برمی‌گرداند.

کد پایتون زیر عمل را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # دریافت PictureFrame از اولین اسلاید.
    picture_frame = slides.shape[0]

    # دریافت PictureFrame از اولین اسلاید.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # نتیجه را ذخیره کنید.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
متد [delete_picture_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، می‌تواند اندازه ارائه را کاهش دهد؛ در غیر این صورت، تعداد تصاویر در ارائه نهایی ممکن است افزایش یابد.

در حین برش، این متد فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند.
{{% /alert %}}

## **Compress Images**

می‌توانید یک تصویر موجود در ارائه را با استفاده از متد [PictureFillFormat.compress_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/compress_image/) فشرده کنید. این متد تصویر را با کاهش اندازه براساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند و گزینه حذف نواحی برش‌خورده نیز موجود است.

این کار اندازه و وضوح تصویر را به‌گونه‌ای تنظیم می‌کند که مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint باشد.

مثال‌های پایتون زیر نشان می‌دهند چگونه یک تصویر را با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده فشرده کنید:

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

یا با استفاده مستقیم از مقدار DPI سفارشی:

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
این متد تصویر را به وضوح کمتر بر اساس اندازه شکل و DPI ارائه شده تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه طرز کار PowerPoint با JPEGهای با وضوح بالا.
{{% /alert %}}

## **Lock the Aspect Ratio**

اگر می‌خواهید شکلی که شامل یک تصویر است پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، ویژگی [aspect_ratio_locked](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) را بر روی `True` تنظیم کنید.

کد پایتون زیر نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # قفل نسبت ابعاد هنگام تغییر اندازه.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
این تنظیم *قفل نسبت ابعاد* تنها نسبت ابعاد شکل را حفظ می‌کند، نه نسبت ابعاد تصویر داخل آن.
{{% /alert %}}

## **Use Stretch Offset Properties**

با استفاده از ویژگی‌های `stretch_offset_left`، `stretch_offset_top`، `stretch_offset_right` و `stretch_offset_bottom` کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/)، می‌توانید یک مستطیل پر کردن تعریف کنید.

زمانی که کشش برای یک تصویر مشخص می‌شود، مستطیل منبع برای پر کردن مستطیل هدف مقیاس می‌شود. هر لبه از مستطیل هدف با یک درصد جابجایی نسبت به لبه متناظر جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی داخلی و درصد منفی یک بیرون‌زدگی را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.  
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی اضافه کنید.  
4. نوع پر کردن شکل را تنظیم کنید.  
5. حالت پر کردن تصویر شکل را تنظیم کنید.  
6. یک تصویر را بارگذاری کنید.  
7. تصویر را برای پر کردن شکل اختصاص دهید.  
8. جابجایی‌های تصویر را از لبه‌های متناظر جعبه مرزی شکل مشخص کنید.  
9. ارائه را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نحوه استفاده از ویژگی‌های Stretch Offset را نشان می‌دهد:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نماینده یک فایل PPTX است ایجاد کنید.
with slides.Presentation() as presentation:
    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک AutoShape مستطیلی اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # نوع پر کردن شکل را تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # حالت پر کردن تصویر شکل را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تصویر را بارگذاری کنید و به ارائه اضافه کنید.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # تصویر را برای پر کردن شکل اختصاص دهید.
    shape.fill_format.picture_fill_format.picture.image = image

    # جابجایی‌های تصویر را نسبت به لبه‌های متناظر جعبه مرزی شکل مشخص کنید.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose تبدیل‌کنندگان رایگانی ارائه می‌دهد—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید.
{{% /alert %}}

## **FAQ**

**چگونه می‌توانم بفهمم کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**  
Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (به عنوان مثال SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور اسلاید و تبدیل تصویر هم‌پوشانی دارد.

**اضافه کردن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد PPTX دارد؟**  
جاسازی مستقیم تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ پیوند دادن تصاویر به حفظ کوچک بودن اندازه ارائه کمک می‌کند ولی نیازمند دسترسی مداوم به فایل‌های خارجی است. Aspose.Slides امکان افزودن تصاویر از طریق پیوند را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازه تصادفی قفل کنم؟**  
از [shape locks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/picture_frame_lock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن جابجایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقاله‌ی جداگانه‌ی [protection article](/slides/fa/python-net/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا هنگام صادرات ارائه به PDF/تصاویر، کیفیت برداری SVG حفظ می‌شود؟**  
Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) به عنوان بردار اصلی را فراهم می‌کند. هنگام [exporting to PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) یا [raster formats](/slides/fa/python-net/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به رستر تبدیل شود؛ اما حفظ SVG به‌عنوان بردار توسط رفتار استخراج تأیید می‌شود.