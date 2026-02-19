---
title: ビデオ
type: docs
weight: 80
url: /ja/java/examples/elements/video/
keywords:
- コード例
- ビデオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してビデオを追加および制御します。挿入、再生、トリミング、ポスター画像の設定、そして PPT、PPTX、ODP プレゼンテーション用の Java サンプルでエクスポートできます。"
---
この記事では、**Aspose.Slides for Java** を使用してビデオフレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオフレームの追加**

スライドに空のビデオフレームを挿入します。

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ビデオを追加します。
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **ビデオフレームの取得**

スライドに追加された最初のビデオフレームを取得します。

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // スライド上の最初のビデオフレームにアクセスします。
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
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

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // ビデオフレームを削除します。
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ビデオの再生設定**

スライドが表示されたときにビデオが自動的に再生されるように設定します。

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // ビデオを自動再生するように設定します。
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```