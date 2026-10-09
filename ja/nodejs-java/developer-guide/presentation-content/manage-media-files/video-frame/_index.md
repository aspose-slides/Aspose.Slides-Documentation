---
title: Node.js を使用したプレゼンテーションのビデオフレーム管理
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
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のスライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。短時間で読めるハウツーガイドです。"
---
## **はじめに**

動画は、アイデアの説明やオーディエンスの関心を引くのに役立ちます。Aspose.Slides for Node.js via Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートしています。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) クラス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例では、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。保存が完了するまでストリームは開いたままになります。これは、[LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) がプレゼンテーションで使用されている間ストリームをロックしたままにするためです。

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

ローカルビデオのパスを直接 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) に渡すこともできます。この例では、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。プレゼンテーションが保存されるまでビデオはアクセス可能な状態である必要があります。

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

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーション内のオンラインビデオをサポートしています。YouTube ビデオなど、オンラインビデオへのリンクを持つビデオフレームを作成できます。

この例では、YouTube ビデオのリンクとサムネイルを最初のスライドに追加します。別のビデオを使用するには、ビデオ識別子を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) メソッドは自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアーもオンラインビデオの再生をサポートしている必要があります。

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

## **フルスクリーンモードでビデオを再生**

トレーニング用のプレゼンテーションでは、ソフトウェアデモをフルスクリーンモードで再生して、視聴者に詳細を見せることができます。再生中にこの動作を有効にするには、`true` を指定して [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) を呼び出します。

この例では、プレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) を検索し、フルスクリーン再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

フルスクリーン再生はビデオの表示方法を制御します。個別に、[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) は自動再生またはクリック時再生のどちらかを制御し、[setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) は繰り返しの有無を制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto または VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) に設定します。この例は既存の開始設定とループ設定を保持します。

## **再生後にビデオを巻き戻す**

再生が終了した後にビデオを開始位置に戻すには、`true` を指定して [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) を呼び出します。

この例では、プレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) を検索し、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリック時開始に設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

巻き戻しはビデオを再び開始せずに開始位置に戻します。対照的に、[setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) に `true` を指定すると再生が自動的に繰り返されます。ビデオを終了させて再生可能な状態に保ちたい場合は、ループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) は自動開始またはクリック開始を個別に制御します。この例では、プレゼンターが再生開始を制御できるように [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) を使用しています。ループ設定の後に再生モードを設定します（例を参照）。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) とは独立して動作します。

## **ビデオフレームをトリミング**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) を使用して、再生時にビデオの冒頭または末尾の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定の設定**

この例では、ローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒以上の長さのビデオを使用してください。

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

**トリム設定の読み取り**

この例では、最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションには少なくとも1つのスライドが必要です。そのスライドにビデオフレームがない場合、何も出力されません。前の例では 2500 と 1000 の値が生成されます。

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

Aspose.Slides を使用すると、PowerPoint プレゼンテーションのビデオフレームに対してクローズドキャプションを管理できます。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオフレームにキャプションを追加**

この例では、ローカルビデオを埋め込み、English とラベル付けされた WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオに合わせる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

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

**ビデオフレームからキャプションを抽出**

この例では、最初のスライド上のビデオフレームからすべてのキャプショントラックを別々の WebVTT ファイルとして保存します。連番により出力ファイルが区別されます。コンソールには抽出されたトラック数が表示されます。プレゼンテーションには少なくとも1つのスライドが必要です。

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

各 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除**

この例では、最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

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

単一のキャプショントラックのみを削除したい場合は、[clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides を使用すると、プレゼンテーションに埋め込まれたビデオを抽出できます。

この例では、各スライドから埋め込みビデオを別々の番号付きバイナリファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールには各ビデオの MIME タイプと総数が出力されます。出力は汎用的な `.bin` 拡張子を使用します。必要に応じて、報告されたメディアタイプに合わせて拡張子を変更してください。

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

**ビデオフレームの再生パラメータで変更できるものはどれですか？**

[playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオへのリンクとサムネイルを追加する場合、プレゼンテーションはビデオデータではなくリンクとプレビュー画像を保存するため、サイズ増加は通常小さくなります。

**既存のビデオフレームのビデオを位置やサイズを変えずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) を入れ替えることで、シェイプの形状を保持したままビデオを置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）は判別できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) があり、これを読み取って使用できます。たとえばディスクに保存する際などに利用できます。