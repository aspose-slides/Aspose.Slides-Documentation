---
title: تنسيق أشكال PowerPoint في Python عبر Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم اليدوي
- خط الشكل المخطط
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة نسيجية
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج الرمادي
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python عبر Java باستخدام Aspose.Slides—حدد أنماط الملء والحد وتأثيرات الملفات PPT وPPTX بدقة وتحكم كامل."
---
## **المقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها وملئها والتأثيرات الخاصة بها. تتيح لك Aspose.Slides for Python عبر Java التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق الثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Python عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) للتحكم في حدود الشكل. يخلق هذا المثال مستطيلًا غير مملوء بحد أزرق متقطع. يختار [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) خطًا مركبًا سميك-رفيع، بينما يحدد [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) عرضه إلى 7 نقاط و[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) يختار نمط الشرط.

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

![الخطوط المُنسقة في العرض التقديمي](formatted-lines.png)

### **ضبط أنماط الخط المتقطعة المخصصة**

استخدم [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المسبقة الطول والفواصل التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط الشرط تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

تتناوب قيم المصفوفة بين أطوال الشرط والفواصل، بدءًا بشرط. كل قيمة هي مضاعف عرض الخط: `[4, 2]` عند عرض 3 نقاط ينتج شرطًا بطول 12 نقطة يليه فجوة بطول 6 نقاط. استخدم أزواجًا من القيم النهائية غير السالبة لتحديد مقاطع الشرط‑الفاصل الكاملة. يستخدم المثال قيمًا موجبة لإبقاء كل شرط وفاصل مرئيًا.

هذا المثال يخلق خمس خطوط زرقاء بنفس الطول والنهايات المسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. الرابعة تكرر النمط الأول بعرض مضاعف، مضاعفة كل من أطوال الشرط والفواصل. الخامسة تنتقل من نمط مخصص إلى خط صلب.

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

للعودة إلى نمط متقطع مسبقًا بدلاً من ذلك، مرر [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) إلى [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint، من أعلى إلى أسفل: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; و **Solid, 3 pt**.

![ثلاث أنماط متقطعة مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **ضبط نهايات الخط**

استخدم [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) لضبط نهايات خط مفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) ثلاثة أنماط نهايات صريحة:

- `Flat`: التوقف عند نقطة النهاية.
- `Round`: غطاء نصف دائري يمتد إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.
- `Square`: غطاء مربع يمتد إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، مما يعني أنه لم يتم تعيين نمط نهية صريح.

النهايات تختلف عن رؤوس السهام، التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. هذا المثال يعطل رؤوس السهام عبر [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) بحيث تتم مقارنة أشكال النهايات فقط.

المثال التالي يخلق ثلاثة خطوط أفقية متطابقة عرضها 20 نقطة. من أعلى إلى أسفل، يستخدم نهايات مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ النهايات المستديرة والمربعة تمتد 10 نقاط خارج كل نقطة انتهاء.

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

النتيجة في PowerPoint، من أعلى إلى أسفل: **Flat**, **Round**, و **Square**.

![نهايات مسطحة، مستديرة، ومربعة على خطوط سُمك متساوية في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم اليدوي على خطوط الشكل**

يجلُّ تأثير الرسم اليدوي خط الشكل ليظهر كأنه مرسوم يدويًا. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم اليدوي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) لتحديد قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

المثال التالي في بايثون يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) واقرأ نوع الرسم اليدوي من تنسيق الخط الفعلي المرتجع، كما هو موضح أدناه. القيمة الفعالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريطته الأولى ويطبع القيمتين:

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

Here are the three join type options:
* Round
* Miter
* Bevel

نمط الوصل يتحكم في طريقة التقاء مقطعي الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

هذا المثال يخلق ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يستخدم [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) لتعيين قيم المِتر، المبيف، والمستدئ في [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

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

### **تحديد وصلات المِتر عند الزوايا الحادة**

استخدم [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) مع [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) مع ضبطه إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) لتقييد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزوايا الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، قيمة `8` تسمح بطول مِتر يصل إلى ثمانية أضعاف عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مبيفة عند تلك الزاوية. الحد الأكبر يسمح بنقاط أكثر حدة. الإعداد يؤثر على وصلات المِتر فقط، ولا يحدث أي تأثير مرئي عند بقاء الزاوية داخل الحدين.

هذا المثال يخلق مثلثين غير مملوءين متطابقين بحدود عرضها 20 نقطة. المثلث الأيسر يستخدم حدًا قدره `2`، والأيمن يستخدم `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، ما يعطى زاوية علوية بنسبة تقريبية `4.12` بين طول المِتر وعرض الخط. وبالتالي، يقوم PowerPoint بعمل وصلة مبيفة للقمة اليسرى ويحافظ على القمة اليمنى.

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

![قمة مقوَّسة بحد مِتر 2 وقمة حادة بحد مِتر 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرجية**

تعبئة تدرجية تمزج الألوان عبر الشكل. هذا المثال يملأ إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). طريقة [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) تضع نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. مسح نقاط التوقف الحالية يضمن استخدام هذين اللونين فقط.

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

![الإهليلج بتعبئة تدرجية](gradient-fill.png)

إذا ظهر التدرج مختلفًا في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [اختر نمط عرض التدرج](/slides/ar/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

### **ضبط زاوية التدرج الخطي**

استخدم [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسورية. تُطبع الزوايا خارج المجال `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

هذا المثال يخلق ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة في المواضع `0`، `0.5`، و`1`. تم تعطيل التحجيم حتى يمكن مقارنة الزاوية مستقلةً عن نسب المستطيلات. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

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

![تدرجات خطية عند 0°, 45°, و90° في الصف العلوي، و135°, 180°, و270° في الصف السفلي](linear-gradient-angles.png)

### **تحجيم تدرج خطي مع الشكل**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) يقبل قيمة من نوع [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False_` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو إلى `True_` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية المرئية عن الزاوية المعينة على شكل غير مربع.

المثال التالي يستخدم زاوية `45` درجة ونقاط توقف الألوان نفسها كما في مقارنة الزوايا. العمود الأيسر يستخدم `False_`؛ العمود الأيمن يستخدم `True_`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ تعديل عرض وارتفاع المستطيل الثاني يُظهر كيف يستجيب التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

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

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة مع تدرج 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى شرائط اللون المائلة ذات الاتجاه نفسه في كلا المستطيلين. مع تمكين التحجيم، تمتد الشرائط مع نسب الشكل. يساعد ذلك في استنساخ تدرج القالب عند تعديل الشكل إلى حجم مختلف. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

كلا الإعدادين، الزاوية والتحجيم، ينطبقان على التدرجات الخطية. لا يتحكمان في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) يختار نمط تدرج من فئة [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/)، وهو ليس بديلاً عن الزاوية الرقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزَّع فيها الألوان دون تغيير الزاوية المُحدَّدة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). حافظ على الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

