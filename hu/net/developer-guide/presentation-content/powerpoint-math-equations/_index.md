---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz .NET-ben
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/net/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai szimbólum
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai szimbólum hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével, OMML támogatással, formázási vezérlésekkel és érthető C# kódmintákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for .NET segítségével programozott módon hozhat létre ugyanilyen matematikai tartalmat: törteket, gyököket, függvényeket, határokat, N‑árnyú operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában a **Beszúrás > Egyenlet** menüből adnak hozzá egyenleteket:

![PowerPoint Beszúrás lap az Egyenlet parancs kijelölve](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) a matematikai tartalmat tárolja az alakzat szövegkeretén belül.
- A [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) folyékony módszereit használja, hogy a kód rövid és olvasható legyen.

MathML export esetén lásd a [Exportálja a matematikai egyenleteket a prezentációkból .NET‑ben](/slides/hu/net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) segítségével hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz‑tételt:

![Az egyenlet: c² = a² + b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), lekéri a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), és hozzáadja a matematikai blokkokat vagy elemeket.
{{% /alert %}}

### **Matematikai blokkok kombinálása**

Ha egy egyenlet részei önállóan [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) objektumokként épülnek, a [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) segítségével kombinálhatók. A példa a bal blokkban a `c² =` kifejezést, a jobb blokkban pedig az `a² + b²` kifejezést építi. A [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) szerkeszthető matematikai felső indexeket hoz létre mindhárom hatványhoz.

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

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) a `leftBlock`‑et adja vissza, amely most már sorrendben tartalmazza mindkét részt, míg a `rightBlock` üres marad. A kombinált blokkot csak egyszer kell hozzáadni a [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)-hoz. Az `equation.pptx` újbóli megnyitása után a bekezdés egyetlen blokkot tartalmaz, amely a `c² = a² + b²` egyenletet jelenti, a három hatvány megtartva matematikai felső indexként.

A [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) `leftBlock.Add(rightBlock)` hívása megkísérli egy blokkot közvetlenül egy másikba ágyazni, és `InvalidOperationException`‑t dob.

## **Törtek hozzáadása**

Használja a [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) metódust törtek létrehozásához. A törttípus kiválasztásához használja a [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)‑t.

![Ferde matematikai tört, amely egyet oszt el x‑szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)‑t:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. Az aktuális elem lesz az alap, a paraméter pedig a gyök fokszáma.

![n‑edik gyök, ahol az x a gyökjel alatt áll](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

Egy négyzetgyök megjeleníthet explicit 2‑t vagy a hagyományos √x jelölést használhatja. Az [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) tulajdonsága szabályozza, hogy melyik forma jelenik meg. Mindkét forma megtartja a fokszám 2‑t és az x‑et az editálható egyenletben.

![Ugyanaz a négyzetgyök, bal oldalon HideDegree false, jobb oldalon true](square-root-degree.png)

A példa kétszer menti ugyanazt a négyzetgyököt. A `visible-degree.pptx` fájlban a 2 látható. A `hidden-degree.pptx` esetén rejtve van.

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

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) vagy a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határokhoz helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/)-ba, vagy használja a [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)‑t.

![Az x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egy egyedi függvénynév esetén tegye a függvénynevet az aktuális elemmé, majd hívja a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)‑t a paraméterrel:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N‑árnyú operátorok és integrálok hozzáadása**

Használja az [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/)‑t összegzések, uniók, metszetek és egyéb nagy operátorok létrehozásához. Az integrálokhoz használja az [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)‑t. Mindkét metódus lehetővé teszi alsó és felső határ beállítását.

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

Az N‑árnyú operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, `=` általában a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)‑val kerülnek felvételre és összefűzésre a kifejezésben.

Integrál esetén használja a [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)‑t:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/)‑t sorok és oszlopok definiálásához. A mátrixok alapból nem tartalmaznak zárójeleket, ezért a kifejezést körülveheti zárójelek, szögletes vagy kapcsos zárójelek használatával, ha szükséges.

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra órában a `matrix.pptx` fájlban megtalálható a koefficiensmátrix a korábbi példa szerint. A következő feladatban megtartjuk az első egyenletet, a másodikat két új egyenlettel helyettesítjük, és a változók halmazát módosítjuk. Nyissa meg a meglévő mátrixot a [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) segítségével, hogy megőrizze a még érvényes koefficienseket.

![Eredeti két soros koefficiensmátrix 1, x és egy üres cella az első sorban, valamint x, 2, y a második sorban](matrix-before-edit.png)

A sor- és oszlopt indexek nullától indulnak, és a mátrix aktuális állapotára vonatkoznak minden hívásnál. Sor beszúrása az 1. index előtt áthelyezi az eredeti második sort a 2. indexre. Beszúrás 2. index után új sort ad a végére. A 2. sor törlése eltávolítja az eredeti második egyenletet, és feljebb hozza a beszúrt sort. Az oszlopok ugyanígy tolódnak.

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

// Az új cellák kezdetben null értékűek. Először állítsa be a nem nulla koefficienseket.
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

