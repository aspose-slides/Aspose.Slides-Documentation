---
title: .NET におけるプレゼンテーションのオーディオ フレームの管理
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
description: "Aspose.Slides for .NET を使用して、スライドにオーディオを埋め込み、オーディオ アイコンを変更し、再生設定を構成し、WebVTT キャプションを管理し、スライド遷移のサウンドを抽出します。"
---
## **概要**

オーディオ フレームを使用すると、スライド上でサウンドを再生できます。Aspose.Slides for .NET を使用すると、オーディオ クリップを埋め込み、これを表す画像を選択し、再生を調整し、キャプションを添付できます。また、スライド遷移に割り当てられたサウンドを取得することもできます。

## **オーディオ フレームの作成**

最初のスライドにローカル オーディオ クリップを埋め込むには、[AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) を使用します。最初の 2 つの座標はフレームの位置を決め、次の 2 つの値は幅と高さをポイント単位で設定します。この例では、[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) を自動的にクリップを開始するように設定し、[Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) を大音量のプリセットに設定しています。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **オーディオ フレームのサムネイルを変更**

デフォルトでは、オーディオ フレームはスピーカー アイコンを表示します。カスタム サムネイルを表示するには、[AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) を使用してプレゼンテーションに画像を追加し、フレームの [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) プロパティに割り当てます。この例では、埋め込みオーディオ クリップのサムネイルとして JPEG を使用しています。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **オーディオ 再生オプションの変更**

PowerPoint の **Audio Options** コントロールは、クリップの開始タイミング、音量、スライドショー中の動作を決定します。

![オーディオ フレームの PowerPoint オーディオ オプション コントロール](audio_frame_0.png)

| PowerPoint コントロール | Aspose.Slides プロパティ |
| --- | --- |
| 開始 | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| 音量プリセット | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| スライド全体で再生 | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| 停止するまでループ | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| ショー中に非表示 | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| 再生後に巻き戻し | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| フェードイン | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| フェードアウト | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| オーディオ開始時間のトリム | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| オーディオ終了時間のトリム | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| 音量スライダー | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

この例は、最初のスライド上の最初のオーディオ フレームを検索し、[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) をクリック時に再生開始するように設定し、低音量プリセットを選択します。クリップはループが無効な状態でスライド間で再生し続けます。アイコンはショー中に非表示のままになり、再生後にクリップが巻き戻ります。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

3.5 秒を超えるクリップの場合、この例は最初の 1.5 秒と最後の 2 秒をスキップします。[TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) はクリップの末尾から除外する時間を測定します。PowerPoint に表示される終了時間を取得するには、そのオフセットをクリップ全体の長さから引きます。トリミングされたクリップは 200 ミリ秒でフェードインし、500 ミリ秒でフェードアウトします。4 つのプロパティはすべてミリ秒単位の値を取ります。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

再生音量を特定のパーセンテージで設定するには、[VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) を使用します。この例では、最初のスライド上の最初のオーディオ フレームを 85% に設定しています。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **オーディオ キャプションの管理**

各オーディオ フレームには [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) コレクションがあります。これを使用して、クリップに WebVTT キャプションを添付したり、既存のトラックをエクスポートしたり、削除したりできます。

### **オーディオ キャプションの追加**

この例は最初のスライドにオーディオ クリップを埋め込み、[ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) を使用してローカル WebVTT トラックを添付します。最初の引数はトラックラベルを指定し、2 番目の引数は時間付きキャプションを含むファイルを指定します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **オーディオ キャプションの抽出**

この例は、最初のスライド上のオーディオ フレームに添付された各キャプショントラックをエクスポートします。トラックの [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) を WebVTT ファイルに書き出し、[CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) をファイル名として使用することで、各トラックが個別の出力となります。

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **オーディオ キャプションの削除**

[Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) を使用して個々のトラックを削除します。この例では、[Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) を使用して、クリップを保持しながら最初のスライド上の最初のオーディオ フレームからすべてのキャプションを削除しています。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **オーディオ キャプション内の行を検索**

最初のスライド上のオーディオ キャプションで行を検索するには、各トラックの [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) をメモリ上で読み取ります。プレーンテキストの WebVTT キューでは、タイミング行に `-->` が含まれ、続く行がキャプションで、空行でキューが終了します。この例は、トラックラベルと “café” を含む各キャプション行を出力します。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **オーディオの抽出**

スライド遷移には独自のサウンドを設定できます。それを取得するには、遷移の [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) プロパティを読み取ります。この例では、サウンドの [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) にアクセスし、そのバイトサイズを出力します。最初のスライドに遷移サウンドがない場合は、代わりにメッセージを出力します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**複数のスライドで同じオーディオ クリップを重複させずに再利用できますか？**

はい。クリップをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) に一度だけ追加し、各スライドで同じオーディオ オブジェクトを [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) に渡します。

**既存のオーディオ フレームのサウンドを置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) を置換ファイルを指すように更新します。埋め込みサウンドの場合は、プレゼンテーションのオーディオ コレクションから別のクリップを [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) に割り当てます。どちらの方法でも既存のフレームは保持されます。

**トリミングはプレゼンテーションに保存されているオーディオ データを変更しますか？**

いいえ。[TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) と [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) は再生範囲を設定します。フルクリップは引き続き [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) から取得可能です。