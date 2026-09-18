---
title: "Javaでカスタム アニメーション ビヘイビアを作成および変更する"
linktitle: "カスタム アニメーション"
type: docs
weight: 151
url: /ja/java/custom-animation/
keywords:
- "カスタム アニメーション"
- "アニメーション ビヘイビア"
- "モーション パス"
- "PowerPoint"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内のカスタム アニメーション ビヘイビアと編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタムアニメーション ビヘイビアを使用すると、色の変更、形状の回転、編集可能なモーション パスの追従など、アニメーション効果内の個々の操作を制御できます。このガイドでは、ビヘイビアの作成と組み合わせ、タイミングの構成、既存のアニメーションの検査と変更、そしてプロパティがプレゼンテーションの保存と再オープン後も保持されることを確認する方法を示します。

事前定義された効果やクリック トリガーについては、[Shape Animation](/slides/ja/java/shape-animation/) を参照してください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます。

- [getTimeline](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getTimeline--) メソッドはスライドのタイムラインを返し、メイン シーケンスとインタラクティブ シーケンスを含みます。
- [ISequence](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/) は効果を保持し、異なる形状を対象にできる場合があります。
- [IEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/) は対象形状、プリセット、サブタイプ、効果のタイミングを識別します。
- [IEffect.getBehaviors](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getBehaviors--) が返すコレクションには、色の変更、移動、回転、プロパティ設定など、効果を実装する操作が含まれます。

## **個々のビヘイビアの作成**

[ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) を呼び出して効果を作成し、[getBehaviors](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getBehaviors--) コレクションにアクセスします。プリセットはこのコレクションを自動的に構成できます。プリセットを拡張する際はその操作を保持し、意図的に置き換える場合は [clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/#clear--) を使用します。

[IBehaviorFactory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/) は以下に示す 8 種類のビヘイビアを生成します。モーションは [Build a Motion Path](#build-a-motion-path) で扱います。各スニペットにはインポートが含まれます。実行文はメソッド内に配置してください。後の編集例では使用する出力ファイルを示します。

### **回転**

[createRotationEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) で回転効果を作成します。[getBy](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irotationeffect/#getBy--) は相対角度（度）を指定し、[getFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irotationeffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irotationeffect/#getTo--) は開始点と終了点を指定します。

この例は Spin 効果で開始し、プリセットの操作を 1 つの回転ビヘイビアに置き換え、継続時間を 2 秒に設定します。90 度の相対角度は形状の開始向きからの 1/4 回転を表すため、明示的な開始角度は不要です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` には 1 つの形状と 1 つの回転ビヘイビアが含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[createScaleEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) を X/Y パーセンテージで使用します。[getFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iscaleeffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iscaleeffect/#getTo--) は開始サイズと終了サイズを示し、[getBy](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iscaleeffect/#getBy--) は相対変化を示します。ここで 100 は元のサイズです。

例では両方の次元を 100% から 125% に 2 秒かけて拡大します。水平・垂直のパーセンテージを同等にすると形状の比率が保たれ、異なるパーセンテージにすると一方の次元が伸びます。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **カラー**

[createColorEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) で塗りつぶしを青からオレンジに変更します。[getFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icoloreffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icoloreffect/#getTo--) は色を示し、[getBy](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icoloreffect/#getBy--) はカラー オフセットです。[IBehavior.getProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehavior/#getProperties--) はアニメーション対象の属性を特定します。

形状の実体塗りは青で初期化され、アニメーションの開始色と一致します。塗りつぶしカラー属性を選択することで、どの部分を変更すべきかビヘイビアに指示します。保存された効果は 2 秒でオレンジに遷移することを記述しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **フィルタ**

[createFilterEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) でワイプを選択します。[getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifiltereffect/#getType--)、[getSubtype](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifiltereffect/#getSubtype--)、[getReveal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifiltereffect/#getReveal--) がそれぞれフィルタ、方向、表示/非表示を指定します。

この例は右方向サブタイプで形状を表示する 2 秒のワイプを構成します。フィルタ設定は効果内のビヘイビアに属するため、プリセットの元の操作を削除した後に設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **プロパティ**

[createPropertyEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) で不透明度をアニメーション化します。[getFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipropertyeffect/#getFrom--)・[getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipropertyeffect/#getTo--)・[getBy](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipropertyeffect/#getBy--) は文字列で、[getValueType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipropertyeffect/#getValueType--) と [getCalcMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) によって解釈されます。3 つすべてを無差別に設定せず、エンドポイントまたは相対オフセットのいずれかを選択してください。

ここでは属性として不透明度を選び、数値文字列で 25% から 100% への変化を表します。線形補間により段階的に変化します。他の属性に適用する場合は、その属性に適した値タイプとエンドポイント値を選びます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **設定**

[createSetEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) を使用して、[getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iseteffect/#getTo--) により可視性を割り当てます。セット ビヘイビアはエンドポイント間を補間しません。

例では可視性属性を選択し、ビヘイビア実行時に文字列 `visible` を設定します。最小構成のプレゼンテーションでは矩形は既に表示されているため、単独では視覚的変化が顕著でないことがあります。これは、形状の表示/非表示を制御する他の効果と組み合わせて使用するのに有用です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **コマンド**

[createCommandEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) を使用し、[getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icommandeffect/#getType--)・[getCommandString](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icommandeffect/#getCommandString--)・[getShapeTarget](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icommandeffect/#getShapeTarget--) を構成します。作業ディレクトリに `sample.wav` という WAV 録音ファイルを配置してください。この例では [addAudioFrameEmbedded](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) で埋め込み、再生コマンドをオーディオフレームに付加します。

オーディオフレームは効果の対象でもあり、コマンドの対象でもあります。これにより再生要求が埋め込み録音に結び付けられ、単なるコマンド文字列だけではどのメディアオブジェクトを制御すべきか特定できません。効果はスライドショー中のクリックで開始するよう構成されています。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

保存により `command.pptx` にコマンドが格納されますが、録音は再生されません。再生にはコマンドとメディア対象をサポートするスライドショー プレイヤーが必要です。

## **ビヘイビア コレクションの管理**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/) は [add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)、[insert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)、[remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)、[removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動させ、回転を削除します。同一オブジェクトの削除と再挿入によりコピーを作成せずに位置が変更されます。

編集シーケンスはコレクションを「回転→拡大縮小」から「拡大縮小→回転」へ、さらに「拡大縮小」のみへと変化させます。インデックスは現在のコレクションを基にするため、再配置後の回転の新しいインデックスが使用されます。最終的な列挙で保存されるビヘイビアが確認できます。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

出力は `ScaleEffect` のみで、拡大縮小だけが残ります。コレクションの順序自体はビヘイビアを連続再生させるスケジューリングを意味しません。すべての操作を置き換える場合にのみコレクションをクリアしてください。

## **ビヘイビア タイミングの構成**

[IBehavior.getTiming](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehavior/#getTiming--) は [ITiming](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/) を露出し、[IEffect.getTiming](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getTiming--) とは独立しています。効果タイミングは囲む効果全体のスケジュールを決定し、ビヘイビアタイミングはその内部の操作を記述します。

### **継続時間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、継続時間 ([getDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getDuration--)) とトリガー遅延 ([getTriggerDelayTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) を秒単位で設定し、[setRepeatCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#setRepeatCount-float-) で繰り返し回数を構成します。[getAccelerate](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getAccelerate--) と [getDecelerate](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getDecelerate--) は継続時間の割合で、合計は最大 1 としてください。

入力ファイルは回転例で作成したものです。最初のビヘイビアが回転であることが分かっています。この例ではそのビヘイビアのタイミングのみを変更し、90 度の角度はそのまま保持します。角度とタイミングを別々に管理することで、アニメーション全体を再構築せずにペース調整が容易になります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

このビヘイビアは 2 秒の継続時間、0.5 秒の遅延、繰り返し回数 3 を使用し、継続時間の最初と最後の 20% が加速と減速に使われます。

他の繰り返しポリシーとしては [getRepeatDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatDuration--)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) があり、すべて同時に有効にするのではなく 1 つを選択してください。[getAutoReverse](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getAutoReverse--) は前進後にアニメーションを逆再生します。加速と減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[createMotionEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) でモーションを作成します。[getFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#getFrom--)・[getTo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#getTo--)・[getBy](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#getBy--) はパーセンテージベースの座標またはオフセットを示します。編集可能な経路を作成するには [MotionPath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/motionpath/) を生成し、[IMotionEffect.setPath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) で割り当てます。[IMotionPath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotionpath/) はパス コマンドを保持します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/motioncommandpathtype/) が操作を選択します。

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定 |
| LineTo | 1 | 直線セグメントを終点まで移動 |
| CurveTo | 3 | 2 つの制御点と終点で定義される三次ベジエ曲線に従う |
| CloseLoop | 0 | 開始位置に戻る |
| End | 0 | パスを終了 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/motionpathpointstype/) はポイントの編集特性（コーナーまたはスムーズ）を示し、コマンドタイプの代替ではありません。下の曲線例では曲線ポイントタイプ、直線セグメントではコーナーポイントタイプを使用します。

パス座標はスライド寸法に正規化されます。X 変位 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは [getOrigin](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#getOrigin--) （パスの基準フレーム選択）や [getPathEditMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioneffect/#getPathEditMode--)（形状移動時のパスの動作制御）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーション ビヘイビアを作成します。[IMotionPath.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) はコマンドタイプ、ポイント配列、ポイントタイプ、相対座標フラグを受け取ります。

開始コマンドは (0, 0) を設定し、直線は (0.25, 0) で終了します。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドは座標ポイントを持ちません。パスを割り当てた後、モーション ビヘイビアを効果に追加すると、そのルートが矩形に接続されます。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` には 3 つのパス コマンドを持つ 1 つのモーション ビヘイビアが含まれます。以下のファイル編集例はこの構造を前提としています。

### **絶対座標と相対座標の比較**

この 2 つのパス オブジェクトは同一ルートを表します。絶対コマンドは (0.3, 0.1) に終了し、相対コマンドは現在位置に (0.1, 0.1) を加えて (0.2, 0) に到達します。

両方のパスは同じ位置で開始します。相対線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対線の場合は終点を直接読み取ります。座標変換せずにフラグだけ切り替えると別のルートになります。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

いずれかのパスをモーション ビヘイビアに割り当ててプレゼンテーションで使用できます。最後の Boolean 引数はそのコマンドに相対座標を使用するかどうかを選択します。

### **直線を曲線に置換**

`motion.pptx` を開き、直線コマンドを三次曲線に置換します。まず 2 つの制御点を、続いて終点を指定します。

開始位置は前のコマンドで供給されます。最初の 2 点が曲線を形作り、3 番目が終点です。3 点が連続した終点という意味ではありません。コマンドタイプ、ポイント編集タイプ、ポイント配列を同時に更新すると、新しいジオメトリに合わせてセグメントが一貫します。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` のパスは依然として 3 コマンドですが、真ん中のコマンドが曲線になっています。

## **保存されたパスの検査と編集**

各 [IMotionCmdPath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioncmdpath/) は [getPoints](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioncmdpath/#getPoints--)・[getCommandType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioncmdpath/#getCommandType--)・[getPointsType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioncmdpath/#getPointsType--)・[isRelative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotioncmdpath/#isRelative--) を公開します。以下の例は `motion.pptx` の既知の 3 コマンド パスを使用します。任意の入力に対しては、編集前に対象効果を特定し、コマンドタイプとポイント数をインデックスで確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了コマンドとクローズループコマンドはポイントを必要としないため、null のポイント配列を許容します。

出力は各数値コマンドタイプと相対座標フラグをペアで示し、その後にポイントを列挙します。これにより、パスを変更する前にエンドポイントとオフセットを区別できます。曲線は 3 点を、直線は 1 点だけを一覧表示します。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

このリストには開始点、(0.25, 0) に終了する絶対直線、そして終了コマンドが含まれます。

### **エンドポイントの変更**

`motion.pptx` を開き、直線のポイント配列を置換してエンドポイントを移動させます。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一ポイントを置換すると、コマンドタイプ、タイミング、コレクション内位置は変わらず、目的地だけが変更されます。コマンドが絶対座標を使用しているため、新しいペアは位置を示します。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` の直線は (0.4, 0.1) に終了し、元ファイルは変更されていません。

### **セグメントの置換**

[insert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) と [removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imotionpath/#removeAt-int-) を使用して `motion.pptx` の直線を置換します。挿入により古い直線はインデックス 2 にシフトします。

この手法は既存座標を編集するのではなく、コマンドオブジェクト自体を置換することを示します。挿入後、コレクションは一時的に開始コマンド、新しい直線、古い直線、終了コマンドの順に含まれます。インデックス 2 を削除すると古い直線が除去され、新しいルートが残ります。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたパスは依然として 3 コマンドで、新しい直線は (0.2, 0.1) に終了し、終了コマンドが最後にあります。

## **既存ビヘイビアの変更と検証**

ビヘイビアのインデックスが不明な場合はタイプで選択します。この例では `rotation.pptx` を開き、[IRotationEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irotationeffect/) を検索し、角度を変更し、再オープン後に保存値を確認します。

タイプチェックにより回転でないビヘイビアはループでスキップされます。2 回目のロードは保存されたファイルを別のプレゼンテーション オブジェクトに読み込み、比較はメモリ上の値ではなく永続化データを対象とします。この例は既知の効果がメインシーケンスの最初にあることを前提としています。任意のプレゼンテーションで正しい効果を見つけるには、タイプでビヘイビアを選択するだけでは不十分です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

出力は `Rotation preserved: true` です。その他のビヘイビアでも同様のタイプチェックパターンを適用してください。完全な保存確認には対象形状、効果、ビヘイビアタイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値許容差を使用します。アニメーション構成が不明なプレゼンテーションについては、[Read Shape Animations](/slides/ja/java/shape-animation/#read-shape-animations) を参照し、メインとインタラクティブ シーケンスの走査方法を確認してください。

## **ビヘイビアの順序、プリセット、再生**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehaviorcollection/) の順序は効果操作の保存順序であり、各ビヘイビアが自動的に前のビヘイビアを待つプレイリストではありません。スケジューリングはタイミングと囲む効果が決定します。ビヘイビアは重複して再生でき、同一プロパティへの操作は [getAdditive](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehavior/#getAdditive--) や [getAccumulate](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibehavior/#getAccumulate--) を通じて相互作用します。「移動 → 回転」のように順序だけでスケジューリングしようとせず、[Shape Animation](/slides/ja/java/shape-animation/) で説明したように明示的なタイミングまたは別々の効果を使用してください。

効果の [getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getType--) と [getSubtype](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getSubtype--) はプリセットを記述しますが、編集されたビヘイビア ツリーの完全な説明ではありません。ビヘイビアをカスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタマイズした Spin 効果を Fade に変更すると、回転ビヘイビアがセットやフィルタ ビヘイビアに置き換わります。プリセットやサブタイプを変更した後はコレクションを再度検査してください。プリセットのビヘイビアをクリアすると、プリセットが必要とする可視化や初期化操作も失われることがあります。例では可視形状を使用し、ビヘイビアを置換しているため、すべてのプリセット実装を再構築してはいません。

## **フォーマット互換性**

保存されたビヘイビア ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を別々に確認してください。

| フォーマットまたは出力 | 確認項目 |
| --- | --- |
| PPTX | 例の主要フォーマットとして使用。再オープンして編集可能なビヘイビア ツリーを確認し、目的の PowerPoint バージョンで再生をチェック |
| PPT | レガシーのバイナリ表現は PPTX と異なる可能性あり。別途保存‑再オープンサイクルと再生をテストし、PPTX の成功だけですべての組み合わせがサポートされると推測しない |
| PDF、PNG、JPEG などの静的スライド画像 | 静的なスライド表現であり、再生可能なビヘイビア タイムラインや最終アニメーション フレームは保証されない |
| [HTML5](/slides/ja/java/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にするとサポートされるアニメーションを再生可能。ブラウザでカスタム組み合わせをテスト |
| [Animated GIF](/slides/ja/java/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保存するが、編集可能なビヘイビアやクリック トリガーは含まれない。実際のモーションを確認 |
| [Video](/slides/ja/java/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングし動画としてエンコード。サポートはレンダラの [supported animations and effects](/slides/ja/java/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインに変換されない |

## **FAQ**

**効果にビヘイビアが何も追加していないのに含まれているのはなぜですか？**

事前定義された効果を作成すると、その基礎となる操作が生成されることがあります。ビヘイビアを拡張するか置換するかを判断する前に、まずそれらを検査してください。

**ビヘイビアを先頭に移動すれば最初に再生されますか？**

必ずしもそうではありません。コレクション順序はタイミングの代替にはなりません。遅延、継続時間、同一プロパティへの操作間の相互作用を確認してください。

**終了コマンドにポイントがないのはなぜですか？**

終了コマンドはパスの終端を示すだけで、座標は不要です。ファイルから読み取ったパスを検査する際は、ポイント配列が null である可能性を考慮してください。

**往復保存だけで再生が確認できるのですか？**

いいえ。再オープンはプロパティが保持されたことを確認しますが、スライドショー プレイヤーやアニメーション エクスポートで実際の視覚的動作を別途テストする必要があります。