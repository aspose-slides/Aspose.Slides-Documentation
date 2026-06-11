---
title: Audio
type: docs
weight: 70
url: /pl/java/examples/elements/audio/
keywords:
- przykład kodu
- audio
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj przykłady audio Aspose.Slides for Java: wstawianie, odtwarzanie, przycinanie i wyodrębnianie dźwięku w prezentacjach PPT, PPTX i ODP przy użyciu przejrzystego kodu Java."
---
Ten artykuł demonstruje, jak osadzić ramki audio i kontrolować odtwarzanie przy użyciu **Aspose.Slides for Java**. Poniższe przykłady pokazują podstawowe operacje audio.

## **Add an Audio Frame**
Wstaw pustą ramkę audio, która później może zawierać osadzone dane dźwiękowe.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Utwórz pustą ramkę audio (dźwięk zostanie osadzony później).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Access an Audio Frame**
Ten kod pobiera pierwszą ramkę audio na slajdzie.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Uzyskaj pierwszą ramkę audio na slajdzie.
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

## **Remove an Audio Frame**
Usuń wcześniej dodaną ramkę audio.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Usuń ramkę audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**
Skonfiguruj ramkę audio tak, aby odtwarzała się automatycznie, gdy slajd się pojawi.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Odtwarzaj automatycznie, gdy slajd się pojawi.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```