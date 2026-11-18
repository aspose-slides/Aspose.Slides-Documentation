---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz JavaScriptben
linktitle: PowerPoint Matematikai Egyenletek
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
description: "Matematikai egyenletek beillesztése és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Node.js via Java segítségével, OMML támogatás, formázási vezérlők és áttekinthető JavaScript kódpéldák."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Node.js via Java segítségével programozottan hozhatók létre ugyanolyan matematikai tartalmak: tört, gyök, függvények, határértékek, N‑áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

PowerPointban a felhasználók általában a **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint beszúrási lap az Egyenlet parancs kiválasztásával](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides a matematikai szöveget három fő objektumon keresztül építi fel:

- A **math shape**, amelyet a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objektumot tartalmaz.

A lenti példák többsége a [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) folyékony metódusait használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a pitagorasz tételt:

![Az egyenlet c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Az első [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) elérésével hívja meg a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) metódust, majd adjon hozzá matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) metódust tört létrehozásához. A törttípust a [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Ferde tört, amelyben 1 osztva x‑szel látható](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) metódust négyzetgyök, köbgyök vagy más gyök létrehozásához. A jelenlegi elem lesz az alap, az argumentum pedig a fokszám.

![n‑edik gyök kifejezés, x a gyökjel alatt](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet explicite 2‑t, vagy használhatja a hagyományos √x jelölést. A [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) metódusa vezérli, melyik forma jelenik meg. Mindkét forma megtartja a 2‑es fokszámot és az x‑et a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, bal oldalon a fokszám látható, jobb oldalon rejtett](square-root-degree.png)

A példa ugyanazt a négyzetgyököt kétszer menti. A `visible-degree.pptx` fájlban a 2 látható, a `hidden-degree.pptx` fájlban pedig rejtett.

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

## **Függvények és határértékek hozzáadása**

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy a [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) metódusokat olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határértékekhez tegye a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) objektumba, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) metódust.

