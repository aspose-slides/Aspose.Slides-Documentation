---
title: Operacje prezentacji low-code w Pythonie
linktitle: API low-code
type: docs
weight: 50
url: /pl/python-net/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- łączenie prezentacji
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów wzorca
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w języku Python do konwertowania i łączenia prezentacji, zbierania kształtów oraz zmniejszania rozmiaru prezentacji."
---
## **Przegląd**

Moduł [aspose.slides.lowcode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/) zapewnia klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki kapsułkują często używane przepływy pracy modelu obiektowego w skoncentrowanych metodach, dzięki czemu możesz konwertować lub scalać pliki, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najprzydatniejsze, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [Aspose.Slides object model](https://reference.aspose.com/slides/pl/python-net/aspose.slides/) gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, wzorcami, układami, kształtami, ustawieniami eksportu lub zależnościami pomiędzy elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/) | Konwertowanie prezentacji na inny format przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [Collect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych wzorców i układów oraz zmniejszanie osadzonych danych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.auto_by_extension](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Klasa [Convert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/) oferuje także dedykowane metody dla wyjścia w formatach PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/python-net/convert-presentation/) dla przepływów pracy i opcji specyficznych dla formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/process/), aby połączyć pełne pliki prezentacji jednym wywołaniem. Wejściowe prezentacje muszą mieć ten sam format pliku.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy wzorzec lub układ, zachować sekcje explicite, lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/python-net/merge-presentation/) dla takich scenariuszy.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Używaj bezpośrednich pętli kolekcji, gdy ważna jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed przetwarzaniem lub szczegółowa kontrola zależności rodzic‑dziecko.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać osadzone dane czcionek:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) usuwa slajdy wzorca, które nie są już używane.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) usuwa nieużywane znaki z osadzonych czcionek.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Usuń nieużywane układy przed nieużywanymi wzorcami, aby wzorzec, który po czyszczeniu układów stanie się niepowiązany, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych wzorców, układów lub pełnych osadzonych danych czcionek. Po więcej szczegółów zobacz [Slide Master](/python-net/slide-master/) i [Embedded Font](/python-net/embedded-font/).

## **FAQ**

**Kiedy powinienem używać interfejsu low-code zamiast pełnego modelu obiektowego?**  
Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać określone slajdy, kontrolować zależności wzorca i układu, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**  
Nie. [Merger.process](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/process/) wymaga, aby wejściowe prezentacje były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.auto_by_extension](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), a następnie scal skonwertowane pliki.

**Co zawiera Collect.shapes?**  
[Collect.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/shapes/) pobiera kształty z prezentacji, aby można je było zachować, filtrować, liczyć lub przeglądać wielokrotnie. Używaj bezpośrednich pętli kolekcji, gdy potrzebna jest precyzyjna kontrola, które typy slajdów lub zagnieżdżone obiekty są odwiedzane.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**  
Nie zawsze. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane wzorce lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez Compress są zapisywane automatycznie?**  
Nie. Te pomocniki działają na wczytanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)