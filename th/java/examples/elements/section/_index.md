---
title: ส่วน
type: docs
weight: 90
url: /th/java/examples/elements/section/
keywords:
- ตัวอย่างโค้ด
- ส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการส่วนสไลด์ใน Aspose.Slides for Java: สร้าง, เปลี่ยนชื่อ, เรียงลำดับใหม่, และจัดกลุ่มสไลด์ด้วยตัวอย่าง Java สำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ, และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for Java** อย่างโปรแกรม

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มต้นที่สไลด์เฉพาะ

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ระบุสไลด์ที่ทำเครื่องหมายจุดเริ่มต้นของส่วน.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // เข้าถึงส่วนโดยใช้ดัชนี.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้า

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // ลบส่วนแรก.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```