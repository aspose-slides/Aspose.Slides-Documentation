---
title: Konwertowanie prezentacji w trybie Handout przy użyciu Pythona
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/python-net/convert-powerpoint-in-Handout-mode/
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
description: "Konwertuj prezentacje do wersji handout w Pythonie. Ustaw slajdy na stronę, zachowaj notatki, eksportuj do PDF lub obrazów za pomocą Aspose.Slides, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides udostępnia możliwość konwertowania prezentacji na różne formaty, w tym tworzenia materiałów drukowanych w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając właściwość `slides_layout_options` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).

## **Eksport trybu Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handoutlayoutingoptions/), który określa, ile slajdów zostanie umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```py
# Załaduj prezentację.
with slides.Presentation("sample.pptx") as presentation:

    # Ustaw opcje eksportu.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slajdy na jednej stronie w poziomie
    slides_layout_options.print_slide_numbers = True                                 # wydrukuj numery slajdów
    slides_layout_options.print_frame_slide = True                                   # wydrukuj ramkę wokół slajdów
    slides_layout_options.print_comments = False                                     # brak komentarzy

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Eksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Należy pamiętać, że właściwość `slides_layout_options` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/) aż do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) i 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz opcję `show_hidden_slides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).