---
title: Python でプレゼンテーションのビデオフレームを管理する
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
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **導入**

ビデオは、アイデアの説明やオーディエンスのエンゲージメントに役立ちます。Aspose.Slides for Python via .NET を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートしています。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) クラス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままになります。これは、[LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) がプレゼンテーションが使用している間ロックしたままにするためです。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

ローカルビデオのパスを直接 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能な状態である必要があります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートしています。YouTube ビデオなどのオンラインビデオへのリンクを持つビデオフレームを作成できます。

この例は、YouTube ビデオへのリンクとサムネイルを最初のスライドに追加します。別のビデオを使用する場合はビデオ識別子を置き換えてください。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 設定は自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアもオンラインビデオ再生をサポートしている必要があります。

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **フルスクリーンモードでビデオを再生**

トレーニング用プレゼンテーションでは、ソフトウェアデモをフルスクリーンモードで再生して観客に詳細を見せることができます。[full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) を `True` に設定すると、再生中にこの動作が有効になります。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を見つけ、フルスクリーン再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

フルスクリーン再生はビデオの表示方法を制御します。別に、[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) は自動開始かクリック開始かを制御し、[play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) は繰り返し再生かどうかを制御します。開始動作を選択するには、[VideoPlayModePreset.AUTO または VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) に再生モードを設定します。この例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションでデモビデオを最初に戻すと、プレゼンターが再び再生できるようになります。[rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) を `True` に設定すると、再生が終了した後にビデオを先頭に戻します。

この例はプレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリックで開始するように設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

巻き戻しはビデオを最初に戻すだけで、再び開始はしません。これに対し、[play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を有効にすると再生が自動的に繰り返されます。ビデオを最後まで再生させてから再度再生できるようにしたい場合は、ループを無効にしてください。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) は自動開始かクリック開始かを個別に制御します。この例は [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) を使用しているため、プレゼンターが再生開始のタイミングを制御できます。ループ設定の後に再生モードを設定してください。巻き戻しは [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) とは独立して機能します。

## **ビデオフレームをトリミング**

[VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) と [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) を使用して、再生時にビデオの開始部または終了部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定の設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るよう、ビデオは 3.5 秒以上の長さである必要があります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**トリム設定の取得**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションに少なくとも1枚のスライドが必要です。そのスライドにビデオフレームがない場合、何も出力されません。前の例は 2500 と 1000 の値を生成します。

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズドキャプションを管理できる機能を提供します。キャプションは WebVTT 形式で保存され、[VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) プロパティを介して取得できます。

### **ビデオフレームにキャプションを追加**

この例はローカルビデオを埋め込み、English とラベル付けされた WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオに合わせる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) クラスは、ストリームからキャプションを追加できるオーバーロードも提供します。

### **ビデオフレームからキャプションを抽出**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番が付与され、出力ファイルが区別されます。コンソールに抽出されたトラック数が表示されます。プレゼンテーションに少なくとも1枚のスライドが必要です。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

各 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

### **ビデオフレームからキャプションを削除**

この例は最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

特定のキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) の代わりに [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) または [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) メソッドを使用してください。

### **ビデオキャプションを検索**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) はヘッダー、タイミング行、キャプションテキストを含む WebVTT トラック全体を返します。たとえば、スライド 2 の英語トラックは次のキューを含む可能性があります。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

この例は `captioned_media.pptx` を開き、各スライド上のすべての最上位ビデオフレームの [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) を読み取ります。プレーンテキストのキューごとに、`-->` を含むタイミング行を見つけ、次の空行またはトラックの終端までのキャプション行を収集します。キャプションテキスト中の “café” を大文字小文字を区別せずに検索し、一致した各項目についてスライド番号、トラックラベル、元のタイミング行、全文キャプションを出力します。

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

サンプルトラックは 1 件の一致を生成します。ヘッダー内の “Café” はキャプションテキストの外側にあり、出力はタイミング設定と両方のキャプション行をそのまま保持します。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

この例はすべてのスライドから埋め込みビデオを個別の番号付きバイナリファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールには各ビデオの MIME タイプと総数が表示されます。出力は汎用の `.bin` 拡張子を使用しますが、必要に応じて報告されたメディアタイプに合わせて変更してください。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**ビデオフレームで変更できるビデオ再生パラメータはどれですか？**

[playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動またはクリック）と [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) オブジェクトのプロパティを介して利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオにリンクしサムネイルを追加する場合、ビデオデータ自体は保存されず、リンクとプレビュー画像のみが保存されるため、サイズ増加は通常小さくなります。

**既存のビデオフレーム内のビデオを位置やサイズを変更せずに差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) を入れ替えることで、シェイプの形状を保持したままビデオを更新できます。これは既存レイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) があり、これを読み取ってディスクに保存する際などに使用できます。