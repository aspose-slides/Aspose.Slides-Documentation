---
title: Voeg wiskundige vergelijkingen toe aan PowerPoint‑presentaties in JavaScript
linktitle: PowerPoint wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg wiskundige vergelijkingen in PowerPoint PPT en PPTX in en bewerk ze met Aspose.Slides voor Node.js via Java, met ondersteuning voor OMML, opmaakcontroles en duidelijke JavaScript‑codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat formules op als Office Math Markup Language (OMML). Met Aspose.Slides voor Node.js via Java kun je dezelfde soort wiskundige inhoud programmatisch maken: breuken, wortels, functies, limieten, N-aire operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gezien formules toe via **Insert > Equation**:

![PowerPoint Insert-tabblad met de opdracht Equation geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint-dia met een bewerkbare wiskundige formule](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst op via drie hoofdobjecten:

- Een wiskundige vorm, gecreëerd met [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), is de vorm die de formule bevat.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) slaat wiskundige inhoud op in het tekstvak van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) bevat een of meer [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) en de vloeiende methoden van [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) om de code kort en leesbaar te houden.

Voor MathML‑exportscenario's, zie [Exporteer wiskundige formules uit presentaties in Node.js via Java](/slides/nl/nodejs-java/exporting-math-equations/).

## **Maak een formule**

Dit voorbeeld gebruikt [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) om een wiskundige vorm te maken en voegt de stelling van Pythagoras toe:

![De formule c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) maakt een vorm die al een wiskundige alinea bevat. Toegang tot de eerste [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), roep [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) aan, en voeg wiskundige blokken of wiskundige elementen toe.
{{% /alert %}}

### **Combineer wiskundige blokken**

