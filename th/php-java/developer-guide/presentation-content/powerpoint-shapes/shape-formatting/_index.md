---
title: จัดรูปแบบรูปร่าง PowerPoint ใน PHP
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/php-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่ระดับ
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- การหมุนรูปร่าง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน PHP ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint ด้วยการปรับเส้นขอบ การเติมสี และเอฟเฟกต์ Aspose.Slides for PHP via Java ช่วยให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโค้ด โปรแกรมได้ รวมถึงความโปร่งแสง การหมุน และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java มีคลาสและเมธอดที่ให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมที่ไม่มีการเติมสีโดยมีเส้นขอบสีฟ้าทำเป็นจุดขาด [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) เพื่อเลือกเส้นแบบ compound หนา-บาง ในขณะที่ [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) ตั้งความกว้างเป็น 7 pt และ [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบการขีดเส้น

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **กำหนดรูปแบบการขีดเส้นแบบกำหนดเอง**

ใช้ [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ตรงกับความยาวและช่องว่างที่ต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนผังเทคนิค การกำหนดรูปแบบจะทำให้สไตล์การขีดเส้นเปลี่ยนเป็น [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)

ค่าตัวอาเรย์สลับระหว่างความยาวของเส้นและช่องว่าง เริ่มจากเส้นแต่ละค่าคูณด้วยความกว้างของเส้น: `[4, 2]` ที่ความกว้าง 3 pt จะได้เส้น 12 pt ตามด้วยช่องว่าง 6 pt ใช้คู่ของค่าที่เป็นจำนวนเต็มไม่เป็นลบเพื่อกำหนดส่วนของเส้นและช่องว่าง ตัวอย่างนี้ใช้ค่าบวกเพื่อให้เส้นและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีฟ้า 5 เส้นที่มีความยาวเท่ากันและหัวเส้นแบน เส้นสามแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 pt เส้นที่สี่ทำซ้ำรูปแบบแรกที่ความกว้างสองเท่า ทำให้เส้นและช่องว่างยาวสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทsolid

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // คืนเส้นสุดท้ายให้เป็นสไตล์เส้นแบบ Solid.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะกำหนดลักษณะการแสดงของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![สามรูปแบบการขีดเส้นกำหนดเอง เส้นกว้างกว่าใช้รูปแบบแรก และเส้นทsolid ใน PowerPoint](custom-dash-patterns.png)

### **กำหนดหัวเส้น**

ใช้ [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) เพื่อกำหนดส่วนปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) มีสามสไตล์หัวเส้นที่ชัดเจน:

- `Flat`: เส้นหยุดที่จุดสิ้นสุด
- `Round`: หัวเส้นกึ่งวงกลมยืดออกไปนอกจุดสิ้นสุดเท่ากับครึ่งความกว้างของเส้น
- `Square`: หัวเส้นสี่เหลี่ยมยืดออกไปนอกจุดสิ้นสุดเท่ากับครึ่งความกว้างของเส้น

คลาสยังมี `NotDefined` ซึ่งหมายความว่าไม่มีการกำหนดหัวเส้นแบบชัดเจน

หัวเส้นจะแตกต่างจากลูกศรซึ่งเพิ่มสัญลักษณ์ที่ปลายเส้น และการเชื่อมต่อ (joins) ซึ่งควบคุมมุมที่เส้นต่อกัน ตัวอย่างนี้ปิดการใช้งานลูกศรด้วย [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปหัวเส้น

ตัวอย่างต่อไปสร้างเส้นแนวนอนสามเส้นที่เหมือนกัน ความกว้าง 20 pt จากบนลงล่างใช้หัวเส้น Flat, Round, และ Square ตามลำดับ จุดสิ้นสุดของเส้นมีพิกัดแนวนอนเท่ากัน แต่หัว Round และ Square ยืดออกไปนอกจุดสิ้นสุด 10 pt

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**

![หัวเส้น Flat, Round, และ Square บนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์บนเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดไว้โดยตรง และลบเอฟเฟกต์ด้วย [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

ค่าที่คืนมาจาก [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปร่าง หากการจัดรูปแบบเส้นถูกสืบทอดจากธีม สไลด์มาสเตอร์ หรือสไลด์เลเอาต์ ให้ใช้ [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) แล้วเข้าถึงเมธอด `getSketchFormat` ของออบเจกต์ที่คืนค่าและอ่านค่าของ `getSketchType` ค่าที่ได้จะแสดงการจัดรูปแบบที่ใช้งานจริงหลังจากการสืบทอดถูกประมวลผล ตัวอย่างนี้ต้องการงานนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ (Join Styles)**

นี่คือสามตัวเลือกชนิดการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าตำแหน่งขอบสองส่วนมาบรรจบกันอย่างไร ที่มุมใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามรูปโดยมีเส้นขอบสีน้ำเงินกว้าง 15 pt ตั้งค่า [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) เป็นค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบการวาดมุม

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **จำกัดมิตเตอร์ที่มุมแหลม**

ใช้ [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) ร่วมกับ [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ที่ตั้งเป็น [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) เพื่อจำกัดความยาวของมิตเตอร์

ค่าจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตเตอร์สูงสุดเจ็ดเท่าของความกว้างของเส้น; ค่านี้ไม่ใช่หน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่กว่าอนุญาตให้จุดแหลมมากขึ้น การตั้งค่านี้มีผลเฉพาะกับการเชื่อมต่อแบบมิตเตอร์เท่านั้น และการเปลี่ยนแปลงจะไม่ปรากฏหากมุมยังคงอยู่ในขอบเขตทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมที่ไม่มีการเติมสีสองรูปที่เหมือนกัน เส้นขอบกว้าง 20 pt สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 pt สูง 160 pt ทำให้สัดส่วนความยาวมิตเตอร์ต่อความกว้างของเส้นประมาณ `4.12` ส่งผลให้ PowerPoint ทำ bevel ที่ยอดซ้ายและคงสภาพมิตเตอร์ที่ยอดขวา

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา

![ยอดที่ bevel ด้วยมิตเตอร์ลิมิต 2 และยอดที่แหลมด้วยมิตเตอร์ลิมิต 8 ใน PowerPoint](miter-limits.png)

## **การเติมสีไล่ระดับ (Gradient Fill)**

การเติมสีไล่ระดับผสมสีทั่วทั้งรูปร่าง ตัวอย่างนี้เติมรูปวงรีด้วยไล่ระดับเชิงเส้นที่มุม 45 องศา จากสีแดงไปสีม่วงโดยใช้ [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) วิธี [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) จะวางจุดหยุดสีที่ 0 และ 1 (จุดเริ่มและจุดสิ้นของไล่ระดับ) การล้างจุดหยุดที่มีอยู่ทำให้ใช้สีเพียงสองสีนี้เท่านั้น

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมสีไล่ระดับ](gradient-fill.png)

หากไล่ระดับดูต่างกันในภาพที่ส่งออกกับใน PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนไล่ระดับที่เก็บไว้ในงานนำเสนอ

### **ตั้งมุมไล่ระดับเชิงเส้น**

ใช้ [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมทิศทางของการเติม [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน มุมที่เป็นเศษส่วนก็รองรับ มุมที่อยู่นอกช่วง `[0, 360)` จะถูกปรับให้เป็นการหมุนหนึ่งรอบ เช่น `-45` จะกลายเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีจุดสีแดง เขียว น้ำเงินเดียวกันที่ตำแหน่ง `0`, `0.5`, และ `1` ปิดการสเกลเพื่อให้มุมเปรียบเทียบได้โดยไม่ขึ้นกับสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ใน PowerPoint:

![ไล่ระดับเชิงเส้นที่ 0°, 45°, 90° ในแถวบนและ 135°, 180°, 270° ในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่ระดับเชิงเส้นตามรูปร่าง**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) ตั้งค่าเป็น `False` เพื่อคงมุมไล่ระดับเชิงเรขาคณิตขณะรูปร่างเปลี่ยนสัดส่วน หรือตั้งเป็น `True` เพื่อสเกลไล่ระดับตามความกว้างและความสูงของรูปร่าง เมื่อสเกลเปิดใช้งาน มุมที่มองเห็นอาจต่างจากมุมที่กำหนดไว้บนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปใช้มุม `45` องศาและจุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งเป็น `False` คอลัมน์ขวาตั้งเป็น `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างอยู่ด้านบนและสี่เหลี่ยมสูงอยู่ด้านล่าง ทั้งสองเริ่มด้วยขนาดกว้างเท่ากัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่ระดับ

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ใน PowerPoint โดยซ้ายสเกลปิดและขวาเปิด:

![สี่เหลี่ยมกว้างและสูงที่มีไล่ระดับ 45° เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อสเกลปิดแถบสีแนวทแยงมุมคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อสเกลเปิดแถบสีจะยืดตามสัดส่วนของรูปร่าง นี้ช่วยให้คัดลอกไล่ระดับของเทมเพลตเมื่อปรับขนาดรูปร่างให้ต่างกัน หากเป็นสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่ระดับ `45` องศานี้

ค่ามุมและสเกลทั้งสองใช้กับไล่ระดับเชิงเส้นและไม่ได้ควบคุมการเติมสี [GradientShape::Radial หรือ GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/)

### **ผสานมุมกับทิศทางไล่ระดับ**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) เลือกสไตล์ไล่ระดับจากคลาส [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) ซึ่งไม่ใช่การทดแทนมุมเชิงตัวเลข สำหรับไล่ระดับเชิงเส้น ทิศทางมุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) ให้คงทิศทางเดิมเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปใช้การตั้งค่าเดียวกันแต่สั่งเรียงลำดับตรงกันข้าม สี่เหลี่ยมสองรูปจะแสดงผลเหมือนกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **การเติมลวดลาย (Pattern Fill)**

การเติมลวดลายใช้การออกแบบสองสี เช่น จุด, ลายเส้น, หรือเช็ค ตัวอย่างนี้ใช้ [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) เพื่อเลือกลายตาข่าย [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) ให้พื้นหลังสีเทาอ่อน และ [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) ให้สีเหลืองของลาย

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลวดลาย](pattern-fill.png)

## **การเติมรูปภาพ (Picture Fill)**

การเติมรูปภาพใช้ภาพภายในรูปร่าง ตัวอย่างนี้ต้องการภาพจากไฟล์ท้องถิ่นและใช้ [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าไปในคอลเลกชันภาพของงานนำเสนอ การตั้งค่า [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมด tiled จะทำให้ภาพซ้ำภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปภาพดอกบัว](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **ตั้งภาพต่อ (Tile) เป็นพื้นผิว (Texture)**

หากต้องการตั้งภาพต่อเป็นพื้นผิวและกำหนดพฤติกรรมการต่อ สามารถใช้เมธอดต่อไปของคลาส [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมภาพ — `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดวางแผ่นต่อภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่าภาพต่อจะพลิกแนวนอน แนวตั้ง หรือทั้งสอง
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดการเยื้องแนวนอนของแผ่นต่อ (เป็น pt) จากจุดเริ่มต้นของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดการเยื้องแนวตั้งของแผ่นต่อ (เป็น pt) จากจุดเริ่มต้นของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของแผ่นต่อเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของแผ่นต่อเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการภาพจากไฟล์ท้องถิ่นและกำหนดให้ [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) ทำซ้ำที่ขนาด 50% ของขนาดดั้งเดิม การเยื้อง `-32` pt จะย้ายแผ่นต่อแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกทั้งสองทิศกำหนดวิธีการจัดเรียงพื้นผิวที่ทำซ้ำ

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการต่อภาพ](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบทำให้รูปร่างมีสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) เป็นโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) แล้วบันทึกสี่เหลี่ยมลงในงานนำเสนอ

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

### **คัดลอกสีพร้อมคงอ้างอิงธีม**

ใช้ [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) เพื่อคัดลอกค่าสีรวมถึงชนิดสี, การอ้างอิงธีม, และการแปลงค่า ซึ่งมีประโยชน์เมื่อต้องถ่ายโอนสีเติมระหว่างรูปร่างที่ควรยังคงตามธีมของงานนำเสนอ เมธอดจะคัดลอกเฉพาะสีไม่รวมประเภทการเติม, เส้นขอบ หรือการจัดรูปแบบอื่น ๆ ตั้งค่าชนิดการเติมของปลายทางโดยใช้ [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) อย่างชัดเจน

ตัวอย่างนี้สร้างสี่เหลี่ยมสามรูปจากซ้ายไปขวา: แหล่งที่มา, คัดลอกที่คำนึงถึงธีม, และคัดลอกเป็น RGB คงที่ แหล่งที่ใช้ [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) เพื่ออ้างอิงสี Accent แรกและเพิ่ม tint ด้วย [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add) คัดลอกเป็น RGB ใช้สีเติมที่มีผลจริงของแหล่งที่มา ทำให้สามรูปแรกดูเหมือนกันทั้งหมด การเรียก [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) จะตั้งค่า RGB คงที่และเคลียร์การแปลงสีใด ๆ ที่มีอยู่

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // การอ้างอิงธีมตามสี Accent ใหม่; ค่ RGB คงที่ไม่ตาม.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ก่อนเปลี่ยนธีม ทั้งสามการเติมสีจะตรงกัน:

![แหล่งที่มา, ปลายทาง copyFrom, และปลายทาง RGB คงที่ที่มีสีสีน้ำเงินเหมือนกัน](color-copy-before.png)

หลังเปลี่ยนธีม แหล่งที่มาและคัดลอกที่คำนึงถึงธีมจะตามสี Accent ใหม่และคง tint ไว้ ส่วนคัดลอก RGB คงที่ยังคงเป็นสีน้ำเงิน:

![แหล่งที่มาและ copyFrom ที่มีสีส้ม ส่วน RGB คงที่ยังคงเป็นสีน้ำเงิน](color-copy-after.png)

คำนิยามที่คัดลอกเป็นอิสระจากแหล่งที่มา การเปลี่ยนแปลงธีมของแหล่งที่มา การกำหนดสีใหม่ หรือการเพิ่ม/ลบการแปลงจะไม่ส่งผลต่อปลายทาง ธีมที่เปลี่ยนยังคงส่งผลต่อทั้งสองรูปร่างเพราะแต่ละอันอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX อีกครั้งจะคงชนิดสีที่คัดลอกโดย [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), การอ้างอิงธีม, และคอลเลกชันการแปลงที่คืนจาก [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform) ไม่ได้แปลงเป็น RGB

เมื่อคัดลอกจากบริบทธีมที่ต่างกัน เช่น งานนำเสนอที่มีพาเล็ตต์ Accent ต่างกัน การอ้างอิงที่คัดลอกจะอ้างอิงตามธีมของปลายทาง ดังนั้นอาจทำให้สีที่มองเห็นต่างกัน ดูที่ [Presentation Theme](/slides/th/php-java/presentation-theme/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการกำหนดธีมสี

## **ใช้พื้นหลังสไลด์เป็นการเติมสีของรูปร่าง**

ใช้ [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ เช่น ในเทมเพลตงานนำเสนอ ตั้งค่าชนิดการเติมด้วย [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) ไปเป็น [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมที่กำหนดโดยตรงออก ด้วยการผสมผสานนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมที่กำหนดเอง การเปิดใช้งานฟล็ากนี้อย่างเดียวไม่ลบการเติมที่มีอยู่

ซึ่งต่างจาก [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) : การเติมพื้นหลังจะครอบออบเจกต์ที่อยู่ด้านหลังรูปร่างด้วยพื้นหลังสไลด์ในพื้นที่ที่สอดคล้องในขณะที่ NoFill ทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่ระดับจะยังคงจัดแนวตามสไลด์แทนการเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปสร้างพื้นหลังมาสเตอร์ที่สืบทอดโดยสไลด์และวางแถบสีมะโกมอยู่ด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, กลางไม่มีการเติม, ขวาเปลี่ยนจากพื้นหลังเป็นการเติมสีส้มโดยชัดเจน

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // สืบทอดไล่ระดับจากมาสเตอร์.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // เพิ่มวัตถุนี้ก่อนเพื่อให้ปรากฏอยู่ด้านหลังสี่เหลี่ยม.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // ปิดการเติมพื้นหลังก่อนกำหนดการเติมแบบชัดเจน.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมแบบชัดเจน** แถบสีมะโกมถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มชัดเจนบนแถบสีมะโกม](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลเอาต์ รูปร่างจะใช้พื้นหลังที่ได้รับการคำนวณของสไลด์; ตัวอย่างนี้ไม่ได้กำหนดพื้นหลังของสไลด์และเลเอาต์เพื่อให้มาสเตอร์จัดหามา

## **ตั้งค่าความโปร่งแสง**

สำหรับการเติมสีทึบ ค่าคอมโพเนนต์ alpha ของสีกำหนดความทึบ: 0 = โปร่งใสเต็ม, 255 = ทึบเต็ม ตัวอย่างนี้ใช้ค่า alpha 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมใต้เห็นได้ สีถูกกำหนดผ่าน [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor)

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปร่างในแนวระนาบของสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

ใช้ [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) เพื่อให้รูปร่างมีความลึกและขอบ bevel ตัวอย่างนี้สร้างวงรีสีเขียวกับเส้นขอบสีส้ม ตั้งค่า [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) เป็น 4 pt และใช้ bevel ด้านบนแบบวงกลมที่กว้างและสูง 6 pt ผ่าน [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) กล้องมุมมองออร์โธกราฟิกหน้าตรงและแสงสามจุดทำให้ bevel มองเห็นได้

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์ 3D bevel](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างควบคุมด้วยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) โดยตั้งค่ามุม latitude, longitude, และ revolution เป็น 40°, 35°, และ 20° ตามลำดับ เลือกกล้องแบบ isometric ด้วย [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) และแสงแบบ balanced ด้วย [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์ขาว‑ดำสำหรับรูปร่าง**

เมธอด [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปร่างแต่ละอันจะแสดงผลอย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว‑ดำ ไม่ได้เปิดการแสดงผลขาว‑ดำเองและไม่ได้เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่น ๆ ในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ เช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับเป็นสีเดียว, `Color` คงสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดขาว‑ดำ, `NotDefined` หมายความว่าไม่ได้กำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและตั้งค่า [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) เป็น `Gray` สี่เหลี่ยมที่บันทึกจะคงสีส้มสำหรับการแสดงสีปกติและขอสีเทาเมื่อแอปพลิเคชันเคารพการตั้งค่าแสดงผลขาว‑ดำ

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ในโหมดสีปกติสี่เหลี่ยมคงสีส้มไว้ ในเวิร์กโฟลว์แสดงผลขาว‑ดำจะใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray` นี้ช่วยให้คุณเก็บสไลด์สีเต็มในขณะที่กำหนดลักษณะเฉพาะสำหรับการพิมพ์, พรีวิว หรือเวิร์กโฟลว์อื่น ๆ ที่เคารพการตั้งค่าแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) เพื่อคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวยึดตำแหน่งบนสไลด์จากตัวยึดตำแหน่งของเลเอาต์ที่สอดคล้อง ตัวอย่างนี้ต้องการงานนำเสนอที่มีตัวยึดตำแหน่งเชื่อมโยงกับเลเอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตัวยึดตำแหน่งในเลเอาต์จะไม่ถูกรีเซ็ต

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังไว้ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง — การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่ารูปร่างมีสไตล์เหมือนกันและจัดกลุ่มเชิงตรรกะ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์ .POTX จากนั้นเมื่อต้องสร้างงานนำเสนอใหม่ เปิดเทมเพลต, คัดลอกรูปร่างที่ต้องการ, และนำการจัดรูปแบบไปใช้ใหม่ตามต้องการ