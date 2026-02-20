---
title: Video
type: docs
weight: 80
url: /de/php-java/examples/elements/video/
keywords:
- Video
- Video-Frame
- Video hinzufügen
- Zugriff auf Video
- Video entfernen
- Videowiedergabe
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit Video in PHP mit Aspose.Slides: Einfügen, Ersetzen, Trimmen, Poster-Frames festlegen und Wiedergabeoptionen konfigurieren sowie Präsentationen für PPT, PPTX und ODP exportieren."
---
Zeigt, wie man Videoframes einbettet und Wiedergabeoptionen festlegt, mit **Aspose.Slides für PHP via Java**.

## **Video-Frame hinzufügen**

Fügen Sie einen Video-Frame in eine Folie ein.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Video-Frame hinzufügen.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf einen Video-Frame**

Rufen Sie den ersten Video-Frame ab, der einer Folie hinzugefügt wurde.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf den ersten Video-Frame auf der Folie.
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

## **Video-Frame entfernen**

Löschen Sie einen Video-Frame aus der Folie.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, dass das erste Shape auf der Folie das Video-Frame ist.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Video-Frame entfernen.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Videowiedergabe festlegen**

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, dass das erste Shape auf der Folie das Video-Frame ist.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Das Video so konfigurieren, dass es automatisch abgespielt wird.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```