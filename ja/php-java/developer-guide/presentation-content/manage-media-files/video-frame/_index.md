---
title: ビデオフレーム
type: docs
weight: 10
url: /php-java/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにビデオフレームを追加 "
---

プレゼンテーションに適切に配置されたビデオは、あなたのメッセージをより魅力的にし、観客とのエンゲージメントレベルを高めることができます。

PowerPointは、プレゼンテーションのスライドにビデオを追加するための2つの方法を提供しています：

* ローカルビデオを追加または埋め込む（マシンに保存されている）
* オンラインビデオを追加する（YouTubeなどのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加するために、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)インターフェース、[IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/)インターフェース、その他関連するタイプを提供しています。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)オブジェクトを追加し、プレゼンテーションにビデオを埋め込むためのビデオファイルパスを渡します。
1. [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/)オブジェクトを追加して、ビデオ用のフレームを作成します。
1. 修正されたプレゼンテーションを保存します。

このPHPコードは、ローカルに保存されているビデオをプレゼンテーションに追加する方法を示しています：

```php
  # Presentationクラスのインスタンスを生成
  $pres = new Presentation("pres.pptx");
  try {
    # ビデオを読み込む
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 最初のスライドを取得し、ビデオフレームを追加
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # プレゼンテーションをディスクに保存
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

また、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)メソッドにビデオのファイルパスを直接渡してビデオを追加することもできます：

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ウェブソースからのビデオフレームの作成**

Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーション内でYouTubeビデオをサポートしています。使用したいビデオがオンライン（例えばYouTubeに）利用可能な場合、ウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)オブジェクトを追加し、ビデオのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このPHPコードは、ウェブからスライドにビデオを追加する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトを生成
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **スライドからのビデオの抽出**

スライドにビデオを追加することに加えて、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)オブジェクトを反復処理して[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

このPHPコードは、プレゼンテーションスライド上のビデオを抽出する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトを生成
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # ファイル拡張子を取得
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```