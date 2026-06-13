---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/androidjava/examples/elements/slide-transition/
keywords:
- ตัวอย่างโค้ด
- การเปลี่ยนสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Aspose.Slides for Android: เพิ่ม ปรับแต่ง และจัดลำดับเอฟเฟกต์และระยะเวลา ด้วยตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการตั้งเวลาโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบจางกับสไลด์แรก.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ใช้การเปลี่ยนแบบจาง.
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดไว้ในสไลด์ปัจจุบัน.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // เข้าถึงประเภทการเปลี่ยน.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟกต์การเปลี่ยนทั้งหมดโดยตั้งค่าชนิดเป็น `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // ลบการเปลี่ยนโดยตั้งค่าเป็น None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าระยะเวลาการเปลี่ยน**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเลื่อนต่อโดยอัตโนมัติ.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // หน่วยเป็นมิลลิวินาที.
    } finally {
        presentation.dispose();
    }
}
```