---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية على Android
linktitle: معادلات رياضية في PowerPoint
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
description: "إدراج وتحرير المعادلات الرياضية في ملفات PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ Android، مع دعم OMML، أدوات التحكم في التنسيق، وعينات شفرة Java واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كلغة توصيف الرياضيات المكتبية (OMML). باستخدام Aspose.Slides for Android عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجياً: الكسور، الجذور، الدوال، الحدود، المشغّلات متعددة الحدود، المصفوفات، المصفوفات، والكتل الرياضية المنسقة.

في PowerPoint، يضيف المستخدمون عادةً المعادلات من **إدراج > معادلة**:

![علامة تبويب إدراج في PowerPoint مع تحديد أمر المعادلة](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/)، وهو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) يخزن محتوى الرياضيات داخل إطار النص الخاص بالشكل.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) يحتوي على كائن أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) والطُرق السلسة من [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) للحفاظ على الاختصار والقراءة.

للتعامل مع تصدير MathML، راجع [Export Math Equations from Presentations on Android](/slides/ar/androidjava/exporting-math-equations/).

## **إنشاء معادلة**

يستخدم هذا المثال [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) لإنشاء شكل رياضي ويضيف نظرية فيثاغورس:

![المعادلة c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ينشئ شكلاً يحتوي بالفعل على فقرة رياضية. الوصول إلى أول [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)، استدعاء [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)، وإضافة كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

## **إضافة الكسور**

استخدم [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/).

![كسر رياضي مائل يُظهر واحد مقسومًا على x](powerpoint-math-equations_4.png)

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

لكسر مكدس، استخدم [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **إضافة الجذور**

استخدم [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) لإنشاء جذر تربيعي أو مكعب أو أي جذر آخر. العنصر الحالي يصبح القاعدة، والوسيط يصبح الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

### **إظهار أو إخفاء درجة الجذر التربيعي**

يمكن للجذر التربيعي إظهار 2 صريحة أو استخدام تدوين √x التقليدي. طريقة [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) في [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/) تتحكم في الشكل الظاهر. كلا الشكلين يحتفظان بالدرجة 2 والجذر x في المعادلة القابلة للتحرير.

![نفس الجذر التربيعي مع إظهار الدرجة على اليسار وإخفائها على اليمين](square-root-degree.png)

يحفظ المثال الجذر نفسه مرتين. في `visible-degree.pptx` تكون الـ2 ظاهرة. في `hidden-degree.pptx` تكون مخفية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة الدوال والحدود**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) أو [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) للدوال مثل `sin(x)`، `log(x)` أو أسماء دوال مخصصة. للحدود، ضع `lim` في [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![حد x عندما يقترب x من المالانهاية](powerpoint-math-equations_8.png)

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

لإعطاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) مع وسيلتها:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **إضافة المشغّلات متعددة الحدود والتكاملات**

استخدم [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) للجمعيات، الاتحادات، التقاطعات، وغيرها من المشغّلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) للتكاملات. كلتا الطريقتين تسمحان بتعيين الحدود السفلية والعليا.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

