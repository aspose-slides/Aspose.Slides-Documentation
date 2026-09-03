---
title: Obsługa ostrzeżeń prezentacji w .NET
type: docs
weight: 120
url: /pl/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides może zgłaszać naprawialne problemy podczas ładowania, renderowania, konwertowania lub zapisywania prezentacji. Przykłady to uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawianie czcionek oraz ograniczenia formatu docelowego. Callback ostrzeżeń pozwala aplikacji zapisać te warunki i zdecydować, czy bieżąca operacja może być kontynuowana.

Zaimplementuj interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iwarningcallback/) i sprawdź właściwości [WarningType](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iwarninginfo/warningtype/) oraz [Description](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iwarninginfo/description/), dostarczane przez [IWarningInfo](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iwarninginfo/). Zwróć [ReturnAction.Continue](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/returnaction/) aby zaakceptować ostrzeżenie, lub `ReturnAction.Abort`, aby zatrzymać operację.

Użyj [LoadOptions.WarningCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/warningcallback/) aby obsługiwać ostrzeżenia podnoszone podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą po [SaveOptions.WarningCallback](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/warningcallback/), które otrzymują ostrzeżenia z renderowania slajdów, konwersji i zapisu. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję callbacka z etapem operacji przy tworzeniu łącznego raportu.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje warunek, z którego Aspose.Slides może się odzyskać, jeśli callback zwróci `ReturnAction.Continue`. Wyjątek oznacza, że żądana operacja nie może zakończyć się pomyślnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsługiwane przez politykę ostrzeżeń.

Zwrócenie `ReturnAction.Abort` powoduje, że dispatcher ostrzeżeń kończy bieżącą operację, podnosząc wyjątek. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład podczas ładowania może pojawić się [PptxReadException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptreadexception/), natomiast przy zapisie lub eksporcie może pojawić się [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/). Obsłuż wyjątek na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać na jednym podtypie wyjątku lub komunikacie. Callback zapisuje ostrzeżenie przed zwróceniem `ReturnAction.Abort`, zapewniając, że przyczyna pozostaje dostępna dla aplikacji.

## **Kategorie ostrzeżeń**

Wyliczenie [WarningType](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/warningtype/) dostarcza następujące kategorie:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| `SourceFileCorruption` | Prezentacja źródłowa zawiera uszkodzenia, które mogą uczynić dokument zapisany w jego oryginalnym formacie nieużytecznym. | Przerwij. |
| `DataLoss` | Tekst, wykresy, obrazy lub inne dane mogą być nieobecne po załadowaniu lub zapisaniu. | Przerwij. |
| `MajorFormattingLoss` | Prezentacja może utracić istotne formatowanie. | Przerwij w trybie ścisłej weryfikacji; w przeciwnym razie rejestruj i kontynuuj. |
| `MinorFormattingLoss` | Może wystąpić ograniczona różnica w formatowaniu. | Zarejestruj do diagnostyki i kontynuuj. |
| `CompatibilityIssue` | Wynik może nie otworzyć się lub nie zachowywać prawidłowo w niektórych aplikacjach lub starszych wersjach. | Zaloguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| `UnexpectedContent` | Źródło zawiera nieobsługiwane lub nierozpoznane treści, których wpływ może nie być jeszcze znany. | Zarejestruj i kontynuuj, lub potraktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję polityki. Przechowuj `Description` do diagnostyki, ale nie polegaj na jej treści w logice aplikacji, ponieważ tekst komunikatu może się różnić w zależności od scenariusza ostrzeżenia i wersji produktu.

## **Zbieranie i klasyfikacja ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Oddzielna instancja callbacka oznacza ostrzeżenia pochodzące z ładowania, renderowania, konwersji PDF i zapisu PPTX. Polityka przerywa przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy dużej utracie formatowania i kontynuuje przy pozostałych ostrzeżeniach.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Ustaw `abortOnMajorFormattingLoss` na `false`, gdy duże różnice w formatowaniu są akceptowalne. Problemy z kompatybilnością, niewielka utrata formatowania i nieoczekiwana treść pozostają w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy.GetAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawiać się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wygenerować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten stan `DataLoss` poprzez [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback na etapie ładowania pozwala aplikacji odrzucić plik lub wyraźnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zamieniona podczas renderowania lub eksportu slajdu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc powyższa ścisła polityka przerywa operację, nawet jeśli aplikacja uznałaby konkretną zamianę za wizualnie dopuszczalną. Aby zaobserwować to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w czasie wykonywania. Opis ostrzeżenia wskazuje zamianę; skonfiguruj wymagane czcionki lub [zasady podstawiania czcionek](/slides/pl/net/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana zawartość:** Ładowarka może napotkać rekordy prezentacji lub funkcje, których nie rozpoznaje. Takie ostrzeżenia mogą używać `UnexpectedContent`, lub bardziej poważnej kategorii, gdy wiadomo, że dane lub formatowanie zostały dotknięte.
- **Kompatybilność formatów:** Zapis do innego formatu prezentacji może pominąć funkcje lub wygenerować wynik, który zachowuje się inaczej w niektórych aplikacjach. Na przykład zapis prezentacji zawierającej więcej niż osiem poziomych lub osiem pionowych linii prowadzących do starszego formatu PPT skutkuje `CompatibilityIssue`. Callback na etapie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli zachowanie wszystkich linii prowadzących jest wymagane.
- **Zachowanie przy ładowaniu:** Opcje ładowania i starsze zachowania mogą również generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego mechanizmu blokowania prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie lub że scenariusz zawsze odpowiada tylko jednej kategorii.

## **Bezpieczne obsługiwanie przerwanych operacji**

Kiedy callback zwróci `ReturnAction.Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego finalizacją.

Zapisz zwalidowane wyniki do osobnej ścieżki, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, gdy raport ostrzeżeń spełnia politykę aplikacji i wynik może być otwarty i sprawdzony. Dzięki temu unikniesz nadpisania prawidłowego pliku źródłowego częściowym lub odrzuconym wynikiem.

Pusty raport ostrzeżeń nie jest gwarancją, że każda cecha źródłowa została zachowana. Wykonaj dodatkowe kontrole zawartości i wizualne wymagane przez aplikację. Zobacz także [Otwieranie prezentacji](/slides/pl/net/open-presentation/) oraz [Zapisywanie prezentacji](/slides/pl/net/save-presentation/).

## **FAQ**

**Czy callback ostrzeżeń może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje on tylko naprawialne warunki zgłaszane jako ostrzeżenia. Wyjątki, które występują niezależnie od callbacka, muszą być obsłużone przez aplikację wokół wywołania ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction.Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie na kontynuację przetwarzania. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, dlatego należy przejrzeć zebrane typy ostrzeżeń i ich opisy.

**Jak aplikacja może zidentyfikować operację, która wywołała ostrzeżenie?**

Utwórz instancję callbacka dla każdej operacji i przechowuj etap zdefiniowany przez aplikację razem z `WarningType` oraz `Description`, jak pokazano w przykładzie.