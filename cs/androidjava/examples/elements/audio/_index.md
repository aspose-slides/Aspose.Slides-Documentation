---
title: Zvuk
type: docs
weight: 70
url: /cs/androidjava/examples/elements/audio/
keywords:
- ukázka kódu
- zvuk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte příklady audia pro Aspose.Slides for Android: vkládání, přehrávání, ořezávání a extrahování zvuku v prezentacích PPT, PPTX a ODP s přehledným kódem v jazyce Java."
---
Tento článek ukazuje, jak vložit audio rámečky a řídit přehrávání s **Aspose.Slides for Android via Java**. Následující příklady ukazují základní operace s audiem.

## **Přidat audio rámeček**

Vložte prázdný audio rámeček, který může později obsahovat vložená zvuková data.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Vytvořte prázdný audio rámeček (audio bude vloženo později).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k audio rámečku**

Tento kód získá první audio rámeček na snímku.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Přístup k prvnímu audio rámečku na snímku.
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

## **Odstranit audio rámeček**

Odstraňte dříve přidaný audio rámeček.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Odstraňte audio rámeček.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit přehrávání audia**

Nastavte audio rámeček tak, aby se přehrával automaticky při zobrazení snímku.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Přehraje se automaticky, když se snímek zobrazí.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```