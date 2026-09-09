---
title: Python でプレゼンテーションのオーディオを管理
linktitle: オーディオフレーム
type: docs
weight: 10
url: /ja/python-java/audio-frame/
keywords:
- オーディオ
- オーディオフレーム
- サムネイル
- オーディオの追加
- オーディオプロパティ
- オーディオオプション
- オーディオ抽出
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java でオーディオフレームを作成および制御します—埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーション全体で構成するコード例です。"
---
## **概要**

この記事では、Aspose.Slidesでオーディオフレームを扱う方法を説明します。スライドに埋め込みオーディオを追加する方法、オーディオフレームのサムネイルをカスタマイズする方法、音量、ループ、非表示、トリミング、フェード時間などの再生オプションを構成する方法、およびスライドショーの遷移で使用されるオーディオを抽出する方法を示します。

## **オーディオフレームの作成**

Aspose.Slides for Python via Java を使用すると、スライドにオーディオファイルを追加できます。オーディオファイルはオーディオフレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに埋め込むオーディオファイルを読み取ります。
4. 埋め込みオーディオフレーム（オーディオファイルを含む）をスライドに追加します。
5. [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) オブジェクトが公開する [setPlayMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayMode) と [setVolume](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolume) を使用します。
6. 変更されたプレゼンテーションを保存します。

この Python コードは、埋め込みオーディオフレームをスライドに追加する方法を示しています：

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

## **オーディオフレームのサムネイルを変更**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（以下のセクションの画像を参照）。オーディオフレームのプレビュー画像を任意の画像に変更できます。

この Python コードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

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

## **オーディオ再生オプションの変更**

Aspose.Slides for Python via Java を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオアイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン：

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) プロパティに対応します：

- **Start** ドロップダウンリストは [setPlayMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayMode) メソッドに対応します
- **Volume** は [setVolume](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolume) メソッドに対応します
- **Play Across Slides** は [setPlayAcrossSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) メソッドに対応します
- **Loop until Stopped** は [setPlayLoopMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setPlayLoopMode) メソッドに対応します
- **Hide During Show** は [setHideAtShowing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setHideAtShowing) メソッドに対応します
- **Rewind after Playing** は [setRewindAudio](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setRewindAudio) メソッドに対応します

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/) プロパティに対応します：

- **Fade In** は [setFadeInDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setFadeInDuration) メソッドに対応します
- **Fade Out** は [setFadeOutDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setFadeOutDuration) メソッドに対応します
- **Trim Audio Start Time** は [setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setTrimFromStart) メソッドに対応します
- **Trim Audio End Time** の値は、オーディオの長さから [setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setTrimFromEnd) メソッドで設定された値を引いたものです

PowerPoint のオーディオコントロールパネルにある **Volume control** は [setVolumeValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setVolumeValue) メソッドに対応します。音量をパーセンテージで変更できます。

オーディオ再生オプションを変更する手順は次のとおりです：

1. [Create](#create-audio-frames) またはオーディオフレームを取得します。
2. 調整したいオーディオフレームプロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この Python コードは、オーディオオプションを調整する操作を示しています：

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
        # クリック時に低音量で再生し、スライド全体で再生、ループしません。
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

この Python の例は、埋め込みオーディオを持つ新しいオーディオフレームを追加し、トリミングし、フェード時間を設定する方法を示しています：

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

    # 開始から1.5秒、終了から2秒をトリムします。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # フェードインを200ミリ秒、フェードアウトを500ミリ秒に設定します。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

次のコードサンプルは、埋め込みオーディオを持つオーディオフレームを取得し、音量を 85% に設定する方法を示しています：

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

## **オーディオキャプションの管理**

Aspose.Slides では、[getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用してオーディオフレームにクローズドキャプションを追加できます。このメソッドは [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) を返し、WebVTT キャプショントラックを追加したり、既存のトラックを列挙したり、必要に応じて削除したりできます。

**オーディオキャプションの追加**

[getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#getCaptionTracks) メソッドを使用して、1 つまたは複数のキャプショントラックをオーディオフレームに添付します。以下の例では、スライドにオーディオファイルを追加し、その後 `.vtt` ファイルから新しいキャプショントラックをロードしています。

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

**オーディオキャプションの抽出**

オーディオフレームに関連付けられたキャプショントラックを列挙し、`.vtt` ファイルとして保存できます。各キャプショントラックはバイナリデータと固有の識別子を公開しており、キャプションのエクスポート時に使用できます。

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

**オーディオキャプションの削除**

オーディオフレームからキャプションを削除するには、[CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) が提供する [clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#remove)、または [removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#removeAt) などのメソッドを使用します。以下の例は、オーディオフレームからすべてのキャプショントラックを削除します。

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

## **オーディオの抽出**

Aspose.Slides for Python via Java を使用すると、スライドショーの遷移で使用される音声を抽出できます。たとえば、特定のスライドで使用される音声を抽出できます。

1. オーディオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで該当スライドへの参照を取得します。
3. スライドの [slideshow transitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideShowTransition) にアクセスします。
4. 音声をバイトデータとして抽出します。

この Python のコードは、スライドで使用されるオーディオを抽出する方法を示しています：

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

**同じオーディオ資産を複数のスライドで再利用して、ファイルサイズを増大させずに使用できますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAudios) にオーディオを一度追加し、既存の資産を参照する追加のオーディオフレームを作成します。これによりメディアデータの重複が防止され、プレゼンテーションサイズを適切に保てます。

**既存のオーディオフレームの音声を、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされた音声の場合は、[link path](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setLinkPathLong) を新しいファイルを指すように更新します。埋め込み音声の場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAudios) から別のオーディオを取得して、[embedded audio](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audioframe/#setEmbeddedAudio) オブジェクトと入れ替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている元のオーディオデータを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元のオーディオバイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオコレクションを通じて引き続きアクセス可能です。