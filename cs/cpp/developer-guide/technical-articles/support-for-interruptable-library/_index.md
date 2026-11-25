---
title: Přerušení dlouho běžících operací prezentace v C++
linktitle: Přerušení operací prezentace
type: docs
weight: 150
url: /cs/cpp/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak zrušit dlouho běžící operace prezentace v Aspose.Slides pro C++ a vrátit částečný výsledek při exportu snímků ve smyčce."
---
## **Přehled**

Aspose.Slides pro C++ může přerušit dlouho běžící operace, jako je načítání, ukládání a vykreslování prezentací. Vaše aplikace může použít stejný token přerušení k zastavení smyčky před tím, než začne zpracovávat další snímek.

## **Přerušit operaci prezentace**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), získejte jeho token pomocí [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), předávejte token do [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), a předávejte možnosti načítání do [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Pro požádání o zrušení zavolejte [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na zdroj. Přerušitelná operace se zastaví, když zaznamená požadavek.

Příklad zahajuje konverzi `sample.pptx` na `sample.ppt` v úloži pozadí a požaduje zrušení, pokud úloha stále běží po 10 sekundách. Pokud konverze skončí dříve, výstup je již kompletní.

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

## **Propojit zrušení aplikace s Aspose.Slides**

Pokud vaše aplikace používá [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), použijte [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/), abyste předali požadavky na zrušení do [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Příklad exportuje `sample.pptx` do `sample.pdf` v úloži pozadí. Pokud export stále běží po 20 sekundách, aplikace zavolá [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), což spustí registrovaný zpětné volání.

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

## **Zastavit před zpracováním dalšího snímku**

Použijte stejný [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) pro prezentaci i smyčku, která exportuje její snímky. Před zahájením každého exportu zkontrolujte [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/). Pokud volající může použít částečný výsledek, vraťte čísla snímků pro exporty, které byly úspěšně dokončeny.

Použijte prezentaci s názvem `sample.pptx` obsahující alespoň dva snímky. Příklad požádá o zrušení okamžitě po zaznamenání prvního úspěšného exportu.

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

Příklad zapíše `slide-1.pdf` a vytiskne `Starting slide 1` následované `Completed: [1]`. Smyčka zaznamená požadavek před tím, než začne snímek 2. Pokud zrušení místo toho přeruší [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) během exportu, blok `catch` ukončí smyčku dříve, než kód zaznamená aktuální snímek jako dokončený.

Pokud volající potřebuje zpracovat zrušení, nahraďte kontrolu `if` a její `break` na začátku smyčky voláním [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) na tokenu. Odstraňte blok `try`/`catch` kolem exportu, aby zrušení během ukládání také dosáhlo volajícího. Se stejným vstupem příklad vytiskne pouze `Starting slide 1` a zapíše `slide-1.pdf`. Na začátku druhé iterace volající obdrží [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) před zahájením exportu. Volající nedostane žádný seznam dokončených snímků.

## **FAQ**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když operace přesáhne váš časový limit nebo když vaše aplikace již výsledek nepotřebuje.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Zdroj umožňuje vaší aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i vaší aplikaci kontrolovat tento požadavek.

**Mohu použít [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) s Aspose.Slides?**

Ano. Když token vaší aplikace signalizuje zrušení, zavolejte [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na zdroj spojený s prezentací.

**Které operace mohu přerušit?**

Můžete přerušit načítání, ukládání a vykreslování. Předejte token do [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) pomocí [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Prezentace tak může sledovat zrušení během následných operací, jako je [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Zastaví se operace okamžitě?**

Zrušení je kooperativní. Operace periodicky kontroluje token a zastaví se, když zaznamená požadavek.

**Co se stane, když zavolám [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) po dokončení operace?**

Dokončená operace si zachová svůj výsledek.

**Mohou více operací sdílet [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Ano. Volání [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Pro každou operaci, kterou chcete rušit nezávisle, použijte samostatný zdroj.