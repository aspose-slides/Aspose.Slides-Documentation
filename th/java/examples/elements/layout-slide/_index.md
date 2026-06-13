---
title: สไลด์เลเอาต์
type: docs
weight: 20
url: /th/java/examples/elements/layout-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์เลเอาต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมสไลด์เลเอาต์ใน Aspose.Slides for Java: เลือก ใช้ และปรับแต่งเลเออตสไลด์ แพลตฟอร์มตัวยึดตำแหน่ง และมาสเตอร์ด้วยตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX และ ODP"
---
บทความนี้แสดงวิธีทำงานกับ **Layout Slides** ใน Aspose.Slides for Java เฉพาะหน้าเลย์เอาต์กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, ทำสำเนา, และลบหน้าเลย์เอาต์ได้ รวมทั้งทำความสะอาดหน้าที่ไม่ได้ใช้เพื่อลดขนาดของงานนำเสนอ

## **เพิ่ม Layout Slide**

คุณสามารถสร้างหน้าเลย์เอาต์แบบกำหนดเองเพื่อกำหนดการจัดรูปแบบที่ใช้ซ้ำได้ ตัวอย่างเช่น คุณอาจเพิ่มกล่องข้อความที่ปรากฏบนทุกสไลด์ที่ใช้เลย์เอาต์นี้

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // สร้างสไลด์เลเอาต์ด้วยประเภทเลเอาต์เปล่าและชื่อที่กำหนดเอง.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // เพิ่มกล่องข้อความลงในสไลด์เลเอาต์.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // เพิ่มสไลด์สองสไลด์โดยใช้เลเอาต์นี้; ทั้งสองจะสืบทอดข้อความจากเลเอาต์.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ 1:** Layout slides ทำหน้าที่เป็นเทมเพลตสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปเพียงครั้งเดียวและนำไปใช้ซ้ำในหลายสไลด์
> 
> 💡 **หมายเหตุ 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงในหน้าเลย์เอาต์ สไลด์ทั้งหมดที่อิงจากเลย์เอาต์นี้จะอัตโนมัติแสดงเนื้อหาที่แชร์นี้
> 
> ภาพหน้าจอด้านล่างแสดงสไลด์สองสไลด์ ซึ่งแต่ละสไลด์สืบทอดกล่องข้อความจากหน้าเลย์เอาต์เดียวกัน

![Slides Inheriting Layout Content](layout-slide-result.png)

## **เข้าถึง Layout Slide**

สามารถเข้าถึง Layout slides ได้โดยใช้ดัชนีหรือโดยประเภทของเลย์เอาต์ (เช่น `Blank`, `Title`, `SectionHeader` ฯลฯ).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // เข้าถึงสไลด์เลเอาต์โดยดัชนี.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // เข้าถึงสไลด์เลเอาต์โดยประเภท.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Layout Slide**

คุณสามารถลบหน้าเลย์เอาต์ที่ระบุได้หากไม่ต้องการใช้อีกต่อไป

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // รับสไลด์เลเอาต์โดยประเภทและลบออก.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

เพื่อลดขนาดของงานนำเสนอ คุณอาจต้องการลบ Layout slides ที่ไม่มีสไลด์ปกติใดใช้

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // อัตโนมัติลบสไลด์เลเอาต์ทั้งหมดที่ไม่ได้อ้างอิงโดยสไลด์ใดเลย.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **ทำสำเนา Layout Slide**

คุณสามารถทำสำเนา Layout slide ด้วยเมธอด `addClone`

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // รับสไลด์เลเอาต์ที่มีอยู่โดยประเภท.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // สร้างสำเนาสไลด์เลเอาต์ไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เลเอาต์.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **สรุป:** Layout slides เป็นเครื่องมือที่ทรงพลังสำหรับการจัดการการจัดรูปแบบที่สอดคล้องกันทั่วสไลด์ Aspose.Slides ให้การควบคุมเต็มรูปแบบในการสร้าง, จัดการ, และปรับแต่ง Layout slides.