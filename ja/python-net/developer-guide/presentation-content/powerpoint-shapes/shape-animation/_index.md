---
title: Python を使用したプレゼンテーションでのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/python-net/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーション を追加
- アニメーション を取得
- アニメーション を抽出
- エフェクト を追加
- エフェクト を取得
- エフェクト を抽出
- エフェクト サウンド
- アニメーション を適用
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、シェイプ アニメーション、タイミング、サウンド、アフター アニメーション 動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

エフェクト内の個々の動作やモーションパス セグメントを編集するには、[Custom Animation](/slides/ja/python-net/custom-animation/) を参照してください。

Aspose.Slides for Python via .NET はスライド アニメーションをスライド タイムライン上のエフェクトとして表します。エフェクトにはターゲット シェイプ、アニメーション タイプとサブタイプ、トリガー、タイミング設定、サウンドやアフター アニメーション 動作などのオプション プロパティがあります。

タイムラインには 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むと再生されます。
- **インタラクティブ シーケンス** はトリガー シェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、テーブル、その他のスライド オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishape/) を実装しているため、ほとんどのスライド コンテンツに対して同じ [Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttype/) 列挙体に一覧表示されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、ターゲット シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトを作成する場合は、そのシェイプをトリガーとするインタラクティブ シーケンスを作成します。

次の例は 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

トリガーはエフェクトの開始タイミングを制御します。

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttriggertype/) はメイン シーケンスでのクリック、またはインタラクティブ シーケンスでのトリガー シェイプのクリックを待機します。
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttriggertype/) は前のエフェクトと同時に開始します。
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttriggertype/) は前のエフェクトが完了したときに開始します。

