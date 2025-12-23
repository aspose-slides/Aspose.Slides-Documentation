---
title: PHP を使用してプレゼンテーション内のビデオフレームを管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/php-java/video-frame/
keywords:
- ビデオの追加
- ビデオの作成
- ビデオの埋め込み
- ビデオの抽出
- ビデオの取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint および OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。すばやいハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、観客とのエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオを追加または埋め込み（マシンに保存されているもの）
* オンラインビデオを追加（YouTube などのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) インターフェイス、その他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) オブジェクトを追加してビデオのフレームを作成します。
1. 変更されたプレゼンテーションを保存します。

この PHP コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("pres.pptx");
  try {
    # ビデオをロードします
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 最初のスライドを取得し、ビデオフレームを追加します
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # プレゼンテーションをディスクに保存します
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


または、ファイルパスを直接 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドに渡すことでビデオを追加できます。
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


## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で利用可能な場合、そのウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この PHP コードは、ウェブからビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
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


## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、ビデオが含まれるプレゼンテーションをロードします。
2. すべての [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) オブジェクトを反復処理します。
3. すべての [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) オブジェクトを反復処理して、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この PHP コードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # ファイル拡張子を取得します
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


## **FAQ**

**VideoFrame の再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）とループ設定[https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/)（auto or on click）および[https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/)（looping）を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) オブジェクトのプロパティを通じて利用可能です。

**ビデオを追加すると PPTX ファイルのサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame 内のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えても、シェイプのジオメトリは保持されます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込まれたビデオには [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) があり、読み取って使用できます。例えばディスクに保存する際などです。