---
title: กลุ่มรูปทรง
type: docs
weight: 170
url: /th/androidjava/examples/elements/group-shape/
keywords:
- ตัวอย่างโค้ด
- กลุ่มรูปทรง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการรูปทรงที่จัดกลุ่มใน Aspose.Slides for Android: สร้าง, ซ้อน, จัดแนว, เรียงลำดับใหม่, และกำหนดสไตล์ให้กับรูปทรงกลุ่มด้วยตัวอย่าง Java ในงานนำเสนอ PPT, PPTX, และ ODP"
---
ตัวอย่างการสร้างกลุ่มของรูปทรง, การเข้าถึง, การแยกกลุ่ม, และการลบโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มกลุ่มรูปทรง**

สร้างกลุ่มที่มีรูปทรงพื้นฐานสองรูป.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงกลุ่มรูปทรง**

ดึงกลุ่มรูปทรงแรกจากสไลด์.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบกลุ่มรูปทรง**

ลบกลุ่มรูปทรงจากสไลด์.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **แยกกลุ่มรูปทรง**

ย้ายรูปทรงออกจากคอนเทนเนอร์กลุ่ม.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // ย้ายรูปร่างออกจากกลุ่ม.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```