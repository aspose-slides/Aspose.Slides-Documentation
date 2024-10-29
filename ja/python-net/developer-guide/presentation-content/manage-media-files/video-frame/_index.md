---
title: ビデオフレーム
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにビデオフレームを追加する"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより魅力的にし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります。

* ローカルビデオ（マシンに保存されたもの）を追加または埋め込む
* オンラインビデオ（YouTubeなどのウェブソースから）を追加する。

ビデオ（ビデオオブジェクト）をプレゼンテーションに追加できるように、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/)インターフェイス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. ビデオのためのフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/)オブジェクトを追加します。
1. 修正されたプレゼンテーションを保存します。

このPythonコードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 最初のスライドを取得してビデオフレームを追加
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # プレゼンテーションをディスクに保存
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

また、`add_video_frame(x, y, width, height, fname)`メソッドにファイルパスを直接渡してビデオを追加することもできます：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **ウェブソースからのビデオを使用したビデオフレームの作成**

Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーションにYouTubeビデオをサポートしています。使用したいビデオがオンラインで利用可能な場合（例：YouTube）、ウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)オブジェクトを追加し、ビデオのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このPythonコードは、ウェブからスライドにビデオを追加する方法を示しています：

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # ビデオフレームを追加
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # サムネイルを読み込み
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドからのビデオの抽出**

スライドにビデオを追加することに加えて、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することを許可します。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトを反復処理します。
3. すべての[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)オブジェクトを反復処理して[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

このPythonコードは、プレゼンテーションスライド上のビデオを抽出する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```