---
title: معادلات ریاضی را به ارائه‌های PowerPoint در Android اضافه کنید
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/androidjava/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- افزودن معادله ریاضی
- افزودن نماد ریاضی
- افزودن فرمول ریاضی
- افزودن متن ریاضی
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Android وارد و ویرایش کنید، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Java."
---
## **بررسی کلی**

PowerPoint معادلات را به‌صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Android از طریق Java، می‌توانید این نوع محتوای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها، و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متنی قابل ویرایش ریاضی روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را با استفاده از سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ایجاد می‌شود، شکلی است که معادله را دربر می‌گیرد.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) استفاده می‌کنند تا کد کوتاه و خوانا بماند.

[صادر کردن معادلات ریاضی از ارائه‌ها در Android](/slides/fa/androidjava/exporting-math-equations/).

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) برای ایجاد یک شکل ریاضی استفاده می‌کند و نظریهٔ فایتاغورث را اضافه می‌کند:

![معادله c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) شکلی ایجاد می‌کند که در حال حاضر شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید، و بلوک‌های ریاضی یا عناصر ریاضی به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که 1 تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر عمودی، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) برای ایجاد ریشه‌ی مربع، ریشه‌ی مکعب یا سایر ریشه‌ها استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![عبارت رادیکال nام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

## **افزودن توابع و حدود**

از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) یا [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) استفاده کنید.

![حد x وقتی x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری تنظیم کنید و [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) را با آرگومان آن فراخوانی کنید:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **افزودن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده نمایید. هر دو روش امکان تنظیم حدهای پایین و بالا را می‌دهند.

![یک جمع با حدهای پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) اضافه شده و به عبارت پیوست می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌صورت پیش‌فرض ماتریس‌ها شامل پرینت‌های [] نیستند، بنابراین هنگام نیاز به پرانتز، کروشه یا آکولاد، ماتریس را داخل آنها بگذارید.

![یک ماتریس ریاضی دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

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

## **افزودن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) هنگامی که به معادلات تراز شده یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

### **تراز یک آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) تنظیمات تراز عمودی آرایه را نسبت به عناصر ریاضی کناری کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند که هر کدام سه ردیف و عناصر همسایه `A=` و `=B` دارند. تمام متن ریاضی از Cambria Math با سایز ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. موقعیت `A=` و `=B` را در کنار هر آرایه مشاهده کنید.

![آرایه‌های معادله در PowerPoint با تراز بالا، مرکز و پایین و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصله ردیف**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) قاعدهٔ فاصله‌گذاری برای ردیف‌های داخل آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) مقدار عددی برای قاعدهٔ فاصله‌گذاری صریح ارائه می‌دهد و توسط قواعد پیش‌تنظیم‌گذاری نادیده گرفته می‌شود.

برای فاصله‌گذاری دقیق، مقدار بر حسب پوینت است. برای فاصله‌گذاری نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام تعیین مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر تنها مقدار عددی قاعدهٔ فاصله‌گذاری را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه ارائهٔ اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو ارائهٔ آخر مقادیر صریح را نشان می‌دهند.

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

فاصله ردیف آرایه جدا از فاصله پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) فضای اطراف پاراگراف حاوی را اضافه می‌کنند، نه بین ردیف‌های آرایه. به همین ترتیب، [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) پاراگراف کل ریاضی را به صورت افقی موقعیت می‌دهد؛ این تنظیم جایگزین تنظیم تراز عمودی آرایه نمی‌شود.

## **افزودن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) وقتی که آرگومان عنصر جاری است و نام تابع شناخته شده باشد استفاده کنید.

