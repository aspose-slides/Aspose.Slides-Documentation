---
title: Audio
type: docs
weight: 70
url: /de/java/examples/elements/audio/
keywords:
- Codebeispiel
- Audio
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie Audio-Beispiele von Aspose.Slides für Java: Einfügen, Abspielen, Kürzen und Extrahieren von Ton in PPT-, PPTX- und ODP-Präsentationen mit klarem Java-Code."
---
Dieser Artikel demonstriert, wie man Audio-Frames einbettet und die Wiedergabe mit **Aspose.Slides für Java** steuert. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Fügen Sie einen leeren Audio-Frame ein, der später eingebettete Audiodaten enthalten kann.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Erstelle einen leeren Audio-Frame (Audio wird später eingebettet).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Auf einen Audio-Frame zugreifen**

Dieser Code ruft den ersten Audio-Frame auf einer Folie ab.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Zugriff auf den ersten Audio-Frame auf der Folie.
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

Löschen Sie einen zuvor hinzugefügten Audio-Frame.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Entferne den Audio-Frame.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio-Wiedergabe festlegen**

Konfigurieren Sie den Audio-Frame so, dass er automatisch abgespielt wird, wenn die Folie angezeigt wird.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Automatisch abspielen, wenn die Folie erscheint.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```