---
title: ビデオフレーム
type: docs
weight: 10
url: /androidjava/video-frame/
keywords: "ビデオの追加、ビデオフレームの作成、ビデオの抽出、PowerPointプレゼンテーション、Java、Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにビデオフレームを追加する"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより魅力的にし、オーディエンスとのエンゲージメントを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります：

* ローカルビデオ（あなたのマシンに保存されているもの）を追加または埋め込む
* オンラインビデオ（YouTubeなどのウェブソースから）を追加する。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加するには、Aspose.Slidesが[IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)インターフェース、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)インターフェース、およびその他の関連タイプを提供しています。

## **埋め込みビデオフレームの作成**

追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成することができます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。 
1. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、プレゼンテーションにビデオを埋め込むためにビデオファイルのパスを渡します。
1. ビデオのためのフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを追加します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```java
// Presentationクラスをインスタンス化
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

また、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)メソッドにビデオファイルのパスを直接渡すことで、ビデオを追加することもできます：

```java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **ウェブソースからのビデオフレームの作成**

Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)はプレゼンテーションでYouTubeビデオをサポートしています。使用したいビデオがオンライン（例えばYouTubeで）で利用できる場合、そのウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。 
1. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。 
1. プレゼンテーションを保存します。

このJavaコードは、PowerPointプレゼンテーションのスライドにウェブからビデオを追加する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化 
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

## **スライドからのビデオの抽出**

スライドにビデオを追加する以外に、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)オブジェクトを反復処理して[VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

このJavaコードは、プレゼンテーションスライド上のビデオを抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化 
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