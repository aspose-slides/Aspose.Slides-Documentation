---
title: Android でのプレゼンテーションにおけるビデオ フレームの管理
linktitle: ビデオ フレーム
type: docs
weight: 10
url: /ja/androidjava/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオ フレーム
- ウェブ ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Aspose.Slides for Android で PowerPoint および OpenDocument スライドにビデオ フレームをプログラムで追加および抽出する方法を学びます。迅速なハウツーガイド。"
---
プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります。

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTubeなどのウェブソースから）

プレゼンテーションにビデオ（ビデオ オブジェクト）を追加できるように、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/)インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオ フレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオ フレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオ ファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. ビデオ用のフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを追加します。
1. 変更されたプレゼンテーションを保存します。

This Java code shows you how to add a video stored locally to a presentation:

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("pres.pptx");
try {
    // ビデオをロード
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 最初のスライドを取得し、ビデオフレームを追加
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // プレゼンテーションをディスクに保存
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

代わりに、ファイル パスを直接[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)メソッドに渡してビデオを追加することもできます：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Web ソースからのビデオでビデオ フレームを作成**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)はプレゼンテーションでYouTubeビデオをサポートしています。使用したいビデオがオンラインで利用可能な場合（例：YouTube）、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオ フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

This Java code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // ビデオフレームを追加
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // サムネイルをロード
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **ビデオ キャプションの管理**

Aspose.Slidesを使用すると、PowerPoint プレゼンテーションのビデオ フレームに対してクローズド キャプションを管理できます。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)メソッドで取得できます。

**ビデオ フレームにキャプションを追加**

ビデオ フレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. プレゼンテーションにビデオを追加します。
1. スライドに[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを追加します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)が返す[ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/)を使用して WebVTT キャプショントラックを追加します。
1. 変更されたプレゼンテーションを保存します。

The following code shows you how to add captions to a video frame:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT ファイルから新しいキャプショントラックを追加します。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/)インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオ フレームからキャプションを抽出**

ビデオ フレームからキャプションを抽出するには：

1. ビデオが含まれるプレゼンテーションをロードします。
1. 対象の[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを見つけます。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)が返すキャプショントラックを反復処理します。
1. 各キャプショントラックを`.vtt`ファイルとして保存します。

The following code shows you how to extract captions from a video frame:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // キャプショントラックを WebVTT ファイルに保存します。
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

各[ICaptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptions/)オブジェクトは、キャプション識別子、ラベル、バイナリ データ、および UTF-8 文字列としてのキャプション データを公開します。

**ビデオ フレームからキャプションを削除**

ビデオ フレームからキャプションを削除するには：

1. ビデオが含まれるプレゼンテーションをロードします。
1. 対象の[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを取得します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)が返すコレクションからキャプショントラックを削除します。
1. 変更されたプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // ビデオフレームからすべてのキャプションを削除します。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1つのキャプショントラックだけを削除する必要がある場合は、[clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/#clear--)の代わりに[remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)または[removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-)メソッドを使用してください。

## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slidesではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/)オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/)オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

This Java code shows you how to extract the video on a presentation slide:

```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //ファイル拡張子を取得
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

**VideoFrameで変更できるビデオ再生パラメータは何ですか？**

再生モード（自動またはクリック時）とループ設定（[looping](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-))を制御できます。これらのオプションは[VideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/)オブジェクトのプロパティで利用可能です。

**ビデオを追加するとPPTXファイルのサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存のVideoFrame内のビデオを位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)を入れ替えることで、シェイプのジオメトリを保持したままビデオを置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには[content type](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/video/#getContentType--)があり、例えばディスクに保存する際などに読み取って使用できます。