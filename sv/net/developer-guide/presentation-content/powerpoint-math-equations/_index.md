---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i .NET
linktitle: PowerPoint matematiska ekvationer
type: docs
weight: 80
url: /sv/net/powerpoint-math-equations/
keywords:
- matematisk ekvation
- matematisk symbol
- matematisk formel
- matematisk text
- lägg till matematisk ekvation
- lägg till matematisk symbol
- lägg till matematisk formel
- lägg till matematisk text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för .NET, med stöd för OMML, formateringskontroller och tydliga C#-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för .NET kan du skapa samma typ av matematiskt innehåll programmässigt: bråk, rötter, funktioner, gränser, N-ary-operatorer, matriser, arrayer och formaterade matematiska block.

I PowerPoint lägger användare normalt till ekvationer från **Insert > Equation**:

![PowerPoint-fliken Infoga med kommandot Equation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint-bild som innehåller en redigerbar matematisk ekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiska texten genom tre huvudobjekt:

- En matematisk form, skapad med [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) lagrar matematiskt innehåll i formens textram.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) och de flytande metoderna från [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Exportera matematiska ekvationer från presentationer i .NET](/slides/sv/net/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel använder [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) för att skapa en matematisk form och lägger till Pythagoras sats:

![Ekvationen c² = a² + b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) skapar en form som redan innehåller ett matematiskt stycke. Åtkom den första [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), hämta dess [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), och lägg till matematiska block eller matematiska element i den.
{{% /alert %}}

## **Lägg till bråk**

Använd [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) för att skapa ett bråk. Du kan välja en bråktyp med [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Ett snedvridet bråk som visar 1/x](powerpoint-math-equations_4.png)

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

För ett staplat bråk, använd [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Lägg till rötter**

Använd [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen, och argumentet blir exponenten.

![Ett n:te rotuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

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

### **Visa eller dölja graden av en kvadratrot**

En kvadratrot kan visa en explicit 2 eller använda den konventionella √x‑notationen. Egenskapen [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) för [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) styr vilken form som visas. Båda formerna behåller graden 2 och radikanden x i den redigerbara ekvationen.

![Samma kvadratrot med HideDegree satt till false till vänster och true till höger](square-root-degree.png)

Exemplet sparar samma kvadratrot två gånger. I `visible-degree.pptx` är 2 synlig. I `hidden-degree.pptx` är den dold.

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

## **Lägg till funktioner och gränser**

Använd [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) eller [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) för funktioner såsom `sin(x)`, `log(x)`, eller egna funktionsnamn. För gränsvärden, placera `lim` i ett [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) eller använd [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Gränsvärdet för x när x närmar sig oändligheten](powerpoint-math-equations_8.png)

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

För ett eget funktionsnamn, gör funktionsnamnet till det aktuella elementet och anropa [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) med dess argument:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Lägg till N-ary-operatorer och integraler**

Använd [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) för summationer, unioner, snitt och andra stora operatorer. Använd [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) för integraler. Båda metoderna låter dig ange lägre och övre gränser.

![En summa med lägre och övre gränser](powerpoint-math-equations_7.png)

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

N-ary-operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) och kombineras i uttrycket.

För en integral, använd [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrisen när du behöver parenteser, hakparenteser eller klammerparenteser.

![En matris med två rader och en tom cell](powerpoint-math-equations_10.png)

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

### **Redigera en befintlig matris**

Anta att en lektion i linjär algebra börjar med koefficientmatrisen i `matrix.pptx`, sparad av föregående exempel. För nästa övning behåller du den första ekvationen, ersätter den andra med två nya ekvationer och reviderar variabeluppsättningen. Öppna den befintliga matrisen via [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) för att behålla de koefficienter som fortfarande gäller.

![Ursprunglig tvåradig koefficientmatris med posterna 1, x och en tom cell i första raden samt x, 2 och y i den andra](matrix-before-edit.png)

Rad- och kolumnindex börjar på noll och refererar till matrisen som den ser ut vid varje anrop. Insättning av en rad före index 1 flyttar den ursprungliga andra raden till index 2. Insättning efter index 2 lägger sedan till en rad. Borttagning av rad 2 tar bort den ursprungliga andra ekvationen och flyttar den tillagda raden upp en position. Kolumner skiftar på samma sätt.

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

// Nya celler är initialt null. Sätt de icke-noll koefficienterna först.
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) justerar den första kolumnen åt vänster. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) justerar tre på varandra följande kolumner åt höger, med start på index 1. I `updated-matrix.pptx` har matrisen tre ekvationer och fyra variabler. De ursprungliga koefficienterna i första raden `1` och `x` visas nu i den första och tredje kolumnen.

![Uppdaterad matris med tre rader som visar raderna 1, 0, x, 0; 12, 1, 0, 0; och 0, 0, 10, 1](matrix-after-edit.png)

## **Lägg till ekvationsarrayer**

Använd [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matematisk array med x ovanför y](powerpoint-math-equations_11.png)

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

### **Justera en array med omgivande element**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) styr den vertikala justeringen av en array i förhållande till de matematiska elementen bredvid den. Exemplet nedan jämför justering med den första raden, centrum av arrayen och den sista raden.

Det följande exemplet skapar tre identiska arrayer, vardera med tre rader och de intilliggande elementen `A=` och `=B`. All matematisk text använder Cambria Math i 24 punkter. Endast array‑justeringen förändras.

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

Följande jämförelse visar den sparade presentationen i PowerPoint. Lägg märke till placeringen av `A=` och `=B` bredvid varje array.

![Ekvationsarrayer i PowerPoint med topp-, center- och bottenjustering och identiska omgivande element](equation-array-alignment.png)

### **Konfigurera radavstånd**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) väljer avståndsregeln för rader i arrayen. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) ger ett numeriskt värde för en explicit regel och ignoreras av de förinställda reglerna.

För exakt avstånd mäts värdet i punkter. För proportionellt avstånd mäts det i halvlinjer: värdet `3` i exemplet betyder 1,5 linjer. Ställ in båda egenskaperna när du anger ett explicit värde; att bara ändra det numeriska värdet väljer inte en regel.

Exemplet nedan sparar fem presentationer med samma ekvationer, justering och teckensnitt. De första tre använder förinställningar; de sista två visar explicita värden.

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

Array‑radavstånd är separerat från styckeavstånd. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) och [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) lägger till avstånd runt det omgivande stycket, inte mellan array‑rader. På samma sätt placerar [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) hela matematiska stycket horisontellt; det ersätter inte den vertikala justeringen för arrayen.

## **Lägg till trigonometriska funktioner**

Använd [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos tillämpad på 2x](powerpoint-math-equations_6.png)

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

## **Lägg till index och exponenter**

Använd hjälpfunktionerna för index och exponenter. När indexen måste visas på vänster sida om basen, använd [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Ett stort Y med vänstersidigt index 1 och exponent n](powerpoint-math-equations_9.png)

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

## **Lägg till avgränsare**

Använd [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) för att placera ett uttryck inom avgränsare. Du kan också ange ett separator‑tecken för avgränsare som innehåller flera element.

![Ett avgränsareuttryck som innehåller x, y och z separerade med vertikala streck](powerpoint-math-equations_13.png)

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

### **Storlek och justering av avgränsare**

Ställ in [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) till `true` för att låta parenteserna växa runt ett högt operand, eller till `false` för att hålla normal storlek. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) tar ett av två [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/)-värden. `Centered` centrerar parenteserna på matematikaxeln, som går genom mitten av likhetstecknet. `Match` justerar dem efter det inneslutna innehållet. Båda inställningarna påverkar endast avgränsarna. Uttrycket inuti förblir oförändrat.

