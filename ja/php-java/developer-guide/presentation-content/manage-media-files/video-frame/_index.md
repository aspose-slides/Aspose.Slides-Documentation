---
title: PHP を使用したプレゼンテーションでのビデオフレームの管理
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **紹介**

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法として、次の 2 つがあります：

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などのウェブソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) クラス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
4. [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを追加してビデオのフレームを作成します。
5. 変更されたプレゼンテーションを保存します。

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

あるいは、ファイルパスを直接 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addvideoframe/) メソッドに渡すことでビデオを追加できます。

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

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオフレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この PHP コードは、Web からビデオを取得して PowerPoint のスライドに追加する方法を示しています。

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

## **ビデオフレームのトリミング**

Aspose.Slides では、[VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#setTrimFromEnd) を使用して trim-from-start および trim-from-end の値を設定することで、再生するビデオの部分を制御できます。両方の値はミリ秒で指定され、ビデオの開始部と終了部からそれぞれどれだけの時間をスキップするかを定義します。これらの設定はプレゼンテーション内のビデオ再生設定を変更しますが、埋め込まれたビデオのバイナリデータを切断したり変更したりするものではありません。

**トリム設定の設定**

ビデオフレームを作成し、トリム設定を行うには：

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションに [Video](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/) オブジェクトを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#setTrimFromEnd) を使用して trim-from-start および trim-from-end の値を設定します。
5. 変更されたプレゼンテーションを保存します。

以下のコード例は、埋め込みビデオの再生時に最初の 2.5 秒と最後の 1 秒をスキップします。

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**トリム設定の取得**

既存のトリム設定を確認するには、プレゼンテーションを読み込み、最初のスライドのシェイプの中から [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを見つけ、[VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getTrimFromStart) と [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getTrimFromEnd) を使用して値を取得します。

以下のコード例は、最初のスライド上の最初のビデオフレームを見つけ、ミリ秒単位でそのトリム設定を報告します。

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ビデオキャプションの管理**

Aspose.Slides では、PowerPoint プレゼンテーションのビデオフレームに対してクローズドキャプションを管理できます。キャプションは WebVTT 形式で保存され、[VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオフレームへのキャプションの追加**

ビデオフレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションにビデオを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/) コレクションを使用して、WebVTT キャプショントラックを追加します。
5. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームにキャプションを追加する方法を示しています。

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

**ビデオフレームからキャプションを抽出する**

ビデオフレームからキャプションを抽出するには：

1. ビデオが含まれるプレゼンテーションを読み込みます。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを見つけます。
3. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) コレクションを反復処理します。
4. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、ビデオフレームからキャプションを抽出する方法を示しています。

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

各 [Captions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、そして UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除する**

ビデオフレームからキャプションを削除するには：

1. ビデオが含まれるプレゼンテーションを読み込みます。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトを取得します。
3. [getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/#getCaptionTracks) コレクションからキャプショントラックを削除します。
4. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています。

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

## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオが含まれるプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 全ての [Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) オブジェクトを走査します。
3. 全ての [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) オブジェクトを走査して、[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この PHP コードは、プレゼンテーションのスライド上のビデオを抽出する方法を示しています。

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

**VideoFrame の再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）とループ設定（[playback mode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setplaymode/) と [looping](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setplayloopmode/)）を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加した場合は、リンクとサムネイルが埋め込まれるだけなので、サイズの増加は小さくなります。

**既存の VideoFrame のビデオを位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプの位置やサイズを保持したままビデオを置き換えることができます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/ja/php-java/aspose.slides/video/getcontenttype/) があり、これを読み取って利用できます。たとえばディスクに保存する際などに使用できます。