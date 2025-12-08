---
title: Pythonでプレゼンテーションにビデオを追加する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords:
- ビデオを追加する
- ビデオを作成する
- ビデオを埋め込む
- ビデオを抽出する
- ビデオを取得する
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドにビデオフレームをプログラムで追加および抽出する方法を学びます。迅速なハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法は次の2つがあります。

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTubeなどのウェブソースから）

プレゼンテーションにビデオオブジェクトを追加できるように、Aspose.Slidesは[IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/)インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。  
1. インデックスを使ってスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。  
1. [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/)オブジェクトを追加してビデオ用のフレームを作成します。  
1. 変更したプレゼンテーションを保存します。  

このPythonコードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 最初のスライドを取得し、ビデオフレームを追加します
        # プレゼンテーションをディスクに保存します
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```


あるいは、`add_video_frame(x, y, width, height, fname)`メソッドにファイルパスを直接渡してビデオを追加することもできます:
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **ウェブソースからのビデオフレームの作成**

Microsoft[PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーションでYouTubeビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）にある場合、そのウェブリンクを使ってプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。  
1. インデックスを使ってスライドの参照を取得します。  
1. [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)オブジェクトを追加し、ビデオへのリンクを渡します。  
1. ビデオフレームのサムネイルを設定します。  
1. プレゼンテーションを保存します。  

このPythonコードは、ウェブ上のビデオをPowerPointプレゼンテーションのスライドに追加する方法を示しています:
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # ビデオフレームを追加します
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # サムネイルをロードします
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. すべての[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトを列挙します。  
3. すべての[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)を探します。  
4. ビデオをディスクに保存します。  

このPythonコードは、プレゼンテーションのスライドからビデオを抽出する方法を示しています:
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```


## **FAQ**

**VideoFrameの再生パラメータで変更できる項目は何ですか？**

[再生モード](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動またはクリック）と[ループ設定](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)を制御できます。これらのオプションは[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)オブジェクトのプロパティで利用できます。

**ビデオを追加するとPPTXファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存のVideoFrameの位置やサイズを変更せずにビデオだけを差し替えることは可能ですか？**

はい。フレーム内の[ビデオ コンテンツ](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これはレイアウト内のメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには[コンテンツタイプ](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)があり、これを読み取ってディスクに保存する際などに利用できます。