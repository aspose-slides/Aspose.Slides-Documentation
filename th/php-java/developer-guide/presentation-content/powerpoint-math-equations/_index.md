---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/php-java/powerpoint-math-equations/
keywords:
- สมการคณิตศาสตร์
- สัญลักษณ์คณิตศาสตร์
- สูตรคณิตศาสตร์
- ข้อความคณิตศาสตร์
- เพิ่มสมการคณิตศาสตร์
- เพิ่มสัญลักษณ์คณิตศาสตร์
- เพิ่มสูตรคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด PHP ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยอัตโนมัติ: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้โดยทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือกไว้](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจ็กต์หลัก:

- รูปคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) คือรูปที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในเฟรมข้อความของรูป
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) และเมธ็อดสไตล์ fluent จาก [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ดูที่ [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปคณิตศาสตร์และเพิ่มทฤษฎีบทพีทาโกรัส:

![สมการ c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="หมายเหตุ" %}}

[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วเพิ่ม MathBlock หรือ MathElement ลงไป

{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/)

![เศษส่วนเอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนกัน ใช้ [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ จากนั้นอีเลเมนต์ปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![สัญลักษณ์ราก n‑th ที่มี x อยู่ภายใต้เครื่องหมายราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากที่สอง**

รากที่สองสามารถแสดงเลข 2 ชัดเจนหรือใช้สัญลักษณ์ √x แบบดั้งเดิม วิธี [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่แสดง ทั้งสองรูปแบบยังคงมีดีกรี 2 และตัว radicand เป็น x ในสมการที่แก้ไขได้

![รากที่สองเดียวกันโดยดีกรีแสดงทางซ้ายและซ่อนทางขวา](square-root-degree.png)

ตัวอย่างบันทึกรากที่สองสองครั้ง ใน `visible-degree.pptx` ดีกรี 2 ปรากฏเห็น ส่วนใน `hidden-degree.pptx` ดีกรีถูกซ่อน

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัด ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit)

![ขีดจำกัดของ x ขณะ x ใกล้กับอนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ทำให้ชื่อฟังก์ชันเป็นอีเลเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิเกรัล**

ใช้ [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) สำหรับการบวก, การรวม, การตัดกัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิเกรัล ทั้งสองเมธ็อดให้คุณกำหนดขีดจำกัดล่างและบน

![สัญลักษณ์บวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่อาจมีขีดจำกัด ตัวดำเนินการง่ายเช่น `+`, `-`, `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) แล้วเชื่อมต่อเข้ากับนิพจน์

สำหรับอินทิเกรัล ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ จึงต้องใส่วงเล็บ, โบว์, หรือเครื่องหมายปีกกาเมื่อจำเป็น

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

## **เพิ่มอาร์เรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดตำแหน่งกันหรือสแตกแนวตั้งของนิพจน์

![อาร์เรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดตำแหน่งอาร์เรย์กับอีเลเมนต์โดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดตำแหน่งแนวตั้งของอาร์เรย์เมื่อเทียบกับอีเลเมนต์คณิตศาสตร์ที่อยู่ข้าง ๆ ตัวอย่างด้านล่างเปรียบเทียบการจัดตำแหน่งกับแถวแรก, ศูนย์ของอาร์เรย์, และแถวสุดท้าย

ตัวอย่างต่อไปสร้างอาร์เรย์สามชุดที่เหมือนกัน แต่ละชุดมีสามแถวและอีเลเมนต์ข้างเคียง `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 pt มีเพียงการจัดตำแหน่งอาร์เรย์ที่แตกต่างกัน

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

เปรียบเทียบการบันทึกพรีเซนเทชันใน PowerPoint จะเห็นตำแหน่งของ `A=` และ `=B` ใกล้กับแต่ละอาร์เรย์

![อาร์เรย์สมการใน PowerPoint กับการจัดตำแหน่งบน, ศูนย์, และล่าง พร้อมอีเลเมนต์ข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างระหว่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎระยะห่างสำหรับแถวภายในอาร์เรย์ [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎระยะห่างที่กำหนดเองและจะถูกละเว้นโดยกฎที่ตั้งไว้ล่วงหน้า

สำหรับระยะห่างที่แน่นอน ค่าเป็นหน่วยจุด สำหรับระยะห่างแบบสัดส่วน ค่าจะเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติเมื่อต้องการค่าที่ชัดเจน; การเปลี่ยนค่าเชิงตัวเลขเพียงอย่างเดียวไม่เลือกกฎระยะห่าง

ตัวอย่างต่อไปบันทึกพรีเซนเทชันห้าชุดด้วยสมการเดียวกัน, การจัดตำแหน่งเดียวกัน, และการตั้งค่าฟอนท์เดียวกัน ชุดแรกสามชุดใช้ค่าที่ตั้งไว้ล่วงหน้า; สองชุดสุดท้ายแสดงค่าที่กำหนดเอง

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

ระยะห่างของแถวอาร์เรย์แยกจากระยะห่างของย่อหน้า [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มช่องว่างรอบย่อหน้าที่บรรจุอาร์เรย์ ไม่ได้เพิ่มระยะห่างระหว่างแถวอาร์เรย์เช่นกัน [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) กำหนดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดตำแหน่งแนวตั้งของอาร์เรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์เป็นอีเลเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ถูกนำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มดัชนีและเลขชี้กำลัง**

ใช้ตัวช่วยสำหรับดัชนีและเลขชี้กำลังเมื่อต้องการจัดตำแหน่งดัชนีหรือกำลัง หากต้องการให้ดัชนีอยู่ด้านซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![อักษร Y ตัวพิมพ์ใหญ่ที่มีดัชนีซ้าย 1 และเลขชี้กำลัง n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่งขอบเขต**

ใช้ [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ไว้ในตัวแบ่งขอบเขต คุณยังสามารถกำหนดอักขระตัวคั่นสำหรับนิพจน์ที่มีหลายอีเลเมนต์

![นิพจน์ที่มีตัวแบ่งขอบเขตประกอบด้วย x, y, และ z ที่คั่นด้วยเส้นแนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดตำแหน่งตัวแบ่งขอบเขต**

ส่งค่า `true` ให้ [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามความสูงของออปเรานด์, หรือส่ง `false` เพื่อคงขนาดปกติ ใช้ [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) พร้อมค่าหนึ่งจากสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) `Centered` ทำให้วงเล็บอยู่กึ่งกลางแกนคณิตศาสตร์ที่ผ่านสัญลักษณ์เท่ากับ `=` ส่วน `Match` จะจัดตำแหน่งให้ตรงกับเนื้อหาที่ครอบอยู่ การตั้งค่าสองแบบนี้มีผลต่อเพียงตัวแบ่งเท่านั้น ส่วนนิพจน์ภายในคงเดิม

ตัวอย่างวางเศษส่วนเป็นดัชนีของ `x` ทำให้นิพจน์ยื่นเหนือบรรทัดฐานมากกว่าล่าง ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนท์เดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบน วงเล็บขยายเพื่อครอบดัชนีและดูเหมือนกันในทั้งสองรูปแบบ ในแถวล่าง การขยายถูกปิด วงเล็บเล็กด้านซ้าย (`Centered`) จัดตำแหน่งกับเครื่องหมายเท่ากับ ส่วนด้านขวา (`Match`) อยู่สูงกว่ารอบนิพจน์

![สี่สมการใน PowerPoint พร้อมการเปิด/ปิดการขยายตัวแบ่งขอบเขต โดย `Centered` อยู่ด้านซ้ายและ `Match` อยู่ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบเขต**

เรียก [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อใส่กรอบรอบนิพจน์ทั้งหมด ผลลัพธ์ที่ได้คืออ็อบเจ็กต์ [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) ที่แสดงสี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านเฉพาะ

ตัวอย่างวางเศษส่วนเดียวกันหกสำเนาบนสไลด์เดียว เพื่อแสดงการขีดฆ่า ให้ซ่อนสี่ด้านทั้งหมดและส่ง `true` ให้ [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อสร้างเส้นทแยงมุมขึ้น (`↗`) หรือใช้ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อสร้างเส้นทแยงมุมลง (`↘`) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) พร้อมการผสมผสานของด้านที่มองเห็น

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, ขีดแนวนอน, ขีดแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นขีดแนวนอนทับบาร์ของเศษส่วน ส่วนเส้นขีดแนวตั้งตัด numerator และ denominator ในขณะที่กรอบรอบ ๆ ยังคงมองเห็นได้ เส้นเหล่านี้เป็นการตกแต่งทั้งนิพจน์ ข้อความปกติที่มีการขีดฆ่าใน PowerPoint จะทำกับอักขระในรันข้อความ หลังจากเปิดพรีเซนเทชันอีกครั้งใน PowerPoint คุณยังคงแก้ไข numerator และ denominator แยกกันได้

## **ควบคุมการมองเห็นและเค้าโครงด้วย Phantom Elements**

ห่อหุ้มนิพจน์ด้วย [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันเพิ่มให้กับสมการโดยอิสระ วิธีการของ [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) ควบคุมดังนี้

| เมธ็อด | ผล |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | ส่งค่า `false` เพื่อซ่อนนิพจน์ มิติกทั้งหมดยังคงมีผลต่อเค้าโครง ยกเว้นเมธ็อดที่กำหนด `true` ต่อไป |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | ปรับความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้อีเลเมนต์ข้างเคียงเคลื่อนเข้าหากัน |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | ปรับส่วนที่อยู่เหนือเส้นฐาน (ascent) เป็นศูนย์ ลดพื้นที่ที่สงวนไว้เหนืออีเลเมนต์ข้างเคียง |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | ปรับส่วนที่อยู่ใต้เส้นฐาน (descent) เป็นศูนย์ ทำให้บาร์ของเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์เข้าใกล้กับเพื่อนบ้านมากขึ้น |

เส้นฐานคือเส้นอ้างอิงที่อักขระคณิตศาสตร์ปกติวางอยู่ การซ่อนเนื้อหาไม่ลบมิติ และการตั้งค่ามิติเป็นศูนย์ไม่ทำให้นิพจน์หายไป นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) ส่งค่า `true` ให้ [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติจะคงเดิม

ตัวอย่างด้านล่างสร้างห้าแบบที่วางข้างกัน: เศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่ยังสงวนพื้นที่, และสามเศษส่วนที่ซ่อนพร้อมการตั้งค่ามิติเป็นศูนย์หนึ่งค่าแต่ละแบบ ทุกแบบใช้สูตรรอบข้างเดียวกันและ Cambria Math ขนาด 24 pt ทั้งหมดมีตำแหน่งบนเดียวกันโดยมีไกด์สีเทา การวาง phantom ใน numerator ของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงเค้าโครงแนวตั้งเห็นได้ง่ายขึ้น

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

![ห้าสมการใน PowerPoint เปรียบเทียบบริเวณที่มองเห็น, ที่ซ่อนแต่สงวนพื้นที่, และที่ซ่อนพร้อม ZeroWidth, ZeroAsc, หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) เพื่อวางตัวอักษรจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้ายกำกับข้อความใด ๆ ด้านล่าง](powerpoint-math-equations_15.png)

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

## **ฟอร์แมตอีเลเมนต์คณิตศาสตร์**

ใช้ตัวช่วยฟอร์แมตเฉพาะเมื่อช่วยให้สูตรชัดเจน ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) ใส่แถบเหนืออีเลเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีแถบเหนือ](powerpoint-math-equations_14.png)

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

### **ฟอร์แมตข้อความในสมการที่มีอยู่**

เพื่อฟอร์แมตข้อความทั่วทั้งสมการที่มีอยู่ ให้วนลูปทุกบล็อกของ MathBlock แล้วเดินทางผ่านโครงสร้างต้นไม้ของอีเลเมนต์ [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) จะคืนค่าเฉพาะลูกโดยตรง ดังนั้นจึงต้องเรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอีเลเมนต์ปัจจุบันพร้อมลูกของมันเพื่อรวมอีเลเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` โดยมีเศษส่วนที่มีดัชนีย่อยใน numerator และรากใน denominator การประมวลผลเฉพาะอีเลเมนต์ระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหา MathPortion ในเฟรมข้อความของสไลด์, เข้าถึงบล็อกผ่าน [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อกำหนดขนาดฟอนท์เป็น 28 pt ผ่านเมธ็อด [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละอีเลเมนต์ข้อความ

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

พรีเซนเทชันที่บันทึกไว้จะมีข้อความที่อัปเดตฟอร์แมตที่ทุกระดับของแต่ละสมการที่ประมวลผลไว้ พร้อมคงเนื้อหาและโครงสร้างคณิตศาสตร์ไว้เดิม

## **ข้อมูลอ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| รวมอีเลเมนต์ | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| สร้างเศษส่วน | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเลขชี้กำลังหรือตัวดัชนี | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มการบวกและอินทิเกรัล | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวแบ่งขอบเขต | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มแถบและกรอบ | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ เปิดพรีเซนเทชัน, ค้นหารูปที่บรรจุ [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วอัปเดต MathBlock ในย่อหนนนั้น

**สมการจะถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้ เรียก [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ของมัน แล้วใช้ [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง ดูตัวอย่างเต็มที่ [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/#export-math-equations-to-latex)