المثال التالي يطبق الإعدادات نفسها بترتيب عكسي. المستطيلان لهما نفس المظهر: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

## **تعبئة نمطية**

تعبئة نمطية تُطبق تصميمًا ثنائي اللون، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط trellis. توفر [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) خلفية رمادية فاتحة، وتوفر [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) لون النمط الأصفر.

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

![المستطيل بتعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تعبئة صورة تستخدم صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) لتحميلها إلى مجموعة صور العرض. ضبط [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) إلى وضع البلاط يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

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

![الشكل بتعبئة صورة](picture-fill.png)

### **بلاط الصورة كنقش**

إذا رغبت في تعيين صورة مبلطة كنقش وتخصيص سلوك البلاط، يمكنك استخدام الأساليب التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان البلاط يُقَلَّب أفقياً أو عمودياً أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): يضبط إزاحة البلاط الأفقية (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): يضبط إزاحة البلاط العمودية (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس البلاط العمودي كنسبة مئوية.

هذا المثال يتطلب صورة محلية ويُهيئ [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) لتكرارها بحجم 50% من حجمها الأصلي. إزاحات `−32` نقطة تحرك البلاط أفقياً ورأسياً؛ المحاذاة أسفل‑يمين والقلب في كلا الاتجاهين يحددان كيفية ترتيب النَسْخَة المتكررة للنقش.

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

![خيارات البلاط](tile-options.png)

## **تعبئة لون صلب**

تعبئة صلبة تعطي الشكل لونًا موحدًا واحدًا. يستخدم هذا المثال [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) لتعيين وضع التعبئة الصلبة ويُعيّن الأصفر عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

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

![الشكل بتعبئة لون صلب](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع السمة**

استخدم [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) لنسخ تعريف اللون، بما في ذلك نوع اللون، ومرجع السمة، والتحويلات. هذا مفيد عند نقل لون تعبئة بين أشكال يجب أن تظل تتبع سمة العرض. تنسخ الطريقة اللون فقط: لا تنسخ نوع التعبئة أو الحد أو أي تنسيقات أخرى للشكل. اضبط نوع تعبئة الوجهة صراحةً باستخدام [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

هذا المثال يخلق ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة واعية للسمة، ونسخة RGB ثابتة. يستخدم المصدر [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) للإشارة إلى أول لون لهجة ويضيف صبغة عبر [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add). تستخدم نسخة RGB لون التعبئة الفعلي للمصدر بحيث تبدو الثلاثة في البداية متطابقة. استدعاء [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) يضبط قيمة RGB ثابتة ويمسح أي تحولات لون موجودة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # مراجع السمة تتبع اللون المميز الجديد؛ قيمة RGB الثابتة لا تفعل ذلك.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قبل تغيير السمة، جميع التعبئات الثلاث متطابقة:

![المصدر، النسخة المنقولة إلى الوجهة، والنسخة RGB الثابتة مع تعبئات زرقاء متطابقة](color-copy-before.png)

بعد تغيير السمة، يتبع المصدر والنسخة الواعية للسمة اللون المتميز الجديد وتحتفظان بصبغتها. تظل نسخة RGB الثابتة زرقاء:

![المصدر ونسخة copyFrom مع تعبئة برتقالية، بينما النسخة RGB الثابتة تظل زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. تغيير مرجع سمة المصدر لاحقًا، أو تعيين لون آخر، أو إضافة أو إزالة التحولات لا يغيّر الوجهة. لا يزال تغيير السمة يؤثر على كلا الشكلين لأن كلًا منهما يشير بشكل مستقل إلى نفس لون السمة.

حفظ وإعادة فتح ملف PPTX يحافظ على نوع اللون المنسوخ الذي تُرجعه [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType)، والمرجع السَمي، ومجموعة التحويلات التي تُرجعها [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform)؛ لا يتم تحويل التعريف إلى RGB.

عند النسخ بين سياقات سمة مختلفة، مثل عروض تقديمية ذات لوحات ألوان لهجات مختلفة، يتم حل المرجع المنسوخ وفقًا لسمة الوجهة. لذا يمكن لنفس المرجع والتحولات أن ينتج لونًا مرئيًا مختلفًا. راجع [سمة العرض](/slides/ar/python-java/presentation-theme/) لمزيد من المعلومات حول تكوين ألوان السمة.

## **استخدام خلفية الشريحة كملء للشكل**

استخدم [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط نوع التعبئة باستخدام [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) إلى [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذه التركيبة، يستخدم الشكل خلفية الشريحة بدلًا من تعبئة نمطه. تمكين العلامة وحده لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات وراء الشكل بالمنطقة المقابلة من خلفية الشريحة، بينما عدم التعبئة يترك تلك الكائنات مرئية. يبقى التدرج محاذيًا للشفرة بدلاً من أن يبدأ داخل كل شكل.

المثال التالي يخلق خلفية رئيسية مُورّثة إلى الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن ينتقل من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

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

    # ورث التدرج من الشّريحة الرئيسة.
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

    # أضف هذا الكائن أولاً حتى يظهر خلف المستطيلات.
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

    # عطّل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة، من اليسار إلى اليمين: **background fill**, **no fill**, و**explicit fill**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يظل مرئيًا من خلال المستطيل الأوسط.

![ملء الخلفية، بدون ملء، وملء برتقالي صريح فوق شريط أرجواني](background-fill.png)

نفس السلوك ينطبق على خلفية معرفة مباشرةً على الشريحة أو مُورّثة من تخطيط. يستخدم الشكل الخلفية المُحَلَّة للشفرة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير معرفة بحيث يزودها الرئيس.

## **ضبط الشفافية**

بالنسبة لتعبئة صلبة، يتحكم مكوّن alpha للون في الشفافية: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة alpha مقدارها 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50% بحيث يظل المستطيل الموجود تحته مرئيًا. يتم تعيين اللون عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

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

استخدم [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال مستطيلًا 5 درجات مع اتجاه عقارب الساعة ويحفظ العرض التقديمي.

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

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) لإعطاء الشكل عمقًا وحوافًا مبيفة. يخلق هذا المثال إهليلجًا أخضرًا بحد برتقالي، ويضبط العمق إلى 4 نقاط عبر [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth)، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). تجعل الكاميرا العمودية المتعامدة والإضاءة ثلاثية النقاط الحافة مرئية.

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

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

يُتحكم عرض الشكل ثلاثي الأبعاد بإعدادات الكاميرا. يستخدم هذا المثال [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) بزاوية عرض 40 درجة، وزاوية طول جغرافية 35 درجة، وزاوية دوران 20 درجة. يختار كاميرا إيزومترية عبر [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المُنسق.

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

## **التحكم في عرض الأسود والأبيض للأشكال**

تُحدد طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض في وضع الأسود والأبيض. لا تُفعِّل هذه الطريقة وضع العرض بالأبيض والأسود بحد ذاتها، ولا تُغيّر ملء الشكل أو حدوده أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، `Gray` و`LightGray` يستخدمان تلوينًا رماديًا، `BlackWhite` يستخدم الأسود والأبيض فقط، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على التلوين العادي، و`Hidden` يحذف الشكل في وضع الأسود والأبيض. `NotDefined` يعني أنه لم يُعيَّن وضع على مستوى الشكل.

هذا المثال يخلق مستطيلًا برتقاليًا ويُعيّن طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) إلى `Gray`. يحتفظ الشكل المحفوظ بملئه البرتقالي للعرض الملون العادي ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

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

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك هذا الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يحترم إعدادات العرض بالأبيض والأسود الخاصة بالعرض.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) لاستعادة موضع وحجم وتنسيق عناصر نائب الشريحة من عناصر نائب التخطيط المقابلة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائب مرتبطة بالتخطيط ويعيد تعيين كل شريحة قبل الحفظ. لا يتم إعادة تعيين الأشكال التي لا تمتلك عناصر نائب مقابلة في التخطيط.

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

الألوان، وأنماط الخطوط، وإعدادات التأثير عادةً ما تضيف كمية قليلة من البيانات مقارنة بالصور والوسائط المضمنة. يمكن لتعبئة الصور زيادة حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متطابق بحيث أستطيع تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — الملء، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن الأنماط متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما تطلب الأمر.