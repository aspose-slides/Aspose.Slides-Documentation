---
title: SmartArt
type: docs
weight: 140
url: /th/nodejs-java/examples/elements/smart-art/
keywords:
- ตัวอย่างโค้ด
- SmartArt
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับ SmartArt ใน Aspose.Slides สำหรับ Node.js: สร้าง, แก้ไข, แปลงและกำหนดสไตล์แผนผังด้วย JavaScript สำหรับการนำเสนอ PowerPoint และ OpenDocument."
---
บทความนี้แสดงวิธีเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ, และเปลี่ยนรูปแบบโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่ม SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเลย์เอาต์ที่มีมาให้

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึง SmartArt**

ดึงอ็อบเจ็กต์ SmartArt แรกบนสไลด์

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ SmartArt**

ลบรูปร่าง SmartArt ออกจากสไลด์

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกเป็น SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เปลี่ยนรูปแบบ SmartArt**

อัปเดตประเภทเลย์เอาต์ของกราฟิก SmartArt ที่มีอยู่

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกเป็น SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```