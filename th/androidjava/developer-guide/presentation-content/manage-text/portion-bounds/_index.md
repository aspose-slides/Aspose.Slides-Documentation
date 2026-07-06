---
title: รับขอบเขตส่วนข้อความจากงานนำเสนอบน Android
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/androidjava/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

ส่วนข้อความ (text portion) แทนส่วนเฉพาะของข้อความภายในย่อหน้าและให้คุณทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหารอบข้าง ใน Aspose.Slides สามารถใช้ portion ได้เมื่อคุณต้องการดึงขอบเขตของส่วนข้อความ ใช้การจัดรูปแบบเฉพาะบางส่วนของย่อหน้า หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดขึ้น

บทความนี้แสดงวิธีการรับสี่เหลี่ยมขอบเขตของ portion โดยใช้ [IPortion.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getRect--). นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของ portion โดยใช้ [IPortion.getCoordinates](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getCoordinates--). นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับ portion เช่น การใส่ลิงก์ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, ความเข้าใจวิธีการแก้ไขรูปแบบผ่าน portion, paragraph, text frame, และการสืบทอดธีม, รวมถึงการจัดการกรณีที่แบบอักษรที่ระบุไม่มีให้ใช้

## **รับขอบเขตของส่วนข้อความ**

ใช้ [IPortion.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getRect--) เพื่อดึงสี่เหลี่ยมขอบเขตของส่วนข้อความ:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [IPortion.getCoordinates](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getCoordinates--) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ลิงก์ไฮเปอร์ลิงก์ให้กับเพียงบางส่วนของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ได้, คุณสามารถ [กำหนดลิงก์ไฮเปอร์ลิงก์](/slides/th/androidjava/manage-hyperlinks/) ให้กับ portion แต่ละอัน; เพียงส่วนนั้นจะคลิกได้, ไม่ใช่ทั้งย่อหน้า.

**การทำงานของการสืบทอดสไตล์เป็นอย่างไร: portion จะครอบคลุมอะไรบ้าง และอะไรจะถูกดึงจากย่อหน้าหรือกรอบข้อความ?**

คุณสมบัติระดับ portion มีลำดับความสำคัญสูงสุด หากคุณสมบัติกำหนดไม่ได้บน [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/), Aspose.Slides จะดึงมาจาก [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/). หากยังไม่ได้กำหนดที่นั่นเช่นกัน Aspose.Slides จะใช้สไตล์จาก [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) หรือ [theme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/theme/).

**จะเกิดอะไรขึ้นถ้าแบบอักษรที่ระบุสำหรับ portion ไม่มีในเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[กฎการทดแทนแบบอักษร](/slides/th/androidjava/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจถูกจัดรูปแบบใหม่: ตัวเมตริกซ์, การแยกคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการจัดตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสของการเติมสีข้อความหรือไล่สีแบบเฉพาะ portion ได้โดยไม่กระทบส่วนอื่นของย่อ้หน้าได้หรือไม่?**

ได้, สีข้อความ, การเติมสี, และความโปร่งใสที่ระดับ [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) สามารถต่างจากส่วนที่อยู่ใกล้เคียงได้.