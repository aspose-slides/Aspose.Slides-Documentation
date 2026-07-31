---
title: Konwertuj prezentacje w trybie Handout przy użyciu Pythona
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/python-net/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb Handout
- Handout
- PowerPoint
- prezentacja
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konwertuj prezentacje do handoutów w Pythonie. Ustaw slajdy na stronę, zachowaj notatki, eksportuj do PDF lub obrazów z Aspose.Slides, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji na różne formaty, w tym tworzenia notatek do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się wyświetlać na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając właściwość `slides_layout_options` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handoutlayoutingoptions/), który określa, ile slajdów ma być umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```py
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

    # Eksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Pamiętaj, że właściwość `slides_layout_options` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **Najczęściej zadawane pytania**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/) do 9 miniatur na stronie z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz opcję `show_hidden_slides` w ustawieniach eksportu dla wybranego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).