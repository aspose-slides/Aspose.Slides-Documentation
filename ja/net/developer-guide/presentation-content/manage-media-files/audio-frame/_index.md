---
title: C# を使用してプレゼンテーション内のオーディオを管理する
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/net/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ の追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ の抽出
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でオーディオ フレームを作成および制御します — C# の例で埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーションに適用します。"
---

## **オーディオフレームの作成**

Aspose.Slides for .NET を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [プレゼンテーション ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームを読み込みます。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) と、[IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) オブジェクトが提供する `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

以下の C# コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
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

    // PowerPoint ファイルをディスクに保存します
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオフレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（以下のセクションの画像を参照）。オーディオ フレームのサムネイル（希望の画像）を変更できます。

以下の C# コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 指定した位置とサイズでスライドにオーディオ フレームを追加します。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // プレゼンテーションのリソースに画像を追加します。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // オーディオ フレームの画像を設定します。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// 変更されたプレゼンテーションをディスクに保存します。
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオ再生オプションの変更**

Aspose.Slides for .NET を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:
![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) プロパティに対応しています:
- **Start** ドロップダウン メニューは [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) プロパティに対応しています
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) プロパティに対応しています
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) プロパティに対応しています
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) プロパティに対応しています
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) プロパティに対応しています
- **Rewind after Playing** は [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) プロパティに対応しています

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) プロパティに対応しています:
- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) プロパティに対応しています
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) プロパティに対応しています
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) プロパティに対応しています
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) プロパティの値を引いたものと同等です

PowerPoint のオーディオ コントロール パネル上の **Volume controll** は [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) プロパティに対応しています。音量をパーセンテージで変更できます。

オーディオ 再生 オプションを変更する手順は次のとおりです:
1. [作成](#create-audio-frame) またはオーディオ フレームを取得します。
2. 調整したいオーディオ フレーム プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

以下の C# コードは、オーディオのオプションを調整する操作を示しています:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 再生モードをクリック時再生に設定します
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 音量を低に設定します
    audioFrame.Volume = AudioVolumeMode.Low;

    // スライド全体でオーディオを再生するように設定します
    audioFrame.PlayAcrossSlides = true;

    // オーディオのループを無効にします
    audioFrame.PlayLoopMode = false;

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.HideAtShowing = true;

    // 再生後にオーディオを先頭に巻き戻します
    audioFrame.RewindAudio = true;

    // PowerPoint ファイルをディスクに保存します
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


以下の C# の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングし、フェード時間を設定する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを1.5秒に設定します
    audioFrame.TrimFromStart = 1500f;
    // トリミング終了オフセットを2秒に設定します
    audioFrame.TrimFromEnd = 2000f;

    // フェードイン時間を200ミリ秒に設定します
    audioFrame.FadeInDuration = 200f;
    // フェードアウト時間を500ミリ秒に設定します
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


次のコードサンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // オーディオの音量を85%に設定します
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオの抽出**

Aspose.Slides for .NET を使用すると、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

以下の C# コードは、スライドで使用されるオーディオを抽出する方法を示しています:
```c#
string presName = "AudioSlide.pptx";

// Instantiates a Presentation class that represents a presentation file
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

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズが増加しないようにできますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) に一度だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズが抑制されます。

**既存のオーディオ フレームのサウンドを、形状を再作成せずに置き換えることはできますか？**

はい。リンクサウンドの場合は、[link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングにより、プレゼンテーションに保存されている元のオーディオ データは変更されますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイト列はそのまま残り、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じてアクセス可能です。