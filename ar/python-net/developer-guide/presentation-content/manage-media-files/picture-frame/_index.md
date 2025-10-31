---
title: إضافة إطارات الصور إلى العروض التقديمية باستخدام بايثون
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-net/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهية
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
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides لبايثون عبر .NET. بسط سير العمل الخاص بك وحسّن تصاميم الشرائح."
---

## **نظرة عامة**

تتيح لك إطارات الصور في Aspose.Slides لبايثون وضع وإدارة الصور النقطية والمتجهية كأشكال شريحة أصلية. يمكنك إدراج الصور من الملفات أو التيارات، وتحديد موضعها وتغيير حجمها بإحداثيات دقيقة، وتطبيق الدوران، وتعيين الشفافية، والتحكم في ترتيب Z جنبًا إلى جنب مع الأشكال الأخرى. تدعم واجهة برمجة التطبيقات أيضًا القص، والحفاظ على نسب الأبعاد، وتعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. نظرًا لأن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة والارتباطات التشعبية ونص بديل، مما يجعل بناء عروض تقديمية غنية بصريًا ومتاحة أمرًا سهلًا.

## **إنشاء إطارات الصور**

يُظهر هذا القسم كيفية إدراج صورة في شريحة بإنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides لبايثون. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرستها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي. ستُستَخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. حفظ العرض التقديمي كملف PPTX.

الكود التالي بايثون يوضح كيفية إنشاء إطار صورة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة بحجم الصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # حفظ العرض التقديمي كملف PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

