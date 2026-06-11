---
title: Formatowanie kształtów PowerPoint w Pythonie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/python-net/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem jednolitym
- przezroczystość kształtu
- obracanie kształtu
- efekt krawędzi 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Pythonie przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące wypełnienie ich wnętrza.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python udostępnia klasy i właściwości, które pozwalają formatować kształty przy użyciu tych samych opcji, co w PowerPoint.

## **Formatowanie linii**

Przy użyciu Aspose.Slides możesz określić niestandardowy styl linii dla kształtu. Poniżej przedstawiono poszczególne kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linedashstyle/) kształtu.
1. Ustaw kolor linii kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak sformatować prostokąt `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ustaw kolor wypełnienia dla prostokątnego kształtu.
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

## **Formatowanie stylów łączenia**

Oto trzy dostępne opcje typu łączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w rogu kształtu), używa ustawienia **Round**. Jeśli jednak rysujesz kształt o ostrych kątach, możesz preferować opcję **Miter**.

![Styl łączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w języku Python demonstruje, jak trzy prostokąty (jak na powyższym obrazku) zostały utworzone przy użyciu ustawień łączenia Miter, Bevel i Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

	# Pobierz pierwszy slajd.
	slide = presentation.slides[0]

	# Dodaj trzy auto kształty typu Prostokąt.
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

	# Ustaw kolor linii każdego prostokąta.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ustaw styl połączenia.
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

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Jak zastosować wypełnienie gradientem w kształcie przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `GRADIENT`.
1. Dodaj dwie wybrane kolory wraz z określonymi pozycjami, używając metod `add` kolekcji `gradient_stops` udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python pokazuje, jak zastosować efekt wypełnienia gradientem do elipsy:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Elipsa.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Zastosuj formatowanie gradientowe do elipsy.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ustaw kierunek gradientu.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Dodaj dwa przystanki gradientu.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Zapisz plik PPTX na dysku.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — na przykład kropki, paski, krzyżowe kreski lub kratkę — w kształcie. Możesz wybrać własne kolory pierwszego i tła wzoru.

Aspose.Slides udostępnia ponad 45 predefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu predefiniowanego wzoru możesz określić dokładne kolory, które mają zostać użyte.

Jak zastosować wypełnienie wzorem w kształcie przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `PATTERN`.
1. Wybierz styl wzoru z predefiniowanych opcji.
1. Ustaw [back_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/back_color/) wzoru.
1. Ustaw [fore_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/fore_color/) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Wzór.
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

Jak użyć Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `PICTURE`.
1. Ustaw tryb wypełnienia obrazem na `TILE` (lub inny wybrany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przypisz ten obraz do właściwości `picture.image` formatu wypełnienia obrazu (`picture_fill_format`) kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” o następującym obrazie:

![Obraz lotosu](lotus.png)

Poniższy kod w języku Python pokazuje, jak wypełnić kształt obrazem:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ustaw typ wypełnienia na Obraz.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ustaw tryb wypełnienia obrazem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Wczytaj obraz i dodaj go do zasobów prezentacji.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ustaw obraz.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Obraz kafelkowy jako tekstura**

Jeśli chcesz ustawić obraz kafelkowy jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących właściwości klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ustawia tryb wypełnienia obrazem — `TILE` lub `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_alignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [tile_flip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_flip/): Kontroluje, czy kafelek jest odbity w poziomie, w pionie lub w obu kierunkach.
- [tile_offset_x](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [tile_offset_y](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [tile_scale_x](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definiuje poziomą skalę kafelka w procentach.
- [tile_scale_y](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definiuje pionową skalę kafelka w procentach.

Poniższy fragment kodu pokazuje, jak dodać prostokątny kształt z kafelkowym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    first_slide = presentation.slides[0]

    # Dodaj auto kształt prostokąta.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ustaw typ wypełnienia kształtu na Obraz.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Wczytaj obraz i dodaj go do zasobów prezentacji.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Przypisz obraz do kształtu.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
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

## **Wypełnienie kolorem jednolitym**

W programie PowerPoint wypełnienie kolorem jednolitym to opcja formatowania, która wypełnia kształt jednym, równomiernym kolorem. Ten jednolity kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem jednolitym w kształcie przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) kształtu na `SOLID`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Python demonstruje, jak zastosować wypełnienie kolorem jednolitym do prostokąta w slajdzie PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ustaw typ wypełnienia na Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ustaw kolor wypełnienia.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Kształt z wypełnieniem kolorem jednolitym](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą w kształtach, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, co umożliwia częściowe widocznie tła lub obiektów leżących pod nim.

Aspose.Slides pozwala ustawić poziom przezroczystości, zmieniając wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw typ wypełnienia na `SOLID`.
1. Użyj `Color.from_argb`, aby zdefiniować kolor z przezroczystością (składnik `alpha` steruje przezroczystością).
1. Zapisz prezentację.

Poniższy kod w języku Python demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]
    
    # Dodaj prostokątny auto kształt wypełniony.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Dodaj przezroczysty prostokątny auto kształt nad wypełnionym kształtem.
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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość `rotation` kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod w języku Python demonstruje, jak obrócić kształt o 5 stopni:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto kształt typu Prostokąt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Obróć kształt o 5 stopni.
    shape.rotation = 5

    # Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3‑D (krawędź)**

Aspose.Slides pozwala zastosować efekty 3‑D krawędzi do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

Aby dodać efekty 3‑D krawędzi do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/) kształtu, aby zdefiniować ustawienia krawędzi.
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak zastosować efekty 3‑D krawędzi do kształtu:

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

![Efekt 3‑D krawędzi](3D-bevel-effect.png)

## **Dodawanie efektów 3‑D (obrót)**

Aspose.Slides umożliwia zastosowanie efektów 3‑D obrotu do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

Aby zastosować obrót 3‑D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwości [camera_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/camera/camera_type/) i [light_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/lightrig/light_type/) kształtu, aby określić obrót 3‑D.
1. Zapisz prezentację.

Poniższy kod w języku Python demonstruje, jak zastosować efekty 3‑D obrotu do kształtu:

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

Poniższy kod w języku Python pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami w [LayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/) do ustawień domyślnych:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Zresetuj każdy kształt na slajdzie, który ma symbol zastępczy w układzie.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko w niewielkim stopniu. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, natomiast parametry kształtów, takie jak kolory, efekty czy gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku i ponownie używać go w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie decku lub w pliku szablonu .POTX. Podczas tworzenia nowej prezentacji otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie w odpowiednich miejscach.