---
title: JavaScript を使用したプレゼンテーションでのビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js（Java）を使用して、PowerPoint と OpenDocument のスライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。迅速なハウツーガイド。"
---
## **導入**

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、観客とのエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオを追加または埋め込む（マシンに保存されている）
* オンラインビデオを追加する（YouTube などのウェブソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) クラス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/) オブジェクトを追加し、ビデオファイルパスを渡してプレゼンテーションにビデオを埋め込みます。
4. ビデオのフレームを作成するために [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを追加します。
5. 変更されたプレゼンテーションを保存します。

この JavaScript コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。

```javascript
// プレゼンテーション クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ビデオを読み込む
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 最初のスライドを取得し、ビデオフレームを追加
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // プレゼンテーションをディスクに保存
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

あるいは、ファイルパスを直接 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) メソッドに渡してビデオを追加することもできます。

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

Microsoft の [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で利用可能な場合、その Web リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/) オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオフレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この JavaScript コードは、Web からビデオを取得し PowerPoint のスライドに追加する方法を示しています。

```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
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

## **ビデオフレームのトリミング**

Aspose.Slides では、[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/settrimfromstart/) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/settrimfromend/) を使用して trim‑from‑start および trim‑from‑end の値を設定することで、ビデオの再生部分を制御できます。両方の値はミリ秒で指定され、ビデオの開始部と終了部からそれぞれどれだけ時間をスキップするかを定義します。これらの設定はプレゼンテーション内のビデオ再生設定を変更しますが、埋め込まれたビデオのバイナリデータを切断したり変更したりはしません。

**トリム設定**

ビデオフレームを作成し、トリム設定を行うには：

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションに [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/) オブジェクトを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/settrimfromstart/) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/settrimfromend/) を使用して trim‑from‑start および trim‑from‑end の値を設定します。
5. 変更されたプレゼンテーションを保存します。

以下のコード例は、埋め込みビデオの再生時に最初の 2.5 秒と最後の 1 秒をスキップします。

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**トリム設定の取得**

既存のトリム設定を確認するには、プレゼンテーションをロードし、最初のスライドのシェイプの中から [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを見つけ、[VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) と [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/gettrimfromend/) で値を取得します。

以下のコード例は、最初のスライド上の最初のビデオフレームを見つけ、ミリ秒単位でそのトリム設定を報告します。

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **ビデオキャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションのビデオフレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオフレームにキャプションを追加**

ビデオフレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションにビデオを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) コレクションを使用して WebVTT キャプショントラックを追加します。
5. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームにキャプションを追加する方法を示しています。

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT ファイルから新しいキャプショントラックを追加します。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できる [addFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#addFromStream) メソッドも提供します。

**ビデオフレームからキャプションを抽出**

ビデオフレームからキャプションを抽出するには：

1. ビデオが含まれるプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを見つけます。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) コレクションを反復処理します。
4. 各キャプショントラックを `.vtt` ファイルに保存します。

以下のコードは、ビデオフレームからキャプションを抽出する方法を示しています。

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // キャプショントラックを WebVTT ファイルに保存します。
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

各 [Captions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、および UTF‑8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除**

ビデオフレームからキャプションを削除するには：

1. ビデオが含まれるプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトを取得します。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) コレクションからキャプショントラックを削除します。
4. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています。

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // タイプ: com.aspose.slides.VideoFrame

    // ビデオフレームからすべてのキャプションを削除します。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#removeAt) メソッドを使用します。

## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/) オブジェクトを反復処理します。
3. すべての [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) オブジェクトを反復処理して、[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この JavaScript コードは、プレゼンテーションスライド上のビデオを抽出する方法を示しています。

```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
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

## **よくある質問**

**VideoFrame のビデオ再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/setplayloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX のファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプの形状を保持したままビデオを置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/getcontenttype/) があり、たとえばディスクに保存するときなどに読み取って利用できます。