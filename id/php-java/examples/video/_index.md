---
title: Video
type: docs
weight: 80
url: /id/php-java/examples/elements/video/
keywords:
- video
- bingkai video
- menambahkan video
- mengakses video
- menghapus video
- pemutaran video
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan video di PHP menggunakan Aspose.Slides: menyisipkan, mengganti, memotong, mengatur bingkai poster dan opsi pemutaran, serta mengekspor presentasi ke PPT, PPTX, dan ODP."
---
Menampilkan cara menyematkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for PHP via Java**.

## **Menambahkan Bingkai Video**

Menyisipkan bingkai video ke dalam slide.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tambahkan bingkai video.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Bingkai Video**

Mengambil bingkai video pertama yang ditambahkan ke slide.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengakses bingkai video pertama pada slide.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Bingkai Video**

Menghapus bingkai video dari slide.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bentuk pertama pada slide adalah bingkai video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Hapus bingkai video.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengatur Pemutaran Video**

Mengkonfigurasi video agar diputar secara otomatis saat slide ditampilkan.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bentuk pertama pada slide adalah bingkai video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Mengatur video agar diputar secara otomatis.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```