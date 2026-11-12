---
title: إضافة معادلات الرياضيات إلى عروض PowerPoint التقديمية في JavaScript
linktitle: معادلات الرياضيات في PowerPoint
type: docs
weight: 80
url: /ar/nodejs-java/powerpoint-math-equations/
keywords:
- معادلة رياضية
- رمز رياضي
- صيغة رياضية
- نص رياضي
- إضافة معادلة رياضية
- إضافة رمز رياضي
- إضافة صيغة رياضية
- إضافة نص رياضي
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدراج وتحرير معادلات الرياضيات في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Node.js عبر Java، مع دعم OMML، أدوات تنسيق، وعينات شفرة JavaScript واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغلات N-ary، المصفوفات، المصفوفات (arrays) والكتل الرياضية المنسقة.

في PowerPoint، عادةً ما يضيف المستخدمون المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النص الرياضي القابل للتحرير يظهر على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) يخزن محتوى الرياضيات داخل إطار النص الخاص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) يحتوي على عنصر واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) والطرق المتسلسلة من [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) للحفاظ على القصر وسهولة القراءة في الشيفرة.

للتعامل مع تصدير MathML، راجع [تصدير معادلات الرياضيات من العروض التقديمية في Node.js عبر Java](/slides/ar/nodejs-java/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) ينشئ شكلاً يحتوي بالفعل على فقرة رياضية. احصل على أول [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، وأضف كتلًا رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يظهر واحد مقسومًا على x](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإنشاء كسر مكدس، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) لإنشاء جذر تربيعي، أو جذر مكعب، أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

![تعبير جذري للدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة دوال وحدود**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) أو [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) مع حجته:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **إضافة المشغلات N-ary والتكاملات**

استخدم [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) للتجميعات، والاتحادات، والاقترانات، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) للتكاملات. كلا الطريقتين تسمحان بتحديد الحدود السفلية والعليا.

![جمع بحدود سفلية وعليا](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المشغلات N-ary هي للمشغلات الكبيرة ذات حدود اختيارية. المشغلات البسيطة مثل `+`، `-`، و`=` عادةً ما تُضاف كـ [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تشمل الأقواس بشكل افتراضي، لذا أغلِّق المصفوفة عندما تحتاج إلى أقواس أو قوسين أو أقواس معقوفة.

![مصفوفة رياضية ذات صفين مع خلية فارغة واحدة](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة مصفوفات المعادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) عندما تحتاج إلى معادلات محاذية أو مجموعة عمودية من التعبيرات.

![صف رياضي عمودي مع x فوق y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **محاذاة مصفوفة مع العناصر المحيطة**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) يتحكم في محاذاة الصفوف عموديًا بالنسبة إلى العناصر الرياضية المجاورة. المثال أدناه يقارن المحاذاة مع الصف الأول، وسط المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل منها بثلاث صفوف والعناصر المجاورة `A=` و`=B`. كل النص الرياضي يستخدم خط Cambria Math بحجم 24 نقطة. فقط محاذاة المصفوفة هي التي تتغير.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint. لاحظ موضع `A=` و`=B` بجانب كل مصفوفة.

![مصفوفات المعادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) يختار قاعدة التباعد للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) يزود قيمة رقمية لقاعدة تباعد صريحة ويتم تجاهلها إذا تم اختيار قاعدة مسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بالنصف سطر: القيمة `3` في المثال تمثل 1.5 سطر. عيّن الخاصيتين معًا عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية وحدها لا يختار قاعدة تباعد.

المثال أدناه يحفظ خمسة عروض تقديمية بنفس المعادلات، والمحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم قواعد مسبقة؛ الأخيران يظهرا قيمًا صريحة.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

تباعد صفوف المصفوفة منفصل عن تباعد الفقرات. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) و[setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) يضيفان مسافة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. بالمثل، [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) يحدد موضع الفقرة الرياضية بأكملها أفقياً؛ ولا يستبدل إعداد المحاذاة العمودية للمصفوفة.

## **إضافة الدوال المثلثية**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) عندما يكون المتغير هو العنصر الحالي ويُعرف اسم الدالة.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة أسفلية وفوقية**

