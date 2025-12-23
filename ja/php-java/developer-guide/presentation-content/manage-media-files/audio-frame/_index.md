---
title: PHPを使用したプレゼンテーションでのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/php-java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ の追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ の抽出
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP でオーディオ フレームを作成・制御します—埋め込み、トリム、ループ、PPT、PPTX、ODP プレゼンテーションでの再生設定のコード例です。"
---

## **オーディオフレームの作成**

Aspose.Slides for PHP via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはスライドにオーディオ フレームとして埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) と [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame) オブジェクトが提供する `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この PHP コードは、埋め込みオーディオ フレームをスライドに追加する方法を示しています:
```php
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
$pres = new Presentation();
try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # wav サウンドファイルをストリームにロードします
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # オーディオフレームを追加します
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # オーディオの再生モードと音量を設定します
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint ファイルをディスクに書き込みます
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **オーディオ フレーム サムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像（以下のセクションの画像参照）を持つフレームとして表示されます。オーディオ フレームのプレビュー画像を変更できます（任意の画像を設定）。

この PHP コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# 指定した位置とサイズでスライドにオーディオフレームを追加します。
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
	# オーディオフレームの画像を設定します。
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


## **オーディオ 再生オプションの変更**

Aspose.Slides for PHP via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) プロパティに対応しています:

- **Start** ドロップダウン リストは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode) メソッドに対応しています。
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume) メソッドに対応しています。
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに対応しています。
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに対応しています。
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに対応しています。
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio) メソッドに対応しています。

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) プロパティに対応しています:

- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに対応しています。
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに対応しています。
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに対応しています。
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を引いたものに相当します。

PowerPoint のオーディオ コントロール パネル上の **Volume controll**（音量コントロール）は、[AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応しています。これにより、音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです：

1. [Сreate](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティの新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この PHP コードは、オーディオのオプションを調整する操作を示しています:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # AudioFrame シェイプを取得します
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 再生モードをクリック時に再生に設定します
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 音量を低に設定します
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # オーディオをスライド全体で再生するように設定します
    $audioFrame->setPlayAcrossSlides(true);
    # オーディオのループを無効にします
    $audioFrame->setPlayLoopMode(false);
    # スライドショー中に AudioFrame を非表示にします
    $audioFrame->setHideAtShowing(true);
    # 再生後にオーディオを先頭に戻します
    $audioFrame->setRewindAudio(true);
    # PowerPoint ファイルをディスクに保存します
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


この PHP の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示しています:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // トリミング開始オフセットを1.5秒に設定します
    $audioFrame->setTrimFromStart(1500);
    // トリミング終了オフセットを2秒に設定します
    $audioFrame->setTrimFromEnd(2000);

    // フェードイン期間を200ミリ秒に設定します
    $audioFrame->setFadeInDuration(200);
    // フェードアウト期間を500ミリ秒に設定します
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、その音量を 85% に設定する方法を示しています:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // オーディオフレームシェイプを取得します
    $audioFrame = $slide->getShapes()->get_Item(0);

    // オーディオの音量を85%に設定します
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **オーディオの抽出**

Aspose.Slides for PHP via Java を使用すると、スライドショーのトランジションで使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

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
	# サウンドをバイト配列として抽出します
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増やさずに済みますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) に一度追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズが抑制されます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングにより、プレゼンテーションに保存されている元のオーディオ データが変更されますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオやプレゼンテーションのオーディオ コレクションを介して引き続きアクセス可能です。