---
title: Python を使用したプレゼンテーションでのビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/python-java/video-frame/
keywords:
- ビデオ追加
- ビデオ作成
- ビデオ埋め込み
- ビデオ抽出
- ビデオ取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument スライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **導入**

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオを追加または埋め込み（マシンに保存されている）
* オンラインビデオを追加（YouTube などのウェブソースから）

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) クラス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. [Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) オブジェクトを追加し、ビデオファイルデータを渡してプレゼンテーションにビデオを埋め込みます。
1. [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加してビデオのフレームを作成します。
1. 変更したプレゼンテーションを保存します。

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

あるいは、ビデオのファイルパスを直接 [addVideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addVideoFrame) メソッドに渡してビデオを追加することもできます：

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

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft の [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この Python コードは、ウェブからビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています：

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

    # サムネイルをロードします。
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

## **ビデオフレームのトリミング**

Aspose.Slides では、[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromStart) および [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromEnd) を使用してトリム開始位置とトリム終了位置の値を設定することで、ビデオの再生部分を制御できます。両方の値はミリ秒単位で指定され、ビデオの先頭および末尾からスキップする時間を定義します。これらの設定はプレゼンテーション内のビデオ再生設定を変更しますが、埋め込まれたビデオのバイナリデータをカットしたり変更したりするものではありません。

**トリム設定の設定**

ビデオフレームを作成し、トリム設定を行う手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに [Video](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/) オブジェクトを追加します。
1. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
1. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromStart) と [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setTrimFromEnd) を使用してトリム開始値とトリム終了値を設定します。
1. 変更したプレゼンテーションを保存します。

次のコード例は、埋め込みビデオの再生時に最初の 2.5 秒と最後の 1 秒をスキップします：

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

既存のトリム設定を確認するには、プレゼンテーションをロードし、最初のスライドのシェイプの中から [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを見つけ、[VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getTrimFromStart) と [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getTrimFromEnd) を使用して値を取得します。

次のコード例は、最初のスライド上の最初のビデオフレームを見つけ、ミリ秒単位でそのトリム設定を報告します：

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

## **ビデオキャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションのビデオフレーム用のクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getCaptionTracks) メソッドで取得できます。

**ビデオフレームへのキャプション追加**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションにビデオを追加します。
1. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを追加します。
1. [getCaptionTracks](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#getCaptionTracks) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) を使用して WebVTT キャプショントラックを追加します。
1. 変更したプレゼンテーションを保存します。

次のコードは、ビデオフレームにキャプションを追加する方法を示しています：

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

[CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからのキャプション抽出**

1. ビデオを含むプレゼンテーションをロードします。
1. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを見つけます。
1. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) 内のキャプショントラックを列挙します。
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

次のコードは、ビデオフレームからキャプションを抽出する方法を示しています：

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

各 [Captions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを提供します。

**ビデオフレームからのキャプション削除**

1. ビデオを含むプレゼンテーションをロードします。
1. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトを取得します。
1. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/) からキャプショントラックを削除します。
1. 変更したプレゼンテーションを保存します。

次のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています：

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
        # ビデオフレームからすべてのキャプションを削除します。
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

1 つだけキャプショントラックを削除したい場合は、[clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#clear) の代わりに [remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#remove) または [removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/captionscollection/#removeAt) メソッドを使用してください。

## **スライドからビデオを抽出**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) オブジェクトを列挙します。
3. すべての [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この Python コードは、プレゼンテーションのスライド上のビデオを抽出する方法を示しています：

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

**VideoFrame の動画再生パラメータで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setPlayMode)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setPlayLoopMode) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/) オブジェクトのプロパティから利用できます。

**ビデオを追加すると PPTX のファイルサイズに影響しますか？**

はい。ローカルビデオを埋め込むとバイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオのファイルサイズに比例して増加します。オンラインビデオを追加する場合はリンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoframe/#setEmbeddedVideo) を入れ替えることで、シェイプのジオメトリを保持したままメディアを更新できます。これは既存レイアウトのメディア更新で一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/video/#getContentType) があり、取得して保存時などに利用できます。