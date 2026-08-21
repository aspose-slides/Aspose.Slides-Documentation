---
title: تنسيق أشكال PowerPoint في Python
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل بالرسم
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنقش
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالدرجات الرمادية
- تدوير الشكل
- تأثير بيفيل ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint باستخدام Python و Aspose.Slides—حدد أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة الأشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق التأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عبر تحديد الإعدادات التي تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides للغة Python فئات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين [line style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linestyle/) للشكل.
5. تعيين عرض الخط.
6. تعيين [dash style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linedashstyle/) للشكل.
7. تعيين لون الخط للشكل.
8. حفظ العرض المعدل كملف PPTX.

يُظهر الكود التالي بلغة Python كيفية تنسيق `AutoShape` على شكل مستطيل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # إزالة التعبئة من شكل المستطيل بحيث تكون خطوطه فقط مرئية.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # تطبيق تنسيق على خطوط المستطيل.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # تحديد اللون لخط المستطيل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الخطوط المُنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يُضفي تأثير الرسم مظهرًا يدويًا على خط الشكل. استخدم [Shape.line_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/line_format/) للوصول إلى إعدادات الخط، و[LineFormat.sketch_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lineformat/sketch_format/) للوصول إلى إعدادات الرسم، و[SketchFormat.sketch_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sketchformat/sketch_type/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/).

يعرض الكود التالي بلغة Python كيفية تطبيق تأثير [LineSketchType.CURVED](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/) ، وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.NONE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/linesketchtype/) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # الوصول إلى تنسيق خط الشكل وتنسيق الرسم التخطيطي الخاص به.
    sketch_format = shape.line_format.sketch_format

    # تطبيق تأثير رسم تخطيطي.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # قراءة تأثير الرسم التخطيطي المعين مباشرةً للشكل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # إزالة تأثير الرسم التخطيطي.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

القيمة التي تُعيدها `SketchFormat.sketch_type` تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lineformat/get_effective/)، وِصل إلى خاصية `sketch_format` للكائن المُعاد، واقرأ خاصية `sketch_type` الخاصة بها. القيمة الفعلية تعكس التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة:

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

## **تنسيق أنماط التقاطع**

إليك ثلاثة خيارات لنوع التقاطع:

* مستدير
* ميتّر
* محدب

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **Round**. ومع ذلك، إذا كنت ترسم شكلًا بزاوية حادة، قد تفضّل خيار **Miter**.

![نمط التقاطع في العرض](join-style-powerpoint.png)

يظهر الكود التالي بلغة Python كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع التقاطع Miter وBevel وRound:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

	# الحصول على الشريحة الأولى.
	slide = presentation.slides[0]

	# إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
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

	# تعيين نمط الوصل.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# إضافة نص إلى كل مستطيل.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# حفظ ملف PPTX إلى القرص.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **تعبئة تدرجية**

في PowerPoint، تعبئة التدرج هي خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتحول أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين الخاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `GRADIENT`.
5. إضافة اللونين المفضّلين لديك مع تحديد المواقع باستخدام طرق `add` لمجموعة `gradient_stops` التي يوفّرها الفئة [GradientFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/gradientformat/) .
6. حفظ العرض المعدل كملف PPTX.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # تطبيق تنسيق تدرج على الشكل البيضاوي.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # تعيين اتجاه التدرج.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # إضافة نقطتي تدرج.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الإهليلج بتعبئة تدرجية](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم من لونين—مثل النقاط، أو الخطوط المتعرّجة، أو التعرجات المتقاطعة، أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للخلفية والواجهة للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا محددًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك. حتى بعد اختيار نمط محدد مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك طريقة تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين الخاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `PATTERN`.
5. اختيار نمط نمط من الخيارات المحددة مسبقًا.
6. تعيين الخاصية [back_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/back_color/) للنمط.
7. تعيين الخاصية [fore_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternformat/fore_color/) للنمط.
8. حفظ العرض المعدل كملف PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # تعيين نمط النقشة.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # تعيين ألوان الخلفية والواجهة للنقشة.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![المستطيل بتعبئة نمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يسمح لك بإدراج صورة داخل شكل—بشكل فعّال كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين الخاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `PICTURE`.
5. تعيين وضع تعبئة الصورة إلى `TILE` (أو وضع آخر مفضّل).
6. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
7. تعيين هذه الصورة إلى الخاصية `picture.image` في `picture_fill_format` الخاص بالشكل.
8. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Rectangle.
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

    # حفظ ملف PPTX إلى القرص.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الشكل بتعبئة صورة](picture-fill.png)

### **تحديد صورة متكررة كنقش**

