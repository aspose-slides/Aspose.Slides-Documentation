---
title: Avbryt långvariga presentationsoperationer i C++
linktitle: Avbryt presentationsoperationer
type: docs
weight: 150
url: /sv/cpp/support-for-interruptable-library/
keywords:
- avbrottbara operationer
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du avbryter långvariga presentationsoperationer i Aspose.Slides för C++ och returnerar ett partiellt resultat när du exporterar bilder i en slinga."
---
## **Översikt**

Aspose.Slides för C++ kan avbryta långvariga operationer såsom inläsning, sparande och rendering av presentationer. Din applikation kan använda samma avbrottstoken för att stoppa en loop innan den börjar bearbeta nästa bild.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), hämta dess token med [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), skicka token till [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), och skicka inläsningsalternativen till [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). För att begära avbrytning, anropa [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) på källan. En avbrottbar operation stoppar när den observerar begäran.

Exemplet startar konverteringen av `sample.pptx` till `sample.ppt` i en bakgrundsuppgift och begär avbrytning om uppgiften fortfarande körs efter 10 sekunder. Om konverteringen slutförs tidigare är utskriften redan komplett.

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

## **Koppla applikationsavbrytning till Aspose.Slides**

Om din applikation använder en [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), använd [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) för att vidarebefordra avbrytningförfrågningar till [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Exemplet exporterar `sample.pptx` till `sample.pdf` i en bakgrundsuppgift. Om exporten fortfarande körs efter 20 sekunder, anropar applikationen [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), vilket utlöser den registrerade återanropet.

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

## **Stoppa innan nästa bild bearbetas**

Använd samma [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) för både presentationen och loopen som exporterar dess bilder. Kontrollera [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) innan varje export startas. Om anroparen kan använda ett partiellt resultat, returnera bildnumren för de exporter som slutförts framgångsrikt.

Använd en presentation med namnet `sample.pptx` som har minst två bilder. Exemplet begär avbrytning omedelbart efter att det registrerat den första lyckade exporten.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Loopen ser förfrågan innan den startar bild 2. Om avbrytning istället avbryter [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) under en export, lämnar `catch`‑blocket loopen innan koden registrerar den aktuella bilden som slutförd.

Om anroparen behöver hantera avbrytning, ersätt `if`‑kontrollen och dess `break` högst upp i loopen med ett anrop till [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) på token. Ta bort `try`/`catch`‑blocket kring exporten så att avbrytning under en sparning också når anroparen. Med samma indata skriver exemplet bara ut `Starting slide 1` och skriver `slide-1.pdf`. Vid början av den andra iterationen får anroparen ett [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) innan exporten påbörjas. Anroparen får ingen lista över slutförda bilder.

## **Vanliga frågor**

**När bör jag begära avbrytning?**

Begär avbrytning när en operation överskrider din tidsgräns eller när din applikation inte längre behöver resultatet.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Källan låter din applikation begära avbrytning. Token låter Aspose.Slides och din applikation kontrollera den begäran.

**Kan jag använda en [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) med Aspose.Slides?**

Ja. När din applikations token signalerar avbrytning, anropa [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) på den källa som är associerad med presentationen.

**Vilka operationer kan jag avbryta?**

Du kan avbryta inläsning, sparande och rendering. Skicka token till [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) via [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Presentationen kan sedan observera avbrytning under efterföljande operationer såsom [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Stannar en operation omedelbart?**

Avbrytning är samarbetsbaserad. En operation kontrollerar token periodiskt och stoppar när den observerar begäran.

**Vad händer om jag anropar [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) efter att en operation har avslutats?**

Den avslutade operationen behåller sitt resultat.

**Kan flera operationer dela en [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Ja. Att anropa [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.