---
title: Operacje prezentacji Low-Code w Javie
linktitle: API Low-Code
type: docs
weight: 50
url: /pl/java/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwersja prezentacji
- scalanie prezentacji
- iteracja slajdów
- iteracja kształtów
- iteracja tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych master slajdów
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w Javie, aby konwertować i scalać prezentacje, iterować po zawartości, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Pakiet [com.aspose.slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/) zapewnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki opakowują często używane przepływy pracy modelu obiektowego w skoncentrowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatni, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Skorzystaj z pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/), gdy potrzebujesz precyzyjnej kontroli nad pojedynczymi slajdami, masterami, układami, kształtami, ustawieniami eksportu lub relacjami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik‑do‑pliku. |
| [Merger](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/) | Łączenie pełnych plików prezentacji w tym samym formacie. |
| [ForEach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/) | Uruchamianie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu powtarzalnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz redukcja danych osadzonych czcionek. |

## **Konwertuj prezentację**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) gdy rozszerzenie pliku wyjściowego wystarczy do wyboru formatu eksportu. Metoda otwiera źródłową prezentację, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert] udostępnia także dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Skorzystaj z pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Konwertuj prezentację](/slides/pl/java/convert-presentation/) po szczegółowe przepływy i opcje dla konkretnych formatów.

## **Scal prezentacje**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aby połączyć pełne pliki prezentacji jednym wywołaniem. Wprowadzane prezentacje muszą mieć ten sam format pliku.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają być dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Skorzystaj z pełnego modelu obiektowego, gdy musisz scalić wybrane slajdy, zastosować docelowy master lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Scal prezentacje](/slides/pl/java/merge-presentation/) w tych scenariuszach.

## **Iteruj po elementach prezentacji**

Klasa [ForEach] wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji całej prezentacji lub zmianach formatowania.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), i [ForEach.portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) do inspekcji odpowiednich elementów:

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

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje slajdy normalne, master i układ. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic‑dziecko.

## **Zbierz kształty**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw ma być filtrowany, liczony lub przetwarzany wielokrotnie.

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

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz zachowywać zebranego wyniku.

## **Kompresuj zawartość prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i redukować dane osadzonych czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) usuwa slajdy układu, które nie są referowane przez żaden normalny slajd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) usuwa master‑slajdy, które nie są już używane.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) usuwa nieużywane znaki z osadzonych czcionek.

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

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który stanie się nieodwołany po czyszczeniu układów, również został usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Master slajdu](/slides/pl/java/slide-master/) i [Osadzona czcionka](/slides/pl/java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Skorzystaj z pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, sterować zależnościami master‑ów i układów, sprawdzić stan pośredni lub skonfigurować zachowanie, które pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) wymaga, aby wejściowe prezentacje były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a następnie scali je.

**Czy ForEach przetwarza slajdy master, układ i notatki?**

[ForEach.slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) i [ForEach.portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) obejmują domyślnie slajdy normalne, master i układ. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), aby przetwarzać każdy kształt od razu za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), gdy potrzebujesz iterowalnego wyniku, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadnego z nich nie ma, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/), wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertuj prezentację](/slides/pl/java/convert-presentation/)
- [Scal prezentacje](/slides/pl/java/merge-presentation/)
- [Master slajdu](/slides/pl/java/slide-master/)
- [Zarządzaj polem tekstowym](/slides/pl/java/manage-textbox/)
- [Osadzona czcionka](/slides/pl/java/embedded-font/)