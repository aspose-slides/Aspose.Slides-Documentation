---
title: Konwertowanie prezentacji PowerPoint do HTML w Pythonie przy użyciu Java
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/python-java/convert-powerpoint-to-html/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- zapisz PowerPoint jako HTML
- zapisz prezentację jako HTML
- zapisz slajd jako HTML
- zapisz PPT jako HTML
- zapisz PPTX jako HTML
- eksportuj PPT do HTML
- eksportuj PPTX do HTML
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w Pythonie przy użyciu Java. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG i multimediów."
---
## **Przegląd**

Aspose.Slides for Python via Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja to jednorazowe wczytanie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wywołanie [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z użyciem [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) kiedy potrzebujesz kontrolować układ, czcionki, obrazy, notatki, komentarze, wyjście SVG lub zasoby powiązane.

Ten przewodnik skupia się na praktycznych scenariuszach eksportu HTML:

- Eksport całej prezentacji lub wybranych slajdów.
- Generowanie HTML o stałym układzie, responsywnym lub opartym na SVG.
- Dołączanie notatek prelegenta i komentarzy.
- Kontrola jakości obrazów i danych przyciętych obrazów.
- Osadzanie czcionek lub zapisywanie plików czcionek oddzielnie.
- Wybór sposobu zapisu i odwołań do zewnętrznych zasobów i plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. To wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjściowy. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższego DPI obrazów oraz osadzanie jedynie czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertuj prezentację do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją przy pomocy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Każdy przykład wczytuje `presentation.pptx` z bieżącego katalogu roboczego. Zainstaluj Aspose.Slides for Python via Java oraz kompatybilne środowisko Java przed uruchomieniem. JVM jest uruchamiana raz na proces Pythona.

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest usuwany w bloku `finally`, co zwalnia uchwyty plików i zasoby renderowania po eksporcie.

## **Konfiguracja eksportu HTML**

[HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) jest główną klasą konfiguracyjną eksportu HTML. Typowe ustawienia obejmują:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): dodaje notatki, komentarze, materiały rozdawnicze lub inne informacje układu.
- [setHtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setHtmlFormatter): zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- [setSlideImageFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlideImageFormat): zmienia sposób reprezentacji slajdów, np. jako SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression): steruje DPI obrazów i rozmiarem wyjściowym.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): zachowuje lub usuwa przycięte dane obrazów.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): sprawia, że wyeksportowana treść SVG dostosowuje się do swojego kontenera.
- [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): włącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje przedstawiają najpopularniejsze opcje oddzielnie, abyś mógł łączyć tylko te, które są potrzebne w Twoim przepływie pracy.

## **Konwertuj wybrane slajdy do HTML**

Przeciążenie [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), które przyjmuje numery slajdów, używa pozycji numerowanych od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć taki sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) i przekaż ją do każdego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save).

## **Utwórz responsywny HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/responsivehtmlcontroller/) zapewnia responsywny wynik HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Aby uzyskać responsywny układ oparty na SVG, wywołaj [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) z wartością `True`. Jest to przydatne, gdy treść slajdu jest eksportowana jako skalowalny znacznik SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Dołącz notatki prelegenta i komentarze**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) przez [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje treść slajdu z notatkami prelegenta pod slajdem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Wyeksportowany HTML zawiera obszar notatek:

