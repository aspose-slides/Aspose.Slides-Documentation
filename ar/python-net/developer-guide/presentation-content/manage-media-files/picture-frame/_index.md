---
title: إطار الصورة
type: docs
weight: 10
url: /python-net/picture-frame/
keywords: "إضافة إطار صورة، إنشاء إطار صورة، إضافة صورة، إنشاء صورة، استخراج صورة، خاصية StretchOff، تنسيق إطار الصورة، خصائص إطار الصورة، عرض تقديمي PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة إطار صورة إلى عرض تقديمي PowerPoint باستخدام بايثون"
---

إطار الصورة هو شكل يحتوي على صورة—يشبه الصورة في إطار.

يمكنك إضافة صورة إلى شريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 

تقدم Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. أنشئ مثيلاً لفئة [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. أنشئ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` المعروضة بواسطة كائن الشكل المرتبط بالشريحة المرجعية.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة بايثون يوضح لك كيفية إنشاء إطار صورة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيلاً لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # احصل على الشريحة الأولى
    sld = pres.slides[0]

    # أنشئ مثيلاً لفئة ImageEx
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # أضف إطارًا بارتفاع الصورة وعرضها المكافئ
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # طبق بعض التنسيق على PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # اكتب ملف PPTX إلى القرص
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

تسمح لك إطارات الصور بإنشاء شرائح تقديمية بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك معالجة عمليات الإدخال / الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في رؤية هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

من خلال تغيير النسبة المئوية للصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. أضف صورة إلى مجموعة الصور في العرض التقديمي.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الشكل.
5. حدد عرض الصورة وارتفاعها النسبي في إطار الصورة.
6. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة بايثون يوضح لك كيفية إنشاء إطار صورة مع مقياس نسبي:

```py
import aspose.slides as slides

# أنشئ مثيل لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:
    # يحمل الصورة التي ستضاف إلى مجموعة الصور في العرض التقديمي
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # أضف إطار صورة إلى الشريحة
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # حدد نسبة العرض والارتفاع النسبية
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # احفظ العرض التقديمي
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج صورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) وحفظها في تنسيقات PNG و JPG وأخرى. المثال البرمجي أدناه يوضح كيفية استخراج صورة من الوثيقة "sample.pptx" وحفظها بتنسيق PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **الحصول على شفافية الصورة**

تسمح لك Aspose.Slides بالحصول على شفافية الصورة. يقوم هذا الكود بلغة بايثون بتوضيح العملية: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("شفافية الصورة: " + str(transparencyValue))
```

## **تنسيق إطار الصورة**

تقدم Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليطابق متطلبات محددة.

1. أنشئ مثيل لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. أنشئ `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) المعروضة بواسطة كائن [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) المرتبط بالشريحة المرجعية.
6. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
7. حدد لون خط إطار الصورة.
8. حدد عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة. 
   * القيمة السلبية تدور الصورة في الاتجاه العكسي.
10. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
11. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة بايثون يوضح عملية تنسيق إطار الصورة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيل لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # احصل على الشريحة الأولى
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # أضف إطار صورة مع ارتفاع الصورة وعرضها المكافئ
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # طبق بعض التنسيق على PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # اكتب ملف PPTX إلى القرص
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="نصيحة" color="primary" %}}

طورت Aspose مؤخرًا [صانع الكولاج المجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كارتباط**

لتجنب أحجام العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو مقاطع الفيديو) من خلال روابط بدلاً من تضمين الملفات مباشرة في العروض التقديمية. يقوم هذا الكود بلغة بايثون بإظهار كيفية إضافة صورة وفيديو إلى عنصر نائب:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **قص الصورة**

هذا الكود بلغة بايثون يوضح لك كيفية قص صورة موجودة على شريحة:

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # إنشاء كائن صورة جديدة
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # إضافة إطار صورة إلى الشريحة
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # قص الصورة (قيم النسبة المئوية)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # احفظ النتيجة
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## حذف المناطق المقصوصة من الصورة

إذا كنت ترغب في حذف المناطق المقصوصة من الصورة الموجودة في إطار، يمكنك استخدام الطريقة [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) . هذه الطريقة تعيد الصورة المقصوصة أو الصورة الأصلية إذا كان القص غير ضروري.

هذا الكود بلغة بايثون يوضح العملية:

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # يحصل على PictureFrame من الشريحة الأولى
    picture_frame = slide.shapes[0]

    # يحذف المناطق المقصوصة من صورة PictureFrame ويعيد الصورة المقصوصة
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # احفظ النتيجة
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة delete_picture_cropped_areas الصورة المقصوصة إلى مجموعة الصور في العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) المعالج، يمكن أن يقلل هذا الإعداد حجم العرض التقديمي. خلاف ذلك، سيزداد عدد الصور في العرض التقديمي الناتج.

تقوم هذه الطريقة بتحويل ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا كنت ترغب في الحفاظ على نسبة العرض إلى الارتفاع لشكل يحتوي على صورة حتى بعد تغيير أبعاد الصورة، يمكنك استخدام خاصية *aspect_ratio_locked* لتعيين إعداد *قفل نسبة العرض إلى الارتفاع*.

هذا الكود بلغة بايثون يوضح لك كيفية قفل نسبة العرض إلى الارتفاع لشكل: 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # تعيين الشكل للحفاظ على نسبة العرض إلى الارتفاع عند تغيير الحجم
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="ملاحظة" color="warning" %}} 

يقوم إعداد *قفل نسبة العرض إلى الارتفاع* بالحفاظ على نسبة العرض إلى الارتفاع فقط للشكل وليس للصورة التي يحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خاصيات `StretchOffsetLeft` و `StretchOffsetTop` و `StretchOffsetRight` و `StretchOffsetBottom` من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) ، يمكنك تحديد مستطيل التعبئة. 

عند تحديد التجديد لصورة، يتم تغيير حجم المستطيل المصدر ليتناسب مع المستطيل المحدد. يتم تحديد كل حافة من المستطيل التعبوي بواسطة نسبة مئوية من الحافة المقابلة لمربع الشكل. تحدد النسبة المئوية الإيجابية حواف داخلية بينما تحدد النسبة المئوية السلبية حواف خارجية.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف شكل `AutoShape`. 
4. أنشئ صورة.
5. حدد نوع التعبئة للشكل.
6. حدد وضع ملء الصورة للشكل.
7. أضف صورة محددة لملء الشكل.
8. حدد انزلاقات الصورة من الحافة المقابلة لمربع جوانب الشكل.
9. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة بايثون يوضح عملية استخدام خاصية StretchOff:

```py
import aspose.slides as slides

# أنشئ مثيل لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:

    # احصل على الشريحة الأولى
    slide = pres.slides[0]

    # أنشئ مثيل لفئة ImageEx
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # أضف إطار صورة مع ارتفاع الصورة وعرضها المكافئ
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # حدد نوع التعبئة للشكل
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # حدد وضع ملء الصورة للشكل
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # حدد الصورة لملء الشكل
        shape.fill_format.picture_fill_format.picture.image = imgx

        # حدد انزلاقات الصورة من الحافة المقابلة لمربع جوانب الشكل
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # اكتب ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```