Wanneer delen van een formule onafhankelijk worden opgebouwd als [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) objecten, gebruik dan [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) om ze te combineren. Het voorbeeld bouwt `c² =` in het linkse blok en `a² + b²` in het rechtse blok. [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) maakt bewerkbare wiskundige superscripties voor alle drie de machten.

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

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) retourneert `leftBlock` zelf, nu met beide delen in de juiste volgorde, en laat `rightBlock` leeg. Voeg het gecombineerde blok slechts één keer toe aan de [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Na het heropenen van `equation.pptx` bevat de alinea één blok dat `c² = a² + b²` weergeeft, waarbij alle drie de machten bewaard blijven als wiskundige superscripties.

Het aanroepen van [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) als `leftBlock.add(rightBlock)` probeert in plaats daarvan één blok direct in een ander te nesten en geeft een `InvalidOperationException` terug.

## **Voeg breuken toe**

Gebruik [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x toont](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Voeg wortels toe**

Gebruik [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) om een vierkantswortel, derdemachtswortel of een andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n-de machtswortel met x onder het wortelteken](powerpoint-math-equations_5.png)

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

### **Toon of verberg de graad van een vierkantswortel**

Een vierkantswortel kan een expliciete 2 tonen of de conventionele √x‑notatie gebruiken. De [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree)‑methode van [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) bepaalt welke vorm verschijnt. Beide vormen behouden graad 2 en radicand x in de bewerkbare formule.

![Dezelfde vierkantswortel met de graad zichtbaar links en verborgen rechts](square-root-degree.png)

Het voorbeeld slaat dezelfde vierkantswortel twee keer op. In `visible-degree.pptx` is de 2 zichtbaar. In `hidden-degree.pptx` is hij verborgen.

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

## **Voeg functies en limieten toe**

Gebruik [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) of [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) voor functies zoals `sin(x)`, `log(x)`, of aangepaste functienamen. Voor limieten plaats je `lim` in een [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) of gebruik je [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

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

Voor een aangepaste functienaam maak je van de functienaam het huidige element en roep je [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) aan met het argument:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Voeg N-aire operatoren en integralen toe**

Gebruik [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) voor sommatie, verenigingen, doorsneden en andere grote operatoren. Gebruik [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) voor integralen. Beide methoden laten je onder‑ en bovengrenzen instellen.

![Een sommatie met onder- en bovengrenzen](powerpoint-math-equations_7.png)

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

N-aire operatoren zijn bedoeld voor grote operatoren met optionele limieten. Eenvoudige operatoren zoals `+`, `-` en `=` worden meestal toegevoegd als [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) en samengevoegd in de uitdrukking.

Voor een integraal, gebruik [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Voeg matrices toe**

Gebruik [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omsluit de matrix wanneer je haakjes, vierkante haken of accolades nodig hebt.

![Een wiskundige matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

### **Bewerk een bestaande matrix**

Stel je een lineaire‑algebra‑les voor die start met de coefficientmatrix in `matrix.pptx`, opgeslagen door het voorgaande voorbeeld. Voor de volgende oefening behoud je de eerste formule, vervang je de tweede door twee nieuwe formules en pas je de variabelen aan. Open de bestaande matrix via [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) om de nog geldende coëfficiënten te behouden.

![Originele coefficientmatrix met twee rijen met waarden 1, x en een lege cel in de eerste rij en x, 2 en y in de tweede](matrix-before-edit.png)

Rij‑ en kolomindexen beginnen bij nul en verwijzen naar de matrix zoals die bestaat op het moment van de oproep. Een rij invoegen vóór index 1 verplaatst de oorspronkelijke tweede rij naar index 2. Invoegen na index 2 voegt vervolgens een rij toe. Het verwijderen van rij 2 verwijdert de oorspronkelijke tweede formule en schuift de toegevoegde rij één positie omhoog. Kolommen verschuiven op dezelfde manier.

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

    // Nieuwe cellen zijn aanvankelijk null. Stel eerst de niet-nul coëfficiënten in.
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

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) aligneert de eerste kolom links. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) aligneert drie opeenvolgende kolommen rechts, beginnend bij index 1. In `updated-matrix.pptx` heeft de matrix drie formules en vier variabelen. De oorspronkelijke eerste‑rij‑coëfficiënten `1` en `x` verschijnen nu in de eerste en derde kolom.

![Bijgewerkte matrix met drie rijen waarin de rijen 1, 0, x, 0; 12, 1, 0, 0; en 0, 0, 10, 1 worden getoond](matrix-after-edit.png)

## **Voeg vergelijkingarrays toe**

Gebruik [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) wanneer je uitgelijnde formules of een verticale stapel uitdrukkingen nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

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

### **Lijn een array uit met omliggende elementen**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) bepaalt de verticale uitlijning van een array ten opzichte van de wiskundige elementen ernaast. Het voorbeeld hieronder vergelijkt uitlijning met de eerste rij, het midden van de array en de laatste rij.

Het onderstaande voorbeeld maakt drie identieke arrays, elk met drie rijen en de naburige elementen `A=` en `=B`. Alle wiskundige tekst gebruikt Cambria Math op 24 pt. Alleen de array‑uitlijning verandert.

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

De volgende vergelijking toont de opgeslagen presentatie in PowerPoint. Let op de positie van `A=` en `=B` naast elke array.

![Vergelijkingsarrays in PowerPoint met uitlijning Boven, Midden en Onder en identieke omliggende elementen](equation-array-alignment.png)

### **Stel rijafstand in**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) selecteert de regel voor de afstand tussen rijen binnen de array. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) levert een numerieke waarde voor een expliciete afstandsregel en wordt genegeerd door de vooraf ingestelde regels.

Voor exacte afstand wordt de waarde gemeten in punten. Voor proportionele afstand wordt gemeten in halve regelhoogtes: de waarde `3` in het voorbeeld staat voor 1,5 regels. Stel beide eigenschappen in wanneer je een expliciete waarde opgeeft; alleen de numerieke waarde wijzigen selecteert geen afstandsregel.

Het voorbeeld hieronder slaat vijf presentaties op met dezelfde formules, uitlijning en lettertype‑instellingen. De eerste drie gebruiken presets; de laatste twee tonen expliciete waarden.

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

De rijafstand binnen een array staat los van de alinea‑afstand. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) en [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) voegen ruimte toe rond de omvattende alinea, niet tussen array‑rijen. Evenzo positioneert [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) de hele wiskundige alinea horizontaal; het vervangt niet de verticale uitlijningsinstelling van de array.

## **Voeg trigonometrische functies toe**

Gebruik [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) wanneer het argument het huidige element is en de functienaam bekend is.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

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

## **Voeg subscripties en superscripties toe**

Gebruik de subscript‑ en superscript‑helpers voor indexen en machten. Wanneer de indexen links van de basis moeten verschijnen, gebruik dan [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Een hoofdletter Y met links subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Voeg scheidingstekens toe**

Gebruik [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) om een uitdrukking binnen scheidingstekens te plaatsen. Je kunt ook een scheidingsteken‑karakter instellen voor uitdrukkingen die meerdere elementen bevatten.

![Een scheidingstekenuitdrukking met x, y en z gescheiden door verticale strepen](powerpoint-math-equations_13.png)

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

### **Grootte en uitlijning van scheidingstekens**

Geef `true` aan [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) om de haakjes te laten groeien rondom een hoge operand, of geef `false` om ze op normale grootte te houden. Gebruik [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) met een van de twee [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) waarden. `Centered` centreert de haakjes op de wiskundige as, die door het midden van het gelijkteken loopt. `Match` aligneert ze op de ingesloten inhoud. Beide instellingen beïnvloeden alleen de scheidingstekens. De uitdrukking binnen blijft gelijk.

Het voorbeeld plaatst een breuk in de exponent van `x` zodat de uitdrukking hoger uitsteekt boven de basislijn dan eronder. Alle vier de formules gebruiken dezelfde haakjes en dezelfde lettertype‑instellingen.

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

Vergelijk in PowerPoint de rijen om het effect van groei te zien. In de bovenste rij groeien de haakjes om de exponent heen en zien ze er voor beide vormen gelijk uit. In de onderste rij staat groei uitgeschakeld. De kleinere haakjes links (`Centered`) lijnen zich uit met het gelijkteken, terwijl die rechts (`Match`) hoger om de uitdrukking heen zitten.

![Vier formules in PowerPoint met scheidingsteken‑groei ingeschakeld boven en uitgeschakeld onder, en Centered links en Match rechts](delimiter-sizing.png)

## **Voeg een randvak toe**

Roep [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) aan op een breuk om de gehele uitdrukking in een kader te plaatsen. Het geretourneerde [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) toont standaard alle vier de zijden. Gebruik [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) en [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) om afzonderlijke zijden te verwijderen.

Het voorbeeld plaatst zes kopieën van dezelfde breuk op één dia. Om een kruis‑doorhaling te tonen, verberg je alle vier zijden en geef je `true` aan [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) voor een stijgende diagonaal (↗) of aan [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) voor een dalende diagonaal (↘). Je kunt ook [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) of [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) gebruiken met elke combinatie van zichtbare zijden.

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

![Zes bewerkbare breuken in PowerPoint. Bovenste rij: volledige rand, onder‑ en linkerrand, stijgende diagonaal. Onderste rij: dalende diagonaal, horizontale streep, verticale streep met een volledige rand](border-box-fractions.png)

Bij deze breuk overlapt de horizontale streep de breukstreep. De verticale streep doorsnijdt zowel de teller als de noemer terwijl de omringende rand zichtbaar blijft. Deze lijnen decoreren de gehele uitdrukking. Gewone tekst‑doorhaling geldt voor tekens in een tekstrun. Na het heropenen van de presentatie in PowerPoint kun je de teller en noemer nog steeds onafhankelijk bewerken.

## **Beheer zichtbaarheid en lay-out met fantomelementen**

Wikkel een uitdrukking in [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) om de zichtbaarheid en de ruimte die het bijdraagt aan een formule onafhankelijk te regelen. De [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/)‑methoden regelen het volgende:

| Methode | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | Geef `false` op om de uitdrukking te verbergen. De afmetingen blijven bijdragen aan de lay‑out tenzij de onderstaande methoden `true` ontvangen. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | Beschouw de horizontale breedte van de uitdrukking als nul, zodat naburige elementen dichter bij elkaar kunnen komen. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | Beschouw de stijging, de hoogte boven de basislijn, als nul. Dit kan de gereserveerde ruimte boven naburige elementen verminderen. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | Beschouw de daling, de diepte onder de basislijn, als nul. Dit kan een breukstreep of andere inhoud onder de uitdrukking dichter bij de buren brengen. |

De basislijn is de referentielijn waarop gewone wiskundige letters staan. Het verbergen van inhoud verwijdert de afmetingen niet, en een dimensie op nul stellen verwijdert de uitdrukking niet. De onderliggende uitdrukking blijft beschikbaar via [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase). Geef `true` aan [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) om het weer weer te geven; de dimensie‑instellingen blijven ongewijzigd.

Het voorbeeld hieronder maakt vijf varianten naast elkaar: een zichtbare breuk, een verborgen breuk die ruimte reserveert, en drie verborgen breuken waarbij één dimensie op nul is gezet. Iedere variant gebruikt dezelfde omliggende uitdrukking en Cambria Math op 24 pt. Alle formules hebben dezelfde bovenpositie, gemarkeerd door de grijze hulplijn. Het plaatsen van de phantom in de teller van een buitenste breuk maakt de verticale lay‑out‑wijzigingen beter zichtbaar.

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

![Vijf formules in PowerPoint die een zichtbare breuk, een verborgen breuk die ruimte reserveert, en verborgen breuken met ZeroWidth, ZeroAsc of ZeroDesc tonen](math-phantom.png)

## **Groeperen van termen**

Gebruik [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) om een groepeerteken boven of onder een uitdrukking te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De uitdrukking x + y gegroepeerd met een label eronder](powerpoint-math-equations_15.png)

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

## **Formateer wiskundige elementen**

Gebruik opmaakhulpmiddelen alleen waar ze de formule verduidelijken. Bijvoorbeeld, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) plaatst een streep boven een wiskundig element.

![Een wiskundige uitdrukking ABC met een overstreep](powerpoint-math-equations_14.png)

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

### **Formateer tekst in een bestaande formule**

Om tekst door een bestaande formule heen te formatteren, doorloop je de elementboom van elk wiskundig blok. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) retourneert alleen de directe kinderen, dus roep je het recursief aan om tekst in breuken, scripts, wortels en andere geneste structuren te bereiken. Controleer zowel het huidige element als zijn kinderen om het start‑element op te nemen wanneer het een [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) is.

