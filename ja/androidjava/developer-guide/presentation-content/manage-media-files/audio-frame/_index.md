---
title: Android でのプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/androidjava/audio-frame/
keywords:
- オーディオ
- オーディオフレーム
- サムネイル
- オーディオを追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオを抽出
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でオーディオ フレームを作成および制御します。埋め込み、トリミング、ループ、再生設定を行う Java の例を示し、PPT、PPTX、ODP プレゼンテーション全体での再生を構成できます。"
---

## **オーディオ フレームの作成**
Aspose.Slides for Android via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはスライドにオーディオ フレームとして埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) と `Volume` を [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame) オブジェクトで設定します。
6. 変更されたプレゼンテーションを保存します。

この Java コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // wav サウンドファイルをストリームにロード
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // オーディオフレームを追加
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // オーディオの再生モードと音量を設定
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint ファイルをディスクに書き込む
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **オーディオ フレーム サムネイルの変更**
プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（下のセクションの画像を参照）。オーディオ フレームのプレビュー画像（任意の画像）を変更できます。

この Java コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています。
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドに指定された位置とサイズでオーディオフレームを追加
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // プレゼンテーションのリソースに画像を追加
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オーディオフレームの画像を設定
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // 変更されたプレゼンテーションをディスクに保存
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **オーディオ 再生オプションの変更**
Aspose.Slides for Android via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン：

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) プロパティに対応します。

- **Start** ドロップダウン リストは [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) プロパティに対応します
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) プロパティに対応します
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) プロパティに対応します
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) プロパティに対応します
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) プロパティに対応します
- **Rewind after Playing** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) プロパティに対応します

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) プロパティに対応します。

- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) プロパティに対応します
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) プロパティに対応します
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) プロパティに対応します
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) の値を引いたものに等しいです

PowerPoint のオーディオ コントロール パネル上の **Volume controll** は [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) プロパティに対応し、オーディオの音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです。

1. [Сreate](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame のプロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この Java コードは、オーディオのオプションを調整する操作を示しています。
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 再生モードをクリック時再生に設定
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 音量を Low に設定
    audioFrame.setVolume(AudioVolumeMode.Low);

    // オーディオをスライド間で再生するように設定
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループを無効にする
    audioFrame.setPlayLoopMode(false);

    // スライドショー中に AudioFrame を非表示にする
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを先頭に巻き戻す
    audioFrame.setRewindAudio(true);

    // PowerPoint ファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングし、フェード時間を設定する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを 1.5 秒に設定
    audioFrame.setTrimFromStart(1500f);
    // トリミング終了オフセットを 2 秒に設定
    audioFrame.setTrimFromEnd(2000f);

    // フェードイン時間を 200 ミリ秒に設定
    audioFrame.setFadeInDuration(200f);
    // フェードアウト時間を 500 ミリ秒に設定
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています。
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオフレームシェイプを取得
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオの音量を85%に設定
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **オーディオの抽出**
Aspose.Slides for Android via Java を使用すると、スライドショーのトランジションで使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスで対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この Java のコードは、スライドで使用されるオーディオを抽出する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 目的のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドのスライドショー遷移効果を取得
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //バイト配列としてサウンドを抽出
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用してファイル サイズを増やさずに済みますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) に一度だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーション サイズを抑制できます。

**既存のオーディオ フレームのサウンドを形状を再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) から別の埋め込みオーディオ オブジェクトに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングにより、プレゼンテーションに保存されている基になるオーディオ データが変更されますか？**

いいえ。トリミングは再生の開始・終了位置だけを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。