---
title: Pythonでカスタム アニメーション ビヘイビアを作成および変更
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/python-net/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション ビヘイビア
- モーション パス
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーション内のカスタム アニメーション ビヘイビアと編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタムアニメーション ビヘイビアを使用すると、色の変更、形状の回転、編集可能なモーション パスに従うなど、アニメーション効果内の個々の操作を制御できます。このガイドでは、ビヘイビアの作成と組み合わせ、タイミングの構成、既存のアニメーションの検査と変更、プレゼンテーションの保存と再オープン後にプロパティが保持されていることの確認方法を示します。

プリセット効果とクリック トリガーについては、[Shape Animation](/slides/ja/python-net/shape-animation/) を参照してください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます。

- スライドの[timeline](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/timeline/)にはメインシーケンスとインタラクティブ シーケンスが含まれます。
- [Sequence](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/) は、異なる形状を対象にした効果を格納します。
- [Effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/) は対象形状、プリセット、サブタイプ、効果のタイミングを識別します。
- [Effect.behaviors](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/behaviors/) には、色の変更、移動、回転、プロパティ設定など、効果を実装する操作が含まれます。

## **個々のビヘイビアの作成**

[Sequence.add_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/add_effect/) を呼び出して効果を作成し、その[behaviors](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/behaviors/) コレクションにアクセスします。プリセットを使用するとこのコレクションが自動的に埋められます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は[clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/clear/) を使用します。

