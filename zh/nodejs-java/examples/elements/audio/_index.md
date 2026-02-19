---
title: 音频
type: docs
weight: 70
url: /zh/nodejs-java/examples/elements/audio/
keywords:
- 代码示例
- 音频
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "发现 Aspose.Slides for Node.js 音频示例：在 PPT、PPTX 和 ODP 演示文稿中插入、播放、剪辑和提取声音，并提供清晰的 JavaScript 代码。"
---
本文演示如何在 **Aspose.Slides for Node.js via Java** 中嵌入音频帧并控制播放。以下示例展示了基本的音频操作。

## **添加音频帧**

下面的代码示例在演示文稿的幻灯片上添加音频帧。

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

## **访问音频帧**

此代码检索幻灯片上的第一个音频帧。

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 访问幻灯片上的第一个音频帧。
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

## **删除音频帧**

删除先前添加的音频帧。

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假设第一个形状是音频帧。
        let audioFrame = slide.getShapes().get_Item(0);

        // 删除音频帧。
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **设置音频播放**

配置音频帧，使其在幻灯片出现时自动播放。

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假设第一个形状是音频帧。
        let audioFrame = slide.getShapes().get_Item(0);

        // 在幻灯片出现时自动播放。
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```