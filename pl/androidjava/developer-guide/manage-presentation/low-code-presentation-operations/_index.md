---
title: Operacje prezentacji low-code na Androidzie
linktitle: Interfejs API low-code
type: docs
weight: 50
url: /pl/androidjava/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- scalanie prezentacji
- iteracja slajdów
- iteracja kształtów
- iteracja tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów wzorca
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides na Androidzie, aby konwertować i scalać prezentacje, iterować zawartość, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Pakiet [com.aspose.slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/) zapewnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki opakowują często używane przepływy pracy modelu obiektowego w dedykowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatni, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [Aspose.Slides object model](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/) gdy potrzebujesz drobnej kontroli nad poszczególnymi slajdami, wzorcami, układami, kształtami, ustawieniami eksportu lub relacjami pomiędzy elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub części tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) | Usuwanie nieużywanych wzorców i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) gdy rozszerzenie pliku wyjściowego wystarcza do wyboru formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą wersję z ścieżki wyjściowej i zapisuje wynik.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/) udostępnia również dedykowane metody dla wyjść PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz przejrzeć lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/slides/pl/androidjava/convert-presentation/) po szczegółowe przepływy pracy i opcje specyficzne dla formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) , aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy musisz scalić wybrane slajdy, zastosować docelowy wzorzec lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/slides/pl/androidjava/merge-presentation/) w tych scenariuszach.

## **Iterowanie przez elementy prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania w całej prezentacji.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), oraz [ForEach.portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) do inspekcji odpowiednich elementów:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje zwykłe, wzorcowe i układowe slajdy. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne wyjście, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) , gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany więcej niż raz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz zachowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać dane osadzonych czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) usuwa slajdy układu, które nie są referencjonowane przez żaden zwykły slajd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) usuwa slajdy wzorca, które nie są już używane.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) usuwa nieużywane znaki z osadzonych czcionek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usuń nieużywane układy przed nieużywanymi wzorcami, aby wzorzec, który stanie się nieodwołany po czyszczeniu układów, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych wzorców, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/androidjava/slide-master/) i [Embedded Font](/slides/pl/androidjava/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy kompletnego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować relacje wzorca i układu, przejrzeć stan pośredni lub skonfigurować zachowanie, które pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a następnie scali przetworzone pliki.

**Czy ForEach przetwarza slajdy wzorca, układu i notatek?**

[ForEach.slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje przez zwykłe slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) i [ForEach.portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) obejmują domyślnie zwykłe, wzorcowe i układowe slajdy w całej prezentacji. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), aby przetwarzać każdy kształt od razu za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), gdy potrzebujesz iterowalnego wyniku, który można zachować, filtrować, liczyć lub przeglądać wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane wzorce lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) w pamięci. Po zmianie elementów w funkcji zwrotnej [ForEach] lub po uruchomieniu [Compress], wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwersja prezentacji](/slides/pl/androidjava/convert-presentation/)
- [Scalanie prezentacji](/slides/pl/androidjava/merge-presentation/)
- [Wzorzec slajdu](/slides/pl/androidjava/slide-master/)
- [Zarządzanie polem tekstowym](/slides/pl/androidjava/manage-textbox/)
- [Osadzona czcionka](/slides/pl/androidjava/embedded-font/)