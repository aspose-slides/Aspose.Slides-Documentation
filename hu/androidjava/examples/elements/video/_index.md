---
title: Videó
type: docs
weight: 80
url: /hu/androidjava/examples/elements/video/
keywords:
- kódrészlet
- videó
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Videók hozzáadása és vezérlése az Aspose.Slides for Android segítségével: beszúrás, lejátszás, vágás, poszterkeretek beállítása, és exportálás Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet beágyazni videókereteket és beállítani a lejátszási beállításokat az **Aspose.Slides for Android via Java** használatával.

## **Videókeret hozzáadása**

Helyezz be egy üres videókeretet egy diára.

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

## **Videókeret elérése**

Szerezd meg az első, egy diára hozzáadott videókeretet.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Hozzáfér az első videókerethez a dián.
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

## **Videókeret eltávolítása**

Törölj egy videókeretet a diáról.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Távolítsa el a videókeretet.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Videólejátszás beállítása**

Állítsd be a videót, hogy automatikusan lejátszódjon, amikor a diát megjelenítik.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Állítsa be, hogy a videó automatikusan lejátszódjon.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```