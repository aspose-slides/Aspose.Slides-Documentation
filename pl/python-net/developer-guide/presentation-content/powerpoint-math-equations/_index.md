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
description: "Wstawiaj i edytuj równania matematyczne w plikach PowerPoint PPT i PPTX za pomocą Aspose.Slides dla Pythona przez .NET, obsługując OMML, kontrolę formatowania oraz przejrzyste przykłady kodu w Pythonie."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Z Aspose.Slides dla Pythona przez .NET możesz programowo tworzyć tego samego rodzaju treść matematyczną: ułamki, pierwiastki, funkcje, granice, operatory N‑argumentowe, macierze, tablice i sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![Zakładka Wstaw w PowerPoint z wybraną komendą Równanie](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny przy użyciu trzech głównych obiektów:

- Kształt matematyczny, utworzony przy pomocy [add_math_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_math_shape/), jest kształtem, który zawiera równanie.
- Klasa [MathPortion](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- Klasa [MathParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathematicaltext/) i płynnych metod z [IMathElement](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/), aby kod był krótki i czytelny.

W przypadkach eksportu MathML zobacz [Export Math Equations from Presentations in Python via .NET](/slides/pl/python-net/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład tworzy kształt matematyczny i dodaje twierdzenie Pitagorasa:

![Równanie c² równa się a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`add_math_shape` tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj pierwszą `MathPortion`, pobierz jej `MathParagraph` i dodaj do niego bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodaj ułamki**

Użyj [`divide`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/divide/) aby utworzyć ułamek. Możesz wybrać styl ułamka przy pomocy [MathFractionTypes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Przechylony ułamek matematyczny pokazujący 1 podzielone przez x](powerpoint-math-equations_4.png)

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

Aby uzyskać ułamek w pionie, użyj `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Dodaj pierwiastki**

Użyj [`radical`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/radical/) aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Bieżący element staje się podstawą, a argument określa stopień pierwiastka.

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

Użyj [`as_argument_of_function`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) lub [`function`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/function/) aby wstawić funkcje takie jak `sin(x)`, `log(x)` lub nazwy funkcji niestandardowych. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathlimit/) lub użyj [`set_lower_limit`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

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

Aby użyć niestandardowej nazwy funkcji, ustaw nazwę funkcji jako bieżący element:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Dodaj operatory N‑argumentowe i całki**

Użyj [`nary`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/nary/) aby dodać sumy, sumowania, przekroje i inne duże operatory. Użyj [`integral`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/integral/) aby dodać całki. Obie metody pozwalają ustawić limity dolny i górny.

![Suma z limitami dolnym i górnym](powerpoint-math-equations_7.png)

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

Operatory N‑argumentowe służą do dużych operatorów z opcjonalnymi limitami. Proste operatory takie jak `+`, `-` i `=` zazwyczaj dodaje się jako `MathematicalText` i łączy w wyrażeniu.

Aby dodać całkę, użyj `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathmatrix/) aby określić wiersze i kolumny. Macierze domyślnie nie zawierają nawiasów, więc otocz macierz nawiasami, gdy potrzebne są nawiasy okrągłe, kwadratowe lub klamrowe.

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

## **Dodaj tablice równań**

Użyj [`to_math_array`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/to_math_array/) gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

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

## **Dodaj funkcje trygonometryczne**

Użyj [`as_argument_of_function`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) gdy argument jest bieżącym elementem, a nazwa funkcji jest znana.

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

Użyj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają pojawić się po lewej stronie podstawy, użyj [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Wielka litera Y z lewym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

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

Użyj [`enclose`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/enclose/) aby umieścić wyrażenie wewnątrz delimiterów. Możesz także ustawić znak separatora dla wyrażeń delimiterów zawierających wiele elementów.

![Wyrażenie delimiterów zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

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

## **Dodaj ramkę obramowania**

Użyj [`to_border_box`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/to_border_box/) gdy równanie ma być otoczone ramką.

![Równanie w ramce pokazujące a² = b² + c²](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Grupuj wyrazy**

Użyj [`group`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/group/) aby umieścić znak grupowania nad lub pod wyrażeniem. Dodaj limit, aby oznaczyć pogrupowane wyrazy.

![Wyrażenie x + y pogrupowane z etykietą dowolny tekst pod nim](powerpoint-math-equations_15.png)

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

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają wzór. Na przykład, [`overbar`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/overbar/) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z paskiem nad nim](powerpoint-math-equations_14.png)

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

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Utwórz tekst matematyczny | [MathematicalText](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Połącz elementy | [IMathElement.join](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/join/) |
| Utwórz ułamki | [IMathElement.divide](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Dodaj indeks górny lub dolny | [set_superscript](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Dodaj funkcje | [function](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Dodaj pierwiastki | [radical](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Dodaj granice | [set_lower_limit](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Dodaj indeksy po lewej stronie | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Dodaj sumy i całki | [nary](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Dodaj macierze | [MathMatrix](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/mathmatrix/) |
| Dodaj tablice równań | [to_math_array](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Dodaj delimitery | [enclose](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Dodaj paski i ramki | [overbar](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Grupuj wyrazy | [group](https://reference.aspose.com/slides/pl/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Czy mogę edytować istniejące równanie w PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający `MathPortion`, pobierz jego `MathParagraph` i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Po zapisaniu jako PPTX, Aspose.Slides zapisuje równanie jako edytowalną treść Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Aspose.Slides eksportuje równania matematyczne do MathML. Jeśli potrzebujesz LaTeX, najpierw wyeksportuj do MathML, a następnie skonwertuj MathML przy pomocy narzędzia obsługującego wybrany dialekt LaTeX.