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

ลิงก์ไฮเปอร์เชื่อมต่อเนื้อหาการนำเสนอกับเว็บไซต์หรือสถานที่ภายในงานนำเสนอ ใน PowerPoint ลิงก์ไฮเปอร์มักมีวัตถุประสงค์สองประการ:
* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ.
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่นจากสารบัญ.

Aspose.Slides for PHP via Java ช่วยให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนแต่ละองค์ประกอบและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับการนำเสนอ, สไลด์ หรือกรอบข้อความ พวกเขาสมมติว่า PHP/Java Bridge และ wrapper ของ Aspose.Slides สำหรับ PHP ได้ถูกเริ่มต้นแล้ว สมาชิก API ที่ไม่มีหน้าอ้างอิง PHP จะลิงก์ไปยัง API ของ Java ด้านล่าง

{{% alert color="info" title="Note" %}}
คุณสามารถแก้ไขการนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor)
{{% /alert %}}

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL เว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ ส่วนขององค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์จะกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์ข้อความที่เลือก, ในขณะเดียวกันรูปร่างหรือกรอบจะลิงก์วัตถุสไลด์.

สำหรับการนำเสนอที่มีไฮเปอร์ลิงก์แบบ relative, ดูที่ [จัดการฐานของไฮเปอร์ลิงก์](/slides/th/php-java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์, ส่งผ่าน [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) ของส่วนข้อความ, ตามที่แสดงด้านล่าง เพียงส่วนของข้อความนั้นจะกลายเป็นคลิกได้.

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

เรียกใช้ [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) บนสี่เหลี่ยมเพื่อทำให้พื้นที่ทั้งหมดของมันคลิกได้ ใช้ [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) เพื่อแสดงเคล็ดลับเกี่ยวกับปลายทางเมื่อผู้ใช้ชี้เมาส์บนสี่เหลี่ยม วิธีการทั้งสองนี้ยังสามารถใช้กับเฟรมรูปภาพ, เสียง, และวิดีโอได้.

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

ไฮเปอร์ลิงก์ภายในให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง.

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

คุณสามารถเปลี่ยนสีของข้อความที่เชื่อมโยง, เล่นหรือหยุดเสียงเมื่อผู้อ่านคลิกที่ลิงก์, และตั้งค่า tooltip ที่แสดงเมื่อชี้เมาส์.

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) ของ [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) กำหนดว่าลิงก์ไฮเปอร์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ เพื่อใช้สีข้อความที่กำหนดเองให้เลือก [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) และตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้ถูกนำเสนอใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้.

ในตัวอย่างนี้, [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) ทำให้ลิงก์แรกใช้สีเติมสีแดงของส่วนข้อความ ลิงก์ที่สองคงสีไฮเปอร์ลิงก์ของการนำเสนอ.

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อถูกเปิดหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้วิธีต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:
- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) กำหนดเสียงที่เชื่อมกับไฮเปอร์ลิงก์.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) ควบคุมว่าการเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าไหม.

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ปุ่มบนสไลด์แรกใช้ [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) เพื่อเล่นไฟล์เสียง `sampleaudio.wav` เมื่อผู้อ่านคลิกเพื่อเลื่อนไป สไลด์ที่สองมีปุ่มแยกที่ใช้ [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) เพื่อหยุดการเล่นและให้ผู้อ่านคงอยู่บนสไลด์นั้น.

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

ตัวอย่างต่อไปนี้เปิดการนำเสนอที่สร้างข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปร่างแรกลงในหน่วยความจำผ่าน [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) และ [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

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

### **ข้อความแสดงคำแนะนำ (Tooltip) และการตั้งค่าการโต้ตอบ**

คุณสามารถเรียกใช้เมธอดของ [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:
- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) ตั้งข้อความที่ผู้ดูสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) ระบุเฟรมเป้าหมายภายใน frameset ของ HTML พาเรนต์ หากมี
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางเข้าไปในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) ควบคุมว่าลิงก์ไฮเปอร์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนที่จะทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทเดียวให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); การลบการคลิกจะไม่ลบการโฮเวอร์ที่สอดคล้องกัน.

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

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) จะลบทั้งสองประเภทการเปิดใช้งานในขอบเขตที่เลือกในการเรียกครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน๊ต, ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **ลบไฮเปอร์ลิงก์ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่, การล้างส่วนข้อความอาจทำให้ไฮเปอร์ลิงก์เก่ายังคงอยู่ ดึงย่อหน้าผ่าน [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/) ก่อนล้างส่วนข้อความ ให้เรียก [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) บนกรอบข้อความของรูปร่างโหนดที่แสดงย่อหน้า, จากนั้นเรียก [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) บนวัตถุที่คืนค่า วิธีนี้จะลบไฮเปอร์ลิงก์ทั้งหมดในกรอบนั้น รวมถึงลิงก์ในย่อหน้าอื่น ๆ

ตัวอย่างสมมติว่ารูปร่างที่สามบนสไลด์แรกของไฟล์ `SmartArtHyperlink.pptx` เป็นกราฟิก SmartArt มันแทนที่ย่อหน้าแรกของโหนดที่สี่ ในการนำเสนอนี้, รูปร่างแรกของโหนดแสดงย่อหน้านั้น

