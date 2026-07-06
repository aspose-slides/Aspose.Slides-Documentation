---
title: إضافة إطارات الصور إلى العروض التقديمية باستخدام Python
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-net/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. سهل سير العمل وحسّن تصاميم الشرائح."
---
## **مقدمة**

إطارات الصور في Aspose.Slides for Python تتيح لك وضع وإدارة الصور النقطية والمتجهة كأشكال شريحة أصلية. يمكنك إدراج الصور من الملفات أو التيارات، وتحديد موضعها وتغيير حجمها باستخدام إحداثيات دقيقة، وتطبيق الدوران، وضبط الشفافية، والتحكم في ترتيب z إلى جانب الأشكال الأخرى. يدعم API أيضًا القص، والحفاظ على نسب الأبعاد، وتعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. نظرًا لأن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة، والروابط التشعبية، والنص البديل، مما يجعل بناء عروض تقديمية غنية بصريًا ومتاحة سهلًا.

## **إنشاء إطارات الصور**

يعرض هذا القسم كيفية إدراج صورة في شريحة عن طريق إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides for Python. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة وفقًا لمؤشرها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) الخاص بالعرض. ستُستخدم هذه الصورة لتعبئة الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. حفظ العرض كملف PPTX.

تظهر الشفرة البرمجية Python التالية كيفية إنشاء إطار صورة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى العرض.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة بالحجم المناسب للصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # حفظ العرض كملف PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
تتيح لك إطارات الصور إنشاء شرائح عرض بسرعة من الصور. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-png/); تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-svg/); تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **إنشاء إطارات الصور مع مقياس نسبي**

يوضح هذا القسم وضع صورة بحجم ثابت، ثم تطبيق مقياس يعتمد على النسبة المئوية بشكل مستقل على العرض والارتفاع. نظرًا لاختلاف النسب، قد يتغير نسبة الأبعاد. يتم إجراء التحجيم نسبةً إلى أبعاد الصورة الأصلية.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة وفقًا لمؤشرها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) الخاص بالعرض.
4. إضافة [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. تعيين العرض والارتفاع النسبيين لإطار الصورة.
6. حفظ العرض كملف PPTX.

تظهر الشفرة البرمجية Python التالية كيفية إنشاء إطار صورة مع مقياس نسبي:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة إلى الشريحة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # تعيين العرض والارتفاع بالنسبة المئوية النسبية.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # حفظ العرض.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) وحفظها بتنسيقات PNG أو JPG أو غيرها. يوضح مثال الشفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بتنسيق PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **استخراج صور SVG من إطارات الصور**

عند احتواء عرض على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/)، يسمح Aspose.Slides for Python عبر .NET باسترجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

تظهر الشفرة البرمجية التالية كيفية استخراج صورة SVG من إطار صورة:

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

## **الحصول على شفافية الصورة**

يسمح Aspose.Slides لك باسترجاع تأثير الشفافية المطبق على صورة. يوضح الكود Python التالي العملية:

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
جميع التأثيرات المطبقة على الصور يمكن العثور عليها في [aspose.slides.effects](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/).
{{% /alert %}}

## **الحصول على سطوع وتباين الصورة**

يسمح Aspose.Slides لك باسترجاع تأثير السطوع والتباين المطبق على صورة. تمثل الفئة [Luminance](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/luminance/) هذا التأثير على الصورة.

يظهر الكود Python التالي كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

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

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار صورة لتلبية متطلبات محددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة وفقًا لمؤشرها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) الخاص بالعرض. ستُستخدم هذه الصورة لتعبئة الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/) الخاصة بالشريحة.
6. ضبط لون خط إطار الصورة.
7. ضبط عرض خط إطار الصورة.
8. تدوير إطار الصورة بتوفير قيمة موجبة (في اتجاه عقارب الساعة) أو سالبة (عكس اتجاه عقارب الساعة).
9. حفظ العرض المعدل كملف PPTX.

تظهر الشفرة البرمجية Python التالية عملية تنسيق إطار صورة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة بالحجم المناسب للصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # تطبيق التنسيق على إطار الصورة.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # حفظ العرض كملف PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
قامت Aspose بتطوير أداة مجانية تسمى [Collage Maker](https://products.aspose.app/slides/ar/collage). إذا كنت بحاجة إلى [دمج JPG/JPEG](https://products.aspose.app/slides/ar/collage/jpg) أو صور PNG، أو [إنشاء شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، يمكنك استخدام هذه الخدمة.
{{% /alert %}}

## **إضافة صور كروابط**

للحفاظ على ملفات العرض بحجم صغير، يمكنك إضافة صور أو مقاطع فيديو عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح الكود Python التالي كيفية إدراج صورة وفيديو في عنصر نائب:

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

## **قص الصور**

في هذا القسم، ستتعلم كيفية قص المنطقة المرئية للصورة داخل إطار صورة دون تعديل الملف الأصلي. كما ستتعلم الطريقة الأساسية لتطبيق هوامش القص لإنشاء تركيبة نظيفة ومركزة مباشرةً على الشريحة.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # إضافة إطار صورة إلى الشريحة.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # قص الصورة (قيم النسبة المئوية).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # حفظ النتيجة.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف المناطق المقتطعة من الصور**

إذا رغبت في حذف المناطق المقتطعة من صورة داخل إطار، استخدم طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). تُعيد هذه الطريقة الصورة المقتطعة، أو الصورة الأصلية إذا لم يكن هناك قص ضروري.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # احصل على إطار الصورة من الشريحة الأولى.
    picture_frame = slides.shape[0]

    # احصل على إطار الصورة من الشريحة الأولى.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # احفظ النتيجة.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
