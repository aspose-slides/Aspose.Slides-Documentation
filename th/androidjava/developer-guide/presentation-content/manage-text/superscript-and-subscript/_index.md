---
title: จัดการตัวเอ็นและตัวห้อยลงในงานนำเสนอบน Android
linktitle: ตัวเอ็นและตัวห้อยลง
type: docs
weight: 80
url: /th/androidjava/superscript-and-subscript/
keywords:
- ตัวเอ็น
- ตัวห้อยลง
- เพิ่มตัวเอ็น
- เพิ่มตัวห้อยลง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เชี่ยวชาญการใช้ตัวเอ็นและตัวห้อยลงใน Aspose.Slides สำหรับ Android ผ่าน Java และยกระดับงานนำเสนอของคุณด้วยการฟอร์แมตข้อความระดับมืออาชีพเพื่อผลลัพธ์ที่สูงสุด."
---
## **ภาพรวม**

Aspose.Slides มีฟีเจอร์สำหรับการแทรกข้อความตัวเอ็นและตัวห้อยลงในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรือเพิ่มหมายเหตุย่อท้าย ฟอร์แมตแบบพิเศษเหล่านี้ช่วยให้ข้อมูลคมชัดและแม่นยำ ในบทความนี้คุณจะได้เรียนรู้วิธีการใช้สไตล์ตัวเอ็นและตัวห้อยลงอย่างไรให้ราบรื่นและได้ผลลัพธ์ระดับมืออาชีพในแต่ละสไลด์

## **การจัดการข้อความตัวเอ็นและตัวห้อยลง**
คุณสามารถเพิ่มข้อความตัวเอ็นและตัวห้อยลงภายในส่วนของย่อหน้าใด ๆ ได้ สำหรับการเพิ่มข้อความตัวเอ็นหรือตัวห้อยลงในเฟรมข้อความของ Aspose.Slides จำเป็นต้องใช้เมธอด [**setEscapement**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PortionFormat)

คุณสมบัตินี้คืนค่า หรือกำหนดค่าข้อความตัวเอ็นหรือห้อยลง (ค่าตั้งแต่ -100% (ห้อยลง) ถึง 100% (เอ็น) ) ตัวอย่างเช่น:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) แบบ [Rectangle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeType#Rectangle) ไปยังสไลด์
- เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame) ที่เชื่อมกับ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape)
- ลบ Paragraphs ที่มีอยู่เดิม
- สร้างอ็อบเจกต์ย่อหน้าใหม่เพื่อเก็บข้อความตัวเอ็นและเพิ่มลงใน [IParagraphs collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) ของ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame)
- สร้างอ็อบเจกต์ Portion ใหม่
- ตั้งค่า Escapement ของ Portion ระหว่าง 0 ถึง 100 เพื่อเพิ่มตัวเอ็น (0 หมายถึงไม่มีตัวเอ็น)
- ตั้งข้อความบางส่วนให้กับ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน Portion ของย่อหน้า
- สร้างอ็อบเจกต์ย่อหน้าใหม่เพื่อเก็บข้อความตัวห้อยลงและเพิ่มลงในคอลเลกชัน IParagraphs ของ ITextFrame
- สร้างอ็อบเจกต์ Portion ใหม่
- ตั้งค่า Escapement ของ Portion ระหว่าง 0 ถึง -100 เพื่อเพิ่มตัวห้อยลง (0 หมายถึงไม่มีตัวห้อยลง)
- ตั้งข้อความบางส่วนให้กับ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Portion) แล้วเพิ่มลงในคอลเลกชัน Portion ของย่อหน้า
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนด้านบนมีตัวอย่างโค้ดดังต่อไปนี้

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างกล่องข้อความ
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // สร้างย่อหน้าสำหรับข้อความตัวเอ็น
    IParagraph superPar = new Paragraph();

    // สร้าง Portion ด้วยข้อความทั่วไป
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // สร้าง Portion ด้วยข้อความตัวเอ็น
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // สร้างย่อหน้าสำหรับข้อความตัวห้อยลง
    IParagraph paragraph2 = new Paragraph();

    // สร้าง Portion ด้วยข้อความทั่วไป
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // สร้าง Portion ด้วยข้อความตัวห้อยลง
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // เพิ่มย่อหน้าเข้าไปในกล่องข้อความ
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ตัวเอ็นและตัวห้อยลงจะยังคงอยู่เมื่อส่งออกเป็น PDF หรือรูปแบบอื่นหรือไม่?**

ใช่, Aspose.Slides จะรักษาการฟอร์แมตตัวเอ็นและตัวห้อยลงอย่างถูกต้องเมื่อส่งออกงานนำเสนอเป็น PDF, PPT/PPTX, ภาพ และรูปแบบอื่นที่รองรับ ฟอร์แมตพิเศษนี้จะคงสภาพเดิมในไฟล์ผลลัพธ์ทั้งหมด

**สามารถนำตัวเอ็นและตัวห้อยลงมาผสมกับสไตล์ฟอร์แมตอื่น เช่น ตัวหนา หรือ ตัว italics ได้หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณผสมสไตล์ข้อความหลายแบบภายใน Portion เดียวกัน คุณสามารถเปิดใช้งานตัวหนา, ตัว italics, ขีดเส้นใต้ และพร้อมกันกับการกำหนดค่าตัวเอ็นหรือห้อยลงโดยตั้งค่าคุณสมบัติตรงกับ [PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portionformat/)

**การฟอร์แมตตัวเอ็นและตัวห้อยลงทำงานได้กับข้อความในตาราง, แผนภูมิ หรือ SmartArt หรือไม่?**

ใช่, Aspose.Slides รองรับการฟอร์แมตภายในวัตถุต่าง ๆ มากมายรวมถึงตารางและองค์ประกอบของแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/smartartnode/)) และตัวเก็บข้อความของมัน แล้วตั้งค่าคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portionformat/) ในลักษณะเดียวกัน.