---
title: Python で PowerPoint プレゼンテーションを動画に変換する
linktitle: PowerPoint を動画に変換
type: docs
weight: 130
url: /ja/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint を動画に変換
- PowerPoint を動画に変換
- プレゼンテーションを動画に変換
- プレゼンテーションを動画に変換
- PPT を動画に変換
- PPT を動画に変換
- PPTX を動画に変換
- PPTX を動画に変換
- ODP を動画に変換
- ODP を動画に変換
- PowerPoint を MP4 に変換
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に変換
- プレゼンテーションを MP4 に変換
- PPT を MP4 に変換
- PPT を MP4 に変換
- PPTX を MP4 に変換
- PPTX を MP4 に変換
- PowerPoint の動画変換
- プレゼンテーションの動画変換
- PPT の動画変換
- PPTX の動画変換
- ODP の動画変換
- Python の動画変換
- PowerPoint
- Python
- Aspose.Slides
description: "Python を使用して PowerPoint および OpenDocument プレゼンテーションを動画に変換する方法を学びます。サンプルコードと自動化テクニックを活用してワークフローを効率化しましょう。"
---

## **概要**

PowerPoint または OpenDocument プレゼンテーションを動画に変換することで、次の利点が得られます。

**アクセシビリティの向上:** すべてのデバイスはプラットフォームに関係なくデフォルトで動画プレーヤーを搭載しているため、従来のプレゼンテーションアプリケーションよりも動画の再生や閲覧が容易です。

**リーチの拡大:** 動画はより多くの視聴者にリーチでき、情報を魅力的な形式で提示できます。調査や統計によれば、動画コンテンツを視聴・消費することを人々は他の形態より好むため、メッセージのインパクトが高まります。

{{% alert color="primary" %}} 
[**PowerPointから動画へのオンライン変換ツール**](https://products.aspose.app/slides/video) をぜひご利用ください。ここでは本稿で説明するプロセスのライブかつ効果的な実装例が確認できます。
{{% /alert %}} 

[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) では、プレゼンテーションを動画に変換する機能を実装しました。

* Aspose.Slides for Python を使用して、指定したフレームレート (FPS) でスライドからフレームを生成します。  
* その後、ffmpeg などのサードパーティユーティリティを使用してフレームを動画にまとめます。

## **PowerPoint プレゼンテーションを動画に変換する手順**

1. pip インストールコマンドで Aspose.Slides for Python をプロジェクトに追加します: `pip install aspose-slides==24.4.0`  
2. [here](https://ffmpeg.org/download.html) から ffmpeg をダウンロードするか、パッケージマネージャーでインストールします。  
3. ffmpeg が `PATH` に含まれていることを確認してください。含まれていない場合は、バイナリへのフルパスで ffmpeg を起動します（例: Windows の `C:\ffmpeg\ffmpeg.exe`、Linux の `/opt/ffmpeg/ffmpeg`）。  
4. PowerPoint から動画への変換コードを実行します。

以下の Python コードは、シェイプと 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```


## **動画エフェクト**

Aspose.Slides for Python で PowerPoint プレゼンテーションを動画に変換する際、さまざまな動画エフェクトを適用して出力の視覚品質を向上させることができます。これらのエフェクトにより、スムーズなトランジションやアニメーション、その他の視覚要素を追加して、最終動画でスライドの外観を制御できます。本章では利用可能な動画エフェクトのオプションを説明し、適用方法を示します。

{{% alert color="primary" %}} 
[PowerPoint アニメーション](https://docs.aspose.com/slides/python-net/powerpoint-animation/)、[シェイプ アニメーション](https://docs.aspose.com/slides/python-net/shape-animation/)、および [シェイプ エフェクト](https://docs.aspose.com/slides/python-net/shape-effect/) を参照してください。
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的にし、動画にも同様の効果があります。前のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```python
import aspose.pydrawing as drawing

# 笑顔のシェイプを追加してアニメーションを設定します。
# ...

# 新しいスライドを追加し、アニメーション付きのトランジションを設定します。
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python はテキストアニメーションもサポートしています。以下の例では、オブジェクト上の段落を順番に表示し、各段落の間に 1 秒の遅延を入れています:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # テキストとアニメーションを追加します。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # フレームを動画に変換します。
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **動画変換クラス**

PowerPoint から動画への変換タスクを実現するために、Aspose.Slides for Python は [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/) を提供します。

`PresentationEnumerableFramesGenerator` はコンストラクタで動画のフレームサイズと FPS (1 秒あたりフレーム数) を設定できます。プレゼンテーションのインスタンスを渡すと、その `Presentation.SlideSize` が使用されます。

プレゼンテーション内のすべてのアニメーションを同時に再生させるには、`PresentationEnumerableFramesGenerator.enumerate_frames` メソッドを使用します。このメソッドはスライドコレクションを受け取り、順次 [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/) を返します。その後、`EnumerableFrameArgs.get_frame()` で各動画フレームを取得します。
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


生成されたフレームは動画にコンパイルできます。詳細は [PowerPoint を動画に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) のセクションをご覧ください。

## **サポートされているアニメーションとエフェクト**

PowerPoint プレゼンテーションを動画に変換する際、出力でサポートされるアニメーションとエフェクトを把握しておくことが重要です。Aspose.Slides はフェード、フライイン、ズーム、スピンなどの一般的な出入りおよび強調エフェクトを幅広くサポートしています。ただし、一部の高度なカスタムアニメーションは完全に保持されないか、最終動画で異なる表示になる場合があります。本章ではサポート対象を一覧で示します。

**Entrance（出入り）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Emphasis（強調）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit（終了）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths（モーション パス）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **サポートされているスライド トランジション エフェクト**

動画内でスライド間のスムーズで視覚的に魅力的な切り替えを実現するために、スライド トランジション エフェクトは重要です。Aspose.Slides for Python は、元のプレゼンテーションの流れとスタイルを保持するための一般的なトランジション効果を多数サポートしています。本章では、変換プロセスでサポートされるトランジションをハイライトします。

**Subtle（控えめ）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Exciting（エキサイティング）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamic Content（動的コンテンツ）**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides for Python はパスワード保護されたプレゼンテーションの操作をサポートしています。対象ファイルを処理する際は、正しいパスワードを指定してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

**Aspose.Slides for Python はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides for Python はクラウド アプリケーションやサービスに組み込むことができます。サーバー環境での高パフォーマンスとスケーラビリティを提供し、バッチ処理に適しています。

**変換時のプレゼンテーションサイズに制限はありますか？**

Aspose.Slides for Python は実質的に任意のサイズのプレゼンテーションを処理可能です。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されます。