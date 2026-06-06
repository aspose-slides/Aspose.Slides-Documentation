---
title: تعزيز معالجة الصور باستخدام الواجهة البرمجية الحديثة
linktitle: الواجهة البرمجية الحديثة
type: docs
weight: 280
url: /ar/python-net/modern-api/
keywords:
- الواجهة البرمجية الحديثة
- الرسم
- صورة مصغرة للشرحة
- شريحة إلى صورة
- صورة مصغرة للشكل
- شكل إلى صورة
- صورة مصغرة للعرض التقديمي
- عرض تقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Python
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عبر استبدال واجهات برمجة التطبيقات التصويرية المهجورة بواجهة برمجة التطبيقات الحديثة للغة بايثون، لتحقيق أتمتة سلسة لعروض PowerPoint وOpenDocument."
---
## **مقدمة**

يعتمد Aspose.Slides for Python API العام حاليًا على الأنواع التالية في `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

اعتبارًا من الإصدار 24.4، تم **إهمال** هذا API العام بسبب [التغييرات](https://releases.aspose.com/slides/ar/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) في Aspose.Slides for Python API العام.

للتخلص من `aspose.pydrawing` في API العام، قدمنا **الواجهة البرمجية الحديثة**. الطرق التي تستخدم `aspose.pydrawing.Image` و`aspose.pydrawing.Bitmap` مهجورة ويجب استبدالها بنظيراتها في الواجهة الحديثة. الطرق التي تستخدم `aspose.pydrawing.Graphics` مهجورة ولا توجد لها بديلة مباشرة في الواجهة الحديثة.

في الإصدارات الحالية، عُد الـ API العام الذي يعتمد على `aspose.pydrawing` إلى الكود القديم/المهجور. استخدم الواجهة الحديثة في الكود الجديد وعند ترحيل سير عمل معالجة الصور الحالي.

## **الواجهة البرمجية الحديثة**

تمت إضافة الفئات والعدد الثابتة التالية إلى الـ API العام:

- [aspose.slides.IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) - يمثل صورة نقطية أو متجهية.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imageformat/) - يمثل تنسيق ملف صورة.
- [aspose.slides.Images](https://reference.aspose.com/slides/ar/python-net/aspose.slides/images/) - يوفر طرقًا لإنشاء والعمل مع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/).

استخدم `get_image` لتصوير شريحة أو شكل واحد. استخدم `get_images` لتصوير عدة شرائح من العرض التقديمي. استخدم [Images](https://reference.aspose.com/slides/ar/python-net/aspose.slides/images/) لتحميل الصور، و`add_image` مع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و`replace_image` مع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) لتحديث صورة عرض تقديمي موجودة.

سيناريو الاستخدام النموذجي للواجهة البرمجية الجديدة يبدو هكذا:

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

## **استبدال الكود القديم بالواجهة البرمجية الحديثة**

لتسهيل الانتقال، تعكس الفئة الجديدة [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) واجهات برمجية منفصلة لـ `aspose.pydrawing.Image` و`aspose.pydrawing.Bitmap`. في معظم الحالات، تحتاج فقط إلى استبدال استدعاءات الطرق التي تستخدم `aspose.pydrawing` بنظيراتها في الواجهة الحديثة.

### **الحصول على صورة مصغرة للشريحة**

**الواجهة البرمجية القديمة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**الواجهة البرمجية الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **الحصول على صورة مصغرة للشكل**

**الواجهة البرمجية القديمة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**الواجهة البرمجية الحديثة:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **الحصول على صورة مصغرة للعرض التقديمي**

**الواجهة البرمجية القديمة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**الواجهة البرمجية الحديثة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **إضافة صورة إلى عرض تقديمي**

**الواجهة البرمجية القديمة:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**الواجهة البرمجية الحديثة:**

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

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|save(fname, format, options, response, show_inline)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|print()|لا يوجد استبدال للواجهة البرمجية الحديثة|
|print(printer_settings)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|print(printer_name)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|print(printer_settings, pres_name)|لا يوجد استبدال للواجهة البرمجية الحديثة|

### **فئة Slide**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|render_to_graphics(options, graphics, scale_x, scale_y)|لا يوجد استبدال للواجهة البرمجية الحديثة|
|render_to_graphics(options, graphics, rendering_size)|لا يوجد استبدال للواجهة البرمجية الحديثة|

### **فئة Shape**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **فئة ImageCollection**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **فئة PPImage**

|توقيع الطريقة/الخاصية|توقيع الطريقة/الخاصية البديلة|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/image/)|

### **فئة ImageWrapperFactory**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **فئة PatternFormat**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **فئة IPatternFormatEffectiveData**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **فئة Output**

|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **دعم API لـ aspose.pydrawing.Graphics**

الطرق التي تستخدم `aspose.pydrawing.Graphics` مهجورة ولا يوجد لها بديل مباشر في الواجهة الحديثة.

استخدم طرق تصيير الصور في الواجهة الحديثة بدلاً من الطرق التي تصيّر إلى `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **الأسئلة الشائعة**

**لماذا تم حذف `aspose.pydrawing.Graphics`؟**

تم إهمال دعم `aspose.pydrawing.Graphics` في الـ API العام لتوحيد العمل مع التصيير والصور، وإزالة الاعتماد على مكونات منصة معينة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/). استخدم `get_image` أو `get_images` بدلاً من التصيير إلى `aspose.pydrawing.Graphics`.

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) مقارنةً بـ `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`؟**

[IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) يوحد التعامل مع الصور النقطية والمتجهية، يبسط الحفظ إلى تنسيقات مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imageformat/)، يقلل الاعتماد على pydrawing، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة البرمجية الحديثة على أداء إنشاء الصور المصغرة؟**

الانتقال من `get_thumbnail` إلى `get_image` لا يضيف سلبيات في معظم السيناريوهات؛ الطرق الجديدة توفر نفس القدرات لإنشاء الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان الفعلي يعتمد على السيناريو، لكن وظائف الاستبدال متكافئة.