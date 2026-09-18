---
title: .NET でカスタム アニメーション 動作を作成および変更
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/net/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション 動作
- モーション パス
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint プレゼンテーションで Aspose.Slides for .NET を使用して、カスタム アニメーション 動作と編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタム アニメーション 動作を使用すると、色の変更、形状の回転、編集可能なモーション パスの追従など、アニメーション 効果内の個々の操作を制御できます。このガイドでは、動作の作成と組み合わせ、タイミングの構成、既存のアニメーションの検査と変更、そしてプロパティがプレゼンテーションの保存と再オープン後も保持されることを確認する方法を示します。

事前定義された効果やクリック トリガーについては、[シェイプ アニメーション](/slides/ja/net/shape-animation/)をご参照ください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます。

- スライドの[Timeline](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/timeline/)にはメイン シーケンスとインタラクティブ シーケンスが含まれます。
- [ISequence](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/)は、対象となる形状が異なる可能性のあるエフェクトを保持します。
- [IEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/)は対象形状、プリセット、サブタイプ、エフェクト タイミングを特定します。
- [IEffect.Behaviors](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/behaviors/)には、色の変更、移動、回転、プロパティ設定など、エフェクトを実装する操作が含まれます。

## **個別の動作の作成**

[ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) を呼び出してエフェクトを作成し、その [Behaviors](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/behaviors/) コレクションにアクセスします。プリセットはこのコレクションを自動的に構成できます。プリセットを拡張する際はその操作を保持し、意図的に置き換える場合は [Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/clear/) を使用します。

