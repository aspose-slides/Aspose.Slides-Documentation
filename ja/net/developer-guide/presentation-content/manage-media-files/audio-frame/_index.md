---
title: オーディオフレーム - C#を使用してPowerPointにオーディオを挿入および抽出する
linktitle: オーディオフレーム
type: docs
weight: 10
url: /ja/net/audio-frame/
keywords: "オーディオサムネイル画像, オーディオを追加, オーディオフレーム, オーディオプロパティ, オーディオを抽出, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにオーディオを追加する"
---

## **オーディオフレームを作成する**
Aspose.Slides for .NETを使用すると、スライドにオーディオファイルを追加できます。オーディオファイルはオーディオフレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに埋め込むオーディオファイルのストリームをロードします。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset)および[IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)オブジェクトによって公開される`Volume`を設定します。
6. 修正されたプレゼンテーションを保存します。

このC#コードは、スライドに埋め込まれたオーディオフレームを追加する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化する
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得する
    ISlide sld = pres.Slides[0];
    
    // wavサウンドファイルをストリームにロードする
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // オーディオフレームを追加する
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // オーディオの再生モードと音量を設定する
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPointファイルをディスクに書き込む
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **オーディオフレームのサムネイルを変更する**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（下のセクションの画像を参照）。オーディオフレームのサムネイルを変更することができます（好みの画像を設定します）。

このC#コードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 指定された位置とサイズでスライドにオーディオフレームを追加する。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // プレゼンテーションリソースに画像を追加する。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // オーディオフレームの画像を設定する。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
    // 修正されたプレゼンテーションをディスクに保存
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **オーディオ再生オプションを変更する**

Aspose.Slides for .NETを使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、オーディオをループ再生するように設定したり、オーディオアイコンを隠すこともできます。

Microsoft PowerPointの**オーディオオプション**パネル：

![example1_image](audio_frame_0.png)

PowerPointのオーディオオプションは、Aspose.Slidesの[AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)プロパティに対応しています：

- オーディオオプションの**開始**ドロップダウンメニューは、[AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)プロパティに一致します 
- オーディオオプションの**音量**は、[AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)プロパティに一致します 
- オーディオオプションの**スライド間再生**は、[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)プロパティに一致します 
- オーディオオプションの**停止するまでループ**は、[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)プロパティに一致します 
- オーディオオプションの**スライドショー中に隠す**は、[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)プロパティに一致します 
- オーディオオプションの**再生後に巻き戻す**は、[AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)プロパティに一致します 

オーディオ再生オプションを変更する方法は次のとおりです：

1. [オーディオフレームを作成](#create-audio-frame)または取得します。
2. 調整したいオーディオフレームプロパティの新しい値を設定します。
3. 修正されたPowerPointファイルを保存します。

このC#コードは、オーディオのオプションを調整する操作を示しています：

```csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrameシェイプを取得します
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 再生モードをクリック時に変更
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 音量を低く設定
    audioFrame.Volume = AudioVolumeMode.Low;

    // オーディオをスライド間で再生するように設定
    audioFrame.PlayAcrossSlides = true;

    // オーディオのループを無効にする
    audioFrame.PlayLoopMode = false;

    // スライドショー中にAudioFrameを隠す
    audioFrame.HideAtShowing = true;

    // 再生後にオーディオを巻き戻す
    audioFrame.RewindAudio = true;

    // PowerPointファイルをディスクに保存
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **オーディオを抽出する**
Aspose.Slides for .NETを使用すると、スライドショーのトランジションで使用される音声を抽出できます。たとえば、特定のスライドで使用される音声を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを介して関連するスライドの参照を取得します。
3. スライドのスライドショートランジションにアクセスします。
4. バイトデータでサウンドを抽出します。

このC#コードは、スライドで使用されるオーディオを抽出する方法を示しています：

```c#
string presName = "AudioSlide.pptx";

// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化する
Presentation pres = new Presentation(presName);

// スライドにアクセスする
ISlide slide = pres.Slides[0];

// スライドのスライドショートランジション効果を取得する
ISlideShowTransition transition = slide.SlideShowTransition;

//バイト配列で音声を抽出する
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```