หลังจากเพิ่มทั้งสองส่วน, ตัวอย่างนี้อ่านการจัดรูปแบบที่มีผลของพวกมันด้วย [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/) บนการจัดรูปแบบนั้น, [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) จะคืนค่าไฮเปอร์ลิงก์ใหม่สำหรับส่วนแรกและ `null` สำหรับส่วนที่สอง.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): ส่วนที่สองไม่มีไฮเปอร์ลิงก์.
} finally {
    $presentation->dispose();
}
```

## **สร้างรายการไฮเปอร์ลิงก์ที่สมบูรณ์**

ก่อนแจกจ่ายการนำเสนอ, ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) จะคืนค่าอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการสตริง URL แบน ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ ดังนั้นรายงานสมบูรณ์อาจต้องมีสูงสุดสองแถวต่อคอนเทนเนอร์.

### **สอบถามขอบเขตการนำเสนอ, สไลด์, และกรอบข้อความ**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) สามารถใช้ได้ผ่าน [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). ทุกขอบเขตสนับสนุนการสอบถามเดียวกัน:
- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) คืนค่าคอนเทนเนอร์ที่มีการคลิก.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) คืนค่าคอนเทนเนอร์ที่มีการโฮเวอร์.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) คืนค่าคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ.

ตัวอย่างนี้กำหนดการคลิกและโฮเวอร์ให้กับรูปร่างและข้อความของมัน, และการทำแมโครให้กับปุ่มแยกต่างหาก มันเปรียบเทียบจำนวนคอนเทนเนอร์ที่คืนค่าจาก [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) กับจำนวนสำหรับแต่ละประเภทการเปิดใช้งาน การสอบถามกรอบข้อความจะนับเฉพาะลิงก์ในข้อความ การกระทำของรูปร่างที่ล้อมรอบจะแสดงในผลการสอบถามของสไลด์และการนำเสนอ.

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

สำหรับตัวอย่างนี้, การสอบถามระดับการนำเสนอและสไลด์แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์โฮเวอร์สองรายการ, และคอนเทนเนอร์ที่มีการกระทำใด ๆ ทั้งหมดสามรายการ การสอบถามกรอบข้อความรายงานหนึ่งคอนเทนเนอร์ในแต่ละหมวด.

### **จำแนกการกระทำและปลายทาง**

ใช้ [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) เพื่อประเมินการกระทำก่อนประเมินปลายทางของมัน ค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน. |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, ประมวลผลในบริบทสไลด์โชว์. |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงสไลด์แบบกำหนดเอง. |
| `StartMacro` | เรียกใช้แมโคร. |
| `StartProgram` | เปิดโปรแกรม. |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ. |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ. |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ. |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวม tooltip ที่คืนจาก [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) หากมี.

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่างนี้เปิดการนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ปกติ, มาสเตอร์, เลย์เอาต์, และโน๊ต รวมถึงมาสเตอร์โน๊ตและมือจับเมื่อมีอยู่ ใช้การเทียบอ้างอิงเพื่อให้นับคอนเทนเนอร์แต่ละอันหนึ่งครั้ง ปรับใช้แนวทางที่อธิบายด้านล่าง และเปิดการนำเสนอที่บันทึกไว้ใหม่เพื่อเช็คการกระทำทั้งคลิกและโฮเวอร์.

รายงานบันทึกดัชนีสไลด์ที่เริ่มจากหนึ่งและ [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อมีอยู่ [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน๊ตไม่มีดัชนีสไลด์ทั่วไปและระบุด้วยขอบเขตของพวกมัน คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายแยกต่างหาก; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์แต่ละคอนเทนเนอร์จะได้รับ ID ภายในรายงานเพื่อให้การกระทำสองอย่างถูกเชื่อมโยงกัน รายงานเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enumeration ของ PHP.

นโยบายแอปพลิเคชันที่เจาะจงนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มรูปและเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจเชิงนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่ถือเป็นความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือดำเนินการใด ๆ.

สำหรับการแก้ไข, คอนเทนเนอร์ของ [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). ที่นี่ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า HTTPS คงที่; คลิกที่ห้ามอื่น ๆ และการกระทำโฮเวอร์ที่ห้ามจะถูกลบแยกกัน ตั้งค่า `$replaceExternalClicks` เป็น `false` เพื่อทำการลบการละเมิดนโยบายทั้งหมด เลือกหน้าแทนที่ที่เป็นของแอปพลิเคชันก่อนการนำไปใช้.

แฟล็กการส่งออกของรายงานใช้แนวทางการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำโฮเวอร์และสิ่งใดที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นั่นเป็นคำแนะนำการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่หลังการส่งออก การส่งออก [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/php-java/convert-powerpoint-to-html/) ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ ตัวเลือกการส่งออก และโปรแกรมอ่าน ภาพ [images](/slides/th/php-java/convert-powerpoint-to-png/) และ [video](/slides/th/php-java/convert-powerpoint-to-video/) แบบราสเตอร์ไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบได้; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น.

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

ด้วยอินพุตที่สร้างขึ้นด้านบน, รายงานมีห้าแถวของการกระทำ ลิงก์โฮเวอร์ไฟล์และการคลิกแมโครถูกลบออก ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบแสดงศูนย์การกระทำที่ห้าม อินพุตที่มี URL คลิกภายนอกที่ห้ามก็จะทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีการคลิกที่อนุญาตและโฮเวอร์ที่ห้ามจะคงการคลิกไว้.

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), ที่ลบทั้งสองประเภทการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก.

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนนั้นอย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในมุ่งเป้าไปที่สไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถผูกไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้ในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้อง.

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อนำออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้; ภาพแบบราสเตอร์และวิดีโอไม่สามารถทำได้ ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).