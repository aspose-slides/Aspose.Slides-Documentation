---
title: Dodaj równania matematyczne do prezentacji PowerPoint w Pythonie
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Wstawiaj i edytuj równania matematyczne w PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla Pythona poprzez Java, obsługując OMML, kontrolę formatowania i przejrzyste przykłady kodu w Pythonie."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Za pomocą Aspose.Slides dla Pythona poprzez Java można programowo tworzyć tego samego rodzaju zawartość matematyczną: ułamki, pierwiastki, funkcje, granice, operatory N‑ary, macierze, tablice oraz sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![Zakładka Wstaw w PowerPoint z wybranym poleceniem Równanie](powerpoint-math-equations_1.png)

Rezultatem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalny równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides tworzy ten tekst matematyczny przy użyciu trzech głównych obiektów:

- Kształt matematyczny, tworzony za pomocą [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), jest kształtem zawierającym równanie.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) przechowuje zawartość matematyczną w ramce tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) oraz płynnych metod z [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) , aby kod był krótki i czytelny.

Dla scenariuszy eksportu MathML, zobacz [Eksportuj równania matematyczne z prezentacji w Pythonie](/slides/pl/python-java/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), aby utworzyć kształt matematyczny i dodaje twierdzenie Pitagorasa:

![Równanie c do kwadratu równa się a do kwadratu plus b do kwadratu](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) tworzy kształt, który już zawiera paragraf matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), i dodaj do niego bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodaj ułamki**

