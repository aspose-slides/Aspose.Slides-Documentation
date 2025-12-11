---
title: Android でプレゼンテーションのビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/androidjava/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Aspose.Slides for Android で PowerPoint および OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより魅力的にし、オーディエンスとのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が2つあります：

* ローカルビデオ（マシンに保存されている）を追加または埋め込む
* オンラインビデオ（YouTube などのウェブソースから）を追加する

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は[IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)インターフェイス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
4. [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)オブジェクトを追加して、ビデオ用のフレームを作成します。
5. 変更されたプレゼンテーションを保存します。

この Java コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています:
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


または、ファイルパスを直接[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)メソッドに渡すことでビデオを追加できます:
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web ソースからのビデオでビデオフレームを作成**

Microsoft[PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で利用できる場合、そのウェブリンクを使用してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオフレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この Java コードは、ウェブからビデオを取得して PowerPoint のスライドに追加する方法を示しています:
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


## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成して、ビデオを含むプレゼンテーションをロードします。
2. すべての[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)オブジェクトを列挙します。
3. すべての[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)オブジェクトを列挙して、[VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)を見つけます。
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

**VideoFrame のビデオ再生パラメータで変更できる項目は何ですか？**

再生モード（自動またはクリック時）は[playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)で、ループ設定は[looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)で制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)を置き換えることで、シェイプのジオメトリを保持したままビデオを交換できます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込みビデオには[content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--)があり、これを取得して使用できます。たとえばディスクに保存する際に利用できます。