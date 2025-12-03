---
title: Java を使用したプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ の追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ の抽出
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でオーディオ フレームを作成・制御します—埋め込み、トリム、ループ、PPT、PPTX、ODP プレゼンテーションでの再生設定のコード例。"
---

## **オーディオ フレームの作成**

Aspose.Slides for Java はスライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームを読み込みます。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame) オブジェクトが提供する [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) と `Volume` を設定します。
6. 変更したプレゼンテーションを保存します。

この Java コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // wav サウンド ファイルをストリームにロードします
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // オーディオ フレームを追加します
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // オーディオの再生モードと音量を設定します
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint ファイルをディスクに書き込みます
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **オーディオ フレームのサムネイルを変更**

プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像を持つフレームとして表示されます（以下の画像を参照）。オーディオ フレームのプレビュー画像を好きな画像に変更できます。

この Java コードは、オーディオ フレームのサムネイル（プレビュー画像）を変更する方法を示しています:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 指定した位置とサイズでスライドにオーディオ フレームを追加します。
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

    // オーディオ フレームの画像を設定します。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //変更されたプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for Java は、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) プロパティに対応しています:

- **Start** ドロップダウンは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-) メソッドに対応
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-) メソッドに対応
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) メソッドに対応
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) メソッドに対応
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) メソッドに対応
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) メソッドに対応

PowerPoint の **Editing** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) プロパティに対応しています:

- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) メソッドに対応
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) メソッドに対応
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) メソッドに対応
- **Trim Audio End Time** の値はオーディオ全体の長さから [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) メソッドの値を引いたものに等しい

PowerPoint のオーディオ コントロール パネルの **Volume control** は [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-) メソッドに対応し、音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順:

1. [Create](#create-audio-frame) もしくは取得したオーディオ フレームを使用します。
2. 変更したいオーディオ フレーム プロパティに新しい値を設定します。
3. 変更した PowerPoint ファイルを保存します。

この Java コードは、オーディオのオプションを調整する操作を示しています:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 再生モードをクリック時再生に設定します
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // ボリュームを Low に設定します
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライド全体でオーディオを再生するように設定します
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループを無効にします
    audioFrame.setPlayLoopMode(false);

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを先頭に巻き戻します
    audioFrame.setRewindAudio(true);

    // PowerPoint ファイルをディスクに保存します
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java の例は、埋め込みオーディオ付きの新しいオーディオ フレームを追加し、トリムおよびフェード時間を設定する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
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


以下のコードサンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオ の音量を 85% に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **オーディオ の抽出**

Aspose.Slides for Java は、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. オーディオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この Java のコードは、スライドで使用されるオーディオを抽出する方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 対象スライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドのスライドショー遷移効果を取得します
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //バイト配列としてサウンドを抽出します
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増大させない方法はありますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) にオーディオを一度だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複を防ぎ、プレゼンテーションのサイズを抑えられます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることは可能ですか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルに更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基になるオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元のオーディオ バイトは変更されず、そのまま埋め込みオーディオやプレゼンテーションのオーディオ コレクションからアクセス可能です。