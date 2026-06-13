---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/nodejs-java/examples/elements/hyperlink/
keywords:
- ตัวอย่างโค้ด
- ไฮเปอร์ลิงก์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides for Node.js: ลิงก์ข้อความ, รูปทรง, และรูปภาพ, ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX, และ ODP พร้อมตัวอย่าง."
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง, ลบ, และอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for Node.js via Java**.

## **Add a Hyperlink**
สร้างรูปสี่เหลี่ยมผืนผ้าพร้อมไฮเปอร์ลิงก์ที่เชื่อมโยงไปยังเว็บไซต์ภายนอก.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Hyperlink**
อ่านไฮเปอร์ลิงก์จากส่วนข้อความของรูปทรง.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างตัวแรกมีข้อความที่มีไฮเปอร์ลิงก์อยู่.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Hyperlink**
ลบไฮเปอร์ลิงก์จากข้อความของรูปทรง.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างตัวแรกมีข้อความที่มีไฮเปอร์ลิงก์.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Update a Hyperlink**
เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งทำเหมือนกับวิธีที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างตัวแรกมีข้อความที่มีไฮเปอร์ลิงก์.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // การเปลี่ยนไฮเปอร์ลิงก์ในข้อความที่มีอยู่ควรทำผ่าน
        // HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
        // ซึ่งทำแบบเดียวกับที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```