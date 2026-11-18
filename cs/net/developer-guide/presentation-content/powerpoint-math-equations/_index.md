---
title: Přidat matematické rovnice do prezentací PowerPoint v .NET
linktitle: Matematické rovnice PowerPoint
type: docs
weight: 80
url: /cs/net/powerpoint-math-equations/
keywords:
- matematická rovnice
- matematický symbol
- matematický vzorec
- matematický text
- přidat matematickou rovnici
- přidat matematický symbol
- přidat matematický vzorec
- přidat matematický text
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro .NET, s podporou OMML, ovládáním formátování a přehlednými ukázkami kódu v C#."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro .NET můžete programově vytvářet stejný typ matematického obsahu: zlomky, kořeny, funkce, limity, N-ary operátory, matice, pole a formátované bloky matematiky.

V PowerPointu uživatelé obvykle přidávají rovnice pomocí **Insert > Equation**:

![Karta Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledkem je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), je tvar, který obsahuje rovnici.
- Objekt [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ukládá matematický obsah uvnitř textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Většina níže uvedených příkladů používá [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) a plynulé metody z [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) , aby byl kód stručný a čitelný.

Pro scénáře exportu MathML viz [Exportovat matematické rovnice z prezentací v .NET](/slides/cs/net/exporting-math-equations/).

## **Vytvořit rovnici**

Tento příklad používá [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) , aby vytvořil matematický tvar a přidal Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) vytváří tvar, který již obsahuje matematický odstavec. Získejte první [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), získáte jeho [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), a přidejte matematické bloky nebo matematické prvky.
{{% /alert %}}

## **Přidat zlomky**

Použijte [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) , abyste vytvořili zlomek. Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Zkosený matematický zlomek zobrazující 1 děleno x](powerpoint-math-equations_4.png)

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

Pro zaskládaný zlomek použijte [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) :

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Přidat kořeny**

Použijte [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) , abyste vytvořili druhou odmocninu, třetí odmocninu nebo jiný kořen. Aktuální prvek se stane základnou a argument se stane stupněm.

![Výraz n-té odmocniny s x pod znakem kořene](powerpoint-math-equations_5.png)

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

### **Zobrazit nebo skrýt stupeň druhé odmocniny**

Druhá odmocnina může zobrazovat explicitní 2 nebo používat konvenční zápis √x. Vlastnost [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) objektu [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) řídí, která forma se zobrazí. Obě formy zachovávají stupeň 2 a radikand x v editovatelné rovnici.

![Stejná druhá odmocnina s HideDegree nastaveným na false vlevo a true vpravo](square-root-degree.png)

Příklad ukládá stejnou druhou odmocninu dvakrát. V souboru `visible-degree.pptx` je 2 viditelné. V souboru `hidden-degree.pptx` je skryté.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Přidat funkce a limity**

Použijte [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) nebo [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) nebo použijte [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce vytvořte název funkce jako aktuální prvek a zavolejte [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) s jeho argumentem:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Přidat N-ární operátory a integrály**

Použijte [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) pro součty, unie, průniky a další velké operátory. Použijte [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) pro integrály. Obě metody umožňují nastavit dolní a horní limity.

![Součet s dolní a horní limitou](powerpoint-math-equations_7.png)

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

N-ární operátory slouží pro velké operátory s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) a spojují do výrazu.

Pro integrál použijte [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) :

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Přidat matice**

Použijte [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) pro řádky a sloupce. Matice standardně neobsahují závorky, takže pokud potřebujete kulaté, hranaté nebo složené závorky, obalte matici.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

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

## **Přidat pole rovnic**

Použijte [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) , když potřebujete zarovnané rovnice nebo vertikální zásobník výrazů.

![Vertikální matematické pole s x nad y](powerpoint-math-equations_11.png)

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

### **Zarovnat pole s okolními prvky**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) řídí vertikální zarovnání pole vzhledem k matematickým elementům vedle něj. Níže uvedený příklad porovnává zarovnání s prvním řádkem, středem pole a posledním řádkem.

Následující příklad vytváří tři identická pole, každé se třemi řádky a sousedními prvky `A=` a `=B`. Veškerý matematický text používá Cambria Math o velikosti 24 bodů. Pouze se mění zarovnání pole.

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

Následující srovnání zobrazuje uloženou prezentaci v PowerPointu. Všimněte si pozice `A=` a `=B` vedle každého pole.

