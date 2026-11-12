---
title: Wiskundige vergelijkingen toevoegen aan PowerPoint‑presentaties in .NET
linktitle: PowerPoint wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/net/powerpoint-math-equations/
keywords:
- wiskundige vergelijking
- wiskundig symbool
- wiskundige formule
- wiskundige tekst
- wiskundige vergelijking toevoegen
- wiskundig symbool toevoegen
- wiskundige formule toevoegen
- wiskundige tekst toevoegen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Wiskundige vergelijkingen invoegen en bewerken in PowerPoint PPT en PPTX met Aspose.Slides voor .NET, met ondersteuning voor OMML, opmaakbesturingen en duidelijke C#‑codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides for .NET kun je dezelfde soort wiskundige inhoud programmatisch maken: breuken, wortels, functies, limieten, N‑ary‑operatoren, matrices, arrays en geformatteerde wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Insert > Equation**:

![PowerPoint Invoegen‑tab met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint‑dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) slaat wiskundige inhoud op in het tekstframe van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) bevat één of meer [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)‑objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) en de fluent‑methoden van [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) om de code kort en leesbaar te houden.

Voor MathML‑exportsituaties, zie [Exporteer wiskundige vergelijkingen uit presentaties in .NET](/slides/nl/net/exporting-math-equations/).

## **Een vergelijking maken**

Dit voorbeeld gebruikt [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) om een wiskundige vorm te maken en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) maakt een vorm die al een wiskundige alinea bevat. Open de eerste [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), haal de bijbehorende [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), en voeg wiskundige blokken of wiskundige elementen toe.
{{% /alert %}}

## **Breuken toevoegen**

Gebruik [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x toont](powerpoint-math-equations_4.png)

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

