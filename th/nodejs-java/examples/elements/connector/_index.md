---
title: คอนเนคเตอร์
type: docs
weight: 190
url: /th/nodejs-java/examples/elements/connector/
keywords:
- ตัวอย่างโค้ด
- คอนเนคเตอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, กำหนดเส้นทาง, และจัดรูปแบบคอนเนคเตอร์ระหว่างรูปร่างโดยใช้ Aspose.Slides สำหรับ Node.js พร้อมตัวอย่าง JavaScript สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการเชื่อมต่อรูปร่างด้วยคอนเนคเตอร์และเปลี่ยนเป้าหมายของพวกมันโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มคอนเนคเตอร์**

แทรกรูปร้านคอนเนคเตอร์ระหว่างสองจุดบนสไลด์.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงคอนเนคเตอร์**

ดึงรูปคอนเนคเตอร์แรกที่เพิ่มลงในสไลด์.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงคอนเนคเตอร์แรกบนสไลด์.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบคอนเนคเตอร์**

ลบคอนเนคเตอร์ออกจากสไลด์.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างแรกเป็นคอนเนคเตอร์และลบออก.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เชื่อมต่อรูปร่างใหม่**

แนบคอนเนคเตอร์กับสองรูปร่างโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```