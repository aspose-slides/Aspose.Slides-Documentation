---
title: Python を使用したプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/python-net/audio-frame/
keywords:
- オーディオを追加
- オーディオを埋め込む
- オーディオ フレーム
- オーディオ ファイル
- オーディオ プロパティ
- オーディオを抽出
- オーディオを取得
- オーディオを変更
- 再生オプション
- 再生モード
- スライド全体で再生
- 停止までループ
- 再生中に非表示
- 再生後に巻き戻し
- オーディオ ボリューム
- デフォルト画像
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP のオーディオ フレームを簡単に追加、抽出、管理できます。コード例を確認し、プレゼンテーションを今すぐ強化しましょう。"
---
## **オーディオフレームの作成**

Aspose.Slides for Python via .NET を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [IAudioFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/) オブジェクトが提供する [PlayMode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioplaymodepreset) と `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この Python コードは、スライドに埋め込みオーディオ フレームを追加する方法を示します：

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # wav サウンド ファイルをストリームにロード
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # オーディオ フレームを追加
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # オーディオの再生モードと音量を設定
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPoint ファイルをディスクに保存
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオ フレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（下のセクションの画像を参照）。オーディオ フレームのサムネイルを変更できます（好みの画像を設定）。

この Python コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 指定された位置とサイズでスライドにオーディオ フレームを追加します。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # プレゼンテーションのリソースに画像を追加します。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # オーディオ フレームの画像を設定します。
        audioFrame.picture_format.picture.image = audioImage
        
        #変更されたプレゼンテーションをディスクに保存します
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオ再生オプションの変更**

Aspose.Slides for Python via .NET を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** パネル:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/) プロパティに対応しています:

- **Start** ドロップダウン リストは [AudioFrame.play_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/play_mode/) プロパティと一致します
- **Volume** は [AudioFrame.volume](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/volume/) プロパティと一致します
- **Play Across Slides** は [AudioFrame.play_across_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/play_across_slides/) プロパティと一致します
- **Loop until Stopped** は [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/play_loop_mode/) プロパティと一致します
- **Hide During Show** は [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/hide_at_showing/) プロパティと一致します
- **Rewind after Playing** は [AudioFrame.rewind_audio](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/rewind_audio/) プロパティと一致します

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/) プロパティに対応しています:

- **Fade In** は [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/fade_in_duration/) プロパティと一致します
- **Fade Out** は [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/fade_out_duration/) プロパティと一致します
- **Trim Audio Start Time** は [AudioFrame.trim_from_start](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/trim_from_start/) プロパティと一致します
- **Trim Audio End Time** の値は、オーディオの長さから [AudioFrame.trim_from_end](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/trim_from_end/) プロパティの値を引いたものに等しいです

PowerPoint のオーディオ コントロール パネル上の **Volume controll** は [AudioFrame.volume_value](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/volume_value/) プロパティに対応しています。音量をパーセンテージで変更できます。

オーディオ再生オプションを変更する方法は次のとおりです：

1. [Сreate](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この Python コードは、オーディオのオプションを調整する操作を示します：

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame シェイプを取得します
    audioFrame = pres.slides[0].shapes[0]

    # 再生モードをクリック時再生に設定
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # ボリュームを低に設定
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # オーディオをスライド全体で再生するように設定
    audioFrame.play_across_slides = True

    # オーディオのループ再生を無効化
    audioFrame.play_loop_mode = False

    # スライドショー中に AudioFrame を非表示にする
    audioFrame.hide_at_showing = True

    # 再生後にオーディオを開始位置に巻き戻す
    audioFrame.rewind_audio = True

    # PowerPoint ファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

この Python の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示します：

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # トリミング開始オフセットを 1.5 秒に設定
    audio_frame.trim_from_start = 1500.0
    # トリミング終了オフセットを 2 秒に設定
    audio_frame.trim_from_end = 2000.0

    # フェードイン時間を 200 ミリ秒に設定
    audio_frame.fade_in_duration = 200.0
    # フェードアウト時間を 500 ミリ秒に設定
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

次のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示します：

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # オーディオ フレーム シェイプを取得します
    audio_frame = pres.slides[0].shapes[0]

    # オーディオ ボリュームを 85% に設定します
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオ キャプションの管理**

Aspose.Slides を使用すると、[caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/caption_tracks/) プロパティを介してオーディオ フレームにクローズド キャプションを追加できます。このプロパティは [CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) を返し、WebVTT キャプショントラックの追加、既存トラックの列挙、必要に応じた削除が可能です。

**オーディオ キャプションの追加**

[caption_tracks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/caption_tracks/) プロパティを使用して、1 つまたは複数のキャプショントラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、次に `.vtt` ファイルから新しいキャプショントラックをロードします。

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # WebVTT ファイルから新しいキャプショントラックを追加します。
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**オーディオ キャプションの抽出**

オーディオ フレームに関連付けられたキャプショントラックを列挙し、`.vtt` ファイルとして保存できます。各キャプショントラックはバイナリ データと一意の識別子を公開し、キャプションのエクスポート時に使用できます。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # キャプショントラックを .vtt ファイルとして保存します。
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**オーディオ キャプションの削除**

オーディオ フレームからキャプションを削除するには、[CaptionsCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/) が提供するメソッド（[clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/clear/)、[remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove/)、[remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/captionscollection/remove_at/) など）を使用します。以下の例は、オーディオ フレームからすべてのキャプショントラックを削除します。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # audio_frame からすべてのキャプショントラックを削除します。
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオの抽出**

Aspose.Slides for Python via .NET を使用すると、スライドショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

この Python コードは、スライドで使用されるオーディオを抽出する方法を示します：

```python
import aspose.slides as slides

#slides.Presentation("AudioSlide.pptx") を使用
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 対象スライドにアクセス
    slide = pres.slides[0]  

    # スライドのスライドショー遷移効果を取得
    transition = slide.slide_show_transition

    #サウンドをバイト配列で抽出
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**同じオーディオ資産を複数のスライドで再利用して、ファイルサイズを増大させずに済みますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/audios/) に一度追加し、その既存資産を参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズが抑制されます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えられますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/link_path_long/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audioframe/embedded_audio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/audios/) から別のオブジェクトに入れ替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている基礎となるオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションの audio collection を通じてアクセス可能です。