Exemplet placerar ett bråk i exponenten för `x` så att uttrycket sträcker sig längre över baslinjen än under den. Alla fyra ekvationer använder samma parenteser och teckensnitt.

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

I PowerPoint, jämför raderna för att se effekten av tillväxt. I översta raden växer parenteserna för att omfatta exponenten och ser likadana ut för båda formerna. I nedersta raden är tillväxten avstängd. De mindre parenteserna till vänster (`Centered`) justeras med likhetstecknet, medan de till höger (`Match`) sitter högre kring uttrycket.

![Fyra ekvationer i PowerPoint med avgränsargödsling aktiverad ovanför och inaktiverad nedanför, och Centered till vänster och Match till höger](delimiter-sizing.png)

## **Lägg till en kantlinjebox**

Anropa [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) på ett bråk för att rama in hela uttrycket. Den returnerade [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) visar som standard alla fyra sidor. Använd [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) och [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) för att ta bort enskilda sidor.

Exemplet placerar sex kopior av samma bråk på en bild. För att visa annullering, dölj alla fyra sidor och ange [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) för en stigande diagonal (↗) eller [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) för en fallande diagonal (↘). Du kan också använda [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) eller [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) med valfri kombination av synliga sidor.

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

![Sex redigerbara bråk i PowerPoint. Översta raden: full kant, nedre och vänstra sidorna, stigande diagonal. Nedre raden: fallande diagonal, horisontell linje, vertikal linje med full kant.](border-box-fractions.png)

