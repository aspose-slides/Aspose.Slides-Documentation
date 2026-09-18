---
title: Python（Java 経由）でカスタム アニメーション ビヘイビアを作成および変更
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/python-java/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション ビヘイビア
- モーション パス
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのカスタム アニメーション ビヘイビアと編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタム アニメーション ビヘイビアを使用すると、色の変更、図形の回転、編集可能なモーション パスの追従など、アニメーション効果内の個々の操作を制御できます。このガイドでは、ビヘイビアの作成と組み合わせ、タイミングの設定、既存のアニメーションの検査と変更、プレゼンテーションの保存と再オープン後にプロパティが保持されていることの確認方法を示します。

事前定義された効果やクリック トリガーについては、[シェイプ アニメーション](/slides/ja/python-java/shape-animation/)をご覧ください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます。

- [getTimeline](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getTimeline) メソッドはスライド タイムラインを返し、メイン シーケンスとインタラクティブ シーケンスを含みます。
- [Sequence](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/) は、異なる図形を対象にできる効果を保持します。
- [Effect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/) は対象図形、プリセット、サブタイプ、および効果のタイミングを特定します。
- [Effect.getBehaviors](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getBehaviors) が返すコレクションには、色の変更、移動、回転、プロパティ設定など、効果を実装する操作が含まれます。

## **個別ビヘイビアの作成**

[Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) を呼び出して効果を作成し、[getBehaviors](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getBehaviors) コレクションにアクセスします。プリセットはこのコレクションを自動的に埋めることができます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は [clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/#clear) を使用します。

[BehaviorFactory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/) は以下に示す 8 種類のビヘイビアを生成します。モーションは [モーション パスの作成](#build-a-motion-path) でカバーしています。各スニペットはインポート文を含み、必要に応じて JVM を起動します。Java のポイント オブジェクトや配列は JPype を通じて作成されます。後の編集例では使用する出力ファイルを明記しています。

### **回転**

[createRotationEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createRotationEffect) を使用して回転効果を作成します。[getBy](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotationeffect/#getBy) で相対角度（度）を指定し、[getFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotationeffect/#getFrom) と [getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotationeffect/#getTo) で端点を指定します。

この例は Spin 効果で始め、プリセットの操作を 1 つの回転ビヘイビアに置き換え、継続時間を 2 秒に設定します。90 度の相対角度は図形の開始向きから 1/4 回転を表すため、開始角度を明示的に指定する必要はありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` には 1 つの図形と 1 つの回転ビヘイビアが含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[createScaleEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createScaleEffect) を X/Y のパーセンテージで使用します。[getFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/scaleeffect/#getFrom) と [getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/scaleeffect/#getTo) が開始サイズと終了サイズを示し、[getBy](https://reference.aspose.com/slides/ja/python-java/aspose.slides/scaleeffect/#getBy) が相対変化を示します。ここで 100 は元のサイズを意味します。

例では 2 秒間で 100% から 125% へ両寸法を拡大します。水平・垂直のパーセンテージを同じにすれば図形の比例が保たれ、異なるパーセンテージにすると一方の寸法が伸びます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **色**

[createColorEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createColorEffect) を使用して塗りを青からオレンジに変更します。[getFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/coloreffect/#getFrom) と [getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/coloreffect/#getTo) は色、[getBy](https://reference.aspose.com/slides/ja/python-java/aspose.slides/coloreffect/#getBy) は色オフセットです。[Behavior.getProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behavior/#getProperties) はアニメーション対象の属性を特定します。

図形の塗りは青で初期化され、アニメーションの開始色と一致します。塗り色属性を選択することで、ビヘイビアが図形のどの部分を変更すべきかが決まります。保存された効果は 2 秒でオレンジへ遷移することを記述しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **フィルタ**

[createFilterEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createFilterEffect) を使用してワイプを選択します。[getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filtereffect/#getType)、[getSubtype](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filtereffect/#getSubtype)、[getReveal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filtereffect/#getReveal) がそれぞれフィルタ、方向、表示/非表示を指定します。

この例は右方向サブタイプで図形を表示する 2 秒のワイプを設定します。フィルタ設定は効果内のビヘイビアに属するため、プリセットの元の操作を除去した後に構成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **プロパティ**

[createPropertyEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) を使用して不透明度をアニメーション化します。[getFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/propertyeffect/#getFrom)、[getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/propertyeffect/#getTo)、[getBy](https://reference.aspose.com/slides/ja/python-java/aspose.slides/propertyeffect/#getBy) は文字列で、[getValueType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/propertyeffect/#getValueType) と [getCalcMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/propertyeffect/#getCalcMode) によって解釈されます。3 つすべてを同時に設定するのではなく、終点または相対オフセットを選択してください。

ここでは属性として不透明度を選び、数値文字列は 25% から 100% への変化を表します。線形補間により徐々に変化します。この例を別の属性に適用する場合は、その属性に適した値タイプと終点値を選択してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **設定**

[createSetEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createSetEffect) を使用して [getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/seteffect/#getTo) により可視性を設定します。設定ビヘイビアは終点間を補間しません。

例では可視性属性を選択し、ビヘイビア実行時に文字列 `visible` を割り当てます。この最小プレゼンテーションでは矩形はすでに表示されているため、単独では目に見える変化はありません。より大きな効果の一部として、図形の表示／非表示を制御する際に有用です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **コマンド**

[createCommandEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createCommandEffect) を使用し、[getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commandeffect/#getType)、[getCommandString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commandeffect/#getCommandString)、[getShapeTarget](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commandeffect/#getShapeTarget) を構成します。作業ディレクトリに `sample.wav` という WAV 録音を配置してください。この例は [addAudioFrameEmbedded](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) で埋め込み、再生コマンドをオーディオ フレームに付与します。

オーディオ フレームは効果のターゲットでもコマンドのターゲットでもあるため、再生要求が埋め込み録音に結び付けられます。コマンド文字列単体ではどのメディア オブジェクトを制御するか特定できません。効果はスライドショー中のクリックで開始するよう設定されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存すると `command.pptx` にコマンドが格納されますが、録音は再生されません。再生にはコマンドとメディア ターゲットをサポートするスライドショー プレーヤーが必要です。

## **ビヘイビア コレクションの管理**

[BehaviorCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/) は [add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/#add)、[insert](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/#insert)、[remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/#remove)、[removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/#removeAt) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動し、回転を削除します。同一オブジェクトを削除して再挿入するとコピーは作成されず位置が変更されます。

編集の順序によりコレクションは回転‑拡大縮小 → 拡大縮小‑回転 → 拡大縮小 の順に変化します。インデックスは現在のコレクションを基準とするため、再配置後の回転の新しいインデックスで削除が行われます。最終的な列挙で保存されるビヘイビアが確認できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

出力は `ScaleEffect` のみで、拡大縮小だけが残ります。コレクションの順序だけでビヘイビアが連続して実行されるわけではありません。すべての操作を置き換えるときだけ `clear` を使用してください。

## **ビヘイビア タイミングの設定**

[Behavior.getTiming](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behavior/#getTiming) は [Timing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/) を公開し、[Effect.getTiming](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getTiming) とは独立しています。Effect のタイミングは外側の効果全体をスケジュールし、ビヘイビアのタイミングはその内部操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、期間 ([getDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getDuration)) とトリガー遅延 ([getTriggerDelayTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getTriggerDelayTime)) を秒単位で設定し、[setRepeatCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#setRepeatCount) で繰り返し回数を構成します。[getAccelerate](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getAccelerate) と [getDecelerate](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getDecelerate) は期間の割合で、合計が 1 以下になるようにします。

入力ファイルは回転例で作成したものです。最初のビヘイビアが回転であることが分かっているので、この例ではそのビヘイビアのタイミングのみ変更し、90 度の角度はそのままにします。角度とタイミングを分離しておくと、アニメーションを再構築せずにペースを調整しやすくなります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

このビヘイビアは 2 秒の期間、0.5 秒の遅延、繰り返し回数 3 を使用します。期間の最初と最後の 20% が加速と減速に割り当てられます。

他の繰り返しポリシーには [getRepeatDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatDuration)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getRepeatUntilNextClick) があり、すべて同時に有効にするのではなく 1 つを選択します。[getAutoReverse](https://reference.aspose.com/slides/ja/python-java/aspose.slides/timing/#getAutoReverse) は前進後に逆再生します。加速・減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[createMotionEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorfactory/#createMotionEffect) を使用してモーションを作成します。[getFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#getFrom)、[getTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#getTo)、[getBy](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#getBy) はパーセンテージベースの座標またはオフセットを表します。編集可能なルートを作成するには [MotionPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpath/) を生成し、[MotionEffect.setPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#setPath) で割り当てます。[MotionPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpath/) はパス コマンドを保持します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncommandpathtype/) は操作種別を選択します：

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定 |
| LineTo | 1 | 直線セグメントの終点へ移動 |
| CurveTo | 3 | 2 つの制御点と終点で定義される三次ベジェ曲線に従う |
| CloseLoop | 0 | 開始位置に戻る |
| End | 0 | パスを終了 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpathpointstype/) はポイントの編集特性（コーナーかスムーズか）を表し、コマンド種別を置き換えるものではありません。以下の曲線例では曲線ポイントタイプ、直線セグメントではコーナーポイントタイプを使用します。

パス座標はスライド寸法に正規化されます。X の 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは [getOrigin](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#getOrigin)（パスの基準フレーム）や [getPathEditMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioneffect/#getPathEditMode)（図形移動時のパス動作）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーション ビヘイビアを作成します。[MotionPath.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpath/#add) はコマンド種別、ポイント配列、ポイント種別、相対座標フラグを受け取ります。

開始コマンドで (0, 0) を設定し、線分は (0.25, 0) で終わります。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標ポイントがありません。パスが割り当てられたら、モーション ビヘイビアを効果に追加して矩形に結び付けます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` には 3 つのパス コマンドを持つ 1 つのモーション ビヘイビアが含まれます。以下のファイル編集例はこの構造を前提とします。

### **絶対座標と相対座標の比較**

この 2 つのパス オブジェクトは同一ルートを表します。絶対コマンドは (0.3, 0.1) で終わり、相対コマンドは現在位置に (0.1, 0.1) を加算して (0.2, 0) になります。

両パスは同じ開始位置から始まります。相対ラインはオフセットを現在位置に加えて終点を得ますが、絶対ラインは終点を直接読み取ります。フラグだけを切り替えて座標を変換しないと、異なるルートになります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

どちらかのパスをモーション ビヘイビアに割り当ててプレゼンテーションで使用できます。最後の Boolean 引数はそのコマンドが相対座標かどうかを選択します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。まず 2 つの制御点、続いて終点を指定します。

開始位置は直前のコマンドから供給されます。最初の 2 点が曲線を形作り、3 番目が目的地です。コマンド種別、ポイント編集種別、ポイント配列を同時に更新すると、セグメントが新しいジオメトリに一貫して保持されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ち、真ん中のコマンドが曲線になっています。

## **保存されたパスの検査と編集**

各 [MotionCmdPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncmdpath/) は [getPoints](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncmdpath/#getPoints)、[getCommandType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncmdpath/#getCommandType)、[getPointsType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncmdpath/#getPointsType)、[isRelative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motioncmdpath/#isRelative) を公開します。以下の例は `motion.pptx` にある既知の 3 コマンド パスを使用します。任意の入力では、編集前に対象効果を特定し、コマンド種別とポイント数をインデックスで確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了コマンドやクローズループコマンドはポイントが不要なので、null 配列に対応できるようにします。

出力は数値のコマンド種別と相対座標フラグのペアを示し、その後にポイントが列挙されます。これにより、パスを変更する前に終点とオフセットを区別できます。曲線は 3 点を列挙し、こちらのファイルの直線は 1 点だけです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

一覧には開始点、(0.25, 0) で終わる絶対ライン、終了コマンドが含まれます。

### **終点の変更**

`motion.pptx` を開き、ラインのポイント配列を置き換えて終点を移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 がラインです。ラインの単一ポイントを置き換えることで、コマンド種別、タイミング、コレクション内の位置は変更せずに目的地を変更できます。コマンドが絶対座標を使用しているため、新しいペアはオフセットではなく位置を指定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` のラインは (0.4, 0.1) で終わります。元のファイルは変更されません。

### **セグメントの置き換え**

[insert](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpath/#insert) と [removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/motionpath/#removeAt) を使用して `motion.pptx` のラインを置き換えます。挿入により古いラインはインデックス 2 にシフトします。

この手順は既存座標を編集するのではなく、コマンドオブジェクト自体を置き換えることを示しています。挿入後、コレクションは一時的に開始コマンド、新しいライン、古いライン、終了コマンドの順序になります。インデックス 2 を削除すると古いラインが除去され、新しいルートが残ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存されたパスは依然として 3 コマンドで、新しいラインは (0.2, 0.1) で終わり、最後に終了コマンドがあります。

## **既存ビヘイビアの変更と検証**

ビヘイビアのインデックスが不明な場合はタイプで選択します。この例は `rotation.pptx` を開き、[RotationEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotationeffect/) を見つけて角度を変更し、再オープン後に保存値を確認します。

タイプチェックにより、回転でないビヘイビアはループでスキップされます。2 回目の読み込みは保存されたファイルを別のプレゼンテーション オブジェクトに読み込み、メモリ上の値ではなく永続化されたデータを比較します。この例は既知の効果がメイン シーケンスの最初にあることを前提としています。タイプでビヘイビアを選択しても、任意のプレゼンテーションで正しい効果が見つかるとは限りません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

出力は `Rotation preserved: True` となります。同様のタイプチェック パターンを他のビヘイビアにも適用してください。完全な保持チェックでは、対象図形、効果、ビヘイビアの種類と順序、タイミング、パス コマンドを比較し、浮動小数点値には数値的許容差を使用します。アニメーション構成が不明なプレゼンテーションについては、[シェイプ アニメーションの読み取り](/slides/ja/python-java/shape-animation/#read-shape-animations) を参照してください。

## **ビヘイビアの順序、プリセット、再生**

[BehaviorCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behaviorcollection/) の順序は効果の操作が格納される順序であり、すべてのビヘイビアが自動的に前のものを待つプレイリストではありません。スケジューリングはタイミングと外側の効果が決定します。ビヘイビアは重なり合うことができ、同じプロパティに対する操作は [getAdditive](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behavior/#getAdditive) や [getAccumulate](https://reference.aspose.com/slides/ja/python-java/aspose.slides/behavior/#getAccumulate) を通じて相互作用します。単にコレクションの順序を変えるだけで “移動してから回転” を実現しようとしないでください。明示的なタイミングまたは別効果を使用してください（[シェイプ アニメーション](/slides/ja/python-java/shape-animation/) を参照）。

効果の [getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getType) と [getSubtype](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effect/#getSubtype) はプリセットを記述しますが、編集されたビヘイビア ツリーの完全な記述ではありません。ビヘイビアをカスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタム Spin 効果を Fade に変更すると、回転ビヘイビアが設定やフィルタ ビヘイビアに置き換わります。プリセットやサブタイプを変更した後はコレクションを再度確認してください。プリセットの可視性や初期化操作をクリアすると、プリセットが必要とする操作が失われることがあります。例はすべて可視の図形を使用し、ビヘイビアを置き換えているため、各プリセットの実装全体を再構築していません。

## **形式の互換性**

保持されたビヘイビア ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を個別に確認してください。

| 形式または出力 | 確認すべき項目 |
| --- | --- |
| PPTX | 本例の主な形式として使用。再オープンして編集可能なビヘイビア ツリーを確認し、目的の PowerPoint バージョンで再生をチェック。 |
| PPT | レガシー バイナリ表現は PPTX と異なる場合があります。別途保存‐再オープンサイクルと再生をテストし、PPTX の成功だけで全組み合わせのサポートを推測しないでください。 |
| PDF、PNG、JPEG などの静的スライド画像 | 静的なスライド表現であり、再生可能なビヘイビア タイムラインや最終フレームの保証はありません。 |
| [HTML5](/slides/ja/python-java/export-to-html5/) | エクスポート オプションでシェイプ アニメーションを有効にすればサポートされるアニメーションを再生できます。ブラウザでカスタム組み合わせをテストしてください。 |
| [Animated GIF](/slides/ja/python-java/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保持しますが、編集可能なビヘイビアやクリック トリガーはありません。実際のモーションを確認してください。 |
| [Video](/slides/ja/python-java/convert-powerpoint-to-video/) | アニメーション フレームをレンダリングし動画としてエンコードします。サポートはレンダラの [supported animations and effects](/slides/ja/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインになりません。 |

## **FAQ**

**なぜ効果にビヘイビアが既に含まれているのですか？**

事前定義された効果を作成すると、基になる操作が自動的に生成されることがあります。プリセットを拡張するかビヘイビアを置き換えるかを決める前に、まずそれらを検査してください。

**ビヘイビアを先頭に移動すれば最初に再生されますか？**

必ずしもそうとは限りません。コレクションの順序はタイミングの代替にはなりません。遅延、期間、同一プロパティ上の操作間の相互作用を確認してください。

**なぜ終了コマンドにポイントがありませんか？**

終了コマンドはパスの終端を示すだけで座標は不要です。ファイルからパスを読み取る際は、null のポイント配列があるかどうかをチェックしてください。

**往復保存だけで再生が確認できるのですか？**

いいえ。再オープンはチェックしたプロパティの保持を確認しますが、スライドショー プレーヤーやアニメーション エクスポートでの実際の視覚的な動作は別途テストしてください。