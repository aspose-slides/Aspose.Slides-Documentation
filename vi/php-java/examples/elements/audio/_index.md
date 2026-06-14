---
title: Âm thanh
type: docs
weight: 70
url: /vi/php-java/examples/elements/audio/
keywords:
- âm thanh
- khung âm thanh
- thêm âm thanh
- truy cập âm thanh
- xóa âm thanh
- phát lại âm thanh
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Làm việc với âm thanh trong PHP bằng Aspose.Slides: thêm, thay thế, trích xuất và cắt giảm âm thanh, thiết lập âm lượng và phát lại cho các slide và hình dạng trong PowerPoint và OpenDocument."
---
Minh họa cách nhúng khung âm thanh và điều khiển phát lại với **Aspose.Slides for PHP via Java**. Các ví dụ sau cho thấy các thao tác âm thanh cơ bản.

## **Thêm một khung âm thanh**

Chèn một khung âm thanh.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tạo một khung âm thanh.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập vào khung âm thanh**

Mã này truy xuất khung âm thanh đầu tiên trên một slide.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập khung âm thanh đầu tiên trên slide.
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

## **Xóa khung âm thanh**

Xóa một khung âm thanh đã được thêm trước đó.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là một khung âm thanh.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Xóa khung âm thanh.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cài đặt phát lại âm thanh**

Cấu hình khung âm thanh để tự động phát khi slide xuất hiện.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là một khung âm thanh.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Phát tự động khi slide xuất hiện.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```