---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در جاوا
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
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای Java وارد و ویرایش کنید؛ پشتیبانی از OMML، کنترل‌های قالب‌بندی و نمونه‌های واضح کد Java."
---
## **بررسی کلی**

PowerPoint معادلات را به صورت Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای Java، می‌توانید همان نوع محتوای ریاضی را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدود، عوامل N‑ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌دهی شده.

In PowerPoint, users normally add equations from **Insert > Equation**:

![zbane Insert dar PowerPoint ba farman Equation entekhab shode](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![yek slide PowerPoint shamel yek ma&#7729;ale riyazi qabele virayesh](powerpoint-math-equations_2.png)

Aspose.Slides متن ریاضی را از طریق سه شی اصلی می‌سازد:

- یک شکل ریاضی، که با [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ایجاد می‌شود، شکلی است که معادله را شامل می‌شود.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) محتوای ریاضی را داخل چارچوب متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) است.

بیشتر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) و روش‌های fluent از [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) استفاده می‌کنند تا کد کوتاه و قابل خواندن باشد.

For MathML export scenarios, see [Export Math Equations from Presentations in Java](/slides/fa/java/exporting-math-equations/).

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) برای ایجاد یک شکل ریاضی استفاده می‌کند و قضیهٔ فیثاغورث را اضافه می‌کند:

![ma&#7729;ale c^2 = a^2 + b^2](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) یک شکلی ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) را دسترسی پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌ها یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

### **ترکیب بلوک‌های ریاضی**

When بخش‌های یک معادله به طور مستقل به عنوان اشیاء [IMathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/) ساخته می‌شوند، از [joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) برای ترکیب آن‌ها استفاده کنید. این مثال `c² =` را در بلوک چپ و `a² + b²` را در بلوک راست می‌سازد. [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) سوپراسکریپت‌های ریاضی قابل ویرایشی برای هر سه توان ایجاد می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathParagraph mathParagraph = mathPortion.getMathParagraph();

    MathBlock leftBlock = new MathBlock();
    leftBlock.add(new MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new MathematicalText("="));

    MathBlock rightBlock = new MathBlock();
    rightBlock.add(new MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new MathematicalText("+"));
    rightBlock.add(new MathematicalText("b").setSuperscript("2"));

    IMathBlock combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) مقدار `leftBlock` را برمی‌گرداند، که اکنون هر دو بخش را به ترتیب شامل می‌شود و `rightBlock` را خالی می‌گذارد. بلوک ترکیب‌شده را فقط یک بار به [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) اضافه کنید. پس از بازکردن دوبارهٔ `equation.pptx`، پاراگراف شامل یک بلوک است که `c² = a² + b²` را نمایش می‌دهد، با حفظ سه توان به عنوان سوپراسکریپت‌های ریاضی.

فراخوانی [add](https://reference.aspose.com/slides/java/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) به صورت `leftBlock.add(rightBlock)` به‌جای آن سعی می‌کند یک بلوک را مستقیماً داخل بلوک دیگر تو در تو کند و `InvalidOperationException` را صادر می‌کند.

## **اضافه کردن کسرها**

Use [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) برای ایجاد یک کسر. می‌توانید سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) انتخاب کنید.

![yek kasr riyazi ke yek be x taghsim shode ra neshan midahad](powerpoint-math-equations_4.png)

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

برای یک کسر لایه‌ای، از [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **اضافه کردن رادیکال‌ها**

Use [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) برای ایجاد رادیکال مربع، رادیکال مکعب یا رادیکال دیگری استفاده کنید. عنصر فعلی به پایه تبدیل می‌شود و آرگومان به درجه تبدیل می‌شود.

![yeki ebarat radikal n-am ba x zir alamaate radikal](powerpoint-math-equations_5.png)

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

### **نمایش یا مخفی کردن درجهٔ رادیکال مربع**

یک رادیکال مربع می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد متعارف √x استفاده کند. روش [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) از [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) تعیین می‌کند که کدام فرم ظاهر شود. هر دو فرم درجه ۲ و رادیکاند x را در معادلهٔ قابل ویرایش حفظ می‌کنند.

![haman radikal ba daraje namayandeye dar chape chape va muparwa sqrt dar chape rast](square-root-degree.png)

این مثال همان رادیکال مربع را دو بار ذخیره می‌کند. در `visible-degree.pptx`، عدد ۲ نمایان است. در `hidden-degree.pptx`، مخفی است.

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

## **اضافه کردن توابع و حدود**

از [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) یا [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) برای توابعی مانند `sin(x)`, `log(x)` یا نام‌های توابع سفارشی استفاده کنید. برای حدود، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) استفاده کنید.

