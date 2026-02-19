---
title: 音频
type: docs
weight: 70
url: /zh/androidjava/examples/elements/audio/
keywords:
- 代码示例
- 音频
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "发现 Aspose.Slides for Android 的音频示例：在 PPT、PPTX 和 ODP 演示文稿中插入、播放、修剪和提取声音，并提供清晰的 Java 代码。"
---
本文演示如何在 **Aspose.Slides for Android via Java** 中嵌入音频帧并控制播放。以下示例展示了基本的音频操作。

## **添加音频帧**

插入一个空的音频帧，以便以后容纳嵌入的音频数据。

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 创建一个空的音频帧（音频将在稍后嵌入）。
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **访问音频帧**

此代码检索幻灯片上的第一个音频帧。

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 访问幻灯片上的第一个音频帧。
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

## **删除音频帧**

删除先前添加的音频帧。

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 删除音频帧。
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **设置音频播放**

将音频帧配置为在幻灯片出现时自动播放。

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // 幻灯片出现时自动播放。
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```