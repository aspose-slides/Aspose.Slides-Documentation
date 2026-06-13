---
title: จัดการกล่องข้อความในงานนำเสนอด้วย PHP
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
description: "Aspose.Slides สำหรับ PHP ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเพิ่มประสิทธิภาพการทำงานอัตโนมัติของการนำเสนอของคุณ"
---
## **แนะนำ**

ข้อความบนสไลด์มักจะอยู่ในกล่องข้อความหรือรูปทรง ดังนั้น เพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความก่อน แล้วจึงใส่ข้อความลงในกล่องนั้น Aspose.Slides for PHP via Java มีคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่ช่วยให้คุณเพิ่มรูปทรงที่มีข้อความได้

{{% alert title="Info" color="info" %}}

Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ที่ช่วยให้คุณเพิ่มรูปทรงลงในสไลด์ได้ อย่างไรก็ตาม ไม่ใช่ทุกรูปทรงที่เพิ่มผ่านคลาส `Shape` สามารถบรรจุข้อความได้ แต่รูปทรงที่เพิ่มผ่านคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) อาจมีข้อความได้

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

ดังนั้น เมื่อทำงานกับรูปทรงที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกสร้างผ่านคลาส `AutoShape` เท่านั้น จึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ซึ่งเป็นคุณสมบัติของ `AutoShape` ได้ ดูส่วน [Update Text](/slides/th/php-java/manage-textbox/#update-text) ในหน้านี้

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่  
3. เพิ่มอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) โดยกำหนดประเภทรูปทรงเป็น [Rectangle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/#Rectangle) ที่ตำแหน่งที่กำหนดบนสไลด์ และรับอ้างอิงของอ็อบเจ็กต์ `AutoShape` ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` เพื่อบรรจุข้อความ ในตัวอย่างด้านล่าง เราเพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`  

โค้ด PHP นี้—เป็นการดำเนินการตามขั้นตอนข้างต้น—จะแสดงวิธีเพิ่มข้อความลงในสไลด์:

```php
  # สร้างอินสแตนซ์ Presentation
  $pres = new Presentation();
  try {
    # รับสไลด์แรกในพรีเซนเทชัน
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # เพิ่ม TextFrame ให้กับ Rectangle
    $ashp->addTextFrame(" ");
    # เข้าถึง TextFrame
    $txtFrame = $ashp->getTextFrame();
    # สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # สร้างอ็อบเจ็กต์ Portion สำหรับ Paragraph
    $portion = $para->getPortions()->get_Item(0);
    # ตั้งค่าข้อความ
    $portion->setText("Aspose TextBox");
    # บันทึกพรีเซนเทชันลงดิสก์
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตรวจสอบว่ารูปทรงเป็นกล่องข้อความหรือไม่**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/istextbox/) จากคลาส [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) เพื่อให้คุณตรวจสอบรูปทรงและระบุว่ามันเป็นกล่องข้อความหรือไม่

![Text box and shape](istextbox.png)

โค้ด PHP นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

โปรดทราบว่า หากคุณเพียงเพิ่ม AutoShape ผ่านเมธอด `addAutoShape` ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) เมธอด `isTextBox` ของ AutoShape จะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับ AutoShape ผ่านเมธอด `addTextFrame` หรือเมธอด `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`

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

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumncount/) และ [setColumnSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumnspacing/) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) ซึ่งช่วยให้คุณเพิ่มคอลัมน์ให้กับกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์และระยะห่างระหว่างคอลัมน์เป็นจุดได้

โค้ดต่อไปนี้แสดงการดำเนินการตามที่อธิบายไว้:

```php
  $pres = new Presentation();
  try {
    # รับสไลด์แรกในพรีเซนเทชัน
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # เพิ่ม TextFrame ให้กับ Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # รับรูปแบบข้อความของ TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # กำหนดจำนวนคอลัมน์ใน TextFrame
    $format->setColumnCount(3);
    # กำหนดระยะห่างระหว่างคอลัมน์
    $format->setColumnSpacing(10);
    # บันทึกพรีเซนเทชัน
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for PHP via Java มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setcolumncount/) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้ คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้

โค้ด PHP นี้แสดงวิธีการเพิ่มคอลัมน์ภายใน Text Frame:

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

Aspose.Slides อนุญาตให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในพรีเซนเทชัน

โค้ด PHP นี้แสดงตัวอย่างการอัปเดตหรือเปลี่ยนข้อความทั้งหมดในพรีเซนเทชัน:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # ตรวจสอบว่ารูปทรงสนับสนุน TextFrame (IAutoShape) หรือไม่.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # วนลูปผ่าน Paragraphs ใน TextFrame
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # วนลูปผ่าน Portion แต่ละส่วนใน Paragraph
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// เปลี่ยนข้อความ

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// เปลี่ยนการจัดรูปแบบ

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

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนำไปเปิดลิงก์

ขั้นตอนการเพิ่มกล่องข้อความที่มีลิงก์:

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่  
3. เพิ่มอ็อบเจ็กต์ `AutoShape` โดยกำหนด `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ AutoShape ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` โดยมีข้อความเริ่มต้น *Aspose TextBox*  
5. สร้างอินสแตนซ์ของคลาส `HyperlinkManager`  
6. กำหนดไฮเปอร์ลิงก์โดยใช้เมธอด [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) กับส่วนที่คุณต้องการใน `TextFrame`  
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`

โค้ด PHP นี้—เป็นการดำเนินการตามขั้นตอนข้างต้น—จะแสดงวิธีเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ลงในสไลด์:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # รับสไลด์แรกในพรีเซนเทชัน
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มอ็อบเจ็กต์ AutoShape โดยกำหนดประเภทเป็น Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # แคสต์รูปร่างเป็น AutoShape
    $pptxAutoShape = $shape;
    # เข้าถึงคุณสมบัติ ITextFrame ที่เกี่ยวข้องกับ AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # เพิ่มข้อความบางส่วนลงในเฟรม
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # ตั้งค่า Hyperlink สำหรับข้อความส่วน
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # บันทึกพรีเซนเทชัน PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความกับตัวกรอกรูปแบบข้อความเมื่อทำงานกับสไลด์มาสเตอร์คืออะไร?**

[placeholder](/slides/th/php-java/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) และสามารถถูกเขียนทับใน [layouts](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ได้ ในขณะที่กล่องข้อความทั่วไปเป็นออบเจ็กต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความจำนวนมากทั่วทั้งพรีเซนเทชันโดยไม่กระทบข้อความในแผนภูมิ ตาราง และ SmartArt อย่างไร?**

จำกัดการวนลูปเฉพาะออโต้-เชปที่มี TextFrame และละเว้นออบเจ็กต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/)) โดยแยกแยะคอลเลกชันของพวกมันออกจากกันหรือข้ามประเภทออบเจ็กต์เหล่านั้น