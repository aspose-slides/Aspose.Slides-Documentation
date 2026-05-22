---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: معادلات رياضية في PowerPoint
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
description: "إدراج وتعديل المعادلات الرياضية في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لـ Node.js عبر Java، مع دعم OMML، أدوات تنسيق، وعينات شفرة JavaScript واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجياً: كسور، جذور، دوال، حدود، عوامل N-ary، مصفوفات، صفوف، وكتل رياضية منسقة.

في PowerPoint، يضيف المستخدمون عادة المعادلات من **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addMathShape)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathportion/) يتخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/) يحتوي على كائن أو أكثر من [MathBlock](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathematicaltext/) والطُرق المتسلسلة من [MathElementBase](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) لجعل الكود قصيراً وسهل القراءة.

للتصدير إلى MathML، راجع [Export Math Equations from Presentations in Node.js via Java](/slides/ar/nodejs-java/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلاً رياضياً ويضيف مبرهنة فيثاغورس:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
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

{{% alert color="primary" %}}
`addMathShape` ينشئ شكلاً يحتوي بالفعل على فقرة رياضية. احصل على أول `MathPortion`، ثم على `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة الكسور**

استخدم [`divide`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) لإنشاء كسر. يمكنك اختيار نمط الكسر عبر [MathFractionTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
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

لإنشاء كسر مكدس، استخدم `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم [`radical`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) لإنشاء جذر تربيعي، مكعب، أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
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

## **إضافة الدوال والحدود**

استخدم [`asArgumentOfFunction`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) أو [`function`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathlimit/) أو استخدم [`setLowerLimit`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **إضافة عوامل N-ary والتكاملات**

استخدم [`nary`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) للجمع، الاتحاد، التقاطع، وغيرها من العوامل الكبيرة. استخدم [`integral`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) للتكاملات. تسمح الطريقتان بتحديد الحدود السفلية والعليا.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
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

عوامل N-ary هي عوامل كبيرة يمكن أن تحتوي على حدود اختيارية. تُضاف العوامل البسيطة مثل `+`, `-`, `=` عادةً كـ `MathematicalText` وتُدمج في التعبير.

لإنشاء تكامل، استخدم `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس بشكل افتراضي، لذا أدرج المصفوفة بين أقواس أو أقواس معقوفة عند الحاجة.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
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

## **إضافة صفوف المعادلات**

استخدم [`toMathArray`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) عندما تحتاج إلى معادلات محاذاة أو مجموعة عمودية من التعبيرات.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
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

## **إضافة الدوال المثلثية**

استخدم [`asArgumentOfFunction`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) عندما يكون المتغير هو العنصر الحالي ويكون اسم الدالة معروفاً.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
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

## **إضافة المؤشرات والسوبر سكريبت**

استخدم المساعدين للكتابة السفلية والعلوية للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
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

## **إضافة المحددات**

استخدم [`enclose`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) لوضع تعبير داخل محددات. يمكنك أيضًا تحديد حرف فاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
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

## **إضافة إطار حدودي**

استخدم [`toBorderBox`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) عندما يجب أن تكون المعادلة نفسها محاطة بإطار.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تجميع المصطلحات**

استخدم [`group`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) لوضع علامة تجميع فوق أو تحت تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [`overbar`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) يضع شريطًا فوق عنصر رياضي.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
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

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathematicaltext/) |
| دمج العناصر | [join](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إنشاء الكسور | [divide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة سوبر سكريبت أو سوبسكريبت | [setSuperscript](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة الدوال | [function](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة الجذور | [radical](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة الحدود | [setLowerLimit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة السكريبتات الجانبية | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة الجمعيات والتكاملات | [nary](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة المصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathmatrix/) |
| إضافة صفوف المعادلات | [toMathArray](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة المحددات | [enclose](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| إضافة الشرائط والإطارات | [overbar](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathelementbase/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في ذلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، يكتب Aspose.Slides المعادلة كـ Office Math محتوى قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

يصدر Aspose.Slides المعادلات الرياضية إلى MathML. إذا كنت بحاجة إلى LaTeX، قم أولاً بالتصدير إلى MathML ثم حول MathML باستخدام أداة تدعم صيغ LaTeX المستهدفة.