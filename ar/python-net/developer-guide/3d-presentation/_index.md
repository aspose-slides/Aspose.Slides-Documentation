---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في Python
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- تمديد ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أنشئ عروض تقديمية ثلاثية الأبعاد تفاعلية في Python باستخدام Aspose.Slides بسهولة. صدّر بسرعة إلى صيغ PowerPoint وOpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**

كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد في PowerPoint؟ يتيح لك Microsoft PowerPoint إضافة نماذج ثلاثية الأبعاد، وتطبيق تأثيرات ثلاثية الأبعاد على الأُشكال، وإنشاء نص ثلاثي الأبعاد، وإدراج رسومات ثلاثية الأبعاد، وبناء رسومات متحركة ثلاثية الأبعاد.

إن إنشاء التأثيرات الثلاثية الأبعاد له تأثير كبير وغالبًا ما يكون أسهل طريقة لتحويل مجموعة شرائح عادية إلى عرض تقديمي ثلاثي الأبعاد. منذ الإصدار Aspose.Slides 20.9، تمت إضافة **محرك ثلاثي الأبعاد متعدد المنصات** جديد. يمكّن هذا المحرك من تصدير ورسم الأُشكال والنصوص ذات التأثيرات الثلاثية الأبعاد. في الإصدارات السابقة، كانت الأُشكال التي تحتوي على تأثيرات ثلاثية الأبعاد تُعرض مسطّحة؛ الآن يمكن رسمها بـ **3D كامل**. يمكنك أيضًا إنشاء أُشكال ذات تأثيرات ثلاثية الأبعاد عبر واجهة برمجة تطبيقات Aspose.Slides.

في واجهة برمجة التطبيقات Aspose.Slides، لجعل الشكل شكل PowerPoint ثلاثي الأبعاد، استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) التي تُظهر أعضاء الفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) و [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): ضبط الحواف، اختيار نوع الحافة (مثل Angle و Circle و SoftRound)، وتعريف ارتفاع وعرض الحافة.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): محاكاة حركة الكاميرا حول الكائن؛ من خلال تعديل دوران الكاميرا، zoom، وغيرها من الخصائص، يمكنك التحكم بالأُشكال كأنها نماذج ثلاثية الأبعاد في PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) و [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): ضبط خصائص الحد لجعل الشكل يبدو ككائن PowerPoint ثلاثي الأبعاد.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)، [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)، و [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): جعل الشكل ثلاثي الأبعاد عبر ضبط عمقه أو بجره.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): إنشاء تأثيرات إضاءة على الشكل ثلاثي الأبعاد؛ مشابهًا للكاميرا، يمكنك ضبط دوران الضوء بالنسبة للشكل ثلاثي الأبعاد واختيار نوع الضوء.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): اختيار مادة لجعل الشكل ثلاثي الأبعاد أكثر واقعية. تشمل المواد المعرفة مسبقًا Metal و Plastic و Powder و Matte وغيرها.

يمكن تطبيق جميع ميزات 3D على كل من الأُشكال والنص. تُظهر الأقسام أدناه كيفية الوصول إلى هذه الخصائص ثم فحصها خطوة بخطوة.
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


الصورة المصغرة المعروضة تبدو كالتالي:

![todo:image_alt_text](img_01_01.png)

## **تدوير ثلاثي الأبعاد**

يمكنك تدوير الأُشكال ثلاثية الأبعاد في PowerPoint في الفضاء الثلاثي الأبعاد لإضافة تفاعل. لتدوير شكل ثلاثي الأبعاد في PowerPoint، استخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في واجهة برمجة التطبيقات Aspose.Slides، تتحكم في تدوير الشكل ثلاثي الأبعاد عبر الخاصية [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).
```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... ضبط باقي معلمات المشهد ثلاثي الأبعاد

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```


## **عمق ثلاثي الأبعاد والتمديد**

لإضافة البُعد الثالث إلى الشكل وجعله ثلاثيًا فعليًا، استخدم الخصائص [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) و [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):
```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... ضبط باقي معلمات المشهد ثلاثي الأبعاد

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```


في PowerPoint، عادةً ما تستخدم قائمة **Depth** لضبط عمق الشكل ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)

## **تدرج ثلاثي الأبعاد**

يمكن استخدام التدرج لتعبئة شكل PowerPoint ثلاثي الأبعاد. لننشئ شكلًا بملء تدرجي ونطبق عليه تأثير ثلاثي الأبعاد:
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


وهذا هو النتيجة:

![todo:image_alt_text](img_02_03.png)

بالإضافة إلى ملء التدرج، يمكنك تعبئة الأُشكال بصورة:
```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... إعداد ثلاثي الأبعاد: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* الخصائص

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


وهكذا يبدو الشكل:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**

تمكنك Aspose.Slides من تطبيق تأثيرات ثلاثية الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد، يمكنك استخدام تأثير تحويل WordArt:
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


هذه هي النتيجة:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**هل ستُحافظ تأثيرات 3D عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides 3D برسم تأثيرات 3D عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم الفعّالة (النهائية) لمعلمات 3D التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides واجهات برمجة تطبيقات لقراءة القيم الفعّالة ([read effective values](/slides/ar/python-net/shape-effective-properties/)) (بما في ذلك للإضاءة، الحواف، وما إلى ذلك) حتى تتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات 3D عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/python-net/convert-powerpoint-to-video/)، تُرسم تأثيرات 3D كما تُرسم للـ [الصور المصدَّرة](/slides/ar/python-net/convert-powerpoint-to-png/).