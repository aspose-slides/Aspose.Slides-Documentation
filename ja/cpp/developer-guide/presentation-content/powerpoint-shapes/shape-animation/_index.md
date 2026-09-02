---
title: C++ を使用したプレゼンテーションへのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/cpp/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、シェイプ アニメーションの追加、検査、カスタマイズ、タイミング、サウンド、アフター アニメーション 動作、およびアニメーション テキストの方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、スライド アニメーションをスライド タイムライン上のエフェクトとして表現します。エフェクトには対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、およびサウンドやアフター アニメーション 動作などのオプション プロパティがあります。

タイムラインには次の 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進行する際に再生されます。  
- **インタラクティブ シーケンス** はトリガー シェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、テーブル、その他のスライド オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) を実装しているため、ほとんどのスライド コンテンツに対して同じ [ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttype/) 列挙体に一覧化されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合、そのシェイプをトリガーとしたインタラクティブ シーケンスを作成します。

以下の例は両方のタイプのアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

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

トリガーはエフェクトの開始タイミングを制御します。

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttriggertype/) はメイン シーケンスではクリック待ち、インタラクティブ シーケンスではトリガー シェイプのクリック待ちです。  
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttriggertype/) は直前のエフェクトと同時に開始します。  
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttriggertype/) は直前のエフェクトが終了したときに開始します。

画像、チャート、またはその他のシェイプ タイプをアニメーション化する場合は、`targetShape` の代わりにそのオブジェクトを [ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) に渡します。チャート固有のグループ化オプションについては [Animated Charts](/slides/ja/cpp/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は、[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) を使用します。すべてのエフェクトを調べるには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙時にインデックス `0` にエフェクトが必ずあると仮定しないでください。

以下の例はメイン シーケンスとインタラクティブ シーケンスのエフェクトを持つシェイプを作成し、対象シェイプのエフェクトを取得した後、スライド上のすべてのシーケンスを列挙します。

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

1 つのシェイプだけのエフェクトが必要な場合は、名前、プレースホルダー タイプ、または他の安定したプロパティでシェイプを特定し、[ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) を呼び出してください。インデックス `0` の [IShapeCollection::idx_get](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/idx_get/) が常に目的のオブジェクトであるとは限りません。

## **継承プレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウト スライドやマスタースライド上の対応するプレースホルダーからアニメーション動作を継承できます。[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getbaseplaceholder/) はその親プレースホルダーを返し、存在しない場合は `nullptr` を返します。

以下の例のプレゼンテーションでは、フッターが通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** のエフェクトを持っています。

![通常スライド上のフッター アニメーション エフェクト](slide-shape-animation.png)

![レイアウトスライド上のフッター プレースホルダー アニメーション エフェクト](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション エフェクト](master-shape-animation.png)

次の例はプレースホルダー階層自体を構築します。マスタープレースホルダー、レイアウトプレースホルダー、通常スライド上の対応プレースホルダーにエフェクトを追加します。すべての [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getbaseplaceholder/) 呼び出しは、返されたシェイプが使用される前にチェックされています。

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

## **アニメーション タイミングの変更**

PowerPoint の **Timing** ダイアログは [ITiming](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/) のメソッドに対応します。

![アニメーション エフェクトの PowerPoint Timing ダイアログ](shape-animation.png)

- **Start** は [ITiming::set_TriggerType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_triggertype/) にマップされます。  
- **Duration** は秒単位で [ITiming::set_Duration](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_duration/) にマップされます。  
- **Delay** は秒単位で [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) にマップされます。  
- **Repeat** は [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatcount/)、[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)、または [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) にマップされます。  
- **Rewind when done playing** は [ITiming::set_Rewind](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_rewind/) にマップされます。

この独立した例では、[ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) が返すオブジェクトを使用してエフェクトを追加し、タイミングを変更して結果を保存します。返された [IEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/) 参照を保持することで、不要なコレクション インデックス取得を回避します。

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

繰り返しモードは意図的に 1 つだけ使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアーによっては混乱する結果になる可能性があります。繰り返しモードを変更する際は、[ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) と [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) を先に呼び出し、次に [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itiming/set_repeatcount/) を呼び出してください。フラグを設定するとアクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [IEffect::set_Sound](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_sound/) を使用して埋め込みオーディオを参照できます。[IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) は、以前のエフェクトで開始されたサウンドを停止させることができます。

### **エフェクトにサウンドを追加する**

以下の例はローカルのオーディオ ファイル `animation-sound.wav` を前提としています。2 つのエフェクトを作成し、最初のエフェクトにそのファイルをサウンドとして埋め込み、2 番目のエフェクトでサウンドを停止するよう設定します。今回も [ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) が返すオブジェクトを使用するため、シーケンス インデックスは不要です。

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

### **埋め込みエフェクト サウンドの抽出**

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を前提としています。メイン シーケンスとインタラクティブ シーケンスの両方を走査し、埋め込みサウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。ファイル拡張子は [IAudio::get_ContentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudio/get_contenttype/) が返す MIME タイプから選択されます。

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

大容量のオーディオ オブジェクトの場合は、[IAudio::GetStream](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudio/getstream/) を使用してストリームをファイルにコピーし、全体をバイト配列として読み込むのを避けてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプがどうなるかを制御します。

![After animation 設定を示す PowerPoint Effect Options ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) 列挙体は、シェイプを変更しない、色を変える、アニメーション後に非表示にする、または次のクリックで非表示にする、という動作をサポートします。タイプが [AfterAnimationType::Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) の場合は、[IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) を使用して色も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトを介してアフター アニメーション 動作を設定し、結果を保存します。

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/afteranimationtype/) 以外のタイプに変更すると、アフター アニメーションの色設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには次の 2 つの関連コントロールがあります。

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itextanimation/set_buildtype/) は段落単位で表示するか、全体として表示するかを制御します。  
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) はテキストの表示方式（全体、一語、文字単位）を制御します。[IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) は語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType::AsOneObject](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/buildtype/) を使用して段落単位のビルドを無効にし、単語設定をテキスト フレーム全体に適用しています。

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

