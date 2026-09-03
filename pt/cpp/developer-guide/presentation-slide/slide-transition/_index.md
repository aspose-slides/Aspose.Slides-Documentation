---
title: Gerenciar Transições de Slide em Apresentações Usando C++
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/cpp/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição de slide avançada
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aplique transições de slide, configure o avanço automático de slides e personalize Morph e outros efeitos de transição com Aspose.Slides para C++."
---
## **Visão geral**

As transições de slides controlam como os slides aparecem durante uma apresentação. Com Aspose.Slides para C++, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou temporizador e ajustar opções específicas de um efeito. Este artigo usa exemplos em C++ para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar Transição de Slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e acesse as configurações de transição de um slide através de [get_SlideShowTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Chame [set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_type/) com um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitiontype/), então salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Adicionar Transição de Slide Avançada**

Você pode configurar quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. Os métodos a seguir controlam esse comportamento:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) permite que o visualizador avance clicando o mouse.
- [set_AdvanceAfter](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ativa o avanço automático.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto o cronometrado para permitir que o visualizador avance com um clique ou aguarde o temporizador. Para usar somente o temporizador, chame [set_AdvanceOnClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) com `false`. O atraso controla quando a apresentação avança; ele não define a duração do efeito visual da transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Para verificar se o avanço cronometrado está habilitado, chame [get_AdvanceAfter](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Um atraso armazenado sozinho não indica que o temporizador está ativo.

O próximo exemplo abre o arquivo salvo acima, relata cada temporizador habilitado e desabilita o avanço automático para slides com atraso maior que dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Controlar o Tempo da Transição com Precisão**

Use [set_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_duration/) para especificar o comprimento exato de um efeito de transição em milissegundos. O método [get_SlideShowTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) do slide expõe essas configurações através de [ISlideShowTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/):

| Método | Propósito |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_duration/) | Define a duração do próprio efeito de transição, em milissegundos. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Chame [set_AdvanceAfter](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_advanceafter/) com `true` para ativar esse temporizador. |
| [set_Speed](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_speed/) | Seleciona uma categoria de velocidade predefinida da enumeração [TransitionSpeed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ou Fast. É usada quando uma duração exata não é especificada. |

[set_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_duration/) controla somente o efeito de transição; não determina quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, Aspose.Slides determina a duração do efeito com base no tipo de transição e no valor devolvido por [get_Speed](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Aplicar a Mesma Duração a Cada Slide**

Para um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a todos os slides. Este exemplo carrega `input.pptx`, seleciona Fade da [TransitionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitiontype/), e atribui a cada transição uma duração de 750 milissegundos. Ele habilita separadamente o avanço automático após 5 000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Configure o avanço automático independentemente da duração do efeito.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Definir Durações Diferentes para Slides Individuais**

Slides diferentes podem usar durações de efeito distintas. Por exemplo, use uma transição breve para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1 200 milissegundos para o segundo. Use um arquivo `input.pptx` com ao menos dois slides.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Coordinar Transições com Saída Animada**

Ao preparar um [animated GIF](/slides/pt/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pt/cpp/export-to-html5/) ou [video](/slides/pt/cpp/convert-powerpoint-to-video/), defina durações de transição exatas antes da exportação para corresponder ao ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste o atraso de avanço de cada slide separadamente para permitir tempo para sua narração ou conteúdo.

Para GIF e vídeo, sincronize a taxa de quadros de saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. No HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de tempo suportados pelo formato de exportação escolhido e pré-visualize a saída para confirmar a sincronização.

### **Ler a Duração de uma Transição Existente**

Chame [get_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_duration/) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor `-1` indica que nenhuma duração explícita foi definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração de reprodução calculada: Aspose.Slides usa o tipo de transição e o valor devolvido por [get_Speed](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_speed/) para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto inspecione as configurações originais primeiro.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Transição Morph**

A transição Morph anima mudanças entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece aos objetos correspondentes a animação entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Tipos de Transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionmorphtype/) controla como o Morph combina e anima o conteúdo:

- [ByObject](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como um objeto completo.
- [ByWord](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionmorphtype/) anima o texto correspondendo palavras quando possível.
- [ByChar](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionmorphtype/) anima o texto correspondendo caracteres quando possível.

Chame [set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_type/) com Morph antes de acessar [get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_value/). O valor então fornece a interface [IMorphTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/imorphtransition/), cujo método [set_MorphType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Definir Efeitos de Transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito começa a partir de uma tela preta. As opções disponíveis dependem do tipo de transição selecionado. Defina o tipo primeiro, depois use a interface apropriada devolvida por [get_Value](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_value/).

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele chama [set_FromBlack](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) com `true` através de [IOptionalBlackTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/ioptionalblacktransition/) para que a transição comece a partir de uma tela preta.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Prefer [set_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_duration/) when you need an exact effect duration in milliseconds. Use [set_Speed](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_speed/) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Can I attach audio to a transition and make it loop?**

Yes. Assign embedded audio with [set_Sound](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_sound/), call [set_SoundMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_soundmode/) with StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitionsoundmode/) enumeration, and enable looping with [set_SoundLoop](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_soundloop/). The audio loops until the next sound event in the slide show.

**What's the fastest way to apply the same transition to every slide?**

Loop through the collection returned by the presentation's [get_Slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slides/) method and call [set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/set_type/) with the same value for each slide's transition. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**How can I check which transition is currently set on a slide?**

Call [get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideshowtransition/get_type/) on the transition returned by the slide's [get_SlideShowTransition](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) method. It returns a value from the [TransitionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/transitiontype/) enumeration; None means that no transition effect is applied.