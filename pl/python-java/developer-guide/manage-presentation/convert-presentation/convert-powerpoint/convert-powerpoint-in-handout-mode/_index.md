---
title: Konwertuj prezentacje PowerPoint w trybie rozdania przy użyciu Pythona
linktitle: Tryb rozdania
type: docs
weight: 150
url: /pl/python-java/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb rozdania
- rozdanie
- PPT
- PPTX
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na rozdania w Pythonie za pośrednictwem Javy. Układaj wiele slajdów na jednej stronie i eksportuj do PDF przy użyciu Aspose.Slides."
---
## **Wstęp**

Aspose.Slides for Python via Java umożliwia eksportowanie prezentacji w trybie rozdania, układając wiele slajdów na jednej stronie. Jest to przydatne przy drukowaniu materiałów prezentacyjnych na konferencje, seminaria i podobne wydarzenia.

Układ można skonfigurować za pomocą metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Układy rozdania są obsługiwane przez [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/). Użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handoutlayoutingoptions/) aby określić ustawienia układu i wyświetlania.

Aby ustawić wymiary i orientację strony rozdania przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/python-java/notes-size/).

## **Eksport w trybie rozdania**

Aby wyeksportować prezentację w trybie rozdania, utwórz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handoutlayoutingoptions/) i przypisz ją do docelowych opcji eksportu za pomocą [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Poniższy przykład ładuje `sample.pptx` i eksportuje go do PDF z czterema slajdami na stronie w kolejności poziomej. Zawiera numerację slajdów i ramki wokół slajdów oraz pomija komentarze.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Załaduj prezentację.
presentation = Presentation("sample.pptx")
try:
    # Skonfiguruj układ rozdania.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Wyeksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Ustawienia układu rozdania dotyczą obsługiwanych formatów wyjściowych, takich jak PDF, HTML, TIFF i renderowane obrazy. Nie przestawiają one slajdów w źródłowej prezentacji.
{{% /alert %}}

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronę w trybie rozdania?**

Aspose.Slides obsługuje maksymalnie dziewięć miniatur na stronę. Predefiniowane ustawienia [HandoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handouttype/) oferują jedną, dwie, trzy, cztery, sześć lub dziewięć slajdów na stronę. Ustawienia czterech, sześciu i dziewięciu slajdów umożliwiają kolejność poziomą i pionową.

**Czy mogę zdefiniować własną siatkę, np. pięć lub osiem slajdów na stronę?**

Nie. Liczba i kolejność miniatur są kontrolowane przez predefiniowane wartości [HandoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handouttype/). Losowe siatki nie są obsługiwane przez te ustawienia układu rozdania.

**Czy mogę uwzględnić ukryte slajdy w wyjściu rozdania?**

Tak. Włącz ukryte slajdy w ustawieniach eksportu dla docelowego formatu. Dla PDF wywołaj [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z wartością `True` przed zapisaniem prezentacji.