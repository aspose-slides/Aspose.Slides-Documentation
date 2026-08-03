---
title: Tworzenie miniaturek kształtów prezentacji w Pythonie
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/python-net/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- wizualne granice
- granice kształtu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez .NET – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides dla Pythona poprzez .NET służy do tworzenia plików prezentacji, w których każda strona jest slajdem. Możesz przeglądać te slajdy w Microsoft PowerPoint, otwierając plik prezentacji. Jednak deweloperzy czasami potrzebują zobaczyć obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides może generować miniatury obrazów kształtów slajdu. Ten artykuł wyjaśnia, jak korzystać z tej funkcji.

## **Generowanie miniatur kształtów ze slajdów**

Gdy potrzebujesz podglądu konkretnego obiektu, a nie całego slajdu, możesz wyrenderować miniaturę pojedynczego kształtu. Aspose.Slides umożliwia eksport dowolnego kształtu do obrazu, co ułatwia tworzenie lekkich podglądów, ikon lub zasobów do dalszego przetwarzania.

Aby wygenerować miniaturę z dowolnego kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego identyfikatora (ID) lub indeksu.
1. Uzyskaj odwołanie do kształtu na tym slajdzie.
1. Wyrenderuj miniaturę obrazu kształtu.
1. Zapisz obraz miniatury w wybranym formacie.

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

Ta sekcja pokazuje, jak generować miniatury kształtów z definiowanym przez użytkownika współczynnikiem skalowania w Aspose.Slides. Kontrolując skalę, możesz precyzyjnie dopasować rozmiar miniatury do podglądów, eksportu lub wyświetlaczy o wysokiej rozdzielczości DPI.

Aby wygenerować miniaturę dla dowolnego kształtu na slajdzie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego identyfikatora (ID) lub indeksu.
1. Uzyskaj docelowy kształt na tym slajdzie.
1. Wyrenderuj miniaturę obrazu kształtu z określoną skalą.
1. Zapisz obraz miniatury w wybranym formacie.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Utwórz obraz z zdefiniowaną skalą.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Zapisz obraz na dysku w formacie PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generowanie miniatur przy użyciu granic wyglądu kształtu**

Ta sekcja pokazuje, jak generować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura jest ograniczona do granic slajdu.

Aby wygenerować miniaturę dowolnego kształtu slajdu w granicach jego wyglądu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego identyfikatora (ID) lub indeksu.
1. Uzyskaj docelowy kształt na tym slajdzie.
1. Wyrenderuj miniaturę obrazu kształtu z określonymi granicami.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Utwórz obraz kształtu z granicami wyglądu.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Zapisz obraz na dysku w formacie PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Uzyskanie rzeczywistych wizualnych granic kształtu**

Właściwości ramki [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) — `Shape.x`, `Shape.y`, `Shape.width` i `Shape.height` — opisują prostokąt przechowywany w modelu prezentacji. Zawartość rzeczywiście renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Rotacja, obrysy, groty strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmieniać zajęty obszar.

Użyj [Shape.get_visual_bounds](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_visual_bounds/) aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca prostokąt zmiennoprzecinkowy w współrzędnych slajdu. Zwrócony prostokąt nie jest przycięty do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

Poniższy przykład pobiera i porównuje ramkę oraz wizualne granice:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Tego samego prostokąta można użyć do wyrównania pobliskich kształtów względem jego krawędzi `left`, `right`, `top` lub `bottom`; zarezerwowania wystarczającej przestrzeni w generowanym układzie; lub wykrycia zawartości poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape.get_visual_bounds](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_visual_bounds/) gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [Shape.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/) gdy potrzebujesz wyrenderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.SHAPE` określa rozmiar obrazu na podstawie granic kształtu, w tym ustawień obrysu, podczas gdy `ShapeThumbnailBounds.APPEARANCE` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast `Shape.get_visual_bounds` zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazów można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/), oraz inne. Kształty mogą być także [wyeksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami SHAPE a APPEARANCE przy renderowaniu miniatury?**

`SHAPE` używa geometrii kształtu; `APPEARANCE` uwzględnia [efekty wizualne](/slides/pl/python-net/shape-effect/) (cienie, poświaty itp.).

**Co się dzieje, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flagi ukrycia wpływają na wyświetlanie w pokazie slajdów, ale nie uniemożliwiają generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/), oraz [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur dla kształtów tekstowych?**

Tak. Powinieneś [dostarczyć wymagane czcionki](/slides/pl/python-net/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/python-net/font-substitution/)), aby uniknąć niechcianych fallbacków i przemieszczeń tekstu.