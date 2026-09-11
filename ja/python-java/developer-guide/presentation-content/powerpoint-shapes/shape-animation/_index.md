---
title: Python via Java を使用したプレゼンテーションでシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/python-java/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーションシェイプ
- アニメーションテキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクトサウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、シェイプ アニメーション、タイミング、サウンド、アフターアニメーション動作、アニメーションテキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java は、スライドアニメーションをスライドタイムライン上のエフェクトとして表現します。エフェクトは対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、およびサウンドやアフターアニメーション動作などのオプションプロパティを持ちます。

タイムラインには次の 2 種類のシーケンスがあります。

- **メインシーケンス** はスライドが進行するにつれて再生されます。
- **インタラクティブシーケンス** はトリガーシェイプがクリックされたときに開始します。

テキストボックス、画像、チャート、表、その他のスライドオブジェクトはすべて [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) から派生するため、ほとんどのスライドコンテンツに対して同じ [Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effecttype/) クラスに一覧化されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメインシーケンスを取得し、対象シェイプ、エフェクトタイプ、サブタイプ、トリガーを指定して [Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合、そのシェイプをトリガーとしたインタラクティブシーケンスを作成します。

以下のサンプルは 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

トリガーはエフェクト開始時期を制御します。

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effecttriggertype/#OnClick) はメインシーケンスではクリック待ち、インタラクティブシーケンスではトリガーシェイプのクリック待ちです。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effecttriggertype/#WithPrevious) は直前のエフェクトと同時に開始します。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effecttriggertype/#AfterPrevious) は直前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプに対してアニメーションを付ける場合は、`target_shape` の代わりにそのオブジェクトを [Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) に渡します。チャート固有のグループ化オプションについては、[Animated Charts](/slides/ja/python-java/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は、[Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#getEffectsByShape) を使用します。すべてのエフェクトを調べるには、メインシーケンスとすべてのインタラクティブシーケンスを列挙します。列挙することで、シーケンスのインデックス `0` にエフェクトが必ずあるという前提を避けられます。

以下のサンプルは、メインシーケンスとインタラクティブシーケンスのエフェクトを持つシェイプを作成し、そのシェイプを対象としたエフェクトを取得した後、スライド上のすべてのシーケンスを列挙します。

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

特定のシェイプだけのエフェクトが必要な場合は、名前、プレースホルダータイプ、または他の安定したプロパティでシェイプを特定してから [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#getEffectsByShape) を呼び出します。[ShapeCollection.get_Item](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#get_Item) のインデックス `0` が常に目的のオブジェクトであると想定しないでください。

## **継承プレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウトスライドやマスタースライド上の対応するプレースホルダーからアニメーション動作を継承できます。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getBasePlaceholder) は親プレースホルダーを返し、親が存在しない場合は `None` を返します。

以下の例示プレゼンテーションでは、フッターが通常スライドで **Random Bars**、レイアウトスライドで **Split**、マスタースライドで **Fly In** のアニメーションを持ちます。

![通常スライド上のフッター アニメーション効果](slide-shape-animation.png)

![レイアウトスライド上のフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新規プレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、および通常スライド上の対応プレースホルダーにエフェクトを追加します。すべての [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getBasePlaceholder) 呼び出しは、返されたシェイプを使用する前にチェックされます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **アニメーションタイミングの変更**

PowerPoint の **Timing** ダイアログは [Timing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/) のプロパティにマッピングされます。

![アニメーションエフェクトの PowerPoint Timing ダイアログ](shape-animation.png)

- **Start** は [Timing.getTriggerType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getTriggerType) に対応します。
- **Duration** は [Timing.getDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getDuration)（秒）に対応します。
- **Delay** は [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getTriggerDelayTime)（秒）に対応します。
- **Repeat** は [Timing.getRepeatCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatUntilNextClick) または [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) に対応します。
- **Rewind when done playing** は [Timing.getRewind](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRewind) に対応します。

この独立した例はエフェクトを追加し、[Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを介してタイミングを変更し、結果を保存します。返された [Effect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/) 参照を保持することで、不要なコレクションインデックス取得を回避します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

繰り返しモードは意図的に 1 つだけ使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアによっては混乱を招く結果になることがあります。繰り返しモードを変更する際は、[Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#setRepeatUntilNextClick) と [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) を [Timing.setRepeatCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#setRepeatCount) の前に設定してください。いずれかのフラグを設定すると、アクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーションエフェクトは [Effect.getSound](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getSound) を通じて埋め込み音声を参照できます。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#setStopPreviousSound) は、前のエフェクトで開始された音声を停止させるよう指示します。

### **エフェクトにサウンドを追加する**

以下の例はローカルの音声ファイル `animation-sound.wav` を想定しています。2 つのエフェクトを作成し、最初のエフェクトにそのファイルをサウンドとして埋め込み、2 番目のエフェクトでサウンドを停止するよう構成します。[Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを使用するため、シーケンスインデックスは不要です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **埋め込みエフェクトサウンドの抽出**

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を想定しています。メインシーケンスとインタラクティブシーケンスの両方を走査し、埋め込みエフェクトサウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [Audio.getContentType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audio/#getContentType) で取得できるオーディオ MIME タイプから選択されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

大きなオーディオオブジェクトの場合は、[Audio.getStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/audio/#getStream) を使用してストリームをファイルにコピーし、全体をバイト配列に読み込むのを避けてください。

## **アフターアニメーション動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプに何が起こるかを制御します。

![After animation 設定を示す PowerPoint Effect Options ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/afteranimationtype/) クラスは、シェイプをそのまま残す、色を変更する、アニメーション後に非表示にする、または次のクリックで非表示にする、という動作をサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/python-java/aspose.slides/afteranimationtype/#Color) の場合は、[Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getAfterAnimationColor) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクトオブジェクトを介してアフターアニメーション動作を設定し、結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/python-java/aspose.slides/afteranimationtype/#Color) 以外のタイプに変更すると、アフターアニメーションの色設定はクリアされます。

## **テキスト アニメーション**

テキストアニメーションには 2 つの関連コントロールがあります。

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textanimation/#getBuildType) は段落単位で表示するか、全体で表示するかを制御します。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getAnimateTextType) はテキストを一括、単語単位、文字単位で表示するかを制御します。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getDelayBetweenTextParts) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキストボックス内の単語を順番にアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/buildtype/#AsOneObject) を使用すると段落単位のビルドが無効になり、単語設定がテキストフレーム全体に適用されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テキストボックスを段落単位でビルドしたい場合は、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/python-java/aspose.slides/buildtype/#ByLevelParagraphs1)（または他の段落レベル）を設定します。単一段落に対して独自のエフェクトを付けたい場合は、[Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を受け取るオーバーロードの [Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) を使用してください。段落レベルの例については [Animated Text](/slides/ja/python-java/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX への保存はアニメーションモデルを保持しますが、最終的な再生はプレゼンテーションビューアが制御します。
- PDF および静止画像はアニメーションを再生しません。動きを示す必要がある場合は、[HTML5 エクスポート](/slides/ja/python-java/export-to-html5/)、アニメーション GIF、または [動画変換](/slides/ja/python-java/convert-powerpoint-to-video/) を使用してください。
- HTML5 では [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateShapes) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateTransitions) を設定してください。
- 動画レンダリングは多くの一般的な入場、強調、退出、モーションパス効果をサポートしますが、すべての PowerPoint 効果がサポートされているわけではありません。現在の [supported animations and effects](/slides/ja/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- 高度なカスタム効果や他のプレゼンテーション形式からインポートされた効果はファイル内に保持される場合がありますが、PowerPoint、HTML5、または動画では異なる表示になることがあります。効果名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**PowerPoint ではアニメーションが表示されるのに PDF では表示されないのはなぜですか？**

PDF は静的フォーマットであるため、アニメーションやスライド遷移は再生されません。動きを保持する必要がある場合は HTML5、アニメーション GIF、または動画にエクスポートしてください。

**動画でエフェクトの再生が異なるのはなぜですか？**

動画エクスポートはアニメーションを実際にレンダリングして保存するため、元の PowerPoint の動作そのものは保持されません。高度な効果の一部は未サポートまたは近似処理されます。サポートされている効果の一覧を確認し、実際のプレゼンテーションをテストしてから本番で使用してください。

**シェイプを前面または背面に移動するとアニメーション順序が変わりますか？**

いいえ。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーションの再生順序を制御します。再生順序を変更したい場合はタイムラインを調整してください。