---
title: Pythonでプレゼンテーションにシェイプアニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/python-net/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーションシェイプ
- アニメーションテキスト
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- 効果を追加
- 効果を取得
- 効果を抽出
- 効果音
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでシェイプアニメーションを作成・カスタマイズする方法をご紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、シェイプ、または[チャート](/slides/ja/python-net/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると

* 情報の流れを制御できる
* 重要なポイントを強調できる
* 聴衆の関心や参加意欲を高められる
* コンテンツを読みやすく、理解しやすくできる
* プレゼンテーション内の重要な部分へ視聴者の注意を引きつけられる

PowerPoint では、**入場**, **退出**, **強調**, **動きの経路** のカテゴリにわたる多数のオプションとツールが提供されています。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 名前空間の下で、アニメーションの操作に必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 列挙体で **150 以上のアニメーション効果** を提供します。これらの効果は基本的に PowerPoint で使用されるものと同等です。

## **テキストボックスへのアニメーション適用**

Aspose.Slides for Python via .NET を使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。
4. `IAutoShape.TextFrame` にテキストを追加します。
5. メインシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティに `BuildType` 列挙体の値を設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Python コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *段落単位* に設定する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # テキスト付きの新しい AutoShape を追加します。
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # スライドのメインシーケンスを取得します。
    sequence = sld.timeline.main_sequence

    # シェイプに Fade アニメーション効果を追加します。
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # テキストアニメーションを段落単位に設定します。
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

テキストへのアニメーション適用だけでなく、単一の[Paragraph](/slides/ja/python-net/animated-text/)にも適用できます。[**Animated Text**](/slides/ja/python-net/animated-text/) を参照してください。

{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加または取得します。
4. メインシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Python コードは、PictureFrame に `Fly` 効果を適用する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
with slides.Presentation() as pres:
    # プレゼンテーションの画像コレクションに追加する画像を読み込みます。
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # スライドにピクチャーフレームを追加します。
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # スライドのメインシーケンスを取得します。
    sequence = pres.slides[0].timeline.main_sequence

    # ピクチャーフレームに左からの Fly アニメーション効果を追加します。
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプへのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します。
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) を追加します（クリックするとアニメーションが再生されます）。
5. ベベルシェイプ上で効果シーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` 用の移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Python コードは、シェイプに `PathFootball`（パスフットボール）効果を適用する方法を示しています。

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 既存のシェイプに対して PathFootball 効果を作成します。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # PathFootBall アニメーション効果を追加します。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 「ボタン」的なシェイプを作成します。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # ボタン用の効果シーケンスを作成します。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # カスタムユーザーパスを作成します。ボタンがクリックされた後にオブジェクトが移動します。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # パスが空なので、移動コマンドを追加します。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプに適用されたアニメーション効果の取得**

以下の例は、[Sequence](/slides/ja/python-net/aspose.slides.animation/sequence/) クラスの `get_effects_by_shape` メソッドを使用して、シェイプに適用されたすべてのアニメーション効果を取得する方法を示しています。

**例 1: 通常スライド上のシェイプに適用されたアニメーション効果の取得**

以前、PowerPoint のプレゼンテーションにシェイプへアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初のシェイプに適用された効果を取得する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # スライドのメインアニメーションシーケンスを取得します。
    sequence = first_slide.timeline.main_sequence

    # 最初のスライド上の最初のシェイプを取得します。
    shape = first_slide.shapes[0]

    # シェイプに適用されたアニメーション効果を取得します。
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("シェイプ", shape.name, "には", len(shape_effects), "個のアニメーション効果があります。")
```

**例 2: プレースホルダーから継承された効果を含むすべてのアニメーション効果の取得**

通常スライド上のシェイプがレイアウトスライドやマスタースライドのプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にシェイプはプレースホルダーから継承された効果も含めてすべて再生されます。

たとえば、`sample.pptx` という PowerPoint ファイルに、フッターシェイプのみがありテキスト「Made with Aspose.Slides」が設定され、**Random Bars** 効果が適用されているとします。

![スライドシェイプアニメーション効果](slide-shape-animation.png)

さらに、**Split** 効果がレイアウトスライドのフッタープレースホルダーに適用されているとします。

![レイアウトシェイプアニメーション効果](layout-shape-animation.png)

最後に、**Fly In** 効果がマスタースライドのフッタープレースホルダーに適用されているとします。

![マスターシェイプアニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[Shape](/slides/ja/python-net/aspose.slides/shape/) クラスの `get_base_placeholder` メソッドを使用してプレースホルダーを取得し、レイアウトおよびマスタースライド上のプレースホルダーから継承された効果も含めてフッターシェイプに適用されたアニメーション効果を取得する方法を示しています。

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 通常スライド上のシェイプのアニメーション効果を取得します。
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # マスタースライド上のプレースホルダーのアニメーション効果を取得します。
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("シェイプ効果のメインシーケンス:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

出力例:

```text
シェイプ効果のメインシーケンス:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for Python via .NET では、アニメーション効果のタイミングプロパティを変更できます。

Microsoft PowerPoint のアニメーション タイミング パネル:

![例1 画像](shape-animation.png)

PowerPoint のタイミングと `Effect.Timing` プロパティの対応表:

- PowerPoint タイミング **開始** ドロップダウンは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) プロパティに対応します。  
- PowerPoint タイミング **期間** は `Effect.Timing.Duration` に対応します。アニメーションの期間（秒）は、効果が 1 サイクル完了するまでの合計時間です。  
- PowerPoint タイミング **遅延** は `Effect.Timing.TriggerDelayTime` に対応します。  

効果のタイミングプロパティを変更する手順:

1. [シェイプへのアニメーション適用](#apply-animation-to-shape) か、既存のアニメーション効果を取得します。
2. 必要な `Effect.Timing` プロパティに新しい値を設定します。
3. 変更後の PPTX ファイルを保存します。

以下の Python コードは操作例です。

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # スライドのメインシーケンスを取得します。
    sequence = pres.slides[0].timeline.main_sequence

    # メインシーケンスの最初の効果を取得します。
    effect = sequence[0]

    # トリガータイプをクリック時開始に変更します。
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 期間を 3 秒に変更します。
    effect.timing.duration = 3

    # 遅延時間を 0.5 秒に変更します。
    effect.timing.trigger_delay_time = 0.5

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーション効果サウンド**

Aspose.Slides は、アニメーション効果でサウンドを扱うために以下のプロパティを提供します。

- `sound`
- `stop_previous_sound`

### **アニメーション効果サウンドの追加**

この Python コードは、アニメーション効果にサウンドを追加し、次の効果が開始したときにサウンドを停止する方法を示します。

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # プレゼンテーションのオーディオコレクションに音声を追加します。
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # スライドのメインシーケンスを取得します。
    sequence = first_slide.timeline.main_sequence

    # メインシーケンスの最初の効果を取得します。
    first_effect = sequence[0]

    # 「サウンドなし」かどうかを確認します。
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 最初の効果にサウンドを追加します。
        first_effect.sound = effect_sound

    # スライドの最初のインタラクティブシーケンスを取得します。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 効果の「前のサウンドを停止」フラグを設定します。
    interactive_sequence[0].stop_previous_sound = True

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. メインシーケンスを取得します。
4. 各アニメーション効果に埋め込まれた `sound` を抽出します。

以下の Python コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # スライドのメインシーケンスを取得します。
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # 効果サウンドをバイト配列として抽出します。
        audio = effect.sound.binary_data
```

## **アフターアニメーション**

Aspose.Slides for .NET では、アニメーション効果の「After animation」プロパティを変更できます。

Microsoft PowerPoint のアニメーション効果ペインと拡張メニュー:

![例1 画像](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウンは以下のプロパティに対応します。

- `after_animation_type` プロパティ（After animation のタイプ）:
  * PowerPoint の **More Colors** は [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します。
  * PowerPoint の **Don't Dim** は [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプ（デフォルト）に対応します。
  * PowerPoint の **Hide After Animation** は [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します。
  * PowerPoint の **Hide on Next Mouse Click** は [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) タイプに対応します。
- `after_animation_color` プロパティは、`COLOR` タイプと組み合わせて使用し、After animation のカラー形式を定義します。タイプを別のものに変更すると、After animation のカラーはクリアされます。

この Python コードは、After animation 効果を変更する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メインシーケンスの最初の効果を取得します。
    first_effect = first_slide.timeline.main_sequence[0]

    # After animation のタイプを Color に変更します。
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # After animation のディムカラーを設定します。
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために以下のプロパティを提供します。

- `animate_text_type`（テキストアニメーションのタイプ）:
  * 全体一括 ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
  * 単語単位 ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
  * 文字単位 ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) タイプ)
- `delay_between_text_parts`（テキストパーツ間の遅延）を設定します。正の値は効果期間のパーセンテージ、負の値は秒単位の遅延を表します。

このプロパティを変更する手順:

1. [シェイプへのアニメーション適用](#apply-animation-to-shape) か、既存のアニメーション効果を取得します。
2. `build_type` プロパティに [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) の値を設定し、*By Paragraphs* アニメーションモードをオフにします。
3. `animate_text_type` と `delay_between_text_parts` に新しい値を設定します。
4. 変更後の PPTX ファイルを保存します。

以下の Python コードは操作例です。

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # メインシーケンスの最初の効果を取得します。
    first_effect = first_slide.timeline.main_sequence[0]

    # テキストアニメーションのビルドタイプを「オブジェクト単位」に変更します。
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # テキストアニメーションタイプを「単語単位」に変更します。
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 単語間の遅延を効果期間の 20% に設定します。
    first_effect.delay_between_text_parts = 20

    # PPTX ファイルをディスクに保存します。
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションを保持するにはどうすればよいですか？**

[HTML5 へのエクスポート](/slides/ja/python-net/export-to-html5/) を使用し、[shape](/slides/ja/python-net/aspose.slides.export/html5options/animate_shapes/) と [transition](/slides/ja/python-net/aspose.slides.export/html5options/animate_transitions/) アニメーションを有効にするオプションを設定してください。通常の HTML はスライドアニメーションを再生しませんが、HTML5 は再生します。

**シェイプの Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**

アニメーションと描画順は独立しています。効果は表示/非表示のタイミングとタイプを制御し、[z_order_position](/slides/ja/python-net/aspose.slides/shape/z_order_position/) は何が何を覆うかを決定します。最終的な表示は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides の効果とシェイプのモデルも同様です。）

**特定の効果をビデオに変換する際に制限はありますか？**

一般的に[アニメーションはサポート](/slides/ja/python-net/convert-powerpoint-to-video/) されていますが、稀なケースや特定の効果は異なる描画になることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。