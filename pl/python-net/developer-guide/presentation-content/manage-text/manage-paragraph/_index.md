---
title: Zarządzanie akapitami tekstu w PowerPoint przy użyciu Pythona
linktitle: Zarządzaj akapitem
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
- zarządzaj punktami
- wcięcie akapitu
- wcięcie wiszące
- punkt akapitu
- lista numerowana
- lista punktowana
- właściwości akapitu
- importuj HTML
- tekst na HTML
- akapit na HTML
- akapit na obraz
- tekst na obraz
- eksportuj akapit
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) reprezentuje pojedynczy akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) reprezentuje ciąg znaków w akapicie. Każdy fragment może mieć własne formatowanie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatach, używając wielu fragmentów.

## **Utwórz i formatuj akapity**

Utwórz akapity w ramce tekstowej kształtu i używaj fragmentów do formatowania poszczególnych ciągów tekstowych. Ten rozdział pokazuje, jak połączyć wiele fragmentów w każdym akapicie oraz zastosować różne kolory, rozmiary czcionek i style.

### **Utwórz akapity z wieloma fragmentami**

Poniższy przykład w Pythonie tworzy trzy akapity, każdy zawierający trzy ciągi tekstu w kolekcji [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Ponownie używa domyślnego akapitu i jego pustego fragmentu, a następnie dodaje pozostałe akapity i fragmenty. Formatowanie jest stosowane przez [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): pierwszy fragment w każdym akapicie jest czerwony, pogrubiony i ma 15 punktów; drugi jest niebieski, kursywa i ma 18 punktów. Trzeci fragment zachowuje domyślne formatowanie:

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

## **Utwórz listy punktowane i numerowane**

Organizuj tekst akapitu w listy z symbolami, numerami lub własnymi obrazami. Przykłady w tym rozdziale obejmują formatowanie punktów, listy wielopoziomowe i własne liczby początkowe.

### **Utwórz listę punktowaną lub numerowaną**

Punkty i numeracja ułatwiają szybkie przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane przez [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Ten przykład w Pythonie dodaje symbol punktu i element numerowany do tej samej ramki tekstowej. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) wybiera typ punktu, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) dostarcza symbol, a [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) wybiera styl numeracji. Oba elementy używają czarnych punktów o wysokości 100 % i wcięcia akapitu wynoszącego 25 punktów:

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

### **Użyj punktów obrazkowych**

Punkty obrazkowe pozwalają użyć własnego obrazu zamiast symbolu lub numeru.

