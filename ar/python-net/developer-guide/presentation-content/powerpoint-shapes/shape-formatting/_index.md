---
title: تنسيق أشكال PowerPoint في بايثون
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل المرسوم
- تنسيق نمط الوصل
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنسيج
- تعبئة بلون صلب
- شفافية الشكل
- دوران الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير التدوير ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint في بايثون باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثيرات لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Python فئات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linedashstyle/) للشكل.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة Python يوضح كيفية تنسيق مستطيل `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # تعيين لون التعبئة للشكل المستطيل.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # تطبيق تنسيق على خطوط المستطيل.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # تعيين اللون لخط المستطيل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ ملف PPTX على القرص.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يضيف تأثير الرسم مظهرًا كأن الخط مرسوم يدويًا. استخدم [Shape.line_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/line_format/) للوصول إلى إعدادات الخط، [LineFormat.sketch_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lineformat/sketch_format/) للوصول إلى إعدادات الرسم، و[SketchFormat.sketch_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sketchformat/sketch_type/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/).

الكود التالي يوضح كيفية تطبيق تأثير [LineSketchType.CURVED](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.NONE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # الوصول إلى تنسيق خط الشكل وتنسيق الرسم.
    sketch_format = shape.line_format.sketch_format

    # تطبيق تأثير الرسم.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # قراءة تأثير الرسم المعين مباشرةً إلى الشكل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # إزالة تأثير الرسم.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

القيمة التي يرجعها `SketchFormat.sketch_type` تمثل الإعداد المعين مباشرةً للشكل. إذا كان تنسيق الخط يمكن وراثته من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lineformat/get_effective/)، وصول إلى خاصية `sketch_format` للكائن المعاد، وقراءة خاصية `sketch_type` الخاصة به. القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **تنسيق أنماط الانضمام**

فيما يلي خيارات ثلاثة لأنواع الوصل:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزاويا حادة، قد تفضّل خيار **Miter**.

![نمط الوصل في العرض](join-style-powerpoint.png)

الكود التالي يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل Miter وBevel وRound:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

	# الحصول على الشريحة الأولى.
	slide = presentation.slides[0]

	# إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# تعيين لون التعبئة لكل شكل مستطيل.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# تعيين عرض الخط.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# تعيين اللون لخط كل مستطيل.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# تعيين نمط الوصل.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# إضافة نص إلى كل مستطيل.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# حفظ ملف PPTX على القرص.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **تعبئة متدرجة**

في PowerPoint، تعبئة متدرجة هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `GRADIENT`.
1. إضافة اللونين المفضّلين لديك مع تحديد المواقع باستخدام طريقة `add` لمجموعة `gradient_stops` التي يوفّرها الفئة [GradientFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تطبيق تأثير تعبئة متدرجة على إهليلج:

```python
import aspose.slides as slides

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # تطبيق تنسيق تدرج على الشكل الإهليلجي.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # تعيين اتجاه التدرج.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # إضافة نقطتي تدرج.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # حفظ ملف PPTX على القرص.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الإهليلج مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم ذو لونين—مثل النقاط أو الخطوط أو التلاميـد المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية ونقوش النمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتحسين المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `PATTERN`.
1. اختيار نمط نمطي من الخيارات المحددة مسبقًا.
1. تعيين خاصية [back_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/back_color/) للنمط.
1. تعيين خاصية [fore_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/fore_color/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تطبيق تعبئة بنمط على مستطيل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # تعيين نمط النمط.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # تعيين ألوان الخلفية والواجهة للنمط.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

في PowerPoint، تعبئة بصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—مما يجعل الصورة خلفية الشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة بصورة على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `PICTURE`.
1. تعيين وضع تعبئة الصورة إلى `TILE` (أو أي وضع مفضّل آخر).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. إسناد هذه الصورة إلى خاصية `picture.image` لتنسيق تعبئة صورة الشكل `picture_fill_format`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي يوضح كيفية تعبئة شكل بالصورة:

```python
import aspose.slides as slides

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # تعيين نوع التعبئة إلى Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تعيين وضع تعبئة الصورة.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # تحميل صورة وإضافتها إلى موارد العرض.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # تعيين الصورة.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # حفظ ملف PPTX على القرص.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة مبلطة كملمس**

إذا أردت تعيين صورة مبلطة كملمس وتخصيص سلوك التبليط، يمكنك استخدام الخصائص التالية للفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/picture_fill_mode/): يحدد وضع تعبئة الصورة—إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_alignment/): يحدد محاذاة البلاط داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_flip/): يتحكم فيما إذا كان البلاط يُقلب أفقياً أو رأسياً أو كليهما.
- [tile_offset_x](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_offset_x/): يحدد إزاحة البلاط أفقياً (بالنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_offset_y/): يحدد إزاحة البلاط رأسياً (بالنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_scale_x/): يعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_scale_y/): يعرّف مقياس البلاط العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل مع تعبئة صورة مبلطة وتكوين خيارات التبليط:

```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    first_slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # تعيين نوع التعبئة للشكل إلى Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تحميل الصورة وإضافتها إلى موارد العرض.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # إسناد الصورة إلى الشكل.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # تكوين وضع تعبئة الصورة وخصائص التبليط.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # حفظ ملف PPTX على القرص.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خيارات التبليط](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو نُسُج أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `SOLID`.
1. إسناد لون التعبئة المفضّل إلى الشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # تعيين لون التعبئة.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عندما تطبق لونًا صلبًا أو تعبئة متدرجة أو صورة أو نسيجًا على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في شفافية التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح للملف الخلفي أو الكائنات الأساسية بأن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة alpha في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين نوع التعبئة إلى `SOLID`.
1. استخدام `Color.from_argb` لتعريف لون مع شفافية (مكوّن الـ `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]
    
    # إضافة شكل تلقائي مستطيل صلب.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند تحديد مواضع العناصر البصرية وفقًا لاحتياجات محاذاة أو تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية `rotation` لل shape إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي يوضح كيفية تدوير شكل بزاوية 5 درجات:

```python
import aspose.slides as slides

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تدوير الشكل بزاوية 5 درجات.
    shape.rotation = 5

    # حفظ ملف PPTX على القرص.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) .

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين خاصية [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) لتحديد إعدادات الحافة.
1. حفظ العرض.

الكود التالي يوضح كيفية تطبيق تأثيرات حافة ثلاثية الأبعاد على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # إضافة شكل إلى الشريحة.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # تعيين خصائص ThreeDFormat للشكل.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات التدوير ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات التدوير ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) .

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصيتي [camera_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/camera/camera_type/) و[light_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lightrig/light_type/) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي يوضح كيفية تطبيق تأثيرات التدوير ثلاثية الأبعاد على شكل:

```python
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الكود التالي يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موقع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

التأثير ضئيل فقط. الصور والوسائط المدمجة تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متماثل لكي أقوم بتجميعها؟**

قارن الخصائص التنسيقية الأساسية لكل شكل—الإعدادات المتعلقة بالملء، الخط، والمؤثرات. إذا طابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة نموذج أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات التنسيق المطلوب، وطبق تنسيقاتها حسب الحاجة.