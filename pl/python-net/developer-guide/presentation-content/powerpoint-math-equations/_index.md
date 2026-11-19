---
title: Dodawanie równań matematycznych do prezentacji PowerPoint w Pythonie
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
description: "Wstawiaj i edytuj równania matematyczne w plikach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Pythona via .NET, obsługując OMML, kontrolę formatowania oraz przejrzyste przykłady kodu w Pythonie."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides for Python via .NET możesz programowo tworzyć taki sam rodzaj treści matematycznej: ułamki, pierwiastki, funkcje, granice, operatory N‑ary, macierze, tablice i sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj wstawiają równania z **Insert > Equation**:

![Zakładka Wstawianie w PowerPoint z zaznaczonym poleceniem Równanie](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny przy użyciu trzech głównych obiektów:

- Kształt matematyczny, utworzony za pomocą [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), jest kształtem zawierającym równanie.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Większość poniższych przykładów używa [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) oraz metod fluent z [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) aby kod był krótki i czytelny.

W scenariuszach eksportu do MathML zobacz [Export Math Equations from Presentations in Python via .NET](/slides/pl/python-net/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) do stworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![Równanie c² = a² + b²](powerpoint-math-equations_3.png)

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

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), pobierz jego [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i dodaj bloki lub elementy matematyczne.

{{% /alert %}}

### **Łączenie bloków matematycznych**

Gdy części równania są budowane niezależnie jako obiekty [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), użyj [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) do ich połączenia. Przykład tworzy `c² =` w lewym bloku i `a² + b²` w prawym. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) tworzy edytowalne superskrypty dla wszystkich trzech potęg.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) zwraca sam `left_block`, teraz zawierający oba elementy w kolejności, a `right_block` zostaje pusty. Dodaj połączony blok do [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) tylko raz. Po ponownym otwarciu `equation.pptx` akapit zawiera jeden blok reprezentujący `c² = a² + b²`, z zachowanymi trzema potęgami jako superskrypty.

Wywołanie [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) jako `left_block.add(right_block)` próbuje zagnieździć jeden blok wewnątrz drugiego i powoduje `RuntimeError` opakowujący .NET `InvalidOperationException`.

## **Dodawanie ułamków**

Użyj [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Ułamek ukośny pokazujący jeden podzielony przez x](powerpoint-math-equations_4.png)

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

