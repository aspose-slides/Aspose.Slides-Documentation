---
title: 在 C++ 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/cpp/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為以及可編輯的移動路徑。"
---
## **概述**

自訂動畫行為讓您能控制動畫效果中的各個操作，例如變更顏色、旋轉形狀或遵循可編輯的移動路徑。本指南說明如何建立與組合行為、設定其時間、檢查與修改現有動畫，以及驗證其屬性在儲存與重新開啟簡報後仍能保留。

對於預先定義的效果和點擊觸發，請參閱 [Shape Animation](/slides/zh-hant/cpp/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- 投影片的 [get_Timeline](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslide/get_timeline/) 包含其主要序列與互動序列。
- 一個 [ISequence](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/) 包含效果，可能對不同形狀產生作用。
- 一個 [IEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/) 會指明目標形狀、預設、子類型與效果的時間設定。
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_behaviors/) 包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立個別行為**

呼叫 [ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 以建立效果並存取其 [get_Behaviors](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_behaviors/) 集合。預設可以自動填充此集合。擴充預設時保留其操作，或在有意取代時使用 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/clear/)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/) 建立下列說明的八種行為類型。移動相關說明請參閱 [Build a Motion Path](#build-a-motion-path)。每個建立範例都是可在函式內執行的獨立程式碼；稍後的編輯範例會說明使用哪個輸出檔案。

### **旋轉**

使用 [CreateRotationEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) 建立旋轉。 [get_By](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/irotationeffect/get_by/) 指定相對角度（度）；[get_From](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/irotationeffect/get_from/) 與 [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/irotationeffect/get_to/) 指定端點。

此範例從 Spin 效果開始，將其預設操作取代為單一旋轉行為，並將該操作設定為兩秒持續時間。90 度的相對角度代表形狀起始方向的四分之一轉向，故不需要明確的起始角度。

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

`rotation.pptx` 包含一個形狀與一個旋轉行為。以下的集合、時間與旋轉編輯範例皆使用此檔案。

### **縮放**

使用 [CreateScaleEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) 搭配 X/Y 百分比： [get_From](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/iscaleeffect/get_from/) 與 [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/iscaleeffect/get_to/) 描述起始與結束大小，而 [get_By](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/iscaleeffect/get_by/) 描述相對變化。此處，100 代表原始大小。

此範例在兩秒內將兩個維度從 100% 成長至 125%。使用相同的水平與垂直百分比可保持形狀比例；若使用不同的百分比則會拉伸某一維度。

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

### **顏色**

使用 [CreateColorEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) 將填充顏色從藍色變更為橙色。 [get_From](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icoloreffect/get_from/) 與 [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icoloreffect/get_to/) 為顏色；[get_By](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icoloreffect/get_by/) 為顏色偏移。 [IBehavior::get_Properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehavior/get_properties/) 用以識別被動畫化的屬性。

形狀的實心填充被初始化為藍色，與動畫的起始顏色相符合。選取填充顏色屬性告訴行為要變更形狀的哪一部分；僅有顏色端點不足以識別該屬性。已儲存的效果描述了兩秒的過渡至橙色。

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

### **濾鏡**

使用 [CreateFilterEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) 以選擇抹除特效。 [get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), 與 [get_Reveal](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) 指定濾鏡、方向以及是顯示或隱藏形狀。

此範例設定一個兩秒的抹除，使用向右方向子類別來顯示形狀。濾鏡設定屬於效果內的行為，因而在移除預設原始操作後再進行設定。

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

### **屬性**

使用 [CreatePropertyEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) 來對不透明度進行動畫化。 [get_From](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ipropertyeffect/get_to/), 與 [get_By](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ipropertyeffect/get_by/) 為字串，會依照 [get_ValueType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) 與 [get_CalcMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) 進行解釋。請選擇端點或相對偏移，而非同時設定三者。

此處，選取的屬性為不透明度，數值字串表示從 25% 不透明度變為全不透明度。線性插值描述了這些值之間的漸進變化。若將此範例套用到其他屬性，請選擇適合該屬性的值類型與端點值。

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

使用 [CreateSetEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) 透過 [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/iseteffect/get_to/) 指定可見性。Set 行為不會在端點之間插值。

此範例選取可見性屬性，並在行為執行時指派字串 `visible`。在 C++ 中，需先將字串包裝為物件再指派給 set 行為。此最小簡報中矩形已預設為可見，故此指派本身可能不會產生明顯的視覺變化。此類操作在更大的效果中有用，能同時控制形狀何時隱藏或顯示。

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

### **指令**

使用 [CreateCommandEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) 並設定 [get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), 與 [get_ShapeTarget](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/)。將名為 `sample.wav` 的 WAV 錄音檔放置於工作目錄中。本範例使用 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) 將其嵌入，並將播放指令附加至音訊框架。

音訊框架同時是效果的目標與指令的目標。這樣會將播放請求連結至嵌入的錄音；僅有指令字串本身無法辨識要控制的媒體物件。此效果被設定為在投影片放映時點擊啟動。

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

儲存時會將指令存入 `command.pptx`；不會播放錄音。播放需使用支援該指令與其媒體目標的投影片播放器。