![A határérték, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet a jelenlegi elemként, majd hívja meg a [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) metódust az argumentummal:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja az [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) metódust összegzések, uniók, metszetek és egyéb nagy operátorok létrehozásához. Az [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) metódus az integrálokhoz szolgál. Mindkét módszer lehetővé teszi az alsó és felső határ beállítását.

![Összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-` és `=`, általában a [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) segítségével kerülnek be a kifejezésbe.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) metódust:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) osztályt sorok és oszlopok létrehozásához. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért szükség esetén zárójelek, szögletes vagy kapcsos zárójelek közé helyezze őket.

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx` fájlban lévő koefficiensmátrixszal kezdődik, amelyet az előző példa mentett. A következő feladatban tartsa meg az első egyenletet, cserélje le a másodikat két új egyenletre, és módosítsa a változók halmazát. A meglévő mátrixot a [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) segítségével nyissa meg, hogy megőrizze a még érvényes koefficienseket.

![Eredeti kétsoros koefficiensmátrix 1, x és egy üres cella az első sorban, valamint x, 2 és y a második sorban](matrix-before-edit.png)

A sor- és oszlopindexek nullától indulnak, és az aktuális hívás időpontjában lévő mátrixra vonatkoznak. Sor beszúrása az 1‑es index előtt a második sort 2‑re toltja. Sor beszúrása a 2‑es index után egy új sort ad hozzá. A 2‑es sor törlése eltávolítja az eredeti második egyenletet, és feljebb mozgatja a hozzáadott sort. Az oszlopok ugyanígy eltolódnak.

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

    // Az új cellák kezdetben null értékűek. Először állítsa be a nem nulla együtthatókat.
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

A [setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) a első oszlopot balra igazítja. A [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) három egymást követő oszlopot jobbra igazít a 1‑es indextől kezdve. A `updated-matrix.pptx` fájlban a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiensei (`1` és `x`) most az első és a harmadik oszlopban jelennek meg.

![Frissített háromsoros mátrix sorai: 1, 0, x, 0; 12, 1, 0, 0; 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) metódust, ha egymás alá rendezett egyenletekre vagy függőleges kifejezéstömbökra van szüksége.

![Függőleges matematikai tömb, ahol x fent, y lent](powerpoint-math-equations_11.png)

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

### **Tömb igazítása környező elemekhez**

A [setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az első sor, a tömb középső része és az utolsó sor igazítását.

A következő példa három azonos tömböt hoz létre, mindegyik három sorból áll, a szomszédos `A=` és `=B` elemekkel. Az összes matematikai szöveg Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg a `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Soros térköz beállítása**

A [setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) választja ki a sorok közti térköz szabályát a tömbön belül. A [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) numerikus értéket ad meg egy explicit szabályhoz, a preset szabályok ezt figyelmen kívül hagyják.

Pontos térköz esetén az érték pontban van megadva. Arányos térköz esetén fél sorokban van mérve: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; csak a numerikus érték változtatása nem választ szabályt.

Az alábbi példa öt prezentációt ment azonos egyenletekkel, igazítással és betűtípus beállításokkal. Az első három presetet használ, az utolsó kettő explicit értékeket mutat.

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

A tömb sorok közti térköze független a bekezdés térközétől. A [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) és a [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) a tartalmazó bekezdés körül helyez el helyet, nem a tömb sorai között. Hasonlóképpen a [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) a teljes matematikai bekezdést igazítja vízszintesen; nem a tömb függőleges igazítását helyettesíti.

## **Trigonometrikus függvények hozzáadása**

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) metódust, amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos trigonometrikus függvény 2x‑re alkalmazva](powerpoint-math-equations_6.png)

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

Használja az alsó‑ és felsőindex segédfüggvényeket indexek és hatványok létrehozásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) metódust.

![Nagy Y baloldali alsóindex 1‑el és felsőindex n‑nel](powerpoint-math-equations_9.png)

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

Használja az [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) metódust egy kifejezés határolók közé helyezéséhez. Több elemet tartalmazó kifejezéseknél állíthat be elválasztó karaktert is.

![Határoló kifejezés, amely x‑et, y‑t és z‑t függőlegesen elválasztó vonalakkal tartalmazza](powerpoint-math-equations_13.png)

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

### **A határolók méretezése és igazítása**

Adjon `true` értéket a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metódusnak, hogy a zárójelek a magas operandus köré nőjenek, vagy `false`‑t adjon meg a normál méret megtartásához. Használja a [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) metódust a két [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) érték egyikével. A `Centered` a zárójelet a matematikai tengely közepére helyezi, amely az egyenlőségjel közepén áthalad. A `Match` a zárójelet a körülöttük lévő tartalomhoz igazítja. Mindkét beállítás csak a határolókat érinti; a kifejezés belseje változatlan marad.

A példa a `x` kitevőjébe tesz egy törtet, így a kifejezés a vonal fölött nagyobb, mint alatta. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípusbeállításokat használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megfigyeléséhez. A felső sorban a zárójelek nőnek, hogy befoglalják a kitevőt, és mindkét alakzat egyforma. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazodnak, míg a jobboldali (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, a határoló növekedés engedélyezve a felső sorban és letiltva az alsó sorban, bal oldalon Centered, jobb oldalon Match](delimiter-sizing.png)

## **Border Box hozzáadása**

Hívja meg a [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) metódust egy törtön, hogy a teljes kifejezés körül keretet kapjon. A visszaadott [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) alapértelmezés szerint négy oldalát megjeleníti. Használja a [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) és a [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) metódusokat egyes oldalak eltávolításához.

A példa hat példányt helyez el ugyanabból a törtből egy dián. A törlés bemutatásához rejtse el mind a négy oldalt, és adjon `true`‑t a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metódusnak egy felfelé irányuló átló (↗) vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metódusnak egy lefelé irányuló átló (↘) létrehozásához. Használhatja a [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metódusokat is, bármilyen kombinációban látható oldalakkal.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alatti és bal oldali oldalak, felfelé irányuló átló. Alsó sor: lefelé irányuló átló, vízszintes áthúzás, függőleges áthúzás teljes kerettel.](border-box-fractions.png)

Ezen törtön a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás áthalad a számláló és a nevező felett, miközben a környező keret látható marad. Ezek a vonalak az egész kifejezést díszítik. A szokásos szöveges áthúzás csak a szövegfutamban lévő karaktereket érinti. A prezentáció újra megnyitása után továbbra is szerkeszthető a számláló és a nevező külön-külön.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

Kövesse egy kifejezést a [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) objektummal, hogy önállóan szabályozza a láthatóságát és a egyenlethez járuló helyet. A [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) metódusai a következőket ellenőrzik:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | Adjon `false`‑t a kifejezés elrejtéséhez. Mérete még mindig részt vesz az elrendezésben, hacsak az alább felsorolt metódusok nem kapnak `true`‑t. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | A kifejezés vízszintes szélességét nullának tekinti, lehetővé téve a szomszédos elemek közelebb helyezését. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | A felemelkedését (a vonal feletti magasságot) nullának tekinti, csökkentve a szomszédos elemek fölötti helyet. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | A süllyedését (a vonal alatti mélységet) nullának tekinti, így a törtvonal vagy más tartalom a kifejezés alatt közelebb kerül a szomszédokhoz. |

Az alapvonal az a referenciavonal, amelyen a hagyományos matematikai betűk nyugszanak. A tartalom elrejtése nem távolítja el a méreteket, és egy dimenzió nullának tekintése sem törli a kifejezést. Az alapról származó kifejezés a [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) segítségével továbbra is elérhető. Adjon `true`‑t a [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) metódusnak a megjelenítéshez; a dimenzióbeállítások változatlanok maradnak.

Az alábbi példa öt egymás mellett elhelyezett változatot hoz létre: egy látható tört, egy rejtett tört, amely helyet foglal, és három rejtett tört, amelyben egy dimenzió nullára van állítva. Minden változat ugyanazt a környező kifejezést és Cambria Math 24‑pontos betűtípust használja. Az összes egyenlet alakzat ugyanabban a felső pozícióban helyezkedik el, egy szürke útmutató jelzi. A fantom az outer tört számlálójában elhelyezve könnyebben láthatóvá teszi a függőleges elrendezésváltozásokat.

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

![Öt egyenlet PowerPointban, összehasonlítva egy látható törtet, egy helyet foglaló rejtett törtet és ZeroWidth, ZeroAsc vagy ZeroDesc engedélyezett rejtett törteket](math-phantom.png)

## **Csoportosítás**

Használja a [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) metódust, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adjon hozzá limitet a csoportosított tagok címkézéséhez.

![Az x + y kifejezés csoportosítva, alatta a "bármilyen szöveg" címkével](powerpoint-math-equations_15.png)

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

Használjon formázó segédfüggvényeket csak ott, ahol az egyenletet tisztábbá teszik. Például az [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) metódus egy vonalat helyez a matematikai elem fölé.

![ABC matematikai kifejezés overbar‑ral](powerpoint-math-equations_14.png)

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

Egy meglévő egyenlet szövegének formázásához járja be minden matematikai blokk elemfáját. A [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni a tört, indexek, gyökök és egyéb beágyazott struktúrák szövegének eléréséhez. Ellenőrizze a jelenlegi elemet és annak gyermekeit is, hogy a [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) kiinduló elemét is belefoglalja.

Ez a példa azt feltételezi, hogy a `input.pptx` tartalmaz egy olyan egyenletet, mint `z = xᵢ / ∛y`, amelynek törtjában a számlálóban alsóindex, a nevezőben pedig gyök van. Ha csak a blokk felsőszintű elemeit dolgozza fel, a törtben lévő szöveget kihagyja. A példa a diák szövegdobozaiban keresi a matematikai részeket, a blokkokat a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) segítségével érheti el, és a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) metódussal 28 pont méretű betűt állít be minden szövegelem [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) metódusán keresztül.

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

A mentett prezentáció frissített szövegformázást tartalmaz minden szintben a feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyorsreferencia**

| Task | Main API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Elek kombinálása | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Törtek létrehozása | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Felső‑ vagy alsóindex hozzáadása | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Határértékek hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Baloldali szkriptek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Összegzések és integrálok | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Vonalak és keretek | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)‑t tartalmaz, hívja meg a [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) metódust, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként kerülnek mentésre?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze be az egyenlet [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)‑ból, majd hívja meg a [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) metódust a közvetlen exportáláshoz. Teljes példa a [Export Math Equations from Presentations in Node.js via Java](/slides/hu/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) oldalon található.