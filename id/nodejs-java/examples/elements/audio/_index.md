---
title: Audio
type: docs
weight: 70
url: /id/nodejs-java/examples/elements/audio/
keywords:
- contoh kode
- audio
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan contoh audio Aspose.Slides untuk Node.js: sisipkan, putar, potong, dan ekstrak suara dalam presentasi PPT, PPTX, dan ODP dengan kode JavaScript yang jelas."
---
Artikel ini menunjukkan cara menyematkan frame audio dan mengendalikan pemutaran dengan **Aspose.Slides for Node.js via Java**. Contoh-contoh berikut menampilkan operasi audio dasar.

## **Tambah Frame Audio**

Contoh kode di bawah ini menambahkan frame audio pada slide presentasi.

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Frame Audio**

Kode ini mengambil frame audio pertama pada sebuah slide.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses frame audio pertama pada slide.
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Frame Audio**

Menghapus frame audio yang sebelumnya ditambahkan.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anggap bentuk pertama adalah frame audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Hapus frame audio.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Setel Pemutaran Audio**

Mengonfigurasi frame audio untuk diputar secara otomatis saat slide muncul.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anggap bentuk pertama adalah frame audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Putar secara otomatis saat slide muncul.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```