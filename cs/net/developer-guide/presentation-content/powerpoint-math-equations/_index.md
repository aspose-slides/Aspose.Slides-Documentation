---
title: Přidání matematických rovnic do prezentací PowerPoint v .NET
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
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro .NET, podporující OMML, ovládací prvky formátování a přehledné ukázky kódu v C#."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro .NET můžete programově vytvářet stejný druh matematického obsahu: zlomky, odmocniny, funkce, limity, N-ary operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé normálně přidávají rovnice pomocí **Insert > Equation**:

![Karta Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledek je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický objekt, vytvořený pomocí [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ukládá matematický obsah do textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Většina níže uvedených příkladů používá [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) a plynulé metody z [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) , aby byl kód stručný a čitelný.

Pro scénáře exportu MathML viz [Export rovnic v MathML z prezentací v .NET](/slides/cs/net/exporting-math-equations/).

## **Vytvoření rovnice**

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) vytváří tvar, který již obsahuje matematický odstavec. Získejte první [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), jeho [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), a přidejte do něj matematické bloky nebo matematické elementy.
{{% /alert %}}

### **Kombinace matematických bloků**

Když jsou části rovnice vytvořeny nezávisle jako objekty [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/), použijte [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) , aby je spojili. Příklad vytvoří `c² =` v levém bloku a `a² + b²` v pravém bloku. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) vytváří editovatelné matematické horní indexy pro všechny tři mocniny.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) vrací samotný `leftBlock`, který nyní obsahuje obě části v pořadí, a ponechává `rightBlock` prázdný. Přidejte kombinovaný blok do [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) pouze jednou. Po opětovném otevření `equation.pptx` odstavce obsahuje jeden blok představující `c² = a² + b²`, přičemž všechny tři mocniny jsou zachovány jako matematické horní indexy.

Volání [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) jako `leftBlock.Add(rightBlock)` se místo toho pokusí vložit jeden blok přímo do druhého a vyvolá `InvalidOperationException`.

## **Přidání zlomků**

Použijte [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) , abyste vytvořili zlomek. Můžete vybrat styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Nákloný matematický zlomek zobrazující jeden dělený x](powerpoint-math-equations_4.png)

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

