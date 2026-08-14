---
title: 使用 C++ 在簡報中套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/cpp/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 已動畫化的形狀
- 已動畫化的文字
- 新增動畫
- 取得動畫
- 抽取動畫
- 新增效果
- 取得效果
- 抽取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 來新增、檢查和自訂形狀動畫、時間設定、音效、動畫結束後的行為，以及已動畫化的文字。"
---
## **概述**

Aspose.Slides for C++ 將投影片動畫表示為投影片時間軸中的效果。每個效果包括目標形狀、動畫類型與子類型、觸發方式、時間設定，以及可選的屬性（例如音效或動畫結束後的行為）。

時間軸包含兩種序列：

- **主要序列** 會在投影片前進時播放。
- **互動序列** 會在其觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格和其他投影片物件皆實作[IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，您可以對大多數投影片內容使用相同的[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 方法。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttype/) 列舉。

## **為形狀加入動畫**

若要加入動畫，取得投影片的主要序列，然後呼叫[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 並傳入目標形狀、效果類型、子類型與觸發方式。若要建立在點擊其他形狀時開始的效果，請建立觸發形狀為該其他形狀的互動序列。

以下範例同時建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

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

觸發方式決定效果何時開始：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttriggertype/) 在主要序列中等待點擊，或在互動序列中等待對觸發形狀的點擊。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttriggertype/) 與前一個效果同時開始。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttriggertype/) 在前一個效果結束後開始。

若要為圖片、圖表或其他形狀類型進行動畫，只需將該物件傳給[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/)，而不是 `targetShape`。圖表專屬的分組選項，請參閱[Animated Charts](/slides/zh-hant/cpp/animated-charts/)。

## **讀取形狀動畫**

當您已知目標形狀時，使用[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)。若要檢視每個效果，請列舉主要序列以及所有互動序列。列舉可避免假設序列在索引 `0` 處一定有效果。

以下範例建立具有主要序列與互動效果的形狀，取得針對該形狀的效果，並列舉投影片上的每個序列。

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

如果只需要單一形狀的效果，請先依名稱、佔位符類型或其他穩定屬性識別該形狀，然後呼叫[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)。不要假設[IShapeCollection::idx_get](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/idx_get/) 在索引 `0` 處一定是目標物件。

## **處理繼承自佔位符的效果**

普通投影片上的佔位符可以繼承其版面投影片與母版投影片中相對佔位符的動畫行為。[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getbaseplaceholder/) 會回傳該父佔位符，若不存在則回傳 `nullptr`。

在以下範例簡報中，頁腳在普通投影片上具有 **Random Bars**，在版面投影片上具有 **Split**，在母版投影片上具有 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上的頁腳佔位符動畫效果](master-shape-animation.png)

接下來的範例自行建立佔位符層級，分別在母版佔位符、版面佔位符與普通投影片上的相對佔位符加入效果。每次呼叫[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getbaseplaceholder/) 前，都會先檢查回傳的形狀是否為空。

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

## **變更動畫時間設定**

PowerPoint 的 **Timing** 對話方塊對應至[ITiming](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/) 的方法。

![PowerPoint 動畫效果的 Timing 對話方塊](shape-animation.png)

- **Start** 對應 [ITiming::set_TriggerType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_triggertype/)。
- **Duration** 對應 [ITiming::set_Duration](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_duration/)，單位為秒。
- **Delay** 對應 [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/)，單位為秒。
- **Repeat** 對應 [ITiming::set_RepeatCount](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatcount/)、[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) 或 [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)。
- **Rewind when done playing** 對應 [ITiming::set_Rewind](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_rewind/)。

