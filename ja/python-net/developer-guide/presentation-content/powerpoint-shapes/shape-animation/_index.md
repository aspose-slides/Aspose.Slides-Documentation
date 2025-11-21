---
title: Pythonでプレゼンテーションのシェイプ アニメーションを適用する
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
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- エフェクトを追加
- エフェクトを取得
- エフェクトを抽出
- エフェクト サウンド
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法を学び、差別化しましょう！"
---

アニメーションは、テキスト、画像、図形、または[charts](/slides/ja/python-net/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、次のことができます
* 情報の流れを制御する
* 重要なポイントを強調する
* 観客の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は、**entrance**、**exit**、**emphasis**、**motion paths** の各カテゴリにわたるアニメーションおよびアニメーション効果の多くのオプションとツールを提供しています。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、アニメーションを操作するために必要なクラスと型を [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間で提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙体で **150** 以上のアニメーション効果を提供します。これらの効果は、基本的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーション適用**

Aspose.Slides for Python via .NET を使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。
4. `IAutoShape.TextFrame` にテキストを追加します。
5. メイン シーケンスのエフェクトを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Python コードは、AutoShape に `Fade` 効果を適用し、テキスト アニメーションを *By 1st Level Paragraphs* の値に設定する方法を示しています：
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーション クラスをインスタンス化します。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # テキスト付きの新しい AutoShape を追加
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # スライドのメイン シーケンスを取得
    sequence = sld.timeline.main_sequence

    # シェイプに Fade アニメーション効果を追加
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # シェイプのテキストを第1レベル段落ごとにアニメーション化
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTX ファイルをディスクに保存
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)にもアニメーションを適用できます。[**Animated Text**](/slides/ja/python-net/animated-text/)をご覧ください。
{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加するか取得します。
4. メイン シーケンスのエフェクトを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Python コードは、PictureFrame に `Fly` 効果を適用する方法を示しています：
```python
import aspose.slides as slides
import aspose.pydrawing as draw


# プレゼンテーション ファイルを表すプレゼンテーション クラスをインスタンス化します。
with slides.Presentation() as pres:
    # プレゼンテーションの画像コレクションに追加する画像を読み込む
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # スライドにピクチャーフレームを追加
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # スライドのメイン シーケンスを取得
    sequence = pres.slides[0].timeline.main_sequence

    # ピクチャーフレームに左からのフライ アニメーション効果を追加
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTX ファイルをディスクに保存
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Shape へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。
4. `Bevel` の [IAutoShape]((https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します（このオブジェクトがクリックされると、アニメーションが再生されます）。
5. ベベル シェイプに対してエフェクトのシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` に移動するコマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Python コードは、Shape に `PathFootball` (path football) 効果を適用する方法を示しています：
```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスをインスタンス化します。
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 既存のシェイプに対して PathFootball 効果を最初から作成します。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # PathFootBall アニメーション効果を追加します。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 種類が "ボタン" のオブジェクトを作成します。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # ボタン用のエフェクトシーケンスを作成します。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # カスタム ユーザーパスを作成します。ボタンがクリックされた後にだけオブジェクトが移動します。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 作成したパスが空なので移動コマンドを追加します。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTX ファイルをディスクに書き込みます。
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) クラスの `get_effects_by_shape` メソッドを使用して、シェイプに適用されたすべてのアニメーション効果を取得する方法を示しています。

**Example 1: 通常のスライド上のシェイプに適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションのシェイプにアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初のシェイプに適用された効果を取得する方法を示しています。
```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # スライドのメイン アニメーション シーケンスを取得します。
    sequence = first_slide.timeline.main_sequence

    # 最初のスライド上の最初のシェイプを取得します。
    shape = first_slide.shapes[0]

    # シェイプに適用されたアニメーション効果を取得します。
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```


**Example 2: プレースホルダーから継承されたものを含め、すべてのアニメーション効果を取得**

通常のスライド上のシェイプにプレースホルダーがあり、これらのプレースホルダーがレイアウトスライドやマスタースライド上にあり、さらにそれらにアニメーション効果が追加されている場合、スライドショー中にシェイプのすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint プレゼンテーション ファイルに、フッター シェイプ（テキスト "Made with Aspose.Slides"）が 1 枚のスライドにだけ含まれ、**Random Bars** 効果がシェイプに適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

さらに、レイアウト スライドのフッター プレースホルダーに **Split** 効果が適用されているとします。

![Layout shape animation effect](layout-shape-animation.png)

最後に、マスター スライドのフッター プレースホルダーに **Fly In** 効果が適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスの `get_base_placeholder` メソッドを使用してシェイプのプレースホルダーにアクセスし、レイアウトおよびマスター スライド上のプレースホルダーから継承されたものを含め、フッター シェイプに適用されたアニメーション効果を取得する方法を示しています。
```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 通常スライド上のシェイプのアニメーション効果を取得する。
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # レイアウトスライド上のプレースホルダーのアニメーション効果を取得する。
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # マスタースライド上のプレースホルダーのアニメーション効果を取得する。
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```


Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```


## **アニメーション効果のタイミング プロパティの変更**

Aspose.Slides for Python via .NET を使用すると、アニメーション効果のタイミング プロパティを変更できます。

This is the Animation Timing pane in Microsoft PowerPoint:
![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and `Effect.Timing` properties:

- PowerPoint Timing **Start** ドロップダウン リストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) プロパティに対応します。
- PowerPoint Timing **Duration** は `Effect.Timing.Duration` プロパティに対応します。アニメーションの持続時間（秒）は、アニメーションが 1 サイクルを完了するまでの総時間です。
- PowerPoint Timing **Delay** は `Effect.Timing.TriggerDelayTime` プロパティに対応します。

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. 必要な `Effect.Timing` プロパティに新しい値を設定します。
3. 変更した PPTX ファイルを保存します。

この Python コードは操作を示しています：
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーション クラスをインスタンス化します。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # スライドのメイン シーケンスを取得します。
    sequence = pres.slides[0].timeline.main_sequence

    # メイン シーケンスの最初のエフェクトを取得します。
    effect = sequence[0]

    # エフェクトの TriggerType をクリック時開始に変更します
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # エフェクトの Duration を変更します
    effect.timing.duration = 3

    # エフェクトの TriggerDelayTime を変更します
    effect.timing.trigger_delay_time = 0.5

    # PPTX ファイルをディスクに保存します
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために次のプロパティを提供します：

- `sound`
- `stop_previous_sound`

### **アニメーション効果サウンドの追加**

この Python コードは、アニメーション効果サウンドを追加し、次の効果が開始されるときにサウンドを停止する方法を示しています：
```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # プレゼンテーションのオーディオ コレクションにオーディオを追加
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # スライドのメイン シーケンスを取得。
    sequence = first_slide.timeline.main_sequence

    # メイン シーケンスの最初のエフェクトを取得
    first_effect = sequence[0]

    # 効果が「サウンドなし」かどうかチェック
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 最初のエフェクトにサウンドを追加
        first_effect.sound = effect_sound

    # スライドの最初のインタラクティブ シーケンスを取得。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # エフェクトの「前のサウンドを停止」フラグを設定
    interactive_sequence[0].stop_previous_sound = True

    # PPTX ファイルをディスクに書き込み
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. メイン シーケンスのエフェクトを取得します。
4. 各アニメーション効果に埋め込まれた `sound` を抽出します。

この Python コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています：
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーション クラスをインスタンス化します。
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # スライドのメイン シーケンスを取得します。
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # エフェクトのサウンドをバイト配列として抽出します。
        audio = effect.sound.binary_data
```


## **アフター アニメーション**

Aspose.Slides for .NET を使用すると、アニメーション効果の After animation プロパティを変更できます。

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:
![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ドロップダウン リストは以下のプロパティに対応します：

- `after_animation_type` プロパティは After animation の種類を表します：
  * PowerPoint **More Colors** は [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します；
  * PowerPoint **Don't Dim** は [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型（デフォルトの after animation 種類）に対応します；
  * PowerPoint **Hide After Animation** は [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します；
  * PowerPoint **Hide on Next Mouse Click** は [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型に対応します；
- `after_animation_color` プロパティは after animation の色形式を定義します。このプロパティは [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 型と組み合わせて使用します。種類を別のものに変更すると、after animation の色はクリアされます。

この Python コードは、after animation 効果を変更する方法を示しています：
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表すプレゼンテーション クラスをインスタンス化します
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メイン シーケンスの最初のエフェクトを取得します
    first_effect = first_slide.timeline.main_sequence[0]

    # after animation のタイプを Color に変更します
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # after animation のディムカラーを設定します
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTX ファイルをディスクに保存します
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのアニメーション化**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します：

- `animate_text_type` は効果のアニメート テキストの種類を示します。シェイプのテキストは次のいずれかでアニメーション化できます：
  - All at once ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)
  - By word ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)
  - By letter ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 型)
- `delay_between_text_parts` はアニメートされたテキスト パーツ（単語または文字）間の遅延を設定します。正の値は効果持続時間のパーセンテージを、負の値は秒単位の遅延を指定します。

This is how you can change the Effect Animate text properties:

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. `build_type` プロパティを [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) の値に設定して *By Paragraphs* アニメーション モードをオフにします。
3. `animate_text_type` と `delay_between_text_parts` プロパティに新しい値を設定します。
4. 変更した PPTX ファイルを保存します。

この Python コードは操作を示しています：
```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メイン シーケンスの最初のエフェクトを取得します
    first_effect = first_slide.timeline.main_sequence[0]

    # エフェクトのテキスト アニメーション タイプを "As One Object" に変更します
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # エフェクトのアニメート テキスト タイプを "By word" に変更します
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 単語間の遅延をエフェクト時間の 20% に設定します
    first_effect.delay_between_text_parts = 20

    # PPTX ファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**How can I ensure animations are preserved when publishing the presentation to the web?**

[Export to HTML5](/slides/ja/python-net/export-to-html5/) と、[shape](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) アニメーションに関するオプションを有効にします。通常の HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

**How does changing the z-order (layer order) of shapes affect animation?**

アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) は何が何を覆うかを決定します。最終的な表示は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides の効果とシェイプのモデルも同様です。）

**Are there limitations when converting animations to video for certain effects?**

一般的に、[animations are supported](/slides/ja/python-net/convert-powerpoint-to-video/) ですが、稀なケースや特定の効果では異なるレンダリングになることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。