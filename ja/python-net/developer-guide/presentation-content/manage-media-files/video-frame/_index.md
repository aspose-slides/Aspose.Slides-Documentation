---
title: Pythonでプレゼンテーションにビデオを追加する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込み
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---
プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、オーディエンスとのエンゲージメントレベルを向上させることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります。

* ローカルビデオ（マシンに保存されているもの）を追加または埋め込む
* オンラインビデオ（YouTube などの Web ソース）を追加する

プレゼンテーションにビデオオブジェクトを追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) クラス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合は、ビデオ フレームを作成してプレゼンテーションに埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. ビデオ ファイル パスを渡してビデオを埋め込むために [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) オブジェクトを追加します。  
4. ビデオ用のフレームを作成するために [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを追加します。  
5. 変更したプレゼンテーションを保存します。  

以下の Python コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。

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

あるいは、`add_video_frame(x, y, width, height, fname)` メソッドにファイル パスを直接渡してビデオを追加することもできます。

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Web ソースからのビデオ フレームの作成**

Microsoft [PowerPoint 2013 およびそれ以降のバージョン](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) は、プレゼンテーションで YouTube ビデオをサポートします。使用したいビデオがオンライン（例: YouTube）に存在する場合は、Web リンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. ビデオへのリンクを渡して [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) オブジェクトを追加します。  
4. ビデオ フレームのサムネイルを設定します。  
5. プレゼンテーションを保存します。  

以下の Python コードは、Web からビデオを取得して PowerPoint スライドに追加する方法を示しています。

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

## **ビデオ キャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーション内のビデオ フレームのクローズド キャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) プロパティを通じて取得できます。

**ビデオ フレームにキャプションを追加する**

ビデオ フレームにキャプションを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーションにビデオを追加します。  
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを追加します。  
4. [caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) を使用して WebVTT キャプション トラックを追加します。  
5. 変更したプレゼンテーションを保存します。  

以下のコードは、ビデオ フレームにキャプションを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT ファイルから新しいキャプション トラックを追加します。
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオ フレームからキャプションを抽出する**

ビデオ フレームからキャプションを抽出する手順:

1. ビデオを含むプレゼンテーションを読み込みます。  
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを検索します。  
3. [caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) コレクションを列挙します。  
4. 各キャプション トラックを `.vtt` ファイルとして保存します。  

以下のコードは、ビデオ フレームからキャプションを抽出する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # キャプション トラックを WebVTT ファイルに保存します。
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

各 [Captions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captions/) オブジェクトは、キャプション ID、ラベル、バイナリ データ、および UTF-8 文字列としてのキャプション テキストを公開します。

**ビデオ フレームからキャプションを削除する**

ビデオ フレームからキャプションを削除する手順:

1. ビデオを含むプレゼンテーションを読み込みます。  
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを取得します。  
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) からキャプション トラックを削除します。  
4. 変更したプレゼンテーションを保存します。  

以下のコードは、ビデオ フレームからすべてのキャプションを削除する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # ビデオフレームからすべてのキャプションを削除します。
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

1 つだけのキャプション トラックを削除したい場合は、[clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/clear/) の代わりに [remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove/) または [remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove_at/) メソッドを使用してください。

## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出する機能も提供します。

1. ビデオを含むプレゼンテーションを読み込むために [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. すべての [Slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) オブジェクトを列挙します。  
3. すべての [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) を探します。  
4. ビデオをディスクに保存します。  

以下の Python コードは、プレゼンテーション スライドからビデオを抽出する方法を示しています。

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

**VideoFrame の再生パラメータで変更できる項目は何ですか？**

[playback mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/play_mode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/play_loop_mode/) を制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトのプロパティを介して利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカル ビデオを埋め込むと、バイナリ データがドキュメントに含まれるため、ファイル サイズに比例してプレゼンテーションのサイズが増加します。オンライン ビデオを追加する場合は、リンクとサムネイルが埋め込まれるだけなので、増加幅は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずにビデオを入れ替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/embedded_video/) を交換すれば、シェイプのジオメトリを保持したままメディアを更新できます。これは既存レイアウトのメディア更新で一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには [content type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/content_type/) があり、読み取ってディスクに保存するときなどに利用できます。