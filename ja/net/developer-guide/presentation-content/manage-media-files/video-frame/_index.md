---
title: .NET のプレゼンテーションでビデオフレームを管理する
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
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument スライドでビデオフレームの追加や抽出をプログラムで行う方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、視聴者とのエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が2つあります：
* ローカルビデオを追加または埋め込む（マシンに保存されている）
* オンラインビデオを追加する（YouTube などのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は[IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
4. ビデオ用のフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) オブジェクトを追加します。
5. 変更したプレゼンテーションを保存します。

この C# コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：
```c#
// Presentation クラスのインスタンス化
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

あるいは、ファイルパスを直接[AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) メソッドに渡すことでビデオを追加することもできます：
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の[PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例：YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオフレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この C# コードは、ウェブからビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています：
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


## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) を探します。
4. ビデオをディスクに保存します。

この C# コードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています：
```c#
 // プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します 
Presentation presentation = new Presentation("Video.pptx");

// スライドを走査します
foreach (ISlide slide in presentation.Slides)
{
    // シェイプを走査します
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ビデオを含む VideoFrame が見つかったらビデオをディスクに保存します
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


## **よくある質問**

**VideoFrame の再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）として[playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) を制御し、[looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) を設定できます。これらのオプションは[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリ データが文書に含まれ、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さく抑えられます。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したまま置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには[content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) があり、これを読み取って使用できます。たとえばディスクに保存する際などに利用できます。