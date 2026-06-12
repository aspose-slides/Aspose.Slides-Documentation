---
title: Audio
type: docs
weight: 70
url: /it/java/examples/elements/audio/
keywords:
- esempio di codice
- audio
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri gli esempi audio di Aspose.Slides per Java: inserire, riprodurre, ritagliare ed estrarre suoni in presentazioni PPT, PPTX e ODP con codice Java chiaro."
---
Questo articolo dimostra come incorporare fotogrammi audio e controllare la riproduzione con **Aspose.Slides per Java**. Gli esempi seguenti mostrano operazioni audio di base.

## **Aggiungi un fotogramma audio**

Inserisci un fotogramma audio vuoto che in seguito potrà contenere dati audio incorporati.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crea un fotogramma audio vuoto (l'audio verrà incorporato in seguito).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un fotogramma audio**

Questo codice recupera il primo fotogramma audio presente in una diapositiva.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Accedi al primo fotogramma audio sulla diapositiva.
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

## **Rimuovi un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Rimuovi il fotogramma audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta la riproduzione audio**

Configura il fotogramma audio affinché venga riprodotto automaticamente quando la diapositiva appare.

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