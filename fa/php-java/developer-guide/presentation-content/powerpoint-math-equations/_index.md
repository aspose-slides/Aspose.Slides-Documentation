---
title: افزودن معادلات ریاضی به ارائه‌های PowerPoint در PHP
linktitle: معادلات ریاضی PowerPoint
type: docs
weight: 80
url: /fa/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "در PowerPoint (PPT و PPTX) معادلات ریاضی را با Aspose.Slides برای PHP از طریق Java وارد و ویرایش کنید؛ از پشتیبانی OMML، کنترل‌های قالب‌بندی، و نمونه‌های واضح کد PHP بهره‌مند شوید."
---
## **بررسی کلی**

PowerPoint معادلات را به عنوان Office Math Markup Language (OMML) ذخیره می‌کند. با Aspose.Slides برای PHP از طریق Java، می‌توانید همان نوع محتویات ریاضی را به صورت برنامه‌نویسی ایجاد کنید: کسرها، رادیکال‌ها، توابع، حدها، عملگرهای N-ary، ماتریس‌ها، آرایه‌ها و بلوک‌های ریاضی قالب‌بندی شده.

در PowerPoint، کاربران معمولاً معادلات را از **Insert > Equation** اضافه می‌کنند:

![زبانه Insert در PowerPoint با فرمان Equation انتخاب شده](powerpoint-math-equations_1.png)

نتیجه متن ریاضی قابل ویرایش بر روی اسلاید است:

![یک اسلاید PowerPoint شامل یک معادله ریاضی قابل ویرایش](powerpoint-math-equations_2.png)

Aspose.Slides این متن ریاضی را از طریق سه شی اصلی می‌سازد:

- یک شکل ریاضی که با [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) ایجاد می‌شود، شکلی است که معادله را شامل می‌شود.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) محتویات ریاضی را داخل فریم متن شکل ذخیره می‌کند.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) شامل یک یا چند شیء [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) است.

اکثر مثال‌های زیر از [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) و روش‌های زنجیره‌ای [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) برای کوتاه و قابل‌خواندن نگه داشتن کد استفاده می‌کنند.

برای سناریوهای صدور MathML، ببینید [صادر کردن معادلات ریاضی از ارائه‌ها در PHP از طریق Java](/slides/fa/php-java/exporting-math-equations/).

## **ایجاد یک معادله**

این مثال از [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) برای ایجاد یک شکل ریاضی استفاده می‌کند و نظریه فیثاغورث را اضافه می‌کند:

![معادله c مربع مساوی a مربع به‌علاوه b مربع](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) یک شکل ایجاد می‌کند که از پیش شامل یک پاراگراف ریاضی است. اولین [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) را دسترسی یافته، [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی یا عناصر ریاضی را به آن اضافه کنید.
{{% /alert %}}

## **اضافه کردن کسرها**

از [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) برای ایجاد یک کسر استفاده کنید. می‌توانید یک سبک کسر را با [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) انتخاب کنید.

![یک کسر ریاضی کج که یک تقسیم بر x نشان می‌دهد](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

برای کسر ستیک، از [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) استفاده کنید:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **اضافه کردن رادیکال‌ها**

از [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) برای ایجاد ریشه‌ دوم، ریشه‌ سوم یا ریشه‌های دیگر استفاده کنید. عنصر فعلی به‌عنوان پایه می‌شود و آرگومان به‌عنوان درجه.

![یک عبارت رادیکال درجه n که x زیر علامت رادیکال قرار دارد](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **نمایش یا مخفی‌کردن درجهٔ ریشهٔ دوم**

یک ریشهٔ دوم می‌تواند عدد ۲ صریح را نمایش دهد یا از نماد متعارف √x استفاده کند. متد [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) از [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) تعیین می‌کند کدام فرم ظاهر شود. هر دو فرم درجه ۲ و رادیکاند x را در معادلهٔ قابل ویرایش نگه می‌دارند.

![همان ریشهٔ دوم با درجهٔ نمایان در سمت چپ و مخفی در سمت راست](square-root-degree.png)

مثال ریشهٔ دوم را دو بار ذخیره می‌کند. در `visible-degree.pptx`، ۲ قابل‌مشاهده است. در `hidden-degree.pptx`، مخفی است.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **اضافه کردن توابع و حدها**

از [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) یا [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) برای توابعی مانند `sin(x)`, `log(x)` یا نام توابع سفارشی استفاده کنید. برای حدها، `lim` را در یک [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) قرار دهید یا از [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) استفاده کنید.

![حد x وقتی x به بی‌نهایت میل می‌کند](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

برای نام تابع سفارشی، نام تابع را عنصر فعلی کنید و با [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) همراه با آرگومان آن فراخوانی کنید:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **اضافه کردن عملگرهای N-ary و انتگرال‌ها**

از [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) برای جمع‌ها، اتحادها، اشتراک‌ها و سایر عملگرهای بزرگ استفاده کنید. از [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) برای انتگرال‌ها استفاده کنید. هر دو روش به شما امکان می‌دهند حد پایین و بالا را تنظیم کنید.

![یک مجموع با حد پایین و حد بالا](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

عملگرهای N-ary برای عملگرهای بزرگ با حدهای اختیاری استفاده می‌شوند. عملگرهای ساده مانند `+`، `-` و `=` معمولاً به‌صورت [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) اضافه می‌شوند و به عبارت پیوسته می‌شوند.

برای یک انتگرال، از [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) استفاده کنید:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **اضافه کردن ماتریس‌ها**

از [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) برای ردیف‌ها و ستون‌ها استفاده کنید. به‌طور پیش‌فرض ماتریس‌ها پرانتز ندارند، بنابراین برای نیاز به پرانتز، کروشه یا آکولاد، ماتریس را درون آن‌ها بگذارید.

![یک ماتریس ریاضی دو رودی با یک سلول خالی](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **ویرایش یک ماتریس موجود**

فرض کنید یک درس جبر خطی با ماتریس ضرایب موجود در `matrix.pptx`، که توسط مثال قبلی ذخیره شده، شروع می‌شود. برای تمرین بعدی، معادلهٔ اول را نگه دارید، معادلهٔ دوم را با دو معادلهٔ جدید جایگزین کنید و مجموعه متغیرها را بازنگری کنید. ماتریس موجود را از طریق [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) باز کنید تا ضرایبی که هنوز معتبرند حفظ شوند.

![ماتریس ضریب دو ردیفی اصلی با ورودی‌های 1، x، و یک سلول خالی در ردیف اول و x، 2، و y در ردیف دوم](matrix-before-edit.png)

شاخص‌های ردیف و ستون از صفر شروع می‌شوند و به ماتریس در هر فراخوانی اشاره می‌کنند. درج یک ردیف قبل از شاخص 1، ردیف دوم اصلی را به شاخص 2 منتقل می‌کند. درج پس از شاخص 2 سپس یک ردیف اضافه می‌کند. حذف ردیف 2 معادلهٔ دوم اصلی را حذف کرده و ردیف اضافه شده را یک موقعیت بالا می‌برد. ستون‌ها به‌همین ترتیب جابه‌جا می‌شوند.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // سلول‌های جدید ابتدا مقدار null هستند. ابتدا ضرایب غیرصفر را تنظیم کنید.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) ستون اول را به سمت چپ تنظیم می‌کند. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) سه ستون متوالی را از شاخص 1 به سمت راست تنظیم می‌کند. در `updated-matrix.pptx`، ماتریس دارای سه معادله و چهار متغیر است. ضرایب اصلی ردیف اول `1` و `x` اکنون در ستون‌های اول و سوم ظاهر می‌شوند.

![ماتریس سه رودی به‌روز شده نشان‌دهنده ردیف‌های 1، 0، x، 0؛ 12، 1، 0، 0؛ و 0، 0، 10، 1](matrix-after-edit.png)

## **اضافه کردن آرایه‌های معادله**

از [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) وقتی به معادلات هم‌راستا یا پشتهٔ عمودی عبارات نیاز دارید استفاده کنید.

![یک آرایه ریاضی عمودی با x بالای y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **ترازبندی آرایه با عناصر اطراف**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) تراز عمودی آرایه نسبت به عناصر ریاضی کناری را کنترل می‌کند. مثال زیر تراز را با ردیف اول، مرکز آرایه و ردیف آخر مقایسه می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقایسه زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد. به موقعیت `A=` و `=B` کنار هر آرایه توجه کنید.

![آرایه‌های معادله در PowerPoint با تراز بالایی، وسطی و پایینی و عناصر همسایهٔ یکسان](equation-array-alignment.png)

### **پیکربندی فاصلهٔ ردیف‌ها**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) قانون فاصله‌گذاری برای ردیف‌های داخل آرایه را انتخاب می‌کند. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) مقدار عددی برای قانون واضح فراهم می‌کند و توسط قوانین پیش‌فرض نادیده گرفته می‌شود.

برای فاصلهٔ دقیق، مقدار بر حسب نقطه اندازه‌گیری می‌شود. برای فاصلهٔ نسبی، بر حسب نیم‌خط اندازه‌گیری می‌شود: مقدار `3` در مثال برابر 1.5 خط است. هنگام تعیین مقدار واضح، هر دو خصوصیت را تنظیم کنید؛ تغییر فقط مقدار عددی قانون فاصله را انتخاب نمی‌کند.

مثال زیر پنج ارائه با معادلات، تراز و تنظیمات قلم یکسان ذخیره می‌کند. سه مورد اول از پیش‌فرض‌ها استفاده می‌کنند؛ دو مورد آخر مقادیر واضح را نشان می‌دهند.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

فاصلهٔ ردیف آرایه جدا از فاصلهٔ پاراگراف است. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) فضای اطراف پاراگراف شامل‌کننده را اضافه می‌کنند، نه بین ردیف‌های آرایه. به همین ترتیب، [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) کل پاراگراف ریاضی را افقی موقعیت می‌دهد؛ تنظیم عمودی آرایه را جایگزین نمی‌کند.

## **اضافه کردن توابع مثلثاتی**

از [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) زمانی که آرگومان عنصر فعلی است و نام تابع شناخته شده است، استفاده کنید.

![تابع مثلثاتی cos بر 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **اضافه کردن زیرنویس و بالانویس**

از کمکی‌های زیرنویس و بالانویس برای نمایه‌ها و توان‌ها استفاده کنید. وقتی نمایه‌ها باید در سمت چپ پایه ظاهر شوند، از [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) استفاده کنید.

![یک Y بزرگ با زیرنویس سمت چپ 1 و بالانویس n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **اضافه کردن جداکننده‌ها**

از [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) برای قرار دادن یک عبارت داخل جداکننده‌ها استفاده کنید. می‌توانید یک کاراکتر جداکننده برای عبارات شامل چند عنصر تنظیم کنید.

![یک عبارت جداکننده شامل x، y و z جدا شده با خطوط عمودی](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **اندازه و تراز جداکننده‌ها**

به [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) مقدار `true` بدهید تا پرانتزها برای یک عامل بلند بزرگ شوند، یا مقدار `false` بدهید تا اندازهٔ عادی خود را حفظ کنند. از [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) همراه با یکی از دو مقدار [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) استفاده کنید. `Centered` پرانتزها را بر محور ریاضی که از وسط علامت مساوات عبور می‌کند، مرکز می‌کند. `Match` آن‌ها را با محتوای محاط‌شده هم‌راستا می‌کند. هر دو تنظیم فقط بر جداکننده‌ها اثر می‌گذارند؛ عبارت داخلی همان‌ باقی می‌ماند.

مثال یک کسر را در توان `x` قرار می‌دهد تا عبارت بالاتر از خط پایه نسبت به پایین بیشتر گسترش یابد. چهار معادله از یک پرانتز و تنظیمات قلم یکسان استفاده می‌کنند.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در PowerPoint ردیف‌ها را برای دیدن اثر رشد مقایسه کنید. در ردیف بالا، پرانتزها برای محاط کردن توان رشد می‌کنند و برای هر دو شکل یکسان به‌نظر می‌رسند. در ردیف پایین، رشد غیرفعال است. پرانتزهای کوچکتر سمت چپ (`Centered`) با علامت مساوات هم‌راستا هستند، در حالی که سمت راست (`Match`) بالاتر برای محاط کردن عبارت قرار می‌گیرند.

![چهار معادله در PowerPoint با رشد جداکننده فعال در بالا و غیرفعال در پایین، و Centered در سمت چپ و Match در سمت راست](delimiter-sizing.png)

## **اضافه کردن جعبهٔ مرزی**

با فراخوانی [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) بر روی یک کسر، کل عبارت در یک قاب قرار می‌گیرد. [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) به‌صورت پیش‌فرض چهار طرف را نشان می‌دهد. برای حذف طرف‌های جداگانه می‌توانید از [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) و [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) استفاده کنید.

مثال شش کپی از همان کسر را روی یک اسلاید قرار می‌دهد. برای نمایش لغو، تمام چهار طرف را مخفی کنید و برای یک قطر صعودی (↗) مقدار `true` را به [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) یا برای یک قطر نزولی (↘) به [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) بدهید. می‌توانید همچنین از [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) یا [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) همراه با ترکیبی از طرف‌های قابل مشاهده استفاده کنید.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![شش کسر قابل ویرایش در PowerPoint. ردیف بالا: مرز کامل، طرفین پایین و چپ، خط مورب صعودی. ردیف پایین: خط مورب نزولی، ضرب‌در افقی، ضرب‌در عمودی با مرز کامل](border-box-fractions.png)

در این کسر، خط افقی بر روی خط کسر همپوشانی دارد. خط عمودی هر دو صورت و مخرج را قطع می‌کند در حالی که مرز اطراف همچنان قابل مشاهده است. این خطوط کل عبارت را تزئین می‌کنند. Strikethrough معمولی فقط بر روی کاراکترهای یک ران متن اعمال می‌شود. پس از باز کردن مجدد ارائه در PowerPoint، هنوز می‌توانید صورت و مخرج را به‌صورت مستقل ویرایش کنید.

## **کنترل قابلیت مشاهده و چیدمان با عناصر فانتوم**

یک عبارت را در [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) بپیچید تا قابلیت مشاهده آن و فضایی که به معادله می‌افزاید را به‌طور جداگانه کنترل کنید. متدهای [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) موارد زیر را کنترل می‌کنند:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | مقدار `false` را بدهید تا عبارت مخفی شود. ابعاد آن همچنان در چیدمان مؤثر هستند مگر اینکه متدهای مربوطه در زیر مقدار `true` بگیرند. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | عرض افقی عبارت را صفر در نظر می‌گیرد و اجازه می‌دهد عناصر همسایه به یکدیگر نزدیک‌تر شوند. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | ارتفاع بالای خط پایه (ascender) را صفر در نظر می‌گیرد؛ این می‌تواند فضای رزرو شده بالای عناصر همسایه را کاهش دهد. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | ارتفاع زیر خط پایه (descender) را صفر در نظر می‌گیرد؛ این می‌تواند نوار کسر یا محتوای زیرین را نزدیک‌تر به همسایه‌هایش بیاورد. |

خط پایه مرجع خطی است که حروف ریاضی معمولی بر روی آن قرار می‌گیرند. مخفی کردن محتوا ابعاد آن را حذف نمی‌کند و در نظر گرفتن یک بُعد به‌عنوان صفر، عبارت را حذف نمی‌کند. عبارت زیرین همچنان از طریق [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) در دسترس است. برای نمایش مجدد، مقدار `true` را به [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) بدهید؛ تنظیمات بُعدی همان‌جا باقی می‌مانند.

مثال زیر پنج نوع متفاوت کنارهم ایجاد می‌کند: یک کسر قابل مشاهده، یک کسر مخفی که فضا را رزرو می‌کند، و سه کسر مخفی با یک بُعد به‌صورت صفر (ZeroWidth، ZeroAsc یا ZeroDesc). هر نوع از همان عبارت پیرامونی و قلم Cambria Math با 24 نقطه استفاده می‌کند. تمام اشکال معادله موقعیت بالایی یکسانی دارند که با راهنمای خاکستری نشان داده شده است. قرار دادن فانتوم در صورت یک کسر بیرونی تغییرات چیدمان عمودی را واضح‌تر می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![پنج معادله در PowerPoint که یک کسر قابل مشاهده، یک کسر مخفی که فضا را رزرو می‌کند، و کسرهای مخفی با ZeroWidth، ZeroAsc یا ZeroDesc فعال را مقایسه می‌کند](math-phantom.png)

## **گروه‌بندی عبارات**

از [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) برای قرار دادن یک کاراکتر گروه‌بندی بالا یا پایین یک عبارت استفاده کنید. برای برچسب‌گذاری عبارات گروه‌بندی‌شده می‌توانید یک حد اضافه کنید.

![عبارت x به‌علاوه y که با برچسب any text در زیر آن گروه‌بندی شده است](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **قالب‌بندی عناصر ریاضی**

از کمک‌کننده‌های قالب‌بندی فقط در جایی استفاده کنید که فرمول را واضح می‌کند. به عنوان مثال، [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) یک نوار بالای عنصر ریاضی می‌گذارد.

![یک عبارت ریاضی ABC با یک overbar](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **قالب‌بندی متن در یک معادله موجود**

برای قالب‌بندی متن در تمام یک معادلهٔ موجود، درخت عناصر هر بلوک ریاضی را پیمایش کنید. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) فقط فرزندان مستقیم را باز می‌گرداند، بنابراین برای دسترسی به متن داخل کسرها، اسکریپت‌ها، رادیکال‌ها و سایر ساختارهای تو در تو باید به‌صورت بازگشتی فراخوانی شود. عنصر فعلی و فرزندان آن را بررسی کنید تا زمانی که عنصر [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) باشد، شامل شود.

این مثال فرض می‌کند `input.pptx` حاوی معادله‌ای مانند `z = xᵢ / ∛y` است که در آن کسر شامل زیرنویس در صورت و رادیکال در مخرج می‌باشد. پردازش فقط عناصر سطح بالای بلوک متن‌های داخل کسر را از دست می‌دهد. این مثال بخش‌های ریاضی در فریم‌های متن اسلاید را پیدا می‌کند، بلوک‌های آن‌ها را از طریق [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) دسترسی می‌یابد و با [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) اندازهٔ قلم را به 28 نقطه برای هر عنصر متنی از طریق متد [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) تنظیم می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ارائهٔ ذخیره‌شده متن قالب‌بندی‌شده به‌روز شده را در هر سطح از هر معادلهٔ پردازش‌شده دارد، در حالی که محتویات متنی و ساختار ریاضی آن حفظ می‌شود.

## **مرجع سریع**

| Task | Main API |
| --- | --- |
| ایجاد متن ریاضی | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| ترکیب عناصر | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| ایجاد کسرها | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن بالانویس یا زیرنویس | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن توابع | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن رادیکال‌ها | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن حدها | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن اسکریپت‌های سمت چپ | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن جمع‌ها و انتگرال‌ها | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن ماتریس‌ها | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| اضافه کردن آرایه‌های معادله | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن جداکننده‌ها | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| اضافه کردن خطوط و حاشیه‌ها | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| گروه‌بندی عبارات | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **سوالات متداول**

**آیا می‌توانم یک معادلهٔ موجود در PowerPoint را ویرایش کنم؟**

بله. ارائه را باز کنید، شکلی که حاوی یک [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) است پیدا کنید، [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) را فراخوانی کنید و بلوک‌های ریاضی آن پاراگراف را به‌روزرسانی کنید.

**آیا معادلات به‌صورت ریاضی قابل ویرایش PowerPoint ذخیره می‌شوند؟**

بله. هنگام ذخیره به قالب PPTX، Aspose.Slides معادله را به‌عنوان محتوای ریاضی Office قابل ویرایش می‌نویسد.

**آیا می‌توانم معادلات را به LaTeX صادر کنم؟**

بله. [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) مربوط به معادله را از [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) دریافت کنید و متد [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) را برای صادر کردن مستقیم فراخوانی کنید. برای یک مثال کامل، ببینید [صادر کردن معادلات ریاضی از ارائه‌ها در PHP از طریق Java](/slides/fa/php-java/exporting-math-equations/#export-math-equations-to-latex).