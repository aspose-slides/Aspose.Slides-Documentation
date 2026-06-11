---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i .NET
linktitle: PowerPoint-matematikekvationer
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

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för .NET kan du skapa samma typ av matematiskt innehåll programmässigt: bråk, radikaler, funktioner, gränsvärden, N-ära operatorer, matriser, arrayer och formaterade matematiksblock.

I PowerPoint lägger användare normalt till ekvationer via **Infoga > Ekvation**:

![PowerPoint Infoga-flik med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint-bild som innehåller en redigerbar matematisk ekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiken genom tre huvudobjekt:

- En matematisk form, skapad med [AddMathShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addmathshape/), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathportion/) lagrar matematiskt innehåll i formens textram.
- [MathParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathematicaltext/) och de flytande metoderna från [IMathElement](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Exportera matematiska ekvationer från presentationer i .NET](/slides/sv/net/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en matematisk form och lägger till Pythagoras sats:

![Ekvationen c kvadrat är lika med a kvadrat plus b kvadrat](powerpoint-math-equations_3.png)

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

`AddMathShape` skapar en form som redan innehåller ett matematiskt stycke. Hämta den första `MathPortion`, få dess `MathParagraph` och lägg till matematiska block eller matematiska element i den.

{{% /alert %}}

## **Lägg till bråk**

Använd `Divide` för att skapa ett bråk. Du kan välja en bråkstil med [MathFractionTypes](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathfractiontypes/).

![Ett snett matematiskt bråk som visar ett delat med x](powerpoint-math-equations_4.png)

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

För ett staplat bråk, använd `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Lägg till radikaler**

Använd `Radical` för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n-te rotradicuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

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

## **Lägg till funktioner och gränsvärden**

Använd `AsArgumentOfFunction` eller `Function` för funktioner som `sin(x)`, `log(x)` eller anpassade funktionsnamn. För gränsvärden, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathlimit/) eller använd `SetLowerLimit`.

![Gränsvärdet för x när x går mot oändligheten](powerpoint-math-equations_8.png)

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

För ett anpassat funktionsnamn, gör funktionsnamnet till det aktuella elementet:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Lägg till N-ära operatorer och integraler**

Använd `Nary` för summor, unioner, snitt och andra stora operatorer. Använd `Integral` för integraler. Båda metoderna låter dig ange lägre och övre gränser.

![En summa med lägre och övre gränser](powerpoint-math-equations_7.png)

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

N-ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer som `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och slås ihop i uttrycket.

För en integral, använd `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrisen när du behöver parenteser, hakparenteser eller klammer.

![En tvåradermatris med en tom cell](powerpoint-math-equations_10.png)

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

## **Lägg till ekvationsarrayer**

Använd `ToMathArray` när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matris med x ovanför y](powerpoint-math-equations_11.png)

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

## **Lägg till trigonometriska funktioner**

Använd `AsArgumentOfFunction` när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos tillämpad på 2x](powerpoint-math-equations_6.png)

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

## **Lägg till nedsänkta och upphöjda**

Använd hjälpfunktionerna för nedsänkta och upphöjda för index och potenser. När indexen måste visas på vänster sida av basen, använd `SetSubSuperscriptOnTheLeft`.

![Ett stort Y med nedsänkt index 1 till vänster och upphöjd n](powerpoint-math-equations_9.png)

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

## **Lägg till avgränsare**

Använd `Enclose` för att placera ett uttryck inom avgränsare. Du kan också ange ett separatorstecken för avgränsade uttryck som innehåller flera element.

![Ett avgränsat uttryck som innehåller x, y och z separerade med vertikala staplar](powerpoint-math-equations_13.png)

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

## **Lägg till en ramruta**

Använd `ToBorderBox` när själva ekvationen ska ramas in.

![En inramad ekvation som visar a kvadrat är lika med b kvadrat plus c kvadrat](powerpoint-math-equations_12.png)

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

## **Gruppera termer**

Använd `Group` för att placera ett grupperingstecken ovanför eller under ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten någon text nedanför](powerpoint-math-equations_15.png)

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

## **Formatera matematiska element**

Använd formateringshjälp med endast där de förtydligar formeln. Till exempel placerar `Overbar` ett streck över ett matematiskt element.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa matematisk text | [MathematicalText](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinera element | [IMathElement.Join](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/join/) |
| Skapa bråk | [IMathElement.Divide](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/divide/) |
| Lägg till upphöjd eller nedsänkt | [SetSuperscript](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Lägg till funktioner | [Function](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Lägg till radikaler | [IMathElement.Radical](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/radical/) |
| Lägg till gränsvärden | [SetLowerLimit](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Lägg till vänstersidiga index | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Lägg till summor och integraler | [Nary](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/integral/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/mathmatrix/) |
| Lägg till ekvationsarrayer | [ToMathArray](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Lägg till avgränsare | [Enclose](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/enclose/) |
| Lägg till överstreck och ramar | [Overbar](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Gruppera termer | [Group](https://reference.aspose.com/slides/sv/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera de matematiska blocken i det stycket.

**Sparas ekvationer som redigerbar PowerPoint‑matte?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑matematikinnehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematiska ekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stödjer ditt mål‑LaTeX‑dialekt.