Dit voorbeeld gaat ervan uit dat `input.pptx` een formule bevat zoals `z = xᵢ / ∛y`, met een breuk die een subscript in de teller heeft en een wortel in de noemer. Alleen de bovenliggende elementen van het blok verwerken zou de tekst binnen de breuk missen. Het voorbeeld zoekt wiskundige porties in dia‑tekstkaders, benadert hun blokken via [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), en gebruikt [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) om de lettergrootte op 28 pt te zetten via de [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat)‑methode van elk tekstelement.

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

De opgeslagen presentatie bevat de bijgewerkte tekstopmaak op elk niveau van elke verwerkte formule, terwijl de tekstinhoud en wiskundige structuur behouden blijven.

## **Snel overzicht**

| Taak | Hoofd‑API |
| --- | --- |
| Maak wiskundige tekst | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Combineer elementen | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Maak breuken | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg superscript of subscript toe | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg functies toe | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg wortels toe | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg limieten toe | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg linkszijdige scripts toe | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg sommaties en integralen toe | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg matrices toe | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Voeg vergelijkingarrays toe | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg scheidingstekens toe | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Voeg staven en randen toe | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Groeperen van termen | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑formule bewerken?**

Ja. Open de presentatie, zoek de vorm die een [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) bevat, roep [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) aan en werk de wiskundige blokken in die alinea bij.

**Worden formules opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer je opslaat naar PPTX, schrijft Aspose.Slides de formule weg als bewerkbare Office‑math‑inhoud.

**Kan ik formules exporteren naar LaTeX?**

Ja. Haal de [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) van de [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) op en roep [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) aan om direct te exporteren. Voor een volledig voorbeeld, zie [Exporteer wiskundige formules uit presentaties in Node.js via Java](/slides/nl/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).