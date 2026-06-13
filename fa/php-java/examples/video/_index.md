---
title: ویدئو
type: docs
weight: 80
url: /fa/php-java/examples/elements/video/
keywords:
  - ویدئو
  - قاب ویدئویی
  - افزودن ویدئو
  - دسترسی به ویدئو
  - حذف ویدئو
  - پخش ویدئو
  - مثال‌های کد
  - PowerPoint
  - OpenDocument
  - ارائه
  - PHP
  - Aspose.Slides
description: "کار با ویدئو در PHP با استفاده از Aspose.Slides: درج، جایگزینی، برش، تنظیم قاب‌های پوستر و گزینه‌های پخش، و استخراج ارائه‌ها برای PPT، PPTX و ODP."
---
نحوه درج قاب‌های ویدئویی و تنظیم گزینه‌های پخش را با استفاده از **Aspose.Slides for PHP via Java** نشان می‌دهد.

## **افزودن یک قاب ویدئویی**

یک قاب ویدئویی را در یک اسلاید درج کنید.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک قاب ویدئویی اضافه کنید.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به یک قاب ویدئویی**

اولین قاب ویدئویی اضافه شده به یک اسلاید را بازیابی کنید.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین قاب ویدئویی در اسلاید.
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

## **حذف یک قاب ویدئویی**

یک قاب ویدئویی را از اسلاید حذف کنید.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید قاب ویدئویی است.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // قاب ویدئویی را حذف کنید.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تنظیم پخش ویدئو**

پیکربندی کنید تا ویدئو به طور خودکار هنگام نمایش اسلاید اجرا شود.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید قاب ویدئویی است.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // پیکربندی کنید تا ویدئو به طور خودکار اجرا شود.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```