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
description: "Wstawiaj i edytuj równania matematyczne w plikach PowerPoint PPT i PPTX za pomocą Aspose.Slides for .NET, obsługując OMML, kontrolki formatowania i przejrzyste przykłady kodu C#."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Za pomocą Aspose.Slides for .NET możesz programowo tworzyć tego samego rodzaju zawartość matematyczną: ułamki, pierwiastki, funkcje, granice, operatory N-arne, macierze, tablice i sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![Karta Wstaw w PowerPoint z zaznaczoną komendą Równanie](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalny równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny przy użyciu trzech głównych obiektów:

- Kształt matematyczny, tworzony za pomocą [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), jest kształtem, który zawiera równanie.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) przechowuje treść matematyczną we wnętrzu ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) oraz metod Fluent z [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/), aby kod był krótki i czytelny.

W scenariuszach eksportu MathML zobacz [Export Math Equations from Presentations in .NET](/slides/pl/net/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) do utworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![Równanie c² = a² + b²](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), pobierz jego [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), i dodaj do niego bloki lub elementy matematyczne.
{{% /alert %}}

## **Dodaj ułamki**

Użyj [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) do utworzenia ułamka. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Ułamek skośny przedstawiający jeden podzielony przez x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Aby uzyskać ułamek ze składką pionową, użyj [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Dodaj pierwiastki**

Użyj [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) do utworzenia pierwiastka kwadratowego, sześciennego lub innego. Aktualny element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n‑tego stopnia z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Użyj [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) lub [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) dla funkcji takich jak `sin(x)`, `log(x)` lub niestandardowych nazw funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) lub użyj [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Granica x, gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Aby użyć niestandardowej nazwy funkcji, ustaw nazwę funkcji jako bieżący element i wywołaj [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) z jej argumentem:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Dodaj operatory N-arne i całki**

Użyj [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) dla sum, unii, przecięć i innych dużych operatorów. Użyj [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) dla całek. Obie metody umożliwiają ustawienie dolnych i górnych granic.

![Sumowanie z dolnym i górnym limitem](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Operatory N-arne służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` zazwyczaj dodaje się jako [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) i łączy w wyrażeniu.

Dla całki użyj [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) dla wierszy i kolumn. Domyślnie macierze nie zawierają nawiasów, więc otaczaj macierz, gdy potrzebne są nawiasy okrągłe, kwadratowe lub klamrowe.

![Matryca matematyczna o dwóch wierszach z jedną pustą komórką](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Użyj [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/), gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Wyrównaj tablicę z otaczającymi elementami**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) kontroluje pionowe wyrównanie tablicy względem elementów matematycznych obok niej. Przykład poniżej porównuje wyrównanie pierwszego wiersza, środka tablicy i ostatniego wiersza.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami i sąsiadującymi elementami `A=` oraz `=B`. Cały tekst matematyczny używa czcionki Cambria Math 24 pt. Zmienia się jedynie wyrównanie tablicy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Poniższe porównanie pokazuje zapisane w PowerPoint prezentację. Zauważ pozycję `A=` i `=B` obok każdej tablicy.

![Tablice równań w PowerPoint z wyrównaniem Góra, Środek i Dół oraz identycznymi elementami sąsiadującymi](equation-array-alignment.png)

### **Skonfiguruj odstępy między wierszami**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) wybiera regułę odstępu dla wierszy w tablicy. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) podaje wartość liczbową dla wyraźnie określonej reguły i jest ignorowane przy użyciu reguł wstępnych.

Dla dokładnego odstępu wartość jest podawana w punktach. Dla odstępu proporcjonalnego mierzy się go w półliniach: wartość `3` w przykładzie oznacza 1,5 linii. Ustaw oba właściwości, gdy określasz wyraźną wartość; zmiana samej wartości liczbowej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają ustawień wstępnych; ostatnie dwa pokazują wartości wyraźne.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Odstępy wierszy tablicy są oddzielne od odstępów akapitu. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) i [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) dodają przestrzeń wokół zawierającego akapitu, nie między wierszami tablicy. Podobnie [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) pozycjonuje cały akapit matematyczny w poziomie; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodaj funkcje trygonometryczne**

Użyj [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) gdy argument jest bieżącym elementem i nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Użyj pomocników indeksów dolnych i górnych dla indeksów i potęg. Gdy indeksy muszą znajdować się po lewej stronie podstawy, użyj [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Wielka litera Y z lewostronnym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Użyj [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) aby umieścić wyrażenie w delimiterach. Możesz także ustawić znak separatora dla wyrażeń delimiterowych zawierających kilka elementów.

![Wyrażenie delimitera zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Rozmiar i wyrównanie delimiterów**

Ustaw [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) na `true`, aby nawiasy rosły wokół wysokiego operandu, lub na `false`, aby pozostały w normalnym rozmiarze. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) przyjmuje jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `Match` wyrównuje je do zawartości. Oba ustawienia wpływają tylko na delimitery. Wyrażenie wewnątrz pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, tak że wyrażenie rozciąga się bardziej powyżej linii bazowej niż poniżej. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

W PowerPoint porównaj wiersze, aby zobaczyć efekt rozciągania. W górnym wierszu nawiasy rosną, obejmując wykładnik, i wyglądają tak samo dla obu kształtów. W dolnym wierszu rozciąganie jest wyłączone. Mniejsze nawiasy po lewej (`Centered`) są wyrównane do znaku równości, natomiast po prawej (`Match`) są wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym rozciąganiem delimiterów powyżej i wyłączonym poniżej, oraz Centered po lewej i Match po prawej](delimiter-sizing.png)

## **Dodaj ramkę obramowania**

Wywołaj [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) dla ułamka, aby otoczyć cały wyraz. Zwracany [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) domyślnie pokazuje wszystkie cztery strony. Użyj [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) i [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/), aby usunąć poszczególne krawędzie.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery krawędzie i ustaw [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) dla rosnącej przekątnej (↗) lub [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) dla spadającej przekątnej (↘). Możesz także użyć [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) lub [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) z dowolną kombinacją widocznych krawędzi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełna ramka, dolna i lewa strona, rosnąca przekątna. Dolny wiersz: spadająca przekątna, poziome przetarcie, pionowe przetarcie z pełną ramką.](border-box-fractions.png)

Na tym ułamku poziome przetarcie zachodzi na kreskę ułamka. Pionowe przetarcie przecina zarówno licznik, jak i mianownik, podczas gdy otaczająca ramka pozostaje widoczna. Linie te ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w ciągu tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal możesz edytować licznik i mianownik niezależnie.

## **Grupuj wyrażenia**

Użyj [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/), aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj granicę, aby oznaczyć pogrupowane wyrażenia.

![Wyrażenie x plus y pogrupowane z etykietą dowolny tekst poniżej](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z paskiem nad nim](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Formatuj tekst w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź po drzewie elementów każdego bloku matematycznego. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) zwraca tylko bezpośrednie potomki, więc wywołaj ją rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, indeksów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź bieżący element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Ten przykład zakłada, że prezentacja zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastek w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje fragmenty matematyczne w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków przez [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), i ustawia [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) na 28 pt dla każdego elementu tekstowego poprzez jego właściwość [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie przetworzonych równań, zachowując jednocześnie treść tekstową i strukturę matematyczną.

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Utwórz tekst matematyczny | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Połącz elementy | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Utwórz ułamki | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Dodaj indeks górny lub dolny | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Dodaj funkcje | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Dodaj pierwiastki | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Dodaj granice | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Dodaj skrypty po lewej stronie | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Dodaj sumy i całki | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Dodaj macierze | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Dodaj tablice równań | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Dodaj delimitery | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Dodaj paski i obramowania | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Grupuj wyrażenia | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Czy mogę edytować istniejące równanie PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), pobierz jego [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Po zapisaniu jako PPTX, Aspose.Slides zapisuje równanie jako edytowalną treść Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) z jego [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), i wywołaj [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/), aby wyeksportować je bezpośrednio. Pełny przykład znajdziesz w [Export Math Equations from Presentations in .NET](/slides/pl/net/exporting-math-equations/#export-math-equations-to-latex).