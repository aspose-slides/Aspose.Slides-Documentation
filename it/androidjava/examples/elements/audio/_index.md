---
title: Audio
type: docs
weight: 70
url: /it/androidjava/examples/elements/audio/
keywords:
- esempio di codice
- audio
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri gli esempi audio di Aspose.Slides per Android: inserire, riprodurre, ritagliare ed estrarre suoni in presentazioni PPT, PPTX e ODP con codice Java chiaro."
---
Questo articolo dimostra come incorporare fotogrammi audio e controllare la riproduzione con **Aspose.Slides for Android via Java**. Gli esempi seguenti mostrano le operazioni audio di base.

## **Aggiungere un fotogramma audio**

Inserisci un fotogramma audio vuoto che in seguito potrà contenere dati audio incorporati.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crea un fotogramma audio vuoto (l'audio sarà incorporato successivamente).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Accedere a un fotogramma audio**

Questo codice recupera il primo fotogramma audio in una diapositiva.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Accede al primo fotogramma audio sulla diapositiva.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Rimuove il fotogramma audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Impostare la riproduzione audio**

Configura il fotogramma audio per riprodursi automaticamente quando la diapositiva appare.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Riproduci automaticamente quando la diapositiva appare.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```