---
title: Audio
type: docs
weight: 70
url: /cs/java/examples/elements/audio/
keywords:
- ukázka kódu
- audio
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte ukázky audia pro Aspose.Slides for Java: vkládání, přehrávání, ořezávání a extrahování zvuku v prezentacích PPT, PPTX a ODP s přehledným Java kódem."
---
Tento článek ukazuje, jak vložit audio snímky a řídit jejich přehrávání pomocí **Aspose.Slides for Java**. Následující příklady představují základní operace s audiem.

## **Přidat audio snímek**

Vložte prázdný audio snímek, který může později obsahovat vložená zvuková data.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Vytvořte prázdný audio snímek (audio bude vloženo později).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k audio snímku**

Tento kód získá první audio snímek na snímku.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Přístup k prvnímu audio snímku na snímku.
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

## **Odebrat audio snímek**

Odstraňte dříve přidaný audio snímek.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Odstranit audio snímek.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit přehrávání audia**

Nastavte audio snímek tak, aby se spustil automaticky, když se snímek zobrazí.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Přehrát automaticky, když se snímek objeví.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```