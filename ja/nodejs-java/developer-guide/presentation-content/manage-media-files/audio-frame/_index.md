---
title: JavaScript を使用したプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/nodejs-java/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオを追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオを抽出
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でオーディオ フレームを作成・制御します—埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーション全体で行う JavaScript のサンプルです。"
---

## **オーディオ フレームの作成**

Aspose.Slides for Node.js via Java を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 埋め込むオーディオ ファイルのストリームをロードします。  
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。  
5. [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame) オブジェクトが公開する [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) と `Volume` を設定します。  
6. 変更したプレゼンテーションを保存します。

この JavaScript コードは、スライドに埋め込みオーディオ フレームを追加する方法を示します:
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
const pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    const sld = pres.getSlides().get_Item(0);
    // wav サウンド ファイルをストリームに読み込む
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // オーディオ フレームを追加
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // オーディオの再生モードと音量を設定
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // PowerPoint ファイルを書き出す
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **オーディオ フレームのサムネイルを変更**

プレゼンテーションにオーディオ ファイルを追加すると、標準の既定画像を持つフレームとして表示されます（以下の画像参照）。オーディオ フレームのプレビュー画像（任意の画像）に変更できます。

この JavaScript コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します:
```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // 指定した位置とサイズでスライドにオーディオ フレームを追加します。
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
    // 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for Node.js via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) プロパティに対応します:
- **Start** ドロップダウンは [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) メソッドに一致  
- **Volume** は [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) メソッドに一致  
- **Play Across Slides** は [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに一致  
- **Loop until Stopped** は [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに一致  
- **Hide During Show** は [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに一致  
- **Rewind after Playing** は [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) メソッドに一致  

PowerPoint の **Editing** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) プロパティに対応します:
- **Fade In** は [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに一致  
- **Fade Out** は [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに一致  
- **Trim Audio Start Time** は [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに一致  
- **Trim Audio End Time** の値はオーディオの長さから [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を引いたものに等しい  

音量コントロール パネルの PowerPoint **Volume controll** は [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応し、パーセンテージで音量を変更できます。

オーディオ 再生オプションを変更する手順:

1. [Create](#create-audio-frame) もしくは Audio Frame を取得します。  
2. 調整したい Audio Frame プロパティに新しい値を設定します。  
3. 変更した PowerPoint ファイルを保存します。

この JavaScript コードは、オーディオのオプションを調整する操作を示します:
```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame シェイプを取得
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 再生モードをクリック時再生に設定
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // 音量を低に設定
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // オーディオをスライド全体で再生するように設定
    audioFrame.setPlayAcrossSlides(true);
    // オーディオのループを無効化
    audioFrame.setPlayLoopMode(false);
    // スライドショー中に AudioFrame を非表示に設定
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


この JavaScript サンプルは、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングし、フェード時間を設定する方法を示します:
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

    // フェードイン期間を 200 ミリ秒に設定
    audioFrame.setFadeInDuration(200);
    // フェードアウト期間を 500 ミリ秒に設定
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


次のコード例は、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示します:
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


## **オーディオ の抽出**

Aspose.Slides for Node.js via Java を使用すると、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。  
2. インデックスを使用して対象スライドの参照を取得します。  
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) にアクセスします。  
4. サウンドをバイト データとして抽出します。

この JavaScript コードは、スライドで使用されるオーディオを抽出する方法を示します:
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // 対象のスライドにアクセス
    const slide = pres.getSlides().get_Item(0);
    // スライドのスライドショー遷移効果を取得
    const transition = slide.getSlideShowTransition();
    // サウンドをバイト配列で抽出
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増加させない方法はありますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) にオーディオを一度だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が回避され、プレゼンテーション サイズが制御下に保たれます。

**既存のオーディオ フレームのサウンドを形状を作り直さずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) を新しいファイルに更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) から別のものに入れ替えます。フレームの書式設定とほとんどの再生設定はそのまま残ります。

**トリミングはプレゼンテーションに保存されている基礎オーディオ データを変更しますか？**

いいえ。トリミングは再生境界のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを介してアクセス可能なままです。