![Pole rovnic v PowerPointu s horním, středním a dolním zarovnáním a identickými sousedními prvky](equation-array-alignment.png)

### **Nastavit rozestupy řádků**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) vybírá pravidlo rozestupu pro řádky v poli. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) poskytuje číselnou hodnotu pro explicitní pravidlo rozestupu a je ignorováno přednastavenými pravidly.

Pro přesný rozestup se hodnota měří v bodech. Pro proporční rozestup se měří v půlřádcích: hodnota `3` v příkladu představuje 1,5 řádku. Při zadávání explicitní hodnoty nastavte oba vlastnosti; změna pouze číselné hodnoty nevybírá pravidlo rozestupu.

Níže uvedený příklad uloží pět prezentací se stejnými rovnicemi, zarovnáním a nastavením písma. První tři používají předvolby; poslední dvě ukazují explicitní hodnoty.

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

Rozestup řádků v poli je oddělený od rozestupu odstavců. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) a [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) přidávají prostor kolem obsahujícího odstavce, ne mezi řádky pole. Podobně [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) umisťuje celý matematický odstavec horizontálně; nenahrazuje nastavení vertikálního zarovnání pole.

## **Přidat trigonometrické funkce**

Použijte [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) , když je argument aktuálním prvkem a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

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

## **Přidat dolní a horní indexy**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když mají být indexy na levé straně základny, použijte [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) .

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

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

## **Přidat oddělovače**

Použijte [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) , abyste vložili výraz do oddělovačů. Můžete také nastavit znak oddělovače pro výrazy v oddělovačích, které obsahují několik prvků.

![Výraz v oddělovačích obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

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

### **Velikost a zarovnání oddělovačů**

Nastavte [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) na `true`, aby se závorky rozšířily kolem vysokého operandu, nebo na `false`, aby zůstaly v normální velikosti. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) přijímá jednu ze dvou hodnot [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) . `Centered` vystředí závorky na matematické ose, která prochází středem znaménka rovnosti. `Match` je zarovná s obsahem uvnitř. Obě nastavení ovlivňují jen oddělovače. Výraz uvnitř zůstává stejný.

Příklad vloží zlomek do exponentu `x`, takže výraz sahá výše nad základní čáru než pod ní. Všechny čtyři rovnice používají stejné závorky a nastavení písma.

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

V PowerPointu porovnejte řádky, abyste viděli efekt rozšíření. V horním řádku se závorky rozšíří, aby obklopily exponent, a vypadají stejně pro oba tvary. Ve spodním řádku je rozšíření vypnuto. Menší závorky vlevo (`Centered`) jsou zarovnány se znaménkem rovnosti, zatímco ty vpravo (`Match`) jsou vyšší kolem výrazu.

![Čtyři rovnice v PowerPointu s povoleným růstem oddělovačů nahoře a zakázaným dole, a `Centered` vlevo a `Match` vpravo](delimiter-sizing.png)

## **Přidat rámečkový box**

Zavolejte [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) na zlomek, aby ohraničil celý výraz. Vrácený [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) zobrazuje všechny čtyři strany ve výchozím nastavení. Použijte [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) a [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) , abyste odstranili jednotlivé strany.

Příklad umístí šest kopií stejného zlomku na jeden snímek. Pro zobrazení zrušení skryjte všechny čtyři strany a nastavte [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) pro stoupající úhlopříčku (↗) nebo [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) pro klesající úhlopříčku (↘). Můžete také použít [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) nebo [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) s libovolnou kombinací viditelných stran.

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

![Šest editovatelných zlomků v PowerPointu. Horní řádek: celý rámeček, spodní a levá strana, stoupající úhlopříčka. Dolní řádek: klesající úhlopříčka, horizontální přeškrtnutí, vertikální přeškrtnutí s úplným rámečkem](border-box-fractions.png)

U tohoto zlomku se horizontální přeškrtnutí překrývá s čárou zlomku. Vertikální přeškrtnutí prochází čitatelem i jmenovatelem, zatímco okolní rámeček zůstává viditelný. Tyto čáry zdobí celý výraz. Přes běžné přeškrtnutí textu se přeškrtnutí vztahuje na znaky v textovém bloku. Po opětovném otevření prezentace v PowerPointu můžete i nadále nezávisle upravovat čitatele a jmenovatele.

