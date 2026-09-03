---
title: จัดการกล่องข้อความในงานนำเสนอโดยใช้ PHP
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/php-java/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้าง, ระบุ, จัดรูปแบบ และอัปเดตกล่องข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **บทนำ**

ใน Aspose.Slides for PHP via Java ข้อความบนสไลด์ถูกจัดเก็บในกรอบข้อความที่เป็นส่วนหนึ่งของรูปร่าง คลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แสดงรูปร่างที่มักจะมีข้อความเป็นส่วนใหญ่และเปิดเผยข้อความของมันผ่านเมธอด [AutoShape::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#getTextFrame) 

{{% alert color="info" title="Note" %}}
รูปร่างอัตโนมัติทุกตัวสืบทอดมาจาก [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/), แต่ไม่ใช่รูปร่างทุกตัวเป็นรูปร่างอัตโนมัติหรือรองรับกรอบข้อความ เมื่อประมวลผลงานนำเสนอที่มีอยู่ ใช้ `java_instanceof` เพื่อตรวจสอบว่ารูปร่างเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ก่อนเข้าถึงข้อความของมัน
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความ ให้เพิ่มรูปร่างอัตโนมัติลงในสไลด์ เพิ่มข้อความลงในกรอบข้อความของมัน และบันทึกงานนำเสนอ ตัวอย่างต่อไปนี้สร้างกล่องข้อความสี่เหลี่ยม:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

พิกัดและมิติที่ส่งให้กับเมธอด [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) จะวัดเป็นจุด (points) เมธอด [AutoShape::addTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#addTextFrame) จะเริ่มต้นกรอบข้อความด้วยข้อความที่ระบุ

## **ตรวจสอบว่ารูปร่างเป็นกล่องข้อความหรือไม่**

ใช้เมธอด [AutoShape::isTextBox](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#isTextBox) เพื่อตรวจสอบว่ารูปร่างอัตโนมัติถูกพิจารณาเป็นกล่องข้อความหรือไม่ สิ่งนี้เป็นประโยชน์เมื่องานนำเสนอมีทั้งรูปร่างอัตโนมัติที่มีข้อความและรูปร่างกราฟิกอย่างเดียว

![กล่องข้อความและรูปร่าง](istextbox.png)

ตัวอย่างต่อไปนี้ตรวจสอบรูปร่างอัตโนมัติทุกตัวในงานนำเสนอ:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

รูปร่างอัตโนมัติที่เพิ่งเพิ่มจะไม่ถูกถือว่าเป็นกล่องข้อความจนกว่าจะมีข้อความที่ไม่ว่างเปล่า คุณสามารถกำหนดข้อความนั้นผ่านเมธอด [AutoShape::addTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#addTextFrame) หรือ [TextFrame::setText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#setText) การเพิ่มหรือตั้งค่าสตริงว่างทำให้เมธอด [AutoShape::isTextBox](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#isTextBox) คืนค่า `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

การเรียกแรกสองครั้งพิมพ์ค่า `true`; สองครั้งสุดท้ายพิมพ์ค่า `false`.

## **ค้นหารูปร่างที่เป็นเจ้าของกรอบข้อความ**

โค้ดประมวลผลข้อความทั่วไปอาจได้รับอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) โดยไม่ทราบว่างานนำเสนออ็อบเจกต์ใดเป็นเจ้าของ ใช้เมธอดอ่านอย่างเดียว [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) เพื่อย้อนกลับไปยัง [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ที่เป็นเจ้าของ

สำหรับกรอบข้อความที่เป็นของรูปร่างอัตโนมัติหรือรูปร่างที่มีข้อความอื่น ๆ [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) คืนค่าเจ้าของและ [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) คืนค่า `null` ตรวจสอบค่าที่ส่งคืนด้วย `java_is_null` ก่อนเข้าถึง เพื่อระบุทั้งเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/php-java/search-and-replace-text/)

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

เมธอด [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setColumnCount) แบ่งกรอบข้อความเป็นหลายคอลัมน์ ในขณะที่ [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setColumnSpacing) ตั้งค่าระยะห่างระหว่างคอลัมน์เป็นหน่วยจุด การตั้งค่าทั้งสองเป็นของ [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) และสามารถเปลี่ยนได้ผ่านกรอบข้อความของกล่องข้อความที่มีอยู่ ข้อความจะไหลใหม่ระหว่างคอลัมน์ภายในรูปร่างเดียวกัน; ไม่ต่อเนื่องไปยังรูปร่างอื่น

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีสามคอลัมน์โดยมีระยะห่าง 10 จุดระหว่างคอลัมน์ บันทึกงานนำเสนอและอ่านการตั้งค่าที่เก็บไว้จากไฟล์ผลลัพธ์:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **สกัดข้อความจากคอลัมน์แต่ละคอลัมน์**

ใช้เมธอด [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#splitTextByColumns) เพื่อดึงข้อความที่กำหนดให้กับแต่ละคอลัมน์ที่มองเห็นได้ในกรอบข้อความที่มีอยู่ เมธอดจะคืนสตริงหนึ่งค่าให้แต่ละคอลัมน์ตามลำดับการอ่านแบบคอลัมน์ กรอบข้อความที่มีเพียงคอลัมน์เดียวจะให้แอเรย์ที่มีหนึ่งองค์ประกอบ และคอลัมน์ที่ว่างเปล่าจะแทนด้วยสตริงว่าง สตริงเหล่านี้ประกอบด้วยข้อความธรรมดาเท่านั้น; การจัดรูปแบบระดับส่วนไม่ได้ถูกเก็บรักษา

สิ่งนี้เป็นประโยชน์เมื่อคุณต้องการ:
- สกัดข้อความพร้อมคงลำดับการอ่านแบบคอลัมน์
- ทำดัชนีหรือเปรียบเทียบเนื้อหาของสไลด์หลายคอลัมน์
- ส่งออกแต่ละคอลัมน์ไปยังไฟล์แยกกัน, ฟิลด์ฐานข้อมูล หรือปลายทางอื่น
- ตรวจสอบว่าข้อความถูกกระจายใหม่อย่างไรหลังจากเปลี่ยนจำนวนคอลัมน์ด้วย [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setColumnCount), ปรับระยะห่างด้วย [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setColumnSpacing), ฟอนต์, หรือขนาดของกรอบข้อความ

เมธอดนี้รายงานข้อความที่กระจายภายใน [TextFrame] ปัจจุบัน; มันจะไม่ไหลอัตโนมัติระหว่างรูปร่างหรือกล่องข้อความแยกต่างหาก การกระจายคอลัมน์อาจขึ้นกับฟอนต์ที่มีและการตั้งค่าเค้าโครงข้อความอื่น ๆ ดังนั้นตรวจสอบให้แน่ใจว่าฟอนต์ที่ต้องการพร้อมใช้งานเมื่อผลลัพธ์ที่สม่ำเสมอสำคัญ

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ค้นหารูปร่างอัตโนมัติหลายคอลัมน์แรกที่มีกรอบข้อความ, อ่านจำนวนคอลัมน์ที่กำหนดไว้, และเขียนข้อความจากทุกคอลัมน์ไปยังไฟล์แยกกัน รูปร่างที่ไม่มีกรอบข้อความจะถูกข้าม

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **อัปเดตข้อความ**

เพื่ออัปเดตข้อความทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์และรูปร่าง, เลือกรูปร่างอัตโนมัติ, แล้วแก้ไขส่วนข้อความของมัน การทำงานระดับส่วนจะให้คุณเปลี่ยนทั้งข้อความและการจัดรูปแบบอักขระ

ตัวอย่างต่อไปนี้แทนที่ทุกการปรากฏของ `years` ด้วย `months` ในข้อความของรูปร่างอัตโนมัติและทำให้แต่ละส่วนที่ได้รับผลกระทบเป็นตัวหนา:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
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
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเดินครั้งนี้อัปเดตข้อความเฉพาะในรูปร่างอัตโนมัติ ข้อความที่เก็บไว้ในตาราง, แผนภูมิ, SmartArt หรือรูปร่างที่จัดกลุ่มต้องเดินแบบผ่านคอลเลกชันของอ็อบเจกต์เหล่านั้น

## **เพิ่มกล่องข้อความที่มีไฮเปอร์ลิงก์**

ไฮเปอร์ลิงก์สามารถกำหนดให้กับส่วนข้อความเฉพาะได้ ดังนั้นเฉพาะข้อความนั้นจึงทำหน้าที่เป็นลิงก์ที่คลิกได้ ใช้เมธอด [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) เพื่อเชื่อมส่วนดังกล่าวกับ URL ภายนอก

ตัวอย่างต่อไปนี้สร้างข้อความที่มีลิงก์และบันทึกลงในงานนำเสนอ:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**กล่องข้อความกับตัวอย่างข้อความ (placeholder) บนมาสเตอร์หรือเลย์เอาต์สไลด์แตกต่างกันอย่างไร?**

[placeholder](/slides/th/php-java/manage-placeholder/) สามารถสืบสานตำแหน่งและการจัดรูปแบบจาก [master slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) หรือ [layout slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) กล่องข้อความธรรมดาเป็นรูปร่างอิสระบนสไลด์ที่สร้างขึ้นและจะไม่ได้รับพฤติกรรม placeholder เมื่อเลย์เอาต์เปลี่ยนแปลง

**ฉันจะแทนที่ข้อความโดยไม่กระทบข้อความในแผนภูมิ ตาราง หรือ SmartArt ได้อย่างไร?**

จำกัดการเดินลูปให้กับอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) เท่านั้น ตามที่แสดงในตัวอย่างอัปเดตข้อความ แผนภูมิ ตาราง และ SmartArt เก็บข้อความในโมเดลอ็อบเจ็กต์ของตนเอง ดังนั้นจึงไม่ถูกแก้ไขโดยลูปนั้น