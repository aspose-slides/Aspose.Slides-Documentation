---
title: กลุ่มรูปทรง
type: docs
weight: 170
url: /th/nodejs-java/examples/elements/group-shape/
keywords:
- ตัวอย่างโค้ด
- กลุ่มรูปทรง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการรูปทรงที่จัดกลุ่มใน Aspose.Slides for Node.js: สร้าง, ซ้อน, จัดแนว, เรียงลำดับ, และกำหนดสไตล์ให้กับรูปกลุ่มด้วยตัวอย่างในงานนำเสนอ PPT, PPTX, และ ODP"
---
ตัวอย่างการสร้างกลุ่มของรูปทรง, การเข้าถึง, การยกเลิกการจัดกลุ่ม, และการลบโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มรูปกลุ่ม**

สร้างกลุ่มที่ประกอบด้วยรูปทรงพื้นฐานสองรูป.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงรูปกลุ่ม**

ดึงรูปกลุ่มแรกจากสไลด์.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบรูปกลุ่ม**

ลบรูปกลุ่มจากสไลด์.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปแรกเป็นรูปกลุ่ม.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ยกเลิกการจัดกลุ่มรูปทรง**

ย้ายรูปทรงออกจากคอนเทนเนอร์กลุ่ม.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปแรกเป็นรูปกลุ่ม.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // คัดลอกรูปแต่ละรูปจากกลุ่มไปยังสไลด์.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```