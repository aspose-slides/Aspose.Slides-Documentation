---
title: Video
type: docs
weight: 80
url: /it/java/examples/elements/video/
keywords:
- esempio di codice
- video
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Aggiungi e controlla i video con Aspose.Slides for Java: inserisci, riproduci, ritaglia, imposta i fotogrammi poster e esporta con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare fotogrammi video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for Java**.

## **Aggiungere un fotogramma video**

Inserisci un fotogramma video vuoto su una diapositiva.

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

## **Accedere a un fotogramma video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Accedi al primo fotogramma video nella diapositiva.
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

## **Rimuovere un fotogramma video**

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

## **Impostare la riproduzione video**

Configura il video in modo che venga riprodotto automaticamente quando la diapositiva viene mostrata.

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