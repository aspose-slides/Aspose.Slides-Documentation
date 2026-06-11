---
title: Konwertowanie slajdów PowerPoint na PNG w Pythonie
linktitle: Slajd do PNG
type: docs
weight: 30
url: /pl/python-net/convert-powerpoint-to-png/
keywords:
- konwertować PowerPoint do PNG
- konwertować prezentację do PNG
- konwertować slajd do PNG
- konwertować PPT do PNG
- konwertować PPTX do PNG
- konwertować ODP do PNG
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- ODP do PNG
- Python
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides for Python via .NET, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia prostą konwersję prezentacji PowerPoint do formatu PNG. Ładujesz prezentację, przechodzisz przez jej slajdy, renderujesz każdy z nich do obrazu rastrowego i zapisujesz wynik jako pliki PNG. Jest to idealne rozwiązanie do generowania podglądów slajdów, osadzania slajdów na stronach internetowych lub tworzenia statycznych zasobów do dalszego przetwarzania.

## **Konwertowanie slajdów do PNG**

Ta sekcja prezentuje najprostszy możliwy przykład konwersji prezentacji PowerPoint do obrazów PNG przy użyciu Aspose.Slides for Python via .NET.

Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd z kolekcji `Presentation.slides` (zobacz klasę [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/)).
3. Użyj metody `Slide.get_image`, aby wygenerować miniaturę slajdu.
4. Użyj metody `Presentation.save`, aby zapisać miniaturę slajdu w formacie PNG.

Ten kod w Pythonie pokazuje, jak przekonwertować prezentację PowerPoint do PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konwertowanie slajdów do PNG z niestandardowymi wymiarami**

Aby wyeksportować slajdy do PNG w niestandardowej skali, wywołaj `Slide.get_image` z poziomymi i pionowymi współczynnikami skali. Te mnożniki zmieniają rozmiar wyjścia względem oryginalnych wymiarów slajdu — na przykład `2.0` podwaja zarówno szerokość, jak i wysokość. Użyj równych wartości dla `scale_x` i `scale_y`, aby zachować proporcje.

Ten kod w Pythonie demonstruje opisane działanie:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konwertowanie slajdów do PNG z niestandardowym rozmiarem**

Jeśli chcesz generować pliki PNG o określonym rozmiarze, przekaż żądane wartości `width` i `height`. Poniższy kod pokazuje, jak przekonwertować prezentację PowerPoint do PNG, określając rozmiar obrazu:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Możesz wypróbować darmowe konwertery **PowerPoint-to-PNG** firmy Aspose — [PPTX to PNG](https://products.aspose.app/slides/pl/conversion/pptx-to-png) i [PPT to PNG](https://products.aspose.app/slides/pl/conversion/ppt-to-png). Udostępniają one działającą implementację procesu opisanego na tej stronie.
{{% /alert %}}

## **FAQ**

**Jak mogę wyeksportować tylko określony kształt (np. wykres lub obraz) zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur pojedynczych kształtów](/slides/pl/python-net/create-shape-thumbnails/); możesz wyrenderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/python-net/multithreading/) jednej instancji prezentacji wielu wątkom. Użyj osobnej instancji na każdy wątek lub proces.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do wygenerowanych obrazów i wymusza [inne ograniczenia](/slides/pl/python-net/licensing/), dopóki nie zostanie zastosowana licencja.