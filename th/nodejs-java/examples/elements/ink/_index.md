---
title: หมึก
type: docs
weight: 180
url: /th/nodejs-java/examples/elements/ink/
keywords:
- ตัวอย่างโค้ด
- หมึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับหมึกใน Aspose.Slides for Node.js: วาด, นำเข้า, และแก้ไขเส้น, ปรับสีและความกว้าง, และส่งออกเป็น PPT, PPTX, และ ODP ด้วยตัวอย่าง."
---
บทความนี้ให้ตัวอย่างของการเข้าถึงรูปแบบหมึกที่มีอยู่และการลบมันโดยใช้ **Aspose.Slides for Node.js via Java**.

> ❗ **หมายเหตุ:** รูปแบบหมึกแสดงถึงการป้อนข้อมูลของผู้ใช้จากอุปกรณ์เฉพาะ. Aspose.Slides ไม่สามารถสร้างเส้นหมึกใหม่โดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่ได้.

## **เข้าถึงหมึก**

ดึงรูปแบบหมึกแรกบนสไลด์.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบหมึก**

ลบรูปแบบหมึกจากสไลด์.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปแบบหมึกเป็นรูปแบบแรกบนสไลด์.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```