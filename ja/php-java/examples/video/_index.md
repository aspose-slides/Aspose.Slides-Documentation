---
title: ビデオ
type: docs
weight: 80
url: /ja/php-java/examples/elements/video/
keywords:
- ビデオ
- ビデオ フレーム
- ビデオの追加
- ビデオへのアクセス
- ビデオの削除
- ビデオ再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP で Aspose.Slides を使用してビデオを操作します。挿入、置換、トリミング、ポスターフレームと再生オプションの設定、そして PPT、PPTX、ODP 用にプレゼンテーションをエクスポートします。"
---
**Aspose.Slides for PHP via Java** を使用して、ビデオ フレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオ フレームの追加**

スライドにビデオ フレームを挿入します。

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ビデオ フレームを追加します。
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ビデオ フレームへのアクセス**

スライドに追加された最初のビデオ フレームを取得します。

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のビデオフレームにアクセスします。
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ビデオ フレームの削除**

スライドからビデオ フレームを削除します。

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがビデオフレームであると想定します。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // ビデオフレームを削除します。
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ビデオ再生の設定**

スライドが表示されるときにビデオが自動的に再生されるように設定します。

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがビデオフレームであると想定します。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // ビデオを自動再生するように設定します。
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```