Dla ułamka składanego użyj [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Dodawanie pierwiastków**

Użyj [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Aktualny element staje się podstawą, a argument stopniem pierwiastka.

![Wyrażenie pierwiastkowe n‑tego stopnia z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

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

### **Pokaż lub ukryj stopień pierwiastka kwadratowego**

Pierwiastek kwadratowy może wyświetlać wyraźne 2 lub używać konwencjonalnego zapisu √x. Właściwość [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) klasy [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) kontroluje, która forma się pojawia. Obie formy zachowują stopień 2 i radicand x w edytowalnym równaniu.

![Pierwiastek kwadratowy z x, z widocznym stopniem 2 po lewej i ukrytym po prawej](square-root-degree.png)

Przykład zapisuje ten sam pierwiastek dwa razy. 2 jest widoczne w `visible-degree.pptx` i ukryte w `hidden-degree.pptx`.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie funkcji i granic**

Użyj [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) lub [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) dla funkcji takich jak `sin(x)`, `log(x)` lub nazw własnych funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) lub użyj [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

![Granica x przy dążeniu do nieskończoności](powerpoint-math-equations_8.png)

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

Dla własnej nazwy funkcji ustaw nazwę funkcji jako aktualny element i wywołaj [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) z jej argumentem:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Dodawanie operatorów N‑ary i całek**

Użyj [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) dla sum, unii, przecięć i innych dużych operatorów. Użyj [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) dla całek. Obie metody pozwalają ustawić limity dolne i górne.

![Sumowanie z limitami dolnym i górnym](powerpoint-math-equations_7.png)

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

Operatory N‑ary służą do dużych operatorów z opcjonalnymi limitami. Proste operatory takie jak `+`, `-` i `=` zwykle dodaje się jako [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) i łączy w wyrażeniu.

Dla całki użyj [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Dodawanie macierzy**

Użyj [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) dla wierszy i kolumn. Domyślnie macierze nie zawierają nawiasów, więc otaczaj macierz, gdy potrzebujesz nawiasów okrągłych, kwadratowych lub klamrowych.

![Macierz matematyczna z dwoma wierszami i jedną pustą komórką](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")
    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

### **Edycja istniejącej macierzy**

Załóżmy, że lekcja algebry liniowej zaczyna się od macierzy współczynników w `matrix.pptx`, zapisanej w poprzednim przykładzie. Dla kolejnego ćwiczenia zachowaj pierwsze równanie, zamień drugie na dwa nowe i zaktualizuj zbiór zmiennych. Uzyskaj istniejącą macierz jako [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/), aby zachować współczynniki wciąż obowiązujące.

![Oryginalna macierz współczynników dwóch wierszy z wpisami 1, x i pustą komórką w pierwszym wierszu oraz x, 2 i y w drugim](matrix-before-edit.png)

Indeksy wierszy i kolumn zaczynają się od zera i odnoszą się do aktualnego stanu macierzy przy każdym wywołaniu. Wstawienie wiersza przed indeksem 1 przesuwa oryginalny drugi wiersz na indeks 2. Wstawienie po indeksie 2 dodaje kolejny wiersz. Usunięcie wiersza 2 usuwa oryginalne drugie równanie i przesuwa dodany wiersz w górę. Kolumny przesuwają się analogicznie.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) ustawia wyrównanie pierwszej kolumny do lewej. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) wyrównuje trzy kolejne kolumny do prawej, począwszy od indeksu 1. W `updated-matrix.pptx` macierz ma trzy równania i cztery zmienne. Oryginalne współczynniki pierwszego wiersza `1` i `x` pojawiają się teraz w pierwszej i trzeciej kolumnie.

![Zaktualizowana macierz trzech wierszy pokazująca wiersze 1, 0, x, 0; 12, 1, 0, 0; oraz 0, 0, 10, 1](matrix-after-edit.png)

## **Dodawanie tablic równań**

Użyj [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

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

### **Wyrównanie tablicy do otaczających elementów**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) steruje pionowym wyrównaniem tablicy względem elementów matematycznych obok niej. Poniższy przykład porównuje wyrównanie do pierwszego wiersza, środka tablicy i ostatniego wiersza.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami i sąsiednimi elementami `A=` oraz `=B`. Wszystkie teksty matematyczne używają czcionki Cambria Math 24 pt. Zmienia się tylko wyrównanie tablicy.

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

![Tablice równań w PowerPoint z wyrównaniem Góra, Środek i Dół oraz identycznymi elementami sąsiadującymi](equation-array-alignment.png)

### **Konfiguracja odstępów wierszy**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) wybiera regułę odstępu dla wierszy w tablicy. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) podaje wartość numeryczną dla wyraźnej reguły i jest ignorowane przy użyciu reguł wstępnych.

Dla dokładnego odstępu wartość jest podawana w punktach. Dla odstępu proporcjonalnego mierzy się w pół-liniach: wartość `3` w przykładzie oznacza 1,5 linii. Ustaw oba pola, gdy podajesz wyraźną wartość; zmiana samej wartości liczbowej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają ustawień wstępnych; ostatnie dwa pokazują wyraźne wartości.

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

Odstęp wierszy tablicy jest niezależny od odstępu akapitu. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) i [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) dodają odstęp wokół całego akapitu, nie między wierszami tablicy. Podobnie [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) pozycjonuje cały akapit matematyczny w poziomie; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodawanie funkcji trygonometrycznych**

Użyj [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) gdy argument jest bieżącym elementem, a nazwa funkcji jest znana.

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

## **Dodawanie indeksów dolnych i górnych**

Używaj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają znajdować się po lewej stronie bazy, użyj [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

![Wielka litera Y z lewostronnym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

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

## **Dodawanie separatorów**

Użyj [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) aby umieścić wyrażenie w separatorach. Możesz także ustawić znak separatora dla wyrażeń zawierających kilka elementów.

![Wyrażenie z separatorami zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

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

### **Rozmiar i wyrównanie separatorów**

Ustaw [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) na `True`, aby nawiasy rosły wokół wysokiego argumentu, lub na `False`, aby zachować ich normalny rozmiar. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) przyjmuje jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `MATCH` wyrównuje je do otaczającej treści. Oba ustawienia wpływają tylko na same separatory. Wyrażenie w środku pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, tak że wyrażenie wznosi się wyżej nad linią bazową niż pod nią. Wszystkie cztery równania używają takich samych nawiasów i ustawień czcionki.

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

W PowerPoint porównaj wiersze, aby zobaczyć efekt wzrostu. W górnym wierszu nawiasy rosną, aby objąć wykładnik i wyglądają tak samo dla obu kształtów. W dolnym wierszu wzrost jest wyłączony. Mniejsze nawiasy po lewej (`CENTERED`) są wyrównane do znaku równości, podczas gdy te po prawej (`MATCH`) siedzą wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym i wyłączonym wzrostem separatorów, oraz Centered po lewej i Match po prawej](delimiter-sizing.png)

## **Dodawanie ramki obramowania**

Wywołaj [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) na ułamku, aby otoczyć cały wyraz ramką. Zwrócony [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) domyślnie pokazuje wszystkie cztery strony. Użyj [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/) i [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/), aby usunąć poszczególne krawędzie.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery krawędzie i ustaw [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) dla rosnącej przekątnej (↗) lub [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) dla opadającej (↘). Możesz także użyć [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) lub [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) z dowolną kombinacją widocznych krawędzi.

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

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełna ramka, dolna i lewa krawędź, rosnąca przekątna. Dolny wiersz: opadająca przekątna, poziome przekreślenie, pionowe przekreślenie z pełną ramką](border-box-fractions.png)

Na tym ułamku poziome przekreślenie zachodzi na belkę ułamka. Pionowe przekreślenie przecina zarówno licznik, jak i mianownik, podczas gdy otaczająca ramka pozostaje widoczna. Te linie ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w ciągu tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal możesz edytować licznik i mianownik niezależnie.

## **Kontrola widoczności i układu za pomocą elementów phantom**

Otocz wyrażenie w [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/), aby kontrolować jego widoczność i przestrzeń, jaką zajmuje w równaniu, niezależnie. Jego właściwości kontrolują następujące:

| Właściwość | Efekt |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | Ustaw na `False`, aby ukryć wyrażenie. Jego wymiary nadal wpływają na układ, chyba że poniższe właściwości są `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | Traktuj poziomą szerokość wyrażenia jako zero, umożliwiając sąsiadującym elementom zbliżenie się. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Traktuj jego wzniesienie (wysokość nad linią bazową) jako zero. Może to zmniejszyć przestrzeń nad sąsiadującymi elementami. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Traktuj jego opad (głębokość pod linią bazową) jako zero. Może to przybliżyć belkę ułamka lub inną treść pod wyrażeniem do sąsiadów. |

Linia bazowa to odniesienie, na którym stoją zwykłe litery matematyczne. Ukrywanie treści nie usuwa jej wymiarów, a traktowanie wymiaru jako zero nie usuwa wyrażenia. Podstawowe wyrażenie pozostaje dostępne przez [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/). Ustaw ponownie [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) na `True`, aby wyświetlić je ponownie; ustawienia wymiarów pozostają niezmienione.

Poniższy przykład tworzy pięć wariantów obok siebie: widoczny ułamek, ukryty ułamek zachowujący miejsce oraz trzy ukryte ułamki z jedną wymiarem traktowanym jako zero. Każdy wariant używa tego samego otaczającego wyrażenia i czcionki Cambria Math 24 pt. Wszystkie kształty równań mają tę samą pozycję górną, zaznaczona szarą linią pomocniczą. Umieszczenie phantom w liczniku zewnętrznego ułamka ułatwia zauważenie zmian układu pionowego.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![Pięć równań w PowerPoint porównujących widoczny ułamek, ukryty ułamek zachowujący miejsce oraz ukryte ułamki z ZeroWidth, ZeroAsc lub ZeroDesc włączonymi](math-phantom.png)


## **Grupowanie terminów**

Użyj [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj limit, aby oznaczyć pogrupowane terminy.

![Wyrażenie x + y pogrupowane z etykietą dowolny tekst poniżej](powerpoint-math-equations_15.png)

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

## **Formatowanie elementów matematycznych**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z nadkreśleniem](powerpoint-math-equations_14.png)

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

### **Formatowanie tekstu w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź po drzewie elementów każdego bloku matematycznego. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) zwraca tylko bezpośrednie dzieci, więc wywołaj go rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, skryptów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź zarówno bieżący element, jak i jego dzieci, aby uwzględnić element startowy, gdy jest [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Ten przykład zakłada, że `input.pptx` zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastkiem w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje fragmenty matematyczne w ramkach tekstowych slajdów, uzyskuje ich bloki przez [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i ustawia [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) na 28 pt przez właściwość [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) każdego elementu tekstowego.

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
| Tworzenie tekstu matematycznego | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Łączenie elementów | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Tworzenie ułamków | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Dodawanie superskryptu lub indeksu dolnego | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Dodawanie funkcji | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Dodawanie pierwiastków | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Dodawanie granic | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Dodawanie skryptów po lewej stronie | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Dodawanie sum i całek | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Dodawanie macierzy | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Dodawanie tablic równań | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Dodawanie separatorów | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Dodawanie pasków i ramek | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Grupowanie terminów | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**Czy mogę edytować istniejące równanie PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), pobierz jego [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalne matematyczne treści PowerPoint?**

Tak. Podczas zapisu do PPTX Aspose.Slides zapisuje równanie jako edytowalną treść Office Math.

**Czy mogę eksportować równania do LaTeX?**

Tak. Pobierz [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) równania z jego [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), i wywołaj [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/), aby wyeksportować je bezpośrednio. Pełny przykład znajdziesz w [Export Math Equations from Presentations in Python via .NET](/slides/pl/python-net/exporting-math-equations/#export-math-equations-to-latex).