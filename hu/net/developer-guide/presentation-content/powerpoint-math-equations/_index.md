---
title: "Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz .NET-ben"
linktitle: "PowerPoint Matematikai Egyenletek"
type: docs
weight: 80
url: /hu/net/powerpoint-math-equations/
keywords:
- "matematikai egyenlet"
- "matematikai szimbólum"
- "matematikai képlet"
- "matematikai szöveg"
- "matematikai egyenlet hozzáadása"
- "matematikai szimbólum hozzáadása"
- "matematikai képlet hozzáadása"
- "matematikai szöveg hozzáadása"
- "PowerPoint"
- "prezentáció"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével, OMML támogatással, formázási vezérlésekkel és átlátható C# kódmintákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for .NET‑tel programozottan hozhat létre ugyanolyan matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N‑áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában az **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint Insert lapfül, a Képlet parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektum segítségével építi fel ezt a matematikai szöveget:

- Egy matematikai alak, amelyet az [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) hoz létre, az a alak, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) a matematikai tartalmat tárolja az alak szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) folyékony metódusait használja, hogy a kód rövid és olvasható legyen.

MathML exportálási esetekhez lásd a [Exportálja a matematikai egyenleteket a prezentációkból .NET‑ben](/slides/hu/net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa az [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) használatával hoz létre egy matematikai alakot, és hozzáadja a Pitagorasz‑tételt:

![c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) olyan alakot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáférhet az első [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), lekéri a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), és hozzáadhat matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) metódust tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Döntött tört, amely egyet oszt x‑szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) metódust négyzetgyök, köbgyök vagy más gyök létrehozásához. Az aktuális elem lesz az alap, az argumentum pedig a gyök fokszáma.

![n‑edik gyök kifejezés, ahol x a gyökjel alatt](powerpoint-math-equations_5.png)

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

## **Függvények és határok hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) vagy a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határok esetén helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) elembe, vagy használja a [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![x határa, ahogy x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet az aktuális elemmé, és hívja a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)‑t a argumentummal:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja a [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/)‑t összegeknél, unióknál, metszetnél és más nagy operátoroknál. Integrálokhoz a [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)‑t. Mindkét módszerrel megadhatja az alsó és felső határokat.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-` és `=` általában [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)‑ként kerülnek hozzáadásra és egyesítésre a kifejezésben.

Integrálhoz használja a [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)-t:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/)‑t sorok és oszlopok számára. A mátrixok alapértelmezésben nem tartalmaznak zárójeleket, ezért ha zárójelek, szögletes vagy kapcsos zárójelek szükségesek, akkor zárja be a mátrixot.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)‑t, ha igazított egyenletekre vagy függőlegesen egymásra rakott kifejezésekre van szüksége.

![Függőleges matematikai tömb, ahol x y‑felett van](powerpoint-math-equations_11.png)

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

### **Tömb igazítása a környező elemekkel**

