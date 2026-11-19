---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz JavaScriptben
linktitle: PowerPoint Matematikai Egyenletek
type: docs
weight: 80
url: /hu/nodejs-java/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai jel
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai jel hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Node.js via Java segítségével, OMML támogatással, formázási vezérlőkkel és világos JavaScript kódpéldákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket Office Math Markup Language (OMML) formátumban tárol. Az Aspose.Slides for Node.js via Java segítségével programozottan létrehozhatja ugyanazt a matematikai tartalmat: törtöket, gyököket, függvényeket, határokat, N‑áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában a **Beszúrás > Egyenlet** menüből adnak hozzá egyenleteket:

![PowerPoint Beszúrás lapja, ahol az Egyenlet parancs ki van választva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint diát tartalmazó szerkeszthető matematikai egyenlet](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül hozza létre ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) segítségével hozunk létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) folyékony metódusait használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Matematikai egyenletek exportálása prezentációkból Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz‑tételt:

![Az egyenlet: c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Érje el az első [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), hívja a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), és adjon hozzá matematikai blokkokat vagy elemeket.
{{% /alert %}}

### **Matematikai blokkok egyesítése**

Ha egy egyenlet részeit önállóan [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objektumokként építik, a [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) használatával egyesítheti őket. A példa a bal blokkban `c² =`, a jobb blokkban `a² + b²` kifejezést építi fel. A [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) szerkeszthető matematikai felső indexeket hoz létre mindhárom hatványhoz.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const mathParagraph = mathPortion.getMathParagraph();

    const leftBlock = new slides.MathBlock();
    leftBlock.add(new slides.MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new slides.MathematicalText("="));

    const rightBlock = new slides.MathBlock();
    rightBlock.add(new slides.MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new slides.MathematicalText("+"));
    rightBlock.add(new slides.MathematicalText("b").setSuperscript("2"));

    const combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) visszaadja a `leftBlock`‑ot magát, amely most már sorrendben tartalmazza mindkét részt, és a `rightBlock`‑ot üresen hagyja. A kombinált blokkot csak egyszer adja hozzá a [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)‑hez. A `equation.pptx` újranyitása után a bekezdés egy blokkot tartalmaz, amely a `c² = a² + b²` kifejezést képviseli, mindhárom hatvány matematikai felső indexként megmarad.

A [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) `leftBlock.add(rightBlock)`‑ként való hívása helyette megpróbálja egy blokkot közvetlenül egy másikba ágyazni, és `InvalidOperationException`‑t dob.

## **Törtek hozzáadása**

A [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) használatával hozhat létre egy törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Egy ferde matematikai tört, amelyben egyet osztjuk x‑szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) értéket:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) segítségével hozhat létre négyzetgyököt, köbgyököt vagy más gyököt. A jelenlegi elem lesz az alap, az argumentum pedig a gyök fokát adja meg.

![Egy n‑edik gyök radikális kifejezés, ahol x a gyökjel alatt található](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokának megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet egy explicit 2‑t, vagy használhatja a szokásos √x jelölést. A [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) metódusa szabályozza, hogy melyik forma jelenjen meg. Mindkét forma megtartja a 2‑es fokot és az x‑et a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, a bal oldalon a fok látható, a jobb oldalon elrejtett](square-root-degree.png)

A példa ugyanazt a négyzetgyököt kétszer menti. A `visible-degree.pptx`‑ben a 2 látható. A `hidden-degree.pptx`‑ben rejtett.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Függvények és határok hozzáadása**

Használja a [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy a [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) metódusokat olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határokhoz helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/)‑ba, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)‑t.

![Az x határa, miközben x a végtelenhez tart](powerpoint-math-equations_8.png)

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

Egy egyedi függvénynév esetén tegye a függvénynevet a jelenlegi elemmé, és hívja a [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function)‑t a argumentummal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary)‑t összegekre, uniókra, metszetekre és egyéb nagy operátorokra. A [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)‑t integrálokhoz. Mindkét metódus lehetővé teszi az alsó és felső határ beállítását.

