---
title: .NET でプレゼンテーションのビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/net/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

ビデオは、アイデアを説明し、オーディエンスを引き付けるのに役立ちます。Aspose.Slides for .NET を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートしています。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) インターフェイス、その他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは、保存が完了するまで開いたままになります。これは、[LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) がプレゼンテーションが使用している間ロックされたままにするためです。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

ローカルビデオのパスを直接 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能である必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Web ソースからのビデオでビデオフレームを作成する**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートしています。YouTube ビデオなど、オンラインビデオへのリンクを持つビデオフレームを作成できます。

この例は、最初のスライドに YouTube ビデオのリンクとサムネイルを追加します。別のビデオを使用する場合は、ビデオ識別子を置き換えてください。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 設定は自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアーもオンラインビデオの再生をサポートしている必要があります。

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **全画面モードでビデオを再生する**

トレーニング用プレゼンテーションでは、ソフトウェアデモを全画面モードで再生し、オーディエンスに詳細を見せることができます。再生中にこの動作を有効にするには、[FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) を `true` に設定します。

この例はプレゼンテーションを開き、最初のスライドで最初の [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) を検索し、全画面再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

全画面再生はビデオの表示方法を制御します。別個に、[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) は自動開始かクリック開始かを制御し、[PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) は繰り返し再生するかを制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) に設定します。この例は既存の開始設定とループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションでは、デモビデオを最初に戻すことで、プレゼンターが再度再生できるようにします。再生が終了した後にビデオを最初に戻すには、[RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) を `true` に設定します。

この例はプレゼンテーションを開き、最初のスライドで最初の [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) を検索し、巻き戻しを有効にします。ループを無効にして再生が完了できるようにし、クリックで開始するように再生を設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

巻き戻しはビデオを再び開始せずに最初に戻します。対照的に、[PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) を有効にすると再生が自動的に繰り返されます。ビデオを終了させ、再生待ちの状態にしたい場合はループを無効にしておいてください。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) は自動開始またはクリック開始を個別に制御します。この例では [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) を使用し、プレゼンターが再生開始時期を制御します。例に示すように、ループ設定の後に再生モードを設定します。巻き戻しは [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) とは独立して機能します。

## **ビデオフレームのトリミング**

[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) と [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) を使用して、再生中にビデオの開始部または終了部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定の設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒より長いビデオを使用してください。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**トリム設定の読み取り**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションには少なくとも1つのスライドが必要です。そのスライドにビデオフレームがない場合は何も出力されません。前の例は 2500 と 1000 の値を生成します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームのクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) プロパティで取得できます。

**ビデオフレームへのキャプションの追加**

この例はローカルビデオを埋め込み、英語とラベル付けされた WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオと一致させる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからのキャプションの抽出**

この例は、最初のスライド上のビデオフレームからすべてのキャプショントラックを別々の WebVTT ファイルとして保存します。連番で出力ファイルを区別します。コンソールは抽出されたトラック数を報告します。プレゼンテーションには少なくとも1つのスライドが必要です。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

各 [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) オブジェクトはキャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからのキャプションの削除**

この例は、最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

1 つだけキャプショントラックを削除したい場合は、[Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) の代わりに [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) メソッドを使用してください。

## **スライドからビデオを抽出する**

スライドへのビデオ追加に加えて、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

この例は各スライドから埋め込みビデオを抽出し、個別の番号付きバイナリファイルに保存します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールは各ビデオの MIME タイプと総数を出力します。出力は汎用的な `.bin` 拡張子を使用します。必要に応じて、報告されたメディアタイプに合わせて変更してください。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**ビデオフレームの再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック）とループ設定を [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) と [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) で制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して大きくなります。オンラインビデオへのリンクとサムネイルを追加する場合、プレゼンテーションはビデオデータではなくリンクとプレビュー画像を保存するため、サイズ増加は通常小さくなります。

**既存のビデオフレームのビデオを位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えても、シェイプの形状は保持できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) があり、取得して使用できます。たとえばディスクに保存する際などに利用できます。