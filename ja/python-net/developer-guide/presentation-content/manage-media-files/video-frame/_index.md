---
title: Python でプレゼンテーションに動画を追加する
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords:
- 動画を追加
- 動画を作成
- 動画を埋め込む
- 動画を抽出
- 動画を取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドで動画フレームをプログラム的に追加および抽出する方法を学びます。迅速なハウツーガイド。"
---
## **はじめに**

プレゼンテーションに適切に配置された動画は、メッセージをより魅力的にし、視聴者とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドに動画を追加する方法が 2 つあります。

* ローカル動画を追加または埋め込む（マシンに保存されている）
* オンライン動画を追加する（YouTube などの Web ソースから）。

プレゼンテーションに動画（video オブジェクト）を追加できるように、Aspose.Slides は [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) クラス、およびその他の関連タイプを提供します。

## **埋め込み動画フレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、動画フレームを作成してプレゼンテーションに動画を埋め込むことができます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) オブジェクトを追加し、動画ファイルのパスを渡してプレゼンテーションに動画を埋め込みます。
4. [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを追加して、動画のフレームを作成します。
5. 変更されたプレゼンテーションを保存します。

この Python コードは、ローカルに保存された動画をプレゼンテーションに追加する方法を示します。

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

あるいは、`add_video_frame(x, y, width, height, fname)` メソッドにファイルパスを直接渡すことで動画を追加することもできます。

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Web ソースからの動画で動画フレームを作成**

Microsoft の新しいバージョンの [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) は、プレゼンテーションでオンライン動画をサポートしています。使用したい動画がオンライン（例: YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) オブジェクトを追加し、動画へのリンクを渡します。
4. 動画フレームのサムネイルを設定します。
5. プレゼンテーションを保存します。

この Python コードは、Web から動画を取得して PowerPoint プレゼンテーションのスライドに追加する方法を示します。

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

## **動画フレームのトリミング**

Aspose.Slides では、[VideoFrame.trim_from_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_start/) および [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_end/) を使用して trim-from-start と trim-from-end の値を設定することで、動画の再生部分を制御できます。両方の値はミリ秒で指定され、動画の開始部と終了部からそれぞれスキップする時間を定義します。これらの設定はプレゼンテーション内の動画再生設定を変更しますが、埋め込まれた動画のバイナリデータをカットしたり変更したりはしません。

**トリム設定を設定**

動画フレームを作成し、トリム設定を行うには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションに [Video](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/) オブジェクトを追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを追加します。
4. [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_start/) と [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_end/) を使用して trim-from-start と trim-from-end の値を設定します。
5. 変更されたプレゼンテーションを保存します。

以下のコード例は、埋め込み動画の再生時に最初の 2.5 秒と最後の 1 秒をスキップします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**トリム設定の読み取り**

既存のトリム設定を確認するには、プレゼンテーションをロードし、最初のスライドのシェイプの中から [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを見つけ、[VideoFrame.trim_from_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_start/) と [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/trim_from_end/) を通じて値を取得します。

以下のコード例は、最初のスライド上の最初の動画フレームを見つけ、ミリ秒単位でトリム設定を報告します。

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **動画キャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションの動画フレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[VideoFrame.caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) プロパティを介して取得できます。

**動画フレームにキャプションを追加**

動画フレームにキャプションを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーションに動画を追加します。
3. スライドに [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを追加します。
4. [caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) が返す [CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) を使用して WebVTT キャプショントラックを追加します。
5. 変更されたプレゼンテーションを保存します。

以下のコードは、動画フレームにキャプションを追加する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT ファイルから新しいキャプショントラックを追加します。
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**動画フレームからキャプションを抽出**

動画フレームからキャプションを抽出するには、次の手順を実行します。

1. 動画が含まれるプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを見つけます。
3. [caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/caption_tracks/) コレクションを列挙します。
4. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、動画フレームからキャプションを抽出する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # キャプショントラックを WebVTT ファイルに保存します。
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

各 [Captions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

**動画フレームからキャプションを削除**

動画フレームからキャプションを削除するには、次の手順を実行します。

1. 動画が含まれるプレゼンテーションをロードします。
2. 対象の [VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトを取得します。
3. [CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) からキャプショントラックを削除します。
4. 変更されたプレゼンテーションを保存します。

以下のコードは、動画フレームからすべてのキャプションを削除する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 型: slides.VideoFrame

    # ビデオフレームからすべてのキャプションを削除します。
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

1 つのキャプショントラックだけを削除する必要がある場合は、[clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/clear/) の代わりに [remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove/) または [remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove_at/) メソッドを使用してください。

## **スライドから動画を抽出**

スライドに動画を追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

1. 動画が含まれるプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [Slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) オブジェクトを列挙します。
3. すべての [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) を探します。
4. 動画をディスクに保存します。

この Python コードは、プレゼンテーションのスライド上の動画を抽出する方法を示します。

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

**VideoFrame の動画再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）とループ設定は、[playback mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/play_mode/) と [looping](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/play_loop_mode/) で制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/) オブジェクトのプロパティを通じて利用可能です。

**動画を追加すると PPTX ファイルのサイズに影響がありますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、ファイルサイズに比例してプレゼンテーションのサイズが増加します。オンライン動画を追加する場合は、リンクとサムネイルが埋め込まれるだけなので、サイズの増加は小さくなります。

**既存の VideoFrame の動画を位置やサイズを変えずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/python-net/aspose.slides/videoframe/embedded_video/) を入れ替えることで、シェイプの形状を保持したまま動画を置き換えることができます。これは、既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれた動画のコンテンツタイプ（MIME）を判別できますか？**

はい。埋め込まれた動画には [content type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/video/content_type/) があり、読み取って使用できます。たとえばディスクに保存する際などに利用できます。