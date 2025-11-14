---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 280
url: /ar/python-net/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة, الرسم"
description: "واجهة برمجة التطبيقات الحديثة"
---

## مقدمة

حاليًا، تحتوي مكتبة Aspose.Slides لـ Python عبر .NET على اعتمادات في واجهتها العامة على الفئات التالية من `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتبارًا من الإصدار 24.4، تم إعلان هذه الواجهة العامة مك Deprecated بسبب [التغييرات](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) في واجهة Aspose.Slides لـ .NET.

من أجل التخلص من الاعتماد على `aspose.pydrawing` في الواجهة العامة، أضفنا ما يسمى "واجهة برمجة التطبيقات الحديثة". تم إعلان طرق استخدام `aspose.pydrawing.Image` و `aspose.pydrawing.Bitmap` بأنها Deprecated وسيتم استبدالها بالطرق المقابلة من واجهة برمجة التطبيقات الحديثة. تم إعلان طرق استخدام `aspose.pydrawing.Graphics` بأنها Deprecated وسيتم إزالة دعمها من الواجهة العامة.

سيتم إزالة الواجهة العامة Deprecated التي تعتمد على `aspose.pydrawing` في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تمت إضافة الفئات والتعدادات التالية إلى الواجهة العامة:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - يمثل الصورة النقطية أو المتجهية.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - يمثل تنسيق الملف للصورة.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - طرق لإنشاء والتعامل مع واجهة `IImage`.

يمكن أن تبدو سيناريوهات استخدام واجهة برمجة التطبيقات الجديدة كما يلي:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة

لتسهيل الانتقال، تتكرر واجهة `IImage` الجديدة في التوقيعات المنفصلة لفئات `Image` و `Bitmap`. بشكل عام، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة باستخدام `aspose.pydrawing` بالطريقة الجديدة.

### الحصول على صورة مصغرة للشريحة

الكود باستخدام واجهة برمجة التطبيقات Deprecated:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

واجهة برمجة التطبيقات الحديثة:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### الحصول على صورة مصغرة لشكل

الكود باستخدام واجهة برمجة التطبيقات Deprecated:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

واجهة برمجة التطبيقات الحديثة:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### الحصول على صورة مصغرة للعروض التقديمية

الكود باستخدام واجهة برمجة التطبيقات Deprecated:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

واجهة برمجة التطبيقات الحديثة:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### إضافة صورة إلى عرض تقديمي

الكود باستخدام واجهة برمجة التطبيقات Deprecated:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

واجهة برمجة التطبيقات الحديثة:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## الطرق/الخصائص التي سيتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### فئة العروض التقديمية
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|سيتم حذفه بالكامل|
|save(fname, format, options, response, show_inline)|سيتم حذفه بالكامل|
|print()|سيتم حذفه بالكامل|
|print(printer_settings)|سيتم حذفه بالكامل|
|print(printer_name)|سيتم حذفه بالكامل|
|print(printer_settings, pres_name)|سيتم حذفه بالكامل|

### فئة الشريحة
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|سيتم حذفه بالكامل|
|render_to_graphics(options, graphics, scale_x, scale_y)|سيتم حذفه بالكامل|
|render_to_graphics(options, graphics, rendering_size)|سيتم حذفه بالكامل|

### فئة الشكل
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### فئة مجموعة الصور
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### فئة PPImage
|توقيع/خاصية الطريقة|توقيع/خاصية طريقة الاستبدال|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### فئة ImageWrapperFactory
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### فئة PatternFormat
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### فئة IPatternFormatEffectiveData
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### فئة Output
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## دعم واجهة برمجة التطبيقات لـ `aspose.pydrawing.Graphics` سيتوقف

تم إعلان طرق استخدام `aspose.pydrawing.Graphics` بأنها Deprecated وسيتم إزالة دعمها من الواجهة العامة.

سيتم إزالة الجزء من واجهة برمجة التطبيقات الذي يستخدمها:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`