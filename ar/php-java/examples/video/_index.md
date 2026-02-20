---
title: فيديو
type: docs
weight: 80
url: /ar/php-java/examples/elements/video/
keywords:
- فيديو
- إطار فيديو
- إضافة فيديو
- الوصول إلى فيديو
- حذف فيديو
- تشغيل فيديو
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع مقاطع الفيديو في PHP باستخدام Aspose.Slides: إدراج، استبدال، قص، تعيين إطارات الملصق وخيارات التشغيل، وتصدير العروض التقديمية إلى PPT و PPTX و ODP."
---
يوضح كيفية تضمين إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة إطار فيديو**

إدراج إطار فيديو في الشريحة.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة إطار فيديو.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى إطار فيديو**

استرجاع أول إطار فيديو تمت إضافته إلى الشريحة.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول إطار فيديو على الشريحة.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة إطار فيديو**

حذف إطار فيديو من الشريحة.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو إطار الفيديو.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // إزالة إطار الفيديو.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تعيين تشغيل الفيديو**

تكوين الفيديو لتشغيله تلقائيًا عند عرض الشريحة.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو إطار الفيديو.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // تكوين الفيديو ليتم تشغيله تلقائيًا.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```