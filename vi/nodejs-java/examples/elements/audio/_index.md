---
title: Âm thanh
type: docs
weight: 70
url: /vi/nodejs-java/examples/elements/audio/
keywords:
- ví dụ mã
- âm thanh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các ví dụ âm thanh của Aspose.Slides cho Node.js: chèn, phát, cắt và trích xuất âm thanh trong các bản trình chiếu PPT, PPTX và ODP với mã JavaScript rõ ràng."
---
Bài viết này trình bày cách nhúng khung âm thanh và điều khiển việc phát lại với **Aspose.Slides for Node.js via Java**. Các ví dụ sau minh họa các thao tác âm thanh cơ bản.

## **Thêm một Khung Âm Thanh**

Ví dụ mã dưới đây thêm một khung âm thanh vào một slide trong bản trình chiếu.

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

## **Truy cập một Khung Âm Thanh**

Đoạn mã này lấy khung âm thanh đầu tiên trên một slide.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập khung âm thanh đầu tiên trên slide.
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

## **Xóa một Khung Âm Thanh**

Xóa một khung âm thanh đã được thêm trước đó.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung âm thanh.
        let audioFrame = slide.getShapes().get_Item(0);

        // Xóa khung âm thanh.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt Phát Lại Âm Thanh**

Cấu hình khung âm thanh để tự động phát khi slide xuất hiện.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung âm thanh.
        let audioFrame = slide.getShapes().get_Item(0);

        // Tự động phát khi slide xuất hiện.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```