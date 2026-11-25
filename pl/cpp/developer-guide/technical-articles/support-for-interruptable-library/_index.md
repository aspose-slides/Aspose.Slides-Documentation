---
title: Przerwanie długotrwałych operacji prezentacji w C++
linktitle: Przerwanie operacji prezentacji
type: docs
weight: 150
url: /pl/cpp/support-for-interruptable-library/
keywords:
- operacje podlegające przerwaniu
- token przerwania
- token anulowania
- zadanie długotrwałe
- przerwać zadanie
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak anulować długotrwałe operacje prezentacji w Aspose.Slides dla C++ i zwrócić częściowy wynik podczas eksportowania slajdów w pętli."
---
## **Przegląd**

Aspose.Slides for C++ może przerywać długotrwałe operacje, takie jak ładowanie, zapisywanie i renderowanie prezentacji. Twoja aplikacja może używać tego samego tokenu przerwania, aby zatrzymać pętlę przed rozpoczęciem przetwarzania kolejnego slajdu.

## **Przerwij operację prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), pobierz jego token przy pomocy [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), przekaż token do [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), a opcje ładowania przekaż do [konstruktor Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Aby zgłosić anulowanie, wywołaj [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na źródle. Operacja, którą można przerwać, zatrzymuje się, gdy wykryje żądanie.

Przykład rozpoczyna konwersję `sample.pptx` do `sample.ppt` w zadaniu w tle i żąda anulowania, jeśli zadanie nadal działa po 10 sekundach. Jeśli konwersja zakończy się wcześniej, wynik jest już gotowy.

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

## **Połącz anulowanie aplikacji z Aspose.Slides**

Jeśli Twoja aplikacja używa [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), użyj [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/), aby przekazać żądania anulowania do [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Przykład eksportuje `sample.pptx` do `sample.pdf` w zadaniu w tle. Jeśli eksport nadal działa po 20 sekundach, aplikacja wywołuje [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), co uruchamia zarejestrowane wywołanie zwrotne.

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

## **Zatrzymaj przed przetworzeniem następnego slajdu**

Użyj tego samego [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) zarówno dla prezentacji, jak i dla pętli eksportującej jej slajdy. Sprawdź [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) przed rozpoczęciem każdego eksportu. Jeśli wywołujący może skorzystać z częściowego wyniku, zwróć numery slajdów, które zostały pomyślnie wyeksportowane.

Użyj prezentacji o nazwie `sample.pptx` zawierającej co najmniej dwa slajdy. Przykład żąda anulowania natychmiast po zapisaniu pierwszego udanego eksportu.

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

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, a następnie `Completed: [1]`. Pętla zauważa żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie zamiast tego przerwie [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) podczas eksportu, blok `catch` wychodzi z pętli przed zapisaniem aktualnego slajdu jako ukończonego.

Jeśli wywołujący musi obsłużyć anulowanie, zamień sprawdzenie `if` i jego `break` na początku pętli na wywołanie [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) na tokenie. Usuń blok `try`/`catch` wokół eksportu, aby anulowanie podczas zapisu również docierało do wywołującego. Przy tym samym wejściu przykład wypisuje jedynie `Starting slide 1` i zapisuje `slide-1.pdf`. Na początku drugiej iteracji wywołujący otrzymuje [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) zanim rozpocznie się eksport. Wywołujący nie otrzymuje listy zakończonych slajdów.

## **FAQ**

**Kiedy powinienem zgłosić anulowanie?**

Zgłoś anulowanie, gdy operacja przekracza Twój limit czasu lub gdy aplikacja już nie potrzebuje wyniku.

**Jaka jest różnica pomiędzy [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Źródło pozwala Twojej aplikacji żądać anulowania. Token umożliwia Aspose.Slides oraz Twojej aplikacji sprawdzenie tego żądania.

**Czy mogę używać [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) z Aspose.Slides?**

Tak. Gdy token Twojej aplikacji sygnalizuje anulowanie, wywołaj [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) na źródle powiązanym z prezentacją.

**Jakie operacje mogę przerwać?**

Możesz przerwać ładowanie, zapisywanie i renderowanie. Przekaż token do [konstruktor Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) za pomocą [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Prezentacja będzie wtedy mogła wykrywać anulowanie podczas kolejnych operacji, takich jak [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Czy operacja zatrzymuje się natychmiast?**

Anulowanie jest współpracujące. Operacja okresowo sprawdza token i zatrzymuje się, gdy wykryje żądanie.

**Co się stanie, jeśli wywołam [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) po zakończeniu operacji?**

Zakończona operacja zachowuje swój wynik.

**Czy wiele operacji może współdzielić [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Tak. Wywołanie [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) żąda anulowania dla każdej operacji korzystającej z tokenu z tego źródła. Użyj osobnego źródła dla każdej operacji, którą chcesz anulować niezależnie.