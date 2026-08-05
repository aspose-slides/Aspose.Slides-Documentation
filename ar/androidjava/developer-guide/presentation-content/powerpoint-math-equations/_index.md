---
title: إضافة معادلات رياضية إلى عروض PowerPoint على Android
linktitle: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "إدراج وتعديل المعادلات الرياضية في عروض PowerPoint بصيغة PPT وPPTX باستخدام Aspose.Slides لنظام Android، مع دعم OMML، أدوات تنسيق، وعينات شفرة Java واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides for Android عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجياً: الكسور، الجذور، الدوال، الحدود، عوامل N-ary، المصفوفات، المصفوفات، والكتل الرياضية المنسقة.

في PowerPoint، يضيف المستخدمون المعادلات عادةً من **Insert > Equation**:

![تبويب الإدراج في PowerPoint مع تحديد أمر المعادلة](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathportion/) يخزن محتوى الرياضيات داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) يحتوي على كائن واحد أو أكثر من [MathBlock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathematicaltext/) والطرق السلسة من [IMathElement](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) لتقليل طول الشيفرة وجعلها قابلة للقراءة.

للاسستعمالات تصدير MathML، راجع [Export Math Equations from Presentations on Android](/slides/ar/androidjava/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلًا رياضيًا ويضيف نظرية فيثاغورس:

![المعادلة c تربيع تساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` ينشئ شكلاً يحتوي مسبقاً على فقرة رياضية. احصل على أول `MathPortion`، ثم `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة كسور**

استخدم `divide` لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لقطع مكدس، استخدم `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة جذور**

استخدم `radical` لإنشاء جذر تربيعي أو مكعب أو جذر آخر. يصبح العنصر الحالي القاعدة، وتصبح الوسيطة الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة دوال وحدود**

استخدم `asArgumentOfFunction` أو `function` للدوال مثل `sin(x)`, `log(x)` أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathlimit/) أو استخدم `setLowerLimit`.

![حد x عندما يقترب x من ما لا نهاية](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **إضافة عوامل N-ary وتكاملات**

استخدم `nary` للجمع، الاتحاد، التقاطع، وعوامل كبيرة أخرى. استخدم `integral` للتكاملات. كلتا الطريقتين تسمحان بتعيين حدود سفلية وعلوية.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. تُضاف العوامل البسيطة مثل `+`, `-`, و `=` عادةً كـ `MathematicalText` وتُدمج في التعبير.

للتكامل، استخدم `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تشمل الأقواس بشكل افتراضي، لذا احط المصفوفة بأقواس أو أقواس مربعة أو أقواس معقوفة عندما تحتاج ذلك.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة مصفوفات المعادلات**

استخدم `toMathArray` عندما تحتاج إلى معادلات محاذاة أو مجموعة عمودية من التعبيرات.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة الدوال المثلثية**

استخدم `asArgumentOfFunction` عندما يكون الوسيط هو العنصر الحالي ويُعرف اسم الدالة.

![دالة مثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة المؤشرات والرفعات**

استخدم المساعدات للمؤشرات والرفعات للمؤشرات والأسس. عندما يجب أن تظهر المؤشرات على الجانب الأيسر للقاعدة، استخدم `setSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مؤشر أيسر 1 ورفع n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة محددات**

استخدم `enclose` لوضع تعبير داخل محددات. يمكنك أيضاً تحديد حرف فاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x، y، و z مفصولين بأشرطة رأسية](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة إطار حد**

استخدم `toBorderBox` عندما يجب أن تكون المعادلة نفسها مؤطرة.

![معادلة في إطار تُظهر a تربيع يساوي b تربيع زائد c تربيع](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تجميع المصطلحات**

استخدم `group` لوضع حرف تجميع فوق أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x زائد y مُجمّع مع تسمية أي نص أسفله](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنسيق عناصر الرياضيات**

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، `overbar` يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة رفع أو مؤشر | [setSuperscript](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة جذور | [IMathElement.radical](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة مؤشرات على الجانب الأيسر | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة جمع وتكامل | [nary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathmatrix/) |
| إضافة مصفوفات المعادلات | [toMathArray](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |

## **FAQ**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في ذلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، تقوم Aspose.Slides بكتابة المعادلة كـ Office Math محتوى قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/) للمعادلة من خلال [IMathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/)، ثم استدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/#toLatex--) لتصديره مباشرة. للحصول على مثال كامل، راجع [Export Math Equations from Presentations in Android via Java](/slides/ar/androidjava/exporting-math-equations/#export-math-equations-to-latex).