[IBehaviorFactory](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/) は下記の 8 種類の動作を作成します。モーションに関しては [モーション パスの作成](#build-a-motion-path) を参照してください。各作成例は完全なプログラムです。後続の編集例は使用する出力ファイルを明記しています。

### **回転**

[CreateRotationEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) を使用して回転を作成します。[By](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/irotationeffect/by/) は度数で相対角度を指定し、[From](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/irotationeffect/from/) と [To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/irotationeffect/to/) は端点を指定します。

この例は Spin エフェクトから開始し、プリセット操作を 1 つの回転動作に置き換え、操作に 2 秒の期間を設定します。90 度の相対角度は形状の開始向きから 1/4 回転を表すため、開始角度を明示的に指定する必要はありません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` には 1 つの形状と 1 つの回転動作が含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[X/Y パーセンテージ] を用いて [CreateScaleEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) を使用します。[From](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/iscaleeffect/from/) と [To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/iscaleeffect/to/) は開始サイズと終了サイズを表し、[By](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/iscaleeffect/by/) は相対変化を表します。ここで 100 は元のサイズを意味します。

例では両方の寸法を 100% から 125% に 2 秒かけて拡大します。水平・垂直のパーセンテージを同じにすると形状の比率が保たれ、異なるパーセンテージにすると一方がより伸びます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **色**

[CreateColorEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) を使用して塗りを青からオレンジに変更します。[From](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icoloreffect/from/) と [To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icoloreffect/to/) は色で、[By](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icoloreffect/by/) は色のオフセットです。[IBehavior.Properties](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehavior/properties/) はアニメーション対象の属性を識別します。

形状の実体塗りは青で初期化され、アニメーションの開始色と一致します。塗りのカラー属性を選択することで、どの部分を変更すべきかが動作に伝わります。保存されたエフェクトは 2 秒でオレンジへ遷移することを記述しています。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **フィルタ**

[CreateFilterEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) を使用してワイプを選択します。[Type](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ifiltereffect/type/)、[Subtype](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ifiltereffect/subtype/)、[Reveal](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ifiltereffect/reveal/) がフィルタ、方向、表示/非表示を指定します。

この例は右方向のサブタイプで形状を表示する 2 秒のワイプを設定します。フィルタ設定はエフェクト内の動作に属するため、プリセットの元の操作を除去した後に構成します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **プロパティ**

[CreatePropertyEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) を使用して不透明度をアニメーション化します。[From](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ipropertyeffect/from/)、[To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ipropertyeffect/to/)、[By](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ipropertyeffect/by/) は文字列で、[ValueType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ipropertyeffect/valuetype/) と [CalcMode](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ipropertyeffect/calcmode/) によって解釈されます。3 つすべてを同時に設定するのではなく、エンドポイントまたは相対オフセットを選択してください。

ここでは属性として不透明度を選択し、数値文字列は 25% の不透明度から完全不透明度への変化を表します。線形補間により、これらの値の間を徐々に変化させます。別の属性に適用する場合は、その属性に適した値タイプとエンドポイント値を選択してください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **設定**

[CreateSetEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) を使用して [To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/iseteffect/to/) により可視性を設定します。設定動作はエンドポイント間を補間しません。

例では可視性属性を選択し、動作実行時に文字列 `visible` を割り当てます。最小限のプレゼンテーションでは矩形は既に可視状態のため、単独では目立った変化は見られません。この操作は、形状の表示／非表示を制御する他の効果と組み合わせる際に有用です。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **コマンド**

[CreateCommandEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) を使用し、[Type](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icommandeffect/type/)、[CommandString](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icommandeffect/commandstring/)、[ShapeTarget](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/icommandeffect/shapetarget/) を構成します。作業ディレクトリに `sample.wav` という WAV 録音ファイルを配置してください。この例は [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addaudioframeembedded/) で埋め込み、再生コマンドをオーディオ フレームに付加します。

オーディオ フレームはエフェクトの対象でもあり、コマンドの対象でもあります。これにより再生要求が埋め込み録音に結び付けられ、コマンド文字列だけではどのメディア オブジェクトを制御するかは特定できません。エフェクトはスライドショー中のクリックで開始するよう構成されています。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

保存後は `command.pptx` にコマンドが格納されますが、録音は再生されません。再生にはコマンドとメディア対象をサポートするスライドショー プレーヤーが必要です。

## **動作コレクションの管理**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/) は [Add](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/add/)、[Insert](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/insert/)、[Remove](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/removeat/) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動させ、回転を削除します。同一オブジェクトを削除して再挿入するとコピーを作成せずに位置が変更されます。

編集の順序によりコレクションは rotation–scale → scale–rotation → scale の順に変化します。インデックスは現在のコレクションを指すため、再配置後の回転の新しいインデックスで削除が行われます。最終的な列挙で保存される動作が確認できます。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

出力は `ScaleEffect` だけです。コレクションの順序自体は動作を順に実行させるスケジュールにはなりません。すべての操作を置き換える場合にのみ Clear を使用してください。

## **動作タイミングの構成**

[IBehavior.Timing](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehavior/timing/) は [ITiming](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/) を公開し、[IEffect.Timing](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/timing/) とは独立しています。エフェクトのタイミングはエフェクト全体のスケジュール、動作のタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、[Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/duration/) と [TriggerDelayTime](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/triggerdelaytime/) を秒単位で設定し、続いて [RepeatCount](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatcount/) を構成します。[Accelerate](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/accelerate/) と [Decelerate](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/decelerate/) は期間の割合で、合計は最大 1 に保ちます。

入力ファイルは回転例で作成したものです。最初の動作が回転であることが分かっています。この例ではその動作のタイミングだけを変更し、90 度の角度はそのままです。角度とタイミングを分離して保持することで、アニメーションを再構築せずにペース調整が容易になります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

この動作は 2 秒の期間、0.5 秒の遅延、繰り返し回数 3 を使用します。期間の最初と最後の 20% が加速と減速に割り当てられます。

その他の繰り返しポリシーとして [RepeatDuration](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatduration/)、[RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilendslide/)、[RepeatUntilNextClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilnextclick/) があります。すべてを同時に有効にするのではなく、1 つを選択してください。[AutoReverse](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/autoreverse/) は前方向の再生後に逆方向で再生します。加速・減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[CreateMotionEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) を使用してモーションを作成します。[From](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/from/)、[To](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/to/)、[By](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/by/) はパーセンテージベースの座標またはオフセットを示します。編集可能なルートが必要な場合は [MotionPath](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/motionpath/) を作成し、[IMotionEffect.Path](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/path/) に割り当てます。[IMotionPath](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotionpath/) はパス コマンドを保持します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/motioncommandpathtype/) が操作を選択します：

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定します。 |
| LineTo | 1 | 直線セグメントの終点まで移動します。 |
| CurveTo | 3 | 2 つの制御点と終点で定義された三次ベジェ曲線に従います。 |
| CloseLoop | 0 | 開始位置に戻ります。 |
| End | 0 | パスを終了します。 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/motionpathpointstype/) はコーナー点やスムーズ点など、ポイントの編集特性を記述します。コマンドタイプの代替にはなりません。下の曲線例では曲線ポイントタイプを、直線セグメントではコーナーポイントタイプを使用してください。

パス座標はスライド寸法に正規化されます。X の 0.25 移動はスライド幅の 1/4 を意味し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは [Origin](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/origin/)（パスの基準フレーム選択）や [PathEditMode](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioneffect/patheditmode/)（形状移動時のパス動作制御）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーション 動作を作成します。[IMotionPath.Add](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotionpath/add/) はコマンドタイプ、ポイント配列、ポイントタイプ、相対座標フラグを受け取ります。

開始コマンドは (0, 0) を設定し、直線は (0.25, 0) で終わります。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標ポイントはありません。パスを割り当てた後にモーション 動作をエフェクトに追加すると、そのルートが矩形に接続されます。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` には 3 つのパス コマンドを持つ 1 つのモーション 動作が含まれます。以下のファイル編集例はこの構造を前提にしています。

### **絶対座標と相対座標の比較**

以下の 2 つのパスオブジェクトは同一ルートを表します。絶対コマンドは (0.3, 0.1) に終点を持ち、相対コマンドは現在位置 (0.2, 0) に (0.1, 0.1) を加えます。

両パスは同じ開始位置から始まります。相対線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対線の場合は直接終点を読み取ります。フラグだけを切り替えて座標を変換しないと別のルートになります。

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

どちらかのパスをモーション 動作に割り当ててプレゼンテーションで使用できます。最後の Boolean 引数はそのコマンドに相対座標を使用するかどうかを選択します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。最初に 2 つの制御点を、続いて終点を指定します。

開始位置は前のコマンドで供給されます。最初の 2 点が曲線の形状を決め、3 点目が目的地となります。コマンドタイプ、ポイント編集タイプ、ポイント配列を同時に更新すると、新しいジオメトリに一致したセグメントになります。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ちますが、真ん中のコマンドが曲線に変わっています。

## **保存されたパスの検査と編集**

各 [IMotionCmdPath](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioncmdpath/) は [Points](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioncmdpath/points/)、[CommandType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioncmdpath/commandtype/)、[PointsType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioncmdpath/pointstype/)、[IsRelative](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotioncmdpath/isrelative/) を公開します。以下の例は `motion.pptx` にある既知の 3 コマンド パスを使用します。任意の入力の場合は、編集前に対象エフェクトを特定し、コマンドタイプとポイント数をインデックスで確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了コマンドとクローズループコマンドにはポイントは不要なので、null のポイント配列を許容します。

出力は各コマンドと相対座標フラグをペアにし、その後にポイントを列挙します。これにより、パスを変更する前にエンドポイントとオフセットを区別できます。曲線は 3 点をリストし、ここにある直線は 1 点だけです。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

一覧には開始点、(0.25, 0) で終わる絶対直線、そして終了コマンドが含まれます。

### **エンドポイントの変更**

`motion.pptx` を開き、直線のポイント配列を置き換えてエンドポイントを移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一ポイントを置き換えることで、コマンドタイプ、タイミング、コレクション内の位置を変更せずに目的地を変更できます。コマンドが絶対座標を使用しているため、新しいペアはオフセットではなく位置を表します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx` の直線は (0.4, 0.1) で終わり、元のファイルは変更されていません。

### **セグメントの置き換え**

[Insert](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotionpath/insert/) と [RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/imotionpath/removeat/) を使用して `motion.pptx` の直線を置き換えます。挿入により古い直線はインデックス 2 にシフトします。

これは既存座標を編集するのではなく、コマンド オブジェクト自体を置き換える例です。挿入後、コレクションは一時的に開始コマンド、新しい直線、古い直線、終了コマンドの 4 つを保持します。インデックス 2 を削除すると古い直線が削除され、新しいルートが残ります。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

保存されたパスは依然として 3 つのコマンドを持ち、新しい直線は (0.2, 0.1) で終わり、終了コマンドが最後になります。

## **既存の動作の変更と検証**

インデックスが不明な場合はタイプで選択します。この例は `rotation.pptx` を開き、[IRotationEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/irotationeffect/) を見つけ、角度を変更し、再オープン後に保存された値を確認します。

タイプチェックにより、回転でない動作はループでスキップされます。2 回目のロードは保存されたファイルを別のプレゼンテーション オブジェクトに読み込み、比較はメモリ上の値ではなく永続化されたデータをチェックします。この例は既知のエフェクトがメイン シーケンスの最初にあることを前提としていますが、タイプで動作を選択しても任意のプレゼンテーションで正しいエフェクトが見つかる保証はありません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

出力は `Rotation preserved: True` です。同様のタイプチェック パターンを他の動作にも適用してください。完全な保存確認のためは、対象形状、エフェクト、動作タイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値許容誤差を使用します。アニメーションレイアウトが不明なプレゼンテーションについては、[シェイプ アニメーションの読み取り](/slides/ja/net/shape-animation/#read-shape-animations) を参照し、メインおよびインタラクティブ シーケンスの走査方法を確認してください。

## **動作の順序、プリセット、再生**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehaviorcollection/) の順序はエフェクトの操作の保存順序です。これは自動的に前の動作を待つプレイリストではありません。タイミングとエフェクト自体がスケジューリングを決定します。動作は重なることがあり、同一プロパティへの操作は [Additive](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehavior/additive/) や [Accumulate](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ibehavior/accumulate/) を介して相互作用します。「移動 → 回転」のように単にコレクション順序を変更してスケジュールしようとしないでください。明示的なタイミングまたは別々のエフェクトを使用してください（[シェイプ アニメーション](/slides/ja/net/shape-animation/) を参照）。

エフェクトの [Type](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/type/) と [Subtype](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/subtype/) はプリセットを記述しますが、編集された動作ツリーの完全な説明ではありません。カスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタマイズされた Spin エフェクトを Fade に変更すると、回転動作が設定およびフィルタ 動作に置き換えられます。プリセットやサブタイプを変更した後はコレクションを再度確認してください。プリセットの可視性や初期化操作を削除すると、プリセットが必要とする操作が失われることがあります。例では可視形状を使用し、動作を置き換えているため、すべてのプリセット実装を再構築しているわけではありません。

## **形式互換性**

保存された動作ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を別々に確認してください。

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | 例の主要形式として使用します。再オープンして編集可能な動作ツリーを確認し、対象の PowerPoint バージョンで再生を確認してください。 |
| PPT | 従来のバイナリ表現は PPTX と異なる場合があります。別途保存‑再オープンサイクルと再生をテストし、PPTX の成功だけですべてのカスタム組み合わせがサポートされるとは判断しないでください。 |
| PDF、PNG、JPEG などの静的スライド画像 | 静的なスライド表現であり、再生可能な動作タイムラインや最終アニメーションフレームは保証されません。 |
| [HTML5](/slides/ja/net/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすれば、サポートされたアニメーションを再生できます。ブラウザでカスタム組み合わせをテストしてください。 |
| [Animated GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保存しますが、編集可能な動作やクリック トリガーのインタラクションは含まれません。実際のレンダリングされた動きを確認してください。 |
| [Video](/slides/ja/net/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングしてビデオとしてエンコードします。サポートはレンダラの [サポートされるアニメーションとエフェクト](/slides/ja/net/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインにはなりません。 |

## **FAQ**

**なぜエフェクトに動作が既に含まれているのですか？**

事前定義されたエフェクトを作成すると、その基礎となる操作が生成されることがあります。拡張するか置き換えるかを決める前にそれらを検査してください。

**動作を先頭に移動すれば最初に再生されますか？**

必ずしもそうではありません。コレクション順序はタイミングの代替にはなりません。遅延、期間、同一プロパティへの操作間の相互作用を確認してください。

**終了コマンドにポイントがないのはなぜですか？**

パスの終了を示すためのもので、座標は不要です。ファイルから読み取ったパスを検査する際は、ポイント配列が null であることをチェックしてください。

**往復保存だけで再生が確認できますか？**

いいえ。再オープンはチェックしたプロパティの保持を確認しますが、スライドショー プレーヤーやアニメーション エクスポートで実際の視覚的動作を別途テストする必要があります。