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
- افزودن معادله ریاضی
- افزودن نماد ریاضی
- افزودن فرمول ریاضی
- افزودن متن ریاضی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "درج و ویرایش معادلات ریاضی در فایل‌های PowerPoint PPT و PPTX با Aspose.Slides برای Java، با پشتیبانی از OMML، کنترل‌های قالب‌بندی و نمونه‌های کد واضح Java."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides for Java می‌توانید محتویات ریاضی مشابه را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ساخته می‌شود، شکلی است که معادله را دربر می‌گیرد.
- [MathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathblock/) را شامل می‌شود.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathematicaltext/) و متدهای زنجیروار [IMathElement](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/) برای کوتاه و واضح نگه داشتن کد استفاده می‌کنند.

برای سناریوهای صدور MathML، به [Export Math Equations from Presentations in Java](/slides/fa/java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال یک شکل ریاضی ایجاد می‌کند و قضیه فیثاغورث را اضافه می‌نماید:

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
`addMathShape` یک شکل ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین `MathPortion` را دسترسی پیدا کنید، `MathParagraph` آن را بگیرید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از `divide` برای ساخت یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathfractiontypes/) انتخاب کنید.

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

برای یک کسر عمودی، از `MathFractionTypes.Bar` استفاده کنید:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **اضافه کردن رادیکال‌ها**

از `radical` برای ساخت رادیکال درجه دوم، سوم یا دیگر رادیکال‌ها استفاده کنید. عنصر کنونی به عنوان پایه می‌شود و آرگومان به عنوان درجه.

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

## **اضافه کردن توابع و حدود**

از `asArgumentOfFunction` یا `function` برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathlimit/) قرار دهید یا از `setLowerLimit` استفاده کنید.

![حد x هنگامی که x به بینهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

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

برای نام توابع سفارشی، نام تابع را به عنوان عنصر کنونی قرار دهید:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از `nary` برای مجموع‌ها، اجتماع‌ها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. برای انتگرال‌ها از `integral` بهره ببرید. هر دو متد به شما امکان تنظیم حدود پایین و بالا را می‌دهند.

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

عملگرهای N-ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به عنوان `MathematicalText` افزوده شده و در عبارت ترکیب می‌شوند.

برای یک انتگرال، از `integral` استفاده کنید:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین برای افزودن پرانتز، کروشه یا آکل‌نقش آن را درون پرانتز بگیرید.

![یک ماتریکس ریاضی دو ردیفی با یک سلول خالی](powerpoint-math-equations_10.png)

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

## **اضافه کردن آرایه‌های معادله**

از `toMathArray` وقتی به معادلات تراز شده یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

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

## **اضافه کردن توابع مثلثاتی**

از `asArgumentOfFunction` وقتی آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos اعمال‌شده بر 2x](powerpoint-math-equations_6.png)

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

## **اضافه کردن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از `setSubSuperscriptOnTheLeft` استفاده کنید.

![حرف Y بزرگ با زیرنویس سمت چپ 1 و بالانویس n](powerpoint-math-equations_9.png)

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

## **اضافه کردن جداکننده‌ها**

از `enclose` برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید کاراکتر جداکننده را برای عبارات شامل چند عنصر تنظیم کنید.

![یک عبارت جداکننده شامل x، y و z که با خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

## **اضافه کردن جعبه مرزی**

از `toBorderBox` وقتی خود معادله باید در یک قاب قرار گیرد، استفاده کنید.

![یک معادله درون جعبه که a² = b² + c² را نشان می‌دهد](powerpoint-math-equations_12.png)

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

از `group` برای قرار دادن یک علامت گروه‌بندی بالای یا زیر یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده، یک حد اضافه کنید.

![عبارت x + y گروه‌بندی شده با برچسب هر متنی در زیر آن](powerpoint-math-equations_15.png)

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

از ابزارهای قالب‌بندی فقط در جایی استفاده کنید که فرمول را واضح‌تر می‌کند. برای مثال، `overbar` یک خط بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک خط بالایی](powerpoint-math-equations_14.png)

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

## **راهنمای سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| اضافه کردن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-),[setSubscript](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-),[asArgumentOfFunction](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| اضافه کردن رادیکال‌ها | [IMathElement.radical](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| اضافه کردن حدود | [setLowerLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-),[setUpperLimit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| اضافه کردن اسکریپت‌های طرف چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-),[integral](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#toMathArray--) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| اضافه کردن خط‌ها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#overbar--),[toBorderBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#toBorderBox--) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **سوالات متداول**

**آیا می‌توانم یک معادله PowerPoint موجود را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل `MathPortion` است پیدا کنید، `MathParagraph` آن را بگیرید و بلوک‌های ریاضی داخل آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به صورت ریاضی ویرایش‌پذیر PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به قالب PPTX، Aspose.Slides معادله را به عنوان محتوای ریاضی ویرایش‌پذیر Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

Aspose.Slides معادلات ریاضی را به MathML صادر می‌کند. اگر به LaTeX نیاز دارید، ابتدا به MathML صادر کنید و سپس با ابزاری که از دیالکت LaTeX هدف پشتیبانی می‌کند، MathML را به LaTeX تبدیل کنید.