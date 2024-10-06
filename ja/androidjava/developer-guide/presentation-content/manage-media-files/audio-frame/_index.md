---
title: オーディオフレーム
type: docs
weight: 10
url: /ja/androidjava/audio-frame/
keywords: "オーディオの追加, オーディオフレーム, オーディオプロパティ, オーディオの抽出, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにオーディオを追加する"
---

## **オーディオフレームを作成する**
Aspose.Slides for Android via Javaを使用すると、スライドにオーディオファイルを追加できます。オーディオファイルは、スライドにオーディオフレームとして埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオファイルストリームをロードします。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset)と[IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame)オブジェクトによって公開される`Volume`を設定します。
6. 修正されたプレゼンテーションを保存します。

このJavaコードは、スライドに埋め込まれたオーディオフレームを追加する方法を示しています：

```Java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // wav音声ファイルをストリームに読み込む
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // オーディオフレームを追加する
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // オーディオのプレイモードとボリュームを設定する
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPointファイルをディスクに書き込む
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **オーディオフレームのサムネイルを変更する**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像としてフレームに表示されます（下のセクションの画像を参照）。オーディオフレームのプレビュー画像を変更します（好みの画像を設定します）。

このJavaコードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 指定された位置とサイズでスライドにオーディオフレームを追加する。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // プレゼンテーションリソースに画像を追加。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オーディオフレームに画像を設定する。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // 修正されたプレゼンテーションをディスクに保存
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **オーディオ再生オプションを変更する**

Aspose.Slides for Android via Javaを使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオのボリュームを調整したり、オーディオをループ再生したり、オーディオアイコンを非表示にすることができます。

Microsoft PowerPointの**オーディオオプション**ペイン：

![example1_image](audio_frame_0.png)

PowerPointのオーディオオプションは、Aspose.Slidesの[AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame)プロパティに対応しています：
- オーディオオプションの**開始**ドロップダウンリストは、[AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--)プロパティに一致します
- オーディオオプションの**ボリューム**は、[AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--)プロパティに一致します
- オーディオオプションの**スライド間で再生**は、[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)プロパティに一致します
- オーディオオプションの**停止するまでループ**は、[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--)プロパティに一致します
- オーディオオプションの**スライドショー中は非表示**は、[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--)プロパティに一致します
- オーディオオプションの**再生後に巻き戻す**は、[AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--)プロパティに一致します

オーディオの再生オプションを変更する手順は次のとおりです：

1. [オーディオフレームを作成](#create-audio-frame)または取得します。
2. 調整したいオーディオフレームのプロパティに新しい値を設定します。
3. 修正されたPowerPointファイルを保存します。

このJavaコードは、オーディオのオプションが調整される操作を示しています：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame形状を取得する
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // プレイモードをクリック時に再生するように設定する
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // ボリュームを小に設定する
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライド間で再生するように設定する
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループ再生を無効にする
    audioFrame.setPlayLoopMode(false);

    // スライドショー中にAudioFrameを非表示にする
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを巻き戻す
    audioFrame.setRewindAudio(true);

    // PowerPointファイルをディスクに保存する
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **オーディオの抽出**

Aspose.Slides for Android via Javaを使用すると、スライドショーのトランジションに使用される音声を抽出できます。たとえば、特定のスライドで使用される音声を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、スライドトランジションを含むプレゼンテーションをロードします。
2. 対象のスライドにアクセスします。
3. スライドの[スライドショートランジション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)にアクセスします。
4. バイトデータで音声を抽出します。

このJavaコードは、スライドで使用されるオーディオを抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成する
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 対象のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドのスライドショートランジション効果を取得する
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // 音声をバイト配列で抽出する
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("長さ: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```