---
title: ส่วนหัวและส่วนท้าย
type: docs
weight: 220
url: /th/androidjava/examples/elements/header-footer/
keywords:
- ตัวอย่างโค้ด
- ส่วนหัว
- ส่วนท้าย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides for Android: เพิ่มวันที่ เลขสไลด์ และข้อความกำหนดเองใน PPT, PPTX, และ ODP ด้วยตัวอย่าง Java."
---
บทความนี้แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวแสดงตำแหน่งวันที่และเวลาโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความลงในพื้นที่ส่วนท้ายของสไลด์และทำให้มองเห็นได้.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวแสดงตำแหน่งวันที่และเวลาในสไลด์.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```