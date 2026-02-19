---
title: ビデオ
type: docs
weight: 80
url: /ja/nodejs-java/examples/elements/video/
keywords:
- コード例
- ビデオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用してビデオを追加および制御します。挿入、再生、トリミング、ポスターフレームの設定、PPT、PPTX、ODP プレゼンテーションのエクスポート例を含みます。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用してビデオフレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオフレームの追加**

スライドにビデオフレームを追加します。

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ビデオを追加します。
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ビデオフレームへのアクセス**

スライドに追加された最初のビデオフレームを取得します。

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // スライド上の最初のビデオフレームにアクセスします。
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

## **ビデオフレームの削除**

スライドからビデオフレームを削除します。

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがビデオフレームであると仮定します。
        let videoFrame = slide.getShapes().get_Item(0);

        // ビデオフレームを削除します。
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ビデオ再生の設定**

スライドが表示されたときにビデオが自動的に再生されるように設定します。

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがビデオフレームであると仮定します。
        let videoFrame = slide.getShapes().get_Item(0);

        // ビデオを自動再生するように設定します。
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```