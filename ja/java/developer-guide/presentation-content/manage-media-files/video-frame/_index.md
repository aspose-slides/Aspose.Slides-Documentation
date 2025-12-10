---
title: Java を使用したプレゼンテーションでのビデオフレームの管理
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
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument スライドにビデオフレームをプログラム的に追加および抽出する方法を学びます。迅速なハウツーガイドです。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります:

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などのウェブソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) インターフェイス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。  
1. [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) オブジェクトを追加してビデオ用のフレームを作成します。  
1. 変更したプレゼンテーションを保存します。  

この Java コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("pres.pptx");
try {
    // ビデオをロードします
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 最初のスライドを取得し、ビデオフレームを追加します
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // プレゼンテーションをディスクに保存します
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


あるいは、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドにファイルパスを直接渡してビデオを追加することもできます:
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

Microsoft [PowerPoint 2013 とそれ以降のバージョン](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオの使用をサポートします。オンラインで利用可能なビデオ（例: YouTube）をプレゼンテーションに追加するには、Web リンクを使用します。

1. [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。  
1. ビデオフレームのサムネイルを設定します。  
1. プレゼンテーションを保存します。  

この Java コードは、Web からビデオを取得して PowerPoint スライドに追加する方法を示しています:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します 
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
    // ビデオフレームを追加します
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // サムネイルをロードします
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

ビデオをスライドに追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオが含まれるプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) オブジェクトを列挙します。  
3. すべての [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) を見つけます。  
4. ビデオをディスクに保存します。  

この Java コードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています:
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

                //ファイル拡張子を取得します
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

**VideoFrame の再生パラメータで変更できるものは何ですか？**

[再生モード](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック時）と [ループ設定](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、ファイルサイズはビデオのサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [ビデオコンテンツ](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を差し替えることで、形状のジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込まれたビデオには [コンテンツタイプ](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) があり、取得して使用することができます。