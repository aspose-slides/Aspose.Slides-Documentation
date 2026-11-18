---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في JavaScript
linktitle: معادلات رياضية PowerPoint
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
description: "إدراج وتعديل المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Node.js عبر Java، مع دعم OMML، والتحكم في التنسيق، وعينات شفرة JavaScript واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغلات متعددة الحدود، المصفوفات، القوائم، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة التبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape)، هو الشكل الذي يحتوي المعادلة.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) يخزن المحتوى الرياضي داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) يحتوي على عنصر واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) والطرق المتسلسلة من [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) لجعل الكود قصيرًا وسهل القراءة.

للحالات التي تتضمن تصدير MathML، راجع [Export Math Equations from Presentations in Node.js via Java](/slides/ar/nodejs-java/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c تربيع يساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. احصل على أول [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، وأضف كتلًا رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يُظهر واحدًا مقسومًا على x](powerpoint-math-equations_4.png)

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

استخدم [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) لإنشاء جذر تربيعي أو مكعب أو جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

### **إظهار أو إخفاء درجة الجذر التربيعي**

يمكن للجذر التربيعي إظهار الرقم 2 صراحةً أو استخدام الصيغة التقليدية √x. تتحكم طريقة [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) في [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) في أي شكل يظهر. كلا الشكلين يحتفظان بالدرجة 2 والقاعدة x في المعادلة القابلة للتحرير.

![نفس الجذر التربيعي مع الدرجة مرئية على اليسار ومخفية على اليمين](square-root-degree.png)

يُحفظ المثال الجذر التربيعي نفسه مرتين. في `visible-degree.pptx` تكون الـ2 مرئية. في `hidden-degree.pptx` تكون مخفية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة دوال وحدود**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) أو [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) للدوال مثل `sin(x)`, `log(x)`، أو لأسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![حد x عندما يقترب x من ما لا نهاية](powerpoint-math-equations_8.png)

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

## **إضافة المشغلات متعددة الحدود والتكاملات**

استخدم [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) للجمعيات، الاتحادات، التقاطعات، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) للتكاملات. كلا الطريقتين تسمحان بتحديد الحدود السفلى والعلوية.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

