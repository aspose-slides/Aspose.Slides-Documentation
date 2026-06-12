---
title: Video
type: docs
weight: 80
url: /it/androidjava/examples/elements/video/
keywords:
- esempio di codice
- video
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi e controlla i video con Aspose.Slides per Android: inserisci, riproduci, ritaglia, imposta i fotogrammi di anteprima e esporta con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare fotogrammi video e impostare le opzioni di riproduzione usando **Aspose.Slides for Android via Java**.

## **Aggiungi un fotogramma video**

Inserisci un fotogramma video vuoto in una diapositiva.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aggiungi un video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un fotogramma video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Accedi al primo fotogramma video sulla diapositiva.
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

## **Rimuovi un fotogramma video**

Elimina un fotogramma video dalla diapositiva.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Rimuovi il fotogramma video.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta la riproduzione video**

Configura il video perché venga riprodotto automaticamente quando la diapositiva è visualizzata.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configura il video per la riproduzione automatica.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```