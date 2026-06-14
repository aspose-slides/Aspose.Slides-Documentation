---
title: 音訊
type: docs
weight: 70
url: /zh-hant/php-java/examples/elements/audio/
keywords:
- 音訊
- 音訊框架
- 新增音訊
- 存取音訊
- 移除音訊
- 音訊播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中處理音訊：新增、取代、擷取與裁剪聲音，並在 PowerPoint 與 OpenDocument 中設定投影片與圖形的音量與播放方式。"
---
說明如何在 **Aspose.Slides for PHP via Java** 中嵌入音訊框架並控制播放。以下示例展示了基本的音訊操作。

## **新增音訊框架**

插入音訊框架。

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 建立音訊框架。
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取音訊框架**

此程式碼取得投影片上的第一個音訊框架。

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個音訊框架。
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

## **移除音訊框架**

刪除先前加入的音訊框架。

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個形狀是音訊框架。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 移除音訊框架。
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **設定音訊播放**

設定音訊框架，使其在投影片出現時自動播放。

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個形狀是音訊框架。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 投影片出現時自動播放。
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```