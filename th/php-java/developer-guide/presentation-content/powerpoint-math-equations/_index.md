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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด PHP ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยอัตโนมัติ: เศษส่วน, ราดิกัล, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N‑ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปจะเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) คือรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ประกอบด้วยหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ดู [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มสูตรพีทากอรัส:

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วเพิ่ม MathBlock หรือ MathElement ลงไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนได้ด้วย [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/)

![เศษส่วนเอียงที่แสดง 1 ÷ x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนกัน ให้ใช้ [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **เพิ่มราดิกัล**

ใช้ [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ ตัวแปรปัจจุบันจะเป็นฐาน ส่วนอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์ราก n‑th ที่มี x อยู่ใต้เครื่องหมายราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากกำลังสอง**

รากกำลังสองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามปกติ เมธอด [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่แสดง ทั้งสองรูปแบบยังคงเก็บดีกรี 2 และ radicand x ไว้ในสมการที่แก้ไขได้

![รากกำลังสองเดียวกันที่ดีกรีแสดงบนซ้ายและซ่อนบนขวา](square-root-degree.png)

ตัวอย่างบันทึกรากกำลังสองเดียวกันสองครั้ง ใน `visible-degree.pptx` ดีกรี 2 แสดงออกมา ส่วนใน `hidden-degree.pptx` ดีกรีถูกซ่อน

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

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัด ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit)

![ขีดจำกัดของ x เมื่อ x เก approaching ∞](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นอิลเมนต์ปัจจุบันแล้วเรียก [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) สำหรับการบวก, การรวม, การตัดกัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณตั้งค่าขีดจำกัดบนและล่างได้

![การบวกรวมที่มีขีดจำกัดบนและล่าง](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่อาจมีขีดจำกัด ตัวดำเนินการแบบง่ายเช่น `+`, `-`, `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) แล้วเชื่อมต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) เพื่อกำหนดแถวและคอลัมน์ เมทริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ ดังนั้นเมื่อต้องการวงเล็บ ปีกกา หรือวงเกลียวให้ใส่เมทริกซ์ไว้ในเครื่องหมายนั้นเอง

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

### **แก้ไขเมทริกซ์ที่มีอยู่**

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์สัมประสิทธิ์ใน `matrix.pptx` ซึ่งบันทึกโดยตัวอย่างก่อนหน้า สำหรับแบบฝึกหัดต่อไป ให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสองสมการใหม่, แล้วปรับชุดตัวแปร เปิดเมทริกซ์ที่มีอยู่ผ่าน [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) เพื่อคงค่าตัวค่าสัมประสิทธิ์ที่ยังใช้ได้

![เมทริกซ์สัมประสิทธิ์สองแถวดั้งเดิมที่มีค่า 1, x, และเซลล์ว่างในแถวแรก และ x, 2, y ในแถวสอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มจากศูนย์และอ้างอิงเมทริกซ์ตามสภาพในแต่ละครั้ง การแทรกแถวก่อนดัชนี 1 จะทำให้แถวที่สองเดิมย้ายไปเป็นดัชนี 2 การแทรกหลังดัชนี 2 จะเพิ่มแถวใหม่ การลบแถวที่ 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มเข้ามาขึ้นหนึ่งตำแหน่ง คอลัมน์ก็เปลี่ยนเช่นเดียวกัน

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

    // เซลล์ใหม่เริ่มต้นเป็น null. ตั้งค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน.
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

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) จัดแนวคอลัมน์แรกไปทางซ้าย [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) จัดแนวสามคอลัมน์ต่อเนื่องไปทางขวา เริ่มจากดัชนี 1 ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร สัมประสิทธิ์แรกแถว `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สาม

![เมทริกซ์สามแถวที่อัปเดตโดยมีแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือสแต็กแนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดตำแหน่งอาเรย์กับองค์ประกอบรอบข้าง**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาเรย์เทียบกับองค์ประกอบคณิตศาสตร์ที่อยู่ข้างๆ ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวตามแถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปนี้สร้างอาเรย์สามชุดที่เหมือนกัน ทั้งหมดมีสามแถวและมีองค์ประกอบข้างเคียง `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ฟอนต์ Cambria Math ขนาด 24 จุด มีเพียงการจัดแนวของอาเรย์ที่เปลี่ยน

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

การเปรียบเทียบต่อไปนี้แสดงการบันทึกไฟล์นำเสนอใน PowerPoint ให้สังเกตตำแหน่งของ `A=` และ `=B` ที่อยู่ข้างแต่ละอาเรย์

![อาเรย์สมการใน PowerPoint กับการจัดแนวบน, กลาง, และล่าง พร้อมองค์ประกอบข้างเคียงเดียวกัน](equation-array-alignment.png)

### **ตั้งค่าระยะห่างระหว่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์ [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎระยะห่างแบบเจาะจงและจะถูกเพิกเฉยหากใช้กฎที่กำหนดไว้ล่วงหน้า

สำหรับระยะห่างที่แม่นยำ ค่าจะวัดเป็นพอยต์ สำหรับระยะห่างแบบอัตราส่วน จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติเมื่อระบุค่าที่เจาะจง; การเปลี่ยนค่าเลขเดียวไม่ทำให้เลือกกฎระยะห่าง

ตัวอย่างต่อไปนี้บันทึกไฟล์นำเสนอห้าไฟล์ที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน สามไฟล์แรกใช้ค่าที่กำหนดไว้ล่วงหน้า สองไฟล์สุดท้ายแสดงค่าที่ตั้งเอง

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

ระยะห่างของแถวในอาเรย์แยกจากระยะห่างของย่อหน้า [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะห่างรอบย่อหน้าที่บรรจุอาเรย์ ไม่ได้เพิ่มระยะห่างระหว่างแถวของอาเรย์เช่นกัน เช่นเดียวกับ [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) ที่กำหนดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์เป็นอิลเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ที่นำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวขึ้นบรรทัดและตัวล่างบรรทัด**

ใช้ตัวช่วยสำหรับตัวล่างบรรทัดและตัวขึ้นบรรทัดสำหรับดัชนีและเลขยกกำลัง เมื่อดัชนีต้องอยู่ด้านซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![ตัวอักษร Y ตัวพิมพ์ใหญ่ที่มีดัชนีซ้าย 1 และเลขยกกำลัง n ด้านซ้าย](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวกำกับ**

ใช้ [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ไว้ในตัวกำกับ คุณยังสามารถตั้งค่าตัวอักษรคั่นสำหรับนิพจน์ที่มีหลายอิลเมนต์

![นิพจน์ตัวกำกับที่มี x, y, และ z คั่นด้วยเครื่องหมายเส้นแนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและจัดตำแหน่งตัวกำกับ**

ส่งค่า `true` ไปที่ [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามความสูงของอ็อบเจ็กต์ที่สูง; หรือส่ง `false` เพื่อคงขนาดเดิม ใช้ [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) พร้อมค่าหนึ่งจากสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) `Centered` ทำให้วงเล็บอยู่กึ่งกลางแกนคณิตศาสตร์ที่วิ่งผ่านเครื่องหมายเท่ากัน `Match` จัดให้วงเล็บสอดคล้องกับเนื้อหาที่ครอบไว้ ทั้งสองการตั้งค่ามีผลต่อเฉพาะตัวกำกับเท่านั้น ส่วนนิพจน์ภายในคงเดิม

ตัวอย่างวางเศษส่วนเป็นตัวกำลังของ `x` ทำให้นิพจน์ยืดออกเหนือเส้นฐานมากกว่าใต้เส้นฐาน ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย แถวบนวงเล็บจะขยายเพื่อครอบตัวกำลังและดูเหมือนกันสำหรับทั้งสองรูปแบบ แถวล่างการขยายถูกปิด วงเล็บเล็กด้านซ้าย (`Centered`) จัดกับเครื่องหมายเท่ากัน ส่วนด้านขวา (`Match`) อยู่สูงกว่าตรงเหนือนิพจน์

![สี่สมการใน PowerPoint ที่เปิด/ปิดการขยายตัวกำกับ และจัดตำแหน่ง Centered ทางซ้ายและ Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อใส่กรอบรอบนิพจน์ทั้งหมด [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) จะโชว์สี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านแต่ละด้าน

ตัวอย่างวางเศษส่วนเดียวกันหกสำเนาบนสไลด์เดียว เพื่อแสดงการยกเลิก ให้ซ่อนสี่ด้านและส่งค่า `true` ไปที่ [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อให้เส้นทแยงมุมขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อให้เส้นทแยงมุมลง (↘) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับการแสดงด้านใดด้านหนึ่งตามต้องการ

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นตัดแนวนอน, เส้นตัดแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นตัดแนวนอนทับบาร์ของเศษส่วน เส้นตัดแนวตั้งตัดทั้งตัวเศษและตัวส่วน ในขณะที่กรอบรอบข้างยังคงมองเห็นได้ เส้นเหล่านี้เป็นการตกแต่งนิพจน์ทั้งหมด ข้อความทั่วไปที่ใช้ strikethrough จะทำกับตัวอักษรในรันข้อความ หลังเปิดไฟล์นำเสนอใหม่ใน PowerPoint คุณยังสามารถแก้ไขตัวเศษและตัวส่วนแยกกันได้

## **ควบคุมการมองเห็นและการจัดวางด้วย Phantom Elements**

ห่อใส่นิพจน์ใน [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันทำให้สมการใช้ได้อย่างอิสระ เมธอดของ [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) ควบคุมดังต่อไปนี้

| เมธอด | ผล |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | ส่ง `false` เพื่อซ่อนนิพจน์ มิติของมันยังคงมีผลต่อการจัดวางเว้นแต่เมธอดต่อไปนี้รับ `true` |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | ถือความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้อิลเมนต์ข้างเคียงยืดเข้ามาใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | ถือค่า ascent (ความสูงเหนือ baseline) ของนิพจน์เป็นศูนย์ สามารถลดช่องว่างด้านบนของอิลเมนต์ใกล้เคียง |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | ถือค่า descent (ความลึกใต้ baseline) ของนิพจน์เป็นศูนย์ สามารถทำให้บาร์ของเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์อยู่ใกล้กันขึ้น |

Baseline คือเส้นอ้างอิงที่ตัวอักษรคณิตศาสตร์ปกติพักอยู่ การซ่อนเนื้อหาไม่ลบมิติของมัน และการถือมิติเป็นศูนย์ไม่ลบนิพจน์ออก นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) ส่ง `true` ไปที่ [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง มิติที่ตั้งค่าไว้จะคงเดิม

ตัวอย่างด้านล่างสร้างห้าตัวแปรข้างเคียงกัน: เศษส่วนที่มองเห็นได้, เศษส่วนที่ซ่อนแต่ยังจองพื้นที่, และสามเศษส่วนที่ซ่อนโดยตั้งค่าแต่ละมิติเป็นศูนย์ แต่ละแบบใช้นิพจน์รอบข้างเดียวกันและฟอนต์ Cambria Math ขนาด 24 จุด ทุกรูปร่างสมการมีตำแหน่งบนเท่ากันโดยมีไกด์สีเทาลากไว้ การวาง Phantom ในตัวเศษของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งดูง่ายขึ้น

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

![ห้าสมการใน PowerPoint ที่เปรียบเทียบบรรทัดที่มองเห็นได้, บรรทัดที่ซ่อนแต่ยังจองพื้นที่, และบรรทัดที่ซ่อนพร้อม ZeroWidth, ZeroAsc, หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือต่ำกว่านิพจน์ แล้วเพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อทำให้สูตรเข้าใจง่าย ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) ใส่บาร์เหนืออิลเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีบาร์เหนือ](powerpoint-math-equations_14.png)

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

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่ ให้วนรอบต้นไม้ของอิลเมนต์ในแต่ละ MathBlock [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) จะคืนค่าเด็กระดับแรกเท่านั้น ดังนั้นจึงต้องเรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความในเศษส่วน, สคริปต์, ราดิกัล และโครงสร้างที่ซ้อนกันอื่น ๆ ตรวจสอบอิลเมนต์ปัจจุบันพร้อมกับลูกของมันเพื่อรวมอิลเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` ซึ่งเศษส่วนมีตัวล่างในตัวเศษและราดิกัลในตัวส่วน การประมวลผลเฉพาะอิลเมนต์ระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหาส่วนคณิตศาสตร์ในกรอบข้อความของสไลด์ เข้าถึงบล็อกผ่าน [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งขนาดฟอนต์เป็น 28 จุดผ่านเมธอด [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละอิลเมนต์ข้อความ

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

ไฟล์นำเสนอที่บันทึกจะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล ขณะเดียวกันยังคงรักษาเนื้อหาข้อความและโครงสร้างคณิตศาสตร์ไว้

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| รวมอิลเมนต์ | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| สร้างเศษส่วน | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวล่างบรรทัดหรือสูงบรรทัด | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มราดิกัล | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มการบวกรวมและอินทิกรัล | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวกำกับ | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้. เปิดไฟล์นำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) แล้วอัปเดต MathBlock ใน Paragraph นั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้. รับ [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) แล้วเรียก [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง ตัวอย่างเต็มดูได้ที่ [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/#export-math-equations-to-latex)