![تابع مثلثاتی cos اعمال شده بر ۲x](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس و بالانویس**

از کمک‌کننده‌های زیرنویس و بالانویس برای شاخص‌ها و توان‌ها استفاده کنید. وقتی که شاخص‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید.

![یک Y بزرگ با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **افزودن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید برای عبارات دارای چند عنصر، یک کاراکتر جداکننده تنظیم نمایید.

![عبارتی جداکننده شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز جداکننده‌ها**

`true` را به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) بدهید تا پرانتزها حول یک عملوند بلند بزرگ شوند، یا `false` بدهید تا اندازهٔ معمولی خود را حفظ کنند. از [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را بر محور ریاضی که از وسط علامت مساوی می‌گذرد، مرکز می‌کند. `Match` آن‌ها را با محتوای داخل هماهنگ می‌سازد. هر دو تنظیم فقط بر جداکننده‌ها تأثیر می‌گذارند. عبارت داخل بدون تغییر می‌ماند.

در این مثال یک کسر در توان `x` قرار داده می‌شود تا عبارت بالاتر از خط پایه بیشتر گسترش یابد تا زیر آن. تمام چهار معادله از یک پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر بزرگ‌شدن را ببینید. در ردیف بالایی، پرانتزها برای دربرگیری توان بزرگ می‌شوند و برای هر دو شکل یکسان به نظر می‌رسند. در ردیف پایینی، بزرگ‌شدن فعال نیست. پرانتزهای کوچک‌تر در سمت چپ (`Centered`) با علامت مساوی تراز می‌شوند، در حالی که در سمت راست (`Match`) بالاتر در اطراف عبارت قرار دارند.

![چهار معادله در PowerPoint با فعال بودن رشد جداکننده در بالا و غیرفعال بودن در پایین، و Centered در سمت چپ و Match در سمت راست](delimiter-sizing.png)

## **افزودن جعبه حاشیه**

روی یک کسر [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) را فراخوانی کنید تا تمام عبارت در یک جعبه قاب‌بندی شود. [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) بازگردانده‌شده به‌صورت پیش‌فرض چهار طرف را نشان می‌دهد. برای حذف طرف‌های جداگانه از [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-)، [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-)، [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-) و [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) استفاده کنید.

مثال شش کپی از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن حذف، تمام چهار طرف را پنهان کنید و `true` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) برای یک قطر صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) برای یک قطر نزولی (↘) بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) یا [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالایی: حاشیه کامل، طرف‌های پایین و چپ، قطر صعودی. ردیف پایینی: قطر نزولی، خط افقی، خط عمودی با حاشیه کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر می‌چسبد. خط عمودی هم شمارنده و هم مخرج را می‌قطع می‌کند در حالی که حاشیه اطراف قابل مشاهده می‌ماند. این خطوط کل عبارت را تزئین می‌کنند. خط‌خوردهٔ متن عادی بر روی حروف یک اجرا اعمال می‌شود. پس از بازگشایی مجدد ارائه در PowerPoint، می‌توانید همچنان شمارنده و مخرج را به‌صورت جداگانه ویرایش کنید.

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده یک حد اضافه کنید.

![عبارت x به‌علاوه y که با برچسب متن دلخواه در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

## **قالب‌بندی عناصر ریاضی**

از کمکی‌های قالب‌بندی فقط در جایی استفاده کنید که فرمول را روشن می‌کنند. برای مثال، [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) یک خط بالای یک عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با خط بالای آن](powerpoint-math-equations_14.png)

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

### **قالب‌بندی متن در یک معادله موجود**

برای قالب‌بندی متن در تمام یک معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، زیرنویس‌ها، رادیکال‌ها و سایر ساختارهای تو درتو آن را به‌صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا عنصر شروع را زمانی که [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) باشد، شامل شود.

این مثال فرض می‌کند که `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است، که یک کسر با زیرنویس در شمارنده و رادیکال در مخرج دارد. پردازش فقط عناصر سطح بالای بلوک متن را از دست می‌دهد. مثال بخش‌های ریاضی را در فریم‌های متن اسلاید پیدا می‌کند، بلوک‌های آن‌ها را از طریق [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) دسترسی می‌دهد و از [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) برای تنظیم اندازه قلم به ۲۸ پوینت از طریق متد [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) هر عنصر متن استفاده می‌کند.

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

ارائهٔ ذخیره‌شده شامل قالب‌بندی متن به‌روز شده در هر سطح از هر معادله پردازش‌شده است، در حالی که محتوای متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن توابع | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن رادیکال‌ها | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن حدود | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن خط‌ها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **پرسش‌های متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکل حاوی یک [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) را پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش در PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادرات کنم؟**

بله. [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) معادله را از [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) دریافت کنید و [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) را برای صادرات مستقیم فراخوانی کنید. برای مثال کامل، به [Export Math Equations from Presentations in Android via Java](/slides/fa/androidjava/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.