---
title: Konwersja PPT do PPTX w PHP
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/php-java/convert-ppt-to-pptx/
keywords:
- konwertowanie PowerPoint
- konwertowanie prezentacji
- konwertowanie slajdu
- konwertowanie PPT
- PPT do PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX w PHP przy użyciu Aspose.Slides. Zawiera przykłady PHP dla konwersji pojedynczych plików oraz wsadowej, obsługę błędów i uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX jest nowszym formatem Open XML. Aspose.Slides for PHP via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i następnie wywołaj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) z argumentem [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i uwalnia jej zasoby.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Wczytaj starszą prezentację PPT.
$presentation = new Presentation("presentation.ppt");
try {
    // Zapisz prezentację w formacie PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; argument [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/#Pptx) to robi. Utrzymuj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować pierwotny plik PPT.

## **Konwertowanie wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałej partii.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

W środowiskach produkcyjnych loguj pełny wyjątek, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, i zapisz nazwy nieudanych plików do kolejki ponownego przetwarzania lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymagania hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/php-java/password-protected-presentation/) aby wczytać zaszyfrowane pliki.

## **Wierność i funkcje przestarzałe**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednakże PPT i PPTX nie odwzorowują każdej funkcji w dokładnie taki sam sposób. Funkcja przestarzała, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z obsługą makr, gdy VBA musi pozostać dostępne. Zweryfikuj również, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

Dla ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź liczbę slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej aplikacji. Nie traktuj udanego wywołania [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) jako dowodu, że każda funkcja przestarzała ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako archiwalną lub przywracalną kopię, dopóki przekonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z wskazówek specyficznych dla formatu w [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku pojedynczego pliku lub szybkiego porównania możesz użyć [konwertera online PPT do PPTX](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API PHP.

## **Powiązane artykuły**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/php-java/save-presentation/)
- [Supported File Formats](/php-java/supported-file-formats/)
- [Open Presentations in PHP](/php-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for PHP via Java wczytuje i zapisuje pliki prezentacji bez wymogu Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa dokładnie całą zawartość?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej przestarzałej lub nieobsługiwanej funkcji. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę skonwertować plik PPT zabezpieczony hasłem?**

Tak, jeśli podasz prawidłowe hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach roboczych, które są dla Ciebie istotne. Zapewnia to kopię zapasową, jeśli funkcja przestarzała zostanie skonwertowana inaczej.