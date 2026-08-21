---
title: Operacje prezentacji low-code na Androidzie
linktitle: API low-code
type: docs
weight: 50
url: /pl/androidjava/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- łączenie prezentacji
- iterowanie slajdów
- iterowanie kształtów
- iterowanie tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych masterów slajdów
- usuwanie nieużywanych układów slajdów
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides na Androidzie, aby konwertować i łączyć prezentacje, iterować zawartość, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Pakiet [com.aspose.slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/) dostarcza statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki kapsułkują często używane przepływy pracy modelu obiektowego w skoncentrowanych metodach, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/) gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, masterami, układami, kształtami, ustawieniami eksportu lub zależnościami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Do czego służy |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy bezpośrednim wywołaniu plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/) | Łączenie kompletnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz redukcja osadzonych danych czcionek. |

## **Konwersja prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) gdy rozszerzenie pliku wyjściowego wystarczy do wyboru formatu eksportu. Metoda otwiera źródłową prezentację, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/) udostępnia również dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której wybrany pomocnik nie udostępnia. Zobacz [Convert Presentation](/androidjava/convert-presentation/) dla przepływów pracy i opcji specyficznych dla formatu.

## **Łączenie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aby połączyć kompletne pliki prezentacji jednym wywołaniem. Wejściowe prezentacje muszą mieć ten sam format pliku.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Pomocnik jest odpowiedni, gdy wszystkie slajdy mają być dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy master lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/androidjava/merge-presentation/) dla tych scenariuszy.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy przeglądzie całej prezentacji lub zmianach formatowania.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), i [ForEach.portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) aby sprawdzić odpowiednie elementy:

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

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje slajdy normalne, master i układy. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Używaj bezpośrednich pętli kolekcji, gdy ważna jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

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

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz przechowywać zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i redukować osadzone dane czcionek:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) usuwa slajdy master, które nie są już używane.
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

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który po czyszczeniu układów przestanie być referencjonowany, również mógł zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Aby uzyskać więcej szczegółów, zobacz [Slide Master](/androidjava/slide-master/) i [Embedded Font](/androidjava/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy potrzebujesz wybrać konkretne slajdy, kontrolować zależności master i układów, przeglądać stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) wymaga, aby wejściowe prezentacje były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a następnie scal skonwertowane pliki.

**Czy ForEach przetwarza slajdy master, układu i notatek?**

[ForEach.slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), i [ForEach.portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) obejmują domyślnie slajdy normalne, master i układy. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), aby przetworzyć każdy kształt od razu za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), gdy potrzebujesz iterowalnego wyniku, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy w prezentacji znajdują się nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzane przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) należy wywołać [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertowanie prezentacji](/androidjava/convert-presentation/)
- [Łączenie prezentacji](/androidjava/merge-presentation/)
- [Master slajdu](/androidjava/slide-master/)
- [Zarządzanie polem tekstowym](/androidjava/manage-textbox/)
- [Osadzona czcionka](/androidjava/embedded-font/)