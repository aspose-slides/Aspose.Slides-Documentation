---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/python-net/shape-formatting/
keywords: "تنسيق الشكل، تنسيق الخطوط، تنسيق أنماط الانضمام، تعبئة متدرج، تعبئة نمطية، تعبئة صورة، تعبئة بلون صلب، تدوير الأشكال، تأثيرات حواف ثلاثية الأبعاد، تأثير دوران ثلاثي الأبعاد، عرض تقديمي PowerPoint، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "تنسيق شكل في عرض تقديمي PowerPoint باستخدام بايثون"
---

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيق الأشكال عن طريق تعديل أو تطبيق تأثيرات معينة على خطوطها المكونة. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال من خلال تحديد الإعدادات التي تحدد كيفية تعبئة المنطقة داخلها.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides لـ Python عبر .NET** يوفر واجهات وخصائص تسمح لك بتنسيق الأشكال استنادًا إلى الخيارات المعروفة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط الخط المفضل لديك لشكل. توضح هذه الخطوات إجراءً من هذا القبيل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين العرض لخطوط الشكل.
6. تعيين [نمط الخط](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) لخط الشكل.
7. تعيين [نمط الخط المتقطع](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) لخط الشكل.
8. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية باستخدام بايثون عملية قمنا فيها بتنسيق مستطيل `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Prseetation تمثل ملف PPTX
with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى
    sld = pres.slides[0]

    # يضيف شكل مستطيل تلقائي
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # يحدد لون تعبئة شكل المستطيل
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # يطبق بعض التنسيقات على خطوط المستطيل
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # يحدد اللون لخط المستطيل
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # يكتب ملف PPTX إلى القرص
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسيق أنماط الانضمام**

هذه هي 3 خيارات لأنماط الانضمام:

* دائري
* مائل
* حافة

بشكل افتراضي، عندما ينضم PowerPoint إلى خطين بزاوية (أو زاوية شكل)، فإنه يستخدم إعداد **دائري**. ومع ذلك، إذا كنت ترغب في رسم شكل بزوايا حادة جدًا، فقد ترغب في اختيار **مائل**.

![join-style-powerpoint](join-style-powerpoint.png)

توضح هذه الشيفرة البرمجية باستخدام بايثون عملية تم فيها إنشاء 3 مستطيلات (الصورة أعلاه) باستخدام إعدادات أنماط الانضمام مائل، حافة، ودائري:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Prseetation تمثل ملف PPTX
with slides.Presentation() as pres:
	# يحصل على الشريحة الأولى
	sld = pres.slides[0]

	# يضيف 3 أشكال مستطيلة تلقائية
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# يحدد لون تعبئة شكل المستطيل
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# يحدد عرض الخط
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# يحدد اللون لخط المستطيل
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# يحدد نمط الانضمام
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# يضيف نصًا إلى كل مستطيل
	shp1.text_frame.text = "هذا هو نمط الانضمام مائل"
	shp2.text_frame.text = "هذا هو نمط الانضمام حافة"
	shp3.text_frame.text = "هذا هو نمط الانضمام دائري"

	# يكتب ملف PPTX إلى القرص
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **تعبئة متدرجة**
في PowerPoint، تعبئة متدرجة هي خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد حيث يتلاشى لون واحد ببطء ويتحول إلى لون آخر.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لتطبيق تعبئة متدرجة على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `متدرج`.
5. إضافة لونين مفضلين لديك مع المواقع المحددة باستخدام طرق `Add` المعروفة من مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية باستخدام بايثون عملية تم فيها استخدام تأثير التعبئة المتدرجة على شكل بيضاوي:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Presentation تمثل ملف عرض تقديمي
with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى
    sld = pres.slides[0]

    # يضيف شكل بيضاوي تلقائي
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # يطبق تنسيق متدرج على الشكل البيضاوي
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # يحدد اتجاه التدرج
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # يضيف 2 من توقفات التدرج
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # يكتب ملف PPTX إلى القرص
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **تعبئة نمطية**
في PowerPoint، تعبئة نمطية هي خيار تنسيق يسمح لك بتطبيق تصميم ثنائي اللون يتكون من نقاط، خطوط، أو مربعات على شكل. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك للخلفية والألوان الأمامية للنمط.

تقدم Aspose.Slides أكثر من 45 نمطًا محددًا مسبقًا يمكن استخدامها لتنسيق الأشكال وتزيين العروض التقديمية. حتى بعد اختيار نمط نمطي محدد مسبقًا، يمكنكstill تحديد الألوان التي يجب أن يحتويها النمط.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لتطبيق تعبئة نمطية على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `نمط`.
5. تعيين نمط التعبئة المفضل لديك للشكل.
6. تعيين لون الخلفية لـ [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. تعيين لون المقدمة لـ [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية باستخدام بايثون عملية تم فيها استخدام تعبئة نمطية لتزين مستطيل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Presentation تمثل ملف عرض تقديمي
with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى
    sld = pres.slides[0]

    # يضيف شكل مستطيل تلقائي
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # يحدد نوع التعبئة إلى نمط
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # يحدد نمط التعبئة
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # يحدد لون الخلفية والألوان الأمامية للنمط
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # يكتب ملف PPTX إلى القرص
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **تعبئة صورة**
في PowerPoint، تعبئة الصورة هي خيار تنسيق يسمح لك بوضع صورة داخل شكل. بشكل أساسي، يمكنك استخدام صورة كخلفية للشكل.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لتعبئة شكل بصورة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `صورة`.
5. تعيين وضع تعبئة الصورة إلى البلاط.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي ستستخدم لتعبئة الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` إلى `IPPImage` الذي تم إنشاؤه مؤخرًا.
8. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية كيفية تعبئة شكل بصورة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Prseetation تمثل ملف PPTX
with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى
    sld = pres.slides[0]

    # يضيف شكل مستطيل تلقائي
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)


    # يحدد نوع التعبئة إلى صورة
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # يحدد وضع تعبئة الصورة
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # يحدد الصورة
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # يكتب ملف PPTX إلى القرص
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **تعبئة بلون صلب**
في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يسمح لك بملء شكل بلون واحد. اللون المختار يكون عادةً لونًا عاديًا. يتم تطبيق اللون على خلفية الشكل مع أي تأثيرات خاصة أو تعديلات.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لتطبيق تعبئة بلون صلب على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشكل إلى `صلب`.
5. تعيين اللون المفضل لديك للشكل.
6. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية كيفية تطبيق تعبئة بلون صلب على مربع في PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # يحصل على الشريحة الأولى
    slide = presentation.slides[0]

    # يضيف شكل مستطيل تلقائي
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # يحدد نوع التعبئة إلى صلب
    shape.fill_format.fill_type = slides.FillType.SOLID

    # يحدد اللون للمستطيل
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # يكتب ملف PPTX إلى القرص
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديد الشفافية**

