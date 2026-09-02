---
title: Aplicar Animações de Forma em Apresentações Usando C++
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/cpp/shape-animation/
keywords:
- forma
- animação
- efeito
- forma animada
- texto animado
- adicionar animação
- obter animação
- extrair animação
- adicionar efeito
- obter efeito
- extrair efeito
- som do efeito
- aplicar animação
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como adicionar, inspecionar e personalizar animações de forma, tempo, sons, comportamento pós-animação e texto animado com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ representa animações de slides como efeitos em uma linha do tempo de slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de tempo e propriedades opcionais, como som ou comportamento após a animação.

A linha do tempo contém dois tipos de sequências:

- A **sequência principal** é reproduzida conforme o slide avança.
- Uma **sequência interativa** inicia quando sua forma de gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide implementam [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), você usa o mesmo método [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) para a maioria do conteúdo do slide. Os efeitos disponíveis são listados na enumeração [EffectType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttype/).

## **Adicionar Animações de Forma**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) com a forma de destino, o tipo de efeito, o subtipo e o gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

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

O gatilho controla quando um efeito inicia:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttriggertype/) aguarda um clique na sequência principal, ou um clique na forma de gatilho em uma sequência interativa.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttriggertype/) inicia com o efeito anterior.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttriggertype/) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) em vez de `targetShape`. Para opções de agrupamento específicas de gráficos, veja [Animated Charts](/slides/pt/cpp/animated-charts/).

## **Ler Animações de Forma**

Use [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) quando você conhece a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e todas as sequências interativas. A enumeração evita presumir que uma sequência contenha um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como destino e, em seguida, enumera todas as sequências no slide.

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

Se você precisar apenas dos efeitos para uma única forma, primeiro identifique a forma por nome, tipo de placeholder ou outra propriedade estável; então chame [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Não presuma que [IShapeCollection::idx_get](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/idx_get/) no índice `0` seja sempre o objeto desejado.

## **Trabalhar com Efeitos de Placeholder Herdados**

Um placeholder em um slide normal pode herdar o comportamento de animação do placeholder correspondente em seu slide de layout e slide mestre. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getbaseplaceholder/) retorna esse placeholder pai, ou `nullptr` quando nenhum pai existe.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação do rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo constrói a hierarquia de placeholders por si mesmo. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getbaseplaceholder/) é verificada antes que a forma retornada seja usada.

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

## **Alterar o Tempo da Animação**

A caixa de diálogo **Timing** do PowerPoint corresponde aos métodos de [ITiming](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/).

![Caixa de diálogo Timing do PowerPoint para um efeito de animação](shape-animation.png)

- **Início** corresponde a [ITiming::set_TriggerType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duração** corresponde a [ITiming::set_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_duration/), em segundos.
- **Atraso** corresponde a [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), em segundos.
- **Repetir** corresponde a [ITiming::set_RepeatCount](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), ou [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rebobinar ao terminar a reprodução** corresponde a [ITiming::set_Rewind](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_rewind/).

Este exemplo independente adiciona um efeito, altera seu tempo através do objeto retornado por [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/), e salva o resultado. Manter a referência ao [IEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/) retornado evita um índice de coleção desnecessário.

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

Use intencionalmente um único modo de repetição. Combinar um contador de repetição com um sinalizador "until" pode gerar resultados confusos em diferentes visualizadores. Ao alterar os modos de repetição, chame [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) e [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) antes de [ITiming::set_RepeatCount](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/set_repeatcount/), pois definir qualquer um dos sinalizadores também altera o modo de repetição ativo.

## **Adicionar e Extrair Sons de Animação**

Um efeito de animação pode referenciar áudio incorporado através de [IEffect::set_Sound](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) indica que um efeito deve interromper o áudio iniciado por um efeito anterior.

### **Adicionar um Som a um Efeito**

O exemplo a seguir espera um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som para o primeiro efeito e configura o segundo efeito para interromper o som. Usa os objetos retornados por [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/), portanto nenhum índice de sequência é necessário.

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

### **Extrair Sons Incorporados de Efeitos**

O exemplo a seguir espera uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele varre as sequências principal e interativa e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [IAudio::get_ContentType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudio/get_contenttype/).

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

Para objetos de áudio grandes, use [IAudio::GetStream](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudio/getstream/) e copie o fluxo para um arquivo em vez de carregar todo o objeto em um array de bytes.

## **Definir o Comportamento Pós-Animação**

A opção **After animation** controla o que acontece com uma forma após a conclusão do seu efeito.

![Caixa de diálogo Opções de Efeito do PowerPoint mostrando configurações de After animation](shape-after-animation.png)

A enumeração [AfterAnimationType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/) oferece opções de deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo é [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/), chame [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) para definir a cor também.

Este exemplo independente cria um efeito, define seu comportamento pós-animação através do objeto de efeito retornado e salva o resultado.

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

Alterar o tipo de [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/) limpa a configuração de cor pós‑animação.

## **Animar Texto**

A animação de texto tem dois controles relacionados:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itextanimation/set_buildtype/) controla se os parágrafos aparecem juntos ou por nível de parágrafo.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) controla se o texto aparece tudo de uma vez, por palavra ou por letra. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType::AsOneObject](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/buildtype/) desativa a construção parágrafo a parágrafo para que a configuração de palavra se aplique a todo o quadro de texto.

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

Para construir uma caixa de texto por parágrafo, use [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itextanimation/set_buildtype/) com [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/buildtype/) ou outro nível de parágrafo. Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) que aceita um [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/). Veja [Animated Text](/slides/pt/cpp/animated-text/) para exemplos em nível de parágrafo.

## **Notas de Exportação e Compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.
- PDF e imagens estáticas não reproduzem animações. Use [HTML5 export](/slides/pt/cpp/export-to-html5/), GIF animado ou [video conversion](/slides/pt/cpp/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.
- Para HTML5, habilite [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animateshapes/) e, quando necessário, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- A renderização de vídeo oferece suporte a muitos efeitos comuns de entrada, ênfase, saída e caminhos de movimento, mas nem todo efeito do PowerPoint é suportado. Verifique as [supported animations and effects](/slides/pt/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) atuais e teste apresentações críticas com a versão do Aspose.Slides alvo.
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, mas são renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **Perguntas Frequentes**

**Por que uma animação aparece no PowerPoint mas não em um PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando o movimento precisar ser preservado.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza as animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Revise a tabela de efeitos suportados e teste a apresentação real antes do uso em produção.

**Mover uma forma para frente ou para trás altera a ordem da sua animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Altere a linha do tempo se precisar de uma ordem de reprodução diferente.