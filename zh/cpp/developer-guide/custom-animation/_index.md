---
title: 在 C++ 中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/cpp/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 PowerPoint 演示文稿中使用 Aspose.Slides for C++ 创建、检查和修改自定义动画行为以及可编辑的运动路径。"
---
## **概述**

自定义动画行为让您能够控制动画效果中的各个操作，例如更改颜色、旋转形状或沿可编辑的运动路径进行跟随。本指南展示了如何创建和组合行为、配置其时间、检查和修改现有动画，以及验证其属性在保存并重新打开演示文稿后仍然保留。

有关预定义效果和点击触发器，请参阅[形状动画](/slides/zh/cpp/shape-animation/)。

## **了解动画模型**

动画组织结构为 **时间线 → 序列 → 效果 → 行为**：

- 幻灯片的[get_Timeline](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_timeline/)包含其主序列和交互序列。
- 一个[ISequence](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/)包含效果，可能针对不同的形状。
- 一个[IEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/)标识目标形状、预设、子类型以及效果时间。
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_behaviors/)包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)创建效果并访问其[get_Behaviors](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_behaviors/)集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用[Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/clear/)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/)创建下文所示的八种行为类型。运动路径相关内容请参见[构建运动路径](#build-a-motion-path)。每个创建示例都是可在函数内部直接运行的独立代码；后续编辑示例会说明使用的输出文件。

### **旋转**

使用[CreateRotationEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)创建旋转。[get_By](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/irotationeffect/get_by/)指定相对角度（度）；[get_From](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/irotationeffect/get_from/)和[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/irotationeffect/get_to/)指定端点。

示例从 Spin 效果开始，用一个旋转行为替换其预设操作，并为该操作设置两秒持续时间。90 度的相对角度表示形状起始方向的四分之一次转，因此无需显式指定起始角度。

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

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均基于此文件。

### **缩放**

使用[CreateScaleEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)并提供 X/Y 百分比：[get_From](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/iscaleeffect/get_from/)和[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/iscaleeffect/get_to/)描述起始和结束尺寸，而[get_By](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/iscaleeffect/get_by/)描述相对变化。这里的 100 代表原始尺寸。

示例在两秒内将两个维度从 100% 增长到 125%。使用相同的水平和垂直百分比可保持形状比例；不同的百分比会导致一个维度被拉伸。

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

### **颜色**

使用[CreateColorEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)将填充色从蓝色改为橙色。[get_From](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icoloreffect/get_from/)和[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icoloreffect/get_to/)是颜色；[get_By](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icoloreffect/get_by/)是颜色偏移。[IBehavior::get_Properties](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehavior/get_properties/)标识被动画化的属性。

形状的实心填充被初始化为蓝色，匹配动画的起始颜色。选择填充颜色属性告诉行为要改变形状的哪一部分；仅有颜色端点并不能指明该属性。保存的效果描述了两秒的过渡到橙色。

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

### **滤镜**

使用[CreateFilterEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)选择擦除效果。[get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ifiltereffect/get_type/)、[get_Subtype](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ifiltereffect/get_subtype/)和[get_Reveal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ifiltereffect/get_reveal/)分别指定滤镜、方向以及是显示还是隐藏形状。

本示例配置了一个两秒的擦除效果，使用右向子类型显示形状。滤镜设置属于效果内部的行为，因此在移除预设的原始操作后再进行配置。

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

### **属性**

使用[CreatePropertyEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)对不透明度进行动画化。[get_From](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ipropertyeffect/get_from/)、[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ipropertyeffect/get_to/)和[get_By](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ipropertyeffect/get_by/)是字符串，需通过[get_ValueType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/)和[get_CalcMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/)进行解释。请酌情选择端点或相对偏移，而不是同时设置全部三个。

此处选中的属性是不透明度，数值字符串表示从 25% 不透明度变化到完全不透明。线性插值描述了这些数值之间的逐渐变化。将此示例迁移到其他属性时，请为该属性选择合适的值类型和端点值。

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

### **设置**

使用[CreateSetEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/)通过[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/iseteffect/get_to/)赋予可见性。Set 行为不会在端点之间进行插值。

示例选择可见性属性，并在行为运行时将字符串`visible`赋给它。在 C++ 中，需要先将字符串包装为对象再赋给 Set 行为。矩形在此最小化示例中已经可见，因此仅赋值本身可能看不出明显的视觉变化。此类操作在配合控制形状隐藏或显示的更大效果时非常有用。

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

### **命令**

使用[CreateCommandEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)并配置[get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icommandeffect/get_type/)、[get_CommandString](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icommandeffect/get_commandstring/)和[get_ShapeTarget](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/)。在工作目录中放置名为`sample.wav`的 WAV 录音。本示例使用[AddAudioFrameEmbedded](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addaudioframeembedded/)将其嵌入，并向音频帧附加播放命令。

音频帧既是效果的目标也是命令的目标。这将播放请求链接到嵌入的录音；仅有命令字符串并不能指明要控制的媒体对象。该效果被配置为在幻灯片放映期间点击时启动。

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

保存后将命令存储在`command.pptx`中；它不会播放录音。要播放需要支持该命令及其媒体目标的幻灯片播放器。

## **管理行为集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/)支持[Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/add/)、[Insert](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/insert/)、[Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/removeat/)。本示例打开`rotation.pptx`，添加缩放行为，将其插入到旋转之前，并删除旋转。移除后再次插入同一对象会改变其存储位置而不产生副本。

编辑顺序将集合从 rotation–scale 变为 scale–rotation，最终只剩 scale。索引指向当前集合，因此在重新排序后删除使用的是旋转的新索引。最终枚举确认了将被保存的行为。

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

输出为`ScaleEffect`：仅保留缩放。仅凭集合顺序并不会使行为依次执行。仅在全部替换时才使用 Clear 清空集合。

## **配置行为时间**

[IBehavior::get_Timing](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehavior/get_timing/)公开[ITiming](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/)，独立于[IEffect::get_Timing](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_timing/)。效果时间调度外层效果；行为时间描述其内部的操作。

### **设置持续时间、延迟、重复和加速**

打开`rotation.pptx`并以秒为单位设置[get_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_duration/)和[get_TriggerDelayTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/)，随后配置[get_RepeatCount](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_repeatcount/)。[get_Accelerate](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_accelerate/)和[get_Decelerate](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_decelerate/)是持续时间的分数，确保它们之和不超过 1。

输入文件为旋转示例中创建的文件，其中已知第一个行为是旋转。本示例仅更改该行为的时间；90 度角保持不变。将角度与时间分离，使得在不重新构建动画的情况下更容易调整节奏。

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

该行为使用两秒持续时间、半秒延迟和 3 次重复。其持续时间的前后 20% 用于加速和减速。

其他重复策略包括[get_RepeatDuration](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_repeatduration/)、[get_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/)、[get_RepeatUntilNextClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/)，请根据需要选择一种，而非全部同时启用。[get_AutoReverse](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/get_autoreverse/)会在正向播放后进行逆向播放。加速和减速仅适用于连续变化，不适用于离散赋值或命令。

## **构建运动路径**

使用[CreateMotionEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)创建运动。其[get_From](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_from/)、[get_To](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_to/)、[get_By](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_by/)描述基于百分比的坐标或偏移。若需可编辑路径，请创建[MotionPath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/motionpath/)并将其分配给[IMotionEffect::get_Path](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_path/)。[IMotionPath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotionpath/)存储路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/motioncommandpathtype/) 选择操作：

