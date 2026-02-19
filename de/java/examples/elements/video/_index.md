---
title: Video
type: docs
weight: 80
url: /de/java/examples/elements/video/
keywords:
- Codebeispiel
- Video
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Videos mit Aspose.Slides für Java hinzufügen und steuern: Einfügen, Abspielen, Trimmen, Poster-Frames festlegen und Exportieren mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie Videoframes eingebettet und Wiedergabeoptionen mit **Aspose.Slides for Java** festgelegt werden.

## **Videoframe hinzufügen**

Fügen Sie einen leeren Videoframe zu einer Folie hinzu.

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

## **Auf einen Videoframe zugreifen**

Rufen Sie den ersten zu einer Folie hinzugefügten Videoframe ab.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Zugriff auf das erste Video-Frame auf der Folie.
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

Löschen Sie einen Videoframe von der Folie.

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

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Video so konfigurieren, dass es automatisch abgespielt wird.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```