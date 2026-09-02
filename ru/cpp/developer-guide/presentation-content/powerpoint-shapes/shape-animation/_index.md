---
title: "Применение анимации форм в презентациях с использованием C++"
linktitle: "Анимация формы"
type: docs
weight: 60
url: /ru/cpp/shape-animation/
keywords:
- форма
- анимация
- эффект
- анимированная форма
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звук эффекта
- применить анимацию
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавлять, проверять и настраивать анимацию форм, время, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, параметры времени и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **главная последовательность** воспроизводится по мере перехода к следующему слайду.
- **интерактивная последовательность** начинается при щелчке по её триггер‑форме.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), для большинства содержимого слайда вы используете один и тот же метод [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/). Доступные эффекты перечислены в перечислении [EffectType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttype/).

## **Добавление анимации форм**

Чтобы добавить анимацию, получите главную последовательность слайда и вызовите [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/) с целевой формой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при щелчке по другой форме, создайте интерактивную последовательность, триггером которой будет эта другая форма.

Следующий пример создаёт оба типа анимации и сохраняет результат в `shape-animations.pptx`.

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

Триггер определяет, когда эффект начинается:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttriggertype/) ждёт щелчка в главной последовательности или щелчка по триггер‑форме в интерактивной последовательности.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttriggertype/) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effecttriggertype/) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип формы, передайте соответствующий объект в [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/) вместо `targetShape`. Параметры группировки, специфичные для диаграмм, см. в разделе [Animated Charts](/slides/ru/cpp/animated-charts/).

## **Чтение анимации форм**

Используйте [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/geteffectsbyshape/), когда известна целевая форма. Чтобы просмотреть каждый эффект, переберите главную последовательность и все интерактивные последовательности. Перебор избавляет от предположения, что в последовательности есть эффект с индексом `0`.

Следующий пример создаёт форму с эффектами главной и интерактивной последовательностей, получает эффекты, направленные к этой форме, а затем перебирает каждую последовательность на слайде.

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

Если нужны только эффекты для одной формы, сначала определите форму по имени, типу заполнителя или другому стабильному свойству; затем вызовите [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Не предполагаете, что [IShapeCollection::idx_get](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/idx_get/) с индексом `0` всегда возвращает нужный объект.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать поведение анимации от соответствующего заполнителя на слайде‑шаблоне и на мастер‑слайде. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getbaseplaceholder/) возвращает родительский заполнитель или `nullptr`, если родителя нет.

В представлении ниже в нижнем колонтитуле на обычном слайде указаны **Random Bars**, на шаблонном слайде — **Split**, а на мастер‑слайде — **Fly In**.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на шаблонном слайде](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на мастер‑слайде](master-shape-animation.png)

Следующий пример создает иерархию заполнителей. Он добавляет эффекты к заполнитель‑мастеру, заполнитель‑шаблону и соответствующему заполнителю на обычном слайде. Каждый вызов [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getbaseplaceholder/) проверяется перед использованием возвращённой формы.

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

## **Изменение времени анимации**

Диалог PowerPoint **Timing** соответствует методам [ITiming](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/).

![Диалог Timing в PowerPoint для эффекта анимации](shape-animation.png)

- **Start** соответствует [ITiming::set_TriggerType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** соответствует [ITiming::set_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_duration/), в секундах.
- **Delay** соответствует [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), в секундах.
- **Repeat** соответствует [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) или [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** соответствует [ITiming::set_Rewind](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_rewind/).

Этот самостоятельный пример добавляет эффект, меняет его время через объект, возвращённый [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/), и сохраняет результат. Сохранение ссылки на возвращённый [IEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/) избавляет от необходимости использовать индекс коллекции.

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

Используйте один режим повторения преднамеренно. Сочетание количества повторов с флагом «until» может приводить к запутанным результатам в разных просмотрщиках. При изменении режима повторения вызывайте [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) и [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) **до** [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/set_repeatcount/), поскольку установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный аудио‑файл через [IEffect::set_Sound](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) указывает эффекту остановить звук, запущенный предыдущим эффектом.

### **Добавление звука к эффекту**

В следующем примере ожидается локальный аудио‑файл `animation-sound.wav`. Он создаёт два эффекта, встраивает файл как звук первого эффекта и настраивает второй эффект для остановки звука. Для этого используются объекты, возвращённые [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/), поэтому индекс последовательности не требуется.

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

### **Извлечение встроенных звуков эффектов**

В следующем примере ожидается локальная презентация `presentation-with-animation-sounds.pptx`. Он сканирует как главные, так и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается исходя из MIME‑типа аудио, получаемого через [IAudio::get_ContentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudio/get_contenttype/).

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

Для больших аудио‑объектов используйте [IAudio::GetStream](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudio/getstream/) и копируйте поток в файл вместо загрузки полного объекта в массив байтов.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с формой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Перечисление [AfterAnimationType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) поддерживает оставление формы без изменений, изменение её цвета, скрытие после анимации или скрытие при следующем щелчке. Когда тип равен [AfterAnimationType::Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/), вызовите [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) для установки цвета.

Этот самостоятельный пример создаёт эффект, задаёт его поведение после анимации через возвращённый объект эффекта и сохраняет результат.

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

Изменение типа от [AfterAnimationType::Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) очищает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных параметра:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itextanimation/set_buildtype/) управляет тем, появляются ли абзацы совместно или по отдельным абзацам.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) управляет тем, появляется ли текст сразу, по словам или по буквам. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) задаёт задержку между словами или буквами. Положительное значение — это процент от длительности эффекта; отрицательное значение — задержка в секундах.

Следующий самостоятельный пример анимирует слова в текстовом поле. [BuildType::AsOneObject](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/buildtype/) отключает построение по абзацам, поэтому настройка по словам применяется ко всему текстовому кадру.

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

Чтобы построить текстовое поле по абзацам, используйте [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itextanimation/set_buildtype/) с [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/buildtype/) или другим уровнем абзаца. Чтобы задать отдельный эффект для одного абзаца, используйте перегрузку [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/), принимающую [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/). См. раздел [Animated Text](/slides/ru/cpp/animated-text/) для примеров уровня абзаца.

## **Экспорт и замечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется средством просмотра презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/cpp/export-to-html5/), анимированный GIF или [video conversion](/slides/ru/cpp/convert-powerpoint-to-video/), когда вывод должен показывать движение.
- Для HTML5 включите [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animateshapes/) и, при необходимости, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Видеорендеринг поддерживает многие обычные эффекты входа, выделения, выхода и движения по траектории, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [supported animations and effects](/slides/ru/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с используемой версией Aspose.Slides.
- Продвинутые пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только имя эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимация и переходы слайдов не воспроизводятся. При необходимости движения экспортируйте в HTML5, анимированный GIF или видео.

**Почему эффект воспроизводится иначе в видео?**

При экспорте в видео анимация рендерится, а не сохраняется оригинальное поведение PowerPoint. Некоторые продвинутые эффекты не поддерживаются или приближенно имитируются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед выпуском.

**Изменяет ли перемещение формы вперёд или назад её порядок анимации?**

Нет. Порядок z‑положения формы управляет наложением, тогда как порядок последовательности и триггеры управляют воспроизведением анимации. Измените временную шкалу, если нужен иной порядок воспроизведения.