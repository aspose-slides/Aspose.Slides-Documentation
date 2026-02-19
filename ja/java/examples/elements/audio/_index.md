---
title: オーディオ
type: docs
weight: 70
url: /ja/java/examples/elements/audio/
keywords:
- コード例
- オーディオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のオーディオ サンプルを発見: PPT、PPTX、ODP プレゼンテーションにサウンドを挿入、再生、トリム、抽出する方法をわかりやすい Java コードで示します。"
---
この記事では、**Aspose.Slides for Java** を使用してオーディオ フレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的なオーディオ操作を示します。

## **オーディオ フレームの追加**

後で埋め込まれたサウンド データを保持できる空のオーディオ フレームを挿入します。

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 空のオーディオ フレームを作成します（オーディオは後で埋め込まれます）。
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **オーディオ フレームへのアクセス**

このコードは、スライド上の最初のオーディオ フレームを取得します。

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // スライド上の最初のオーディオ フレームにアクセスします。
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

## **オーディオ フレームの削除**

以前に追加されたオーディオ フレームを削除します。

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // オーディオ フレームを削除します。
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **オーディオ 再生の設定**

スライドが表示されたときにオーディオ フレームが自動的に再生されるように設定します。

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // スライドが表示されたときに自動的に再生します。
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```