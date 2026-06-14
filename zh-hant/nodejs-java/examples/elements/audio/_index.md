---
title: 音訊
type: docs
weight: 70
url: /zh-hant/nodejs-java/examples/elements/audio/
keywords:
- 程式碼範例
- 音訊
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js 的音訊範例：在 PPT、PPTX 與 ODP 簡報中插入、播放、剪輯與擷取音效，並提供清晰的 JavaScript 程式碼。"
---
本文示範如何在 **Aspose.Slides for Node.js via Java** 中嵌入音訊框架並控制播放。以下範例展示基本的音訊操作。

## **新增音訊框架**

以下程式碼範例會在投影片上新增音訊框架。

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

## **存取音訊框架**

此程式會取得投影片上的第一個音訊框架。

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 存取投影片上的第一個音訊框架。
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

## **移除音訊框架**

刪除先前新增的音訊框架。

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個圖形是音訊框架。
        let audioFrame = slide.getShapes().get_Item(0);

        // 移除音訊框架。
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **設定音訊播放**

設定音訊框架，使其在投影片出現時自動播放。

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個圖形是音訊框架。
        let audioFrame = slide.getShapes().get_Item(0);

        // 投影片出現時自動播放。
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```