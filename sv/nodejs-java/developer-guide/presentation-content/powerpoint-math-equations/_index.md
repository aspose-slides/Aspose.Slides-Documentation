---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i JavaScript
linktitle: PowerPoint-matematikekvationer
type: docs
weight: 80
url: /sv/nodejs-java/powerpoint-math-equations/
keywords:
- matematikekvation
- matematiksymbol
- matematikformel
- matematisk text
- lägg till matematikekvation
- lägg till matematiksymbol
- lägg till matematikformel
- lägg till matematisk text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för Node.js via Java, med stöd för OMML, formateringskontroller och tydliga JavaScript-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för Node.js via Java kan du programatiskt skapa samma typ av matematikinnehåll: bråk, radikaler, funktioner, gränsvärden, N-ära operatorer, matriser, arrayer och formaterade matematiska block.

I PowerPoint lägger användare normalt till ekvationer från **Infoga > Ekvation**:

![PowerPoint‑fliken Infoga med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint‑bild som innehåller en redigerbar matematikekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiska texten via tre huvudobjekt:

- En matematikform, skapad med [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) lagrar matematiskt innehåll i formens textruta.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)‑objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) och de flödande metoderna från [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Exportera matematiska ekvationer från presentationer i Node.js via Java](/slides/sv/nodejs-java/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel använder [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) för att skapa en matematikform och lägger till Pythagoras sats:

![Ekvationen c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) skapar en form som redan innehåller ett matematikparagraf. Åtkomst till den första [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), anropa [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), och lägg till matematikblock eller matematiskelement i den.
{{% /alert %}}

## **Lägg till bråk**

Använd [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) för att skapa ett bråk. Du kan välja en bråksstil med [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Ett snett matematiskt bråk som visar en dividerat med x](powerpoint-math-equations_4.png)

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

För ett staplat bråk, använd [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Lägg till radikaler**

Använd [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n:te röttradicuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

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

## **Lägg till funktioner och gränsvärden**

Använd [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) eller [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) för funktioner som `sin(x)`, `log(x)` eller anpassade funktionsnamn. För gränsvärden, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) eller använd [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Gränsvärdet för x när x närmar sig oändlighet](powerpoint-math-equations_8.png)

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

För ett anpassat funktionsnamn, gör funktionsnamnet till det aktuella elementet och anropa [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) med dess argument:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Lägg till N-ära operatorer och integraler**

Använd [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) för summor, unioner, snitt och andra stora operatorer. Använd [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) för integraler. Båda metoderna låter dig sätta lägre och övre gränser.

![En summa med lägre och övre gränser](powerpoint-math-equations_7.png)

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

N-ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) och slås ihop i uttrycket.

För en integral, använd [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrisen när du behöver parenteser, hakparenteser eller måsvingar.

![En tvåradig matematisk matris med en tom cell](powerpoint-math-equations_10.png)

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

## **Lägg till ekvationsarrayer**

Använd [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matematisk array med x ovanför y](powerpoint-math-equations_11.png)

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

### **Justera en array med omgivande element**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) styr den vertikala justeringen av en array i förhållande till de matematiska element som ligger bredvid den. Exemplet nedan jämför justering med den första raden, mitten av arrayen och den sista raden.

Följande exempel skapar tre identiska arrayer, var och en med tre rader och de intilliggande elementen `A=` och `=B`. All matematisk text använder Cambria Math i 24 punkter. Endast arrayens justering förändras.

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

Följande jämförelse visar den sparade presentationen i PowerPoint. Notera positionen för `A=` och `=B` bredvid varje array.

![Ekvationsarrayer i PowerPoint med topp-, mitten- och bottenjustering samt identiska intilliggande element](equation-array-alignment.png)

### **Konfigurera radavstånd**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) väljer avståndsregeln för rader inom arrayen. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) anger ett numeriskt värde för en explicit avståndsregel och ignoreras av förinställda regler.

För exakt avstånd mäts värdet i punkter. För proportionellt avstånd mäts det i halva rader: värdet `3` i exemplet motsvarar 1,5 rader. Ställ in båda egenskaperna när du anger ett explicit värde; att bara ändra det numeriska värdet väljer inte en avståndsregel.

Exemplet nedan sparar fem presentationer med samma ekvationer, justering och teckensnittinställningar. De första tre använder förinställningar; de två sista visar explicita värden.

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

Radavstånd i en array är separat från styckeavstånd. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) och [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) lägger till utrymme runt det innehållande stycket, inte mellan arrayrader. På samma sätt placerar [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) hela math‑stycket horisontellt; det ersätter inte arrayens vertikala justeringsinställning.

## **Lägg till trigonometriska funktioner**

Använd [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos tillämpad på 2x](powerpoint-math-equations_6.png)

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

## **Lägg till nedsänkta och upphöjda index**

Använd hjälparna för nedsänkta och upphöjda index för index och potenser. När indexen måste visas på vänster sida av basen, använd [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![En versal Y med nedsänkt index 1 på vänster sida och upphöjt index n](powerpoint-math-equations_9.png)

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

## **Lägg till avgränsare**

Använd [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) för att placera ett uttryck inom avgränsare. Du kan också ange ett avgränsartecken för avgränsarexpressioner som innehåller flera element.

![En avgränsarexpression som innehåller x, y och z åtskilda av vertikala streck](powerpoint-math-equations_13.png)

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

### **Storlek och justering av avgränsare**

Skicka `true` till [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) för att låta parenteserna växa runt en hög operand, eller skicka `false` för att behålla deras normala storlek. Använd [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) med ett av två [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/)‑värden. `Centered` centrerar parenteserna på den matematiska axeln, som löper genom mitten av likhetstecknet. `Match` justerar dem med det omslutna innehållet. Båda inställningarna påverkar endast avgränsarna. Uttrycket inuti förblir detsamma.

Exemplet placerar ett bråk i exponenten av `x` så att uttrycket sträcker sig längre över baslinjen än under den. Alla fyra ekvationer använder samma parenteser och teckensnittinställningar.

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

I PowerPoint, jämför raderna för att se effekten av tillväxt. I den översta raden växer parenteserna för att omsluta exponenten och ser likadana ut för båda formerna. I den nedersta raden är tillväxt avstängd. De mindre parenteserna till vänster (`Centered`) är i linje med likhetstecknet, medan de till höger (`Match`) sitter högre kring uttrycket.

![Fyra ekvationer i PowerPoint med avgränsartillväxt aktiverad ovan och avstängd nedan, och Centered till vänster och Match till höger](delimiter-sizing.png)

## **Lägg till en ramruta**

Anropa [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) på ett bråk för att rama in hela uttrycket. Den returnerade [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) visar alla fyra sidor som standard. Använd [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) och [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) för att ta bort enskilda sidor.

Exemplet placerar sex kopior av samma bråk på en bild. För att visa avbokning, dölj alla fyra sidor och skicka `true` till [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) för en stigande diagonal (↗) eller [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) för en fallande diagonal (↘). Du kan också använda [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) eller [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) med valfri kombination av synliga sidor.

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

![Sex redigerbara bråk i PowerPoint. Övre raden: full ram, botten- och vänstersidor, stigande diagonal. Nedre raden: fallande diagonal, horisontell streckning, vertikal streckning med full ram](border-box-fractions.png)

På detta bråk överlappar den horisontella streckningen bråkstrecket. Den vertikala streckningen korsar både täljaren och nämnaren medan den omgivande ramen förblir synlig. Dessa linjer dekorerar hela uttrycket. Vanlig textgenomstrykning gäller tecken i en textrun. Efter att ha öppnat presentationen igen i PowerPoint kan du fortfarande redigera täljaren och nämnaren separat.

## **Gruppera termer**

Använd [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) för att placera ett grupperingstecken ovanför eller nedanför ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten någon text nedanför](powerpoint-math-equations_15.png)

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

## **Formatera matematiska element**

Använd formateringshjälpare endast där de tydliggör formeln. Till exempel placerar [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) ett streck över ett matematiskt element.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

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

### **Formatera text i en befintlig ekvation**

För att formatera text i hela en befintlig ekvation, traversera varje math‑blocks elementträd. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) returnerar endast de omedelbara barnen, så anropa den rekursivt för att nå text inuti bråk, skript, radikaler och andra nästlade strukturer. Kontrollera det aktuella elementet samt dess barn för att inkludera startelementet när det är [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Detta exempel antar att `input.pptx` innehåller en ekvation såsom `z = xᵢ / ∛y`, med ett bråk som innehåller ett nedsänkt index i täljaren och en radikal i nämnaren. Att endast bearbeta blockets top‑nivå‑element skulle missa texten i bråket. Exemplet hittar matematiska portioner i bildens textrutor, får åtkomst till deras block via [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), och använder [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) för att sätta teckenstorleken till 28 punkter via varje textelements [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat)‑metod.

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

Den sparade presentationen innehåller den uppdaterade textformateringen på varje nivå av varje bearbetad ekvation, samtidigt som dess textinnehåll och matematiska struktur bevaras.

## **Snabbreferens**

| Task | Main API |
| --- | --- |
| Skapa matematisk text | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Kombinera element | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Skapa bråk | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till upphöjt eller nedsänkt index | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till funktioner | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till radikaler | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till gränsvärden | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till skript på vänstersidan | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till summationer och integraler | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Lägg till ekvationsarrayer | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till avgränsare | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till streck och ramar | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Gruppera termer | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), anropa [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), och uppdatera matematikblocken i det stycket.

**Sparas ekvationer som redigerbar PowerPoint‑math?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑math‑innehåll.

**Kan jag exportera ekvationer till LaTeX?**

Ja. Hämta ekvationens [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) från dess [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), och anropa [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) för att exportera den direkt. För ett komplett exempel, se [Exportera matematiska ekvationer från presentationer i Node.js via Java](/slides/sv/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).