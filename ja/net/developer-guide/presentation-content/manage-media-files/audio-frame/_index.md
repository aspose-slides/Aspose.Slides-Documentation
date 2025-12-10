---
title: .NET のプレゼンテーションでオーディオ フレームを管理する
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
description: "Aspose.Slides for .NET でオーディオ フレームを作成および制御する—埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーションで行う C# の例。"
---

## **オーディオフレームの作成**

Aspose.Slides for .NET はスライドにオーディオ ファイルを追加することができます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームを読み込みます。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) と `Volume` を [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) オブジェクトで設定します。
6. 変更したプレゼンテーションを保存します。

この C# コードは、スライドに埋め込みオーディオ フレームを追加する方法を示します。
```c#
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];
    
    // wav サウンド ファイルをストリームに読み込みます
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Audio Frame を追加します
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // オーディオの再生モードと音量を設定します
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPoint ファイルを書き込みます
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオ フレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像が付いたフレームとして表示されます（以下の画像を参照）。オーディオ フレームのサムネイルを変更できます（好きな画像を設定）。

この C# コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します。
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 指定した位置とサイズでスライドにオーディオフレームを追加します。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // プレゼンテーションのリソースに画像を追加します。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // オーディオフレームの画像を設定します。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// 変更したプレゼンテーションをディスクに保存します
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオ再生オプションの変更**

Aspose.Slides for .NET は、オーディオの再生やプロパティを制御するオプションを変更することができます。たとえば、音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

The **Audio Options** pane in Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) properties:
- **Start** ドロップダウンメニューは [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) プロパティに対応しています
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) プロパティに対応しています
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) プロパティに対応しています
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) プロパティに対応しています
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) プロパティに対応しています
- **Rewind after Playing** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) プロパティに対応しています

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) properties:
- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) プロパティに対応しています
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) プロパティに対応しています
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) プロパティに対応しています
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) プロパティの値を引いたものに等しいです

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) property. It lets you change the audio volume as a percentage.

オーディオ 再生 オプションを変更する手順は次のとおりです。

1. [Create](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この C# コードは、オーディオのオプションを調整する操作を示します。
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 再生モードをクリック時再生に設定します
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 音量を低に設定します
    audioFrame.Volume = AudioVolumeMode.Low;

    // 音声をスライド全体で再生するように設定します
    audioFrame.PlayAcrossSlides = true;

    // 音声のループ再生を無効にします
    audioFrame.PlayLoopMode = false;

    // スライドショー中に AudioFrame を非表示にします
    audioFrame.HideAtShowing = true;

    // 再生後に音声を先頭に巻き戻します
    audioFrame.RewindAudio = true;

    // PowerPoint ファイルをディスクに保存します
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


この C# 例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示します。
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


以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、その音量を 85% に設定する方法を示します。
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // オーディオフレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // オーディオの音量を85%に設定します
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **オーディオの抽出**

Aspose.Slides for .NET は、スライドショーの遷移で使用されるサウンドを抽出することができます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスで該当スライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

この C# コードは、スライドで使用されるオーディオを抽出する方法を示します。
```c#
string presName = "AudioSlide.pptx";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation(presName);

// スライドにアクセスします
ISlide slide = pres.Slides[0];

// スライドのスライドショー遷移効果を取得します
ISlideShowTransition transition = slide.SlideShowTransition;

// バイト配列としてサウンドを抽出します
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズが増大しないようにできますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) にオーディオを一度追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防がれ、プレゼンテーションのサイズを抑制できます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) から別のものに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎オーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。