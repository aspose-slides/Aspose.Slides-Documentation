---
title: Video
type: docs
weight: 80
url: /sv/java/examples/elements/video/
keywords:
- kodexempel
- video
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lägg till och kontrollera videor med Aspose.Slides för Java: infoga, spela upp, trimma, ange posterramar och exportera med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man bäddar in videoramar och ställer in uppspelningsalternativ med **Aspose.Slides for Java**.

## **Lägg till en videoruta**

Infoga en tom videoruta på en bild.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till en video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en videoruta**

Hämta den första videorutan som lagts till på en bild.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Åtkomst till den första videoramen på bilden.
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

## **Ta bort en videoruta**

Ta bort en videoruta från bilden.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Ta bort videoramen.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Konfigurera videon så att den spelas upp automatiskt.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```