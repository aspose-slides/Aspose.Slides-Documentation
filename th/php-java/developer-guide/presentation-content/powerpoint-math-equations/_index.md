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
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด PHP ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันโดยโปรแกรมได้ ได้แก่ เศษส่วน ราก นิพจน์ ฟังก์ชัน ขีดจำกัด ตัวดำเนินการ N‑ary เมทริกซ์ อาร์เรย์ และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปจะเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามวัตถุหลัก:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addMathShape) คือรูปที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตย์ภายในกรอบข้อความของรูป
- [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) ประกอบด้วยหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathematicaltext/) และเมธอด fluent จาก [MathElementBase](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ให้ดูที่ [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้สร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทาโกรัส:

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

{{% alert color="primary" %}}
`addMathShape` สร้างรูปที่มี MathParagraph อยู่แล้ว เข้าถึง `MathPortion` ตัวแรก, รับ `MathParagraph` ของมัน, และเพิ่ม MathBlock หรือ MathElement เข้าไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [`divide`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathfractiontypes/)

![เศษส่วนเอียงที่แสดง 1 หาร x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อน ให้ใช้ `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **เพิ่มราก**

ใช้ [`radical`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เพื่อสร้างรากกำลังสอง รากกำลังสาม หรือรากอื่น ๆ องค์ประกอบปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์ราก n‑th ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [`asArgumentOfFunction`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) หรือ [`function`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัด ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathlimit/) หรือใช้ [`setLowerLimit`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/)

![ขีดจำกัดของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบัน:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [`nary`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [`integral`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) สำหรับอินทิกรัล ทั้งสองเมธอดอนุญาตให้ตั้งขีดจำกัดล่างและบน

![ผลบวกพร้อมขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary เป็นตัวดำเนินการใหญ่ที่มีขีดจำกัดเลือกได้ ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` ปกติจัดเป็น `MathematicalText` แล้วต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathmatrix/) เพื่อกำหนดแถวและคอลัมน์ เมทริกซ์โดยปกติจะไม่มีวงเล็บ จึงต้องใส่วงเล็บหรือวงเกลียวตามต้องการ

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งเซลล์](powerpoint-math-equations_10.png)

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

ใช้ [`toMathArray`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เมื่อคุณต้องการสมการที่จัดแนวหรือการจัดเรียงแนวตั้งของนิพจน์

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

ใช้ [`asArgumentOfFunction`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

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

## **เพิ่มตัวห้อยและตัวห้อยบน**

ใช้ตัวช่วยสำหรับตัวห้อยและตัวห้อยบนสำหรับดัชนีและกำลัง เมื่อดัชนีต้องปรากฏด้านซ้ายของฐาน ให้ใช้ [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/)

![ตัว Y ตัวใหญ่ที่มีตัวห้อยซ้าย 1 และตัวห้อยบน n](powerpoint-math-equations_9.png)

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

## **เพิ่มเครื่องหมายกำกับ**

ใช้ [`enclose`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เพื่อใส่นิพจน์ไว้ในเครื่องหมายกำกับ คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบได้

![นิพจน์เครื่องหมายกำกับที่มี x, y, และ z คั่นด้วยเส้นแนวตั้ง](powerpoint-math-equations_13.png)

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

## **เพิ่มกล่องขอบ**

ใช้ [`toBorderBox`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เมื่อสมการควรอยู่ในกรอบ

![สมการในกรอบที่แสดง a กำลังสองเท่ากับ b กำลังสองบวก c กำลังสอง](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **จัดกลุ่มเทอม**

ใช้ [`group`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) เพื่อวางอักขระการจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายกำกับข้อความใด ๆ ด้านล่าง](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน เช่น [`overbar`](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) จะใส่เส้นเหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นเหนือ](powerpoint-math-equations_14.png)

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

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [join](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| สร้างเศษส่วน | [divide](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวห้อยบนหรือด้านล่าง | [setSuperscript](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเครื่องหมายกำกับ | [enclose](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| เพิ่มเส้นเหนือและกรอบ | [overbar](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ คุณเพียงเปิดงานนำเสนอ ค้นหารูปร่างที่มี `MathPortion` รับ `MathParagraph` ของมัน และอัปเดต MathBlock ภายในพารากราฟนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ของ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่สามารถแก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้ ให้ดึง [MathParagraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathportion/) แล้วเรียก [MathParagraph::toLatex](https://reference.aspose.com/slides/th/php-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง สำหรับตัวอย่างเต็มดูที่ [Export Math Equations from Presentations in PHP via Java](/slides/th/php-java/exporting-math-equations/#export-math-equations-to-latex)