![Wyjściowy HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, wywołaj [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), np. z [CommentsPositions.Right](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commentspositions/#Right) lub [CommentsPositions.Bottom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commentspositions/#Bottom). Jeśli potrzebujesz tylko komentarzy, pomiń [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Jeśli potrzebujesz zarówno notatek, jak i komentarzy, wywołaj obie metody.

## **Kontrola jakości obrazów i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Przekaż wartość do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression) z [PicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturescompression/), gdy potrzebna jest wyższa jakość obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyniku. Zachowaj przycięte dane tylko wtedy, gdy użytkownicy muszą móc odzyskać lub przejrzeć te ukryte części obrazu. Zachowanie ich może zwiększyć rozmiar HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Dodaj CSS**

Dla prostej stylizacji przekaż ciąg CSS do [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Zmieni to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Aby dodać własny nagłówek dokumentu, połączony plik CSS lub własny znacznik wokół slajdów i kształtów, użyj własnego kontrolera formatowania przez proxy interfejsu JPype i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/) przy pomocy [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Osadź czcionki**

Jeśli w docelowym środowisku czcionki prezentacji mogą nie być zainstalowane, osadź je w HTML przy pomocy [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Wyklucz czcionki tylko wtedy, gdy masz pewność, że docelowe przeglądarki lub systemy już je zapewniają. Dla czcionek firmowych lub mniej popularnych osadzanie jest zwykle bezpieczniejsze.

## **Zapisz zasoby zewnętrznie**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą sprawić, że plik będzie duży. Jeśli aplikacja wymaga zewnętrznych plików obrazów, zaimplementuj kontroler łączenia zasobów przez proxy interfejsu JPype i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/).

Podczas externalizacji zasobów wybierz dwie ścieżki świadomie:

- Ścieżka systemu plików, w której aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, którą przeglądarka używa z dokumentu HTML do ładowania tych plików.

## **Eksportuj pliki multimedialne**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz generuje HTML, który może je odtworzyć w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym zostaną zapisane wygenerowane pliki multimedialne.
- `fileName`: nazwa generowanego pliku HTML.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Poniższy przykład eksportuje multimedia już osadzone w `presentation.pptx`. Generowany HTML odwołuje się do plików multimedialnych wyłącznie po nazwie pliku, względnie względem dokumentu HTML, więc `path` musi być katalogiem, w którym również zostanie zapisany plik HTML. `baseUri` musi być absolutnym URI: do lokalnego podglądu zbuduj URI `file:///` z katalogu wyjściowego; dla aplikacji wdrożonych użyj bezwzględnego adresu URL publikowanego katalogu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Używaj katalogów wyjściowych unikatowych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML to operacja renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI obrazu przekazywane do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression), osadzone czcionki, wyjście SVG oraz zachowane przycięte obszary obrazów mogą poprawić wierność, ale zwykle zwiększają rozmiar wyjścia.

Przy konwersji wsadowej:

- Niezwłocznie zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla oddzielnych zadań.
- Unikaj osadzania popularnych czcionek, chyba że wymaga tego wierność.
- Obniż DPI obrazów, gdy HTML służy do podglądu lub miniatur.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż ścieżki wdrożeniowe będą ostateczne.

## **FAQ**

**Czy hiperłączka są zachowywane w wyjściu HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy adres URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie udostępniaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) między wątkami. Przetwarzaj różne pliki w oddzielnych instancjach prezentacji, osobnych strumieniach i oddzielnych katalogach wyjściowych. Zobacz [multithreading guidance](/slides/pl/python-java/multithreading/) po szczegóły.

**Czy obiekt prezentacji jest wątkowo‑bezpieczny?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) powinna być wczytana, zmodyfikowana, zapisana i zwolniona w jednym wątku. Do pracy równoległej twórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy wysokiego DPI, multimedia, treść SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz powszechne czcionki z osadzania i przekaż niższą wartość DPI do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression), gdy mniejszy rozmiar wyjścia jest ważniejszy niż maksymalna wierność.

**Dlaczego wartości font‑size w HTML różnią się od wartości w PowerPoint?**

Wyeksportowana strona może używać systemów współrzędnych SVG i transformacji skalowania. Sama wartość CSS lub SVG font‑size nie opisuje ostatecznego rozmiaru wyświetlanego. Porównaj renderowany slajd przy zamierzonym poziomie powiększenia i sprawdź dostępność czcionek, jeśli tekst wygląda inaczej.

**Jak wybrać baseUri dla eksportu multimediów?**

Wybierz `baseUri` z punktu widzenia przeglądarki i przekaż go jako absolutny URI. Do lokalnego podglądu możesz go wyprowadzić z katalogu wyjściowego jako `output_directory.as_uri() + "/"`. Dla wdrożenia użyj bezwzględnego adresu URL publikowanego katalogu. Ścieżka systemowa `path` i przeglądarkowa `baseUri` nie muszą być tym samym ciągiem, ale muszą opisywać to samo miejsce, które musi być katalogiem zawierającym wygenerowany plik HTML, ponieważ odnośniki multimedialne są zapisywane względem niego.

**Czy mogę dołączyć ukryte slajdy?**

Tak. Wywołaj [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) z wartością `True`, gdy ukryte slajdy muszą być wyeksportowane.