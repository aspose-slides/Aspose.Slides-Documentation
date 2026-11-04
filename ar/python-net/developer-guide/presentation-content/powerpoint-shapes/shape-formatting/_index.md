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
- تنسيق نمط الوصل
- تعبئة تدرج لوني
- تعبئة نمطية
- تعبئة صورة
- تعبئة قوام
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- دوران الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python باستخدام Aspose.Slides—ضبط أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

قُم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، تعبئاتها، وتأثيراتها. Aspose.Slides for Python via .NET يتيح لك التحكم في هذه الإعدادات برمجيًا، بما في ذلك الشفافية، الدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET يوفر فئات وخصائص تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) للتحكم في حدود الشكل. هذا المثال ينشئ مستطيلًا غير مملوء بحد أزرق متقطع. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) يختار خطًا مركبًا سميك‑رفيع، بينما [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) يعيّن عرضه إلى 7 نقاط و[LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) يختار نمط الشرط.

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

### **تعيين أنماط الشرط المخصصة للخط**

استخدم [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) عندما لا توفر الأنماط الخطية المحددة مسبقًا أطوال الشرط والفجوات التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. تعيين نمط يضبط تلقائيًا [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) إلى [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

تتبادل إدخالات القائمة بين أطوال الشرط والفجوة، بدءًا بشرط. كل قيمة هي مضاعف عرض الخط: `[4, 2]` بعرض 3 نقاط ينتج شرطًا بطول 12 نقطة يليه فجوة بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة وغير السالبة لتعريف أقسام الشرط والفجوة الكاملة. المثال يستخدم قيمًا موجبة للحفاظ على رؤية كل شرط وفجوة.

هذا المثال ينشئ خمسة خطوط زرقاء ذات نفس الطول ونهايات مسطحة. الثلاثة الأولى تقارن الأنماط بعرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مضاعفًا كلًا من طول الشرط والفجوة. الخامس ينتقل من نمط مخصص إلى خط صلب.

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

    # إرجاع الخط الأخير إلى نمط صلب.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

للتبديل إلى نمط متقطع محدد مسبقًا، عيّن [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) إلى [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![ثلاثة أنماط شرط مخصصة، خط أعرض يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين نهايات الخط**

استخدم [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) لتعيين نهايات خط مفتوح. تعداد [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) يوفر ثلاث أنماط واضحة للنهاية:

- `FLAT`: يتوقف الخط عند النهاية.
- `ROUND`: نهاية نصف دائرية تمتد خارج النهاية بنصف عرض الخط.
- `SQUARE`: نهاية مربعة تمتد خارج النهاية بنصف عرض الخط.

التعداد أيضًا يشمل `NOT_DEFINED`، مما يعني عدم تعيين نمط نهاية صريح.

النهايات تختلف عن رؤوس السهام التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين قطاعات الخط. هذا المثال يعطل رؤوس السهام عبر [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) و[LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) بحيث تُقارن فقط أشكال النهايات.

المثال التالي ينشئ ثلاثة خطوط أفقية متطابقة عرضها 20 نقطة. من الأعلى إلى الأسفل، تستخدم نهايات مسطحة، مستديرة، ومربعة. إحداثيات نهاياتها أفقية متساوية؛ النهايتان المستديرة والمربعة تمتدان 10 نقاط خارج كل نهاية.

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

النتيجة في PowerPoint من الأعلى إلى الأسفل: **Flat**, **Round**, و**Square**.

![نهايات مسطحة، ومستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

تجعل تأثيرات الرسم التخطيطي خط الشكل يبدو كأنه مرسم يدويًا. استخدم [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) للوصول إلى إعدادات الخط، [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

الكود التالي يوضح كيفية تطبيق تأثير [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) وقراءة القيم المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)، وصولًا إلى [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)، وقراءة [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

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

## **تنسيق أنماط الوصل**

فيما يلي الخيارات الثلاثة لأنواع الوصل:
* مستدير
* ميتّر
* مشطوف

نمط الوصل يتحكم في كيفية اتصال قطعتين من الحدود عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المشطوفة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

هذا المثال ينشئ ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يعيّن [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) إلى قيم الميتّر، المشطوف، والمستدير من تعداد [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) على التوالي، لمقارنة طريقة رسم الزوايا.

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

### **تحديد وصلات الميتّر عند الزوايا الحادة**

استخدم [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) مع [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) مضبوطة على [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) لتحديد الحد الأقصى لامتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزاويتين الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول ميتّر يصل إلى ثماني مرات عرض الخط؛ لا تُقاس بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مشطوفة في تلك الزاوية. زيادة الحد تسمح بنقاط أكثر حدة. الإعداد يؤثر فقط على وصلات الميتّر، ولا يظهر أي أثر مرئي عند بقاء الزاوية ضمن الحدين.

هذا المثال ينشئ مثلثين غير مملئين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا بقيمة `2`، والمثلث الأيمن حدًا بقيمة `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، ما يعطي زواياه العلوية نسبة تقريبية `4.12` بين طول الميتّر وعرض الخط. نتيجةً لذلك، يُشطب PowerPoint قمة المثلث الأيسر ويحتفظ بقمة المثلث الأيمن.

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

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مشطوفة بحد miter 2 وقمة حادة بحد miter 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرج لوني**

تدمج تعبئة التدرج الألوان عبر الشكل. يملأ هذا المثال إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى البنفسجي باستخدام [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). تضع طريقة [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. مسح نقاط التوقف الحالية يضمن استخدام هذين اللونين فقط.

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

![الإهليلج مع تعبئة تدرج لوني](gradient-fill.png)

إذا بدا التدرج مختلفًا في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

### **تعيين زاوية التدرج الخطي**

استخدم [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) للتحكم في اتجاه تعبئة [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تُدعم الزوايا الكسرية. تُطبع الزوايا الخارجة عن النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

هذا المثال ينشئ ستة مستطيلات بنقاط توقف حمراء وخضراء وزرقاء متطابقة عند المواقع `0`، `0.5`، و`1`. تم تعطيل التحجيم حتى يمكن مقارنة الزاوية بصورة مستقلة عن أبعاد المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

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

### **تحجيم تدرج خطي مع الشكل**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) تقبل قيمة [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). عيّنها صراحةً إلى `FALSE` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو إلى `TRUE` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية المرئية عن الزاوية المعينة على شكل غير مربع.

المثال التالي يستخدم زاوية `45` درجة ونقاط توقف ألوان مماثلة لتلك المستخدمة في مقارنة الزوايا. العمود الأيسر يستخدم `FALSE`؛ العمود الأيمن يستخدم `TRUE`. كل عمود يحتوي على مستطيل عريض فوق مستطيل طويل. يبدأ كليهما بنفس الأبعاد العريضة؛ تعديل عرض وارتفاع المستطيل الثاني يوضح كيف يستجيب التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

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

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتفعيل التحجيم على اليمين:

![مستطيلات عريضة وطويلة مع تدرج بزاوية 45 درجة، مقارنة linear_gradient_scaled FALSE على اليسار مع TRUE على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى أشرطة اللون القطرية ذات الاتجاه نفسه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع أبعاد الشكل. يساعد ذلك على إعادة إنتاج تدرج القالب عند تعديل حجم الشكل. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

كلا الإعدادين—الزاوية والتحجيم—ينطبقان على التدرجات الخطية. لا يتحكمان في تعبئة [GradientShape.RADIAL أو GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) يختار نمط تدرج من تعداد [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/)، وليس بديلاً عن الزاوية الرقمية. بالنسبة للتدرج الخطّي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزع فيها الألوان دون تعديل [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). أبق الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

التطبيق التالي يطبّق الإعدادات نفسها بترتيب عكسي. المستطيلان يظهرا نفس المظهر: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

## **تعبئة نمطية**

تطبق تعبئة النمط تصميمًا بلونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) لاختيار نمط شبكة. يوفر [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) خلفية رمادية فاتحة، و[PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) لون النمط الأصفر.

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

النتيجة:

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تستخدم تعبئة الصورة صورةً داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) على وضع التكرار يعيد الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

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

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كقوام**

إذا رغبت في ضبط صورة مكررة كقوام وتخصيص سلوك التكرار، يمكنك استخدام الخصائص التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): تعيين وضع تعبئة الصورة — إما `TILE` أو `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): تحديد محاذاة البلاط داخل الشكل.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): التحكم فيما إذا كان البلاط يُقلب أفقياً أو رأسياً أو كلاهما.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): تعيين الإزاحة الأفقية للبلاط (بالنقاط) من أصل الشكل.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): تعيين الإزاحة الرأسية للبلاط (بالنقاط) من أصل الشكل.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): تحديد مقياس البلاط الأفقي كنسبة مئوية.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): تحديد مقياس البلاط الرأسي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويُعدّ [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) لتكرارها بنسبة 50 % من حجمها الأصلي. إزاحات `−32` نقطة تُحرك البلاط أفقياً ورأسياً؛ المحاذاة أسفل‑يمين والقلب في الاتجاهين يحددان كيفية ترتيب القوام المتكرر.

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