此獨立範例加入一個效果，透過[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 回傳的物件變更其時間設定，並儲存結果。保留回傳的[IEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/) 參考可避免不必要的集合索引。

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

請僅使用一種重複模式。將重複次數與「until」旗標同時使用，可能在不同檢視器中產生混淆結果。變更重複模式時，請先呼叫[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)與[ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)，再呼叫[ITiming::set_RepeatCount](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itiming/set_repeatcount/)，因為設定任一旗標都會同時變更目前的重複模式。

## **加入與擷取動畫音效**

動畫效果可以透過[IEffect::set_Sound](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_sound/) 參照嵌入的音訊。[IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) 可指示效果在播放前一個效果的音訊時停止它。

### **為效果加入音效**

以下範例假設本機有名為 `animation-sound.wav` 的音訊檔。它建立兩個效果，將該檔案嵌入為第一個效果的音效，並設定第二個效果停止音效。範例使用[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 回傳的物件，無需指定序列索引。

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

### **擷取嵌入的效果音效**

以下範例假設本機有名為 `presentation-with-animation-sounds.pptx` 的簡報。它掃描主要與互動序列，將每個嵌入的效果音效寫入 `extracted-animation-sounds` 目錄。副檔名會根據[IAudio::get_ContentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudio/get_contenttype/) 回傳的音訊 MIME 類型自動選取。

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

對於大型音訊物件，請使用[IAudio::GetStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudio/getstream/) 並將串流複製到檔案，而非將整個物件載入記憶體的位元組陣列。

## **設定動畫結束後的行為**

**After animation** 選項控制形狀在效果結束後的狀態。

![PowerPoint 效果選項對話方塊顯示 After animation 設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 列舉支援保持形狀不變、變更顏色、在動畫後隱藏，或在下一次點擊時隱藏。當類型為[AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 時，請呼叫[IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) 以同時設定顏色。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫結束後的行為，並儲存結果。

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

將類型改為非[AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/afteranimationtype/) 時，會清除先前設定的 after‑animation 顏色。

## **文字動畫**

文字動畫有兩個相關控制項：

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 控制段落是一次顯示還是逐段顯示。
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 控制文字是一次顯示、逐字或逐詞顯示。[IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 設定字或詞之間的延遲。正值表示效果持續時間的百分比，負值則是以秒為單位的延遲。

以下獨立範例對文字方塊內的詞彙進行動畫。[BuildType::AsOneObject](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/buildtype/) 會停用逐段建構，使詞彙設定套用於整個文字框。

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

若要逐段建構文字方塊，請使用[ITextAnimation::set_BuildType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 並搭配 [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/buildtype/) 或其他段落層級。若要針對單一段落設定獨立效果，請使用接受[IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 的[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/) 重載。相關段落層級範例請參閱[Animated Text](/slides/zh-hant/cpp/animated-text/)。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放方式取決於簡報檢視器。
- PDF 與靜態圖片不會播放動畫。若輸出必須展示動態效果，請使用[HTML5 export](/slides/zh-hant/cpp/export-to-html5/)、動畫 GIF 或[video conversion](/slides/zh-hant/cpp/convert-powerpoint-to-video/)。
- 針對 HTML5，請啟用[Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animateshapes/)，必要時再啟用[Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animatetransitions/)。
- 影片轉換支援許多常見的進場、強調、退出與路徑動畫，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[Supported animations and effects](/slides/zh-hant/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) 並在目標 Aspose.Slides 版本上測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能會在檔案中保留，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而不要僅依賴效果名稱。

## **常見問答**

**為什麼動畫在 PowerPoint 中能顯示，卻在 PDF 中看不到？**

PDF 為靜態格式，無法播放動畫和投影片切換。若需保留動態效果，請匯出為 HTML5、動畫 GIF 或影片。

**為什麼同一效果在影片中播放的結果不同？**

影片匯出會將動畫渲染成視訊，而不是保留原始 PowerPoint 行為。某些進階效果不支援或只能近似。請參考支援的效果清單，並在正式使用前測試實際簡報。

**將形狀向前或向後移動會改變動畫的播放順序嗎？**

不會。形狀的 Z‑order 只控制重疊順序，而序列順序與觸發方式才決定動畫播放順序。若需變更播放順序，請調整時間軸。