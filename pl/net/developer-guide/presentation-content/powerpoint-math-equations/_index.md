---
title: Dodaj równania matematyczne do prezentacji PowerPoint w .NET
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Wstawiaj i edytuj równania matematyczne w PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla .NET, obsługując OMML, kontrolki formatowania i przejrzyste przykłady kodu C#."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides dla .NET możesz programowo tworzyć taki sam rodzaj treści matematycznych: ułamki, pierwiastki, funkcje, granice, operatory N-ary, macierze, tablice i sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Insert > Equation**:

![Karta Insert w PowerPoint z wybraną komendą Equation](powerpoint-math-equations_1.png)

Wynik to edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny za pomocą trzech głównych obiektów:

- Kształt matematyczny, utworzony za pomocą [AddMathShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addmathshape/), jest kształtem zawierającym równanie.
- [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathematicaltext/) oraz metod fluent z [IMathElement](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/) aby kod był krótki i czytelny.

W scenariuszach eksportu MathML zobacz [Export Math Equations from Presentations in .NET](/slides/pl/net/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład tworzy kształt matematyczny i dodaje twierdzenie Pitagorasa:

![Równanie c^2 = a^2 + b^2](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape` tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego `MathPortion`, pobierz jego `MathParagraph` i dodaj bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodaj ułamki**

Użyj `Divide`, aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathfractiontypes/).

![Przechylony ułamek matematyczny pokazujący 1 podzielone przez x](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Aby uzyskać ułamek stosowany, użyj `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Dodaj pierwiastki**

Użyj `Radical`, aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Aktualny element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n‑tego z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Dodaj funkcje i granice**

Użyj `AsArgumentOfFunction` lub `Function` dla funkcji takich jak `sin(x)`, `log(x)` lub własnych nazw funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathlimit/) lub użyj `SetLowerLimit`.

![Granica x, gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Aby użyć własnej nazwy funkcji, ustaw nazwę funkcji jako bieżący element:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Dodaj operatory N-ary i całki**

Użyj `Nary` dla sum, unii, przecięć i innych dużych operatorów. Użyj `Integral` dla całek. Obie metody pozwalają ustawić dolne i górne granice.

![Sumowanie z dolną i górną granicą](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Operatory N-ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` są zazwyczaj dodawane jako `MathematicalText` i łączone w wyrażeniu.

Dla całki, użyj `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathmatrix/) dla wierszy i kolumn. Macierze domyślnie nie zawierają nawiasów, więc otocz macierz, gdy potrzebujesz nawiasów okrągłych, kwadratowych lub klamrowych.

![Macierz matematyczna z dwoma wierszami i jedną pustą komórką](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Dodaj tablice równań**

Użyj `ToMathArray`, gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Dodaj funkcje trygonometryczne**

Użyj `AsArgumentOfFunction`, gdy argument jest bieżącym elementem, a nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Dodaj indeksy dolne i górne**

Użyj pomocy indeksów dolnych i górnych dla pod indeksów i potęg. Gdy indeksy muszą pojawić się po lewej stronie podstawy, użyj `SetSubSuperscriptOnTheLeft`.

![Wielka litera Y z lewostronnym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Dodaj delimitery**

Użyj `Enclose`, aby umieścić wyrażenie w delimitatorach. Możesz także ustawić znak separatora dla wyrażeń delimitowanych zawierających kilka elementów.

![Wyrażenie delimitera zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **Dodaj ramkę**

Użyj `ToBorderBox`, gdy samo równanie ma być otoczone ramką.

![Równanie w ramce pokazujące a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Grupuj wyrażenia**

Użyj `Group`, aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj granicę, aby oznaczyć zgrupowane wyrażenia.

![Wyrażenie x + y zgrupowane z etykietą dowolny tekst pod nim](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Formatuj elementy matematyczne**

Używaj pomocy formatowania tylko tam, gdzie wyjaśniają wzór. Na przykład `Overbar` umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z paskiem nad nim](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Utwórz tekst matematyczny | [MathematicalText](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathematicaltext/) |
| Połącz elementy | [IMathElement.Join](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/join/) |
| Utwórz ułamki | [IMathElement.Divide](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/divide/) |
| Dodaj indeks górny lub dolny | [SetSuperscript](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Dodaj funkcje | [Function](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Dodaj pierwiastki | [IMathElement.Radical](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/radical/) |
| Dodaj granice | [SetLowerLimit](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Dodaj skrypty po lewej stronie | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Dodaj sumy i całki | [Nary](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/integral/) |
| Dodaj macierze | [MathMatrix](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathmatrix/) |
| Dodaj tablice równań | [ToMathArray](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Dodaj delimitery | [Enclose](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/enclose/) |
| Dodaj paski i ramki | [Overbar](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Grupuj wyrażenia | [Group](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Czy mogę edytować istniejące równanie w PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający `MathPortion`, pobierz jego `MathParagraph` i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Podczas zapisywania do PPTX, Aspose.Slides zapisuje równanie jako edytowalną treść matematyczną Office.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [IMathParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathparagraph/) równania z jego [MathPortion](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/mathportion/), a następnie wywołaj [IMathParagraph.ToLatex](https://reference.aspose.com/slides/pl/net/aspose.slides.mathtext/imathparagraph/tolatex/), aby wyeksportować go bezpośrednio. Pełny przykład można znaleźć w [Export Math Equations from Presentations in .NET](/slides/pl/net/exporting-math-equations/#export-math-equations-to-latex).