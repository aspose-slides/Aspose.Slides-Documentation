---
title: Pythonでプレゼンテーションにビデオを追加
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- Webソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションで適切に配置されたビデオは、メッセージをより魅力的にし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります：

* ローカル ビデオ（マシンに保存）を追加または埋め込む
* オンライン ビデオ（YouTube などのウェブ ソース）を追加する。

プレゼンテーションにビデオ（ビデオ オブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) クラス、その他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオ フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドのインデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) オブジェクトを追加し、ビデオ ファイル パスを渡してプレゼンテーションにビデオを埋め込みます。
1. ビデオ用のフレームを作成するために [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) オブジェクトを追加します。
1. 変更されたプレゼンテーションを保存します。

この Python コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 最初のスライドを取得し、ビデオフレームを追加します
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # プレゼンテーションをディスクに保存します
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```


または、`add_video_frame(x, y, width, height, fname)` メソッドにファイル パスを直接渡すことでビデオを追加できます。
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Web ソースからのビデオを使用したビデオフレームの作成**

Microsoft の [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) はプレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例えば YouTube）で入手可能な場合、そのウェブ リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドのインデックスを使用してスライドの参照を取得します。
1. [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオ フレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この Python コードは、ウェブからのビデオを PowerPoint プレゼンテーションのスライドに追加する方法を示しています。
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # ビデオフレームを追加します
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # サムネイルを読み込みます
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides ではプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションを読み込むために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) オブジェクトを反復処理します。
3. すべての [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を検索します。
4. ビデオをディスクに保存します。

この Python コードは、プレゼンテーションのスライド上のビデオを抽出する方法を示しています。
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```


## **よくある質問**

**VideoFrame の再生パラメーターで変更できる項目は何ですか？**

再生モード（自動またはクリック時）と [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) オブジェクトのプロパティを通じて利用可能です。

**ビデオを追加すると PPTX ファイルのサイズに影響がありますか？**

はい。ローカル ビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、プレゼンテーションのサイズはファイル サイズに比例して増加します。オンライン ビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) を入れ替えてもシェイプの形状は維持されます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) があり、例えばディスクに保存する際などに読み取って使用できます。