Przykład wymaga pliku `bullets.png` w katalogu roboczym. Ten przykład w Pythonie dodaje obraz do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) i używa go jako punktu akapitu. Ustawia [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na punkt obrazkowy i przypisuje obraz przez [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) jest ustawiony na 100 % aby dopasować rozmiar punktu względem tekstu akapitu:

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

### **Utwórz listę wielopoziomową**

Ustaw [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

Ten przykład w Pythonie przypisuje wartości [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) od 0 do 3 czterem akapitom, tworząc hierarchię w jednej ramce tekstowej. Każdy akapit używa punktu symbolicznego, a [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) naprzemiennie przełącza się między okrągłym punktem a dywizem, aby odróżnić sąsiadujące poziomy:

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

### **Rozpocznij numerowaną listę od własnych wartości**

Użyj [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

Ten przykład w Pythonie ustawia [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na numerację dla trzech akapitów i przypisuje wartości [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 2, 3 i 7. Wartość początkowa jest konfigurowana oddzielnie dla każdego akapitu, co pozwala pomijać wybrane liczby:

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

## **Kontroluj układ akapitu i właściwości końcowe**

Dostosuj marginesy i wcięcia akapitu, aby kontrolować położenie pierwszej linii oraz linii zawiniętych. Możesz także sformatować znak końca akapitu osobno od widocznych fragmentów tekstu.

### **Ustaw wcięcie pierwszej linii**

Użyj właściwości [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) aby kontrolować wcięcie pierwszej linii akapitu. Właściwość ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład nadaje trzem akapitom ten sam [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) = 20 punktów oraz wartości [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) = 0, 20 i 40 punktów. Pierwsze linie zaczynają się w coraz większych odstępach, podczas gdy linie zawinięte zachowują ten sam lewy margines:

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

### **Ustaw wcięcie wiszące**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy właściwości [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Ustaw `indent` na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) definiuje lewą pozycję treści akapitu, a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) definiuje pozycję pierwszej linii względem tego marginesu. Aby uzyskać wcięcie wiszące, ustaw dodatnią wartość `margin_left` i ujemną wartość `indent`.

Takie formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których linie zawinięte muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

Poniższy przykład w Pythonie łączy wartości [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) = 40 i 60 punktów z wartościami [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) = -20 i -30 punktów. W każdym akapicie pierwsza linia zaczyna się po lewej stronie linii zawiniętych; drugi akapit ma głębsze wcięcie wiszące:

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

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustaw właściwości końcowego fragmentu akapitu**

Właściwość [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) kontroluje formatowanie znaku końca akapitu. Przykład ładuje `Test.pptx`, który musi zawierać co najmniej jeden slajd, i tworzy [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) z [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) = 48 punktów oraz [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) = Times New Roman. Przypisuje ten format do znaku końcowego drugiego akapitu, pozostawiając niezmienione widoczne fragmenty tekstu:

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

## **Policz wyrenderowane wiersze**

Dla reguł akapitu wpływających na automatyczne zawijanie i interpunkcję na końcach wierszy, zobacz [Control Line Breaking](/slides/pl/python-net/text-formatting/#control-line-breaking) oraz [Control Hanging Punctuation](/slides/pl/python-net/text-formatting/#control-hanging-punctuation).

Użyj [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) aby policzyć wiersze zajmowane przez akapit po rozmieszczeniu tekstu, w tym automatyczne zawijanie. Jest to przydatne przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), i może zajmować kilka wyrenderowanych wierszy. Jawny podział wiersza wewnątrz akapitu wymusza nowy wiersz bez tworzenia nowego akapitu. Automatyczne zawijanie tworzy wiersze na podstawie dostępnej szerokości, nie wstawiając jawnych znaków podziału w tekście. Dlatego liczenie akapitów lub znaków podziału nie daje liczby wyrenderowanych wierszy.

Poniższy przykład tworzy kształt tekstowy, liczy jego wiersze, zwęża kształt, a następnie zastępuje tekst krótszym ciągiem. Przykład włącza [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) i wyłącza [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/), tak aby szerokość kształtu kontrolowała zawijanie bez automatycznego zmniejszania tekstu ani rozmiaru kształtu. Każdy pomiar używa [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Wymiary kształtu podane są w punktach. Na końcu przykład dodaje kolejny akapit i sumuje liczby wierszy w całej ramce tekstowej.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Przy tym tekście i tych wymiarach zwężenie kształtu zwiększa liczbę wierszy, natomiast zastąpienie tekstu krótkim ciągiem ją zmniejsza. Dokładne wyniki mogą się różnić w zależności od dostępności czcionek i ich podstawień, rozmiaru czcionki, marginesów, wcięć, zawijania i ustawień autofitu. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy weryfikacji szablonu.

Liczba wierszy sama w sobie nie określa, czy tekst przekracza swój kontener. Ważna jest dostępna wysokość, wysokość wierszy, odstępy między akapitami i wierszami oraz zachowanie autofitu; nawet pojedynczy wiersz może wykraczać poza dostępną szerokość, gdy zawijanie jest wyłączone.

## **Import i eksport treści akapitów**

Użyj HTML, aby wprowadzić tekst do prezentacji lub wyeksportować istniejące akapity do użycia poza nią. Ten rozdział pokazuje również, jak renderować pojedyncze akapity jako obrazy, w tym akapity w komórkach tabel.

### **Importuj tekst HTML do akapitów**

Użyj [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) aby przekonwertować znacznik HTML na akapity i fragmenty w ramce tekstowej.

Ten przykład w Pythonie odczytuje HTML z pliku `file.html` w katalogu roboczym i przekazuje znacznik do [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Czyści domyślny akapit ramki tekstowej, aby ramka zawierała wyłącznie zaimportowaną treść. Prostokątny kształt pozostawia margines 10 punktów po każdej stronie slajdu:

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

### **Eksportuj tekst akapitu do HTML**

Użyj [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) aby wyeksportować wybrany zakres akapitów jako HTML. Gdy ponownie używasz tekstu prezentacji na stronie internetowej, możesz chcieć zachować lokalne wyróżnienia bez przenoszenia czcionki, rozmiaru czy stylów pola tekstowego prezentacji. Ustaw [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) aby kontrolować, jak daleko eksporter podąża za dziedziczeniem formatowania.

Pobierz [przykładową prezentację](text-inheritance.pptx) i umieść ją w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera jeden kształt tekstowy z tekstem „Inherited text; explicit red 18pt”. Wejście celowo używa kilku poziomów formatowania:

- Domyślny styl tekstu prezentacji dostarcza czcionkę Calibri i rozmiar 28 pt.
- Styl tekstu pierwszego poziomu ramki tekstowej dostarcza niebieski tekst i kursywę.
- Akapit wyraźnie ustawia pogrubiony tekst.
- Drugi fragment, „explicit red 18pt”, wyraźnie ustawia czerwony tekst i rozmiar 18 pt.

Poniższy kompletny przykład eksportuje te same akapity trzy razy. Przekazuje [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) do metody eksportu i zapisuje każdy wynik jako osobny plik HTML w kodowaniu UTF‑8:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Wygenerowany HTML zawiera następujący CSS dla pierwszego fragmentu, „Inherited text; ”. Tabela wymienia odpowiednie deklaracje; inne wygenerowane właściwości są pominięte dla przejrzystości.

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa w 28 pt w Calibri, jeśli ta czcionka jest dostępna. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki i rozmiar. |
| `ParagraphOnly.html` | `font-weight:bold` | Pogrubiony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki, rozmiar, kolor i styl kursywy. |

Drugi fragment zachowuje `color:#ff0000`, `font-size:18pt` i `font-weight:bold` we wszystkich trzech wynikach. Zachowuje także kursywę w `ALL` i `TEXT_BOX`, ale nie w `PARAGRAPH_ONLY`. Ograniczenie dziedziczenia nie usuwa więc formatowania przypisanego explicite do akapitu lub fragmentu.

Otwórz pliki w tej samej przeglądarce, aby je porównać. W dwóch trybach ograniczonych pominięte właściwości CSS są rozwiązywane przez style strony docelowej lub domyślne style przeglądarki, więc ostateczny wygląd zależy od miejsca użycia HTML.

### **Renderuj akapit jako obraz**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy użyciu [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Nie musisz renderować całego kształtu ani ręcznie przycinać bitmapy.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) może zwrócić `None`, jeśli akapit nie zostanie znaleziony w kolekcji rodzica, nie ma prawidłowych granic renderowania lub nie może zostać wyrenderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderuj akapit w domyślnej skali**

Przykład używa `sample.pptx`, prezentacji z jednym slajdem, którego pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład wybiera drugi akapit o indeksie 1 i wywołuje [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) bez parametrów skali. Sprawdza, czy kształt zawiera wymagany akapit i czy renderowanie zwróciło obraz, zanim wywoła [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) w formacie PNG. Menedżer kontekstu zwalnia zasoby obrazu po użyciu.

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

#### **Renderuj akapit w komórce tabeli ze skalowaniem**

Użyj przeciążenia [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) przyjmującego parametry `scale_x` i `scale_y`, aby ustawić czynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej domyślnej szerokości i wysokości oraz zapisuje wynik jako plik PNG.

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

Współczynnik skali `1` zachowuje domyślny rozmiar w pikselach. Na przykład `2` dla obu współczynników powoduje, że obraz ma przybliżoną podwójną szerokość i wysokość, czyli czterokrotnie więcej pikseli. Większe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` dają mniejsze obrazy z mniejszą szczegółowością. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu za pomocą [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) pozostaje przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu wyłącznie akapitu użyj [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii w ramce tekstowej?**

Tak. Ustaw [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) aby wyłączyć zawijanie, tak aby linie nie łamały się na krawędziach ramki tekstowej.

**Jak uzyskać dokładne granice akapitu na slajdzie?**

Użyj [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) aby pobrać prostokąt graniczny akapitu. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) podaje granice pojedynczego fragmentu.

**Gdzie kontroluje się wyrównanie akapitu (lewo, prawo, środno lub wyjustowanie)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

Aby wyrównać pionowo fragmenty o różnych rozmiarach czcionki w każdym wierszu, zobacz [Align Fonts Within a Line](/slides/pl/python-net/text-formatting/#align-fonts-within-a-line).

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.