![had x zaman ke x be bi nاحیت beresad](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

برای نام تابع سفارشی، نام تابع را به عنوان عنصر فعلی قرار دهید و با آرگومان آن [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) را فراخوانی کنید:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای جمع‌ها، اتحادیه‌ها، اشتراک‌ها و دیگر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) برای انتگرال‌ها استفاده کنید. هر دو روش به شما اجازه می‌دهند حدود پایین و بالا را تنظیم کنید.

![yek jam ba hadood payin va bala](powerpoint-math-equations_7.png)

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

عملگرهای N‑ary برای عملگرهای بزرگ با حدود اختیاری هستند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به صورت [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) اضافه شده و به عبارت ترکیب می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به طور پیش‌فرض ماتریس‌ها شامل پرانتز نیستند، بنابراین زمانی که به پرانتز، کروشه یا آکولاد نیاز دارید، ماتریس را بپیچید.

![yek matrix riyazi do radifi ba yek selole khali](powerpoint-math-equations_10.png)

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

فرض کنید یک درس جبر خطی با ماتریس ضرایب در `matrix.pptx` که توسط مثال قبلی ذخیره شده، شروع می‌شود. برای تمرین بعدی، معادلهٔ اول را نگه دارید، معادلهٔ دوم را با دو معادله جدید جایگزین کنید و مجموعهٔ متغیرها را بازنگری کنید. برای حفظ ضرایقی که هنوز معتبر هستند، ماتریس موجود را از طریق [IMathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/) باز کنید.

![matrix aslie do radif ba varedat 1, x va yek selole khali dar radife aval va x, 2 va y dar radife dovom](matrix-before-edit.png)

اندیس‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج یک ردیف قبل از اندیس ۱، ردیف دوم اصلی را به اندیس ۲ منتقل می‌کند. درج پس از اندیس ۲ سپس یک ردیف اضافه می‌کند. حذف ردیف ۲ معادلهٔ دوم اصلی را حذف کرده و ردیف اضافه‌شده را یک موقعیت به بالا می‌برد. ستون‌ها به همان روش جابه‌جا می‌شوند.

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

    // سلول‌های جدید ابتدا null هستند. ابتدا ضرایب غیرصفر را تنظیم کنید.
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

[setColumnAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) ستون اول را به چپ تراز می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) سه ستون متوالی را به راست تراز می‌کند، شروع از اندیس ۱. در `updated-matrix.pptx`، ماتریس دارای سه معادله و چهار متغیر است. ضرایب ردیف اول اصلی `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![matrix be rooz shode se radifi ba satrhai 1, 0, x, 0; 12, 1, 0, 0; va 0, 0, 10, 1](matrix-after-edit.png)

## **اضافه کردن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) وقتی به معادلات تراز شده یا یک پشتهٔ عمودی از عبارات نیاز دارید، استفاده کنید.

![yek array riyazi amoodi ba x balaye y](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) تراز عمودی یک آرایه نسبت به عناصر ریاضی کنار آن را کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

مثال زیر سه آرایهٔ یکسان ایجاد می‌کند، هر کدام با سه ردیف و عناصر همسایه `A=` و `=B`. تمام متن ریاضی از Cambria Math با اندازه ۲۴ پوینت استفاده می‌کند. فقط تراز آرایه تغییر می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

مقایسه زیر ارائه ذخیره‌شده در PowerPoint را نشان می‌دهد. موقعیت `A=` و `=B` را در کنار هر آرایه مشاهده کنید.

![arayeye ma&#7729;ale dar PowerPoint ba tarez Bala, Markaz va Paein va anasir ham saye hastand](equation-array-alignment.png)

### **پیکربندی فاصله ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) قاعده فاصله‌گذاری برای ردیف‌های داخل آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) مقداری عددی برای قاعدهٔ فاصله‌گذاری صریح فراهم می‌کند و توسط قواعد پیش‌فرض نادیده گرفته می‌شود.

برای فاصله‌گذاری دقیق، مقدار بر حسب پوینت اندازه‌گیری می‌شود. برای فاصله‌گذاری نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال معادل ۱٫۵ خط است. هنگام مشخص کردن یک مقدار صریح، هر دو ویژگی را تنظیم کنید؛ تغییر تنها مقدار عددی قاعدهٔ فاصله‌گذاری را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه مورد اول از پیش‌تنظیم‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر صریح را نشان می‌دهند.

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

فاصله‌گذاری ردیف‌های آرایه جدا از فاصله‌گذاری پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) فضایی اطراف پاراگراف حاوی اضافه می‌کنند، نه بین ردیف‌های آرایه. به همین ترتیب، [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) پاراگراف ریاضی را به صورت افقی موقعیت می‌دهد؛ این تنظیم جایگزین تنظیمات تراز عمودی آرایه نمی‌شود.

## **اضافه کردن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) وقتی آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![tabe trigonometric cos baraye 2x](powerpoint-math-equations_6.png)

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

از کمک‌کننده‌های زیرنویس و بالانویس برای اندیس‌ها و توان‌ها استفاده کنید. وقتی اندیس‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) استفاده کنید.

![Y bozorg ba zirnevis 1 dar samte chap va balanevis n](powerpoint-math-equations_9.png)

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

## **اضافه کردن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) برای قراردادن یک عبارت داخل جداکننده‌ها استفاده کنید. همچنین می‌توانید یک کاراکتر جداکننده برای عبارات جداکننده‌ای که شامل چندین عنصر هستند، تنظیم کنید.

![yek ebarat mojaz baraye x, y va z ke tavasot khataye amoodi joda shode and](powerpoint-math-equations_13.png)

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

مقدار `true` را به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) بدهید تا پرانتزها حول یک عملوند بلند بزرگ شوند، یا مقدار `false` بدهید تا اندازهٔ معمولی خود باقی بمانند. از [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) همراه با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را بر روی محور ریاضی که از وسط علامت مساوی عبور می‌کند، مرکز می‌کند. `Match` آنها را با محتوای درون‌گذاری شده تراز می‌کند. هر دو تنظیم فقط بر روی جداکننده‌ها تأثیر دارند. عبارت درون آن همان‌طور باقی می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به زیر آن گسترش یابد. هر چهار معادله از همان پرانتزها و تنظیمات قلم استفاده می‌کنند.

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

در PowerPoint، ردیف‌ها را برای دیدن اثر رشد مقایسه کنید. در ردیف بالا، پرانتزها برای دربرگیری توان بزرگ می‌شوند و برای هر دو شکل یکسان به نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر در سمت چپ (`Centered`) با علامت مساوی تراز می‌شوند، در حالی که پرانتزهای سمت راست (`Match`) بالاتر اطراف عبارت قرار دارند.

![chahar ma&#7729;ale dar PowerPoint ba fa&#7729;al shodan roshd mojaz dar bala va ghayr fa&#7729;al dar paein, va Centered dar chap va Match dar rast](delimiter-sizing.png)

## **اضافه کردن جعبهٔ حاشیه‌ای**

روی یک کسر [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) را صدا بزنید تا کل عبارت را در یک قاب بپیچید. [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) بازگشت داده شده به طور پیش‌فرض چهار طرف را نشان می‌دهد. از [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), و [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) برای حذف طرف‌های جداگانه استفاده کنید.

مثال شش نسخه از همان کسر را بر روی یک اسلاید قرار می‌دهد. برای نشان دادن حذف، تمام چهار طرف را مخفی کنید و مقدار `true` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) برای یک خط مورب صعودی (↗) یا به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) برای یک خط مورب نزولی (↘) بدهید. همچنین می‌توانید از [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) یا [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) با هر ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

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

![shesh kasr qabele virayesh dar PowerPoint. radif bala: hader kamel, tarafe paeen va chap, khat morabi roshan. radif paeen: khat morabi payin, khat amoodi, khat amoodi ba hader kamel](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر قرار می‌گیرد. خط عمودی هر دو صورت و مخرج را می‌گذرد در حالی که حاشیهٔ اطراف قابل مشاهده می‌ماند. این خطوط تمام عبارت را تزئین می‌کنند. خط‌خوردهٔ متن معمولی برای کاراکترهای یک بخش متن اعمال می‌شود. پس از باز کردن دوبارهٔ ارائه در PowerPoint، می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **کنترل نمایش و چیدمان با عناصر فانتوم**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) بپیچید تا به‌صورت مستقل نمایش آن و فضایی که به یک معادله اضافه می‌کند را کنترل کنید. متدهای [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) موارد زیر را کنترل می‌کنند:

| روش | اثر |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | مقدار `false` را بگذارید تا عبارت مخفی شود. ابعاد آن همچنان در چیدمان مؤثر است مگر اینکه متدهای زیر مقدار `true` دریافت کنند. |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | عرض افقی عبارت را صفر در نظر بگیرید تا عناصر همجوار بتوانند به هم نزدیک‌تر شوند. |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | ارتفاع بالای خط پایه (ascender) را صفر در نظر بگیرید. این می‌تواند فضای رزرو شده بالای عناصر همجوار را کاهش دهد. |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | عمق زیر خط پایه (descent) را صفر در نظر بگیرید. این می‌تواند نوار کسر یا محتوای دیگر زیر عبارت را به همسایگان نزدیک‌تر کند. |

خط پایه خط مرجع است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بعد به عنوان صفر عبارت را حذف نمی‌کند. عبارت زیرین از طریق [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) در دسترس باقی می‌ماند. مقدار `true` را به [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) بدهید تا دوباره نمایش داده شود؛ تنظیمات بعدی بدون تغییر می‌مانند.

مثال زیر پنج گونهٔ هم‌نشینی ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را رزرو می‌کند، و سه کسر مخفی با یک بعد به صورت صفر. هر گونه از همان عبارت اطراف و Cambria Math با اندازهٔ ۲۴ پوینت استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که با راهنمای خاکستری علامت‌گذاری شده است. قرار دادن فانتوم در صورت یک کسر بیرونی تغییرات چیدمان عمودی را به‌صورت واضح‌تری نشان می‌دهد.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY);

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

![panj ma&#7729;ale dar PowerPoint ke yek kasr qabele neshan, yek kasr makhfiy ke faza ra rezerv mikonad, va kasrhai makhfiy ba fa&#7729;al kardan ZeroWidth, ZeroAsc ya ZeroDesc neshan midahand](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) برای قرار دادن یک کاراکتر گروه‌بندی بالای یا زیر یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی شده یک حد اضافه کنید.

![ebarat x + y ke ba barcheLabel any text dar zirash goruh bandi shode ast](powerpoint-math-equations_15.png)

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

از کمک‌کننده‌های قالب‌بندی فقط در جایی که فرمول را واضح‌تر می‌کند استفاده کنید. برای مثال، [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) یک خط بالای یک عنصر ریاضی می‌گذارد.

![yek ebarat riyazi ABC ba yek khat bala-ash](powerpoint-math-equations_14.png)

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

برای قالب‌بندی متن در تمام یک معادله موجود، درخت عنصر هر بلوک ریاضی را پیمایش کنید. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) فقط فرزندان مستقیم را برمی‌گرداند، بنابراین برای رسیدن به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو، به صورت بازگشتی فراخوانی کنید. عنصر فعلی و فرزندان آن را بررسی کنید تا عنصر شروع را زمانی که [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) است، شامل شود.

این مثال فرض می‌کند `input.pptx` شامل معادله‌ای مانند `z = xᵢ / ∛y` است که در آن یک کسر دارای زیرنویس در صورت و رادیکال در مخرج دارد. پردازش فقط عناصر سطح بالای بلوک متن داخل کسر را از دست می‌دهد. مثال بخش‌های ریاضی در چارچوب متن اسلایدها را پیدا می‌کند، بلوک‌هایشان را از طریق [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) دسترسی می‌یابد و از [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) برای تنظیم اندازه قلم به ۲۸ پوینت برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) استفاده می‌کند.

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

ارائهٔ ذخیره‌شده حاوی قالب‌بندی متن به‌روز شده در هر سطح از هر معادلهٔ پردازش‌شده است، در حالی که محتوای متن و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| کار | API اصلی |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| ایجاد کسرها | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| افزودن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| افزودن توابع | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| افزودن رادیکال‌ها | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| افزودن حدود | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| افزودن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| افزودن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| افزودن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| افزودن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| افزودن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| افزودن خط بالا و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **پرسش‌های متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که شامل یک [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) را فراخوانی کنید و بلوک‌های ریاضی در آن پاراگراف را به‌روز کنید.

**آیا معادلات به‌عنوان ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) معادله را از [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) دریافت کنید و [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) را برای خروجی مستقیم فراخوانی کنید. برای یک مثال کامل، به [Export Math Equations from Presentations in Java](/slides/fa/java/exporting-math-equations/#export-math-equations-to-latex) مراجعه کنید.