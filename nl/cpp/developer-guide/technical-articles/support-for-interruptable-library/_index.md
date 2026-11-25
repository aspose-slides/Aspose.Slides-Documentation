---
title: Onderbreek langlopende presentatiebewerkingen in C++
linktitle: Onderbreek presentatiebewerkingen
type: docs
weight: 150
url: /nl/cpp/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annuleringstoken
- langlopende taak
- onderbreekbare taak
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u langlopende presentatiebewerkingen in Aspose.Slides voor C++ kunt annuleren en een gedeeltelijk resultaat kunt retourneren bij het exporteren van dia's in een lus."
---
## **Overzicht**

Aspose.Slides voor C++ kan lange bewerkingen zoals het laden, opslaan en renderen van presentaties onderbreken. Uw toepassing kan dezelfde interruption‑token gebruiken om een lus te stoppen voordat deze de volgende dia verwerkt.

## **Onderbreek een presentatie‑operatie**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), haal zijn token op met [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), geef het token door aan [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), en geef de laadopties door aan de [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Om annulering aan te vragen, roep [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) aan op de bron. Een onderbreekbare bewerking stopt wanneer deze het verzoek opmerkt.

Het voorbeeld start met het converteren van `sample.pptx` naar `sample.ppt` in een achtergrondtaak en vraagt om annulering als de taak na 10 seconden nog steeds loopt. Als de conversie eerder voltooid is, is de uitvoer al compleet.

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

## **Koppel applicatie‑annulering aan Aspose.Slides**

Als uw toepassing een [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) gebruikt, gebruik dan [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) om annuleringsverzoeken door te sturen naar [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Het voorbeeld exporteert `sample.pptx` naar `sample.pdf` in een achtergrondtaak. Als de export na 20 seconden nog steeds loopt, roept de toepassing [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) aan, waardoor de geregistreerde callback wordt uitgevoerd.

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

## **Stop voordat de volgende dia wordt verwerkt**

Gebruik dezelfde [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) voor zowel de presentatie als de lus die de dia's exporteert. Controleer [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) voordat u elke export start. Als de aanroeper een gedeeltelijk resultaat kan gebruiken, geef dan de dianummers terug van de export die succesvol voltooid is.

Gebruik een presentatie met de naam `sample.pptx` met ten minste twee dia's. Het voorbeeld vraagt om annulering direct nadat het de eerste succesvolle export heeft geregistreerd.

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

Het voorbeeld schrijft `slide-1.pdf` en print `Starting slide 1` gevolgd door `Completed: [1]`. De lus ziet het verzoek voordat hij dia 2 start. Als annulering in plaats daarvan [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) onderbreekt tijdens een export, verlaat het `catch`‑blok de lus voordat de code de huidige dia als voltooid registreert.

Als de aanroeper annulering moet afhandelen, vervangt u de `if`‑controle en de bijbehorende `break` aan het begin van de lus door een oproep naar [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) op het token. Verwijder de `try`/`catch`‑blokken rond de export zodat annulering tijdens een opslaan ook bij de aanroeper terechtkomt. Met dezelfde invoer print het voorbeeld alleen `Starting slide 1` en schrijft `slide-1.pdf`. Aan het begin van de tweede iteratie ontvangt de aanroeper een [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) voordat de export start. De aanroeper ontvangt geen lijst van voltooide dia's.

## **FAQ**

**Wanneer moet ik annulering aanvragen?**

Vraag om annulering wanneer een bewerking uw tijdslimiet overschrijdt of wanneer uw toepassing het resultaat niet meer nodig heeft.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

De bron stelt uw toepassing in staat om annulering aan te vragen. Het token laat Aspose.Slides en uw toepassing controleren op dat verzoek.

**Kan ik een [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) gebruiken met Aspose.Slides?**

Ja. Wanneer het token van uw toepassing annulering signaleert, roept u [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) aan op de bron die bij de presentatie hoort.

**Welke bewerkingen kan ik onderbreken?**

U kunt het laden, opslaan en renderen onderbreken. Geef het token door aan de [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) via [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). De presentatie kan vervolgens annulering waarnemen tijdens latere bewerkingen zoals [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Stopt een bewerking onmiddellijk?**

Annulering gebeurt coöperatief. Een bewerking controleert periodiek het token en stopt wanneer het het verzoek opmerkt.

**Wat gebeurt er als ik [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) aanroep nadat een bewerking is voltooid?**

De voltooide bewerking behoudt zijn resultaat.

**Kunnen meerdere bewerkingen eenzelfde [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) delen?**

Ja. Het aanroepen van [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) vraagt annulering aan voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt annuleren.