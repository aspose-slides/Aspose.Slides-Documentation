---
title: Konwertuj prezentacje w trybie Handout przy użyciu Pythona
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/python-net/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- handout
- PowerPoint
- prezentacja
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konwertuj prezentacje do handoutów w Pythonie. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji do różnych formatów, w tym tworzenia notatek do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów pojawia się na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając właściwość `slides_layout_options` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/), oraz [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/) classes.

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/python-net/notes-size/).

## **Eksport trybu Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handoutlayoutingoptions/), który określa, ile slajdów jest umieszczanych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do formatu PDF w trybie Handout.

```py
import aspose.slides as slides

# Wczytaj prezentację.
with slides.Presentation("sample.pptx") as presentation:

    # Ustaw opcje eksportu.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slajdy na jednej stronie w poziomie
    slides_layout_options.print_slide_numbers = True                                 # wydrukuj numery slajdów
    slides_layout_options.print_frame_slide = True                                   # wydrukuj ramkę wokół slajdów
    slides_layout_options.print_comments = False                                     # bez komentarzy

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Wyeksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Pamiętaj, że właściwość `slides_layout_options` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **Najczęściej zadawane pytania**

**Jaka jest maksymalna liczba miniatur slajdów na jednej stronie w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/) do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, taką jak 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyniku Handout?**

Tak. Włącz opcję `show_hidden_slides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/), lub [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).