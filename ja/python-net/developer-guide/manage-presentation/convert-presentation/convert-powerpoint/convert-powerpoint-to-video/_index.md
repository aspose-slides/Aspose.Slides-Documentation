---
title: Python でプレゼンテーションをビデオに変換する
linktitle: プレゼンテーションをビデオに
type: docs
weight: 130
url: /ja/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint をビデオに
- OpenDocument をビデオに
- PowerPoint をビデオに変換
- プレゼンテーションをビデオに
- プレゼンテーションをビデオに変換
- PPT をビデオに
- PPT をビデオに変換
- PPTX をビデオに
- PPTX をビデオに変換
- ODP をビデオに
- ODP をビデオに変換
- PowerPoint を MP4 に
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に
- プレゼンテーションを MP4 に変換
- PPT を MP4 に
- PPT を MP4 に変換
- PPTX を MP4 に
- PPTX を MP4 に変換
- PowerPoint をビデオに変換
- プレゼンテーションをビデオに変換
- PPT をビデオに変換
- PPTX をビデオに変換
- ODP をビデオに変換
- Python ビデオ変換
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Python を使用して PowerPoint および OpenDocument プレゼンテーションをビデオに変換する方法を学びましょう。サンプルコードと自動化のテクニックを紹介し、ワークフローを効率化します。"
---

PowerPointプレゼンテーションを動画に変換すると、次のメリットがあります。

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションと比べて、すべてのデバイス（プラットフォームに関係なく）はデフォルトで動画プレーヤーを搭載しているため、ユーザーは動画を開くまたは再生するのが容易です。
* **リーチの拡大:** 動画を通じて、プレゼンテーションでは退屈に感じるかもしれない情報を、大規模なオーディエンスに届けることができます。多くの調査や統計によれば、人々は他の形式のコンテンツよりも動画を視聴し消費することが多く、一般的にそのようなコンテンツを好みます。

{{% alert color="primary" %}} 

このプロセスのライブかつ効果的な実装である[**PowerPointを動画に変換するオンラインコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word)をチェックすることをお勧めします。

{{% /alert %}} 

## **Aspose.SlidesにおけるPowerPointから動画への変換**

[Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)では、プレゼンテーションから動画への変換のサポートを実装しました。

* Aspose.Slidesを使用して、特定のFPS（フレーム毎秒）に対応するフレームのセット（プレゼンテーションスライドから）を生成します。
* ffmpegのようなサードパーティユーティリティを使用して、フレームに基づいて動画を作成します。

### **PowerPointを動画に変換**

1. pip installコマンドを使用して、Aspose.Slidesをプロジェクトに追加します：
   * `pip install Aspose.Slides==24.4.0`を実行します。