[BehaviorFactory](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/) は以下に示す 8 種類のビヘイビアを作成します。モーションは[Build a Motion Path](#build-a-motion-path)で扱います。各作成例は完全なプログラムです。後続の編集例は使用する出力ファイルを示します。

### **回転**

[create_rotation_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) を使用して回転を作成します。[by](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/rotationeffect/by/) は度数での相対角度を指定し、[from_address](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/rotationeffect/from_address/) と[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/rotationeffect/to/) は開始点と終了点を指定します。

この例は Spin 効果で始まり、プリセット操作を 1 つの回転ビヘイビアに置き換え、操作に 2 秒の期間を設定します。90 度の相対角度は形状の初期向きからの 1/4 回転を表すため、明示的な開始角度は不要です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` には 1 つの形状と 1 つの回転ビヘイビアが含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[X/Y パーセンテージ] を指定して[create_scale_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) を使用します。[from_address](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/scaleeffect/from_address/) と[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/scaleeffect/to/) は開始サイズと終了サイズを表し、[by](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/scaleeffect/by/) は相対変化を表します。ここで 100 は元のサイズを意味します。

この例は両方の寸法を 100% から 125% に 2 秒かけて拡大します。水平・垂直パーセンテージを等しく設定すると形状の比率が保たれ、異なるパーセンテージにすると一方が伸びます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **カラー**

[create_color_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) を使用して塗りを青からオレンジに変更します。[from_address](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/coloreffect/from_address/) と[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/coloreffect/to/) は色を表し、[by](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/coloreffect/by/) は色のオフセットです。[Behavior.properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behavior/properties/) はアニメーション対象の属性を特定します。

形状の単色塗りは青で初期化され、アニメーションの開始色と一致します。塗り色属性を選択することでビヘイビアが形状のどの部分を変更すべきかを指示し、色の終点だけでは属性は特定できません。保存された効果は 2 秒でオレンジに変化することを記述しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **フィルタ**

[create_filter_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) を使用してワイプを選択します。[type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/filtereffect/type/)、[subtype](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/filtereffect/subtype/)、[reveal](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/filtereffect/reveal/) はフィルタ、方向、表示/非表示を指定します。

この例は右方向サブタイプで形状を表示する 2 秒のワイプを構成します。フィルタ設定は効果内のビヘイビアに属するため、プリセットの元の操作を削除した後に設定します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **プロパティ**

[create_property_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) を使用して不透明度をアニメーションします。[from_address](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/from_address/)、[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/to/)、[by](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/by/) は文字列で、[value_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/value_type/) と[calc_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/calc_mode/) によって解釈されます。3 つすべてを無差別に設定するのではなく、終点または相対オフセットを選択してください。

ここでは属性として不透明度を選び、文字列 `"25%"` から `"100%"` への変化を表します。線形補間により値が徐々に変化します。別の属性に適用する場合は、その属性に適した value_type と終点値を選択してください。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **設定**

[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/seteffect/to/) を使用して可視性を割り当てる [create_set_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) を作成します。セットビヘイビアは終点間を補間しません。

この例は可視性属性を選択し、ビヘイビア実行時に文字列 `visible` を割り当てます。最小限のプレゼンテーションでは矩形は既に表示されているため、単独では目立った変化はありません。形状の表示/非表示を制御する他の効果と組み合わせる際に有用です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **コマンド**

[create_command_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) を使用し、[type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/commandeffect/type/)、[command_string](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/commandeffect/command_string/)、[shape_target](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/commandeffect/shape_target/) を構成します。作業ディレクトリに `sample.wav` という名前の WAV 録音を置いてください。この例は [add_audio_frame_embedded](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) で埋め込み、再生コマンドをオーディオ フレームに付加します。

オーディオ フレームは効果のターゲットでもありコマンドのターゲットでもあります。これにより再生要求が埋め込み録音に結び付けられ、コマンド文字列だけではどのメディアオブジェクトを制御するか特定できません。効果はスライドショー中のクリックで開始するように構成されています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

保存すると `command.pptx` にコマンドが格納されますが、録音は再生されません。再生にはコマンドとメディア対象をサポートするスライドショー プレーヤーが必要です。

## **ビヘイビア コレクションの管理**

[BehaviorCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/) は [add](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/remove/)、[remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/remove_at/) をサポートします。この例は `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動し、回転を削除します。同じオブジェクトを削除して再挿入するとコピーせずに位置が変更されます。

編集の順序はコレクションを「回転→拡大縮小」から「拡大縮小→回転」へ、さらに「拡大縮小のみ」へと変化させます。インデックスは現在のコレクションを基準にするため、再配置後の回転の新しいインデックスを使用して削除します。最終的な列挙で保存されるビヘイビアが確認できます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

出力は `ScaleEffect` のみで、拡大縮小だけが残ります。コレクションの順序自体はビヘイビアを連続して実行させるスケジュールにはなりません。すべての操作を置き換える場合にのみコレクションをクリアしてください。

## **ビヘイビア タイミングの構成**

[Behavior.timing](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behavior/timing/) は [Timing](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/) を公開し、[Effect.timing](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/timing/) とは独立しています。Effect のタイミングは外側の効果全体をスケジュールし、ビヘイビアのタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、秒単位で [duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/duration/) と [trigger_delay_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/trigger_delay_time/) を設定し、[repeat_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_count/) を構成します。[accelerate](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/accelerate/) と [decelerate](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/decelerate/) は期間の割合で、合計が 1 を超えないようにします。

入力ファイルは回転例で作成したものです。最初のビヘイビアが回転であることが分かっています。この例はそのビヘイビアのタイミングだけを変更し、90 度の角度はそのまま保持します。角度とタイミングを分離しておくと、アニメーションの再構築なしに速度調整が容易になります。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

ビヘイビアは 2 秒の期間、0.5 秒の遅延、繰り返し回数 3 を使用します。期間の最初と最後の 20% が加速と減速に使われます。

他の繰り返しポリシーには [repeat_duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_duration/)、[repeat_until_end_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)、[repeat_until_next_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/repeat_until_next_click/) があります。すべて同時に有効にするのではなく、目的に応じて 1 つを選択してください。[auto_reverse](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/timing/auto_reverse/) は前進後に逆再生します。加速・減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの構築**

[create_motion_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) を使用してモーションを作成します。[from_address](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/from_address/)、[to](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/to/)、[by](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/by/) はパーセンテージベースの座標またはオフセットを表します。編集可能なルートが必要な場合は [MotionPath](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpath/) を作成し、[MotionEffect.path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/path/) に割り当てます。[MotionPath](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpath/) はパスコマンドを保持します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncommandpathtype/) は操作を選択します。

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MOVE_TO | 1 | 開始位置を設定します。 |
| LINE_TO | 1 | 直線セグメントを終点まで移動します。 |
| CURVE_TO | 3 | 2 つの制御点と終点で定義された三次ベジェ曲線に沿って移動します。 |
| CLOSE_LOOP | なし | 開始位置に戻ります。 |
| END | なし | パスを終了します。 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpathpointstype/) は点の編集特性（コーナー点やスムーズ点など）を表し、コマンドタイプの代替ではありません。曲線例では曲線点タイプ、直線セグメント例ではコーナー点タイプを使用してください。

