---
title: فيديو
type: docs
weight: 80
url: /ar/nodejs-java/examples/elements/video/
keywords:
- مثال على الكود
- فيديو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة والتحكم في مقاطع الفيديو باستخدام Aspose.Slides for Node.js: الإدراج، التشغيل، القص، تعيين إطارات الملصق، وتصدير مع أمثلة لعروض PPT وPPTX وODP."
---
توضح هذه المقالة كيفية تضمين إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة إطار فيديو**

أضف إطار فيديو إلى شريحة.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // أضف فيديو.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى إطار فيديو**

استرداد أول إطار فيديو تم إضافته إلى شريحة.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى أول إطار فيديو على الشريحة.
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

## **إزالة إطار فيديو**

حذف إطار فيديو من الشريحة.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو إطار الفيديو.
        let videoFrame = slide.getShapes().get_Item(0);

        // إزالة إطار الفيديو.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين تشغيل الفيديو**

تكوين الفيديو ليتم تشغيله تلقائيًا عند عرض الشريحة.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افترض أن الشكل الأول هو إطار الفيديو.
        let videoFrame = slide.getShapes().get_Item(0);

        // تكوين الفيديو ليتم تشغيله تلقائيًا.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```