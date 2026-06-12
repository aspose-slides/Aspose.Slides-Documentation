---
title: Video
type: docs
weight: 80
url: /cs/androidjava/examples/elements/video/
keywords:
- příklad kódu
- video
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidávejte a ovládejte videa pomocí Aspose.Slides pro Android: vkládejte, přehrávejte, ořízněte, nastavujte plakátové snímky a exportujte s ukázkami v Javě pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit video rámy a nastavit možnosti přehrávání pomocí **Aspose.Slides for Android via Java**.

## **Přidání video rámečku**

Vložte prázdný video rámeček na snímek.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Přidejte video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k video rámečku**

Získejte první video rámeček přidaný na snímek.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Přístup k prvnímu video rámečku na snímku.
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

## **Odstranění video rámečku**

Odstraňte video rámeček ze snímku.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Odstraňte video rámeček.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavení přehrávání videa**

Nakonfigurujte video tak, aby se spustilo automaticky při zobrazení snímku.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Nastavte video tak, aby se přehrávalo automaticky.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```