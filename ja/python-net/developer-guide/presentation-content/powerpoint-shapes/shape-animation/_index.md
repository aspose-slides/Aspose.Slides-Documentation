---
title: Python を使用したプレゼンテーションへの図形アニメーションの適用
linktitle: 図形アニメーション
type: docs
weight: 60
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで図形アニメーションを作成およびカスタマイズする方法をご紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/python-net/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

* 情報の流れを制御する  
* 重要なポイントを強調する  
* オーディエンスの関心や参加意欲を高める  
* コンテンツを読みやすく、理解しやすく、処理しやすくする  
* 読者や視聴者の注意をプレゼンテーションの重要な部分へ引きつける  

PowerPoint は、**入口**、**終了**、**強調**、**動きのパス** の各カテゴリにわたる多数のアニメーションオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、アニメーションを操作するために必要なクラスと型を [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間で提供します。  
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙体で **150 以上のアニメーション効果** を提供します。これらの効果は基本的に PowerPoint で使用されるものと同等です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Python via .NET を使用すると、図形内のテキストにアニメーションを適用できます。

1. プレゼンテーション クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `rectangle` の [IAutoShape] を追加します。  
4. `IAutoShape.TextFrame` にテキストを追加します。  
5. メインの効果シーケンスを取得します。  
6. [IAutoShape] にアニメーション効果を追加します。  
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

テキストにアニメーションを適用するだけでなく、単一の[段落]にアニメーションを適用することもできます。詳しくは[**アニメーションテキスト**](/slides/ja/python-net/animated-text/)をご覧ください。

{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. プレゼンテーション クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライドに [PictureFrame] を追加または取得します。  
4. メインの効果シーケンスを取得します。  
5. [PictureFrame] にアニメーション効果を追加します。  
6. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

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

## **図形へのアニメーションの適用**

1. プレゼンテーション クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `rectangle` の [IAutoShape] を追加します。  
4. `Bevel` の [IAutoShape] を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。  
5. ベベル形状に対して効果シーケンスを作成します。  
6. カスタムの `UserPath` を作成します。  
7. `UserPath` への移動コマンドを追加します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

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

## **図形に適用されたアニメーション効果の取得**

以下の例は、[Sequence] クラスの `get_effects_by_shape` メソッドを使用して、図形に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 標準スライド上の図形に適用されたアニメーション効果の取得**

以前は、PowerPoint プレゼンテーションの図形にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の標準スライドの最初の図形に適用された効果を取得する方法を示します。

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

**例 2: プレースホルダーから継承されたものも含め、すべてのアニメーション効果を取得**

標準スライド上の図形が、レイアウトスライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、プレゼンテーション中に図形のすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

PowerPoint プレゼンテーション ファイル `sample.pptx` があり、1 枚のスライドにフッター形状だけが含まれ、テキストは「Made with Aspose.Slides」で、**Random Bars** 効果がその形状に適用されているとします。

さらに、**レイアウト** スライドのフッタープレースホルダーに **Split** 効果が適用されているとします。

最後に、**マスター** スライドのフッタープレースホルダーに **Fly In** 効果が適用されているとします。

以下のサンプルコードは、[Shape] クラスの `get_base_placeholder` メソッドを使用して形状のプレースホルダーにアクセスし、レイアウトおよびマスター スライド上のプレースホルダーから継承されたものを含め、フッター形状に適用されたアニメーション効果を取得する方法を示します。

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

## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for Python via .NET を使用すると、アニメーション効果のタイミングプロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング ペインです：

- PowerPoint のタイミング **開始** ドロップダウンは [Effect.Timing.TriggerType] プロパティに対応しています。  
- PowerPoint のタイミング **期間** は `Effect.Timing.Duration` プロパティに対応しています。アニメーションの期間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。  
- PowerPoint のタイミング **遅延** は `Effect.Timing.TriggerDelayTime` プロパティに対応しています。  

Effect のタイミングプロパティを変更する手順は次のとおりです：

1. アニメーション効果を適用するか取得します。  
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

## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを扱うために以下のプロパティを提供します：

- `sound`  
- `stop_previous_sound`  

### **アニメーション効果サウンドの追加**

この Python コードは、アニメーション効果にサウンドを追加し、次の効果が開始されるとサウンドを停止する方法を示します：

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

### **アニメーション効果サウンドの抽出**

1. プレゼンテーション クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. メインの効果シーケンスを取得します。  
4. `sound` を各アニメーション効果に埋め込まれたものを抽出します。  

この Python コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：

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

## **アフターアニメーション**

Aspose.Slides for .NET を使用すると、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint の Effect ペインと拡張メニューです：

PowerPoint の Effect **After animation** ドロップダウンは以下のプロパティに対応しています：

- `after_animation_type` プロパティは After animation のタイプを表します：  
  * PowerPoint の **More Colors** は [COLOR] タイプに対応します；  
  * PowerPoint の **Don't Dim** は [DO_NOT_DIM] タイプ（デフォルト）に対応します；  
  * PowerPoint の **Hide After Animation** は [HIDE_AFTER_ANIMATION] タイプに対応します；  
  * PowerPoint の **Hide on Next Mouse Click** は [HIDE_ON_NEXT_MOUSE_CLICK] タイプに対応します；  
- `after_animation_color` プロパティはアフターアニメーションのカラー形式を定義します。このプロパティは [COLOR] タイプと連携して機能します。別のタイプに変更すると、アフターアニメーションのカラーはクリアされます。  

この Python コードは、After animation 効果を変更する方法を示します：

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

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを扱うために以下のプロパティを提供します：

- `animate_text_type` は効果のアニメーションテキストタイプを表します。形状のテキストは次のようにアニメーション化できます：  
  - すべて同時 ([ALL_AT_ONCE] タイプ)  
  - 単語単位 ([BY_WORD] タイプ)  
  - 文字単位 ([BY_LETTER] タイプ)  
- `delay_between_text_parts` はアニメーション対象のテキスト部分（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを、負の値は秒数で遅延を指定します。  

Effect の Animate text プロパティを変更する手順は次のとおりです：

1. アニメーション効果を適用するか取得します。  
2. `build_type` プロパティに [AS_ONE_OBJECT] の値を設定して、*By Paragraphs* アニメーションモードをオフにします。  
3. `animate_text_type` と `delay_between_text_parts` プロパティに新しい値を設定します。  
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

## **よくある質問**

**プレゼンテーションを Web に公開する際にアニメーションが保持されるようにするにはどうすればよいですか？**  
[Export to HTML5](/slides/ja/python-net/export-to-html5/) を使用し、[shape](/slides/ja/python-net/aspose.slides.export/html5options/animate_shapes/) と [transition](/slides/ja/python-net/aspose.slides.export/html5options/animate_transitions/) アニメーションに対応するオプションを有効にします。プレーン HTML ではスライドアニメーションは再生されませんが、HTML5 では再生されます。

**図形の Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**  
アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングとタイプを制御し、[z-order](/slides/ja/python-net/aspose.slides/shape/z_order_position/) は何が何を覆うかを決定します。最終的な見た目は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides の効果と図形のモデルも同様です。）

**特定の効果をビデオに変換する際に制限がありますか？**  
一般的に[アニメーションはサポート](/slides/ja/python-net/convert-powerpoint-to-video/)されていますが、稀なケースや特定の効果は異なる方法でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。