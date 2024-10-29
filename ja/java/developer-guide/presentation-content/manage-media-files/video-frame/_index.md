---
title: ビデオフレーム
type: docs
weight: 10
url: /ja/java/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにビデオフレームを追加"
---

プレゼンテーションでのビデオの適切な配置は、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法は2つあります：

* ローカルビデオを追加または埋め込む（あなたのマシンに保存されたもの）
* オンラインビデオを追加する（YouTubeなどのWebソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるようにするために、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)インターフェース、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)インターフェース、およびその他の関連タイプを提供しています。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオファイルパスを渡してプレゼンテーションにビデオを埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)オブジェクトを追加して、ビデオのフレームを作成します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```java
// Presentationクラスのインスタンスを生成
Presentation pres = new Presentation("pres.pptx");
try {
    // ビデオを読み込み
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

また、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)メソッドを使用して、ビデオのファイルパスを直接渡してビデオを追加することもできます：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Webソースのビデオを使用したビデオフレームの作成**

Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーション内でYouTubeビデオをサポートしています。使用したいビデオがオンラインで利用可能（例：YouTube上）な場合、そのWebリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このJavaコードは、Webからビデオをスライドに追加する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトを生成 
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

    // サムネイルを読み込み
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

## **スライドからビデオを抽出**

スライドにビデオを追加することに加えて、Aspose.Slidesではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)オブジェクトを反復処理します。
3. [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)オブジェクトをすべて反復処理して、[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

このJavaコードは、プレゼンテーションスライド上のビデオを抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトを生成 
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

                // ファイル拡張子を取得
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