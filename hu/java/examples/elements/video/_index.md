---
title: Videó
type: docs
weight: 80
url: /hu/java/examples/elements/video/
keywords:
- kódpélda
- videó
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Videók hozzáadása és kezelése az Aspose.Slides for Java-val: beszúrás, lejátszás, vágás, poszterkeretek beállítása, valamint exportálás Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet videokereteket beágyazni és lejátszási beállításokat megadni az **Aspose.Slides for Java** használatával.

## **Videokeret hozzáadása**

Helyezzünk egy üres videokeretet a diára.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Videót ad hozzá.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Videokeret elérése**

A diára hozzáadott első videokeret lekérdezése.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // A dián az első videokeret elérése.
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

## **Videokeret eltávolítása**

Videokeret törlése a diáról.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // A videokeret eltávolítása.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Videó lejátszásának beállítása**

Állítsa be a videót, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // A videót automatikus lejátszásra állítja be.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```