段落単位でテキスト ボックスをビルドしたい場合は、[ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/itextanimation/set_buildtype/) に [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/buildtype/) などの段落レベルを指定してください。単一の段落に個別のエフェクトを適用するには、[IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) を受け取るオーバーロードの [ISequence::AddEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/isequence/addeffect/) を使用します。段落レベルの例については [Animated Text](/slides/ja/cpp/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX で保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアーによって制御されます。  
- PDF および静止画像はアニメーションを再生しません。モーションを示す必要がある場合は、[HTML5 エクスポート](/slides/ja/cpp/export-to-html5/)、アニメーション GIF、または [ビデオ変換](/slides/ja/cpp/convert-powerpoint-to-video/) を使用してください。  
- HTML5 の場合は [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animateshapes/) を有効にし、必要に応じて [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animatetransitions/) も有効にしてください。  
- ビデオレンダリングは多くの一般的な入口、強調、退出、モーションパス エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポート対象アニメーションとエフェクト](/slides/ja/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。  
- カスタム エフェクトや他のプレゼンテーション形式からインポートされたエフェクトはファイル内に保持されることがありますが、PowerPoint、HTML5、またはビデオでの描画が異なる場合があります。エフェクト名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**PowerPoint ではアニメーションが表示されるのに PDF では表示されないのはなぜですか？**

PDF は静的形式であるため、アニメーションやスライド遷移は再生されません。モーションを保持する必要がある場合は HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**ビデオでエフェクトの再生が異なるのはなぜですか？**

ビデオエクスポートはアニメーションをレンダリングしたもので、元の PowerPoint の動作を保存するものではありません。一部の高度なエフェクトはサポートされていないか、近似されます。サポート対象エフェクト一覧を確認し、実際のプレゼンテーションでテストしてください。

**シェイプを前面または背面に移動するとアニメーション順序が変わりますか？**

変更されません。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーション再生順序を制御します。再生順序を変更したい場合は、タイムラインを調整してください。