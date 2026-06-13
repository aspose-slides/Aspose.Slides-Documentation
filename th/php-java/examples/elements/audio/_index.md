---
title: เสียง
type: docs
weight: 70
url: /th/php-java/examples/elements/audio/
keywords:
- เสียง
- เฟรมเสียง
- เพิ่มเสียง
- เข้าถึงเสียง
- ลบเสียง
- การเล่นเสียง
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับเสียงใน PHP โดยใช้ Aspose.Slides: เพิ่ม, แทนที่, แยกและตัดเสียง, ตั้งระดับเสียงและการเล่นสำหรับสไลด์และรูปร่างใน PowerPoint และ OpenDocument."
---
อธิบายวิธีฝังเฟรมเสียงและควบคุมการเล่นด้วย **Aspose.Slides for PHP via Java**. ตัวอย่างต่อไปนี้แสดงการทำงานพื้นฐานของเสียง

## **เพิ่มเฟรมเสียง**

แทรกเฟรมเสียง

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สร้างเฟรมเสียง.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้ดึงเฟรมเสียงแรกบนสไลด์

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงเฟรมเสียงแรกบนสไลด์.
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

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่ได้เพิ่มไว้ก่อนหน้านี้

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็นเฟรมเสียง.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // ลบเฟรมเสียง.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นอัตโนมัติเมื่อสไลด์ปรากฏ

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็นเฟรมเสียง.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // เล่นอัตโนมัติเมื่อสไลด์ปรากฏ.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```