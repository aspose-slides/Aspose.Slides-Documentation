---
title: Java を使用したプレゼンテーションでオーディオを管理する
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオの追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオの抽出
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でオーディオ フレームを作成および制御します—PPT、PPTX、ODP プレゼンテーション向けの埋め込み、トリム、ループ、再生設定のコード例。"
---
## **オーディオフレームの作成**

Aspose.Slides for Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはスライドにオーディオ フレームとして埋め込まれます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイルのストリームをロードします。
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. IAudioFrame オブジェクトが提供する PlayMode と Volume を設定します。
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

## **オーディオ フレーム サムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（以下の画像を参照）。オーディオ フレームのプレビュー画像（好みの画像）に変更できます。

この Java コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドに指定された位置とサイズでオーディオ フレームを追加します。
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

    // 変更したプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **オーディオ 再生オプションの変更**

Aspose.Slides for Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** パネル:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options**（Aspose.Slides の [AudioFrame] プロパティに対応）:

- **Start** ドロップダウン リストは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setPlayMode-int-) メソッドに対応します
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setVolume-int-) メソッドに対応します
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) メソッドに対応します
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) メソッドに対応します
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) メソッドに対応します
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) メソッドに対応します

PowerPoint の **Editing** オプション（Aspose.Slides の [AudioFrame] プロパティに対応）:

- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) メソッドに対応します
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) メソッドに対応します
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) メソッドに対応します
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) メソッドの値を差し引いたものに等しくなります

PowerPoint のオーディオ コントロール パネルの **Volume** コントロールは [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/audioframe/#setVolumeValue-float-) メソッドに対応します。音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順:

1. [作成](#create-audio-frame) または取得した Audio Frame。
2. 調整したい Audio Frame のプロパティに新しい値を設定します。
3. 変更した PowerPoint ファイルを保存します。

この Java コードは、オーディオのオプションを調整する操作を示しています:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 再生モードをクリック時に再生するように設定します
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 音量を Low に設定します
    audioFrame.setVolume(AudioVolumeMode.Low);

    // オーディオをスライド全体で再生するように設定します
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

この Java 例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示しています:

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

    // フェードインの長さを 200 ミリ秒に設定します
    audioFrame.setFadeInDuration(200f);
    // フェードアウトの長さを 500 ミリ秒に設定します
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // オーディオの音量を 85% に設定します
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **オーディオ キャプションの管理**

Aspose.Slides は、[getCaptionTracks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) メソッドを使用してオーディオ フレームにクローズド キャプションを追加できるようにします。このメソッドは [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの反復、必要に応じた削除が可能です。

**オーディオ キャプションの追加**

[getCaptionTracks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) メソッドを使用して、1 つまたは複数のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックをロードしています。

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

オーディオ フレームに関連付けられたキャプション トラックを反復処理し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと一意の識別子を公開しており、キャプションのエクスポート時に使用できます。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // キャプショントラックを .vtt ファイルとして保存します。
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**オーディオ キャプションの削除**

キャプションをオーディオ フレームから削除するには、[ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) が提供する [clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#clear--)、[remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)、または [removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#removeAt-int-) メソッドを使用します。以下の例は、オーディオ フレームからすべてのキャプション トラックを削除します。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // オーディオ フレームからすべてのキャプショントラックを削除します。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オーディオの抽出**

Aspose.Slides for Java を使用すると、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この Java コードは、スライドで使用されているオーディオを抽出する方法を示しています:

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

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズが増大しないようにできますか？**

はい。プレゼンテーションの共有 **audio collection** にオーディオを 1 回だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が回避され、プレゼンテーション サイズを抑制できます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) を新しいファイルに更新します。埋め込みサウンドの場合は、プレゼンテーションの **audio collection** から別の [embedded audio](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) オブジェクトに差し替えます。フレームの書式設定や多くの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている基礎のオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを介して引き続きアクセス可能です。