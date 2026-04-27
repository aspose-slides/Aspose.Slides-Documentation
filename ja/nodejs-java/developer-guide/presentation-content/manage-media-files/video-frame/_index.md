---
title: プレゼンテーションでのビデオフレームの管理（JavaScript 使用）
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
description: "Aspose.Slides for Node.js を Java で使用し、PowerPoint および OpenDocument のスライドでビデオフレームをプログラムで追加および抽出する方法を学べる、迅速なハウツーガイド。"
---
プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、視聴者とのエンゲージメントレベルを向上させることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります：
* ローカル ビデオを追加または埋め込む（マシンに保存）
* オンライン ビデオを追加する（YouTube などのウェブ ソースから）。

プレゼンテーションにビデオ（ビデオ オブジェクト）を追加できるように、Aspose.Slides は[Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/)クラス、[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)クラス、その他の関連型を提供しています。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオ フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/)オブジェクトを追加し、ビデオ ファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
4. [VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)オブジェクトを追加してビデオ用のフレームを作成します。
5. 変更されたプレゼンテーションを保存します。

この JavaScript コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ビデオを読み込みます
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

あるいは、ファイル パスを直接[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-)メソッドに渡してビデオを追加できます：

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

## **Web ソースからのビデオを使用したビデオ フレームの作成**

Microsoft PowerPoint 2013 以降は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）にある場合、そのウェブ リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/video/)オブジェクトを追加し、ビデオへのリンクを渡します。
4. ビデオ フレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この JavaScript コードは、Web からビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています：

```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトのインスタンスを作成します
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

## **ビデオ キャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションのビデオ フレームに対してクローズド キャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)メソッドで取得できます。

**ビデオ フレームにキャプションを追加する**

ビデオ フレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. プレゼンテーションにビデオを追加します。
3. スライドに[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)オブジェクトを追加します。
4. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/)コレクションを使用して WebVTT キャプショントラックを追加します。
5. 変更されたプレゼンテーションを保存します。

次のコードは、ビデオ フレームにキャプションを追加する方法を示しています：

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

[CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/)クラスは、ストリームからキャプションを追加できる[addFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#addFromStream)メソッドも提供しています。

**ビデオ フレームからキャプションを抽出する**

ビデオ フレームからキャプションを抽出するには：

1. ビデオを含むプレゼンテーションをロードします。
2. 対象の[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)オブジェクトを見つけます。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/)コレクションを列挙します。
4. 各キャプショントラックを`.vtt`ファイルに保存します。

次のコードは、ビデオ フレームからキャプションを抽出する方法を示しています：

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

各[Captions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captions/)オブジェクトは、キャプション識別子、ラベル、バイナリ データ、および UTF-8 文字列としてのキャプションテキストを提供します。

**ビデオ フレームからキャプションを削除する**

ビデオ フレームからキャプションを削除するには：

1. ビデオを含むプレゼンテーションをロードします。
2. 対象の[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)オブジェクトを取得します。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/)コレクションからキャプショントラックを削除します。
4. 変更されたプレゼンテーションを保存します。

次のコードは、ビデオ フレームからすべてのキャプションを削除する方法を示しています：

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // 型: com.aspose.slides.VideoFrame

    // ビデオフレームからすべてのキャプションを削除します。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つのキャプション トラックだけを削除する必要がある場合は、[clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#clear)の代わりに[remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#remove)または[removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#removeAt)メソッドを使用してください。

## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. すべての[Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/)オブジェクトを列挙します。
3. すべての[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/)オブジェクトを列挙して[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

この JavaScript コードは、プレゼンテーション スライドからビデオを抽出する方法を示しています：

```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトのインスタンスを作成します
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

**VideoFrame の再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）およびループ設定を制御できます。これらのオプションは VideoFrame オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは変わりますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに差し替えることはできますか？**

はい。フレーム内のビデオ コンテンツを置き換えても、シェイプの形状は保持されます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオにはコンテンツタイプがあり、取得して使用できます。たとえばディスクに保存する際などに利用できます。