![Összeg alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=` általában [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)‑ként kerülnek hozzáadásra, és az kifejezésbe illesztésre.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)‑t:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/)‑t sorok és oszlopok kezelésére. A mátrixok alapból nem tartalmaznak zárójeleket, ezért zárójelek, szögletes vagy kapcsos zárójelek esetén manuálisan kell körülvenni a mátrixot.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

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

### **Létező mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx`‑ben lévő koefficiens mátrixszal kezdődik, amelyet az előző példa mentett. A következő feladathoz tartsa meg az első egyenletet, cserélje le a másodikat két új egyenletre, és módosítsa a változók halmazát. Nyissa meg a meglévő mátrixot a [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) segítségével, hogy megőrizze a még alkalmazható koefficienseket.

![Eredeti kétsoros koefficiens mátrix, 1, x és egy üres cella az első sorban, valamint x, 2, y a második sorban](matrix-before-edit.png)

A sor és oszlop indexek nullától indulnak, és az adott híváskor létező mátrixra vonatkoznak. Egy sor beszúrása az 1‑es index előtt áthelyezi az eredeti második sort a 2‑es indexre. Az 2‑es index után történő beszúrás egy új sort ad hozzá. A 2‑es sor törlése eltávolítja az eredeti második egyenletet, és az új sor feljebb kerül. Az oszlopok is hasonlóan eltolódnak.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Új cellák kezdetben null értékűek. Először állítsa be a nem nulla együtthatókat.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) balra igazítja az első oszlopot. A [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) három egymást követő oszlopot jobbra igazít a 1‑es indextől kezdve. A `updated-matrix.pptx`‑ben a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiensei `1` és `x` most az első és a harmadik oszlopban jelennek meg.

![Frissített háromsoros mátrix, sorok: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray)‑t, ha igazított egyenletekre vagy függőleges kifejezéshalmazra van szüksége.

![Függőleges matematikai tömb, x fölött y](powerpoint-math-equations_11.png)

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

### **Tömb igazítása környező elemekkel**

A [setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa az első sor, a tömb középső része és az utolsó sor igazítását mutatja be.

A következő példa három azonos tömböt hoz létre, mindegyik három soros, és a szomszédos elemek `A=` és `=B`. Minden matematikai szöveg Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A következő összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` helyzetét minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sorok közti távolság beállítása**

A [setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) választja ki a sorok közti távolság szabályát a tömbön belül. A [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) numerikus értéket ad egy explicit távolság szabálynak, és a preset szabályok figyelmen kívül hagyják.

Az pontos távolság pontban mérendő. Az arányos távolság fél-sorokban van megadva: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot meg kell adni explicit érték esetén; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal az egyenlettel, igazítással és betűtípusbeállítással. Az első három preset‑eket használ, az utolsó kettő explicit értékeket mutat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

A tömb sorok közti távolsága különbözik a bekezdés távolságától. A [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) és a [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) a környező bekezdés körül adnak szóközt, nem a tömb sorok között. Hasonlóképpen a [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) a teljes matematikai bekezdést helyezi el vízszintesen; nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja a [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction)‑t, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![A trigonometriás cos függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

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

## **Alsó és felső indexek hozzáadása**

Használja az alsó‑ és felső‑index segédfüggvényeket indexek és hatványok esetén. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)‑t.

![Egy nagy Y betű bal oldali alsó index 1‑gyel és felső index n‑nel](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

Használja a [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose)‑t, hogy egy kifejezést határolókba helyezzen. Több elemet tartalmazó határoló kifejezéseknél beállíthat egy elválasztó karaktert is.

![Határoló kifejezés, amely x, y és z elemeket tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Határolók mérete és igazítása**

Adjon `true`‑t a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)‑nek, hogy a zárójelek egy magas operandus körül növekedjenek, vagy `false`‑t adjon, hogy a normál méretüket megőrizzék. Használja a [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape)‑t a két [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) érték egyikkel. A `Centered` középre helyezi a zárójeleket a matematikai tengelyen, amely az egyenlőségjel közepén halad. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak a határolókra vonatkozik. A kifejezés maga változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a bázisvonal fölött magasabban nyúlik, mint alatta. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípusbeállításokat használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatását. A felső sorban a zárójelek a kitevő körül nőnek, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjellel igazodnak, míg a jobb oldali (`Match`) a kifejezés fölé helyezkednek.

![Négy egyenlet PowerPointban, a zárójel növekedés be‑ és kikapcsolva, a bal oldalon `Centered`, a jobb oldalon `Match`](delimiter-sizing.png)

## **Szegélydoboz hozzáadása**

Hívja a [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox)‑t egy törtön, hogy a teljes kifejezést keretbe foglalja. A visszaadott [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) alapértelmezés szerint a négy oldalát megjeleníti. A [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) és [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) segítségével eltávolíthat egyes oldalakat.

A példa hat példányt helyez el ugyanabból a törtből egy dián. A törlés megjelenítéséhez rejtse el a négy oldalt, és adjon `true`‑t a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight)‑nek egy emelkedő átló (↗) vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)‑nek egy süllyedő átló (↘) létrehozásához. A [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) is használható bármely kombinációval a látható oldalakon.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes szegély, alsó és bal oldal, emelkedő átló. Alsó sor: süllyedő átló, vízszintes vonal, függőleges vonal teljes szegéllyel](border-box-fractions.png)

Ezen tört esetén a vízszintes vonal átfedi a törtvonalat. A függőleges vonal áthalad a számláló és a nevező felett, miközben a környező szegély látható marad. Ezek a vonalak a teljes kifejezést díszítik. A szokásos szövegsztrikthe (áthúzás) karakterekre vonatkozik. A prezentáció PowerPointban történő újbóli megnyitása után a számlálót és a nevezőt továbbra is külön‑külön szerkesztheti.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

Tegye egy kifejezést a [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/)‑ba, hogy függetlenül vezérelje annak láthatóságát és az egyenlethez hozzájáruló helyet. A [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) metódusai a következőket szabályozzák:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false`‑t adva elrejti a kifejezést. Méretei továbbra is részt vesznek az elrendezésben, hacsak az alábbi metódusok nem kapnak `true`‑t. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | A kifejezés vízszintes szélességét nullának tekinti, így a szomszédos elemek közelebb kerülhetnek egymáshoz. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | A felmenet (a bázisvonal feletti magasság) nullának tekinthető, ez csökkentheti a szomszédos elemek fölötti helyet. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | A lesüllyedés (a bázisvonal alatti mélység) nullának tekinthető, ez a törtvonal vagy egyéb tartalom alatti helyet közelebb hozhatja a szomszédokhoz. |

A bázisvonal a referencia vonal, amelyen a szokásos matematikai betűk ülnek. A tartalom elrejtése nem távolítja el a méreteket, a méret nullává tétele sem törli a kifejezést. A mögöttes kifejezés a [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase)‑on keresztül továbbra is elérhető. A [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) `true`‑ra állítása visszaállítja a láthatóságot; a méretbeállítások változatlanok maradnak.

Az alábbi példa öt egymás mellett elhelyezett változatot hoz létre: egy látható tört, egy elrejtett tört, amely helyet tart, és három elrejtett tört, amelynél egy dimenzió nullaként van kezelve. Minden változat ugyanazt a környező kifejezést és a Cambria Math 24 pont betűtípust használja. Az összes egyenletforma ugyanabban a felső pozícióban helyezkedik el, amit a szürke segédvonal jelöl. A fantom elhelyezése egy külső tört számlálójában könnyebbé teszi a függőleges elrendezés változásainak megfigyelését.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Öt egyenlet PowerPointban, összehasonlítva egy látható törtet, egy helyet tartó elrejtett törtet, és a ZeroWidth, ZeroAsc vagy ZeroDesc engedélyezett elrejtett törteket](math-phantom.png)

