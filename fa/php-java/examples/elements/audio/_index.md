---
title: صوت
type: docs
weight: 70
url: /fa/php-java/examples/elements/audio/
keywords:
- صوت
- فریم صوتی
- افزودن صدا
- دسترسی به صدا
- حذف صدا
- پخش صدا
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کار با صدا در PHP با استفاده از Aspose.Slides: افزودن، جایگزینی، استخراج و برش صداها، تنظیم حجم و پخش برای اسلایدها و اشکال در PowerPoint و OpenDocument."
---
نشان می‌دهد چگونه فریم‌های صوتی را جاسازی کرده و پخش را با **Aspose.Slides for PHP via Java** کنترل کنید. مثال‌های زیر عملیات پایه‌ای صوتی را نشان می‌دهند.

## **افزودن فریم صوتی**

یک فریم صوتی وارد کنید.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ایجاد یک فریم صوتی.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به فریم صوتی**

این کد اولین فریم صوتی در یک اسلاید را بازیابی می‌کند.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین فریم صوتی در اسلاید.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف فریم صوتی**

فریم صوتی که پیشتر افزوده شده بود را حذف کنید.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید یک فریم صوتی است.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // حذف فریم صوتی.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تنظیم پخش صوتی**

فریم صوتی را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض بر این است که اولین شکل در اسلاید یک فریم صوتی است.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // به صورت خودکار هنگام نمایش اسلاید پخش شود.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```