---
title: 在演示文稿中使用 C++ 应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/cpp/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 添加、检查和自定义形状动画、时间设置、声音、动画结束后行为以及动画文本。"
---
## **概述**

Aspose.Slides for C++ 将幻灯片动画表示为幻灯片时间轴中的效果。每个效果包括目标形状、动画类型和子类型、触发方式、时间设置以及可选的属性，如声音或动画完成后的行为。

时间轴包含两类序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被单击时启动。

由于文本框、图片、图表、表格及其他幻灯片对象实现了[IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/)，您可以对大多数幻灯片内容使用相同的[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)方法。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effecttype/)枚举中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)，传入目标形状、效果类型、子类型和触发方式。对于需要在单击另一个形状时启动的效果，创建一个触发器为该形状的交互序列。

下面的示例创建两种类型的动画并将结果保存为`shape-animations.pptx`。

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

触发器决定效果何时开始：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effecttriggertype/) 在主序列中等待点击，或在交互序列中等待对触发形状的点击。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effecttriggertype/) 与前一个效果同时启动。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effecttriggertype/) 在前一个效果结束后启动。

要为图片、图表或其他形状类型添加动画，请将相应对象传递给[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)，而不是`targetShape`。有关图表特定的分组选项，请参阅[Animated Charts](/slides/zh/cpp/animated-charts/)。

## **读取形状动画**

当已知目标形状时，使用[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)。若要检查每个效果，请枚举主序列和所有交互序列。枚举可以避免假设序列在索引`0`处一定存在效果。

下面的示例创建了一个具有主序列和交互效果的形状，获取针对该形状的效果，然后枚举幻灯片上的所有序列。

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

如果只需要单个形状的效果，首先通过名称、占位符类型或其他稳定属性定位该形状；然后调用[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)。不要假设[IShapeCollection::idx_get](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/idx_get/)在索引`0`处始终是目标对象。

## **处理继承占位符效果**

普通幻灯片上的占位符可以继承其布局幻灯片和母版幻灯片上对应占位符的动画行为。[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getbaseplaceholder/)返回该父占位符；如果没有父占位符，则返回`nullptr`。

在下面的示例演示文稿中，页脚在普通幻灯片上使用 **Random Bars**，在布局幻灯片上使用 **Split**，在母版幻灯片上使用 **Fly In**。

![普通幻灯片上的页脚动画效果](slide-shape-animation.png)

![布局幻灯片上页脚占位符的动画效果](layout-shape-animation.png)

![母版幻灯片上页脚占位符的动画效果](master-shape-animation.png)

接下来的示例自行构建占位符层级。它向母版占位符、布局占位符以及普通幻灯片上的对应占位符添加效果。每次调用[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getbaseplaceholder/)前都会进行检查。

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **更改动画时间设置**

PowerPoint **Timing** 对话框对应于[ITiming](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/)的方法。

![PowerPoint 动画效果的 Timing 对话框](shape-animation.png)

- **Start** 对应[ITiming::set_TriggerType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_triggertype/)。
- **Duration** 对应[ITiming::set_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_duration/)，单位为秒。
- **Delay** 对应[ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/)，单位为秒。
- **Repeat** 对应[ITiming::set_RepeatCount](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatcount/)、[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)或[ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)。
- **Rewind when done playing** 对应[ITiming::set_Rewind](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_rewind/)。

下面的独立示例添加一个效果，通过[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)返回的对象更改其时间设置，并保存结果。保留返回的[IEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/)引用可以避免不必要的集合索引。

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

请仅使用一种重复模式。将重复计数与“直到”标志组合使用可能在不同的查看器中产生混乱的结果。更改重复模式时，先调用[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)和[ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)，再调用[ITiming::set_RepeatCount](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itiming/set_repeatcount/)，因为设置任意标志都会同时改变当前的重复模式。

## **添加和提取动画声音**

动画效果可以通过[IEffect::set_Sound](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_sound/)引用嵌入的音频。[IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/)指示效果停止先前效果启动的音频。

### **向效果添加声音**

下面的示例需要本地音频文件`animation-sound.wav`。它创建两个效果，将该文件嵌入为第一个效果的声音，并将第二个效果配置为停止该声音。示例使用[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/)返回的对象，因此不需要序列索引。

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **提取嵌入的效果声音**

下面的示例需要本地演示文稿`presentation-with-animation-sounds.pptx`。它扫描主序列和交互序列，将每个嵌入的效果声音写入`extracted-animation-sounds`目录。文件扩展名根据[IAudio::get_ContentType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iaudio/get_contenttype/)返回的音频 MIME 类型自动选择。

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

对于大型音频对象，请使用[IAudio::GetStream](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iaudio/getstream/)并将流复制到文件，而不是一次性加载整个对象到字节数组中。

## **设置动画结束后的行为**

**After animation** 选项控制形状在其效果完成后会发生什么。

![PowerPoint 效果选项对话框显示 After animation 设置](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 枚举支持保持形状不变、改变颜色、在动画后隐藏或在下一次点击时隐藏。当类型为[AfterAnimationType::Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/)时，调用[IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/)来设置颜色。

下面的独立示例创建一个效果，通过返回的效果对象设置其动画结束后行为，并保存结果。

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
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
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

将类型从[AfterAnimationType::Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/)更改会清除动画结束后的颜色设置。

## **文本动画**

文本动画有两个相关控制：

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 控制段落是一起出现还是逐段出现。
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 控制文本是一次性出现、按单词还是按字符出现。[IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 设置单词或字符之间的延迟。正值为效果持续时间的百分比，负值为秒数延迟。

下面的独立示例对文本框中的单词进行动画演示。[BuildType::AsOneObject](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/buildtype/) 关闭段落逐段构建，使单词设置适用于整个文本框。

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若要按段落构建文本框，请使用[ITextAnimation::set_BuildType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/itextanimation/set_buildtype/)并传入[BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/buildtype/)或其他段落级别。若要为单独段落指定独立效果，请使用接受[IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 参数的[ISequence::AddEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/addeffect/) 重载。有关段落级别示例，请参阅[Animated Text](/slides/zh/cpp/animated-text/)。

## **导出和兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不播放动画。需要展示运动时请使用[HTML5 导出](/slides/zh/cpp/export-to-html5/)、动画 GIF 或[视频转换](/slides/zh/cpp/convert-powerpoint-to-video/)。
- 对于 HTML5，启用[Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animateshapes/)，必要时再启用[Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animatetransitions/)。
- 视频渲染支持许多常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请查看当前的[受支持动画和效果](/slides/zh/cpp/convert-powerpoint-to-video/#supported-animations-and-effects)，并在目标 Aspose.Slides 版本下对关键演示文稿进行测试。
- 高级自定义效果以及从其他演示文稿格式导入的效果可能在文件中保留下来，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不要仅依赖效果名称。

## **常见问题**

**为什么动画在 PowerPoint 中出现，但在 PDF 中没有？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保留运动时请导出为 HTML5、动画 GIF 或视频。

**为什么同一效果在视频中呈现不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或被近似。请查看受支持的效果表，并在投入生产前对实际演示文稿进行测试。

**移动形状的前置或后置会改变其动画顺序吗？**

不会。形状的 Z 顺序控制重叠，序列顺序和触发方式控制动画播放。如果需要不同的播放顺序，请修改时间轴。