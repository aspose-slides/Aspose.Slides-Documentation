---
title: "จัดรูปแบบรูปทรง PowerPoint ใน PHP"
linktitle: "การจัดรูปแบบรูปทรง"
type: docs
weight: 20
url: /th/php-java/shape-formatting/
keywords:
- "จัดรูปแบบรูปทรง"
- "จัดรูปแบบเส้น"
- "เอฟเฟกต์สเก็ตช์"
- "เส้นรูปทรงสเก็ตช์"
- "จัดรูปแบบสไตล์การเชื่อมต่อ"
- "การเติมสีไล่ระดับ"
- "การเติมแบบลาย"
- "การเติมภาพ"
- "การเติมเท็กซ์เจอร์"
- "การเติมสีทึบ"
- "ความโปร่งใสของรูปทรง"
- "การเรนเดอร์รูปทรงสีขาว‑ดำ"
- "การเรนเดอร์รูปทรงระดับสีเทา"
- "หมุนรูปทรง"
- "เอฟเฟกต์ Bevel 3 มิติ"
- "เอฟเฟกต์การหมุน 3 มิติ"
- "รีเซ็ตการจัดรูปแบบ"
- "PowerPoint"
- "การนำเสนอ"
- "PHP"
- "Aspose.Slides"
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน PHP ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปทรงใน PowerPoint โดยปรับแต่งเส้นขอบ การเติมสี และเอฟเฟกต์ Aspose.Slides สำหรับ PHP ผ่าน Java ช่วยให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งใส การหมุน และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปทรงใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ PHP ผ่าน Java มีคลาสและเมธอดที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปทรง ตัวอย่างนี้สร้างสี่เหลี่ยมไม่มีการเติมสีที่มีเส้นขอบสีน้ำเงินแบบเส้นประ [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) เลือกเส้นผสมหนา-บาง, ขณะที่ [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) ตั้งความกว้างเป็น 7 พอยต์และ [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบเส้นประ

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

### **ตั้งค่ารูปแบบเส้นประแบบกำหนดเอง**

ใช้ [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อลักษณะเส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างของเส้นประที่คุณต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือภาพแผนผังเชิงเทคนิค การกำหนดลวดลายจะเปลี่ยนสไตล์เส้นประโดยอัตโนมัติเป็น [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)

รายการในอาร์เรย์สลับระหว่างความยาวของเส้นประและช่องว่างโดยเริ่มจากเส้นประ แต่ละค่าเป็นหลายเท่าของความกว้างของเส้น: `[4, 2]` ที่ความกว้าง 3 พอยต์จะให้เส้นประ 12 พอยต์ตามด้วยช่องว่าง 6 พอยต์ ใช้คู่ของค่าจำนวนเต็มที่ไม่เป็นลบเพื่อกำหนดส่วนของเส้นประและช่องว่างอย่างครบถ้วน ตัวอย่างใช้ค่าบวกเพื่อให้เส้นประและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวเท่ากันและปลายเส้นแบบแบน เส้นสามแรกเปรียบเทียบลวดลายที่ความกว้าง 3 พอยต์ เส้นที่สี่ทำซ้ำลวดลายแรกที่ความกว้างสองเท่า เพิ่มความยาวของเส้นประและช่องว่างเป็นสองเท่า เส้นที่ห้าสลับจากลวดลายกำหนดเองเป็นเส้นทึบ

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

    // คืนเส้นสุดท้ายเป็นสไตล์เส้นทึบ.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่ง [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามรูปแบบเส้นประกำหนดเอง, เส้นที่กว้างกว่าโดยใช้รูปแบบแรก, และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าปลายเส้น**

ใช้ [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) เพื่อตั้งค่าปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) มีสไตล์ปลายเส้นที่ชัดเจนสามแบบ:

- `Flat`: เส้นหยุดที่จุดสิ้นสุด.
- `Round`: ปลายเส้นกึ่งวงกลมยืดออกนอกจุดสิ้นสุดครึ่งความกว้างของเส้น.
- `Square`: ปลายเส้นสี่เหลี่ยมจัตุรัสยืดออกนอกจุดสิ้นสุดครึ่งความกว้างของเส้น.

คลาสนี้ยังรวม `NotDefined` ซึ่งหมายความว่าไม่ได้กำหนดสไตล์ปลายเส้นอย่างชัดเจน

ปลายเส้นแตกต่างจากหัวลูกศรที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการทำงานของหัวลูกศรโดยใช้ [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปแบบของปลายเส้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกันโดยมีความกว้าง 20 พอยต์ จากบนลงล่าง ใช้ปลายเส้นแบบ flat, round, และ square จุดสิ้นสุดของเส้นมีพิกัดแนวนอนเท่ากัน; ปลายเส้นแบบ round และ square ยืดออกนอกแต่ละจุดสิ้นสุด 10 พอยต์

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

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**.

![ปลายเส้นแบบ Flat, Round, และ Square บนเส้นหนาที่เหมือนกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนวาดด้วยมือ ใช้ [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)

โค้ด PHP ต่อไปนี้แสดงวิธีการใช้เอฟเฟกต์ [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , อ่านค่าที่กำหนดอย่างชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์หลัก, หรือสไลด์เลย์เอาต์ได้ ให้ใช้ [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) เข้าถึงเมธอด `getSketchFormat` ของอ็อบเจกต์ที่คืนค่าและอ่านค่าของ `getSketchType` ค่าที่มีประสิทธิภาพสะท้อนการจัดรูปแบบที่ถูกนำไปใช้จริงหลังจากการสืบทอดแก้ไข ตัวอย่างนี้ต้องใช้งานนำเสนอที่มีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

ต่อไปนี้คือตัวเลือกสามแบบของการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อกำหนดว่าเส้นขอบสองส่วนมาพบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามรูปที่มีเส้นขอบสีน้ำเงินความกว้าง 15 พอยต์ โดยตั้งค่า [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) เป็นค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบการวาดมุม

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

### **จำกัดการเชื่อมต่อแบบ Miter ที่มุมแหลม**

ใช้ [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) ร่วมกับ [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ที่ตั้งเป็น [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมจะยืดออก

ขีดจำกัดเป็นอัตราส่วนของระยะระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่าที่เป็น `8` อนุญาตให้ความยาวของ miter ได้สูงสุดเป็นแปดเท่าของความกว้างของเส้น; ไม่ได้เป็นหน่วยพอยต์ หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่สูงกว่าให้จุดที่แหลมขึ้น การตั้งค่านี้ส่งผลต่อการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลที่มองเห็นได้เมื่อมุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีที่เหมือนกันโดยมีเส้นขอบความกว้าง 20 พอยต์ สามเหลี่ยมด้านซ้ายใช้ขีดจำกัด `2` ส่วนด้านขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 พอยต์และสูง 160 พอยต์ ให้มุมบนอัตราส่วนความยาวของ miter ต่อความกว้างของเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำ bevel ที่ยอดซ้ายและรักษายอดขวาไว้

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

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ด้านซ้ายและ **miter limit 8** ด้านขวา.

![ยอดมุมแบนด้วย miter limit 2 และยอดมุมแหลมด้วย miter limit 8 ใน PowerPoint](miter-limits.png)

## **การเติมสีไล่ระดับ**

การเติมสีไล่ระดับผสมสีทั่วรูปทรง ตัวอย่างนี้เติมสีในรูปวงรีด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) เมธอด [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) วางจุดสีที่ตำแหน่ง 0 และ 1 คือจุดเริ่มต้นและสิ้นสุดของไล่สี การล้างจุดสีที่มีอยู่ทำให้ใช้สีเพียงสองสีนี้เท่านั้น

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

![วงรีที่มีการเติมสีไล่ระดับ](gradient-fill.png)

หากไล่สีดูแตกต่างในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนไล่สีที่จัดเก็บในงานนำเสนอ

### **ตั้งค่ามุมของ Gradient เชิงเส้น**

ใช้ [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมการวางแนวของการเติม [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` ไหลจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, และ `270` จากล่างขึ้นบน รองรับมุมเศษส่วน มุมที่อยู่นอกช่วง `[0, 360)` จะถูกทำให้เป็นหนึ่งรอบเต็ม; ตัวอย่างเช่น `-45` จะกลายเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีจุดสีแดง, เขียว, น้ำเงินเดียวกันที่ตำแหน่ง `0`, `0.5`, และ `1` ปิดการสเกลเพื่อให้เปรียบเทียบมุมได้โดยไม่สนอัตราส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, และ `90` และในแถวที่สองคือ `135`, `180`, และ `270`

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

![ไล่สีเชิงเส้นที่ 0, 45, และ 90 องศาในแถวบน, และ 135, 180, และ 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **ปรับขนาด Gradient เชิงเส้นตามรูปทรง**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) ตั้งค่าเป็น `False` ชัดเจนเพื่อรักษามุมของไล่สีเชิงเรขาคณิตเมื่อสัดส่วนของรูปทรงเปลี่ยน, หรือเป็น `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปทรง เมื่อเปิดสเกลมุมที่มองเห็นอาจแตกต่างจากมุมที่กำหนดบนรูปทรงที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False` คอลัมน์ขวาใช้ `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างอยู่ด้านบนและสี่เหลี่ยมสูงอยู่ด้านล่าง ทั้งสองเริ่มด้วยขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดอย่างไรโดยไม่ต้องเปลี่ยนการตั้งค่าไล่สี

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

ผลลัพธ์ใน PowerPoint, โดยปิดการปรับสเกลด้านซ้ายและเปิดการปรับสเกลด้านขวา:

![สี่เหลี่ยมกว้างและสูงที่มี Gradient 45 องศา, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อปิดการสเกล แถบสีทแยงมุมคงการวางแนวเดียวกันในทั้งสองสี่เหลี่ยม เมื่อเปิดการสเกล แถบสีจะยืดตามอัตราส่วนของรูปทรง ซึ่งช่วยทำซ้ำไล่สีของต้นแบบเมื่อปรับรูปทรงให้มีขนาดต่างกัน ในสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่สี `45` องศานี้

การตั้งค่ามุมและการสเกลใช้กับไล่สีเชิงเส้นเท่านั้น ไม่ใช้กับการเติม [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/)

### **รวมมุมกับทิศทาง Gradient**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) เลือกสไตล์ไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) ซึ่งไม่ใช่ตัวแทนของมุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) ให้คงทิศทางไว้เมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่สลับลำดับสองสี่เหลี่ยมมีลักษณะเดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยนแปลง

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

## **การเติมแบบลาย**

การเติมแบบลายใช้การออกแบบสองสี เช่น จุด, แถบ, หรือตรวจสอบ ตัวอย่างนี้ใช้ [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) เพื่อเลือกลายตาข่าย [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) ให้พื้นหลังสีเทาอ่อน, และ [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) ให้สีเหลืองเป็นสีลาย

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

![สี่เหลี่ยมที่มีการเติมแบบลาย](pattern-fill.png)

## **การเติมรูปภาพ**

การเติมรูปภาพใช้ภาพภายในรูปทรง ตัวอย่างนี้ต้องมีภาพในเครื่องและใช้ [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าสู่คอลเลกชันภาพของงานนำเสนอ การตั้งค่า [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมดต่อกันทำให้ภาพซ้ำภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปดอกบัว](lotus.png)

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

![รูปทรงที่มีการเติมรูปภาพ](picture-fill.png)

### **วางภาพเป็นเท็กซ์เจอร์แบบต่อกัน**

หากคุณต้องการตั้งภาพต่อกันเป็นเท็กซ์เจอร์และปรับพฤติกรรมการต่อ สามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งโหมดการเติมภาพ—either `Tile` or `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุการจัดตำแหน่งของไทล์ภายในรูปทรง.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่าไทล์จะถูกพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่า offset แนวนอนของไทล์ (หน่วยพอยต์) จากจุดเริ่มต้นของรูปทรง.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่า offset แนวตั้งของไทล์ (หน่วยพอยต์) จากจุดเริ่มต้นของรูปทรง.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์.

ตัวอย่างนี้ต้องมีภาพในเครื่องและกำหนดค่า [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) ให้ซ้ำที่ 50% ของขนาดต้นฉบับ การกำหนด offset ที่ −32 พอยต์ทำให้ไทล์เลื่อนแนวนอนและแนวตั้ง; การจัดตำแหน่งที่ด้านล่าง‑ขวาและการพลิกในทั้งสองทิศทางกำหนดการจัดเรียงเท็กซ์เจอร์ที่ซ้ำ

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

![ตัวเลือกการต่อไทล์](tile-options.png)

## **การเติมสีทึบ**

การเติมสีทึบทำให้รูปทรงมีสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) เป็นโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) จากนั้นบันทึกสี่เหลี่ยมในงานนำเสนอ

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

![รูปทรงที่มีการเติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังสไลด์เป็นการเติมรูปทรง**

ใช้ [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปทรงควรตรงกับพื้นหลังสไลด์ เช่น ในแม่แบบงานนำเสนอ ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) เป็น [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ก่อนเพื่อลบการเติมที่กำหนดไว้โดยเฉพาะ ด้วยการผสมนี้รูปทรงจะใช้พื้นหลังสไลด์แทนการเติมสไตล์ของมันเอง การเปิดใช้งานฟล็ากนี้เพียงอย่างเดียวไม่ลบการเติมที่กำหนดไว้ก่อนหน้า

สิ่งนี้แตกต่างจาก [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) : การเติมพื้นหลังจะครอบวัตถุที่อยู่ข้างหลังรูปทรงด้วยพื้นที่ของพื้นหลังสไลด์ที่สอดคล้องกัน, ในขณะที่ไม่มีการเติมทำให้วัตถุนั้นมองเห็นได้ Gradient จะยังคงจัดแนวกับสไลด์แทนการเริ่มใหม่ภายในแต่ละรูปทรง

ตัวอย่างต่อไปนี้สร้างพื้นหลังแม่แบบที่สไลด์สืบทอดและวางแถบสีชมพูเมจันต์ไว้ด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, สี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มอย่างชัดเจน

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

    // สืบทอดไล่สีจากมาสเตอร์.
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

    // เพิ่มวัตถุนี้ก่อนเพื่อให้แสดงอยู่ด้านหลังสี่เหลี่ยม.
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

    // ปิดการเติมพื้นหลังก่อนที่จะกำหนดการเติมแบบชัดเจน.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **background fill**, **no fill**, และ **explicit fill**. แถบสีชมพูเมจันต์ถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![พื้นหลังเติม, ไม่มีการเติม, และการเติมสีส้มอย่างชัดเจนบนแถบสีชมพูเมจันต์](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปทรงจะใช้พื้นหลังที่แก้ไขของสไลด์; ตัวอย่างนี้ปล่อยให้พื้นหลังของสไลด์และเลย์เอาต์ไม่กำหนดเพื่อให้แม่แบบจัดหาให้

## **ตั้งค่าความโปร่งใส**

สำหรับการเติมสีทึบ ส่วน alpha ของสีควบคุมความทึบแสง: 0 หมายถึงโปร่งใสเต็มที่และ 255 หมายถึงทึบเต็มที่ ตัวอย่างนี้ใช้ค่า alpha 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างยังมองเห็นได้ สีถูกกำหนดผ่าน [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor)

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

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปทรง**

ใช้ [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปทรงในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

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

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

ใช้ [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) เพื่อให้รูปทรงมีความลึกและขอบ bevel ตัวอย่างนี้สร้างวงรีสีเขียวที่มีเส้นขอบสีส้ม ตั้งค่า [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) เป็น 4 พอยต์ และใช้ bevel ด้านบนแบบวงกลมที่กว้างและสูง 6 พอยต์ผ่าน [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) กล้องแบบออร์โธกราฟิกที่หน้าโดยตรงและแสงสามจุดทำให้ bevel มองเห็นได้

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

![เอฟเฟกต์ Bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปทรงถูกควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) พร้อมมุมละติจูด, ลองจิจูด, และรอบการหมุนที่ 40°, 35°, และ 20° ตามลำดับ เลือกกล้องไอโซเมตริกผ่าน [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) และแสงสมดุลผ่าน [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปทรง**

เมธอด [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปทรงแต่ละอันจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ เมธอดนี้ไม่ได้เปิดการแสดงผลสีขาว‑ดำเองและไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่นของรูปทรงในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ เช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` คงสีปกติ, และ `Hidden` ไม่แสดงรูปทรงในโหมดสีขาว‑ดำ `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปทรง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและตั้งค่า [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) เป็นสีเทา รูปร่างที่บันทึกจะคงการเติมสีส้มสำหรับการแสดงผลสีปกติและขอให้แอปที่เคารพการตั้งค่าสีขาว‑ดำใช้สีเทา:

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

ในโหมดสีปกติ สี่เหลี่ยมคงการเติมสีส้มไว้ ในกระบวนการแสดงผลสีขาว‑ดำ จะใช้สีเทาเพราะโหมดถูกตั้งเป็น `Gray` สิ่งนี้ช่วยให้คุณรักษาสไลด์สีเต็มขณะกำหนดลักษณะที่แตกต่างสำหรับการพิมพ์, การพรีวิว หรือกระบวนการอื่นที่เคารพการตั้งค่าสีขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) เพื่อเรียกคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวตำแหน่งในสไลด์จากตัวตำแหน่งในเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีตัวตำแหน่งเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปทรงที่ไม่มีตัวตำแหน่งในเลย์เอาต์ที่สอดคล้องกันจะไม่ถูกรีเซ็ต

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

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์ทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังไว้ การเติมรูปภาพอาจทำให้ไฟล์ใหญ่ขึ้นเพราะภาพถูกจัดเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปทรงในสไลด์ที่มีรูปแบบเดียวกันเพื่อให้สามารถจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่ารูปแบบเหมือนกันและจัดกลุ่มรูปทรงเหล่านั้นอย่างเป็นตรรกะ ซึ่งจะอำนวยความสะดวกในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปทรงกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในชุดสไลด์แม่แบบหรือไฟล์เท็มเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเท็มเพลต, คัดลอกรูปทรงที่สไตล์ต้องการและนำการจัดรูปแบบของมันไปใช้ที่ต้องการทั่วงานนำเสนอ.