| 命令 | 点数 | 含义 |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动至其端点。 |
| CurveTo | Three | 按两控制点和端点定义的三次曲线进行跟随。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 完成路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/motionpathpointstype/) 描述点的编辑特性，如拐角点或平滑点。它不替代命令类型。对下面的曲线示例使用曲线点类型，对直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸进行归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正 Y 向下。绝对命令在路径坐标系中指定位置， 相对命令指定相对于当前位置信息的偏移。这与[get_Origin](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_origin/)选择的参考框架以及[get_PathEditMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)控制形状移动时路径如何随之移动是分开的。

### **创建直线路径**

创建一个起点、一个直线段和一个结束命令的运动行为。[IMotionPath::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotionpath/add/)接受命令类型、其点、点类型以及相对坐标标志。

起始命令建立 (0, 0)，直线在 (0.25, 0) 结束，使路径在水平方向上位移幻灯片宽度的四分之一。结束命令没有坐标点。路径分配后，将运动行为加入效果即可将该路线连接到矩形。

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

`motion.pptx` 包含一个包含三个路径命令的运动行为。下面的文件编辑示例均基于此已知结构。

### **比较绝对坐标与相对坐标**

这两个路径对象描述相同的路线。绝对命令以 (0.3, 0.1) 结束；相对命令则在当前位置信息上加上 (0.1, 0.1) 形成 (0.2, 0)。

