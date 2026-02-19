---
title: オーディオ
type: docs
weight: 70
url: /ja/androidjava/examples/elements/audio/
keywords:
- コード例
- オーディオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android のオーディオ例を確認しましょう：PPT、PPTX、ODP プレゼンテーションに音声を挿入、再生、トリミング、抽出する方法を、わかりやすい Java コードと共に紹介します。"
---
この記事では、**Aspose.Slides for Android via Java** を使用してオーディオフレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的なオーディオ操作を紹介します。

## **オーディオフレームの追加**

後で埋め込まれたサウンドデータを保持できる空のオーディオフレームを挿入します。

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 空のオーディオフレームを作成します（後でオーディオが埋め込まれます）。
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **オーディオフレームへのアクセス**

このコードは、スライド上の最初のオーディオフレームを取得します。

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // スライド上の最初のオーディオフレームにアクセスします。
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

## **オーディオフレームの削除**

以前に追加したオーディオフレームを削除します。

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // オーディオフレームを削除します。
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **オーディオ再生の設定**

スライドが表示されたときにオーディオフレームが自動的に再生されるように設定します。

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