---
title: ビデオフレーム
type: docs
weight: 10
url: /net/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにビデオフレームを追加する"
---

プレゼンテーションにおいて適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります：

* ローカルビデオを追加または埋め込む（自分のマシンに保存されているビデオ）
* オンラインビデオを追加する（YouTubeなどのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)インターフェース、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)インターフェース、およびその他の関連タイプを提供しています。

## **埋め込まれたビデオフレームを作成する**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)オブジェクトを追加し、プレゼンテーションにビデオを埋め込むためのビデオファイルパスを渡します。
1. ビデオのフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)オブジェクトを追加します。
1. 修正されたプレゼンテーションを保存します。

このC#コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
using (Presentation pres = new Presentation("pres.pptx"))
{
    // ビデオをロード
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // 最初のスライドを取得し、ビデオフレームを追加
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // プレゼンテーションをディスクに保存
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
また、[AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)メソッドにビデオのファイルパスを直接渡すことで、ビデオを追加することもできます：

```csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **ウェブソースからのビデオでビデオフレームを作成する**
Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)では、プレゼンテーションでYouTubeビデオをサポートしています。使用したいビデオがオンラインで利用可能な場合（例えばYouTube上）、そのウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このC#コードは、PowerPointプレゼンテーション内のスライドにウェブからビデオを追加する方法を示しています：

```c#
public static void Run()
{
    // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // ビデオフレームを追加
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // サムネイルをロード
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **スライドからビデオを抽出する**
スライドにビデオを追加することに加えて、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe)を見つけます。
4. ビデオをディスクに保存します。

このC#コードは、プレゼンテーションスライドからビデオを抽出する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("Video.pptx");

// スライドを反復
foreach (ISlide slide in presentation.Slides)
{
    // シェイプを反復
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ビデオを含むVideoFrameが見つかった場合、ディスクにビデオを保存
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