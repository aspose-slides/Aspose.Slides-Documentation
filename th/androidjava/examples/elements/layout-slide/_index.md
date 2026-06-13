---
title: สไลด์เค้าโครง
type: docs
weight: 20
url: /th/androidjava/examples/elements/layout-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์เค้าโครง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมสไลด์เค้าโครงใน Aspose.Slides สำหรับ Android: เลือก ใช้งาน และปรับแต่งเค้าโครงสไลด์, ตัวแทนตำแหน่ง, และมาสเตอร์ด้วยตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้สาธิบายวิธีการทำงานกับ **Layout Slides** ใน Aspose.Slides สำหรับ Android ผ่าน Java. Layout slide กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, คัดลอก, และลบ layout slides รวมถึงทำความสะอาดที่ไม่ได้ใช้เพื่อ ลดขนาดการนำเสนอ.

## **เพิ่ม Layout Slide**

คุณสามารถสร้าง layout slide แบบกำหนดเองเพื่อกำหนดรูปแบบที่สามารถนำกลับมาใช้ใหม่ได้ ตัวอย่างเช่น คุณอาจเพิ่มกล่องข้อความที่ปรากฏบนทุกสไลด์โดยใช้ layout นี้.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // สร้างสไลด์เค้าโครงด้วยประเภทเค้าโครงเปล่าและชื่อที่กำหนดเอง
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // เพิ่มกล่องข้อความไปยังสไลด์เค้าโครง
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // เพิ่มสองสไลด์โดยใช้เค้าโครงนี้; ทั้งสองจะสืบทอดข้อความจากเค้าโครง
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ 1:** Layout slides ทำหน้าที่เป็นแม่แบบสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปเพียงครั้งเดียวและนำกลับมาใช้ใหม่ในหลายสไลด์.
> 💡 **หมายเหตุ 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงใน layout slide สไลด์ทั้งหมดที่อิงตาม layout นั้นจะทำการแสดงเนื้อหาร่วมนี้โดยอัตโนมัติ.
> ภาพหน้าจอด้านล่างแสดงสองสไลด์ที่แต่ละสไลด์สืบทอดกล่องข้อความจาก layout slide เดียวกัน.

![สไลด์สืบทอดเนื้อหา Layout](layout-slide-result.png)

## **เข้าถึง Layout Slide**

สามารถเข้าถึง Layout slides ได้ด้วยดัชนีหรือโดยประเภท layout (เช่น `Blank`, `Title`, `SectionHeader`, เป็นต้น).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // เข้าถึงสไลด์เค้าโครงตามดัชนี.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // เข้าถึงสไลด์เค้าโครงตามประเภท.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Layout Slide**

คุณสามารถลบ layout slide เฉพาะที่ไม่จำเป็นต้องใช้แล้วได้.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // รับสไลด์เค้าโครงตามประเภทและลบออก.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

เพื่อให้ขนาดการนำเสนอลดลง คุณอาจต้องการลบ layout slides ที่ไม่มีสไลด์ปกติใดใช้.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // ลบสไลด์เค้าโครงทั้งหมดที่ไม่ได้อ้างอิงโดยสไลด์ใด ๆโดยอัตโนมัติ.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **คัดลอก Layout Slide**

คุณสามารถทำสำเนา layout slide ด้วยวิธี `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // รับสไลด์เค้าโครงที่มีอยู่ตามประเภท.
        // ทำสำเนาสไลด์เค้าโครงไปยังตำแหน่งสุดท้ายของคอลเลคชันสไลด์เค้าโครง.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **สรุป:** Layout slides เป็นเครื่องมือที่มีประสิทธิภาพสำหรับการจัดการรูปแบบที่สอดคล้องกันทั่วทั้งสไลด์ Aspose.Slides ให้การควบคุมเต็มที่ในการสร้าง, จัดการ, และเพิ่มประสิทธิภาพของ layout slides.