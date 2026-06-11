---
title: Utwórz przeglądarkę prezentacji w Pythonie
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/python-net/presentation-viewer/
keywords:
- przeglądanie prezentacji
- przeglądarka prezentacji
- tworzenie przeglądarki prezentacji
- przeglądanie PPT
- przeglądanie PPTX
- przeglądanie ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Dowiedz się, jak stworzyć własną przeglądarkę prezentacji w Pythonie przy użyciu Aspose.Slides. Łatwo wyświetlaj pliki PowerPoint (PPTX, PPT) i OpenDocument (ODP) bez Microsoft PowerPoint ani innego oprogramowania biurowego."
---
## **Wprowadzenie**

Aspose.Slides dla Pythona służy do tworzenia plików prezentacji ze slajdami. Te slajdy można przeglądać, otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Jednak deweloperzy mogą czasami potrzebować wyświetlać slajdy jako obrazy w preferowanym przeglądarce zdjęć lub używać ich w niestandardowej przeglądarce prezentacji. W takich przypadkach Aspose.Slides umożliwia eksportowanie pojedynczych slajdów jako obrazy. Ten artykuł wyjaśnia, jak to zrobić.

## **Wygeneruj obraz SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu po jego indeksie.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Utwórz miniaturę slajdu**

Aspose.Slides pomaga generować miniatury slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu po jego indeksie.
1. Utwórz obraz miniatury referowanego slajdu w żądanej skali.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Utwórz miniaturę slajdu o wymiarach określonych przez użytkownika**

Aby utworzyć obraz miniatury slajdu o wymiarach określonych przez użytkownika, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu po jego indeksie.
1. Wygeneruj obraz miniatury referowanego slajdu o podanych wymiarach.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Utwórz miniaturę slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/).
1. Użyj właściwości `RenderingOptions.slides_layout_options`, aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu po jego indeksie.
1. Wygeneruj obraz miniatury referowanego slajdu przy użyciu opcji renderowania.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Przykład na żywo**

Wypróbuj darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/pl/viewer/)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji internetowej ASP.NET?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako [obrazy](/slides/pl/python-net/convert-powerpoint-to-png/) lub [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) i wyświetlać je w przeglądarce. Funkcje nawigacji i powiększania można zaimplementować w JavaScript, aby uzyskać interaktywne wrażenia.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowej przeglądarce .NET?**

Zalecane podejście polega na renderowaniu każdego slajdu jako [obraz](/slides/pl/python-net/convert-powerpoint-to-png/) (np. PNG lub SVG) lub konwersji do [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) przy użyciu Aspose.Slides, a następnie wyświetlenie wyniku w kontrolce PictureBox (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji webowych).

**Jak radzić sobie z dużymi prezentacjami zawierającymi wiele slajdów?**

W przypadku dużych prezentacji warto rozważyć leniwe ładowanie lub renderowanie slajdów na żądanie. Oznacza to generowanie treści slajdu tylko wtedy, gdy użytkownik do niego przejdzie, co zmniejsza zużycie pamięci i czas ładowania.