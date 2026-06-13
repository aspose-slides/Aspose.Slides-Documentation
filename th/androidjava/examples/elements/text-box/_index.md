---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/androidjava/examples/elements/text-box/
keywords:
- ตัวอย่างโค้ด
- กล่องข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับกล่องข้อความใน Aspose.Slides สำหรับ Android: เพิ่ม, จัดรูปแบบ, จัดแนว, แบ่งบรรทัด, ปรับอัตโนมัติ, และปรับสไตล์ข้อความโดยใช้ Java สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
ใน Aspose.Slides, **text box** จะถูกแทนด้วย `AutoShape` ซึ่งเกือบทุกรูปทรงสามารถบรรจุตัวอักษรได้ แต่ text box ปกติจะไม่มีการเติมสีหรือเส้นขอบและจะแสดงเฉพาะข้อความเท่านั้น.

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึงและลบ text box อย่างโปรแกรมเมชัน.

## **เพิ่ม Text Box**

Text box คือเพียง `AutoShape` ที่ไม่มีการเติมสีหรือเส้นขอบและมีข้อความที่จัดรูปแบบไว้ นี่คือตัวอย่างการสร้างหนึ่งอัน:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // สร้างรูปสี่เหลี่ยม (ค่าตั้งต้นคือเติมสีพร้อมขอบและไม่มีข้อความ)
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // ลบการเติมสีและขอบเพื่อให้ดูเหมือนกล่องข้อความทั่วไป
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // ตั้งค่าการจัดรูปแบบข้อความ.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // กำหนดเนื้อหาข้อความจริง
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ:** `AutoShape` ใด ๆ ที่มี `TextFrame` ที่ไม่ว่างเปล่าสามารถทำหน้าที่เป็น text box ได้

## **เข้าถึง Text Box ตามเนื้อหา**

เพื่อค้นหา text box ทั้งหมดที่มีคีย์เวิร์ดเฉพาะ (เช่น "Slide") ให้วนลูปผ่านรูปทรงทั้งหมดและตรวจสอบข้อความของพวกมัน:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // มีเฉพาะ AutoShape เท่านั้นที่สามารถบรรจุตัวอักษรที่แก้ไขได้.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // ทำบางอย่างกับกล่องข้อความที่ตรงกัน.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Text Box ตามเนื้อหา**

ตัวอย่างนี้ค้นหาและลบ text box ทั้งหมดในสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของคอลเลกชันรูปทรงก่อนทำการแก้ไขระหว่างการวนลูปเพื่อหลีกเลี่ยงข้อผิดพลาดจากการแก้ไขคอลเลกชัน