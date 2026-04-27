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
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、視聴者とのエンゲージメントを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオ（マシンに保存されたもの）を追加または埋め込む  
* オンラインビデオ（YouTube などのウェブソース）を追加する  

ビデオオブジェクトをプレゼンテーションに追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供しています。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合は、ビデオフレームを作成してプレゼンテーションに埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドの参照を取得します。  
3. ビデオを埋め込むためにビデオファイルのパスを渡して [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) オブジェクトを追加します。  
4. ビデオ用のフレームを作成するために [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを追加します。  
5. 変更したプレゼンテーションを保存します。

この C# コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。

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
または、ビデオのファイル パスを直接 [AddVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addvideoframe/) メソッドに渡してビデオを追加することもできます。

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **ウェブソースからのビデオフレームの作成**
Microsoft [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオの使用をサポートしています。使用したいビデオがオンライン（例: YouTube）にある場合は、ウェブ リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドの参照を取得します。  
3. ビデオへのリンクを渡して [IVideo](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideo/) オブジェクトを追加します。  
4. ビデオフレームのサムネイルを設定します。  
5. プレゼンテーションを保存します。

この C# コードは、ウェブ上のビデオを PowerPoint スライドに追加する方法を示しています。

```c#
public static void Run()
{
    // プレゼンテーション ファイルを表す Presentation オブジェクトのインスタンスを作成します 
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

## **ビデオキャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーション内のビデオフレームのクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) プロパティを介して取得できます。

**ビデオフレームにキャプションを追加する**

ビデオフレームにキャプションを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーションにビデオを追加します。  
3. スライドに [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを追加します。  
4. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションを使用して WebVTT キャプショントラックを追加します。  
5. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオフレームにキャプションを追加する方法を示しています。

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

[ICaptionsCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出する**

ビデオフレームからキャプションを抽出する手順:

1. ビデオを含むプレゼンテーションをロードします。  
2. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを見つけます。  
3. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションを列挙します。  
4. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、ビデオフレームからキャプションを抽出する方法を示しています。

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

各 [ICaptions](https://reference.aspose.com/slides/ja/net/aspose.slides/icaptions/) オブジェクトは、キャプション識別子、ラベル、バイナリ データ、UTF-8 文字列としてのキャプション テキストを公開します。

**ビデオフレームからキャプションを削除する**

ビデオフレームからキャプションを削除する手順:

1. ビデオを含むプレゼンテーションをロードします。  
2. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) オブジェクトを取得します。  
3. [CaptionTracks](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/captiontracks/) コレクションからキャプショントラックを削除します。  
4. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています。

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

1 つのキャプショントラックだけを削除したい場合は、[Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/clear/) の代わりに [Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/captionscollection/removeat/) メソッドを使用してください。

## **スライドからビデオを抽出する**
ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide) オブジェクトを列挙します。  
3. すべての [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe) を探します。  
4. ビデオをディスクに保存します。

この C# コードは、プレゼンテーション スライドからビデオを抽出する方法を示しています。

```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトのインスタンスを作成します 
Presentation presentation = new Presentation("Video.pptx");

// スライドを反復処理します
foreach (ISlide slide in presentation.Slides)
{
    // シェイプを反復処理します
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

## **FAQ**

**VideoFrame の再生パラメータで変更できる項目は何ですか？**

[再生モード](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/playmode/)（自動またはクリック時）と [ループ設定](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/playloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、ファイル サイズに比例してプレゼンテーションのサイズが増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので増加幅は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/net/aspose.slides/videoframe/embeddedvideo/) を入れ替えることで、形状のジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/ja/net/aspose.slides/video/contenttype/) が設定されており、読み取ってディスクに保存する際などに利用できます。