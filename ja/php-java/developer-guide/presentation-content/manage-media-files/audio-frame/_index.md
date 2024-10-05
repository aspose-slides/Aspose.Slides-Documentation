---
title: オーディオフレーム
type: docs
weight: 10
url: /php-java/audio-frame/
keywords: "オーディオを追加, オーディオフレーム, オーディオプロパティ, オーディオを抽出, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにオーディオを追加"
---

## **オーディオフレームの作成**
Aspose.Slides for PHP via Javaを使用すると、スライドにオーディオファイルを追加できます。オーディオファイルはスライドにオーディオフレームとして埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに埋め込むオーディオファイルのストリームをロードします。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset)と[IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame)オブジェクトによって公開された`Volume`を設定します。
6. 修正されたプレゼンテーションを保存します。

このPHPコードは、スライドに埋め込まれたオーディオフレームを追加する方法を示しています：

```php
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # wav音声ファイルをストリームにロード
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # オーディオフレームを追加
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # オーディオの再生モードと音量を設定
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPointファイルをディスクに書き込み
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **オーディオフレームのサムネイルを変更**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（以下のセクションの画像参照）。オーディオフレームのプレビュー画像を変更します（好みの画像を設定）。

このPHPコードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 指定された位置とサイズでスライドにオーディオフレームを追加
    $audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    $audioStream->close();
    # プレゼンテーションリソースに画像を追加
    $picture;
    $image = Images->fromFile("eagle.jpeg");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # オーディオフレームの画像を設定
    $audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

    # 修正されたプレゼンテーションをディスクに保存
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **オーディオ再生オプションの変更**

Aspose.Slides for PHP via Javaを使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、オーディオをループ再生したり、オーディオアイコンを非表示にすることができます。

Microsoft PowerPointの**オーディオオプション**パネル：

![example1_image](audio_frame_0.png)

PowerPointオーディオオプションは、Aspose.Slidesの[AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame)プロパティに対応しています：
- オーディオオプションの**開始**ドロップダウンリストは、[AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--)プロパティに一致します
- オーディオオプションの**音量**は[AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--)プロパティに一致します
- オーディオオプションの**スライド全体で再生**は[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--)プロパティに一致します
- オーディオオプションの**停止するまでループ**は[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--)プロパティに一致します
- オーディオオプションの**スライドショー中に非表示**は[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--)プロパティに一致します
- オーディオオプションの**再生後に巻き戻す**は[AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--)プロパティに一致します

オーディオ再生オプションを変更する方法は次のとおりです：

1. [オーディオフレームを作成](#create-audio-frame)または取得します。
2. 調整したいオーディオフレームプロパティに新しい値を設定します。
3. 修正されたPowerPointファイルを保存します。

このPHPコードは、オーディオのオプションを調整する操作を示しています：

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # AudioFrameシェイプを取得
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # クリックで再生するようにプレイモードを設定
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 音量を低に設定
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # スライド全体でオーディオを再生するように設定
    $audioFrame->setPlayAcrossSlides(true);
    # オーディオのループを無効にする
    $audioFrame->setPlayLoopMode(false);
    # スライドショー中にAudioFrameを非表示にする
    $audioFrame->setHideAtShowing(true);
    # 再生後にオーディオを巻き戻す
    $audioFrame->setRewindAudio(true);
    # PowerPointファイルをディスクに保存
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **オーディオの抽出**

Aspose.Slides for PHP via Javaを使用すると、スライドショーのトランジションで使用される音を抽出できます。たとえば、特定のスライドで使用されている音を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成し、スライドトランジションを含むプレゼンテーションをロードします。
2. 希望のスライドにアクセスします。
3. スライドの[スライドショートランジション](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--)にアクセスします。
4. バイトデータで音を抽出します。

このコードは、スライドで使用されているオーディオを抽出する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 希望のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライドのスライドショートランジション効果を取得
    $transition = $slide->getSlideShowTransition();
    # バイト配列で音を抽出
    $audio = $transition->getSound()->getBinaryData();
    echo("長さ: " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```