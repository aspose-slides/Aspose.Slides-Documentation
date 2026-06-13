---
title: จัดการส่วนข้อความในงานนำเสนอบน Android
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/androidjava/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง"
---
## **บทนำ**

ส่วนของข้อความ (text portion) แสดงถึงส่วนย่อยเฉพาะของข้อความภายในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหาที่อยู่รอบข้าง ใน Aspose.Slides, Portion สามารถใช้เมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดมากขึ้น。

## **รับพิกัดของส่วนข้อความ**
[**getCoordinates()**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getCoordinates--) เมธอดได้ถูกเพิ่มลงในคลาส [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) และ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ซึ่งทำให้สามารถดึงพิกัดของจุดเริ่มต้นของ Portion ได้。

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ปรับโครงสร้างของการนำเสนอ
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับเพียงบางส่วนของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ใช่, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/androidjava/manage-hyperlinks/) ให้กับ Portion เฉพาะส่วนหนึ่ง; ส่วนนั้นเท่านั้นที่จะคลิกได้, ไม่ใช่ย่อหน้าทั้งหมด。

**รูปแบบการสืบทอดสไตล์ทำงานอย่างไร: Portion จะทำการแทนที่อะไรและอะไรที่มาจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงที่สุด หากคุณสมบัติงไม่ได้รับการตั้งค่าบน [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/), เอนจินจะใช้ค่าจาก [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/); หากไม่ตั้งค่าอยู่ที่นั่นเช่นกัน, จะใช้ค่าจาก [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/theme/)。

**จะเกิดอะไรขึ้นหากแบบอักษรที่ระบุสำหรับ Portion ไม่มีบนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[กฎการแทนที่แบบอักษร](/slides/th/androidjava/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจเกิดการไหลใหม่: เมตริกส์, การแยกคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการวางตำแหน่งที่แม่นยำ。

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความระดับ Portion แยกจากย่อหน้าอื่นได้หรือไม่?**

ใช่, สีข้อความ, การเติม, และความโปร่งใสที่ระดับ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้。