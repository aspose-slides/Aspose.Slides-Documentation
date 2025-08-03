---
title: Pythonでプレゼンテーションに図形アニメーションを適用する
linktitle: 図形アニメーション
type: docs
weight: 60
url: /ja/python-net/shape-animation/
keywords:
- 図形
- アニメーション
- エフェクト
- アニメーション化された図形
- アニメーション化されたテキスト
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- エフェクトを追加
- エフェクトを取得
- エフェクトを抽出
- 効果音
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument プレゼンテーションで図形アニメーションを作成およびカスタマイズする方法をご紹介します。他と差をつけましょう！"
---

アニメーションは、テキスト、画像、シェイプ、または [チャート](/slides/ja/python-net/animated-charts/) に適用できる視覚効果です。プレゼンテーションやその構成要素に生命を与えます。

### **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用することで、

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、または理解しやすくする
* プレゼンテーション内の重要な部分に読者や視聴者の注意を引く

PowerPointは、**入口**、**出口**、**強調**、**動きのパス**カテゴリのアニメーションおよびアニメーション効果のための多くのオプションとツールを提供しています。

### **Aspose.Slidesにおけるアニメーション**

* Aspose.Slidesは、[Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間の下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slidesは、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙型の下で**150以上のアニメーション効果**を提供しています。これらの効果は基本的にPowerPointで使用されるものと同じです。

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for Python via .NETを使用すると、シェイプのテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。
4. `IAutoShape.TextFrame` にテキストを追加します。
5. 効果のメインシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙型の値に設定します。
8. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPythonコードは、`Fade` 効果をAutoShapeに適用し、テキストアニメーションを *By 1st Level Paragraphs* 値に設定する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # テキスト付きの新しいAutoShapeを追加します
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "最初の段落 \n二番目の段落 \n三番目の段落"

    # スライドのメインシーケンスを取得します。
    sequence = sld.timeline.main_sequence

    # シェイプにFadeアニメーション効果を追加します
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # シェイプのテキストを1段落ずつアニメーション化します
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTXファイルをディスクに保存します
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

テキストにアニメーションを適用することに加えて、単一の [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) にもアニメーションを適用できます。詳細は [**アニメーションテキスト**](/slides/ja/python-net/animated-text/) をご覧ください。

{{% /alert %}} 

## **PictureFrameにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加または取得します。 
4. 効果のメインシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) にアニメーション効果を追加します。
6. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPythonコードは、`Fly` 効果をピクチャーフレームに適用する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
with slides.Presentation() as pres:
    # プレゼンテーションの画像コレクションに追加する画像を読み込みます
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # スライドにピクチャーフレームを追加します
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # スライドのメインシーケンスを取得します。
    sequence = pres.slides[0].timeline.main_sequence

    # ピクチャーフレームに左からのFlyアニメーション効果を追加します
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTXファイルをディスクに保存します
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。 
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します（このオブジェクトがクリックされると、アニメーションが再生されます）。
5. ベベルシェイプの効果のシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPythonコードは、シェイプに `PathFootball` （パスフットボール）効果を適用する方法を示しています：

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すプレゼンテーションクラスをインスタンス化します
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 既存のシェイプのためにPathFootball効果を最初から作成します。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("アニメーションテキストボックス")

    # PathFootballアニメーション効果を追加します。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # ある種の「ボタン」を作成します。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # ボタンのための効果のシーケンスを作成します。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # カスタムユーザーパスを作成します。私たちのオブジェクトはボタンがクリックされて初めて移動します。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 作成したパスが空であるため、移動コマンドを追加します。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTXファイルをディスクに保存します
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプに適用されたアニメーション効果を取得する**

単一のシェイプに適用されたすべてのアニメーション効果を調べることができます。

