---
title: วิดีโอ
type: docs
weight: 80
url: /th/php-java/examples/elements/video/
keywords:
- วิดีโอ
- เฟรมวิดีโอ
- เพิ่มวิดีโอ
- เข้าถึงวิดีโอ
- ลบวิดีโอ
- การเล่นวิดีโอ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับวิดีโอใน PHP ด้วย Aspose.Slides: แทรก, แทนที่, ตัด, ตั้งค่าเฟรมโปสเตอร์และตัวเลือกการเล่น, และส่งออกการนำเสนอเป็น PPT, PPTX และ ODP."
---
แสดงวิธีฝังเฟรมวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มเฟรมวิดีโอ**

แทรกเฟรมวิดีโอลงในสไลด์.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มเฟรมวิดีโอ.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงเฟรมวิดีโอ**

ดึงเฟรมวิดีโอแรกที่เพิ่มลงในสไลด์.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงเฟรมวิดีโอแรกบนสไลด์.
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

## **ลบเฟรมวิดีโอ**

ลบเฟรมวิดีโอออกจากสไลด์.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็นเฟรมวิดีโอ.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // ลบเฟรมวิดีโอ.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดให้วิดีโอเล่นอัตโนมัติเมื่อสไลด์แสดงผล.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็นเฟรมวิดีโอ.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // ตั้งค่าให้วิดีโอเล่นอัตโนมัติ.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```