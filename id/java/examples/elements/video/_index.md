---
title: Video
type: docs
weight: 80
url: /id/java/examples/elements/video/
keywords:
- contoh kode
- video
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tambahkan dan kendalikan video dengan Aspose.Slides untuk Java: sisipkan, putar, pangkas, atur bingkai poster, dan ekspor dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyematkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for Java**.

## **Tambah Bingkai Video**

Sisipkan bingkai video kosong ke dalam slide.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tambahkan video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Bingkai Video**

Ambil bingkai video pertama yang ditambahkan ke slide.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Akses bingkai video pertama pada slide.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Bingkai Video**

Hapus bingkai video dari slide.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Hapus bingkai video.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Atur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis ketika slide ditampilkan.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Konfigurasikan video agar diputar secara otomatis.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```