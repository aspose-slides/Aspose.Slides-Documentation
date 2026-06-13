---
title: ویدئو
type: docs
weight: 80
url: /fa/java/examples/elements/video/
keywords:
- نمونه کد
- ویدئو
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویدئوها را با Aspose.Slides برای Java اضافه و کنترل کنید: وارد کردن، پخش، برش، تنظیم فریم‌های پوستر و استخراج با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه فریم‌های ویدئویی را وارد کنید و گزینه‌های پخش را با استفاده از **Aspose.Slides for Java** تنظیم کنید.

## **افزودن فریم ویدئو**

یک فریم ویدئویی خالی را به یک اسلاید وارد کنید.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // افزودن یک ویدئو.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به فریم ویدئو**

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

## **حذف فریم ویدئو**

یک فریم ویدئویی را از اسلاید حذف کنید.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // حذف فریم ویدئو.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم پخش ویدئو**

ویدئو را به گونه‌ای تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // تنظیم ویدئو برای پخش خودکار.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```