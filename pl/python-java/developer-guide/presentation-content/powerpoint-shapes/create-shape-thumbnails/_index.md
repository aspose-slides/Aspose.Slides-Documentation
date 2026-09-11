---
title: Utwórz miniatury kształtów prezentacji w Python via Java
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/python-java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtów
- granice wizualne
- granice kształtu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for Python via Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wstęp**

Aspose.Slides for Python via Java może być używany do tworzenia plików prezentacji, w których każda strona odpowiada slajdowi. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak programiści czasami muszą wyświetlać obrazy kształtów oddzielnie w przeglądarce obrazów. W takich przypadkach Aspose.Slides for Python via Java pomaga generować miniatury obrazów kształtów slajdu.

Ten artykuł wyjaśnia, jak generować miniatury kształtów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu z wymiarami określonymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**

Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Python via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu, używając jego identyfikatora lub indeksu.
3. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) kształtu na wskazanym slajdzie w domyślnej skali.
4. Zapisz obraz miniatury w preferowanym formacie obrazu.

Przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation("Thumbnail.pptx")
try:
    # Utwórz obraz w pełnej skali.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Zapisz obraz na dysku w formacie PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Generowanie miniatury z określonym przez użytkownika współczynnikiem skalowania**

Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Python via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu, używając jego identyfikatora lub indeksu.
3. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) kształtu na wskazanym slajdzie z wymiarami określonymi przez użytkownika.
4. Zapisz obraz miniatury w preferowanym formacie obrazu.

Przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie określonego współczynnika skalowania:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation("Thumbnail.pptx")
try:
    # Utwórz obraz skalowany współczynnikiem 2 w obu kierunkach.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Zapisz obraz na dysku w formacie PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Utworzenie miniatury wyglądu kształtu opartej na granicach**

Ta metoda tworzenia miniatur kształtów pozwala programistom wygenerować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz obraz miniatury kształtu na wskazanym slajdzie, używając jego granic wyglądu.
4. Zapisz obraz miniatury w preferowanym formacie obrazu.

Przykładowy kod oparty jest na powyższych krokach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation("Thumbnail.pptx")
try:
    # Utwórz obraz w pełnej skali.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Zapisz obraz na dysku w formacie PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Pobranie rzeczywistych granic wizualnych kształtu**

Właściwości ramki [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) — metody [getX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getWidth) i [getHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getHeight) — opisują prostokąt przechowywany w modelu prezentacji. Treść rzeczywiście renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Rotacja, kontury, groty strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmienić zajęty obszar.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getVisualBounds), aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycinany do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

Poniższy przykład pobiera i porównuje granice ramki oraz wizualne:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Ten sam [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) może być użyty do wyrównywania pobliskich kształtów do jego lewej, prawej, górnej lub dolnej krawędzi; rezerwowania wystarczającej przestrzeni w wygenerowanym układzie; lub wykrywania zawartości poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obrotowych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getVisualBounds), gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [Shape.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage), gdy potrzebujesz renderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapethumbnailbounds/#Shape) określa rozmiar obrazu na podstawie granic kształtu, włączając ustawienia konturu, podczas gdy [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapethumbnailbounds/#Appearance) określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getVisualBounds) zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/), i inne. Kształty mogą być również [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#writeAsSvgToBytes), zapisując zawartość kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/python-java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal będzie renderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/python-java/custom-font/) (lub [skonfigurować substytucje czcionek](/slides/pl/python-java/font-substitution/)), aby uniknąć niepożądanych fallbacków i zmiany układu tekstu.