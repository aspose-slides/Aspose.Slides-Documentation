---
title: プレゼンテーションでのオーディオ管理（PHP 使用）
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/php-java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ 追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ 抽出
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP でオーディオ フレームを作成・制御します。埋め込み、トリム、ループ、再生設定を PPT、PPTX、ODP プレゼンテーションで行うコード例を掲載しています。"
---
## **オーディオ フレームを作成**

Aspose.Slides for PHP via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームを読み込みます。
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [AudioFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/) オブジェクトが公開する [PlayMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/AudioPlayModePreset) と `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この PHP コードは、スライドに埋め込まれたオーディオ フレームを追加する方法を示しています:

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
$pres = new Presentation();
try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # wav サウンドファイルをストリームにロードします
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # オーディオ フレームを追加します
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # オーディオの再生モードと音量を設定します
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint ファイルを書き出してディスクに保存します
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **オーディオ フレームのサムネイルを変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が付いたフレームとして表示されます（以下の画像参照）。オーディオ フレームのプレビュー画像（好きな画像）に変更できます。

この PHP コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# 指定された位置とサイズでスライドにオーディオ フレームを追加します。
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# プレゼンテーションのリソースに画像を追加します。
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# オーディオ フレームの画像を設定します。
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----
	
	# 変更されたプレゼンテーションをディスクに保存します
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **オーディオ 再生オプションを変更**

Aspose.Slides for PHP via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生を設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/) プロパティに対応:

- **Start** ドロップダウンは [AudioFrame::setPlayMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setPlayMode) メソッドに対応
- **Volume** は [AudioFrame::setVolume](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setVolume) メソッドに対応
- **Play Across Slides** は [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに対応
- **Loop until Stopped** は [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに対応
- **Hide During Show** は [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに対応
- **Rewind after Playing** は [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setRewindAudio) メソッドに対応

PowerPoint **Editing** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/) プロパティに対応:

- **Fade In** は [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに対応
- **Fade Out** は [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに対応
- **Trim Audio Start Time** は [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに対応
- **Trim Audio End Time** の値はオーディオの長さから [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を引いたものに等しい

PowerPoint のオーディオ コントロール パネルの **Volume controll** は [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応し、音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順:

1. [Create](#create-audio-frame) または取得した Audio Frame を使用します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この PHP コードは、オーディオのオプションを調整する操作を示しています:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # AudioFrame シェイプを取得します
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # クリック時に再生するように再生モードを設定します
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 音量を低に設定します
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # スライド間でオーディオを再生するように設定します
    $audioFrame->setPlayAcrossSlides(true);
    # オーディオのループを無効にします
    $audioFrame->setPlayLoopMode(false);
    # スライドショー中に AudioFrame を非表示にします
    $audioFrame->setHideAtShowing(true);
    # 再生後にオーディオを先頭に巻き戻します
    $audioFrame->setRewindAudio(true);
    # PowerPoint ファイルをディスクに保存します
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

この PHP の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示します:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // トリミング開始オフセットを 1.5 秒に設定します
    $audioFrame->setTrimFromStart(1500);
    // トリミング終了オフセットを 2 秒に設定します
    $audioFrame->setTrimFromEnd(2000);

    // フェードイン時間を 200 ミリ秒に設定します
    $audioFrame->setFadeInDuration(200);
    // フェードアウト時間を 500 ミリ秒に設定します
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

次のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // オーディオ フレーム シェイプを取得します
    $audioFrame = $slide->getShapes()->get_Item(0);

    // オーディオの音量を 85% に設定します
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **オーディオ キャプションを管理**

Aspose.Slides を使用すると、[getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを介してオーディオ フレームにクローズド キャプションを追加できます。このメソッドは [CaptionsCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの反復、必要に応じた削除が可能です。

**オーディオ キャプションを追加**

[getCaptionTracks](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用して、1 つまたは複数のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックを読み込みます。

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // WebVTT ファイルから新しいキャプション トラックを追加します。
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**オーディオ キャプションを抽出**

オーディオ フレームに関連付けられたキャプション トラックを反復し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと一意の識別子を公開しており、キャプションのエクスポート時に使用できます。

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // 各キャプション トラックを .vtt ファイルとして保存します。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**オーディオ キャプションを削除**

オーディオ フレームからキャプションを削除するには、[CaptionsCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/) が提供するメソッド（[clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#remove)、[removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/captionscollection/#removeAt) など）を使用します。次の例は、オーディオ フレームからすべてのキャプション トラックを削除します。

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // タイプ: AudioFrame

    // オーディオ フレームからすべてのキャプション トラックを削除します。
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **オーディオを抽出**

Aspose.Slides for PHP via Java を使用すると、スライド ショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. オーディオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getSlideShowTransition) にアクセスします。
4. バイト データとしてサウンドを抽出します。

このコードは、スライドで使用されているオーディオを抽出する方法を示しています:

```php
# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# 目的のスライドにアクセスします
	$slide = $pres->getSlides()->get_Item(0);
	# スライドのスライドショー遷移効果を取得します
	$transition = $slide->getSlideShowTransition();
	# 音声をバイト配列として抽出します
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用し、ファイル サイズを増加させずに済みますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getaudios/) にオーディオを一度追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーション サイズが抑制されます。

**既存のオーディオ フレームのサウンドを形状を再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/setlinkpathlong/) を新しいファイルに更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getaudios/) から別の埋め込みオーディオ オブジェクトに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎オーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。