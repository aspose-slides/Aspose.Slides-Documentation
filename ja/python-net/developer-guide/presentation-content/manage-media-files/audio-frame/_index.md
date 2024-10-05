---
title: オーディオフレーム
type: docs
weight: 10
url: /python-net/audio-frame/
keywords: "オーディオを追加, オーディオフレーム, オーディオプロパティ, オーディオを抽出, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにオーディオを追加する"
---

## **オーディオフレームの作成**
Aspose.Slides for Python via .NETを使用すると、スライドにオーディオファイルを追加できます。オーディオファイルはオーディオフレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに埋め込みたいオーディオファイルストリームをロードします。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)オブジェクトから公開されている[PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset)と`Volume`を設定します。
6. 修正したプレゼンテーションを保存します。

このPythonコードは、スライドに埋め込まれたオーディオフレームを追加する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # wavサウンドファイルをストリームに読み込み
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # オーディオフレームを追加
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # オーディオの再生モードと音量を設定
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPointファイルをディスクに書き込む
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオフレームサムネイルの変更**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（以下のセクションの画像を参照）。オーディオフレームのサムネイル（好みの画像を設定）を変更します。

このPythonコードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 指定した位置とサイズでスライドにオーディオフレームを追加します。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # プレゼンテーションリソースに画像を追加します。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # オーディオフレームの画像を設定します。
        audioFrame.picture_format.picture.image = audioImage
        
        # 修正されたプレゼンテーションをディスクに保存します
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオ再生オプションの変更**

Aspose.Slides for Python via .NETを使用すると、オーディオの再生またはプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、オーディオをループ再生したり、オーディオアイコンを隠すことができます。

Microsoft PowerPointの**オーディオオプション**ウィンドウ：

![example1_image](audio_frame_0.png)

PowerPointのオーディオオプションは、Aspose.Slidesの[AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに対応しています：
- オーディオオプションの**開始**ドロップダウンリストは[AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致
- オーディオオプションの**音量**は[AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致
- オーディオオプションの**スライド間再生**は[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致
- オーディオオプションの**停止までループ**は[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致
- オーディオオプションの**スライドショー中に非表示**は[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致
- オーディオオプションの**再生後に巻き戻す**は[AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)プロパティに一致 

これがオーディオ再生オプションを変更する手順です：

1. [オーディオフレームの作成](#create-audio-frame)または取得します。
2. 調整したいオーディオフレームプロパティの新しい値を設定します。
3. 修正したPowerPointファイルを保存します。

このPythonコードは、オーディオのオプションを調整する操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame形状を取得
    audioFrame = pres.slides[0].shapes[0]

    # 再生モードをクリック時に再生に設定
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 音量を低に設定
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # スライド間で再生するように設定
    audioFrame.play_across_slides = True

    # オーディオのループを無効にする
    audioFrame.play_loop_mode = False

    # スライドショー中にAudioFrameを隠す
    audioFrame.hide_at_showing = True

    # 再生後にオーディオを巻き戻す
    audioFrame.rewind_audio = True

    # PowerPointファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **オーディオの抽出**
Aspose.Slides for Python via .NETを使用すると、スライドショーのトランジションで使用された音声を抽出できます。たとえば、特定のスライドで使用された音声を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを通じて関連するスライドの参照を取得します。
3. スライドのスライドショートランジションにアクセスします。
4. バイナリデータとして音声を抽出します。

このPythonコードは、スライドで使用されるオーディオを抽出する方法を示しています：

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 必要なスライドにアクセス
    slide = pres.slides[0]  

    # スライドのスライドショー遷移効果を取得
    transition = slide.slide_show_transition

    # バイト配列に音声を抽出
    audio = transition.sound.binary_data

    print("長さ: " + str(len(audio)))
```