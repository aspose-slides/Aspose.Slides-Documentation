---
title: Dodaj równania matematyczne do prezentacji PowerPoint w Pythonie
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/python-net/powerpoint-math-equations/
keywords:
- równanie matematyczne
- symbol matematyczny
- formuła matematyczna
- tekst matematyczny
- dodaj równanie matematyczne
- dodaj symbol matematyczny
- dodaj formułę matematyczną
- dodaj tekst matematyczny
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Wstawiaj i edytuj równania matematyczne w plikach PowerPoint PPT i PPTX przy użyciu Aspose.Slides for Python via .NET, obsługując OMML, kontrolki formatowania oraz przejrzyste przykłady kodu w Pythonie."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides for Python via .NET możesz programowo tworzyć taki sam rodzaj treści matematycznej: ułamki, pierwiastki, funkcje, granice, operatory N-ary, macierze, tablice i sformatowane bloki matematyczne.

W programie PowerPoint użytkownicy zazwyczaj dodają równania z **Insert > Equation**:

![Karta Wstawianie w PowerPoint z wybranym poleceniem Równanie](powerpoint-math-equations_1.png)

Rezultatem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny za pomocą trzech głównych obiektów:

- Kształt matematyczny, tworzony przy użyciu [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), jest kształtem, który zawiera równanie.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) przechowuje zawartość matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) oraz płynnych metod z [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) , aby kod był krótki i czytelny.

