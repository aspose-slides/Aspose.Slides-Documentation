---
title: Node.js を使用したプレゼンテーションでのビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/nodejs-java/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込み
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
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のスライドでビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

動画はアイデアの説明や観客の関心を引くのに役立ちます。Aspose.Slides for Node.js via Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカル動画とオンライン動画へのリンク（たとえば YouTube 動画）をサポートしています。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) クラス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

この例は既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままになります。なぜなら [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) がプレゼンテーションが使用している間ロックされたままにするからです。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

ローカルビデオパスを直接 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) に渡すこともできます。この例は新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能である必要があります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Web ソースからのビデオでビデオフレームを作成する**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンライン動画をサポートしています。YouTube 動画などのオンライン動画へのリンクを持つビデオフレームを作成できます。

この例は YouTube 動画のリンクとサムネイルを最初のスライドに追加します。別の動画を使用する場合はビデオ識別子を置き換えてください。 [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) メソッドは自動再生を要求します。サムネイルのダウンロードと動画の再生にはインターネット接続が必要です。プレゼンテーションビューアもオンライン動画再生をサポートしている必要があります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **全画面モードでビデオを再生する**

トレーニング用プレゼンテーションでは、ソフトウェアのデモを全画面モードで再生して、観客に詳細を見せることができます。`true` を渡して [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) を呼び出すと、再生中にこの動作が有効になります。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) を見つけ、全画面再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

全画面再生はビデオの表示方法を制御します。別に、[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) は自動開始かクリック開始かを制御し、[setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) はループするかどうかを制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto または VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) に設定します。例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションで、デモ動画を最初に戻すことで、プレゼンターが再度再生できるようにします。`true` を渡して [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) を呼び出すと、再生が終了した後にビデオが最初に戻ります。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) を見つけ、巻き戻しを有効にします。ループは無効にして再生が終了できるようにし、クリックで開始するように再生モードを設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

巻き戻しはビデオを再度開始せずに最初に戻します。対照的に、`true` を渡して [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) を呼び出すと再生が自動的に繰り返されます。ビデオを最後まで再生させてから再度再生できるようにしたい場合は、ループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) は自動開始かクリック開始かを個別に制御します；この例ではプレゼンターが再生開始を制御できるように [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) を使用しています。ループ設定の後に再生モードを設定します（例参照）。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) とは独立して機能します。

## **ビデオフレームをトリミングする**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) を使用して、再生時にビデオの冒頭または末尾の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定の設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒以上の長さのビデオを使用してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**トリム設定の取得**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションには少なくとも1つのスライドが必要です。そのスライドにビデオフレームがない場合は何も出力されません。前の例は 2500 と 1000 の値を生成します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

### **ビデオフレームにキャプションを追加する**

この例はローカルビデオを埋め込み、English というラベルの WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオと一致させる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加するための [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) メソッドも提供します。

### **ビデオフレームからキャプションを抽出する**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番により出力ファイルが区別されます。コンソールは抽出されたトラック数を報告します。プレゼンテーションには少なくとも1つのスライドが必要です。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

各 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) オブジェクトはキャプション識別子、ラベル、バイナリ データ、UTF-8 文字列としてのキャプションテキストを公開します。

### **ビデオフレームからキャプションを削除する**

この例は最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つだけキャプショントラックを削除したい場合は、[clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

### **ビデオキャプションを検索する**

[Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) メソッドはヘッダー、タイミング行、キャプションテキストを含む完全な WebVTT トラックを返します。メモリ内のキャプションテキストを検索してフレーズとそのタイムスタンプを見つけることができます。たとえば、スライド 2 の英語トラックは次のようなキューを含む場合があります。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

この例は `captioned_media.pptx` を開き、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) を使用して各スライド上のすべてのトップレベルビデオフレームのトラックを読み取ります。プレーンテキストキューではタイミング行に `-->` が含まれ、空行でキューが終了します。キャプションテキストに大小文字を区別せずに “café” を含む場合、例はスライド番号、トラックラベル、元のタイミング行、完全なキャプションを出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

“café” の検索はサンプルトラックで 1 件ヒットします。検索はトラックヘッダーをスキップし、出力ではタイミング設定と改行を保持します。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することもできます。

この例はすべてのスライドから埋め込みビデオを個別の番号付きバイナリ ファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールは各ビデオの MIME タイプと合計数を出力します。出力は汎用的な `.bin` 拡張子を使用しますが、必要に応じて報告されたメディアタイプに合わせて変更してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ビデオフレームで変更できるビデオ再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動またはクリック）と [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) オブジェクトのメソッドを通じて利用できます。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオへのリンクとサムネイルを追加する場合、プレゼンテーションはビデオデータではなくリンクとプレビュー画像を保存するため、サイズ増加は通常小さくなります。

**既存のビデオフレームの位置とサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存のレイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込みビデオは [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) を持っており、これを読み取ってたとえばディスクに保存する際に使用できます。