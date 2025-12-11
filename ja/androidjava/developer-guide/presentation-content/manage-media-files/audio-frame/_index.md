---
title: Android でのプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/androidjava/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオの追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオの抽出
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でオーディオ フレームを作成および制御する—埋め込み、トリミング、ループ、再生設定を行う PPT、PPTX、ODP プレゼンテーション用の Java サンプル。"
---

## **オーディオ フレームの作成**
Aspose.Slides for Android via Java を使用すると、スライドに音声ファイルを追加できます。音声ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込む音声ファイルのストリームを読み込みます。
4. 埋め込み音声フレーム（音声ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) と、[IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame) オブジェクトが公開する `Volume` を設定します。
6. 変更したプレゼンテーションを保存します。

この Java コードは、埋め込み音声フレームをスライドに追加する方法を示しています：
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // wav 音声ファイルをストリームに読み込みます
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // オーディオフレームを追加します
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // オーディオの再生モードとボリュームを設定します
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint ファイルをディスクに書き込みます
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **オーディオ フレーム サムネイルの変更**

プレゼンテーションに音声ファイルを追加すると、音声は標準のデフォルト画像が設定されたフレームとして表示されます（下記画像参照）。このフレームのプレビュー画像（好きな画像）に変更できます。

この Java コードは、オーディオ フレームのサムネイル（プレビュー画像）を変更する方法を示しています：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 指定された位置とサイズでスライドにオーディオフレームを追加します。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // プレゼンテーションのリソースに画像を追加します。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オーディオフレームの画像を設定します。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //変更されたプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for Android via Java では、音声の再生やプロパティを制御するオプションを変更できます。たとえば、音量の調整、ループ再生の設定、音声アイコンの非表示などが可能です。

Microsoft PowerPoint の **Audio Options** ペイン：

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) プロパティに対応しています：

- **Start** のドロップダウンは [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) プロパティに対応
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) プロパティに対応
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) プロパティに対応
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) プロパティに対応
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) プロパティに対応
- **Rewind after Playing** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) プロパティに対応

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) プロパティに対応しています：

- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) プロパティに対応
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) プロパティに対応
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) プロパティに対応
- **Trim Audio End Time** の値は、音声の全長から [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) プロパティの値を引いたものに等しい

PowerPoint の音声コントロールパネルにある **Volume control** は、[AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) プロパティに対応し、パーセンテージで音量を変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです：

1. [Create](#create-audio-frame) でオーディオ フレームを作成するか、既存のフレームを取得します。
2. 変更したいオーディオ フレーム プロパティに新しい値を設定します。
3. 変更した PowerPoint ファイルを保存します。

この Java コードは、音声のオプションを調整する操作例を示しています：
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 再生モードをクリック時再生に設定します
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 音量を低に設定します
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライド間で音声を再生するように設定します
    audioFrame.setPlayAcrossSlides(true);

    // 音声のループを無効にします
    audioFrame.setPlayLoopMode(false);

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.setHideAtShowing(true);

    // 再生後に音声を先頭に巻き戻します
    audioFrame.setRewindAudio(true);

    // PowerPoint ファイルをディスクに保存します
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java の例は、埋め込み音声付きの新しいオーディオ フレームを追加し、トリミングとフェード 時間を設定する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを 1.5 秒に設定します
    audioFrame.setTrimFromStart(1500f);
    // トリミング終了オフセットを 2 秒に設定します
    audioFrame.setTrimFromEnd(2000f);

    // フェードイン時間を 200 ミリ秒に設定します
    audioFrame.setFadeInDuration(200f);
    // フェードアウト時間を 500 ミリ秒に設定します
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


次のコードサンプルは、埋め込み音声付きオーディオ フレームを取得し、音量を 85% に設定する方法を示しています：
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオフレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオの音量を 85% に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **オーディオの抽出**

Aspose.Slides for Android via Java を使用すると、スライドショーの切り替え時に使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. 音声を含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この Java コードは、スライドで使用されている音声を抽出する方法を示しています：
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 対象のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドのスライドショー遷移効果を取得します
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //バイト配列でサウンドを抽出します
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**同じ音声アセットを複数のスライドで再利用して、ファイルサイズを増やさずに済むでしょうか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) に音声を1回だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防がれ、プレゼンテーションサイズが抑制されます。

**既存のオーディオ フレームのサウンドを形状を作り直さずに差し替えることは可能ですか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルに更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている元の音声データを変更しますか？**

いいえ。トリミングは再生範囲だけを調整し、元の音声バイト列は変更されず、埋め込み音声またはプレゼンテーションの音声コレクションを通じて引き続きアクセス可能です。