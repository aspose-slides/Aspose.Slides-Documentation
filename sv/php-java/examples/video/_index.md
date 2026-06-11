---
title: Video
type: docs
weight: 80
url: /sv/php-java/examples/elements/video/
keywords:
- video
- videoram
- lägg till video
- åtkomst till video
- ta bort video
- videouppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med video i PHP med Aspose.Slides: infoga, ersätta, trimma, ställa in poster-ramar och uppspelningsalternativ, samt exportera presentationer för PPT, PPTX och ODP."
---
Visar hur man bäddar in videoramar och ställer in uppspelningsalternativ med **Aspose.Slides for PHP via Java**.

## **Lägg till en videoram**

Infoga en videoram i en bild.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till en videoram.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kom åt en videoram**

Hämta den första videoramen som lagts till i en bild.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första videoramen på bilden.
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

## **Ta bort en videoram**

Ta bort en videoram från bilden.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är videoramen.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Ta bort videoramen.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är videoramen.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Konfigurera videon att spelas upp automatiskt.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```