---
title: Android のプレゼンテーションでビデオフレームを管理する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/androidjava/video-frame/
keywords:
- ビデオの追加
- ビデオの作成
- ビデオの埋め込み
- ビデオの抽出
- ビデオの取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Aspose.Slides for Android で PowerPoint および OpenDocument スライドにビデオフレームをプログラムで追加・抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

プレゼンテーションに適切に配置された動画は、メッセージをより説得力のあるものにし、オーディエンスとのエンゲージメントレベルを高めます。

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります：

* ローカル動画（コンピューターに保存されている）を追加または埋め込む
* オンライン動画（YouTube などのウェブソースから）を追加する

Aspose.Slides は、プレゼンテーションに動画（ビデオオブジェクト）を追加できるように、[IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) インターフェイス、その他関連型を提供します。

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、動画フレームを作成してプレゼンテーションに埋め込むことができます。

1. [Presentation ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/) オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに動画を埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) オブジェクトを追加して動画のフレームを作成します。
1. 変更したプレゼンテーションを保存します。

以下の Java コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示しています：

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

あるいは、[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) メソッドにファイルパスを直接渡すことで動画を追加することもできます：

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

Microsoft PowerPoint の新しいバージョンでは、プレゼンテーションにオンライン動画をサポートしています。使用したい動画がオンライン（例: YouTube）にある場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/) オブジェクトを追加し、動画へのリンクを渡します。
1. 動画フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、ウェブ上の動画を PowerPoint プレゼンテーションのスライドに追加する方法を示しています：

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

## **動画フレームのトリミング**

Aspose.Slides では、[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) と [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用して、開始位置と終了位置のトリム値をミリ秒単位で設定することで、再生する動画の部分を制御できます。これらの設定はプレゼンテーション内の動画再生設定を変更しますが、埋め込まれた動画のバイナリデータをカットしたり変更したりはしません。

**トリム設定の設定**

動画フレームを作成し、トリム設定を行う手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideo/) オブジェクトをプレゼンテーションに追加します。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) オブジェクトをスライドに追加します。
1. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) と [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用して、開始トリムと終了トリムの値を設定します。
1. 変更したプレゼンテーションを保存します。

以下のコード例は、埋め込まれた動画の最初の 2.5 秒と最後の 1 秒を再生時にスキップします：

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

既存のトリム設定を確認するには、プレゼンテーションをロードし、最初のスライド上のシェイプの中から [IVideoFrame] オブジェクトを見つけ、[IVideoFrame.getTrimFromStart] と [IVideoFrame.getTrimFromEnd] を使って値を取得します。

以下のコード例は、最初のスライドにある最初の動画フレームを見つけ、そのトリム設定（ミリ秒）を出力します：

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

Aspose.Slides は、PowerPoint プレゼンテーションの動画フレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。

**動画フレームにキャプションを追加する**

動画フレームにキャプションを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに動画を追加します。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) オブジェクトをスライドに追加します。
1. [getCaptionTracks] が返す [ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/) を使用して、WebVTT キャプショントラックを追加します。
1. 変更したプレゼンテーションを保存します。

以下のコードは、動画フレームにキャプションを追加する方法を示しています：

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

[ICaptionsCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供しています。

**動画フレームからキャプションを抽出する**

動画フレームからキャプションを抽出する手順は次のとおりです。

1. 動画を含むプレゼンテーションをロードします。
1. 対象の [IVideoFrame] オブジェクトを見つけます。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) が返すキャプショントラックを列挙します。
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、動画フレームからキャプションを抽出する方法を示しています：

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

各 [ICaptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icaptions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、そして UTF-8 文字列としてのキャプションデータを提供します。

**動画フレームからキャプションを削除する**

動画フレームからキャプションを削除する手順は次のとおりです。

1. 動画を含むプレゼンテーションをロードします。
1. 対象の [IVideoFrame] オブジェクトを取得します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) が返すコレクションからキャプショントラックを削除します。
1. 変更したプレゼンテーションを保存します。

以下のコードは、動画フレームからすべてのキャプションを削除する方法を示しています：

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

1 つだけキャプショントラックを削除したい場合は、[clear] の代わりに [remove] または [removeAt] メソッドを使用してください。

## **スライドから動画を抽出する**

動画をスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、動画を含むプレゼンテーションをロードします。
2. すべての [ISlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) オブジェクトを列挙します。
3. すべての [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/) を探します。
4. 動画をディスクに保存します。

以下の Java コードは、プレゼンテーションのスライド上の動画を抽出する方法を示しています：

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

## **よくある質問**

**VideoFrame の再生パラメーターで変更できる項目は何ですか？**

[VideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/) オブジェクトのプロパティを使用して、再生モード（自動またはクリック時）やループ設定を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/) の [setPlayMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) と [setPlayLoopMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) で利用できます。

**動画を追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、ファイルサイズは動画のサイズに比例して増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame の動画を位置やサイズを変えずに差し替えることはできますか？**

はい。フレーム内の動画コンテンツを [setEmbeddedVideo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) で置き換えることで、シェイプの位置やサイズを維持したまま動画を差し替えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれた動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれた動画は [content type](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/video/#getContentType--) を持ち、取得して使用することができます。たとえば、ディスクに保存する際に利用できます。