---
title: تنسيق أشكال PowerPoint في JavaScript
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/nodejs-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل رسم تخطيطي
- تنسيق نمط الوصلة
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنسق
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج الرمادي
- دوران الشكل
- تأثير Bevel ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في JavaScript باستخدام Aspose.Slides — اضبط أنماط التعبئة والحد وتأثيرات الملفات PPT وPPTX بدقة وتحكم كامل."
---
## **مقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، وتعبئتها، وتأثيراتها. يتيح لك Aspose.Slides for Node.js عبر Java التحكم في هذه الإعدادات برمجيًا، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for Node.js عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) للتحكم في حد الشكل. ينشئ هذا المثال مستطيلًا غير مملوء بخط أزرق متقطع. يختار [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) خطًا مركبًا سميك‑رقيق، بينما يحدد [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) عرضه إلى 7 نقاط و[LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) نمط الشرط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الخطوط المُنسقة في العرض التقديمي](formatted-lines.png)

### **ضبط أنماط الشرط المخصصة للخط**

استخدم [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المسبقة للطول والفراغ المطلوبين، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يغيّر تعيين نمط تلقائيًا نمط الشرط إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

تتناوب قيم المصفوفة بين أطوال الشرط والفراغ، بدءًا بالشرط. كل قيمة هي مضاعف لعرض الخط: ‎`[4, 2]`‎ عند عرض 3 نقاط ينتج شرطة بطول 12 نقطة يليه فراغ بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة غير السالبة لتعريف مقاطع الشرط‑الفراغ الكاملة. يستخدم المثال قيمًا موجبة لإبقاء كل شرط وفراغ مرئيين.

هذا المثال ينشئ خمسة خطوط زرقاء بطول موحد ونهايات مسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مضاعفًا كل من أطوال الشرط والفراغ. الخامس ينتقل من نمط مخصص إلى خط صلب.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // إرجاع الخط الأخير إلى نمط صلب.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للعودة إلى نمط متقطع مسبق، مرّر [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) إلى [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). يتحكم النمط المحدد في مظهر الخط.

النتيجة في PowerPoint، من أعلى إلى أسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط شرط مخصصة، خط أوسع باستخدام النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **ضبط نهايات الخط**

استخدم [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) لتحديد نهايات الخط المفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) ثلاثة أنماط صريحة للنهاية:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: تمتد النهاية شبه دائرية إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `Square`: تمتد النهاية مربعة إلى ما بعد نقطة النهاية بنصف عرض الخط.

تشمل الفئة أيضًا `NotDefined`، مما يعني عدم تعيين نمط نهاية صريح.

النهايات تختلف عن رؤوس السهام التي تضيف رموزًا إلى نهايات الخط، وكذلك الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يعطل هذا المثال رؤوس السهام عبر [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) حتى تتم مقارنة أشكال النهايات فقط.

إنشاء المثال التالي ثلاثة خطوط أفقية متطابقة، عرضها 20 نقطة. من أعلى إلى أسفل، تستخدم نهايات مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ تمتد النهايات المستديرة والمربعة 10 نقاط إلى ما بعد كل نقطة نهاية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint، من أعلى إلى أسفل: **Flat**, **Round**, و**Square**.

