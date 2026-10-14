---
title: Formatowanie kształtów PowerPoint w Pythonie za pomocą Java
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/python-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicowa kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt 3D bevel
- efekt 3D obrotu
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie za pomocą Java przy użyciu Aspose.Slides — ustaw style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [styl linii](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) kształtu.
5. Ustaw szerokość linii.
6. Ustaw [styl kreskowania](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) linii.
7. Ustaw kolor linii dla kształtu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod pokazuje, jak sformatować prostokąt [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

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

    # Zastosuj formatowanie do linii prostokąta.
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

Efekt szkicu sprawia, że linia kształtu wygląda jak narysowana ręcznie. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) aby uzyskać dostęp do ustawień szkicu oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Poniższy kod w języku Python pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved), odczytać wyraźnie przypisaną wartość oraz usunąć efekt za pomocą [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

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

Wartość zwrócona przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu nadrzędnego lub układu slajdu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), uzyskaj dostęp do `LineFormatEffectiveData.getSketchFormat` i odczytaj `SketchFormatEffectiveData.getSketchType`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

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

## **Formatowanie stylów łączenia**

Oto trzy dostępne opcje typu łączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w narożniku kształtu), używa ustawienia **Round**. Jednakże, jeśli rysujesz kształt z ostrymi kątami, możesz preferować opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w języku Python pokazuje, jak trzy prostokąty (widoczne na powyższym obrazie) zostały utworzone przy użyciu ustawień typu łączenia Miter, Bevel i Round:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

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

## **Wypełnienie gradientowe**

W programie PowerPoint wypełnienie gradientowe jest opcją formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) kształtu na `Gradient`.
5. Dodaj dwa wybrane kolory o określonych pozycjach, używając metody [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) kolekcji przystanków gradientu udostępnionej przez klasę [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/).
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

    # Zastosuj formatowanie gradientowe do elipsy.
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

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Wybierz styl renderowania gradientu](/slides/pl/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany wypełnienia gradientowego przechowywanego w prezentacji.

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — taki jak kropki, paski, krzyżaki lub kratkę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 predefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu predefiniowanego wzoru, możesz dalej określić dokładne kolory, które ma on używać.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) kształtu na `Pattern`.
5. Wybierz styl wzoru z dostępnych predefiniowanych opcji.
6. Ustaw [Kolor tła](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) wzoru.
7. Ustaw [Kolor pierwszego planu](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) wzoru.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides, aby zastosować wypełnienie obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) kształtu na `Picture`.
5. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
6. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
7. Przekaż obraz do metody `SlidesPicture.setImage`.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

![Obraz lotosu](lotus.png)

Poniższy kod w języku Python pokazuje, jak wypełnić kształt obrazem:

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

![Kształt z wypełnieniem obrazem](picture-fill.png)

## **Ustaw obraz jako teksturę kafelkową**

Jeśli chcesz ustawić obraz kafelkowy jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbity w poziomie, w pionie, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka w procentach.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka w procentach.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z wypełnieniem obrazem kafelkowym i skonfigurować opcje kafelkowania:

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

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem w kształcie przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) kształtu na `Solid`.
5. Przypisz wybrany kolor wypełnienia do kształtu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz również ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej prześwitujący, umożliwiając częściowe widoczność tła lub znajdujących się pod nim obiektów.

Aspose.Slides pozwala ustawić poziom przezroczystości, dostosowując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) kształtu na `Solid`.
5. Użyj [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html), aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
6. Zapisz prezentację.

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

    # Dodaj automatyczny kształt prostokątny wypełniony.
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

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy rozmieszczaniu elementów wizualnych z określonym wyrównaniem lub wymaganiami projektowymi.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw właściwość rotacji kształtu na żądany kąt.
5. Zapisz prezentację.

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

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D bevel**

Aspose.Slides umożliwia zastosowanie efektów 3D bevel do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia bevel.
5. Zapisz prezentację.

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

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efekt 3D bevel](3D-bevel-effect.png)

## **Dodaj efekty 3D obrotu**

Aspose.Slides umożliwia zastosowanie efektów 3D obrotu do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do slajdu.
4. Użyj metod [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), aby zdefiniować obrót 3D.
5. Zapisz prezentację.

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

![Efekt 3D obrotu](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) określa, w jaki sposób pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samej funkcji wyświetlania w czerni i bieli oraz nie zmienia wypełnienia, linii ani innych formatowań kształtu w normalnym trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/), aby wybrać żądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają szarego koloru, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod w języku Python tworzy kolorowy kształt i sprawia, że w trybie wyświetlania czarno‑białego jest on szary:

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

    # Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno‑białego używa szarego kolorowania, ponieważ jego tryb jest ustawiony na `Gray`. Pozwala to zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla druku, podglądu lub innych przepływów, które respektują ustawienia wyświetlania czarno‑białego prezentacji.

## **Resetowanie formatowania**

Poniższy kod w języku Python pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

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

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonu lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne kształty ze stylami i ponownie zastosuj ich formatowanie w dowolnym miejscu.