---
title: Wiskundige vergelijkingen toevoegen aan PowerPoint-presentaties in .NET
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
description: "Wiskundige vergelijkingen invoegen en bewerken in PowerPoint PPT en PPTX met Aspose.Slides voor .NET, met ondersteuning voor OMML, opmaakbesturingen en duidelijke C# codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides voor .NET kunt u dezelfde soort wiskundige inhoud programmatig creëren: breuken, radicalen, functies, limieten, N‑aire operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Insert > Equation**:

![PowerPoint Invoegen-tabblad met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint-dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) slaat wiskundige inhoud op binnen het tekstvak van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) bevat één of meer [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) en de fluent‑methoden van [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) om de code kort en leesbaar te houden.

Voor MathML‑exportscenario's, zie [Exporteer wiskundige vergelijkingen uit presentaties in .NET](/slides/nl/net/exporting-math-equations/).

## **Maak een vergelijking**

Dit voorbeeld gebruikt [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) om een wiskundige vorm te maken en voegt het Pythagoras‑theorema toe:

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

{{% alert color="info" title="Opmerking" %}}

[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) maakt een vorm die al een wiskundige alinea bevat. Open de eerste [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), haal zijn [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) op, en voeg wiskundige blokken of wiskundige elementen toe.

{{% /alert %}}

### **Combineer wiskundige blokken**

Wanneer delen van een vergelijking onafhankelijk worden opgebouwd als [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/)‑objecten, gebruik dan [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) om ze te combineren. Het voorbeeld bouwt `c² =` in het linkse blok en `a² + b²` in het rechtse blok. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) maakt bewerkbare wiskundige superscripten voor alle drie de machten.

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

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) retourneert `leftBlock` zelf, nu met beide delen in de juiste volgorde, en laat `rightBlock` leeg. Voeg het gecombineerde blok één keer toe aan de [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/). Na het opnieuw openen van `equation.pptx` bevat de alinea één blok dat `c² = a² + b²` voorstelt, met alle drie de machten bewaard als wiskundige superscripten.

Het aanroepen van [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) als `leftBlock.Add(rightBlock)` probeert één blok direct binnen een ander te nestelen en veroorzaakt een `InvalidOperationException`.

## **Voeg breuken toe**

Gebruik [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) om een breuk te maken. U kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Een scheve wiskundige breuk waarin één gedeeld wordt door x](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Voeg radicalen toe**

Gebruik [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) om een vierkantswortel, derdemachtswortel of een andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n-de wortel met x onder het wortelteken](powerpoint-math-equations_5.png)

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

### **Toon of verberg de graad van een vierkantswortel**

Een vierkantswortel kan een expliciete 2 tonen of de conventionele √x‑notatie gebruiken. De eigenschap [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) van [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) bepaalt welke vorm verschijnt. Beide vormen behouden graad 2 en radicand x in de bewerkbare vergelijking.

![Dezelfde vierkantswortel met HideDegree ingesteld op false links en true rechts](square-root-degree.png)

Het voorbeeld slaat dezelfde vierkantswortel twee keer op. In `visible-degree.pptx` is de 2 zichtbaar. In `hidden-degree.pptx` is hij verborgen.

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

## **Voeg functies en limieten toe**

