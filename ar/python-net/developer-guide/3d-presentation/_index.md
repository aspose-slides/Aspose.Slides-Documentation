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
- بايثون
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال ونصوص PowerPoint باستخدام بايثون مع Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python عبر .NET إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في النتيجة المصدرة ذات البعدين.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الخاصية [Shape.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/three_d_format/) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُظهر الخاصية [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/)، التي تتحكم بالمشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم الخاصية [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/). يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما تتحكم به | متى تُستخدم |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/camera/) | نقطة المشاهدة، نوع الكاميرا المُحدد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد في PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/light_rig/) | إعداد الضوء المحدد مسبقًا، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [material](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/material/) | مادة السطح، مثل مسطحة، غير لامعة، بلاستيك، أو معدن. | اجعل الشكل نفسه يبدو أكثر تسطحًا، أو نعومة، أو لامعًا، أو معدنيًا. |
| [extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) | المسافة التي يمتد فيها الشكل إلى الخلف من الوجه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [extrusion_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_color/) | لون الجوانب الممدودة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/depth/) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة لأشكال أو نصوص، خاصةً مع إعدادات الحافة والمادة. |
| [bevel_top](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/bevel_top/) و [bevel_bottom](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/bevel_bottom/) | حواف مرتفعة أو مُدوَّرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعّمة أو مُشكَّلة بدلاً من وجه حاد مسطح. |
| [contour_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/contour_color/) و [contour_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/contour_width/) | حد حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في الناتج المرسوم. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بأقوى صورة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجهين والجانبين قابلين للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيق ثلاثي الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويعرض الشريحة كصورة PNG.

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

تظهر صورة الشريحة المرسومة المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل ثلاثي الأبعاد أزرق مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة دوران ثلاثي الأبعاد. قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [ThreeDFormat.camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغيّر منظور الرؤية ثلاثي الأبعاد المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا عن طريق تمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السمك المرئي، وتتحكم أداة التحكم في اللون في لون الوجوه الجانبية.

![ضوابط العمق في PowerPoint مرفقة بلون البثق وخصائص ارتفاع البثق](img_02_02.png)

اضبط [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) للسمك و[ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_color/) للون الجوانب:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

استخدم [ThreeDFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/depth/) عندما تحتاج إلى العمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة والمادة وتأثيرات النص. في كثير من سيناريوهات الشكل، يكون [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/extrusion_height/) هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن البثق المرئي.

## **استخدام التعبئة بالتدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تعبئة تدرج على الشكل ولون بثق أغمق للجوانب:

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

المخرجات المرسومة تحافظ على التدرج على الوجه الأمامي وتعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدريجية من الأزرق إلى البرتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

الصورة تُظهر على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات الشكل ثلاثية الأبعاد على جسم الشكل. تؤثر تنسيقات النص ثلاثية الأبعاد على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى بثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [TextFrameFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/):

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

النص يُعرض كحروف ثلاثية الأبعاد منحنية، بغطاء نمط برتقالي، وبثق داكن:

![نص ثلاثي الأبعاد مع تحويل WordArt مقوس، تعبئة بنمط برتقالي، وبثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة التخطيط، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تعرض الشرائح إلى [PNG](/slides/ar/python-net/convert-powerpoint-to-png/)، أو تصدر إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، أو تولد إطارات لـ [تحويل الفيديو](/slides/ar/python-net/convert-powerpoint-to-video/).

ضع في اعتبارك النقاط التالية:

- الصور وملفات PDF المصدرة لا تكون تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، نظام الإضاءة، المادة، البثق، التعبئة، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى القالب، اقرأ [effective shape properties](/slides/ar/python-net/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من الاحتفاظ بإعدادات ثلاثية الأبعاد قابلة للتعديل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يظل تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، يجب ضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط نظام الإضاءة والمادة حتى تكون الوجوه المعروضة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/three_d_format/) لجسم الشكل و[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. الناتج المصدّر يحتوي على المظهر المرسوم، لا ككائن ثلاثي الأبعاد قابل للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات القالب؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الواردة في [Shape Effective Properties](/slides/ar/python-net/shape-effective-properties/) لقراءة الكاميرا النهائية، نظام الإضاءة، الحافة، والقيم الثلاثية الأبعاد المرتبطة.