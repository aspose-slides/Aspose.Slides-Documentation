---
title: ตัวเชื่อมต่อ
type: docs
weight: 190
url: /th/java/examples/elements/connector/
keywords:
- ตัวอย่างโค้ด
- Connector
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, วางแนว, และกำหนดรูปแบบคอนเนคเตอร์ระหว่างรูปร่างโดยใช้ Aspose.Slides for Java พร้อมตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้สาธิตวิธีเชื่อมต่อรูปร่างด้วยคอนเนคเตอร์และเปลี่ยนเป้าหมายของพวกมันโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มคอนเนคเตอร์**

แทรกรูปร่างคอนเนคเตอร์ระหว่างสองจุดบนสไลด์.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงคอนเนคเตอร์**

ดึงรูปร่างคอนเนคเตอร์ตัวแรกที่เพิ่มลงในสไลด์.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // เข้าถึงคอนเนคเตอร์ตัวแรกบนสไลด์
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
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

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **เชื่อมต่อรูปร่างใหม่**

แนบคอนเนคเตอร์กับสองรูปร่างโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```