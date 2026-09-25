---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام بايثون
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في بايثون باستخدام Aspose.Slides. تكوين الكاميرا، الإضاءة، المادة، البثق، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides للغة Python عبر .NET إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد شبيه بـ PowerPoint للأشكال والنصوص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، تعبئة التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتناول تأثيرات التنسيق ثلاثي الأبعاد على أشكال PowerPoint والنصوص. وهي ليست حول إدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في النتيجة المصدرة ذات البعدين.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/three_d_format/) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تعرض الخاصية [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) التي تتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم الخاصية [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/) . يطبق هذا تنسيقًا ثلاثيًا الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما الذي يتحكم فيه | متى يتم الاستخدام |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/camera/) | نقطة المشهد، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/light_rig/) | إعداد مسبق للإضاءة، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [material](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/material/) | مادة السطح، مثل مسطح، مطفي، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر استواءً، نعومة، لمعانًا، أو معدنية. |
| [extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) | المدى الذي يمتد به الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [extrusion_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_color/) | لون الجوانب البثقة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/depth/) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النصوص، خاصةً مع إعدادات الحافة والمادة. |
| [bevel_top](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/bevel_bottom/) | حواف مرفوعة أو مستديرة على الوجهين الأمامي والخلفي. | إضافة حافة ناعمة أو مُشكَّلة بدلاً من وجه مسطح وحاد. |
| [contour_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/contour_width/) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | تسليط الضوء على حدود الكائن في النتيجة المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب واضحة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق هو 100 نقطة. يقوم المثال برسم الشريحة إلى صورة PNG بمقاس مضاعف عن الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

تُظهر صورة الشريحة المرسومة المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل ثلاثي الأبعاد أزرق مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران الثلاثي الأبعاد من لوحة الدوران ثلاثي الأبعاد. قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع تمييز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، يمكنك الوصول إلى الكاميرا عبر [ThreeDFormat.camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/camera/). ينشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X و Y و Z إلى 20 و30 و40 درجة على التوالي. يقوم بتكوين الشكل في الذاكرة دون حفظ ملف:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا تغير الهندسة الثنائية الأبعاد للشكل على الشريحة. بل تغير منظور العرض ثلاثي الأبعاد الذي يستخدمه PowerPoint و Aspose.Slides عند الرسم.

## **إضافة بثق وعمق**

يجعل البثق الشكل يبدو سميكًا عن طريق تمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السمك المرئي، ويتحكم التحكم في اللون في لون الوجهين الجانبيين.

![تحكمات العمق في PowerPoint المرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

حدد [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) للسمك و[ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_color/) للون الجوانب. يمنح هذا المثال المستطيل بثرقًا بطول 100 نقطة مع جوانب أرجوانية ويدور الكاميرا لإظهار سمكه. يقوم بتكوين الشكل في الذاكرة دون حفظ ملف:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

خاصية [ThreeDFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/depth) تحدد عمق الشكل ثلاثي الأبعاد. خاصية [extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا والإضاءة والمادة والبرق.

يطبق هذا المثال تدرجًا من الأزرق إلى البرتقالي على الوجه الأمامي ولونًا برتقاليًا داكنًا على بثرق بطول 150 نقطة. يحددون التدرج عند 0 و100 كنقطة بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. يتم رسم الشريحة إلى صورة PNG بمقاس مضاعف عن الأبعاد الافتراضية:

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
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي وبثرق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال ملفًا موجودًا اسمه "image.jpg" في دليل العمل. يقوم بتمديد الصورة لملء المستطيل، يطبق بثرقًا بطول 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يقوم بتكوين الشكل في الذاكرة دون حفظ أو رسم ملف:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![مستطيل ثلاثي الأبعاد مرسوم مع تعبئة صورة على الوجه الأمامي وبثرق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات الشكل ثلاثية الأبعاد على جسم الشكل. وتؤثر تنسيقات النص ثلاثية الأبعاد على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بثرق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي أبيض، يطبق قوسًا صاعدًا، ويضبط إعدادات ثلاثية الأبعاد عبر [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/). ارتفاع البثرق والعمق بوحدات النقاط، ودوران الإضاءة بالدرجات. تم إخفاء تعبئة الشكل وخطه الخارجي بحيث يكون النص فقط مرئيًا. يرسم المثال صورة PNG بمقاس مضاعف عن أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![نص ثلاثي الأبعاد مرسوم مع تحويل WordArt مقوس، تعبئة بنمط برتقالي، وبثرق داكن](img_02_05.png)

## **الحفاظ على النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، اضبط [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/keep_text_flat/) من خلال [TextFrame.text_frame_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/text_frame/text_frame_format/). عندما تكون القيمة `True`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `False`، يشارك النص في المشهد ويتبع اتجاهه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق الشكل ثلاثي الأبعاد: لا يزال الكاميرا والإضاءة والمادة والبرزق مكوّنة عبر [Shape.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/three_d_format/). وهو مختلف أيضًا عن الدوران العادي. [Shape.rotation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/rotation/) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/rotation_angle/) يتحكم في دوران النص المخصص داخل إطاره. الحفاظ على النص خارج المشهد ثلاثي الأبعاد لا يعيد تعيين أيٍ من هذين الزاويتين.

المثال التالي المستقل ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصل. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ يختلف فقط إعداد النص: `False` على اليسار و`True` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثرق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويرسم شريحة المقارنة إلى PNG بمقاس مضاعف عن الأبعاد الافتراضية.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل للقراءة. يحتفظ كلا المستطيلين بنفس البثرق الظاهر والاتجاه ثلاثي الأبعاد.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: keep_text_flat هو False على اليسار وTrue على اليمين](keep_text_flat.png)

## **سلوك التصدير والرسم**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ بتنسيقات PowerPoint مثل PPTX. عند الرسم أو التصدير إلى تنسيقات ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطيات أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تقوم برسم الشرائح إلى [PNG](/slides/ar/python-net/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [video conversion](/slides/ar/python-net/convert-powerpoint-to-video/).

ضع في اعتبارك النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد دوران الكائن بعد التصدير.
- المظهر النهائي يعتمد على تركيبة الكاميرا، وإعداد الإضاءة، والمادة، والبثرق، والتعبئة، وتعديل حجم الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعالة](/slides/ar/python-net/shape-effective-properties/).
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيق PowerPoint ثلاثي الأبعاد القابل للتعديل. في تلك التنسيقات، يتم عرض النتيجة البصرية بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتعديل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يقوم Aspose.Slides بإنشاء وتطبيق تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنصوص. لا يجعل الصور أو ملفات PDF أو صفحات HTML المصدرة مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في ملف PPTX، يظل تنسيق ثلاثي الأبعاد قابلًا للتعديل في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج ثلاثي الأبعاد والتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يتم إدراجه في العرض التقديمي. أما التأثير ثلاثي الأبعاد فهو تنسيق يُطبق على شكل أو نص PowerPoint عادي، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

في الحد الأدنى، ضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضل أيضًا ضبط إعداد الإضاءة والمادة لتظهر الوجوه المرسومة بوضوح مع إضاءات وظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنصوص؟**

نعم. استخدم [Shape.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/three_d_format/) لجسم الشكل و[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/) للنص.

**هل تظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى الصور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. تقوم Aspose.Slides برسم تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات التحويل إلى الفيديو. يحتوي الناتج المصدّر على المظهر المرسوم، وليس كائنًا ثلاثيًا قابلًا للتعديل.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعالة](/slides/ar/python-net/shape-effective-properties/) لقراءة قيم الكاميرا النهائية، وإعداد الإضاءة، والحافة، والقيم الثلاثية الأبعاد المرتبطة.