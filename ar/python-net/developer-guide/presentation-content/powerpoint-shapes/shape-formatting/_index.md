---
title: تنسيق أشكال PowerPoint في Python
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الانضمام
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيجية
- تعبئة بلون صلب
- شفافية الشكل
- دوران الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية تنسيق أشكال PowerPoint في Python باستخدام Aspose.Slides—اضبط أنماط الملء والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال مكوّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية ملء داخلياتها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Python فئات وخصائص تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. ضبط [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) للشكل.
1. ضبط لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

يوضح كود Python التالي كيفية تنسيق `AutoShape` مستطيل:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # ضبط لون التعبئة لشكل المستطيل.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # تطبيق التنسيق على خطوط المستطيل.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # ضبط لون خط المستطيل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ ملف PPTX على القرص.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تنسيق أنماط الانضمام**

إليك خيارات ثلاثة لأنواع الانضمام:

* Round
* Miter
* Bevel

افتراضيًا، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية الشكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **Miter**.

![نمط الانضمام في العرض](join-style-powerpoint.png)

يوضح كود Python التالي كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات الانضمام Miter وBevel وRound:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

	# الحصول على الشريحة الأولى.
	slide = presentation.slides[0]

	# إضافة ثلاثة أشكال تلقائية من نوع Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# ضبط لون التعبئة لكل شكل مستطيل.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# ضبط عرض الخط.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# ضبط لون خط كل مستطيل.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# ضبط نمط الانضمام.
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


## **تعبئة تدرجية**

في PowerPoint، تعبئة تدرجية هي خيار تنسيق يسمح لك بتطبيق تدرج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى فيها أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) الخاص بالشكل إلى `GRADIENT`.
1. إضافة لونين مفضلين مع مواقع محددة باستخدام أساليب `add` لمجموعة `gradient_stops` التي يوفرها فئة [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

يوضح كود Python التالي كيفية تطبيق تأثير تعبئة تدرجية على شكل بيضاوي:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # تطبيق تنسيق التدرج على الشكل البيضاوي.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # ضبط اتجاه التدرج.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # إضافة نقطتي توقف للتدرج.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # حفظ ملف PPTX على القرص.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![البيضاوي مع تعبئة تدرجية](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة بنمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو الخطوط المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدمه.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقه على الأشكال لتحسين الجاذبية البصرية لعروضك التقديمية. حتى بعد اختيار نمط مسبق، يمكنكstill تحديد الألوان الدقيقة التي يجب عليه استخدامها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) الخاص بالشكل إلى `PATTERN`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. ضبط [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) للنمط.
1. ضبط [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

يوضح كود Python التالي كيفية تطبيق تعبئة بنمط على مستطيل:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ضبط نوع التعبئة إلى Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # ضبط نمط النمط.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # ضبط ألوان الخلفية ومقدمة النمط.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—بفعالية استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) الخاص بالشكل إلى `PICTURE`.
1. ضبط وضعية تعبئة الصورة إلى `TILE` (أو وضعية مفضلة أخرى).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تعيين هذه الصورة إلى الخاصية `picture.image` لتنسيق `picture_fill_format` الخاص بالشكل.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

يوضح كود Python التالي كيفية تعبئة شكل بالصورة:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # ضبط نوع التعبئة إلى Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ضبط وضع تعبئة الصورة.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # ضبط الصورة.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # حفظ ملف PPTX على القرص.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تبطين الصورة كقوام**

إذا كنت تريد تعيين صورة مكررة كقوام وتخصيص سلوك التبليط، يمكنك استخدام الخصائص التالية لفئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) : يحدد وضعية تعبئة الصورة—إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/) : يحدد محاذاة البلاط داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/) : يتحكم في ما إذا كان البلاط يُقلب أفقياً أو رأسياً أو كلاهما.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/) : يحدد إزاحة البلاط أفقياً (بنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/) : يحدد إزاحة البلاط رأسياً (بنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/) : يعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/) : يعرّف مقياس البلاط الرأسي كنسبة مئوية.

يوضح مثال الكود التالي كيفية إضافة شكل مستطيل بتعبئة صورة مكررة وتكوين خيارات البلاط:
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    first_slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # ضبط نوع التعبئة للشكل إلى Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # تعيين الصورة إلى الشكل.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # تكوين وضع تعبئة الصورة وخصائص البلاط.
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

![خيارات البلاط](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) الخاص بالشكل إلى `SOLID`.
1. تعيين اللون المفضل للتعبئة إلى الشكل.
1. حفظ العرض المعدل كملف PPTX.

يوضح كود Python التالي كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ضبط نوع التعبئة إلى Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # ضبط لون التعبئة.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عندما تطبق لونًا صلبًا أو تدرجًا أو صورة أو تعبئة قوام على الأشكال، يمكنك أيضًا تعيين مستوى شفافية للتحكم في عتامة التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح للخلفية أو الكائنات الأساسية بأن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides تعيين مستوى الشفافية عن طريق ضبط قيمة ألفا في اللون المستخدم للتعبئة. إليك كيفية القيام بذلك:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط نوع التعبئة إلى `SOLID`.
1. استخدام `Color.from_argb` لتعريف لون مع شفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

يوضح كود Python التالي كيفية تطبيق لون تعبئة شفاف على مستطيل:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

## **دوران الأشكال**

تتيح لك Aspose.Slides دوران الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع تتطلب محاذاة أو تصميمًا معينًا.

لدوّر شكلًا على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط خاصية `rotation` للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

يوضح كود Python التالي كيفية دوران شكل بزاوية 5 درجات:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات حواف ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات حواف ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) الخاص بالشكل لتحديد إعدادات الحافة.
1. حفظ العرض.

يوضح كود Python التالي كيفية تطبيق تأثيرات حواف ثلاثية الأبعاد على شكل:
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

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) و [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

يوضح كود Python التالي كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:
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

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة ضبط التنسيق**

يظهر كود Python التالي كيفية إعادة ضبط تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بشكل طفيف فقط. الصور والوسائط المضمّنة هي التي تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا ملحوظًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في نفس التنسيق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات المتعلقة بالملء، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المصممة التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.