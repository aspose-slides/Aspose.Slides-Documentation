---
title: صوت
type: docs
weight: 70
url: /fa/nodejs-java/examples/elements/audio/
keywords:
- مثال کد
- صوت
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مثال‌های صوتی Aspose.Slides برای Node.js را کشف کنید: درج، پخش، برش و استخراج صدا در ارائه‌های PPT، PPTX و ODP با کد واضح JavaScript."
---
این مقاله نشان می‌دهد که چگونه فریم‌های صوتی را جاسازی کرده و پخش را با **Aspose.Slides for Node.js via Java** کنترل کنید. مثال‌های زیر عملیات پایه‌ای صوتی را نشان می‌دهند.

## **افزودن یک فریم صوتی**

مثال کد زیر یک فریم صوتی را در یک اسلاید ارائه اضافه می‌کند.

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

## **دسترسی به یک فریم صوتی**

این کد اولین فریم صوتی موجود در یک اسلاید را بازیابی می‌کند.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین فریم صوتی در اسلاید.
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

## **حذف یک فریم صوتی**

فریم صوتی قبلاً اضافه‌شده را حذف کنید.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل، فریم صوتی است.
        let audioFrame = slide.getShapes().get_Item(0);

        // فریم صوتی را حذف کنید.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم پخش صوتی**

فریم صوتی را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل یک فریم صوتی است.
        let audioFrame = slide.getShapes().get_Item(0);

        // به‌صورت خودکار هنگام نمایش اسلاید پخش شود.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```