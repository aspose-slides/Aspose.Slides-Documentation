---
title: Python でプレゼンテーションの図形アニメーションを適用する
linktitle: 図形アニメーション
type: docs
weight: 60
url: /ja/python-net/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションで図形アニメーションを作成・カスタマイズする方法をご紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/python-net/animated-charts/)に適用できるビジュアル効果です。プレゼンテーションやその構成要素に命を吹き込みます。  

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、  

* 情報の流れをコントロールできる  
* 重要なポイントを強調できる  
* 聴衆の関心や参加意欲を高められる  
* コンテンツを読みやすく、理解しやすく、処理しやすくできる  
* プレゼンテーションの重要箇所に視聴者の注意を引きつけられる  

PowerPoint では、**入場**、**退出**、**強調**、**動きのパス**というカテゴリにわたる多数のアニメーションオプションとツールが提供されています。  

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間でアニメーション操作に必要なクラスと型を提供します。  
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙体で **150 種類以上** のアニメーション効果を提供します。これらは基本的に PowerPoint で使用される効果と同等です。  

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for Python via .NET を使用すると、図形内のテキストにアニメーションを適用できます。  

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。  
4. `IAutoShape.TextFrame` にテキストを追加します。  
5. メインシーケンス（効果のシーケンス）を取得します。  
6. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) にアニメーション効果を追加します。  
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。  

以下の Python コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *By 1st Level Paragraphs* に設定する例です。

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

テキストへのアニメーション適用に加えて、単一の[Paragraph](/slides/ja/python-net/animated-text/)にもアニメーションを適用できます。詳細は **[アニメーションテキスト](/slides/ja/python-net/animated-text/)** を参照してください。  

{{% /alert %}}  

## **PictureFrame にアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加または取得します。  
4. メインシーケンスを取得します。  
5. [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) にアニメーション効果を追加します。  
6. PPTX ファイルとしてディスクに保存します。  

以下の Python コードは、PictureFrame に `Fly` 効果を適用する例です。

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

## **図形にアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。  
4. クリック時にアニメーションが再生される `Bevel` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。  
5. ベベル形状の効果シーケンスを作成します。  
6. カスタム `UserPath` を作成します。  
7. `UserPath` 用の移動コマンドを追加します。  
8. PPTX ファイルとしてディスクに保存します。  

以下の Python コードは、図形に `PathFootball`（パスフットボール）効果を適用する例です。

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

## **図形に適用されたアニメーション効果を取得する**

次の例では、[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) クラスの `get_effects_by_shape` メソッドを使用して、図形に適用されたすべてのアニメーション効果を取得する方法を示します。  

**例 1: 通常スライド上の図形に適用されたアニメーション効果を取得する**  

以前、PowerPoint プレゼンテーションの図形にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、`AnimExample_out.pptx` の最初の通常スライド上の最初の図形に適用された効果を取得する方法を示します。

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

**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果を取得する**  

通常スライド上の図形にレイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に図形はプレースホルダーから継承された効果も含めてすべて再生されます。  

たとえば、`sample.pptx` という PowerPoint ファイルにフッター形状だけがあり、テキストは「Made with Aspose.Slides」、**Random Bars** 効果が適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

さらに、レイアウトスライド上のフッタープレースホルダーに **Split** 効果が適用されているとします。

![Layout shape animation effect](layout-shape-animation.png)

最後に、マスタースライド上のフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスの `get_base_placeholder` メソッドを使用してプレースホルダーを取得し、レイアウトおよびマスターから継承された効果を含めてフッター形状のアニメーション効果を取得する方法を示します。

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

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for Python via .NET を使用すると、アニメーション効果のタイミングプロパティを変更できます。  

以下は Microsoft PowerPoint の「アニメーション タイミング」ペインです。

![example1_image](shape-animation.png)

PowerPoint のタイミングと `Effect.Timing` プロパティの対応表は次のとおりです。

- PowerPoint の **開始** ドロップダウンは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) プロパティに対応します。  
- PowerPoint の **期間** は `Effect.Timing.Duration` プロパティに対応します。アニメーションの期間（秒）は、1 サイクルが完了するまでの総時間です。  
- PowerPoint の **遅延** は `Effect.Timing.TriggerDelayTime` プロパティに対応します。  

タイミングプロパティを変更する手順:

1. [図形にアニメーションを適用する](#apply-animation-to-shape) か、既存の効果を取得します。  
2. 必要な `Effect.Timing` プロパティに新しい値を設定します。  
3. 変更後の PPTX ファイルを保存します。  

以下の Python コードは操作例です。

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

## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果にサウンドを組み込むための以下のプロパティを提供します。

- `sound`  
- `stop_previous_sound`  

### **アニメーション効果にサウンドを追加する**

以下の Python コードは、アニメーション効果にサウンドを追加し、次の効果が開始されたときにサウンドを停止する例です。

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

### **アニメーション効果のサウンドを抽出する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. メインシーケンスを取得します。  
4. 各アニメーション効果に埋め込まれた `sound` を抽出します。  

以下の Python コードは、アニメーション効果に埋め込まれたサウンドを抽出する例です。

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

## **After Animation（終了後の動作）**

Aspose.Slides for .NET を使用すると、アニメーション効果の「After animation」プロパティを変更できます。  

以下は Microsoft PowerPoint の「アニメーション効果」ペインと拡張メニューです。

![example1_image](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウンは次のプロパティに対応します。

- `after_animation_type`：終了後のアニメーションタイプを示すプロパティ  
  * **More Colors** → [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Don't Dim** → [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) （デフォルト）  
  * **Hide After Animation** → [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Hide on Next Mouse Click** → [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
- `after_animation_color`：After animation のカラー形式を定義します。このプロパティは `COLOR` タイプと組み合わせて使用します。別のタイプに変更すると、カラーはクリアされます。  

以下の Python コードは、After animation 効果を変更する例です。

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

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します。

- `animate_text_type`：効果のテキストアニメーションタイプを示します。テキストのアニメーション方法は以下のとおりです。  
  - **ALL_AT_ONCE**（一括）  
  - **BY_WORD**（単語単位）  
  - **BY_LETTER**（文字単位）  
- `delay_between_text_parts`：テキストパーツ（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージ、負の値は秒数で指定します。  

テキストアニメーションプロパティを変更する手順:

1. [図形にアニメーションを適用する](#apply-animation-to-shape) か、既存の効果を取得します。  
2. `build_type` プロパティを [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) に設定し、*By Paragraphs* モードをオフにします。  
3. `animate_text_type` と `delay_between_text_parts` に新しい値を設定します。  
4. 変更後の PPTX を保存します。  

以下の Python コードは操作例です。

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

**プレゼンテーションを Web に公開するときにアニメーションを保持するにはどうすればよいですか？**  

[HTML5 へエクスポート](/slides/ja/python-net/export-to-html5/) し、[shape](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) のアニメーションを有効にするオプションを設定します。純粋な HTML ではスライドアニメーションは再生されませんが、HTML5 では再生されます。  

**図形の Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**  

アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) は何が何を覆うかを決定します。最終的な見た目は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides の効果‑図形モデルも同様です。）  

**特定の効果をビデオに変換するときに制限はありますか？**  

一般的に[アニメーションはサポート](/slides/ja/python-net/convert-powerpoint-to-video/) されていますが、稀なケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることをお勧めします。