Użyj [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide), aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Skośny ułamek matematyczny pokazujący jeden podzielony przez x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dla ułamka w formie stosu, użyj [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Dodaj pierwiastki**

Użyj [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical), aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Aktualny element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n‑tego z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pokaż lub ukryj stopień pierwiastka kwadratowego**

Pierwiastek kwadratowy może wyświetlać explicite 2 lub używać konwencjonalnej notacji √x. Metoda [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) klasy [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) kontroluje, która forma się pojawi. Obie formy zachowują stopień 2 oraz radicand x w edytowalnym równaniu.

![Ten sam pierwiastek kwadratowy z widocznym stopniem po lewej i ukrytym po prawej](square-root-degree.png)

Przykład zapisuje ten sam pierwiastek dwukrotnie. W pliku `visible-degree.pptx` liczba 2 jest widoczna. W pliku `hidden-degree.pptx` jest ukryta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj funkcje i granice**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) lub [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) dla funkcji takich jak `sin(x)`, `log(x)`, lub własnych nazw funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) lub użyj [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Granica x, gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dla własnej nazwy funkcji, ustaw nazwę funkcji jako aktualny element i wywołaj [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) z jej argumentem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Dodaj operatory N‑ary i całki**

Użyj [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), aby dodać sumy, unie, przecięcia oraz inne duże operatory. Użyj [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral), aby dodać całki. Obie metody pozwalają ustawić dolne i górne granice.

![Sumowanie z dolną i górną granicą](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Operatory N‑ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` są zwykle dodawane jako [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) i łączone w wyrażeniu.

Aby dodać całkę, użyj [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) , aby określić wiersze i kolumny. Domyślnie macierze nie zawierają nawiasów, więc otaczaj macierz, gdy potrzebne są nawiasy, klamry lub nawiasy kwadratowe.

![Matematyczna macierz o dwóch wierszach z jedną pustą komórką](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edytuj istniejącą macierz**

Załóżmy, że lekcja algebry liniowej zaczyna się od macierzy współczynników w `matrix.pptx`, zapisanej w poprzednim przykładzie. W kolejnych ćwiczeniach zachowaj pierwsze równanie, zamień drugie na dwa nowe równania i zaktualizuj zestaw zmiennych. Otwórz istniejącą macierz za pomocą [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) , aby zachować nadal obowiązujące współczynniki.

![Oryginalna macierz współczynników o dwóch wierszach z wpisami 1, x i pustą komórką w pierwszym wierszu oraz x, 2 i y w drugim](matrix-before-edit.png)

Indeksy wierszy i kolumn zaczynają się od zera i odnoszą się do macierzy w stanie w danym wywołaniu. Wstawienie wiersza przed indeksem 1 przesuwa oryginalny drugi wiersz na indeks 2. Wstawienie po indeksie 2 dodaje kolejny wiersz. Usunięcie wiersza 2 usuwa pierwotne drugie równanie i przesuwa dodany wiersz o jedną pozycję w górę. Kolumny przestawiają się w ten sam sposób.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Nowe komórki są początkowo puste. Najpierw ustaw niezerowe współczynniki.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) wyrównuje pierwszą kolumnę do lewej. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) wyrównuje pozostałe trzy kolumny do prawej, począwszy od indeksu 1. W `updated-matrix.pptx` macierz zawiera trzy równania i cztery zmienne. Oryginalne współczynniki pierwszego wiersza `1` i `x` pojawiają się teraz w pierwszej i trzeciej kolumnie.

![Zaktualizowana macierz trzech wierszy przedstawiająca wiersze 1, 0, x, 0; 12, 1, 0, 0; oraz 0, 0, 10, 1](matrix-after-edit.png)

## **Dodaj tablice równań**

Użyj [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray), gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Wyrównaj tablicę z otaczającymi elementami**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) kontroluje pionowe wyrównanie tablicy względem otaczających ją elementów matematycznych. Poniższy przykład porównuje wyrównanie z pierwszym wierszem, środkiem tablicy i ostatnim wierszem.

Następny przykład tworzy trzy identyczne tablice, każda z trzema wierszami i sąsiednimi elementami `A=` i `=B`. Cały tekst matematyczny używa czcionki Cambria Math w rozmiarze 24 punkty. Zmienia się tylko wyrównanie tablicy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe porównanie pokazuje zapisaną prezentację w PowerPoint. Zwróć uwagę na pozycję `A=` i `=B` obok każdej tablicy.

![Tablice równań w PowerPoint z wyrównaniem Góra, Środek i Dół oraz identycznymi elementami sąsiadującymi](equation-array-alignment.png)

### **Konfiguruj odstępy wierszy**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) wybiera regułę odstępu dla wierszy w tablicy. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) podaje wartość liczbową dla explicite reguły odstępu i jest ignorowane przez reguły domyślne.

Dla dokładnego odstępu wartość jest mierzona w punktach. Dla odstępu proporcjonalnego jest mierzona w półwierszach: wartość `3` w przykładzie określa 1,5 linii. Ustaw obie właściwości przy podawaniu explicite wartości; zmiana samej wartości liczbowej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają presetów; ostatnie dwa pokazują wartości explicite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Odstępy wierszy tablicy są oddzielne od odstępów paragrafu. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) i [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) dodają odstęp wokół zawierającego paragrafu, nie pomiędzy wierszami tablicy. Podobnie [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) pozycjonuje cały paragraf matematyczny w poziomie; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodaj funkcje trygonometryczne**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction), gdy argument jest aktualnym elementem, a nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj indeksy dolne i górne**

Użyj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają pojawić się po lewej stronie podstawy, użyj [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Duża litera Y z indeksem dolnym 1 po lewej i indeksem górnym n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj ograniczniki**

Użyj [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose), aby umieścić wyrażenie w ogranicznikach. Możesz także ustawić znak separatora dla wyrażeń z wieloma elementami.

![Wyrażenie ograniczające zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Rozmiar i wyrównanie ograniczników**

Przekaż `True` do [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), aby nawiasy rosły wokół wysokiego operandu, albo `False`, aby pozostały w normalnym rozmiarze. Użyj [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) z jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `Match` wyrównuje je do zawartości. Oba ustawienia wpływają tylko na ograniczniki. Wyrażenie wewnątrz pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, tak że wyrażenie rozciąga się wyżej ponad linię bazową niż poniżej. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W PowerPoint porównaj wiersze, aby zobaczyć efekt rozrostu. W górnym wierszu nawiasy rosną, aby objąć wykładnik i wyglądają tak samo w obu kształtach. W dolnym wierszu rozrost jest wyłączony. Mniejsze nawiasy po lewej (`Centered`) są wyrównane do znaku równości, natomiast po prawej (`Match`) są wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym rozrostem ograniczników powyżej i wyłączonym poniżej, oraz Centered po lewej i Match po prawej](delimiter-sizing.png)

## **Dodaj ramkę obramowania**

Wywołaj [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) na ułamku, aby otoczyć całe wyrażenie ramką. Zwrócony [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) domyślnie pokazuje wszystkie cztery boki. Użyj [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) i [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight), aby usunąć poszczególne boki.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery boki i przekaż `True` do [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) dla rosnącej przekątnej (↗) lub [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) dla malejącej przekątnej (↘). Możesz także użyć [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) lub [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) z dowolną kombinacją widocznych boków.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełna ramka, dolny i lewy bok, rosnąca przekątna. Dolny wiersz: malejąca przekątna, poziome przekreślenie, pionowe przekreślenie z pełną ramką](border-box-fractions.png)

W tym ułamku poziome przekreślenie pokrywa kreskę ułamkową. Pionowe przekreślenie przecina zarówno licznik, jak i mianownik, podczas gdy otaczająca ramka pozostaje widoczna. Te linie ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w fragmencie tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal można edytować licznik i mianownik osobno.

## **Steruj widocznością i układem za pomocą elementów phantom**

Otocz wyrażenie w [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/), aby niezależnie kontrolować jego widoczność i przestrzeń, jaką wnosi do równania. Metody [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) kontrolują następujące:

| Metoda | Efekt |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | Przekaż `False`, aby ukryć wyrażenie. Jego wymiary nadal wpływają na układ, chyba że poniższe odpowiadające metody otrzymają `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | Traktuj szerokość poziomą wyrażenia jako zero, co pozwala sąsiednim elementom zbliżyć się do siebie. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Traktuj wzniesienie, czyli wysokość powyżej linii bazowej, jako zero. Może to zmniejszyć przestrzeń zarezerwowana nad sąsiednimi elementami. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Traktuj opadanie, czyli głębokość pod linią bazową, jako zero. Może to przybliżyć kreskę ułamka lub inną zawartość pod wyrażeniem do sąsiadów. |

Linia bazowa to linia odniesienia, na której znajdują się zwykłe litery matematyczne. Ukrywanie treści nie usuwa jej wymiarów, a traktowanie wymiaru jako zero nie usuwa wyrażenia. Podstawowe wyrażenie pozostaje dostępne poprzez [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). Przekaż `True` do [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow), aby ponownie je wyświetlić; ustawienia wymiarów pozostają niezmienione.

Poniższy przykład tworzy pięć wariantów obok siebie: widoczny ułamek, ukryty ułamek, który zachowuje przestrzeń, oraz trzy ukryte ułamki z jedną wymiarowo traktowaną jako zero. Każdy wariant używa tego samego otaczającego wyrażenia i czcionki Cambria Math w 24 punktach. Wszystkie kształty równań mają tę samą pozycję górną, oznaczoną szarym prowadnikiem. Umieszczenie phantom w liczniku zewnętrznego ułamka ułatwia zauważenie zmian układu pionowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Pięć równań w PowerPoint porównujących widoczny ułamek, ukryty ułamek zachowujący przestrzeń oraz ukryte ułamki z włączonymi ZeroWidth, ZeroAsc lub ZeroDesc](math-phantom.png)

## **Grupuj wyrazy**

Użyj [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) , aby umieścić znak grupujący powyżej lub poniżej wyrażenia. Dodaj limit, aby oznaczyć grupowane wyrazy.

![Wyrażenie x plus y zgrupowane z etykietą dowolny tekst poniżej](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatuj elementy matematyczne**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z paskiem nad nim](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatuj tekst w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź przez drzewo elementów każdego bloku matematycznego. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) zwraca tylko bezpośrednie dzieci, więc wywołaj ją rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, indeksów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź aktualny element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest to [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Ten przykład zakłada, że `input.pptx` zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastkiem w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje matematyczne fragmenty w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków poprzez [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), i używa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki na 28 punktów dla każdego elementu tekstowego poprzez metodę [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie każdego przetworzonego równania, zachowując jednocześnie jego treść tekstową i strukturę matematyczną.

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Utwórz tekst matematyczny | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Połącz elementy | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Utwórz ułamki | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Dodaj indeks górny lub dolny | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Dodaj funkcje | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Dodaj pierwiastki | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Dodaj granice | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Dodaj indeksy po lewej stronie | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Dodaj sumy i całki | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Dodaj macierze | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Dodaj tablice równań | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Dodaj ograniczniki | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Dodaj kreski i obramowania | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Grupuj wyrazy | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**Czy mogę edytować istniejące równanie PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), i zaktualizuj bloki matematyczne w tym paragrafie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Po zapisaniu do PPTX, Aspose.Slides zapisuje równanie jako edytowalną zawartość Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) równania z jego [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), i wywołaj [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex), aby wyeksportować go bezpośrednio. Pełny przykład znajduje się w [Eksportuj równania matematyczne z prezentacji w Pythonie](/slides/pl/python-java/exporting-math-equations/#export-math-equations-to-latex).