![نهايات مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يجعل تأثير الرسم التخطيطي خط الشكل يبدو كأنه مرسوم يدويًا. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، ثم [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، واستخدم [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

يعرض الكود التالي كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تُرجعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective)، وندِّ `getSketchFormat` على الكائن المرجع، ثم استدعِ طريقة `getSketchType` الخاصة به. تمثل القيمة الفاعلة التنسيق المطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **تنسيق أنماط الوصل**

إليك ثلاثة خيارات لنوع الوصلة:

* Round
* Miter
* Bevel

تتحكم أنماط الوصلة في كيفية التقاء مقطعي الحد عند الزاوية. استخدم **Round** للزوايا المدورة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

ينشئ هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يستخدم [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) لتطبيق القيم miter وbevel وround من فئة [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **قصر وصلات Miter عند الزوايا الحادة**

استخدم [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) مع [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) مضبوطًا على [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) لتحديد الحد الأقصى لامتداد زاوية حادة.

الحد هو نسبة المسافة بين الزاوية الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول miter يصل إلى ثماني مرات عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مسطحة في تلك الزاوية. كلما زاد الحد، كلما أصبحت النقاط أكثر حدة. يؤثر الإعداد على وصلات miter فقط، ولا يغير مظهرًا مرئيًا عند بقاء الزاوية ضمن الحدين.

ينشئ هذا المثال مثلثين غير مملوئين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا `2`، واليميني حدًا `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، مما يعطي نسبة طول miter إلى عرض الخط تقريبًا `4.12`. بناءً على ذلك، يقوم PowerPoint بتمهيد القمة اليسرى ويحافظ على حدة القمة اليمنى.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مسطحة بحد miter 2 وقمة حادة بحد miter 8 في PowerPoint](miter-limits.png)

## **تعبئة متدرجة**

تدمج تعبئة متدرجة الألوان عبر الشكل. يملأ هذا المثال بيضاويًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). تضع طريقة [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط التدرج عند 0 و1، بداية ونهاية التدرج. يضمن مسح النقاط الحالية استخدام اللونين فقط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![البيضاوي مع تعبئة متدرجة](gradient-fill.png)

إذا ظهر التدرج مختلفًا في صورة مُصدَّرة مقارنةً بـ PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير التدرج المخزن في العرض.

### **ضبط زاوية التدرج الخطي**

استخدم [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبع الزوايا خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

ينشئ هذا المثال ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة عند المواقع `0`، `0.5`، و`1`. تم تعطيل التحجيم حتى يمكن مقارنة الزاوية بغض النظر عن أبعاد المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint:

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

تقبل [GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو إلى `True` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونقاط التوقف نفسها كما في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ والعمود الأيمن يستخدم `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ يوضح تغيير عرض وارتفاع المستطيل الثاني كيفية استجابة التعبئة لإعادة الحجم دون تغيير إعدادات التدرج.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة مع تدرج 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى الشرائط الملونة القطرية ذات الاتجاه نفسه في كلا المستطيلين. مع تمكين التحجيم، تمتد الشرائط مع أبعاد الشكل. يساعد ذلك في إعادة إنتاج تدرج القالب عند تعديل حجم الشكل. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية فقط. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **دمج الاتجاه مع الزاوية**

تختار [GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) نمط التدرج من فئة [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/)، وهو ليس بديلًا للزاوية الرقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير مساحة توزيع الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). حافظ على اتجاه الثابت عند مقارنة الزوايا أو التحجيم.

يطبق المثال التالي الإعدادات نفسها بترتيب عكسي. يحصل المستطيلان على نفس المظهر: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعبئة بنمط**

تطبيق تعبئة بنمط يضيف تصميمًا من لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط trellis. توفر [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) الخلفية الرمادية الفاتحة، وتوفر [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) لون النمط الأصفر.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل بتعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

تستخدم تعبئة بصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) لتحميلها إلى مجموعة صور العرض. ضبط [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) على الوضع المتكرر يكرر الصورة داخل المستطيل. الصورة المستخدمة موضحة أدناه:

![صورة اللوتس](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل بتعبئة صورة](picture-fill.png)

### **تلبيس الصورة كملمس متكرر**

إذا رغبت في تعيين صورة مكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): يضبط وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم في ما إذا كان البلاط يُقلب أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد إزاحة البلاط أفقيًا (بالنقاط) عن أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد إزاحة البلاط عموديًا (بالنقاط) عن أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس البلاط العمودي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) لتكرارها بنسبة 50% من حجمها الأصلي. تقوم إزاحات `−32` نقطة بتحريك البلاط أفقيًا وعموديًا؛ تحدد المحاذاة السفلية اليمنى والانعكاس في الاتجاهين كيفية ترتيب النسيج المتكرر.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![خيارات البلاط](tile-options.png)

## **تعبئة بلون صلب**

