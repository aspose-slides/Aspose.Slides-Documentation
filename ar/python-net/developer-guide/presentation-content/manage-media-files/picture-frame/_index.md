---
title: إضافة إطارات صور إلى العروض التقديمية باستخدام بايثون
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-net/developer-guide/presentation-content/manage-media-files/picture-frame/
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
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. بسط سير عملك وحسّن تصاميم الشرائح."
---

## **نظرة عامة**

تتيح إطارات الصور في Aspose.Slides لبايثون وضع وإدارة الصور النقطية والمتجهة كأشكال شريحة أصلية. يمكنك إدراج الصور من ملفات أو تدفقات، وتحديد موقعها وتغيير حجمها باستخدام إحداثيات دقيقة، وتطبيق دوران، وتعيين الشفافية، والتحكم في ترتيب Z إلى جانب الأشكال الأخرى. كما يدعم الـ API قص الصور، والمحافظة على نسب الأبعاد، وتعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون الحاجة إلى إعادة بناء التخطيط. وبما أن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة حركات، وروابط تشعبية، ونص بديل، مما يجعل إنشاء عروض بصرية غنية وسهلة الوصول أمرًا مباشرًا.

## **إنشاء إطارات صور**

توضح هذه الفقرة كيفية إدراج صورة في شريحة عن طريق إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides لبايثون. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) للعرض. ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بالحجم المحدد باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. حفظ العرض كملف PPTX.

الكود التالي بلغة بايثون يُظهر كيفية إنشاء إطار صورة:

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

تتيح إطارات الصور إنشاء شرائح عرض بسرعة من الصور. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: التحويل إلى [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); التحويل من [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); التحويل من [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); التحويل من [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); التحويل من [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); التحويل من [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطارات صور بمقياس نسبي**

توضح هذه الفقرة وضع صورة بحجم ثابت، ثم تطبيق مقياس نسبي قائم على النسبة المئوية لكل من العرض والارتفاع بشكل مستقل. لأن النسب قد تختلف، يمكن أن تتغير نسبة العرض إلى الارتفاع. يتم تطبيق المقياس نسبةً إلى أبعاد الصورة الأصلية.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
4. إضافة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. ضبط العرض والارتفاع النسبيين لإطار الصورة.
6. حفظ العرض كملف PPTX.

الكود التالي بلغة بايثون يُظهر كيفية إنشاء إطار صورة بمقياس نسبي:

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

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح المثال التالي كيف يتم استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، يتيح Aspose.Slides لبايثون عبر .NET استرجاع الصور المتجهة الأصلية بجودة كاملة. عبر استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame]، والتحقق ما إذا كان [PPImage] الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة على القرص أو في تدفق بصيغتها الأصلية SVG.

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

يتيح Aspose.Slides استخراج تأثير الشفافية المطبق على صورة. يوضح الكود التالي عملية استخراج قيمة الشفافية:

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

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهرسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/). ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) الخاصة بالشريحة.
6. تعيين لون حدود إطار الصورة.
7. تعيين عرض حدود إطار الصورة.
8. تدوير إطار الصورة بتزويد قيمة موجبة (في اتجاه عقارب الساعة) أو سالبة (عكس اتجاه عقارب الساعة).
9. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح عملية تنسيق إطار الصورة:

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

قامت Aspose بتطوير أداة مجانية تُدعى [Collage Maker](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صور كروابط**

للحفاظ على حجم ملفات العروض صغيرًا، يمكنك إضافة صور أو فيديوهات عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح الكود التالي كيفية إدراج صورة وفيديو في عنصر نائب:

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

في هذا القسم، ستتعلم كيفية قص المنطقة الظاهرة من صورة داخل إطار صورة دون تعديل الملف الأصلي. ستتعلم أيضًا الطريقة الأساسية لتطبيق هوامش القص لإنشاء تركيبة نظيفة ومركزة مباشرة على الشريحة.

الكود التالي يوضح كيفية قص صورة على شريحة:

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

## **حذف المناطق المقتصة من الصور**

إذا رغبت في حذف المناطق المقتصة من صورة في إطار، استخدم طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). تُعيد هذه الطريقة الصورة المقتصة، أو الصورة الأصلية إذا لم يكن هناك قص.

الكود التالي يوضح العملية:

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

تضيف طريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) الصورة المقتصة إلى مجموعة صور العرض. إذا استُخدمت الصورة فقط في [PictureFrame] المعالج، قد يقل حجم العرض؛ وإلا قد يزيد عدد الصور في العرض الناتج.

خلال عملية القص، تُحوِّل هذه الطريقة ملفات WMF/EMF إلى صورة نقطية PNG.

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا أردت أن يحتفظ الشكل المحتوي على صورة بنسبة عرض إلى ارتفاع ثابتة بعد تعديل أبعاد الصورة، اضبط الخاصية [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) على `True`.

الكود التالي يوضح كيفية قفل نسبة العرض إلى الارتفاع للشكل:

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

إعداد *قفل نسبة العرض إلى الارتفاع* يحافظ فقط على نسبة الشكل، وليس نسبة الصورة داخل الشكل.

{{% /alert %}}

## **استخدام خصائص إزاحة التمدد**

باستخدام الخصائص `stretch_offset_left`، `stretch_offset_top`، `stretch_offset_right` و `stretch_offset_bottom` لفئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل ملء.

عند تحديد التمدد لصورة، يتم تحجيم المستطيل المصدر لملاءمة مستطيل الملء. كل جانب من جوانب مستطيل الملء يُعرَّف بنسبة إزاحة من الجانب المقابل لمستطيل حد الشكل. النسبة الموجبة تُشير إلى تقليل، بينما النسبة السالبة تُشير إلى توسيع.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع لشريحة بواسطة فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيل.
4. تعيين نوع ملء الشكل.
5. تعيين نمط ملء الصورة للشكل.
6. تحميل صورة.
7. ربط الصورة بملء الشكل.
8. تحديد إزاحات الصورة من الجوانب المقابلة لمستطيل حد الشكل.
9. حفظ العرض كملف PPTX.

الكود التالي يوضح كيفية استخدام خصائص إزاحة التمدد:

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

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}}

## **الأسئلة المتكررة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المربوط بـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). قائمة الصيغ المدعومة تتقاطع عادةً مع قدرات محرك التحويل للشرائح والصور.

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم وأداء PPTX؟**

تؤدي إضافة الصور الكبيرة كملفات مضمنة إلى زيادة حجم الملف واستهلاك الذاكرة؛ بينما تساعد الروابط في تقليل حجم العرض ولكنها تتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل عنصر الصورة لمنع تحريكه/تحجيمه غير المقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) لـ [PictureFrame] (مثلاً، تعطيل التحريك أو التحجيم). يُوصف آلية القفل للأشكال في مقالة [الحماية](/slides/ar/python-net/applying-protection-to-presentation/) وتدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame].

**هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame] كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو [صيغ نقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي حسب إعدادات التصدير؛ لكن الاحتفاظ بالمتجه الأصلي يتم التأكد منه عبر سلوك الاستخراج.