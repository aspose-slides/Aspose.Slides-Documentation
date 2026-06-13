---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/java/examples/elements/slide-transition/
keywords:
- ตัวอย่างโค้ด
- การเปลี่ยนสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Aspose.Slides for Java: เพิ่ม ปรับแต่ง และจัดลำดับเอฟเฟกต์และระยะเวลา พร้อมตัวอย่าง Java สำหรับไฟล์นำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการกำหนดเวลาโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบเฟดกับสไลด์แรก.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ใช้การเปลี่ยนแบบเฟด.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดให้สไลด์อยู่ในขณะนี้.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // เข้าถึงประเภทการเปลี่ยนสไลด์.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟกต์การเปลี่ยนใด ๆ โดยตั้งค่าชนิดเป็น `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // ลบการเปลี่ยนโดยตั้งค่าเป็น none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าระยะเวลาในการเปลี่ยน**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเลื่อนไปอัตโนมัติ.

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