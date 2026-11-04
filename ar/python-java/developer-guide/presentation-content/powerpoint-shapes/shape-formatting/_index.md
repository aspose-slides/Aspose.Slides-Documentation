---
title: تنسيق أشكال PowerPoint في Python عبر Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط الشكل المرسوم
- تنسيق نمط الوصل
- تعبئة بالتدرج
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بالنقش
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python عبر Java باستخدام Aspose.Slides—حدد أنماط التعبئة، الخط، والتأثيرات لملفات PPT وPPTX بدقة وتحكم كامل."
---
## **المقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، تعبئتها وتأثيراتها. تتيح لك Aspose.Slides for Python عبر Java التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، الدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Python عبر Java فئات وأساليب تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) للتحكم في حدود الشكل. يخلق هذا المثال مستطيلًا غير مملوء بحد أزرق متقطع. يختار [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) خطًا مركبًا سميكًا-رفيعًا، بينما يحدد [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) عرضه إلى 7 نقاط و[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) نمط الشرطية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط الشرطية المخصصة للخط**

استخدم [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المسبقة للطول والفواصل التي تحتاجها، على سبيل المثال للحدود المميزة أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط الشرطية تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

تتبادل قيم المصفوفة بين أطوال الشرطية والفواصل، بدءًا بشرطية. كل قيمة هي مضاعف لعرض الخط: `[4, 2]` بعرض 3 نقاط ينتج شرطية بطول 12 نقطة تليها فجوة بطول 6 نقاط. استخدم أزواجًا من القيم النهائية وغير السالبة لتحديد مقاطع الشرطية والفواصل الكاملة. يستخدم المثال قيمًا موجبة لإبقاء كل شرطية وفجوة مرئية.

هذا المثال يخلق خمسة خطوط زرقاء بطول ثابت وقمصان مسطحة. الثلاثة الأولى تقارن الأنماط بعرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مضاعفًا كلًا من طول الشرطية والفجوة. الخامس يتحول من نمط مخصص إلى خط صلب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # إرجاع الخط الأخير إلى نمط صلب.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

للعودة إلى نمط مسبق منقّط، مرّر [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) إلى [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط شرطية مخصصة، خط أوسع باستخدام النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **ضبط قُبُع الخط**

استخدم [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) لتعيين نهايات الخط المفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) ثلاثة أنماط قُبُع صريحة:

- `Flat`: يتوقف الرسم عند نقطة النهاية.
- `Round`: قُبَعة نصف دائرية تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `Square`: قُبَعة مربعة تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، وهذا يعني عدم تعيين نمط قُبَعة صراحة.

القُبُع تختلف عن رؤوس السهام، التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يقوم هذا المثال بتعطيل رؤوس السهام عبر [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) بحيث تتم مقارنة أشكال القُبُع فقط.

المثال التالي يخلق ثلاثة خطوط أفقية متماثلة عرضها 20 نقطة. من الأعلى إلى الأسفل، يستخدم قُبُعات مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ القُبُعات المستديرة والمربعة تمتد 10 نقاط إلى ما بعد كل نقطة نهاية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة في PowerPoint من الأعلى إلى الأسفل: **Flat**، **Round**، و**Square**.

![قُبُعات مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يُضيف تأثير الرسم مظهرًا يدويًا لخط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، ثم [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم، وأخيرًا [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

يعرض الكود التالي كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

القيمة التي تُعيدها [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن أن يرث تنسيق الخط من سمة، شريحة رئيسية، أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) وقراءة نوع الرسم من التنسيق الفعلي المسترجَع، كما هو موضح أدناه. القيمة الفعّالة تعكس التنسيق الذي يُطبّق فعليًا بعد حل وراثة الإعدادات. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **تنسيق أنماط الوصل**

فيما يلي خيارات أنماط الوصل الثلاثة:

* Round
* Miter
* Bevel

يتحكم نمط الوصل في كيفية التقاء قطعي الحدود عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا الممسوحة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

يخلق هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يستخدم [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) لتعيين قيم المتر، والبيفل، والمستدير لفئة [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تقييد وصلات المتر عند الزوايا الحادة**

استخدم [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) مع [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) المحدد إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) لتقييد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزاوية الداخلية والخارجية للوصل إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول متر يصل إلى ثمان مرات عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلًا مبيفلاً عند تلك الزاوية. الحد الأكبر يسمح بنقاط أكثر حدة. هذا الإعداد يؤثر على وصلات المتر فقط، ولا يُحدث تأثيرًا مرئيًا عندما تظل الزاوية ضمن الحدين.

يخلق هذا المثال مثلثين غير مملوءين متطابقين بحدود عرضها 20 نقطة. المثلث الأيسر يستخدم حدًا `2`، واليمنى يستخدم حدًا `8`. كل مثلث عرضُه 80 نقطة وارتفاعه 160 نقطة، ما يُعطي زاوية أعلى المثلث نسبة طول المتر إلى عرض الخط تقارب `4.12`. وبالتالي، يقوم PowerPoint ببيفلة القمة اليسرى ويُحافظ على القمة اليمنى حادة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مبيفلة بحد المتر 2 وقمة حادة بحد المتر 8 في PowerPoint](miter-limits.png)

## **تعبئة بالتدرج اللوني**

يُمزج التدرج اللوني الألوان عبر الشكل. يملأ هذا المثال بيضاويًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى البنفسجي باستخدام [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). يضع الأسلوب [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. يضمن مسح النقاط الموجودة أن يُستَخدم هذان اللونان فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![البيضاوي مع تعبئة بالتدرج اللوني](gradient-fill.png)

إذا بدى التدرج مختلفًا في صورة مُصدَّرة مقارنةً بـ PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير التدرج المخزن في العرض.

### **تحديد زاوية التدرج الخطي**

استخدم [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبَّق الزوايا النهائية خارج النطاق `[0, 360)` على دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

يخلق هذا المثال ستة مستطيلات بنقاط توقف نفسية للون الأحمر، الأخضر، والأزرق في المواضع `0` و`0.5` و`1`. تم تعطيل التحجيم بحيث يمكن مقارنة الزوايا بغض النظر عن نسب المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة في PowerPoint:

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

يقبل [GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). عيّنها صراحةً إلى `False_` للحفاظ على زاوية التدرج الهندسية عند تغيير أبعاد الشكل، أو إلى `True_` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونفس نقاط التوقف اللونية كما في مقارنة الزوايا. العمود الأيسر يستخدم `False_`؛ العمود الأيمن يستخدم `True_`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة مماثلة؛ يُظهر تعديل عرض وارتفاع المستطيل الثاني كيفية استجابة التعبئة لتغيير الحجم دون تغيير إعدادات التدرج.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة في PowerPoint مع تعطيل التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة مع تدرج بزاوية 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تحتفظ أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع نسب الشكل. يساعد ذلك في إعادة إنتاج تدرج قالب عند تعديل الشكل إلى حجم مختلف. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية. ولا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

يختار [GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) نمطًا تدرجيًا من فئة [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/)، وهو ليس بديلاً عن الزاوية الرقمية. بالنسبة للتدرج الخطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزع فيها الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). احتفظ بالاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

التطبيق التالي يطبق نفس الإعدادات بترتيب عكسي. المستطيلان يبدوان متماثلين: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعبئة بالنمط**

تطبيق تعبئة بنمط يضيف تصميمًا من لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط التريليس. توفر [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) خلفية رمادية فاتحة، وتوفر [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) لونًا أصفرًا للنمط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

تعبئة الصورة تستخدم صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) لتحميلها في مجموعة الصور الخاصة بالعرض التقديمي. ضبط [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) على وضع التكرار (Tile) يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة موضحة أدناه:

![صورة اللوتس](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كنقش**

إذا أردت تعيين صورة متكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الأساليب التالية في فئة [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاطات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت البلاطة مقلوبة أفقيًا أو عموديًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد إزاحة البلاطة أفقياً (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد إزاحة البلاطة عموديًا (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس البلاطة الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس البلاطة العمودي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) لتكرارها بنسبة 50 % من حجمها الأصلي. الإزاحات `−32` نقطة تحرك البلاطات أفقيًا وعموديًا؛ المحاذاة السفلية اليمنى والقلب في الاتجاهين يحددان كيفية ترتيب النقش المتكرر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![خيارات البلاطات](tile-options.png)

## **تعبئة بلون صلب**

توفر التعبئة الصلبة للشكل لونًا موحدًا واحدًا. يستخدم هذا المثال [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) لتعيين وضع التعبئة الصلبة ويُعين الأصفر عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **استخدام خلفية الشريحة كتعبئة للشكل**

استخدم [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يطابق الشكل خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) إلى [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. مع هذا الجمع، يستخدم الشكل خلفية الشريحة بدلاً من تعبئة النمط الخاصة به. تفعيل العلامة وحدها لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة الخلفية المقابلة للشريحة، بينما لا تعبئة تترك تلك الكائنات مرئية. يظل التدرج محاذيًا مع الشريحة بدلاً من إعادة البدء داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية موروثة من الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # وراثة التدرج من القالب الرئيسي.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # إضافة هذا الكائن أولاً حتى يظهر خلف المستطيلات.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # إلغاء تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة من اليسار إلى اليمين: **تعبئة خلفية**، **بدون تعبئة**، و**تعبئة صريحة**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا عبر المستطيل الأوسط.

![تعبئة خلفية، بدون تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

ينطبق السلوك نفسه على خلفية معرفة مباشرةً على الشريحة أو موروثة من تخطيط. يستخدم الشكل الخلفية المُحلَّة للشريحة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير مُعَرَّفين حتى يزودهما الرئيس.

## **ضبط الشفافية**

في التعبئة الصلبة، يتحكم مكون ألفا للون في نسبة الشفافية: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة ألفا `128` لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50 % بحيث يظل المستطيل الموجود تحته مرئيًا. يُعيّن اللون عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

استخدم [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات في اتجاه عقارب الساعة ويحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) لإعطاء الشكل عمقًا وحوافًا مائلة. يخلق هذا المثال إهليلجًا أخضر بحد برتقالي، ويضبط العمق إلى 4 نقاط عبر [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth)، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). تجعل الكاميرا المتعامدة الأمامية وإضاءة ثلاثية النقاط الحافة مرئية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

يُتحكم عرض الشكل ثلاثي الأبعاد بإعدادات الكاميرا الخاصة به. يستخدم هذا المثال [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) بزاوية خط العرض، الطول، والثورة 40 و35 و20 درجة على التوالي. يختار كاميرا إسومترية عبر [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المنسق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) كيفية عرض شكل فردي عندما يُعرض أو يُعالج عرض تقديمي بوضع الأبيض والأسود. لا تمكّن العرض بالأبيض والأسود بنفسها، ولا تغير تعبئة الشكل أو حدوده أو تنسيقه في وضع اللون الطبيعي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، و`Gray` و`LightGray` يستخدمان تلوينًا رماديًا، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يجبران على لون واحد، و`Color` يحافظ على التلوين الطبيعي، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويستخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) لتعيين الوضع إلى رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان الطبيعية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في وضع اللون الطبيعي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يحترم إعدادات عرض الأبيض والأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) لاستعادة موضع وحجم وتنسيق عناصر نائب الشرائح من عناصر نائب التخطيط المقابلة لها. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائب مرتبطة بالتخطيط ويعيد تعيين كل شريحة قبل الحفظ. لا تُعاد الأشكال التي لا توجد لها عناصر نائب في التخطيط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

الألوان، أنماط الخطوط، وإعدادات التأثيرات عادةً ما تضيف بيانات قليلة مقارنةً بالصور والوسائط المضمنة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض التقديمي.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متطابق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية بالأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وأعد تطبيق تنسيقها حسب الحاجة.