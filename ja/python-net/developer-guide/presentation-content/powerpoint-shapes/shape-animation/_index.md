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
- アニメーション化されたシェイプ
- アニメーション化されたテキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法をご紹介します。際立ちましょう！
---
  
アニメーションは、テキスト、画像、シェイプ、または[チャート](/slides/ja/python-net/animated-charts/)に適用できる視覚エフェクトです。プレゼンテーションやその構成要素に命を吹き込みます。  

## **プレゼンテーションでアニメーションを使用する理由**

- 情報の流れを制御する  
- 重要なポイントを強調する  
- 聴衆の関心や参加意欲を高める  
- コンテンツを読みやすく、理解しやすく、処理しやすくする  
- 聴衆の注意をプレゼンテーションの重要部分に向ける  

PowerPoint は、**開始**、**終了**、**強調**、**モーション パス** カテゴリにわたるアニメーションやアニメーション エフェクトの多くのオプションとツールを提供します。  

## **Aspose.Slides のアニメーション**

- Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間でアニメーションを操作するために必要なクラスと型を提供します。  
- Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙体で **150 以上のアニメーション エフェクト** を提供します。これらのエフェクトは、実質的に PowerPoint で使用される同等のエフェクトです。  

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Python via .NET を使用すると、シェイプ内のテキストにアニメーションを適用できます。  

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。  
4. `IAutoShape.TextFrame` にテキストを追加します。  
5. メイン シーケンス (effects) を取得します。  
6. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) にアニメーション エフェクトを追加します。  
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。  

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

テキストへのアニメーション適用に加えて、単一の[段落](/slides/ja/python-net/aspose.slides/iparagraph/) にもアニメーションを適用できます。**アニメーション テキスト**をご覧ください。  

{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加するか取得します。  
4. メイン シーケンスを取得します。  
5. [PictureFrame] にアニメーション エフェクトを追加します。  
6. PPTX ファイルとしてディスクに保存します。  

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプへのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。  
4. `Bevel` の [IAutoShape] を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。  
5. Bevel シェイプに対してエフェクトのシーケンスを作成します。  
6. カスタム `UserPath` を作成します。  
7. `UserPath` への移動コマンドを追加します。  
8. PPTX ファイルとしてディスクに保存します。  

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプに適用されたアニメーション エフェクトの取得**

以下の例は、[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) クラスの `get_effects_by_shape` メソッドを使用して、シェイプに適用されたすべてのアニメーション エフェクトを取得する方法を示します。  

**例 1: 通常スライド上のシェイプに適用されたアニメーション エフェクトの取得**

以前、PowerPoint プレゼンテーションのシェイプにアニメーション エフェクトを追加する方法を学びました。次のサンプルコードは、`AnimExample_out.pptx` の最初の通常スライドの最初のシェイプに適用されたエフェクトを取得する方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション エフェクトの取得**

通常スライド上のシェイプがレイアウト スライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにエフェクトが追加されている場合、スライドショー中にそれらすべてのエフェクトが再生されます（継承されたものも含む）。

PowerPoint プレゼンテーション ファイル `sample.pptx` があり、1 枚のスライドにフッター シェイプのみが含まれ、テキストは「Made with Aspose.Slides」で、**Random Bars** エフェクトがシェイプに適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

レイアウト スライドのフッター プレースホルダーには **Split** エフェクトが適用されているとします。

![Layout shape animation effect](layout-shape-animation.png)

マスタースライドのフッター プレースホルダーには **Fly In** エフェクトが適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスの `get_base_placeholder` メソッドを使用してプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたエフェクトを含むフッター シェイプのエフェクトを取得する方法を示します。

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

出力:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **アニメーション エフェクトのタイミング プロパティの変更**

Aspose.Slides for Python via .NET を使用すると、アニメーション エフェクトのタイミング プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング ペインです：

![example1_image](shape-animation.png)

PowerPoint タイミングと `Effect.Timing` プロパティの対応表：

- PowerPoint タイミング **Start** ドロップダウンは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) プロパティに対応します。  
- PowerPoint タイミング **Duration** は `Effect.Timing.Duration` プロパティに対応します。アニメーションの長さ（秒）は、1 サイクルが完了するまでの総時間です。  
- PowerPoint タイミング **Delay** は `Effect.Timing.TriggerDelayTime` プロパティに対応します。  

