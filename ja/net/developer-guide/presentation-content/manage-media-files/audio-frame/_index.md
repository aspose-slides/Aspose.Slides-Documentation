---
title: .NET のプレゼンテーションでオーディオ フレームを管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/net/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオの追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオの抽出
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でオーディオ フレームを作成・制御します—C# の例で埋め込み、トリミング、ループ、そして PPT、PPTX、ODP プレゼンテーションでの再生設定を行います。"
---

## **オーディオフレームの作成**

Aspose.Slides for .NET では、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはスライドにオーディオ フレームとして埋め込まれます。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) と `Volume` を [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) オブジェクトが公開するものとして設定します。
6. 変更されたプレゼンテーションを保存します。

```c#
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];
    
    // wav サウンド ファイルをストリームにロードします
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // オーディオ フレームを追加します
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // オーディオの再生モードと音量を設定します
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPoint ファイルをディスクに書き込みます
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオフレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（下のセクションの画像を参照）。オーディオ フレームのサムネイル（任意の画像）を変更できます。

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 指定された位置とサイズでスライドにオーディオ フレームを追加します。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // プレゼンテーションのリソースに画像を追加します。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // オーディオ フレームの画像を設定します。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

	//変更されたプレゼンテーションをディスクに保存します
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオ再生オプションの変更**

Aspose.Slides for .NET では、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) プロパティに対応しています。

- **Start** ドロップダウン メニューは [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) プロパティに対応します
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) プロパティに対応します
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) プロパティに対応します
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) プロパティに対応します
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) プロパティに対応します
- **Rewind after Playing** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) プロパティに対応します

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) properties:

- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) プロパティに対応します
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) プロパティに対応します
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) プロパティに対応します
- **Trim Audio End Time** の値は、オーディオの総時間から [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) の値を引いたものに等しくなります

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) property. It lets you change the audio volume as a percentage.

Audio 再生オプションを変更する手順は次のとおりです。

1. [Create](#create-audio-frame) または Audio Frame を取得します。
2. 変更したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 再生モードをクリック時再生に設定します
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 音量を Low に設定します
    audioFrame.Volume = AudioVolumeMode.Low;

    // 音声をスライド全体で再生するように設定します
    audioFrame.PlayAcrossSlides = true;

    // 音声のループを無効にします
    audioFrame.PlayLoopMode = false;

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.HideAtShowing = true;

    // 再生後に音声を先頭へ巻き戻します
    audioFrame.RewindAudio = true;

    // PowerPoint ファイルをディスクに保存します
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミングの開始オフセットを 1.5 秒に設定します
    audioFrame.TrimFromStart = 1500f;
    // トリミングの終了オフセットを 2 秒に設定します
    audioFrame.TrimFromEnd = 2000f;

    // フェードインの時間を 200 ミリ秒に設定します
    audioFrame.FadeInDuration = 200f;
    // フェードアウトの時間を 500 ミリ秒に設定します
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // オーディオフレーム・シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // オーディオの音量を85%に設定します
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオの抽出**

Aspose.Slides for .NET では、スライドショー遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象のスライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

```c#
string presName = "AudioSlide.pptx";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**同じオーディオ資産を複数のスライドで再利用して、ファイルサイズが増大しないようにできますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) に一度だけ追加し、既存の資産を参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズが抑えられます。

**既存のオーディオ フレームのサウンドを形状を再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎のオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。