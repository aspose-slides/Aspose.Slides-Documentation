---
title: Matematikai egyenletek hozzáadása PowerPoint-prezentációkhoz .NET-ben
linktitle: PowerPoint Matematikai Egyenletek
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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével, OMML támogatással, formázási vezérlőkkel és világos C# kódrészletekkel."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for .NET használatával programozott módon hozhat létre ugyanilyen matematikai tartalmakat: törtek, gyökök, függvények, határok, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában az **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint Insert lap az Equation parancs kiválasztásával](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) tartalmaz egy vagy több [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) objektumot.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) folyékony módszereit használja, hogy a kód rövid és olvasható legyen.

MathML export esetén tekintse meg a [Matematikai egyenletek exportálása bemutatókból .NET‑ben](/slides/hu/net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) használja egy matematikai alakzat létrehozásához, és hozzáadja a Pitagorasz-tételt:

![Az egyenlet: c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Megjegyzés" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Elérhető az első [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), megkapja annak [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), és hozzáadhat matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) metódust törtek létrehozásához. A törttípust a [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Egy ferde törttel ábrázolt 1 osztva x-szel](powerpoint-math-equations_4.png)

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

Halmozott (stacked) tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) metódust a négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. Az aktuális elem lesz az alap, az argumentum pedig a gyök fokszáma.

![Egy n-dik gyök kifejezés, ahol x a gyökjel alatt](powerpoint-math-equations_5.png)

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

Használja a [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) vagy a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határok esetén helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) elembe vagy használja a [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Az x határa, amikor x a végtelenhez tart](powerpoint-math-equations_8.png)

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

Az egyedi függvénynévhez tegye a függvény nevét az aktuális elemként, és hívja a [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)‑t a argumentummal:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-áris operátorok és integrálok hozzáadása**

Használja a [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) metódust összegekkel, uniókkal, metszetekkel és egyéb nagy operátorokhoz. Az [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) metódust integrálokhoz. Mindkét módszer lehetővé teszi az alsó és felső határ beállítását.

