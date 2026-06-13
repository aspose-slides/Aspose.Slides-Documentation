---
title: คอนเนคเตอร์
type: docs
weight: 190
url: /th/androidjava/examples/elements/connector/
keywords:
- ตัวอย่างโค้ด
- คอนเนคเตอร์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, กำหนดเส้นทางและจัดรูปแบบคอนเนคเตอร์ระหว่างรูปร่างโดยใช้ Aspose.Slides สำหรับ Android พร้อมตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX และ ODP."
---
บทความนี้แสดงวิธีเชื่อมต่อรูปร่างด้วยคอนเนคเตอร์และเปลี่ยนเป้าหมายของมันโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มคอนเนคเตอร์**
แทรกรูปร่างคอนเนคเตอร์ระหว่างจุดสองจุดบนสไลด์.

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
ดึงรูปร่างคอนเนคเตอร์แรกที่เพิ่มลงในสไลด์.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // เข้าถึงคอนเนคเตอร์แรกบนสไลด์.
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

## **เชื่อมต่อรูปทรงใหม่**
แนบคอนเนคเตอร์กับรูปทรงสองรูปโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

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