Az [IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az igazítást az első sor, a tömb közepe és az utolsó sor esetén.

A következő példa három azonos tömböt hoz létre, mindegyik három soros és a szomszédos elemek `A=` és `=B`. Minden matematikai szöveg Cambria Math betűtípust használ 24 pontban. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg a `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök a PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sorok távolságának beállítása**

A [RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) választja ki a sorok távolság szabályát a tömbön belül. A [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) numerikus értéket ad egy explicit távolság szabálynak, és a preset szabályok figyelmen kívül hagyják.

Pontos távolság esetén az érték pontban van megadva. Arányos távolságnál fél sorokban mérik: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; csak a numerikus érték változtatása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazokkal az egyenletekkel, igazítással és betűbeállításokkal. Az első három presetet használ, az utolsó kettő explicit értékeket mutat.

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

A tömb sorok távolsága különbözik a bekezdés távolságától. A [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és a [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) a tartalmazó bekezdés körül adnak helyet, nem a tömb sorai között. Hasonlóképpen az [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) a teljes matematikai bekezdést vízszintesen helyezi, nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)‑t, ha az argumentum az aktuális elem, és a függvény neve ismert.

![A cos trigonometrikus függvény 2x‑re alkalmazva](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó- és felső index segédfüggvényeit indexek és hatványok számára. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)‑t.

![Nagy Y baloldali alsó index 1‑el és felső index n‑mel](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

Használja az [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/)‑t, hogy egy kifejezést határolók közé helyezzen. Megadhat egy elválasztó karaktert is az olyan határolt kifejezésekhez, amelyek több elemet tartalmaznak.

![Egy határoló kifejezés, amely x, y és z‑t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Határolók mérete és igazítása**

Állítsa a [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/)‑t `true`‑ra, hogy a zárójelek a magas operandus körül növekedjenek, vagy `false`‑ra, hogy megmaradjanak normál méretben. A [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) a két [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) érték közül egyet vehet fel. A `Centered` a zárójeleket a matematikai tengely közepére helyezi, amely az egyenlőségjel közepén halad. A `Match` a zárójeleket a körülvevő tartalomhoz igazítja. Mindkét beállítás csak a határolókra vonatkozik. A benne lévő kifejezés változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a alapvonal fölött tovább nyúlik, mint alatta. Mind a négy egyenlet ugyanazt a zárójelet és betűbeállítást használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek a kitevőt körülvéve nőnek, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`Centered`) az egyenlőségjellel igazodnak, míg a jobboldali (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet a PowerPointban, ahol a határolók növekedése felül engedélyezett, alul letiltott, baloldalon Centered, jobboldalon Match](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Hívja a [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/)‑t egy törtön, hogy a teljes kifejezést keretezze. A visszakapott [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) alapértelmezésben mind a négy oldalt megjeleníti. Használja a [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), és [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/)‑t egyedi oldalak eltávolításához.

A példa hat példányban helyezi el ugyanazt a törtet egy dián. A törlés megjelenítéséhez rejtse el a négy oldalt, és állítsa be a [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/)‑t emelkedő átlóhoz (↗) vagy a [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/)‑t csökkenő átlóhoz (↘). Használhatja a [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) vagy a [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/)‑t is bármilyen látható oldal kombinációval.

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

![Hat szerkeszthető tört a PowerPointban. Felső sor: teljes keret, alsó és bal oldal, emelkedő átló. Alsó sor: csökkenő átló, vízszintes áthúzás, függőleges áthúzás teljes kerettel](border-box-fractions.png)

Ezen a törtön a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás áthalad a számláló és a nevező felett, miközben a környező keret látható marad. Ezek a vonalak az egész kifejezést díszítik. A szokásos szöveg áthúzása a szövegfutam karaktereire vonatkozik. A prezentáció PowerPointban való újbóli megnyitása után is szerkesztheti a számlálót és a nevezőt külön-külön.

## **Kifejezések csoportosítása**

Használja a [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/)‑t, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adjunk határt a csoportosított kifejezések címkézéséhez.

![Az x plus y kifejezés csoportosítva a label alatt lévő tetszőleges szöveggel](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Használjon formázó segédfüggvényeket csak akkor, amikor azok tisztázzák a képletet. Például az [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) egy sávot helyez az elem fölé.

![Matematikai kifejezés ABC felülvonallal](powerpoint-math-equations_14.png)

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

### **Szöveg formázása meglévő egyenletben**

A szöveg formázásához egy meglévő egyenletben bejárja minden matematikai blokk elemtölcsérét. Az [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a szöveget törtökben, indexekben, gyökökben és egyéb beágyazott struktúrákban. Ellenőrizze az aktuális elemet és annak gyermekeit is, hogy a kezdő elemet is belefoglalja, ha az [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)‑ként van.

Ez a példa feltételezi, hogy egy prezentáció tartalmaz egy egyenletet, például `z = xᵢ / ∛y`, egy törtet alulindexszel a számlálóban és gyököt a nevezőben. A blokk felső szintű elemeinek csak feldolgozása kihagyja a szöveget a törtben. A példa megtalálja a matematikai részeket a diák szövegdobozaiban, eléri blokkjukat a [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/)‑n keresztül, és a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)‑t 28 pontra állítja minden szövegelem [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/)‑tulajdonságán keresztül.

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

A mentett prezentáció minden szinten tartalmazza a frissített szövegformázást a feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyors referencia**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Create fractions | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Add superscript or subscript | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Add functions | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Add radicals | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Add limits | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Add left-side scripts | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Add summations and integrals | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Add delimiters | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Add bars and borders | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Group terms | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakot, amely [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)‑t tartalmaz, szerezze meg a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)-t, és frissítse a bekezdés matematikai blokkjait.

**Az egyenletek szerkeszthető PowerPoint matematikaként mentődnek?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikaként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)-ból, és hívja meg a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/)‑t a közvetlen exportáláshoz. Teljes példaért lásd az [Exportálja a matematikai egyenleteket a prezentációkból .NET‑ben](/slides/hu/net/exporting-math-equations/#export-math-equations-to-latex) című oldalt.