---
title: Formatowanie kształtów PowerPoint w Pythonie za pośrednictwem Java
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/python-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia kształtu szkicu
- formatowanie stylu łączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- renderowanie kształtu w czerni i bieli
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt 3D fazowania
- efekt 3D rotacji
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie za pośrednictwem Java przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące wypełnienie ich wnętrza.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java zapewnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Przy użyciu Aspose.Slides możesz określić niestandardowy styl linii dla kształtu. Poniższe kroki przedstawiają procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Ustaw kolor wypełnienia dla prostokątnego kształtu.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Zastosuj formatowanie linii prostokąta.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręczną. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getLineFormat), aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/lineformat/#getSketchFormat), aby uzyskać dostęp do ustawień szkicu, oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sketchformat/#setSketchType), aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linesketchtype/).

Poniższy kod w Pythonie pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linesketchtype/#Curved), odczytać przypisaną wartość i usunąć efekt przy użyciu [LineSketchType.None_](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linesketchtype/#None) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Uzyskaj dostęp do formatu linii kształtu i jego formatu szkicu.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Zastosuj efekt szkicu.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Usuń efekt szkicu.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Wartość zwracana przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sketchformat/#getSketchType) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu-matka lub slajdu układu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/lineformat/#getEffective), uzyskaj dostęp do `LineFormatEffectiveData.getSketchFormat` i odczytaj `SketchFormatEffectiveData.getSketchType`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w rogu kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach możesz wolać opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w Pythonie demonstruje, jak utworzono trzy prostokąty (jak na powyższym obrazku) przy użyciu ustawień połączenia Miter, Bevel i Round :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj trzy automatyczne kształty typu Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Ustaw szerokość linii.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Ustaw kolor linii dla każdego prostokąta.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Ustaw styl połączenia.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Dodaj tekst do każdego prostokąta.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Zapisz plik PPTX na dysku.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem jest opcją formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów tak, aby jeden stopniowo przechodził w drugi.

Oto jak zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metody [addPresetColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gradientstopcollection/#addPresetColor) kolekcji przystanków gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/gradientformat/) .
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w Pythonie demonstruje, jak zastosować efekt wypełnienia gradientem do elipsy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Zastosuj formatowanie gradientem do elipsy.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Dodaj dwa przystanki gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Zapisz plik PPTX na dysku.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżykowanie lub szachownicę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wbudowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu wstępnie zdefiniowanego wzoru możesz określić dokładne kolory, które ma on używać.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) na `Pattern`.
1. Wybierz styl wzoru spośród dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternformat/#getBackColor) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/python-java/aspose.slides/patternformat/#getForeColor) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w Pythonie demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Oto jak użyć Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) z obrazu, który chcesz użyć.
1. Przekaż obraz do metody `SlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" o następującym obrazie:

![Obraz lotosu](lotus.png)

Poniższy kod w Pythonie demonstruje, jak wypełnić kształt obrazem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Ustaw typ wypełnienia na Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Wczytaj obraz i dodaj go do zasobów prezentacji.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Ustaw obraz.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstury**

Jeśli chcesz ustawić obraz w trybie kafelkowania jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbity poziomo, pionowo, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) względem początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) względem początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    first_slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt prostokątny.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Ustaw typ wypełnienia kształtu na Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Wczytaj obraz i dodaj go do zasobów prezentacji.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Przypisz obraz do kształtu.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Tło jest stosowane bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w Pythonie demonstruje, jak zastosować wypełnienie jednolitym kolorem do prostokąta w slajdzie PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz wypełnienie jednolite, gradientowe, obrazowe lub teksturowe do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, umożliwiając częściowe widzenie tła lub obiektów znajdujących się pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez modyfikację wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) na `Solid`.
1. Użyj [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html), aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod w Pythonie demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
    presentation = Presentation()
    try:
        # Pobierz pierwszy slajd.
        slide = presentation.getSlides().get_Item(0)

        # Dodaj automatyczny prostokątny kształt wypełniony jednolicie.
        solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

        # Dodaj przezroczysty prostokątny kształt automatyczny nad wypełnionym kształtem.
        transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
        transparent_shape.getFillFormat().setFillType(FillType.Solid)
        transparent_color = Color(255, 255, 0, 204)
        transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

        # Zapisz plik PPTX na dysku.
        presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod w Pythonie demonstruje, jak obrócić kształt o 5 stopni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj automatyczny kształt typu Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Obróć kształt o 5 stopni.
    shape.setRotation(5)

    # Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3D Bevel**

Aspose.Slides umożliwia zastosowanie efektów 3D Bevel do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/) .

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj właściwość [ThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/) kształtu, aby zdefiniować ustawienia bevel.
1. Zapisz prezentację.

Poniższy kod w Pythonie pokazuje, jak zastosować efekty 3D Bevel do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt do slajdu.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Ustaw właściwości ThreeDFormat kształtu.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodawanie efektów 3D Rotation**

Aspose.Slides umożliwia zastosowanie efektów 3D Rotation do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/) .

Aby zastosować 3D Rotation do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/lightrig/#setLightType), aby zdefiniować rotację 3D.
1. Zapisz prezentację.

Poniższy kod w Pythonie demonstruje, jak zastosować efekty 3D Rotation do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Efekt 3D Rotation](3D-rotation-effect.png)

## **Kontrola renderowania czarno‑białego dla kształtów**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑bialym. Nie włącza ona trybu czarno‑białego samodzielnie i nie zmienia wypełnienia, linii ani innych formatowań w trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/blackwhitemode/), aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod w Pythonie tworzy kolorowy kształt i sprawia, że wyświetla się szaro w trybie czarno‑białym:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w szarym kolorze w trybie czarno-białym.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W workflow wyświetlania czarno‑białego używa szarego koloru, ponieważ jego tryb jest ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych procesów respektujących ustawienia wyświetlania czarno‑białego.

## **Resetowanie formatowania**

Poniższy kod w Pythonie pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy formatowanie kształtu wpływa na ostateczny rozmiar pliku prezentacji?**

Jedynie nieznacznie. Osadzone obrazy i multimedia zajmują najwięcej miejsca, natomiast parametry kształtów, takie jak kolory, efekty i gradienty są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru pliku.

**Jak wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające sobie wartości są równe, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylizowane kształty i ponownie zastosuj ich formatowanie w wybranych miejscach.