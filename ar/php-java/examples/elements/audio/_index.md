---
title: صوت
type: docs
weight: 70
url: /ar/php-java/examples/elements/audio/
keywords:
- صوت
- إطار صوت
- إضافة صوت
- الوصول إلى صوت
- إزالة صوت
- تشغيل الصوت
- أمثلة على الشفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "العمل مع الصوت في PHP باستخدام Aspose.Slides: إضافة، استبدال، استخراج وتقطيع الأصوات، ضبط مستوى الصوت وتشغيله للشرائح والأشكال في PowerPoint وOpenDocument."
---
يوضح كيفية تضمين إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for PHP via Java**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوتي**

إدراج إطار صوتي.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إنشاء إطار صوتي.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى إطار صوتي**

يقوم هذا الكود باسترداد أول إطار صوتي في الشريحة.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول إطار صوت على الشريحة.
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

## **إزالة إطار صوتي**

حذف إطار صوت تم إضافته مسبقاً.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو إطار صوت.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // إزالة إطار الصوت.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ضبط تشغيل الصوت**

قم بتكوين إطار الصوت ليتم تشغيله تلقائيًا عند ظهور الشريحة.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول على الشريحة هو إطار صوت.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // تشغيل تلقائي عند ظهور الشريحة.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```