---
title: فيديو
type: docs
weight: 80
url: /ar/java/examples/elements/video/
keywords:
- مثال على الكود
- فيديو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إضافة والتحكم في مقاطع الفيديو باستخدام Aspose.Slides for Java: الإدراج، التشغيل، القطع، تعيين إطارات الملصق، وتصدير أمثلة Java لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية تضمين إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for Java**.

## **إضافة إطار فيديو**

أدخل إطار فيديو فارغًا إلى الشريحة.

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

استرجع أول إطار فيديو تمت إضافته إلى الشريحة.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // الوصول إلى إطار الفيديو الأول على الشريحة.
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

احذف إطار فيديو من الشريحة.

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

قم بتكوين الفيديو لتشغيله تلقائيًا عند عرض الشريحة.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // تكوين الفيديو لتشغيله تلقائيًا.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```