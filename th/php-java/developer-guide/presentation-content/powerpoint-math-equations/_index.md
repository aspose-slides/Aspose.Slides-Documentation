---
title: เพิ่มสมการคณิตศาสตร์ลงในงานนำเสนอ PowerPoint ด้วย PHP
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
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด PHP ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันด้วยโปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็กรูปแบบแทรกของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), เป็นรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) และวิธีเชื่อมต่อจาก [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) เพื่อทำให้โค้ดสั้นและอ่านง่าย.

สำหรับสถานการณ์การส่งออก MathML ดูที่ [ส่งออกสมการ Math จากการนำเสนอใน PHP ผ่าน Java](/slides/th/php-java/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทาโกรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) แรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), และเพิ่ม math blocks หรือ math elements ลงในนั้น.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![เศษส่วนคณิตศาสตร์เอียงที่แสดง 1 หาร x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนกัน, ใช้ [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ. องค์ประกอบปัจจุบันจะเป็นฐานและอากิวเมนต์จะเป็นดีกรี.

![นิพจน์รากที่ n โดยมี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขอบเขต**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขอบเขต, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![ขอบเขตของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) พร้อมอากิวเมนต์ของมัน:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) สำหรับผลบวก, ยูเนียน, อินเตอร์เซกชัน และตัวดำเนินการขนาดใหญ่อื่น ๆ. ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล. ทั้งสองวิธีให้คุณตั้งขอบเขตล่างและบน.

![ผลบวกพร้อมขอบเขตล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขอบเขตเป็นตัวเลือก. ตัวดำเนินการพื้นฐานเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) และเชื่อมต่อเข้ากับนิพจน์.

สำหรับอินทิกรัล, ใช้ [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์. โดยปริยายเมทริกซ์ไม่มีวงเล็บ, ดังนั้นให้ล้อมเมทริกซ์ด้วยวงเล็บ, ก้อนวงเล็บเหลี่ยม หรือวงเล็บโค้งเมื่อจำเป็น.

![เมทริกซ์คณิตศาสตร์สองแถวที่มีช่องว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือสแต็กแนวตั้งของนิพจน์.

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

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออากิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

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

## **เพิ่มตัวล่างและตัวบน**

ใช้ตัวช่วย subscript และ superscript สำหรับดัชนีและกำลัง. เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน, ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![อักษร Y ตัวพิมพ์ใหญ่ที่มี subscript 1 ด้านซ้ายและ superscript n ด้านบน](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่ง**

ใช้ [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ภายในตัวแบ่ง. คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบ.

![นิพจน์ตัวแบ่งที่มี x, y, และ z แยกด้วยเส้นตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดตำแหน่งตัวแบ่ง**

Pass `true` to [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายรอบตัวดำเนินการที่สูง, หรือส่ง `false` เพื่อคงขนาดปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) กับหนึ่งในสองค่า [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` จัดกลางวงเล็บบนแกนคณิตศาสตร์, ซึ่งผ่านกลางเครื่องหมายเท่ากับ. `Match` จัดให้ตรงกับเนื้อหาที่ล้อม. ทั้งสองการตั้งค่าส่งผลต่อเพียงตัวแบ่ง. นิพจน์ภายในคงเดิม.

ตัวอย่างวางเศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ยืดออกเหนือ baseline มากกว่าด้านล่าง. สมการสี่ตัวใช้วงเล็บและการตั้งค่าแบบอักษรเดียวกัน.

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

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. ในแถวบน, วงเล็บขยายเพื่อคลุมเลขชี้กำลังและดูเหมือนกันสำหรับรูปแบบทั้งสอง. ในแถวล่าง, การขยายปิด. วงเล็บที่เล็กกว่าด้านซ้าย (`Centered`) จัดกับเครื่องหมายเท่ากับ, ขณะที่ด้านขวา (`Match`) อยู่สูงกว่ารอบนิพจน์.

![สี่สมการใน PowerPoint ที่เปิดการขยายตัวแบ่งด้านบนและปิดด้านล่าง, โดยด้านซ้ายใช้ Centered และด้านขวาใช้ Match](delimiter-sizing.png)

## **เพิ่มกล่องกรอบ**

Call [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) on a fraction to frame the entire expression. The returned [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) shows all four sides by default. Use [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), and [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) to remove individual sides.

The example places six copies of the same fraction on one slide. To show cancellation, hide all four sides and pass `true` to [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) for a rising diagonal (↗) or [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) for a falling diagonal (↘). You can also use [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) or [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) with any combination of visible sides.

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นขวาง, เส้นแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้, เส้นขวางแนวนอนทับบาร์ของเศษส่วน. เส้นขวางแนวตั้งตัดผ่านตัวเศษและตัวส่วนในขณะเดียวกันกับกรอบที่ยังคงมองเห็นได้. เส้นเหล่านี้ตกแต่งทั้งนิพจน์. การขีดเส้นกลางข้อความทั่วไปใช้กับตัวอักษรในรันข้อความ. หลังจากเปิดไฟล์นำเสนอใน PowerPoint อีกครั้ง, คุณยังสามารถแก้ไขตัวเศษและตัวส่วนแยกกันได้.

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขอบเขตเพื่อระบุชื่อกลุ่มเทอม.

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

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) วางบาร์เหนือองค์ประกอบคณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC พร้อมเส้นบาร์ด้านบน](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่, ให้เดินทางผ่านต้นไม้ของแต่ละ math block. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) คืนค่าเฉพาะลูกโดยตรง, ดังนั้นให้เรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, ตัวสคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, โดยมีเศษส่วนที่มี subscript ในนิพจน์เศษและรากในส่วนของส่วน. การประมวลผลเฉพาะองค์ประกอบระดับบนของบล็อกจะพลาดข้อความในเศษส่วน. ตัวอย่างนี้ค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งขนาดฟอนต์เป็น 28 pt ผ่านเมธอด [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละองค์ประกอบข้อความ.

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

การบันทึกนำเสนอจะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมยังคงรักษาเนื้อหาข้อความและโครงสร้างคณิตศาสตร์ไว้.

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| สร้างเศษส่วน | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มซูเปอร์สคริปต์หรือซับสคริปต์ | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มขอบเขต | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวแบ่ง | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้. เปิดการนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), และอัปเดต math blocks ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ได้. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้. รับ [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), แล้วเรียก [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) เพียงแค่ส่งออกโดยตรง. ตัวอย่างเต็มดูที่ [ส่งออกสมการ Math จากการนำเสนอใน PHP ผ่าน Java](/slides/th/php-java/exporting-math-equations/#export-math-equations-to-latex).