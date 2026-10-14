---
title: تنسيق أشكال PowerPoint في Python
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل المخطط
- تنسيق نمط الانضمام
- ملء متدرج
- ملء نمط
- ملء صورة
- ملء نسيج
- ملء بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج رمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python باستخدام Aspose.Slides—ضبط أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال مكوَّنة من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق التأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال من خلال تحديد الإعدادات التي تتحكم في كيفية ملء داخليتها.

![format-shape-powerpoint](format-shape-powerpoint.png)

توفر Aspose.Slides للغة Python فصولًا وخصائص تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنformat Lines**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) للشكل.
5. تعيين عرض الخط.
6. تعيين [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) للشكل.
7. تعيين لون الخط للشكل.
8. احفظ العرض التقديمي المعدل كملف PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع المستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # إزالة التعبئة من الشكل المستطيل بحيث تظهر خطوطه فقط.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # تطبيق التنسيق على خطوط المستطيل.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # تحديد لون خط المستطيل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ ملف PPTX على القرص.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The formatted lines in the presentation](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضيف تأثير الرسم التخطيطي مظهرًا للخط كأنه مرسوم يدويًا. استخدم [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) للوصول إلى إعدادات الخط، و[LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

يعرض الشيفرة Python التالية كيفية تطبيق تأثير [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # الوصول إلى تنسيق الخط للشكل وتنسيق الرسم التخطيطي الخاص به.
    sketch_format = shape.line_format.sketch_format

    # تطبيق تأثير رسم تخطيطي.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # قراءة تأثير الرسم التخطيطي المعين مباشرةً إلى الشكل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # إزالة تأثير الرسم التخطيطي.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

القيمة التي تُرجِعها الخاصية `SketchFormat.sketch_type` تمثل الإعداد المُعين مباشرةً للشكل. إذا كان يمكن أن يتم وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)، ثم وصول إلى الخاصية `sketch_format` للعنصر المُعاد، وقراءة خاصية `sketch_type` الخاصة به. القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة:

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

## **تنformat Join Styles**

فيما يلي خيارات ثلاثة لأنواع الانضمام:

* مستديرة
* مائلة
* مشطوفة

بشكل افتراضي، عندما يقوم PowerPoint بدمج خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **مستديرة**. ومع ذلك، إذا كنت ترسم شكلًا بزوايا حادة، قد تفضّل خيار **مائلة**.

![The join style in the presentation](join-style-powerpoint.png)

يعرض الشيفرة Python التالية كيف تم إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الانضمام مائلة، مشطوفة، ومستديرة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

	# الحصول على الشريحة الأولى.
	slide = presentation.slides[0]

	# إضافة ثلاثة أشكال أوتوماتيكية من نوع المستطيل.
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

	# تعيين لون خط كل مستطيل.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# تعيين نمط الانضمام.
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

## **ملء متدرج**

في PowerPoint، يُعد ملء التدرج خيارًا تنسيقيًا يتيح لك تطبيق تدرج لوني مستمر على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق ملء متدرج على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `GRADIENT`.
5. إضافة اللونين المفضلين لديك مع تحديد المواضع باستخدام طرق `add` لمجموعة `gradient_stops` التي تُعرض عبر فئة [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) .
6. احفظ العرض التقديمي المعدل كملف PPTX.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع القطعة البيضوية.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # تطبيق تنسيق التدرج على القطعة البيضوية.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # تعيين اتجاه التدرج.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # إضافة نقطتي توقف للمتدرج.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # حفظ ملف PPTX على القرص.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The ellipse with gradient fill](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير ملء التدرج المخزن في العرض.

## **ملء بنمط**

في PowerPoint، يُعد ملء النمط خيارًا تنسيقيًا يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدمه.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك طريقة تطبيق ملء بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `PATTERN`.
5. اختيار نمط نمط من الخيارات المسبقة.
6. تعيين [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) للنمط.
7. تعيين [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) للنمط.
8. احفظ العرض التقديمي المعدل كملف PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع المستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى نمط.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # تعيين نمط النقشة.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # تعيين ألوان الخلفية والواجهة للنمط.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The rectangle with pattern fill](pattern-fill.png)

## **ملء صورة**

في PowerPoint، يُعد ملء الصورة خيارًا تنسيقيًا يتيح لك إدراج صورة داخل الشكل—وبذلك تُستَخدم الصورة كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `PICTURE`.
5. تعيين وضع ملء الصورة إلى `TILE` (أو وضع آخر مفضل).
6. إنشاء كائن من نوع [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
7. تعيين هذه الصورة إلى الخاصية `picture.image` في `picture_fill_format` للشكل.
8. احفظ العرض التقديمي المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" مع الصورة التالية:

![The lotus picture](lotus.png)

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع المستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # تعيين نوع التعبئة إلى صورة.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تعيين وضع ملء الصورة.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # تعيين الصورة.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # حفظ ملف PPTX على القرص.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The shape with picture fill](picture-fill.png)

### **استخدام صورة متكررة كنسيج**

إذا كنت تريد تعيين صورة متكررة كنسيج وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): يحدد وضع ملء الصورة—إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): يحدد محاذاة البلاطات داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): يتحكم فيما إذا كانت البلاطة مقلوبة أفقيًا أو رأسيًا أو كليهما.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): يحدد الإزاحة الأفقية للبلاطة (بالنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): يحدد الإزاحة الرأسية للبلاطة (بالنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): يحدد مقياس البلاطة الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): يحدد مقياس البلاطة الرأسي كنسبة مئوية.

