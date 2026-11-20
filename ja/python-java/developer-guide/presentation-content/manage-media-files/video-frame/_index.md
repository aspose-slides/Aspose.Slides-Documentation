---
title: プレゼンテーションで動画フレームを管理する（Python 使用）
linktitle: 動画フレーム
type: docs
weight: 10
url: /ja/python-java/video-frame/
keywords:
- 動画を追加
- 動画を作成
- 動画を埋め込む
- 動画を抽出
- 動画を取得
- 動画フレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument スライドで動画フレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

ビデオは、アイデアの説明や観客の関心を引くのに役立ちます。Aspose.Slides for Python via Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、字幕を管理し、埋め込まれたビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートしています。

ビデオ データとビデオフレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) クラス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、ビデオ フレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。Python はディスクからビデオ バイトを読み取り、JPype がそれらを Java のバイト配列に変換してからビデオをプレゼンテーションに追加します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ローカルビデオのパスを直接 [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能な状態である必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ウェブソースからのビデオでビデオフレームを作成する**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンライン ビデオをサポートしています。YouTube ビデオなどのオンライン ビデオへのリンクを持つビデオ フレームを作成できます。

この例は、YouTube ビデオのリンクとサムネイルを最初のスライドに追加します。別のビデオを使用する場合はビデオ識別子を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) メソッドは自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーション ビューアーもオンライン ビデオ再生をサポートしている必要があります。

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **フルスクリーン モードでビデオを再生する**

トレーニング プレゼンテーションでは、ソフトウェア デモをフルスクリーン モードで再生して、聴衆が詳細を確認できるようにします。再生中にこの動作を有効にするには、`True` を指定して [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) を呼び出します。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) を見つけ、フルスクリーン再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

フルスクリーン再生はビデオの表示方法を制御します。別に、[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) は自動開始かクリック開始かを制御し、[setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) は繰り返しの有無を制御します。開始動作を選択するには、[VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) に再生モードを設定します。この例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング プレゼンテーションで、デモ ビデオを冒頭に戻すことにより、プレゼンターが再度再生できるようにします。[setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) に `True` を渡すと、再生が終了した後にビデオが冒頭に戻ります。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリックで開始するように設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

巻き戻しはビデオを冒頭に戻すだけで再度開始はしません。対照的に、[setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) に `True` を渡すと自動的に繰り返し再生します。ビデオを終了させて再生待ち状態にしたい場合は、ループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) は自動開始またはクリック開始を個別に制御します；この例では [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) を使用してプレゼンターが再生開始のタイミングを制御します。ループ設定の後に再生モードを設定します（例参照）。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) とは独立して動作します。

## **ビデオフレームをトリミングする**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) を使用して、再生時にビデオの先頭または末尾の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込まれたビデオ データを変更せずに再生設定を変更します。

**トリム設定の設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒以上のビデオを使用してください。

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**トリム設定の取得**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒単位で表示します。プレゼンテーションに少なくとも 1 つのスライドが含まれている必要があります。そのスライドにビデオフレームがない場合は何も出力されません。前述の例では 2500 と 1000 が出力されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **ビデオ字幕の管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズド キャプションを管理できるようにします。字幕は WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

### **ビデオフレームに字幕を追加する**

この例はローカルビデオを埋め込み、英語というラベルの WebVTT 字幕トラックを追加します。字幕のタイムスタンプはビデオに合わせる必要があります。保存されたプレゼンテーションにはビデオと字幕の両方が含まれます。

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT ファイルから新しい字幕トラックを追加します。
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) クラスは、ストリームから字幕を追加できるオーバーロードも提供します。

### **ビデオフレームから字幕を抽出する**

この例は最初のスライド上のビデオフレームからすべての字幕トラックを個別の WebVTT ファイルとして保存します。連番により出力ファイルが区別されます。コンソールには抽出されたトラック数が表示されます。プレゼンテーションに少なくとも 1 つのスライドが必要です。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

各 [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) オブジェクトは、字幕識別子、ラベル、バイナリ データ、UTF-8 文字列としての字幕テキストを公開します。

### **ビデオフレームから字幕を削除する**

この例は最初のスライドの最初のシェイプ位置にあるビデオフレームからすべての字幕を削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # ビデオフレームからすべての字幕を削除します。
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

1 つの字幕トラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

### **ビデオ字幕を検索する**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) はヘッダー、タイミング行、字幕テキストを含む完全な WebVTT トラックを返します。メモリ上の字幕を検索してフレーズとタイムスタンプを見つけることができます。たとえば、スライド 2 の英語トラックには次のようなテキストが含まれている場合があります。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

この例は `captioned_media.pptx` を開き、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) を使用して各スライド上のすべてのトップレベルビデオフレームのトラックを読み取ります。プレーンテキストのキューでは、タイミング行に `-->` が含まれ、空行でキューが終了します。任意の大文字小文字で “café” を含む字幕について、スライド番号、トラック ラベル、元のタイミング行、全文字幕を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

“café” の検索はサンプルトラックで 1 件の一致を生成します。検索はトラックヘッダーを除外し、タイミング設定と改行を出力に保持します。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することもできます。

この例はすべてのスライドから埋め込まれたビデオを個別の番号付きバイナリ ファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールには各ビデオの MIME タイプと合計数が表示されます。出力は汎用的な `.bin` 拡張子を使用しますが、必要に応じて報告されたメディア タイプに合わせて変更してください。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**ビデオフレームで変更できるビデオ再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはビデオ ファイルのサイズに比例して増加します。オンラインビデオにリンクしサムネイルを追加する場合、プレゼンテーションはビデオ データではなくリンクとプレビュー画像を保存するため、サイズの増加は通常小さくなります。

**既存のビデオフレームの位置やサイズを変更せずにビデオを置き換えることはできますか？**

はい。[video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) をフレーム内で入れ替えることで、シェイプの形状を保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツ タイプ（MIME）は取得できますか？**

はい。埋め込まれたビデオは [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) を持っており、これを読み取ってたとえばディスクに保存する際に利用できます。