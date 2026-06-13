---
title: วิดีโอ
type: docs
weight: 80
url: /th/nodejs-java/examples/elements/video/
keywords:
- ตัวอย่างโค้ด
- วิดีโอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มและควบคุมวิดีโอด้วย Aspose.Slides for Node.js: แทรก, เล่น, ตัด, ตั้งค่าเฟรมโปสเตอร์, และส่งออกพร้อมตัวอย่างสำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้สาธิตวิธีแทรกเฟรมวิดีโอและกำหนดตัวเลือกการเล่นโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มเฟรมวิดีโอ**

เพิ่มเฟรมวิดีโอลงในสไลด์.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เพิ่มวิดีโอ.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงเฟรมวิดีโอ**

ดึงเฟรมวิดีโอตัวแรกที่เพิ่มลงในสไลด์.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงเฟรมวิดีโอตัวแรกบนสไลด์.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบเฟรมวิดีโอ**

ลบเฟรมวิดีโอออกจากสไลด์.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape ตัวแรกคือเฟรมวิดีโอ.
        let videoFrame = slide.getShapes().get_Item(0);

        // ลบเฟรมวิดีโอ.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดให้วิดีโอเล่นอัตโนมัติเมื่อสไลด์แสดงผล.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape ตัวแรกคือเฟรมวิดีโอ.
        let videoFrame = slide.getShapes().get_Item(0);

        // กำหนดให้วิดีโอเล่นอัตโนมัติ.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```