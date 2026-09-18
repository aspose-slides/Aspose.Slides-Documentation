---
title: C++でカスタム アニメーション 動作を作成および変更する
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/cpp/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション 動作
- モーション パス
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint プレゼンテーションで Aspose.Slides for C++ を使用して、カスタム アニメーション 動作と編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタム アニメーション 動作を使用すると、色の変更、図形の回転、編集可能なモーション パスに従うなど、アニメーション効果内の個々の操作を制御できます。このガイドでは、動作の作成と組み合わせ、タイミングの設定、既存のアニメーションの検査と変更、プレゼンテーションの保存と再開後にプロパティが保持されているかの確認方法を示します。

事前定義された効果やクリック トリガーについては、[シェイプ アニメーション](/slides/ja/cpp/shape-animation/) を参照してください。

## **アニメーション モデルの理解**

アニメーションは **タイムライン → シーケンス → 効果 → 動作** の階層で構成されます。

- スライドの [get_Timeline](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_timeline/) には、メイン シーケンスとインタラクティブ シーケンスが含まれます。
- [ISequence](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/) は、異なる図形を対象にする可能性がある効果を保持します。
- [IEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/) は、対象図形、プリセット、サブタイプ、および効果のタイミングを識別します。
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_behaviors/) には、色の変更、移動、回転、プロパティ設定など、効果を実装する操作が格納されます。

## **個別の動作の作成**

[ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) を呼び出して効果を作成し、その [get_Behaviors](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_behaviors/) コレクションにアクセスします。プリセットを使用すると、このコレクションが自動的に設定されます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は [Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/clear/) を使用します。

