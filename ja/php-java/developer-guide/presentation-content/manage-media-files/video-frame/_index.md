---
title: PHP を使用してプレゼンテーションのビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/php-java/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込み
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument スライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---


プレゼンテーションで適切に配置されたビデオは、メッセージをより魅力的にし、オーディエンスとのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が2つあります。

* ローカルビデオを追加または埋め込む（コンピュータに保存されているもの）
* オンラインビデオを追加する（YouTube などのウェブソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) クラス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) オブジェクトを追加してビデオのフレームを作成します。
1. 変更したプレゼンテーションを保存します。

この PHP コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("pres.pptx");
  try {
    # ビデオをロード
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


あるいは、[addVideoFrame(float x,float y,float width,float height,Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) メソッドにファイルパスを直接渡すことでビデオを追加することもできます。
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


## **Web ソースからのビデオでビデオフレームを作成する**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）に存在する場合、そのウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) オブジェクトを追加し、ビデオへのリンクを渡します。
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


## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトを反復処理します。
3. すべての [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) を見つけます。
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

**VideoFrame で変更できるビデオ再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズの増加は小さくなります。

**既存の VideoFrame のビデオを位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えても、シェイプの形状は保持されます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには取得できる [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) があり、例えばディスクに保存する際に利用できます。