两条路径起点相同。对于相对直线，需将其 X、Y 偏移加到当前位置信息上得到端点；对于绝对直线，则直接读取端点坐标。若不转换坐标而仅切换标志，将描述不同的路线。

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

将任意一个路径分配给运动行为即可在演示文稿中使用。最后的布尔参数用于为该命令选择相对坐标。

### **用曲线替换直线**

打开`motion.pptx`并将其直线命令替换为三次曲线。先提供两个控制点，再提供端点。

起始位置由前一个命令提供。前两个点形成曲线形状，第三个点是目标位置；它们不是三个连续的目标点。同步更新命令类型、点编辑类型以及点数组，可确保该段在新几何形状下保持一致。

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

`curve.pptx` 中的路径仍然有三个命令，只是其中的中间命令现在定义为曲线。

## **检查并编辑已保存的路径**

每个[IMotionCmdPath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioncmdpath/)都公开[get_Points](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioncmdpath/get_points/)、[get_CommandType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/)、[get_PointsType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/)、[get_IsRelative](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/)。以下示例使用 `motion.pptx` 中已知的三命令路径。对于任意输入，请先定位目标效果并在按索引编辑前检查命令类型和点数。

### **读取命令和坐标**

在不修改路径的情况下读取。结束和闭环命令不需要点，因此要为可能的空点数组做好准备。

输出在列出点之前，会先显示每个命令的相对坐标标志。这样可以在修改路径前区分端点和偏移。曲线会列出三个点，而本文件中的直线仅列出一个点。

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

列出内容包括起始点、一个结束于 (0.25, 0) 的绝对直线以及结束命令。

### **更改端点**

打开`motion.pptx`并替换直线的点数组，以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单一点会改变其目的地，而不会改变命令类型、时间或在集合中的位置。由于该命令使用绝对坐标，新点指定的是位置而非额外的偏移。

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

`motion-endpoint.pptx` 中的直线结束于 (0.4, 0.1)；原文件保持不变。

### **替换段落**

使用[Insert](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotionpath/insert/)和[RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/imotionpath/removeat/)替换 `motion.pptx` 中的直线。插入会将旧直线移至索引 2。

此示例演示了替换命令对象而不是编辑其已有坐标。插入后，集合临时包含起始命令、新直线、旧直线和结束命令。删除索引 2 后，旧直线被丢弃，新的路线保留下来。

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

保存的路径仍然有三个命令，新的直线结束于 (0.2, 0.1)，结束命令仍在最后。

## **修改并验证现有行为**

当行为索引未知时，可按类型选择。此示例打开`rotation.pptx`，找到其[IRotationEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/irotationeffect/)，更改角度，并在重新打开后检查保存的数值。