في PowerPoint، عندما تقوم بملء الأشكال بألوان صلبة، أو متدرجة، أو صور، أو نسيج، يمكنك تحديد مستوى الشفافية الذي يحدد شفافية التعبئة. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، سيظهر عنصر الشريحة أو الخلفية خلف الشكل.

يسمح لك Aspose.Slides بتعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. استخدام `Color.FromArgb` مع قيمة المكون ألفا محددة.
5. حفظ الكائن كملف PowerPoint.

توضح هذه الشيفرة البرمجية عملية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # يضيف شكل صلب
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # يضيف شكل شفاف فوق الشكل الصلب
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **تدوير الأشكال**
يسمح لك Aspose.Slides بتدوير شكل مضاف إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تدوير الشكل بدرجات الحاجة.
5. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية كيفية تدوير شكل بزاوية 90 درجة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى
    sld = pres.slides[0]

    # يضيف شكل مستطيل تلقائي
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # يدور الشكل بزاوية 90 درجة
    shp.rotation = 90

    # يكتب ملف PPTX إلى القرص
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة تأثيرات حواف ثلاثية الأبعاد**
يسمح لك Aspose.Slides لـ Python عبر .NET بإضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تعيين معلماتك المفضلة لخصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) للشكل.
5. كتابة العرض التقديمي إلى القرص.

توضح هذه الشيفرة البرمجية كيفية إضافة تأثيرات حواف ثلاثية الأبعاد إلى شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # يضيف شكلًا إلى الشريحة
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # يحدد خصائص ThreeDFormat للشكل
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # يكتب العرض التقديمي كملف PPTX
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة تأثير دوران ثلاثي الأبعاد**
يسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) إلى الشريحة.
4. تحديد الأشكال المفضلة لديك لـ CameraType و LightType.
5. كتابة العرض التقديمي إلى القرص.

توضح هذه الشيفرة البرمجية كيفية تطبيق تأثيرات دوران ثلاثي الأبعاد على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا من فئة Presentation
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **إعادة تعيين التنسيق**

توضح هذه الشيفرة البرمجية باستخدام بايثون كيفية إعادة تعيين التنسيق في شريحة وإرجاع الموقع والحجم والتنسيق لكل شكل يحتوي على عنصر نائب على [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) إلى قيمها الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # سيتم إرجاع كل شكل على الشريحة الذي يحتوي على عنصر نائب على التخطيط إلى قيمته الافتراضية
        slide.reset()
```