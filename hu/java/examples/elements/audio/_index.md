---
title: Hang
type: docs
weight: 70
url: /hu/java/examples/elements/audio/
keywords:
- kódpélda
- hang
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java audio példákat: hang beillesztése, lejátszása, vágása és kinyerése PPT, PPTX és ODP prezentációkban, világos Java kóddal."
---
Ez a cikk bemutatja, hogyan lehet audio kereteket beágyazni és vezérelni a lejátszást az **Aspose.Slides for Java** segítségével. A következő példák az alapvető audio műveleteket mutatják be.

## **Audio keret hozzáadása**

Helyezzen be egy üres audio keretet, amely később beágyazott hangadatot tartalmazhat.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Üres audio keret létrehozása (a hang később be lesz ágyazva).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Audio keret elérése**

Ez a kód lekéri az első audio keretet a dián.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Elérni az első audio keretet a dián.
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

## **Audio keret eltávolítása**

Töröljön egy korábban hozzáadott audio keretet.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Az audio keret eltávolítása.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio lejátszás beállítása**

Állítsa be az audio keretet úgy, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Automatikusan lejátszódik, amikor a dia megjelenik.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```