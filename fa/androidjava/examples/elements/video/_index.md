---
title: ویدیو
type: docs
weight: 80
url: /fa/androidjava/examples/elements/video/
keywords:
- نمونه کد
- ویدیو
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ویدیوها را با Aspose.Slides برای Android اضافه کنید و کنترل کنید: درج، پخش، برش، تنظیم فریم‌های پوستر، و خروجی با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه‌ی جاسازی فریم‌های ویدئویی و تنظیم گزینه‌های پخش را با استفاده از **Aspose.Slides for Android via Java** نشان می‌دهد.

## **افزودن فریم ویدئویی**

یک فریم ویدئویی خالی را روی اسلاید اضافه کنید.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک ویدیو اضافه کنید.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به فریم ویدئویی**

اولین فریم ویدئویی اضافه شده به اسلاید را بازیابی کنید.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // دسترسی به اولین فریم ویدئویی در اسلاید.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف فریم ویدئویی**

فریم ویدئویی را از اسلاید حذف کنید.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // فریم ویدئو را حذف کنید.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم پخش ویدئویی**

ویدئو را طوری تنظیم کنید که هنگام نمایش اسلاید به‌صورت خودکار پخش شود.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // پیکربندی ویدیو برای پخش خودکار.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```