## **管理行為集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/) 支援 [Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/remove/), 與 [RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/removeat/)。此範例開啟 `rotation.pptx`，加入縮放，將其移至旋轉之前，並移除旋轉。移除後重新插入相同物件會變更其儲存位置而不產生副本。

編輯順序會將集合從 rotation–scale 變為 scale–rotation，最終僅保留 scale。索引指向當前集合，因此移除時使用旋轉在重新排序後的新索引。最終的列舉確認了將被儲存的行為。

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

輸出為 `ScaleEffect`：僅剩縮放。僅靠集合順序本身不會使行為依序排程。僅在全部取代其操作時才清除集合。

## **設定行為時間**

[IBehavior::get_Timing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehavior/get_timing/) 會公開 [ITiming](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/)，與 [IEffect::get_Timing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_timing/) 獨立。效果時間排程外層效果；行為時間則描述其中的操作。

### **設定持續時間、延遲、重複與加速**

開啟 `rotation.pptx`，以秒為單位設定 [get_Duration](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_duration/) 與 [get_TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/)，接著設定 [get_RepeatCount](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_repeatcount/)。 [get_Accelerate](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_accelerate/) 與 [get_Decelerate](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_decelerate/) 為持續時間的比例；其總和請不超過 1。

輸入檔案為旋轉範例所建立的檔案，第一個行為已知為旋轉。本範例僅變更該行為的時間設定，90 度角度保持不變。將角度與時間分開可更輕鬆調整節奏，而無需重新建構動畫。

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

此行為使用兩秒持續時間、半秒延遲，且重複次數為 3。持續時間的前 20% 與後 20% 用於加速與減速。

其他重複政策包括 [get_RepeatDuration](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), 與 [get_RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); 請選擇單一政策，而非同時啟用全部。[get_AutoReverse](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/get_autoreverse/) 會在正向播放後反向播放動畫。加速與減速適用於連續變化，不適用於離散的指定或指令。

## **建立移動路徑**

使用 [CreateMotionEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) 建立移動。其 [get_From](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_to/), 與 [get_By](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_by/) 描述以百分比為基礎的座標或偏移。若需可編輯路徑，請建立 [MotionPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/motionpath/) 並指派給 [IMotionEffect::get_Path](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_path/)。 [IMotionPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotionpath/) 會儲存路徑指令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/motioncommandpathtype/) 選擇操作：

| 指令 | 點數 | 說明 |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至其端點。 |
| CurveTo | Three | 遵循由兩個控制點與端點定義的三次曲線。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 結束路徑。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/motionpathpointstype/) 描述點的編輯特性，例如拐角或平滑點。它不會取代指令類型。對於下方曲線範例使用曲線點類型，對於直線段使用拐角點類型。

路徑座標會正規化為投影片尺寸：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。Y 正向向下。絕對指令指定路徑座標系統中的位置；相對指令則指定相對於當前位置的偏移。這與 [get_Origin](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_origin/)（選取路徑的參考框架）以及 [get_PathEditMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)（控制形狀移動時路徑的移動方式）是分開的。

### **建立直線路徑**

建立具有起始點、一條直線段與結束指令的移動行為。[IMotionPath::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotionpath/add/) 需要指令類型、其點、點的類型，以及相對座標旗標。

起始指令設定為 (0, 0)，而直線結束於 (0.25, 0)，使路徑在水平方向上位移投影片寬度的四分之一。結束指令沒有座標點。路徑指派完成後，將移動行為加入效果即會把此路徑連結至矩形。

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

`motion.pptx` 包含一個具有三個路徑指令的移動行為。以下的檔案編輯範例皆使用此已知結構。

### **比較絕對與相對座標**

這兩個路徑物件描述相同的路徑。絕對指令結束於 (0.3, 0.1)；相對指令則在當前位置 (0.2, 0) 上加上 (0.1, 0.1)。

兩條路徑皆從相同位置開始。對於相對線，需要將其 X、Y 偏移加至當前位置以取得端點；對於絕對線，直接讀取端點。若未轉換座標即切換旗標，會描述不同的路徑。

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

將任一路徑指派給移動行為即可在簡報中使用。最後的布林參數會為該指令選擇相對座標。

### **將直線取代為曲線**

開啟 `motion.pptx`，將其直線指令取代為三次曲線。先提供兩個控制點，再提供端點。

起始位置由前一指令提供。前兩個點塑造曲線，第三個點為其終點；它們不是連續的三個目的地。同步更新指令類型、點的編輯類型與點陣列，可確保片段與新幾何形狀一致。

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

`curve.pptx` 中的路徑仍有三個指令；其中間的指令現在定義為曲線。

## **檢查與編輯已儲存的路徑**

每個 [IMotionCmdPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioncmdpath/) 會公開 [get_Points](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), 與 [get_IsRelative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/)。以下範例使用 `motion.pptx` 中已知的三指令路徑。對於任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數量。

### **讀取指令與座標**

在不修改的情況下讀取路徑。End 與 close-loop 指令不需要點，因此需允許空的點陣列。