المشغلات متعددة الحدود مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`, `-`, `=` تُضاف عادةً كـ [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) وتُدمج في التعبير.

لإنشاء تكامل، استخدم [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) للصفوف والأعمدة. لا تتضمن المصفوفات أقواسًا بشكل افتراضي، لذا أرفق المصفوفة بأقواس أو أقواس معقوفة عندما تحتاج ذلك.

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

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي حفظها المثال السابق. للتمرين التالي، احتفظ بالمعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وعدّل مجموعة المتغيّرات. افتح المصفوفة الموجودة عبر [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) للحفاظ على المعاملات التي لا تزال صالحة.

![المصفوفة الأصلية ذات صفين مع القيم 1، x، وخلية فارغة في الصف الأول وx، 2، وy في الصف الثاني](matrix-before-edit.png)

مؤشرات الصفوف والأعمدة تبدأ من الصفر وتشير إلى المصفوفة كما هي في كل استدعاء. إدراج صف قبل الفهرس 1 ينقل الصف الثاني الأصلي إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفًا. حذف الصف 2 يزيل المعادلة الثانية الأصلية وينقل الصف المضاف لأعلى موضع واحد. الأعمدة تتحرك بنفس الطريقة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // الخلايا الجديدة في البداية تكون null. اضبط معاملات غير الصفر أولاً.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) يضبط محاذاة العمود الأول إلى اليسار. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) يضبط ثلاثة أعمدة متتالية إلى اليمين، بدءًا من الفهرس 1. في `updated-matrix.pptx`، تحتوي المصفوفة على ثلاث معادلات وأربع متغيّرات. المعاملات الأصلية للصف الأول `1` و`x` تظهر الآن في العمودين الأول والثالث.

![المصفوفة المحدثة ذات ثلاثة صفوف تُظهر الصفوف 1،0،x،0؛ 12،1،0،0؛ و0،0،10،1](matrix-after-edit.png)

## **إضافة مصفوفات معادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) عندما تحتاج إلى معادلات متراصّة أو مجموعة عمودية من التعبيرات.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

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

### **محاذاة المصفوفة مع العناصر المجاورة**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) يتحكم في محاذاة المصفوفة رأسياً بالنسبة للعناصر الرياضية المجاورة لها. المثال أدناه يقارن المحاذاة مع الصف الأول، وسط المصفوفة، والصف الأخير.

المثال التالي يُنشئ ثلاث مصفوفات متطابقة، كل واحدة بثلاثة صفوف والعناصر المجاورة `A=` و`=B`. جميع النصوص الرياضية تستخدم Cambria Math بحجم 24 نقطة. يتغيّر فقط محاذاة المصفوفة.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موقع `A=` و`=B` بجانب كل مصفوفة.

![مصفوفات معادلات في PowerPoint بمحاذاة أعلى، وسط، وأسفل مع عناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) يختار قاعدة التباعد للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) يزوّد قيمة رقمية لقاعدة تباعد صريحة ويتم تجاهلها إذا استخدمت القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بالنصف سطور: القيمة `3` في المثال تمثّل 1.5 سطر. اضبط كلتا الخاصيتين عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية وحدها لا يحدد قاعدة التباعد.

المثال أدناه يحفظ خمس عروض تقديمية بنفس المعادلات، المحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم الإعدادات المسبقة؛ الأخيرة اثنتان تُظهران قيمًا صريحة.

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

تباعد صفوف المصفوفة منفصل عن تباعد الفقرات. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) و[setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) يضيفان مساحة حول الفقرة المحتواة، وليس بين صفوف المصفوفة. بالمثل، [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) يضبط موضع الفقرة الرياضية ككل أفقياً؛ ولا يستبدل إعداد المحاذاة العمودية للمصفوفة.

## **إضافة دوال مثلثية**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) عندما يكون الوسيط هو العنصر الحالي ويُعرف اسم الدالة.

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

## **إضافة مؤشرات وتراكيب فوقية**

استخدم مساعدي المؤشر والتراكيب للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![حرف Y كبير مع مؤشر سفلي 1 ومركّب عُلوي n على اليسار](powerpoint-math-equations_9.png)

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

استخدم [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) لوضع تعبير داخل محددات. يمكنك أيضًا تحديد حرف فاصل لتعبيرات المحدد التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأشرطة رأسية](powerpoint-math-equations_13.png)

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

### **حجم وتوجيه المحددات**

مرّر `true` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) للسماح للأقواس بالنمو حول عنصر مرتفع، أو مرّر `false` لإبقائها بحجمها الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) مع أحد قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر منتصف علامة المساواة. `Match` يطابقها مع المحتوى المحاط. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير داخلها كما هو.

المثال يضع كسرًا في أس الأعلى لـ `x` بحيث يمتد التعبير أعلى القاعدة أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتحيط بالأس وتتشابه الشكلين. في الصف السفلي، يكون النمو معطلاً. الأقواس الصغيرة على اليسار (`Centered`) تتماشى مع علامة المساواة، بينما تلك على اليمين (`Match`) تجلس أعلى حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، وCentered على اليسار وMatch على اليمين](delimiter-sizing.png)

## **إضافة صندوق حدود**

استدعِ [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) على كسر لتأطير التعبير بأكمله. يعرض [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) جميع الجوانب الأربعة افتراضيًا. استخدم [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft)، و[setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) لإزالة جوانب معينة.

المثال يضع ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة ومرّر `true` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) للحصول على خط مائل صاعد (↗) أو إلى [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) للحصول على خط مائل هابط (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) أو [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) مع أي تركيبة من الجوانب المرئية.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حدود كاملة، جانبان سفلي ويساري، خط مائل صاعد. الصف السفلي: خط مائل هابط، خط أفقي، خط عمودي مع حدود كاملة](border-box-fractions.png)

على هذا الكسر، يتقاطع الخط الأفقي مع شريط الكسر. الخط العمودي يقطع كلًا من البسط والمقام بينما يبقى الحد الخارجي مرئيًا. هذه الخطوط تُزيّن التعبير بأكمله. شطب النص العادي يُطبّق على الأحرف في مجموعة النص. بعد إعادة فتح العرض التقديمي في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل منفصل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر Phantom**

لفّ التعبير داخل [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) للتحكم في رؤيته والمساحة التي يساهم بها في المعادلة بشكل مستقل. تُحكم طرق [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) الخصائص التالية:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | مرّر `false` لإخفاء التعبير. أبعادّه لا تزال تُساهم في التخطيط ما لم تتلقى الطرق المقابلة `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | عالج العرض الأفقي للتعبير كصفر، مما يسمح للعناصر المجاورة بالاقتراب. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | عالج الصعود (الارتفاع فوق الخط الأساسي) كصفر. يمكن أن يقلل ذلك من المسافة المحجوزة فوق العناصر المجاورة. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | عالج النزول (العمق تحت الخط الأساسي) كصفر. يمكن أن يحرك شريط الكسر أو محتوى آخر أسفل التعبير أقرب إلى جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، ومعالجة البُعد كصفر لا يحذف التعبير. يظل التعبير الأساسي متاحًا عبر [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase). مرّر `true` إلى [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) لإظهاره مرة أخرى؛ تظل إعدادات البُعد كما هي.

