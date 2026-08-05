---
title: اضافه کردن معادلات ریاضی به ارائه‌های PowerPoint در Java
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/java/powerpoint-math-equations/
keywords:
- معادله ریاضی
- نماد ریاضی
- فرمول ریاضی
- متن ریاضی
- اضافه کردن معادله ریاضی
- اضافه کردن نماد ریاضی
- اضافه کردن فرمول ریاضی
- اضافه کردن متن ریاضی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای Java، با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Java."
---
## **نمای کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Java می‌توانید همان نوع محتویات ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **درج > معادله** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه یک متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint که شامل یک معادله ریاضی قابل ویرایش است](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ایجاد می‌شود، شکلی است که معادله را در خود دارد.
- [MathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متنی شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) حاوی یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/) برای کوتاه و قابل خواندن نگه داشتن کد استفاده می‌کند.

برای موارد صادرات MathML، به [Export Math Equations from Presentations in Java](/slides/fa/java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال یک شکل ریاضی ایجاد می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` شکلی را می‌سازد که از پیش شامل یک پاراگراف ریاضی است. به اولین `MathPortion` دسترسی پیدا کنید، `MathParagraph` آن را دریافت کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از `divide` برای ایجاد یک کسر استفاده کنید. می‌توانید با استفاده از [MathFractionTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathfractiontypes/) سبک کسر را انتخاب کنید.

![یک کسر ریاضی کج که یک تقسیم بر x را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر انباشته، از `MathFractionTypes.Bar` استفاده کنید:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **افزودن رادیکال‌ها**

از `radical` برای ایجاد رادیکال درجه دوم، سوم یا سایر رادیکال‌ها استفاده کنید. عنصر جاری به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![یک عبارت رادیکال n-ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

## **افزودن توابع و حدود**

از `asArgumentOfFunction` یا `function` برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathlimit/) بگذارید یا از `setLowerLimit` استفاده کنید.

![حد x وقتی x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را به‌عنوان عنصر جاری قرار دهید:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **افزودن عملگرهای N-ary و انتگرال‌ها**

از `nary` برای جمع‌ها، اتحادیه‌ها، اشتراک‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از `integral` استفاده کنید. هر دو متد به شما امکان تنظیم حدود پایین و بالا را می‌دهند.

![یک جمع با حدود پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`, `-`, و `=` معمولاً به‌عنوان `MathematicalText` اضافه شده و به عبارت پیوست می‌شوند.

برای یک انتگرال، از `integral` استفاده کنید:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. ماتریس‌ها به‌طور پیش‌فرض پرانتز ندارند، بنابراین وقتی به پرانتز، کروشه یا آکولاد نیاز دارید، ماتریس را محاط کنید.

![یک ماتریس ریاضی دو ردیفه با یک سلول خالی](powerpoint-math-equations_10.png)

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

## **افزودن آرایه‌های معادله**

از `toMathArray` وقتی به معادلات هم‌تراز یا پشتهٔ عمودی عبارات نیاز دارید استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

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

## **افزودن توابع مثلثاتی**

از `asArgumentOfFunction` وقتی آرگومان عنصر جاری است و نام تابع شناخته‌شده است، استفاده کنید.

![تابع مثلثاتی cos که بر ۲x اعمال شده است](powerpoint-math-equations_6.png)

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

## **افزودن زیرنویس و بالانویس**

از helperهای زیرنویس و بالانویس برای ایندکس‌ها و توان‌ها استفاده کنید. وقتی ایندکس‌ها باید در سمت چپ پایه ظاهر شوند، از `setSubSuperscriptOnTheLeft` استفاده کنید.

![یک Y بزرگ با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

## **افزودن جداسازها**

از `enclose` برای قرار دادن یک عبارت داخل جداسازها استفاده کنید. می‌توانید کاراکتر جداکننده را برای عبارات جداساز که شامل چندین عنصر هستند تنظیم کنید.

![یک عبارت جداساز شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

## **افزودن جعبه حاشیه‌دار**

از `toBorderBox` وقتی خود معادله باید در یک قاب قرار گیرد استفاده کنید.

![یک معادله درون جعبه که نشان می‌دهد a² = b² + c²](powerpoint-math-equations_12.png)

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

## **گروه‌بندی عبارات**

از `group` برای قرار دادن یک کاراکتر گروه‌بندی بالای یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده، یک حد اضافه کنید.

![عبارتی x به‌علاوه y که با برچسب هر متنی در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

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

## **قالب‌بندی عناصر ریاضی**

از helperهای قالب‌بندی فقط در مواردی استفاده کنید که فرمول را واضح‌تر می‌کنند. برای مثال، `overbar` یک خط بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با خط بالای آن](powerpoint-math-equations_14.png)

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

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| افزودن توابع | [function](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| افزودن رادیکال‌ها | [IMathElement.radical](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| افزودن حدود | [setLowerLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#toMathArray--) |
| افزودن جداسازها | [enclose](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| افزودن خط فوق و حاشیه | [overbar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#toBorderBox--) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **سوالات متداول**

**آیا می‌توانم یک معادله موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک `MathPortion` است پیدا کنید، `MathParagraph` آن را دریافت کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگامی که به PPTX ذخیره می‌کنید، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. `IMathParagraph` معادله را از `IMathPortion` مرتبط دریافت کنید و سپس `IMathParagraph.toLatex` را فراخوانی کنید تا مستقیماً صادر شود. برای یک مثال کامل، به [Export Math Equations from Presentations in Java](/slides/fa/java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.