## **Csoportosítási elemek**

Használja a [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group)‑ot, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adj hozzá egy határt a csoportosított tagok címkézéséhez.

![Az x + y kifejezés, amely alatt „bármilyen szöveg” felirat szerepel](powerpoint-math-equations_15.png)

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

Csak ott használjon formázó segédfüggvényeket, ahol az egyenlet átláthatóságát növelik. Például a [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) egy sávot helyez egy matematikai elem fölé.

![ABC matematikai kifejezés, amelynek felett egy overbar van](powerpoint-math-equations_14.png)

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

### **Szöveg formázása egy meglévő egyenletben**

A teljes meglévő egyenlet szövegének formázásához járja be minden matematikai blokk elemtree‑jét. A [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a törtek, indexek, gyökök és egyéb beágyazott struktúrák szövegét. Ellenőrizze a jelenlegi elemet, valamint a gyermekeket, hogy a kiinduló elem is bekerüljön, ha az [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) típusú.

Ez a példa feltételezi, hogy a `input.pptx` tartalmaz egy olyan egyenletet, mint `z = xᵢ / ∛y`, ahol a tört számlálójában alsó index, a nevezőben pedig radikál van. Ha csak a blokk felső szintű elemeit dolgozná fel, a törtben lévő szöveget elmulasztaná. A példa a diák szövegdobozában lévő matematikai részeket keresi, blokkjait a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)‑on keresztül érheti el, és a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight)‑et használja, hogy minden szövegelem [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) metódusával 28 pont betűméretet állítson be.

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

A mentett prezentáció frissített szövegformázást tartalmaz minden szintjén az egyenleteknek, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyors referencia**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Combine elements | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Create fractions | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add superscript or subscript | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add functions | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add radicals | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add limits | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add left‑side scripts | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Add equation arrays | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Group terms | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **GYIK**

**Szerkeszthetem a meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely tartalmaz egy [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)-t, hívja a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)-t, és frissítse a matematikai blokkokat abban a bekezdésben.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja ki.

**Exportálhatom az egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)-ját a [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)-ról, és hívja a [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex)-et a közvetlen exportáláshoz. Teljes példa: lásd a [Matematikai egyenletek exportálása prezentációkból Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).