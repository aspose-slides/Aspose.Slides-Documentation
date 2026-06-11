---
title: Wideo
type: docs
weight: 80
url: /pl/java/examples/elements/video/
keywords:
- przykład kodu
- wideo
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dodawaj i kontroluj filmy wideo przy użyciu Aspose.Slides for Java: wstawiaj, odtwarzaj, przycinaj, ustawiaj ramki plakatu i eksportuj z przykładami w Javie dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak osadzić ramki wideo i ustawić opcje odtwarzania przy użyciu **Aspose.Slides for Java**.

## **Dodaj ramkę wideo**

Wstaw pustą ramkę wideo na slajd.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dodaj wideo.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
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

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Usuń ramkę wideo.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj odtwarzanie wideo automatycznie, gdy slajd jest wyświetlany.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Skonfiguruj wideo, aby odtwarzało się automatycznie.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```