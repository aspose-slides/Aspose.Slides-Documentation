---
title: Wideo
type: docs
weight: 80
url: /pl/php-java/examples/elements/video/
keywords:
- wideo
- ramka wideo
- dodaj wideo
- dostęp do wideo
- usuń wideo
- odtwarzanie wideo
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z wideo w PHP przy użyciu Aspose.Slides: wstawiaj, zastępuj, przycinaj, ustaw ramki plakatu i opcje odtwarzania oraz eksportuj prezentacje do PPT, PPTX i ODP."
---
Pokazuje, jak osadzić ramki wideo i ustawić opcje odtwarzania przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj ramkę wideo**

Wstaw ramkę wideo do slajdu.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj ramkę wideo.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
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

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka wideo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Usuń ramkę wideo.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj wideo tak, aby odtwarzało się automatycznie, gdy slajd jest wyświetlany.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka wideo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Skonfiguruj wideo, aby odtwarzało się automatycznie.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```