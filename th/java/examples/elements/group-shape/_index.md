---
title: กลุ่มรูปร่าง
type: docs
weight: 170
url: /th/java/examples/elements/group-shape/
keywords:
- ตัวอย่างโค้ด
- กลุ่มรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดการรูปทรงที่จัดกลุ่มใน Aspose.Slides for Java: สร้าง, ซ้อน, จัดแนว, เรียงลำดับใหม่, และกำหนดรูปแบบรูปทรงกลุ่มด้วยตัวอย่าง Java ในการนำเสนอ PPT, PPTX และ ODP"
---
ตัวอย่างการสร้างกลุ่มของรูปทรง, การเข้าถึง, การแยกกลุ่ม และการลบโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มกลุ่มรูปร่าง**

สร้างกลุ่มที่มีรูปทรงพื้นฐานสองอัน.

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

## **เข้าถึงกลุ่มรูปร่าง**

ดึงกลุ่มรูปร่างแรกจากสไลด์.

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

## **ลบกลุ่มรูปร่าง**

ลบกลุ่มรูปร่างออกจากสไลด์.

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

ย้ายรูปร่างออกจากคอนเทนเนอร์ของกลุ่ม.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // ย้ายรูปทรงออกจากกลุ่ม.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```