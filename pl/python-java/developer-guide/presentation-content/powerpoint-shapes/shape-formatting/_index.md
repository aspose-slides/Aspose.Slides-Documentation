---
title: Formatowanie kształtów PowerPoint w Pythonie przy użyciu Java
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/python-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- szkicowanie linii kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt fazowania 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie przy użyciu Java i Aspose.Slides — ustawiaj style wypełnienia, linii i efektów dla plików PPT i PPTX z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

Formatowanie kształtów w programie PowerPoint poprzez dostosowywanie ich konturów, wypełnień i efektów. Aspose.Slides for Python via Java umożliwia kontrolowanie tych ustawień programowo, w tym przezroczystość, obrót i formatowanie 3D.

![Opcje formatowania kształtu w programie PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w programie PowerPoint.

## **Formatowanie linii**

Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat), aby kontrolować obrys kształtu. Ten przykład tworzy prostokąt bez wypełnienia z niebieskim, przerywanym obrysem. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) wybiera linię złożoną gruba‑cienka, natomiast [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ustawia jej szerokość na 7 punktów, a [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) wybiera wzorzec kreski.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

### **Ustawianie własnych wzorców kreskowania linii**

Użyj [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern), gdy wstępnie zdefiniowane style linii nie zapewniają potrzebnych długości kresek i przerw, na przykład w przypadku oznaczeń firmowych lub diagramów technicznych. Przypisanie wzorca automatycznie zmienia styl kreskowania linii na [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Wpisy w tablicy naprzemiennie określają długość kreski i przerwy, zaczynając od kreski. Każda wartość jest wielokrotnością szerokości linii: `[4, 2]` przy szerokości 3 punktów daje kreskę o długości 12 punktów, a następnie przerwę 6‑puntową. Używaj par skończonych, nieujemnych wartości, aby zdefiniować pełne segmenty kreska‑przerwa. Przykład używa dodatnich wartości, aby każda kreska i przerwa były widoczne.

Ten przykład tworzy pięć niebieskich linii o tej samej długości i płaskich zakończeniach. Pierwsze trzy porównują wzorce przy szerokości 3 punktów. Czwarta powtarza pierwszy wzorzec przy dwukrotnej szerokości, podwajając zarówno długość kreski, jak i przerwy. Piąta zmienia wzorzec niestandardowy na linię ciągłą.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Ustaw ostatnią linię na styl ciągły.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby powrócić do wstępnie zdefiniowanego stylu kreskowanego, przekaż [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) do [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Wybrany styl kontroluje wygląd linii.

Wynik w programie PowerPoint, od góry do dołu: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; oraz **Solid, 3 pt**.

![Trzy własne wzorce kreskowania, szersza linia używająca pierwszego wzorca i linia ciągła w programie PowerPoint](custom-dash-patterns.png)

### **Ustawianie zakończeń linii**

Użyj [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle), aby ustawić końce otwartej linii. Klasa [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) udostępnia trzy wyraźne style zakończeń:

- `Flat`: Pędzel zatrzymuje się w punkcie końcowym.
- `Round`: Półokrągłe zakończenie wystaje poza punkt końcowy o połowę szerokości linii.
- `Square`: Kwadratowe zakończenie wystaje poza punkt końcowy o połowę szerokości linii.

Klasa zawiera także `NotDefined`, co oznacza, że żaden styl zakończenia nie został jawnie przypisany.

Zakończenia różnią się od grotów strzałek, które dodają symbole do końców linii, oraz połączeń, które kontrolują narożniki między odcinkami linii. Ten przykład wyłącza groty strzałek przy użyciu [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) i [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle), tak aby porównane zostały wyłącznie kształty zakończeń.

Poniższy przykład tworzy trzy w pozostałych aspektach identyczne poziome linie, o szerokości 20 punktów. Od góry do dołu używają zakończeń płaskich, okrągłych i kwadratowych. Ich punkty końcowe mają te same współrzędne poziome; zakończenia okrągłe i kwadratowe wystają 10 punktów poza każdy koniec.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik w programie PowerPoint, od góry do dołu: **Flat**, **Round** i **Square**.

![Płaskie, okrągłe i kwadratowe zakończenia na identycznych grubych liniach w programie PowerPoint](line-caps.png)

## **Zastosowanie efektu szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręcznie narysowaną. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat), aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat), aby uzyskać dostęp do ustawień szkicu, oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType), aby wybrać wartość z klasy [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Poniższy kod Pythona pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), odczytać jawnie przypisaną wartość oraz usunąć efekt za pomocą [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

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

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Wartość zwracana przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu-matki lub slajdu‑układu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) i odczytaj typ szkicu z zwróconego efektywnego formatowania linii, jak pokazano poniżej. Wartość efektywna odzwierciedla formatowanie, które jest faktycznie zastosowane po rozwiązaniu dziedziczenia. Ten przykład wymaga istniejącej prezentacji z co najmniej jednym kształtem na pierwszym slajdzie i drukuje obie wartości:

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

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Styl połączenia kontroluje, w jaki sposób dwa odcinki konturu łączą się w narożniku. Użyj **Round** dla zaokrąglonych narożników, **Miter** dla ostrych narożników lub **Bevel** dla spłaszczonych narożników.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Ten przykład tworzy trzy czarne prostokąty z niebieskimi obramowaniami o szerokości 15 punktów. Używa [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle), aby ustawić kolejno wartości miter, bevel i round klasy [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), aby porównać, jak rysowane są narożniki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ograniczanie połączeń miter przy ostrych narożnikach**

Użyj [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) razem z [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) ustawionym na [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), aby ograniczyć, jak daleko ostry narożnik może wystawać.

Limit jest stosunkiem odległości pomiędzy wewnętrznym a zewnętrznym narożnikiem połączenia do szerokości linii. Na przykład wartość `8` dopuszcza długość miteru do ośmiu razy szerokości linii; nie jest to pomiar w punktach. Jeśli narożnik przekroczyłby limit, PowerPoint zastosuje połączenie fazowane w tym miejscu. Większy limit umożliwia ostrzejsze punkty. Ustawienie wpływa wyłącznie na połączenia miter i nie ma widocznego efektu, gdy narożnik pozostaje w granicach obu limitów.

Ten przykład tworzy dwa identyczne, nie wypełnione trójkąty z obramowaniami o szerokości 20 punktów. Lewy trójkąt używa limitu `2`, prawy `8`. Każdy trójkąt ma szerokość 80 punktów i wysokość 160 punktów, co daje stosunek długości miteru do szerokości linii w górnym narożniku około `4.12`. W konsekwencji PowerPoint fazuje lewy wierzchołek i zachowuje prawy wierzchołek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik w programie PowerPoint: **Miter limit 2** po lewej i **miter limit 8** po prawej.

![Fazowany szczyt z limitem miter 2 i ostry szczyt z limitem miter 8 w programie PowerPoint](miter-limits.png)

## **Wypełnienie gradientowe**

Wypełnienie gradientowe miesza kolory w obrębie kształtu. Ten przykład wypełnia elipsę gradientem liniowym pod kątem 45 stopni od czerwonego do fioletowego przy użyciu [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Metoda [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) umieszcza przystanki kolorów na pozycjach 0 i 1, czyli na początku i końcu gradientu. Usunięcie istniejących przystanków zapewnia, że użyte będą tylko te dwa kolory.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Choose a Gradient Rendering Style](/slides/pl/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany gradientu zapisanego w prezentacji.

### **Ustawienie kąta gradientu liniowego**

Użyj [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle), aby kontrolować orientację wypełnienia [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). Kąt podawany jest w stopniach i rośnie zgodnie z ruchem wskazówek zegara: `0` przebiega od lewej do prawej, `90` od góry do dołu, `180` od prawej do lewej, a `270` od dołu do góry. Obsługiwane są kąty ułamkowe. Kąty skończone poza zakresem `[0, 360)` są normalizowane do jednej pełnej rotacji; na przykład `-45` staje się `315`, a `360` staje się `0`.

Ten przykład tworzy sześć prostokątów z identycznymi przystankami czerwonego, zielonego i niebieskiego na pozycjach `0`, `0.5` i `1`. Skalowanie jest wyłączone, aby kąt mógł być porównywany niezależnie od proporcji prostokątów. Kąty, od lewej do prawej, to `0`, `45` i `90` w pierwszym wierszu oraz `135`, `180` i `270` w drugim wierszu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik w programie PowerPoint:

![Gradienty liniowe pod kątami 0, 45 i 90 stopni w górnym wierszu oraz 135, 180 i 270 stopni w dolnym wierszu](linear-gradient-angles.png)

### **Skalowanie gradientu liniowego razem z kształtem**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) przyjmuje wartość [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Ustaw ją jawnie na `False_`, aby zachować geometryczny kąt gradientu przy zmianie proporcji kształtu, lub na `True_`, aby skalować gradient razem z szerokością i wysokością kształtu. Przy włączonym skalowaniu widoczny kąt może różnić się od przypisanego kąta w przypadku kształtu niebędącego kwadratem.

Poniższy przykład używa kąta `45` stopni i tych samych przystanków kolorów co w porównaniu kątów. Lewa kolumna używa `False_`; prawa kolumna używa `True_`. Każda kolumna zawiera szeroki prostokąt nad wysokim prostokątem. Oba zaczynają się od tych samych szerokich wymiarów; zmiana szerokości i wysokości drugiego prostokąta demonstruje, jak wypełnienie reaguje na zmianę rozmiaru bez zmiany ustawień gradientu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik w programie PowerPoint, przy wyłączonym skalowaniu po lewej i włączonym po prawej:

![Szerokie i wysokie prostokąty z gradientem 45‑stopni, porównanie LinearGradientScaled False po lewej i True po prawej](linear-gradient-scaling.png)

Przy wyłączonym skalowaniu przekątne pasma kolorów zachowują tę samą orientację w obu prostokątach. Przy włączonym skalowaniu pasma rozciągają się razem z proporcjami kształtu. Pomaga to odtworzyć gradient szablonu przy dostosowywaniu kształtu do innego rozmiaru. Na kwadracie włączenie skalowania nie zmienia wyglądu tego gradientu `45`‑stopniowego.

Zarówno kąt, jak i ustawienia skalowania dotyczą gradientów liniowych. Nie kontrolują wypełnień [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Łączenie kąta z kierunkiem gradientu**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) wybiera styl gradientu z klasy [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); nie jest to zamiennik dla liczbowego kąta. Dla gradientu liniowego style narożników mogą zmienić obszar, na którym rozłożone są kolory, bez zmiany kąta przypisanego przez [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Zachowaj niezmieniony kierunek przy porównywaniu kątów lub skalowaniu.

Poniższy przykład stosuje te same ustawienia w odwrotnej kolejności. Dwa prostokąty mają taki sam wygląd: ustawienie kierunku przed lub po kącie nie zmienia wyniku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wypełnienie wzorem**

Wypełnienie wzorem stosuje dwukolorowy wzór, taki jak kropki, paski lub kratkę. Ten przykład używa [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle), aby wybrać wzór kratkowy. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) zapewnia jasnoszare tło, a [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) dostarcza żółty kolor wzoru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

Wypełnienie obrazem używa obrazu wewnątrz kształtu. Ten przykład wymaga lokalnego obrazu i używa [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), aby załadować go do kolekcji obrazów prezentacji. Ustawienie [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) na tryb kafelkowy powtarza obraz w prostokącie. Poniżej pokazano używany obraz źródłowy:

![Obraz lotosu](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstury**

Jeśli chcesz ustawić obraz kafelkowany jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków w kształcie.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbity poziomo, pionowo lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

Ten przykład wymaga lokalnego obrazu i konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/), aby powtarzał go w 50 % pierwotnego rozmiaru. Przesunięcia o −32 punkty przesuwają kafelki poziomo i pionowo; wyrównanie prawy‑dolny oraz odbicie w obu kierunkach określają, jak powtarzana tekstura jest rozmieszczona.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

Wypełnienie stałe nadaje kształtowi jeden, jednolity kolor. Ten przykład używa [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), aby ustawić tryb wypełnienia stałego i przypisuje żółty kolor za pomocą [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), a następnie zapisuje prostokąt w prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Kształt z wypełnieniem kolorem stałym](solid-color-fill.png)

## **Użycie tła slajdu jako wypełnienia kształtu**

Użyj [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill), gdy kształt ma odpowiadać tle slajdu, na przykład w szablonie prezentacji. Najpierw ustaw [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) na [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), aby usunąć wszelkie jawne wypełnienie. Dzięki tej kombinacji kształt używa tła slajdu zamiast własnego wypełnienia stylowego. Samo włączenie flagi nie usuwa istniejącego jawnego wypełnienia.

Różni się to od [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): wypełnienie tłem pokrywa obiekty znajdujące się za kształtem obszarem odpowiadającym tle slajdu, natomiast brak wypełnienia pozostawia te obiekty widoczne. Gradient pozostaje wyrównany do slajdu, a nie rozpoczyna się wewnątrz każdego kształtu.

Poniższy przykład tworzy tło mastera dziedziczone przez slajd i umieszcza magentowy pasek za trzema prostokątami. Lewy prostokąt używa tła, środkowy nie ma wypełnienia, a prawy przełącza się z wypełnienia tłem na jawne wypełnienie pomarańczowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Dziedzicz gradient z mastera.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Dodaj ten obiekt jako pierwszy, aby znajdował się za prostokątami.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Wyłącz wypełnienie tłem przed zastosowaniem jawnego wypełnienia.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik, od lewej do prawej: **background fill**, **no fill**, i **explicit fill**. Pasek magentowy jest ukryty przez lewy i prawy prostokąt, ale pozostaje widoczny przez środkowy prostokąt.

![Wypełnienie tłem, brak wypełnienia i jawne pomarańczowe wypełnienie nad magentowym pasmem](background-fill.png)

To samo zachowanie dotyczy tła zdefiniowanego bezpośrednio na slajdzie lub dziedziczonego z układu. Kształt używa rozwiązanego tła slajdu; przykład pozostawia zarówno tło slajdu, jak i układu niezdefiniowane, tak aby dostarczył je master.

## **Ustawienie przezroczystości**

Dla wypełnienia stałego przezroczystość kontroluje komponent alfa koloru: 0 oznacza całkowitą przezroczystość, a 255 pełną nieprzezroczystość. Ten przykład używa wartości alfa 128 dla żółtego prostokąta, co sprawia, że jest on w przybliżeniu w 50 % przezroczysty, dzięki czemu prostokąt pod nim pozostaje widoczny. Kolor jest przypisany za pomocą [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Przezroczy kształt](shape-transparency.png)

## **Obracanie kształtów**

Użyj [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation), aby obrócić kształt w płaszczyźnie slajdu. Kąt mierzony jest w stopniach; ten przykład obraca prostokąt o 5 stopni zgodnie z ruchem wskazówek zegara i zapisuje prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodanie efektów fazowania 3D**

Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat), aby dodać kształtowi głębokość i fazowane krawędzie. Ten przykład tworzy zieloną elipsę z pomarańczowym obramowaniem, używa [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth), aby ustawić głębokość na 4 punkty, i stosuje okrągłe fazowanie górne o szerokości i wysokości 6 punktów za pomocą [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Kamera ortograficzna skierowana przodem i oświetlenie trójpunktowe sprawiają, że fazowanie jest widoczne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Efekt fazowania 3D](3D-bevel-effect.png)

## **Dodanie efektów obrotu 3D**

Widok 3D kształtu kontrolowany jest przez ustawienia kamery. Ten przykład używa [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) z kątami szerokości, długości i obrotu wynoszącymi odpowiednio 40, 35 i 20 stopni. Wybiera kamerę izometryczną przez [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) oraz zrównoważone oświetlenie przez [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), a następnie zapisuje sformatowany prostokąt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Efekt obrotu 3D](3D-rotation-effect.png)