Pro vrstvený zlomek použijte [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Přidání odmocnin**

Použijte [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) , abyste vytvořili druhou odmocninu, třetí odmocninu nebo jiný kořen. Aktuální element se stane základem a argument se stane exponentem.

![Vyjádření n-té odmocniny s x pod znakem odmocniny](powerpoint-math-equations_5.png)

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

### **Zobrazení nebo skrytí exponentu druhé odmocniny**

Druhá odmocnina může zobrazovat explicitní 2 nebo použít konvenční zápis √x. Vlastnost [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) třídy [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) řídí, která forma se zobrazí. Obě formy zachovávají exponent 2 a radikand x v editovatelné rovnici.

![Stejná druhá odmocnina s HideDegree nastaveným na false vlevo a true vpravo](square-root-degree.png)

Příklad uloží stejnou druhou odmocninu dvakrát. V `visible-degree.pptx` je 2 viditelné. V `hidden-degree.pptx` je skryté.

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

## **Přidání funkcí a limit**

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

Pro vlastní název funkce nastave funkční název jako aktuální element a zavolejte [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) , s jeho argumentem:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Přidání N-ary operátorů a integrálů**

Použijte [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) pro součty, sjednocení, průniky a další velké operátory. Použijte [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) pro integrály. Obě metody umožňují nastavit spodní a horní limity.

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

N-ary operátory jsou určeny pro velké operátory s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` jsou obvykle přidávány jako [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) a spojeny do výrazu.

Pro integrál použijte [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) , pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, takže matice obalte, když potřebujete závorky, hranaté závorky nebo složené závorky.

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

### **Úprava existující matice**

Předpokládejme, že lekce lineární algebry začíná koeficientovou maticí v `matrix.pptx`, uloženou předchozím příkladem. Pro další cvičení zachovejte první rovnici, nahraďte druhou dvěma novými rovnicemi a upravte množinu proměnných. Otevřete existující matici přes [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) , aby se zachovaly koeficienty, které stále platí.

![Původní dvouřádková koeficientová matice s položkami 1, x a prázdnou buňkou v prvním řádku a x, 2 a y ve druhém](matrix-before-edit.png)

Indexy řádků a sloupců začínají nulou a odkazují na matici tak, jak existuje při každém volání. Vložení řádku před index 1 posune původní druhý řádek na index 2. Vložení po indexu 2 pak přidá řádek. Smazání řádku 2 odstraní původní druhou rovnici a posune přidaný řádek o jednu pozici výš. Sloupce se posunou stejným způsobem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// Nové buňky jsou zpočátku null. Nejprve nastavte nenulové koeficienty.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) zarovnává první sloupec doleva. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) zarovnává tři po sobě jdoucí sloupce doprava, počínaje indexem 1. V `updated-matrix.pptx` má matice tři rovnice a čtyři proměnné. Původní koeficienty první řady `1` a `x` se nyní objevují v prvním a třetím sloupci.

![Aktualizovaná matice se třemi řádky zobrazující řádky 1, 0, x, 0; 12, 1, 0, 0; a 0, 0, 10, 1](matrix-after-edit.png)

## **Přidání polí rovnic**

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

### **Zarovnání pole s okolními elementy**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) řídí vertikální zarovnání pole vzhledem k matematickým prvkům vedle něj. Níže uvedený příklad porovnává zarovnání s prvním řádkem, středem pole a posledním řádkem.

Následující příklad vytvoří tři identické pole, každé se třemi řádky a sousedními elementy `A=` a `=B`. Veškerý matematický text používá Cambria Math o velikosti 24 bodů. Pouze zarovnání pole se mění.

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

Následující srovnání ukazuje uloženou prezentaci v PowerPointu. Všimněte si umístění `A=` a `=B` vedle každého pole.

![Pole rovnic v PowerPointu s horním, středním a spodním zarovnáním a identickými sousedními prvky](equation-array-alignment.png)

### **Nastavení řádkování**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) vybírá pravidlo řádkování pro řádky uvnitř pole. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) poskytuje číselnou hodnotu pro explicitní pravidlo řádkování a je ignorováno přednastavenými pravidly.

Pro přesné řádkování je hodnota měřena v bodech. Pro proporciální řádkování se měří v půlřádcích: hodnota `3` v příkladu udává 1,5 řádku. Nastavte obě vlastnosti při specifikaci explicitní hodnoty; pouhá změna číselné hodnoty nevybere pravidlo řádkování.

Následující příklad uloží pět prezentací se stejnými rovnicemi, zarovnáním a nastavením písma. První tři používají předvolby; poslední dva ukazují explicitní hodnoty.

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

Řádkování pole je oddělené od řádkování odstavce. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) a [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) přidávají prostor kolem obsahujícího odstavce, nikoli mezi řádky pole. Stejně tak [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) umisťuje celý matematický odstavec horizontálně; nenahrazuje nastavení vertikálního zarovnání pole.

## **Přidání trigonometrických funkcí**

Použijte [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) , když je argument aktuální element a název funkce je znám.

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

## **Přidání dolních a horních indexů**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když se indexy musí zobrazit na levé straně základu, použijte [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

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

### **Zarovnání pravých dolních a horních indexů**

Když oba indexy patří ke stejnému základu, použijte [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/) . Jeho vlastnost [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) řídí jejich horizontální polohu: `false` (výchozí) nechá je sledovat obrys základu, zatímco `true` zarovná indexy horizontálně vůči sobě.

Tento příklad umisťuje dva kopie stejného editovatelného výrazu vedle sebe. Oba používají matematické kurzívní f (U+1D453), dolní index 1, horní index 2 a Cambria Math o velikosti 72 bodů. Šikmý základ ukazuje rozdíl v PowerPointu. Před spuštěním příkladu nainstalujte Cambria Math.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![Dvě editovatelné výrazy v PowerPointu s AlignScripts nastaveným na false vlevo a true vpravo](aligned-scripts.png)

Nalevo dolní index začíná dále vlevo než horní index, následující obrys základu. Napravo jsou oba indexy horizontálně zarovnány vůči sobě.

## **Přidání oddělovačů**

Použijte [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) , abyste vložili výraz do oddělovačů. Můžete také nastavit znak oddělovače pro výrazy s oddělovači, které obsahují několik elementů.

![Výraz s oddělovači obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

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

Nastavte [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) na `true`, aby se závorky rozšířily kolem vysokého operandu, nebo na `false`, aby zůstaly v normální velikosti. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) přijímá jednu ze dvou hodnot [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) . `Centered` vycentruje závorky na matematické ose, která prochází středem znaménka rovnosti. `Match` je zarovná k obsahu uvnitř. Obě nastavení ovlivňují jen oddělovače. Výraz uvnitř zůstává stejný.

Příklad umisťuje zlomek do exponentu `x`, takže výraz se rozšiřuje více nad základní linku než pod ní. Všechny čtyři rovnice používají stejné závorky a nastavení písma.

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

V PowerPointu porovnejte řádky, abyste viděli efekt růstu. V horním řádku se závorky rozšíří, aby obalily exponent, a vypadají stejně pro oba tvary. Ve spodním řádku je růst vypnutý. Menší závorky vlevo (`Centered`) jsou zarovnané se znaménkem rovnosti, zatímco ty vpravo (`Match`) jsou výše kolem výrazu.

![Čtyři rovnice v PowerPointu s povoleným růstem oddělovačů nahoře a zakázaným dole, a Centered vlevo a Match vpravo](delimiter-sizing.png)

## **Přidání ohraničeného rámečku**

Zavolejte [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) na zlomek, abyste orámovali celý výraz. Vrácený [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) standardně zobrazuje všechny čtyři strany. Použijte [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), a [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) , abyste odstranili jednotlivé strany.

Příklad umisťuje šest kopií stejného zlomku na jeden snímek. Pro zobrazení zrušení skrývejte všechny čtyři strany a nastavte [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) , pro rostoucí úhlopříčku (↗) nebo [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) , pro klesající úhlopříčku (↘). Můžete také použít [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) , [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) s libovolnou kombinací viditelných stran.

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

![Šest editovatelných zlomků v PowerPointu. Horní řada: plné ohraničení, spodní a levá strana, rostoucí úhlopříčka. Spodní řada: klesající úhlopříčka, horizontální přeškrtnutí, vertikální přeškrtnutí s plným ohraničením](border-box-fractions.png)

Na tomto zlomku horizontální čára překrývá čáru zlomku. Vertikální čára prochází čitatel i jmenovatel, zatímco okolní ohraničení zůstává viditelné. Tyto čáry zdobí celý výraz. Běžné přeškrtnutí textu se vztahuje na znaky v textovém úseku. Po opětovném otevření prezentace v PowerPointu můžete stále editovat čitatel a jmenovatel samostatně.

## **Řízení viditelnosti a rozvržení pomocí phantom elementů**

Obalte výraz do [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) , aby bylo možné nezávisle řídit jeho viditelnost a prostor, který do rovnice přispívá. Vlastnosti [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) řídí následující:

| Vlastnost | Efekt |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Nastavte na `false`, aby se výraz skryl. Jeho rozměry stále přispívají k rozvržení, pokud níže uvedené vlastnosti nejsou `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Považuje vodorovnou šířku výrazu za nulu, což umožňuje sousedním prvkům se přiblížit. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Považuje jeho vzestup, výšku nad základní linku, za nulu. To může snížit prostor vyhrazený nad sousedními prvky. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Považuje jeho sestup, hloubku pod základní linku, za nulu. To může posunout čáru zlomku nebo jiný obsah pod výraz blíže k sousedům. |

Základní linka je referenční čára, na které leží běžná matematická písmena. Skrytí obsahu neodstraňuje jeho rozměry a považování rozměru za nulu neodstraňuje výraz. Podkladový výraz zůstává dostupný přes [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) . Nastavte [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) zpět na `true`, aby se znovu zobrazil; nastavení rozměrů zůstane beze změny.

Příklad níže vytvoří pět variant vedle sebe: viditelný zlomek, skrytý zlomek, který zachovává prostor, a tři skryté zlomky, kde je jeden rozměr považován za nulu. Každá varianta používá stejný okolní výraz a Cambria Math o velikosti 24 bodů. Všechny tvary rovnic mají stejnou horní pozici, označenou šedým vodítkem. Umístění phantom do čitatele vnějšího zlomku usnadňuje vidět změny ve vertikálním rozvržení.

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

![Pět rovnic v PowerPointu porovnávajících viditelný zlomek, skrytý zlomek, který zachovává prostor, a skryté zlomky s povoleným ZeroWidth, ZeroAsc nebo ZeroDesc](math-phantom.png)

## **Seskupení termínů**

Použijte [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) , abyste umístili znak skupiny nad nebo pod výraz. Přidejte limit pro označení seskupených termínů.

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

## **Formátování matematických elementů**

Používejte formátovací pomocníky jen tam, kde objasňují vzorec. Například [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) umisťuje pruh nad matematický element.

![Matematický výraz ABC s pruhovým nadpisem](powerpoint-math-equations_14.png)

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

### **Formátování textu v existující rovnici**

Pro formátování textu v celé existující rovnici projděte strom elementů každého matematického bloku. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) vrací pouze bezprostřední potomky, takže jej volajte rekurzivně, abyste dosáhli textu uvnitř zlomků, indexů, odmocnin a dalších vnořených struktur. Kontrolujte aktuální element i jeho potomky, aby se zahrnul i výchozí element, když je [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) .

