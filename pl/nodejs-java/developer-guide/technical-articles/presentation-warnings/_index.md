---
title: Obsługa ostrzeżeń prezentacji w Node.js
type: docs
weight: 90
url: /pl/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback ostrzeżeń
- polityka ostrzeżeń
- utrata danych
- uszkodzenie źródła
- problem z kompatybilnością
- podstawianie czcionek
- podpis cyfrowy
- ładowanie prezentacji
- renderowanie prezentacji
- konwersja prezentacji
- zapisywanie prezentacji
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla Node.js za pośrednictwem Javy."
---
## **Przegląd**

Aspose.Slides może zgłaszać problemy możliwe do odzyskania podczas ładowania, renderowania, konwertowania lub zapisywania prezentacji. Przykłady to uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawienie czcionki oraz ograniczenia formatu docelowego. Callback ostrzeżenia pozwala aplikacji zarejestrować te warunki i zdecydować, czy bieżąca operacja może być kontynuowana.

Użyj `java.newProxy`, aby zaimplementować interfejs Java [IWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarningcallback/) w JavaScript i przeanalizować wartości zwracane przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) oraz [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) dostępne w [IWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/). Zwróć [ReturnAction.Continue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/returnaction/#Continue), aby zaakceptować ostrzeżenie, lub [ReturnAction.Abort](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/returnaction/#Abort), aby przerwać operację.

Użyj [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) dla ostrzeżeń podnoszonych podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), które odbierają ostrzeżenia z renderowania slajdów, konwersji i zapisu. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję callbacku z etapem operacji, gdy budujesz raport zbiorczy.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje warunek, od którego Aspose.Slides może się odzyskać, jeśli callback zwróci `ReturnAction.Continue`. Wyjątek oznacza, że żądana operacja nie może zakończyć się normalnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsługiwane przez politykę ostrzeżeń.

Zwrócenie `ReturnAction.Abort` prosi dyspozytor ostrzeżeń o zakończenie bieżącej operacji poprzez zgłoszenie wyjątku. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład ładowanie może wyrzucić [PptxReadException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptreadexception/), podczas gdy zapisywanie lub eksport może spowodować [PptxException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxexception/). Przechwyć błąd z mostu Java na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać na jednym podtypie wyjątku lub komunikacie. Callback rejestruje ostrzeżenie przed zwróceniem `ReturnAction.Abort`, zapewniając dostępność przyczyny dla aplikacji.

## **Kategorie ostrzeżeń**

Klasa [WarningType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/) udostępnia stałe liczbowe dla poniższych kategorii:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Prezentacja źródłowa zawiera uszkodzenia, które mogą uczynić dokument zapisany w jego pierwotnym formacie nieużytecznym. | Zatrzymaj. |
| [DataLoss](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#DataLoss) | Tekst, wykresy, obrazy lub inne dane mogą być nieobecne po załadowaniu lub zapisaniu. | Zatrzymaj. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentacja może utracić istotne formatowanie. | Zatrzymaj w trybie ścisłej walidacji; w przeciwnym razie rejestruj i kontynuuj. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Może wystąpić ograniczona różnica w formatowaniu. | Rejestruj do diagnostyki i kontynuuj. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Wynik może nie otworzyć się lub nie działać poprawnie w niektórych aplikacjach lub starszych wersjach. | Loguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| [UnexpectedContent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Źródło zawiera nieobsługiwaną lub nierozpoznaną treść, której wpływ może nie być jeszcze znany. | Rejestruj i kontynuuj, lub traktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję polityki. Przechowuj wartość zwróconą przez [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) w celach diagnostycznych, ale nie polegaj na jej brzmieniu w logice aplikacji, ponieważ tekst komunikatu może się różnić w zależności od scenariusza ostrzeżenia i wersji produktu.

## **Zbieranie i klasyfikacja ostrzeżeń**

Poniższy przykład JavaScript używa jednego raportu aplikacyjnego dla całego potoku przetwarzania. Osobna instancja callbacku oznacza ostrzeżenia pochodzące z ładowania, renderowania, konwersji PDF i zapisu PPTX. Polityka przerywa działanie przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy dużej utracie formatowania i kontynuuje dla pozostałych ostrzeżeń.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Przekaż `false` dla `abortOnMajorFormattingLoss` przy konstruowaniu `WarningPolicy`, jeśli duże różnice w formatowaniu są akceptowalne. Problemy kompatybilności, mniejsze utraty formatowania oraz nieoczekiwana treść pozostają w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy.getAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawiać się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wygenerować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides raportuje ten stan jako `DataLoss` poprzez [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback w fazie ładowania pozwala aplikacji odrzucić plik lub wyraźnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania lub eksportu slajdu. Ostrzeżenia o podstawianiu czcionek są raportowane jako `DataLoss`, więc powyższa ścisła polityka przerywa działanie, nawet jeśli aplikacja uznałaby konkretne podstawienie za wizualnie dopuszczalne. Aby zobaczyć to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w środowisku uruchomieniowym. Opis ostrzeżenia identyfikuje podstawienie; skonfiguruj wymagane czcionki lub [zasady podstawiania czcionek](/slides/pl/nodejs-java/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana treść:** Ładowarka może natrafić na rekordy prezentacji lub funkcje, których nie rozpoznaje. Takie ostrzeżenia mogą używać `UnexpectedContent` lub bardziej poważnej kategorii, gdy wiadomo, że dane lub formatowanie zostały naruszone.
- **Kompatybilność formatu:** Zapis do innego formatu prezentacji może pominąć funkcje lub wygenerować wynik zachowujący się inaczej w niektórych aplikacjach. Na przykład zapis prezentacji zawierającej ponad osiem poziomych lub pionowych prowadnic rysunkowych do starszego PPT zgłasza `CompatibilityIssue`. Callback w fazie zapisu może zarejestrować utratę i kontynuować, lub odrzucić, jeśli zachowanie wszystkich prowadnic jest wymagane.
- **Zachowanie podczas ładowania:** Opcje ładowania i zachowania legacy również mogą generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego zachowania blokady prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik wygeneruje ostrzeżenie ani że dany scenariusz zawsze odpowiada jednej kategorii.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy callback zwróci `ReturnAction.Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego pełnym zapisaniem.

Zapisz zweryfikowane wyniki w osobnej ścieżce, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, spełnieniu wymagań polityki ostrzeżeń i potwierdzeniu, że wynik można otworzyć i sprawdzić. Dzięki temu unikniesz nadpisania prawidłowego pliku źródłowego wynikiem częściowym lub odrzuconym.

Pusty raport ostrzeżeń nie gwarantuje, że każda cecha źródłowa została zachowana. Zastosuj dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Open Presentations](/slides/pl/nodejs-java/open-presentation/) oraz [Save Presentations](/slides/pl/nodejs-java/save-presentation/).

## **FAQ**

**Czy callback ostrzeżeń może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje on warunki możliwe do odzyskania, zgłaszane jako ostrzeżenia. Wyjątki występujące niezależnie od callbacku muszą być obsłużone przez aplikację wokół wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction.Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie na kontynuację przetwarzania. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, więc należy przejrzeć zebrane typy ostrzeżeń i ich opisy.

**Jak aplikacja może zidentyfikować operację, która wywołała ostrzeżenie?**

Utwórz instancję callbacku dla każdej operacji i przechowuj etap zdefiniowany przez aplikację razem z wartościami zwróconymi przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) i [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--), jak pokazano w przykładzie.