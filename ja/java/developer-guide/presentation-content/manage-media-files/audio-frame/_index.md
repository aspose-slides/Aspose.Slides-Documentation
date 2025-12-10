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
- オーディオ を追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ の抽出
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でオーディオ フレームを作成・制御します。埋め込み、トリミング、ループ、再生設定を行うコード例を、PPT、PPTX、ODP プレゼンテーション向けに紹介します。"
---

## **オーディオフレームの作成**

Aspose.Slides for Java は、スライドにオーディオ ファイルを追加することを可能にします。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドのインデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイルのストリームを読み込みます。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) と `Volume` を [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame) オブジェクトで設定します。
6. 変更されたプレゼンテーションを保存します。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // wav サウンド ファイルをストリームに読み込みます
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

プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像が付いたフレームとして表示されます（以下のセクションの画像をご参照ください）。オーディオ フレームのプレビュー画像を（好きな画像に）変更できます。

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

    //変更したプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for Java は、オーディオの再生や属性を制御するオプションを変更することを可能にします。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) プロパティに対応しています：

- **Start** ドロップダウン リストは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-) メソッドに対応します
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-) メソッドに対応します
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) メソッドに対応します
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) メソッドに対応します
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) メソッドに対応します
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) メソッドに対応します

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) プロパティに対応しています：

- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) メソッドに対応します
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) メソッドに対応します
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) メソッドに対応します
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) メソッドの値を引いたものに等しいです

PowerPoint のオーディオ コントロール パネル上の **Volume controll** は [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-) メソッドに対応しています。音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです:

1. [Сreate](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 再生モードをクリック時再生に設定します
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 音量を Low に設定します
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライド全体でオーディオを再生するように設定します
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループを無効にします
    audioFrame.setPlayLoopMode(false);

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを先頭に戻すように設定します
    audioFrame.setRewindAudio(true);

    // PowerPoint ファイルをディスクに保存します
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java コードは、オーディオのオプションを調整する操作を示しています:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミングの開始オフセットを 1.5 秒に設定します
    // トリミングの終了オフセットを 2 秒に設定します
    // フェードインの期間を 200 ms に設定します
    // フェードアウトの期間を 500 ms に設定します

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


この Java の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングし、フェード時間を設定する方法を示しています:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオの音量を85%に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


次のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオの音量を85%に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **オーディオの抽出**

Aspose.Slides for Java は、スライドショーの遷移に使用されるサウンドを抽出することを可能にします。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. 該当スライドのインデックスを使用して参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 指定したスライドにアクセスします
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

**複数のスライドで同じオーディオ資産を再利用して、ファイル サイズを増大させずに済みますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) に一度だけ追加し、その既存資産を参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防がれ、プレゼンテーションのサイズが制御できます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) から別のオーディオに [embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) オブジェクトを差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている根本的なオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲だけを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じてアクセス可能です。