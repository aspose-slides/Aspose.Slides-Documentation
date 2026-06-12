---
title: Audio
type: docs
weight: 70
url: /id/php-java/examples/elements/audio/
keywords:
- audio
- kerangka audio
- menambahkan audio
- mengakses audio
- menghapus audio
- pemutaran audio
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan audio di PHP menggunakan Aspose.Slides: menambahkan, mengganti, mengekstrak, dan memangkas suara, mengatur volume dan pemutaran untuk slide dan bentuk di PowerPoint dan OpenDocument."
---
Menunjukkan cara menyisipkan kerangka audio dan mengontrol pemutaran dengan **Aspose.Slides for PHP via Java**. Contoh-contoh berikut menunjukkan operasi audio dasar.

## **Menambahkan Kerangka Audio**

Menyisipkan kerangka audio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Buat kerangka audio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Kerangka Audio**

Kode ini mengambil kerangka audio pertama pada slide.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses kerangka audio pertama pada slide.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Kerangka Audio**

Menghapus kerangka audio yang sebelumnya ditambahkan.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa bentuk pertama pada slide adalah kerangka audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Hapus kerangka audio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengatur Pemutaran Audio**

Mengkonfigurasi kerangka audio agar diputar secara otomatis saat slide muncul.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa bentuk pertama pada slide adalah kerangka audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Putar secara otomatis saat slide muncul.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```