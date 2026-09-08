---
title: Python を使用したプレゼンテーションのビデオ フレームの管理
linktitle: ビデオ フレーム
type: docs
weight: 10
url: /ja/python-java/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオ フレーム
- ウェブ ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument スライドでビデオ フレームをプログラム的に追加および抽出する方法を学びます。迅速なハウツー ガイドです。"
---
## **概要**

プレゼンテーションに適切に配置されたビデオは、メッセージをより魅力的にし、聴衆とのエンゲージメントを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカル ビデオ（マシンに保存されているもの）を追加または埋め込む
* オンライン ビデオ（YouTube などのウェブ ソース）を追加する

ビデオ オブジェクトをプレゼンテーションに追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) クラス、およびその他の関連タイプを提供します。

## **埋め込みビデオ フレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、ビデオ フレームを作成してプレゼンテーションに埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. ビデオ ファイル データを渡してビデオを埋め込むために、[Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) オブジェクトを追加します。
4. ビデオ用のフレームを作成するために、[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
5. 変更したプレゼンテーションを保存します。

この Python コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

または、[addVideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addVideoFrame) メソッドにファイル パスを直接渡すことでビデオを追加できます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Web ソースからのビデオを使用したビデオ フレームの作成**

Microsoft [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートしています。オンライン（例: YouTube）にビデオがある場合、そのウェブ リンクを使用してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. ビデオへのリンクを渡して [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. ビデオ フレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この Python コードは、ウェブ上のビデオを PowerPoint のスライドに追加する方法を示しています：

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # サムネイルを読み込む。
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ビデオ フレームのトリミング**

Aspose.Slides は、[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromEnd) を使用して、開始位置と終了位置のトリム値をミリ秒単位で設定することで、ビデオの再生部分を制御できます。これらの設定はプレゼンテーション内のビデオ再生を変更しますが、埋め込まれたビデオ バイナリ データ自体をカットしたり変更したりはしません。

**トリム設定の設定**

ビデオ フレームを作成し、トリム設定を行う手順：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションに [Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) オブジェクトを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromEnd) を使用してトリム値を設定します。
5. 変更したプレゼンテーションを保存します。

以下のコード例は、埋め込みビデオの再生時に最初の 2.5 秒と最後の 1 秒をスキップします：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**トリム設定の取得**

既存のトリム設定を確認するには、プレゼンテーションをロードし、最初のスライド上のシェイプから [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを見つけ、[VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getTrimFromStart) と [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getTrimFromEnd) を使用して値を取得します。

以下のコード例は、最初のスライド上の最初のビデオ フレームを見つけ、そのトリム設定（ミリ秒）を出力します：

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

## **ビデオ キャプションの管理**

Aspose.Slides は、PowerPoint のビデオ フレームに対してクローズド キャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオ フレームにキャプションを追加する**

ビデオ フレームにキャプションを追加する手順：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションにビデオを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
4. [getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getCaptionTracks) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) を使用して WebVTT キャプショントラックを追加します。
5. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオ フレームにキャプションを追加する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT ファイルから新しいキャプショントラックを追加します。
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供しています。

**ビデオ フレームからキャプションを抽出する**

ビデオ フレームからキャプションを抽出する手順：

1. ビデオを含むプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを見つけます。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) 内のキャプショントラックを列挙します。
4. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、ビデオ フレームからキャプションを抽出する方法を示しています：

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # キャプショントラックを WebVTT ファイルに保存します。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

各 [Captions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captions/) オブジェクトは、キャプション ID、ラベル、バイナリ データ、および UTF-8 文字列としてのキャプション テキストを公開します。

**ビデオ フレームからキャプションを削除する**

ビデオ フレームからキャプションを削除する手順：

1. ビデオを含むプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを取得します。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) からキャプショントラックを削除します。
4. 変更したプレゼンテーションを保存します。

以下のコードは、ビデオ フレームからすべてのキャプションを削除する方法を示しています：

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
        # ビデオ フレームのすべてのキャプションを削除します。
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

1 つだけ削除したい場合は、[clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) オブジェクトを列挙します。
3. すべての [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトを走査して、[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この Python コードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**VideoFrame の再生パラメータで変更できる項目は何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setPlayMode)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setPlayLoopMode) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカル ビデオを埋め込むと、バイナリ データが文書に含まれるため、ファイル サイズに比例してプレゼンテーションのサイズが増加します。オンライン ビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、増加幅は小さくなります。

**既存の VideoFrame の位置とサイズを変えずにビデオを置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setEmbeddedVideo) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディア更新で一般的なシナリオです。

**埋め込みビデオのコンテンツ タイプ（MIME）を取得できますか？**

はい。埋め込みビデオには取得可能な [content type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/#getContentType) があり、たとえばディスクに保存する際に利用できます。