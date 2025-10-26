---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 280
url: /ar/python-net/developer-guide/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- الرسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Python
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات المتقربة للصور بواجهة برمجة التطبيقات الحديثة للبايثون لتسهيل أتمتة PowerPoint و OpenDocument."
---

## **مقدمة**

تُعتمد الآن واجهة برمجة التطبيقات العامة لـ Aspose.Slides for Python على الأنواع التالية من `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتبارًا من الإصدار 24.4، أصبحت هذه الواجهة **متقربة** بسبب [التغييرات](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) في واجهة برمجة التطبيقات العامة لـ Aspose.Slides for Python.

لإزالة `aspose.pydrawing` من الواجهة العامة، قدمنا **الواجهة الحديثة**. الأساليب التي تستخدم `aspose.pydrawing.Image` و `aspose.pydrawing.Bitmap` متقربة وسيتم استبدالها بنظائرها في الواجهة الحديثة. الأساليب التي تستخدم `aspose.pydrawing.Graphics` متقربة، وستُحذف دعمها من الواجهة العامة.

من المقرر إلغاء الواجهة المتقربة التي تعتمد على `aspose.pydrawing` في الإصدار **24.8**.

## **الواجهة الحديثة**

تمت إضافة الفئات والعدادات (enums) التالية إلى الواجهة العامة:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — تمثّل صورة نقطية أو متجهية.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — تمثّل تنسيق ملف الصورة.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — توفر أساليب لإنشاء والعمل مع `IImage`.

سيناريو الاستخدام النموذجي للواجهة الجديدة يكون كما يلي:

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

## **استبدال الكود القديم بالواجهة الحديثة**

للتسهيل في الانتقال، تعكس واجهة `IImage` الجديدة واجهات `Image` و `Bitmap` المنفصلة. في معظم الحالات، يكفي استبدال استدعاءات الأساليب التي تستخدم `aspose.pydrawing` بنظائرها في الواجهة الحديثة.

### **إنشاء صورة مصغرة للشرائح**

**الواجهة المتقربة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**الواجهة الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **إنشاء صورة مصغرة للشكل**

**الواجهة المتقربة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**الواجهة الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **إنشاء صورة مصغرة للعرض التقديمي**

**الواجهة المتقربة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**الواجهة الحديثة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **إضافة صورة إلى عرض تقديمي**

**الواجهة المتقربة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**الواجهة الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **الأساليب والخصائص التي سُتحذف وبدائلها الحديثة**

### **فئة Presentation**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|سيتم حذفه تمامًا|
|save(fname, format, options, response, show_inline)|سيتم حذفه تمامًا|
|print()|سيتم حذفه تمامًا|
|print(printer_settings)|سيتم حذفه تمامًا|
|print(printer_name)|سيتم حذفه تمامًا|
|print(printer_settings, pres_name)|سيتم حذفه تمامًا|

### **فئة Slide**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|سيتم حذفه تمامًا|
|render_to_graphics(options, graphics, scale_x, scale_y)|سيتم حذفه تمامًا|
|render_to_graphics(options, graphics, rendering_size)|سيتم حذفه تمامًا|

### **فئة Shape**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **فئة ImageCollection**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **فئة PPImage**

|توقيع الأسلوب/الخاصية|توقيع أسلوب/خاصية البديل|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **فئة ImageWrapperFactory**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **فئة PatternFormat**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **فئة IPatternFormatEffectiveData**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **فئة Output**

|توقيع الأسلوب|توقيع أسلوب البديل|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **سيتم إيقاف دعم aspose.pydrawing.Graphics**

الأساليب التي تستخدم `aspose.pydrawing.Graphics` متقربة؛ سيُزال دعمها من الواجهة العامة.

الأعضاء الذين يعتمدون على `aspose.pydrawing.Graphics` وسيتم إزالتهم هم:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **الأسئلة الشائعة**

**لماذا تم إلغاء `aspose.pydrawing.Graphics`؟**

يتم حذف دعم Graphics من الواجهة العامة لتوحيد العمل مع التصيّر (rendering) والصور، وإزالة الاعتماد على مكوّنات خاصة بالمنصات، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). ستُحذف جميع أساليب التصيّر إلى Graphics.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) يجمع بين التعامل مع الصور النقطية (raster) والمتجهية (vector)، يبسط الحفظ إلى صيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، يقلل الاعتماد على pydrawing، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `get_thumbnail` إلى `get_image` لا يتسبب في تدهور الأداء؛ توفر الأساليب الجديدة نفس الإمكانات لإنتاج الصور مع الخيارات والأحجام، مع الاحتفاظ بدعم خيارات التصيّر. الفائدة أو الخسارة الفعلية تعتمد على السيناريو، لكن من الناحية الوظيفية فإن البدائل مكافئة.