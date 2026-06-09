---
title: Ses
type: docs
weight: 70
url: /tr/androidjava/examples/elements/audio/
keywords:
- kod örneği
- ses
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ses örneklerini keşfedin: PPT, PPTX ve ODP sunumlarında sesi ekleyin, oynatın, kırpın ve çıkarın, net Java kodu ile."
---
Bu makale, **Aspose.Slides for Android via Java** ile ses çerçevelerini nasıl gömeceğinizi ve oynatmayı nasıl kontrol edeceğinizi gösterir. Aşağıdaki örnekler temel ses işlemlerini göstermektedir.

## **Ses Çerçevesi Ekle**

Daha sonra gömülü ses verisi tutabilecek boş bir ses çerçevesi ekleyin.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Boş bir ses çerçevesi oluştur (ses daha sonra gömülecek).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Ses Çerçevesine Erişme**

Bu kod, bir slayttaki ilk ses çerçevesini getirir.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Slayttaki ilk ses çerçevesine eriş.
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

## **Ses Çerçevesini Kaldırma**

Daha önce eklenmiş bir ses çerçevesini silin.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Ses çerçevesini kaldır.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ses Oynatmayı Ayarla**

Ses çerçevesini, slayt göründüğünde otomatik olarak çalacak şekilde yapılandırın.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Slayt göründüğünde otomatik olarak çal.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```