Voor een stapelbreuk, gebruik [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Wortels toevoegen**

Gebruik [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) om een vierkantswortel, kubieke wortel of een andere wortel te maken. Het huidige element wordt de basis en het argument wordt de graad.

![Een n‑de‑wortel‑expressie met x onder het wortelteken](powerpoint-math-equations_5.png)

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

## **Functies en limieten toevoegen**

Gebruik [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) of [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten, plaats `lim` in een [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) of gebruik [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

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

Voor een aangepaste functienaam, maak de functienaam het huidige element en roep [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) aan met zijn argument:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N‑ary operatoren en integralen toevoegen**

Gebruik [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) voor sommaties, unies, doorsneden en andere grote operatoren. Gebruik [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) voor integralen. Beide methoden laten je de onder‑ en bovengrenzen instellen.

![Een som met onder‑ en bovengrenzen](powerpoint-math-equations_7.png)

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

N‑ary‑operatoren zijn voor grote operatoren met optionele limieten. Eenvoudige operatoren zoals `+`, `-` en `=` worden meestal toegevoegd als [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) en in de expressie samengevoegd.

Voor een integraal, gebruik [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrices toevoegen**

Gebruik [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omkader de matrix wanneer je ronde haakjes, vierkante haakjes of accolades nodig hebt.

![Een wiskundige matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

## **Vergelijkings‑arrays toevoegen**

Gebruik [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) wanneer je uitgelijnde vergelijkingen of een verticale stapel expressies nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

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

### **Een array uitlijnen met omliggende elementen**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) bepaalt de verticale uitlijning van een array ten opzichte van de wiskundige elementen ernaast. Het voorbeeld hieronder vergelijkt uitlijning met de eerste rij, het midden van de array en de laatste rij.

Het voorbeeld hieronder maakt drie identieke arrays, elk met drie rijen en de naburige elementen `A=` en `=B`. Alle wiskundige tekst gebruikt Cambria Math op 24 punten. Alleen de uitlijning van de array verandert.

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

De volgende vergelijking toont de opgeslagen presentatie in PowerPoint. Let op de positie van `A=` en `=B` naast elke array.

![Vergelijkings‑arrays in PowerPoint met boven‑, midden‑ en onder‑uitlijning en identieke aangrenzende elementen](equation-array-alignment.png)

### **Rij‑spatiëring configureren**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) selecteert de spatiëringsregel voor rijen binnen de array. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) levert een numerieke waarde voor een expliciete spatiëringsregel en wordt genegeerd door de voorinstellingregels.

Voor exacte spatiëring wordt de waarde gemeten in punten. Voor proportionele spatiëring wordt gemeten in halve regels: de waarde `3` in het voorbeeld geeft 1,5 regels aan. Stel beide eigenschappen in bij het opgeven van een expliciete waarde; alleen de numerieke waarde aanpassen selecteert geen spatiëringsregel.

Het voorbeeld hieronder slaat vijf presentaties op met dezelfde vergelijkingen, uitlijning en lettertype‑instellingen. De eerste drie gebruiken voorinstellingen; de laatste twee tonen expliciete waarden.

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

Rij‑spatiëring van een array staat los van alinea‑spatiëring. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) en [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) voegen ruimte toe rond de omsluitende alinea, niet tussen array‑rijen. Evenzo positioneert [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) de volledige wiskundige alinea horizontaal; het vervangt niet de verticale uitlijningsinstelling van de array.

## **Trigonometrische functies toevoegen**

Gebruik [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) wanneer het argument het huidige element is en de functienaam bekend is.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

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

## **Subscript‑ en superscript‑tekens toevoegen**

Gebruik de subscript‑ en superscript‑helpers voor indices en machten. Wanneer de indices aan de linkerkant van de basis moeten verschijnen, gebruik [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Een hoofdletter Y met links subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Scheidingstekens toevoegen**

Gebruik [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) om een expressie tussen scheidingstekens te plaatsen. Je kunt ook een scheidingsteken instellen voor delimiter‑expressies die meerdere elementen bevatten.

![Een delimiter‑expressie met x, y en z gescheiden door verticale staven](powerpoint-math-equations_13.png)

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

### **Grootte en uitlijning van scheidingstekens**

Stel [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) in op `true` om de haakjes rond een hoge operand te laten groeien, of op `false` om ze op hun normale grootte te houden. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) accepteert één van twee [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/)‑waarden. `Centered` centreert de haakjes op de wiskundige as, die door het midden van het gelijkteken loopt. `Match` aligneert ze met de ingesloten inhoud. Beide instellingen hebben alleen invloed op de scheidingstekens. De expressie binnen blijft hetzelfde.

Het voorbeeld plaatst een breuk in de exponent van `x` zodat de expressie verder boven de basislijn uitsteekt dan eronder. Alle vier de vergelijkingen gebruiken dezelfde haakjes en lettertype‑instellingen.

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

In PowerPoint, vergelijk de rijen om het effect van groeien te zien. In de bovenste rij groeien de haakjes om de exponent te omsluiten en zien ze er gelijk uit voor beide vormen. In de onderste rij is groei uitgeschakeld. De kleinere haakjes links (`Centered`) zijn uitgelijnd met het gelijkteken, terwijl die rechts (`Match`) hoger rond de expressie staan.

![Vier vergelijkingen in PowerPoint met delimitergroei aan boven en uitgeschakeld onder, en Centered links en Match rechts](delimiter-sizing.png)

## **Een randvak toevoegen**

Roep [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) aan op een breuk om de hele expressie te omkaderen. Het geretourneerde [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) toont standaard alle vier zijden. Gebruik [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), en [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) om individuele zijden te verwijderen.

Het voorbeeld plaatst zes kopieën van dezelfde breuk op één dia. Om annulering te tonen, verberg alle vier zijden en stel [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) in voor een stijgende diagonale (↗) of [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) voor een dalende diagonale (↘). Je kunt ook [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) of [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) gebruiken met een willekeurige combinatie van zichtbare zijden.

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

![Zes bewerkbare breuken in PowerPoint. Bovenste rij: volledige rand, onderste en linkse zijden, stijgende diagonale. Onderste rij: dalende diagonale, horizontale streep, verticale streep met een volledige rand.](border-box-fractions.png)

Bij deze breuk overlapt de horizontale streep de breukstreep. De verticale streep kruist zowel de teller als de noemer terwijl de omringende rand zichtbaar blijft. Deze lijnen versieren de hele expressie. Doorhaling van gewone tekst geldt voor tekens in een tekstreeks. Na het opnieuw openen van de presentatie in PowerPoint kun je de teller en noemer nog steeds onafhankelijk bewerken.

## **Termen groeperen**

Gebruik [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) om een groepeerteken boven of onder een expressie te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De expressie x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

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

## **Wiskundige elementen opmaken**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) plaatst een balk boven een wiskundig element.

![Een wiskundige expressie ABC met een bovenstreep](powerpoint-math-equations_14.png)

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

### **Tekst opmaken in een bestaande vergelijking**

Om tekst door de gehele bestaande vergelijking op te maken, doorloop je de elementboom van elk wiskundig blok. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) geeft alleen de directe kinderen terug, dus roep je het recursief aan om tekst in breuken, scripts, wortels en andere geneste structuren te bereiken. Controleer zowel het huidige element als de kinderen om het begin­element op te nemen wanneer het [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) is.

Dit voorbeeld gaat ervan uit dat een presentatie een vergelijking bevat zoals `z = xᵢ / ∛y`, met een breuk die een subscript in de teller en een wortel in de noemer bevat. Alleen de bovenste elementen van het blok verwerken zou de tekst in de breuk missen. Het voorbeeld vindt wiskundige delen in dia‑tekstframes, opent hun blokken via [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), en stelt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in op 28 punten via de [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/)‑eigenschap van elk tekstelement.

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

De opgeslagen presentatie bevat de bijgewerkte tekstopmaak op elk niveau van elke verwerkte vergelijking, terwijl de tekstinhoud en wiskundige structuur behouden blijven.

## **Snelle referentie**

| Taak | Hoofd‑API |
| --- | --- |
| Wiskundige tekst maken | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Elementen combineren | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Breuken maken | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Superscript of subscript toevoegen | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Functies toevoegen | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Wortels toevoegen | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Limieten toevoegen | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Scripts aan linkerkant toevoegen | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Sommaties en integralen toevoegen | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Matrices toevoegen | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Vergelijkings‑arrays toevoegen | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Scheidingstekens toevoegen | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken en randen toevoegen | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Termen groeperen | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, vind de vorm die een [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) bevat, haal zijn [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) op, en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer je opslaat naar PPTX, schrijft Aspose.Slides de vergelijking als bewerkbare Office‑wiskundige inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal de [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) van de vergelijking op via zijn [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), en roep [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) aan om deze direct te exporteren. Voor een volledig voorbeeld, zie [Export Math Equations from Presentations in .NET](/slides/nl/net/exporting-math-equations/#export-math-equations-to-latex).