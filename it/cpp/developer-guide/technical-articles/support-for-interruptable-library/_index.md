---
title: Interrompere le operazioni di presentazione a lunga esecuzione in C++
linktitle: Interrompere le operazioni di presentazione
type: docs
weight: 150
url: /it/cpp/support-for-interruptable-library/
keywords:
- operazioni interrompibili
- token di interruzione
- token di cancellazione
- attività a lunga esecuzione
- interrompere attività
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come annullare le operazioni di presentazione a lunga esecuzione in Aspose.Slides per C++ e restituire un risultato parziale durante l'esportazione delle diapositive in un ciclo."
---
## **Panoramica**

Aspose.Slides for C++ può interrompere operazioni a lunga esecuzione come il caricamento, il salvataggio e il rendering delle presentazioni. La tua applicazione può utilizzare lo stesso token di interruzione per fermare un ciclo prima che inizi a elaborare la diapositiva successiva.

## **Interrompere un'operazione di presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), recupera il suo token con [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), passa il token a [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), e passa le opzioni di caricamento al [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Per richiedere la cancellazione, chiama [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sulla sorgente. Un'operazione interrompibile si arresta quando osserva la richiesta.

L'esempio avvia la conversione di `sample.pptx` in `sample.ppt` in un'attività in background e richiede la cancellazione se l'attività è ancora in esecuzione dopo 10 secondi. Se la conversione termina prima, l'output è già completo.

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

## **Collegare la cancellazione dell'applicazione a Aspose.Slides**

Se la tua applicazione utilizza un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), usa [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) per inoltrare le richieste di cancellazione a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). L'esempio esporta `sample.pptx` in `sample.pdf` in un'attività in background. Se l'esportazione è ancora in esecuzione dopo 20 secondi, l'applicazione chiama [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), che invoca il callback registrato.

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

## **Interrompere prima di elaborare la diapositiva successiva**

Utilizza lo stesso [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) sia per la presentazione sia per il ciclo che esporta le sue diapositive. Controlla [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) prima di avviare ogni esportazione. Se il chiamante può utilizzare un risultato parziale, restituisci i numeri delle diapositive per le esportazioni completate con successo.

Usa una presentazione denominata `sample.pptx` con almeno due diapositive. L'esempio richiede la cancellazione immediatamente dopo aver registrato la prima esportazione riuscita.

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

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo vede la richiesta prima di avviare la diapositiva 2. Se la cancellazione interrompe invece [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) durante un'esportazione, il blocco `catch` esce dal ciclo prima che il codice registri la diapositiva corrente come completata.

Se il chiamante deve gestire la cancellazione, sostituisci il controllo `if` e il suo `break` all'inizio del ciclo con una chiamata a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) sul token. Rimuovi il blocco `try`/`catch` attorno all'esportazione in modo che la cancellazione durante un salvataggio raggiunga anche il chiamante. Con gli stessi input, l'esempio stampa solo `Starting slide 1` e scrive `slide-1.pdf`. All'inizio della seconda iterazione, il chiamante riceve un [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) prima che l'esportazione inizi. Il chiamante non riceve alcun elenco di diapositive completate.

## **FAQ**

**Quando dovrei richiedere la cancellazione?**

Richiedi la cancellazione quando un'operazione supera il limite di tempo o quando la tua applicazione non ha più bisogno del risultato.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

La sorgente consente alla tua applicazione di richiedere la cancellazione. Il token consente ad Aspose.Slides e alla tua applicazione di verificare tale richiesta.

**Posso utilizzare un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) con Aspose.Slides?**

Sì. Quando il token della tua applicazione segnala la cancellazione, chiama [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sulla sorgente associata alla presentazione.

**Quali operazioni posso interrompere?**

Puoi interrompere il caricamento, il salvataggio e il rendering. Passa il token al [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) tramite [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). La presentazione può quindi osservare la cancellazione durante operazioni successive come [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Un'operazione si interrompe immediatamente?**

La cancellazione è cooperativa. Un'operazione controlla periodicamente il token e si interrompe quando osserva la richiesta.

**Cosa succede se chiamo [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) dopo che un'operazione è terminata?**

L'operazione completata mantiene il suo risultato.

**Possono più operazioni condividere un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Sì. Chiamare [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) richiede la cancellazione per ogni operazione che utilizza un token di quella sorgente. Usa una sorgente separata per ogni operazione che desideri annullare in modo indipendente.