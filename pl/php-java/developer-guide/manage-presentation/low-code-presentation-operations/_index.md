---
title: Operacje prezentacji niskokodowe w PHP
linktitle: API niskokodowe
type: docs
weight: 50
url: /pl/php-java/low-code-presentation-operations/
keywords:
- API niskokodowe prezentacji
- konwersja prezentacji
- łączenie prezentacji
- iteracja slajdów
- iteracja kształtów
- iteracja tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów master
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w PHP, aby konwertować i łączyć prezentacje, iterować zawartość, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw [aspose.slides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/) dostarcza statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocnicze klasy opakowują często używane przepływy pracy modelu obiektowego w ukierunkowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocnicze klasy low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [Aspose.Slides object model](https://reference.aspose.com/slides/pl/php-java/aspose.slides/), gdy potrzebujesz precyzyjnej kontroli nad pojedynczymi slajdami, master, układami, kształtami, ustawieniami eksportu lub powiązaniami pomiędzy elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocnicze klasy:

| Narzędzie | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/) | Łączenie pełnych plików prezentacji w tym samym formacie. |
| [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/) | Uruchamianie funkcji zwrotnej dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu powtarzalnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz redukcja osadzonych danych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert::autoByExtension](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/#autoByExtension), gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą formatę na podstawie ścieżki wyjścia i zapisuje wynik.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/) udostępnia również dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz przejrzeć lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/php-java/convert-presentation/) w celu uzyskania przepływów pracy i opcji specyficznych dla formatu.

## **Łączenie prezentacji**

Użyj [Merger::process](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/#process), aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania ich. Użyj pełnego modelu obiektowego, gdy musisz scalić wybrane slajdy, zastosować docelowy master lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/php-java/merge-presentation/) w tych scenariuszach.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika ona zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania na poziomie całej prezentacji.

Poniższy przykład używa [ForEach_::slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#paragraph) i [ForEach_::portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#portion), aby sprawdzić odpowiednie elementy:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje zwykłe, master i układ slajdów. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy ważna jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola rodzic‑dziecko.

## **Zbieranie kształtów**

Użyj [Collect::shapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/#shapes), gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Użyj [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz zachowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i redukować osadzone dane czcionek:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedMasterSlides) usuwa master slajdy, które nie są już używane.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#compressEmbeddedFonts) usuwa nieużywane znaki z osadzonych czcionek.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który stanie się niezaadresowany po czyszczeniu układów, również mógł zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/php-java/slide-master/) oraz [Embedded Font](/php-java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy kompletnego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować zależności master i układów, przejrzeć stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger::process](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/#process) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert::autoByExtension](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/#autoByExtension), a następnie połącz skonwertowane pliki.

**Czy ForEach_ przetwarza slajdy master, układ i notatki?**

[ForEach_::slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#slide) iteruje przez normalne slajdy prezentacji. Operacje [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#paragraph) i [ForEach_::portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#portion) obejmują domyślnie normalne, master i układ slajdy w całej prezentacji. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach_::shape a Collect::shapes?**

Użyj [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape), aby przetworzyć każdy kształt natychmiast za pomocą funkcji zwrotnej. Użyj [Collect::shapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/#shapes), gdy potrzebujesz iterowalnego wyniku, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy w prezentacji znajdują się nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach_ lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki operują na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w pamięci. Po zmianie elementów w wywołaniu zwrotnym [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/), lub wykonaniu [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/), wywołaj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)