## **Kontrola renderowania czarno‑białego dla kształtów**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedniowy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑białym. Nie włącza ona samego wyświetlania czarno‑białego i nie zmienia wypełnienia, linii ani innych formatów w normalnym trybie kolorów.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/), aby wybrać żądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają jeden kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Ten przykład tworzy pomarańczowy prostokąt i używa [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode), aby ustawić tryb na szary. Zapisany kształt zachowuje pomarańczowe wypełnienie w trybie normalnym i żąda szarego kolorowania od aplikacji, które honorują ustawienia wyświetlania czarno‑białego:

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
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W normalnym trybie kolorów prostokąt zachowuje pomarańczowe wypełnienie. W trybie czarno‑białym używa szarego kolorowania, ponieważ jego tryb jest ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych procesów, które respektują ustawienia wyświetlania czarno‑białego w prezentacji.

## **Resetowanie formatowania**

Użyj [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset), aby przywrócić pozycję, rozmiar i formatowanie placeholderów slajdu z odpowiadających im placeholderów układu. Ten przykład wymaga istniejącej prezentacji z placeholderami połączonymi z układem i resetuje każdy slajd przed zapisaniem. Kształty bez odpowiadających placeholderów układu nie są resetowane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Kolory, style linii i ustawienia efektów zazwyczaj dodają niewiele danych w porównaniu z osadzonymi obrazami i mediami. Wypełnienia obrazami mogą zwiększyć rozmiar pliku, ponieważ ich obrazy są przechowywane w prezentacji.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linia i ustawienia efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, potraktuj ich style jako identyczne i logicznie pogrupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.