إذا كنت تريد تعيين صورة متكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/picture_fill_mode/): تحدد وضع تعبئة الصورة — إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_alignment/): تحدد محاذاة القوالب داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_flip/): تتحكم فيما إذا كانت القالب مقلوبة أفقيًا أو رأسيًا أو كليهما.
- [tile_offset_x](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_offset_x/): تحدد الإزاحة الأفقية للقالب (بالنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_offset_y/): تحدد الإزاحة العمودية للقالب (بالنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_scale_x/): تحدد مقياس القالب الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/tile_scale_y/): تحدد مقياس القالب العمودي كنسبة مئوية.

يظهر المثال التالي كيفية إضافة شكل مستطيل مع تعبئة صورة متكررة وتكوين خيارات القالب:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    first_slide = presentation.slides[0]

    # إضافة شكل تلقائي مستطيل.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # تعيين نوع التعبئة للشكل إلى Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تحميل الصورة وإضافتها إلى موارد العرض.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # تعيين الصورة إلى الشكل.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # تكوين وضع تعبئة الصورة وخصائص التكرار.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # حفظ ملف PPTX إلى القرص.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![خيارات القالب](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين الخاصية [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) للشكل إلى `SOLID`.
5. تعيين لون التعبئة المفضّل إلى الشكل.
6. حفظ العرض المعدل كملف PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # تعيين لون التعبئة.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # حفظ ملف PPTX إلى القرص.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الشكل بتعبئة لون صلب](solid-color-fill.png)

## **تحديد الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو تدرج أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في عتمة التعبئة. كلما ارتفعت قيمة الشفافية، أصبح الشكل أكثر شفافية، مما يسمح بظهور الخلفية أو الكائنات الموجودة تحته جزئيًا.

تتيح لك Aspose.Slides ضبط مستوى الشفافية من خلال تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين نوع التعبئة إلى `SOLID`.
5. استخدام `Color.from_argb` لتحديد لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
6. حفظ العرض.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
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

تسمح لك Aspose.Slides بتدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع عناصر بصرية بمواضع معينة أو وفق احتياجات تصميمية.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين خاصية `rotation` للشكل إلى الزاوية المطلوبة.
5. حفظ العرض.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثّل ملف عرض تقديمي.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تدوير الشكل بـ 5 درجات.
    shape.rotation = 5

    # حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات بيفيل ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات بيفيل ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) .

لإضافة تأثيرات بيفيل ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. ضبط [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) للشكل لتحديد إعدادات البيفيل.
5. حفظ العرض.

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

    # حفظ العرض كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تأثير بيفيل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) .

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. تعيين الخاصيتين [camera_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/camera/camera_type/) و[light_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/lightrig/light_type/) للشكل لتحديد دوران ثلاثي الأبعاد.
5. حفظ العرض.

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

    # حفظ العرض كملف PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في عرض الشكل بالأبيض والأسود**

خاصية [Shape.black_white_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/black_white_mode/) تحدد كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض بالأبيض والأسود. لا تُفعّل العرض بالأبيض والأسود بذاتها، ولا تُغيّر تعبئة الشكل أو خطه أو تنسيقه الآخر في وضع اللون الطبيعي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `AUTOMATIC` يترك تطبيق العرض يختار التحويل، `GRAY` و`LIGHT_GRAY` يستخدمان تلوينًا رماديًا، `BLACK_WHITE` يستخدم فقط الأسود والأبيض، `BLACK` و`WHITE` يفرضان لونًا واحدًا، `COLOR` يحافظ على التلوين الطبيعي، و`HIDDEN` يحذف الشكل في وضع الأبيض والأسود. `NOT_DEFINED` يعني أنه لم يتم تعيين وضع على مستوى الشكل.

الكود التالي بلغة Python ينشئ شكلًا ملونًا ويظهره باللون الرمادي في وضع العرض بالأبيض والأسود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # احتفظ بتعبئة اللون البرتقالي في وضع اللون، ولكن اعرض الشكل بتلوين رمادي في وضع الأبيض والأسود.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

في وضع اللون الطبيعي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه تم تعيينه إلى `GRAY`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو غيرها من سير العمل التي تحترم إعدادات العرض بالأبيض والأسود للعرض.

## **إعادة تعيين التنسيق**

يعرض الكود التالي بلغة Python طريقة إعادة تعيين تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال التي تحتوي على عناصر نائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # إعادة ضبط كل شكل على الشريحة الذي لديه عنصر نائبي في التخطيط.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. تحتل الصور والوسائط المضمنة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف تقريبًا أي حجم إضافي.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متماثل حتى أتمكن من تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل — تعبئة، خط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصّصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ نماذج الأشكال ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما استدعى الأمر.