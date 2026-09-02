---
title: Java を使用したプレゼンテーションの動画フレーム管理
linktitle: 動画フレーム
type: docs
weight: 10
url: /ja/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のスライドに動画フレームをプログラムで追加および抽出する方法を学びます。迅速なハウツーガイド。"
---
## **はじめに**

プレゼンテーションで適切に配置された動画は、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。  

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります。

* ローカル動画（マシンに保存されている）を追加または埋め込む
* オンライン動画（YouTube などのウェブソースから）を追加する。

プレゼンテーションに動画（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/) インターフェイス、およびその他の関連タイプを提供します。 

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、動画フレームを作成してプレゼンテーションに動画を埋め込むことができます。 

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. IVideo オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに動画を埋め込みます。  
1. IVideoFrame オブジェクトを追加して、動画のフレームを作成します。  
1. 変更したプレゼンテーションを保存します。  

この Java コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示しています：

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("pres.pptx");
try {
    // 動画を読み込みます
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

あるいは、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドにファイルパスを直接渡すことで動画を追加できます：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Web ソースからの動画で動画フレームを作成する**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube 動画をサポートしています。使用したい動画がオンライン（例：YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。 

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. IVideo オブジェクトを追加し、動画へのリンクを渡します。  
1. 動画フレームのサムネイルを設定します。  
1. プレゼンテーションを保存します。  

この Java コードは、ウェブ上の動画を PowerPoint プレゼンテーションのスライドに追加する方法を示しています：

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
    // 動画フレームを追加します
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

## **動画フレームのトリミング**

Aspose.Slides では、[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) および [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用して trim-from-start と trim-from-end の値を設定することで、動画の再生部分を制御できます。これらの値はミリ秒単位で指定され、動画の開始部と終了部からそれぞれスキップされる時間を定義します。この設定はプレゼンテーション内の動画再生設定を変更しますが、埋め込まれた動画のバイナリデータを切り取ったり変更したりするものではありません。

**トリム設定の設定**

動画フレームを作成し、トリム設定を行うには：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. プレゼンテーションに IVideo オブジェクトを追加します。  
1. スライドに IVideoFrame オブジェクトを追加します。  
1. IVideoFrame.setTrimFromStart と IVideoFrame.setTrimFromEnd を使用して trim-from-start と trim-from-end の値を設定します。  
1. 変更したプレゼンテーションを保存します。  

以下のコード例は、埋め込み動画の再生時に最初の 2.5 秒と最後の 1 秒をスキップします：

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**トリム設定の取得**

既存のトリム設定を確認するには、プレゼンテーションを読み込み、最初のスライドのシェイプの中から IVideoFrame オブジェクトを見つけ、[IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) と [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) を使用して値を取得します。  

以下のコード例は、最初のスライド上の最初の動画フレームを見つけ、そのトリム設定をミリ秒単位で報告します：

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **動画キャプションの管理**

Aspose.Slides では、PowerPoint プレゼンテーションの動画フレームに対してクローズドキャプションを管理できます。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。  

**動画フレームへのキャプションの追加**

動画フレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. プレゼンテーションに動画を追加します。  
1. スライドに IVideoFrame オブジェクトを追加します。  
1. getCaptionTracks が返す [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) を使用して、WebVTT キャプショントラックを追加します。  
1. 変更したプレゼンテーションを保存します。  

以下のコードは、動画フレームにキャプションを追加する方法を示しています：

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

**動画フレームからのキャプションの抽出**

動画フレームからキャプションを抽出するには：

1. 動画を含むプレゼンテーションを読み込みます。  
2. 対象の IVideoFrame オブジェクトを見つけます。  
3. [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) のキャプショントラックを反復処理します。  
4. 各キャプショントラックを `.vtt` ファイルに保存します。  

以下のコードは、動画フレームからキャプションを抽出する方法を示しています：

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

各 [ICaptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、そして UTF-8 文字列としてのキャプションテキストを提供します。  

**動画フレームからのキャプション削除**

動画フレームからキャプションを削除するには：

1. 動画を含むプレゼンテーションを読み込みます。  
2. 対象の IVideoFrame オブジェクトを取得します。  
3. [ICaptionsCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icaptionscollection/) からキャプショントラックを削除します。  
4. 変更したプレゼンテーションを保存します。  

以下のコードは、動画フレームからすべてのキャプションを削除する方法を示しています：

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

## **スライドからの動画抽出**

スライドに動画を追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれた動画を抽出することもできます。  

1. 動画を含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) オブジェクトを反復処理します。  
3. すべての [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/) を見つけます。  
4. 動画をディスクに保存します。  

この Java コードは、プレゼンテーションのスライド上の動画を抽出する方法を示しています：

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

### **VideoFrame の再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。  

### **動画を追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。  

### **既存の VideoFrame の動画を位置やサイズを変えずに置き換えることはできますか？**

はい。シェイプのジオメトリを保持したまま、フレーム内の [video content](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。  

### **埋め込まれた動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれた動画には読み取って使用できる [content type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/video/#getContentType--) があり、例えばディスクに保存する際に利用できます。