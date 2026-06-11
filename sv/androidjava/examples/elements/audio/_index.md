---
title: Ljud
type: docs
weight: 70
url: /sv/androidjava/examples/elements/audio/
keywords:
- kodexempel
- ljud
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android ljudexempel: infoga, spela upp, trimma och extrahera ljud i PPT-, PPTX- och ODP-presentationer med tydlig Java-kod."
---
Denna artikel visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for Android via Java**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Infoga en tom ljudram som senare kan hålla inbäddade ljuddata.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Skapa en tom ljudram (ljud kommer att bäddas in senare).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Åtkomst till den första ljudramen på bilden.
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

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Ta bort ljudramen.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Spela upp automatiskt när bilden visas.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```