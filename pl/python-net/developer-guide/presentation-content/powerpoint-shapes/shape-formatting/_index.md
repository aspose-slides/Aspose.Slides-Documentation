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
- szkic linii kształtu
- formatowanie stylu łączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- obrót kształtu
- efekt 3d nachylenia
- efekt 3d obrotu
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie przy użyciu Aspose.Slides—ustaw style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wstęp**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące wypełnienie ich wnętrz.

![formatowanie‑kształtu‑powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python udostępnia klasy i właściwości, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują tę procedurę:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [styl kreski](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linedashstyle/) kształtu.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak sformatować prostokąt `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ustaw kolor wypełnienia dla kształtu prostokąta.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Zastosuj formatowanie linii prostokąta.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ustaw kolor linii prostokąta.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosowanie efektu szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręcznie narysowaną. Użyj [Shape.line_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/line_format/), aby uzyskać dostęp do ustawień linii, [LineFormat.sketch_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/lineformat/sketch_format/), aby uzyskać dostęp do ustawień szkicu, oraz [SketchFormat.sketch_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sketchformat/sketch_type/), aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linesketchtype/).

Poniższy kod w języku Python pokazuje, jak zastosować efekt [LineSketchType.CURVED](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linesketchtype/), odczytać jawnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.NONE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Uzyskaj dostęp do formatu linii kształtu i jego formatu szkicu.
    sketch_format = shape.line_format.sketch_format

    # Zastosuj efekt szkicu.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Usuń efekt szkicu.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Wartość zwracana przez `SketchFormat.sketch_type` reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu wzorcowego lub slajdu układu, użyj [LineFormat.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/lineformat/get_effective/), uzyskaj właściwość `sketch_format` zwróconego obiektu i odczytaj jego właściwość `sketch_type`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

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

## **Formatowanie stylów łączenia**

Oto trzy dostępne opcje typu łączenia:

* Zaokrąglony
* Miter
* Fazowy

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w rogu kształtu), używa ustawienia **Zaokrąglony**. Jednak przy rysowaniu kształtu o ostrych kątach możesz preferować opcję **Miter**.

![Styl łączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w języku Python demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień Miter, Fazowy i Zaokrąglony:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

	# Pobierz pierwszy slajd.
	slide = presentation.slides[0]

	# Dodaj trzy automatyczne kształty typu Prostokąt.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Ustaw szerokość linii.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Ustaw kolor linii dla każdego prostokąta.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ustaw styl łączenia.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Dodaj tekst do każdego prostokąta.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Zapisz plik PPTX na dysku.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Wypełnienie gradientowe**

W programie PowerPoint wypełnienie gradientowe to opcja formatowania, która pozwala zastosować płynne przejście kolorów do kształtu. Na przykład możesz nałożyć dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `GRADIENT`.
1. Dodaj dwie preferowane kolory wraz z określonymi pozycjami, używając metod `add` kolekcji `gradient_stops` udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak zastosować efekt wypełnienia gradientowego do elipsy:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Elipsa.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Zastosuj formatowanie gradientowe do elipsy.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ustaw kierunek gradientu.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Dodaj dwa punkty gradientu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Zapisz plik PPTX na dysku.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która umożliwia nałożenie dwukolorowego wzoru — takiego jak kropki, paski, krzyżowanie lub szachownica — na kształt. Możesz wybrać własne kolory pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów w celu podniesienia atrakcyjności wizualnej prezentacji. Nawet po wybraniu wstępnie zdefiniowanego wzoru możesz dalej określić dokładne kolory, które mają być użyte.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `PATTERN`.
1. Wybierz styl wzoru z dostępnych opcji.
1. Ustaw [back_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/back_color/) tła wzoru.
1. Ustaw [fore_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/fore_color/) pierwszego planu wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak zastosować wypełnienie wzorem do prostokąta:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Wzorzec.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ustaw styl wzoru.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ustaw kolory tła i pierwszego planu wzoru.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `PICTURE`.
1. Ustaw tryb wypełnienia obrazem na `TILE` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przypisz ten obraz do własności `picture.image` formatu wypełnienia obrazu (`picture_fill_format`) kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

Poniższy kod w języku Python pokazuje, jak wypełnić kształt obrazem:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ustaw typ wypełnienia na Obraz.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ustaw tryb wypełnienia obrazem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Załaduj obraz i dodaj go do zasobów prezentacji.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ustaw obraz.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić obraz w trybie kafelkowania jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących właściwości klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ustawia tryb wypełnienia obrazu — `TILE` lub `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_alignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [tile_flip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_flip/): Kontroluje, czy kafelek jest odwrócony poziomo, pionowo czy w obu kierunkach.
- [tile_offset_x](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [tile_offset_y](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [tile_scale_x](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiuje poziomą skalę kafelka jako procent.
- [tile_scale_y](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    first_slide = presentation.slides[0]

    # Dodaj automatyczny kształt prostokąta.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ustaw typ wypełnienia kształtu na Obraz.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Załaduj obraz i dodaj go do zasobów prezentacji.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Przypisz obraz do kształtu.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Skonfiguruj tryb wypełnienia obrazem i właściwości kafelkowania.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem to opcja formatowania, która wypełnia kształt jednym, jednorodnym kolorem. Ten prosty kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `SOLID`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak zastosować wypełnienie jednolitym kolorem do prostokąta w slajdzie PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ustaw kolor wypełnienia.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientowe, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, pozwalając częściowo widzieć tło lub obiekty pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw typ wypełnienia na `SOLID`.
1. Użyj `Color.from_argb`, aby określić kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]
    
    # Dodaj prostokątny kształt automatyczny z wypełnieniem stałym.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Dodaj przezroczysty prostokątny kształt automatyczny nad stałym kształtem.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość `rotation` kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak obrócić kształt o 5 stopni:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Obróć kształt o 5 stopni.
    shape.rotation = 5

    # Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3‑D nachylenia**

Aspose.Slides pozwala na zastosowanie efektów 3‑D nachylenia do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

Aby dodać efekty 3‑D nachylenia do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/) kształtu, aby określić ustawienia nachylenia.
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak zastosować efekty 3‑D nachylenia do kształtu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Dodaj kształt do slajdu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Ustaw właściwości ThreeDFormat kształtu.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Zapisz prezentację jako plik PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Efekt 3‑D nachylenia](3D-bevel-effect.png)

## **Dodawanie efektów 3‑D obrotu**

Aspose.Slides umożliwia zastosowanie efektów 3‑D obrotu do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

Aby zastosować 3‑D obrót do kształtu:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [camera_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/camera/camera_type/) i [light_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/lightrig/light_type/) kształtu, aby określić 3‑D obrót.
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak zastosować efekty 3‑D obrotu do kształtu:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Zapisz prezentację jako plik PPTX.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Efekt 3‑D obrotu](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod w języku Python pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z polami zastępczymi na [LayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Jedynie minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je grupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości się zgadzają, traktuj ich style jako identyczne i logicznie grupuj takie kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub w pliku szablonu .POTX. Podczas tworzenia nowej prezentacji otwórz szablon, sklonuj potrzebne stylowe kształty i ponownie zastosuj ich formatowanie w wybranych miejscach.