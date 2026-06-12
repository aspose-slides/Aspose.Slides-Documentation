---
title: Video
type: docs
weight: 80
url: /nl/php-java/examples/elements/video/
keywords:
- video
- videoframe
- video toevoegen
- video openen
- video verwijderen
- video afspelen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werken met video in PHP met Aspose.Slides: invoegen, vervangen, bijsnijden, posterframes en afspeelopties instellen, en presentaties exporteren naar PPT, PPTX en ODP."
---
Toont hoe u videoframes kunt insluiten en afspeelopties kunt instellen met **Aspose.Slides for PHP via Java**.

## **Video-frame toevoegen**

Voeg een videoframe toe aan een dia.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een videoframe toe.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Toegang tot een videoframe**

Haal het eerste toegevoegde videoframe op van een dia.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste videoframe op de dia.
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

## **Video-frame verwijderen**

Verwijder een videoframe van de dia.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia het videoframe is.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Verwijder het videoframe.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Video-afspelen instellen**

Stel het video zo in dat deze automatisch wordt afgespeeld wanneer de dia wordt weergegeven.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia het videoframe is.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Stel de video in om automatisch af te spelen.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```