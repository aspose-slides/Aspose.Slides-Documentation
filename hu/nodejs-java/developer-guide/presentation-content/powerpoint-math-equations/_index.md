---
title: Math egyenletek hozzáadása PowerPoint prezentációkhoz JavaScriptben
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Node.js via Java segítségével, OMML támogatással, formázási vezérlésekkel, és érthető JavaScript kódpéldákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Node.js via Java segítségével programozottan hozhatók létre ugyanilyen matematikai tartalmak: törtök, gyökök, függvények, határok, N-ári operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában az **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Beszúrás lap az Egyenlet parancs kijelölve](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint dián szerkeszthető matematikai egyenlet](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) segítségével hozunk létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példában a [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) folyékony metódusait használjuk a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz-tételt:

![c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) létrehoz egy alakzatot, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), meghívja a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), és hozzáadja a matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

A [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) használatával hozhat létre törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Dőlt tört, amelyben 1 osztva x-szel](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A függőleges törthez használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) használatával hozhat létre négyzetgyököt, köbgyököt vagy egyéb gyököt. A jelenlegi elem lesz az alap, az argumentum pedig a kitevő.

![n-edik gyök kifejezés, x a gyökjel alatt](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Függvények és határok hozzáadása**

A [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) használatával definiálhatók olyan függvények, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határokhoz helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) objektumba, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyedi függvénynév esetén tegye a függvény nevet a jelenlegi elemnek, és hívja meg a [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) a argumentummal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-áris operátorok és integrálok hozzáadása**

A [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) használatával összeadásokat, uniókat, metszeteket és egyéb nagy operátorokat hozhat létre. Az [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) integrálokhoz. Mindkét módszerrel beállíthatók az alsó és felső határok.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az N-áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-` és `=` általában [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) segítségével kerülnek hozzáadásra, és összefűzve jelennek meg a kifejezésben.

Integrálhoz használja a [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

A [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) segítségével sorokat és oszlopokat hozhat létre. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért zárja körül a mátrixot, ha zárójeleket, szögletes vagy kapcsos zárójeleket igényel.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), ha igazított egyenletekre vagy függőleges kifejezéscsoportokra van szükség.

![Függőleges matematikai tömb x felett y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trigonometrikus függvények hozzáadása**

Használja a [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A trigonometrikus cos függvény 2x-re alkalmazva](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alsó- és felső indexek hozzáadása**

Az alsó- és felső indexekhez használja a megfelelő segédfüggvényeket. Ha az indexnek az alap bal oldalán kell megjelenni, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Nagy Y baloldali alsó index 1 és felső index n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Elválasztók (delimiterek) hozzáadása**

Használja a [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose), hogy egy kifejezést elválasztók közé helyezzen. Állíthat elválasztó karaktert is olyan kifejezésekhez, amelyek több elemet tartalmaznak.

![Elválasztó kifejezés, amely x, y és z-ét függőleges vonalakkal választja el](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Elválasztók mérete és igazítása**

Adjon `true` értéket a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), hogy a zárójelek egy magas operandus köré nőjenek, vagy `false` értékkel tartsák meg a normál méretüket. Használja a [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) egyik két [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) értékével. A `Centered` a zárójeleket a matematikai tengely közepére (az egyenlőségjel közepére) helyezi. A `Match` a zárójeleket a körülöttük lévő tartalomhoz igazítja. Mindkét beállítás csak a zárójelekre vonatkozik. A belső kifejezés változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a kiinduló vonal fölött magasabb, mint alatta. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípus-beállításokat használja.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek megnőnek, hogy befoglalják a kitevőt, és mindkét alakzatnál hasonlóak. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazodnak, míg a jobb oldali (`Match`) magasabbra helyezkednek a kifejezés körül.

![Négy egyenlet PowerPointban, a bal oldalon a növekedés engedélyezett, a jobb oldalon letiltva, bal oldalon Centered, jobb oldalon Match](delimiter-sizing.png)

## **Körvonalas keret hozzáadása**

Hívja meg a [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) metódust egy törtön, hogy a teljes kifejezést keretbe tegye. A visszakapott [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. Használja a [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), és a [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) metódusokat egyes oldalak eltávolításához.

A példa hat példányban helyezi el ugyanazt a törtet egy dián. A törlés megjelenítéséhez rejtse el mind a négy oldalt, és adjon `true` értéket a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metódusnak a felfelé irányuló átló (↗) vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) a lefelé irányuló átló (↘) létrehozásához. Használhatja a [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metódusokat is bármely látható oldal kombinációjával.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alsó és bal oldal, felfelé irányuló átló. Alsó sor: lefelé irányuló átló, vízszintes áthúzás, függőleges áthúzás teljes kerettel](border-box-fractions.png)

Ezen a törtön a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás átszeli a számlálót és a nevezőt, miközben a környező keret látható marad. Ezek a vonalak a teljes kifejezést díszítik. A normál szöveg áthúzása csak a szövegrész karaktereire vonatkozik. A prezentáció PowerPointban történő újranyitása után is szerkeszthető a számláló és a nevező külön-külön.

## **Tagok csoportosítása**

Használja a [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) metódust, hogy egy csoportosító karaktert helyezzen a kifejezés fölé vagy alá. Adj hozzá egy határt a csoportosított tagok felcímkézéséhez.

![Az x plus y kifejezés csoportosítva, alatta egy tetszőleges szöveg címkével](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Matematikai elemek formázása**

A formázó segédfüggvényeket csak ott használja, ahol a képletet tisztábbá teszik. Például az [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) egy vonalat helyez az elem fölé.

![Matematikai kifejezés ABC egy felülvonallal](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Szöveg formázása meglévő egyenletben**

A meglévő egyenlet szövegének formázásához járja be minden matematikai blokk elemfáját. A [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan hívja meg, hogy elérje a törtek, szkriptek, gyökök és egyéb beágyazott struktúrák szövegét. Ellenőrizze a jelenlegi elemet és annak gyermekeit, hogy a kiinduló elemet is belefoglalja, ha az [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Ez a példa azt feltételezi, hogy az `input.pptx` egy, például `z = xᵢ / ∛y` egyenletet tartalmaz, ahol a tört számlálójában alsó index, a nevezőjében gyök található. Ha csak a blokk felső szintű elemeit dolgozzuk fel, a tört belső szövege kimarad. A példa matematikai részeket keres a diák szövegdobozában, a blokkokat a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) segítségével érheti el, és a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) használatával 28 pont méretű betűt állít be minden szöveg elem [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) metódusán keresztül.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mentett prezentáció minden szintjén tartalmazza a frissített szövegformázást az egyes feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai szerkezetet.

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Elemek egyesítése | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Törtek létrehozása | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Felső- vagy alsó index hozzáadása | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Határok hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Baloldali indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Elválasztók hozzáadása | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **GYIK**

**Szerkeszthetem-e egy meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) tartalmaz, hívja meg a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), és frissítse a bekezdés matematikai blokkjait.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikaként írja.

**Exportálhatom-e az egyenleteket LaTeX-be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) objektumát a [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) segítségével, és hívja meg a [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) metódust a közvetlen exportáláshoz. Egy teljes példáért lásd a [Export Math Equations from Presentations in Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) oldalt.