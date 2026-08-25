---
title: Operacje prezentacji niskokodowych w JavaScript
linktitle: API niskokodowe
type: docs
weight: 50
url: /pl/nodejs-java/low-code-presentation-operations/
keywords:
- API niskokodowe prezentacji
- konwertuj prezentację
- scal prezentacje
- iteruj slajdy
- iteruj kształty
- iteruj tekst
- zbieraj kształty
- kompresuj prezentację
- usuń nieużywane master slajdy
- usuń nieużywane slajdy układu
- kompresuj osadzone czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w JavaScript, aby konwertować i scalać prezentacje, iterować po zawartości, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

`aspose.slides` namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz redukcja osadzonych danych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/#autoByExtension), gdy wystarczające jest określenie formatu eksportu na podstawie rozszerzenia pliku wyjściowego. Metoda otwiera źródłową prezentację, określa wymaganą formatę na podstawie ścieżki wyjściowej i zapisuje wynik.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/) oferuje także dedykowane metody dla wyjść PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/slides/pl/nodejs-java/convert-presentation/) aby poznać przepływy pracy i opcje specyficzne dla formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/#process), aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Ten pomocnik jest właściwy, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub przemapowywania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalania wybranych slajdów, zastosowania docelowego mastera lub układu, jawnego zachowania sekcji lub dopasowania różnych rozmiarów slajdów. Zobacz [Merge Presentations](/slides/pl/nodejs-java/merge-presentation/) dla tych scenariuszy.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania na poziomie całej prezentacji. W Node.js twórz implementacje interfejsów zwrotnych przy użyciu `java.newProxy`.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#paragraph) i [ForEach.portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#portion) do inspekcji odpowiadających elementów:

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

Domyślnie przeglądanie kształtów i tekstu na poziomie całej prezentacji obejmuje slajdy normalne, master i układy. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy ważna jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/#shapes), gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

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

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), gdy każdy kształt może być obsłużony natychmiast i nie musisz przechowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i redukować osadzone dane czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) usuwa slajdy układu, które nie są referencjonowane przez żadne normalne slajdy.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) usuwa master slajdy, które nie są już używane.
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

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który stanie się nieodwoływany po czyszczeniu układów, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/nodejs-java/slide-master/) i [Embedded Font](/slides/pl/nodejs-java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować zależności mastera i układu, sprawdzić stan pośredni lub skonfigurować zachowanie, które nie jest udostępnione przez pomocnika.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/merger/#process) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw przekonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/convert/#autoByExtension), a następnie scali skonwertowane pliki.

**Czy ForEach przetwarza slajdy master, układ i notatki?**

[ForEach.slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#slide) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#paragraph) i [ForEach.portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#portion) obejmują domyślnie slajdy normalne, master i układy. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/#shape), aby przetworzyć każdy kształt natychmiast za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/collect/#shapes), gdy potrzebujesz iterowalnego wyniku, który może być przechowywany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/), wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertowanie prezentacji](/slides/pl/nodejs-java/convert-presentation/)
- [Scalanie prezentacji](/slides/pl/nodejs-java/merge-presentation/)
- [Master slajdu](/slides/pl/nodejs-java/slide-master/)
- [Zarządzanie polem tekstowym](/slides/pl/nodejs-java/manage-textbox/)
- [Osadzona czcionka](/slides/pl/nodejs-java/embedded-font/)