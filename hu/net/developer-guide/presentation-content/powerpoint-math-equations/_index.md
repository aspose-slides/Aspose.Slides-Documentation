---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz .NET-ben
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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével, OMML támogatással, formázási vezérlőkkel és érthető C# kódmintákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for .NET segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N-árnyú operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában az **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Insert fül, ahol a Equation parancs van kijelölve](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektum segítségével építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [AddMathShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addmathshape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegtáblájában.
- [MathParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/) folyékony módszereit használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in .NET](/slides/hu/net/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz‑tételt:

![Az egyenlet: c² = a² + b²](powerpoint-math-equations_3.png)

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

`AddMathShape` olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. A első `MathPortion`-hez fér hozzá, lekéri annak `MathParagraph`-ját, és hozzáadja a matematika blokkokat vagy elemeket.

{{% /alert %}}

## **Törtek hozzáadása**

`Divide` használatával hozhat létre törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Egy ferde tört, ahol az 1 osztva x-szel mutatja](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a `MathFractionTypes.Bar`-t:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

`Radical` használatával hozhat létre négyzetgyököt, köbgyököt vagy más gyököt. A jelenlegi elem lesz az alap, az argumentum pedig a kitevő.

![n-edik gyök kifejezés, ahol az x a gyökjel alatt áll](powerpoint-math-equations_5.png)

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

## **Függvények és határok hozzáadása**

`AsArgumentOfFunction` vagy `Function` használatával hozhat létre függvényeket, például `sin(x)`, `log(x)` vagy egyedi függvényneveket. Határokhoz helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathlimit/) elembe, vagy használja a `SetLowerLimit`-et.

![x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet a jelenlegi elemként:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-árnyú operátorok és integrálok hozzáadása**

`Nary` használatával hozhat összeadást, uniót, metszetet és egyéb nagy operátorokat. Az integrálokhoz használja az `Integral`-t. Mindkét metódus lehetővé teszi a felső és alsó határ beállítását.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N-árnyú operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint `+`, `-`, és `=` általában `MathematicalText`-ként vannak hozzáadva és összefűzve a kifejezésbe.

Integrálhoz használja az `Integral`-t:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

A sorok és oszlopok definiálásához használja a [MathMatrix](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathmatrix/) elemet. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért ha szükséges, zárja körül a mátrixot zárójelek, szögletes zárójelek vagy kapcsos zárójelek használatával.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a `ToMathArray`-t, ha igazított egyenletekre vagy függőleges kifejezéscsoportokra van szükség.

![Függőleges matematikai tömb, ahol az x a y felett áll](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

`AsArgumentOfFunction` használata akkor szükséges, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos trigonometrikus függvény alkalmazva 2x-re](powerpoint-math-equations_6.png)

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

## **Alsó- és felsőindexek hozzáadása**

Az indexek és a hatványok hozzáadásához használja az alsó- és felsőindex segédeszközöket. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a `SetSubSuperscriptOnTheLeft`-t.

![Nagy Y betű baloldali al‑indexszel 1 és felsőindexszel n](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

`Enclose` használatával helyezhet kifejezést határolók közé. Több elemet tartalmazó határolók esetén beállíthat elválasztó karaktert is.

![Határoló kifejezés, amely x, y és z elemeket tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

## **Szegélyes keret hozzáadása**

`ToBorderBox` akkor használatos, amikor magát az egyenletet keretbe kell helyezni.

![Keretbe foglalt egyenlet, ahol a a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Tagok csoportosítása**

`Group` használatával helyezhet csoportosító karaktert egy kifejezés fölé vagy alá. Határral címkézheti a csoportosított tagokat.

![Az x + y kifejezés csoportosítva, alatta egy 'any text' felirattal](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

A formázó segédeszközöket csak akkor használja, ha tisztábbá teszik a képletet. Például az `Overbar` egy vonalat helyez a matematikai elem fölé.

![ABC matematikai kifejezés felülvonallal](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek egyesítése | [IMathElement.Join](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.Divide](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/divide/) |
| Felső- vagy alsóindex hozzáadása | [SetSuperscript](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Függvények hozzáadása | [Function](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Gyökök hozzáadása | [IMathElement.Radical](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [SetLowerLimit](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Baloldali indexek hozzáadása | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Összegzések és integrálok hozzáadása | [Nary](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [ToMathArray](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Határolók hozzáadása | [Enclose](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/enclose/) |
| Áthúzások és keretek hozzáadása | [Overbar](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Tagok csoportosítása | [Group](https://reference.aspose.com/slides/hu/net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek egy meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`‑t tartalmaz, szerezze be a `MathParagraph`‑t, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikaként írja.

**Exportálhatom az egyenleteket LaTeX‑be?**

Az Aspose.Slides a matematikai egyenleteket MathML‑be exportálja. Ha LaTeX‑re van szükség, először exportáljon MathML‑be, majd konvertálja a MathML‑t egy olyan eszközzel, amely támogatja a kívánt LaTeX dialektust.