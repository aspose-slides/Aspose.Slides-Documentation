---
title: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-net/3d-presentation/
keywords:
- 3D
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض PowerPoint
- بايثون
- Aspose.Slides لبايثون عبر .NET
description: "عرض PowerPoint ثلاثي الأبعاد في بايثون"
---

## نظرة عامة
كيف تقوم عادةً بإنشاء عرض PowerPoint ثلاثي الأبعاد؟
يمكن Microsoft PowerPoint من إنشاء عروض ثلاثية الأبعاد حيث يمكننا إضافة نماذج ثلاثية الأبعاد، وتطبيق تأثيرات ثلاثية الأبعاد على الأشكال، 
إنشاء نص ثلاثي الأبعاد، تحميل رسومات ثلاثية الأبعاد في العرض، وإنشاء تكوينات ثلاثية الأبعاد في PowerPoint.

إن إنشاء تأثيرات ثلاثية الأبعاد يحدث تأثيرًا كبيرًا في تحسين العرض ليصبح عرضًا ثلاثي الأبعاد، وقد يكون أسهل تنفيذ لعرض ثلاثي الأبعاد. 
منذ إصدار Aspose.Slides 20.9، تمت إضافة **محرك ثلاثي الأبعاد عبر المنصات** جديد. يتيح المحرك الثلاثي الأبعاد الجديد 
تصدير ورستر الأشكال والنصوص مع تأثيرات ثلاثية الأبعاد. في الإصدارات السابقة، 
كانت الأشكال مع تطبيق تأثيرات ثلاثية الأبعاد تُعرض بشكل مسطح. لكن، الآن من الممكن 
عرض الأشكال بشكل **ثلاثي الأبعاد كامل**.
علاوة على ذلك، أصبح من الممكن الآن إنشاء أشكال مع تأثيرات ثلاثية الأبعاد عبر واجهة برمجة التطبيقات العامة لSlides.

في واجهة برمجة تطبيقات Aspose.Slides، لجعل 
شكل ما يصبح شكل PowerPoint ثلاثي الأبعاد، استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) 
التي ترث ميزات واجهة [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
و [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): set bevel to the shape, define bevel type (e.g. Angle, Circle, SoftRound), define height and width of bevel.
- [الكاميرا](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): تُستخدم لتقليد حركات الكاميرا حول الكائن. بعبارة أخرى، من خلال ضبط دوران الكاميرا، والتكبير، وخصائص أخرى - يمكنك التفاعل مع 
أشكالك كما لو كانت النموذج ثلاثي الأبعاد في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
و [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): اضبط خصائص الحواف لجعل الشكل يبدو كشكل PowerPoint ثلاثي الأبعاد.
- [عمق](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/)، 
[لون البروز](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
و [ارتفاع البروز](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): تُستخدم لجعل الشكل ثلاثي الأبعاد، مما يعني تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد، 
من خلال ضبط عمقه أو بروزته.
- [إضاءة](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): يمكن أن تخلق تأثير إضاءة على شكل ثلاثي الأبعاد. منطق هذه الخاصية مشابه للكاميرا، يمكنك ضبط دوران الضوء 
بالنسبة للشكل الثلاثي الأبعاد واختيار نوع الضوء.
- [المادة](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): يمكن أن يجلب ضبط نوع مادة الشكل الثلاثي الأبعاد تأثيرًا أكثر حيوية. توفر الخاصية مجموعة من المواد المحددة مسبقًا، مثل: 
المعدن، البلاستيك، المسحوق، غير اللامع، إلخ.  

يمكن تطبيق جميع ميزات 3D على الأشكال والنصوص. دعنا نرى كيفية الوصول إلى الخصائص المذكورة أعلاه ثم نتناولها بالتفصيل خطوة بخطوة:
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

تبدو الصورة المُعالجة على هذا النحو:

![todo:image_alt_text](img_01_01.png)

## دوران ثلاثي الأبعاد
من الممكن تدوير أشكال PowerPoint ثلاثية الأبعاد في الفضاء ثلاثي الأبعاد، مما يجلب المزيد من التفاعل. لتدوير شكل ثلاثي الأبعاد في PowerPoint، عادة ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في واجهة برمجة تطبيقات Aspose.Slides، يمكن إدارة دوران الشكل ثلاثي الأبعاد باستخدام خاصية [الكاميرا](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## عمق وثقب ثلاثي الأبعاد
لإضفاء البعد الثالث على الشكل وجعله شكلًا ثلاثي الأبعاد، استخدم خصائص [ ارتفاع البروز](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
و [لون البروز](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

عادةً، تستخدم قائمة العمق في PowerPoint لضبط العمق لشكل PowerPoint ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)

## تدرج ثلاثي الأبعاد
يمكن استخدام التدرج لملء لون شكل PowerPoint ثلاثي الأبعاد. دعنا نخلق شكلًا بلون ملء متدرج ونطبق عليه تأثير ثلاثي الأبعاد:

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

بجانب لون الملء المتدرج، يمكن أيضًا ملء الأشكال بصورة:
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... setup 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

إليك كيف يبدو الشكل:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
يتيح Aspose.Slides تطبيق التأثيرات الثلاثية الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد، من الممكن استخدام تأثير تحويل WordArt:

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
    shape.text_frame.text = "نص ثلاثي الأبعاد"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # setup "Arch Up" تأثير تحويل WordArt
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

وإليك الناتج:

![todo:image_alt_text](img_02_05.png)

## غير مدعوم - قادم قريبًا
الميزات التالية في PowerPoint 3D غير مدعومة بعد:
- الحواف
- المادة
- الحواف
- الإضاءة

نواصل تحسين محرك 3D الخاص بنا وهذه الميزات هي موضوع تنفيذ إضافي.