---
title: Zarządzanie akapitami tekstu PowerPoint w Pythonie
linktitle: Zarządzanie akapitem
type: docs
weight: 40
url: /pl/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- dodaj tekst
- dodaj akapit
- zarządzaj tekstem
- zarządzaj akapitem
- zarządzaj wypunktowaniem
- wcięcie akapitu
- wcięcie zwisające
- wypunktowanie akapitu
- lista numerowana
- lista wypunktowana
- właściwości akapitu
- import HTML
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksport akapitu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) reprezentuje pojedynczy akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) reprezentuje ciąg tekstowy w obrębie akapitu. Każdy fragment może mieć własny tekst oraz formatowanie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych właściwościach formatowania, wykorzystując wiele fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przez jego indeks.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Skorzystaj z domyślnego akapitu i dodaj dwa kolejne obiekty [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) do każdego akapitu, aby zawierały po trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków poprzez [Portion.portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/portion_format/).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Python implementuje powyższe kroki:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Tworzenie list wypunktowanych i numerowanych**

### **Tworzenie listy wypunktowanej lub numerowanej**

Punkty i numeracja ułatwiają skanowanie powiązanych elementów. W Aspose.Slides ustawienia listy definiuje się za pomocą [BulletFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przez jego indeks.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) dla punktu symbolicznego.
7. Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/) i określ znak wypunktowania.
8. Ustaw tekst akapitu, wcięcie, kolor wypunktowania oraz wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego wypunktowania i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład w języku Python tworzy wypunktowanie symboliczne oraz numerowane:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Użycie wypunktowania obrazkowego**

Wypunktowanie obrazkowe pozwala użyć własnego obrazu zamiast symbolu lub liczby.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przez jego indeks.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) i uzyskaj dostęp do jego [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Załaduj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/).
8. Przypisz obraz poprzez [BulletFormat.picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/picture/) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Python tworzy wypunktowanie obrazkowe:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Tworzenie listy wielopoziomowej**

Ustaw [ParagraphFormat.depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/depth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) oraz usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [ParagraphFormat.depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/depth/) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w języku Python tworzy czteropoziomową listę wypunktowaną:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Rozpoczynanie numerowanych elementów listy od własnych wartości**

Użyj [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) na `2`, `3` i `7` dla kolejnych akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w języku Python przypisuje własny początkowy numer każdemu akapitowi:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawianie wcięcia pierwszej linii**

Użyj właściwości [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) aby kontrolować wcięcie pierwszej linii akapitu. Właściwość ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do ciała akapitu.

Używaj [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/margin_left/) gdy musisz przesunąć cały akapit. Używaj [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) gdy potrzebne jest jedynie wcięcie pierwszej linii.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

### **Ustawianie wcięcia zwisającego**

Wcięcie zwisające to układ akapitu, w którym pierwsza linia zaczyna się bardziej po lewej niż pozostałe linie. W Aspose.Slides efekt ten uzyskuje się przy pomocy właściwości [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/). Ustaw `indent` na wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/margin_left/) definiuje lewą pozycję ciała akapitu, a [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) określa pozycję pierwszej linii względem tego marginesu. Aby uzyskać wcięcie zwisające, ustaw dodatnią wartość `margin_left` oraz ujemną wartość `indent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których zwijane linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/margin_left/) dla każdego z nich.
6. Ustaw ujemną wartość [ParagraphFormat.indent](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/indent/) aby uzyskać efekt wcięcia zwisającego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie zwisające dla akapitu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wcięcie zwisające akapitów](hanging_indent.png)

### **Ustawianie właściwości końcowych akapitu**

Właściwość [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) kontroluje formatowanie znaku końca akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końca drugiego akapitu:

1. Załaduj [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) i usuń jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/) dla znaku końca drugiego akapitu.
5. Ustaw [PortionFormat.font_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/font_height/) oraz [PortionFormat.latin_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/latin_font/).
6. Przypisz format do [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) i zapisz prezentację.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Import i eksport zawartości akapitu**

### **Import tekstu HTML do akapitów**

Użyj [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphcollection/add_from_html/) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
4. Odczytaj źródłowy plik HTML.
5. Przekaż ciąg HTML do [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Python importuje HTML do ramki tekstowej:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphcollection/export_to_html/) aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) zawierający tekst.
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
4. Wywołaj [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphcollection/export_to_html/) podając indeks początkowego akapitu i liczbę akapitów do wyeksportowania.
5. Zapisz zwrócony ciąg HTML do pliku.

Ten przykład w języku Python eksportuje wszystkie akapity z pierwszego kształtu tekstowego:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Renderowanie akapitu jako obrazu**

[Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) udostępnia metodę `get_image` umożliwiającą renderowanie pojedynczego akapitu bezpośrednio. Metoda zwraca obiekt [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/), który można zapisać do pliku lub strumienia przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/save/). Nie trzeba renderować całego kształtu ani ręcznie przycinać bitmapy.

Metoda `get_image` może zwrócić `None`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź rezultat przed zapisem i użyj zwróconego obrazu jako menedżera kontekstu, aby zwolnić zasoby.

#### **Renderowanie akapitu w skali domyślnej**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, a pierwszym kształtem jest pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym kształcie tekstowym w skali domyślnej i zapisuje zwrócony obraz w formacie PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Przekaż współczynniki skalowania poziomego i pionowego do `get_image`, aby kontrolować rozmiar renderowanego akapitu. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnym zwiększeniu zarówno szerokości, jak i wysokości, i zapisuje wynik jako obraz PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Współczynnik `1` pozostawia daną oś w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników daje obraz, którego szerokość i wysokość są w przybliżeniu dwa razy większe niż domyślne wymiary, co skutkuje czterokrotną liczbą pikseli. Wyższe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` produkują mniejsze obrazy z mniejszą szczegółowością. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu przy użyciu [Shape.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/) jest przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu wyłącznie akapitu użyj `Paragraph.get_image`.

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie linii w ramce tekstowej?**

Tak. Ustaw [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/wrap_text/) aby wyłączyć łamanie, dzięki czemu linie nie będą dzielone przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice akapitu na slajdzie?**

Użyj [Paragraph.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/get_rect/) aby pobrać prostokąt otaczający akapit. [Portion.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_rect/) dostarcza granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyrównane)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/alignment/) jest ustawieniem na poziomie akapitu i obowiązuje cały akapit, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [PortionFormat.language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/language_id/) dla poszczególnych fragmentów, dzięki czemu jeden akapit może zawierać tekst w kilku językach.