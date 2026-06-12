---
title: Audio
type: docs
weight: 70
url: /id/java/examples/elements/audio/
keywords:
- contoh kode
- audio
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Temukan contoh audio Aspose.Slides untuk Java: menyisipkan, memutar, memotong, dan mengekstrak suara dalam presentasi PPT, PPTX, dan ODP dengan kode Java yang jelas."
---
Artikel ini menunjukkan cara menyematkan frame audio dan mengontrol pemutaran dengan **Aspose.Slides for Java**. Contoh berikut menunjukkan operasi audio dasar.

## **Tambah Frame Audio**

Sisipkan frame audio kosong yang nantinya dapat menampung data suara yang disematkan.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Buat sebuah frame audio kosong (audio akan disematkan nanti).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Frame Audio**

Kode ini mengambil frame audio pertama pada slide.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Akses frame audio pertama pada slide.
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

## **Hapus Frame Audio**

Hapus frame audio yang sebelumnya telah ditambahkan.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Hapus frame audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Atur Pemutaran Audio**

Konfigurasikan frame audio untuk diputar secara otomatis saat slide muncul.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Putar secara otomatis ketika slide muncul.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```