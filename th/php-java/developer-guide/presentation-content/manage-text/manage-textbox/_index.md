---
title: จัดการกล่องข้อความในงานนำเสนอโดยใช้ PHP
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/php-java/manage-textbox/
keywords:
- กล่องข้อความ
- เฟรมข้อความ
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
description: "Aspose.Slides for PHP ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเพิ่มประสิทธิภาพการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้น เพื่อเพิ่มข้อความไปยังสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความลงในกล่องนั้น Aspose.Slides for PHP via Java มีคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่อนุญาตให้คุณเพิ่มรูปร่างที่มีข้อความ

{{% alert title="Info" color="info" %}}

Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ที่อนุญาตให้คุณเพิ่มรูปร่างไปยังสไลด์ อย่างไรก็ตาม ไม่ใช่รูปร่างทั้งหมดที่เพิ่มผ่านคลาส `Shape` สามารถบรรจุข้อความได้ แต่รูปร่างที่เพิ่มผ่านคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) อาจมีข้อความได้

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

ดังนั้นเมื่อต้องจัดการกับรูปร่างที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสท์ผ่านคลาส `AutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ซึ่งเป็น property ของ `AutoShape` ได้ ดูส่วน [Update Text](/slides/th/php-java/manage-textbox/#update-text) ในหน้านี้

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่  
3. เพิ่มอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) โดยกำหนดประเภทรูปร่างเป็น [Rectangle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/#Rectangle) ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ `AutoShape` ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ไปยังอ็อบเจ็กต์ `AutoShape` เพื่อบรรจุข้อความ ตัวอย่างด้านล่างเราได้เพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้ายให้เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`  

โค้ด PHP—การนำขั้นตอนข้างต้นไปใช้—จะแสดงวิธีการเพิ่มข้อความไปยังสไลด์:

```php
  # สร้างอินสแตนซ์ Presentation
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรกในงานนำเสนอ
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # เพิ่ม TextFrame ไปยัง Rectangle
    $ashp->addTextFrame(" ");
    # เข้าถึงข้อความเฟรม
    $txtFrame = $ashp->getTextFrame();
    # สร้างอ็อบเจ็กต์ Paragraph สำหรับข้อความเฟรม
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
    $portion = $para->getPortions()->get_Item(0);
    # ตั้งค่าข้อความ
    $portion->setText("Aspose TextBox");
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตรวจสอบรูปแบบกล่องข้อความ**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/istextbox/) จากคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่ช่วยให้คุณตรวจสอบรูปร่างและระบุว่ามันเป็นกล่องข้อความหรือไม่

![กล่องข้อความและรูปร่าง](istextbox.png)

โค้ด PHP นี้จะแสดงวิธีตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

โปรดทราบว่าหากคุณเพิ่ม AutoShape โดยใช้เมธอด `addAutoShape` จากคลาส [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) เมธอด `isTextBox` ของ AutoShape จะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความลงใน AutoShape ด้วยเมธอด `addTextFrame` หรือเมธอด `setText` property `isTextBox` จะคืนค่า `true`

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() คืนค่า false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() คืนค่า true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() คืนค่า false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() คืนค่า true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() คืนค่า false
$shape3->addTextFrame("");
// shape3->isTextBox() คืนค่า false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() คืนค่า false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() คืนค่า false
```

## **ค้นหารูปร่างที่เป็นเจ้าของ Text Frame**

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) โดยยังไม่ทราบว่าอยู่ในงานนำเสนอใด ใช้เมธอด [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) เพื่อย้อนกลับไปยัง [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ที่เป็นเจ้าของ

สำหรับ Text Frame ที่เป็นของ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) หรือรูปร่างอื่นที่บรรจุข้อความ เมธอด [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) จะคืนค่ารูปร่างเจ้าของและเมธอด [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) จะคืนค่า `null` ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว ดังนั้นการเรียกใช้จะไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่าที่คืนกลับด้วย `java_is_null` ก่อนเข้าถึงรูปร่างเสมอ

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/php-java/search-and-replace-text/)

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumncount/) และ [setColumnSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumnspacing/) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) ที่อนุญาตให้คุณเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์และระยะห่างระหว่างคอลัมน์เป็นจุดได้

โค้ดตัวอย่างต่อไปนี้แสดงการดำเนินการที่อธิบายไว้:

```php
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรกในงานนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # เพิ่ม TextFrame ไปยัง Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # ดึงรูปแบบข้อความของ TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # ระบุจำนวนคอลัมน์ใน TextFrame
    $format->setColumnCount(3);
    # ระบุระยะห่างระหว่างคอลัมน์
    $format->setColumnSpacing(10);
    # บันทึกงานนำเสนอ
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มคอลัมน์ใน Text Frame**

Aspose.Slides for PHP via Java มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumncount/) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) ที่อนุญาตให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่าน property นี้คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้

โค้ด PHP นี้จะแสดงวิธีการเพิ่มคอลัมน์ภายใน Text Frame:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **อัปเดตข้อความ**

Aspose.Slides ช่วยให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในงานนำเสนอได้

โค้ด PHP นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดในงานนำเสนอ:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # ตรวจสอบว่ารูปร่างสนับสนุน text frame (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # ทำซ้ำผ่านย่อหน้าใน text frame
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # ทำซ้ำผ่านแต่ละ portion ในย่อหน้า
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// เปลี่ยนข้อความ

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// เปลี่ยนรูปแบบ

            }
          }
        }
      }
    }
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์**

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อผู้ใช้คลิกที่กล่องข้อความ จะถูกเปิดลิงก์นั้น

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่  
3. เพิ่มอ็อบเจ็กต์ `AutoShape` โดยกำหนด `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของ AutoShape ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ไปยังอ็อบเจ็กต์ `AutoShape` โดยให้มีข้อความเริ่มต้นเป็น *Aspose TextBox*  
5. สร้างอ็อบเจ็กต์ `HyperlinkManager`  
6. กำหนดไฮเปอร์ลิงก์โดยใช้เมธอด [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) ที่เชื่อมกับส่วนที่คุณต้องการใน `TextFrame`  
7. สุดท้ายให้เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`  

โค้ด PHP—การนำขั้นตอนข้างต้นไปใช้—จะแสดงวิธีการเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ไปยังสไลด์:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรกในงานนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มอ็อบเจ็กต์ AutoShape โดยกำหนดประเภทเป็น Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # แคสท์รูปร่างเป็น AutoShape
    $pptxAutoShape = $shape;
    # เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # เพิ่มข้อความบางส่วนลงในเฟรม
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # ตั้งค่า Hyperlink สำหรับข้อความ portion
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # บันทึกงานนำเสนอ PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวจัดตำแหน่งข้อความเมื่อทำงานกับสไลด์มาสเตอร์คืออะไร?**

[placeholder](/slides/th/php-java/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) และสามารถถูกเขียนทับบน [layouts](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ได้ ส่วนกล่องข้อความทั่วไปเป็นอ็อบเจ็กต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความจำนวนมากทั่วทั้งงานนำเสนอโดยไม่กระทบข้อความในแผนภูมิ ตาราง และ SmartArt ได้อย่างไร?**

จำกัดการวนลูปของคุณให้กับอัตโนมที่มี Text Frame เท่านั้นและไม่รวมออบเจ็กต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/)) โดยการ Traversal คอลเลกชันของพวกมันแยกกันหรือข้ามประเภทออบเจ็กต์เหล่านั้น