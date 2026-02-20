---
title: 音频
type: docs
weight: 70
url: /zh/php-java/examples/elements/audio/
keywords:
- 音频
- 音频帧
- 添加音频
- 访问音频
- 删除音频
- 音频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 处理音频：添加、替换、提取和剪辑声音，设置 PowerPoint 和 OpenDocument 中幻灯片和形状的音量和播放方式。"
---
说明如何使用 **Aspose.Slides for PHP via Java** 嵌入音频帧并控制播放。以下示例展示了基本的音频操作。

## **添加音频帧**

在幻灯片中插入音频帧。

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 创建音频帧。
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问音频帧**

此代码检索幻灯片上的第一个音频帧。

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个音频帧。
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

## **删除音频帧**

删除先前添加的音频帧。

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是音频帧。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 删除音频帧。
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **设置音频播放**

将音频帧配置为在幻灯片出现时自动播放。

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是音频帧。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 幻灯片出现时自动播放。
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```