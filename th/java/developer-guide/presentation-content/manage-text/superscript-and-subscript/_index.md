---
title: จัดการซูเปอร์สคริปต์และซับสคริปต์ในงานนำเสนอด้วย Java
linktitle: ซูเปอร์สคริปต์และซับสคริปต์
type: docs
weight: 80
url: /th/java/superscript-and-subscript/
keywords:
- ซูเปอร์สคริปต์
- ซับสคริปต์
- เพิ่มซูเปอร์สคริปต์
- เพิ่มซับสคริปต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เชี่ยวชาญซูเปอร์สคริปต์และซับสคริปต์ใน Aspose.Slides สำหรับ Java และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้ได้ผลกระทบสูงสุด."
---
## **ภาพรวม**

Aspose.Slides ให้คุณสมบัติสำหรับการรวมข้อความซูเปอร์สคริปต์และซับสคริปต์ในงานพรีเซนเทชัน PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรือใส่หมายเหตุท้ายหน้า ตัวเลือกการจัดรูปแบบพิเศษเหล่านี้ช่วยให้คงความชัดเจนและแม่นยำ ในบทความนี้ คุณจะได้เรียนรู้วิธีการใช้สไตล์ซูเปอร์สคริปต์และซับสคริปต์อย่างราบรื่นและให้ผลลัพธ์มืออาชีพในทุกสไลด์

## **จัดการข้อความซูเปอร์สคริปต์และซับสคริปต์**
คุณสามารถเพิ่มข้อความซูเปอร์สคริปต์และซับสคริปต์ได้ภายในส่วนของย่อหน้าใด ๆ สำหรับการเพิ่มข้อความซูเปอร์สคริปต์หรือซับสคริปต์ในกรอบข้อความของ Aspose.Slides จำเป็นต้องใช้เมธอด [**setEscapement**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/PortionFormat)

คุณสมบัตินี้คืนค่า หรือกำหนดข้อความซูเปอร์สคริปต์หรือซับสคริปต์ (ค่าตั้งแต่ -100% (ซับสคริปต์) ถึง 100% (ซูเปอร์สคริปต์)). ตัวอย่างเช่น:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class.
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ประเภท [Rectangle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ShapeType#Rectangle) ลงในสไลด์.
- เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrame) ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape).
- ลบ Paragraphs ที่มีอยู่
- สร้างอ็อบเจกต์ Paragraph ใหม่สำหรับเก็บข้อความซูเปอร์สคริปต์และเพิ่มลงใน [IParagraphs collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrame#getParagraphs--) ของ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrame).
- สร้างอ็อบเจกต์ Portion ใหม่
- ตั้งค่า Escapement สำหรับ Portion ระหว่าง 0 ถึง 100 เพื่อเพิ่มซูเปอร์สคริปต์ (0 หมายถึงไม่มีซูเปอร์สคริปต์)
- ตั้งค่าข้อความสำหรับ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph.
- สร้างอ็อบเจกต์ Paragraph ใหม่สำหรับเก็บข้อความซับสคริปต์และเพิ่มลงใน IParagraphs collection ของ ITextFrame.
- สร้างอ็อบเจกต์ Portion ใหม่
- ตั้งค่า Escapement สำหรับ Portion ระหว่าง 0 ถึง -100 เพื่อเพิ่มซับสคริปต์ (0 หมายถึงไม่มีซับสคริปต์)
- ตั้งค่าข้อความสำหรับ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph.
- บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.

การทำตามขั้นตอนข้างต้นมีดังต่อไปนี้.

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างกล่องข้อความ
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // สร้างย่อหน้าสำหรับข้อความซูเปอร์สคริปต์
    IParagraph superPar = new Paragraph();

    // สร้าง portion กับข้อความปกติ
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // สร้าง portion กับข้อความซูเปอร์สคริปต์
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // สร้างย่อหน้าสำหรับข้อความซับสคริปต์
    IParagraph paragraph2 = new Paragraph();

    // สร้าง portion กับข้อความปกติ
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // สร้าง portion กับข้อความซับสคริปต์
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // เพิ่มย่อหน้าไปยังกล่องข้อความ
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ข้อความซูเปอร์สคริปต์และซับสคริปต์จะถูกเก็บไว้เมื่อตีออกเป็น PDF หรือรูปแบบอื่นหรือไม่?**

ใช่, Aspose.Slides จะรักษาการจัดรูปแบบซูเปอร์สคริปต์และซับสคริปต์อย่างถูกต้องเมื่อส่งออกพรีเซนเทชันเป็น PDF, PPT/PPTX, รูปภาพและรูปแบบที่สนับสนุนอื่น ๆ การจัดรูปแบบพิเศษจะคงอยู่ในไฟล์ผลลัพธ์ทั้งหมด

**ข้อความซูเปอร์สคริปต์และซับสคริปต์สามารถรวมกับสไตล์การจัดรูปแบบอื่นเช่น ตัวหนา หรือ ตัวเอียงได้หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณผสมสไตล์ข้อความต่าง ๆ ภายในส่วนของข้อความเดียวกัน คุณสามารถเปิดใช้งานตัวหนา, ตัวเอียง, ขีดเส้นใต้ และพร้อมกันใช้ซูเปอร์สคริปต์หรือซับสคริปต์ได้โดยกำหนดคุณสมบัติเกี่ยวข้องใน [PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/portionformat/)

**การจัดรูปแบบซูเปอร์สคริปต์และซับสคริปต์ทำงานได้กับข้อความภายในตาราง, แผนภูมิ หรือ SmartArt หรือไม่?**

ใช่, Aspose.Slides รองรับการจัดรูปแบบภายในวัตถุส่วนใหญ่ รวมถึงตารางและองค์ประกอบของแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/java/com.aspose.slides/smartartnode/)) และตัวคอนเทนเนอร์ข้อความของพวกมัน จากนั้นกำหนดคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/portionformat/) ในลักษณะเดียวกัน.