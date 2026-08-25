---
title: Konwertuj PPT na PPTX w PHP
linktitle: PPT na PPTX
type: docs
weight: 20
url: /pl/php-java/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT na PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj starsze pliki PPT na PPTX w PHP przy użyciu Aspose.Slides. Zawiera przykłady PHP dla konwersji pojedynczego pliku i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX jest nowszym formatem Open XML. Aspose.Slides dla PHP via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak przekonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertuj plik PPT na PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), a następnie wywołaj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) z argumentem [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/#Pptx). Blok `finally` zwalnia prezentację i zwalnia jej zasoby.

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

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/#Pptx). Utrzymuj różne ścieżki wejścia i wyjścia, jeśli musisz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

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

W środowiskach produkcyjnych należy rejestrować pełne wyjątki, decydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisywać nazwy nieudanych plików do kolejki ponownego przetwarzania lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/slides/pl/php-java/password-protected-presentation/) aby wczytać zaszyfrowane pliki.

## **Wierność i funkcje przestarzałe**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w dokładnie taki sam sposób. Funkcja przestarzała, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy z włączonymi makrami, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym przekonwertowana prezentacja będzie otwierana lub renderowana.

Dla ważnych dokumentów ponownie otwórz wygenerowany PPTX programowo i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w zamierzonym przeglądarce. Nie traktuj udanego wywołania [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) jako dowodu, że każda przestarzała funkcja ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami obsługującymi pakiety Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Przechowuj oryginalny PPT jako archiwalną lub przywracaną kopię, dopóki przekonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z wskazówek specyficznych dla formatu w [Convert Presentations to Multiple Formats](/slides/pl/php-java/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

Do okazjonalnego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API PHP.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/php-java/ppt-vs-pptx/)
- [Zapisz prezentacje w PHP](/slides/pl/php-java/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/php-java/supported-file-formats/)
- [Otwieranie prezentacji w PHP](/slides/pl/php-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides dla PHP via Java wczytuje i zapisuje pliki prezentacji bez potrzeby Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej przestarzałej lub nieobsługiwanej funkcji. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę skonwertować plik PPT zabezpieczony hasłem?**

Tak, pod warunkiem podania prawidłowego hasła podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Przechowuj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i procesach, które są dla Ciebie istotne. Zapewnia to kopię zapasową w razie, gdy przestarzała funkcja zostanie przekonwertowana inaczej.