المثال أدناه يُنشئ خمسة متغيّرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحتفظ بالمساحة، وثلاثة كسور مخفية مع معالجة بُعد واحد كصفر. كل متغيّر يستخدم نفس التعبير المحيط وCambria Math بحجم 24 نقطة. جميع أشكال المعادلات لها نفس الموضع العلوي، مؤشرًا بالخط الرمادي. وضع الـ phantom في بسط كسر خارجي يجعل تغييرات التخطيط العمودي أسهل رؤية.

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
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![خمسة معادلات في PowerPoint تقارن كسرًا مرئيًا، كسرًا مخفيًا يحتفظ بالمسافة، وكُسور مخفية مع تمكين ZeroWidth أو ZeroAsc أو ZeroDesc](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) لوضع علامة تجميع فوق أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x زائد y مُجمّع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) يضع شريطًا فوق عنصر رياضي.

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

لتنسيق النص في معادلة موجودة، تجول في شجرة عناصر كل كتلة رياضية. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) يُرجع الأطفال المباشرين فقط، لذا نادِه بشكل متكرر للوصول إلى النص داخل الكسور، النصوص السفلية، الجذور، والهياكل المتداخلة الأخرى. تحقق من العنصر الحالي وكذلك من أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر سفلي في البسط وجذر في المقام. معالجة العناصر العليا فقط للكتلة ستفوت النص داخل الكسر. المثال يعثر على أجزاء رياضية في إطارات نص الشرائح، يصل إلى كتلها عبر [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) لتعيين حجم الخط إلى 28 نقطة عبر طريقة [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) لكل عنصر نصي.

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

العرض التقدّمي يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| Task | Main API |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| دمج عناصر | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إنشاء كسور | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة أس أو مؤشر سفلي | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة نصوص على الجانب الأيسر | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة جمعيات وتكاملات | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| إضافة مصفوفات معادلات | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة أشرطة وحدود | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **الأسئلة المتكررة**

**هل يمكن تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، تقوم Aspose.Slides بكتابة المعادلة ك-content رياضي Office قابل للتحرير.

**هل يمكن تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) الخاص بالمعادلة من [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)، واستدعِ [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) لتصديره مباشرة. للحصول على مثال كامل، راجع [Export Math Equations from Presentations in Node.js via Java](/slides/ar/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).