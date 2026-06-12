---
title: Video
type: docs
weight: 80
url: /nl/java/examples/elements/video/
keywords:
- codevoorbeeld
- video
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Video's toevoegen en beheren met Aspose.Slides for Java: invoegen, afspelen, trimmen, posterframes instellen en exporteren met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe je videoframes kunt insluiten en afspeelopties kunt instellen met **Aspose.Slides for Java**.

## **Videoframe toevoegen**

Voeg een lege videoframe toe aan een dia.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een video toe.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een videoframe**

Haal het eerste videoframe op dat aan een dia is toegevoegd.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Toegang tot het eerste videoframe op de dia.
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

## **Videoframe verwijderen**

Verwijder een videoframe van de dia.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Verwijder het videoframe.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Videoweergave instellen**

Stel het videobestand zo in dat het automatisch wordt afgespeeld wanneer de dia wordt weergegeven.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Stel de video zo in dat hij automatisch wordt afgespeeld.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```