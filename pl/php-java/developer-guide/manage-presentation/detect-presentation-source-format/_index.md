---
title: Określenie oryginalnego formatu prezentacji w PHP
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/php-java/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji w PHP przy użyciu Aspose.Slides dla PHP via Java, porównaj API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj metodę [Presentation::getSourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSourceFormat) aby określić jej oryginalny format. Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została załadowana bieżąca instancja.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/) wybranego dla pliku wyjściowego. Zapisanie do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczytanie formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation::getSourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSourceFormat), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zamień komunikaty na własną logikę aplikacji.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Rozpoznawanie obsługiwanych wartości**

Klasa [SourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sourceformat/) definiuje stałe całkowite, które rozróżniają następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalne, a nie rekonstrukcją oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentacja PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentacja Office Open XML |
| `Pptm` | `.pptm` | Prezentacja Office Open XML z obsługą makr |
| `Pps` | `.pps` | Pokaz slajdów PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Pokaz slajdów Office Open XML |
| `Ppsm` | `.ppsm` | Pokaz slajdów Office Open XML z obsługą makr |
| `Pot` | `.pot` | Szablon PowerPoint 97–2003 |
| `Potx` | `.potx` | Szablon Office Open XML |
| `Potm` | `.potm` | Szablon Office Open XML z obsługą makr |
| `Odp` | `.odp` | Prezentacja OpenDocument |
| `Otp` | `.otp` | Szablon prezentacji OpenDocument |
| `Fodp` | `.fodp` | Prezentacja Flat XML ODF |
| `Xml` | `.xml` | Prezentacja PowerPoint XML |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Wczytanie jego bajtów do strumienia pamięci modeluje wejście otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) otrzymuje jedynie strumień.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu po ścieżce do pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsza zawartość PPS i POT może być zgłoszona jako `SourceFormat::Ppt`; przykład PPS powyżej wypisuje wartość całkowitą `SourceFormat::Ppt`.

Jeśli aplikacja musi zachować to rozróżnienie, przechowuj oryginalną nazwę pliku lub metadane podtypu osobno. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrywania przed i po załadowaniu**

Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) i [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#getLoadFormat), gdy potrzebujesz sprawdzić plik przed załadowaniem pełnego modelu obiektu prezentacji. Użyj [Presentation::getSourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSourceFormat), gdy instancja już istnieje.

Ten przykład wymaga pliku `sample.pptx` i wypisuje wartości całkowite `LoadFormat::Pptx` oraz `SourceFormat::Pptx`. W środowisku produkcyjnym wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga dodatkowego sprawdzania wyłącznie w celu uzyskania jej formatu źródłowego.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Wyniki używają stałych z różnych klas: [LoadFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sourceformat/). Nie porównuj ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłoszony jako `LoadFormat::Unknown` przed załadowaniem i jako `SourceFormat::Xml` po załadowaniu.

## **Utrzymywanie formatu źródłowego i wyjściowego osobno**

Ten przykład wymaga pliku `sample.pptx` i zapisuje `converted.odp`. Wypisuje wartość całkowitą `SourceFormat::Pptx` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja załadowana z wyjścia ODP zgłasza `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Prezentacja utworzona od zera za pomocą `new Presentation()` zgłasza `SourceFormat::Pptx`. Nie ma ona pliku wejściowego: jest to wartość domyślna dla nowo utworzonej instancji, a nie dowód, że załadowano plik PPTX. Śledź, czy aplikacja utworzyła, czy załadowała instancję osobno, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapasowy mechanizm zapobiega cichej asignacji rozszerzenia do nierozpoznanej wartości.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

To mapowanie nie konwertuje pliku ani nie przywraca starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/) explicite, lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów przez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w bieżącym katalogu, nadpisując pliki o tych samych nazwach. Otwiera każdy wynik zarówno po ścieżce, jak i poprzez strumień pamięci. Dla PPTX i ODP oba sposoby zgłaszają zapisany format. Dla PPS, ładowanie po ścieżce zgłasza `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku zgłasza `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Poniższa tabela podsumowuje identyfikację formatu źródłowego dla prezentacji o pasujących rozszerzeniach. Nazwy oznaczają stałe; przykłady PHP wypisują ich wartości całkowite:

| Zapisany format | SourceFormat ze ścieżki pliku | SourceFormat ze strumienia bez nazwy |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Zawartość PPS/POT jest identyfikowana jako `Ppt` w strumieniach bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich cech prezentacji podczas konwersji.

## **FAQ**

**Czy zapisanie do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal zgłasza `Pptx`. Instancja załadowana z zapisanego pliku ODP zgłasza `Odp`.

**Czy strumień zawsze może odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT współdzielą format binarny. Przechowuj nazwę pliku lub metadane podtypu osobno, gdy to rozróżnienie jest wymagane.

**Jakiego API powinienem używać, jeśli prezentacja jest już załadowana?**

Użyj [Presentation::getSourceFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSourceFormat). Skorzystaj z [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo), aby przeprowadzić inspekcję przed załadowaniem.