المشغّلات متعددة الحدود مخصصة للمشغّلات الكبيرة ذات حدود اختيارية. المشغّلات البسيطة مثل `+`، `-`، و `=` تُضاف عادةً كـ [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **إضافة المصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن الأقواس افتراضيًا، لذا أدرج المصفوفة عندما تحتاج إلى أقواس أو أقواس مربعة أو أقواس معقوفة.

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

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي حفظها المثال السابق. للتمرين التالي، احفظ المعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وراجع مجموعة المتغيّرات. افتح المصفوفة الموجودة عبر [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) لتبقى المعاملات التي لا زالت صالحة.

![مصفوفة معاملات أصلية من صفين مع القيم 1، x، وخلية فارغة في الصف الأول، وx، 2، وy في الصف الثاني](matrix-before-edit.png)

تبدأ مؤشرات الصف والعمود من الصفر وتشير إلى المصفوفة كما هي عند كل استدعاء. إدراج صف قبل الفهرس 1 ينقل الصف الثاني الأصلي إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفًا. حذف الصف 2 يزيل المعادلة الثانية الأصلية ويحرّك الصف المضاف لأعلى موقعًا واحدًا. الأعمدة تتحرك بنفس الطريقة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("matrix.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathMatrix matrix = (IMathMatrix) portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // الخلايا الجديدة في البداية تكون null. اضبط المعاملات غير الصفرية أولاً.
    matrix.set_Item(1, 0, new MathematicalText("12"));
    matrix.set_Item(1, 1, new MathematicalText("1"));
    matrix.set_Item(2, 2, new MathematicalText("10"));
    matrix.set_Item(2, 3, new MathematicalText("1"));
    for (int row = 0; row < matrix.getRowCount(); row++) {
        for (int column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) يساير العمود الأول إلى اليسار. [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) يساير ثلاثة أعمدة متتالية إلى اليمين بدءًا من الفهرس 1. في `updated-matrix.pptx`، للمصفوفة ثلاث معادلات وأربعة متغيّرات. المعاملات الأصلية `1` و `x` الآن تظهران في العمودين الأول والثالث.

![مصفوفة محدثة من ثلاثة صفوف تُظهر الصفوف 1، 0، x، 0؛ 12، 1، 0، 0؛ و0، 0، 10، 1](matrix-after-edit.png)

## **إضافة مصفوفات المعادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) عندما تحتاج إلى معادلات محاذاة أو مجموعة عمودية من التعبيرات.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

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

### **محاذاة مصفوفة مع العناصر المجاورة**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) يتحكم في المحاذاة العمودية للمصفوفة نسبة إلى العناصر الرياضية المجاورة لها. المثال أدناه يقارن المحاذاة مع الصف الأول، مركز المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل منها ثلاث صفوف والعناصر المجاورة `A=` و `=B`. كل النص الرياضي يستخدم Cambria Math بحجم 24 نقطة. فقط محاذاة المصفوفة تتغيّر.

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

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موقع `A=` و `=B` بجانب كل مصفوفة.

![مصفوفات المعادلات في PowerPoint مع محاذاة أعلى، وسط، وأسفل وعناصر مجاورة متطابقة](equation-array-alignment.png)

### **تكوين مسافة الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) يختار قاعدة المسافة للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) يزوّد قيمة رقمية لقاعدة مسافة صريحة ويتم تجاهلها إذا استخدمت القواعد المسبقة.

للمسافة الدقيقة، تُقاس القيمة بالنقاط. للمسافة النسبية، تُقاس بنصف السطور: القيمة `3` في المثال تعني 1.5 سطر. اضبط الخصيتين معًا عند تحديد قيمة صريحة؛ تغيير القيمة الرقمية وحدها لا يختار قاعدة مسافة.

المثال أدناه يحفظ خمس عروض تقديمية بنفس المعادلات، المحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيران يظهران قيمًا صريحة.

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

مسافة صفوف المصفوفة منفصلة عن مسافة الفقرة. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) يضيفان مساحة حول الفقرة المحتوية، وليس بين صفوف المصفوفة. بالمثل، [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) يحدد موضع الفقرة الرياضية بالكامل أفقياً؛ لا يستبدل إعداد المحاذاة العمودية للمصفوفة.

## **إضافة الدوال المثلثية**

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

## **إضافة الأسفلية والعلوية**

استخدم المساعدين للكتابة الأسفلية والعلوية للمؤشرات والأسس. عندما يجب أن تظهر المؤشرات على الجانب الأيسر للقاعدة، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![حرف Y كبير مع أسفلية 1 على اليسار وعلوية n](powerpoint-math-equations_9.png)

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

## **إضافة المحددات**

استخدم [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات محددات تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x و y و z مفصولة بأشرطة رأسية](powerpoint-math-equations_13.png)

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

مرّر `true` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) لإتاحة نمو الأقواس حول عنصر طويل، أو مرّر `false` لإبقائها بحجمها الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) مع إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر وسط علامة المساواة. `Match` يسايرها مع المحتوى المشمول. كلا الإعدادين يؤثران فقط على المحددات. التعبير الداخلي يبقى كما هو.

يضع المثال كسرًا في أسـ `x` بحيث يمتد التعبير أعلى خط الأساس أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

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

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتغلق الأس وتبدو متطابقة لكلا الشكلين. في الصف السفلي، النمو مُعطل. الأقواس الصغيرة على اليسار (`Centered`) تُوسّط مع علامة المساواة، بينما الأقواس على اليمين (`Match`) ترتفع أعلى التعبير.

![أربع معادلات في PowerPoint مع تمكين نمو المحددات بالأعلى وتعطيلها بالأدنى، وCentered على اليسار وMatch على اليمين](delimiter-sizing.png)

## **إضافة إطار حد**

استدعِ [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) على كسر لتأطير التعبير كاملًا. الـ[IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) المعاد يُظهر الأربعة جوانب افتراضيًا. استخدم [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-)، [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-)، [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-)، و [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) لإزالة الجوانب الفردية.

