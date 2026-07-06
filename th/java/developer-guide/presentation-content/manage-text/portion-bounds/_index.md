---
title: ดึงขอบเขตส่วนข้อความจากงานนำเสนอใน Java
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/java/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

ส่วนของข้อความ (text portion) แสดงถึงส่วนย่อยเฉพาะของข้อความภายในย่อหน้าและอนุญาตให้คุณทำงานกับส่วนนั้นโดยอิสระจากเนื้อหารอบข้าง ใน Aspose.Slides สามารถใช้ portion ได้เมื่อคุณต้องการดึงขอบเขตของส่วนข้อความ เรียกใช้การจัดรูปแบบเฉพาะบางส่วนของย่อหน้า หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดกว่า

บทความนี้แสดงวิธีรับสี่เหลี่ยมขอบของ portion โดยใช้ [IPortion.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getRect--). นอกจากนี้ยังแสดงวิธีรับพิกัดของจุดเริ่มต้นของ portion โดยใช้ [IPortion.getCoordinates](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getCoordinates--). อีกทั้งยังเน้นสถานการณ์ที่พบบ่อยเกี่ยวกับ portion เช่น การใส่ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว การเข้าใจวิธีการสืบทอดรูปแบบผ่าน portion, paragraph, text frame และ theme และการจัดการกรณีที่แบบอักษรที่ระบุไม่มีอยู่

## **รับสี่เหลี่ยมขอบของส่วนข้อความ**

ใช้ [IPortion.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getRect--) เพื่อดึงสี่เหลี่ยมขอบของส่วนข้อความ:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [IPortion.getCoordinates](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getCoordinates--) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ลิงก์ไฮเปอร์ลิงก์ให้กับเพียงบางส่วนของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ใช่, คุณสามารถ [assign a hyperlink](/slides/th/java/manage-hyperlinks/) ให้กับ portion เดี่ยว; เฉพาะส่วนนั้นเท่านั้นที่จะคลิกได้ ไม่ใช่ทั้งย่อหน้า.

**การสืบทอดสไตล์ทำงานอย่างไร: portion จะลบล้างอะไรและอะไรที่ถูกนำมาจากย่อหน้าหรือเฟรมข้อความ?**

คุณสมบัติระดับ portion มีลำดับความสำคัญสูงสุด หากคุณสมบัติไม่ได้ตั้งค่าใน [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/), Aspose.Slides จะดึงจาก [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/). หากยังไม่ได้ตั้งค่าที่นั่นอีก Aspose.Slides จะใช้สไตล์จาก [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) หรือ [theme](https://reference.aspose.com/slides/th/java/com.aspose.slides/theme/) แทน.

**จะเกิดอะไรขึ้นถ้าแบบอักษรที่ระบุสำหรับ portion ไม่มีในเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[Font substitution rules](/slides/th/java/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจเลื่อนตำแหน่งใหม่: เมตริก, การแบ่งบรรทัด, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการจัดตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสของการเติมสีข้อความหรือไล่สีเฉพาะ portion ได้โดยอิสระจากส่วนที่เหลือของย่อหน้าหรือไม่?**

ใช่, สีข้อความ, การเติมสีและความโปร่งใสที่ระดับ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.