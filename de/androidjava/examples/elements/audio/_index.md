---
title: Audio
type: docs
weight: 70
url: /de/androidjava/examples/elements/audio/
keywords:
- Codebeispiel
- Audio
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Audio-Beispiele von Aspose.Slides für Android: Einfügen, Abspielen, Trimmen und Extrahieren von Ton in PPT-, PPTX- und ODP-Präsentationen mit übersichtlichem Java-Code."
---
Dieser Artikel demonstriert, wie Audio-Frames eingebettet und die Wiedergabe mit **Aspose.Slides for Android via Java** gesteuert werden können. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Ein leeres Audio-Frame einfügen, das später eingebettete Audiodaten aufnehmen kann.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Erstelle ein leeres Audio-Frame (Audio wird später eingebettet).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein Audio-Frame**

Dieser Code ruft das erste Audio-Frame auf einer Folie ab.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Zugriff auf das erste Audio-Frame auf der Folie.
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

## **Audio-Frame entfernen**

Löscht ein zuvor hinzugefügtes Audio-Frame.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Entferne das Audio-Frame.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio-Wiedergabe festlegen**

Konfigurieren Sie das Audio-Frame so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Automatisch abspielen, wenn die Folie angezeigt wird.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```