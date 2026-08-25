---
title: Operacje prezentacji w trybie low-code w Pythonie
linktitle: API low-code
type: docs
weight: 50
url: /pl/python-net/low-code-presentation-operations/
keywords:
- API low-code do prezentacji
- konwertowanie prezentacji
- scalanie prezentacji
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów master
- usuwanie nieużywanych slajdów układu
- kompresja wbudowanych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w Pythonie, aby konwertować i scalać prezentacje, zbierać kształty oraz zmniejszyć rozmiar prezentacji."
---
## **Przegląd**

Moduł [aspose.slides.lowcode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/) udostępnia klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki enkapsulują często używane przepływy pracy modelu obiektowego w dedykowanych metodach, dzięki czemu możesz konwertować lub scalać pliki, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/), gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, wzorcami, układami, kształtami, ustawieniami eksportu lub zależnościami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/) | Łączenie pełnych plików prezentacji w tym samym formacie. |
| [Collect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych wzorców i układów oraz zmniejszanie danych wbudowanych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.auto_by_extension](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą formatę na podstawie ścieżki wyjściowej i zapisuje wynik.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Klasa [Convert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/) udostępnia również dedykowane metody dla wyjścia PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której wybrany pomocnik nie udostępnia. Zobacz [Konwertowanie prezentacji](/slides/pl/python-net/convert-presentation/) aby poznać przepływy pracy i opcje specyficzne dla formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/process/), aby połączyć pełne pliki prezentacji jednoczesnym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy wzorzec lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Scalanie prezentacji](/slides/pl/python-net/merge-presentation/) dla takich scenariuszy.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz zbioru wszystkich kształtów w prezentacji. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, zliczany lub przetwarzany wielokrotnie.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Użyj bezpośrednich pętli zbierających, gdy ważne są kolejność przeglądania, wczesne zakończenie, filtrowanie przed przetwarzaniem lub szczegółowa kontrola relacji rodzic‑dziecko.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać dane wbudowanych czcionek:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) usuwa slajdy master, które nie są już używane.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) usuwa nieużywane znaki z wbudowanych czcionek.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który przestanie być referencjonowany po czyszczeniu układów, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych masterów, układów lub pełnych danych wbudowanych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/python-net/slide-master/) oraz [Embedded Font](/slides/pl/python-net/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować zależności master‑ów i układów, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/merger/process/) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.auto_by_extension](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), a następnie scal skonwertowane pliki.

**Co obejmuje Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/collect/shapes/) pobiera kształty z prezentacji, aby mogły być zachowane, filtrowane, liczone lub przeglądane wielokrotnie. Użyj bezpośrednich pętli zbierających, gdy potrzebujesz precyzyjnej kontroli nad tym, które typy slajdów lub zagnieżdżone obiekty są odwiedzane.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Niekoniecznie. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mastery lub wbudowane czcionki z nieużywanymi znakami. Jeśli żadne z nich nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) w pamięci. Po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/), wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertowanie prezentacji](/slides/pl/python-net/convert-presentation/)
- [Scalanie prezentacji](/slides/pl/python-net/merge-presentation/)
- [Slide Master](/slides/pl/python-net/slide-master/)
- [Manage Text Box](/slides/pl/python-net/manage-textbox/)
- [Embedded Font](/slides/pl/python-net/embedded-font/)