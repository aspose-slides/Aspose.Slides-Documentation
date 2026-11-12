---
title: اضافه‌کردن معادلات ریاضی به ارائه‌های PowerPoint در Android
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/androidjava/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- اضافه‌کردن معادله ریاضی
- اضافه‌کردن نماد ریاضی
- اضافه‌کردن فرمول ریاضی
- اضافه‌کردن متن ریاضی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Android وارد و ویرایش کنید؛ پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های کد Java واضح."
---
## **مرور کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Android از طریق Java می‌توانید همان نوع محتوای ریاضی را به‌صورت برنامه‌نویسی‌ ای ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N‑ary، ماتریکس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) و متدهای fluent از [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations on Android](/slides/fa/androidjava/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) برای ایجاد یک شکل ریاضی استفاده می‌کند و تئوری فیثاغورث را اضافه می‌کند:

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) شکلی را می‌سازد که از پیش یک پاراگراف ریاضی دارد. اولین [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی مورب نشان‌دهنده یک تقسیم بر x](powerpoint-math-equations_4.png)

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

برای یک کسر چیده‌شده، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) برای ایجاد ریشهٔ مربعی، مکعبی یا سایر ریشه‌ها استفاده کنید. عنصر فعلی به پایه تبدیل می‌شود و آرگومان به درجه ریشه.

![یک عبارت رادیکال n‑ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

## **اضافه کردن توابع و حدها**

برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های تابع سفارشی از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) یا [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) بگذارید یا از [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) استفاده کنید.

![حد x زمانی که x به بینهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را عنصر فعلی کنید و [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) را با آرگومان‌اش فراخوانی کنید:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید. هر دو متد اجازه می‌دهند حدهای پایین و بالا تنظیم شوند.

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`, `-`, `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت پیوست می‌گردند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریکس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به طور پیش‌فرض ماتریکس‌ها براکت ندارند، بنابراین وقتی نیاز به پرانتز، براکت یا آکولاد دارید، ماتریکس را درون آن‌ها بگذارید.

![یک ماتریکس دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

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

## **اضافه کردن آرایه‌های معادله**

وقتی به معادلات تراز شده یا یک پشتهٔ عمودی از عبارات نیاز دارید، از [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) استفاده کنید.

![یک آرایهٔ ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

## **اضافه کردن توابع مثلثاتی**

زمانی که آرگومان عنصر فعلی است و نام تابع شناخته‌شده، از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) استفاده کنید.

![تابع مثلثاتی cos اعمال‌شده بر 2x](powerpoint-math-equations_6.png)

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

## **اضافه کردن زیرنویس و بالانویس**

از کمکی‌های زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید.

![یک Y بزرگ با زیرنویس ۱ سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **اضافه کردن delimiters**

از [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) برای قرار دادن یک عبارت داخل delimiters استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات delimiters که شامل چند عنصر هستند، تنظیم کنید.

![یک عبارت delimiter شامل x, y و z که توسط خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

### **اندازه و تراز delimiters**

به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) مقدار `true` بدهید تا پرانتزها برای عملوند بلندتر بزرگ شوند، یا `false` بدهید تا اندازهٔ عادی خود بمانند. با [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) و یکی از مقادیر [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) تنظیم کنید. `Centered` پرانتزها را در محور ریاضی مرکز می‌کند، که از وسط علامت مساوی عبور می‌کند. `Match` آنها را با محتوای داخل هم‌تراز می‌کند. هر دو تنظیم تنها بر روی delimiters اثر می‌گذارند؛ عبارت داخل همچنان یکسان می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بیشتر از خط پایه بالا برود تا زیر آن. چهار معادله همگی از یک پرانتز و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را برای مشاهدهٔ اثر رشد مقایسه کنید. در ردیف بالا، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یکسان به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر سمت چپ (`Centered`) با علامت مساوی هم‌تراز می‌شوند، در حالی که آن سمت راست (`Match`) بالاتر اطراف عبارت قرار می‌گیرد.

![چهار معادله در PowerPoint با رشد delimiter فعال در بالا و غیرفعال در پایین، و Centered در چپ و Match در راست](delimiter-sizing.png)

## **اضافه کردن یک Border Box**

برای یک کسر، [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) را فراخوانی کنید تا کل عبارت داخل یک کادر قرار گیرد. [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) بازگردانده‌شده به‌طور پیش‌فرض چهار طرف را نشان می‌دهد. با [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), و [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) می‌توانید طرف‌های جداگانه را حذف کنید.

مثال شش نسخه از همان کسر را روی یک اسلاید قرار می‌دهد. برای نمایش حذف، چهار طرف را مخفی کنید و برای یک خط مورب صعودی (↗) مقدار `true` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) یا برای یک خط مورب نزولی (↘) به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) یا [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) به همراه ترکیبی از طرف‌های قابل‌نمایش استفاده کنید.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: مرز کامل، سمت پایین و چپ، خط مورب صعودی. ردیف پایین: خط مورب نزولی، خط افقی، خط عمودی با مرز کامل.](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر هم‌پوشانی دارد. خط عمودی هر دو صورت و مخرج را می‌پوشاند در حالی که مرز اطراف همچنان قابل مشاهده است. این خطوط کل عبارت را تزئین می‌کنند. Strikethrough معمولی فقط بر روی کاراکترهای یک بخش متن اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی شده می‌توانید یک حد اضافه کنید.

![عبارتی به شکل x + y که با برچسب any text زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

از کمکی‌های قالب‌بندی فقط در جایی استفاده کنید که فرمول را واضح‌تر می‌کند. برای مثال، [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) یک خط بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در سرتاسر یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) فقط بچه‌های مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و ساختارهای تو در تو دیگر، این متد را به‌صورت بازگشتی فراخوانی کنید. عنصر فعلی و همچنین بچه‌های آن را بررسی کنید تا زمانی که عنصر [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) باشد، شامل عنصر شروع شود.

این مثال فرض می‌کند `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است که یک کسر با زیرنویس در صورت و رادیکال در مخرج دارد. پردازش تنها عناصر سطح‑بالایی بلوک‌ها متن داخل کسر را از دست می‌دهد. مثال، بخش‌های ریاضی موجود در فریم‌های متن اسلاید را پیدا می‌کند، بلوک‌هایشان را از طریق [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) دسترسی می‌یابد و با [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) اندازهٔ قلم را به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) تنظیم می‌کند.

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

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شدهٔ به‌روزشده را در هر سطح از هر معادله پردازش‌شده شامل می‌شود، در حالی که محتوای متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن توابع | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن رادیکال‌ها | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن حدها | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن ماتریکس‌ها | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن delimiters | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن خطوط و حواشی | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **سؤالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی را که شامل یک [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به عنوان ریاضی قابل ویرایش در PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به قالب PPTX، Aspose.Slides معادله را به‌عنوان محتوای Office Math قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادرات کنم؟**

بله. [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) معادله را از [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) دریافت کنید و با فراخوانی [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) مستقیماً صادر کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Android via Java](/slides/fa/androidjava/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.