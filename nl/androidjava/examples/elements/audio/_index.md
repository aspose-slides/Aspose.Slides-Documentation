---
title: Audio
type: docs
weight: 70
url: /nl/androidjava/examples/elements/audio/
keywords:
- codevoorbeeld
- audio
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek audio‑voorbeelden voor Aspose.Slides voor Android: voeg toe, speel af, knip en extraheer geluid in PPT-, PPTX- en ODP‑presentaties met duidelijke Java‑code."
---
Dit artikel demonstreert hoe je audioframes kunt insluiten en de afspelen kunt beheersen met **Aspose.Slides for Android via Java**. De volgende voorbeelden tonen basis‑audio‑bewerkingen.

## **Audioframe toevoegen**

Voeg een leeg audioframe in dat later ingesloten geluidsgegevens kan bevatten.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Maak een leeg audioframe (audio wordt later ingesloten).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een audioframe**

Deze code haalt het eerste audioframe op een dia op.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Toegang tot het eerste audioframe op de dia.
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

## **Audioframe verwijderen**

Verwijder een eerder toegevoegd audioframe.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Verwijder het audioframe.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio‑afspelen instellen**

Stel het audioframe in om automatisch af te spelen wanneer de dia verschijnt.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Speel automatisch af wanneer de dia verschijnt.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```