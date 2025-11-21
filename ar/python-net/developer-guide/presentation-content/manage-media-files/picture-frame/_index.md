---
title: إضافة إطارات الصور إلى العروض التقديمية باستخدام Python
linktitle: إطار صورة
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
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير صورة
- نسبة أبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة إطارات الصور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. سهل سير عملك وعزز تصاميم الشرائح."
---

## **نظرة عامة**

تسمح لك إطارات الصور في Aspose.Slides for Python بوضع وإدارة الصور النقطية والمتجهة كأشكال شريحة أصلية. يمكنك إدراج الصور من الملفات أو التدفقات، وتحديد موضعها وتغيير حجمها باستخدام إحداثيات دقيقة، وتطبيق الدوران، وتعيين الشفافية، والتحكم في ترتيب z إلى جانب الأشكال الأخرى. يدعم API أيضًا القص، والحفاظ على نسب الأبعاد، وتعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. نظرًا لأن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة والارتباطات التشعبية والنص البديل، مما يجعل بناء عروض تقديمية غنية بصريًا وسهلة الوصول أمرًا بسيطًا.

## **إنشاء إطارات الصور**

يوضح هذا القسم كيفية إدراج صورة في شريحة عن طريق إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides for Python. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي. ستُستخدم هذه الصورة لملء الشكل.
4. حدد عرض الإطار وارتفاعه.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # احصل على الشريحة الأولى.
    slide = presentation.slides[0]

    # أضف الصورة إلى العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # أضف إطار صورة بحجم الصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # احفظ العرض التقديمي كملف PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" %}}
تسمح لك إطارات الصور بإنشاء شرائح عرض تقديمي بسرعة من الصور. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في الاطلاع على هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); تحويل [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); تحويل [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **إنشاء إطارات صور بمقياس نسبي**

يوضح هذا القسم وضع صورة بحجم ثابت، ثم تطبيق تحجيم بنسب مئوية بشكل مستقل على عرضها وارتفاعها. نظرًا لأن النسب قد تختلف، قد تتغير نسبة الأبعاد. يتم تنفيذ التحجيم نسبةً لأبعاد الصورة الأصلية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
4. إضافة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. تحديد العرض والارتفاع النسبيين لإطار الصورة.
6. احفظ العرض التقديمي كملف PPTX.

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

        # ضبط العرض والارتفاع بالنسبة النسبية.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # حفظ العرض التقديمي.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```


## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها بصيغ PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for Python via .NET استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك التعرف على كل [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، والتحقق ما إذا كان كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) المتضمن يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو تدفق بصيغة SVG الأصلية.

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

يتيح لك Aspose.Slides استرجاع تأثير الشفافية المطبق على صورة. يوضح الكود التالي العملية في Python:
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
جميع التأثيرات المطبقة على الصور يمكن العثور عليها في [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لتلبية المتطلبات المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/). ستُستخدم هذه الصورة لملء الشكل.
4. حدد عرض الإطار وارتفاعه.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) الخاصة بالشريحة.
6. تعيين لون خط إطار الصورة.
7. تعيين عرض خط إطار الصورة.
8. تدوير إطار الصورة بتوفير قيمة موجبة (عقارب الساعة) أو سالبة (عكس عقارب الساعة).
9. احفظ العرض التقديمي المعدل كملف PPTX.

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
طورت Aspose أداة مجانية تُدعى [Collage Maker](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.
{{% /alert %}}

## **إضافة الصور كروابط**

للحفاظ على حجم ملفات العرض التقديمي صغيرًا، يمكنك إضافة الصور أو مقاطع الفيديو عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح الكود التالي كيفية إدراج صورة وفيديو في عنصر نائب:
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

في هذا القسم، ستتعلم كيفية قص المنطقة المرئية من صورة داخل إطار صورة دون تعديل ملف المصدر. ستتعلم أيضًا الطريقة الأساسية لتطبيق هوامش القص لإنشاء تركيبة نظيفة ومركزة مباشرة على الشريحة.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
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


## **حذف المناطق المقصوصة من الصور**

إذا أردت حذف المناطق المقصوصة من صورة في إطار، استخدم طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). تُعيد هذه الطريقة الصورة المقصوصة، أو الصورة الأصلية إذا لم يكن هناك قص مطلوب.

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
تضيف طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) المُعالجة، يمكن أن يقلل ذلك من حجم العرض؛ وإلا قد يزداد عدد الصور في العرض الناتج.

أثناء القص، تقوم هذه الطريقة بتحويل ملفات WMF/EMF الميتافايل إلى صورة PNG نقطية.
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده بعد تغيير أبعاد الصورة، عيّن الخاصية [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) إلى `True`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # قفل نسبة الأبعاد عند إعادة التحجيم.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل، لا على نسبة أبعاد الصورة داخل الشكل.
{{% /alert %}}

## **استخدام خصائص إزاحة التمدد**

باستخدام خصائص `stretch_offset_left` و`stretch_offset_top` و`stretch_offset_right` و`stretch_offset_bottom` من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل ملء.

عند تحديد تمدد لصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل الملء. كل حد من حدود مستطيل الملء يُحدد بنسبة إزاحة من الحد المقابل لصندوق حدود الشكل. النسبة الموجبة تُشير إلى تقليل، بينما النسبة السالبة تُشير إلى زيادة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيل.
4. تعيين نوع ملء الشكل.
5. تعيين وضع ملء صورة الشكل.
6. تحميل صورة.
7. إسناد الصورة لملء الشكل.
8. تحديد إزاحات الصورة من الحدود المقابلة لصندوق حدود الشكل.
9. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي مستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # تعيين نوع ملء الشكل.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تعيين وضع ملء الصورة للشكل.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة وإضافتها إلى العرض التقديمي.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # إسناد الصورة لملء الشكل.
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
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور.
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لـ PictureFrame؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). عادةً ما تتداخل قائمة التنسيقات المدعومة مع إمكانيات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم PPTX والأداء؟**

تؤدي عملية تضمين صور كبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ يساعد ربط الصور على تقليل حجم العرض التقديمي ولكن يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية ربط الصور لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغيير حجمه عن طريق الخطأ؟**

استخدم [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) لـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (مثلاً، تعطيل التحريك أو تغيير الحجم). تم شرح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/python-net/applying-protection-to-presentation/) وتدعم أنواعًا مختلفة من الأشكال، بما فيها [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجه SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو إلى [الصيغ النقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطة اعتمادًا على إعدادات التصدير؛ لكن وجود SVG الأصلي كمتجه يتم تأكيده بسلوك الاستخراج.