يعرض المثال البرمجي التالي كيفية إضافة شكل مستطيل بملء صورة متكررة وتكوين خيارات البلاطة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    first_slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي مستطيل.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # تعيين نوع تعبئة الشكل إلى صورة.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # تعيين الصورة إلى الشكل.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # تهيئة وضع ملء الصورة وخصائص التكرار.
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

![The tile options](tile-options.png)

## **ملء بلون صلب**

في PowerPoint، يُعد ملء بلون صلب خيارًا تنسيقيًا يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق ملء بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `SOLID`.
5. تعيين لون التعبئة المفضل لديك إلى الشكل.
6. احفظ العرض التقديمي المعدل كملف PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع المستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى صلب.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # تعيين لون التعبئة.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # حفظ ملف PPTX على القرص.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The shape with solid color fill](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عندما تطبق ملءً بلون صلب أو تدرج أو صورة أو نسيج على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في عتمة التعبئة. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات السفلى جزئيًا.

تمكنك Aspose.Slides من تعيين مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين نوع التعبئة إلى `SOLID`.
5. استخدام `Color.from_argb` لتحديد لون مع شفافية (المكون `alpha` يتحكم في الشفافية).
6. احفظ العرض التقديمي.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]
    
    # إضافة شكل أوتوماتيكي مستطيل صلب.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # إضافة شكل أوتوماتيكي مستطيل شفاف فوق الشكل الصلب.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The transparent shape](shape-transparency.png)

## **تدوير الأشكال**

تمكنك Aspose.Slides من تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية مع احتياجات معينة للموضع أو التصميم.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية `rotation` للشكل إلى الزاوية المطلوبة.
5. احفظ العرض التقديمي.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل أوتوماتيكي من نوع المستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تدوير الشكل بزاوية 5 درجات.
    shape.rotation = 5

    # حفظ ملف PPTX على القرص.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The shape rotation](shape-rotation.png)

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

تمكنك Aspose.Slides من تطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تكوين [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) للشكل لتحديد إعدادات الحافة.
5. احفظ العرض التقديمي.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

تمكنك Aspose.Slides من تطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) و[light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) لل shape لتحديد الدوران ثلاثي الأبعاد.
5. احفظ العرض التقديمي.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
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

![The 3D rotation effect](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد خاصية [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) كيفية عرض شكل فردي عندما يتم عرض أو معالجة العرض في وضع الأسود والأبيض. لا تُفعِّل العرض بالأبيض والأسود بحد ذاته، ولا تُغيّر ملء الشكل أو خطه أو تنسيقات أخرى في وضع اللون العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `AUTOMATIC` يسمح لتطبيق العرض باختيار التحويل، و`GRAY` و`LIGHT_GRAY` يستخدمان تلوينًا رماديًا، و`BLACK_WHITE` يستخدم فقط اللونين الأسود والأبيض، و`BLACK` و`WHITE` يجبران على لون واحد، و`COLOR` يحافظ على تلوين عادي، و`HIDDEN` يحذف الشكل في وضع الأسود والأبيض. `NOT_DEFINED` تعني عدم تعيين وضع على مستوى الشكل.

يعرض الشيفرة Python التالية كيفية إنشاء شكل ملون وجعله يظهر باللون الرمادي في وضع العرض بالأبيض والأسود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # احتفظ بملء اللون البرتقالي في وضع اللون، ولكن عرض الشكل بتلوين رمادي في وضع الأسود والأبيض.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `GRAY`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات العرض بالأبيض والأسود للعرض.

## **إعادة تعيين التنسيق**

يعرض الشيفرة Python التالية كيفية إعادة تعيين تنسيق شريحة وإرجاع موضع وحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة على [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # إعادة ضبط كل شكل على الشريحة الذي له عنصر نائب في التخطيط.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على الحجم النهائي لملف العرض التقديمي؟**

قليلًا فقط. تحتل الصور والوسائط المضمّنة معظم مساحة الملف، بينما تُخزَّن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا إضافيًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متماثل بحيث يمكنني تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل—الإعدادات الخاصة بالملء والخط والتأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقياً، مما يُسهِّل إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة في ملف منفصل لاستخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وطبق تنسيقها مرة أخرى حيثما يلزم.