---
title: オーディオ
type: docs
weight: 70
url: /ja/nodejs-java/examples/elements/audio/
keywords:
- コード例
- オーディオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js のオーディオ例を発見: PPT、PPTX、ODP プレゼンテーションにサウンドを挿入、再生、トリム、抽出する方法を、分かりやすい JavaScript コードで示します。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用してオーディオフレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的なオーディオ操作を紹介します。

## **オーディオフレームを追加する**

以下のコード例は、プレゼンテーションのスライドにオーディオフレームを追加します。

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

## **オーディオフレームにアクセスする**

このコードは、スライド上の最初のオーディオフレームを取得します。

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // スライド上の最初のオーディオフレームにアクセスします。
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

## **オーディオフレームを削除する**

以前に追加したオーディオフレームを削除します。

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがオーディオフレームであると仮定します。
        let audioFrame = slide.getShapes().get_Item(0);

        // オーディオフレームを削除します。
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **オーディオ再生を設定する**

スライドが表示されたときにオーディオフレームが自動的に再生されるように設定します。

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがオーディオフレームであると仮定します。
        let audioFrame = slide.getShapes().get_Item(0);

        // スライドが表示されたときに自動的に再生します。
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```