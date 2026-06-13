---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/nodejs-java/examples/elements/slide-transition/
keywords:
- ตัวอย่างโค้ด
- การเปลี่ยนสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Node.js: เพิ่ม, ปรับแต่ง และจัดลำดับเอฟเฟกต์และระยะเวลา พร้อมตัวอย่างสำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการตั้งเวลาโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบจางกับสไลด์แรก.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ใช้การเปลี่ยนแบบจาง.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดให้สไลด์ในปัจจุบัน.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงประเภทการเปลี่ยน.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบการเปลี่ยนสไลด์**

ล้างเอฟเฟกต์การเปลี่ยนใดๆ โดยตั้งค่าชนิดเป็น `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ลบการเปลี่ยนโดยตั้งค่าเป็น None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งระยะเวลาการเปลี่ยน**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเลื่อนต่อโดยอัตโนมัติ.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // เป็นมิลลิวินาที.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```