![Egy összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorokhoz használhatók opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-`, és `=` általában [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) formájában kerülnek a kifejezésbe.

Integrálok esetén használja a [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)‑t:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) metódust sorok és oszlopok létrehozásához. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért ha szükséges, zárja be a mátrixot zárójelek, szögletes vagy kapcsos zárójelekkel.

![Egy két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

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

Használja a [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) metódust, ha igazított egyenletekre vagy függőleges kifejezéstömbre van szüksége.

![Egy függőleges matematikai tömb, x a y felett](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

Használja a [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) metódust, ha az argumentum az aktuális elem, és a függvény neve ismert.

![A trigonometrikus cos függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

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

Használja az alsó- és felső index segédeket indexekhez és hatványokhoz. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)‑t.

![Egy nagy Y baloldali alsóindexszel 1 és felsőindexszel n](powerpoint-math-equations_9.png)

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

## **Elválasztó jelek hozzáadása**

Használja a [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) metódust egy kifejezés elválasztójelek közé helyezéséhez. Beállíthat elválasztó karaktert azoknál az elválasztójeles kifejezéseknél, amelyek több elemet tartalmaznak.

![Egy elválasztó jelekkel ellátott kifejezés, amely x‑et, y‑t és z‑t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Elválasztók mérete és igazítása**

A [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) értékét `true`‑ra állítva a zárójelek növekednek egy magas operandus körül, `false`‑ra állítva a normál méretben maradnak. A [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) két [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) érték egyikét veheti fel. A `Centered` középre helyezi a zárójeleket a matematikai tengelyen, amely az egyenlőségjel közepén halad. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak az elválasztókat érinti. A kifejezés belseje változatlan marad.

A példa egy törtet helyez el az `x` kitevőjébe, így a kifejezés a vonal felett magasabbra nyúlik, mint alatta. A négy egyenlet ugyanazokat a zárójeleket és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek nőnek, hogy körülvegyék a kitevőt, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazodnak, míg a jobboldali (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, ahol a bal oldali zárójelek növekednek, a jobb oldali nem, a bal oldali `Centered`, a jobb oldali `Match`](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Használja a [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) metódust egy törtön, hogy keretezze az egész kifejezést. A visszaadott [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint a négy oldalt megjeleníti. A [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), és a [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) segítségével eltávolíthatók az egyes oldalak.

A példa hat példányt helyez el ugyanabból a törtből egy dián. Az áthúzás megjelenítéséhez rejtse el a négy oldalt, és állítsa be a [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/)‑t egy emelkedő átló (↗) vagy a [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/)‑t egy csökkenő átló (↘) esetén. Használhatja a [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) vagy a [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) metódusokat is, bármely kombinációban a látható oldalakon.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alsó és bal oldalak, emelkedő átló. Alsó sor: csökkenő átló, vízszintes áthúzás, függőleges áthúzás teljes kerettel](border-box-fractions.png)

Ezen a törtön a vízszintes áthúzás átfedi a törttest. A függőleges áthúzás keresztezi a számlálót és a nevezőt, miközben a környező keret látható marad. Ezek a vonalak az egész kifejezést díszítik. A normál szöveg áthúzása a szövegfutamon belüli karakterekre vonatkozik. A prezentáció PowerPointban való újbóli megnyitása után továbbra is szerkeszthető a számláló és a nevező külön-külön.

## **Kifejezések csoportosítása**

Használja a [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) metódust, hogy egy csoportosító karaktert helyezzen a kifejezés fölé vagy alá. Adj hozzá határt a csoportosított kifejezések címkézéséhez.

![A kifejezés x plus y csoportosítva, alatta egy tetszőleges szöveg címkével](powerpoint-math-equations_15.png)

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

Használja a formázó segédeket csak ott, ahol a képletet érthetőbbé teszik. Például a [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez az elem fölé.

![Egy ABC matematikai kifejezés felülvonalazva](powerpoint-math-equations_14.png)

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

### **Szöveg formázása egy meglévő egyenletben**

Az egész meglévő egyenlet szövegének formázásához bejárja minden matematikai blokk elemmagját. Az [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a szöveget a törtek, indexek, gyökök és egyéb beágyazott struktúrák belsejében. Ellenőrizze az aktuális elemet és annak gyermekeit is, hogy a kezdőelemet is belefoglalja, ha az [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) .

Ez a példa azt feltételezi, hogy a prezentáció egy olyan egyenletet tartalmaz, mint a `z = xᵢ / ∛y`, ahol a tört számlálójában alsóindex, nevezőjében pedig gyök van. Ha csak a blokk felső szintű elemeit dolgozzuk fel, a tört belső szövegét kihagyjuk. A példa megtalálja a matematikai részeket a diák szövegdobozaiban, eléri azok blokkjait az [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) segítségével, és minden szövegelemen a [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságon keresztül a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) értékét 28 pontra állítja.

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

A mentett prezentáció minden szintjén tartalmazza a frissített szövegformázást minden feldolgozott egyenletben, miközben megőrzi a szöveg tartalmát és a matematikai struktúrát.

## **Gyors hivatkozás**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Felső- vagy alsóindex hozzáadása | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Függvények hozzáadása | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Gyökök hozzáadása | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Baloldali indexek hozzáadása | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Összegek és integrálok hozzáadása | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Elválasztók hozzáadása | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és keretek hozzáadása | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Kifejezések csoportosítása | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) tartalmaz, szerezze meg annak [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office math tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) elemét a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)‑ból, és hívja a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/)‑t a közvetlen exportáláshoz. Egy komplett példáért tekintse meg a [Matematikai egyenletek exportálása bemutatókból .NET‑ben](/slides/hu/net/exporting-math-equations/#export-math-equations-to-latex).