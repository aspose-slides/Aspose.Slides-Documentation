---
title: Konwertuj prezentacje PowerPoint do HTML w Pythonie via Java
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
description: "Konwertuj prezentacje PowerPoint do HTML w Pythonie via Java. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG i multimediów."
---
## **Przegląd**

Aspose.Slides for Python via Java może zapisywać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja to jednorazowe wczytanie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wywołanie [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z podaniem [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) kiedy potrzebujesz kontrolować układ, czcionki, obrazy, notatki, komentarze, wyjście SVG lub powiązane zasoby.

Ten przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksport całej prezentacji lub wybranych slajdów.
- Generowanie HTML o stałym układzie, responsywnego lub opartego na SVG.
- Dołączanie notatek prelegenta i komentarzy.
- Kontrola jakości obrazu i przyciętych danych obrazów.
- Osadzanie czcionek lub zapisywanie plików czcionek osobno.
- Wybór sposobu zapisu i odwoływania się do zewnętrznych zasobów oraz plików multimedialnych.

Domyślnie eksport HTML tworzy dokument HTML samodzielny, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższą DPI obrazu i osadzanie tylko czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertuj prezentację do HTML**

Aby wyeksportować prezentację do HTML, wczytaj ją za pomocą [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat.Html](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Html).

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

Każdy przykład wczytuje `presentation.pptx` z bieżącego katalogu roboczego. Zainstaluj Aspose.Slides for Python via Java oraz kompatybilną maszynę wirtualną Javy przed uruchomieniem. JVM jest uruchamiana raz na proces Pythona.

Ten przykład zapisuje jeden plik HTML. Obiekt prezentacji jest zwalniany w bloku `finally`, co zwalnia uchwyty do plików i zasoby renderowania po eksporcie.

## **Konfiguracja eksportu HTML**

[HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) jest główną klasą konfiguracyjną dla eksportu HTML. Typowe ustawienia obejmują:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): dodaje notatki, komentarze, materiały pomocnicze lub inne informacje układu.
- [setHtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setHtmlFormatter): zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- [setSlideImageFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlideImageFormat): zmienia sposób reprezentacji slajdów, np. jako SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression): steruje DPI obrazu i rozmiarem wyjścia.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): zachowuje lub usuwa przycięte dane obrazów.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): włącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje prezentują najczęstsze opcje osobno, aby można było połączyć tylko te potrzebne w danym przepływie pracy.

## **Konwertuj wybrane slajdy do HTML**

Przeciążenie [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), które przyjmuje numery slajdów, używa 1‑opartych pozycji slajdów. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

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

Użyj tego wzorca, gdy strona internetowa lub aplikacja potrzebuje jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) i przekaż ją do każdego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save).

## **Utwórz responsywny HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/responsivehtmlcontroller/) zapewnia responsywny kod HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

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

