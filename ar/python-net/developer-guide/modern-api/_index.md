---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيق الحديثة
linktitle: واجهة برمجة التطبيق الحديثة
type: docs
weight: 280
url: /ar/python-net/modern-api/
keywords:
- واجهة برمجة تطبيقات حديثة
- رسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للأشكال
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- بايثون
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات المتقادمة للصور بواجهة برمجة التطبيق الحديثة لبايثون لتسهيل أتمتة PowerPoint وOpenDocument."
---

## **المقدمة**

تعتمد الواجهة العامة لــ Aspose.Slides for Python حالياً على الأنواع التالية في ‎`aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتباراً من الإصدار 24.4، تم **إهمال** هذه الواجهة العامة بسبب [التغييرات](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) في واجهة برمجة التطبيق العامة لـ Aspose.Slides for Python.

للتخلص من ‎`aspose.pydrawing` في الواجهة العامة، قدمنا **الواجهة الحديثة**. يتم إهمال الطرق التي تستخدم ‎`aspose.pydrawing.Image` و ‎`aspose.pydrawing.Bitmap` وسيتم استبدالها بنظيراتها في الواجهة الحديثة. كما يتم إهمال الطرق التي تستخدم ‎`aspose.pydrawing.Graphics`، وسيتم حذف الدعم لها من الواجهة العامة.

من المقرر إزالة الواجهة المتقادمة التي تعتمد على ‎`aspose.pydrawing` في الإصدار **24.8**.

## **الواجهة الحديثة**

تمت إضافة الفئات والتعدادات التالية إلى الواجهة العامة:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — تمثل صورة نقطية أو متجهة.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — تمثل تنسيق ملف الصورة.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — توفر طرقاً لإنشاء والعمل مع ‎`IImage`.

سيناريو الاستخدام النموذجي للواجهة الجديدة يبدو كالتالي:

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

لتسهيل الانتقال، تعكس الواجهة الجديدة ‎`IImage` واجهات الـ `Image` و `Bitmap` المنفصلة. في معظم الحالات، كل ما عليك هو استبدال الاستدعاءات للطرق التي تستخدم ‎`aspose.pydrawing` بنظيراتها في الواجهة الحديثة.

### **الحصول على صورة مصغرة للشريحة**

**الواجهة المتقادمة:**

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

### **الحصول على صورة مصغرة للشكل**

**الواجهة المتقادمة:**

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

### **الحصول على صورة مصغرة للعرض**

**الواجهة المتقادمة:**

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

**الواجهة المتقادمة:**

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

## **الطرق والخصائص التي سيتم إزالتها واستبدالاتها الحديثة**

### **فئة Presentation**

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

### **فئة Slide**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|سيتم حذفه بالكامل|
|render_to_graphics(options, graphics, scale_x, scale_y)|سيتم حذفه بالكامل|
|render_to_graphics(options, graphics, rendering_size)|سيتم حذفه بالكامل|

### **فئة Shape**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **فئة ImageCollection**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **فئة PPImage**

|توقيع الطريقة/الخاصية|توقيع طريقة/خاصية الاستبدال|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **فئة ImageWrapperFactory**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **فئة PatternFormat**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **فئة IPatternFormatEffectiveData**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **فئة Output**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **سيتوقف دعم أسلوب aspose.pydrawing.Graphics**

الطرق التي تستخدم ‎`aspose.pydrawing.Graphics` تم إهمالها؛ سيُزيل الدعم لها من الواجهة العامة.

الأعضاء الذين يعتمدون على ‎`aspose.pydrawing.Graphics` وسيتم إزالتهم هم:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **الأسئلة المتكررة**

**لماذا تم إلغاء ‎aspose.pydrawing.Graphics؟**

يتم حذف الدعم لـ Graphics من الواجهة العامة لتوحيد العمل مع عمليات التصيير والصور، وإزالة الاعتماد على مكوّنات خاصة بالمنصات، والانتقال إلى نهج متعدد المنصات مع ‎[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). سيتم حذف جميع أساليب التصيير إلى Graphics.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

توحد ‎[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) العمل مع كل من الصور النقطية والمتجهة، وتبسّط الحفظ بصيغ مختلفة عبر ‎[ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وتقلل الاعتماد على pydrawing، وتجعل الكود أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من ‎`get_thumbnail` إلى ‎`get_image` لا يفاقم الأداء؛ الطرق الجديدة توفر نفس الإمكانيات لإنتاج الصور مع خيارات وأحجام مختلفة، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان الفعلي يعتمد على السيناريو، لكن من الناحية الوظيفية البدائل متساوية.