---
title: إنشاء عروض تقديمية ثلاثية الأبعاد باستخدام Python
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في Python باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint وOpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**

كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد في PowerPoint؟ يتيح لك Microsoft PowerPoint إضافة نماذج ثلاثية الأبعاد، وتطبيق تأثيرات ثلاثية الأبعاد على الأشكال، وإنشاء نص ثلاثي الأبعاد، وإدراج رسومات ثلاثية الأبعاد، وبناء رسوم متحركة ثلاثية الأبعاد.

إنشاء تأثيرات ثلاثية الأبعاد له تأثير كبير وغالبًا ما يكون أسهل طريقة لتحويل مجموعة شرائح قياسية إلى عرض تقديمي ثلاثي الأبعاد. منذ إصدار Aspose.Slides 20.9، تمت إضافة **محرك ثلاثي الأبعاد متعدد المنصات**. يتيح هذا المحرك تصدير ورَسمة الأشكال والنصوص ذات التأثيرات الثلاثية الأبعاد. في الإصدارات السابقة، كانت الأشكال ذات التأثيرات الثلاثية الأبعاد تُعرَّض مسطحة؛ الآن يمكن عرضها **ثلاثية الأبعاد بالكامل**. يمكنك أيضًا إنشاء أشكال ذات تأثيرات ثلاثية الأبعاد عبر Aspose.Slides API.

في Aspose.Slides API، لجعل شكل ما شكل ثلاثي الأبعاد في PowerPoint، استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) التي تكشف عن أعضاء فئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) و [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): ضبط الحواف، اختيار نوع الحافة (مثل Angle أو Circle أو SoftRound)، وتحديد ارتفاع وعرض الحافة.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): محاكاة حركة الكاميرا حول الكائن؛ من خلال تعديل دوران الكاميرا، التكبير، والخصائص الأخرى، يمكنك تحريك الأشكال كأنها نماذج ثلاثية الأبعاد في PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) و [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): ضبط خصائص الحدود لجعل الشكل يبدو ككائن ثلاثي الأبعاد في PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)، [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)، و [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): جعل الشكل ثلاثيًا بالأبعاد عبر ضبط عمقه أو بُره.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): إنشاء تأثيرات إضاءة على الشكل ثلاثي الأبعاد؛ مشابهًا للكاميرا، يمكنك ضبط دوران الضوء بالنسبة للشكل ثلاثي الأبعاد واختيار نوع الضوء.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): اختيار مادة لجعل الشكل ثلاثي الأبعاد يبدو أكثر واقعية. تشمل المواد المحددة مسبقًا Metal و Plastic و Powder و Matte وغير ذلك.

يمكن تطبيق جميع ميزات الثلاثية الأبعاد على الأشكال والنصوص على حدٍ سواء. تُظهر الأقسام أدناه كيفية الوصول إلى هذه الخصائص ثم فحصها خطوة بخطوة.

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

الصورة المصغرة المُعالجة تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **دوران ثلاثي الأبعاد**

يمكنك تدوير أشكال PowerPoint ثلاثية الأبعاد في الفضاء الثلاثي الأبعاد لإضافة تفاعلية. لتدوير شكل ثلاثي الأبعاد في PowerPoint، استخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في Aspose.Slides API، تتحكم في دوران الشكل ثلاثي الأبعاد عبر خاصية [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **عمق ثلاثي الأبعاد والبُرْز (Extrusion)**

لإضافة بُعد ثالث إلى الشكل وجعله ثلاثيًا فعليًا، استخدم خصائص [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) و [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

في PowerPoint، تستخدم عادةً القائمة **Depth** لتحديد عمق الشكل ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)

## **تدرج ثلاثي الأبعاد**

يمكن استخدام التدرج لتعبئة شكل ثلاثي الأبعاد في PowerPoint. لننشئ شكلًا بتعبئة تدرجية ونطبق عليه تأثيرًا ثلاثيًا:

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

وهذا هو الناتج:

![todo:image_alt_text](img_02_03.png)

بالإضافة إلى التعبئة بالتدرج، يمكنك تعبئة الأشكال بصورة:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... إعدادات الثلاثية الأبعاد: shape.three_d_format.camera، shape.three_d_format.light_rig، shape.three_d_format.Extrusion* ...

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

هكذا يبدو الشكل:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**

يسمح لك Aspose.Slides بتطبيق تأثيرات ثلاثية الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد، يمكنك استخدام تأثير التحويل WordArt:

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
    # إعداد تأثير التحويل WordArt "Arch Up"
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

وهذا هو الناتج:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**هل ستحافظ تأثيرات الثلاثية الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides 3D بمعالجة تأثيرات الثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات الثلاثية الأبعاد التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides واجهات برمجة تطبيقات لقراءة القيم الفعّالة ([قراءة القيم الفعّالة](/slides/ar/python-net/shape-effective-properties/)) (بما في ذلك للإضاءة، الحواف، إلخ) بحيث يمكنك رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات الثلاثية الأبعاد عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/python-net/convert-powerpoint-to-video/)، تُعالج تأثيرات الثلاثية الأبعاد بنفس الطريقة التي تُعالج بها [الصور المصدَّرة](/slides/ar/python-net/convert-powerpoint-to-png/).