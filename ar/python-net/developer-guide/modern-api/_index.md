---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 280
url: /ar/python-net/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- رسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- Python
- Aspose.Slides
description: "قم بتحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات المتقادمة للصور بواجهة برمجة التطبيقات الحديثة للبايثون لتحقيق أتمتة سلسة لعروض PowerPoint ومستندات OpenDocument."
---

## **المقدمة**

يعتمد Aspose.Slides for Python API العام حاليًا على الأنواع التالية من `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتبارًا من الإصدار 24.4، تم **إهمال** هذا API العام بسبب [التغييرات](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) في Aspose.Slides for Python API العام.

لإزالة `aspose.pydrawing` من الـ API العام، قدمنا **الـ API الحديث**. الأساليب التي تستخدم `aspose.pydrawing.Image` و`aspose.pydrawing.Bitmap` قد تم إهمالها وسيتم استبدالها بنظيراتها في الـ API الحديث. الأساليب التي تستخدم `aspose.pydrawing.Graphics` قد تم إهمالها، وسيُزال الدعم لها من الـ API العام.

من المخطط إزالة الـ API المُهمَل الذي يعتمد على `aspose.pydrawing` في الإصدار **24.8**.

## **الـ API الحديث**

تمت إضافة الفئات والعدادات التالية إلى الـ API العام:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — تمثّل صورة نقطية أو متجهة.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — تمثّل صيغة ملف الصورة.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — توفر أساليب لإنشاء والعمل مع `IImage`.

سيناريو الاستخدام النموذجي للـ API الجديد هو كما يلي:
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


## **استبدال الكود القديم بالـ API الحديث**

للتسهيل في الانتقال، يطابق واجهة `IImage` الجديدة الـ API المنفصل للفئات `Image` و`Bitmap`. في معظم الحالات، كل ما عليك هو استبدال الاستدعاءات التي تستخدم `aspose.pydrawing` بنظيراتها في الـ API الحديث.

### **الحصول على صورة مصغرة للشريحة**

**الـ API المُهمَل:**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```


**الـ API الحديث:**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```


### **الحصول على صورة مصغرة للشكل**

**الـ API المُهمَل:**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```


**الـ API الحديث:**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```


### **الحصول على صورة مصغرة للعرض التقديمي**

**الـ API المُهمَل:**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```


**الـ API الحديث:**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


### **إضافة صورة إلى عرض تقديمي**

**الـ API المُهمَل:**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```


**الـ API الحديث:**
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```


## **الطرق والخصائص التي سيتم إزالتها واستبدالاتها في الـ API الحديث**

### **فئة Presentation**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|سيتم حذفها تمامًا|
|save(fname, format, options, response, show_inline)|سيتم حذفها تمامًا|
|print()|سيتم حذفها تمامًا|
|print(printer_settings)|سيتم حذفها تمامًا|
|print(printer_name)|سيتم حذفها تمامًا|
|print(printer_settings, pres_name)|سيتم حذفها تمامًا|

### **فئة Slide**

|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|سيتم حذفها تمامًا|
|render_to_graphics(options, graphics, scale_x, scale_y)|سيتم حذفها تمامًا|
|render_to_graphics(options, graphics, rendering_size)|سيتم حذفها تمامًا|

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

## **ستتوقف دعم الـ API لـ aspose.pydrawing.Graphics**

الأساليب التي تستخدم `aspose.pydrawing.Graphics` قد تم إهمالها؛ سيتم إزالة الدعم لها من الـ API العام.

الأعضاء الذين يعتمدون على `aspose.pydrawing.Graphics` وسيتم إزالتهم يشملون:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **الأسئلة الشائعة**

**لماذا تم إلغاء `aspose.pydrawing.Graphics`؟**

يتم إزالة دعم Graphics من الـ API العام لتوحيد العمل مع التصيير والصور، وإلغاء الاعتماد على مكونات خاصة بالمنصة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). سيتم حذف جميع الأساليب التي تُصوّر إلى Graphics.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) يوحّد العمل مع الصور النقطية والمتجهة، يبسط حفظ الصور بصيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، يقلل الاعتماد على pydrawing، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل سيؤثر الـ API الحديث على أداء إنشاء الصور المصغرة؟**

التحول من `get_thumbnail` إلى `get_image` لا يفاقم السيناريوهات: توفر الأساليب الجديدة نفس الإمكانيات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الكسب أو الفقدان المحدد يعتمد على السيناريو، لكن وظائفياً التعويضات متكافئة.