---
title: Obsługa ostrzeżeń prezentacji na Androidzie
type: docs
weight: 90
url: /pl/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Aspose.Slides może zgłaszać problemy możliwe do odzyskania podczas ładowania, renderowania, konwertowania lub zapisywania prezentacji. Przykłady obejmują uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawianie czcionek oraz ograniczenia docelowego formatu. Wywołanie zwrotne ostrzeżenia pozwala aplikacji rejestrować te warunki i decydować, czy bieżąca operacja może być kontynuowana.

Zaimplementuj interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarningcallback/) i sprawdź wartości [getWarningType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) oraz [getDescription](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) dostarczane za pośrednictwem [IWarningInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/). Zwróć [ReturnAction.Continue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/returnaction/#Continue), aby zaakceptować ostrzeżenie, lub [ReturnAction.Abort](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/returnaction/#Abort), aby zatrzymać operację.

Użyj [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) dla ostrzeżeń generowanych podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), które otrzymują ostrzeżenia z renderowania slajdów, konwersji i zapisu. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, skojarz każdą instancję wywołania zwrotnego z etapem operacji podczas budowania raportu zbiorczego.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje warunek, z którego Aspose.Slides może się odzyskać, jeśli wywołanie zwrotne zwróci `ReturnAction.Continue`. Wyjątek oznacza, że żądana operacja nie może zostać zakończona normalnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsłużone przez politykę ostrzeżeń.

Zwrócenie `ReturnAction.Abort` prosi dyspozytor ostrzeżeń o zakończenie bieżącej operacji poprzez podniesienie wyjątku. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład ładowanie może spowodować wystąpienie [PptxReadException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptreadexception/), podczas gdy zapisywanie lub eksport może spowodować [PptxException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxexception/). Obsłuż wyjątek na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać na jednym podtypie wyjątku lub komunikacie. Wywołanie zwrotne rejestruje ostrzeżenie przed zwróceniem `ReturnAction.Abort`, zapewniając, że przyczyna pozostaje dostępna dla aplikacji.

## **Kategorie ostrzeżeń**

Klasa [WarningType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/) udostępnia stałe całkowite dla następujących kategorii:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Prezentacja źródłowa zawiera uszkodzenia, które mogą uczynić dokument zapisany w oryginalnym formacie nieużytecznym. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#DataLoss) | Po załadowaniu lub zapisaniu może brakować tekstu, wykresów, obrazów lub innych danych. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Prezentacja może utracić istotne formatowanie. | Abort w trybie ścisłej walidacji; w innym wypadku rejestruj i kontynuuj. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Może wystąpić ograniczona różnica w formatowaniu. | Rejestruj do diagnostyki i kontynuuj. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Wynik może nie otworzyć się lub nie działać prawidłowo w niektórych aplikacjach lub starszych wersjach. | Loguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| [UnexpectedContent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Źródło zawiera nieobsługiwaną lub nierozpoznaną treść, której wpływ może nie być jeszcze znany. | Rejestruj i kontynuuj, lub traktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję polityki. Przechowuj wartość zwróconą przez [getDescription](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) w celach diagnostycznych, ale nie polegaj na jej brzmieniu w logice aplikacji, ponieważ tekst komunikatu może się różnić w zależności od scenariusza ostrzeżenia i wersji produktu.

## **Zbieranie i klasyfikowanie ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Osobna instancja wywołania zwrotnego oznacza ostrzeżenia pochodzące z ładowania, renderowania, konwersji do PDF i zapisu PPTX. Polityka przerywa działanie przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy poważnej utracie formatowania i kontynuuje przy pozostałych ostrzeżeniach.

Umieść `input.pptx` w zapisywalnym katalogu aplikacji i przekaż ten katalog do `PresentationWarningExample.run`. Przykład zapisuje swoje wyniki w tym samym katalogu. Uruchom przetwarzanie prezentacji w wątku tła, aby interfejs użytkownika Android pozostał responsywny.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Przy konstruowaniu `WarningPolicy` przekaż `false` dla `abortOnMajorFormattingLoss`, jeśli większe różnice w formatowaniu są akceptowalne. Problemy zgodności, drobna utrata formatowania oraz nieoczekiwana treść pozostają w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy.getAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawiać się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wywołać ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten warunek `DataLoss` za pośrednictwem [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Wywołanie zwrotne w fazie ładowania pozwala aplikacji odrzucić plik lub wyraźnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania slajdu lub eksportu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc powyższa ścisła polityka przerywa, nawet jeśli aplikacja uznałaby konkretną zamianę za wizualnie dopuszczalną. Aby zaobserwować to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w czasie wykonywania. Opis ostrzeżenia identyfikuje podstawienie; skonfiguruj wymagane czcionki lub [reguły podstawiania czcionek](/slides/pl/androidjava/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana treść:** Ładowarka może natrafić na rekordy prezentacji lub funkcje, których nie rozpoznaje. Tego typu ostrzeżenia mogą używać `UnexpectedContent` lub bardziej surowej kategorii, gdy wiadomo, że dane lub formatowanie zostają naruszone.
- **Kompatybilność formatów:** Zapis do innego formatu prezentacji może pominąć funkcje lub skutkować wynikiem zachowującym się inaczej w niektórych aplikacjach. Na przykład zapis prezentacji z ponad ośmioma poziomymi lub pionowymi prowadnicami rysunku do starszego PPT zgłasza `CompatibilityIssue`. Wywołanie zwrotne w fazie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli zachowanie wszystkich prowadnic jest wymagane.
- **Zachowanie podczas ładowania:** Opcje ładowania i zachowania legacy mogą także generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego zachowania blokowania prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie ani że scenariusz zawsze mapuje się na jedną kategorię.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy wywołanie zwrotne zwróci `ReturnAction.Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego pełnym zapisaniem.

Zapisz zwalidowane wyniki do osobnej ścieżki, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, gdy raport ostrzeżeń spełnia politykę aplikacji i wynik może zostać otwarty oraz sprawdzony. Zapobiega to nadpisaniu prawidłowego pliku źródłowego wynikiem częściowym lub odrzuconym.

Pusty raport ostrzeżeń nie gwarantuje, że każda cecha źródłowa została zachowana. Zastosuj dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Open Presentations](/slides/pl/androidjava/open-presentation/) i [Save Presentations](/slides/pl/androidjava/save-presentation/).

## **FAQ**

**Czy wywołanie zwrotne ostrzeżenia może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje warunki możliwe do odzyskania zgłaszane jako ostrzeżenia. Wyjątki, które występują niezależnie od wywołania zwrotnego, muszą być obsłużone przez aplikację wokół wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction.Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie kontynuować przetwarzanie. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, więc należy przeanalizować zebrane typy i opisy ostrzeżeń.

**Jak aplikacja może zidentyfikować operację, która wygenerowała ostrzeżenie?**

Utwórz osobną instancję wywołania zwrotnego dla każdej operacji i przechowuj definiowany przez aplikację etap razem z wartościami zwróconymi przez [getWarningType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) i [getDescription](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), jak pokazano w przykładzie.