---
title: Pobieranie i aktualizacja informacji o prezentacji w PHP
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/php-java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- czytanie właściwości
- zmiana właściwości
- modyfikowanie właściwości
- aktualizacja właściwości
- sprawdzanie PPTX
- sprawdzanie PPT
- sprawdzanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument, korzystając z Aspose.Slides dla PHP, aby szybciej uzyskać wgląd i inteligentniej przeprowadzić audyt treści."
---
## **Przegląd**

Aspose.Slides może rozpoznać format prezentacji i odczytać metadane dokumentu bez tworzenia pełnego modelu obiektowego prezentacji. Jest to przydatne, gdy trzeba klasyfikować pliki, tworzyć inwentaryzację lub sprawdzać właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł demonstruje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) i [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/), a także ukierunkowane aktualizacje przy użyciu [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/).

## **Sprawdź format prezentacji**

Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) aby sprawdzić plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Metoda [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#getLoadFormat) zgłasza wykryty format, taki jak PPTX, PPT lub ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Zbuduj lekką inwentaryzację prezentacji**

Gdy przetwarzasz wiele plików prezentacji, możesz potrzebować zwartej inwentaryzacji do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) aby uzyskać obiekt [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/), a następnie wywołaj [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektowego prezentacji.

Rozszerzone właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/) dostarczają następujące wartości inwentaryzacji:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getSlides) | Łączna liczba slajdów. |
| [getHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Liczba ukrytych slajdów. |
| [getNotes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getNotes) | Liczba slajdów zawierających notatki. |
| [getParagraphs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getParagraphs) | Łączna liczba akapitów, jeśli dostępna. |
| [getWords](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getWords) | Łączna liczba słów. |
| [getMultimediaClips](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i wypisuje zwartą inwentaryzację. Łączy także [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getHeadingPairs) z [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getTitlesOfParts), aby wyświetlić grupy zawartości, takie jak czcionki, motywy i tytuły slajdów.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Każdy [HeadingPair](https://reference.aspose.com/slides/pl/php-java/aspose.slides/headingpair/) dostarcza nazwę grupy i liczbę elementów w tej grupie. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getTitlesOfParts) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy nagłówek.

### **Przechowywane metadane i ograniczenia formatów**

Właściwości inwentaryzacji zwracane przez [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) odzwierciedlają metadane dostępne w dokumencie źródłowym. Aspose.Slides nie wczytuje i nie przegląda modelu obiektowego prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane domyślnymi wartościami, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja, która ostatnio zapisała plik, nie zaktualizowała właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwróci jej przechowywaną lub domyślną wartość zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólnych statystyk dokumentu, takich jak liczba stron, akapitów i słów, ale te wartości nie mapują na wszystkie specyficzne dla PowerPointa rozszerzone właściwości. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie traktuj wartości zero ani pustej tablicy jako ostatecznego dowodu, że odpowiadająca im treść jest nieobecna.

Używaj lekkiego podejścia opartego na metadanych do inwentaryzacji i wstępnych sprawdzeń. Załaduj prezentację i sprawdź jej żywy model obiektowy, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy trzeba zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizuj właściwości prezentacji**

Właściwości zwracane przez [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) mogą być również zmieniane bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Zastosuj zmiany za pomocą [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), a następnie zapisz powiązaną prezentację przy pomocy [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Poniższy obrazek pokazuje oryginalne właściwości dokumentu prezentacji PowerPoint.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Poniższy przykład zmienia tytuł i czas ostatniego zapisu oraz zapisuje wynik do nowego pliku:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Do powiązanych kontroli bezpieczeństwa i ustawień ochrony zobacz następujące artykuły:

- [Password-Protect Presentations](/slides/pl/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pl/php-java/write-protected-presentation/)

## **FAQ**

**Jak sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation::getFontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getFontsManager). Wywołaj [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts), aby uzyskać osadzone czcionki, oraz [FontsManager::getFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getFonts), aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getHiddenSlides) przez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) i [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties). To rozwiązanie jest odpowiednie dla lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być brakujące lub nieaktualne, lub jeśli potrzebujesz zweryfikować bieżące wartości, przeiteruj przez [Presentation::getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlides) i sprawdź metodę [Slide::getHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getHidden) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od domyślnych?**

Tak. Załaduj prezentację i wywołaj [Presentation::getSlideSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlideSize). Użyj [SlideSize::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/#getSize) i [SlideSize::getOrientation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/#getOrientation), aby porównać bieżące ustawienia z oczekiwanymi presetami i wymiarami.

**Czy istnieje szybki sposób, aby zobaczyć, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Zlokalizuj każdy [Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/) i wywołaj [ChartData::getDataSourceType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getDataSourceType). Dla zewnętrznego skoroszytu wywołaj [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Typ źródła danych i ścieżka identyfikują zewnętrzne odwołanie, ale weryfikacja dostępności docelowego zasobu wymaga osobnego sprawdzenia.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport PDF?**

Nie istnieje pojedyncza właściwość złożoności. Przejrzyj [Presentation::getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlides) i kolekcję [BaseSlide::getShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getShapes) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników, a następnie zmierz reprezentatywny render lub eksport przed uznaniem slajdu za potwierdzony wąski gardło wydajności.