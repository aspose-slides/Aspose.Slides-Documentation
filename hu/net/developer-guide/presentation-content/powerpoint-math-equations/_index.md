---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz .NET-ben
linktitle: PowerPoint matematika egyenletek
type: docs
weight: 80
url: /hu/net/powerpoint-math-equations/
keywords:
- matematika egyenlet
- matematika szimbólum
- matematika képlet
- matematika szöveg
- matematika egyenlet hozzáadása
- matematika szimbólum hozzáadása
- matematika képlet hozzáadása
- matematika szöveg hozzáadása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Matematika egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével, OMML támogatással, formázási vezérlésekkel és áttekinthető C# kódrészletekkel."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for .NET segítségével programozottan hozhat létre hasonló matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N-árnyú operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában az **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Insert lapfül a Képlet parancs kiválasztva](powerpoint-math-equations_1.png)

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) a matematikai tartalmat tárolja az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi példák a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) folyékony metódusait használják a kód rövid és olvasható tartásához.

Matematikai egyenletek exportálása prezentációkból .NET-ben: [Export Math Equations from Presentations in .NET](/slides/hu/net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz-tételt:

![c négyzet egyenlő a négyzet + b négyzet](powerpoint-math-equations_3.png)

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
A [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) létrehoz egy alakzatot, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), lekéri annak [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), és hozzáadja a matematikai blokkokat vagy elemeket.{{% /alert %}}

## **Törtek hozzáadása**

Használja a [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) metódust tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Ferdeségű tört, 1 osztva x-szel](powerpoint-math-equations_4.png)

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

