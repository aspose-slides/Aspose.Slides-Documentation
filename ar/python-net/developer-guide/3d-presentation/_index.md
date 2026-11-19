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
description: "تطبيق ورسم تأثيرات ثلاثية الأبعاد لأشكال ونص PowerPoint في بايثون باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يمكنه إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد بنمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المحدبة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال ونص PowerPoint. لا تتعلق بإدراج أو تحرير ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتحويل تلك التأثيرات ثلاثية الأبعاد إلى ناتج ثنائي الأبعاد مُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تكشف الخاصية عن [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)، الذي يتحكم في المشهد الثلاثي الأبعاد لذلك الشكل.

للنص، استخدم الخاصية [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) . هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما الذي تتحكم فيه | متى يتم استخدامها |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | نقطة المشهد، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء الثلاثي الأبعاد أو محاكاة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | إعداد إضاءة مسبق، الاتجاه، ودوران الضوء. | تعديل مظهر الإضاءات والظلال على السطح الثلاثي الأبعاد. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | مادة السطح، مثل مسطح، مطفي، بلاستيك أو معدن. | جعل الشكل نفسه يبدو أكثر تسطحًا أو نعومة أو لمعانًا أو معدنًا. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | مقدار امتداد الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | لون الجوانب المُبثقة. | إظهار العمق أو توحيد لون الجوانب مع التعبئة الأمامية. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) و [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُقوَّسة بدلاً من وجه مسطح حاد. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) و [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | الخط الخارجي حول الكائن الثلاثي الأبعاد. | توضيح حدود الكائن في المخرجات المُرسَّمة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب مقروءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية إظهار الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجة، وارتفاع البثق 100 نقطة. يقوم المثال برسم الشريحة إلى صورة PNG بمقاس مرتين الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

الصورة المرسومة للشرائح تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران الثلاثي الأبعاد من خلال لوحة 3‑D Rotation. قيم الدوران X وY وZ تقابل ما تُحدده عبر واجهة برمجة تطبيقات الكاميرا.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

في Aspose.Slides، يتم الوصول إلى الكاميرا عبر [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). هذا المثال يُنشئ مستطيلًا، يختار عرضًا أماميًا أورثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على الترتيب. يكوّن الشكل في الذاكرة دون حفظ ملف:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

استخدم الكاميرا عندما تحتاج لتغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائي الأبعاد على الشريحة؛ بل يغيّر منظور العرض الثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند الرسم.

### **نسخ توجيه الكاميرا من شكل قالب**

لمطابقة توجيه شكل القالب، انسخ إعداد [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) المسبق واقرأ دورانه باستخدام [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين لديهما إضاءة ثلاثية الأبعاد مسبقة، والشكل الثاني لا يملك دوران كاميرا صريح.

القيم بالدرجة. الفهارس `0` و`1` و`2` تمثل العرض، الطول، والثورة على الترتيب. مرّرها إلى [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) بهذا الترتيب. إذا لم يكن للمصدر دوران صريح، يُعيد `get_rotation` القيمة `None`، لذا اترك الزوايا الوجهة غير مُحددة. إذا عيّن المصدر جميع الزوايا الثلاثة إلى صفر صراحةً، انسخ تلك الصفرات.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

عند إعادة فتح `camera-copy.pptx` في PowerPoint، يحمل الشكلان نفس إعداد الكاميرا والدوران. السهم على اليمين يستخدم التوجيه المنسوخ من المستطيل على اليسار. كلا الشكلين يستخدمان نفس الإضاءة وعمق البثق.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم عنصر العمق في هذا السُمك المرئي، وتتحكم خاصية اللون في لون الجوانب.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

عيّن [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) للسُمك و[ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) للون الجوانب. المثال التالي يمنح المستطيل بُثقًا بارتفاع 100 نقطة وجوانب بنفسجية ويُدوّر الكاميرا لإظهار السمك. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

خاصية [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) تُحدد عمق الشكل الثلاثي الأبعاد. خاصية [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة بالتدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرجًا من الأزرق إلى البرتقالي على الوجه الأمامي ولونًا برتقاليًا داكنًا على البثق بارتفاع 150 نقطة. توقِّفات التدرج عند 0 و100 تمثل بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجة. تُرسم الشريحة إلى صورة PNG بمقاس مرتين الأبعاد الافتراضية:

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

الناتج المرسوم يحتفظ بالتدرج على الوجه الأمامي ويُظهر البثق بشكل منفصل:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

لاستخدام تعبئة صورة، أضف الصورة إلى العرض التقديمي وعينها كملء للشكل. يتطلب المثال وجود ملف اسمه "image.jpg" في دليل العمل. يُمدّ الصورة لتملأ المستطيل، يضيف بُثقًا بارتفاع 150 نقطة، ويُعيّن دوران الكاميرا بالدرجة. يكوّن الشكل في الذاكرة دون حفظ أو رسم ملف:

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

الصورة تُرسم على الوجه الأمامي، بينما يُرسم البثق كسطح جانبي ثلاثي الأبعاد:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات WordArt حيث تحتاج الحروف نفسها إلى بُثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي يُنشئ نصًا بنمط شبكة برتقالي-أبيض، يضيف قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). ارتفاع البثق والعمق بالنقاط، ودوران الضوء بالدرجة. يُخفى ملء الشكل والحد لتظهر النص فقط. يرسم المثال صورة PNG بمقاس مرتين أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كـ PPTX:

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

النص يُرسم كحروف ثلاثية الأبعاد منحنية ومبثقة:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **الحفاظ على نص مسطح على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل الثلاثي الأبعاد، عيّن [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) عبر [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). عندما تكون القيمة `True`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `False`، يشارك النص في المشهد ويتبع توجيه 3D.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد للشكل: الكاميرا، الإضاءة، المادة، والبثق لا يزالون مكوَّنين عبر [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). وهو مختلف عن الدوران العادي. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) يتحكم في دوران النص داخل الصندوق المحيط به. إبقاء النص خارج المشهد لا يعيد ضبط أي من تلك الزوايا.

المثال المستقل التالي يُنشئ مستطيلًا أزرقًا بنص، ثم ينسخه بجانب الأصل. كلا الشكلين لهما نفس تنسيق 3D؛ الاختلاف فقط في إعداد النص: `False` على اليسار و`True` على اليمين. زوايا الكاميرا بالدرجة، وارتفاع البثق 40 نقطة. يحفظ المثال العرض التقديمي كـ PPTX ويرسم شريحة المقارنة إلى PNG بمقاس مرتين الأبعاد الافتراضية.

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

على اليسار، يتبع النص توجيه 3D. على اليمين يبقى مسطحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البثق المرئي وتوجيه 3D.

![Side-by-side 3D rectangles: keep_text_flat is False on the left and True on the right](keep_text_flat.png)

## **السلوك عند التصدير والرسم**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ بصيغ PowerPoint مثل PPTX. عند الرسم أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد الثلاثي الأبعاد إلى صورة ثنائية الأبعاد في الناتج. ينطبق ذلك عندما تُرسم الشرائح إلى [PNG](/slides/ar/python-net/convert-powerpoint-to-png/)، أو تُصدّر إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، أو تُولّد إطارات لتحويل [الفيديو](/slides/ar/python-net/convert-powerpoint-to-video/).

احرص على ما يلي:

- الصور وملفات PDF المُصدَّرة غير تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البثق، التعبئة، وتكبير الشريحة.
- إذا احتجت لقراءة القيم الموروثة أو المستندة إلى السمة، استخدم [effective shape properties](/slides/ar/python-net/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق 3D القابل للتحرير في PowerPoint. في تلك الصيغ، يُرسم الناتج بصريًا بدلاً من حفظه كإعدادات 3D قابلة للتعديل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يُنشئ Aspose.Slides ويُظهر تأثيرات 3D في PowerPoint للأشكال والنص. لا يجعل الصور أو ملفات PDF أو صفحات HTML مشاهد 3D تفاعلية يمكن للمستخدم تدويرها. في PPTX، يبقى تنسيق 3D قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج ثلاثي الأبعاد والتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل أو نص PowerPoint عادي، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة تأثيرات 3D.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، عيّن دوران كاميرا وإما بُثق أو عمق. عمليًا، يُفضَّل أيضًا تعيين مجموعة إضاءة ومادة لكي تظهر الوجوه المُرسَّمة بوضوح مع إضاءات وظلال.

**هل يمكنني تطبيق تأثيرات 3D على الأشكال والنص معًا؟**

نعم. استخدم [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) لجسم الشكل و[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) للنص.

**هل ستظهر تأثيرات 3D عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. يرسم Aspose.Slides تأثيرات 3D عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. يحتوي الناتج المُصدَّر على المظهر المرسوم، وليس كائنًا ثلاثيًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية لـ 3D بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الواردة في [Shape Effective Properties](/slides/ar/python-net/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.