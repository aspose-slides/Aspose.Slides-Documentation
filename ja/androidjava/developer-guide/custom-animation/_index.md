---
title: Androidでカスタム アニメーション ビヘイビアを作成および変更する
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/androidjava/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション ビヘイビア
- モーション パス
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides で、PowerPoint プレゼンテーションのカスタム アニメーション ビヘイビアおよび編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタム アニメーション ビヘイビアを使用すると、カラーの変更、シェイプの回転、編集可能なモーション パスの追従など、アニメーション効果内の個々の操作を制御できます。このガイドでは、ビヘイビアの作成と組み合わせ、タイミングの設定、既存アニメーションの検査と変更、そしてプレゼンテーションの保存と再オープン後もプロパティが保持されることを確認する方法を示します。

事前定義済みの効果やクリック トリガーについては、[シェイプ アニメーション](/slides/ja/androidjava/shape-animation/)をご覧ください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** と構成されます。

- The [getTimeline](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) メソッドはスライドのタイムラインを返し、メイン シーケンスとインタラクティブ シーケンスが含まれます。
- An [ISequence](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/) は効果を含み、異なるシェイプを対象にすることがあります。
- An [IEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/) は対象シェイプ、プリセット、サブタイプ、効果のタイミングを識別します。
- The collection returned by [IEffect.getBehaviors](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getBehaviors--) が返すコレクションには、効果を実装する操作（カラーの変更、移動、回転、プロパティの設定など）が含まれます。

## **個別ビヘイビアの作成**

[ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) を呼び出して効果を作成し、[getBehaviors] コレクションにアクセスします。プリセットはこのコレクションを自動的に構成できます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は [clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) を使用します。

