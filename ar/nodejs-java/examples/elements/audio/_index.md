---
title: الصوت
type: docs
weight: 70
url: /ar/nodejs-java/examples/elements/audio/
keywords:
- مثال على الكود
- الصوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف أمثلة الصوت لـ Aspose.Slides for Node.js: إدراج، تشغيل، قص، واستخراج الصوت في عروض PPT و PPTX و ODP مع شفرة JavaScript واضحة."
---
توضح هذه المقالة كيفية تضمين إطارات الصوت والتحكم في التشغيل باستخدام **Aspose.Slides for Node.js via Java**. تظهر الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوت**

تضيف عينة الشيفرة أدناه إطار صوت إلى شريحة عرض.

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

## **الوصول إلى إطار صوت**

تسترجع هذه الشيفرة أول إطار صوت في الشريحة.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى أول إطار صوت في الشريحة.
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

## **إزالة إطار صوت**

احذف إطار صوت تم إضافته مسبقًا.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو إطار الصوت.
        let audioFrame = slide.getShapes().get_Item(0);

        // إزالة إطار الصوت.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين تشغيل الصوت**

قم بتكوين إطار الصوت ليُشغَّل تلقائيًا عند ظهور الشريحة.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو إطار صوت.
        let audioFrame = slide.getShapes().get_Item(0);

        // تشغيل تلقائيًا عند ظهور الشريحة.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```