النتيجة:

![خيارات البلاط](tile-options.png)

## **تعبئة لون صلب**

توفر التعبئة الصلبة لونًا موحّدًا للشكل. يعين هذا المثال [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى وضع التعبئة الصلبة ويُعطي اللون الأصفر عبر [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)، ثم يحفظ المستطيل في عرض تقديمي.

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

النتيجة:

![الشكل مع تعبئة لون صلب](solid-color-fill.png)

## **استخدام خلفية الشريحة كتعبئة للشكل**

استخدم [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذه المجموعة، يستخدم الشكل خلفية الشريحة بدلاً من تعبئة النمط الخاصة به. تمكين العلامة وحده لا يزيل تعبئة صريحة موجودة.

يختلف هذا عن [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بالمنطقة المقابلة من خلفية الشريحة، بينما لا تعبئة تُظهر تلك الكائنات. يبقى التدرج محاذيًا مع الشريحة بدلاً من البدء داخل كل شكل.

المثال التالي ينشئ خلفية رئيسية تُورّثها الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # ورث التدرج من القالب الرئيسي.
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

النتيجة، من اليسار إلى اليمين: **background fill**, **no fill**, و**explicit fill**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا عبر المستطيل الأوسط.

![تعبئة خلفية، لا تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

السلوك نفسه ينطبق على خلفية مُعرفة مباشرةً على الشريحة أو مُورّثة من تخطيط. يستخدم الشكل الخلفية التي تم حلها للشرائح؛ يترك المثال كلًا من خلفيات الشريحة والتخطيط غير معرفة بحيث يتولى الماستر توفيرها.

## **تعيين الشفافية**

في التعبئة الصلبة، يتحكم مكوّن ألفا للون في التعتيم: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة ألفا `128` لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50 % بحيث يظل المستطيل الموجود تحته مرئيًا. يُعيّن اللون عبر [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

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

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

استخدم [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) لدوران الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال مستطيلًا بزاوية 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات حافة ثلاثية الأبعاد**

استخدم [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) لإعطاء الشكل عمقًا وحوافًا مائلّة. ينشئ هذا المثال إهليلجًا أخضر بحد برتقالي، يعيّن [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) إلى 4 نقاط، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). تجعل الكاميرا الإسقاطية الأمامية والإضاءة الثلاثية النقاط الحافة مرئية.

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

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تُتحكم إعدادات الكاميرا في عرض الشكل ثلاثي الأبعاد. يستخدم هذا المثال [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) بزاوية خط العرض، خط الطول، وثورة 40، 35، و20 درجة على التوالي. يختار كاميرا إيزومترية عبر [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) وإضاءة متوازنة عبر [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/)، ثم يحفظ المستطيل المنسق.

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

النتيجة:

![تأثير دوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد خاصية [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) كيفية عرض الشكل الفردي عندما يُعرض أو يُعالج العرض التقديمي في وضع أبيض‑أسود. لا تُفعِّل وضع العرض بالأبيض والأسود بحد ذاتها، ولا تُغيِّر تعبئة الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `AUTOMATIC` يترك تطبيق العرض يختار التحويل، `GRAY` و`LIGHT_GRAY` يستخدمان تلوينًا رماديًا، `BLACK_WHITE` يستخدم الأسود والأبيض فقط، `BLACK` و`WHITE` يفرضان لونًا واحدًا، `COLOR` يحافظ على التلوين العادي، و`HIDDEN` يحذف الشكل في وضع أبيض‑أسود. `NOT_DEFINED` يعني عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويعيّن [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) إلى رمادي. يحافظ الشكل المُحفظ على تعبئته البرتقالية للعرض العادي ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

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

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض‑أسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `GRAY`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يحترم إعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) لاستعادة موضع وحجم وتنسيق عناصر النائب في الشريحة من عناصر النائب المقابلة في التخطيط. يتطلب هذا المثال عرضًا تقديميًا موجودًا به عناصر نائب مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا تُعاد ضبط الأشكال التي لا تقابلها عناصر نائب في التخطيط.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

عادةً ما تضيف الألوان وأنماط الخط وإعدادات التأثيرات بيانات قليلة مقارنةً بالصور والوسائط المضمَّنة. قد تزيد تعبئة الصور من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متماثل حتى أتمكن من تجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا طابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وجمّع تلك الأشكال منطقيًا، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المصممة التي تحتاجها، وأعد تطبيق تنسيقها حيثما دعت الحاجة.