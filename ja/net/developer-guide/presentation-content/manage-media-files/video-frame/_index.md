---
title: .NET でのプレゼンテーションにおける動画フレームの管理
linktitle: 動画フレーム
type: docs
weight: 10
url: /ja/net/video-frame/
keywords:
- 動画の追加
- 動画の作成
- 動画の埋め込み
- 動画の抽出
- 動画の取得
- 動画フレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument スライドに動画フレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

プレゼンテーションに適切に配置された動画は、メッセージをより魅力的にし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が2つあります。

* ローカル動画（マシンに保存されているもの）を追加または埋め込む
* オンライン動画（YouTube などのウェブソース）を追加する

動画オブジェクトをプレゼンテーションに追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) インターフェイス、および関連する型を提供しています。

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、プレゼンテーションに動画を埋め込む動画フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを追加して動画用のフレームを作成します。  
1. 変更したプレゼンテーションを保存します。

以下の C# コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示しています。

```c#
// Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 動画を読み込みます
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // 最初のスライドを取得し、ビデオフレームを追加します
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // プレゼンテーションをディスクに保存します
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
あるいは、[AddVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addvideoframe/) メソッドにファイルパスを直接渡すことで動画を追加することもできます。

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Web ソースからの動画フレームの作成**
Microsoft の新しいバージョンの [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) は、プレゼンテーションでオンライン動画をサポートしています。使用したい動画がオンライン（例: YouTube）にある場合、そのウェブリンクを使用してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) オブジェクトを追加し、動画へのリンクを渡します。
1. 動画フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

以下の C# コードは、ウェブ上の動画を PowerPoint のスライドに追加する方法を示しています。

```c#
public static void Run()
{
    // プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // VideoFrame を追加します
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // サムネイルを読み込みます
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **動画フレームのトリミング**

Aspose.Slides では、[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromstart/) と [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromend/) を使用して、動画の開始位置と終了位置をミリ秒単位で設定することで、再生される部分を制御できます。これらの設定はプレゼンテーション内の動画再生設定を変更しますが、埋め込まれた動画のバイナリデータそのものをカットしたり変更したりはしません。

**トリム設定の設定**

動画フレームを作成し、トリム設定を行う手順:

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) オブジェクトを追加します。
1. スライドに [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを追加します。
1. [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromstart/) と [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromend/) を使用して start と end の値を設定します。
1. 変更したプレゼンテーションを保存します。

以下のコード例は、埋め込まれた動画の再生時に最初の 2.5 秒と最後の 1 秒をスキップする方法を示しています。

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**トリム設定の取得**

既存のトリム設定を確認するには、プレゼンテーションを読み込み、最初のスライド上のシェイプの中から [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを見つけ、[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromstart/) と [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/trimfromend/) の値を取得します。

以下のコード例は、最初のスライド上の最初の動画フレームを取得し、ミリ秒単位のトリム設定をレポートします。

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **動画キャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションの動画フレームに対してクローズドキャプションを管理できる機能を提供します。キャプションは WebVTT 形式で格納され、[IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) プロパティを介してアクセスできます。

**動画フレームにキャプションを追加する**

動画フレームにキャプションを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに動画を追加します。
1. スライドに [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを追加します。
1. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションを使用して WebVTT キャプショントラックを追加します。
1. 変更したプレゼンテーションを保存します。

以下のコードは、動画フレームにキャプションを追加する方法を示しています。

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // WebVTT ファイルから新しいキャプショントラックを追加します。
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供しています。

**動画フレームからキャプションを抽出する**

動画フレームからキャプションを抽出する手順:

1. 動画を含むプレゼンテーションを読み込みます。
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを見つけます。
1. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションを走査します。
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、動画フレームからキャプションを抽出する方法を示しています。

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // キャプショントラックを WebVTT ファイルに保存します。
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

各 [ICaptions](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

**動画フレームからキャプションを削除する**

動画フレームからキャプションを削除する手順:

1. 動画を含むプレゼンテーションを読み込みます。
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを取得します。
1. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションからキャプショントラックを削除します。
1. 変更したプレゼンテーションを保存します。

以下のコードは、動画フレームからすべてのキャプションを削除する方法を示しています。

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // ビデオフレームからすべてのキャプションを削除します。
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

1 つだけのキャプショントラックを削除したい場合は、[Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/clear/) の代わりに [Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/removeat/) メソッドを使用してください。

## **スライドから動画を抽出する**
動画をスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

1. 動画を含むプレゼンテーションを読み込むために [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. すべての [ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide) オブジェクトを走査します。
3. すべての [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape) オブジェクトを走査し、[VideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe) を見つけます。
4. 動画をディスクに保存します。

以下の C# コードは、プレゼンテーションのスライド上の動画を抽出する方法を示しています。

```c#
 // プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します 
 Presentation presentation = new Presentation("Video.pptx");

 // スライドを反復処理します
 foreach (ISlide slide in presentation.Slides)
 {
     // シェイプを反復処理します
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // 動画を含む VideoFrame が見つかったら、ディスクに動画を保存します
         if (shape is VideoFrame)
         {
             IVideoFrame vf = shape as IVideoFrame;
             String type = vf.EmbeddedVideo.ContentType;
             int ss = type.LastIndexOf('/');
             type = type.Remove(0, type.LastIndexOf('/') + 1);
             Byte[] buffer = vf.EmbeddedVideo.BinaryData;
             using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
             {                                                     
                 stream.Write(buffer, 0, buffer.Length);
             }
         }
     }
 }
```

## **FAQ**

**VideoFrame で変更できる動画再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/playmode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/playloopmode/) を [VideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/) オブジェクトのプロパティで制御できます。

**動画を追加すると PPTX ファイルサイズは増加しますか？**

はい。ローカル動画を埋め込むとバイナリデータがドキュメントに含まれるため、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、増加幅は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずに動画だけを差し替えられますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したままメディアを更新できます。これは既存レイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれた動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれた動画には [content type](https://reference.aspose.com/slides/ja/net/aspose.slides/video/contenttype/) があり、読み取ってディスクに保存する際などに利用できます。