---
title: Tworzenie miniatur kształtów prezentacji w Pythonie
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/python-net/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET służy do tworzenia plików prezentacji, w których każda strona jest slajdem. Możesz przeglądać te slajdy w Microsoft PowerPoint, otwierając plik prezentacji. Jednak programiści czasami potrzebują wyświetlić obrazy kształtów oddzielnie w przeglądarce obrazów. W takich przypadkach Aspose.Slides może generować miniatury obrazów dla kształtów slajdu. Ten artykuł wyjaśnia, jak używać tej funkcji.

## **Generowanie miniatur kształtów ze slajdów**

Gdy potrzebujesz podglądu konkretnego obiektu zamiast całego slajdu, możesz wygenerować miniaturę pojedynczego kształtu. Aspose.Slides umożliwia eksport dowolnego kształtu do obrazu, co ułatwia tworzenie lekkich podglądów, ikon lub zasobów do dalszego przetwarzania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego identyfikatora lub indeksu.
1. Uzyskaj odniesienie do kształtu na tym slajdzie.
1. Wygeneruj miniaturę obrazu kształtu.
1. Zapisz obraz miniatury w żądanym formacie.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Utwórz obraz z domyślną skalą.
    with shape.get_image() as thumbnail:
        # Zapisz obraz na dysku w formacie PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generowanie miniatur z niestandardowym współczynnikiem skalowania**

Ta sekcja pokazuje, jak generować miniatury kształtów z definiowanym przez użytkownika współczynnikiem skalowania w Aspose.Slides. Kontrolując skalę, możesz precyzyjnie dopasować rozmiar miniatury do podglądów, eksportów lub wyświetlaczy wysokiej rozdzielczości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj slajd za pomocą jego identyfikatora lub indeksu.
1. Uzyskaj docelowy kształt na tym slajdzie.
1. Wygeneruj miniaturę obrazu kształtu z określoną skalą.
1. Zapisz obraz miniatury w żądanym formacie.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Utwórz obraz z określoną skalą.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Zapisz obraz na dysku w formacie PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generowanie miniatur przy użyciu granic wyglądu kształtu**

Ta sekcja pokazuje, jak wygenerować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura jest ograniczona do granic slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj slajd za pomocą jego identyfikatora lub indeksu.
1. Uzyskaj docelowy kształt na tym slajdzie.
1. Wygeneruj miniaturę obrazu kształtu z określonymi granicami.
1. Zapisz obraz miniatury w żądanym formacie obrazu.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Utwórz obraz kształtu w granicach wyglądu.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Zapisz obraz na dysku w formacie PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/), oraz inne. Kształty mogą być także [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami SHAPE a APPEARANCE przy renderowaniu miniatury?**

`SHAPE` używa geometrii kształtu; `APPEARANCE` uwzględnia [efekty wizualne](/slides/pl/python-net/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wygenerowana miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie w pokazie slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/) i [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/python-net/custom-font/) (lub [skonfigurować zamienniki czcionek](/slides/pl/python-net/font-substitution/)), aby uniknąć niechcianych zastąpień i przemieszczenia tekstu.