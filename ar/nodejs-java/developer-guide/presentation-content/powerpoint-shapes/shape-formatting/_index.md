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
- خط الشكل التخطيطي
- تنسيق أسلوب الوصل
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة صورة
- تعبئة بنقش
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج رمادي
- دوران الشكل
- تأثير تقويم ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في JavaScript باستخدام Aspose.Slides—قم بتعيين أنماط التعبئة وخط الشكل والتأثيرات لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **المقدمة**

قُم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، تعبئتها، وتأثيراتها. تتيح لك Aspose.Slides for Node.js عبر Java التحكم في هذه الإعدادات برمجيًا، بما في ذلك الشفافية، الدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Node.js عبر Java فئات وأساليب تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) للتحكم في حدود الشكل. يُنشئ هذا المثال مستطيلًا غير مملوء بحد أزرق متقطّع. يختار [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) خطًا مركبًا سميك‑رفيع، بينما يضبط [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) عرضه إلى 7 نقاط و[LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) يحدد نمط التقطيع.

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

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط التقطيع المخصصة للخط**

استخدم [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المحددة مسبقًا أطوال الفواصل والشرط التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط التقطيع تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

تتناوب القيم في المصفوفة بين طول الفاصل وطول الفارغ، بدءًا بفاصل. كل قيمة هي مضاعف لعرض الخط: `[4, 2]` عند عرض 3 نقاط ينتج عنه فاصل بطول 12 نقطة يليه فارغ بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة غير السالبة لتعريف مقاطع الفاصل‑الفارغ الكاملة. يستخدم المثال قيمًا موجبة للحفاظ على رؤية كل فاصل وفارغ.

ينشئ هذا المثال خمسة خطوط زرقاء بنفس الطول ورؤوس مسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. يعيد الرابع تكرار النمط الأول بعرض مضاعف، مما يضاعف كل من أطوال الفاصل والفارغ. الخامس ينتقل من نمط مخصص إلى خط صلب.

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

للعودة إلى نمط متقطع محدد مسبقًا، مرّر [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) إلى [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). النمط المختار يتحكم في مظهر الخط.

النتيجة في PowerPoint، من أعلى إلى أسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![ثلاثة أنماط تقطع مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين أطراف الخط**

استخدم [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) لتحديد نهايات خط مفتوح. توفر الفئة [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) ثلاثة أنماط رأس صريحة:

- `Flat`: يتوقف الضرب عند نقطة النهاية.
- `Round`: رأس نصف دائري يمتد خارج نقطة النهاية نصف عرض الخط.
- `Square`: رأس مربع يمتد خارج نقطة النهاية نصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، مما يعني عدم تعيين نمط رأس صريح.

الأطراف مختلفة عن رؤوس السهام، التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يُعطِّل هذا المثال رؤوس السهام عبر [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) لكي تُقارن فقط أشكال الأطراف.

ينشئ المثال التالي ثلاثة خطوط أفقية متطابقة أخرى، عرضها 20 نقطة. من أعلى إلى أسفل، تستخدم أطرافًا مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ الأطراف المستديرة والمربعة تمتد 10 نقاط خارج كل نقطة نهائية.

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

النتيجة في PowerPoint، من أعلى إلى أسفل: **Flat**، **Round**، و**Square**.

![أطراف مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

يعرض كود JavaScript التالي كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

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

القيمة التي تُعيدها [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرة إلى الشكل. إذا كان تنسيق الخط يمكن وراثته من سمة، شريحة رئيسية، أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective)، ثم استدعِ `getSketchFormat` على الكائن المرجع، وبعد ذلك استدعِ طريقة `getSketchType` الخاصة به. القيمة الفعّالة تعكس التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة. يتطلّب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في الشريحة الأولى ويطبع القيمتين:

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

## **تنسيق أنماط الوصلات**

فيما يلي ثلاثة خيارات لأنواع الوصلات:

* Round
* Miter
* Bevel

يتحكم نمط الوصلة في كيفية التقاء مقطعي الحدود عند زاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

يُنشئ هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يستخدم [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) لتطبيق قيم الميتر، والميزات، والدوائر من فئة [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/)، على التوالي، للمقارنة بين كيفية رسم الزوايا.

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

### **تقييد وصلات الميتر عند الزوايا الحادة**

استخدم [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) مع [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) مضبوطًا على [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) لتقييد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزاويتين الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول ميتر يصل إلى ثمان مرات عرض الخط؛ وهي ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مائلة عند تلك الزاوية. يسمح الحد الأكبر بنقاط أكثر حدة. يؤثر الإعداد على وصلات الميتر فقط، ولا يُظهر تأثيرًا مرئيًا عند بقاء الزاوية ضمن الحدين.

ينشئ هذا المثال مثلثين غير مملوءين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا مقداره `2`، واليمن يستخدم `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، مما يمنح زاوية القمة نسبة طول الميتر إلى عرض الخط تقريبًا `4.12`. وبالتالي، يقوم PowerPoint بعمل وصلة مائلة للزاوية اليسرى ويحافظ على حدة الزاوية اليمنى.

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

![قمة مائلة بحد ميتر 2 وقمة حادة بحد ميتر 8 في PowerPoint](miter-limits.png)

## **تعبئة متدرجة**

تُدمج تعبئة المتدرجة الألوان عبر الشكل. يملأ هذا المثال إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى البنفسجي باستخدام [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). تُضيف طريقة [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط التوقف اللونية عند 0 و 1، بداية ونهاية التدرج. يضمن مسح نقاط التوقف الحالية استخدام هذين اللونين فقط.

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

![الإهليلج بتعبئة متدرجة](gradient-fill.png)

إذا بدا التدرج مختلفًا في صورة مُصدرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير التدرج المخزن في العرض التقديمي.

### **ضبط زاوية التدرج الخطي**

استخدم [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد مع عقرب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و `270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبع الزوايا خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` يصبح `315` و `360` يصبح `0`.

ينشئ هذا المثال ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة عند المواضع `0`، `0.5`، و `1`. تم تعطيل التحجيم بحيث يمكن مقارنة الزاوية بشكل مستقل عن أبعاد المستطيلات. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و `90` في الصف الأول، و `135`، `180`، و `270` في الصف الثاني.

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

![تدرجات خطية بزاوية 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

تقبل [GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية عند تغيير أبعاد الشكل، أو إلى `True` لتحجيم التدرج مع عرض وارتفاع الشكل. مع تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونفس نقاط التوقف اللونية كما في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ يوضح تغيير عرض وارتفاع المستطيل الثاني كيف يستجيب التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

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

![مستطيلات عريضة وطويلة بتدرج 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تحتفظ أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع أبعاد الشكل. يساعد هذا في إعادة إنتاج تدرج القالب عند تعديل الشكل إلى حجم مختلف. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية فقط. فهي لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

تختار [GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) نمط تدرج من فئة [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); وهو ليس بديلاً للزاوية الرقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزّع فيها الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). حافظ على الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

التطبيق التالي يطبق نفس الإعدادات بترتيب عكسي. المستطيلان يظهران مظهرًا متطابقًا: ضبط الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

تطبيق تعبئة بنمط يضيف تصميمًا بلونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط شبكي. توفر [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) خلفية رمادية فاتحة، وتوفر [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) لون النمط الأصفر.

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

![المستطيل بتعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تستخدم تعبئة الصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) لتحميلها إلى مجموعة صور العرض. يضبط [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) إلى وضعية التكرار لتكرار الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا معروضة أدناه:

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

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كنقش**

إذا رغبت في تعيين صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضعية تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): يُحدد محاذاة القوالب داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت القالب تُقلب أفقيًا أو رأسيًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد إزاحة القالب أفقياً (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد إزاحة القالب رأسياً (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): يعرّف مقياس القالب أفقيًا كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): يعرّف مقياس القالب رأسيًا كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) لتكرارها بنسبة 50 % من حجمها الأصلي. تُحوِّل الإزاحات بـ −32 نقطة القوالب أفقيًا ورأسيًا؛ تحدد محاذاة الزاوية السفلية اليمنى والقلب في كلا الاتجاهين كيفية ترتيب النقش المتكرر.

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

![خيارات القالب](tile-options.png)

## **تعبئة بلون صلب**

توفر التعبئة الصلبة لونًا موحدًا للشكل. يستخدم هذا المثال [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) لتحديد وضعية التعبئة الصلبة ويعين اللون الأصفر عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

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

## **استخدام خلفية الشريحة كتعبئة للشكل**

استخدم [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. استخدم [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) لتحديد [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذه المجموعة، يستخدم الشكل خلفية الشريحة بدلاً من تعبئته الخاصة. تمكين العلم بمفرده لا يُزيل أي تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة الخلفية المقابلة للشريحة، بينما لا تعبئة تترك تلك الكائنات مرئية. يظل التدرج محاذيًا مع الشريحة بدلاً من اعادة البدء داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية يُورّثها الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، المستطيل الأوسط لا تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // ورث التدرج من الماستر.
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

    // أضف هذا الكائن أولاً بحيث يظهر خلف المستطيلات.
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

    // تعطيل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة، من اليسار إلى اليمين: **تعبئة خلفية**، **بدون تعبئة**، و**تعبئة صريحة**. شريط الأرجواني مخفي خلف المستطيلين الأيسر واليمن لكنه يبقى مرئيًا عبر المستطيل الأوسط.

![تعبئة خلفية، بدون تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

ينطبق نفس السلوك على خلفية معرفة مباشرةً على الشريحة أو مُورّثة من تخطيط. يستخدم الشكل خلفية الشريحة المُحَلَّة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير مُحددة بحيث يزود الماستر الخلفية.

## **ضبط الشفافية**

في تعبئة صلبة، تتحكم مكوّن ألفا للون في مستوى الشفافية: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50 % بحيث يظل المستطيل الموجود تحته مرئيًا. يُعيّن اللون عبر [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

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

استخدم [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات مع عقرب الساعة ويحفظ العرض التقديمي.

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

## **إضافة تأثيرات تقويم ثلاثية الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) لإضفاء عمق وحواف مقطعة على الشكل. يُنشئ هذا المثال إهليلجًا أخضرًا بحد برتقالي، ويستخدم [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) لتعيين العمق إلى 4 نقاط، ويطبق تقويمًا علويًا دائريًا بعرض وارتفاع 6 نقاط عبر [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). تجعل كاميرا إقليدية أمامية وإضاءة ثلاثية النقاط التقويم مرئيًا.

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

![تأثير التقويم ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تُتحكم إعدادات الكاميرا في طريقة عرض الشكل ثلاثي الأبعاد. يستخدم هذا المثال [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) بزاوية درجة عرض 40، وخط عرض 35، ودرجة دوران 20. يختار كاميرا إيزومتريّة عبر [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المُنسق.

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

تحدد طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي بوضعية الأبيض والأسود. لا تُفعِّل طريقة العرض بالأبيض والأسود بنفسها، ولا تغير تعبئة الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يسمح لتطبيق العرض باختيار التحويل، `Gray` و `LightGray` تُظهر تلوينًا رماديًا، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و `White` يجبران على لون واحد، `Color` يحافظ على التلوين العادي، و `Hidden` يُزيل الشكل في وضعية الأبيض والأسود. `NotDefined` يعني عدم تعيين وضعية على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويستخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) لتحديد تلوين رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض الملون العادي ويطلب تلوينًا رماديًا من التطبيقات التي تُطبق إعدادات العرض بالأبيض والأسود:

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

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه محدد إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يُطبق إعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

استخدم [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) لاستعادة موضع، حجم، وتنسيق عناصر النائب في الشريحة من عناصر النائب المقابلة في التخطيط. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائب مرتبطة بالتخطيط ويُعيد تعيين كل شريحة قبل الحفظ. لا تُعاد العناصر التي ليس لها عنصر نائب في التخطيط.

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

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

عادةً ما تُضيف الألوان، أنماط الخطوط، وإعدادات التأثيرات كمية قليلة من البيانات مقارنةً بالصور والوسائط المضمنة. قد تزيد تعبئات الصور من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في الشريحة التي تشترك في تنسيق متطابق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الأساسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أسلوبها متطابقًا وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأسلوب لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصّصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية ذات الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المُنسقة التي تحتاجها، وأعد تطبيق تنسيقاتها حيثما دُعيت.