---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน PHP
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/php-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java โดยใช้ตัวอย่าง PHP."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือที่ตั้งภายในงานนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อสองวัตถุประสงค์:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for PHP via Java ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียงของมัน ปรับปรุงคุณสมบัติและลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบเดี่ยวและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับงานนำเสนอ, สไลด์ หรือ Text‑Frame พวกเขาอ้างอิงว่ามีการเริ่มต้น PHP/Java Bridge และ Aspose.Slides PHP wrapper แล้ว สมาชิก API ที่ไม่มีหน้าวิจารณ์ PHP จะลิงก์ไปยัง API Java ที่เกี่ยวข้อง

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [ฟรีออนไลน์ Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง หรือกรอบสื่อได้ พื้นที่ที่สามารถคลิกได้กำหนดโดยองค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์: ส่วนของข้อความจะลิงก์ข้อความที่เลือก, ส่วนของรูปหรือกรอบจะลิงก์อ็อบเจกต์สไลด์

สำหรับงานนำเสนอที่มีไฮเปอร์ลิงก์แบบ relative, ดูที่ [จัดการฐานไฮเปอร์ลิงก์](/slides/th/php-java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยนหรือเคลียร์ฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์, ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) ของส่วนข้อความตามตัวอย่างด้านล่าง ส่วนของข้อความที่ระบุเท่านั้นจะกลายเป็นคลิกได้

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบสามารถคลิกได้, เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) ของมัน ไฮเปอร์ลิงก์จะเป็นของอ็อบเจกต์เอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันใช้กับภาพ, ไฟล์เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและเรียก [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) หากต้องการ

ตัวอย่างต่อไปนี้ทำให้สี่เหลี่ยมคลิกได้:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “หน้าที่ 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) ของ [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือรูปแบบของส่วนข้อความหรือไม่ เพื่อกำหนดสีข้อความแบบกำหนดเอง, เลือก [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เปิดตัวใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปนี้เพิ่มไฮเปอร์ลิงก์ข้อความสองอันลงบนสไลด์เดียว อันแรกใช้สีเติมข้อความเป็นสีแดง, ส่วนที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **เสียง**

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อถูกใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้กับไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้โหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำไปสไลด์ต่อไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทางใด ๆ

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดงานนำเสนอที่สร้างขึ้นข้างต้นและอ่านเสียงของไฮเปอร์ลิงก์จากรูปแรกโดยใช้เมธอด [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) และ [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/)

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **การตั้งค่า Tooltip และการโต้ตอบ**

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง คุณสามารถเรียกเมธอดของ [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) ดังต่อไปนี้:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) ตั้งข้อความที่ผู้ชมอาจเห็นเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) ระบุกรอบเป้าหมายภายใน HTML frameset ของพาเรนต์เมื่อมีการใช้
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) ควบคุมว่าการคลิกลิงก์จะเพิ่มปลายทางไปยังรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) ควบคุมว่าฮายเปอร์ลิงก์จะถูกเน้นเมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ของส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก หากต้องการลบเฉพาะประเภทหนึ่งให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) จะลบประเภทการเปิดใช้งานทั้งสองในขอบเขตที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, โน้ต, ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์ที่ครบถ้วน**

ก่อนที่จะแจกจ่ายงานนำเสนอ, ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) จะคืนค่าอ็อบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) บนแต่ละคอนเทนเนอร์ พวกมันทำงานแยกกัน: คอนเทนเนอร์เดียวกันอาจเปิดใช้งานทั้งสอง, ดังนั้นรายงานที่ครบถ้วนอาจต้องมีสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สืบค้นขอบเขตที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่คุณจะได้อัปเดตหรือเอาการกระทำของมันออกในภายหลัง

### **ค้นหาขอบเขตของงานนำเสนอ สไลด์ และ Text‑Frame**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). แต่ละขอบเขตสนับสนุนการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการเมาส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างต่อไปนี้สร้างไฟล์ `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางภายในสไลด์, ลิงก์เมาส์โอเวอร์ข้อความ, และการดำเนินการแมโคร ตัวอย่างไม่ได้ทำการเรียกใช้การกระทำใด ๆ คำสั่งสืบค้นสามคำสั่งทำงานที่ทุกขอบเขต; จำนวนที่แสดงอ้างอิงถึงคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำทั้งหมด ขอบเขต Text‑Frame จะยกเว้นลิงก์ของรูปร่างที่ห่อหุ้ม

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับตัวอย่างนี้, การสืบค้นระดับงานนำเสนอและสไลด์แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เมาส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีหนึ่งในสองการกระทำสามรายการ ขอบเขต Text‑Frame รายงานคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จำแนกการกระทำและปลายทาง**