Használja a [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. Az aktuális elem az alap lesz, az argumentum pedig a gyök fokát adja.

![n-dik gyök kifejezés x-szel a gyökjel alatt](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokának megjelenítése vagy elrejtése**

Az [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) tulajdonsága a [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) osztályban szabályozza, hogy melyik formát jelenítse meg. Mindkét forma megtartja a 2 fokot és az x radikandot a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, ahol a HideDegree bal oldalon false, jobb oldalon true](square-root-degree.png)

Az példa ugyanazt a négyzetgyököt kétszer menti. A `visible-degree.pptx` fájlban a 2 látható. A `hidden-degree.pptx` fájlban pedig rejtett.

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

## **Függvények és határok hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) vagy a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) metódusokat olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határok esetén helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) belé, vagy használja a [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvény neve esetén tegye a függvény nevét az aktuális elemként, és hívja a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)‑t a megfelelő argumentummal:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-árnyú operátorok és integrálok hozzáadása**

Használja a [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) metódust összegekre, uniókra, interszekciókra és más nagy operátorokra. Használja az [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) metódust integrálokhoz. Mindkét módszerrel beállíthatja az alsó és felső határokat.

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

N-ary operátorok nagy operátorokhoz használhatók opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=` általában a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) segítségével kerülnek a kifejezésbe.

Integrálhoz használja a [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)‑t:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) metódust sorok és oszlopok kezeléséhez. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért a mátrixot zárójelek, szögletes vagy kapcsos zárójelek közé kell helyezni, ha szükséges.

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

Használja a [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) metódust, ha rendezett egyenletekre vagy függőleges kifejezésveremre van szükség.

![Függőleges matematikai tömb, x felül, y alatt](powerpoint-math-equations_11.png)

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

Az [IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa a három igazítást mutatja: első sor, a tömb közepe, és az utolsó sor.

Az alábbi példa három azonos tömböt hoz létre, mindegyik három sorból áll, és a szomszédos elemek `A=` és `=B`. Minden matematikai szöveg Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

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

A következő összehasonlítás mutatja a mentett prezentációt PowerPointban. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos környező elemekkel](equation-array-alignment.png)

### **Sor távolság beállítása**

Az [RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) kiválasztja a sorok távolság szabályát a tömbön belül. A [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) numerikus értéket ad meg egy explicit szabályhoz, és a beállított szabályok figyelmen kívül hagyják.

A pontos távolság esetén az érték pontban van megadva. Arányos távolság esetén fél sorban mérik: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; a numerikus érték önmagában nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazokkal az egyenletekkel, igazítással és betűtípus beállításokkal. Az első három előre definiált beállítást használ; az utolsó kettő explicit értékeket mutat.

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

Az tömb sor távolság külön van a bekezdés távolságtól. A [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) a körülvevő bekezdés körül ad távolságot, nem a tömb sorok között; hasonlóan az [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) a teljes matematikai bekezdést helyezi meg vízszintesen, nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) metódust, ha az argumentum az aktuális elem, és a függvény neve ismert.

![A cos trigonometrikus függvény 2x-re alkalmazva](powerpoint-math-equations_6.png)

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

Használja a felső és alsó index segédmetódusokat indexekhez és hatványokhoz. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)‑t.

![Nagy Y bal oldali alsó indexe 1 és felső indexe n](powerpoint-math-equations_9.png)

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

Használja a [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/)‑t, hogy egy kifejezést határolók közé helyezzen. Több elemet tartalmazó határoló kifejezéseknél megadhat egy elválasztó karaktert is.

![Határoló kifejezés, amely x, y és z-t tartalmaz, függőleges sávokkal elválasztva](powerpoint-math-equations_13.png)

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

Állítsa a [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/)‑t `true`‑ra, hogy a zárójelek egy magas operandus körül növekedjenek, vagy `false`‑ra, hogy a normál méretet megtartsák. A [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) a két [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) érték egyikét veszi fel. A `Centered` a zárójeleket a matematikai tengely közepére helyezi, amely a egyenlőség jel középvonalán halad. A `Match` a zárójeleket a körülöttük lévő tartalomhoz igazítja. Mindkét beállítás csak a határolókra hat, a kifejezés belseje változatlan marad.

A példa egy törtet helyez a `x` kitevőjébe, így a kifejezés a vonal felett magasabban nyúlik, mint alatta. A négy egyenlet ugyanazt a zárójelet és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megfigyeléséhez. A felső sorban a zárójelek nőnek, hogy befoglalják a kitevőt, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőség jelhez igazodnak, míg a jobb oldali (`Match`) feljebb helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, ahol a határolók növekedése be van kapcsolva felül, letiltva alul, a bal oldalon `Centered`, a jobb oldalon `Match`](delimiter-sizing.png)

## **Szegély doboz hozzáadása**

A [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/)‑t egy törtre hívva keretezi a teljes kifejezést. A visszaadott [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. Az egyes oldalakat a [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) és [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) segítségével távolíthatja el.

A példa egy dián hat másolatot helyez el ugyanabból a törtből. A törlés megjelenítéséhez elrejti a négy oldalt, és a [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/)‑t állítja be egy emelkedő átló (↗) vagy a [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/)‑t egy süllyedő átló (↘) használatához. Használhatja a [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) vagy a [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/)‑t is, bármely látható oldalkombinációval.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes szegély, alsó és bal oldal, emelkedő átló. Alsó sor: süllyedő átló, vízszintes átló, függőleges átló teljes szegéllyel](border-box-fractions.png)

Ezen tört esetén a vízszintes átló átfedi a tört vonalát. A függőleges átló átszeli a számlálót és a nevezőt, miközben a környező szegély látható marad. Ezek a vonalak az egész kifejezést díszítik. Az egyszerű szöveg áthúzása csak a szövegfutam karaktereire vonatkozik. A prezentáció PowerPointban való újranyitása után továbbra is szerkeszthető a számláló és a nevező külön-külön.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

A [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/)‑val körülvevő kifejezés segítségével önállóan szabályozhatja a láthatóságát és az egyenlethez járuló helyet. Az [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) tulajdonságai a következőket vezérlik:

| Tulajdonság | Hatás |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Állítsa `false`-ra a kifejezés elrejtéséhez. Méretei továbbra is hozzájárulnak a layouthoz, hacsak a lentiek nem `true`-k. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Kezelje a kifejezés vízszintes szélességét nullának, lehetővé téve a szomszédos elemek közelebb kerülését. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Kezelje a kifejezés felemelkedését (magasság a baseline fölött) nullának. Ez csökkentheti a szomszédos elemek felett fenntartott helyet. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Kezelje a kifejezés süllyedését (mélység a baseline alatt) nullának. Ez egy tört vonalát vagy más tartalmat a kifejezés alatti részekkel közelebb hozhat a szomszédokhoz. |

A baseline a referencia vonal, amelyen a hagyományos matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, és egy dimenzió nullának kezelése nem törli a kifejezést. Az alaptárolt kifejezés továbbra is elérhető a [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/)‑on keresztül. Állítsa a [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/)‑t vissza `true`‑ra a megjelenítéshez; a dimenzióbeállítások változatlanok maradnak.

Az alábbi példa öt egymás melletti variánst hoz létre: egy látható tört, egy rejtett tört, amely helyet foglal, és három rejtett tört, ahol egy dimenzió nullának van beállítva. Minden variáns ugyanazt a környező kifejezést és Cambria Math 24 pontos betűméretet használja. Minden egyenlet alakzat ugyanazon a felső pozíción van, szürke segédvonal jelöli. A fantom elhelyezése egy külső tört számlálójában megkönnyíti a függőleges elrendezési változások láthatóságát.

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

![Öt egyenlet PowerPointban, amely összehasonlítja a látható törtet, a helyet foglaló rejtett törtet, valamint a ZeroWidth, ZeroAsc vagy ZeroDesc engedélyezett rejtett törteket](math-phantom.png)

## **Kifejezések csoportosítása**

Használja a [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/)‑t, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Hozzon létre egy határt, hogy felcímkézze a csoportosított kifejezéseket.

![A kifejezés x plusz y csoportosítva egy tetszőleges szöveget tartalmazó címkével alatta](powerpoint-math-equations_15.png)

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

Használjon formázó segédmetódusokat csak ott, ahol a képlet egyértelműsödik. Például a [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) egy sávot helyez egy matematikai elem fölé.

![Matematikai kifejezés ABC egy fölé írt vonallal](powerpoint-math-equations_14.png)

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

A szöveg formázásához egy meglévő egyenletben járja be minden matematikai blokk elemfáját. Az [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell meghívni, hogy elérje a tört, szkriptek, gyökök és egyéb beágyazott struktúrák szövegét. Ellenőrizze az aktuális elemet és annak gyermekeit is, hogy magát az induló elemet is belevegye, ha az [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) típusú.

A példa azt feltételezi, hogy egy prezentáció tartalmaz egy egyenletet, például `z = xᵢ / ∛y`, ahol a tört számlálója egy alsó indexet, nevezője pedig egy gyököt tartalmaz. Ha csak a blokk felső szintű elemeit dolgozzuk fel, a tört belső szövege kimarad. A példa megtalálja a matematikai részeket a dia szövegdobozokban, eléri a blokkokat az [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/)‑on keresztül, és a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)‑t 28 pontra állítja minden szövegelem [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságán keresztül.

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

A mentett prezentáció minden szinten frissített szövegformázást tartalmaz az egyes feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyorsreferencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Felső vagy alsó index hozzáadása | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Függvények hozzáadása | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Gyökök hozzáadása | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Baloldali szkriptek hozzáadása | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Összegek és integrálok hozzáadása | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Határolók hozzáadása | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalkák és szegélyek hozzáadása | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Kifejezések csoportosítása | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely egy [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)‑t tartalmaz, szerezze be annak [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)‑ját, és frissítse a matematika blokkokat abban a bekezdésben.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office math tartalomként írja ki.

**Exportálhatok egyenleteket LaTeX-be?**

Igen. Szerezze be az egyenlet [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)‑ból, és hívja a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/)‑t a közvetlen exportáláshoz. Teljes példáért tekintse meg a [Export Math Equations from Presentations in .NET](/slides/hu/net/exporting-math-equations/#export-math-equations-to-latex) oldalt.