تضيف طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) الصورة المقتطعة إلى مجموعة صور العرض. إذا استُخدمت الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) المعالجة، يمكن أن يقلل ذلك من حجم العرض؛ وإلا قد يزيد عدد الصور في العرض الناتج.

أثناء القص، تقوم هذه الطريقة بتحويل ملفات WMF/EMF إلى صورة PNG نقطية.
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض باستخدام طريقة [PictureFillFormat.compress_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/compress_image/). تقلل هذه الطريقة من حجم الصورة بناءً على حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقتطعة.

إنها تعدل حجم الصورة ودقتها بطريقة مماثلة لميزة **Picture Format -> Compress Pictures -> Resolution** في PowerPoint.

تُظهر أمثلة Python التالية كيفية ضغط صورة في عرض عن طريق تحديد دقة مستهدفة وحذف المناطق المقتطعة اختياريًا:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # التحقق من نتيجة الضغط.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

أو باستخدام قيمة DPI مخصصة مباشرة:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # ضغط الصورة إلى 150 DPI (دقة الويب)، مع إزالة المناطق المقصوصة.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقتطعة لتحسين حجم الملف.
إذا كانت الصورة ملفًا ميتا (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كذلك، يتم الحفاظ على جودة JPEG أو تقليلها قليلًا بناءً على الدقة، مماثلًا للطريقة التي يتعامل بها PowerPoint مع JPEG عالي الدقة.
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها بعد تغيير أبعاد الصورة، عيّن خاصية [aspect_ratio_locked](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) إلى `True`.

تُظهر الشفرة البرمجية Python التالية كيفية قفل نسبة أبعاد الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # قفل نسبة الأبعاد عند تغيير الحجم.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
إعداد *قفل نسبة الأبعاد* هذا يحافظ فقط على نسبة أبعاد الشكل، وليس نسبة أبعاد الصورة داخله.
{{% /alert %}}

## **استخدام خصائص إزاحة التمدد**

باستخدام خصائص `stretch_offset_left` و `stretch_offset_top` و `stretch_offset_right` و `stretch_offset_bottom` لفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل تعبئة.

عند تحديد تمدد لصورة، يتم تحجيم المستطيل المصدر ليناسب مستطيل التعبئة. كل حافة من حواف مستطيل التعبئة تُحدد بنسبة إزاحة من الحافة المقابلة لصندوق حدود الشكل. النسبة الموجبة تعني تقليل، بينما السلبية تعني توسيع.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة وفقًا لمؤشرها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة.
4. تعيين نوع تعبئة الشكل.
5. تعيين وضع تعبئة الصورة للشكل.
6. تحميل صورة.
7. إسناد الصورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الحواف المقابلة لمربع حدود الشكل.
9. حفظ العرض كملف PPTX.

تُظهر الشفرة البرمجية Python التالية كيفية استخدام خصائص إزاحة التمدد:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل AutoShape مستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # تعيين نوع تعبئة الشكل.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تعيين وضع تعبئة الصورة للشكل.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة وإضافتها إلى العرض.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # إسناد الصورة لتعبئة الشكل.
    shape.fill_format.picture_fill_format.picture.image = image

    # تحديد إزاحات الصورة من الحواف المقابلة لمربع حدود الشكل.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # حفظ ملف PPTX إلى القرص.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور.
{{% /alert %}}

## **FAQ**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (على سبيل المثال، SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/). القائمة العامة للصالات المدعومة تتقاطع عادةً مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم وأداء ملف PPTX؟**

زيادة تضمين الصور الكبيرة يزيد من حجم الملف واستخدام الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides القدرة على إضافة الصور عبر رابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره غير المقصود؟**

استخدم [shape locks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/picture_frame_lock/) لـ [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) (مثلاً، تعطيل التحريك أو تغيير الحجم). يُشرح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/python-net/applying-protection-to-presentation/) منفصلة وتُدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجه SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو [تنسيقات نقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطة اعتمادًا على إعدادات التصدير؛ لكن سلوك الاستخراج يؤكد أن SVG الأصلي يبقى متجهًا.