---
title: Android でプレゼンテーションの動画フレームを管理する
linktitle: 動画フレーム
type: docs
weight: 10
url: /ja/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、PowerPoint および OpenDocument スライドに動画フレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションに適切に配置された動画は、メッセージをより魅力的にし、オーディエンスとのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります。

* ローカル動画を追加または埋め込み（マシンに保存されている）
* Web ソース（YouTube など）からオンライン動画を追加。

プレゼンテーションに動画（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) インターフェイス、およびその他の関連タイプを提供します。

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、プレゼンテーションに動画を埋め込むための動画フレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) オブジェクトを追加し、動画ファイルのパスを指定してプレゼンテーションに動画を埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) オブジェクトを追加して、動画のフレームを作成します。
1. 変更されたプレゼンテーションを保存します。

この Java コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示します。
```java
// Presentation クラスのインスタンス化
Presentation pres = new Presentation("pres.pptx");
try {
    // 動画をロード
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


または、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドにファイルパスを直接渡すことで動画を追加できます。
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web ソースからの動画で動画フレームを作成**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube 動画をサポートしています。使用したい動画がオンラインで利用可能（例: YouTube）な場合、そのウェブリンクを通じてプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) オブジェクトを追加し、動画へのリンクを渡します。
1. 動画フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この Java コードは、Web から動画を取得して PowerPoint プレゼンテーションのスライドに追加する方法を示します。
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

    // サムネイルを読み込む
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


## **スライドから動画を抽出**

スライドに動画を追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

1. 動画が含まれるプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. すべての [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) オブジェクトを列挙します。
3. すべての [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) オブジェクトを列挙して、[VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) を見つけます。
4. 動画をディスクに保存します。

この Java コードは、プレゼンテーションのスライドから動画を抽出する方法を示します。
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


## **FAQ**

**VideoFrame の再生パラメータで変更できる項目は何ですか？**

[playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック時）と[looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**動画を追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカル動画を埋め込むと、バイナリデータが文書に含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame の動画を位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることで、シェイプの形状を保持したまま置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込み動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込み動画には[content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) があり、例えばディスクに保存する際などに読み取って使用できます。