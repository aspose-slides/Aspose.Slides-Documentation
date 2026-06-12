---
title: Video
type: docs
weight: 80
url: /id/nodejs-java/examples/elements/video/
keywords:
- contoh kode
- video
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Menambahkan dan mengontrol video dengan Aspose.Slides untuk Node.js: menyisipkan, memutar, memotong, mengatur frame poster, dan mengekspor dengan contoh untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan frame video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for Node.js via Java**.

## **Tambahkan Frame Video**

Tambahkan frame video ke slide.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tambahkan video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Frame Video**

Ambil frame video pertama yang ditambahkan ke slide.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Akses frame video pertama pada slide.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Frame Video**

Hapus frame video dari slide.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Asumsikan shape pertama adalah frame video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Hapus frame video.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis saat slide ditampilkan.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Asumsikan shape pertama adalah frame video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Konfigurasikan video untuk diputar secara otomatis.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```