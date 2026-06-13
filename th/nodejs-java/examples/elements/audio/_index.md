---
title: เสียง
type: docs
weight: 70
url: /th/nodejs-java/examples/elements/audio/
keywords:
- ตัวอย่างโค้ด
- เสียง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบตัวอย่างเสียงของ Aspose.Slides for Node.js: แทรก, เล่น, ตัดต่อ และสกัดเสียงในงานนำเสนอ PPT, PPTX และ ODP ด้วยโค้ด JavaScript ที่ชัดเจน"
---
บทความนี้สาธิตวิธีฝังเฟรมเสียงและควบคุมการเล่นด้วย **Aspose.Slides for Node.js via Java** ตัวอย่างต่อไปนี้แสดงการทำงานพื้นฐานของเสียง

## **เพิ่มเฟรมเสียง**

ตัวอย่างโค้ดด้านล่างเพิ่มเฟรมเสียงในสไลด์การนำเสนอ

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้ดึงเฟรมเสียงแรกบนสไลด์

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงเฟรมเสียงแรกบนสไลด์.
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่เพิ่มไว้ก่อนหน้า

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกคือเฟรมเสียง.
        let audioFrame = slide.getShapes().get_Item(0);

        // ลบเฟรมเสียง.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นอัตโนมัติเมื่อสไลด์ปรากฏ

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกคือเฟรมเสียง.
        let audioFrame = slide.getShapes().get_Item(0);

        // เล่นอัตโนมัติเมื่อสไลด์ปรากฏ.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```