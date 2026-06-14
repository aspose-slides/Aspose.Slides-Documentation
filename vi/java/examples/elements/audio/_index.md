---
title: Âm thanh
type: docs
weight: 70
url: /vi/java/examples/elements/audio/
keywords:
- ví dụ mã
- âm thanh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá các ví dụ âm thanh của Aspose.Slides for Java: chèn, phát, cắt và trích xuất âm thanh trong các bản trình bày PPT, PPTX và ODP với mã Java rõ ràng."
---
Bài viết này trình bày cách nhúng khung âm thanh và điều khiển việc phát lại với **Aspose.Slides for Java**. Các ví dụ sau cho thấy các hoạt động âm thanh cơ bản.

## **Thêm Khung Âm Thanh**

Chèn một khung âm thanh trống mà sau này có thể chứa dữ liệu âm thanh được nhúng.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tạo một khung âm thanh trống (âm thanh sẽ được nhúng sau).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập Khung Âm Thanh**

Đoạn mã này lấy khung âm thanh đầu tiên trên một slide.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Truy cập khung âm thanh đầu tiên trên slide.
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

## **Xóa Khung Âm Thanh**

Xóa một khung âm thanh đã được thêm trước đó.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Xóa khung âm thanh.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Thiết lập Phát lại Âm Thanh**

Cấu hình khung âm thanh để tự động phát khi slide xuất hiện.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Phát tự động khi slide xuất hiện.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```