Gebruik [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) of [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) voor functies zoals `sin(x)`, `log(x)` of zelfgekozen functienamen. Voor limieten, plaats `lim` in een [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) of gebruik [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

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

Voor een eigen functienaam, maak de functienaam het huidige element en roep [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) aan met zijn argument:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Voeg N‑aire operatoren en integralen toe**

Gebruik [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) voor sommaties, unies, sneden en andere grote operatoren. Gebruik [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) voor integralen. Beide methoden laten u onder‑ en bovengrenzen instellen.

![Een sommeteken met onder‑ en bovengrenzen](powerpoint-math-equations_7.png)

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

N‑aire operatoren zijn voor grote operatoren met optionele grenzen. Simpele operatoren zoals `+`, `-` en `=` worden gewoonlijk toegevoegd als [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) en samengevoegd in de expressie.

Voor een integraal, gebruik [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Voeg matrices toe**

Gebruik [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omsluit de matrix wanneer u haakjes, vierkante haken of accolades nodig heeft.

![Een matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

### **Bewerk een bestaande matrix**

Stel dat een lineaire‑algebra‑les begint met de coëfficiëntenmatrix in `matrix.pptx`, opgeslagen door het voorgaande voorbeeld. Voor de volgende oefening behoudt u de eerste vergelijking, vervangt u de tweede door twee nieuwe vergelijkingen, en past u de set variabelen aan. Open de bestaande matrix via [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) om de nog geldige coëfficiënten te behouden.

![Originele matrix met twee rijen, invoer 1, x en een lege cel in de eerste rij en x, 2 en y in de tweede rij](matrix-before-edit.png)

Rij‑ en kolomindexen beginnen bij nul en verwijzen naar de matrix zoals die op elk moment bestaat. Een rij invoegen vóór index 1 verschuift de oorspronkelijke tweede rij naar index 2. Invoegen na index 2 voegt vervolgens een rij toe. Het verwijderen van rij 2 verwijdert de oorspronkelijke tweede vergelijking en verschuift de toegevoegde rij één positie omhoog. Kolommen verschuiven op dezelfde manier.

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

// Nieuwe cellen zijn aanvankelijk null. Stel eerst de niet‑nul coëfficiënten in.
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) lijnt de eerste kolom links uit. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) lijnt drie opeenvolgende kolommen rechts uit, beginnend bij index 1. In `updated-matrix.pptx` heeft de matrix drie vergelijkingen en vier variabelen. De oorspronkelijke coëfficiënten `1` en `x` van de eerste rij verschijnen nu in de eerste en derde kolom.

![Bijgewerkte matrix met drie rijen: 1, 0, x, 0; 12, 1, 0, 0; en 0, 0, 10, 1](matrix-after-edit.png)

## **Voeg vergelijking‑arrays toe**

Gebruik [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) wanneer u uitgelijnde vergelijkingen of een verticale stapel expressies nodig heeft.

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

### **Lijn een array uit met omringende elementen**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) bepaalt de verticale uitlijning van een array ten opzichte van de wiskundige elementen ernaast. Het onderstaande voorbeeld vergelijkt uitlijning met de eerste rij, het midden van de array en de laatste rij.

Het volgende voorbeeld maakt drie identieke arrays, elk met drie rijen en de naastliggende elementen `A=` en `=B`. Alle wiskundige tekst gebruikt Cambria Math met 24 pt. Alleen de array‑uitlijning verschuift.

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

![Vergelijking‑arrays in PowerPoint met boven‑, midden‑ en onder‑uitlijning en identieke naburige elementen](equation-array-alignment.png)

### **Stel rij‑spatiëring in**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) kiest de spatiëringsregel voor rijen binnen de array. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) geeft een numerieke waarde voor een expliciete spatiëringsregel en wordt genegeerd door de voorinstellingen.

Voor exacte spatiëring wordt de waarde gemeten in punten. Voor proportionele spatiëring wordt gemeten in halve regels: de waarde `3` in het voorbeeld betekent 1,5 regels. Stel beide eigenschappen in wanneer u een expliciete waarde opgeeft; het alleen wijzigen van de numerieke waarde selecteert de spatiëringsregel niet.

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

Array‑rij‑spatiëring staat los van alinea‑spatiëring. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) en [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) voegen ruimte toe rond de omvattende alinea, niet tussen array‑rijen. Evenzo positioneert [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) de hele wiskundige alinea horizontaal; het vervangt niet de verticale uitlijningsinstelling van de array.

## **Voeg trigonometrische functies toe**

Gebruik [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) wanneer het argument het huidige element is en de functienaam bekend.

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

## **Voeg sub‑ en superscripten toe**

Gebruik de sub‑ en superscript‑helpers voor indexen en machten. Wanneer de indexen links van de basis moeten staan, gebruik dan [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Een hoofdletter Y met links‑subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Voeg begrenzers toe**

Gebruik [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) om een expressie binnen begrenzers te plaatsen. U kunt ook een scheidingsteken definiëren voor begrenzer‑expressies die meerdere elementen bevatten.

![Een begrenzer‑expressie met x, y en z gescheiden door verticale streepjes](powerpoint-math-equations_13.png)

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

### **Grootte en uitlijning van begrenzers**

Stel [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) in op `true` om de haakjes te laten groeien rondom een hoge operand, of op `false` om de normale grootte te behouden. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) accepteert één van twee waarden van [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` centreert de haakjes op de wiskundige as, die door het midden van het =‑teken loopt. `Match` lijnt ze uit met de ingesloten inhoud. Beide instellingen beïnvloeden uitsluitend de begrenzers. De expressie binnen blijft gelijk.

Het voorbeeld plaatst een breuk in de exponent van `x` zodat de expressie verder boven de basislijn uitsteekt dan eronder. Alle vier vergelijkingen gebruiken dezelfde haakjes en lettertype‑instellingen.

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

In PowerPoint vergelijkt u de rijen om het effect van groei te zien. In de bovenste rij groeien de haakjes om de exponent en zien er identiek uit voor beide vormen. In de onderste rij is groei uitgeschakeld. De kleinere haakjes links (`Centered`) lijnen uit met het =‑teken, terwijl die rechts (`Match`) hoger staan rond de uitdrukking.

![Vier vergelijkingen in PowerPoint met begrenzer‑groei ingeschakeld boven en uitgeschakeld hieronder, en Centered links en Match rechts](delimiter-sizing.png)

## **Voeg een randvak toe**

Roep [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) aan op een breuk om de gehele expressie te omlijsten. Het geretourneerde [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) toont standaard alle vier zijden. Gebruik [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) en [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) om individuele zijden te verwijderen.

Het voorbeeld plaatst zes kopieën van dezelfde breuk op één dia. Om annulering te tonen, verberg alle vier de zijden en stel [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) in voor een stijgende diagonale lijn (↗) of [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) voor een dalende diagonale lijn (↘). U kunt ook [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) of [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) gebruiken met elke combinatie van zichtbare zijden.

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

![Zes bewerkbare breuken in PowerPoint. Bovenste rij: volledige rand, onder‑ en linkerseiten, stijgende diagonale lijn. Onderste rij: dalende diagonale lijn, horizontale lijn, verticale lijn met volledige rand.](border-box-fractions.png)

Op deze breuk overlapt de horizontale streep de breukstreep. De verticale streep doorsnijdt zowel de teller als de noemer terwijl de omringende rand zichtbaar blijft. Deze lijnen sieren de volledige expressie. Normale doorhaling van tekst geldt alleen voor karakters in een tekstrun. Na het opnieuw openen van de presentatie in PowerPoint kunt u de teller en noemer nog steeds onafhankelijk bewerken.

## **Beheer zichtbaarheid en opmaak met phantom‑elementen**

Wikkel een expressie in [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) om de zichtbaarheid en de ruimte die het bijdraagt aan een vergelijking onafhankelijk te regelen. De eigenschappen van [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) bepalen het volgende:

| Eigenschap | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Zet op `false` om de expressie te verbergen. De afmetingen blijven bijdragen aan de lay-out tenzij de bijbehorende eigenschappen hieronder op `true` staan. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Behandelt de horizontale breedte van de expressie als nul, zodat naburige elementen dichter bij elkaar kunnen komen. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Behandelt de stijging (hoogte boven de basislijn) als nul. Dit kan de ruimte boven naburige elementen verminderen. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Behandelt de daling (diepte onder de basislijn) als nul. Dit kan een breukstreep of andere inhoud onder de expressie dichter bij de buren plaatsen. |

De basislijn is de referentielijn waarop gewone wiskundige letters rusten. Het verbergen van inhoud verwijdert niet de afmetingen, en een afmeting op nul zetten verwijdert de expressie niet. De onderliggende expressie blijft beschikbaar via [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Zet [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) terug op `true` om hem weer te tonen; de dimensioneringsinstellingen blijven behouden.

Het voorbeeld hieronder creëert vijf varianten naast elkaar: een zichtbare breuk, een verborgen breuk die ruimte reserveert, en drie verborgen breuken met één dimensie op nul. Elke variant gebruikt dezelfde omringende expressie en Cambria Math met 24 pt. Alle vergelijking‑vormen hebben dezelfde bovenste positie, gemarkeerd door de grijze hulplijn. Het plaatsen van de phantom in de teller van een buitenste breuk maakt de verticale lay‑outveranderingen duidelijker.

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

![Vijf vergelijkingen in PowerPoint die een zichtbare breuk, een verborgen breuk die ruimte reserveert, en verborgen breuken met ZeroWidth, ZeroAsc of ZeroDesc tonen](math-phantom.png)

## **Groeperen van termen**

Gebruik [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) om een groeperings‑teken boven of onder een expressie te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De expressie x + y gegroepeerd met het label enige tekst eronder](powerpoint-math-equations_15.png)

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

## **Opmaak van wiskunde‑elementen**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) plaatst een balk boven een wiskundig element.

![Een wiskundige expressie ABC met een overbar](powerpoint-math-equations_14.png)

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

### **Opmaak van tekst in een bestaande vergelijking**

Om tekst door een bestaande vergelijking heen te formatteren, doorloopt u elke wiskundige blok‑elementboom. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) retourneert alleen de directe kinderen, dus roep het recursief aan om tekst in breuken, script‑elementen, radicalen en andere geneste structuren te bereiken. Controleer zowel het huidige element als zijn kinderen om ook het start‑element mee te nemen wanneer het [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) is.

Dit voorbeeld gaat uit van een presentatie met een vergelijking zoals `z = xᵢ / ∛y`, met een breuk die een subscript in de teller heeft en een radicaal in de noemer. Het verwerken van alleen de top‑level elementen van het blok zou de tekst in de breuk missen. Het voorbeeld vindt wiskundige porties in dia‑tekstkaders, opent hun blokken via [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), en stelt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in op 28 pt via elke tekstelement‑[Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

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
| Maak wiskundige tekst | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combineer elementen | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Maak breuken | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Voeg superscript of subscript toe | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Voeg functies toe | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Voeg radicalen toe | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Voeg limieten toe | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Voeg links‑scripts toe | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Voeg sommaties en integralen toe | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Voeg matrices toe | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Voeg vergelijking‑arrays toe | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Voeg begrenzers toe | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Voeg balken en randen toe | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Groepeer termen | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, vind de vorm die een [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) bevat, haal de bijbehorende [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) op, en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer u naar PPTX opslaat, schrijft Aspose.Slides de vergelijking weg als bewerkbare Office‑wiskunde‑inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal de [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) van de [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) op, en roep [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) aan om rechtstreeks te exporteren. Voor een volledig voorbeeld, zie [Exporteer wiskundige vergelijkingen uit presentaties in .NET](/slides/nl/net/exporting-math-equations/#export-math-equations-to-latex).