---
title: จัดการไฮเปอร์ลิงก์งานนำเสนอใน PHP
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
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — เพิ่มความโต้ตอบและกระบวนการทำงานในเวลาไม่กี่นาที."
---
## **บทนำ**

ไฮเปอร์ลิงก์คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง  
ต่อไปนี้เป็นตัวอย่างไฮเปอร์ลิงก์ที่พบบ่อยในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ, รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for PHP via Java ช่วยให้คุณสามารถทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="primary" %}} 

คุณอาจต้องการลองใช้ Aspose แบบง่าย, [โปรแกรมแก้ไข PowerPoint ออนไลน์ฟรี.](https://products.aspose.app/slides/th/editor)

{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

โค้ด PHP นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังข้อความ:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปร่างหรือเฟรม**

โค้ดตัวอย่างนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังสื่อ**

Aspose.Slides ให้คุณเพิ่มไฮเปอร์ลิงก์ไปยังรูปภาพ, ไฟล์เสียง และไฟล์วิดีโอ  

โค้ดตัวอย่างนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **รูปภาพ**:

```php
  $pres = new Presentation();
  try {
    # เพิ่มรูปภาพลงในงานนำเสนอ
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # สร้างเฟรมรูปภาพบนสไลด์ 1 โดยอิงจากภาพที่เพิ่มไว้ก่อนหน้า
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

โค้ดตัวอย่างนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **ไฟล์เสียง**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

โค้ดตัวอย่างนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **วิดีโอ**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 

คุณอาจต้องการดู *[จัดการ OLE](/slides/th/php-java/manage-ole/)*.

{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ช่วยให้คุณสามารถเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ได้ คุณสามารถใช้มันสร้างสารบัญได้  

โค้ดตัวอย่างนี้แสดงวิธีสร้างสารบัญโดยใช้ไฮเปอร์ลิงก์:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วยเมธอด [setColorSource](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/setcolorsource/) ในคลาส [Hyperlink](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/) คุณสามารถกำหนดสีสำหรับไฮเปอร์ลิงก์และยังสามารถดึงข้อมูลสีจากไฮเปอร์ลิงก์ได้ ฟีเจอร์นี้ถูกแนะนำครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ส่งผลกับเวอร์ชัน PowerPoint ที่เก่ากว่า  

โค้ดตัวอย่างนี้สาธิตการทำงานที่เพิ่มไฮเปอร์ลิงก์ที่มีสีต่างกันลงในสไลด์เดียวกัน:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

### **ลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด PHP นี้แสดงวิธีลบไฮเปอร์ลิงก์จากข้อความในสไลด์ของงานนำเสนอ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ลบไฮเปอร์ลิงก์จากรูปร่างหรือเฟรม**

โค้ด PHP นี้แสดงวิธีลบไฮเปอร์ลิงก์จากรูปร่างในสไลด์ของงานนำเสนอ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/) เป็นคลาสที่สามารถแก้ไขได้ ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าให้กับคุณสมบัติเหล่านี้ได้:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

โค้ดสแนปป์นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยังสไลด์และแก้ไข tooltip ของมันภายหลัง:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คุณสมบัติที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง [HyperlinkQueries](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/) จากงานนำเสนอ, สไลด์ หรือข้อความที่มีการกำหนดไฮเปอร์ลิงก์  

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/gethyperlinkqueries/)

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/) รองรับเมธอดและคุณสมบัติดังนี้:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในที่ไม่ใช่แค่ไปยังสไลด์ แต่ไปยัง "section" หรือสไลด์แรกของ section ได้อย่างไร?**  

Sections ใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยหลักจะชี้ไปยังสไลด์ที่เฉพาะเจาะจง เพื่อ “นำทางไปยัง section” คุณมักจะลิงก์ไปยังสไลด์แรกของมัน  

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**  

ได้. องค์ประกอบของมาสเตอร์สไลด์และเลเอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะปรากฏบนสไลด์ลูกและสามารถคลิกได้ระหว่างการนำเสนอ  

**ไฮเปอร์ลิงก์จะถูกรักษาไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**  

ใน [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/php-java/convert-powerpoint-to-html/) มี—ลิงก์โดยทั่วไปจะยังคงอยู่ เมื่อส่งออกเป็น [images](/slides/th/php-java/convert-powerpoint-to-png/) และ [video](/slides/th/php-java/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถ่ายทอดต่อ เนื่องจากลักษณะของฟอร์แมตเหล่านั้น (เฟรมระดับราสเตอร์/วิดีโอไม่รองรับไฮเปอร์ลิงก์).