---
title: "بهبود پردازش تصویر با API مدرن"
linktitle: "API مدرن"
type: docs
weight: 280
url: /fa/python-net/modern-api/
keywords:
- "API مدرن"
- "رسم"
- "تصویر بندانگشتی اسلاید"
- "تبدیل اسلاید به تصویر"
- "تصویر بندانگشتی شکل"
- "تبدیل شکل به تصویر"
- "تصویر بندانگشتی ارائه"
- "تبدیل ارائه به تصاویر"
- "افزودن تصویر"
- "افزودن عکس"
- "Python"
- "Aspose.Slides"
description: "پردازش تصویر اسلایدها را با جایگزینی APIهای منسوخ تصویر با API مدرن پایتون، برای خودکارسازی یکپارچه PowerPoint و OpenDocument به‌روز کنید."
---
## **معرفی**

API عمومی Aspose.Slides برای Python در حال حاضر به انواع زیر `aspose.pydrawing` بستگی دارد:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

از نسخه 24.4، این API عمومی **منسوخ** شده است زیرا به [تغییرات](https://releases.aspose.com/slides/fa/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) در API عمومی Aspose.Slides برای Python اعمال شده است.

برای حذف `aspose.pydrawing` از API عمومی، **API مدرن** معرفی شد. متدهایی که از `aspose.pydrawing.Image` و `aspose.pydrawing.Bitmap` استفاده می‌کنند منسوخ شده‌اند و باید با معادل‌های API مدرن جایگزین شوند. متدهایی که از `aspose.pydrawing.Graphics` استفاده می‌کنند منسوخ هستند و جایگزین مستقیم در API مدرن ندارند.

در نسخه‌های فعلی، API عمومی که به `aspose.pydrawing` وابسته است را به عنوان قدیمی/منسوخ درنظر بگیرید. برای کدهای جدید و هنگام مهاجرت از گردش‌کارهای پردازش تصویر موجود، از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و enumهای زیر به API عمومی اضافه شده‌اند:

- [aspose.slides.IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) - نمایانگر یک تصویر رستری یا برداری.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/) - نمایانگر قالب فایل تصویر.
- [aspose.slides.Images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/images/) - متدهایی برای ایجاد و کار با [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) فراهم می‌کند.

از `get_image` برای رندر یک اسلاید یا شکل استفاده کنید. از `get_images` برای رندر چندین اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/images/) برای بارگذاری تصاویر، `add_image` با [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برای افزودن آن‌ها به ارائه، و `replace_image` با [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برای به‌روزرسانی تصویر موجود در ارائه استفاده نمایید.

یک سناریوی استفاده معمولی برای API جدید به شکل زیر است:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **جایگزینی کد قدیمی با API مدرن**

برای انتقال آسان‌تر، کلاس جدید [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) رفتار APIهای جداگانه `aspose.pydrawing.Image` و `aspose.pydrawing.Bitmap` را بازتاب می‌دهد. در اکثر موارد، فقط کافی است فراخوانی‌های متدهایی که از `aspose.pydrawing` استفاده می‌کنند را با معادل‌های API مدرن جایگزین کنید.

### **دریافت تصویر بندانگشتی اسلاید**

**Deprecated API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **دریافت تصویر بندانگشتی شکل**

**Deprecated API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **دریافت تصویر بندانگشتی ارائه**

**Deprecated API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **افزودن تصویر به یک ارائه**

**Deprecated API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **متدها و خصوصیات قابل حذف و جایگزین‌های مدرن آن‌ها**

### **کلاس Presentation**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **کلاس Slide**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **کلاس Shape**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **کلاس ImageCollection**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **کلاس PPImage**

|امضای متد/خصوصیت|امضای متد/خصوصیت جایگزین|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/image/)|

### **کلاس ImageWrapperFactory**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **کلاس PatternFormat**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **کلاس IPatternFormatEffectiveData**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **کلاس Output**

|امضای متد|امضای متد جایگزین|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **پشتیبانی API برای aspose.pydrawing.Graphics**

متدهایی که از `aspose.pydrawing.Graphics` استفاده می‌کنند منسوخ شده‌اند و جایگزین مستقیم در API مدرن ندارند.

به جای API که به `aspose.pydrawing.Graphics` رندر می‌کند، از متدهای رندر تصویر API مدرن استفاده کنید:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **پرسش‌های متداول**

**چرا `aspose.pydrawing.Graphics` حذف شد؟**

پشتیبانی از `aspose.pydrawing.Graphics` در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی به پلتفرم‌های خاص حذف شود و به یک رویکرد فراسازمانی با [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) سوئیچ شود. به جای رندر به `aspose.pydrawing.Graphics` از `get_image` یا `get_images` استفاده کنید.

**فایده عملی [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) نسبت به `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` چیست؟**

[IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) کار با هر دو تصویر رستری و برداری را یکپارچه می‌کند، ذخیره‌سازی به قالب‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/) ساده می‌سازد، وابستگی به pydrawing را کاهش می‌دهد و کد را در محیط‌های مختلف قابل حملتر می‌نماید.

**آیا API مدرن بر عملکرد تولید تصویرهای بندانگشتی تأثیر می‌گذارد؟**

تبدیل از `get_thumbnail` به `get_image` باعث کاهش کارایی نمی‌شود: متدهای جدید همان قابلیت‌ها را برای تولید تصویر با گزینه‌ها و اندازه‌ها فراهم می‌کنند و همچنان از گزینه‌های رندر پشتیبانی می‌کنند. سود یا ضرر خاص بستگی به سناریو دارد، اما از نظر عملکردی جایگزین‌ها معادل هستند.