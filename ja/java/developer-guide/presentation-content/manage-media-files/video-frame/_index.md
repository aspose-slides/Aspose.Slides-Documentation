---
title: Java を使用してプレゼンテーション内のビデオフレームを管理する
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
プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを向上させます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります:

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などの Web ソースから）

ビデオオブジェクトをプレゼンテーションに追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) インターフェイス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。  
1. [IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) オブジェクトを追加してビデオ用のフレームを作成します。  
1. 変更したプレゼンテーションを保存します。

この Java コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています:

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("pres.pptx");
try {
    // ビデオを読み込みます
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

あるいは、ビデオのファイル パスを直接 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドに渡すことでもビデオを追加できます:

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

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオの使用をサポートしています。オンライン上にビデオがある場合（例: YouTube）、そのウェブ リンクを使用してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。  
1. ビデオフレームのサムネイルを設定します。  
1. プレゼンテーションを保存します。

この Java コードは、Web からビデオを取得して PowerPoint のスライドに追加する方法を示しています:

```java
// プレゼンテーション ファイルを表す Presentation オブジェクトを生成します
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

    // サムネイルを読み込みます
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

## **ビデオキャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーション内のビデオフレームに対してクローズド キャプションを管理できる機能を提供します。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。

**ビデオフレームにキャプションを追加する**

ビデオフレームにキャプションを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. プレゼンテーションにビデオを追加します。  
1. スライドに [IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) オブジェクトを追加します。  
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) が返す [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) を使用して WebVTT キャプショントラックを追加します。  
1. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオフレームにキャプションを追加する方法を示しています:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

[ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出する**

ビデオフレームからキャプションを抽出する手順:

1. ビデオが含まれるプレゼンテーションを読み込みます。  
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) オブジェクトを見つけます。  
1. [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) 内のキャプショントラックを列挙します。  
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、ビデオフレームからキャプションを抽出する方法を示しています:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // キャプショントラックを WebVTT ファイルに保存します。
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

各 [ICaptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptions/) オブジェクトは、キャプション識別子、ラベル、バイナリ データ、および UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除する**

ビデオフレームからキャプションを削除する手順:

1. ビデオが含まれるプレゼンテーションを読み込みます。  
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) オブジェクトを取得します。  
1. [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) からキャプショントラックを削除します。  
1. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // ビデオフレームからすべてのキャプションを削除します。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#clear--) の代わりに [remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) または [removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/#removeAt-int-) メソッドを使用してください。

## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出する機能も提供します。

1. ビデオが含まれるプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) オブジェクトを走査します。  
3. すべての [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) オブジェクトを走査し、[VideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/) を見つけます。  
4. ビデオをディスクに保存します。

この Java コードは、プレゼンテーション スライドからビデオを抽出する方法を示しています:

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

                // ファイル拡張子を取得します
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

[playback mode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むとバイナリ データがドキュメントに含まれるため、ファイル サイズに比例してプレゼンテーションのサイズが増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、増加幅は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディア更新で一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには取得可能な [content type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/video/#getContentType--) があり、例えばディスクに保存する際に利用できます。