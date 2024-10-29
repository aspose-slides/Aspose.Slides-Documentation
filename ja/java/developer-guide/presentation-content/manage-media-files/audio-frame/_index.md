---
title: オーディオフレーム
type: docs
weight: 10
url: /ja/java/audio-frame/
keywords: "オーディオの追加, オーディオフレーム, オーディオプロパティ, オーディオの抽出, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにオーディオを追加する"
---

## **オーディオフレームの作成**
Aspose.Slides for Javaを使用すると、スライドにオーディオファイルを追加できます。オーディオファイルは、オーディオフレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通してスライドの参照を取得します。
3. スライドに埋め込むオーディオファイルストリームを読み込みます。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset)と、[IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame)オブジェクトによって公開される`Volume`を設定します。
6. 修正されたプレゼンテーションを保存します。

このJavaコードは、スライドに埋め込まれたオーディオフレームを追加する方法を示しています：

```Java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // wav音声ファイルをストリームに読み込み
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // オーディオフレームを追加
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // オーディオのプレイモードとボリュームを設定
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPointファイルをディスクに書き出す
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **オーディオフレームのサムネイルを変更する**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（下のセクションの画像を参照）。オーディオフレームのプレビュー画像を変更することができます（お好みの画像を設定します）。

このJavaコードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドに指定された位置とサイズでオーディオフレームを追加
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // プレゼンテーションリソースに画像を追加
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オーディオフレームの画像を設定
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // 修正されたプレゼンテーションをディスクに保存
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **オーディオ再生オプションを変更する**

Aspose.Slides for Javaを使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオのボリュームを調整したり、オーディオがループ再生されるように設定したり、オーディオアイコンを隠したりすることができます。

Microsoft PowerPointの**オーディオオプション**パネル：

![example1_image](audio_frame_0.png)

PowerPointのオーディオオプションは、Aspose.Slidesの[AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame)プロパティに対応しています：
- オーディオオプションの**開始**ドロップダウンリストは[AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--)プロパティに一致
- オーディオオプションの**ボリューム**は[AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)プロパティに一致
- オーディオオプションの**スライドを越えて再生**は[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)プロパティに一致
- オーディオオプションの**停止するまでループ**は[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)プロパティに一致
- オーディオオプションの**スライドショー中に隠す**は[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)プロパティに一致
- オーディオオプションの**再生後に巻き戻す**は[AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)プロパティに一致

次の手順でオーディオ再生オプションを変更します：

1. [オーディオフレームを作成](#create-audio-frame)または取得します。
2. 調整したいオーディオフレームプロパティの新しい値を設定します。
3. 修正されたPowerPointファイルを保存します。

このJavaコードは、オーディオのオプションが調整される操作を示しています：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrameシェイプを取得
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // クリック時に再生するようにプレイモードを設定
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // ボリュームを低に設定
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライドを越えて再生するように設定
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループを無効にする
    audioFrame.setPlayLoopMode(false);

    // スライドショー中にAudioFrameを隠す
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを巻き戻すように設定
    audioFrame.setRewindAudio(true);

    // PowerPointファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **オーディオを抽出する**

Aspose.Slides for Javaを使用すると、スライドショーのトランジションで使用された音声を抽出できます。たとえば、特定のスライドで使用されている音声を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成し、スライドトランジションを含むプレゼンテーションを読み込みます。
2. 必要なスライドにアクセスします。
3. スライドの[スライドショートランジション](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--)にアクセスします。
4. 音声をバイトデータとして抽出します。

このJavaコードは、スライドで使用されているオーディオを抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 必要なスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドのスライドショートランジション効果を取得
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // バイト配列として音声を抽出
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("長さ: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```