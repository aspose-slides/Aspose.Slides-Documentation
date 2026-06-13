---
title: จัดการข้อความยกสูงและยกต่ำในงานนำเสนอโดยใช้ PHP
linktitle: ยกสูงและยกต่ำ
type: docs
weight: 80
url: /th/php-java/superscript-and-subscript/
keywords:
- ยกสูง
- ยกต่ำ
- เพิ่ม ยกสูง
- เพิ่ม ยกต่ำ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เชี่ยวชาญการใช้ยกสูงและยกต่ำใน Aspose.Slides สำหรับ PHP ผ่าน Java และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อผลกระทบสูงสุด."
---
## **ภาพรวม**

Aspose.Slides มีฟีเจอร์สำหรับผสานข้อความยกสูงและยกต่ำเข้าไปในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรือใส่หมายเหตุท้ายข้อความ ตัวเลือกการจัดรูปแบบเฉพาะเหล่านี้ช่วยให้คงความชัดเจนและแม่นยำ ในบทความนี้ คุณจะได้เรียนรู้วิธีใช้สไตล์ยกสูงและยกต่ำอย่างราบรื่นและทำให้ผลลัพธ์เป็นมืออาชีพในทุกสไลด์

## **จัดการข้อความยกสูงและยกต่ำ**
คุณสามารถเพิ่มข้อความยกสูงและยกต่ำในส่วนของย่อหน้าใดๆก็ได้ เพื่อเพิ่มข้อความยกสูงหรือยกต่ำในกรอบข้อความของ Aspose.Slides จะต้องใช้เมธอด [**setEscapement**](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setEscapement) ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/PortionFormat)  

คุณสมบัตินี้คืนค่า或กำหนดข้อความยกสูงหรือยกต่ำ (ค่าตั้งแต่ -100% (ยกต่ำ) ถึง 100% (ยกสูง)). ตัวอย่างเช่น:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ประเภท [Rectangle](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeType#Rectangle) ไปยังสไลด์
- เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)
- ลบ Paragraphs ที่มีอยู่
- สร้างอ็อบเจ็กต์ paragraph ใหม่เพื่อเก็บข้อความยกสูงและเพิ่มไปยัง [IParagraphs collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParagraphs) ของ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)
- สร้างอ็อบเจ็กต์ portion ใหม่
- ตั้งค่าคุณสมบัติ Escapement ของ portion ตั้งแต่ 0 ถึง 100 เพื่อเพิ่มยกสูง (0 หมายถึงไม่มียกสูง)
- กำหนดข้อความบางส่วนให้กับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph
- สร้างอ็อบเจ็กต์ paragraph ใหม่เพื่อเก็บข้อความยกต่ำและเพิ่มไปยัง IParagraphs collection ของ ITextFrame
- สร้างอ็อบเจ็กต์ portion ใหม่
- ตั้งค่าคุณสมบัติ Escapement ของ portion ตั้งแต่ 0 ถึง -100 เพื่อเพิ่มยกต่ำ (0 หมายถึงไม่มียกต่ำ)
- กำหนดข้อความบางส่วนให้กับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph
- บันทึกการนำเสนอเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่างนี้.

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างกล่องข้อความ
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # สร้างพารากราฟสำหรับข้อความยกสูง
    $superPar = new Paragraph();
    # สร้าง portion ด้วยข้อความปกติ
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # สร้าง portion ด้วยข้อความยกสูง
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # สร้างพารากราฟสำหรับข้อความยกต่ำ
    $paragraph2 = new Paragraph();
    # สร้าง portion ด้วยข้อความปกติ
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # สร้าง portion ด้วยข้อความยกต่ำ
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # เพิ่มพารากราฟลงในกล่องข้อความ
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ข้อความยกสูงและยกต่ำจะถูกเก็บไว้เมื่อนำออกเป็น PDF หรือรูปแบบอื่นหรือไม่?**  
ใช่, Aspose.Slides จะเก็บรูปแบบข้อความยกสูงและยกต่ำอย่างถูกต้องเมื่อส่งออกการนำเสนอเป็น PDF, PPT/PPTX, ภาพ และรูปแบบที่รองรับอื่นๆ รูปแบบพิเศษนี้จะคงอยู่โดยไม่เสียหายในไฟล์ผลลัพธ์ทั้งหมด

**ข้อความยกสูงและยกต่ำสามารถรวมกับสไตล์การจัดรูปแบบอื่น เช่น ตัวหนา หรือ ตัวเอียง ได้หรือไม่?**  
ใช่, Aspose.Slides อนุญาตให้คุณผสมสไตล์ข้อความหลากหลายภายในส่วนของข้อความเดียว คุณสามารถเปิดใช้ตัวหนา, ตัวเอียง, ขีดเส้นใต้ และทำการยกสูงหรือยกต่ำพร้อมกันได้โดยการกำหนดคุณสมบัติเชิงสัมพันธ์ใน [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/)

**การจัดรูปแบบข้อความยกสูงและยกต่ำทำงานกับข้อความภายในตาราง, แผนภูมิ หรือ SmartArt หรือไม่?**  
ใช่, Aspose.Slides รองรับการจัดรูปแบบภายในวัตถุส่วนใหญ่ รวมถึงตารางและองค์ประกอบของแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/)) และคอนเทนเนอร์ข้อความของมัน แล้วกำหนดคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) ในลักษณะเดียวกัน