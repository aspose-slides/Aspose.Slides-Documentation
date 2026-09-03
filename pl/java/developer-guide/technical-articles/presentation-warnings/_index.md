---
title: Obsługa ostrzeżeń prezentacji w Javie
type: docs
weight: 90
url: /pl/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- wywołanie zwrotne ostrzeżenia
- polityka ostrzeżeń
- utrata danych
- uszkodzenie źródła
- problem zgodności
- podstawianie czcionek
- podpis cyfrowy
- ładowanie prezentacji
- renderowanie prezentacji
- konwersja prezentacji
- zapisywanie prezentacji
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides może zgłaszać problemy, które można naprawić, podczas ładowania, renderowania, konwertowania lub zapisywania prezentacji. Przykłady to uszkodzone rekordy źródłowe, treść, której nie da się zachować, podstawianie czcionek oraz ograniczenia formatu docelowego. Mechanizm wywołania zwrotnego ostrzeżeń pozwala aplikacji zarejestrować te warunki i zdecydować, czy bieżąca operacja może być kontynuowana.

Zaimplementuj interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarningcallback/) i sprawdzaj wartości zwracane przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) oraz [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) w obiekcie [IWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/). Zwróć [ReturnAction.Continue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/returnaction/#Continue), aby zaakceptować ostrzeżenie, lub [ReturnAction.Abort](https://reference.aspose.com/slides/pl/java/com.aspose.slides/returnaction/#Abort), aby przerwać operację.

Użyj [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) dla ostrzeżeń pojawiających się podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), które odbierają ostrzeżenia z renderowania slajdów, konwersji i zapisu. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję wywołania zwrotnego z etapem operacji, gdy budujesz łączny raport.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje sytuację, z której Aspose.Slides może się odzyskać, jeśli wywołanie zwrotne zwróci `ReturnAction.Continue`. Wyjątek oznacza, że żądana operacja nie może zakończyć się normalnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsługiwane przez politykę ostrzeżeń.

Zwrócenie `ReturnAction.Abort` powoduje, że dyspozytor ostrzeżeń przerywa bieżącą operację, podnosząc wyjątk. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład ładowanie może zgłosić [PptxReadException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptreadexception/), natomiast zapisywanie lub eksportowanie może zgłosić [PptxException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxexception/). Obsłuż wyjątek na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać wyłącznie na podtypie wyjątku lub jego komunikacie. Wywołanie zwrotne rejestruje ostrzeżenie przed zwróceniem `ReturnAction.Abort`, zapewniając, że przyczyna pozostaje dostępna dla aplikacji.

## **Kategorie ostrzeżeń**

Klasa [WarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/) udostępnia stałe całkowite dla następujących kategorii:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Źródłowa prezentacja zawiera uszkodzenia, które mogą sprawić, że dokument zapisany w pierwotnym formacie będzie nieużyteczny. | Anuluj. |
| [DataLoss](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#DataLoss) | Po załadowaniu lub zapisaniu może brakować tekstu, wykresów, obrazów lub innych danych. | Anuluj. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Prezentacja może utracić istotne formatowanie. | Anuluj w trybie ścisłej walidacji; w przeciwnym razie rejestruj i kontynuuj. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Może wystąpić ograniczona różnica w formatowaniu. | Rejestruj do diagnostyki i kontynuuj. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Wynik może nie otworzyć się lub nie działać poprawnie w niektórych aplikacjach lub starszych wersjach. | Zaloguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| [UnexpectedContent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/warningtype/#UnexpectedContent) | Źródło zawiera nieobsługiwaną lub nierozpoznaną treść, której wpływ może być nieznany. | Rejestruj i kontynuuj, albo traktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję polityki. Przechowuj wartość zwróconą przez [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) do diagnostyki, ale nie opieraj logiki aplikacji na jej sformułowaniu, ponieważ tekst komunikatu może się różnić między scenariuszami ostrzeżeń i wersjami produktu.

## **Zbieranie i klasyfikowanie ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Oddzielne instancje wywołań zwrotnych oznaczają ostrzeżenia pochodzące z ładowania, renderowania, konwersji do PDF i zapisu PPTX. Polityka przerywa przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy poważnej utracie formatowania i kontynuuje w przypadku pozostałych ostrzeżeń.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Przekaż `false` dla `abortOnMajorFormattingLoss` przy tworzeniu `WarningPolicy`, jeśli duże różnice w formatowaniu są dopuszczalne. Problemy zgodności, drobna utrata formatowania i nieoczekiwana treść pozostają w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy.getAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawiać się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wygenerować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten stan `DataLoss` poprzez [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Wywołanie zwrotne na etapie ładowania pozwala aplikacji odrzucić plik lub wyraźnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania slajdu lub eksportu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc powyższa ścisła polityka przerywa, nawet jeśli aplikacja uznałaby konkretne zastąpienie za akceptowalne wizualnie. Aby zobaczyć to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w czasie wykonania. Opis ostrzeżenia wskazuje na podmianę; skonfiguruj wymagane czcionki lub [zasady podstawiania czcionek](/slides/pl/java/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana treść:** Ładowarka może napotkać rekordy prezentacji lub funkcje, których nie rozpoznaje. Tego typu ostrzeżenia mogą używać `UnexpectedContent` lub bardziej poważnej kategorii, gdy wiadomo, że dane lub formatowanie są zagrożone.
- **Zgodność formatu:** Zapis do innego formatu prezentacji może pominąć funkcje lub wygenerować wynik zachowujący się inaczej w niektórych aplikacjach. Przykładowo, zapis prezentacji z więcej niż ośmioma poziomymi lub pionowymi prowadnicami rysunkowymi do starszego PPT zgłasza `CompatibilityIssue`. Wywołanie zwrotne na etapie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli zachowanie wszystkich prowadnic jest wymagane.
- **Zachowanie podczas ładowania:** Opcje ładowania i starsze zachowania mogą także generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego mechanizmu blokowania prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie ani że scenariusz zawsze mapuje się na jedną kategorię.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy wywołanie zwrotne zwróci `ReturnAction.Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wyjście renderowania lub zapisu jest kompletne. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego pełnym zapisaniem.

Zapisz zwalidowane wyniki w osobnej ścieżce, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, gdy raport ostrzeżeń spełnia politykę aplikacji i wynik może być otwarty i sprawdzony. Zapobiega to nadpisaniu prawidłowego pliku źródłowego częściowym lub odrzuconym rezultatem.

Pusty raport ostrzeżeń nie jest gwarancją, że każda funkcja źródłowa została zachowana. Wykonaj dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Open Presentations](/slides/pl/java/open-presentation/) oraz [Save Presentations](/slides/pl/java/save-presentation/).

## **FAQ**

**Czy callback ostrzeżeń może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje on jedynie warunki odzyskiwalne zgłaszane jako ostrzeżenia. Wyjątki występujące niezależnie od wywołania zwrotnego muszą być obsłużone przez aplikację wokół wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction.Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie kontynuować przetwarzanie. Zgłoszona sytuacja może nadal powodować różnice w danych, formatowaniu lub zgodności, dlatego należy przeanalizować zebrane typy ostrzeżeń i ich opisy.

**Jak aplikacja może zidentyfikować operację, która wygenerowała ostrzeżenie?**

Utwórz osobną instancję wywołania zwrotnego dla każdej operacji i przechowuj etap określony przez aplikację razem z wartościami zwróconymi przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) i [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--), jak pokazano w przykładzie.