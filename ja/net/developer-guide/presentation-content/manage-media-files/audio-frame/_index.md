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
- オーディオを追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオを抽出
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でオーディオ フレームを作成および制御します—埋め込み、トリミング、ループ、再生設定を行う C# の例で、PPT、PPTX、ODP プレゼンテーション全体に対応しています。"
---
## **オーディオ フレームの作成**

Aspose.Slides for .NET は、スライドにオーディオ ファイルを追加できるようにします。オーディオ ファイルは、スライドにオーディオ フレームとして埋め込まれます。

1. [Presentation ](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使ってスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/ja/net/aspose.slides/audioplaymodepreset) と [IAudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe) オブジェクトが公開する `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この C# コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています。

```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];
    
    // wav サウンド ファイルをストリームに読み込みます
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

## **オーディオ フレーム サムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が付いたフレームとして表示されます（以下のセクションの画像を参照）。オーディオ フレームのサムネイル（好みの画像）を変更できます。

この C# コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています。

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // スライドにオーディオ フレームを指定された位置とサイズで追加します。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // プレゼンテーションのリソースに画像を追加します。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Sets the image for the audio frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
    //修正されたプレゼンテーションをディスクに保存します
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **オーディオ 再生オプションの変更**

Aspose.Slides for .NET は、オーディオの再生やプロパティを制御するオプションを変更できるようにします。たとえば、音量を調整したり、ループ再生に設定したり、アイコンを非表示にしたりできます。

The **Audio Options** pane in Microsoft PowerPoint:

![例1_画像](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe) properties:

- **Start** ドロップダウン メニューは [AudioFrame.PlayMode](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/playmode) プロパティに対応しています
- **Volume** は [AudioFrame.Volume](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/volume) プロパティに対応しています
- **Play Across Slides** は [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/playacrossslides) プロパティに対応しています
- **Loop until Stopped** は [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/playloopmode) プロパティに対応しています
- **Hide During Show** は [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/hideatshowing) プロパティに対応しています
- **Rewind after Playing** は [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/properties/rewindaudio) プロパティに対応しています

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe) properties:

- **Fade In** は [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/fadeinduration/) プロパティに対応しています
- **Fade Out** は [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/fadeoutduration/) プロパティに対応しています
- **Trim Audio Start Time** は [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/trimfromstart/) プロパティに対応しています
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/trimfromend/) プロパティの値を引いたものに等しいです

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/volumevalue/) property. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [作成](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

This C# code demonstrates an operation in which an audio's options are adjusted:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame シェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // クリック時に再生するように再生モードを設定します
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 音量を Low に設定します
    audioFrame.Volume = AudioVolumeMode.Low;

    // オーディオをスライド全体で再生するように設定します
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

This C# example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを 1.5 秒に設定します
    audioFrame.TrimFromStart = 1500f;
    // トリミング終了オフセットを 2 秒に設定します
    audioFrame.TrimFromEnd = 2000f;

    // フェードイン時間を 200 ミリ秒に設定します
    audioFrame.FadeInDuration = 200f;
    // フェードアウト時間を 500 ミリ秒に設定します
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // オーディオ フレーム シェイプを取得します
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // オーディオの音量を 85% に設定します
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **オーディオ キャプションの管理**

Aspose.Slides は、[CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/captiontracks/) プロパティを使用してオーディオ フレームにクローズド キャプションを追加できるようにします。このプロパティは [ICaptionsCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの列挙、必要に応じた削除が可能です。

**オーディオ キャプションの追加**

[CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/captiontracks/) プロパティを使用して、1 つ以上のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックをロードします。

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT ファイルから新しいキャプショントラックを追加します。
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**オーディオ キャプションの抽出**

オーディオ フレームに関連付けられたキャプション トラックを列挙し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと一意の識別子を公開しており、エクスポート時に使用できます。

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // キャプショントラックを .vtt ファイルとして保存します。
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**オーディオ キャプションの削除**

[ICaptionsCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/) が提供するメソッド（[Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/clear/)、[Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/removeat/) など）を使用してキャプションを削除します。以下の例は、オーディオ フレームからすべてのキャプション トラックを削除します。

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // オーディオ フレームからすべてのキャプショントラックを削除します。
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **オーディオの抽出**
Aspose.Slides for .NET は、スライドショーの遷移で使用されるサウンドを抽出できるようにします。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. オーディオを含むプレゼンテーションを読み込み、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

この C# コードは、スライドで使用されているオーディオを抽出する方法を示しています。

```c#
string presName = "AudioSlide.pptx";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation(presName);

// スライドにアクセスします
ISlide slide = pres.Slides[0];

// スライドのスライドショー遷移効果を取得します
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズが増大しないようにできますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/audios/) にオーディオを一度だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーション サイズが抑制されます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/linkpathlong/) を新しいファイルに更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/ja/net/aspose.slides/audioframe/embeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/audios/) にある別のオーディオに置き換えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている基礎となるオーディオ データを変更しますか？**

いいえ。トリミングは再生境界のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。