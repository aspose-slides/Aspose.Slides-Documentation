---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در Android
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
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Android وارد و ویرایش کنید؛ با پشتیبانی از OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد Java."
---
## **نمای کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Android از طریق Java، می‌توانید همان نوع محتواهای ریاضی را به‌صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی‌شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش روی اسلاید است:

![یک اسلاید PowerPoint حاوی یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شیء اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ایجاد می‌شود، شکل حاوی معادله است.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) محتوای ریاضی را داخل فریم متنی شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) است.

اکثریت مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) و متدهای زنجیره‌ای [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) استفاده می‌کند تا کد کوتاه و خوانا بماند.

برای سناریوهای خروجی MathML، به [صادرات معادلات ریاضی از ارائه‌ها در Android](/slides/fa/androidjava/exporting-math-equations/) مراجعه کنید.

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیه فیثاغورث را اضافه می‌کند:

![معادله c به توان دو برابر a به توان دو به اضافه b به توان دو](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) شکلی ایجاد می‌کند که از قبل شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **افزودن کسرها**

از [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) برای ایجاد یک کسر استفاده کنید. می‌توانید یک سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی تک‌جانبه که یک بر x تقسیم شده را نشان می‌دهد](powerpoint-math-equations_4.png)

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

برای یک کسر ستاک (سطحی)، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **افزودن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) برای ایجاد ریشهٔ مربع، ریشهٔ مکعب یا ریشه‌های دیگر استفاده کنید. عنصر فعلی به پایه تبدیل می‌شود و آرگومان به درجه.

![یک عبارت رادیکال n-ام با x زیر علامت رادیکال](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی‌سازی درجهٔ ریشهٔ مربع**

یک ریشهٔ مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نوشتار معمولی √x استفاده کند. متد [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) از [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/) تعیین می‌کند کدام شکل ظاهر می‌شود. هر دو شکل درجهٔ ۲ و رادیکال x را در معادلهٔ قابل ویرایش حفظ می‌کنند.

![یک ریشهٔ مربع یکسان که در سمت چپ درجهٔ قابل مشاهده و در سمت راست مخفی است](square-root-degree.png)

این مثال ریشهٔ مربع یکسان را دو بار ذخیره می‌کند. در `visible-degree.pptx`، عدد ۲ قابل مشاهده است. در `hidden-degree.pptx`، مخفی است.

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

## **افزودن توابع و حدها**

از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) یا [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) برای توابعی مانند `sin(x)`، `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) استفاده کنید.

![حد x هنگامی که x به بی‌نهایت نزدیک می‌شود](powerpoint-math-equations_8.png)

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

برای نام تابع سفارشی، نام تابع را عنصر فعلی کنید و [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) را با آرگومان آن فراخوانی کنید:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **افزودن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای جمع‌ها، اتحادها، تقاطع‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای انتگرال‌ها استفاده کنید. هر دو متد به شما امکان تنظیم حدود پایین و بالا را می‌دهند.

![یک جمع با حدود پایین و بالا](powerpoint-math-equations_7.png)

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

عملگرهای N-ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) افزوده می‌شوند و به عبارت ترکیب می‌گردند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **افزودن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین وقتی به پرانتز، کروشه یا آکولاد نیاز دارید، ماتریس را محصور کنید.

![یک ماتریس ریاضی دو سطری با یک سلول خالی](powerpoint-math-equations_10.png)

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

### **ویرایش یک ماتریس موجود**

فرض کنید یک درس جبر خطی با ماتریس ضرایب در `matrix.pptx` که توسط مثال قبلی ذخیره شده، شروع می‌شود. برای تمرین بعدی، معادلهٔ اول را حفظ کنید، دومین معادله را با دو معادله جدید جایگزین کنید و مجموعهٔ متغیرها را بازنگری کنید. با استفاده از [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) ماتریس موجود را باز کنید تا ضرایفی که هنوز معتبرند حفظ شوند.

![ماتریس ضرایب دو سطری اصلی با مقادیر 1، x و یک سلول خالی در سطر اول و x، 2، و y در سطر دوم](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج یک ردیف قبل از اندیس ۱، ردیف دوم اصلی را به اندیس ۲ منتقل می‌کند. درج پس از اندیس ۲ سپس یک ردیف اضافه می‌کند. حذف ردیف ۲، معادلهٔ دوم اصلی را حذف کرده و ردیف افزوده‌شده را یک موقعیت بالا می‌برد. ستون‌ها به همین ترتیب جابه‌جا می‌شوند.

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

    // سلول‌های جدید در ابتدا null هستند. ابتدا ضرایب غیر صفر را تنظیم کنید.
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

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) اولین ستون را به سمت چپ ترازبندی می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) سه ستون متوالی را از اندیس ۱ به سمت راست ترازبندی می‌کند. در `updated-matrix.pptx`، ماتریس شامل سه معادله و چهار متغیر است. ضرایب سطر اول اولیه `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه سطری به‌روز شده که سطرهای 1، 0، x، 0؛ 12، 1، 0، 0؛ و 0، 0، 10، 1 را نشان می‌دهد](matrix-after-edit.png)