[IBehaviorFactory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/) は下記に示す 8 つのビヘイビア タイプを作成します。モーションは [モーション パスの作成](#build-a-motion-path) で取り上げられています。各スニペットにはインポートが含まれ、実行文はメソッド内に配置してください。後の編集例では使用する出力ファイルが示されています。Android では、サンプルファイル名をアプリがアクセス可能なディレクトリ（例：アプリの files ディレクトリ）内の完全パスに置き換えてください。

### **回転**

[createRotationEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) を使用して回転を作成します。[getBy](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/irotationeffect/#getBy--) は相対角度（度）を指定し、[getFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/irotationeffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/irotationeffect/#getTo--) は終点を指定します。

例では Spin 効果から開始し、プリセットの操作を 1 つの回転ビヘイビアに置き換え、その操作に 2 秒の期間を設定します。90 度の相対角度はシェイプの開始向きからの 1/4 回転を表すため、明示的な開始角度は不要です。

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

`rotation.pptx` には 1 つのシェイプと 1 つの回転ビヘイビアが含まれます。以下のコレクション、タイミング、回転編集の例はこのファイルを使用します。

### **拡大縮小**

[createScaleEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) を X/Y パーセンテージで使用します。[getFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iscaleeffect/#getTo--) は開始サイズと終了サイズを表し、[getBy](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iscaleeffect/#getBy--) は相対変化を表します。ここで 100 は元のサイズを意味します。

例では両方の次元を 100% から 125% に 2 秒かけて拡大します。水平・垂直のパーセンテージを同じにするとシェイプの比率が保たれ、異なるパーセンテージにすると一方の次元がより伸びます。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **カラー**

[createColorEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) を使用して塗りを青からオレンジに変更します。[getFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icoloreffect/#getFrom--) と [getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icoloreffect/#getTo--) はカラーで、[getBy](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icoloreffect/#getBy--) はカラーオフセットです。[IBehavior.getProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehavior/#getProperties--) はアニメーション対象の属性を特定します。

シェイプの単色塗りは青で初期化され、アニメーションの開始カラーに一致します。塗りカラー属性を選択することで、ビヘイビアがシェイプのどの部分を変更すべきかが決まります。カラーの終点だけでは属性は特定できません。保存された効果は 2 秒でオレンジに遷移することを記述しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **フィルタ**

[createFilterEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) を使用してワイプを選択します。[getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifiltereffect/#getType--)、[getSubtype](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--)、[getReveal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) がフィルタ、方向、そしてシェイプを表示するか隠すかを指定します。

この例では右方向サブタイプでシェイプを表示する 2 秒間のワイプを設定します。フィルタ設定は効果内のビヘイビアに属するため、プリセットの元の操作を削除した後に構成します。

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

[createPropertyEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) を使用して不透明度をアニメーションします。[getFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--)、[getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipropertyeffect/#getTo--)、[getBy](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) は文字列で、[getValueType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) と [getCalcMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) によって解釈されます。すべてのパラメータを同時に設定するのではなく、終点または相対オフセットを選択してください。

ここでは属性として不透明度を選択し、文字列は 25% の不透明度から完全不透明度への変化を表します。線形補間によりこれらの値の間を徐々に変化します。この例を別の属性に適用する場合は、その属性に適した値タイプと終点値を選択してください。

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

[createSetEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) を使用して [getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iseteffect/#getTo--) により可視性を割り当てます。Set ビヘイビアは終点間を補間しません。

例では可視性属性を選択し、ビヘイビア実行時に文字列 `visible` を設定します。最小限のプレゼンテーションでは矩形は既に可視なので、単独では明確な視覚変化は見られないかもしれません。この操作は、シェイプの表示/非表示を制御する他のビヘイビアと組み合わせる際に有用です。

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

[createCommandEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) を使用し、[getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommandeffect/#getType--)、[getCommandString](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommandeffect/#getCommandString--)、[getShapeTarget](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) を構成します。作業ディレクトリに `sample.wav` という WAV 録音を配置してください。この例では [addAudioFrameEmbedded](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) で埋め込み、再生コマンドをオーディオ フレームに付加します。

オーディオ フレームは効果のターゲットでもあり、コマンドのターゲットでもあります。これにより再生要求が埋め込み録音に結び付けられます。コマンド文字列単体ではどのメディアオブジェクトを制御するか特定できません。効果はスライドショー中のクリックで開始するよう構成されています。

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

保存するとコマンドは `command.pptx` に格納されますが、録音は再生されません。再生にはコマンドとメディアターゲットをサポートするスライドショー プレーヤーが必要です。

## **ビヘイビア コレクションの管理**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/) は [add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)、[insert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)、[remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)、[removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動させ、回転を削除します。同じオブジェクトを削除して再挿入すると、コピーを作らずに格納位置が変更されます。

編集のシーケンスによりコレクションは rotation–scale → scale–rotation → scale の順に変化します。インデックスは現在のコレクションを基準にするため、再配置後の回転の新しいインデックスを使用して削除します。最終的な列挙で保存されるビヘイビアが確認できます。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

出力は `ScaleEffect`：拡大縮小のみが残ります。コレクション順序自体はビヘイビアを連続して実行させるスケジューリングにはなりません。すべての操作を置き換えるときだけコレクションをクリアしてください。

## **ビヘイビア タイミングの構成**

[IBehavior.getTiming](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehavior/#getTiming--) は [ITiming](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/) を公開し、[IEffect.getTiming](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getTiming--) とは独立しています。効果のタイミングはエンclosing effect をスケジュールし、ビヘイビアのタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、秒単位で期間 ([getDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getDuration--)) とトリガー遅延 ([getTriggerDelayTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) を設定し、[setRepeatCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) で繰り返し回数を構成します。[getAccelerate](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getAccelerate--) と [getDecelerate](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getDecelerate--) は期間の分数であり、合計は最大で 1 にしてください。

入力ファイルは回転例で作成したものです。最初のビヘイビアが回転であることが分かっています。この例ではそのビヘイビアのタイミングだけを変更し、90 度の角度はそのまま保持します。角度とタイミングを分離しておくと、アニメーション全体を再構築せずに速度調整が容易になります。

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

ビヘイビアは 2 秒の期間、0.5 秒の遅延、繰り返し回数 3 回を使用します。期間の最初と最後の 20% が加速と減速に使われます。

他の繰り返しポリシーとしては [getRepeatDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatDuration--)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) があり、すべて同時に有効にせずにポリシーを選択してください。[getAutoReverse](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getAutoReverse--) は前方再生の後に逆方向でアニメーションを再生します。加速と減速は連続した変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[createMotionEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) を使用してモーションを作成します。その [getFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#getFrom--)、[getTo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#getTo--)、[getBy](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#getBy--) はパーセンテージベースの座標またはオフセットを表します。編集可能なルートを作成するには [MotionPath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/motionpath/) を生成し、[IMotionEffect.setPath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) で割り当てます。[IMotionPath] はパスコマンドを格納します。

[MotionCommandPathType] は操作を選択します：

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 開始位置を設定します。 |
| LineTo | One | 直線セグメントに沿って終点まで移動します。 |
| CurveTo | Three | 2 つの制御点と終点で定義される三次ベジエ曲線に沿って移動します。 |
| CloseLoop | None | 開始位置に戻ります。 |
| End | None | パスを終了します。 |

[MotionPathPointsType] はコーナー点やスムーズ点など、点の編集特性を示します。コマンドタイプの代替ではありません。下の曲線例では CurvePointType、直線セグメントでは CornerPointType を使用してください。

パス座標はスライドのサイズに正規化されます。X の 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。Absolute コマンドはパス座標系で位置を指定し、Relative コマンドは現在位置からのオフセットを指定します。これは [getOrigin](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) がパスの基準フレームを選択し、[getPathEditMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) がシェイプ移動時のパスの動作を制御することとは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドで構成されるモーションビヘイビアを作成します。[IMotionPath.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) はコマンドタイプ、点配列、点タイプ、相対座標フラグを受け取ります。

開始コマンドは (0, 0) を設定し、線は (0.25, 0) で終了し、スライド幅の 1/4 の水平変位になります。終了コマンドには座標点がありません。パスを割り当てた後、モーションビヘイビアを効果に追加すると、そのルートが矩形に接続されます。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` には 3 つのパスコマンドを持つ 1 つのモーションビヘイビアが含まれます。以下のファイル編集例はこの構造を前提としています。

### **絶対座標と相対座標の比較**

この 2 つのパスオブジェクトは同じルートを表します。絶対コマンドは (0.3, 0.1) で終了し、相対コマンドは現在位置に (0.1, 0.1) を加えて (0.2, 0) にします。

両方のパスは同じ位置から開始します。相対線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対線の場合は直接終点を読み取ります。座標変換せずにフラグだけ切り替えると別のルートになります。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

どちらかのパスをモーションビヘイビアに割り当ててプレゼンテーションで使用します。最後の Boolean 引数はそのコマンドの座標が相対かどうかを選択します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジエ曲線に置き換えます。最初に 2 つの制御点、次に終点を指定します。

開始位置は直前のコマンドで供給されます。最初の 2 点が曲線の形状を決め、3 番目が目的地です。コマンドタイプ、点編集タイプ、点配列を同時に更新すると、セグメントが新しいジオメトリと整合します。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ち、中央のコマンドが曲線になっています。

## **保存されたパスの検査と編集**

各 [IMotionCmdPath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioncmdpath/) は [getPoints](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--)、[getCommandType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--)、[getPointsType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--)、[isRelative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) を公開します。以下の例は `motion.pptx` の既知の 3 コマンドパスを使用します。任意の入力では、編集前に対象効果を特定し、コマンドタイプと点数をインデックスで編集する前に確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。End と CloseLoop コマンドは点が不要なため、null の点配列を許容します。

出力は各数値コマンドタイプと相対座標フラグをペアで示し、その後に点を列挙します。これにより、パスを変更する前に終点とオフセットを区別できます。曲線は 3 点を、直線は 1 点だけを一覧表示します。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

リストには開始点、(0.25, 0) で終了する絶対線、そして End コマンドが含まれます。

### **終点の変更**

`motion.pptx` を開き、線の点配列を置き換えて終点を移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が線です。線の単一点を置き換えることで、コマンドタイプ、タイミング、コレクション内の位置を変更せずに目的地だけ変更できます。コマンドが絶対座標であるため、新しいペアは位置を指定し、オフセットを加えるわけではありません。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` の線は (0.4, 0.1) で終了し、元のファイルは変更されていません。

### **セグメントの置き換え**

[insert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) と [removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) を使用して `motion.pptx` の線を置き換えます。挿入により古い線はインデックス 2 にシフトします。

この操作は既存座標を編集するのではなく、コマンドオブジェクト自体を置き換える例です。挿入後、コレクションは一時的に開始コマンド、新しい線、古い線、End コマンドの順に含まれます。インデックス 2 を削除すると古い線が廃棄され、新しいルートが残ります。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたパスは依然として 3 つのコマンドを持ち、新しい線は (0.2, 0.1) で終了し、最後は End コマンドです。

## **既存ビヘイビアの変更と検証**

ビヘイビアのインデックスが不明な場合はタイプで選択します。この例では `rotation.pptx` を開き、[IRotationEffect] を見つけて角度を変更し、再オープン後に保存された値を確認します。

タイプチェックにより、回転でないビヘイビアはループでスキップされます。2 回目のロードでは保存されたファイルを別のプレゼンテーションオブジェクトに読み込み、比較はメモリ上の値ではなく永続化されたデータを確認します。この例は効果がメインシーケンスの最初にあることを前提としていますが、タイプでビヘイビアを選択しても任意のプレゼンテーションで正しい効果を特定できるわけではありません。

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

出力は `Rotation preserved: true` です。その他のビヘイビアにも同様のタイプチェックパターンを適用してください。完全な保存チェックを行うには、対象シェイプ、効果、ビヘイビアタイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値許容差を使用します。アニメーション構成が不明なプレゼンテーションについては、[シェイプ アニメーションの読み取り](/slides/ja/androidjava/shape-animation/#read-shape-animations) を参照してメインシーケンスとインタラクティブシーケンスを走査してください。

## **ビヘイビアの順序、プリセット、再生**

[IBehaviorCollection] の順序は効果の操作の保存順序です。各ビヘイビアが自動的に前のビヘイビアを待つプレイリストではありません。タイミングとエンclosing effect がスケジューリングを決定します。ビヘイビアは重複して実行でき、同一プロパティに対する操作は [getAdditive](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehavior/#getAdditive--) と [getAccumulate](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) によって相互作用することがあります。単にコレクションの順序を変更して「移動、次に回転」を実現しようとしないでください。明示的なタイミングまたは別々の効果を使用してください（[シェイプ アニメーション](/slides/ja/androidjava/shape-animation/) を参照）。

効果の [getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getType--) と [getSubtype](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getSubtype--) はプリセットを記述しますが、編集されたビヘイビアツリー全体の説明にはなりません。ビヘイビアをカスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタマイズされた Spin 効果を Fade に変更すると、回転ビヘイビアが Set や Filter ビヘイビアに置き換わります。プリセットやサブタイプを変更した後は必ずコレクションを再検査してください。プリセットビヘイビアをクリアすると、プリセットが必要とする可視性や初期化操作も削除されることがあります。例では可視シェイプを使用し、ビヘイビアを置き換えているため、すべてのプリセット実装を再構築しているわけではありません。

## **形式互換性**

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | これらの例の主な形式として使用します。再度開いて編集可能なビヘイビア ツリーを確認し、目的の PowerPoint バージョンで再生をチェックします。 |
| PPT | レガシーのバイナリ表現は PPTX と異なる場合があります。別途保存→再オープンサイクルと再生をテストし、PPTX の成功だけですべてのカスタム組み合わせがサポートされると推測しないでください。 |
| PDF、PNG、JPEG、その他の静的スライド画像 | 静的なスライド表現であり、再生可能なビヘイビア タイムラインや最終アニメーションフレームの保証はありません。 |
| [HTML5](/slides/ja/androidjava/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすれば、サポートされたアニメーションをブラウザで再生できます。カスタム組み合わせはブラウザでテストしてください。 |
| [Animated GIF](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保存しますが、編集可能なビヘイビアやクリックトリガーは含まれません。実際のレンダリングされた動きを確認してください。 |
| [Video](/slides/ja/androidjava/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングし、動画としてエンコードします。サポートはレンダラの [supported animations and effects](/slides/ja/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブイベントは編集可能なタイムラインにはなりません。 |

## **よくある質問**

**Why does my effect contain behaviors before I add any?**  
プリセット効果を作成すると、その基礎となる操作が自動的に生成されることがあります。拡張するか置き換えるかを決める前にそれらを検査してください。

**Does moving a behavior to the beginning make it play first?**  
必ずしもそうとは限りません。コレクション順序はタイミングの代替ではありません。遅延、期間、同一プロパティ上の操作間の相互作用を確認してください。

**Why does an end command have no points?**  
End コマンドはパスの終了を示すだけで座標は不要です。ファイルから読み取ったパスを検査する際は、点配列が null である可能性を考慮してください。

**Is a successful round trip sufficient to confirm playback?**  
いいえ。再オープンはプロパティの保持を確認しますが、スライドショー プレーヤーやアニメーションのエクスポートで実際の再生を別途テストして、視覚的な動作を確認する必要があります。