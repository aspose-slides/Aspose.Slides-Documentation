---
title: Videó
type: docs
weight: 80
url: /hu/php-java/examples/elements/video/
keywords:
- videó
- videókeret
- videó hozzáadása
- videó elérése
- videó eltávolítása
- videó lejátszás
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Videóval való munka PHP-ben az Aspose.Slides használatával: beillesztés, csere, vágás, poszterképek és lejátszási beállítások megadása, valamint prezentációk exportálása PPT, PPTX és ODP formátumokra."
---
Bemutatja, hogyan ágyazhat be video kereteket, és állíthatja be a lejátszási beállításokat az **Aspose.Slides for PHP via Java** használatával.

## **Videókeret hozzáadása**

Videókeret beszúrása egy diára.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Videókeret hozzáadása.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Videókeret elérése**

Az első, a diára hozzáadott videókeret lekérése.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A dia első videókeretének elérése.
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

## **Videókeret eltávolítása**

Videókeret törlése a diákról.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakja a videókeret.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // A videókeret eltávolítása.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Videó lejátszás beállítása**

A videó beállítása, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakja a videókeret.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // A videó beállítása az automatikus lejátszáshoz.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```