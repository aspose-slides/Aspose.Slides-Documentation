---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية باستخدام Java
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "إدراج وتعديل المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ Java، مع دعم OMML، أدوات تنسيق، وأمثلة شفرة Java واضحة."
---
## **نظرة عامة**

يخزن PowerPoint المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides for Java، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجيًا: الكسور، الجذور، الدوال، الحدود، عمليات N-ary، المصفوفات، المصفوفات، وكتل الرياضيات المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [addMathShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathportion/) يخزن محتوى الرياضيات داخل إطار النص الخاص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathematicaltext/) والطرق المتسلسلة من [IMathElement](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/) لتقليل طول الكود وزيادة مقروئيته.

للتعامل مع تصدير MathML، راجع [Export Math Equations from Presentations in Java](/slides/ar/java/exporting-math-equations/).

## **إنشاء معادلة**

توفر هذه المثال شكلًا رياضيًا ويضيف نظرية فيثاغورس:

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
`addMathShape` ينشئ شكلًا يحتوي مسبقًا على فقرة رياضية. قم بالوصول إلى أول `MathPortion`، احصل على `MathParagraph` الخاص به، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة الكسور**

استخدم `divide` لإنشاء كسر. يمكنك اختيار نمط الكسر عبر [MathFractionTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يُظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

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

لإنشاء كسر مكدس، استخدم `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم `radical` لإنشاء جذر تربيعي، جذر مكعب، أو أي جذر آخر. يصبح العنصر الحالي القاعدة، ويصبح الوسيط هو الدرجة.

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

## **إضافة الدوال والحدود**

استخدم `asArgumentOfFunction` أو `function` للدوال مثل `sin(x)`، `log(x)`، أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathlimit/) أو استخدم `setLowerLimit`.

![الحد للـ x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **إضافة عمليات N-ary والتكاملات**

استخدم `nary` للجمعيات، الاتحادات، التقاطعات، وغيرها من المشغلات الكبيرة. استخدم `integral` للتكاملات. كلا الطريقتين تسمحان بتعيين حدود سفلية وفوقية.

![جمعية مع حدود سفلية وفوقية](powerpoint-math-equations_7.png)

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

عمليات N-ary مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`، `-`، و`=` تُضاف عادةً كـ `MathematicalText` وتُدمج في التعبير.

للتكامل، استخدم `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathmatrix/) للصفوف والأعمدة. لا تتضمن المصفوفات الأقواس بشكل افتراضي، لذا قم بإحاطة المصفوفة عندما تحتاج إلى أقواس مستديرة أو مربعة أو معقوفة.

![مصفوفة رياضية ذات صفّين مع خلية فارغة واحدة](powerpoint-math-equations_10.png)

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

استخدم `toMathArray` عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعابير.

![مصفوفة رياضية رأسية مع x فوق y](powerpoint-math-equations_11.png)

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

استخدم `asArgumentOfFunction` عندما يكون الوسيط هو العنصر الحالي واسم الدالة معروف.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة المقاطعات والارتفاعات**

استخدم مساعدي المقاطعة والارتفاع للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر للأساس، استخدم `setSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مقاطعة يسرى 1 وارتفاع n](powerpoint-math-equations_9.png)

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

استخدم `enclose` لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصول بأشرطة عمودية](powerpoint-math-equations_13.png)

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

## **إضافة إطار حدودي**

استخدم `toBorderBox` عندما يجب أن يكون للمعادلة إطارًا.

![معادلة محاطة بإطار تُظهر c تربيع يساوي b تربيع زائد a تربيع](powerpoint-math-equations_12.png)

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

استخدم `group` لوضع رمز تجميع فوق أو تحت التعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x زائد y مُجمع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

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

استخدم مساعدي التنسيق فقط حيث يوضح الصيغة. على سبيل المثال، `overbar` يضع شريطًا فوق عنصر رياضي.

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
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| إنشاء الكسور | [IMathElement.divide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| إضافة ارتفاع أو مقاطعة | [setSuperscript](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| إضافة الدوال | [function](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| إضافة الجذور | [IMathElement.radical](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| إضافة الحدود | [setLowerLimit](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| إضافة سكريبتات على الجانب الأيسر | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| إضافة الجمعيات والتكاملات | [nary](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| إضافة المصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathmatrix/) |
| إضافة مصفوفات المعادلات | [toMathArray](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#toMathArray--) |
| إضافة المحددات | [enclose](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| إضافة الشرائط والإطارات | [overbar](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#toBorderBox--) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **الأسئلة المتداولة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظك إلى PPTX، تكتب Aspose.Slides المعادلة كمحتوى رياضي Office قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/) الخاص بالمعادلة من خلال [IMathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/)، واستدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/#toLatex--) لتصديره مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in Java](/slides/ar/java/exporting-math-equations/#export-math-equations-to-latex).