A [SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) a bal oldali oszlopot balra igazítja. A [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) három egymást követő oszlopot jobbra igazít a 1‑es indextől kezdve. A `updated-matrix.pptx` fájlban a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiensei `1` és `x` most az első és a harmadik oszlopban jelennek meg.

![Frissített három soros mátrix a sorokkal: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet‑tömbök hozzáadása**

Használja a [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)‑t, ha igazított egyenletekre vagy függőleges kifejezés‑veremre van szükség.

![Függőleges matematikai tömb, ahol az x a y fölött áll](powerpoint-math-equations_11.png)

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

### **Tömb igazítása a környező elemekhez**

Az [IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa az első sor, a tömb közepe és az utolsó sor igazítását hasonlítja össze.

A következő példa három azonos tömböt hoz létre, mindegyik három sorral és a szomszédos elemekkel `A=` és `=B`. Minden szöveg Cambria Math betűtípust használ 24 pont méretben. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet‑tömbök a PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sor‑távolság beállítása**

A [RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) választja ki a sorok közti távolság szabályát a tömbön belül. A [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) numerikus értéket ad egy explicit szabálynak, és a preset szabályok figyelmen kívül hagyják.

Az exakktávolság értékét pontban mérik. Az arányos távolságot fél‑sorban mérik: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot be kell állítani explicit érték megadásakor; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal az egyenlettel, igazítással és betűtípussal. Az első három preset, az utolsó kettő explicit értékeket használ.

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

A tömb sor‑távolsága különbözik a bekezdés távolságától. A [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és a [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) a környező bekezdés körül ad helyet, nem a tömb sorai között. Hasonlóképpen az [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) a teljes matematikai bekezdést igazítja vízszintesen; nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)‑t, ha a jelenlegi elem a függvény argumentuma és a függvény neve ismert.

![A trigonometrikus `cos` függvény, amely a `2x`‑re van alkalmazva](powerpoint-math-equations_6.png)

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

## **Alsó és felső indexek hozzáadása**

Használja az alsó‑ és felső‑index segédfüggvényeket indexek és hatványok létrehozásához. Ha az indexeknek a báziselem bal oldalán kell megjelenniük, használja a [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)‑t.

![Nagy `Y` betű baloldali alsó index `1`‑el és felső index `n`‑nel](powerpoint-math-equations_9.png)

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

### **Jobb oldali alsó‑ és felsőindexek igazítása**

Ha a két index ugyanahhoz az alapelemhez tartozik, használja a [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)-t. Az [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) tulajdonság vezérli a horizontális pozíciójukat: a `false` (alapértelmezett) érték a bázis kontúrját követi, míg a `true` a szkripteket egymáshoz igazítja.

Ez a példa két példányban helyezi el ugyanazt a szerkeszthető kifejezést egymás mellett. Mindkettő matematikai dőlt `f` (U+1D453), alsó index `1`, felső index `2`, és Cambria Math 72 pont betűmérettel. A dőlt bázis a különbséget láthatóvá teszi a PowerPointban. Mielőtt futtatná a példát, telepítse a Cambria Math‑ot.

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

![Két szerkeszthető kifejezés a PowerPointban, bal oldalon AlignScripts false, jobb oldalon true](aligned-scripts.png)

Bal oldalon az alsó index balra indul a felső indexnél, követve a bázis kontúrját. Jobb oldalon a két index vízszintesen egymáshoz van igazítva.

## **Határolók hozzáadása**

Használja a [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/)‑t, hogy egy kifejezést határolók közé helyezzen. Több elemet tartalmazó határolók esetén beállíthatja az elválasztó karaktert is.

![Határoló kifejezés, amely `x`, `y` és `z` elemeket függőlegesen elválasztó vonalakkal tartalmaz](powerpoint-math-equations_13.png)

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

Állítsa a [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) értékét `true`‑ra, hogy a zárójelek a magas operandus köré növekedjenek, vagy `false`‑ra, hogy normál méretűek maradjanak. A [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) két [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) értéket vehet fel. A `Centered` a zárójeleket a matematikai tengely közepére helyezi, amely az egyenlőségjel közepén halad. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak a határolókra vonatkozik; a kifejezés magja változatlan marad.

A példa egy törtet helyez az `x` exponensébe, így a kifejezés a bázisvonaltól magasabban húzódik. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat, hogy lássa a növekedés hatását. A felső sorban a zárójelek növekednek, hogy befoglalják az exponenset, és mindkét forma hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazulnak, míg a jobb oldali (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet a PowerPointban, a zárójelek növekedése be‑ és kikapcsolva, a bal oldalon Centered, a jobb oldalon Match](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Hívja a [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/)‑t egy törtön, hogy a teljes kifejezést keretezze. A visszaadott [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. A [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) és a [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) segítségével eltávolíthat egyes oldalakat.

A példa hat példányban helyezi el ugyanazt a törtet egy dián. A törléshez elrejti mind a négy oldalt, és beállítja a [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/)‑t egy emelkedő átlóhoz (↗), vagy a [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/)‑t egy lejjebb származó átlóhoz (↘). Emellett használható a [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) vagy a [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) bármely kombinációjával látható oldalak esetén.

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

![Hat szerkeszthető tört a PowerPointban. Felső sor: teljes keret, alsó és bal oldal, emelkedő átló. Alsó sor: lejjebb származó átló, vízszintes vonal, függőleges vonal teljes kerettel.](border-box-fractions.png)

Ezen tört esetén a vízszintes vonal átfedi a törtvonalat. A függőleges vonal mind a számlálót, mind a nevezőt átszeli, miközben a környező keret látható marad. Ezek a vonalak a teljes kifejezést díszítik. A hagyományos szöveg‑átvágás csak a szövegrészek karaktereire vonatkozik. A prezentáció újbóli megnyitása után a számláló és a nevező továbbra is önállóan szerkeszthető marad.

## **Láthatóság és elrendezés vezérlése fantóm elemekkel**

Tegye a kifejezést egy [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/)‑ba, hogy önállóan szabályozza a láthatóságát és az egyenlethez való térbeli hozzájárulását. Az [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) tulajdonságai a következőket befolyásolják:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | `false` értékre állítva elrejti a kifejezést. Méretei továbbra is részt vesznek az elrendezésben, kivéve ha az alábbi tulajdonságok `true` értéken vannak. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | A kifejezés vízszintes szélességét nullának tekinti, így a szomszédos elemek közelebb kerülhetnek. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | A felmenet (a bázisvonal feletti magasság) nullának tekinti, csökkentve a fenti térközt. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | A lemenet (a bázisvonal alatti mélység) nullának tekinti, így a törtvonal vagy egyéb tartalom a kifejezés alatt közelebb kerül a szomszédokhoz. |

A bázisvonal az a referenciavonal, amelyen a hagyományos matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, a méret nullának tekintése sem törli a kifejezést. A mögöttes kifejezés a [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/)‑on keresztül érhető el. Állítsa a [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/)‑t vissza `true`‑ra a megjelenítéshez; a méretbeállítások változatlanok maradnak.

Az alábbi példa öt egymás mellé helyezett változatot hoz létre: egy látható tört, egy elrejtett tört, amely helyet foglal, és három elrejtett tört, ahol egy dimenzió nullának van tekintve. Minden variáns ugyanazt a környező kifejezést és Cambria Math 24 pont betűtípust használja. Az összes egyenlet alakzat ugyanazon a felső pozíción helyezkedik el, szürke segédvonallal jelölve. A fantóm elhelyezése egy külső tört számlálójában megkönnyíti a függőleges elrendezés változásainak látását.

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

![Öt egyenlet a PowerPointban, összehasonlítva egy látható törtet, egy helyet foglaló elrejtett törtet, valamint ZeroWidth, ZeroAsc vagy ZeroDesc bekapcsolt elrejtett törteket](math-phantom.png)

## **Kifejezések csoportosítása**

Használja a [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/)‑t, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adj hozzá egy határt a csoportosított kifejezések feliratozásához.

![A `x + y` kifejezés csoportosítva az `any text` felirattal alatta](powerpoint-math-equations_15.png)

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

Csak ott használjon formázó segédfüggvényeket, ahol azok tisztábbá teszik a képletet. Például a [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) egy sávot helyez a matematikai elem fölé.

![Az `ABC` matematikai kifejezés egy felső vonallal](powerpoint-math-equations_14.png)

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

A szöveg teljes formázásához egy meglévő egyenletben járja be minden matematikai blokk elemeit. Az [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) csak a közvetlen gyerekeket adja vissza, ezért rekurzívan hívja meg, hogy elérje a törtben, indexekben, gyökökben és más beágyazott struktúrákban lévő szöveget is. Ellenőrizze a jelenlegi elemet és annak gyerekeit, hogy a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) kezdőelemet is belefoglalja.

Ez a példa feltételezi, hogy egy prezentációban egy `z = xᵢ / ∛y` egyenlet van, amelynek törtje alsó indexet tartalmaz a számlálójában és gyököt a nevezőjében. Ha csak a blokk felső‑szintű elemeit dolgozza fel, a törtben lévő szöveget kihagyja. A példa megtalálja a matematikai részeket a dia szövegkeretekben, hozzáfér a blokkokhoz a [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/)‑on keresztül, és a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)‑t 28 pontra állítja minden szövegelem [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságán keresztül.

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

A mentett prezentáció frissített szövegformázást tartalmaz minden szinten a feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

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

## **GYIK**

**Can I edit an existing PowerPoint equation?**

Yes. Open the presentation, find the shape that contains a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), get its [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), and update the math blocks in that paragraph.

**Are equations saved as editable PowerPoint math?**

Yes. When you save to PPTX, Aspose.Slides writes the equation as editable Office math content.

**Can I export equations to LaTeX?**

Yes. Get the equation's [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) from its [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), and call [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) to export it directly. For a complete example, see [Export Math Equations from Presentations in .NET](/slides/hu/net/exporting-math-equations/#export-math-equations-to-latex).