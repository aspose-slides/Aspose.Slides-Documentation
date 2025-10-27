---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في بايثون
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- استخراج ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في بايثون باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint وOpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**

كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد في PowerPoint؟ يسمح لك Microsoft PowerPoint بإضافة نماذج ثلاثية الأبعاد، وتطبيق تأثيرات ثلاثية الأبعاد على الأشكال، وإنشاء نص ثلاثي الأبعاد، وإدراج رسومات ثلاثية الأبعاد، وبناء رسوم متحركة ثلاثية الأبعاد.

إنشاء تأثيرات ثلاثية الأبعاد له تأثير كبير وغالبًا ما يكون أسهل طريقة لتحويل مجموعة شرائح عادية إلى عرض تقديمي ثلاثي الأبعاد. منذ الإصدار 20.9 من Aspose.Slides، تمت إضافة **محرك ثلاثي الأبعاد متعدد المنصات** جديد. يتيح هذا المحرك تصدير ورسم الأشكال والنصوص ذات التأثيرات ثلاثية الأبعاد. في الإصدارات السابقة، كانت الأشكال ذات التأثيرات ثلاثية الأبعاد تُرسم بشكل مسطح؛ الآن يمكن رسمها بـ **ثلاثي أبعاد كامل**. يمكنك أيضًا إنشاء أشكال ذات تأثيرات ثلاثية الأبعاد عبر واجهة برمجة تطبيقات Aspose.Slides.

في واجهة برمجة تطبيقات Aspose.Slides، لجعل الشكل شكل PowerPoint ثلاثي الأبعاد، استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) التي تُظهر أعضاء الفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) و[bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): ضبط الحواف، اختيار نوع الحافة (مثال: Angle، Circle، SoftRound)، وتحديد ارتفاع وعرض الحافة.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): محاكاة حركة الكاميرا حول الكائن؛ عن طريق تعديل تدوير الكاميرا، التكبير، وخصائص أخرى، يمكنك التحكم بالأشكال كما لو كانت نماذج ثلاثية الأبعاد في PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) و[contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): ضبط خصائص الخط لتجعل الشكل يبدو ككائن PowerPoint ثلاثي الأبعاد.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)، [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)، و[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): جعل الشكل ثلاثي الأبعاد بتعيين عمقه أو بضغطه.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): إنشاء تأثيرات إضاءة على الشكل الثلاثي الأبعاد؛ مشابهًا للكاميرا، يمكنك ضبط تدوير الضوء بالنسبة للشكل واختيار نوع الضوء.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): اختيار مادة لجعل الشكل الثلاثي الأبعاد يبدو أكثر واقعية. تشمل المواد المعرفة مسبقًا: Metal، Plastic، Powder، Matte، وغيرها.

يمكن تطبيق جميع ميزات الثلاثي الأبعاد على كل من الأشكال والنص. تُظهر الأقسام أدناه كيفية الوصول إلى هذه الخصائص ثم فحصها خطوة بخطوة.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

الصورة المصغرة المُنشأة تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **التدوير ثلاثي الأبعاد**

يمكنك تدوير أشكال PowerPoint ثلاثية الأبعاد في الفضاء ثلاثي الأبعاد لإضافة تفاعلية. لتدوير شكل ثلاثي الأبعاد في PowerPoint، استخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في واجهة برمجة تطبيقات Aspose.Slides، تتحكم في تدوير الشكل ثلاثي الأبعاد عبر الخاصية [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... تعيين باقي معلمات المشهد ثلاثي الأبعاد

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **العمق ثلاثي الأبعاد والضغط**

لإضافة بُعد ثالث إلى الشكل وجعله ثلاثي الأبعاد فعليًا، استخدم الخواص [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) و[ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... تعيين باقي معلمات المشهد ثلاثي الأبعاد

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

في PowerPoint، عادةً ما تستخدم قائمة **العمق** لتعيين عمق الشكل الثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)

## **تدرج الألوان ثلاثي الأبعاد**

يمكن استخدام التدرج لتعبئة شكل PowerPoint ثلاثي الأبعاد. لننشئ شكلًا بتعبئة تدرج ونطبق عليه تأثير ثلاثي الأبعاد:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)
   
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

وهنا النتيجة:

![todo:image_alt_text](img_02_03.png)

بالإضافة إلى تعبئة التدرج، يمكنك تعبئة الأشكال بصورة:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... إعداد ثلاثي الأبعاد: shape.three_d_format.camera، shape.three_d_format.light_rig، shape.three_d_format.Extrusion* ...

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

هذا هو الشكل النهائي:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**

تسمح لك Aspose.Slides بتطبيق تأثيرات ثلاثية الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد، يمكنك استخدام تأثير تحويل WordArt:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # إعداد تأثير تحويل WordArt "Arch Up"
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

وهنا النتيجة:

![todo:image_alt_text](img_02_05.png)

## **الأسئلة الشائعة**

**هل سيتم الحفاظ على تأثيرات الثلاثي الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides الثلاثي الأبعاد بتصوير تأثيرات الثلاثي الأبعاد عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، وغيرها).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات الثلاثي الأبعاد التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides API إمكانية [قراءة القيم الفعّالية](/slides/ar/python-net/shape-effective-properties/) (بما في ذلك للإضاءة، الحواف، إلخ) لتتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات الثلاثي الأبعاد عند تحويل العرض إلى مقطع فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/python-net/convert-powerpoint-to-video/)، تُصوَّر تأثيرات الثلاثي الأبعاد بنفس الطريقة التي تُصوَّر بها [الصور المصدرة](/slides/ar/python-net/convert-powerpoint-to-png/).