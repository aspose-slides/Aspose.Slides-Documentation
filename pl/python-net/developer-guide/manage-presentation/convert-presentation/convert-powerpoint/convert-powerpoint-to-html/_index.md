---
title: Konwertowanie prezentacji PowerPoint do HTML w Pythonie
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /pl/python-net/convert-powerpoint-to-html/
keywords:
- konwersja PowerPoint
- konwersja prezentacji
- konwersja slajdu
- konwersja PPT
- konwersja PPTX
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
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do HTML w Pythonie. Użyj Aspose.Slides do eksportu plików PPT i PPTX, wybranych slajdów, notatek, czcionek, obrazów, SVG oraz multimediów."
---
## **Przegląd**

Aspose.Slides for Python via .NET może zapisać prezentacje PowerPoint jako HTML bez Microsoft PowerPoint. Podstawowa konwersja polega na jednorazowym załadowaniu [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wywołaniu `save` z [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/). Użyj [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) gdy potrzebujesz kontrolować układ eksportu, czcionki, obrazy, notatki, komentarze, wyjście SVG lub połączone zasoby.

Ten przewodnik koncentruje się na praktycznych scenariuszach eksportu HTML:

- Eksport całej prezentacji lub wybranych slajdów.
- Generowanie HTML o stałym układzie, responsywnego lub opartego na SVG.
- Dołączanie notatek prelegenta i komentarzy.
- Kontrola jakości obrazu oraz przyciętych danych obrazów.
- Osadzanie czcionek lub zapisywanie plików czcionek osobno.
- Wybór sposobu zapisu i odwołań do zasobów zewnętrznych i plików multimedialnych.

Domyślnie eksport HTML tworzy samodzielny dokument HTML, w którym większość zasobów jest osadzona. Jest to wygodne przy udostępnianiu jednego pliku, ale może zwiększyć rozmiar wyjścia. Przy publikacji w sieci rozważ użycie zasobów zewnętrznych, niższego DPI obrazów oraz osadzanie tylko tych czcionek, które nie są pewnie dostępne w docelowym środowisku.

## **Konwertowanie prezentacji do HTML**

Aby wyeksportować prezentację do HTML, załaduj ją przy pomocy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i zapisz przy użyciu [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Ten przykład zapisuje jeden plik HTML. Instrukcja `with` zwalnia obiekt prezentacji oraz zwalnia uchwyty do plików i zasoby renderowania po eksporcie.

## **Użycie HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) jest główną klasą konfiguracyjną eksportu HTML. Typowe ustawienia obejmują:

- `slides_layout_options`: dodaje notatki, komentarze, materiały rozdawnicze lub inne informacje o układzie.
- `html_formatter`: zmienia strukturę dokumentu HTML lub deleguje formatowanie do kontrolera.
- `slide_image_format`: zmienia sposób reprezentacji slajdów, na przykład jako SVG.
- `pictures_compression`: kontroluje DPI obrazu i rozmiar wyjścia.
- `delete_pictures_cropped_areas`: zachowuje lub usuwa przycięte dane obrazów.
- `svg_responsive_layout`: sprawia, że wyeksportowana zawartość SVG dostosowuje się do swojego kontenera.
- `show_hidden_slides`: dołącza ukryte slajdy, gdy jest to wymagane.

Poniższe sekcje pokazują najpopularniejsze opcje osobno, abyś mógł łączyć tylko te potrzebne w twoim przepływie pracy.

## **Konwertowanie wybranych slajdów do HTML**

Przeciążenie `save`, które przyjmuje numery slajdów, używa numeracji od 1. Pętla poniżej zapisuje każdy slajd do osobnego pliku HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Użyj tego wzorca, gdy strona internetowa lub aplikacja wymaga jednej strony HTML na slajd. Jeśli każdy slajd ma mieć ten sam układ, utwórz jedną instancję [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) i przekaż ją do każdego wywołania `save`.

## **Tworzenie responsywnego HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/responsivehtmlcontroller/) zapewnia responsywny wynik HTML poprzez [HtmlFormatter](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmlformatter/). Użyj go, gdy wyeksportowana strona ma lepiej dostosowywać się do szerokości przeglądarki.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Aby uzyskać responsywny układ oparty na SVG, ustaw `svg_responsive_layout` w [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/). Jest to przydatne, gdy zawartość slajdu jest eksportowana jako skalowalny znacznik SVG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Dołączanie notatek prelegenta i komentarzy**

Użyj [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) poprzez `html_options.slides_layout_options`, aby dołączyć notatki prelegenta lub komentarze. Notatki i komentarze są domyślnie ukryte, chyba że określisz ich pozycję.

Załóżmy, że źródłowa prezentacja zawiera notatki prelegenta:

![Slajd z notatkami prelegenta w PowerPoint](slide_with_notes.png)

Poniższy kod eksportuje zawartość slajdu wraz z notatkami prelegenta pod slajdem.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Wyeksportowany HTML zawiera obszar notatek:

![Wyjście HTML ze slajdem i notatkami prelegenta](HTML_with_notes.png)

Aby wyeksportować komentarze, ustaw `comments_position`, na przykład na `CommentsPositions.RIGHT` lub `CommentsPositions.BOTTOM`. Jeśli potrzebujesz tylko komentarzy, pomiń `notes_position`. Jeśli potrzebujesz zarówno notatek, jak i komentarzy, ustaw obie właściwości.

## **Kontrola jakości obrazu i przyciętych obszarów**

Eksport HTML może kompresować obrazy slajdów, aby zmniejszyć rozmiar wyjścia. Ustaw `pictures_compression` na wartość z [PicturesCompression](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/picturescompression/), gdy potrzebujesz wyższej jakości obrazu.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Domyślnie przycięte obszary obrazów mogą być usuwane z wyeksportowanego wyjścia. Zachowuj przycięte dane tylko wtedy, gdy użytkownicy muszą mieć możliwość ich odzyskania lub przeglądania. Zachowanie ich może zwiększyć rozmiar HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Dodawanie CSS**

Dla prostego stylowania przekaż ciąg CSS do [HtmlFormatter](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmlformatter/). Zmienia to otaczający dokument HTML, podczas gdy Aspose.Slides nadal renderuje zawartość slajdu.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Aby dodać własny nagłówek dokumentu, połączony plik CSS lub własny znacznik wokół slajdów i kształtów, użyj własnego kontrolera formatowania i przekaż go do [HtmlFormatter](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmlformatter/) przy pomocy `create_custom_formatter`.

## **Osadzanie czcionek**

Jeśli w docelowym środowisku mogą nie być zainstalowane czcionki użyte w prezentacji, osadź czcionki w HTML przy użyciu [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Osadzanie poprawia wierność wizualną, ale zwiększa rozmiar wyjścia.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Wyklucz czcionkę tylko wtedy, gdy jesteś pewny, że docelowe przeglądarki lub systemy już ją dostarczają. W przypadku czcionek firmowych lub rzadziej używanych, osadzanie jest zazwyczaj bezpieczniejsze.

## **Linkowanie plików czcionek zamiast ich osadzania**

Aby zmniejszyć rozmiar pliku HTML, możesz zapisać dane czcionek w oddzielnych plikach WOFF i dodać reguły `@font-face` do HTML. Wymaga to kontrolera, który dostosowuje sposób zapisu danych czcionki podczas eksportu. W Pythonie via .NET zaimplementuj taki kontroler w małym zestawie pomocy .NET, załaduj go w Pythonie i przekaż obiekt pomocy do [HtmlFormatter](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmlformatter/) przy pomocy `create_custom_formatter`.

Kiedy externalizujesz czcionki, wybierz dwa ścieżki świadomie:

- Katalog wyjściowy w systemie plików, w którym zostaną zapisane wygenerowane pliki WOFF.
- Ścieżka URL, która pojawi się w dokumencie HTML i którą przeglądarka użyje do załadowania tych plików czcionek.

Trzymaj plik HTML i wygenerowane pliki czcionek razem, aż ścieżki wdrożeniowe będą ostateczne. Jeśli pliki zostaną wdrożone w innym miejscu, dopasuj prefiks URL do faktycznej ścieżki URL.

## **Zapis zasobów zewnętrznie**

Samodzielny HTML jest łatwy do przenoszenia, ale osadzone zasoby Base64 mogą sprawić, że plik będzie duży. Jeśli aplikacja potrzebuje zewnętrznych plików obrazu, czcionki, audio lub wideo, użyj własnego kontrolera link/ embed i przekaż go do konstruktora [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/).

Kiedy externalizujesz zasoby, wybierz dwa ścieżki świadomie:

- Ścieżka wyjściowa w systemie plików, gdzie aplikacja zapisuje wygenerowane obrazy, czcionki, audio lub wideo.
- Ścieżka URL, której przeglądarka używa z dokumentu HTML do ładowania tych plików.

Po pełną dyskusję na temat linkowania obrazów znajdziesz w [Export Presentations to HTML with Externally Linked Images](/slides/pl/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Eksport plików multimedialnych**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/videoplayerhtmlcontroller/) eksportuje pliki wideo i audio oraz generuje HTML, który może je odtwarzać w przeglądarce. Jego konstruktor przyjmuje:

- `path`: katalog, w którym zostaną zapisane wygenerowane pliki multimedialne.
- `file_name`: nazwa generowanego pliku HTML.
- `base_uri`: absolutny prefiks URI używany w odnośnikach HTML do plików multimedialnych.

Jeśli plik HTML znajduje się w `html-output/presentation.html`, a pliki multimedialne w `html-output/media`, `path` powinien wskazywać katalog multimedialny na dysku, natomiast `base_uri` powinien wskazywać ten sam katalog z perspektywy przeglądarki. Do podglądu lokalnego możesz zbudować URI `file:///` z katalogu multimedialnego. Dla wdrożonej aplikacji użyj absolutnego URL opublikowanego katalogu multimedialnego.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Używaj katalogów wyjściowych, które są unikalne dla każdego zadania eksportu, szczególnie w aplikacjach serwerowych. Wspólne ścieżki wyjściowe mogą powodować nadpisywanie plików z różnych konwersji.

## **Wydajność i zarządzanie zasobami**

Konwersja HTML to operacja renderowania, więc czas przetwarzania i zużycie pamięci zależą od liczby slajdów, rozdzielczości obrazów, czcionek, efektów, wykresów i osadzonych multimediów. Wyższe wartości DPI w `pictures_compression`, osadzone czcionki, wyjście SVG i zachowane przycięte obszary obrazów mogą poprawić wierność, ale zazwyczaj zwiększają rozmiar wyjścia.

Dla konwersji wsadowej:

- Szybko zwalniaj każdą instancję [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
- Używaj oddzielnych katalogów wyjściowych dla oddzielnych zadań.
- Unikaj osadzania popularnych czcionek, chyba że wymaga tego wierność.
- Obniż DPI obrazów, gdy HTML ma służyć podglądowi lub miniaturkom.
- Trzymaj źródłową prezentację, wygenerowany HTML i zasoby zewnętrzne razem, aż ścieżki wdrożeniowe będą ostateczne.

## **FAQ**

**Czy hiperłącza są zachowywane w wyjściu HTML?**

Tak. Hiperłącza z prezentacji są eksportowane do HTML i pozostają klikalne, gdy docelowy URL jest prawidłowy.

**Czy mogę konwertować prezentacje do HTML równolegle?**

Tak, ale nie współdziel jednego obiektu [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) między wątkami. Przetwarzaj różne pliki przy użyciu oddzielnych instancji prezentacji, oddzielnych strumieni i oddzielnych katalogów wyjściowych. Zobacz [multithreading guidance](/slides/pl/python-net/multithreading/) po szczegóły.

**Czy obiekt Presentation jest wątkowo‑bezpieczny?**

Nie. Jedna instancja [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) powinna być ładowana, modyfikowana, zapisywana i zwalniana w jednym wątku. Do pracy równoległej utwórz niezależną instancję na każdy wątek lub proces.

**Dlaczego wygenerowany plik HTML jest duży?**

Domyślny eksport może osadzać zasoby bezpośrednio w HTML. Osadzone czcionki, obrazy wysokiego DPI, multimedia, zawartość SVG oraz zachowane przycięte obszary obrazów również zwiększają rozmiar. Użyj zasobów zewnętrznych, wyklucz częste czcionki z osadzania i obniż `pictures_compression`, gdy mniejszy rozmiar wyjścia jest ważniejszy niż maksymalna wierność.

**Dlaczego rozmiar czcionki PowerPoint 24 pt pojawia się jako 17.999819 pt w HTML?**

Może to wynikać z różnych modeli DPI w PowerPoint i HTML. PowerPoint przechowuje rozmiary tekstu w punktach typograficznych opartych na 72 DPI, podczas gdy układ HTML opiera się na pikselach CSS w modelu 96 DPI. Gdy Aspose.Slides eksportuje prezentację do HTML, rozmiar czcionki jest przeliczany między tymi systemami, co może wprowadzać niewielkie różnice zaokrągleń.

Te wartości nie oznaczają rzeczywistej zmiany widocznego rozmiaru czcionki. Są to jedynie matematyczne skutki uboczne konwersji metryk tekstu między PowerPoint a HTML.

**Jak powinienem wybrać base_uri dla eksportu multimediów?**

Wybierz `base_uri` z perspektywy przeglądarki i przekaż go jako absolutny URI. Do podglądu lokalnego możesz go uzyskać z katalogu wyjściowego przy pomocy `Path(media_directory).as_uri() + "/"`. Dla wdrożenia użyj absolutnego URL opublikowanego katalogu multimedialnego. System plików `path` i przeglądarkowy `base_uri` nie muszą być tymi samymi ciągami, ale muszą opisywać to samo położenie zasobu.

**Czy mogę dołączyć ukryte slajdy?**

Tak. Ustaw `show_hidden_slides = True` w [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/), gdy ukryte slajdy muszą być eksportowane.