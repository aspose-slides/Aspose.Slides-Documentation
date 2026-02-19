---
title: Video
type: docs
weight: 80
url: /de/androidjava/examples/elements/video/
keywords:
- Codebeispiel
- Video
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Videos mit Aspose.Slides für Android hinzufügen und steuern: Einfügen, Abspielen, Trimmen, Poster-Frames festlegen und Exportieren mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie Videoframes eingebettet und Wiedergabeoptionen mit **Aspose.Slides for Android via Java** festgelegt werden.

## **Videoframe hinzufügen**

Ein leeres Videoframe in eine Folie einfügen.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Video hinzufügen.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Auf ein Videoframe zugreifen**

Das zuerst zu einer Folie hinzugefügte Videoframe abrufen.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Zugriff auf den ersten Videoframe auf der Folie.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Videoframe entfernen**

Ein Videoframe aus der Folie löschen.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Video-Frame entfernen.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Videowiedergabe festlegen**

Das Video so konfigurieren, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Das Video so konfigurieren, dass es automatisch abgespielt wird.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```