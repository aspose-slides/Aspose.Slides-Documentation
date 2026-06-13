---
title: สไลด์
type: docs
weight: 10
url: /th/nodejs-java/examples/elements/slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมสไลด์ใน Aspose.Slides for Node.js: สร้าง, คัดลอก, จัดเรียงใหม่, ปรับขนาด, ตั้งค่าพื้นหลัง, และใช้การเปลี่ยนภาพสำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้นำเสนอตัวอย่างหลายชุดที่สาธิตวิธีทำงานกับสไลด์โดยใช้ **Aspose.Slides for Node.js via Java** คุณจะได้เรียนรู้วิธีเพิ่ม, เข้าถึง, คัดลอก, จัดเรียงใหม่, และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างจะมีคำอธิบายสั้น ๆ ตามด้วยโค้ดสแน็ปใน JavaScript.

## **เพิ่มสไลด์**

เพื่อเพิ่มสไลด์ใหม่ คุณต้องเลือกเค้าโครงก่อน ในตัวอย่างนี้ เราใช้เค้าโครง `Blank` และเพิ่มสไลด์เปล่าลงในงานนำเสนอ.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** แต่ละเค้าโครงสไลด์มาจากสไลด์แม่ ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตำแหน่งตัวเก็บข้อมูล รูปภาพด้านล่างแสดงให้เห็นว่าการจัดระเบียบของสไลด์แม่และเค้าโครงที่เกี่ยวข้องใน PowerPoint เป็นอย่างไร

![Master and Layout Relationship](master-layout-slide.png)

## **เข้าถึงสไลด์โดยดัชนี**

คุณสามารถเข้าถึงสไลด์โดยใช้ดัชนีของมัน ซึ่งเป็นประโยชน์สำหรับการวนรายการหรือแก้ไขสไลด์เฉพาะเจาะจง.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // เข้าถึงสไลด์โดยใช้ดัชนี.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **ทำสำเนาสไลด์**

ตัวอย่างนี้แสดงวิธีทำสำเนาสไลด์ที่มีอยู่ สไลด์ที่ทำสำเนาจะถูกเพิ่มอัตโนมัติไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **จัดเรียงสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์ได้โดยการย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ไปยังตำแหน่งแรก.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // จัดเรียงสไลด์ใหม่โดยย้ายสไลด์ที่สองไปยังตำแหน่งแรก.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์**

เพื่อลบสไลด์ เพียงอ้างอิงสไลด์นั้นและเรียกใช้ `remove` ตัวอย่างนี้เพิ่มสไลด์ที่สองแล้วลบสไลด์ต้นฉบับ ทำให้เหลือเพียงสไลด์ใหม่เท่านั้น.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```