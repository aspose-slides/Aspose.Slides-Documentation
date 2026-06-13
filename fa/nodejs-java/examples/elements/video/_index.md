---
title: ویدیو
type: docs
weight: 80
url: /fa/nodejs-java/examples/elements/video/
keywords:
- مثال کد
- ویدیو
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ویدیوها را با Aspose.Slides برای Node.js اضافه و کنترل کنید: درج، پخش، برش، تنظیم فریم‌های پوستر و صادر کردن با مثال‌ها برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه فریم‌های ویدئویی را جاسازی کرده و گزینه‌های پخش را با استفاده از **Aspose.Slides for Node.js via Java** تنظیم کنید.

## **افزودن فریم ویدئویی**

یک فریم ویدئویی به اسلاید اضافه کنید.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // یک ویدیو اضافه کنید.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به فریم ویدئویی**

فریم ویدئویی اول اضافه شده به اسلاید را بازیابی کنید.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین فریم ویدئویی در اسلاید.
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

## **حذف فریم ویدئویی**

یک فریم ویدئویی را از اسلاید حذف کنید.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل فریم ویدئویی است.
        let videoFrame = slide.getShapes().get_Item(0);

        // فریم ویدئویی را حذف کنید.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم پخش ویدئویی**

ویدئو را طوری تنظیم کنید که هنگام نمایش اسلاید به‌صورت خودکار پخش شود.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل فریم ویدئویی است.
        let videoFrame = slide.getShapes().get_Item(0);

        // پیکربندی ویدئو برای پخش خودکار.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```