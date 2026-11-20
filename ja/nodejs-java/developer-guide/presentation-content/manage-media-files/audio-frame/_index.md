---
title: "JavaScript を使用してプレゼンテーションでオーディオフレームを管理する"
linktitle: "オーディオフレーム"
type: docs
weight: 10
url: /ja/nodejs-java/audio-frame/
keywords:
- "オーディオ"
- "オーディオフレーム"
- "サムネイル"
- "オーディオ追加"
- "オーディオプロパティ"
- "オーディオオプション"
- "オーディオ抽出"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を使用して、スライドにオーディオを埋め込み、オーディオアイコンを変更し、再生を構成し、WebVTT キャプションを管理し、スライド遷移のサウンドを抽出します。"
---
## **概要**

オーディオフレームを使用すると、スライド上でサウンドを再生できます。Aspose.Slides for Node.js via Java を使用すると、オーディオクリップを埋め込み、それを表す画像を選択し、再生を調整し、キャプションを添付できます。また、スライド遷移に割り当てられたサウンドを取得することもできます。

## **オーディオフレームの作成**

最初のスライドにローカルオーディオクリップを埋め込むには、[addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) を使用します。最初の 2 つの座標はフレームの位置をスライド上で指定し、次の 2 つの値は幅と高さをポイント単位で設定します。この例では、クリップを自動的に開始するために [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) を呼び出し、音量の大きいプリセットを選択するために [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) を呼び出します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オーディオフレームのサムネイル変更**

デフォルトでは、オーディオフレームはスピーカーアイコンを表示します。カスタムサムネイルを表示するには、[addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) でプレゼンテーションに画像を追加し、[setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) でフレームの画像として設定します。この例では、埋め込みオーディオクリップのサムネイルとして `eagle.jpeg` を使用しています。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オーディオ再生オプションの変更**

PowerPoint の **Audio Options** コントロールは、クリップの開始タイミング、音量、スライドショー中の動作を決定します。

![オーディオフレーム用 PowerPoint Audio Options コントロール](audio_frame_0.png)

| PowerPoint コントロール | Aspose.Slides for Node.js via Java メソッド |
| --- | --- |
| 開始 | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| 音量プリセット | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| スライドをまたいで再生 | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| 停止までループ | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| ショー中に非表示 | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| 再生後に巻き戻し | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| フェードイン | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| フェードアウト | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| オーディオ開始時刻のトリム | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| オーディオ終了時刻のトリム | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量スライダー | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

この例では、最初のスライド上の最初のオーディオフレームを検索し、クリック時に再生を開始するために [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) を呼び出し、低音量プリセットを選択します。ループを無効にした状態でクリップはスライドをまたいで再生されます。ショー中はアイコンが非表示になり、再生後にクリップが巻き戻されます。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

3.5 秒より長いクリップの場合、この例は最初の 1.5 秒と最後の 2 秒をスキップします。[setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) はクリップの末尾から除外する期間を指定します。PowerPoint に表示される終了時刻を取得するには、全体のクリップ長さからこのオフセットを引きます。トリムされたクリップは 200 ミリ秒でフェードインし、500 ミリ秒でフェードアウトします。4 つのメソッドはすべてミリ秒単位の値を受け取ります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

再生音量を特定のパーセンテージに設定するには、[setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) を使用します。この例では、最初のスライド上の最初のオーディオフレームを 85% に設定しています。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **オーディオキャプションの管理**

各オーディオフレームは [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) を介してキャプショントラックへのアクセスを提供します。コレクションを使用して WebVTT キャプションをクリップに添付したり、既存のトラックをエクスポートしたり、削除したりできます。

### **オーディオキャプションの追加**

この例では、最初のスライドにオーディオクリップを埋め込み、[add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) を使用してローカル WebVTT トラックを添付します。最初の引数はトラックラベルを指定し、2 番目の引数はタイムコード付きキャプションが含まれるファイルを指定します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **オーディオキャプションの抽出**

この例では、最初のスライド上のオーディオフレームに添付された各キャプショントラックをエクスポートします。[getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) が返すバイト列を WebVTT ファイルに書き込み、[getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) が返す識別子をファイル名として使用することで、各トラックが個別の出力になります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **オーディオキャプションの削除**

[remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) を使用して個々のトラックを削除できます。この例では、[clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) を使用して、クリップを保持したまま最初のスライド上の最初のオーディオフレームからすべてのキャプションを削除します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **オーディオキャプション内の行を検索**

最初のスライド上のオーディオキャプション内の行を検索するには、メモリ内の [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) が返すテキストを検索します。プレーンテキストの WebVTT キューでは、タイミング行に `-->` が含まれ、キャプション行がそれに続き、空行でキューが終了します。この例では、トラックラベルと “café” を含む各キャプション行を出力します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **オーディオの抽出**

スライド遷移には独自のサウンドを設定できる場合があります。それを取得するには、スライド遷移で [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) を呼び出します。この例では、[getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) が返すバイト数にアクセスし、バイト数を出力します。最初のスライドに遷移サウンドがない場合は、代わりにメッセージを出力します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**同じオーディオクリップを複数のスライドで再利用し、重複させずに使用できますか？**

はい。プレゼンテーションの [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) にクリップを一度追加し、各スライドで同じオーディオオブジェクトを [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) に渡すだけです。

**既存のオーディオフレームのサウンドを置き換えることはできますか？**

はい。リンクされたサウンドの場合は、置換ファイルを指すように [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) を使用します。埋め込みサウンドの場合は、[setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) を使用してプレゼンテーションのオーディオコレクションから別のクリップを選択します。どちらの方法でも既存のフレームは保持されます。

**トリミングはプレゼンテーションに保存されているオーディオデータを変更しますか？**

いいえ。[setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) と [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) は再生範囲を設定するだけです。[getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) からは依然としてフルクリップを取得できます。