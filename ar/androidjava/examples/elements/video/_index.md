---
title: فيديو
type: docs
weight: 80
url: /ar/androidjava/examples/elements/video/
keywords:
- مثال على الكود
- فيديو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة والتحكم في مقاطع الفيديو باستخدام Aspose.Slides للـ Android: إدراج، تشغيل، قص، تعيين إطارات الملصق، وتصدير مع أمثلة Java لعروض PPT، PPTX، وODP."
---
توضح هذه المقالة كيفية تضمين إطارات الفيديو وتحديد خيارات التشغيل باستخدام **Aspose.Slides for Android via Java**.

## **إضافة إطار فيديو**

إدراج إطار فيديو فارغ إلى شريحة.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إضافة فيديو.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى إطار فيديو**

استرجاع أول إطار فيديو تمت إضافته إلى شريحة.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // الوصول إلى أول إطار فيديو على الشريحة.
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

## **إزالة إطار فيديو**

حذف إطار فيديو من الشريحة.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // إزالة إطار الفيديو.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين تشغيل الفيديو**

ضبط الفيديو ليُشغل تلقائيًا عندما يتم عرض الشريحة.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // تهيئة الفيديو لتشغيله تلقائيًا.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```