[IBehaviorFactory](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/) は、以下に示す 8 種類の動作を作成します。モーションは [モーション パスの作成](#build-a-motion-path) で扱います。各作成例は関数内で実行できる自己完結型コードで、後続の編集例では使用する出力ファイルを明記しています。

### **回転**

[CreateRotationEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) を使用して回転を作成します。[get_By](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/irotationeffect/get_by/) は相対角度（度）を指定し、[get_From](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/irotationeffect/get_from/) と [get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/irotationeffect/get_to/) は開始点と終了点を指定します。

この例は Spin 効果で始め、プリセットの操作を 1 つの回転動作に置き換え、継続時間を 2 秒に設定します。90 度の相対角度は、図形の開始向きから 1/4 回転したことを示すため、明示的な開始角度は不要です。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` には 1 つの図形と 1 つの回転動作が含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[X/Y パーセンテージ] を指定して [CreateScaleEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) を使用します。[get_From](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/iscaleeffect/get_from/) と [get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/iscaleeffect/get_to/) は開始サイズと終了サイズを、[get_By](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/iscaleeffect/get_by/) は相対変化を表します。ここで 100 は元のサイズを意味します。

例では、2 秒間で両方の次元を 100% から 125% に拡大します。水平・垂直のパーセンテージを同じにすると図形の比率が保たれ、異なるパーセンテージにすると片方が伸びます。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **色**

[CreateColorEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) を使用して、塗りを青からオレンジに変更します。[get_From](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icoloreffect/get_from/) と [get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icoloreffect/get_to/) は色、[get_By](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icoloreffect/get_by/) は色オフセットです。[IBehavior::get_Properties](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehavior/get_properties/) はアニメーション対象の属性を示します。

図形の塗りは青で初期化され、アニメーションの開始色と一致します。塗りの色属性を選択することで、どの部分を変更するかが動作に伝わります。保存された効果は、2 秒間でオレンジへ遷移することを記述しています。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **フィルタ**

[CreateFilterEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) を使用してワイプを選択します。[get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ifiltereffect/get_type/)、[get_Subtype](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ifiltereffect/get_subtype/)、[get_Reveal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) がフィルタ、方向、表示/非表示を指定します。

この例では、右方向サブタイプで図形を表示する 2 秒間のワイプを設定します。フィルタ設定は効果内の動作に属するため、プリセットの元の操作を削除した後に構成します。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **プロパティ**

[CreatePropertyEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) を使用して不透明度をアニメーションします。[get_From](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ipropertyeffect/get_from/)、[get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ipropertyeffect/get_to/)、[get_By](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ipropertyeffect/get_by/) は文字列で、[get_ValueType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) と [get_CalcMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) によって解釈されます。すべてを同時に設定するのではなく、エンドポイントまたは相対オフセットを選択してください。

ここでは属性として不透明度を選択し、文字列 "25%" から "100%" への変化を表します。線形補間により、これらの値の間が徐々に変化します。他の属性に適用する場合は、その属性に適した値タイプとエンドポイントを選んでください。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **設定**

[CreateSetEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) を使用して、[get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/iseteffect/get_to/) により可視性を割り当てます。設定動作はエンドポイント間を補間しません。

例では、可視性属性を選択し、動作が実行されると文字列 `visible` を設定します。C++ では文字列をオブジェクトとしてラップしてから設定動作に渡します。矩形は最小のプレゼンテーションですでに可視状態なので、単体では視覚的な変化は目立ちませんが、隠す・表示するタイミングを制御する他の効果と組み合わせる際に有用です。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **コマンド**

[CreateCommandEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) を使用し、[get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icommandeffect/get_type/)、[get_CommandString](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icommandeffect/get_commandstring/)、[get_ShapeTarget](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) を構成します。作業ディレクトリに `sample.wav` という名前の WAV 録音を配置してください。この例では [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) で埋め込み、再生コマンドをオーディオフレームに付加します。

オーディオフレームは効果の対象でもあり、コマンドの対象でもあります。これにより再生要求が埋め込み録音に結び付けられ、コマンド文字列だけではどのメディアオブジェクトを制御するかは特定できません。効果はスライドショー中のクリックで開始するよう設定されています。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

保存するとコマンドは `command.pptx` に格納されますが、録音は自動再生されません。再生には、コマンドとメディア対象をサポートするスライドショー プレーヤーが必要です。

## **動作コレクションの管理**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/) は [Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/add/)、[Insert](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/insert/)、[Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に移動させ、回転を削除します。同一オブジェクトを削除して再挿入すると、コピーを作らずに保存位置が変更されます。

編集の順序によりコレクションは回転–拡大縮小 → 拡大縮小–回転 → 拡大縮小 の順に変化します。インデックスは現在のコレクションを基準にするため、再配置後の回転の新しいインデックスで削除します。最終的な列挙で保存される動作が確認できます。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

出力は `ScaleEffect` のみで、拡大縮小だけが残ります。コレクションの順序だけでは動作が連続して実行されるわけではありません。すべての操作を置き換える場合にのみ Clear を使用してください。

## **動作タイミングの構成**

[IBehavior::get_Timing](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehavior/get_timing/) は [ITiming](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/) を公開し、[IEffect::get_Timing](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_timing/) とは独立しています。効果のタイミングは効果全体をスケジュールし、動作のタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、秒単位で [get_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_duration/) と [get_TriggerDelayTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) を設定し、[get_RepeatCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_repeatcount/) を構成します。[get_Accelerate](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_accelerate/) と [get_Decelerate](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_decelerate/) は期間の分数で、合計は最大で 1 にしてください。

入力ファイルは回転例で作成したものです。ここでは最初の動作が回転であることが分かっているため、その動作のタイミングだけを変更し、90 度の角度はそのままにします。角度とタイミングを分離しておくと、アニメーションを再構築せずに速度調整が容易になります。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

この動作は 2 秒間の期間、0.5 秒の遅延、繰り返し回数 3 を使用します。期間の最初と最後の 20% が加速と減速に使われます。

他の繰り返しポリシーとして [get_RepeatDuration](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_repeatduration/)、[get_RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/)、[get_RepeatUntilNextClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/) があります。すべて同時に有効にせず、ポリシーを選択してください。[get_AutoReverse](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/get_autoreverse/) は前進後に逆再生します。加速・減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[CreateMotionEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) を使用してモーションを作成します。[get_From](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_from/)、[get_To](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_to/)、[get_By](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_by/) はパーセンテージベースの座標またはオフセットを表します。編集可能なルートが必要な場合は [MotionPath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/motionpath/) を作成し、[IMotionEffect::get_Path](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_path/) に割り当てます。[IMotionPath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotionpath/) はパスコマンドを保持します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/motioncommandpathtype/) は操作を選択します:

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定します。 |
| LineTo | 1 | 直線セグメントを終点まで移動します。 |
| CurveTo | 3 | 2 つの制御点と終点で定義される三次ベジェ曲線に従います。 |
| CloseLoop | 0 | 開始位置に戻ります。 |
| End | 0 | パスを終了します。 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/motionpathpointstype/) はコーナー点やスムーズ点など、ポイント編集の特性を示します。コマンドタイプの代替ではありません。下記の曲線例では曲線ポイントタイプを、直線セグメントではコーナーポイントタイプを使用してください。

パス座標はスライド寸法に正規化されます。X の 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは [get_Origin](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_origin/)（パスの基準フレーム）や [get_PathEditMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)（図形移動時のパス挙動）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーション動作を作成します。[IMotionPath::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotionpath/add/) はコマンドタイプ、ポイント配列、ポイントタイプ、相対座標フラグを受け取ります。

開始コマンドは (0, 0) を設定し、直線は (0.25, 0) で終了します。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標ポイントはありません。パスを割り当てた後、モーション動作を効果に追加すると、矩形にこのルートが結び付けられます。

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` には 3 つのパスコマンドを持つ 1 つのモーション動作が含まれます。以下のファイル編集例はこの構造を前提としています。

### **絶対座標と相対座標の比較**

この 2 つのパスオブジェクトは同一ルートを表します。絶対コマンドは (0.3, 0.1) で終了し、相対コマンドは現在位置 (0.2, 0) に (0.1, 0.1) を加えて終点を求めます。

両パスとも同じ開始位置です。相対線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対線の場合は終点を直接読み取ります。座標変換せずにフラグだけを切り替えると、異なるルートになります。

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

どちらかのパスをモーション動作に割り当ててプレゼンテーションで使用できます。最後のブール引数はそのコマンドに対して相対座標を使用するかを指定します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。まず 2 つの制御点を、続いて終点を指定してください。

開始位置は前のコマンドで提供されます。最初の 2 点が曲線を形作り、3 点目が目的地です。コマンドタイプ、ポイント編集タイプ、ポイント配列を同時に更新すると、セグメントが新しいジオメトリと一致します。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ちますが、真ん中のコマンドが曲線になっています。

## **保存されたパスの検査と編集**

各 [IMotionCmdPath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioncmdpath/) は [get_Points](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioncmdpath/get_points/)、[get_CommandType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/)、[get_PointsType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/)、[get_IsRelative](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) を公開します。以下の例は `motion.pptx` にある既知の 3 コマンドパスを使用します。任意の入力では、編集前に対象効果を特定し、コマンドタイプとポイント数をインデックスで確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了コマンドと閉ループコマンドはポイントを必要としないため、null のポイント配列を許容します。

出力は各コマンドとその相対座標フラグをペアで示し、続いてポイントを列挙します。これにより、パスを修正する前にエンドポイントとオフセットを区別できます。曲線は 3 点を列挙し、ここでは直線は 1 点だけです。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

一覧には開始点、(0.25, 0) で終わる絶対線、終了コマンドが含まれます。

### **エンドポイントの変更**

`motion.pptx` を開き、直線のポイント配列を置き換えてエンドポイントを移動します。

入力ファイルでは、インデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一ポイントを置き換えることで、コマンドタイプ、タイミング、コレクション内の位置を変更せずに目的地を変更できます。絶対座標を使用しているため、新しいペアは位置を示し、オフセットではありません。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion-endpoint.pptx` の直線は (0.4, 0.1) で終了し、元ファイルは変更されていません。

### **セグメントの置き換え**

[Insert](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotionpath/insert/) と [RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/imotionpath/removeat/) を使用して `motion.pptx` の直線を置き換えます。挿入により古い直線はインデックス 2 にシフトします。

この手順は既存座標を編集するのではなく、コマンドオブジェクト自体を置き換えることを示します。挿入後、コレクションは一時的に開始コマンド、新しい直線、古い直線、終了コマンドの順になります。インデックス 2 を削除すると古い直線が除去され、新しいルートが残ります。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

保存されたパスは依然として 3 コマンドを持ち、新しい直線は (0.2, 0.1) で終了し、終了コマンドが最後に配置されています。

## **既存動作の変更と検証**

動作のインデックスが不明な場合はタイプで選択します。この例では `rotation.pptx` を開き、[IRotationEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/irotationeffect/) を検索し、角度を変更して再度開いたときに保存された値を確認します。

タイプチェックにより、回転でない動作はループでスキップされます。2 回目のロードでは保存されたファイルを別のプレゼンテーション オブジェクトに読み込み、メモリ上の値ではなく永続化されたデータを比較します。この例は、対象効果がメイン シーケンスの最初にあることを前提としています。タイプで動作を選択しても、任意のプレゼンテーションで正しい効果が見つかる保証はありません。

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

出力は `Rotation preserved: True` です。同様のタイプチェック パターンを他の動作にも適用してください。完全な保存確認を行うには、対象図形、効果、動作タイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値誤差を考慮します。アニメーション構成が不明なプレゼンテーションについては、[シェイプ アニメーションの読み取り](/slides/ja/cpp/shape-animation/#read-shape-animations) を参照し、メインおよびインタラクティブ シーケンスを走査してください。

## **動作順序、プリセット、再生**

[IBehaviorCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehaviorcollection/) の順序は効果の操作が保存される順序です。これは「前の動作が完了するまで待つ」プレイリストではありません。タイミングと効果がスケジュールを決定します。動作は重なり合うことができ、同一プロパティに対する操作は [get_Additive](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehavior/get_additive/) と [get_Accumulate](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ibehavior/get_accumulate/) を通じて相互作用します。コレクションの順序変更だけで「移動 → 回転」をスケジュールしようとしないでください。明示的なタイミングまたは別個の効果を使用してください（[シェイプ アニメーション](/slides/ja/cpp/shape-animation/) 参照）。

効果の [get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_type/) と [get_Subtype](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_subtype/) はプリセットを示しますが、編集された動作ツリーの完全な記述ではありません。カスタマイズ前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタム Spin 効果を Fade に変更すると、回転動作が設定やフィルタ動作に置き換わります。プリセットやサブタイプ変更後はコレクションを再度確認してください。プリセット動作をクリアすると、プリセットが必要とする可視性や初期化操作も削除されることがあります。例では可視図形を使用し、動作を置き換えているため、すべてのプリセット実装を再構築してはいません。

## **形式の互換性**

保存された動作ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を個別に確認してください。

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | これらの例の主要形式として使用します。再度開いて編集可能な動作ツリーを確認し、対象の PowerPoint バージョンで再生をチェックします。 |
| PPT | 従来のバイナリ形式は PPTX と異なる場合があります。別途保存‑再読込サイクルと再生をテストし、PPTX の成功だけですべての組み合わせがサポートされると推測しないでください。 |
| PDF、PNG、JPEG などの静的スライド画像 | 静的スライド表現であり、再生可能なタイムラインや最終アニメーション フレームは保証されません。 |
| [HTML5](/slides/ja/cpp/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすれば、サポートされたアニメーションを再生できます。ブラウザでカスタム組み合わせをテストしてください。 |
| [Animated GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/) | 描画フレームを保存しますが、編集可能な動作やクリックトリガーは含まれません。実際の再生モーションを確認してください。 |
| [Video](/slides/ja/cpp/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングし、動画としてエンコードします。サポートはレンダラの [サポートされるアニメーションと効果](/slides/ja/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインにはなりません。 |

## **FAQ**

**なぜ効果に動作が既に含まれているのですか？**

事前定義された効果を作成すると、その基礎となる操作が生成されることがあります。拡張するか置き換えるかを決める前に、これらを検査してください。

**動作を先頭に移動すれば最初に再生されますか？**

必ずしもそうではありません。コレクション順序はタイミングの代替にはなりません。遅延、期間、同一プロパティへの操作間の相互作用を確認してください。

**終了コマンドにポイントがないのはなぜですか？**

パスの終了を示すだけで座標は不要です。ファイルから読み取ったパスを検査するときは、ポイント配列が null である可能性を考慮してください。

**往復保存だけで再生が確認できるのですか？**

いいえ。再度開くことでプロパティの保存は確認できますが、スライドショー プレーヤーやアニメーション エクスポートで実際の視覚的動作を別途テストする必要があります。