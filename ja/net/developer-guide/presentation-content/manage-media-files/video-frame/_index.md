---
title: ビデオフレーム
type: docs
weight: 10
url: /ja/net/video-frame/
keywords: "動画の追加、ビデオフレームの作成、動画の抽出、PowerPointプレゼンテーション、C#、Csharp、Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにビデオフレームを追加する"
---

プレゼンテーションに適切に配置された動画は、メッセージをより説得力のあるものにし、オーディエンスとのエンゲージメントレベルを高めることができます。  

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります。

* ローカル動画（マシンに保存）を追加または埋め込む
* オンライン動画（YouTube などのウェブソース）を追加する

プレゼンテーションに動画（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連タイプを提供します。  

## **埋め込みビデオフレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、プレゼンテーションに動画を埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに動画を埋め込みます。  
1. [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) オブジェクトを追加して動画用のフレームを作成します。  
1. 変更されたプレゼンテーションを保存します。  

この C# コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 動画をロードします
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

あるいは、動画のファイルパスを直接 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) メソッドに渡して動画を追加することもできます:
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Web ソースからの動画でビデオフレームを作成**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube 動画の使用をサポートしています。オンライン（例: YouTube）に動画がある場合、そのウェブリンクを使用してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、動画へのリンクを渡します。  
1. ビデオフレームのサムネイルを設定します。  
1. プレゼンテーションを保存します。  

この C# コードは、Web から動画を取得して PowerPoint のスライドに追加する方法を示しています:
```c#
public static void Run()
{
    // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
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


## **スライドから動画を抽出**

動画をスライドに追加するだけでなく、Aspose.Slides を使用するとプレゼンテーションに埋め込まれた動画を抽出できます。

1. 動画を含むプレゼンテーションを読み込むために [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) オブジェクトを列挙します。  
3. すべての [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) を探します。  
4. 動画をディスクに保存します。  

この C# コードは、プレゼンテーションのスライドから動画を抽出する方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
Presentation presentation = new Presentation("Video.pptx");

// スライドを反復処理します
foreach (ISlide slide in presentation.Slides)
{
    // 図形を反復処理します
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 動画を含む VideoFrame が見つかったら、動画をディスクに保存します
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

**Which video playback parameters can be changed for a VideoFrame?**  
[playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) オブジェクトのプロパティを介して利用可能です。

**Does adding a video affect the PPTX file size?**  
はい。ローカル動画を埋め込むとバイナリデータがドキュメントに含まれるため、ファイルサイズは動画のサイズに比例して増加します。オンライン動画を追加するとリンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さく抑えられます。

**Can I replace the video in an existing VideoFrame without changing its position and size?**  
はい。フレーム内の [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えることで、形状の位置やサイズを保持したまま動画を差し替えることができます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**Can the content type (MIME) of an embedded video be determined?**  
はい。埋め込まれた動画には [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) があり、これを取得して使用できます（例: ディスクに保存する際など）。