2. ffmpegを[こちら](https://ffmpeg.org/download.html)からダウンロードするか、パッケージマネージャーを介してインストールします。
3. ffmpegが`PATH`に含まれていることを確認してください。そうでない場合は、バイナリへのフルパスを使用してffmpegを起動します（例：Windowsでは`C:\ffmpeg\ffmpeg.exe`、Linuxでは`/opt/ffmpeg/ffmpeg`）。
4. PowerPointから動画へのコードを実行します。

このPythonコードは、（図と2つのアニメーション効果を含む）プレゼンテーションを動画に変換する方法を示しています：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **動画効果**

スライド上のオブジェクトにアニメーションを適用し、スライド間にトランジションを使用することができます。

{{% alert color="primary" %}} 

これらの記事を参照することをお勧めします：[PowerPointアニメーション](https://docs.aspose.com/slides/python-net/powerpoint-animation/)、[シェイプアニメーション](https://docs.aspose.com/slides/python-net/shape-animation/)、および[シェイプ効果](https://docs.aspose.com/slides/python-net/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションは、スライドショーをより魅力的で興味深いものにします。そして、動画でも同じことができます。前のプレゼンテーション用のコードに別のスライドとトランジションを追加しましょう：

```python
import aspose.pydrawing as drawing
# スマイルシェイプを追加しアニメーションします
# ...
# 新しいスライドとアニメーションされたトランジションを追加します

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slidesはテキストのアニメーションもサポートしています。そのため、オブジェクト上の段落をアニメーション化し、1秒の遅延で次々に表示されるようにします：

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # テキストとアニメーションを追加します
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides for .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("テキスト付きPowerPointプレゼンテーションを動画に変換"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("段落ごとに"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # フレームを動画に変換します
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **動画変換クラス**

PowerPointから動画への変換タスクを実行できるように、Aspose.Slidesは[PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/)を提供します。

PresentationEnumerableAnimationsGeneratorを使用すると、後で作成される動画のフレームサイズとFPS値（フレーム毎秒）をコンストラクターを介して設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用されます。

プレゼンテーション内のすべてのアニメーションを同時に再生するには、PresentationEnumerableAnimationsGenerator.enumerate_framesメソッドを使用します。このメソッドはスライドのコレクションを取り、[EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/)を順に取得できるようにします。その後、EnumerableFrameArgs.get_frame()を使用して動画フレームを取得できます：

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

生成されたフレームは動画を生成するためにコンパイルできます。詳細は[PowerPointを動画に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video)のセクションを参照ください。

## **サポートされているアニメーションと効果**

**登場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **現れる** | ![未対応](x.png) | ![対応](v.png) |
| **フェード** | ![対応](v.png) | ![対応](v.png) |
| **フライイン** | ![対応](v.png) | ![対応](v.png) |
| **フロートイン** | ![対応](v.png) | ![対応](v.png) |
| **スプリット** | ![対応](v.png) | ![対応](v.png) |
| **ワイプ** | ![対応](v.png) | ![対応](v.png) |
| **形状** | ![対応](v.png) | ![対応](v.png) |
| **ホイール** | ![対応](v.png) | ![対応](v.png) |
| **ランダムバー** | ![対応](v.png) | ![対応](v.png) |
| **成長＆回転** | ![未対応](x.png) | ![対応](v.png) |
| **ズーム** | ![対応](v.png) | ![対応](v.png) |
| **スイベル** | ![対応](v.png) | ![対応](v.png) |
| **バウンス** | ![対応](v.png) | ![対応](v.png) |

**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **パルス** | ![未対応](x.png) | ![対応](v.png) |
| **カラーパルス** | ![未対応](x.png) | ![対応](v.png) |
| **ティーター** | ![対応](v.png) | ![対応](v.png) |
| **スピン** | ![対応](v.png) | ![対応](v.png) |
| **成長/縮小** | ![未対応](x.png) | ![対応](v.png) |
| **脱色** | ![未対応](x.png) | ![対応](v.png) |
| **暗くする** | ![未対応](x.png) | ![対応](v.png) |
| **明るくする** | ![未対応](x.png) | ![対応](v.png) |
| **透明度** | ![未対応](x.png) | ![対応](v.png) |
| **オブジェクトカラー** | ![未対応](x.png) | ![対応](v.png) |
| **補色** | ![未対応](x.png) | ![対応](v.png) |
| **ラインカラー** | ![未対応](x.png) | ![対応](v.png) |
| **フィルカラー** | ![未対応](x.png) | ![対応](v.png) |

**退出**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消える** | ![未対応](x.png) | ![対応](v.png) |
| **フェード** | ![対応](v.png) | ![対応](v.png) |
| **フライアウト** | ![対応](v.png) | ![対応](v.png) |
| **フロートアウト** | ![対応](v.png) | ![対応](v.png) |
| **スプリット** | ![対応](v.png) | ![対応](v.png) |
| **ワイプ** | ![対応](v.png) | ![対応](v.png) |
| **形状** | ![対応](v.png) | ![対応](v.png) |
| **ランダムバー** | ![対応](v.png) | ![対応](v.png) |
| **縮小＆回転** | ![未対応](x.png) | ![対応](v.png) |
| **ズーム** | ![対応](v.png) | ![対応](v.png) |
| **スイベル** | ![対応](v.png) | ![対応](v.png) |
| **バウンス** | ![対応](v.png) | ![対応](v.png) |

**モーションパス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![対応](v.png) | ![対応](v.png) |
| **アーク** | ![対応](v.png) | ![対応](v.png) |
| **ターン** | ![対応](v.png) | ![対応](v.png) |
| **形状** | ![対応](v.png) | ![対応](v.png) |
| **ループ** | ![対応](v.png) | ![対応](v.png) |
| **カスタムパス** | ![対応](v.png) | ![対応](v.png) |

## **サポートされているスライド遷移効果**

**穏やか**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **モーフ** | ![未対応](x.png) | ![対応](v.png) |
| **フェード** | ![対応](v.png) | ![対応](v.png) |
| **プッシュ** | ![対応](v.png) | ![対応](v.png) |
| **プル** | ![対応](v.png) | ![対応](v.png) |
| **ワイプ** | ![対応](v.png) | ![対応](v.png) |
| **スプリット** | ![対応](v.png) | ![対応](v.png) |
| **公開** | ![未対応](x.png) | ![対応](v.png) |
| **ランダムバー** | ![対応](v.png) | ![対応](v.png) |
| **形状** | ![未対応](x.png) | ![対応](v.png) |
| **露わにする** | ![未対応](x.png) | ![対応](v.png) |
| **カバー** | ![対応](v.png) | ![対応](v.png) |
| **フラッシュ** | ![対応](v.png) | ![対応](v.png) |
| **ストリップス** | ![対応](v.png) | ![対応](v.png) |

**エキサイティング**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **倒れる** | ![未対応](x.png) | ![対応](v.png) |
| **ドレープ** | ![未対応](x.png) | ![対応](v.png) |
| **カーテン** | ![未対応](x.png) | ![対応](v.png) |
| **風** | ![未対応](x.png) | ![対応](v.png) |
| **プレステージ** | ![未対応](x.png) | ![対応](v.png) |
| **破損** | ![未対応](x.png) | ![対応](v.png) |
| **圧縮** | ![未対応](x.png) | ![対応](v.png) |
| **剥がす** | ![未対応](x.png) | ![対応](v.png) |
| **ページカール** | ![未対応](x.png) | ![対応](v.png) |
| **飛行機** | ![未対応](x.png) | ![対応](v.png) |
| **折り紙** | ![未対応](x.png) | ![対応](v.png) |
| **溶解** | ![対応](v.png) | ![対応](v.png) |
| **チェッカーボード** | ![未対応](x.png) | ![対応](v.png) |
| **ブラインド** | ![未対応](x.png) | ![対応](v.png) |
| **時計** | ![対応](v.png) | ![対応](v.png) |
| **波紋** | ![未対応](x.png) | ![対応](v.png) |
| **ハニカム** | ![未対応](x.png) | ![対応](v.png) |
| **グリッター** | ![未対応](x.png) | ![対応](v.png) |
| **渦** | ![未対応](x.png) | ![対応](v.png) |
| **シュレッド** | ![未対応](x.png) | ![対応](v.png) |
| **スイッチ** | ![未対応](x.png) | ![対応](v.png) |
| **フリップ** | ![未対応](x.png) | ![対応](v.png) |
| **ギャラリー** | ![未対応](x.png) | ![対応](v.png) |
| **キューブ** | ![未対応](x.png) | ![対応](v.png) |
| **ドア** | ![未対応](x.png) | ![対応](v.png) |
| **箱** | ![未対応](x.png) | ![対応](v.png) |
| **コーム** | ![未対応](x.png) | ![対応](v.png) |
| **ズーム** | ![対応](v.png) | ![対応](v.png) |
| **ランダム** | ![未対応](x.png) | ![対応](v.png) |

**ダイナミックコンテンツ**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **パン** | ![未対応](x.png) | ![対応](v.png) |
| **観覧車** | ![対応](v.png) | ![対応](v.png) |
| **コンベア** | ![未対応](x.png) | ![対応](v.png) |
| **回転** | ![未対応](x.png) | ![対応](v.png) |
| **軌道** | ![未対応](x.png) | ![対応](v.png) |
| **通過する** | ![対応](v.png) | ![対応](v.png) |