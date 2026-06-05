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
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Python عبر .NET. سَهِّل سير العمل الخاص بك وعزِّز تصاميم الشرائح."
---
## **المقدمة**

تسمح إطارات الصور في Aspose.Slides for Python بوضع وإدارة الصور النقطية والمتجهة كأشكال شريحة أصلية. يمكنك إدراج الصور من ملفات أو تدفقات، وتحديد موضعها وإعادة تحجيمها باستخدام إحداثيات دقيقة، وتطبيق الدوران، وضبط الشفافية، والتحكم في ترتيب الـ z إلى جانب الأشكال الأخرى. تدعم API أيضًا القص، والحفاظ على نسب الأبعاد، وتعيين الحدود والتأثيرات، واستبدال الصورة الأساسية دون إعادة بناء التخطيط. لأن إطارات الصور تتصرف كالأشكال العادية، يمكنك إضافة الرسوم المتحركة، والارتباطات التشعبية، والنص البديل، مما يجعل بناء عروض تقديمية بصريًا غنيًا ومتاحة بسهولة.

## **إنشاء إطارات صور**

توضح هذه الفقرة كيفية إدراج صورة في شريحة عن طريق إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) باستخدام Aspose.Slides for Python. ستتعلم كيفية تحميل الصورة، وضعها بدقة على الشريحة، والتحكم في حجمها وتنسيقها.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهارسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) الخاص بالعرض. ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. حفظ العرض كملف PPTX.

الكود التالي بلغة Python يوضح كيفية إنشاء إطار صورة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة الصورة إلى العرض.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # إضافة إطار صورة بحجم الصورة.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # حفظ العرض بصيغة PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
تسمح إطارات الصور بإنشاء شرائح عرض بسرعة من الصور. عندما تجمع إطارات الصور مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/ar/python-net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-png/); تحويل [PNG to JPG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-svg/); تحويل [SVG to PNG](https://products.aspose.com/slides/ar/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **إنشاء إطارات صور مع مقياس نسبي**

توضح هذه الفقرة وضع صورة بحجم ثابت، ثم تطبيق مقياس نسبي بناءً على النسبة المئوية للعرض والارتفاع بشكل مستقل. نظرًا لأن النسب قد تختلف، يمكن أن تتغير نسبة الأبعاد. يتم تنفيذ المقياس نسبةً إلى أبعاد الصورة الأصلية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهارسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/).
4. إضافة [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) إلى الشريحة.
5. ضبط العرض والارتفاع النسبيين لإطار الصورة.
6. حفظ العرض كملف PPTX.

الكود التالي بلغة Python يوضح كيفية إنشاء إطار صورة بمقياس نسبي:

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

        # ضبط العرض والارتفاع النسبيين للمقياس.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # حفظ العرض.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) وحفظها بصيغ PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/)، يتيح Aspose.Slides for Python عبر .NET استرداد الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة الأشكال في الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو تدفق في صيغتها الأصلية SVG.

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

يسمح Aspose.Slides لك باسترجاع تأثير الشفافية المطبق على صورة. يوضح الكود التالي بلغة Python العملية:

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
يمكن العثور على جميع التأثيرات المطبقة على الصور في [aspose.slides.effects](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/).
{{% /alert %}}

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لتلبية متطلبات معينة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على شريحة بواسطة فهارسها.
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) بإضافة الصورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/). ستُستخدم هذه الصورة لملء الشكل.
4. تحديد عرض وارتفاع الإطار.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) بهذا الحجم باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/) الخاصة بالشريحة.
6. تعيين لون خط إطار الصورة.
7. تعيين عرض خط إطار الصورة.
8. تدوير إطار الصورة بتوفير قيمة موجبة (مع اتجاه عقارب الساعة) أو سالبة (عكس اتجاه عقارب الساعة).
9. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة Python يوضح عملية تنسيق إطار الصورة:

{{f04