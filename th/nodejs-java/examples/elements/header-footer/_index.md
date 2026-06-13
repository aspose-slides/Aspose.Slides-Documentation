---
title: ส่วนหัวและส่วนท้าย
type: docs
weight: 220
url: /th/nodejs-java/examples/elements/header-footer/
keywords:
- ตัวอย่างโค้ด
- ส่วนหัว
- ส่วนท้าย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides สำหรับ Node.js: เพิ่มวันที่ หมายเลขสไลด์ และข้อความกำหนดเองในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่าง JavaScript."
---
บทความนี้แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวยึดวันที่และเวลาโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความในพื้นที่ส่วนท้ายของสไลด์และทำให้มองเห็นได้.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวยึดวันที่และเวลาบนสไลด์.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```