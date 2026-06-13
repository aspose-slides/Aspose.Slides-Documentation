---
title: จัดการซูเปอร์สคริปต์และซับสคริปต์ในงานนำเสนอด้วย JavaScript
linktitle: ซูเปอร์สคริปต์และซับสคริปต์
type: docs
weight: 80
url: /th/nodejs-java/superscript-and-subscript/
keywords:
- ซูเปอร์สคริปต์
- ซับสคริปต์
- เพิ่มซูเปอร์สคริปต์
- เพิ่มซับสคริปต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เชี่ยวชาญการใช้ซูเปอร์สคริปต์และซับสคริปต์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้ได้ผลกระทบสูงสุด."
---
## **ภาพรวม**

Aspose.Slides มีฟีเจอร์สำหรับรวมข้อความซูเปอร์สคริปต์และซับสคริปต์เข้าไปในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรืออธิบายเนื้อหาด้วยหมายเหตุส่วนล่าง ตัวเลือกการจัดรูปแบบพิเศษเหล่านี้ช่วยให้คงความชัดเจนและแม่นยำได้ ในบทความนี้คุณจะได้เรียนรู้วิธีใช้สไตล์ซูเปอร์สคริปต์และซับสคริปต์อย่างราบรื่นและทำให้สไลด์ทุกสไลด์ดูเป็นมืออาชีพ

## **จัดการข้อความซูเปอร์สคริปต์และซับสคริปต์**

คุณสามารถเพิ่มข้อความซูเปอร์สคริปต์และซับสคริปต์ภายในส่วนของย่อหน้าใดก็ได้ เพื่อเพิ่มข้อความ Superscript หรือ Subscript ในกรอบข้อความของ Aspose.Slides จะต้องใช้เมธอด [**setEscapement**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PortionFormat)

คุณสมบัตินี้คืนค่า หรือกำหนดค่าข้อความซูเปอร์สคริปต์หรือซับสคริปต์ (ค่าตั้งแต่ -100% (ซับสคริปต์) ถึง 100% (ซูเปอร์สคริปต์)) ตัวอย่างเช่น:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ประเภท [Rectangle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeType#Rectangle) ลงในสไลด์
- เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape)
- ล้าง Paragraphs ที่มีอยู่
- สร้างวัตถุย่อหน้าใหม่เพื่อเก็บข้อความซูเปอร์สคริปต์และเพิ่มลงใน [Paragraphs collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame#getParagraphs--) ของ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame)
- สร้างวัตถุ Portion ใหม่
- กำหนดค่า Escapement สำหรับ Portion ระหว่าง 0 ถึง 100 เพื่อเพิ่มซูเปอร์สคริปต์ (0 หมายถึงไม่มีซูเปอร์สคริปต์)
- ตั้งข้อความสำหรับ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน Portion ของย่อหน้า
- สร้างวัตถุย่อหน้าใหม่เพื่อเก็บข้อความซับสคริปต์และเพิ่มลงใน IParagraphs collection ของ ITextFrame
- สร้างวัตถุ Portion ใหม่
- กำหนดค่า Escapement สำหรับ Portion ระหว่าง 0 ถึง -100 เพื่อเพิ่มซับสคริปต์ (0 หมายถึงไม่มีซับสคริปต์)
- ตั้งข้อความสำหรับ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน Portion ของย่อหน้า
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นแสดงไว้ด้านล่าง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์
    var slide = pres.getSlides().get_Item(0);
    // สร้างกล่องข้อความ
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // สร้างย่อหน้าสำหรับข้อความซูเปอร์สคริปต์
    var superPar = new aspose.slides.Paragraph();
    // สร้าง Portion ด้วยข้อความธรรมดา
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // สร้าง Portion ด้วยข้อความซูเปอร์สคริปต์
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // สร้างย่อหน้าสำหรับข้อความซับสคริปต์
    var paragraph2 = new aspose.slides.Paragraph();
    // สร้าง Portion ด้วยข้อความธรรมดา
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // สร้าง Portion ด้วยข้อความซับสคริปต์
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // เพิ่มย่อหน้าลงในกล่องข้อความ
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ซูเปอร์สคริปต์และซับสคริปต์จะยังคงอยู่เมื่อส่งออกเป็น PDF หรือฟอร์แมตอื่นหรือไม่?**

ใช่, Aspose.Slides จะเก็บรูปแบบซูเปอร์สคริปต์และซับสคริปต์อย่างถูกต้องเมื่อส่งออกงานนำเสนอเป็น PDF, PPT/PPTX, รูปภาพและฟอร์แมตที่สนับสนุนอื่น ๆ รูปแบบพิเศษจะคงอยู่ในไฟล์ผลลัพธ์ทั้งหมด

**สามารถผสมซูเปอร์สคริปต์และซับสคริปต์กับสไตล์การจัดรูปแบบอื่น ๆ เช่น ตัวหนา หรือ ตัวเอียงได้หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณผสานสไตล์ข้อความต่าง ๆ ภายใน Portion เดียวกัน คุณสามารถเปิดใช้งานตัวหนา, ตัวเอียง, ขีดเส้นใต้ และพร้อมกันนั้นใช้ซูเปอร์สคริปต์หรือซับสคริปต์โดยกำหนดคุณสมบัติที่เกี่ยวข้องใน [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/)

**ซูเปอร์สคริปต์และซับสคริปต์ทำงานกับข้อความภายในตาราง, แผนภูมิ, หรือ SmartArt ได้หรือไม่?**

ใช่, Aspose.Slides รองรับการจัดรูปแบบภายในออบเจ็กต์ส่วนใหญ่รวมถึงตารางและองค์ประกอบของแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงอิลีเมนต์ที่เกี่ยวข้อง (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartnode/)) และคอนเทนเนอร์ข้อความของมัน จากนั้นกำหนดคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) ในลักษณะเดียวกัน.