استخدم المساعدين للأسفلية والفوقية للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر للقاعدة، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![حرف Y كبير مع أسفلية 1 على الجانب الأيسر وفوقية n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة محددات**

استخدم [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات المحدد التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصول بأعمدة عمودية](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حجم ومحاذاة المحددات**

مرّر `true` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) لتسمح للأقواس بالتوسع حول عامل طويل، أو مرّر `false` لإبقائها بحجمها الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) مع إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` يوسط الأقواس على محور الرياضيات، الذي يمر عبر وسط علامة المساواة. `Match` يضبطها لتتناسب مع المحتوى المحصور. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير الداخلي كما هو.

المثال يضع كسرًا في الأس `x` بحيث يمتد التعبير أعلى من خط القاعدة أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في PowerPoint، قارن الصفوف لرؤية تأثير التوسع. في الصف العلوي، تتوسع الأقواس لتحتضن الأس وتتشابه الشكلين. في الصف السفلي، يكون التوسع معطلًا. الأقواس الأصغر على اليسار (`Centered`) تتطابق مع علامة المساواة، بينما الأقواس على اليمين (`Match`) ترتفع حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، وCentered على اليسار وMatch على اليمين](delimiter-sizing.png)

## **إضافة صندوق حدّي**

استدعِ [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) على كسر لتأطير التعبير بالكامل. الكائن المُرجع [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) يُظهر جميع الجوانب الأربعة بصورة افتراضية. استخدم [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft)، و[setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) لإزالة جوانب محددة.

المثال يضع ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة ومرّر `true` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) للحصول على قطري صاعد (↗) أو إلى [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) للحصول على قطري هابط (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) أو [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) مع أي تركيبة من الجوانب المرئية.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجانب السفلي والجانب الأيسر، قطري صاعد. الصف السفلي: قطري هابط، شط سطري، شط عمودي مع حد كامل](border-box-fractions.png)

في هذا الكسر، الشط الأفقي يتقاطع مع شريط الكسر. الشط العمودي يمر عبر البسط والمقام مع بقاء الحد المحيط مرئيًا. هذه الخطوط تُزيّن التعبير بأكمله. شط النص العادي يُطبق على الأحرف داخل جزء النص. بعد إعادة فتح العرض التقديمي في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل منفصل.

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) لوضع رمز تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x زائد y مُجمع مع التسمية أي نص أسفله](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنسيق عناصر الرياضيات**

استخدم مساعدين التنسيق فقط حيث يوضحون الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنسيق النص في معادلة موجودة**

لتنسيق النص عبر معادلة موجودة، استعرض شجرة عناصر كل كتلة رياضية. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) يرجع الأطفال المباشرين فقط، لذا استدعِه بصورة تكرارية للوصول إلى النص داخل الكسور، والكتابات فوق وتحت، والجذور، والهياكل المتداخلة الأخرى. تفحص العنصر الحالي وكذلك أطفاله لتضمين العنصر البداية عندما يكون [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

هذا المثال يفترض أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على أسفلية في البسط وجذر في المقام. معالجة العناصر العليا فقط سيتسبب في فقدان النص داخل الكسر. المثال يجد أجزاء رياضية في إطارات نص الشرائح، يتناول كتلها عبر [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) لتعيين حجم الخط إلى 28 نقطة من خلال طريقة [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) لكل عنصر نصي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العرض التقديمي المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| دمج العناصر | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إنشاء كسور | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة فوقية أو أسفلية | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة نصوص جانبية على اليسار | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة التجميعات والتكاملات | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| إضافة مصفوفات المعادلات | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة أشرطة وحدود | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **الأسئلة الشائعة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، اعثر على الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف كـ PPTX، تقوم Aspose.Slides بكتابة المعادلة كمحتوى Office Math قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) للمعادلة من [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، واستدعِ [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) لتصديره مباشرة. للحصول على مثال كامل، راجع [تصدير معادلات الرياضيات من العروض التقديمية في Node.js عبر Java](/slides/ar/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).