---
title: Audio
type: docs
weight: 70
url: /id/androidjava/examples/elements/audio/
keywords:
- contoh kode
- audio
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan contoh audio Aspose.Slides untuk Android: sisipkan, putar, potong, dan ekstrak suara dalam presentasi PPT, PPTX, dan ODP dengan kode Java yang jelas."
---
Artikel ini menunjukkan cara menyematkan bingkai audio dan mengontrol pemutaran dengan **Aspose.Slides for Android via Java**. Contoh berikut memperlihatkan operasi audio dasar.

## **Tambah Bingkai Audio**

Sisipkan bingkai audio kosong yang nantinya dapat menampung data suara tersemat.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Buat bingkai audio kosong (audio akan disematkan nanti).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Bingkai Audio**

Kode ini mengambil bingkai audio pertama pada slide.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Akses bingkai audio pertama pada slide.
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

## **Hapus Bingkai Audio**

Hapus bingkai audio yang sebelumnya ditambahkan.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Hapus bingkai audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Atur Pemutaran Audio**

Konfigurasikan bingkai audio untuk diputar secara otomatis saat slide muncul.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Putar secara otomatis saat slide muncul.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```