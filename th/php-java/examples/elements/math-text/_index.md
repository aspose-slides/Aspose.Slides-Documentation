---
title: "ข้อความคณิตศาสตร์"
type: docs
weight: 160
url: /th/php-java/examples/elements/math-text/
keywords:
- "ข้อความคณิตศาสตร์"
- "เพิ่มข้อความคณิตศาสตร์"
- "เข้าถึงข้อความคณิตศาสตร์"
- "ลบข้อความคณิตศาสตร์"
- "จัดรูปแบบข้อความคณิตศาสตร์"
- "ตัวอย่างโค้ด"
- PowerPoint
- OpenDocument
- "งานนำเสนอ"
- PHP
- Aspose.Slides
description: "ทำงานกับข้อความคณิตศาสตร์ใน PHP ด้วย Aspose.Slides: สร้างและแก้ไขสมการ, เศษส่วน, ราก, ตัวเขียนย่อย, การจัดรูปแบบ, และเรนเดอร์ผลลัพธ์สำหรับ PPT และ PPTX."
---
แสดงวิธีทำงานกับรูปร่างข้อความคณิตศาสตร์และการจัดรูปแบบสมการโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปร่างคณิตศาสตร์ที่มีเศษส่วนและสูตรพีทากอรัส

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มรูปร่าง Math ไปยังสไลด์.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // เข้าถึงพารากราฟคณิตศาสตร์.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // เพิ่มเศษส่วนง่าย: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // เพิ่มสมการ: c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปร่างที่มีย่อหน้าแบบคณิตศาสตร์บนสไลด์

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ค้นหารูปร่างแรกที่มีพารากราฟคณิตศาสตร์.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปร่างคณิตศาสตร์ออกจากสไลด์

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็นรูปร่าง Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        // ลบรูปร่าง Math ออกจากสไลด์.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

ตั้งค่าคุณสมบัติตัวอักษรสำหรับส่วนคณิตศาสตร์

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็นรูปร่าง Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```