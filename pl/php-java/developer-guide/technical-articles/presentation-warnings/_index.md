---
title: Obsługa ostrzeżeń prezentacji w PHP
type: docs
weight: 90
url: /pl/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback ostrzeżenia
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
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwertowania i zapisywania prezentacji przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Aspose.Slides może zgłaszać problemy możliwe do naprawy podczas ładowania, renderowania, konwertowania lub zapisywania prezentacji. Przykłady obejmują uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawianie czcionek oraz ograniczenia formatu docelowego. Funkcja zwrotna ostrzeżeń pozwala aplikacji rejestrować te warunki i decydować, czy bieżąca operacja może zostać kontynuowana.

Utwórz klasę PHP z publiczną metodą `warning` i udostępnij ją za pośrednictwem PHP Java Bridge jako interfejs Java [IWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarningcallback/) przy użyciu `java_closure`. Przeanalizuj wartości zwracane przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) i [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) dostarczane przez [IWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/). Zwróć [ReturnAction::Continue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/returnaction/#Continue), aby zaakceptować ostrzeżenie, lub [ReturnAction::Abort](https://reference.aspose.com/slides/pl/php-java/aspose.slides/returnaction/#Abort), aby zatrzymać operację.

Użyj [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setWarningCallback) do obsługi ostrzeżeń generowanych podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setWarningCallback), które otrzymują ostrzeżenia z renderowania slajdów, konwersji i zapisywania. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję funkcji zwrotnej z etapem operacji podczas tworzenia łącznego raportu.

## **Ostrzeżenia i wyjątki**

Wyjątki Java są udostępniane w PHP za pośrednictwem PHP Java Bridge; przechwytuj je na granicy operacji, jak pokazano w poniższym przykładzie. Odnośniki do interfejsów Java w tym artykule opisują kontrakt funkcji zwrotnej używany przez most.

Ostrzeżenie opisuje stan, z którego Aspose.Slides może się odzyskać, jeśli funkcja zwrotna zwróci `ReturnAction::Continue`. Wyjątek oznacza, że żądana operacja nie może zakończyć się normalnie; wyjątki nie są przekształcane w ostrzeżenia i nie mogą być obsłużone przez politykę ostrzeżeń.

Zwrócenie `ReturnAction::Abort` powoduje, że dyspozytor ostrzeżeń przerywa bieżącą operację, podnosząc wyjątek. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład podczas ładowania może pojawić się [PptxReadException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptreadexception/), natomiast przy zapisywaniu lub eksportowaniu może wystąpić [PptxException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxexception/). Obsłuż wyjątek na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała zakończenie, zamiast polegać na jednym podtypie wyjątku lub komunikacie. Funkcja zwrotna zapisuje ostrzeżenie przed zwróceniem `ReturnAction::Abort`, zapewniając dostępność przyczyny dla aplikacji.

## **Kategorie ostrzeżeń**

