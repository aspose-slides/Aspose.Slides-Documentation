---
title: プレゼンテーションで PHP を使用してビデオフレームを管理する
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint と OpenDocument のスライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---
プレゼンテーションに適切に配置された動画は、メッセージをより魅力的にし、観客とのエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります。

* ローカル動画を追加または埋め込む（マシンに保存されているもの）
* オンライン動画を追加する（YouTube などの Web ソースから）。

プレゼンテーションに動画（ビデオオブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) クラス、およびその他の関連型を提供します。

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、プレゼンテーションに動画を埋め込むための動画フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに動画を埋め込みます。
1. [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを追加して、動画のフレームを作成します。
1. 変更されたプレゼンテーションを保存します。

この PHP コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示しています。

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

あるいは、[addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addvideoframe/) メソッドにファイルパスを直接渡して動画を追加することもできます：

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

## **Web ソースからの動画を使用した動画フレームの作成**

Microsoft の [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube 動画をサポートしています。使用したい動画がオンライン（例: YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) オブジェクトを追加し、動画へのリンクを渡します。
1. 動画フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この PHP コードは、Web から動画を取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています：

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

## **ビデオキャプションの管理**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションの動画フレームに対してクローズドキャプションを管理できます。キャプションは WebVTT 形式で保存され、[VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオフレームへキャプションを追加**

動画フレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに動画を追加します。
1. [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトをスライドに追加します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/) コレクションを使用して、WebVTT キャプショントラックを追加します。
1. 変更されたプレゼンテーションを保存します。

次のコードは、動画フレームへキャプションを追加する方法を示しています：

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // WebVTT ファイルから新しいキャプショントラックを追加します。
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供しています。

**動画フレームからキャプションを抽出**

動画フレームからキャプションを抽出するには：

1. 動画を含むプレゼンテーションをロードします。
1. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを見つけます。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) コレクションを列挙します。
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

次のコードは、動画フレームからキャプションを抽出する方法を示しています：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // キャプショントラックを WebVTT ファイルに保存します。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

各 [Captions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、およびキャプションテキスト（UTF-8 文字列）を提供します。

**動画フレームからキャプションを削除**

動画フレームからキャプションを削除するには：

1. 動画を含むプレゼンテーションをロードします。
1. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを取得します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) コレクションからキャプショントラックを削除します。
1. 変更されたプレゼンテーションを保存します。

次のコードは、動画フレームからすべてのキャプションを削除する方法を示しています：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // タイプ: VideoFrame

    // ビデオフレームからすべてのキャプションを削除します。
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

1 つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

## **スライドから動画を抽出**

スライドに動画を追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、動画を含むプレゼンテーションをロードします。
2. すべての [Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) オブジェクトを列挙します。
3. すべての [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) を探します。
4. 動画をディスクに保存します。

この PHP コードは、プレゼンテーションスライド上の動画を抽出する方法を示しています：

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

## **よくある質問**

**VideoFrame の再生パラメータで変更できる項目は何ですか？**

再生モード（自動またはクリック時）とループ設定（[playback mode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setplaymode/) と [looping](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setplayloopmode/)）を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**動画を追加すると PPTX ファイルのサイズに影響しますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズの増加は小さくなります。

**既存の VideoFrame の動画を、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプの形状を保持したまま動画を置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれた動画のコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込まれた動画には [content type](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/getcontenttype/) があり、これを読み取って使用できます。たとえばディスクに保存する際などに活用できます。