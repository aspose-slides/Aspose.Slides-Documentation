---
title: สไลด์
type: docs
weight: 10
url: /th/java/examples/elements/slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมสไลด์ใน Aspose.Slides สำหรับ Java: สร้าง, คัดลอก, เรียงลำดับใหม่, ปรับขนาด, ตั้งค่าพื้นหลัง, และใช้การเปลี่ยนภาพด้วย Java สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้นำเสนอชุดตัวอย่างที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for Java** คุณจะได้เรียนรู้วิธีเพิ่ม, เข้าถึง, คัดลอก, เรียงลำดับใหม่, และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างจะประกอบด้วยคำอธิบายสั้น ๆ ตามด้วยโค้ดตัวอย่างใน Java.

## **เพิ่มสไลด์**

เพื่อเพิ่มสไลด์ใหม่ คุณต้องเลือกเลย์เอาต์ก่อน ในตัวอย่างนี้ เราใช้เลย์เอาต์ `Blank` และเพิ่มสไลด์เปล่าเข้าสู่การนำเสนอ.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ:** เลย์เอาต์ของสไลด์แต่ละอันจะสืบทอดมาจากมาสเตอร์สไลด์ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวเว้นที่เก็บข้อมูล ภาพด้านล่างแสดงให้เห็นว่ามาสเตอร์สไลด์และเลย์เอาต์ที่เกี่ยวข้องจัดระเบียบอย่างไรใน PowerPoint.

![ความสัมพันธ์ระหว่างมาสเตอร์และเลย์เอาต์](master-layout-slide.png)

## **เข้าถึงสไลด์โดยดัชนี**

คุณสามารถเข้าถึงสไลด์โดยใช้ดัชนีของมัน หรือค้นหาดัชนีของสไลด์จากการอ้างอิง วิธีนี้มีประโยชน์สำหรับการวนลูปหรือแก้ไขสไลด์เฉพาะเจาะจง.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // เพิ่มสไลด์เปล่าอื่นอีกหนึ่งสไลด์.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // เข้าถึงสไลด์โดยใช้ดัชนี.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // รับดัชนีสไลด์จากการอ้างอิง แล้วเข้าถึงโดยดัชนี.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **คัดลอกสไลด์**

ตัวอย่างนี้แสดงวิธีคัดลอกสไลด์ที่มีอยู่ สไลด์ที่คัดลอกจะถูกเพิ่มโดยอัตโนมัติไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **จัดเรียงสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์ได้โดยการย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ที่คัดลอกไปยังตำแหน่งแรก.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์**

เพื่อทำการลบสไลด์ ให้อ้างอิงสไลด์นั้นและเรียก `remove` ตัวอย่างนี้เพิ่มสไลด์ที่สองแล้วลบสไลด์เดิม ทำให้เหลือเฉพาะสไลด์ใหม่เท่านั้น.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```