## **افزودن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) زمانی که به معادلات هم‌تراز یا یک پشتهٔ عمودی از عبارات نیاز دارید، استفاده کنید.

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

### **تراز یک آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) ترازبندی عمودی یک آرایه را نسبت به عناصر ریاضی کناری کنترل می‌کند. مثال زیر ترازبندی را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند که هر کدام سه ردیف و عناصر همسایه `A=` و `=B` دارند. تمام متن‌های ریاضی از Cambria Math با اندازه ۲۴ پوینت استفاده می‌کنند. تنها ترازبندی آرایه تغییر می‌کند.

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

مقایسهٔ زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` در کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با ترازبندی بالا، مرکز و پایین و عناصر همسایه یکسان](equation-array-alignment.png)

### **پیکربندی فاصله ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) قاعده فاصله‌گذاری برای ردیف‌های داخل آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) مقدار عددی برای قاعده فاصله‌گذاری صریح فراهم می‌کند و توسط قواعد پیش‌تنظیم نادیده گرفته می‌شود.

برای فاصله‌گذاری دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصله‌گذاری نسبی، بر حسب نصف خط‌ها اندازه‌گیری می‌شود: مقدار `3` در مثال برابر ۱٫۵ خط است. هنگام مشخص کردن مقدار صریح هر دو خاصیت را تنظیم کنید؛ تغییر تنها مقدار عددی قاعده فاصله‌گذاری را انتخاب نمی‌کند.

مثال زیر پنج ارائه با همان معادلات، ترازبندی و تنظیمات قلم ذخیره می‌کند. سه ارائه اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو ارائه آخر مقادیر صریح را نشان می‌دهند.

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

فاصله‌گذاری ردیف‌های آرایه جدا از فاصله‌گذاری پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) فضای اطراف پاراگراف حاوی را اضافه می‌کند، نه بین ردیف‌های آرایه. به همین ترتیب، [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیم عمودی آرایه را جایگزین نمی‌کند.

## **افزودن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) زمانی که آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos اعمال شده بر 2x](powerpoint-math-equations_6.png)

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

از کمکی‌های زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید.

![حرف بزرگ Y با زیرنویس ۱ در سمت چپ و بالانویس n](powerpoint-math-equations_9.png)

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

از [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات حاوی چند عنصر نیز تنظیم کنید.

![یک عبارت جداکننده حاوی x، y و z که توسط خطوط عمودی جدا شده‌اند](powerpoint-math-equations_13.png)

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

Pass `true` to [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) to let the parentheses grow around a tall operand, or pass `false` to keep them at their normal size. Use [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) with one of two [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) values. `Centered` centers the parentheses on the math axis, which runs through the middle of the equals sign. `Match` aligns them with the enclosed content. Both settings affect only the delimiters. The expression inside stays the same.

The example places a fraction in the exponent of `x` so the expression extends farther above the baseline than below it. All four equations use the same parentheses and font settings.

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

In PowerPoint, compare the rows to see the effect of growth. In the top row, the parentheses grow to enclose the exponent and look alike for both shapes. In the bottom row, growth is off. The smaller parentheses on the left (`Centered`) align with the equals sign, while those on the right (`Match`) sit higher around the expression.

![چهار معادله در PowerPoint با فعال‌سازی رشد جداکننده در بالا و غیرفعال در پایین، و Centered در سمت چپ و Match در سمت راست](delimiter-sizing.png)

## **افزودن جعبهٔ حاشیه**

Call [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) on a fraction to frame the entire expression. The returned [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) shows all four sides by default. Use [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), and [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) to remove individual sides.

The example places six copies of the same fraction on one slide. To show cancellation, hide all four sides and pass `true` to [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) for a rising diagonal (↗) or [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) for a falling diagonal (↘). You can also use [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) or [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) with any combination of visible sides.

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

![شش کسر قابل ویرایش در PowerPoint. ردیف بالایی: حاشیه کامل، سمت پایین و چپ، مورب صعودی. ردیف پایینی: مورب نزولی، خط افقی، خط عمودی با حاشیه کامل](border-box-fractions.png)

On this fraction, the horizontal strike overlaps the fraction bar. The vertical strike crosses both the numerator and the denominator while the surrounding border stays visible. These lines decorate the whole expression. Ordinary text strikethrough applies to characters in a text run. After reopening the presentation in PowerPoint, you can still edit the numerator and denominator independently.

## **کنترل قابلیت مشاهده و چیدمان با عناصر شبحی**

Wrap an expression in [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/) to control its visibility and the space it contributes to an equation independently. The [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) methods control the following:

| روش | تأثیر |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | با مقدار `false` عبارت را مخفی می‌کند. ابعاد آن همچنان در چیدمان مؤثر است مگر اینکه متدهای زیر مقدار `true` دریافت کنند. |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | عرض افقی عبارت را صفر در نظر می‌گیرد، امکان نزدیک شدن عناصر همسایه را می‌دهد. |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | ارتفاع بالای خط پایه ( ascent ) را صفر در نظر می‌گیرد. این می‌تواند فضای محفوظ بالا در عناصر همسایه را کاهش دهد. |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | عمق زیر خط پایه ( descent ) را صفر در نظر می‌گیرد. این می‌تواند خط کسر یا محتوای زیر عبارت را به همسایه‌ها نزدیک‌تر کند. |

The baseline is the reference line on which ordinary mathematical letters sit. Hiding content does not remove its dimensions, and treating a dimension as zero does not delete the expression. The underlying expression remains available through [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--). Pass `true` to [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) to display it again; the dimension settings remain unchanged.

The example below creates five side-by-side variants: a visible fraction, a hidden fraction that reserves space, and three hidden fractions with one dimension treated as zero. Each variant uses the same surrounding expression and Cambria Math at 24 points. All equation shapes have the same top position, marked by the gray guide. Placing the phantom in the numerator of an outer fraction makes the vertical layout changes easier to see.

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

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضای خود را حفظ می‌کند و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کند](math-phantom.png)

## **گروه‌بندی عبارات**

Use [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) to place a grouping character above or below an expression. Add a limit to label the grouped terms.

![عبارت x به‌علاوه y گروه‌بندی شده با برچسب هر متن زیر آن](powerpoint-math-equations_15.png)

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

Use formatting helpers only where they clarify the formula. For example, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) places a bar above a math element.

![یک عبارت ریاضی ABC با نوار بالایی](powerpoint-math-equations_14.png)

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

To format text throughout an existing equation, traverse each math block's element tree. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) returns only the immediate children, so call it recursively to reach text inside fractions, scripts, radicals, and other nested structures. Check the current element as well as its children to include the starting element when it is [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

This example assumes that `input.pptx` contains an equation such as `z = xᵢ / ∛y`, with a fraction containing a subscript in its numerator and a radical in its denominator. Processing only the block's top-level elements would miss the text inside the fraction. The example finds mathematical portions in slide text frames, accesses their blocks through [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), and uses [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) to set the font size to 28 points through each text element's [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) method.

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

The saved presentation contains the updated text formatting at every level of each processed equation, while preserving its text content and mathematical structure.

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
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| افزودن میله‌ها و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **پرسش‌های متداول**

**آیا می‌توانم یک معادله موجود PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روز کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌صورت محتویات ریاضی قابل ویرایش Office می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. معادلهٔ خود را از [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) به [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) بدست آورید و [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) را برای صادرات مستقیم فراخوانی کنید. برای یک مثال کامل، به [صادرات معادلات ریاضی از ارائه‌ها در Android از طریق Java](/slides/fa/androidjava/exporting-math-equations/#export-math-equations-to-latex) نگاه کنید.