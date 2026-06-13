---
title: ส่วน
type: docs
weight: 90
url: /th/nodejs-java/examples/elements/section/
keywords:
- ตัวอย่างโค้ด
- ส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการส่วนสไลด์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java: สร้าง, เปลี่ยนชื่อ, จัดเรียงใหม่, และจัดกลุ่มสไลด์ด้วยตัวอย่าง JavaScript สำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มต้นที่สไลด์เฉพาะหนึ่ง.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ระบุสไลด์ที่เป็นจุดเริ่มต้นของส่วน
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงส่วนโดยใช้ดัชนี
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้านี้.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ลบส่วนแรก.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```