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
description: "إدراج وتحرير المعادلات الرياضية في عروض PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Android، مع دعم OMML، أدوات تنسيق، وعينات شفرة Java واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ Android عبر Java، يمكنك إنشاء نوع المحتوى الرياضي نفسه برمجيًا: الكسور، الجذور، الدوال، الحدود، المشغلات ذات N-arity، المصفوفات، مصفوفات المعادلات، وكتل الرياضيات المنسقة.

في PowerPoint، عادةً ما يضيف المستخدمون المعادلات من **Insert > Equation**:

![علامة التبويب Insert في PowerPoint مع تحديد أمر Equation](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/)، هو الشكل الذي يحتوي على المعادلة.  
[MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) يخزن المحتوى الرياضي داخل إطار النص الخاص بالشكل.  
[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

تستخدم معظم الأمثلة أدناه [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) وطرق السلسلة من [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) للحفاظ على كود قصير ومقروء.

للحالات تصدير MathML، راجع [تصدير المعادلات الرياضية من العروض التقديمية على Android](/slides/ar/androidjava/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) لإنشاء شكل رياضي ويضيف مبرهنة فيثاغورس:

![المعادلة c تربيع يساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ينشئ شكلًا يحتوي بالفعل على فقرة رياضية. قم بالوصول إلى أول [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)، وأضف كتل رياضية أو عناصر رياضية إليه.
{{% /alert %}}

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يُظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

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

لإنشاء كسر مكدس، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) لإنشاء جذر مربع أو جذر مكعب أو جذر آخر. يصبح العنصر الحالي القاعدة، وتصبح الوسيطة الدرجة.

![تعبير جذر من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

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

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) أو [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) للدوال مثل `sin(x)`، `log(x)`، أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

لتسمية دالة مخصصة، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) مع وسيلتها:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **إضافة المشغلات متعددة الحدود والتكاملات**

استخدم [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) للجمع، الاتحادات، التقاطعات، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) للتكاملات. تسمح لك كلتا الطريقتين بتعيين الحدود السفلية والعلوية.

![جمع مع حدود سفلية وعلوية](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

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

المشغلات متعددة الحدود تُستخدم للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`، `-`، و`=` عادةً ما تُضاف كـ [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس بشكل افتراضي، لذا غلف المصفوة عندما تحتاج إلى أقواس مستديرة أو مربعة أو معقوفة.

![مصفوفة رياضية من صفين مع خلية فارغة واحدة](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

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

## **إضافة مصفوفات معادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) عندما تحتاج إلى معادلات محاذية أو مجموعة رأسية من التعبيرات.

![مصفوفة رياضية عمودية بها x فوق y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

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

### **محاذاة مصفوفة مع العناصر المحيطة**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) يتحكم في محاذاة المصفوفة عموديًا بالنسبة للعناصر الرياضية المجاورة لها. المثال أدناه يقارن المحاذاة مع الصف الأول، وسط المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل واحدة منها بثلاث صفوف والعناصر المجاورة `A=` و`=B`. جميع النصوص الرياضية تستخدم Cambria Math بحجم 24 نقطة. فقط محاذاة المصفوفة تتغير.

```java
import com.aspose.slides.*;
import android.graphics.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint. لاحظ موضع `A=` و`=B` بجانب كل مصفوفة.

![مصفوفات معادلات في PowerPoint مع محاذاة علوية، وسطية وسفلية وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين تباعد الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) يختار قاعدة التباعد للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) يوفر قيمة رقمية لقاعدة تباعد صريحة ويتم تجاهلها عند استخدام القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف الأسطر: القيمة `3` في المثال تعني 1.5 سطر. قم بتعيين كلا الخاصيتين عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية فقط لا يختار قاعدة تباعد.

المثال أدناه يحفظ خمس عروض تقديمية بنفس المعادلات، المحاذاة وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرة تظهر قيمًا صريحة.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

تباعد صفوف المصفوفة منفصل عن تباعد الفقرة. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و[setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) يضيفان مساحة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. وبالمثل، [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) يحدد موضع الفقرة الرياضية بأكملها أفقيًا؛ ولا يستبدل إعداد محاذاة المصفوفة العمودية.