## **Řídit viditelnost a rozvržení pomocí Phantom prvků**

Zabalte výraz do [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) , aby jste nezávisle řídili jeho viditelnost a prostor, který přispívá k rovnici. Vlastnosti [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) řídí následující:

| Vlastnost | Účinek |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Nastavte na `false`, aby se výraz skryl. Jeho rozměry stále přispívají k rozložení, pokud nejsou odpovídající vlastnosti níže nastaveny na `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Považuje vodorovnou šířku výrazu za nulu, umožňující sousedním prvkům se posunout blíže k sobě. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Považuje jeho výšku nad základní čárou (ascent) za nulu. To může snížit rezervovaný prostor nad sousedními prvky. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Považuje jeho klesání (descent), hloubku pod základní čárou, za nulu. To může posunout čáru zlomku nebo jiný obsah pod výraz blíže k sousedům. |

Základní čára je referenční čára, na které stojí běžná matematická písmena. Skrytí obsahu neodstraňuje jeho rozměry a považování rozměru za nulu neodstraňuje výraz. Podkladový výraz zůstává dostupný přes [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) . Nastavte [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) zpět na `true`, aby se znovu zobrazil; nastavení rozměrů zůstane nezměněno.

Níže uvedený příklad vytváří pět variant vedle sebe: viditelný zlomek, skrytý zlomek, který si rezervuje místo, a tři skryté zlomky s jedním rozměrem nastaveným na nulu. Každá varianta používá stejný okolní výraz a Cambria Math o velikosti 24 bodů. Všechny tvary rovnic mají stejnou horní pozici, označenou šedým vodítkem. Umístění phantom prvku do čitatele vnějšího zlomku usnadňuje vidět změny ve vertikálním rozložení.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Pět rovnic v PowerPointu porovnávajících viditelný zlomek, skrytý zlomek, který rezervuje místo, a skryté zlomky s povoleným ZeroWidth, ZeroAsc nebo ZeroDesc](math-phantom.png)

## **Seskupit termíny**

Použijte [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) , aby jste umístili seskupovací znak nad nebo pod výraz. Přidejte limitu pro označení seskupených termínů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

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

## **Formátovat matematické prvky**

Používejte pomocníky formátování jen tam, kde objasňují vzorec. Například [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) umístí čáru nad matematický prvek.

![Matematický výraz ABC s přeškrtnutím (overbar)](powerpoint-math-equations_14.png)

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

### **Formátovat text v existující rovnici**

Pro formátování textu v celé existující rovnici projděte strom elementů každého matematického bloku. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) vrací pouze přímé potomky, takže jej volejte rekurzivně, abyste dosáhli textu uvnitř zlomků, skriptů, kořenů a dalších vnořených struktur. Zkontrolujte aktuální prvek i jeho potomky, aby byl zahrnut počáteční prvek, když je to [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) .

Tento příklad předpokládá, že prezentace obsahuje rovnici jako `z = xᵢ / ∛y`, kde zlomek má dolní index v čitateli a kořen ve jmenovateli. Zpracování pouze prvků nejvyšší úrovně bloku by opomnělo text uvnitř zlomku. Příklad vyhledá matematické části ve snímcích textových rámců, získá jejich bloky přes [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), a nastaví [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) na 28 bodů u každého textového elementu přes jeho [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) .

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

Uložená prezentace obsahuje aktualizovaný formát textu na každé úrovni každé zpracované rovnice, zatímco zachovává její textový obsah a matematickou strukturu.

## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinovat prvky | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Vytvořit zlomky | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Přidat horní nebo dolní index | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Přidat funkce | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Přidat kořeny | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Přidat limity | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Přidat skripty na levé straně | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Přidat součty a integrály | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Přidat pole rovnic | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Přidat oddělovače | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Přidat čáry a rámečky | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Seskupit termíny | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), získejte jeho [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná PowerPointová matematika?**

Ano. Při uložení do PPTX Aspose.Slides zapíše rovnici jako editovatelný Office math obsah.

**Mohu exportovat rovnice do LaTeXu?**

Ano. Získejte [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) rovnice z jejího [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), a zavolejte [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) pro přímý export. Pro kompletní příklad viz [Exportovat matematické rovnice z prezentací v .NET](/slides/cs/net/exporting-math-equations/#export-math-equations-to-latex).