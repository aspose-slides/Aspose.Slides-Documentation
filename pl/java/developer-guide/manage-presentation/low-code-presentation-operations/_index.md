---
title: Operacje niskokodowe prezentacji w Javie
linktitle: API niskokodowe
type: docs
weight: 50
url: /pl/java/low-code-presentation-operations/
keywords:
- API niskokodowe prezentacji
- konwertowanie prezentacji
- scalanie prezentacji
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
- Java
- Aspose.Slides
description: "Użyj API niskokodowego Aspose.Slides w Javie, aby konwertować i scalać prezentacje, iterować po zawartości, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Pakiet [com.aspose.slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/) udostępnia statyczne klasy pomocnicze dla typowych operacji na prezentacjach. Te pomocniki opakowują często używane przepływy pracy modelu obiektowego w skoncentrowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną treść przy mniejszej ilości kodu.

Pomocniki low‑code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/), gdy potrzebna jest szczegółowa kontrola nad poszczególnymi slajdami, masterami, układami, kształtami, ustawieniami eksportu lub relacjami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/) | Konwertowanie prezentacji na inny format przy użyciu bezpośredniego wywołania plik‑do‑pliku. |
| [Merger](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/) | Łączenie kompletnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu powtarzalnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) gdy rozszerzenie pliku wyjściowego wystarczy do wyboru formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą wersję z ścieżki wyjściowej i zapisuje wynik.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/) udostępnia także dedykowane metody dla wyjść PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem albo skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/java/convert-presentation/) po szczegółowe przepływy i opcje zależne od formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aby połączyć pełne pliki prezentacji jednym wywołaniem. Wejściowe prezentacje muszą mieć ten sam format pliku.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy master lub układ, jawnie zachować sekcje albo rozwiązać różne rozmiary slajdów. Zobacz [Merge Presentations](/java/merge-presentation/) dla tych scenariuszy.

## **Iteracja po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika ona zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania w całej prezentacji.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) oraz [ForEach.portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) do inspekcji odpowiednich elementów:

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

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje slajdy normalne, master i układ. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne wyjście, filtrowanie przed wywołaniem zwrotnym lub szczegółowa kontrola rodzic‑dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

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

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) zamiast, gdy każdy kształt można obsłużyć od razu i nie musisz przechowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać dane osadzonych czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) usuwa slajdy układu, do których nie odwołuje się żaden normalny slajd.
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

Najpierw usuń nieużywane układy, a potem nieużywane mastery, aby master, który stanie się nieodwołany po czyszczeniu układów, również mógł zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/java/slide-master/) i [Embedded Font](/java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API niskokodowego zamiast pełnego modelu obiektowego?**

Używaj pomocników low‑code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować powiązania master‑layout, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) wymaga, aby wejściowe prezentacje były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a potem scal skonwertowane pliki.

**Czy ForEach przetwarza slajdy master, layout oraz notatki?**

[ForEach.slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) i [ForEach.portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) domyślnie obejmują slajdy normalne, master i layout. Użyj ich przeciążeń z `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) do natychmiastowego przetwarzania każdego kształtu poprzez funkcję zwrotną. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) gdy potrzebujesz iterowalnego wyniku, który można zachować, filtrować, liczyć lub przeglądać wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy w prezentacji znajdują się nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) w pamięci. Po zmianie elementów w wywołaniu zwrotnym [ForEach] lub po uruchomieniu [Compress] należy wywołać [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertuj prezentację](/java/convert-presentation/)
- [Scal prezentacje](/java/merge-presentation/)
- [Master slajdu](/java/slide-master/)
- [Zarządzanie polem tekstowym](/java/manage-textbox/)
- [Wbudowana czcionka](/java/embedded-font/)