---
title: Obsługa ostrzeżeń w prezentacjach w C++
type: docs
weight: 70
url: /pl/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback ostrzeżeń
- polityka ostrzeżeń
- utrata danych
- uszkodzenie źródła
- problem kompatybilności
- podstawianie czcionek
- podpis cyfrowy
- ładowanie prezentacji
- renderowanie prezentacji
- konwersja prezentacji
- zapisywanie prezentacji
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides może zgłaszać problemy możliwe do odzyskania podczas ładowania, renderowania, konwersji lub zapisywania prezentacji. Przykłady obejmują uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawienie czcionki oraz ograniczenia docelowego formatu. Callback ostrzeżeń pozwala aplikacji zarejestrować te warunki i zdecydować, czy bieżąca operacja może być kontynuowana.

Zaimplementuj interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iwarningcallback/) i sprawdź metody [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) oraz [IWarningInfo::get_Description](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iwarninginfo/get_description/) dostarczane przez [IWarningInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iwarninginfo/). Zwróć [ReturnAction::Continue](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/returnaction/), aby zaakceptować ostrzeżenie lub `ReturnAction::Abort`, aby zatrzymać operację.

Użyj [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_warningcallback/) do obsługi ostrzeżeń generowanych podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_warningcallback/), które otrzymują ostrzeżenia z renderowania slajdów, konwersji i zapisywania. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję callbacku z etapem operacji przy tworzeniu scentralizowanego raportu.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje warunek, z którego Aspose.Slides może się odzyskać, jeśli callback zwróci `ReturnAction::Continue`. Wyjątek oznacza, że żądana operacja nie może zostać zakończona normalnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsługiwane przez politykę ostrzeżeń.

Zwrócenie `ReturnAction::Abort` prosi dyspozytor ostrzeżeń o zakończenie bieżącej operacji poprzez podniesienie wyjątku. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład podczas ładowania może wystąpić [PptxReadException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptreadexception/), natomiast przy zapisywaniu lub eksportowaniu może pojawić się [PptxException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxexception/). Obsłuż wyjątk w granicach operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać na jednym podtypie wyjątku lub komunikacie. Callback rejestruje ostrzeżenie przed zwróceniem `ReturnAction::Abort`, zapewniając, że przyczyna pozostaje dostępna dla aplikacji.

## **Kategorie ostrzeżeń**

Wyliczenie [WarningType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/warningtype/) zawiera następujące kategorie:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| `SourceFileCorruption` | Źródłowa prezentacja zawiera uszkodzenia, które mogą uniemożliwić użycie dokumentu zapisanego w jego oryginalnym formacie. | Przerwij. |
| `DataLoss` | Tekst, wykresy, obrazy lub inne dane mogą być nieobecne po załadowaniu lub zapisaniu. | Przerwij. |
| `MajorFormattingLoss` | Prezentacja może utracić ważne formatowanie. | Przerwij w trybie ścisłej walidacji; w przeciwnym razie zarejestruj i kontynuuj. |
| `MinorFormattingLoss` | Może wystąpić ograniczona różnica w formatowaniu. | Zarejestruj do diagnostyki i kontynuuj. |
| `CompatibilityIssue` | Wynik może nie otworzyć się lub nie zachowywać prawidłowo w niektórych aplikacjach lub starszych wersjach. | Zaloguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| `UnexpectedContent` | Źródło zawiera nieobsługiwaną lub nierozpoznaną zawartość, której wpływ może nie być jeszcze znany. | Zarejestruj i kontynuuj, lub potraktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję o polityce. Przechowuj opis ostrzeżenia do diagnostyki, ale nie polegaj na jego treści w logice aplikacji, ponieważ tekst komunikatu może różnić się w zależności od scenariuszy ostrzeżeń i wersji produktu.

## **Zbieranie i klasyfikacja ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Oddzielna instancja callbacku oznacza ostrzeżenia z ładowania, renderowania, konwersji PDF i zapisu PPTX. Polityka przerywa działanie przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy dużej utracie formatowania i kontynuuje dla pozostałych ostrzeżeń.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Ustaw `abortOnMajorFormattingLoss` na `false`, gdy duże różnice w formatowaniu są akceptowalne. Problemy kompatybilności, mała utrata formatowania i nieoczekiwana zawartość są nadal zachowywane w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy::GetAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą wystąpić na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wygenerować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten warunek `DataLoss` za pośrednictwem [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback na etapie ładowania pozwala aplikacji odrzucić plik lub jawnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania lub eksportowania slajdu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc powyższa ścisła polityka przerywa działanie, nawet jeśli aplikacja uznałaby konkretne zastąpienie za wizualnie dopuszczalne. Aby zaobserwować to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w środowisku uruchomieniowym. Opis ostrzeżenia identyfikuje podstawienie; skonfiguruj wymagane czcionki lub [zasady podstawiania czcionek](/slides/pl/cpp/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana zawartość:** Ładowarka może napotkać rekordy prezentacji lub funkcje, których nie rozpoznaje. Takie ostrzeżenia mogą używać `UnexpectedContent` lub bardziej poważnej kategorii, gdy wiadomo, że dane lub formatowanie są zagrożone.
- **Kompatybilność formatu:** Zapisywanie w innym formacie prezentacji może pominąć funkcje lub wyprodukować wynik, który zachowuje się inaczej w niektórych aplikacjach. Na przykład zapisanie prezentacji z więcej niż ośmioma poziomymi lub ośmioma pionowymi prowadnicami rysunku do starszego formatu PPT zgłasza `CompatibilityIssue`. Callback na etapie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli zachowanie wszystkich prowadnic jest wymagane.
- **Zachowanie ładowania:** Opcje ładowania i starsze zachowania mogą również generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego zachowania blokowania prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji oraz wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie ani że scenariusz zawsze odpowiada jednej kategorii.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy callback zwróci `ReturnAction::Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego pełnym zakończeniem.

Zapisz zwalidowane wyniki w osobnej ścieżce, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, gdy raport ostrzeżeń spełnia politykę aplikacji i wynik może być otwarty i sprawdzony. Zapobiega to nadpisaniu prawidłowego pliku źródłowego wynikiem częściowym lub odrzuconym.

Pusty raport ostrzeżeń nie jest gwarancją, że każda funkcja źródła została zachowana. Zastosuj dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Otwieranie prezentacji](/slides/pl/cpp/open-presentation/) i [Zapisywanie prezentacji](/slides/pl/cpp/save-presentation/).

## **FAQ**

**Czy callback ostrzeżeń może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje on warunki możliwe do odzyskania zgłaszane jako ostrzeżenia. Wyjątki, które występują niezależnie od callbacku, muszą być obsłużone przez aplikację wokół wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction::Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie na kontynuację przetwarzania. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, dlatego należy przejrzeć zebrane typy ostrzeżeń i ich opisy.

**Jak aplikacja może zidentyfikować operację, która wygenerowała ostrzeżenie?**

Utwórz instancję callbacku dla każdej operacji i przechowuj etap zdefiniowany przez aplikację wraz z typem ostrzeżenia i opisem, jak pokazano w przykładzie.