ใช้ [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) มีค่ามากกว่าการนำทางเว็บเท่านั้น

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสกีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทของสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้แมโคร |
| `StartProgram` | เรียกโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; แยกตรวจสอบจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือเป็นการกระทำที่ไม่ระบุซึ่งต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้แปลว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ปกติ, และรวม Tooltip ที่คืนจาก [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง PHP ด้านล่างอ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างด้านบน), เขียนไฟล์ `hyperlink-audit.json`, ใช้นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, และเปิดใหม่เพื่อตรวจสอบประเภทการเปิดใช้งานอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเปรียบเทียบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง การสืบค้นงานนำเสนอครอบคลุมสไลด์ธรรมดา; สำหรับการสำรวจระดับแพ็กเกจ, ยังทำการสืบค้นมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ตและมือแจกเมื่อปรากฏ

รายงานบันทึกดัชนีสไลด์เริ่มต้นจาก 1 และ [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) หากมี [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลย์เอาต์และโน้ตไม่มีดัชนีสไลด์ธรรมดาและจะแยกตามขอบเขต รูปคอนเทนเนอร์และคอนเทนเนอร์รูปแบบส่วนข้อความจะมีป้ายกำกับแยกกัน; ชนิดคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานท้องถิ่นเพื่อให้เชื่อมโยงการกระทำสองอย่างของมัน รายงานบันทึกชนิดการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enum PHP

นโยบายแอปพลิเคชันนี้จำกัดให้ใช้ได้เฉพาะ URL HTTPS แบบ absolute และเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่ทราบ, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจเชิงนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่รับประกันความเชื่อถือได้: เพิ่มรายชื่ออนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ปรับรูปแบบแล้วจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) ของคอนเทนเนอร์สนับสนุน [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) ที่นี่ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; คลิกและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `$replaceExternalClicks` เป็น `false` เพื่อเอาการละเมิดนโยบายทั้งหมดออก เลือกหน้าทดแทนที่เป็นของแอปก่อนทำการเผยแพร่

ค่าสถานะการส่งออกของรายงานใช้แนวทางการตรวจทาน PDF อย่างระมัดระวัง: กำหนดค่าสถานะเมาส์โอเวอร์และการกระทำใด ๆ ที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดไปยังสไลด์เฉพาะว่าอาจไม่รองรับ เป็นเพียงเคล็ดลับการตรวจสอบ ไม่ได้เป็นการทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ตั้งค่าสถานะจะคงอยู่ในการส่งออก PDF และ HTML ที่รองรับอาจคงไว้ซึ่งไฮเปอร์ลิงก์ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมอ่านภาพ [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/php-java/convert-powerpoint-to-html/) ไม่สามารถคงไว้ในรูปภาพ [images](/slides/th/php-java/convert-powerpoint-to-png/) และ [video](/slides/th/php-java/convert-powerpoint-to-video/) ได้

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

ด้วยอินพุตที่สร้างไว้ข้างต้น, รายงานมีแถวการกระทำห้าแถว ลิงก์เมาส์โอเวอร์ไฟล์และแมโครคลิกถูกลบ, ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบแสดงศูนย์การกระทำที่ไม่ได้รับอนุญาต อินพุตที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตก็จะทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่ได้รับอนุญาตและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตจะคงคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) ที่ลบการกระทำทั้งสองในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ, และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะเชื่อมโยงไปยังส่วนหรือสไลด์แรกของมันได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน, ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบของเลย์เอาต์สนับสนุนไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะใช้งานได้ระหว่างการนำเสนอบนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อตีออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคงไว้ซึ่งไฮเปอร์ลิงก์; ภาพเรสเตอร์และวิดีโอไม่สามารถคงไว้ได้ ดูข้อพิจารณาการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)