Klasa [WarningType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/) udostępnia stałe całkowite dla następujących kategorii:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Prezentacja źródłowa zawiera uszkodzenia, które mogą sprawić, że dokument zapisany w oryginalnym formacie będzie nieużyteczny. | Przerwij. |
| [DataLoss](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#DataLoss) | Tekst, wykresy, obrazy lub inne dane mogą być nieobecne po załadowaniu lub zapisaniu. | Przerwij. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentacja może utracić istotne formatowanie. | Przerwij w trybie ścisłej walidacji; w przeciwnym razie zarejestruj i kontynuuj. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Może wystąpić ograniczona różnica w formatowaniu. | Zarejestruj do diagnostyki i kontynuuj. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Rezultat może nie otworzyć się lub nie zachowywać prawidłowo w niektórych aplikacjach lub starszych wersjach. | Zaloguj i kontynuuj, chyba że zgodność jest wymagana. |
| [UnexpectedContent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/warningtype/#UnexpectedContent) | Źródło zawiera nieobsługiwaną lub nierozpoznaną treść, której wpływ może jeszcze nie być znany. | Zarejestruj i kontynuuj, lub traktuj jako błąd w ścisłej polityce. |

Kategoria powinna determinować decyzję polityki. Przechowuj wartość zwracaną przez [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--) w celach diagnostycznych, ale nie polegaj na jej brzmieniu w logice aplikacji, ponieważ tekst komunikatu może różnić się w zależności od scenariusza ostrzeżenia i wersji produktu.

## **Zbieranie i klasyfikacja ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Oddzielna instancja funkcji zwrotnej oznacza ostrzeżenia pochodzące z ładowania, renderowania, konwersji do PDF i zapisu PPTX. Polityka przerywa przy uszkodzeniach źródła lub utracie danych, opcjonalnie przerywa przy dużej utracie formatowania i kontynuuje dla pozostałych ostrzeżeń. Funkcja zwrotna konwertuje wartości ostrzeżeń na natywne wartości PHP przy użyciu `java_values` przed ich rejestracją i porównaniem.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Podaj `false` dla `abortOnMajorFormattingLoss` przy tworzeniu `WarningPolicy`, jeśli duże różnice w formatowaniu są akceptowalne. Problemy z kompatybilnością, mała utrata formatowania i nieoczekiwana treść są nadal zachowywane w raporcie, nawet gdy operacja kontynuuje. Rozszerz `WarningPolicy::getAction`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawić się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może generować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten stan `DataLoss` poprzez [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Funkcja zwrotna na etapie ładowania pozwala aplikacji odrzucić plik lub wyraźnie zaakceptować zgłoszoną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania lub eksportowania slajdu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc ścisła polityka powyżej przerywa operację, nawet jeśli aplikacja uznałaby konkretne zastąpienie za wizualnie dopuszczalne. Aby zaobserwować to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w środowisku uruchomieniowym. Opis ostrzeżenia identyfikuje podstawienie; skonfiguruj wymagane czcionki lub [reguły podstawiania czcionek](/slides/pl/php-java/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana treść:** Ładowarka może napotkać rekordy prezentacji lub funkcje, których nie rozpoznaje. Takie ostrzeżenia mogą używać `UnexpectedContent` lub bardziej poważnej kategorii, gdy wiadomo, że dane lub formatowanie są zagrożone.
- **Kompatybilność formatów:** Zapis do innego formatu prezentacji może pominąć funkcje lub wygenerować wynik, który zachowuje się inaczej w niektórych aplikacjach. Na przykład zapis prezentacji z więcej niż ośmioma poziomymi lub pionowymi prowadnicami rysunkowymi do starszego formatu PPT generuje `CompatibilityIssue`. Funkcja zwrotna na etapie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli konieczne jest zachowanie wszystkich prowadnic.
- **Zachowanie podczas ładowania:** Opcje ładowania i starsze zachowania mogą również generować ostrzeżenia. Na przykład [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identyfikuje użycie przestarzałego zachowania blokowania prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie lub że scenariusz zawsze mapuje się do jednej kategorii.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy funkcja zwrotna zwraca `ReturnAction::Abort`, nie używaj obiektu, który nie został załadowany, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego zakończeniem.

Zapisz zwalidowane wyniki w osobnej ścieżce, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, gdy raport ostrzeżeń spełnia politykę aplikacji i wynik może zostać otwarty i sprawdzony. Zapobiega to nadpisaniu prawidłowego pliku źródłowego wynikiem częściowym lub odrzuconym.

Pusty raport ostrzeżeń nie gwarantuje, że każda cecha źródła została zachowana. Przeprowadź dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Open Presentations](/slides/pl/php-java/open-presentation/) oraz [Save Presentations](/slides/pl/php-java/save-presentation/).

## **FAQ**

**Czy funkcja zwrotna ostrzeżeń może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje ona warunki możliwe do odzyskania, zgłaszane jako ostrzeżenia. Wyjątki, które występują niezależnie od funkcji zwrotnej, muszą być obsłużone przez aplikację w obrębie wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction::Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie na kontynuację przetwarzania. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, dlatego należy przejrzeć zebrane typy i opisy ostrzeżeń.

**Jak aplikacja może zidentyfikować operację, która wywołała ostrzeżenie?**

Utwórz instancję funkcji zwrotnej dla każdej operacji i przechowuj etap zdefiniowany przez aplikację wraz z wartościami zwracanymi przez [getWarningType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getWarningType--) i [getDescription](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarninginfo/#getDescription--), jak pokazano w przykładzie.