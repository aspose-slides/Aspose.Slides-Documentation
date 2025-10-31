---
title: Pythonでプレゼンテーションにビデオを追加する
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
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。迅速なハウツーガイド。"
---

プレゼンテーションにうまく配置されたビデオは、メッセージをより説得力のあるものにし、聴衆のエンゲージメントレベルを向上させます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルに保存されたビデオを追加または埋め込む
* YouTube などのウェブソースからオンラインビデオを追加する

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションに埋め込みます。  
4. [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) オブジェクトを追加してビデオ用のフレームを作成します。  
5. 変更したプレゼンテーションを保存します。

以下の Python コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 最初のスライドを取得し、ビデオフレームを追加
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # プレゼンテーションをディスクに保存
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

または、`add_video_frame(x, y, width, height, fname)` メソッドにファイルパスを直接渡してビデオを追加することもできます。

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **ウェブソースからのビデオでフレームを作成**

Microsoft の [PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーション内で YouTube ビデオをサポートしています。オンラインにあるビデオ（例: YouTube）を使用したい場合は、そのウェブリンクを使用してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。  
4. ビデオフレームのサムネイルを設定します。  
5. プレゼンテーションを保存します。

以下の Python コードは、ウェブ上のビデオを PowerPoint スライドに追加する方法を示しています。

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # ビデオフレームを追加
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # サムネイルを読み込む
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())

with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドからビデオを抽出**

ビデオをスライドに追加するだけでなく、Aspose.Slides を使用すると、プレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオが含まれるプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. すべての [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) オブジェクトを反復処理します。  
3. すべての [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) オブジェクトを反復処理し、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を見つけます。  
4. ビデオをディスクに保存します。

以下の Python コードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています。

```python
import aspose.slides as slides

# Presentation オブジェクトをインスタンス化し、プレゼンテーション ファイルを表します
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**VideoFrame の再生パラメーターで変更できる項目は何ですか？**

[再生モード](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動またはクリック時）と[ループ設定](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリ データが文書に含まれるため、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さく抑えられます。

**既存の VideoFrame の位置やサイズを変えずにビデオを置き換えることはできますか？**

はい。フレーム内の [ビデオ コンテンツ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) を入れ替えることで、形状のジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには [コンテンツタイプ](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) があり、取得して利用することができます（例: ディスクに保存するときなど）。