---
title: "JavaScript を使用してプレゼンテーションのオーディオを管理"
linktitle: "オーディオ フレーム"
type: docs
weight: 10
url: /ja/nodejs-java/audio-frame/
keywords:
- "オーディオ"
- "オーディオ フレーム"
- "サムネイル"
- "オーディオの追加"
- "オーディオ プロパティ"
- "オーディオ オプション"
- "オーディオの抽出"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js でオーディオ フレームを作成・制御します—埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーションで行う例です。"
---
## **オーディオ フレームの作成**

Aspose.Slides for Node.js via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [AudioFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AudioFrame) オブジェクトで公開されている [PlayMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AudioPlayModePreset) と `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この JavaScript コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています:

```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
const pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    const sld = pres.getSlides().get_Item(0);
    // wav サウンド ファイルをストリームにロード
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // オーディオ フレームを追加
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // オーディオの再生モードと音量を設定
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // PowerPoint ファイルをディスクに書き込む
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **オーディオ フレーム サムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像が付いたフレームとして表示されます（以下の画像を参照）。オーディオ フレームのプレビュー画像（好みの画像）に変更できます。

この JavaScript コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // 指定された位置とサイズでスライドにオーディオ フレームを追加します。
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // プレゼンテーションのリソースに画像を追加します。
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // オーディオ フレームの画像を設定します。
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // 変更されたプレゼンテーションをディスクに保存します
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **オーディオ 再生オプションの変更**

Aspose.Slides for Node.js via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **オーディオ オプション** パネル:

![example1_image](audio_frame_0.png)

PowerPoint の **オーディオ オプション** は Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/) プロパティに対応しています:
- **Start** ドロップダウン リストは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setPlayMode) メソッドと一致します
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setVolume) メソッドと一致します
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドと一致します
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドと一致します
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) メソッドと一致します
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setRewindAudio) メソッドと一致します

PowerPoint の **編集** オプションは Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/) プロパティに対応しています:

- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) メソッドと一致します
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドと一致します
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) メソッドと一致します
- **Trim Audio End Time** の値は、オーディオの全体長から [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を差し引いたものに相当します

PowerPoint のオーディオ コントロール パネル上の **ボリューム コントロール** は [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応しており、パーセンテージで音量を変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです:

1. [Create](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この JavaScript コードは、オーディオのオプションを調整する操作を示しています:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 再生モードをクリック時に設定
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // 音量を Low に設定
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // オーディオをスライド全体で再生するよう設定
    audioFrame.setPlayAcrossSlides(true);
    // オーディオのループを無効化
    audioFrame.setPlayLoopMode(false);
    // スライドショー中に AudioFrame を非表示にする
    audioFrame.setHideAtShowing(true);
    // 再生後にオーディオを先頭に巻き戻す
    audioFrame.setRewindAudio(true);
    // PowerPoint ファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

この JavaScript の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングとフェード時間を設定する方法を示しています:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // トリミング開始オフセットを 1.5 秒に設定
    audioFrame.setTrimFromStart(1500);
    // トリミング終了オフセットを 2 秒に設定
    audioFrame.setTrimFromEnd(2000);

    // フェードイン時間を 200 ミリ秒に設定
    audioFrame.setFadeInDuration(200);
    // フェードアウト時間を 500 ミリ秒に設定
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // オーディオ フレーム シェイプを取得
    const audioFrame = slide.getShapes().get_Item(0);

    // オーディオの音量を 85% に設定
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **オーディオ キャプションの管理**

Aspose.Slides を使用すると、[getCaptionTracks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを通じてオーディオ フレームにクローズド キャプションを追加できます。このメソッドは [CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの反復、必要に応じた削除が可能です。

**オーディオ キャプションの追加**

[ getCaptionTracks](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用して、1 つまたは複数のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックを読み込みます。

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT ファイルから新しいキャプション トラックを追加。
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**オーディオ キャプションの抽出**

オーディオ フレームに関連付けられたキャプション トラックを反復処理し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと一意の識別子を公開しており、キャプションのエクスポート時に使用できます。

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // キャプション トラックを .vtt ファイルとして保存します。
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

**オーディオ キャプションの削除**

オーディオ フレームからキャプションを削除するには、[CaptionsCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/) が提供する [clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#remove)、または [removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/captionscollection/#removeAt) メソッドを使用します。以下の例は、オーディオ フレームからすべてのキャプション トラックを削除します。

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // 型: aspose.slides.AudioFrame

    // オーディオ フレームからすべてのキャプション トラックを削除します。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オーディオ の抽出**

Aspose.Slides for Node.js via Java を使用すると、スライド ショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスで対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) にアクセスします。
4. サウンドをバイト データとして抽出します。

この JavaScript コードは、スライドで使用されているオーディオを抽出する方法を示しています:

```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // 目的のスライドにアクセス
    const slide = pres.getSlides().get_Item(0);
    // スライドのスライドショー遷移エフェクトを取得
    const transition = slide.getSlideShowTransition();
    // サウンドをバイト配列として抽出
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増やさずにすみますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getaudios/) にオーディオを 1 回追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防がれ、プレゼンテーション サイズを抑制できます。

**既存のオーディオ フレームのサウンドをシェイプを作り直さずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) を新しいファイルに更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getaudios/) から別の埋め込みオーディオ オブジェクトに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎オーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。