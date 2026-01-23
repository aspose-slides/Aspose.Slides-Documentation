---
title: PHP を使用したプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/php-java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオを追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ抽出
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP でオーディオ フレームを作成および制御します—埋め込み、トリミング、ループ、再生設定を行うコード例（PPT、PPTX、ODP プレゼンテーション対応）。"
---

## **オーディオ フレームの作成**

Aspose.Slides for PHP via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはスライド内にオーディオ フレームとして埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。  
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。  
5. [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) オブジェクトが公開する [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) と `Volume` を設定します。  
6. 変更されたプレゼンテーションを保存します。

この PHP コードは、埋め込まれたオーディオ フレームをスライドに追加する方法を示します:  
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
$pres = new Presentation();
try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # wav サウンドファイルをストリームにロード
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # オーディオ フレームを追加
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # オーディオの再生モードと音量を設定
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint ファイルを書き込む
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **オーディオ フレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（下記画像参照）。オーディオ フレームのプレビュー画像を変更できます（任意の画像に設定）。

この PHP コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します:  
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


## **オーディオ 再生オプションの変更**

Aspose.Slides for PHP via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** が Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) プロパティに対応する項目:

- **Start** ドロップダウン リストは [AudioFrame::setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode) メソッドに対応します。  
- **Volume** は [AudioFrame::setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume) メソッドに対応します。  
- **Play Across Slides** は [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに対応します。  
- **Loop until Stopped** は [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに対応します。  
- **Hide During Show** は [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに対応します。  
- **Rewind after Playing** は [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio) メソッドに対応します。

PowerPoint **Editing** オプションが Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) プロパティに対応する項目:

- **Fade In** は [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに対応します。  
- **Fade Out** は [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに対応します。  
- **Trim Audio Start Time** は [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに対応します。  
- **Trim Audio End Time** の値はオーディオの総再生時間から [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を差し引いたものに相当します。

オーディオ コントロール パネルの **Volume controll** は [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応し、パーセンテージで音量を変更できます。

オーディオ 再生オプションを変更する手順:

1. [Сreate](#create-audio-frame) または Audio Frame を取得します。  
2. 調整したい Audio Frame プロパティに新しい値を設定します。  
3. 変更された PowerPoint ファイルを保存します。

この PHP コードは、オーディオのオプションを調整する操作を示します:  
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # AudioFrame シェイプを取得
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 再生モードをクリックで再生に設定
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 音量を Low に設定
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # オーディオをスライド全体で再生するように設定
    $audioFrame->setPlayAcrossSlides(true);
    # オーディオのループを無効に設定
    $audioFrame->setPlayLoopMode(false);
    # スライドショー中に AudioFrame を非表示に設定
    $audioFrame->setHideAtShowing(true);
    # 再生後にオーディオを開始位置に巻き戻すように設定
    $audioFrame->setRewindAudio(true);
    # PowerPoint ファイルをディスクに保存
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


この PHP 例は、埋め込みオーディオ付きの新しいオーディオ フレームを追加し、トリミングとフェード時間を設定する方法を示します:  
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // トリミング開始オフセットを 1.5 秒に設定
    $audioFrame->setTrimFromStart(1500);
    // トリミング終了オフセットを 2 秒に設定
    $audioFrame->setTrimFromEnd(2000);

    // フェードインの持続時間を 200 ミリ秒に設定
    $audioFrame->setFadeInDuration(200);
    // フェードアウトの持続時間を 500 ミリ秒に設定
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


以下のコード サンプルは、埋め込みオーディオを含むオーディオ フレームを取得し、音量を 85% に設定する方法を示します:  
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // オーディオ フレーム シェイプを取得
    $audioFrame = $slide->getShapes()->get_Item(0);

    // オーディオの音量を 85% に設定
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **オーディオの抽出**

Aspose.Slides for PHP via Java を使用すると、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。  
2. インデックスを使用して対象スライドの参照を取得します。  
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) にアクセスします。  
4. バイト データとしてサウンドを抽出します。

このコードは、スライドで使用されているオーディオを抽出する方法を示します:  
```php
# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# 目的のスライドにアクセス
	$slide = $pres->getSlides()->get_Item(0);
	# スライドのスライドショー遷移効果を取得
	$transition = $slide->getSlideShowTransition();
	# サウンドをバイト配列として抽出
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用し、ファイル サイズを増大させない方法はありますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) にオーディオを 1 回だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズを抑制できます。

**既存のオーディオ フレームのサウンドをシェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングを行うと、プレゼンテーションに保存されている元のオーディオ データが変更されますか？**

いいえ。トリミングは再生境界のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを介して引き続きアクセス可能です。