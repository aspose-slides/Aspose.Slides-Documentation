---
title: Operacje prezentacji low-code w Pythonie za pośrednictwem Java
linktitle: API low-code
type: docs
weight: 50
url: /pl/python-java/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- scalanie prezentacji
- iterowanie slajdów
- iterowanie kształtów
- iterowanie tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych master‑slajdów
- usuwanie nieużywanych układów slajdów
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w Pythonie przez Java, aby konwertować i scalać prezentacje, iterować zawartość, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/pl/python-java/aspose.slides/) zapewnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocnice opakowują często używane przepływy pracy modelu obiektowego w skoncentrowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocnice low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [Aspose.Slides object model](https://reference.aspose.com/slides/pl/python-java/aspose.slides/), gdy potrzebna jest szczegółowa kontrola nad poszczególnymi slajdami, masterami, układami, kształtami, ustawieniami eksportu lub relacjami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocnice:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/python-java/aspose.slides/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/python-java/aspose.slides/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/collect/) | Pobieranie kształtów z całej prezentacji w celu powtarzalnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/) | Usuwanie nieużywanych masterów i układów oraz zmniejszanie osadzonych danych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert.autoByExtension](https://reference.aspose.com/slides/pl/python-java/aspose.slides/convert/#autoByExtension), gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymaganą formatację na podstawie ścieżki wyjściowej i zapisuje wynik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Klasa [Convert](https://reference.aspose.com/slides/pl/python-java/aspose.slides/convert/) udostępnia także dedykowane metody dla wyjścia w formatach PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy potrzebujesz przejrzeć lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrana pomocnica. Zobacz [Convert Presentation](/slides/pl/python-java/convert-presentation/) po szczegółowe przepływy pracy i opcje specyficzne dla formatu.

## **Scalanie prezentacji**

Użyj [Merger.process](https://reference.aspose.com/slides/pl/python-java/aspose.slides/merger/#process), aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Ta pomocnica jest odpowiednia, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy musisz scalać wybrane slajdy, zastosować docelowego mastera lub układ, zachować sekcje w sposób jawny lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/slides/pl/python-java/merge-presentation/) w tych scenariuszach.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania obejmujących całą prezentację.

Poniższy przykład używa [ForEach.slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#paragraph) oraz [ForEach.portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#portion) do inspekcji odpowiadających elementów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Domyślnie, przegląd kształtów i tekstu w całej prezentacji obejmuje normalne, masterowe i układowe slajdy. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy istotny jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola zależności rodzic-dziecko.

## **Zbieranie kształtów**

Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/collect/#shapes), gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, liczony lub przetwarzany wielokrotnie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#shape) zamiast tego, gdy każdy kształt może być obsłużony od razu i nie musisz zachować zebranego wyniku.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać osadzone dane czcionek:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedMasterSlides) usuwa master‑slajdy, które nie są już używane.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#compressEmbeddedFonts) usuwa nieużywane znaki z osadzonych czcionek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który po czyszczeniu układów stanie się nieodwołany, również został usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później będziesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/python-java/slide-master/) oraz [Embedded Font](/slides/pl/python-java/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocniczych funkcji low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować relacje master‑layout, przejrzeć stan pośredni lub skonfigurować zachowanie, które nie jest udostępnione przez pomocnicę.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.process](https://reference.aspose.com/slides/pl/python-java/aspose.slides/merger/#process) wymaga, aby prezentacje wejściowe miały ten sam format. Najpierw przekształć pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.autoByExtension](https://reference.aspose.com/slides/pl/python-java/aspose.slides/convert/#autoByExtension), a następnie scali je.

**Czy ForEach przetwarza slajdy master, układ i notatki?**

[ForEach.slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#slide) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#paragraph) i [ForEach.portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#portion) obejmują domyślnie normalne, masterowe i układowe slajdy. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `True`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.shape a Collect.shapes?**

Użyj [ForEach.shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/foreach/#shape), aby przetwarzać każdy kształt od razu za pomocą funkcji zwrotnej. Użyj [Collect.shapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/collect/#shapes), gdy potrzebujesz iterowalnego wyniku, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadna z tych rzeczy nie występuje, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocnice działają na załadowanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Po zmianie elementów w wywołaniu zwrotnym [ForEach] lub po wykonaniu [Compress](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/), wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/slides/pl/python-java/convert-presentation/)
- [Merge Presentations](/slides/pl/python-java/merge-presentation/)
- [Slide Master](/slides/pl/python-java/slide-master/)
- [Manage Text Box](/slides/pl/python-java/manage-textbox/)
- [Embedded Font](/slides/pl/python-java/embedded-font/)