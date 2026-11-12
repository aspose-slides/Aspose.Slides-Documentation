---
title: اضافه کردن معادلات ریاضی به ارائه‌های PowerPoint در JavaScript
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/nodejs-java/powerpoint-math-equations/
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "در PowerPoint فرمت‌های PPT و PPTX معادلات ریاضی را با Aspose.Slides برای Node.js از طریق Java وارد و ویرایش کنید؛ از پشتیبانی OMML، کنترل‌های قالب‌بندی و نمونه‌های واضح کد JavaScript بهره‌مند شوید."
---
## **نمای کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Node.js از طریق Java می‌توانید همان نوع محتویات ریاضی را به‌صورت برنامه‌نویسی تولید کنید: کسرها، رادیکال‌ها، توابع، حدود، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را شامل می‌شود.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) و متدهای زنجیره‌ای [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) برای کوتاه و خوانا نگه داشتن کد استفاده می‌کنند.

برای سناریوهای خروجی MathML، به [Export Math Equations from Presentations in Node.js via Java](/slides/fa/nodejs-java/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c² = a² + b²](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) یک شکل ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) را دسترسی کنید، [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که یک را بر x تقسیم می‌کند](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

برای یک کسر پشته‌ای، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) برای ایجاد رادیکال درجه دوم، درجه سوم یا سایر رادیکال‌ها استفاده کنید. عنصر جاری به عنوان پایه می‌شود و آرگومان به عنوان درجه.

![یک عبارت رادیکال n‑ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **اضافه کردن توابع و حدود**

از [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های تابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![حد `x` وقتی `x` به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

برای نام تابع سفارشی، نام تابع را عنصر جاری کنید و [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) را با آرگومان آن فراخوانی کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **اضافه کردن عملگرهای N‑ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) برای انتگرال‌ها استفاده کنید. هر دو متد اجازه می‌دهند حد پایین و بالا تنظیم شوند.

![یک جمع با حدهای پایین و بالا](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدهای اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌عنوان [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت متصل می‌گردند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. ماتریس‌ها به‌صورت پیش‌فرض براکت ندارند، بنابراین هنگام نیاز به پرانتز، براکت یا آکلون، ماتریس را داخل آن بپوشانید.

![یک ماتریس ریاضی دو ردیفی با یک خانه خالی](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **اضافه کردن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) وقتی به معادلات هم‌تراز یا یک پشته عمودی از عبارات نیاز دارید، استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **اضافه کردن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) وقتی آرگومان عنصر جاری است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos اعمال شده بر 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **اضافه کردن زیرنویس و بالانویس**

از ابزارهای زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![یک Y بزرگ با زیرنویس چپ‌ side 1 و بالانویس n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **اضافه کردن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات شامل چند عنصر تنظیم کنید.

![یک عبارت جداکننده حاوی x، y و z که توسط خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **اندازه و هم‌راستایی محدوده‌ها**

`true` را به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) پاس دهید تا پرانتزها برای یک عملوند بلند بزرگ شوند، یا `false` را پاس دهید تا اندازهٔ عادی خود را حفظ کنند. از [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) همراه با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را در محور ریاضی که از وسط علامت مساوی می‌گذرد، مرکز می‌کند. `Match` آن‌ها را با محتوای داخل همسو می‌کند. هر دو تنظیم فقط بر روی جداکننده‌ها اثر دارد. عبارت داخل همانند قبلی می‌ماند.

این مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به پایین گسترش یابد. هر چهار معادله از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در PowerPoint، ردیف‌ها را مقایسه کنید تا اثر رشد را ببینید. در ردیف بالا، پرانتزها برای محصور کردن توان رشد می‌کنند و برای هر دو شکل یک‌سان به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر سمت چپ (`Centered`) با علامت مساوی همسو می‌شوند، در حالی که آن‌های سمت راست (`Match`) بالاتر از عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با فعال بودن رشد جداکننده در بالا و غیرفعال بودن در پایین، و `Centered` در سمت چپ و `Match` در سمت راست](delimiter-sizing.png)

## **اضافه کردن جعبهٔ حاشیه‌ای**

بر روی یک کسر [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) را فراخوانی کنید تا کل عبارت قاب‌بندی شود. [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) بازگردانده‌شده به‌صورت پیش‌فرض چهار طرف را نشان می‌دهد. از [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش نسخه از همان کسر را روی یک اسلاید قرار می‌دهد. برای نشان دادن لغو، تمام چهار طرف را مخفی کنید و `true` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) بدهید تا یک قطار مورب صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) برای یک قطار مورب نزولی (↘) اعمال شود. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) به همراه ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: حاشیه کامل، طرف‌های پایین و چپ، قطار صعودی. ردیف پایین: قطار نزولی، خط افقی، خط عمودی با حاشیه کامل.](border-box-fractions.png)

در این کسر، خط افقی بر روی نوار کسر می‌چسبد. خط عمودی هر دو صورت و مخرج را می‌گذرد در حالی که حاشیهٔ اطراف قابل مشاهده می‌ماند. این خطوط تمام عبارت را تزئین می‌کنند. خط‌خوردگی معمول متن فقط بر روی کاراکترهای یک بازهٔ متنی اعمال می‌شود. پس از بازگشایی ارائه در PowerPoint، می‌توانید همچنان صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده، یک حد اضافه کنید.

![عبارت x + y که با برچسب any text زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **قالب‌بندی عناصر ریاضی**

از ابزارهای قالب‌بندی فقط در جایی که فرمول را روشن می‌کند استفاده کنید. به عنوان مثال، [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) یک خط بالای یک عنصر ریاضی قرار می‌دهد.

![یک عبارت ریاضی ABC با یک خط بالایی](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **قالب‌بندی متن در یک معادلهٔ موجود**

برای قالب‌بندی متن در سراسر یک معادلهٔ موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) تنها فرزندان مستقیم را برمی‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر سازه‌های تو در تو، به‌صورت بازگشتی فراخوانی کنید. عنصر جاری و فرزندان آن را بررسی کنید تا شامل عنصر شروع زمانی باشد که آن [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) است.

این مثال فرض می‌کند `input.pptx` حاوی معادله‌ای مانند `z = xᵢ / ∛y` باشد، با کسر حاوی زیرنویس در صورت و رادیکال در مخرج. پردازش فقط عناصر سطح‑بالای بلوک‌ها متن داخل کسر را از دست می‌دهد. مثال بخش‌های ریاضی موجود در فریم‌های متن اسلایدها را پیدا می‌کند، بلوک‌هایشان را از طریق [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌یابد و با استفاده از [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) اندازهٔ قلم را به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) تنظیم می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارائهٔ ذخیره‌شده حاوی قالب‌بندی متن به‌روز شده در هر سطح از هر معادلهٔ پردازش‌شده است، در حالی که محتویات متنی و ساختار ریاضی آن را حفظ می‌کند.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| ایجاد کسرها | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن بالا نویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن حدود | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| اضافه کردن خط بالا و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتویات ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) معادله را از [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) دریافت کنید و [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) را برای صادرات مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Node.js via Java](/slides/fa/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.