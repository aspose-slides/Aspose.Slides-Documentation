---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 280
url: /ar/python-net/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- الرسم
- مصغّر الشريحة
- تحويل الشريحة إلى صورة
- مصغّر الشكل
- تحويل الشكل إلى صورة
- مصغّر العرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Python
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عبر استبدال واجهات برمجة التطبيقات القديمة بالواجهة الحديثة لبايثون لتحقيق أتمتة سلسة لـ PowerPoint و OpenDocument."
---

## **المقدمة**

تتبع Aspose.Slides for Python API العامة حالياً الأنواع التالية من `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتباراً من الإصدار 24.4، تم **إهمال** هذه API العامة بسبب [التغييرات](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) في Aspose.Slides for Python API العامة.

لإزالة `aspose.pydrawing` من API العامة، قدمنا **واجهة برمجة التطبيقات الحديثة**. الطرق التي تستخدم `aspose.pydrawing.Image` و `aspose.pydrawing.Bitmap` تم إهمالها وستُستبدل بنظيراتها في الواجهة الحديثة. الطرق التي تستخدم `aspose.pydrawing.Graphics` تم إهمالها، وستُزال دعمها من API العامة.

من المقرر إزالة API المُهملة التي تعتمد على `aspose.pydrawing` في الإصدار **24.8**.

## **واجهة برمجة التطبيقات الحديثة**

تمت إضافة الفئات والعددات التالية إلى API العامة:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — تمثل صورة نقطية أو متجهة.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — تمثل تنسيق ملف الصورة.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — توفر طرقاً لإنشاء والعمل مع `IImage`.

نموذج سيناريو الاستخدام للواجهة الجديدة هو كما يلي:

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

لتسهيل الانتقال، تعكس واجهة `IImage` الجديدة واجهات برمجة التطبيقات المنفصلة لفئتي `Image` و `Bitmap`. في معظم الحالات، تحتاج فقط إلى استبدال استدعاءات الطرق التي تستخدم `aspose.pydrawing` بنظيراتها في الواجهة الحديثة.

### **الحصول على مصغّر الشريحة**

**API المهملة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **الحصول على مصغّر الشكل**

**API المهملة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **الحصول على مصغّر العرض التقديمي**

**API المهملة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API الحديثة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **إضافة صورة إلى العرض التقديمي**

**API المهملة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **الطرق والخصائص التي ستُزال واستبدالاتها الحديثة**

### **فئة Presentation**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingssize)|
|save(fname, format, response, show_inline)|سيتم حذفها بالكامل|
|save(fname, format, options, response, show_inline)|سيتم حذفها بالكامل|
|print()|سيتم حذفها بالكامل|
|print(printer_settings)|سيتم حذفها بالكامل|
|print(printer_name)|سيتم حذفها بالكامل|
|print(printer_settings, pres_name)|سيتم حذفها بالكامل|

### **فئة Slide**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|سيتم حذفها بالكامل|
|render_to_graphics(options, graphics, scale_x, scale_y)|سيتم حذفها بالكامل|
|render_to_graphics(options, graphics, rendering_size)|سيتم حذفها بالكامل|

### **فئة Shape**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **فئة ImageCollection**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **فئة PPImage**

| توقيع الطريقة/الخاصية | توقيع الطريقة/الخاصية البديلة |
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **فئة ImageWrapperFactory**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **فئة PatternFormat**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **فئة IPatternFormatEffectiveData**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **فئة Output**

| توقيع الطريقة | توقيع الطريقة البديلة |
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **ستتوقف دعم aspose.pydrawing.Graphics**

الطرق التي تستخدم `aspose.pydrawing.Graphics` تم إهمالها؛ سيُزال الدعم عنها من API العامة.

الأعضاء الذين يعتمدون على `aspose.pydrawing.Graphics` وسيتم إزالتهم هم:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **الأسئلة الشائعة**

**لماذا تم إلغاء `aspose.pydrawing.Graphics`؟**

يُزال دعم Graphics من API العامة لتوحيد العمل مع التصيير والصور، وإزالة الارتباطات بالاعتمادات الخاصة بالمنصات، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). جميع طرق التصيير إلى Graphics ستُحذف.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) يوحد التعامل مع الصور النقطية والمتجهة، يبسط حفظها بتنسيقات متعددة عبر [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، يقلل الاعتماد على pydrawing، ويجعل الشيفرة أكثر قابلية للنقل بين البيئات.

**هل تؤثر الواجهة الحديثة على أداء إنشاء المصغرات؟**

التحول من `get_thumbnail` إلى `get_image` لا يُخفض الأداء في السيناريوهات العامة؛ توفر الطرق الجديدة نفس الإمكانيات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان المحدد يعتمد على السيناريو، لكن الوظائفية متساوية.