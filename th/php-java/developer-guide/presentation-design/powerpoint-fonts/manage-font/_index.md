---
title: จัดการฟอนต์ในงานนำเสนอด้วย PHP
linktitle: จัดการฟอนต์
type: docs
weight: 10
url: /th/php-java/manage-fonts/
keywords:
- จัดการฟอนต์
- คุณสมบัติฟอนต์
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมฟอนต์ใน PHP ด้วย Aspose.Slides: ฝัง, เปลี่ยนทดแทนและโหลดฟอนต์กำหนดเองเพื่อให้การนำเสนอ PPT, PPTX และ ODP มีความชัดเจน ปลอดภัยต่อแบรนด์ และสอดคล้องกัน."
---
## **จัดการคุณสมบัติที่เกี่ยวกับฟอนต์**
{{% alert color="primary" %}} 

งานนำเสนอส่วนใหญ่ประกอบด้วยข้อความและรูปภาพทั้งสองอย่าง ข้อความสามารถจัดรูปแบบได้หลายวิธี ไม่ว่าจะเพื่อไฮไลต์ส่วนหรือคำเฉพาะ หรือเพื่อให้สอดคล้องกับสไตล์ขององค์กร การจัดรูปแบบข้อความช่วยให้ผู้ใช้เปลี่ยนลักษณะและรูปลักษณ์ของเนื้อหาภายในงานนำเสนอได้ บทความนี้แสดงวิธีใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อกำหนดคุณสมบัติของฟอนต์ในย่อหน้าของข้อความบนสไลด์

{{% /alert %}} 

เพื่อจัดการคุณสมบัติของฟอนต์ในย่อหน้าโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน 
1. เข้าถึงรูปร่าง [Placeholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/) ในสไลด์และแปลงประเภทเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) 
1. รับ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่เปิดเผยโดย [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) 
1. จัดแนวย่อหน้าให้เป็นแบบเต็ม 
1. เข้าถึง [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ของข้อความใน [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) 
1. กำหนดฟอนต์โดยใช้ [FontData](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontdata/) และตั้งค่า **Font** ของ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ของข้อความตามนั้น 
   1. ตั้งฟอนต์เป็นแบบหนา 
   1. ตั้งฟอนต์เป็นแบบเอียง 
1. ตั้งสีฟอนต์โดยใช้ [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) ที่เปิดเผยโดยออบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่าง ซึ่งจะรับงานนำเสนอที่ไม่มีการตกแต่งและจัดรูปแบบฟอนต์บนสไลด์หนึ่ง ภาพหน้าจอต่อไปนี้แสดงไฟล์ต้นฉบับและวิธีที่โค้ดสแน็ปเปลี่ยนแปลงไฟล์นั้น โค้ดจะเปลี่ยนฟอนต์ สี และรูปแบบฟอนต์

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**รูปภาพ: ข้อความในไฟล์ต้นฉบับ**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**รูปภาพ: ข้อความเดียวกันที่มีการจัดรูปแบบอัปเดต**|

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # เข้าถึง placeholder ที่หนึ่งและที่สองในสไลด์และแปลงประเภทเป็น AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # เข้าถึงย่อหน้าที่หนึ่ง
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # จัดเรียงย่อหน้าให้เต็มบรรทัด
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # เข้าถึง portion ที่หนึ่ง
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # กำหนดฟอนต์ใหม่
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # กำหนดฟอนต์ใหม่ให้กับ portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # ตั้งฟอนต์ให้เป็นตัวหนา
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # ตั้งฟอนต์ให้เป็นตัวเอียง
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # ตั้งสีฟอนต์
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าคุณสมบัติฟอนต์ของข้อความ**
{{% alert color="primary" %}} 

ตามที่ได้กล่าวไว้ใน **จัดการคุณสมบัติที่เกี่ยวกับฟอนต์**, [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ถูกใช้เพื่อเก็บข้อความที่มีรูปแบบเหมือนกันในย่อหน้า บทความนี้แสดงวิธีใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้างกล่องข้อความพร้อมข้อความบางส่วน แล้วกำหนดฟอนต์เฉพาะและคุณสมบัติต่าง ๆ ของหมวดฟอนต์

{{% /alert %}} 

เพื่อสร้างกล่องข้อความและตั้งค่าคุณสมบัติฟอนต์ของข้อความในนั้น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน 
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ชนิด **Rectangle** ลงบนสไลด์ 
1. ลบสไตล์การเติมที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) 
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) 
1. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) 
1. เข้าถึงออบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) 
1. กำหนดฟอนต์ที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) 
1. ตั้งคุณสมบัติฟอนต์อื่น ๆ เช่น ตัวหนา, ตัวเอียง, ขีดเส้นใต้, สี และความสูงโดยใช้คุณสมบัติที่เกี่ยวข้องที่เปิดเผยโดยออบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่าง

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**รูปภาพ: ข้อความพร้อมคุณสมบัติดีไซน์ฟอนต์บางส่วนที่ตั้งโดย Aspose.Slides สำหรับ PHP ผ่าน Java**|

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิด Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # ลบสไตล์การเติมใด ๆ ที่เชื่อมโยงกับ AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # ตั้งค่า Font สำหรับ Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # ตั้งค่าคุณสมบัติ Bold ของ Font
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # ตั้งค่าคุณสมบัติ Italic ของ Font
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # ตั้งค่าคุณสมบัติ Underline ของ Font
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # ตั้งค่าความสูงของ Font
    $port->getPortionFormat()->setFontHeight(25);
    # ตั้งค่าสีของ Font
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```