このPythonコードは、特定のシェイプに適用されたすべての効果を取得する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # スライドのメインシーケンスを取得します。
    sequence = firstSlide.timeline.main_sequence

    # スライドの最初のシェイプを取得します。
    shape = firstSlide.shapes[0]

    # シェイプに適用されたすべてのアニメーション効果を取得します。
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("シェイプ " + shape.name + " には " + str(len(shapeEffects)) + " のアニメーション効果があります。")
```

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for Python via .NETでは、アニメーション効果のタイミングプロパティを変更できます。

これがMicrosoft PowerPointのアニメーションタイミングペインです：

![example1_image](shape-animation.png)

これらはPowerPointのタイミングと `Effect.Timing` プロパティとの対応です：

- PowerPointのタイミング **開始** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) プロパティに対応します。 
- PowerPointのタイミング **期間** は、`Effect.Timing.Duration` プロパティに対応します。アニメーションの持続時間（秒単位）は、アニメーションが1サイクルを完了するのにかかる合計時間です。 
- PowerPointのタイミング **遅延** は、`Effect.Timing.TriggerDelayTime` プロパティに対応します。 

これが効果のタイミングプロパティを変更する方法です：

1. [アニメーション効果を適用](#apply-animation-to-shape)または取得します。
2. 必要な `Effect.Timing` プロパティに新しい値を設定します。 
3. 修正されたPPTXファイルを保存します。

このPythonコードは操作を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # スライドのメインシーケンスを取得します。
    sequence = pres.slides[0].timeline.main_sequence

    # メインシーケンスの最初の効果を取得します。
    effect = sequence[0]

    # 効果のTriggerTypeをクリックで開始するように変更します
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 効果の持続時間を変更します
    effect.timing.duration = 3

    # 効果の遅延時間を変更します
    effect.timing.trigger_delay_time = 0.5

    # PPTXファイルをディスクに保存します
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーション効果の音**

Aspose.Slidesは、アニメーション効果のサウンドを操作するための以下のプロパティを提供します：

- `sound`
- `stop_previous_sound`

### **アニメーション効果の音を追加する**

このPythonコードは、アニメーション効果の音を追加し、次の効果が開始されるとそれを停止する方法を示しています：

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # プレゼンテーションオーディオコレクションに音声を追加します
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # スライドのメインシーケンスを取得します。
    sequence = first_slide.timeline.main_sequence

    # メインシーケンスの最初の効果を取得します
    first_effect = sequence[0]

    # 効果に「サウンドなし」が設定されているか確認します
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 最初の効果に音を追加します
        first_effect.sound = effect_sound

    # スライドの最初のインタラクティブシーケンスを取得します。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 効果の「前の音を停止」フラグを設定します
    interactive_sequence[0].stop_previous_sound = True

    # PPTXファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **アニメーション効果の音を抽出する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. 効果のメインシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた `sound` を抽出します。 

このPythonコードは、アニメーション効果に埋め込まれた音を抽出する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # スライドのメインシーケンスを取得します。
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # 効果の音をバイト配列に抽出します
        audio = effect.sound.binary_data
```

## **アニメーション後**

Aspose.Slides for .NETでは、アニメーション効果のアニメーション後プロパティを変更することができます。

これがMicrosoft PowerPointのアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint Effect **アニメーション後** ドロップダウンリストは、これらのプロパティに対応しています：

- `after_animation_type` プロパティは、アニメーション後のタイプを説明します：
  * PowerPoint **その他の色** は、[COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します；
  * PowerPoint **暗くしない** リスト項目は、[DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプ（デフォルトのアニメーション後のタイプ）に対応します；
  * PowerPoint **アニメーション後に隠す** 項目は、[HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します；
  * PowerPoint **次のマウスクリックで隠す** 項目は、[HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します；
- `after_animation_color` プロパティは、アニメーション後の色フォーマットを定義します。このプロパティは [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプと連動して機能します。別のタイプに変更すると、アニメーション後の色はクリアされます。

このPythonコードは、アニメーション後の効果を変更する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メインシーケンスの最初の効果を取得します
    first_effect = first_slide.timeline.main_sequence[0]

    # アニメーション後のタイプを色に変更します
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # アニメーション後の暗くする色を設定します
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTXファイルをディスクに保存します
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストをアニメーション化する**

Aspose.Slidesは、アニメーション効果の*テキストをアニメーション化*ブロックを操作するための以下のプロパティを提供します：

- `animate_text_type` は、効果のアニメートテキストタイプを説明します。シェイプのテキストは以下のようにアニメーション化できます：
  - 一度にすべて ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
  - 単語ごとに ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
  - 文字ごとに ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
- `delay_between_text_parts` は、アニメーション化されたテキスト部分（単語や文字）の間に遅延を設定します。正の値は効果の持続時間の割合を指定します。負の値は秒単位の遅延を指定します。

これが効果のテキストアニメーションプロパティを変更する方法です：

1. [アニメーション効果を適用](#apply-animation-to-shape)または取得します。
2. `build_type` プロパティを [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) 値に設定して、*段落ごと* のアニメーションモードをオフにします。
3. `animate_text_type` と `delay_between_text_parts` プロパティに新しい値を設定します。
4. 修正されたPPTXファイルを保存します。

このPythonコードは操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メインシーケンスの最初の効果を取得します
    first_effect = first_slide.timeline.main_sequence[0]

    # 効果のテキストアニメーションタイプを「オブジェクトとしてすべて」に変更します
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # 効果のアニメートテキストタイプを「単語ごと」に変更します
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 単語の間の遅延を効果の持続時間の20％に設定します
    first_effect.delay_between_text_parts = 20

    # PPTXファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```