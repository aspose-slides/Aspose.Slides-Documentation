---
title: วัตถุ OLE
type: docs
weight: 210
url: /th/nodejs-java/examples/elements/ole-object/
keywords:
- ตัวอย่างโค้ด
- วัตถุ OLE
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการวัตถุ OLE ใน Aspose.Slides for Node.js: แทรก, ลิงก์, อัปเดต, และดึงเนื้อหาที่ฝังไว้ด้วย JavaScript ในงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้สาธิตการฝังไฟล์เป็นวัตถุ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มวัตถุ OLE**

ฝังไฟล์ PDF ลงในงานนำเสนอ.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงวัตถุ OLE**

ดึงกรอบวัตถุ OLE ตัวแรกบนสไลด์.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบวัตถุ OLE**

ลบวัตถุ OLE ที่ฝังอยู่จากสไลด์.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปแรกเป็นกรอบวัตถุ OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตข้อมูลวัตถุ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในวัตถุ OLE ที่มีอยู่.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปแรกเป็นกรอบวัตถุ OLE.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```