---
title: หมึก
type: docs
weight: 180
url: /th/java/examples/elements/ink/
keywords:
- ตัวอย่างโค้ด
- หมึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำงานกับหมึกใน Aspose.Slides for Java: วาด, นำเข้าและแก้ไขลายเส้น, ปรับสีและความกว้าง, และส่งออกเป็น PPT, PPTX และ ODP ด้วยตัวอย่าง Java."
---
บทความนี้ให้ตัวอย่างการเข้าถึงรูปแบบหมึกที่มีอยู่และการลบออกโดยใช้ **Aspose.Slides for Java**.

> ❗ **หมายเหตุ:** รูปแบบหมึกแสดงถึงการป้อนข้อมูลของผู้ใช้จากอุปกรณ์พิเศษ. Aspose.Slides ไม่สามารถสร้างลายเส้นหมึกใหม่โดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่ได้.

## **เข้าถึงหมึก**

อ่านแท็กจากรูปแบบหมึกแรกบนสไลด์.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // ใช้ tagName ตามต้องการ.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบหมึก**

ลบรูปแบบหมึกออกจากสไลด์หากมีอยู่.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```