---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية على Android
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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لنظام Android، مع دعم OMML، عناصر التحكم في التنسيق، وعينات شفرة Java واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لنظام Android عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجيًا: الكسور، الجذور، الدوال، الحدود، عوامل N‑ary، المصفوفات، المصفوفات، والكتل الرياضية المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **Insert > Equation**:

![علامة تبويب Insert في PowerPoint مع اختيار أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

يبني Aspose.Slides ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathportion/) يخزن المحتوى الرياضي داخل إطار النص الخاص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) يحتوي على واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathematicaltext/) والطرق السلسة من [IMathElement](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) للحفاظ على شفرة مختصرة وقابلة للقراءة.

للحالات التي تتطلب تصدير MathML، راجع [تصدير المعادلات الرياضية من العروض التقديمية على Android](/slides/ar/androidjava/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلاً رياضيًا ويضيف مبرهنة فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` ينشئ شكلاً يحتوي بالفعل على فقرة رياضية. احصل على أول `MathPortion`، استخرج `MathParagraph` الخاص به، ثم أضف كتلًا رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة الكسور**

استخدم `divide` لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathfractiontypes/).

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

استخدم `radical` لإنشاء جذر تربيعي، جذر مكعب أو أي جذر آخر. يصبح العنصر الحالي القاعدة، ويصبح المعامل الدرجة.

![تعبير جذر من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

استخدم `asArgumentOfFunction` أو `function` للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathlimit/) أو استخدم `setLowerLimit`.

![حد x عندما يقترب x من المالانهاية](powerpoint-math-equations_8.png)

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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **إضافة عوامل N‑ary والتكاملات**

استخدم `nary` للجمعيات، الاتحاد، التقاطع وغيرها من العوامل الكبيرة. استخدم `integral` للتكاملات. كلا الطريقتين يتيحان لك تحديد الحد الأدنى والحد الأعلى.

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

العوامل N‑ary مخصصة للعوامل الكبيرة مع حدود اختيارية. العوامل البسيطة مثل `+`، `-`، و`=` عادةً ما تُضاف كـ `MathematicalText` وتدمج ضمن التعبير.

لإنشاء تكامل، استخدم `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس بشكل افتراضي، لذا قم بضم المصفوة عندما تحتاج إلى أقواس مستديرة أو مربعة أو معقوفة.

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

استخدم `toMathArray` عندما تحتاج إلى معادلات محاذاة أو مجموعة عمودية من التعابير.

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

استخدم `asArgumentOfFunction` عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

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

## **إضافة المؤشرات والروابط العلوية**

استخدم المساعدين للمؤشر والرفع العلوي للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر من القاعدة، استخدم `setSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مؤشر سفلي 1 على اليسار ورفع علوي n](powerpoint-math-equations_9.png)

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

## **إضافة المحددات**

استخدم `enclose` لوضع تعبير داخل المحددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأعمدة رأسية](powerpoint-math-equations_13.png)

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

## **إضافة صندوق حدود**

استخدم `toBorderBox` عندما يجب أن يُحاط المعادلة بإطار.

![معادلة محصورة تُظهر a² = b² + c²](powerpoint-math-equations_12.png)

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

![التعبير x + y مُجمّع مع تسمية أي نص أسفله](powerpoint-math-equations_15.png)

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

استخدم مساعدي التنسيق فقط حيث يوضحون الصيغة. على سبيل المثال، `overbar` يضع شريطًا فوق عنصر رياضي.

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
| إنشاء الكسور | [IMathElement.divide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة رفع علوي أو مؤشر سفلي | [setSuperscript](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة جذور | [IMathElement.radical](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة سكريبتات على اليسار | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة عمليات الجمع والتكامل | [nary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathmatrix/) |
| إضافة مصفوفات معادلات | [toMathArray](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| إضافة أشرطة و حدود | [overbar](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathelement/) |

## **الأسئلة الشائعة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل يتم حفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، تقوم Aspose.Slides بكتابة المعادلة ك contenido رياضي من Office قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

تقوم Aspose.Slides بتصدير معادلات الرياضيات إلى MathML. إذا كنت بحاجة إلى LaTeX، قم أولاً بتصدير إلى MathML ثم حوّل MathML باستخدام أداة تدعم لهجتك المستهدفة من LaTeX.