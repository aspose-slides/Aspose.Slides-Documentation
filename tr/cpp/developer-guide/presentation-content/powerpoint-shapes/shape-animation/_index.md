---
title: C++ Kullanarak Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/cpp/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni ekleme, inceleme ve özelleştirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efekt hedef şekil, animasyon türü ve alt tür, tetikleyici, zamanlama ayarları ve isteğe bağlı olarak ses ya da animasyon sonrası davranış gibi özelliklere sahiptir.

Zaman çizelgesi iki tür dizi içerir:

- **ana dizi** slayt ilerlerken oynatılır.
- **etkileşimli dizi** tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) uyguladığından, çoğu slayt içeriği için aynı [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttype/) enumunda listelenmiştir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için slaytın ana dizisini alın ve hedef şekil, efekt türü, alt tür ve tetikleyiciyle [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek hem ana hem de etkileşimli animasyon türlerini oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

Tetikleyici bir efektin ne zaman başlayacağını denetler:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttriggertype/) ana dizide bir tıklama ya da etkileşimli dizide tetikleyici şekle tıklama bekler.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttriggertype/) önceki efektle birlikte başlar.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effecttriggertype/) önceki efekt bittiğinde başlar.

Bir resmi, grafiği veya başka bir şekil türünü animasyonlamak için `targetShape` yerine o nesneyi [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) metoduna gönderin. Grafik‑özel grup seçenekleri için [Animated Charts](/slides/tr/cpp/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) kullanın. Tüm efektleri incelemek için ana diziyi ve her etkileşimli diziyi döngüyle gezinin. Dizi içinde `0` indeksinde bir efekt olduğunu varsaymayın.

Aşağıdaki örnek bir şekle ana‑dizi ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm dizileri döngüyle listeler.

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

Yalnızca tek bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka sabit bir özellik ile tanımlayın; ardından [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) metodunu çağırın. [IShapeCollection::idx_get](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/idx_get/) metodunun `0` indeksindeki nesnenin her zaman istenen nesne olduğunu varsamamalısınız.

## **Devralınan Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve master slayttaki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getbaseplaceholder/) bu üst yer tutucuyu döndürür; üst yoksa `nullptr` döner.

Aşağıdaki örnek sunumda altbilgi, normal slaytta **Random Bars**, düzen slaytta **Split**, master slaytta ise **Fly In** efektine sahiptir.

![Normal slayttaki altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slayttaki altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Master slayttaki altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek yer tutucu hiyerarşisini kendisi oluşturur. Bir master yer tutucu, bir düzen yer tutucu ve normal slayttaki karşılık gelen yer tutucuya efekt ekler. Her [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getbaseplaceholder/) çağrısı, dönen şekil kullanılmadan önce kontrol edilir.

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

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu, [ITiming](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/) yöntemlerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** [ITiming::set_TriggerType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_triggertype/) ile eşleştirilir.
- **Duration** [ITiming::set_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_duration/) ile eşleştirilir, saniye cinsindendir.
- **Delay** [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) ile eşleştirilir, saniye cinsindendir.
- **Repeat** [ITiming::set_RepeatCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) veya [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) ile eşleştirilir.
- **Rewind when done playing** [ITiming::set_Rewind](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_rewind/) ile eşleştirilir.

Bu bağımsız örnek bir efekt ekler, [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesne üzerinden zamanlamasını değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/) referansını tutmak, gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir tekrar modunu kasıtlı olarak kullanın. Tekrar sayısı ile “until” bayrağının bir arada kullanılması, farklı görüntüleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modunu değiştirirken, önce [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) ve [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) ardından [ITiming::set_RepeatCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/set_repeatcount/) çağırın; çünkü bir bayrağın ayarlanması aynı zamanda etkin tekrar modunu değiştirir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon efekti, [IEffect::set_Sound](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_sound/) aracılığıyla gömülü ses referansına sahip olabilir. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) bir efektin, önceki bir efekt tarafından başlatılan sesi durdurmasını söyler.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası olduğunu varsayar. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efektin sesi durdurmasını ayarlar. [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesneler kullanıldığı için dizi indeksine ihtiyaç yoktur.

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

### **Gömülü Efekt Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum olduğunu varsayar. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` klasörüne yazar. Uzantı, [IAudio::get_ContentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudio/get_contenttype/) tarafından sağlanan ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, tüm nesneyi bayt dizisine yüklemek yerine [IAudio::GetStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudio/getstream/) kullanıp akışı bir dosyaya kopyayın.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin efekti bitince ne olacağını belirler.

![PowerPoint Efekt Seçenekleri iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) enumı, şekli değişmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType::Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) ise, renk ayarlamasını yapmak için [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) çağrılır.

Bu bağımsız örnek bir efekt oluşturur, dönen efekt nesnesi üzerinden animasyon‑sonrası davranışı ayarlar ve sonucu kaydeder.

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) dışındaki bir türe geçmek, animasyon‑sonrası renk ayarını temizler.

## **Metin Animasyonu**

Metin animasyonunda iki ilgili kontrol bulunur:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itextanimation/set_buildtype/) paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini belirler.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) metnin tüm olarak, kelime bazında veya harf bazında görünüp görünmeyeceğini belirler. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) kelimeler ya da harfler arasındaki gecikmeyi ayarlar. Pozitif değer efekt süresinin yüzdesi; negatif değer saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType::AsOneObject](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/buildtype/) paragraf‑bazlı oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Metin kutusunu paragraf bazında oluşturmak için [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itextanimation/set_buildtype/) ile [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/buildtype/) veya başka bir paragraf seviyesi kullanın. Tek bir paragrafı kendi etkisiyle hedeflemek için bir [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) alabilen [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animated Text](/slides/tr/cpp/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyon oynatmaz. Hareketin gösterilmesi gerekiyorsa [HTML5 dışa aktarımı](/slides/tr/cpp/export-to-html5/), animasyonlu GIF veya [video dönüştürme](/slides/tr/cpp/convert-powerpoint-to-video/) kullanın.
- HTML5 için [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animateshapes/) ve gerektiğinde [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animatetransitions/) etkinleştirin.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini destekler; ancak her PowerPoint efekti desteklenmez. Güncel [desteklenen animasyonlar ve efektler](/slides/tr/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video içinde farklı şekilde işlenebilir. Yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünüyor ancak PDF’de neden görünmüyor?**

PDF statik bir formattır; animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video içinde farklı nasıl oynatılıyor?**

Video dışa aktarımı animasyonları işler, orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak işlenir. Desteklenen‑efektler tablosunu inceleyin ve üretime geçmeden önce gerçek sunumu test edin.

**Bir şekli öne veya arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑sırası üst üste biniş kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırasına ihtiyacınız varsa zaman çizelgesini değiştirin.