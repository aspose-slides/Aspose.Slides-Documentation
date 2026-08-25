---
title: Niskokodowe operacje na prezentacjach w PHP
linktitle: Niskokodowe API
type: docs
weight: 50
url: /pl/php-java/low-code-presentation-operations/
keywords:
- niskokodowe API prezentacji
- konwertowanie prezentacji
- scalanie prezentacji
- iterowanie slajdów
- iterowanie kształtów
- iterowanie tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów wzorca
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w PHP, aby konwertować i scalać prezentacje, iterować po zawartości, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw [aspose.slides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/) zapewnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki kapsułkują często używane przepływy pracy modelu obiektowego w skoncentrowanych metodach, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki niskokodowe są najprzydatniejsze, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [Aspose.Slides object model](https://reference.aspose.com/slides/pl/php-java/aspose.slides/) gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, wzorcami, układami, kształtami, ustawieniami eksportu lub zależnościami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/) | Konwertowanie prezentacji na inny format przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/) | Uruchamianie funkcji zwrotnej dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) | Usuwanie nieużywanych wzorców i układów oraz redukcja osadzonych danych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert::autoByExtension](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/#autoByExtension) gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/) oferuje również dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/slides/pl/php-java/convert-presentation/) po szczegółowe przepływy pracy i opcje zależne od formatu.

## **Scalanie prezentacji**

Użyj [Merger::process](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/#process) aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają być dołączone do jednego wyniku bez indywidualnego wybierania lub przemapowywania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalać wybrane slajdy, zastosować docelowy wzorzec lub układ, zachować sekcje explicite, lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/slides/pl/php-java/merge-presentation/) dla tych scenariuszy.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika ona zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji całej prezentacji lub zmianach formatowania.

Poniższy przykład używa [ForEach_::slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#paragraph) i [ForEach_::portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#portion) do inspekcji odpowiednich elementów:

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

Domyślnie, przeglądanie kształtów i tekstu w całej prezentacji obejmuje normalne, wzorcowe i układowe slajdy. Przeciążenia z parametrem `includeNotes` mogą także przetwarzać slajdy notatek. Używaj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect::shapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/#shapes) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

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

Użyj [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz przechowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i redukować osadzone dane czcionek:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedMasterSlides) usuwa slajdy wzorca, które nie są już używane.
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

Usuń nieużywane układy przed nieużywanymi wzorcami, aby wzorzec, który stanie się nieodwołany po usunięciu układów, również mógł zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych wzorców, układów lub pełnych osadzonych danych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/php-java/slide-master/) oraz [Embedded Font](/slides/pl/php-java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać interfejsu API niskokodowego zamiast pełnego modelu obiektowego?**

Używaj pomocników niskokodowych, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować zależności wzorca i układu, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger::process](https://reference.aspose.com/slides/pl/php-java/aspose.slides/merger/#process) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert::autoByExtension](https://reference.aspose.com/slides/pl/php-java/aspose.slides/convert/#autoByExtension), a następnie scal przetworzone pliki.

**Czy ForEach_ przetwarza slajdy wzorca, układu i notatek?**

[ForEach_::slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#slide) iteruje przez normalne slajdy prezentacji. Operacje [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#paragraph) i [ForEach_::portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#portion) obejmują domyślnie normalne, wzorcowe i układowe slajdy. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach_::shape a Collect::shapes?**

Użyj [ForEach_::shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/#shape) aby przetwarzać każdy kształt od razu przy użyciu funkcji zwrotnej. Użyj [Collect::shapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/collect/#shapes), gdy potrzebny jest iterowalny rezultat, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Niekoniecznie. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane wzorce lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiadające operacje [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach_ lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach_](https://reference.aspose.com/slides/pl/php-java/aspose.slides/foreach_/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/), wywołaj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertowanie prezentacji](/slides/pl/php-java/convert-presentation/)
- [Scalanie prezentacji](/slides/pl/php-java/merge-presentation/)
- [Wzorzec slajdu](/slides/pl/php-java/slide-master/)
- [Zarządzanie polem tekstowym](/slides/pl/php-java/manage-textbox/)
- [Osadzona czcionka](/slides/pl/php-java/embedded-font/)