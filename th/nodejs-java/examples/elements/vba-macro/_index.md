---
title: แมโคร VBA
type: docs
weight: 150
url: /th/nodejs-java/examples/elements/vba-macro/
keywords:
- ตัวอย่างโค้ด
- VBA
- แมโคร
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "อัตโนมัติการนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: สร้าง, นำเข้าและปกป้องแมโคร VBA ในไฟล์ PPT, PPTX, และ ODP ด้วยตัวอย่าง JavaScript ที่ชัดเจน."
---
บทความนี้แสดงให้เห็นวิธีการเพิ่ม, เข้าถึงและลบแมโคร VBA ด้วย **Aspose.Slides for Node.js via Java**.

## **เพิ่มแมโคร VBA**

สร้างงานนำเสนอพร้อมโครงการ VBA และโมดูลแมโครอย่างง่าย.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงแมโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // สมมติว่าการนำเสนอมีอย่างน้อยหนึ่งโมดูล VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบแมโคร VBA**

ลบโมดูลจากโครงการ VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // สมมติว่าการนำเสนอมีอย่างน้อยหนึ่งโมดูล VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```