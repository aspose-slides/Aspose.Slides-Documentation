---
title: ส่วน
type: docs
weight: 90
url: /th/androidjava/examples/elements/section/
keywords:
- ตัวอย่างโค้ด
- ส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการส่วนสไลด์ใน Aspose.Slides สำหรับ Android: สร้าง, เปลี่ยนชื่อ, จัดเรียงลำดับใหม่, และจัดกลุ่มสไลด์ด้วยตัวอย่าง Java สำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ, และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for Android via Java** ผ่านการเขียนโปรแกรม.

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มที่สไลด์เฉพาะ.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ระบุสไลด์ที่ทำเครื่องหมายการเริ่มต้นของส่วน.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // เข้าถึงส่วนโดยดัชนี.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้า.

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

เปลี่ยนชื่อส่วนที่มีอยู่.

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