تسمح إطارات الصور لك بإنشاء شرائح عرض تقديمي بسرعة من الصور. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); تحويل [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); تحويل [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطارات الصور مع المقياس النسبي**

يعرض هذا القسم وضع صورة بحجم ثابت، ثم تطبيق مقياس نسبي قائم على النسب المئوية للعرض والارتفاع بشكل مستقل. بما أن النسب قد تختلف، قد تتغير نسبة الأبعاد. يتم تنفيذ المقياس نسبةً إلى أبعاد الصورة الأصلية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرستها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي.
4. إضافة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. تعيين العرض والارتفاع النسبيين لإطار الصورة.
6. حفظ العرض التقديمي كملف PPTX.

الكود التالي يوضح كيفية إنشاء إطار صورة مع مقياس نسبي:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة إلى الشريحة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # تعيين عرض وارتفاع المقياس النسبي.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # حفظ العرض التقديمي.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج صور نقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها بصيغة PNG أو JPG وغيرها. يوضح المثال أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عندما يحتوي عرض تقديمي على رسومات SVG موجودة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، يتيح Aspose.Slides لبايثون عبر .NET استرداد الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة الأشكال في الشريحة، يمكنك تحديد كل [PictureFrame]، والتحقق مما إذا كان [PPImage] يحمل محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

الكود التالي يوضح كيفية استخراج صورة SVG من إطار صورة:

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

يوفر Aspose.Slides إمكانية استرجاع تأثير الشفافية المطبق على الصورة. يوضح الكود بايثون التالي العملية:

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
يمكن العثور على جميع التأثيرات المطبقة على الصور في [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لتلبية المتطلبات المحددة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرستها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي. ستُستَخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) الخاصة بالشريحة.
6. تعيين لون خط إطار الصورة.
7. تعيين عرض خط إطار الصورة.
8. تدوير إطار الصورة بتوفير قيمة موجبة (عقارب الساعة) أو سالبة (عكس عقارب الساعة).
9. حفظ العرض التقديمي المعدل كملف PPTX.

الكود التالي يوضح عملية تنسيق إطار الصورة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة بحجم الصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # تطبيق تنسيق على إطار الصورة.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

طوَّر Aspose أداة مجانية تسمى [Collage Maker](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات صور، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صور كروابط**

للحفاظ على حجم ملفات العرض التقديمي صغيرًا، يمكنك إضافة صور أو مقاطع فيديو عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح الكود بايثون التالي كيفية إدراج صورة وفيديو في عنصر نائب:

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

في هذا القسم، ستتعلم كيفية قص المنطقة المرئية من صورة داخل إطار صورة دون تعديل الملف المصدر. ستتعلم أيضًا الأسلوب الأساسي لتطبيق هوامش القص لإنشاء تركيبة نظيفة ومركزة مباشرةً على الشريحة.

الكود التالي يوضح كيفية قص صورة على شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة صور العرض التقديمي.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # إضافة إطار صورة إلى الشريحة.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # قص الصورة (قِيَم النسبة المئوية).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # حفظ النتيجة.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف المناطق المقصوصة من الصور**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة داخل إطار، استخدم طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). تُعيد هذه الطريقة الصورة المقطوعة، أو الصورة الأصلية إذا لم تكن هناك حاجة للقص.

الكود التالي يوضح العملية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # الحصول على إطار الصورة من الشريحة الأولى.
    picture_frame = slides.shape[0]

    # الحصول على إطار الصورة من الشريحة الأولى.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # حفظ النتيجة.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) تُضيف الصورة المقطوعة إلى مجموعة صور العرض التقديمي. إذا استُخدمت الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) المُعالجة، يمكن أن يقلل ذلك من حجم العرض؛ وإلا قد يزداد عدد الصور في العرض الناتج.

أثناء القص، تُحوِّل هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل المحتوي على صورة بنسبة أبعادها بعد تغيير أبعاد الصورة، عيّن خاصية [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) إلى `True`.

الكود التالي يوضح كيفية قفل نسبة الأبعاد للشكل:

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

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل، وليس على نسبة أبعاد الصورة داخله.

{{% /alert %}}

## **استخدام خصائص إزاحة التمدد**

باستخدام خصائص `stretch_offset_left` و `stretch_offset_top` و `stretch_offset_right` و `stretch_offset_bottom` لفئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل تعبئة.

عند تحديد تمدد للصورة، يتم تحجيم المستطيل المصدر لملء مستطيل التعبئة. كل حافة من حواف مستطيل التعبئة تُحدَّد بنسبة مئوية من الحافة المقابلة لصندوق حد الشكل. النسبة المئوية الموجبة تُحدِّد تقليلًا داخليًا، والنسبة السالبة تُحدِّد تمددًا خارجيًا.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر فهرستها.
3. إضافة شكل [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيل.
4. تعيين نوع تعبئة الشكل.
5. تعيين وضع تعبئة صورة الشكل.
6. تحميل صورة.
7. ربط الصورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الحواف المقابلة لصندوق حد الشكل.
9. حفظ العرض التقديمي كملف PPTX.

الكود التالي يوضح كيفية استخدام خصائص إزاحة التمدد:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة AutoShape مستطيلة.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # تعيين نوع تعبئة الشكل.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تعيين وضع تعبئة الصورة للشكل.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة وإضافتها إلى العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # ربط الصورة لتعبئة الشكل.
    shape.fill_format.picture_fill_format.picture.image = image

    # تحديد إزاحات الصورة من الحواف المقابلة لمربع حدود الشكل.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # حفظ ملف PPTX على القرص.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكنك من إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهية (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

زيادة حجم الصور المدمجة يزيد من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة من التحريك/تغيير الحجم غير المقصود؟**

استخدم [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) لـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (مثلًا، تعطيل التحريك أو تغيير الحجم). تم توضيح آلية القفل للأشكال في مقالة حماية منفصلة [/slides/python-net/applying-protection-to-presentation/] وتدعم أنواعًا متعددة من الأشكال، بما فيها [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، قد يتم تحويل النتيجة إلى نقطية اعتمادًا على إعدادات التصدير؛ ومع ذلك، يظل SVG الأصلي مخزنًا كمتجه كما يثبت سلوك الاستخراج.