画像、チャート、またはその他のシェイプ タイプにアニメーションを付ける場合は、`target_shape` の代わりにそのオブジェクトを [Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) に渡します。チャート 固有のグループ化オプションについては、[Animated Charts](/slides/ja/python-net/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

ターゲット シェイプが分かっている場合は、[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) を使用します。すべてのエフェクトを確認するには、メイン シーケンスとすべてのインタラクティブ シーケンスを反復処理します。反復処理により、シーケンスにインデックス `0` のエフェクトが必ず存在するという前提を避けられます。

次の例はメイン シーケンスとインタラクティブ シーケンスのエフェクトを持つシェイプを作成し、対象シェイプのエフェクトを取得してスライド上のすべてのシーケンスを反復します。

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

1 つのシェイプだけのエフェクトが必要な場合は、名前、プレースホルダー タイプ、または他の安定したプロパティでシェイプを特定し、[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) を呼び出します。インデックス `0` のシェイプが常に目的のオブジェクトであると想定しないでください。

## **継承されたプレースホルダー エフェクトの操作**

通常スライド上のプレースホルダーは、レイアウト スライドやマスター スライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[Shape.get_base_placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_base_placeholder/) は親プレースホルダーを返します。親が存在しない場合は `None` を返します。

以下の例示プレゼンテーションでは、フッターは通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスター スライドで **Fly In** が設定されています。

![通常スライドのフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライドのフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスター スライドのフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例はプレースホルダー階層自体を構築します。マスター プレースホルダー、レイアウト プレースホルダー、および通常スライド上の対応するプレースホルダーにエフェクトを追加します。各 [Shape.get_base_placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_base_placeholder/) 呼び出しは、取得したシェイプを使用する前にチェックされます。

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーション タイミングの変更**

PowerPoint の **Timing** ダイアログは [Timing](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/) のプロパティに対応しています。

![アニメーション エフェクトの PowerPoint タイミング ダイアログ](shape-animation.png)

- **Start** は [Timing.trigger_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/trigger_type/) にマップされます。
- **Duration** は秒単位で [Timing.duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/duration/) にマップされます。
- **Delay** は秒単位で [Timing.trigger_delay_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/trigger_delay_time/) にマップされます。
- **Repeat** は [Timing.repeat_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_count/)、[Timing.repeat_until_next_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_next_click/) または [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) にマップされます。
- **Rewind when done playing** は [Timing.rewind](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/rewind/) にマップされます。

この単独の例はエフェクトを追加し、[Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) が返すオブジェクトを通じてタイミングを変更し、結果を保存します。返された [Effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/) 参照を保持することで不要なコレクション インデックス取得を回避できます。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

繰り返しモードは 1 つだけ使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアーによって結果が混乱する可能性があります。繰り返しモードを変更する際は、[Timing.repeat_until_next_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_next_click/) と [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) を先に設定し、最後に [Timing.repeat_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_count/) を設定してください。いずれかのフラグを設定すると、アクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [Effect.sound](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/sound/) を通じて埋め込みオーディオを参照できます。[Effect.stop_previous_sound](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/stop_previous_sound/) は、以前のエフェクトで開始されたオーディオを停止するよう指示します。

### **エフェクトにサウンドを追加する**

次の例はローカルのオーディオ ファイル `animation-sound.wav` が存在することを前提としています。2 つのエフェクトを作成し、最初のエフェクトのサウンドとしてそのファイルを埋め込み、2 番目のエフェクトでサウンドを停止するよう構成します。[Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) が返すオブジェクトを使用するため、シーケンス インデックスは不要です。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **埋め込みエフェクトサウンドの抽出**

次の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` が存在することを前提としています。メイン シーケンスとインタラクティブ シーケンスの両方を走査し、すべての埋め込みエフェクトサウンドを `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [Audio.content_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audio/content_type/) が提供するオーディオ MIME タイプから選択されます。

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

大きなオーディオ オブジェクトの場合は、[Audio.get_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audio/get_stream/) を使用してストリームをファイルにコピーし、バイト配列全体をロードしないようにしてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプに対して行われる処理を制御します。

![After animation 設定を示す PowerPoint エフェクト オプション ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/afteranimationtype/) 列挙体は、シェイプを変更せずに残す、色を変更する、アニメーション後に非表示にする、または次のクリックで非表示にすることをサポートします。タイプが [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/afteranimationtype/) の場合は、[Effect.after_animation_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/after_animation_color/) も設定してください。

この単独の例はエフェクトを作成し、返されたエフェクト オブジェクトを通じてアフター アニメーション 動作を設定し、結果を保存します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

[AfterAnimationType.COLOR](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/afteranimationtype/) 以外のタイプに変更すると、アフター アニメーション の色設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには 2 つの関連コントロールがあります。

- [TextAnimation.build_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/textanimation/build_type/) は段落全体を同時に表示するか、段落レベルで表示するかを制御します。
- [Effect.animate_text_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/animate_text_type/) はテキストをすべて一度に、単語ごと、または文字ごとに表示するかを制御します。[Effect.delay_between_text_parts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/delay_between_text_parts/) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

次の単独例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/buildtype/) を使用すると段落単位のビルドが無効になり、単語設定がテキスト フレーム全体に適用されます。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

段落単位でテキスト ボックスをビルドするには、[BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/buildtype/)（または別の段落レベル）を設定します。単一の段落に独自のエフェクトを適用したい場合は、[IParagraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iparagraph/) を受け取る [Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) のオーバーロードを使用してください。段落レベルの例については [Animated Text](/slides/ja/python-net/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX で保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアーに依存します。
- PDF および静止画像はアニメーションを再生しません。モーションを示す必要がある場合は、[HTML5 エクスポート](/slides/ja/python-net/export-to-html5/)、アニメーション GIF、または [ビデオ変換](/slides/ja/python-net/convert-powerpoint-to-video/) を使用してください。
- HTML5 では [Html5Options.animate_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/html5options/animate_shapes/) を有効にし、必要に応じて [Html5Options.animate_transitions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/html5options/animate_transitions/) も有効にしてください。
- ビデオ レンダリングは多くの一般的な入口、強調、退出、モーション パス エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポートされているアニメーションとエフェクト](/slides/ja/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- カスタム エフェクトや他のプレゼンテーション形式からインポートされたエフェクトはファイル内に保持される場合がありますが、PowerPoint、HTML5、またはビデオでのレンダリングが異なることがあります。エフェクト名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**なぜアニメーションは PowerPoint では表示されるのに PDF では表示されないのですか？**

PDF は静的形式のため、アニメーションやスライド遷移は再生されません。モーションを保持する必要がある場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜビデオでエフェクトの再生が異なるのですか？**

ビデオ エクスポートはアニメーションをレンダリングし、元の PowerPoint 動作を保存しません。一部の高度なエフェクトはサポートされていないか、近似されます。サポートされているエフェクト表を確認し、実際のプレゼンテーションをテストしてから本番で使用してください。

**シェイプを前面または背面に移動するとアニメーションの順序が変わりますか？**

いいえ。シェイプの Z オーダーは重なり順を制御し、シーケンスの順序とトリガーがアニメーションの再生順序を制御します。再生順序を変更する必要がある場合は、タイムラインを調整してください。