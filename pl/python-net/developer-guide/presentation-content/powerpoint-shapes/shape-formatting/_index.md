---
title: Formatowanie kształtów PowerPoint w Pythonie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/python-net/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem jednolitym
- przezroczystość kształtu
- renderowanie czarno-białe kształtu
- renderowanie kształtu w odcieniach szarości
- obrót kształtu
- efekt fazowania 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie przy użyciu Aspose.Slides — ustawiaj style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

Formatuj kształty w programie PowerPoint, dostosowując ich kontury, wypełnienia i efekty. Aspose.Slides for Python via .NET umożliwia programowe sterowanie tymi ustawieniami, w tym przezroczystością, rotacją i formatowaniem 3D.

![Opcje formatowania kształtów w programie PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET udostępnia klasy i właściwości, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Użyj [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) aby kontrolować obrys kształtu. Ten przykład tworzy niewypełniony prostokąt z niebieskim, przerywanym obrysem. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) wybiera złożoną linię grubą‑cienką, natomiast [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ustawia jej szerokość na 7 punktów, a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) wybiera wzór kreski.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

### **Ustaw niestandardowe wzory przerywania linii**

Użyj [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) gdy predefiniowane style linii nie oferują potrzebnych długości kresek i przerw, np. dla znaków firmowych lub diagramów technicznych. Przypisanie wzoru automatycznie ustawia [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) na [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Wpisy listy naprzemiennie określają długości kresek i przerw, zaczynając od kreski. Każda wartość jest wielokrotnością szerokości linii: `[4, 2]` przy szerokości 3 punktów daje kreskę 12‑punktową, a następnie przerwę 6‑punktową. Używaj par wartości skończonych, nieujemnych, aby zdefiniować pełne segmenty kreska‑przerwa. Przykład używa dodatnich wartości, aby każda kreska i przerwa były widoczne.

Ten przykład tworzy pięć niebieskich linii o tej samej długości i płaskich zakończeniach. Pierwsze trzy porównują wzory przy szerokości 3 punktów. Czwarta powtarza pierwszy wzór przy podwojonej szerokości, podwajając zarówno długość kresek, jak i przerw. Piąta przełącza się z niestandardowego wzoru na linię ciągłą.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Przywróć ostatnią linię do stylu ciągłego.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Aby zamiast tego powrócić do predefiniowanego stylu przerywanego, przypisz [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) do [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Wybrany styl kontroluje wygląd linii.

Wynik w programie PowerPoint, od góry do dołu: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; oraz **Solid, 3 pt**.

![Trzy niestandardowe wzory przerywania, szersza linia wykorzystująca pierwszy wzór oraz linia ciągła w programie PowerPoint](custom-dash-patterns.png)

### **Ustaw zakończenia linii**

Użyj [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) aby ustawić końce otwartej linii. Wyliczenie [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) udostępnia trzy wyraźne style zakończeń:

- `FLAT`: Pędzel zatrzymuje się na końcowym punkcie.
- `ROUND`: Półokrągłe zakończenie wystaje poza punkt końcowy o połowę szerokości linii.
- `SQUARE`: Kwadratowe zakończenie wystaje poza punkt końcowy o połowę szerokości linii.

Wyliczenie zawiera także `NOT_DEFINED`, co oznacza, że żaden styl zakończenia nie jest jawnie przypisany.

Zakończenia różnią się od grotów, które dodają symbole do końców linii, oraz od połączeń, które kontrolują narożniki między segmentami linii. Ten przykład wyłącza groty za pomocą [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) i [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/), aby porównać tylko kształty zakończeń.

Poniższy przykład tworzy trzy w pozostałych aspektach identyczne linie poziome o szerokości 20 punktów. Od góry do dołu używają one płaskich, okrągłych i kwadratowych zakończeń. Ich końcowe punkty mają te same współrzędne poziome; okrągłe i kwadratowe zakończenia wystają 10 punktów poza każdy koniec.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Wynik w programie PowerPoint, od góry do dołu: **Flat**, **Round** i **Square**.

![Płaskie, okrągłe i kwadratowe zakończenia na identycznych grubych liniach w programie PowerPoint](line-caps.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda jak odręcznie narysowana. Użyj [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) aby uzyskać dostęp do ustawień linii, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) aby uzyskać dostęp do ustawień szkicu, oraz [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Poniższy kod w języku Python pokazuje, jak zastosować efekt [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , odczytać jawnie przypisaną wartość oraz usunąć efekt za pomocą [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Wartość zwracana przez [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu nadrzędnego lub slajdu układu, użyj [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), uzyskaj dostęp do [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), i odczytaj [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia. Ten przykład wymaga istniejącej prezentacji z co najmniej jednym kształtem na pierwszym slajdzie i wypisuje obie wartości:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formatowanie stylów łączeń**

Oto trzy opcje typów łączeń:

* Round
* Miter
* Bevel

Styl łączenia kontroluje, w jaki sposób dwa odcinki konturu spotykają się w narożniku. Użyj **Round** dla narożników zaokrąglonych, **Miter** dla ostrych narożników lub **Bevel** dla spłaszczonych narożników.

![Styl łączenia w prezentacji](join-style-powerpoint.png)

Ten przykład tworzy trzy czarne prostokąty z niebieskimi konturami o szerokości 15 punktów. Ustawia [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) na wartości miter, bevel i round z [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), odpowiednio, aby porównać, jak rysowane są narożniki.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Ogranicz łączenia miter przy ostrych narożnikach**

Użyj [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) wraz z [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) ustawionym na [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) , aby ograniczyć, jak daleko może wystawać ostry narożnik.

Limit jest stosunkiem odległości między wewnętrznym a zewnętrznym narożnikiem łączenia do szerokości linii. Na przykład wartość `8` pozwala na długość miter do ośmiu razy szerokość linii; nie jest to pomiar w punktach. Jeśli narożnik przekroczy limit, PowerPoint stosuje połączenie fazowane w tym narożniku. Większy limit umożliwia ostrzejsze punkty. Ustawienie wpływa tylko na połączenia miter, a jego zmiana nie ma widocznego efektu, gdy narożnik pozostaje w granicach limitu.

Ten przykład tworzy dwa identyczne, niewypełnione trójkąty z konturami o szerokości 20 punktów. Lewy trójkąt używa limitu `2`, a prawy `8`. Każdy trójkąt ma szerokość 80 punktów i wysokość 160 punktów, co daje stosunek długości miter w górnym narożniku do szerokości linii około `4,12`. W konsekwencji PowerPoint fazuje lewy wierzchołek i zachowuje prawy wierzchołek.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Wynik w PowerPoint: **Miter limit 2** po lewej i **miter limit 8** po prawej.

![Fazowany wierzchołek z limitem miter 2 oraz spiczasty wierzchołek z limitem miter 8 w programie PowerPoint](miter-limits.png)

## **Wypełnienie gradientem**

Wypełnienie gradientem miesza kolory w obrębie kształtu. Ten przykład wypełnia elipsę gradientem liniowym pod kątem 45 stopni od czerwonego do fioletowego przy użyciu [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Metoda [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) umieszcza punkty zatrzymania koloru na 0 i 1, na początku i końcu gradientu. Usunięcie istniejących punktów zatrzymania zapewnia użycie tylko tych dwóch kolorów.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Choose a Gradient Rendering Style](/slides/pl/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany gradientu przechowywanego w prezentacji.

### **Ustaw kąt gradientu liniowego**

Użyj [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) aby kontrolować orientację wypełnienia [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). Kąt jest mierzony w stopniach i rośnie zgodnie z ruchem zegara: `0` przebiega od lewej do prawej, `90` od góry do dołu, `180` od prawej do lewej, a `270` od dołu do góry. Obsługiwane są kąty ułamkowe. Kąty skończone poza zakresem `[0, 360)` są normalizowane do jednego obrotu; na przykład `-45` staje się `315`, a `360` staje się `0`.

Ten przykład tworzy sześć prostokątów z identycznymi punktami zatrzymania czerwonego, zielonego i niebieskiego w pozycjach `0`, `0.5` i `1`. Skalowanie jest wyłączone, aby kąt można było porównać niezależnie od proporcji prostokątów. Kąty, od lewej do prawej, to `0`, `45` i `90` w pierwszym wierszu oraz `135`, `180` i `270` w drugim wierszu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Wynik w programie PowerPoint:

![Gradienty liniowe pod kątem 0, 45 i 90 stopni w górnym wierszu oraz 135, 180 i 270 stopni w dolnym wierszu](linear-gradient-angles.png)

### **Skaluj gradient liniowy z kształtem**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) przyjmuje wartość [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Ustaw ją jawnie na `FALSE`, aby zachować geometryczny kąt gradientu przy zmianie proporcji kształtu, lub na `TRUE`, aby skalować gradient wraz z szerokością i wysokością kształtu. Przy włączonym skalowaniu widoczny kąt może różnić się od przypisanego kąta w kształcie niekwadratowym.

Poniższy przykład używa kąta `45` stopni oraz tych samych punktów zatrzymania kolorów co porównanie kątów. Lewa kolumna używa `FALSE`; prawa kolumna używa `TRUE`. Każda kolumna zawiera szeroki prostokąt nad wysokim prostokątem. Oba zaczynają się od tych samych szerokich wymiarów; zmiana szerokości i wysokości drugiego prostokąta pokazuje, jak wypełnienie reaguje na zmianę rozmiaru bez zmiany ustawień gradientu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Wynik w programie PowerPoint, przy wyłączonym skalowaniu po lewej i włączonym po prawej:

![Szerokie i wysokie prostokąty z gradientem 45‑stopni, porównujące linear_gradient_scaled FALSE po lewej i TRUE po prawej](linear-gradient-scaling.png)

Przy wyłączonym skalowaniu, skośne pasma kolorów zachowują tę samą orientację w obu prostokątach. Przy włączonym skalowaniu pasma rozciągają się zgodnie z proporcjami kształtu. Pomaga to odtworzyć gradient szablonu przy dostosowywaniu kształtu do innego rozmiaru. W kwadracie włączenie skalowania nie zmienia wyglądu tego gradientu 45‑stopni.

Zarówno ustawienie kąta, jak i skalowania dotyczą gradientów liniowych. Nie sterują one wypełnieniami [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Połącz kąt z kierunkiem gradientu**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) wybiera styl gradientu z wyliczenia [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/). Nie jest to zamiennik kąta liczbowego. Dla gradientu liniowego style narożników mogą zmieniać obszar, na którym rozłożone są kolory, bez zmiany [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Zachowaj niezmieniony kierunek przy porównywaniu kątów lub skalowaniu.

Poniższy przykład stosuje te same ustawienia w odwrotnej kolejności. Dwa prostokąty mają taki sam wygląd: przypisanie kierunku przed lub po kącie nie zmienia wyniku.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Wypełnienie wzorem**

Wypełnienie wzorem nakłada dwukolorowy wzór, taki jak kropki, paski lub kratkę. Ten przykład używa [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) aby wybrać wzór kratkowy. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) podaje jasnoszare tło, a [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) podaje żółty kolor wzoru.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

Wypełnienie obrazem używa obrazu wewnątrz kształtu. Ten przykład wymaga lokalnego obrazu i używa [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) aby załadować go do kolekcji obrazów prezentacji. Ustawienie [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) na tryb kafelkowy powtarza obraz w obrębie prostokąta. Poniżej pokazano użyty obraz źródłowy:

![Obraz lotosu](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Użyj obrazu jako tekstury kafelkowej**

Jeśli chcesz ustawić obraz kafelkowy jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących właściwości klasy [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ustawia tryb wypełnienia obrazu — `TILE` lub `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Kontroluje, czy kafelek jest odbity poziomo, pionowo, czy w oba sposoby.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiuje poziomą skalę kafelka jako procent.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiuje pionową skalę kafelka jako procent.

Ten przykład wymaga lokalnego obrazu i konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) aby powtarzał go w 50 % oryginalnego rozmiaru. Przesunięcia o −32 punkty przesuwają kafelki poziomo i pionowo; wyrównanie do prawego dolnego rogu oraz odbicie w obu kierunkach określają, jak powtarzana tekstura jest rozmieszczona.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem jednolitym**

Wypełnienie jednolite nadaje kształtowi pojedynczy, jednorodny kolor. Ten przykład ustawia [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na tryb wypełnienia jednolitego i przypisuje żółty kolor za pomocą [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), a następnie zapisuje prostokąt w prezentacji.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Kształt z jednolitym wypełnieniem kolorowym](solid-color-fill.png)

### **Kopiuj kolory zachowując odwołania do motywu**

Użyj [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) aby skopiować definicję koloru, w tym jego typ, odwołanie do motywu i transformacje. Jest to przydatne przy przenoszeniu koloru wypełnienia między kształtami, które powinny nadal podążać za motywem prezentacji. Metoda kopiuje tylko kolor: nie kopiuje typu wypełnienia, obrysu ani innych formatowań kształtu. Ustaw jawnie [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) w miejscu docelowym.

Ten przykład tworzy trzy prostokąty, od lewej do prawej: źródło, kopię świadomą motywu oraz kopię o stałym RGB. Źródło używa [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) aby odwołać się do pierwszego koloru akcentu i dodaje odcień za pomocą [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). Kopia RGB używa efektywnego koloru wypełnienia źródła, więc wszystkie trzy początkowo wyglądają identycznie. Przypisanie [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) ustawia stałą wartość RGB i usuwa wszelkie istniejące transformacje koloru.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Odwołania do motywu podążają za nowym kolorem akcentu; stała wartość RGB nie podąża.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Przed zmianą motywu wszystkie trzy wypełnienia pasują:

![Źródło, docelowy copy_from i docelowy stały RGB z identycznymi niebieskimi wypełnieniami](color-copy-before.png)

Po zmianie motywu źródło i kopia świadoma motywu podążają za nowym kolorem akcentu i zachowują swój odcień. Kopia stałego RGB pozostaje niebieska:

![Źródło i docelowy copy_from z pomarańczowymi wypełnieniami, podczas gdy docelowy stały RGB pozostaje niebieski](color-copy-after.png)

Skopiowana definicja jest niezależna od źródła. Późniejsze zmiany odwołania do motywu źródła, przypisanie innego koloru lub dodanie lub usunięcie jego transformacji nie zmieniają miejsca docelowego. Zmiana motywu nadal wpływa na oba kształty, ponieważ każdy niezależnie odwołuje się do tego samego koloru motywu.

Zapisanie i ponowne otwarcie pliku PPTX zachowuje skopiowany kolor wraz z [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), odwołaniem do motywu i kolekcją [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) ; nie spłaszcza definicji do RGB.

Podczas kopiowania między różnymi kontekstami motywu, takimi jak prezentacje z różnymi paletami akcentów, skopiowane odwołanie jest rozwiązywane względem motywu miejsca docelowego. To samo odwołanie i transformacje mogą więc dawać inny widoczny kolor. Zobacz [Presentation Theme](/slides/pl/python-net/presentation-theme/) po więcej informacji o konfigurowaniu kolorów motywu.

## **Użyj tła slajdu jako wypełnienia kształtu**

Użyj [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) gdy kształt ma pasować do tła slajdu, na przykład w szablonie prezentacji. Najpierw ustaw [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) , aby usunąć jakiekolwiek wyraźne wypełnienie. Dzięki temu połączeniu kształt używa tła slajdu zamiast własnego wypełnienia stylu. Włączenie samej flagi nie usuwa istniejącego wyraźnego wypełnienia.

Różni się to od [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): wypełnienie tłem pokrywa obiekty za kształtem obszarem odpowiadającym tłu slajdu, podczas gdy brak wypełnienia pozostawia te obiekty widoczne. Gradient pozostaje wyrównany do slajdu, a nie rozpoczyna się wewnątrz każdego kształtu.

Poniższy przykład tworzy tło master, które jest dziedziczone przez slajd i umieszcza magentowy pasek za trzema prostokątami. Lewy prostokąt używa tła, środkowy prostokąt nie ma wypełnienia, a prawy prostokąt przełącza się z wypełnienia tłem na wyraźne pomarańczowe wypełnienie.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Dziedzicz gradient z mastera.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Dodaj ten obiekt najpierw, aby pojawił się za prostokątami.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Wyłącz wypełnienie tłem przed zastosowaniem wyraźnego wypełnienia.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik, od lewej do prawej: **background fill**, **no fill** i **explicit fill**. Magentowy pasek jest ukryty przez lewy i prawy prostokąt, ale pozostaje widoczny przez środkowy prostokąt.

![Wypełnienie tłem, brak wypełnienia i wyraźne pomarańczowe wypełnienie nad magentowym paskiem](background-fill.png)

To samo zachowanie dotyczy tła zdefiniowanego bezpośrednio na slajdzie lub dziedziczonego z układu. Kształt używa rozwiązanego tła slajdu; przykład pozostawia zarówno tło slajdu, jak i układu niezdefiniowane, aby dostarczyło je master.

## **Ustaw przezroczystość**

Dla jednolitego wypełnienia składnik alfa koloru kontroluje nieprzezroczystość: 0 oznacza całkowitą przezroczystość, a 255 pełną nieprzezroczystość. Ten przykład używa wartości alfa 128 dla żółtego prostokąta, czyniąc go w przybliżeniu w 50 % przezroczystym, tak aby prostokąt pod nim pozostał widoczny. Kolor jest przypisany za pomocą [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![Przezroczysty kształt](shape-transparency.png)

## **Obracaj kształty**

Użyj [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) , aby obrócić kształt w płaszczyźnie slajdu. Kąt jest mierzony w stopniach; ten przykład obraca prostokąt o 5 stopni zgodnie z ruchem zegara i zapisuje prezentację.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D Fazowania**

Użyj [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) , aby nadać kształtowi głębię i fazowane krawędzie. Ten przykład tworzy zieloną elipsę z pomarańczowym obrysem, ustawia [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) na 4 punkty i stosuje okrągłe fazowanie górne o szerokości i wysokości 6 punktów za pomocą [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Kamera ortograficzna skierowana na front oraz oświetlenie trójpunktowe sprawiają, że fazowanie jest widoczne.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt 3D fazowania](3D-bevel-effect.png)

## **Dodaj efekty 3D Obracania**

Widok 3D kształtu jest kontrolowany przez ustawienia kamery. Ten przykład używa [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) z kątami szerokości, długości i obrotu wynoszącymi odpowiednio 40, 35 i 20 stopni. Wybiera kamerę izometryczną za pomocą [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) , a zbalansowane oświetlenie przez [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) , po czym zapisuje sformatowany prostokąt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt 3D obrotu](3D-rotation-effect.png)

## **Kontroluj renderowanie czarno‑białe dla kształtów**

Właśćność [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑białym. Nie włącza ona samej wyświetlania w czerni‑bieli i nie zmienia wypełnienia, linii ani innych formatowań kształtu w trybie normalnym.

Użyj wartości z wyliczenia [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) , aby wybrać pożądane zachowanie. Na przykład `AUTOMATIC` pozwala aplikacji renderującej wybrać konwersję, `GRAY` i `LIGHT_GRAY` używają szarego koloru, `BLACK_WHITE` używa wyłącznie czerni i bieli, `BLACK` i `WHITE` wymuszają pojedynczy kolor, `COLOR` zachowuje normalne kolory, a `HIDDEN` pomija kształt w trybie czarno‑białym. `NOT_DEFINED` oznacza, że nie przypisano trybu na poziomie kształtu.

Ten przykład tworzy pomarańczowy prostokąt i ustawia [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) na szary. Zapisany kształt zachowuje pomarańczowe wypełnienie w normalnym wyświetlaniu kolorów i żąda szarego koloru od aplikacji, które respektują ustawienia wyświetlania czarno‑białego:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

W normalnym trybie kształt zachowuje pomarańczowe wypełnienie. W przepływie pracy czarno‑białego używa szarego koloru, ponieważ jego tryb jest ustawiony na `GRAY`. Umożliwia to zachowanie slajdu w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych przepływów pracy, które respektują ustawienia wyświetlania czarno‑białego prezentacji.

## **Resetowanie formatowania**

Użyj [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) , aby przywrócić położenie, rozmiar i formatowanie elementów zastępczych slajdu z ich odpowiadającymi elementami zastępczymi układu. Ten przykład wymaga istniejącej prezentacji z elementami zastępczymi powiązanymi z układem i resetuje każdy slajd przed zapisaniem. Kształty bez odpowiadających elementów zastępczych układu nie są resetowane.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Kolory, style linii i ustawienia efektów zazwyczaj dodają niewiele danych w porównaniu z osadzonymi obrazami i mediami. Wypełnienia obrazem mogą zwiększyć rozmiar pliku, ponieważ ich obrazy są przechowywane w prezentacji.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je grupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające wartości się zgadzają, potraktuj ich style jako identyczne i logicznie pogrupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonu lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.