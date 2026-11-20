---
title: PHP を使用してプレゼンテーションのビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/php-java/video-frame/
keywords:
- 動画の追加
- 動画の作成
- 動画の埋め込み
- 動画の抽出
- 動画の取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。簡潔なハウツーガイドです。"
---
## **はじめに**

動画はアイデアの説明や観客の関心を引くのに役立ちます。Aspose.Slides for PHP via Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカル動画と、YouTube 動画などオンライン動画へのリンクの両方をサポートしています。

動画データおよび動画フレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) クラス、その他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、動画フレームを作成してプレゼンテーションに埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカル動画を埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままです。なぜなら [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) がプレゼンテーションが使用中の間ロックを保持するためです。

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

ローカル動画のパスを [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) に直接渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドに動画を埋め込みます。動画はプレゼンテーションが保存されるまでアクセス可能である必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Web ソースから動画を使用したビデオフレームの作成**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンライン動画をサポートしています。YouTube 動画などのオンライン動画へのリンクを持つビデオフレームを作成できます。

この例は、最初のスライドに YouTube 動画のリンクとサムネイルを追加します。別の動画を使用する場合は動画識別子を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) メソッドは自動再生を要求します。サムネイルのダウンロードと動画の再生にはインターネット接続が必要です。プレゼンテーションビューアーもオンライン動画再生をサポートしている必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **フルスクリーンモードで動画を再生する**

トレーニング用プレゼンテーションでは、ソフトウェアデモンストレーションをフルスクリーンで再生して、観客が詳細を見ることができます。再生中にこの動作を有効にするには、`true` を指定して [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドの最初の [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) を見つけ、フルスクリーン再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

フルスクリーン再生は動画の表示方法を制御します。別途、[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) は自動開始かクリック開始かを制御し、[setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) は繰り返し再生かどうかを制御します。開始動作を選択するには、[VideoPlayModePreset::Auto または VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) に再生モードを設定してください。この例は既存の開始およびループ設定を保持します。

## **再生後に動画を巻き戻す**

トレーニング用プレゼンテーションで、デモ動画を最初に戻すことで、プレゼンターが再び再生できるようにします。再生が終了した後に動画を最初に戻すには、`true` を指定して [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドの最初の [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリックで開始するように設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

巻き戻しは動画を最初に戻すだけで、再度開始はしません。対照的に、`true` を指定して [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) を呼び出すと再生が自動的に繰り返されます。動画を最後まで再生させて再度再生できる状態にしたい場合はループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) は自動開始またはクリック開始を個別に制御します。この例では [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) を使用し、プレゼンターが再生開始のタイミングを制御できるようにしています。ループ設定の後に再生モードを設定してください。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) とは独立して機能します。

## **ビデオフレームのトリミング**

[VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) を使用して、再生時に動画の冒頭または末尾の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込み動画データを変更せずに再生設定を変更します。

**トリム設定の設定**

この例はローカル動画を埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、動画は 3.5 秒以上の長さである必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**トリム設定の取得**

この例は最初のスライドの最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションに少なくとも 1 枚のスライドが含まれている必要があります。そのスライドにビデオフレームがない場合は何も出力されません。前の例は 2500 と 1000 の値を生成します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズドキャプションを管理する機能を提供します。キャプションは WebVTT 形式で保存され、[VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

### **ビデオフレームにキャプションを追加する**

この例はローカル動画を埋め込み、English というラベルの WebVTT キャプショントラックを追加します。キャプションのタイムスタンプは動画に合わせる必要があります。保存されたプレゼンテーションには動画とキャプションの両方が含まれます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供します。

### **ビデオフレームからキャプションを抽出する**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番で出力ファイルを区別します。コンソールは抽出されたトラック数を報告します。プレゼンテーションには少なくとも 1 枚のスライドが必要です。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

各 [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) オブジェクトはキャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

### **ビデオフレームからキャプションを削除する**

この例は最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

1 つだけキャプショントラックを削除したい場合は、[clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

### **ビデオキャプションを検索する**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) はヘッダー、タイミング行、キャプションテキストを含む完全な WebVTT トラックを返します。メモリ内のキューを検索して、話されたフレーズとそのタイムスタンプを見つけることができます。例えば、スライド 2 の英語トラックは次のようなテキストを含む場合があります。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

この例は `captioned_media.pptx` を開き、[VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) を使用して各スライド上の最上位ビデオフレームのトラックを読み取ります。プレーンテキストのキューでは、タイミング行に `-->` が含まれ、空行でキューが終了します。キャプションに大小文字を問わず “café” が含まれる場合、例はスライド番号、トラックラベル、元のタイミング行、全文キャプションを出力します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

“café” を検索するとサンプルトラックで 1 件の一致が得られます。検索はトラックヘッダーを除外し、出力でタイミング設定を保持します。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **スライドから動画を抽出する**

スライドに動画を追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

この例は各スライドから埋め込み動画を個別の番号付きバイナリファイルに抽出します。リンクされた動画は埋め込みデータがないためスキップされます。コンソールは各動画の MIME タイプと総数を出力します。出力は汎用的な `.bin` 拡張子を使用しますが、必要に応じて報告されたメディアタイプに合わせて変更してください。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ビデオフレームの再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode)（自動またはクリック）と [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) オブジェクトのメソッドを通じて利用可能です。

**動画を追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンライン動画へのリンクとサムネイルだけを追加した場合、動画データは保存されずリンクとプレビュー画像のみが保存されるため、サイズ増加は通常は小さくなります。

**既存のビデオフレームの位置やサイズを変更せずに動画を差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) を入れ替えることで、シェイプの幾何情報を保持したまま動画を更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込み動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込み動画には [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) があり、これを読み取って例えばディスクに保存する際に使用できます。