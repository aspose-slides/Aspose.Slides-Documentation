---
title: .NET でプレゼンテーションのビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/net/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込み
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
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のスライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、オーディエンスとのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などの Web ソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを指定してプレゼンテーションにビデオを埋め込みます。  
4. [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) オブジェクトを追加してビデオのフレームを作成します。  
5. 変更されたプレゼンテーションを保存します。  

```c#
// Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("pres.pptx"))
{
    // ビデオを読み込みます
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


または、[AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) メソッドにファイルパスを直接渡してビデオを追加することもできます。  

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）にある場合、その Web リンクを使用してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。  
4. ビデオフレームのサムネイルを設定します。  
5. プレゼンテーションを保存します。  

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

    // サムネイルをロードします
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **スライドからビデオを抽出**

ビデオをスライドに追加するだけでなく、Aspose.Slides を使用してプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) オブジェクトを列挙します。  
3. すべての [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) を探します。  
4. ビデオをディスクに保存します。  

```c#
 // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
 Presentation presentation = new Presentation("Video.pptx");

 // スライドを反復処理します
 foreach (ISlide slide in presentation.Slides)
 {
     // シェイプを反復処理します
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // ビデオを含む VideoFrame が見つかったら、ビデオをディスクに保存します
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

**VideoFrame の再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、増加幅は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) があり、これを読み取ってディスクに保存する際などに使用できます。