パス座標はスライド寸法に正規化されます。X の 0.25 はスライド幅の 1/4 を意味し、ポイント 0.25 ではありません。Y は下方向が正です。Absolute コマンドはパス座標系で位置を指定し、Relative コマンドは現在位置からのオフセットを指定します。これは[path origin](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/origin/) と[path_edit_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/path_edit_mode/) とは別の概念です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーション ビヘイビアを作成します。[MotionPath.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpath/add/) はコマンドタイプ、ポイント配列、点タイプ、相対座標フラグを受け取ります。

開始コマンドで (0, 0) を設定し、直線は (0.25, 0) に終わります。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標点がありません。パスを割り当てた後、モーション ビヘイビアを効果に追加すると矩形にこのルートが接続されます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` には 3 つのパスコマンドを持つ 1 つのモーション ビヘイビアが含まれます。以下のファイル編集例はこの構造を前提にしています。

### **絶対座標と相対座標の比較**

この 2 つのパスオブジェクトは同じルートを表します。Absolute コマンドは (0.3, 0.1) に終わり、Relative コマンドは現在位置 (0.2, 0) に (0.1, 0.1) を加えて終点を決定します。

両方のパスは同じ開始位置です。Relative ラインの場合はオフセットを現在位置に加えて終点を得ます。Absolute ラインの場合は終点を直接読み取ります。フラグだけを切り替えて座標を変換しないと、異なるルートになります。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

いずれかのパスをモーション ビヘイビアに割り当ててプレゼンテーションで使用してください。最終の Boolean 引数はそのコマンドが相対座標かどうかを指定します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。最初に 2 つの制御点を、続いて終点を指定します。

開始位置は前のコマンドで供給されます。最初の 2 点が曲線の形状を決め、3 番目が目的地です。コマンドタイプ、点編集タイプ、点配列を同時に更新すると新しいジオメトリに整合したセグメントになります。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ち、真ん中のコマンドが曲線となります。

## **保存されたパスの検査と編集**

各 [MotionCmdPath](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncmdpath/) は [points](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncmdpath/points/)、[command_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncmdpath/command_type/)、[points_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncmdpath/points_type/)、[is_relative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioncmdpath/is_relative/) を公開します。以下の例は `motion.pptx` の既知の 3 コマンドパスを使用します。任意の入力については、編集前に対象効果を特定し、コマンドタイプとポイント数をインデックスで確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。End および CloseLoop コマンドはポイントを必要としないため、`None` のポイント配列を想定してください。

出力は各コマンドと相対座標フラグをペアで列挙し、続いてポイントを表示します。これによりパスを変更する前に終点とオフセットを区別できます。曲線は 3 点を、直線は 1 点をリストします。

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

一覧には開始点、(0.25, 0) に終わる絶対直線、End コマンドが含まれます。

### **終点の変更**

`motion.pptx` を開き、直線のポイント配列を置き換えて終点を移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一ポイントを置き換えることで、コマンドタイプ、タイミング、コレクション内の位置は変更せずに目的地だけを変更できます。コマンドが絶対座標を使用しているため、新しいペアはオフセットではなく位置を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx` の直線は (0.4, 0.1) に終わり、元のファイルは変更されません。

### **セグメントの置き換え**

[insert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpath/insert/) と [remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motionpath/remove_at/) を使って `motion.pptx` の直線を置き換えます。挿入により古い直線はインデックス 2 にシフトします。

これは既存座標を編集するのではなく、コマンドオブジェクト自体を置き換える例です。挿入後、コレクションは一時的に開始コマンド、新しい直線、古い直線、End コマンドを保持します。インデックス 2 を削除すると古い直線が除去され、新しいルートが残ります。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

保存されたパスは依然として 3 コマンドで、新しい直線は (0.2, 0.1) に終わり、最後が End コマンドです。

## **既存ビヘイビアの変更と検証**

ビヘイビアのインデックスが不明な場合はタイプで選択します。この例は `rotation.pptx` を開き、[RotationEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/rotationeffect/) を見つけて角度を変更し、再オープン後に保存値を確認します。