Dla scenariuszy eksportu MathML zobacz [Eksport równań matematycznych z prezentacji w Pythonie za pośrednictwem .NET](/slides/pl/python-net/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) do utworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![Równanie c kwadrat równa się a kwadrat plus b kwadrat](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), pobierz jego [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i dodaj do niego bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodaj ułamki**

Użyj [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) , aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Skośny ułamek matematyczny pokazujący jeden podzielony przez x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Aby uzyskać ułamek stosowany jeden na drugi, użyj [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Dodaj pierwiastki**

Użyj [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) , aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Bieżący element staje się podstawą, a argument jej stopniem.

![Wyrażenie pierwiastka n-tego z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj funkcje i granice**

Użyj [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) lub [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) , aby dodać funkcje takie jak `sin(x)`, `log(x)` lub własne nazwy funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) lub użyj [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Granica x, gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Dla własnej nazwy funkcji, ustaw nazwę funkcji jako bieżący element i wywołaj [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) z jej argumentem:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Dodaj operatory N-ary i całki**

Użyj [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) , aby dodać sumy, unie, przecięcia i inne duże operatory. Użyj [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) , aby dodać całki. Obie metody pozwalają ustawić dolne i górne granice.

![Suma z dolną i górną granicą](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Operatory N-ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` są zwykle dodawane jako [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) i łączone w wyrażenie.

Aby dodać całkę, użyj [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) :

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) , aby określić wiersze i kolumny. Macierze domyślnie nie zawierają nawiasów, więc otaczaj macierz nawiasami okrągłymi, kwadratowymi lub klamrami, gdy są potrzebne.

![Matematyczna macierz dwuwierszowa z jedną pustą komórką](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # Macierz nie ma własnych nawiasów, więc otocz ją nawiasami okrągłymi.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` buduje siatkę wierszy i kolumn, ustawia przerwy między nimi i wyrównuje kolumny, ale Aspose.Slides for Python via .NET nie udostępnia dostępu do pojedynczej komórki macierzy. Macierz utworzona w kodzie zachowuje więc puste komórki; komórki macierzy pochodzącej z istniejącej prezentacji można odczytać przy pomocy `get_children`. Użyj tablicy równań, gdy potrzebujesz wypełnić wiersze z kodu.
{{% /alert %}}

## **Dodaj tablice równań**

Użyj [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) , gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x powyżej y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

### **Wyrównaj tablicę z otaczającymi elementami**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) kontroluje wyrównanie pionowe tablicy względem elementów matematycznych obok niej. Poniższy przykład porównuje wyrównanie pierwszego wiersza, środka tablicy i ostatniego wiersza.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami oraz sąsiadującymi elementami `A=` i `=B`. Cały tekst matematyczny używa czcionki Cambria Math w rozmiarze 24 punkty. Zmienia się tylko wyrównanie tablicy.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

Poniższe porównanie pokazuje zapisaną prezentację w PowerPoint. Zwróć uwagę na pozycję `A=` i `=B` obok każdej tablicy.

![Tablice równań w PowerPoint z wyrównaniem Górne, Środkowe i Dolne oraz identycznymi elementami sąsiadującymi](equation-array-alignment.png)

### **Skonfiguruj odstęp między wierszami**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) wybiera regułę odstępu dla wierszy w tablicy. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) podaje wartość liczbową dla wyraźnej reguły odstępu i jest ignorowana przy użyciu reguł domyślnych.

Dla dokładnego odstępu, wartość jest mierzona w punktach. Dla odstępu proporcjonalnego, jest mierzona w półliniach: wartość `3` w przykładzie oznacza 1,5 linii. Ustaw obie właściwości przy określaniu wyraźnej wartości; zmiana samej wartości liczbowej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z takimi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają ustawień domyślnych; ostatnie dwa pokazują wartości wyraźne.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Odstęp wierszy tablicy jest oddzielny od odstępu akapitu. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) i [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) dodają odstęp wokół zawierającego akapitu, nie między wierszami tablicy. Podobnie [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) pozycjonuje cały akapit matematyczny poziomo; nie zastępuje to ustawienia pionowego wyrównania tablicy.

## **Dodaj funkcje trygonometryczne**

Użyj [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) , gdy argument jest bieżącym elementem i nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj indeksy dolne i górne**

Użyj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają znajdować się po lewej stronie podstawy, użyj [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Wielka litera Y z indeksem dolnym 1 po lewej i indeksem górnym n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj delimitery**

Użyj [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) , aby umieścić wyrażenie wewnątrz delimiterów. Możesz także ustawić znak separatora dla wyrażeń delimiterowych zawierających kilka elementów.

![Wyrażenie delimiterowe zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **Rozmiar i wyrównanie delimiterów**

Ustaw [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) na `True`, aby nawiasy rozciągały się wokół wysokiego operandu, lub na `False`, aby pozostały w normalnym rozmiarze. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) przyjmuje jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) . `CENTERED` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `MATCH` wyrównuje je do otaczającej treści. Oba ustawienia wpływają tylko na delimitery. Wyrażenie wewnątrz pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, więc wyrażenie rozciąga się wyżej ponad linią podstawową niż pod nią. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

W PowerPoint porównaj wiersze, aby zobaczyć efekt rozciągania. W górnym wierszu nawiasy rozciągają się, aby objąć wykładnik i wyglądają tak samo dla obu kształtów. W dolnym wierszu rozciąganie jest wyłączone. Mniejsze nawiasy po lewej (`CENTERED`) są wyrównane do znaku równości, podczas gdy po prawej (`MATCH`) są wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym rozciąganiem delimiterów u góry i wyłączonym u dołu, oraz Centered po lewej i Match po prawej](delimiter-sizing.png)

## **Dodaj ramkę obramowania**

Wywołaj [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) na ułamku, aby obramować całe wyrażenie. Zwrócony [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) domyślnie pokazuje wszystkie cztery strony. Użyj [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), i [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) , aby usunąć poszczególne strony.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać przekreślenie, ukryj wszystkie cztery strony i ustaw [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) dla rosnącej przekątnej (↗) lub [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) dla malejącej przekątnej (↘). Możesz także użyć [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) lub [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) z dowolną kombinacją widocznych stron.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełna ramka, dolna i lewa strona, rosnąca przekątna. Dolny wiersz: malejąca przekątna, poziome przekreślenie, pionowe przekreślenie z pełną ramką](border-box-fractions.png)

W tym ułamku poziome przekreślenie nakłada się na pasek ułamka. Pionowe przekreślenie przecina zarówno licznik, jak i mianownik, podczas gdy otaczająca ramka pozostaje widoczna. Te linie ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w fragmencie tekstu. Po ponownym otwarciu prezentacji w PowerPoint nadal możesz edytować licznik i mianownik niezależnie.

## **Grupuj wyrażenia**

Użyj [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) , aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj limit, aby oznaczyć grupowane wyrażenia.

![Wyrażenie x plus y zgrupowane z etykietą dowolny tekst pod nim](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatuj elementy matematyczne**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z górnym paskiem](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatuj tekst w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź przez drzewo elementów każdego bloku matematycznego. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) zwraca tylko bezpośrednie dzieci, więc wywołaj ją rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, skryptów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź bieżący element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest to [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) .

Ten przykład zakłada, że `input.pptx` zawiera równanie, takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastek w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje matematyczne części w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków przez [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i ustawia [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) na 28 punktów dla każdego elementu tekstowego za pomocą jego własności [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) .

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie każdego przetworzonego równania, zachowując jednocześnie jego treść i strukturę matematyczną.

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Create fractions | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Add superscript or subscript | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Add functions | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Add radicals | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Add limits | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Add left-side scripts | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Group terms | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Czy mogę edytować istniejące równanie w PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), pobierz jego [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Podczas zapisywania do PPTX, Aspose.Slides zapisuje równanie jako edytowalną zawartość Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) równania z jego [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), i wywołaj [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) , aby wyeksportować go bezpośrednio. Pełny przykład znajdziesz w [Eksport równań matematycznych z prezentacji w Pythonie za pośrednictwem .NET](/slides/pl/python-net/exporting-math-equations/#export-math-equations-to-latex).