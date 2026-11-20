---
title: PHP を使用したプレゼンテーションでのオーディオフレーム管理
linktitle: オーディオフレーム
type: docs
weight: 10
url: /ja/php-java/audio-frame/
keywords:
- オーディオ
- オーディオフレーム
- サムネイル
- オーディオ追加
- オーディオプロパティ
- オーディオオプション
- オーディオ抽出
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、スライドにオーディオを埋め込み、オーディオアイコンを変更し、再生を構成し、WebVTT 字幕を管理し、スライド遷移のサウンドを抽出します。"
---
## **概要**

オーディオフレームを使用すると、スライド上で音声を再生できます。Aspose.Slides for PHP via Java を使用すると、オーディオクリップを埋め込み、その画像を選択し、再生を調整し、字幕を添付できます。また、スライド遷移に割り当てられたサウンドを取得することもできます。

## **オーディオフレームの作成**

ローカルオーディオクリップを最初のスライドに埋め込むには、[addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) を使用します。最初の 2 つの座標はフレームをスライド上に配置し、次の 2 つの値は幅と高さ（単位はポイント）を設定します。この例では、クリップを自動的に開始するために [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) を呼び出し、音量のプリセットを選択するために [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) を呼び出します。

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **オーディオフレームサムネイルの変更**

デフォルトでは、オーディオフレームはスピーカーアイコンを表示します。カスタムサムネイルを表示するには、[addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) でプレゼンテーションに画像を追加し、[setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) でフレームの画像として設定します。この例では、埋め込みオーディオクリップのサムネイルとして JPEG を使用しています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **オーディオ再生オプションの変更**

PowerPoint の **Audio Options** コントロールは、クリップの開始タイミング、音量、スライドショー中の挙動を決定します。

![オーディオフレームの PowerPoint オーディオオプション コントロール](audio_frame_0.png)

| PowerPoint コントロール | Aspose.Slides for PHP via Java メソッド |
| --- | --- |
| 開始 | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| 音量プリセット | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| スライド間で再生 | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| 停止までループ | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| ショー中に非表示 | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| 再生後に巻き戻し | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| フェードイン | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| フェードアウト | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| オーディオ開始時間のトリミング | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| オーディオ終了時間のトリミング | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量スライダー | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

この例は最初のスライドの最初のオーディオフレームを取得し、クリック時に再生を開始するために [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) を呼び出し、低音量プリセットを選択します。ループは無効にしたままスライド間で再生が続きます。アイコンはショー中に非表示にされ、再生後にクリップが巻き戻されます。

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

クリップが 3.5 秒を超える場合、この例は最初の 1.5 秒と最後の 2 秒をスキップします。[setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) はクリップの末尾から除外する時間を指定します。PowerPoint に表示される終了時刻を取得するには、フルクリップの長さからそのオフセットを引きます。トリミングされたクリップは 200 ミリ秒でフェードインし、500 ミリ秒でフェードアウトします。すべてのメソッドはミリ秒単位の値を受け取ります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

再生音量を特定のパーセンテージに設定するには、[setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) を使用します。この例は最初のスライドの最初のオーディオフレームの音量を 85% に設定しています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **オーディオ字幕の管理**

各オーディオフレームは [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) を通じて字幕トラックにアクセスできます。このコレクションを使用して WebVTT 字幕をクリップに添付したり、既存のトラックをエクスポートしたり、削除したりできます。

### **オーディオ字幕の追加**

この例は最初のスライドにオーディオクリップを埋め込み、[add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) を使用してローカル WebVTT トラックを添付します。最初の引数はトラックラベルを提供し、2 番目の引数はタイムコード付き字幕ファイルを指します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **オーディオ字幕の抽出**

この例は最初のスライドのオーディオフレームに添付された各字幕トラックをエクスポートします。[getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) が返すバイトを WebVTT ファイルに書き込み、[getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) が返す識別子をファイル名として使用することで、各トラックが個別の出力になります。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **オーディオ字幕の削除**

[remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) を使用して個別のトラックを削除します。この例は [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) を使用して、クリップを保持したまま最初のスライドの最初のオーディオフレームからすべての字幕を削除しています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **オーディオ字幕内の行を検索**

最初のスライドのオーディオ字幕内で行を検索するには、メモリ内の [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) が返すテキストを検索します。プレーンテキストの WebVTT キューでは、タイミング行に `-->` が含まれ、続いて字幕行が続き、空行でキューが終了します。この例はトラックラベルと “café” を含む各字幕行を出力します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **オーディオの抽出**

スライド遷移には独自のサウンドを設定できる場合があります。それを取得するには、スライド遷移で [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) を呼び出します。この例は [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) が返すバイト数を取得して表示します。最初のスライドに遷移サウンドがない場合は、代わりにメッセージを表示します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**同じオーディオクリップを複数のスライドで重複させずに再利用できますか？**

はい。プレゼンテーションの [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) にクリップを一度追加し、各スライドで同じオーディオオブジェクトを [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) に渡します。

**既存のオーディオフレームのサウンドを置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) を使用して置換ファイルへのパスを指定します。埋め込みサウンドの場合は、[setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) でプレゼンテーションのオーディオコレクションから別のクリップを選択します。どちらの方法でも既存のフレームは保持されます。

**トリミングはプレゼンテーションに保存されているオーディオデータを変更しますか？**

いいえ。[setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) と [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) は再生境界を設定するだけです。フルクリップは引き続き [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) から取得可能です。