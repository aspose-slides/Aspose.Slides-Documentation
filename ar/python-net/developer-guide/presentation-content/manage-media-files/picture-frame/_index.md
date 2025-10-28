---
title: إضافة إطارات الصور إلى العروض التقديمية باستخدام بايثون
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
- اقتصاص صورة
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
description: إضافة إطارات الصور إلى عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides للبايثون عبر .NET. سَهل سير عملك وعزز تصاميم الشرائح.
---

## **نظرة عامة**

تسمح لك إطارات الصور في Aspose.Slides للبايثون بوضع وإدارة الصور النقطية والمتجهة كأشكال أصلية على الشرائح. يمكنك إدراج الصور من ملفات أو تدفقات، وتحديد موقعها وتغيير حجمها باستخدام إحداثيات دقيقة، وتطبيق الدوران، وتعيين الشفافية، والتحكم بترتيب Z إلى جانب الأشكال الأخرى. تدعم الـ API أيضًا الاقتصاص، الحفاظ على نسب الأبعاد، تعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. وبما أن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة، والارتباطات التشعبية، والنص البديل، مما يجعل من السهل إنشاء عروض تقديمية غنية بصريًا وسهلة الوصول.

## **إنشاء إطارات الصور**

يوضح هذا القسم كيفية إدراج صورة في شريحة عن طريق إنشاء [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides للبايثون. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على شريحة باستخدام فهرسها.
3. أنشئ كائنًا من نوع [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection] الخاصة بالعرض. ستُستخدم هذه الصورة لملء الشكل.
4. حدد عرض الإطار وارتفاعه.
5. أنشئ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. احفظ العرض التقديمي كملف PPTX.

الشفرة البرمجية التالية بلغة بايثون توضح كيفية إنشاء إطار صورة:

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

تتيح لك إطارات الصور إنشاء شرائح عرض بسرعة من الصور. عند دمج إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من صيغة إلى أخرى. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); تحويل [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); تحويل [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطارات الصور مع المقياس النسبي**

يوضح هذا القسم وضع صورة بحجم ثابت، ثم تطبيق مقياس نسبي يعتمد على النسبة المئوية للعرض والارتفاع بشكل مستقل. لأن النسب قد تختلف، يمكن أن تتغير نسبة الأبعاد. يتم إجراء المقياس نسبةً إلى أبعاد الصورة الأصلية.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على شريحة باستخدام فهرسها.
3. أنشئ كائنًا من نوع [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection] الخاصة بالعرض.
4. أضف [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. عيّن العرض والارتفاع النسبيين لإطار الصورة.
6. احفظ العرض التقديمي كملف PPTX.

الشفرة البرمجية التالية توضح كيفية إنشاء إطار صورة بمقياس نسبي:

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

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح المثال التالي كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **استخدام خصائص إزاحة التمدد**

باستخدام الخصائص `stretch_offset_left` و `stretch_offset_top` و `stretch_offset_right` و `stretch_offset_bottom` لفئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)، يمكنك تعريف مستطيل ملء.

عند تحديد تمدد لصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل الملء. يُعرّف كل حافة من حواف مستطيل الملء بإزاحة نسبية من الحافة المقابلة لمربع حدود الشكل. تُحدد النسبة المئوية الموجبة تقليلًا داخليًا، بينما تشير النسبة السلبية إلى توسيع خارجي.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع إلى شريحة باستخدام فهرسها.
3. أضف [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلًا.
4. عيّن نوع ملء الشكل.
5. عيّن وضع ملء الصورة للشكل.
6. حمّل صورة.
7. اسند الصورة لملء الشكل.
8. عيّن إزاحات الصورة من الحواف المقابلة لمربع حدود الشكل.
9. احفظ العرض التقديمي كملف PPTX.

الشفرة البرمجية التالية توضح كيفية استخدام خصائص إزاحة التمدد:

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

توفر Aspose محولات مجانية — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — تتيح لك إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تزيد الصور الكبيرة المضمّنة من حجم الملف واستخدام الذاكرة؛ يساعد ربط الصور في تقليل حجم العرض ولكن يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع التحريك/التغيير غير المقصود؟**

استخدم [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) لإطار الصورة (مثل تعطيل التحريك أو تغيير الحجم). توضح آلية القفل الأشكال في مقالة الحماية [المنفصلة](/slides/ar/python-net/applying-protection-to-presentation/) وتدعم أنواع الأشكال المتنوعة، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة رسومات SVG المتجهة عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، قد يتم تحويله إلى صورة نقطية بحسب إعدادات التصدير؛ يتم التأكد من بقاء الـ SVG كمتجه من خلال سلوك الاستخراج.