Tento příklad předpokládá, že prezentace obsahuje rovnici jako `z = xᵢ / ∛y`, se zlomkem obsahujícím dolní index v čitateli a odmocninou ve jmenovateli. Zpracování pouze elementů nejvyšší úrovně bloku by přišlo o text uvnitř zlomku. Příklad najde matematické části v textových rámcích snímků, získá jejich bloky přes [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) , a nastaví [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) na 28 bodů u každého textového elementu přes jeho [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) .

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

Uložená prezentace obsahuje aktualizované formátování textu na každé úrovni každé zpracované rovnice, přičemž zachovává její textový obsah a matematickou strukturu.

---
title: Přidání matematických rovnic do prezentací PowerPoint v .NET
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
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro .NET, podporující OMML, ovládací prvky formátování a přehledné ukázky kódu v C#."
---
## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinovat elementy | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Vytvořit zlomky | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Přidat horní nebo dolní index | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Přidat funkce | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Přidat odmocniny | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Přidat limity | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Přidat levé skripty | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Přidat součty a integrály | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Přidat pole rovnic | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Přidat oddělovače | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Přidat pruhy a ohraničení | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Seskupit termíny | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), získáte jeho [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), a aktualizujete matematické bloky v tomto odstavci.

**Jsou rovnice uloženy jako editovatelná PowerPointová matematika?**

Ano. Při uložení do PPTX Aspose.Slides zapíše rovnici jako editovatelný Office matematický obsah.

**Mohu exportovat rovnice do LaTeXu?**

Ano. Získáte [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) z jeho [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), a zavoláte [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) , abyste jej exportovali přímo. Pro kompletní příklad viz [Export rovnic v MathML z prezentací v .NET](/slides/cs/net/exporting-math-equations/#export-math-equations-to-latex).