يضع المثال ست نسخ من نفس الكسر على شريحة واحدة. لإظهار الإلغاء، أخفِ جميع الجوانب الأربعة ومرّر `true` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) للحصول على خط مائل صاعد (↗) أو [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) لخط مائل هابط (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) أو [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) مع أي تركيبة من الجوانب الظاهرة.

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

![ستة كسور قابلة للتحرير في PowerPoint. الصف العلوي: حد كامل، الجوانب السفلية واليسرى، خط مائل صاعد. الصف السفلي: خط مائل هابط، خط أفقي، خط عمودي مع حد كامل.](border-box-fractions.png)

في هذا الكسر، يتداخل الخط الأفقي مع شريط الكسر. الخط العمودي يمر عبر البسط والمقام بينما يبقى الحد المحيط مرئيًا. هذه الخطوط تُزيّن التعبير كاملًا. يتعامل شطب النص العادي مع الأحرف في مقطع نصي. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تعديل البسط والمقام بشكل مستقل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر شبحية**

لفّ التعبير داخل [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/) للتحكم في رؤيته والمسافة التي يساهم بها في معادلة بشكل مستقل. طرق [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) تتحكم بما يلي:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | مرّر `false` لإخفاء التعبير. أبعاده لا تزال تُساهم في التخطيط ما لم تتلقى الطرق المقابلة أدناه `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | عالج عرض التعبير الأفقي كصفر، مما يسمح للعناصر المجاورة بالاقتراب أكثر. |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | عالج الصعود (الارتفاع فوق خط الأساس) كصفر. يمكن أن يقلل هذا من المسافة المحجوزة فوق العناصر المجاورة. |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | عالج النزول (العمق تحت خط الأساس) كصفر. يمكن أن يحرك شريط الكسر أو أي محتوى أسفل التعبير أقرب إلى جيرانه. |

خط الأساس هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، وتعامل بُعد كصفر لا يزيل التعبير. يبقى التعبير الأساسي متاحًا عبر [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--). مرّر `true` إلى [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) لإظهاره مرة أخرى؛ تبقى إعدادات الأبعاد دون تغيير.

ينشئ المثال أدناه خمسة متغيّرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحتفظ بالمسافة، وثلاثة كسور مخفية مع بُعد واحد معالج كصفر. كل متغيّر يستخدم نفس التعبير المحيط وCambria Math بحجم 24 نقطة. جميع أشكال المعادلة لها نفس الموضع العلوي، مميزًا بالدليل الرمادي. وضع الشبح في بسط كسر خارجي يجعل تغييرات التخطيط العمودي أسهل في الرؤية.

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
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LTGRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![خمسة معادلات في PowerPoint تقارن كسرًا مرئيًا، كسرًا مخفيًا يحتفظ بالمسافة، وكسرًا مخفيًا مع تمكين ZeroWidth أو ZeroAsc أو ZeroDesc](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) لوضع حرف تجميع فوق أو تحت التعبير. أضف حدًا لتسمية المصطلحات المُجمّعة.

![التعبير x زائد y مُجمّع مع التسمية أي نص أسفلها](powerpoint-math-equations_15.png)

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

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) يضع شريطًا فوق عنصر رياضي.

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

لتنسيق النص عبر معادلة موجودة، استعرض شجرة عناصر كل كتلة رياضية. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) تُرجع فقط الأطفال المباشرين، لذا استدعِها بصورة متكررة للوصول إلى النص داخل الكسور، السُكريبتات، الجذور، والهياكل المتداخلة الأخرى. تحقّق من العنصر الحالي وكذلك من أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

يفترض هذا المثال أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، حيث يحتوي كسر على أسفلية في البسط وجذر في المقام. معالجة العناصر العلوية فقط للكتلة سيتخطى النص داخل الكسر. يجد المثال أجزاء الرياضيات في إطارات نص الشرائح، يصل إلى كتلها عبر [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) لتعيين حجم الخط إلى 28 نقطة من خلال طريقة [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) لكل عنصر نص.

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

العرض المحفوظ يحتوي على تنسيق نص محدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص والبنية الرياضية.

## **مرجع سريع**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| Combine elements | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Create fractions | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add superscript or subscript | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add functions | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add radicals | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add limits | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add left-side scripts | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| Add equation arrays | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Group terms | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، تكتب Aspose.Slides المعادلة كمحتوى Office رياضي قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) الخاص بالمعادلة من [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/)، واستدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) لتصديره مباشرة. للحصول على مثال كامل، راجع [Export Math Equations from Presentations in Android via Java](/slides/ar/androidjava/exporting-math-equations/#export-math-equations-to-latex).