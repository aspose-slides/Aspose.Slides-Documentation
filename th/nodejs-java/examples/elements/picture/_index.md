---
title: รูปภาพ
type: docs
weight: 50
url: /th/nodejs-java/examples/elements/picture/
keywords:
- ตัวอย่างโค้ด
- รูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Aspose.Slides for Node.js: แทรก, ครอบ, บีบอัด, เปลี่ยนสี, และส่งออกภาพพร้อมตัวอย่างสำหรับงานนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้สาธิตวิธีการแทรกและเข้าถึงรูปภาพโดยใช้ **Aspose.Slides for Node.js via Java** ตัวอย่างด้านล่างอ่านรูปภาพจากไฟล์ วางลงบนสไลด์ แล้วดึงคืนมา

## **เพิ่มรูปภาพ**
โค้ดนี้อ่านรูปภาพจากไฟล์และแทรกเป็นกรอบรูปบนสไลด์แรก

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // แทรกกรอบรูปที่แสดงภาพบนสไลด์แรก.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงรูปภาพ**
ตัวอย่างนี้ตรวจสอบให้สไลด์มีกรอบรูปแล้วจึงเข้าถึงกรอบรูปแรกที่พบ

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```