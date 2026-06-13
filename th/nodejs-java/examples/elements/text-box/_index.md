---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/nodejs-java/examples/elements/text-box/
keywords:
  - ตัวอย่างโค้ด
  - กล่องข้อความ
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "ทำงานกับกล่องข้อความใน Aspose.Slides สำหรับ Node.js: เพิ่ม, จัดรูปแบบ, จัดแนว, แบ่งบรรทัด, ปรับขนาดอัตโนมัติ, และกำหนดสไตล์ข้อความโดยใช้ JavaScript สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
ใน Aspose.Slides, **กล่องข้อความ** ถูกแทนด้วย `AutoShape`. เกือบทุกรูปร่างสามารถบรรจุตำแหน่งข้อความได้, แต่กล่องข้อความทั่วไปไม่มีการเติมสีหรือขอบและจะแสดงเฉพาะข้อความเท่านั้น.

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึง, และลบกล่องข้อความโดยใช้โปรแกรม.

## **เพิ่มกล่องข้อความ**

กล่องข้อความเป็นเพียง `AutoShape` ที่ไม่มีการเติมสีหรือขอบและมีข้อความที่จัดรูปแบบบางส่วนเท่านั้น นี่คือวิธีการสร้างหนึ่งอัน:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สร้างรูปสี่เหลี่ยม (ค่าเริ่มต้นคือเติมสีพร้อมขอบและไม่มีข้อความ).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // ลบการเติมสีและขอบเพื่อให้ดูเหมือนกล่องข้อความทั่วไป.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // ตั้งค่าการจัดรูปแบบข้อความ.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // กำหนดเนื้อหาข้อความจริง.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ:** `AutoShape` ใด ๆ ที่มี `TextFrame` ที่ไม่ว่างเปล่าสามารถทำหน้าที่เป็นกล่องข้อความได้.

## **เข้าถึงกล่องข้อความ**

ดึงกล่องข้อความแรกจากสไลด์.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // เฉพาะ AutoShape เท่านั้นที่สามารถมีข้อความที่แก้ไขได้.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบกล่องข้อความตามเนื้อหา**

ตัวอย่างนี้ค้นหาและลบกล่องข้อความทั้งหมดในสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของคอลเลกชันรูปร่างก่อนทำการแก้ไขในระหว่างการวนซ้ำเพื่อหลีกเลี่ยงข้อผิดพลาดการแก้ไขคอลเลกชัน.