类型检查使循环能够跳过非旋转行为。第二次加载将已保存的文件读取到另一个演示对象中，因此比较的是持久化数据而不是仍在内存中的值。此示例仍假设已知效果位于主序列的首位；在任意演示文稿中仅按类型选择行为并不能定位正确的效果。

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

输出为`Rotation preserved: True`。对其他行为同样使用类型检查模式。要进行完整的保留检查，请比较目标形状、效果、行为类型与顺序、时间以及路径命令。对浮点数使用数值容差。对于动画布局未知的演示文稿，请参阅[读取形状动画](/slides/zh/cpp/shape-animation/#read-shape-animations)以遍历主序列和交互序列。

## **行为顺序、预设与播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehaviorcollection/) 中的顺序是效果内部操作的存储顺序。它并非播放列表，不能保证每个行为自动等待前一个完成。时间和外层效果决定调度。行为可以重叠，同属性的操作可能通过[get_Additive](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehavior/get_additive/)和[get_Accumulate](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ibehavior/get_accumulate/)产生交互。不要仅依赖集合重新排序来实现“先移动后旋转”；请使用显式时间或如[形状动画](/slides/zh/cpp/shape-animation/)中描述的独立效果。

效果的[get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_type/)和[get_Subtype](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_subtype/)描述其预设。它们并不能完整描述已编辑的行为树。请在自定义行为之前先选择预设和子类型：更改预设会重新构建集合并丢弃自定义操作。例如，将自定义的 Spin 效果改为 Fade 时，会用 Set 和 Filter 行为替代其旋转行为。更改预设或子类型后，请再次检查集合。清除预设行为也可能移除预设所需的可见性或初始化操作。示例有意使用可见形状并替换行为，而不是重新构建每个预设的实现。

## **格式兼容性**

已保存的行为树并不能保证在所有查看器或导出渲染器中呈现完全相同的播放效果。请分别检查保存的数据和渲染输出。

| 格式或输出 | 需要验证的内容 |
| --- | --- |
| PPTX | 作为这些示例的主要格式使用。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放。 |
| PPT | 传统的二进制表示可能与 PPTX 不同。请单独进行保存‑重新打开循环并测试播放；不要仅凭 PPTX 成功就推断对所有自定义组合的支持。 |
| PDF、PNG、JPEG 等静态幻灯片图像 | 仅包含静态幻灯片表示，不包含可播放的行为时间轴或保证的最终动画帧。 |
| [HTML5](/slides/zh/cpp/export-to-html5/) | 在导出选项中启用形状动画时可播放受支持的动画。请在浏览器中测试自定义组合。 |
| [动画 GIF](/slides/zh/cpp/convert-powerpoint-to-animated-gif/) | 存储渲染后的帧，而非可编辑行为或点击触发的交互。请检查实际渲染的运动。 |
| [视频](/slides/zh/cpp/convert-powerpoint-to-video/) | 将动画帧渲染并编码为视频。支持范围受渲染器的[受支持动画和效果](/slides/zh/cpp/convert-powerpoint-to-video/#supported-animations-and-effects)限制；命令和交互事件不会成为可编辑的时间轴。 |

## **常见问题**

**为什么我的效果在未添加任何行为之前就已经包含行为？**

创建预定义效果时可能会生成其底层操作。请在决定是扩展预设还是替换其行为之前先检查这些操作。

**将行为移动到开头会导致它先播放吗？**

不一定。集合顺序并不能替代时间设置。请检查延迟、持续时间以及同属性操作之间的相互影响。

**为什么结束命令没有点？**

结束命令标记路径的结束，不需要坐标。检查从文件读取的路径时，请对可能的空点数组做好判断。

**仅通过成功的往返保存就能确认播放吗？**

不能。重新打开只能确认您检查的属性是否被保留。还需在幻灯片播放器或动画导出中单独测试，以确认其视觉行为。