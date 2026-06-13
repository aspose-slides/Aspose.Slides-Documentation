---
title: จัดการส่วนข้อความในงานนำเสนอด้วย Java
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/java/portion/
keywords:
- ส่วนข้อความ
- ส่วนข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง"
---
## **ภาพรวม**

ส่วนข้อความคือส่วนสำคัญของข้อความที่อยู่ภายในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหาที่อยู่รอบข้าง. ใน Aspose.Slides, สามารถใช้ส่วนข้อความได้เมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, นำการจัดรูปแบบไปใช้กับบางส่วนของย่อหน้าเท่านั้น, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดกว่า.

บทความนี้แสดงวิธีดึงพิกัดของจุดเริ่มต้นของส่วนข้อความโดยใช้เมธอด `getCoordinates()` อีกทั้งยังเน้นสถานการณ์ทั่วไปที่เกี่ยวข้องกับส่วนข้อความ เช่น การกำหนดไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบได้รับการสืบสวนผ่านส่วน, ย่อหน้า, TextFrame และการสืบทอดธีมอย่างไร, และการจัดการกรณีที่ฟอนต์ที่ระบุไม่พร้อมใช้งาน. นอกจากนี้ยังชี้ให้เห็นว่าการเติมสีของข้อความ, สีและความโปร่งแสงสามารถตั้งค่าแตกต่างกันสำหรับแต่ละส่วนภายในย่อหน้าเดียวกันได้.

## **รับพิกัดของส่วนข้อความ**
เมธอด [**getCoordinates()**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getCoordinates--) ถูกเพิ่มไปยังคลาส [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) และ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ซึ่งทำให้สามารถดึงพิกัดของจุดเริ่มต้นของส่วนได้.

```java
// สร้างอินสแตนซ์ของคลาส Prseetation ที่เป็นตัวแทนของ PPTX
Presentation pres = new Presentation();
try {
    // ปรับรูปแบบบริบทของงานนำเสนอ
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

**Can I apply a hyperlink to only part of the text within a single paragraph?**

ได้, คุณสามารถ [assign a hyperlink](/slides/th/java/manage-hyperlinks/) ให้กับส่วนที่เป็นเอกเทศ; เฉพาะส่วนนั้นจะคลิกได้, ไม่ใช่ทั้งย่อหน้า.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงที่สุด หากคุณสมบัติเช่นนั้นไม่ได้ตั้งค่าไว้บน [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/), เngine จะดึงค่าจาก [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/); หากยังไม่ได้ตั้งค่าไว้ที่นั่นอีก จะดึงจาก [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/java/com.aspose.slides/theme/).

**What happens if the font specified for a Portion is missing on the target machine/server?**

[Font substitution rules](/slides/th/java/font-selection-sequence/) จะนำมาใช้ ข้อความอาจทำการ reflow: เมตริกซ์, การขึ้นบรรทัดคั่นคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการจัดตำแหน่งที่แม่นยำ.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

ได้, สีข้อความ, การเติมสีและความโปร่งแสงที่ระดับ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.