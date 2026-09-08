---
title: Python を使用したプレゼンテーションの音声管理
linktitle: 音声フレーム
type: docs
weight: 10
url: /ja/python-java/audio-frame/
keywords:
- 音声
- 音声フレーム
- サムネイル
- 音声の追加
- 音声プロパティ
- 音声オプション
- 音声の抽出
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java で音声フレームを作成・制御します。埋め込み、トリミング、ループ、PPT、PPTX、ODP プレゼンテーションでの再生設定の構成例をコードで示します。"
---
## **概要**

本記事では Aspose.Slides における音声フレームの操作方法を解説します。スライドへ埋め込み音声を追加する方法、音声フレームのサムネイルをカスタマイズする方法、音量・ループ・非表示・トリミング・フェード時間などの再生オプションを設定する方法、スライドショーの遷移で使用される音声を抽出する方法を紹介します。

## **音声フレームの作成**

Aspose.Slides for Python via Java を使用すると、スライドに音声ファイルを追加できます。音声ファイルはスライドに音声フレームとして埋め込まれます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. スライドに埋め込む音声ファイルを読み取ります。
4. 埋め込み音声フレーム（音声ファイルを含む）をスライドに追加します。
5. [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) オブジェクトが提供する [setPlayMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayMode) と [setVolume](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolume) を設定します。
6. 変更されたプレゼンテーションを保存します。

この Python コードは、スライドに埋め込み音声フレームを追加する方法を示します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **音声フレームのサムネイル変更**

プレゼンテーションに音声ファイルを追加すると、音声は標準のデフォルト画像が付いたフレームとして表示されます（下記画像参照）。音声フレームのプレビュー画像を任意の画像に変更できます。

この Python コードは、音声フレームのサムネイル（プレビュー画像）を変更する方法を示します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **音声再生オプションの変更**

Aspose.Slides for Python via Java を使用すると、音声の再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、音声をループ再生したり、音声アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** パネル:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) プロパティに対応しています：

- **開始** のドロップダウンは [setPlayMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayMode) メソッドに対応
- **音量** は [setVolume](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolume) メソッドに対応
- **スライド全体で再生** は [setPlayAcrossSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに対応
- **停止するまでループ** は [setPlayLoopMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに対応
- **ショー中に非表示** は [setHideAtShowing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに対応
- **再生後に巻き戻し** は [setRewindAudio](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setRewindAudio) メソッドに対応

PowerPoint の **編集** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) プロパティに対応しています：

- **フェードイン** は [setFadeInDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに対応
- **フェードアウト** は [setFadeOutDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに対応
- **音声開始位置のトリミング** は [setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに対応
- **音声終了位置のトリミング** の値は音声の全長から [setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドの値を引いたものに等しい

音声コントロールパネルの **音量コントロール** は [setVolumeValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応し、音量をパーセンテージで変更できます。

音声再生オプションを変更する手順は次のとおりです：

1. [音声フレームの作成](#create-audio-frames) または取得。
2. 調整したい音声フレームのプロパティに新しい値を設定。
3. 変更された PowerPoint ファイルを保存。

この Python コードは、音声のオプションを調整する操作を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # クリックで再生し、低音量、スライド全体で再生、ループしません。
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # スライドショー中にフレームを非表示にし、再生後に巻き戻します。
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

この Python の例は、埋め込み音声付きの新しい音声フレームを追加し、トリミングとフェード時間を設定する方法を示します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 開始から 1.5 秒、終了から 2 秒をトリムします。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # フェードインを 200 ms、フェードアウトを 500 ms に設定します。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下のコードサンプルは、埋め込み音声を持つ音声フレームを取得し、音量を 85% に設定する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **音声キャプションの管理**

Aspose.Slides では、[getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用して音声フレームにクローズドキャプションを追加できます。このメソッドは [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) を返し、WebVTT キャプショントラックの追加、既存トラックの列挙、必要に応じた削除が可能です。

**音声キャプションの追加**

[getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用して、音声フレームに 1 つ以上のキャプショントラックを添付します。以下の例では、スライドに音声ファイルを追加した後、`.vtt` ファイルから新しいキャプショントラックを読み込みます。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # WebVTT ファイルから新しいキャプショントラックを追加します。
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**音声キャプションの抽出**

音声フレームに関連付けられたキャプショントラックを列挙し、`.vtt` ファイルとして保存できます。各キャプショントラックはバイナリデータと一意の識別子を公開しており、キャプションのエクスポート時に使用できます。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # キャプショントラックを .vtt ファイルとして保存します。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**音声キャプションの削除**

音声フレームからキャプションを削除するには、[CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) が提供する [clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#remove)、または [removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#removeAt) メソッドを使用します。以下の例は、音声フレームからすべてのキャプショントラックを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **音声の抽出**

Aspose.Slides for Python via Java を使用すると、スライドショー遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、音声を含むプレゼンテーションをロードします。
2. インデックスで対象スライドの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideShowTransition) にアクセスします。
4. サウンドをバイトデータとして抽出します。

この Python のコードは、スライドで使用されている音声を抽出する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**同じ音声アセットを複数のスライドで再利用して、ファイルサイズを増やさずに済みますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAudios) に音声を 1 回だけ追加し、その既存アセットを参照する追加の音声フレームを作成します。これによりメディアデータの重複が防止され、プレゼンテーションのサイズを抑制できます。

**既存の音声フレームのサウンドを形状を作り直さずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setLinkPathLong) を新しいファイルに更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAudios) から別の [embedded audio](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setEmbeddedAudio) オブジェクトに差し替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎となる音声データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元の音声バイト列は変更されず、埋め込み音声またはプレゼンテーションの音声コレクションを介して引き続きアクセス可能です。