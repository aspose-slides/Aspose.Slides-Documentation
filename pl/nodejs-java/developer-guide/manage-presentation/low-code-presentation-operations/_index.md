---
title: Operacje niskokodowe na prezentacjach w JavaScript
linktitle: API niskokodowe
type: docs
weight: 50
url: /pl/nodejs-java/low-code-presentation-operations/
keywords:
- API niskokodowych prezentacji
- konwertowanie prezentacji
- scalanie prezentacji
- iteracja slajdów
- iteracja kształtów
- iteracja tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów wzorcowych
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w JavaScript, aby konwertować i scalać prezentacje, iterować zawartość, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw `aspose.slides` udostępnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocnice kapsułkują często używane przepływy pracy modelu obiektowego w skoncentrowanych metodach, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocnice niskokodowe są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/) , gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, wzorcami, układami, kształtami, ustawieniami eksportu lub powiązaniami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocnice:

| Pomocnica | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu za pomocą bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/) | Łączenie kompletnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub części tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu powtórnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) | Usuwanie nieużywanych wzorców i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/#autoByExtension), gdy rozszerzenie pliku wyjściowego wystarczy, aby wybrać format eksportu. Metoda otwiera prezentację źródłową, określa wymaganego formatu na podstawie ścieżki wyjściowej i zapisuje wynik.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/) udostępnia również dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrana pomocnica. Zobacz [Konwertowanie prezentacji](/nodejs-java/convert-presentation/) po szczegółowe przepływy pracy i opcje zależne od formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/#process), aby połączyć kompletne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Ta pomocnica jest odpowiednia, gdy wszystkie slajdy mają być dołączone do jednego wyniku bez indywidualnego wybierania lub przemapowywania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy wzorzec lub układ, zachować sekcje w sposób jawny lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/nodejs-java/merge-presentation/) dla tych scenariuszy.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji całej prezentacji lub zmianach formatowania. W Node.js twórz implementacje interfejsów zwrotnych za pomocą `java.newProxy`.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#paragraph) i [ForEach.portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#portion), aby zbadać odpowiednie elementy:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje zwykłe, wzorcowe i układowe slajdy. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/#shapes), gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, zliczany lub przetwarzany wielokrotnie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Użyj [ForEach.shape] zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz zachowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać dane osadzonych czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) usuwa slajdy układu, do których nie odwołuje żaden normalny slajd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) usuwa nieużywane slajdy wzorcowe.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) usuwa nieużywane znaki z osadzonych czcionek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usuń nieużywane układy przed nieużywanymi wzorcami, aby wzorzec, który po czyszczeniu układów stanie się nieodwołany, również został usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych wzorców, układów lub kompletnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/nodejs-java/slide-master/) oraz [Embedded Font](/nodejs-java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API niskokodowego zamiast pełnego modelu obiektowego?**

Używaj pomocnic niskokodowych, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować powiązania wzorców i układów, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnica nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/#process) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład za pomocą [Convert.autoByExtension](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/#autoByExtension), a następnie scal je.

**Czy ForEach przetwarza slajdy wzorcowe, układowe i notatek?**

[ForEach.slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#slide) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#paragraph) i [ForEach.portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#portion) obejmują domyślnie slajdy normalne, wzorcowe i układowe. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), aby natychmiast przetwarzać każdy kształt za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/#shapes), gdy potrzebujesz iterowalnego wyniku, który może być zachowany, filtrowany, zliczany lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane wzorce lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocnice działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) w pamięci. Po zmianie elementów w funkcji zwrotnej [ForEach] lub po uruchomieniu [Compress], wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertowanie prezentacji](/nodejs-java/convert-presentation/)
- [Scalanie prezentacji](/nodejs-java/merge-presentation/)
- [Wzorzec slajdu](/nodejs-java/slide-master/)
- [Zarządzanie polem tekstowym](/nodejs-java/manage-textbox/)
- [Osadzona czcionka](/nodejs-java/embedded-font/)