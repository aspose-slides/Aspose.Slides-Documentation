---
title: Hang
type: docs
weight: 70
url: /hu/androidjava/examples/elements/audio/
keywords:
- kód példa
- hang
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android hangpéldákat: hang beszúrása, lejátszása, vágása és kinyerése PPT, PPTX és ODP prezentációkban, világos Java kóddal."
---
Ez a cikk bemutatja, hogyan lehet beágyazni hangkereteket, és vezérelni a lejátszást a **Aspose.Slides for Android via Java** segítségével. A következő példák az alapvető hangműveleteket mutatják.

## **Hangkeret hozzáadása**

Helyezzen be egy üres hangkeretet, amely később beágyazott hangadatokat tárolhat.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Hozzon létre egy üres hangkeretet (a hang később be lesz ágyazva).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Hangkeret elérése**

Ez a kód lekéri az első hangkeretet egy dián.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // A dia első hangkeretének elérése.
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

## **Hangkeret eltávolítása**

Törölje az előzőleg hozzáadott hangkeretet.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Távolítsa el a hangkeretet.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Hang lejátszásának beállítása**

Állítsa be a hangkeretet úgy, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // A dia megjelenésekor automatikus lejátszás.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```