## **إضافة دوال مثلثية**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) عندما يكون الوسيط هو العنصر الحالي وتكون اسم الدالة معروفًا.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

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

## **إضافة أسفلية وفوقية**

استخدم المساعدين للكتابة السفلية والعليا للمؤشرات والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر من القاعدة، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Y capital مع مؤشر سفلي 1 ومؤشر أعلى n على الجانب الأيسر](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

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

استخدم [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأعمدة عمودية](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

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

### **حجم ومحاذاة المحددات**

مرّر `true` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) لتسمح للأقواس بالنمو حول العامل الطويل، أو مرّر `false` لإبقائها بالحجم الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) مع إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر منتصف علامة المساواة. `Match` يطابقها مع المحتوى المغلق. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير داخلها كما هو.

يوضع المثال كسرًا في أس سـ `x` بحيث يمتد التعبير أعلى القاعدة أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتغلف الأس وتبدو متشابهة لكلا الشكلين. في الصف السفلي، يكون النمو متوقفًا. الأقواس الصغيرة على اليسار (`Centered`) تتماشى مع علامة المساواة، بينما الأقواس على اليمين (`Match`) ترتفع حول التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات في الأعلى وتعطيله في الأسفل، و`Centered` على اليسار و`Match` على اليمين](delimiter-sizing.png)

## **إضافة إطار حدودي**

استدعِ [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) على كسر لتأطير التعبير بالكامل. [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) المُرجع يُظهر الجوانب الأربعة افتراضيًا. استخدم [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-)، [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-)، [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-)، و[setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) لإزالة جوانب فردية.

المثال يُضع ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، اخفِ جميع الجوانب الأربعة ومرّر `true` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) للحصول على خط مائل صاعد (↗) أو إلى [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) للحصول على خط مائل هابط (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) أو [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) مع أي تركيبة من الجوانب المرئية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجوانب السفلية واليسرى، خط مائل صاعد. الصف السفلي: خط مائل هابط، خط أفقي، خط عمودي مع حد كامل](border-box-fractions.png)

في هذا الكسر، يتقاطع الخط الأفقي مع خط الكسر. الخط العمودي يمر عبر البسط والمقام بينما يظل الحد المحيط مرئيًا. هذه الخطوط تزيّن التعبير بالكامل. الشطب العادي للنص يُطبق على الأحرف في مقطع نصي. بعد فتح العرض التقديمي مرة أخرى في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) لوضع حرف تجميع فوق أو تحت التعبير. أضف حدًا لتسمية المصطلحات المجمعّة.

![التعبير x + y مُجَمّع مع تسمية أي نص تحته](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

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

استخدم أدوات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع شريط فوقه](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

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

### **تنسيق النص في معادلة موجودة**

لتنسيق النص في كامل المعادلة الموجودة، تجول في شجرة العناصر لكل كتلة رياضية. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) تُعيد الأطفال المباشرين فقط، لذا استدعها بشكل متكرر للوصول إلى النص داخل الكسور، الأُسّ، الجذور، والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على مؤشر سفلي في البسط وجذر في المقام. معالجة العناصر العليا فقط للكتلة سيؤدي إلى فقدان النص داخل الكسر. يحدد المثال الأجزاء الرياضية في إطارات نص الشرائح، يصل إلى كتلها عبر [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) لتعيين حجم الخط إلى 28 نقطة عبر طريقة [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) لكل عنصر نصي.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العرض التقديمي المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| المهمة | API الرئيسي |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| دمج العناصر | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إنشاء كسور | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة أس فوقي أو أس سفلي | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة جذور | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة مؤشرات جانبية على اليسار | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة جمع وتكامل | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| إضافة مصفوفات معادلات | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| إضافة أشرطة وإطارات | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **الأسئلة المتكررة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، وابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), استدعِ [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابل للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، يقوم Aspose.Slides بكتابة المعادلة كمحتوى رياضي Office قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) للمعادلة من [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/), واستدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) لتصديره مباشرة. للحصول على مثال كامل، راجع [تصدير المعادلات الرياضية من العروض التقديمية على Android عبر Java](/slides/ar/androidjava/exporting-math-equations/#export-math-equations-to-latex).