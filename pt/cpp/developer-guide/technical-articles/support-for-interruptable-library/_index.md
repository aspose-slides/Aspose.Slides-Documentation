---
title: Interromper Operações de Apresentação de Longa Duração em C++
linktitle: Interromper Operações de Apresentação
type: docs
weight: 150
url: /pt/cpp/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- tarefa de interrupção
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Saiba como cancelar operações de apresentação de longa duração no Aspose.Slides for C++ e retornar um resultado parcial ao exportar slides em um loop."
---
## **Visão geral**

Aspose.Slides for C++ pode interromper operações de longa duração, como carregamento, salvamento e renderização de apresentações. Seu aplicativo pode usar o mesmo token de interrupção para parar um loop antes de ele começar a processar o próximo slide.

## **Interromper uma operação de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), recupere seu token com [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), passe o token para [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), e passe as opções de carregamento ao [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Para solicitar o cancelamento, chame [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na fonte. Uma operação interrompível para quando observa a solicitação.

O exemplo inicia a conversão de `sample.pptx` para `sample.ppt` em uma tarefa em segundo plano e solicita cancelamento se a tarefa ainda estiver em execução após 10 segundos. Se a conversão terminar antes, a saída já está completa.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Conectar o cancelamento da aplicação ao Aspose.Slides**

Se seu aplicativo usa um [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), use [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) para encaminhar solicitações de cancelamento para [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). O exemplo exporta `sample.pptx` para `sample.pdf` em uma tarefa em segundo plano. Se a exportação ainda estiver em execução após 20 segundos, o aplicativo chama [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), que invoca o callback registrado.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Parar antes de processar o próximo slide**

Use o mesmo [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) tanto para a apresentação quanto para o loop que exporta seus slides. Verifique [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) antes de iniciar cada exportação. Se o chamador puder usar um resultado parcial, retorne os números dos slides cujas exportações foram concluídas com sucesso.

Use uma apresentação chamada `sample.pptx` com pelo menos dois slides. O exemplo solicita cancelamento imediatamente após registrar a primeira exportação bem‑sucedida.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

O exemplo grava `slide-1.pdf` e exibe `Starting slide 1` seguida de `Completed: [1]`. O loop vê a solicitação antes de iniciar o slide 2. Se o cancelamento em vez disso interromper [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) durante uma exportação, o bloco `catch` sai do loop antes que o código registre o slide atual como concluído.

Se o chamador precisar tratar o cancelamento, substitua a verificação `if` e seu `break` no início do loop por uma chamada a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) no token. Remova o bloco `try`/`catch` ao redor da exportação para que o cancelamento durante um salvamento também chegue ao chamador. Com a mesma entrada, o exemplo exibe apenas `Starting slide 1` e grava `slide-1.pdf`. No início da segunda iteração, o chamador recebe um [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) antes que a exportação inicie. O chamador não recebe nenhuma lista de slides concluídos.

## **FAQ**

**Quando devo solicitar cancelamento?**

Solicite cancelamento quando uma operação exceder seu limite de tempo ou quando sua aplicação não precisar mais do resultado.

**Qual é a diferença entre [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

A fonte permite que sua aplicação solicite cancelamento. O token permite que Aspose.Slides e sua aplicação verifiquem essa solicitação.

**Posso usar um [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) com Aspose.Slides?**

Sim. Quando o token da sua aplicação sinaliza cancelamento, chame [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na fonte associada à apresentação.

**Quais operações posso interromper?**

Você pode interromper carregamento, salvamento e renderização. Passe o token ao [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) através de [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). A apresentação pode então observar o cancelamento durante operações subsequentes, como [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**A operação para imediatamente?**

O cancelamento é cooperativo. Uma operação verifica o token periodicamente e para quando observa a solicitação.

**O que acontece se eu chamar [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) após uma operação terminar?**

A operação concluída mantém seu resultado.

**Várias operações podem compartilhar um [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Sim. Chamar [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) solicita cancelamento para toda operação que usar um token daquela fonte. Use uma fonte separada para cada operação que você deseja cancelar independentemente.