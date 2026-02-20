---
title: オーディオ
type: docs
weight: 70
url: /ja/php-java/examples/elements/audio/
keywords:
- オーディオ
- オーディオフレーム
- オーディオを追加
- オーディオにアクセス
- オーディオを削除
- オーディオ再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でオーディオを操作します。音声の追加、置換、抽出、トリミング、スライドやシェイプの音量および再生設定を PowerPoint と OpenDocument で行います。"
---
**Aspose.Slides for PHP via Java** を使用して音声フレームを埋め込み、再生を制御する方法を示します。以下の例では基本的な音声操作を紹介します。

## **音声フレームの追加**

音声フレームを挿入します。

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 音声フレームを作成します。
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **音声フレームへのアクセス**

このコードはスライド上の最初の音声フレームを取得します。

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初の音声フレームにアクセスします。
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

## **音声フレームの削除**

以前に追加した音声フレームを削除します。

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが音声フレームであると想定します。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 音声フレームを削除します。
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **音声再生の設定**

スライドが表示されたときに音声フレームが自動的に再生されるように設定します。

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが音声フレームであると想定します。
        $audioFrame = $slide->getShapes()->get_Item(0);

        // スライドが表示されたときに自動的に再生します。
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```