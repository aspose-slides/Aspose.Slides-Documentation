---
title: PresentationsでPythonを使用してオーディオフレームを管理
linktitle: オーディオフレーム
type: docs
weight: 10
url: /ja/python-net/audio-frame/
keywords:
- オーディオ
- オーディオフレーム
- サムネイル
- オーディオ追加
- オーディオプロパティ
- オーディオオプション
- オーディオ抽出
- WebVTT
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、スライドにオーディオを埋め込み、オーディオアイコンを変更し、再生設定を構成し、WebVTT キャプションを管理し、スライド遷移サウンドを抽出します。"
---
## **概要**

オーディオフレームを使用すると、スライド上でサウンドを再生できます。Aspose.Slides for Python via .NET を使用すると、オーディオクリップを埋め込み、それを表す画像を選択し、再生を調整し、キャプションを添付できます。また、スライド遷移に割り当てられたサウンドを取得することもできます。

## **オーディオフレームの作成**

最初のスライドにローカルオーディオクリップを埋め込むには、[add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) を使用します。最初の 2 つの座標はフレームをスライド上に配置し、次の 2 つの値は幅と高さをポイント単位で設定します。この例では、[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) をクリップの自動開始に、[volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) を大音量のプリセットに設定しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオフレームのサムネイルの変更**

デフォルトでは、オーディオフレームはスピーカーアイコンを表示します。カスタムサムネイルを表示するには、[add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) でプレゼンテーションに画像を追加し、フレームの [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) プロパティに割り当てます。この例では、埋め込みオーディオクリップのサムネイルとして JPEG を使用しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオ再生オプションの変更**

PowerPoint の **Audio Options** コントロールは、クリップの開始タイミング、音量、およびスライドショー中の動作を決定します。

![オーディオフレーム用 PowerPoint オーディオ オプション コントロール](audio_frame_0.png)

| PowerPoint コントロール | Aspose.Slides プロパティ |
| --- | --- |
| 開始 | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| 音量プリセット | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| スライド間で再生 | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| 停止までループ | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| 表示中に非表示 | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| 再生後に巻き戻し | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| フェードイン | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| フェードアウト | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| オーディオ開始位置のトリム | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| オーディオ終了位置のトリム | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| 音量スライダー | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

この例では、最初のスライド上の最初のオーディオフレームを取得し、[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) をクリックで再生開始に設定し、低音量プリセットを選択します。クリップはスライド間で再生を続けますが、ループは無効化されています。アイコンは表示中に隠れ、再生後にクリップは巻き戻されます。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

クリップの長さが 3.5 秒を超える場合、この例は最初の 1.5 秒と最後の 2 秒をスキップします。[trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) はクリップの末尾から除外する長さを測定します。PowerPoint に表示される終了時刻を取得するには、そのオフセットをクリップ全体の長さから引きます。トリミングされたクリップは 200 ミリ秒でフェードインし、500 ミリ秒でフェードアウトします。4 つのプロパティはすべてミリ秒単位の値を取ります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

再生音量を特定のパーセンテージに設定するには、[volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) を使用します。この例は、最初のスライド上の最初のオーディオフレームを 85% に設定しています。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオキャプションの管理**

各オーディオフレームには [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) コレクションがあります。これを使用して WebVTT キャプションをクリップに添付したり、既存のトラックをエクスポートしたり、削除したりできます。

### **オーディオキャプションの追加**

この例は最初のスライドにオーディオクリップを埋め込み、[CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) を使用してローカルの WebVTT トラックを添付します。最初の引数はトラックラベルを提供し、2 番目の引数はタイムスタンプ付きキャプションが含まれるファイルを指定します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **オーディオキャプションの抽出**

この例は最初のスライド上のオーディオフレームに添付された各キャプショントラックをエクスポートします。トラックの [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) を WebVTT ファイルに書き込み、[caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) をファイル名として使用するため、各トラックは個別の出力になります。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **オーディオキャプションの削除**

[remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) または [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) を使用して個別のトラックを削除します。この例は [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) を使用して、クリップを保持しながら最初のスライド上の最初のオーディオフレームからすべてのキャプションを削除しています。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **オーディオキャプション内の行の検索**

最初のスライド上のオーディオキャプションから行を検索するには、各トラックの [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) をメモリ内で読み取ります。プレーンテキストの WebVTT キューでは、タイミング行に `-->` が含まれ、次にキャプション行が続き、空行でキューが終了します。この例はトラックラベルと “café” を含む各キャプション行を出力します。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **オーディオの抽出**

スライド遷移は独自のサウンドを持つことができます。それを取得するには、遷移の [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) プロパティを読み取ります。この例はサウンドの [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) にアクセスし、バイト数でサイズを出力します。最初のスライドに遷移サウンドがない場合は、代わりにメッセージを出力します。

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**同じオーディオクリップを複数のスライドで重複させずに再利用できますか？**

はい。クリップをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) に一度追加し、各スライドで同じオーディオオブジェクトを [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) に渡すだけです。

**既存のオーディオフレームのサウンドを差し替えることはできますか？**

はい。リンクされたサウンドの場合は、[link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) を置換ファイルにポイントするよう更新します。埋め込みサウンドの場合は、プレゼンテーションのオーディオコレクションから別のクリップを [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) に割り当てます。どちらの方法でも既存のフレームは保持されます。

**トリミングはプレゼンテーションに保存されているオーディオデータを変更しますか？**

いいえ。[trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) と [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) は再生範囲の境界を設定します。全クリップは依然として [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) から取得可能です。