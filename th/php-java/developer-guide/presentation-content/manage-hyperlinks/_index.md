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
- ไฮเปอร์ลิงก์รูปทรง
- ไฮเปอร์ลิงก์ภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java โดยใช้ตัวอย่าง PHP."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อวัตถุประสงค์สองประการ:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for PHP via Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละอันและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับการนำเสนอ, สไลด์, หรือกรอบข้อความ พวกมันสมมติว่า PHP/Java Bridge และ Aspose.Slides PHP wrapper ถูกเริ่มต้นแล้ว สมาชิก API ที่ไม่มีหน้าอ้างอิง PHP จะเชื่อมโยงไปยัง Java API ดั้งเดิม

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขการนำเสนอด้วย [free online Aspose PowerPoint editor](https://products.aspose.app/slides/th/editor).
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อ ส่วนที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นพื้นที่ที่คลิกได้: ส่วนของข้อความจะเชื่อมต่อเฉพาะข้อความที่เลือก, ส่วนของรูปร่างหรือกรอบจะเชื่อมต่อกับอ็อบเจ็กต์สไลด์

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์, ส่ง [Hyperlink](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/sethyperlinkclick/) ของส่วนข้อความ, ตามตัวอย่างด้านล่าง เพียงส่วนของข้อความนั้นจะกลายเป็นคลิกได้

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

เพื่อทำให้รูปร่างหรือกรอบคลิกได้, เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/sethyperlinkclick/) ของมัน ไฮเปอร์ลิงก์เป็นของอ็อบเจ็กต์เอง ไม่ได้เป็นของส่วนข้อความภายใน

วิธีเดียวกันใช้ได้กับรูปภาพ, เสียง, และวิดีโอกรอบ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและเรียก [setTooltip](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/settooltip/) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

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

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

## **รูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/setcolorsource/) ของ [Hyperlink](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ เพื่อนำสีข้อความที่กำหนดเองมาใช้, เลือก [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkcolorsource/) และตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นจาก PowerPoint 2019; เวอร์ชันเก่าไม่รองรับการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองอันในสไลด์เดียว อันแรกใช้สีเติมข้อความสีแดง, ส่วนอันที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [Hyperlink::setSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/setsound/) ระบุไฟล์เสียงที่สัมพันธ์กับไฮเปอร์ลิงก์
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/setstopsoundonclick/) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` และเชื่อมโยงกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำทางไปยังสไลด์ถัดไป รูปแบบที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิก โดยไม่มีการนำทาง

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

#### **ดึงเสียงไฮเปอร์ลิงก์ออก**

ตัวอย่างต่อไปเปิดการนำเสนอที่สร้างไว้ด้านบนและอ่านข้อมูลเสียงของไฮเปอร์ลิงก์จากรูปแบบแรกโดยใช้ [getSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/getsound/) และ [getBinaryData](https://reference.aspose.com/slides/th/php-java/aspose.slides/audio/getbinarydata/)

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

### **Tooltip และการตั้งค่าปฏิสัมพันธ์**

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง คุณสามารถเรียกเมธอดของ [Hyperlink](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/) ต่อไปนี้ได้:

- [setTooltip](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/settooltip/) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/settargetframe/) ระบุกรอบเป้าหมายภายในชุดกรอบ HTML ของแม่แบบ, หากมี
- [setHistory](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/sethistory/) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางเข้าไปในรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/sethighlightclick/) ควบคุมว่าไฮเปอร์ลิงก์จะถูกเน้นเมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก หากต้องการลบเฉพาะประเภทหนึ่งให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) การลบการคลิกจะไม่ลบการเมาน์โอเวอร์ที่สอดคล้องกัน

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

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) จะลบการเปิดใช้งานทั้งสองประเภทในขอบเขตที่เลือกในครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและคลอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต, ดูหัวข้อ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์ครบถ้วน**

ก่อนแจกจ่ายการนำเสนอ, ควรตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) จะคืนค่าอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/), ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยการกระทำทั้งสอง, ดังนั้นรายงานเต็มต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สืบค้นขอบเขตที่เหมาะสมแทน และเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อให้คุณสามารถอัปเดตหรือกำจัดการกระทำของมันในภายหลังได้

### **สืบค้นขอบเขตการนำเสนอ, สไลด์, และกรอบข้อความ**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/) มีให้ผ่าน [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/gethyperlinkqueries/). แต่ละขอบเขตสนับสนุนการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการกระทำเมาน์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีการกระทำใด ๆ หรือทั้งสองอย่าง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` ที่มีลิงก์คลิกภายนอก, ลิงก์เมาน์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาน์โอเวอร์ข้อความ, และการกระทำมาโคร ซึ่งไม่ได้เรียกใช้การกระทำใด ๆ การสืบค้นสามแบบทำงานในทุกขอบเขต; จำนวนที่แสดงคือคอนเทนเนอร์, ไม่ใช่จำนวนการกระทำทั้งหมด ขอบเขตกรอบข้อความจะไม่รวมลิงก์ของรูปร่างที่ห่อหุ้มมัน

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

