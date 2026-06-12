---
title: Video
type: docs
weight: 80
url: /cs/java/examples/elements/video/
keywords:
- ukázka kódu
- video
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přidávejte a ovládejte videa pomocí Aspose.Slides pro Java: vkládejte, přehrávejte, ořezávejte, nastavujte úvodní snímky a exportujte s Java ukázkami pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit video rámečky a nastavit možnosti přehrávání pomocí **Aspose.Slides for Java**.

## **Přidat video rámeček**

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

Získejte první video rámeček přidaný do snímku.

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

## **Odstranit video rámeček**

Smažte video rámeček ze snímku.

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

## **Nastavit přehrávání videa**

Nakonfigurujte video tak, aby se přehrávalo automaticky při zobrazení snímku.

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