توفر تعبئة صلبة لونًا موحدًا للشكل. يستخدم هذا المثال [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) لاختيار نمط التعبئة الصلبة ويعين اللون الأصفر عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل بتعبئة لون صلب](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع السمة**

استخدم [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) لنسخ تعريف اللون، بما في ذلك نوعه، مرجع السمة، والتحولات. يكون هذا مفيدًا عند نقل لون تعبئة بين أشكال يجب أن تستمر في اتباع سمة العرض. تنسخ الطريقة اللون فقط: لا تنسخ نوع التعبئة أو الحد أو تنسيقات الشكل الأخرى. اضبط نوع التعبئة للوجهة صراحةً باستخدام [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

ينشئ هذا المثال ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة واعية للسمة، ونسخة RGB ثابتة. يستخدم المصدر [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) للإشارة إلى اللون الأول للتمييز ويضيف تدرجًا عبر [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). تستخدم نسخة RGB اللون الفعّال للمصدر بحيث تبدو الثلاثة متماثلة في البداية. يستدعي [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) لتعيين قيمة RGB ثابتة ويزيل أي تحولات لون موجودة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // تتبع مراجع السمة اللون المميز الجديد؛ قيمة RGB الثابتة لا تتبع ذلك.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قبل تغيير السمة، جميع التعبئات الثلاثة متطابقة:

![المصدر، الوجهة المنسوخة، والوجهة RGB الثابتة بألوان زرقاء متطابقة](color-copy-before.png)

بعد تغيير السمة، يتبع المصدر والنسخة الواعية للسمة اللون الجديد مع الحفاظ على تدرجه. تظل نسخة RGB الثابتة زرقاء:

![المصدر والنسخة المنسوخة بألوان برتقالية، بينما تبقى نسخة RGB ثابتة زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. لذا لا يؤثر تغيير مرجع السمة في المصدر أو إضافة/إزالة التحولات على الوجهة. ومع ذلك، لا يزال تغيير السمة يؤثر على كلا الشكلين لأن كلًا منهما ي référencé إلى نفس لون السمة.

يحافظ حفظ وإعادة فتح ملف PPTX على نوع اللون المنسوخ الذي تُرجعه [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType)، ومرجع السمة، ومجموعة التحولات التي تُرجعها [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform)؛ ولا يتم تحويل التعريف إلى RGB.

عند النسخ بين سياقات سمة مختلفة، مثل عروض تقديمية ذات لوحات ألوان متميزة، يتم حل المرجع المنسوخ وفق سمة الوجهة. وبالتالي قد ينتج عن نفس المرجع والتحولات لون مرئي مختلف. راجع [Presentation Theme](/slides/ar/nodejs-java/presentation-theme/) لمزيد من المعلومات حول تكوين ألوان السمة.

## **استخدام خلفية الشريحة كملء للشكل**

استخدم [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، مثلًا في قالب عرض تقديمي. اضبط نوع التعبئة عبر [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) إلى [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) أولًا لإزالة أي تعبئة صريحة. مع هذا الجمع، يستخدم الشكل خلفية الشريحة بدلاً من تعبئته الخاصة. لا يزيل تفعيل العلم الفلاغ وحده أي تعبئة صريحة موجودة.

يختلف ذلك عن [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما لا تعبئة تترك تلك الكائنات مرئية. يظل التدرج محاذيًا مع الشريحة بدلاً من البدء داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية موروثة من الشريحة ويضع شريطًا بنفسجيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // ورث التدرج من القالب الأساسي.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // أضف هذا الكائن أولًا حتى يظهر خلف المستطيلات.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // قم بإلغاء تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة، من اليسار إلى اليمين: **تعبئة خلفية**، **بدون تعبئة**، و**تعبئة صريحة**. يتم إخفاء الشريط الأرجواني خلف المستطيلين الأيسر والأيمن لكنه يظل مرئيًا من خلال المستطيل الأوسط.

![تعبئة خلفية، بدون تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

ينطبق السلوك نفسه على الخلفية المعرفة مباشرة على الشريحة أو الموروثة من تخطيط. يستخدم الشكل خلفية الشريحة المحلولة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير محددين حتى تقوم الخلفية الرئيسية بتوفيرها.

## **ضبط الشفافية**

في التعبئة الصلبة، يتحكم المكوّن alpha للون في الشفافية: 0 يعني شفاف تمامًا و255 يعني غير شفاف تمامًا. يستخدم هذا المثال قيمة alpha مقدارها 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50% بحيث يبقى المستطيل الموجود تحته مرئيًا. يُعطى اللون عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

استخدم [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) لدوران الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات Bevel ثلاثية الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) لإعطاء الشكل عمقًا وحوافًا مزيّنة. ينشئ هذا المثال بيضاويًا أخضرًا بحد برتقالي، ويضبط العمق إلى 4 نقاط عبر [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth)، ثم يضيف حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). تجعل الكاميرا المتعامدة الأمامية والإضاءة ثلاثية النقاط الحافة مرئية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تأثير Bevel ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

يتم التحكم في منظر الشكل الثلاثي الأبعاد عبر إعدادات الكاميرا. يستخدم هذا المثال [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) بزاوية خطوط العرض والطول والدوران 40، 35، و20 درجة على التوالي. يحدد كاميرا إسومتريّة عبر [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المنسق.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تأثير دوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) كيف يُعرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي بوضع الأبيض والأسود. لا تمكّن هذه الطريقة عرضًا بالأبيض والأسود بحدها، ولا تغير تعبئة الشكل أو حدوده أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يترك التطبيق يختار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على اللون الطبيعي، و`Hidden` يلغي الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويستخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) لتحديد اللون الرمادي. يحتفظ الشكل المحفوظ بملئه البرتقالي للعرض الملون العادي ويطلب اللون الرمادي للتطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض أبيض وأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يحترم إعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) لاستعادة موضع وحجم وتنسيق عناصر النائب في الشريحة من نظيراتها في تخطيط الشريحة. يتطلب هذا المثال وجود عرض تقديمي موجود يحتوي على عناصر نائب مرتبطة بالتخطيط ويعيد تعيين كل شريحة قبل الحفظ. لا يتم إعادة تعيين الأشكال التي لا يوجد لها عنصر نائب في التخطيط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

الألوان، أنماط الخط، وإعدادات التأثير عادةً لا تضيف سوى بيانات قليلة مقارنةً بالصور والوسائط المدمجة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متماثل لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا طابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة نموذج أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وطبق تنسيقاتها حيثما يلزم.