タイプチェックにより、回転でないビヘイビアはループでスキップされます。2 回目のロードは保存されたファイルを別のプレゼンテーション オブジェクトに読み込み、比較はメモリ上の値ではなく永続化されたデータを確認します。この例は既知の効果がメインシーケンスの最初にあることを前提としていますが、タイプでビヘイビアを選択しても任意のプレゼンテーションで正しい効果が見つかるとは限りません。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

出力は `Rotation preserved: True` です。他のビヘイビアにも同様のタイプチェック パターンを適用してください。完全な保存チェックでは、対象形状、効果、ビヘイビアのタイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値許容誤差を使用します。アニメーション構成が不明なプレゼンテーションについては、[Read Shape Animations](/slides/ja/python-net/shape-animation/#read-shape-animations) を参照し、メインおよびインタラクティブ シーケンスをたどってください。

## **ビヘイビアの順序、プリセット、再生**

[BehaviorCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behaviorcollection/) の順序は効果の操作が保存される順序であり、各ビヘイビアが自動的に前のビヘイビアの完了を待つプレイリストではありません。タイミングと外側の効果がスケジューリングを決定します。ビヘイビアは重なることができ、同一プロパティへの操作は [additive](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behavior/additive/) や [accumulate](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behavior/accumulate/) を通じて相互作用します。単にコレクション順序を変えるだけで「移動→回転」をスケジュールしようとしないでください。明示的なタイミングまたは別々の効果を使用してください（[Shape Animation](/slides/ja/python-net/shape-animation/) 参照）。

効果の [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/type/) と [subtype](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effect/subtype/) はプリセットを記述しますが、編集済みビヘイビア ツリーの完全な説明ではありません。ビヘイビアをカスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタマイズされた Spin 効果を Fade に変更すると、回転ビヘイビアが set や filter ビヘイビアに置き換えられます。プリセットやサブタイプを変更した後はコレクションを再度確認してください。プリセットのビヘイビアをクリアすると、プリセットが必要とする可視化や初期化操作も削除されることがあります。例では可視形状を使用し、ビヘイビアを置き換えているため、すべてのプリセット実装を再構築してはいません。

## **フォーマット互換性**

保存されたビヘイビア ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を別々に確認してください。

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | 例の主要フォーマットとして使用します。再オープンして編集可能なビヘイビア ツリーを確認し、対象 PowerPoint バージョンでの再生をチェックします。 |
| PPT | レガシーのバイナリ形式で、PPTX と異なる動作になる可能性があります。別途保存・再オープンと再生をテストし、PPTX の成功だけで全組み合わせがサポートされていると判断しないでください。 |
| PDF、PNG、JPEG、その他の静的スライド画像 | 静的なスライド表現であり、再生可能なビヘイビア タイムラインや最終フレームの保証はありません。 |
| [HTML5](/slides/ja/python-net/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすると、サポートされたアニメーションがブラウザで再生できます。カスタム組み合わせは実際にテストしてください。 |
| [Animated GIF](/slides/ja/python-net/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを格納し、編集可能なビヘイビアやクリック トリガーは含みません。実際のモーションを確認してください。 |
| [Video](/slides/ja/python-net/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングして動画としてエンコードします。サポートはレンダラの [supported animations and effects](/slides/ja/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインになりません。 |

## **FAQ**

**なぜ効果にビヘイビアが何も追加していないのに存在するのですか？**  
プリセット効果を作成すると、その基礎となる操作が生成されることがあります。ビヘイビアを拡張するか置き換えるか決める前に確認してください。

**ビヘイビアを先頭に移動すれば最初に再生されますか？**  
必ずしもそうとは限りません。コレクション順序はタイミングの代替ではありません。遅延、期間、同一プロパティへの相互作用を確認してください。

**なぜ End コマンドにポイントがないのですか？**  
パスの終了を示すだけで座標は不要です。ファイルからパスを読み取る際は `None` のポイント配列をチェックしてください。

**ラウンドトリップが成功すれば再生も保証されますか？**  
いいえ。再オープンはプロパティの保持を確認しますが、スライドショー プレーヤーやアニメーション エクスポートでの実際の再生は別途テストが必要です。