Dla responsywnego układu opartego na SVG, wywołaj [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) z wartością `True`. Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

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

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) poprzez [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycje.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje zawartość slajdu wraz z notatkami prelegenta pod slajdem.

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

![Wyjście HTML z slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, wywołaj [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), np. z [CommentsPositions.Right](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commentspositions/#Right) lub [CommentsPositions.Bottom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commentspositions/#Bottom). Jeśli potrzebujesz tylko komentarze, pomiń [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Jeśli potrzebujesz zarówno notatki, jak i komentarze, wywołaj obie metody.

## **Kontrola jakości obrazu i przyciętych obszarów**

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

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyjścia. Zachowaj przycięte dane tylko wtedy, gdy użytkownicy muszą móc je odzyskać lub zbadać. Zachowanie ich może zwiększyć rozmiar HTML.

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

Dla prostego stylowania przekaż ciąg CSS do [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

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

Aby dodać własny nagłówek dokumentu, podlinkowany plik CSS lub własny znacznik wokół slajdów i kształtów, użyj własnego kontrolera formatowania poprzez proxy interfejsu JPype i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/) przy pomocy [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Osadź czcionki**

Jeśli w docelowym środowisku mogą nie być zainstalowane czcionki użyte w prezentacji, osadź czcionki w HTML przy pomocy [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

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

Wykluczaj czcionki tylko wtedy, gdy masz pewność, że docelowe przeglądarki lub systemy już je zapewniają. Dla czcionek firmowych lub rzadziej spotykanych osadzanie jest zazwyczaj bezpieczniejsze.

## **Zapisz zasoby zewnętrznie**

HTML samodzielny jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą znacznie zwiększyć plik. Jeśli aplikacja wymaga zewnętrznych plików obrazów, zaimplementuj kontroler łączenia zasobów poprzez proxy interfejsu JPype i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/).

Externalizując zasoby, wybierz dwa ścieżki świadomie:

- Ścieżka wyjściowa systemu plików, gdzie aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, której przeglądarka używa z dokumentu HTML do ładowania tych plików.

## **Eksportuj pliki multimedialne**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz generuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym będą zapisywane wygenerowane pliki multimedialne.
- `fileName`: nazwa pliku HTML, który jest generowany.
- `baseUri`: absolutny prefiks URI używany w linkach HTML do plików multimedialnych.

Poniższy przykład eksportuje media już osadzone w `presentation.pptx`. Wygenerowany HTML odwołuje się do plików multimedialnych jedynie po nazwie pliku, względnie do dokumentu HTML, więc `path` musi być katalogiem, w którym także zostanie zapisany plik HTML. `baseUri` musi być absolutnym URI: do podglądu lokalnego zbuduj URI `file:///` z katalogu wyjściowego; w aplikacji wdrożonej użyj bezwzględnego URL opublikowanego katalogu.

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

Używaj katalogów wyjściowych unikalnych dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML jest operacją renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych mediów. Wyższe wartości DPI obrazu przekazywane do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression), osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Podczas konwersji wsadowej:

- Szybko zwalniaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla oddzielnych zadań.
- Unikaj osadzania popularnych czcionek, chyba że wymagana jest maksymalna wierność.
- Obniż DPI obrazu, gdy HTML ma służyć podglądowi lub miniaturkom.
- Przechowuj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż do ustalenia ostatecznych ścieżek wdrożenia.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściu HTML?**

Tak. Hiperłącza w prezentacji są eksportowane do HTML i pozostają klikalne, pod warunkiem że docelowy adres URL jest ważny.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie udostępniaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) pomiędzy wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [multithreading guidance](/slides/pl/python-java/multithreading/) po szczegóły.

**Czy obiekt prezentacji jest wątkowo‑bezpieczny?**

Nie. Jedna instancja [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) powinna być wczytana, modyfikowana, zapisana i zwolniona w jednym wątku. Do pracy równoległej twórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy o wysokiej DPI, multimedia, zawartość SVG i zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz popularne czcionki z osadzania i przekaż niższą wartość DPI do [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setPicturesCompression), gdy mniejszy rozmiar jest ważniejszy niż maksymalna wierność.

**Dlaczego wartości `font-size` w HTML różnią się od wartości w PowerPoint?**

Wyeksportowana strona może używać systemów współrzędnych SVG i przekształceń skalowania. Sama wartość CSS lub SVG `font-size` nie opisuje ostatecznego wyświetlanego rozmiaru. Porównaj renderowany slajd przy zamierzonym poziomie powiększenia i sprawdź dostępność czcionek, jeśli tekst wygląda inaczej.

**Jak wybrać `baseUri` dla eksportu multimediów?**

Wybierz `baseUri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz go uzyskać z katalogu wyjściowego, np. `output_directory.as_uri() + "/"`. W przypadku wdrożenia użyj bezwzględnego URL opublikowanego katalogu. Ścieżka systemowa `path` i przeglądarkowa `baseUri` nie muszą być tym samym ciągiem, ale muszą opisywać to samo miejsce, które musi być katalogiem zawierającym wygenerowany plik HTML, ponieważ linki multimedialne są zapisywane względem niego.

**Czy mogę uwzględnić ukryte slajdy?**

Tak. Wywołaj [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) z wartością `True`, gdy ukryte slajdy muszą być eksportowane.