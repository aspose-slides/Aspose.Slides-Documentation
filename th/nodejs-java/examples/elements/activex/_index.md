---
title: ActiveX
type: docs
weight: 200
url: /th/nodejs-java/examples/elements/activex/
keywords:
- ตัวอย่างโค้ด
- ActiveX
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ดูตัวอย่าง ActiveX ของ Aspose.Slides สำหรับ Node.js: แทรก, กำหนดค่า, และควบคุมวัตถุ ActiveX ในงานนำเสนอ PPT และ PPTX ด้วยโค้ด JavaScript ที่ชัดเจน."
---
บทความนี้สาธิตวิธีการเพิ่ม, เข้าถึง, ลบ และกำหนดค่า ActiveX controls ในงานนำเสนอโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่ม ActiveX Control**

เพิ่ม ActiveX control ใหม่ลงในสไลด์.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เพิ่มคอนโทรล ActiveX ใหม่.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึง ActiveX Control**

อ่านข้อมูลจาก ActiveX control ตัวแรกบนสไลด์.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // เข้าถึงคอนโทรล ActiveX ตัวแรก.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ ActiveX Control**

ลบ ActiveX control ที่มีอยู่จากสไลด์.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // ลบคอนโทรล ActiveX ตัวแรก.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่า ActiveX Properties**

กำหนดค่าคุณสมบัติหลายอย่างของ ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```