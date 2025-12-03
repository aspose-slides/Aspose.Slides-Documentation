---
title: Java を使用したプレゼンテーションでのビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションにうまく配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。  

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) インターフェイス、その他の関連タイプを提供します。  

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
4. ビデオのフレームを作成するために [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) オブジェクトを追加します。
5. 変更されたプレゼンテーションを保存します。

この Java コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("pres.pptx");
try {
    // ビデオを読み込む
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


あるいは、ファイルパスを直接 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドに渡すことでビデオを追加できます。
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web ソースからのビデオを使用したビデオフレームの作成**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で入手可能な場合、その Web リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオフレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この Java コードは、Web からビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
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


## **スライドからビデオを抽出**

スライドにビデオを追加することに加えて、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. すべての [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) オブジェクトを反復処理します。
3. すべての [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この Java コードは、プレゼンテーションのスライド上のビデオを抽出する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
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


## **FAQ**

**VideoFrame の再生パラメータで変更できるものはどれですか？**

再生モード（[playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)）と [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) オブジェクトのプロパティで利用できます。

**ビデオを追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを位置やサイズを変えずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることで、シェイプの形状を維持したままビデオを変更できます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) があり、ディスクに保存する際などに読み取って利用できます。