---
title: Python を使用してプレゼンテーションのオーディオを管理する
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
- ショー中に非表示
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

## **オーディオ フレームの作成**

Aspose.Slides for Python via .NET を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイルのストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [再生モード](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) と `Volume` を [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) オブジェクトで設定します。
6. 変更されたプレゼンテーションを保存します。

この Python コードは、スライドに埋め込みオーディオ フレームを追加する方法を示します：
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # wav 音声ファイルをストリームに読み込む
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # オーディオ フレームを追加
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # オーディオの再生モードと音量を設定
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPoint ファイルを書き込み
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```


## **オーディオ フレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（以下のセクションの画像を参照）。オーディオ フレームのサムネイルを変更できます（好みの画像を設定）。

この Python コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # スライドに指定した位置とサイズでオーディオ フレームを追加します。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # プレゼンテーションのリソースに画像を追加します。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # オーディオ フレームの画像を設定します。
        audioFrame.picture_format.picture.image = audioImage
        
        #修正したプレゼンテーションをディスクに保存します
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for Python via .NET を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生を設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:
![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) プロパティに対応しています：
- **開始** ドロップダウン リストは [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) プロパティに対応しています
- **音量** は [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) プロパティに対応しています
- **スライド全体で再生** は [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) プロパティに対応しています
- **停止までループ** は [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) プロパティに対応しています
- **ショー中に非表示** は [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) プロパティに対応しています
- **再生後に巻き戻し** は [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) プロパティに対応しています

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) プロパティに対応しています：
- **フェードイン** は [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) プロパティに対応しています
- **フェードアウト** は [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) プロパティに対応しています
- **オーディオ開始時間のトリム** は [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) プロパティに対応しています
- **オーディオ終了時間のトリム** の値は、オーディオの長さから [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) プロパティの値を引いたものと等しくなります

PowerPoint のオーディオ コントロール パネル上の **Volume controll** は、[AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) プロパティに対応しています。これにより、音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです：
1. [作成](#create-audio-frame) または Audio Frame を取得します。
2. 調整したい Audio Frame プロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この Python コードは、オーディオのオプションを調整する操作を示します：
```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame シェイプを取得します
    audioFrame = pres.slides[0].shapes[0]

    # 再生モードをクリックで再生に設定
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # ボリュームを低に設定
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # オーディオをスライド全体で再生するように設定
    audioFrame.play_across_slides = True

    # オーディオのループを無効化
    audioFrame.play_loop_mode = False

    # スライドショー中に AudioFrame を非表示にする
    audioFrame.hide_at_showing = True

    # 再生後にオーディオを最初に巻き戻す
    audioFrame.rewind_audio = True

    # PowerPoint ファイルをディスクに保存
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


この Python の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングし、フェード時間を設定する方法を示します：
```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # トリミング開始オフセットを1.5秒に設定します
    audio_frame.trim_from_start = 1500.0
    # トリミング終了オフセットを2秒に設定します
    audio_frame.trim_from_end = 2000.0

    # フェードインの期間を200ミリ秒に設定します
    audio_frame.fade_in_duration = 200.0
    # フェードアウトの期間を500ミリ秒に設定します
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```


以下のコードサンプルは、埋め込みオーディオ付きのオーディオ フレームを取得し、音量を 85% に設定する方法を示します：
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # オーディオ フレーム シェイプを取得します
    audio_frame = pres.slides[0].shapes[0]

    # オーディオの音量を85%に設定します
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **オーディオの抽出**

Aspose.Slides for Python via .NET を使用すると、スライド ショーの切り替えで使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドのスライドショー切り替えにアクセスします。
4. サウンドをバイト データとして抽出します。

この Python コードは、スライドで使用されるオーディオを抽出する方法を示します：
```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 対象のスライドにアクセスします
    slide = pres.slides[0]  

    # スライドのスライドショー遷移効果を取得します
    transition = slide.slide_show_transition

    #バイト配列としてサウンドを抽出します
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増大させずに済みますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) に 1 回だけ追加し、その既存アセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が防止され、プレゼンテーションのサイズが適切に保たれます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、[embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) オブジェクトをプレゼンテーションの [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) から別のものと入れ替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている基盤となるオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整し、元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションから引き続きアクセスできます。