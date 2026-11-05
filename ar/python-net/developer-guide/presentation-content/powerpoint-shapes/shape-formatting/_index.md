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
- خط شكل تخطيطي
- تنسيق نمط الانضمام
- تعبئة تدرج لوني
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج الرمادي
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python باستخدام Aspose.Slides — حدد تعبئة الخطوط وأنماط التأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها وتعبئتها وتأثيراتها. Aspose.Slides for Python عبر .NET يتيح لك التحكم في هذه الإعدادات برمجيًا، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python عبر .NET يوفر فئات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) للتحكم في حدود الشكل. يخلق هذا المثال مستطيلًا غير مملوء بحد أزرق متقطع. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) يحدد خطًا مركبًا سميكًا-رقيقًا، بينما [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) يضبط عرضه إلى 7 نقاط و[LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) يختار نمط الخط المتقطع.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط خطوط مخصصة**

استخدم [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) عندما لا توفر الأنماط المحددة مسبقًا أطوال الفواصل والفجوات التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. تعيين نمط تلقائيًا يضبط [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) إلى [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

تتبادل إدخالات القائمة بين أطوال الفواصل والفجوات، بدءًا بفاصل. كل قيمة هي مضاعف لعرض الخط: `[4, 2]` بعرض 3 نقاط ينتج فاصل بطول 12 نقطة يليه فجوة بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة غير السالبة لتحديد أقسام الفاصل والكفافة بالكامل. يستخدم المثال قيمًا موجبة للحفاظ على رؤية كل فاصل وفجوة.

ينشئ هذا المثال خمس خطوط زرقاء بنفس الطول والنهايات المسطحة. المقاطع الثلاثة الأولى تقارن الأنماط بعرض 3 نقاط. يكرر الرابع النمط الأول بعرض مضاعف، مع مضاعفة أطوال الفواصل والفجوات. يتحول الخامس من نمط مخصص إلى خط صلب.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # إعادة الخط الأخير إلى نمط صلب.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

للعودة إلى نمط متقطع محدد مسبقًا بدلاً من ذلك، عين [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) إلى [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint من الأعلى إلى الأسفل: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; و **Solid, 3 pt**.

![ثلاثة أنماط خطوط مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين نهايات الخط**

استخدم [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) لتعيين نهايات الخط المفتوح. توفر تعداد [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) ثلاثة أنماط واضحة للنهايات:

- `FLAT`: يتوقف الخط عند نقطة النهاية.
- `ROUND`: يمتد ختم نصف دائري إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `SQUARE`: يمتد ختم مربع إلى ما بعد نقطة النهاية بنصف عرض الخط.

يتضمن التعدد أيضًا `NOT_DEFINED`، مما يعني أنه لم يتم تعيين نمط نهية بشكل صريح.

النهايات تختلف عن رؤوس الأسهم التي تضيف رموزًا إلى نهايات الخط، والجوانب التي تتحكم في الزوايا بين أقسام الخط. يلغى هذا المثال رؤوس الأسهم عبر [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) و[LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) بحيث يتم مقارنة أشكال النهايات فقط.

ينشئ المثال التالي ثلاثة خطوط أفقيّة متطابقة تقريبًا، بعرض 20 نقطة. من الأعلى إلى الأسفل، يستخدمون نهايات مسطحة، مستديرة، ومربعة. نقاط نهاياتهم لها نفس الإحداثيات الأفقية؛ النهايات المستديرة والمربعة تمتد 10 نقاط خارج كل نقطة نهاية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة في PowerPoint من الأعلى إلى الأسفل: **Flat**, **Round**, و **Square**.

![نهايات مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يجعل تأثير الرسم التخطيطي خط الشكل يبدو كأنه مرسوم يدويًا. استخدم [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) للوصول إلى إعدادات الخط، و[LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

يعرض كود Python التالي كيفية تطبيق تأثير [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

القيمة التي تُرجعها [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)، وصولًا إلى [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)، وقراءة [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). القيمة الفعلية تعكس التنسيق الذي يطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرض تقديمي موجود يحتوي على شكل واحد على الأقل في الشريحة الأولى ويطبع القيمتين:

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

إليك ثلاثة خيارات لأنواع الانضمام:

* Round
* Miter
* Bevel

يتحكم نمط الانضمام في طريقة التقاء مقطعي الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الانضمام في العرض التقديمي](join-style-powerpoint.png)

ينشئ هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء بعرض 15 نقطة. يضبط [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) على قيم الميتر، والبيفل، والدائري من تعداد [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **تقييد الانضمام الميتر عند الزوايا الحادة**

استخدم [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) مع تعيين [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) إلى [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) لتقييد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزوايا الداخلية والخارجية للانضمام إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول ميتر يصل إلى ثماني مضاعفات عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint انضمامًا مِفلًّا في تلك الزاوية. يتيح الحد الأكبر نقاطًا أكثر حدة. يؤثر هذا الإعداد فقط على انضمامات الميتر، ولا يُظهر أي تأثير مرئي عند بقاء الزاوية ضمن الحدين.

ينشئ هذا المثال مثلثين متطابقين غير مملوءين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا بقيمة `2`؛ ويستخدم الأيمن `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، مما يعطي زاوية القمة العلوية نسبة طول ميتر إلى عرض الخط تقريبًا `4.12`. وبالتالي، يقوم PowerPoint بملف الحافة في القمة اليسرى ويحافظ على القمة اليمنى.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و **miter limit 8** على اليمين.

![قمة مِفلّة بحد ميتر 2 وقمة حادة بحد ميتر 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرج لوني**

تدمج تعبئة التدرج الألوان عبر الشكل. يملأ هذا المثال إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). تضع طريقة [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) نقاط التوقف اللونية عند 0 و 1، بداية ونهاية التدرج. يضمن مسح نقاط التوقف الموجودة استخدام هذين اللونين فقط.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الإهليلج بتعبئة تدرج لوني](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في صورة مُصدَّرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض التقديمي.

### **تعيين زاوية التدرج الخطي**

استخدم [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) للتحكم في اتجاه تعبئة [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُعَدَّل الزوايا المحدودة خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` يصبح `315` و`360` يصبح `0`.

ينشئ هذا المثال ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة في المواضع `0`، `0.5`، و`1`. تم إيقاف التحجيم بحيث يمكن مقارنة الزاوية بشكل مستقل عن نسب المستطيلات. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة في PowerPoint:

![تدرجات خطية بزاوية 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

يقبل [GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). اضبطه صراحةً إلى `FALSE` للحفاظ على زاوية التدرج الهندسية عند تغير أبعاد الشكل، أو إلى `TRUE` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة عند شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونقاط التوقف اللونية نفسها كما في مقارنة الزوايا. العمود الأيسر يستخدم `FALSE`؛ العمود الأيمن يستخدم `TRUE`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بنفس الأبعاد العريضة؛ يوضح تعديل عرض وارتفاع المستطيل الثاني كيف يستجيب التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة في PowerPoint، مع إيقاف التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة بتدرج بزاوية 45 درجة، مقارنة linear_gradient_scaled FALSE على اليسار مع TRUE على اليمين](linear-gradient-scaling.png)

عند إيقاف التحجيم، تحتفظ أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. عند تمكين التحجيم، تمتد الأشرطة مع نسب الشكل. يساعد هذا في إعادة إنتاج تدرج القالب عند تعديل شكل إلى حجم مختلف. في الشكل المربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية. لا تتحكم في تعبئات [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

يختار [GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) نمطًا من التدرج من تعداد [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/). ليس بديلاً عن زاوية رقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي توزع فيها الألوان دون تغيير [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). احتفظ بالاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

يطبق المثال التالي نفس الإعدادات بترتيب عكسي. يمتلك المستطيلان نفس المظهر: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **تعبئة نمط**

تطبق تعبئة النمط تصميمًا من لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) لاختيار نمط "trellis". يوفر [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) خلفية بالرمادي الفاتح، و[PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) اللون الأصفر للنمط.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تستخدم تعبئة الصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) لتحميلها إلى مجموعة صور العرض التقديمي. يضبط [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) إلى وضع القالب لتكرار الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا معروضة أدناه:

![صورة اللوتس](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كقوام**

إذا كنت تريد ضبط صورة مكررة كقوام وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): يضبط وضع تعبئة الصورة — إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): يحدد محاذاة القوالب داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): يتحكم فيما إذا كان القالب يُقلب أفقياً أو عمودياً أو كليهما.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): يضبط الإزاحة الأفقية للقالب (بالنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): يضبط الإزاحة العمودية للقالب (بالنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): يحدد مقياس القالب الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): يحدد مقياس القالب العمودي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويُكوّن [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) لتكرارها بنسبة 50% من حجمها الأصلي. تؤدي الإزاحات بمقدار −32 نقطة إلى إزاحة القوالب أفقياً وعمودياً؛ يحدد المحاذاة سفلية-اليمنى والقلب في كلا الاتجاهين كيفية ترتيب القوام المتكرر.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![خيارات القوالب](tile-options.png)

## **تعبئة لون صلب**

تمنح التعبئة الصلبة الشكل لونًا واحدًا ومتجانسًا. يضبط هذا المثال [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى وضع التعبئة الصلبة ويعيّن الأصفر عبر [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)، ثم يحفظ المستطيل في عرض تقديمي.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![الشكل مع تعبئة لون صلبة](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع السمة**

استخدم [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) لنسخ تعريف اللون، بما في ذلك نوع اللون، مرجع السمة، والتحويلات. هذا مفيد عند نقل لون تعبئة بين أشكال يجب أن تستمر في اتباع سمة العرض التقديمي. ينسخ الأسلوب اللون فقط: لا ينسخ نوع التعبئة أو الحدود أو تنسيقات الشكل الأخرى. اضبط صراحةً [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) للوجهة.

ينشئ هذا المثال ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة حساسة للسمة، ونسخة RGB ثابتة. يستخدم المصدر [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) للإشارة إلى اللون الأساسي الأول ويضيف تدرجًا عبر [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). تستخدم نسخة RGB لون التعبئة الفعّال للمصدر بحيث تبدو الثلاثة متماثلة في البداية. تعيين [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) يحدد قيمة RGB ثابتة ويزيل أي تحويلات لون موجودة.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # مراجع السمة تتبع اللون الأساسي الجديد؛ القيمة الثابتة RGB لا تفعل ذلك.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

قبل تغيير السمة، تتطابق جميع التعبئات الثلاث:

![المصدر، نسخة copy_from، ونسخة RGB ثابتة بتعبئات زرقاء متطابقة](color-copy-before.png)

بعد تغيير السمة، يتبع المصدر والنسخة الحساسة للسمة اللون الأساسي الجديد وتحتفظان بتدرجهما. تظل نسخة RGB الثابتة زرقاء:

![المصدر ونسخة copy_from بتعبئات برتقالية، بينما تبقى نسخة RGB الثابتة زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. لاحقًا، تغيير مرجع سمة المصدر، تعيين لون آخر، أو إضافة أو إزالة تحويلاته لا يغيّر الوجهة. لا يزال تغيير السمة يؤثر على كلا الشكلين لأن كلًا منهما يشير بشكل مستقل إلى نفس لون السمة.

يحفظ فتح وإعادة حفظ ملف PPTX مرجع اللون المنسوخ [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/)، مرجع السمة، ومجموعة [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/)، ولا يُحوِّل التعريف إلى RGB.

عند النسخ بين سياقات سمة مختلفة، مثل عروض تقديمية ذات لوحات ألوان أساسية مختلفة، يُحل المرجع المنسوخ وفق سمة الوجهة. يمكن أن ينتج عن نفس المرجع والتحويلات لون مرئي مختلف. راجع [Presentation Theme](/slides/ar/python-net/presentation-theme/) للمزيد حول تكوين ألوان السمة.

## **استخدام خلفية الشريحة كملء للشكل**

استخدم [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. مع هذا الجمع، يستخدم الشكل خلفية الشريحة بدلاً من تعبئة نمطه. تمكين العلامة وحدها لا يزيل أي تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بالمنطقة المقابلة من خلفية الشريحة، بينما لا تعبئة تترك تلك الكائنات مرئية. يبقى التدرج متوافقًا مع الشريحة بدلاً من البدء داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية يتم وراثتها من قبل الشريحة ويضع شريطًا بنفسجيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # وراثة التدرج من القالب الرئيسي.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # أضف هذا الكائن أولاً حتى يظهر خلف المستطيلات.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # عطّل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة، من اليسار إلى اليمين: **background fill**, **no fill**, و **explicit fill**. يتم إخفاء الشريط البنفسجي بواسطة المستطيلين الأيسر والأيمن لكنه يظل مرئيًا عبر المستطيل الأوسط.

![تعبئة الخلفية، لا تعبئة، وتعبئة برتقالية صريحة فوق شريط بنفسجي](background-fill.png)

ينطبق نفس السلوك على خلفية مُحددة مباشرةً على الشريحة أو مُورثة من تخطيط. يستخدم الشكل الخلفية المُحَلَّة للشريحة؛ يترك المثال خلفيات كل من الشريحة والتخطيط غير معرّفة ليقوم الرئيس بتوفيرها.

## **تعيين الشفافية**

في تعبئة صلبة، يتحكم مكون ألفا للون في الشفافية: 0 يعني شفافية كاملة و255 يعني تعتمة كاملة. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا بنحو 50٪ بحيث يظل المستطيل الموجود تحته مرئيًا. يُعيّن اللون عبر [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

استخدم [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) لتدوير شكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال مستطيلًا 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

استخدم [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) لإعطاء الشكل عمقًا وحوافًا مائلة. ينشئ هذا المثال إهليلجًا أخضر بحواف برتقالية، يضبط [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) إلى 4 نقاط، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). تجعل كاميرا أرثوغرافية تواجه الأمام وإضاءة ثلاثية النقاط الحافة مرئية.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات التدوير ثلاثية الأبعاد**

يتم التحكم في عرض الشكل ثلاثي الأبعاد بإعدادات الكاميرا. يستخدم هذا المثال [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) بزاويات خط العرض، خط الطول، والدوران بمقدار 40، 35، و20 درجة على التوالي. يختار كاميرا إسومترية عبر [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) وإضاءة متوازنة عبر [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/)، ثم يحفظ المستطيل المنسق.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد خاصية [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) كيفية عرض شكل منفرد عندما يُشاهد العرض التقديمي أو يُعالج في وضع أبيض وأسود. لا تُفعّل العرض بالأبيض والأسود بحد ذاتها، ولا تغير تعبئة الشكل أو حدوده أو تنسيقه الآخر في وضع اللون الطبيعي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `AUTOMATIC` يتيح لتطبيق العرض اختيار التحويل، `GRAY` و`LIGHT_GRAY` تستخدم تلوينًا رماديًا، `BLACK_WHITE` يستخدم فقط الأسود والأبيض، `BLACK` و`WHITE` يفرضان لونًا واحدًا، `COLOR` يحافظ على التلوين الطبيعي، و`HIDDEN` يحذف الشكل في وضع أبيض وأسود. `NOT_DEFINED` يعني عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويضبط [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) إلى رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان الطبيعية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

في وضع اللون الطبيعي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `GRAY`. يتيح لك ذلك الحفاظ على شريحة بألوان كاملة مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يحترم إعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) لاستعادة موضع وحجم وتنسيق نائيات الشريحة من نائيات التخطيط المقابلة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على نائيات مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا يتم إعادة تعيين الأشكال التي لا تمتلك نائيات تخطيط مقابلة.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

عمومًا، الألوان وأنماط الخط والإعدادات التأثيرية تضيف بيانات قليلة مقارنةً بالصور والوسائط المدمجة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض التقديمي.

**كيف يمكنني اكتشاف الأشكال في شريحة تشارك تنسيق متطابق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسة لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حيثما كان ذلك مطلوبًا.