Effect Timing プロパティを変更する手順：

1. [シェイプへのアニメーションの適用](#apply-animation-to-shape) でエフェクトを取得または適用します。  
2. 必要な `Effect.Timing` プロパティに新しい値を設定します。  
3. 変更した PPTX ファイルを保存します。  

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーション エフェクト サウンド**

Aspose.Slides は、アニメーション エフェクトのサウンドを操作するために次のプロパティを提供します：

- `sound`  
- `stop_previous_sound`  

### **アニメーション エフェクト サウンドの追加**

次の Python コードは、アニメーション エフェクトにサウンドを追加し、次のエフェクトが開始したときにサウンドを停止する方法を示します。

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **アニメーション エフェクト サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. メイン シーケンスを取得します。  
4. 各アニメーション エフェクトに埋め込まれた `sound` を抽出します。  

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **アフター アニメーション**

Aspose.Slides for .NET を使用すると、アニメーション エフェクトの After animation プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション エフェクト パネルと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウンは以下のプロパティに対応します：

- `after_animation_type` プロパティは After animation の種類を示します：  
  * PowerPoint **More Colors** は [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します。  
  * PowerPoint **Don't Dim** は [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します（デフォルト）。  
  * PowerPoint **Hide After Animation** は [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します。  
  * PowerPoint **Hide on Next Mouse Click** は [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します。  
- `after_animation_color` プロパティは After animation の色形式を定義します。このプロパティは `COLOR` 型と併用されます。タイプを別のものに変更すると、色はクリアされます。  

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストのアニメーション**

Aspose.Slides は、アニメーション エフェクトの *Animate text* ブロックを操作するために次のプロパティを提供します：

- `animate_text_type` はエフェクトのテキストアニメーションの種類を示します。シェイプのテキストは次のいずれかでアニメーションできます：  
  - 全体同時 ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)  
  - 単語単位 ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)  
  - 文字単位 ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)  
- `delay_between_text_parts` はテキストパーツ（単語または文字）間の遅延を設定します。正の値はエフェクトの期間に対するパーセンテージ、負の値は秒数で指定します。  

Effect Animate text プロパティを変更する手順：

1. [シェイプへのアニメーションの適用](#apply-animation-to-shape) でエフェクトを取得または適用します。  
2. `build_type` プロパティを [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) に設定し、*By Paragraphs* モードをオフにします。  
3. `animate_text_type` と `delay_between_text_parts` に新しい値を設定します。  
4. 変更した PPTX ファイルを保存します。  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションを保持するにはどうすればよいですか？**  
[HTML5 へのエクスポート](/slides/ja/python-net/export-to-html5/) を使用し、[shape](/slides/ja/python-net/aspose.slides.export/html5options/animate_shapes/) と [transition](/slides/ja/python-net/aspose.slides.export/html5options/animate_transitions/) アニメーションを有効にするオプションを設定します。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。  

**シェイプの Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**  
アニメーションと描画順は独立しています。エフェクトは表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) は何が何を覆うかを決定します。最終的な見た目は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides のモデルも同様です。）  

**特定のエフェクトをビデオに変換する際に制限はありますか？**  
一般に、[アニメーションはサポートされています](/slides/ja/python-net/convert-powerpoint-to-video/)、ただし稀なケースや特定のエフェクトは異なる形でレンダリングされる場合があります。使用するエフェクトとライブラリのバージョンでテストすることを推奨します。