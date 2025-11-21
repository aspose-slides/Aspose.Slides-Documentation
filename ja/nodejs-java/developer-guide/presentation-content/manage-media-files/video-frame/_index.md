---
title: ビデオフレーム
type: docs
weight: 10
url: /ja/nodejs-java/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint プレゼンテーションにビデオフレームを追加"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります。

* ローカルビデオを追加または埋め込み（マシンに保存）
* オンラインビデオを追加（YouTubeなどのウェブソースから）。

プレゼンテーションにビデオ（video objects）を追加できるように、Aspose.Slidesは[Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)クラス、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)クラス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) オブジェクトを追加し、ビデオファイルパスを渡してプレゼンテーションにビデオを埋め込みます。
1. [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) オブジェクトを追加してビデオのフレームを作成します。
1. 変更されたプレゼンテーションを保存します。

このJavaScriptコードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示します。
```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ビデオをロードします
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 最初のスライドを取得し、ビデオフレームを追加します
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // プレゼンテーションをディスクに保存します
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


あるいは、ファイルパスを直接 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) メソッドに渡すことでビデオを追加できます：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の[PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例：YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このJavaScriptコードは、Web からのビデオを PowerPoint のスライドに追加する方法を示します：
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```


## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオが含まれるプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. すべての[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) オブジェクトを反復処理します。
3. すべての[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

このJavaScriptコードは、プレゼンテーションスライド上のビデオを抽出する方法を示します：
```javascript
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // ファイル拡張子を取得します
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**VideoFrame の再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動またはクリック時）と[looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) を制御できます。これらのオプションは[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオの追加は PPTX ファイルサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズの増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したまま置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込みビデオには[content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) があり、これを読み取って使用できます。たとえばディスクに保存する際などに利用できます。