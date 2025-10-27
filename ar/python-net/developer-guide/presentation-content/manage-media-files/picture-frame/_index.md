---
title: إضافة إطارات صور إلى العروض التقديمية باستخدام Python
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
- نسبة العرض إلى الارتفاع
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint وعروض OpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. بسط سير العمل الخاص بك وعزز تصاميم الشرائح."
---

## **نظرة عامة**

تتيح إطارات الصور في Aspose.Slides للـ Python وضع وإدارة الصور النقطية والمتجهة كأشكال شرائح أصلية. يمكنك إدراج الصور من ملفات أو تدفقات، تحديد موضعها وتغيير حجمها باستخدام إحداثيات دقيقة، تطبيق دوران، ضبط الشفافية، والتحكم في ترتيب z إلى جانب الأشكال الأخرى. يدعم API أيضًا القص، الحفاظ على نسب العرض إلى الارتفاع، تعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. نظرًا لأن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة، الروابط التشعبية، ونص بديل، مما يجعل بناء عروض غنية بصريًا وسهلة الوصول أمرًا مباشرًا.

## **إنشاء إطارات صور**

يُظهر هذا القسم كيفية إدراج صورة في شريحة بإنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides للـ Python. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرسها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) للعرض التقديمي. ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وإرتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. حفظ العرض التقديمي كملف PPTX.

الكود التالي للـ Python يوضح كيفية إنشاء إطار صورة:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

تتيح إطارات الصور إنشاء شرائح عرض من الصور بسرعة. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); تحويل [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); تحويل [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطارات صور بمقياس نسبي**

يوضح هذا القسم وضع صورة بحجم ثابت، ثم تطبيق مقياس نسبي بنسبة مئوية على عرضها وارتفاعها بشكل مستقل. نظرًا لأن النسب قد تختلف، قد يتغيّر نسبة العرض إلى الارتفاع. يتم تنفيذ المقياس نسبةً إلى أبعاد الصورة الأصلية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرسها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
4. إضافة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. ضبط عرض وارتفاع الإطار النسبي.
6. حفظ العرض التقديمي كملف PPTX.

الكود التالي للـ Python يوضح كيفية إنشاء إطار صورة بمقياس نسبي:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها بصيغ PNG أو JPG وغيرها. يوضح المثال التالي كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عند احتواء عرض تقديمي على رسومات SVG داخل أشكال [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، يتيح Aspose.Slides للـ Python عبر .NET استرداد الصور المتجهة الأصلية بكامل دقتها. عبر استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame]، التحقق مما إذا كانت [PPImage] المرتبطة تحتوي على محتوى SVG، ثم حفظ تلك الصورة على القرص أو تدفق كملف SVG أصلي.

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

يتيح Aspose.Slides استرداد تأثير الشفافية المطبق على صورة. يوضح الكود التالي العملية:

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

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لتلبية المتطلبات المحددة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر فهرسها.
3. إنشاء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/). ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وإرتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. ضبط لون خط إطار الصورة.
7. ضبط عرض خط إطار الصورة.
8. تدوير إطار الصورة بقيمة موجبة (عقارب الساعة) أو سالبة (عقارب العكس).
9. حفظ العرض التقديمي المعدل كملف PPTX.

الكود التالي للـ Python يوضح عملية تنسيق إطار الصورة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

قامت Aspose بتطوير أداة مجانية [Collage Maker](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صور كروابط**

للحفاظ على حجم ملفات العرض التقديمي صغيرًا، يمكنك إضافة صور أو مقاطع فيديو عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح الكود التالي للـ Python كيفية إدراج صورة وفيديو في عنصر نائب:

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

في هذا القسم، ستتعلم كيفية قص المنطقة المرئية من صورة داخل إطار صورة دون تعديل ملف المصدر. ستتعلم أيضًا الطريقة الأساسية لتطبيق هوامش القص لإنشاء تركيبة نظيفة ومركَّزة مباشرةً على الشريحة.

الكود التالي للـ Python يوضح كيفية قص صورة على شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف مناطق القص من الصور**

إذا كنت تريد حذف مناطق القص من صورة في إطار، استخدم طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). تُعيد هذه الطريقة الصورة المقصوصة، أو الصورة الأصلية إذا لم يتطلب الأمر قصًا.

الكود التالي للـ Python يوضح العملية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) تُضيف الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا استُخدمت الصورة فقط في الـ [PictureFrame] المعالج، يمكن أن يقلل ذلك من حجم العرض؛ وإلا قد يزداد عدد الصور في العرض الناتج.

أثناء القص، تقوم هذه الطريقة بتحويل ملفات WMF/EMF إلى صورة PNG نقطية.

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا أردت أن تحتفظ شكل يحتوي صورة بنسبة عرض إلى ارتفاع ثابتة بعد تغيير أبعاد الصورة، اضبط الخاصية [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) إلى `True`.

الكود التالي للـ Python يوضح كيفية قفل نسبة عرض إلى ارتفاع الشكل:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

إعداد *قفل نسبة العرض إلى الارتفاع* يحافظ فقط على نسبة عرض إلى ارتفاع الشكل، وليس نسبة عرض إلى ارتفاع الصورة داخله.

{{% /alert %}}

## **استخدام خصائص إزاحة التمدد**

باستخدام الخصائص `stretch_offset_left` و `stretch_offset_top` و `stretch_offset_right` و `stretch_offset_bottom` من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل ملء.

عند تحديد تمدد لصورة، يتم تعديل مستطيل المصدر ليتناسب مع مستطيل الملء. كل حافة من حواف مستطيل الملء تُحدد بنسبة إزاحة من الحافة المقابلة لمستطيل إطارات الشكل. النسبة الموجبة تُشير إلى تقليص، والسالبة إلى توسعة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيل.
4. ضبط نوع ملء الشكل.
5. ضبط وضع ملء الصورة للشكل.
6. تحميل صورة.
7. تعيين الصورة لملء الشكل.
8. تحديد إزاحات الصورة من الحواف المقابلة لمستطيل إطارات الشكل.
9. حفظ العرض التقديمي كملف PPTX.

الكود التالي للـ Python يوضح كيفية استخدام خصائص إزاحة التمدد:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية من الصور بسرعة.

{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

يزيد إدراج صور كبيرة من حجم الملف واستهلاك الذاكرة؛ تساعد الروابط على تقليل حجم العرض التقديمي لكن تتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة صور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن صورة من التحريك/إعادة الحجم العرضية؟**

استخدم [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) لإطار صورة (مثل تعطيل التحريك أو إعادة الحجم). يوضح مقالة الحماية المستقلة [protection article](/slides/ar/python-net/applying-protection-to-presentation/) هذه الميزة وتدعمها أنواع شكل متعددة، بما فيها [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجه SVG عند تصدير العرض إلى PDF/صُور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame] كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو إلى صيغ نقطية [/slides/python-net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية وفقًا لإعدادات التصدير؛ لكن وجود SVG الأصلي كمتجه مؤكد بسلوك الاستخراج.