---
title: Android のプレゼンテーションでオーディオを管理する
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/androidjava/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ 追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ 抽出
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でオーディオ フレームを作成・制御する例です。埋め込み、トリミング、ループ、および PPT、PPTX、ODP プレゼンテーションでの再生設定を構成する Java サンプルを紹介します。"
---
## **オーディオ フレームの作成**
Aspose.Slides for Android via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイルのストリームをロードします。
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAudioFrame) オブジェクトが提供する [PlayMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioPlayModePreset) と `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この Java コードは、スライドに埋め込まれたオーディオ フレームを追加する方法を示しています:

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

## **オーディオ フレームのサムネイルの変更**
プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像を持つフレームとして表示されます（以下の画像参照）。オーディオ フレームのプレビュー画像を好きな画像に変更できます。

この Java コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:

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

    // 変更されたプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **オーディオ再生オプションの変更**
Aspose.Slides for Android via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生にしたり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame) プロパティに対応しています:

- **開始** ドロップダウン リストは [AudioFrame.PlayMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) プロパティと一致します
- **音量** は [AudioFrame.Volume](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getVolume--) プロパティと一致します
- **スライドをまたいで再生** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) プロパティと一致します
- **停止までループ** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) プロパティと一致します
- **ショー中に非表示** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) プロパティと一致します
- **再生後に巻き戻し** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) プロパティと一致します

PowerPoint の **Editing** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/) プロパティに対応しています:

- **フェード イン** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) プロパティと一致します
- **フェード アウト** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) プロパティと一致します
- **オーディオ 開始時のトリミング** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) プロパティと一致します
- **オーディオ 終了時のトリミング** の値はオーディオの長さから [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) プロパティの値を引いたものと等しくなります

オーディオ コントロール パネルの音量コントロールは [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) プロパティに対応しており、音量をパーセンテージで変更できます。

オーディオ再生オプションを変更する手順は次のとおりです:

1. [Create](#create-audio-frame) または取得したオーディオ フレームを使用します。
2. 調整したいオーディオ フレーム プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この Java コードは、オーディオのオプションを調整する操作を示しています:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // クリック時に再生するように再生モードを設定します
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 音量 を低 に設定します
    audioFrame.setVolume(AudioVolumeMode.Low);

    // スライド全体でオーディオを再生するように設定します
    audioFrame.setPlayAcrossSlides(true);

    // オーディオのループを無効にします
    audioFrame.setPlayLoopMode(false);

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.setHideAtShowing(true);

    // 再生後にオーディオを開始位置に巻き戻します
    audioFrame.setRewindAudio(true);

    // PowerPoint ファイルをディスクに保存します
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この Java の例は、埋め込みオーディオ付きの新しいオーディオ フレームを追加し、トリミングとフェード時間を設定する方法を示しています:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを 1.5 秒に設定します
    // トリミング終了オフセットを 2 秒に設定します
    // フェードインの期間を 200 ms に設定します
    // フェードアウトの期間を 500 ms に設定します

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
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

    // オーディオ の音量を 85% に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **オーディオ キャプションの管理**
Aspose.Slides は、[getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) メソッドを使用してオーディオ フレームにクローズド キャプションを追加できます。このメソッドは [ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの反復、必要に応じた削除が可能です。

**オーディオ キャプションの追加**

[getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) メソッドを使用して、1 つまたは複数のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックをロードしています。

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT ファイルから新しいキャプション トラックを追加します。
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**オーディオ キャプションの抽出**

オーディオ フレームに関連付けられたキャプション トラックを反復処理し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと一意の識別子を公開しており、エクスポート時に使用できます。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // キャプション トラックを .vtt ファイルとして保存します。
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**オーディオ キャプションの削除**

キャプションをオーディオ フレームから削除するには、[ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/) が提供する `clear`、`remove`、`removeAt` などのメソッドを使用します。次の例は、オーディオ フレームからすべてのキャプション トラックを削除する方法を示しています。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // オーディオ フレームからすべてのキャプション トラックを削除します。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オーディオの抽出**
Aspose.Slides for Android via Java を使用すると、スライドショーの切り替え時に使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. オーディオを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この Java のコードは、スライドで使用されているオーディオを抽出する方法を示しています:

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 目的のスライドにアクセスします
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

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズが膨らむのを防げますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getAudios--) にオーディオを一度追加し、既存のアセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複を防ぎ、プレゼンテーションのサイズを抑制できます。

**既存のオーディオ フレームのサウンドを、シェイプを作り直さずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は [link path](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルに更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getAudios--) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている元のオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲だけを調整し、元のオーディオ バイト列は変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションから引き続きアクセス可能です。