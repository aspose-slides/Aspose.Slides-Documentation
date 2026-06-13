---
title: ส่วนหัว ส่วนท้าย
type: docs
weight: 220
url: /th/java/examples/elements/header-footer/
keywords:
- ตัวอย่างโค้ด
- ส่วนหัว
- ส่วนท้าย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides for Java: เพิ่มวันที่ หมายเลขสไลด์ และข้อความกำหนดเองใน PPT, PPTX, และ ODP ด้วยตัวอย่าง Java."
---
บทความนี้แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวยึดวันที่และเวลาด้วย **Aspose.Slides for Java**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความในพื้นที่ส่วนท้ายของสไลด์และทำให้มองเห็นได้.

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

แก้ไขตัวยึดวันที่และเวลาบนสไลด์.

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