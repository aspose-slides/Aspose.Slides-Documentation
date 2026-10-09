---
title: "Pythonでプレゼンテーションのビデオフレームを管理する"
linktitle: "ビデオフレーム"
type: docs
weight: 10
url: /ja/python-net/video-frame/
keywords:
- "ビデオを追加"
- "ビデオを作成"
- "ビデオを埋め込む"
- "ビデオを抽出"
- "ビデオを取得"
- "ビデオフレーム"
- "ウェブソース"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラムで追加および抽出する方法を学びます。簡潔なハウツーガイドです。"
---
## **はじめに**

動画はアイデアの説明や視聴者の関心を引くのに役立ちます。Aspose.Slides for Python via .NET を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカル動画および YouTube などのオンライン動画へのリンクをサポートしています。

動画データと動画フレームを表すために、Aspose.Slides は [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) クラス、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) クラス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したい動画ファイルがローカルに保存されている場合、プレゼンテーションに動画を埋め込むビデオフレームを作成できます。

この例では、既存のプレゼンテーションの最初のスライドにローカル動画を埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままになり、[LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) はプレゼンテーションが使用している間ロックされた状態を維持します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

[add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) にローカル動画のパスを直接渡すこともできます。この例では、新しいプレゼンテーションの最初のスライドに動画を埋め込みます。動画はプレゼンテーションが保存されるまでアクセス可能な状態である必要があります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンライン動画をサポートしています。YouTube 動画などのオンライン動画へのリンクとなるビデオフレームを作成できます。

この例では、YouTube の動画リンクとサムネイルを最初のスライドに追加します。別の動画を使用する場合は、動画識別子を置き換えてください。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 設定は自動再生を要求します。サムネイルのダウンロードと動画の再生にはインターネット接続が必要です。また、プレゼンテーションビューアがオンライン動画の再生をサポートしている必要があります。

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

トレーニング用のプレゼンテーションでは、ソフトウェアデモをフルスクリーンモードで再生し、観客に細部を見せることができます。再生中にこの動作を有効にするには、[full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) を `True` に設定します。

この例では、プレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を検索し、フルスクリーン再生を有効にします。入力プレゼンテーションは、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

フルスクリーン再生は動画の表示方法を制御します。別途、[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) は自動開始かクリック開始かを制御し、[play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) は繰り返し再生するかどうかを制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) に設定します。この例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用のプレゼンテーションでは、デモ動画を最初に戻すことで、講師が再度再生できるようにします。再生が終了した後に動画を最初に戻すには、[rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) を `True` に設定します。

この例では、プレゼンテーションを開き、最初のスライド上の最初の [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) を検索し、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、再生開始をクリックに設定します。入力プレゼンテーションは、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

巻き戻しは動画を再び開始せずに最初に戻します。これに対し、[play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を有効にすると再生が自動的に繰り返されます。動画を最後まで再生させ、再度再生できる状態にしておきたい場合は、ループを無効にしておきます。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) は自動開始かクリック開始かを個別に制御します。この例では [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) を使用し、講師が再生開始のタイミングを制御します。例に示すように、ループ設定の後に再生モードを設定します。巻き戻しは [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) とは独立して機能します。

## **ビデオフレームのトリミング**

[VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) と [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) を使用して、再生時に動画の開始部分または終了部分をスキップできます。両方の値はミリ秒で指定します。トリミングは埋め込まれた動画データを変更せずに再生設定を変更します。

**トリム設定の設定**

この例では、ローカル動画を埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒以上の動画を使用してください。

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

この例では、最初のスライド上の最初のビデオフレームのトリム値をミリ秒単位で出力します。プレゼンテーションには少なくとも1枚のスライドが必要です。そのスライドにビデオフレームがない場合は何も出力されません。前の例では 2500 と 1000 の値が生成されます。

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

Aspose.Slides は PowerPoint プレゼンテーションのビデオフレームに対するクローズドキャプションを管理できます。キャプションは WebVTT 形式で保存され、[VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) プロパティで取得できます。

**ビデオフレームにキャプションを追加**

この例では、ローカル動画を埋め込み、英語というラベルの WebVTT キャプショントラックを追加します。キャプションのタイムスタンプは動画と一致させる必要があります。保存されたプレゼンテーションには動画とキャプションの両方が含まれます。

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

**ビデオフレームからキャプションを抽出**

この例では、最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番で出力ファイルを区別します。コンソールには抽出されたトラック数が表示されます。プレゼンテーションには少なくとも1枚のスライドが必要です。

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

各 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) オブジェクトは、キャプションの識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを提供します。

**ビデオフレームからキャプションを削除**

この例では、最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

1 つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) の代わりに [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) または [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) メソッドを使用してください。

## **スライドからビデオを抽出**

スライドに動画を追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれた動画を抽出することも可能です。

この例では、すべてのスライドから埋め込まれた動画を個別の番号付きバイナリファイルに抽出します。リンクされた動画は埋め込みデータがないためスキップされます。コンソールには各動画の MIME タイプと総数が表示されます。出力は汎用的な `.bin` 拡張子を使用します。必要に応じて、報告されたメディアタイプに合わせて拡張子を変更してください。

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

**ビデオフレームの再生パラメータで変更できる項目は何ですか？**

[playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動またはクリック）と [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) オブジェクトのプロパティから利用できます。

**動画を追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカル動画を埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンライン動画へのリンクとサムネイルを追加する場合、プレゼンテーションは動画データではなくリンクとプレビュー画像を保存するため、サイズ増加は通常小さくなります。

**既存のビデオフレームの動画を位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) を交換すれば、シェイプの形状（位置やサイズ）を保持したまま動画を置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込み動画のコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込み動画には [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) があり、これを読み取って利用できます。たとえば、ディスクに保存する際に使用できます。