På detta bråk överlappar den horisontella linjen bråkstrecket. Den vertikala linjen korsar både täljaren och nämnaren medan den omgivande kanten förblir synlig. Dessa linjer dekorerar hela uttrycket. Vanlig genomstrykning av text gäller för tecken i ett textsegment. Efter att ha öppnat presentationen igen i PowerPoint kan du fortfarande redigera täljaren och nämnaren oberoende.

## **Styr synlighet och layout med Phantom‑element**

Omge ett uttryck med [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) för att kontrollera dess synlighet och det utrymme det bidrar med i en ekvation oberoende. [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/)‑egenskaperna styr följande:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Sätt till `false` för att dölja uttrycket. Dess dimensioner bidrar fortfarande till layouten såvida inte motsvarande egenskaper nedan är `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Behandla uttryckets horisontella bredd som noll, så att närliggande element kan komma närmare varandra. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Behandla dess uppstigning, höjden ovanför baslinjen, som noll. Detta kan minska utrymmet reserverat ovanför närliggande element. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Behandla dess nedstigning, djupet under baslinjen, som noll. Detta kan flytta en bråkstreck eller annat innehåll under uttrycket närmare sina grannar. |

Baslinjen är referenslinjen som vanliga matematiska tecken vilar på. Att dölja innehåll tar inte bort dess dimensioner, och att behandla en dimension som noll tar inte bort uttrycket. Det underliggande uttrycket är fortfarande tillgängligt via [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Sätt [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) tillbaka till `true` för att visa det igen; dimensioninställningarna förblir oförändrade.

Exemplet nedan skapar fem sida‑vid‑sida‑varianter: ett synligt bråk, ett dolt bråk som reserverar utrymme och tre dolda bråk där en dimension behandlas som noll. Varje variant använder samma omgivande uttryck och Cambria Math i 24 punkter. Alla ekvationsformer har samma topplacering, markerad av den grå guiden. Att placera phantom i täljaren av ett yttre bråk gör de vertikala layout‑ändringarna lättare att se.

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

![Fem ekvationer i PowerPoint som jämför ett synligt bråk, ett dolt bråk som reserverar utrymme, och dolda bråk med ZeroWidth, ZeroAsc eller ZeroDesc aktiverat](math-phantom.png)

## **Gruppera termer**

Använd [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) för att placera ett grupperings­tecken ovanför eller under ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten någon text nedanför](powerpoint-math-equations_15.png)

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

## **Formatera matematiska element**

Använd formateringshjälpmedel endast där de klargör formeln. Till exempel placerar [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) ett streck ovanför ett matematiskt element.

![Ett matematiskt uttryck ABC med en överstreck](powerpoint-math-equations_14.png)

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

### **Formatera text i en befintlig ekvation**

För att formatera text i hela en befintlig ekvation, gå igenom varje matematiskt blocks elementträd. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) returnerar bara de omedelbara barnen, så anropa den rekursivt för att nå text i bråk, skript, rötter och andra nästlade strukturer. Kontrollera både det aktuella elementet och dess barn för att inkludera start‑elementet när det är [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Detta exempel förutsätter att en presentation innehåller en ekvation som `z = xᵢ / ∛y`, med ett bråk som innehåller ett index i täljaren och en rot i nämnaren. Att bara bearbeta blockets element på top‑nivå skulle missa texten i bråket. Exemplet hittar matematiska portioner i bildtextramar, får åtkomst till deras block via [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), och sätter [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) till 28 punkter genom varje textelements [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/)‑egenskap.

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

Den sparade presentationen innehåller den uppdaterade textformateringen på varje nivå i varje bearbetad ekvation, samtidigt som den bevarar textinnehållet och den matematiska strukturen.

## **Snabbreferens**

| Task | Main API |
| --- | --- |
| Skapa matematisk text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinera element | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Skapa bråk | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Lägg till upphöjt eller nedsänkt tal | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Lägg till funktioner | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Lägg till rötter | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Lägg till gränsvärden | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Lägg till scripts på vänster sida | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Lägg till summationer och integraler | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Lägg till ekvationsarrayer | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Lägg till avgränsare | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Lägg till staplar och kantlinjer | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Gruppera termer | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta den form som innehåller en [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), hämta dess [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), och uppdatera de matematiska blocken i det stycket.

**Sparas ekvationer som redigerbar PowerPoint‑matematik?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑math‑innehåll.

**Kan jag exportera ekvationer till LaTeX?**

Ja. Hämta ekvationens [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) från dess [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), och anropa [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) för att exportera den direkt. För ett komplett exempel, se [Export Math Equations from Presentations in .NET](/slides/sv/net/exporting-math-equations/#export-math-equations-to-latex).