輸出會在列出點之前，先將每個指令與其相對座標旗標配對。這讓您在修改路徑前能分辨端點與偏移。曲線會列出三個點，而此檔案中的直線僅列出一個點。

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

列舉包含起始點、一個結束於 (0.25, 0) 的絕對直線，以及一個 end 指令。

### **變更端點**

開啟 `motion.pptx`，取代直線的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為直線。取代直線的單一點會改變其目的地，但不會改變指令類型、時間或在集合中的位置。因為該指令使用絕對座標，新點對指定的是位置而非追加的偏移。

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

`motion-endpoint.pptx` 中的直線結束於 (0.4, 0.1)；原始檔案未變更。

### **取代段落**

使用 [Insert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotionpath/insert/) 與 [RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/imotionpath/removeat/) 取代 `motion.pptx` 中的直線。插入會將舊的直線移至索引 2。

此示範了取代指令物件而非編輯其已存在座標。插入後，集合暫時包含起始指令、新直線、舊直線與結束指令。移除索引 2 後會丟棄舊直線，保留新路徑。

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

儲存的路徑仍有三個指令，新的直線結束於 (0.2, 0.1)，最後為 end 指令。

## **修改與驗證現有行為**

當行為的索引未知時，可依類型選取。本範例開啟 `rotation.pptx`，尋找其 [IRotationEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/irotationeffect/)，變更角度，並在重新開啟後檢查儲存的值。

類型檢查使迴圈可跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，因而比較的是持久化資料而非仍存於記憶體中的值。本範例仍假設已知的效果位於主序列的第一個；依類型選取行為不一定能在任意簡報中定位正確的效果。

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

輸出為 `Rotation preserved: True`。對其他行為套用相同的類型檢查模式。若要完整驗證保存，請比較目標形狀、效果、行為類型與順序、時間與路徑指令。對浮點值使用數值容差。若簡報的動畫布局未知，請參閱 [Read Shape Animations](/slides/zh-hant/cpp/shape-animation/#read-shape-animations) 以遍歷主序列與互動序列。

## **行為順序、預設與播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehaviorcollection/) 中的順序即為效果操作的儲存順序。它不是自動讓每個行為等待前一個行為的播放清單。時間與外層效果決定排程。行為可以重疊，同一屬性的操作可能透過 [get_Additive](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehavior/get_additive/) 與 [get_Accumulate](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ibehavior/get_accumulate/) 互動。不要僅靠重新排序集合來排程「先移動再旋轉」；請使用明確的時間設定或如 [Shape Animation](/slides/zh-hant/cpp/shape-animation/) 所述的分離效果。

效果的 [get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_type/) 與 [get_Subtype](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_subtype/) 描述其預設。它們並非已編輯行為樹的完整描述。在自訂行為之前先選擇預設與子類型：變更預設可能會重建集合並捨棄您的自訂操作。例如，將已客製化的 Spin 效果改為 Fade，會將其旋轉行為取代為 set 與 filter 行為。變更預設或子類型後請再次檢查集合。清除預設行為亦可能移除預設所需的可見性或初始化操作。範例刻意使用可見形狀並取代行為；不會重建每個預設的實作。

## **格式相容性**

已保存的行為樹並不保證在每個檢視器或匯出渲染器中都有相同的播放效果。請分別檢查已保存的資料與渲染輸出。

| 格式或輸出 | 驗證項目 |
| --- | --- |
| PPTX | 作為本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放。 |
| PPT | 舊版二進位表示可能與 PPTX 不同。測試獨立的儲存再開啟循環與播放；不要僅因 PPTX 輸出成功就推斷支援所有自訂組合。 |
| PDF、PNG、JPEG 以及其他靜態投影片影像 | 僅包含靜態投影片呈現，未包含可播放的行為時間軸或保證的最終動畫畫面。 |
| [HTML5](/slides/zh-hant/cpp/export-to-html5/) | 在匯出選項啟用形狀動畫時可播放支援的動畫。於瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/) | 保存渲染的影格，而非可編輯的行為或點擊觸發的互動。檢查實際渲染的動作。 |
| [Video](/slides/zh-hant/cpp/convert-powerpoint-to-video/) | 渲染動畫影格並編碼為影片。支援受限於渲染器的[支援動畫與效果](/slides/zh-hant/cpp/convert-powerpoint-to-video/#supported-animations-and-effects)；指令與互動事件不會變成可編輯的時間軸。 |

## **常見問題**

**為什麼我的效果在我加入任何行為之前就已包含行為？**

建立預設效果時可能已產生其底層操作。在決定是要擴充預設還是取代其行為之前，請先檢查它們。

**將行為移至開頭會使它首先播放嗎？**

不一定。集合順序並不能取代時間設定。請檢查延遲、持續時間以及同屬性操作之間的互動。

**為什麼 end 指令沒有點？**

它標示路徑的結束，不需要座標。檢查從檔案讀取的路徑時，請留意是否為空的點陣列。

**成功的往返儲存與重新開啟是否足以確認播放？**

不是。重新開啟只確認您檢查的屬性是否被保存。請另行測試投影片播放器或動畫匯出，以確認其視覺行為。