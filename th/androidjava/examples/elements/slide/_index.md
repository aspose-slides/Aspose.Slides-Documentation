---
title: สไลด์
type: docs
weight: 10
url: /th/androidjava/examples/elements/slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมสไลด์ใน Aspose.Slides for Android: สร้าง, คัดลอก, จัดลำดับใหม่, ปรับขนาด, ตั้งค่าแบ็คกราวด์, และใช้การเปลี่ยนภาพด้วย Java สำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้ให้ชุดตัวอย่างที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for Android via Java** คุณจะได้เรียนรู้วิธีเพิ่ม, เข้าถึง, คัดลอก, จัดลำดับใหม่, และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างจะมีคำอธิบายสั้น ๆ ตามด้วยโค้ดสแนปช็อตใน Java.

## **เพิ่มสไลด์**

ในการเพิ่มสไลด์ใหม่ คุณต้องเลือกเค้าโครงก่อน ในตัวอย่างนี้ เราใช้เค้าโครง `Blank` และเพิ่มสไลด์เปล่าไปยังงานนำเสนอ.

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

> 💡 **หมายเหตุ:** เค้าโครงสไลด์แต่ละแบบสืบมาจากสไลด์หลัก ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างตัวจัดเก็บข้อมูล ภาพด้านล่างแสดงให้เห็นว่าสติร์ดหลักและเค้าโครงที่เกี่ยวข้องจัดเรียงอย่างไรใน PowerPoint.

![ความสัมพันธ์ระหว่างสไลด์หลักและเค้าโครง](master-layout-slide.png)

## **เข้าถึงสไลด์โดยดัชนี**

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // เพิ่มสไลด์เปล่าอีกหนึ่งสไลด์.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // เข้าถึงสไลด์โดยใช้ดัชนี.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // ดึงดัชนีสไลด์จากการอ้างอิงแล้วเข้าถึงโดยใช้ดัชนี.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **คัดลอกสไลด์**

ตัวอย่างนี้แสดงวิธีคัดลอกสไลด์ที่มีอยู่ สไลด์ที่คัดลอกจะถูกเพิ่มโดยอัตโนมัติเข้าไปที่ส่วนท้ายของคอลเลกชันสไลด์.

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

## **จัดลำดับสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์โดยย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ที่คัดลอกไปยังตำแหน่งแรก.

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

เพื่อลบสไลด์ เพียงอ้างอิงสไลด์นั้นและเรียก `remove` ตัวอย่างนี้จะเพิ่มสไลด์ที่สองแล้วลบสไลด์เดิม ทำให้เหลือเพียงสไลด์ใหม่.

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