สำหรับตัวอย่างนี้, การสืบค้นระดับการนำเสนอและสไลด์แต่ละรายการแสดงคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เมาน์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีการกระทำใด ๆ สองรายการ ขอบเขตกรอบข้อความแสดงคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [Hyperlink::getActionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/getactiontype/) เพื่อแยกประเภทการกระทำก่อนแยกปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางอีกรอบในโหมดสไลด์โชว์, แก้ไขตามบริบทของสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงที่กำหนดเอง |
| `StartMacro` | เรียกใช้มาโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/getexternalurl/) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/gettargetslide/) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ จัดเก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม tooltip ที่คืนจาก [getTooltip](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/gettooltip/) เมื่อมีให้

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง PHP ด้านล่างอ่านการนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างขึ้นข้างบน), เขียนไฟล์ `hyperlink-audit.json`, ประยุกต์นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบการกระทำทั้งสองประเภทอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนเปลี่ยนแปลงและใช้การเทียบเท่าการอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง การสืบค้นระดับการนำเสนอครอบคลุมสไลด์ปกติ; สำหรับรายการระดับแพ็คเกจ, มันยังสืบค้นมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์ของโน้ตและแจกจ่ายเมื่อมี

รายงานบันทึกดัชนีสไลด์แบบหนึ่ง‑ฐานและ [getSlideId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อมี [ISlideComponent::getSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยขอบเขตของมันเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายแยกต่างหาก; ประเภทคอนเทนเนอร์อื่น ๆ จะคงชื่อประเภทขณะรันแต่ละคอนเทนเนอร์จะมี ID ระดับรายงานเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกัน รายงานเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enumeration ของ PHP

นโยบายแอปพลิเคชันที่เข้มงวดนี้ยอมรับเฉพาะ URL HTTPS แบบสัมบูรณ์และเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย, ไม่ใช่ข้อสรุปด้านความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่ได้สร้างความเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปพลิเคชันของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาทาโดยไม่ติดตามลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [getHyperlinkManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) ของคอนเทนเนอร์สนับสนุน [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) ที่นี่, ลิงก์คลิกภายนอกที่ห้ามใช้จะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; การคลิกที่ห้ามใช้และการเมาน์โอเวอร์ที่ห้ามใช้จะถูกลบแยกกัน ตั้งค่าตัวแปร `$replaceExternalClicks` เป็น `false` เพื่อทำการลบการละเมิดนโยบายทั้งหมด เลือกหน้าแทนที่ที่เป็นของแอปพลิเคชันก่อนการปรับใช้

แฟล็กการส่งออกของรายงานใช้แนวนโยบายรีวิว PDF อย่างระมัดระวัง: ทำแฟล็กการกระทำเมาน์โอเวอร์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นคำแนะนำสำหรับรีวิว, ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำแฟล็กจะคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ชม รูปภาพ raster และวิดีโอไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำแฟล็กทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

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

ด้วยอินพุตที่สร้างข้างบน, รายงานมีแถวการกระทำห้าแถว ลิงก์เมาน์โอเวอร์ไฟล์และคลิกมาโครถูกลบ, ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในคงอยู่ การตรวจสอบพิมพ์จำนวนการกระทำที่ห้ามเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกที่ห้ามจะทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมาน์โอเวอร์ที่ห้ามจะคงคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) ซึ่งลบการกระทำทั้งสองประเภทในขอบเขตที่เลือกโดยไม่สนใจนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ลบ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ, และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน, ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้อง

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้; รูปภาพ raster และวิดีโอไม่สามารถทำได้ ดูข้อพิจารณาการส่งออกในหัวข้อ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).