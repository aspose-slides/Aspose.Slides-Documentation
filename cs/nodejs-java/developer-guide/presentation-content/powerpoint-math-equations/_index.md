---
title: Přidání matematických rovnic do prezentací PowerPoint v JavaScriptu
linktitle: Matematické rovnice PowerPoint
type: docs
weight: 80
url: /cs/nodejs-java/powerpoint-math-equations/
keywords:
- matematická rovnice
- matematický symbol
- matematický vzorec
- matematický text
- přidat matematickou rovnici
- přidat matematický symbol
- přidat matematický vzorec
- přidat matematický text
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro Node.js přes Java, s podporou OMML, kontrolou formátování a přehlednými ukázkami kódu v JavaScriptu."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro Node.js přes Java můžete programově vytvářet stejný typ matematického obsahu: zlomky, odmocniny, funkce, limity, N‑ary operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé obvykle přidávají rovnice pomocí **Insert > Equation**:

![Karta Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledek je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ukládá matematický obsah uvnitř textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Většina příkladů níže používá [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) a plynulé metody z [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) pro udržení kódu stručného a čitelného.

Pro scénáře exportu MathML viz [Export rovnic z prezentací v Node.js přes Java](/slides/cs/nodejs-java/exporting-math-equations/).

## **Vytvoření rovnice**

Tento příklad používá [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) k vytvoření matematického tvaru a přidává Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) vytváří tvar, který již obsahuje matematický odstavec. Přistupte k prvnímu [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), zavolejte [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a přidejte matematické bloky nebo matematické elementy.
{{% /alert %}}

## **Přidání zlomků**

Použijte [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) k vytvoření zlomku. Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Zkosený matematický zlomek zobrazující 1 děleno x](powerpoint-math-equations_4.png)

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

Pro vrstvený zlomek použijte [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Přidání odmocnin**

Použijte [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) k vytvoření druhé odmocniny, třetí odmocniny nebo jiné. Aktuální element se stane základem a argument se stane stupněm.

![Výraz n‑té odmocniny s x pod znakem odmocniny](powerpoint-math-equations_5.png)

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

## **Přidání funkcí a limit**

Použijte [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) nebo [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) nebo použijte [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce udělejte název funkce aktuálním elementem a zavolejte [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) s jejím argumentem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Přidání N‑ary operátorů a integrálů**

Použijte [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) pro součty, sjednocení, průniky a další velké operátory. Použijte [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) pro integrály. Obě metody umožňují nastavit dolní i horní limity.

![Součet s dolní a horní limitou](powerpoint-math-equations_7.png)

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

N‑ary operátory slouží k velkým operátorům s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) a spojují do výrazu.

Pro integrál použijte [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) pro řádky a sloupce. Matice standardně neobsahují závorky, proto je obalte, pokud potřebujete kulaté, hranaté nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

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

## **Přidání polí rovnic**

Použijte [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), když potřebujete zarovnané rovnice nebo svislé uspořádání výrazů.

![Vertikální matematické pole s x nad y](powerpoint-math-equations_11.png)

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

### **Zarovnání pole s okolními elementy**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) řídí svislé zarovnání pole vzhledem k matematickým elementům vedle něj. Následující příklad porovnává zarovnání s první řadou, středem pole a poslední řadou.

Následující příklad vytvoří tři identická pole, každé se třemi řádky a sousedními elementy `A=` a `=B`. Veškerý matematický text používá Cambria Math o velikosti 24 bodů. Pouze zarovnání pole se mění.

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

Následující porovnání ukazuje uloženou prezentaci v PowerPointu. Všimněte si pozice `A=` a `=B` vedle každého pole.

![Pole rovnic v PowerPointu s horním, středním a dolním zarovnáním a identickými sousedními elementy](equation-array-alignment.png)

### **Nastavení řádkování**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) vybírá pravidlo řádkování pro řádky v poli. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) poskytuje číselnou hodnotu pro explicitní pravidlo řádkování a je ignorováno přednastavenými pravidly.

Pro přesné řádkování se hodnota měří v bodech. Pro proporcionální řádkování se měří v půlřádcích: hodnota `3` v příkladu udává 1,5 řádku. Při zadání explicitní hodnoty nastavte obě vlastnosti; změna pouze číselné hodnoty nevybírá pravidlo řádkování.

Níže uvedený příklad uloží pět prezentací se stejnými rovnicemi, zarovnáním a nastavením písma. První tři používají předvolby; poslední dvě ukazují explicitní hodnoty.

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

Řádkování pole je oddělené od řádkování odstavce. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) a [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) přidávají prostor kolem obsahujícího odstavce, nikoli mezi řádky pole. Podobně [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) umisťuje celý matematický odstavec horizontálně; nenahrazuje nastavení svislého zarovnání pole.

## **Přidání trigonometrických funkcí**

Použijte [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), když je argument aktuálním elementem a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

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

## **Přidání dolních a horních indexů**

Použijte pomocníky pro dolní a horní indexy pro indexy a exponenty. Když musí indexy být na levé straně základu, použijte [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

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

## **Přidání ohraničovačů**

Použijte [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) k vložení výrazu do ohraničovačů. Můžete také nastavit znak oddělovače pro výrazy ohraničovačů, které obsahují několik elementů.

![Výraz s ohraničovači obsahující x, y a z oddělené svislými pruhy](powerpoint-math-equations_13.png)

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

### **Velikost a zarovnání ohraničovačů**

Předávejte `true` do [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), aby se závorky zvětšily kolem vysokého operandu, nebo `false`, aby zůstaly v normální velikosti. Použijte [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) s jednou ze dvou hodnot [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` vycentruje závorky na matematické ose, která prochází středem znaménka rovnosti. `Match` je zarovná s obsahem uvnitř. Obě nastavení ovlivňují jen ohraničovače. Výraz uvnitř zůstává stejný.

Příklad umisťuje zlomek do exponentu `x`, takže výraz se rozšiřuje výše nad základní čárou než pod ní. Všechny čtyři rovnice používají stejné závorky a nastavení písma.

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

V PowerPointu porovnejte řádky pro zhlédnutí efektu růstu. V horním řádku se závorky rozšíří, aby obklopily exponent a vypadají stejně pro oba tvary. Ve spodním řádku je růst vypnutý. Menší závorky vlevo (`Centered`) se zarovnají se znaménkem rovnosti, zatímco pravé (`Match`) jsou výše kolem výrazu.

![Čtyři rovnice v PowerPointu s růstem ohraničovačů zapnutým nahoře a vypnutým dole, a Centered vlevo a Match vpravo](delimiter-sizing.png)

## **Přidání ohraničeného rámečku**

Zavolejte [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) na zlomek pro ohraničení celého výrazu. Vrácený [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) ve výchozím nastavení zobrazí všechny čtyři strany. Použijte [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) a [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) pro odebrání jednotlivých stran.

Příklad umístí šest kopií stejného zlomku na jeden snímek. Pro zobrazení zrušení skryjte všechny čtyři strany a předávejte `true` do [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) pro rostoucí úhlopříčku (↗) nebo [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) pro klesající úhlopříčku (↘). Můžete také použít [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) nebo [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) s libovolnou kombinací viditelných stran.

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

![Šest editovatelných zlomků v PowerPointu. Horní řada: úplný rámeček, spodní a levá strana, rostoucí úhlopříčka. Dolní řada: klesající úhlopříčka, horizontální čára, vertikální čára s úplným rámečkem.](border-box-fractions.png)

Na tomto zlomku horizontální čára přesahuje čáru zlomku. Vertikální čára protíná čitatel i jmenovatel, zatímco okolní rámeček zůstává viditelný. Tyto čáry zdobí celý výraz. Běžné přeškrtnutí textu se vztahuje na znaky v textovém běhu. Po opětovném otevření prezentace v PowerPointu můžete nadále samostatně upravovat čitatel i jmenovatel.

## **Seskupení termínů**

Použijte [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) k umístění seskupovacího znaku nad nebo pod výraz. Přidejte limit pro označení seskupených termínů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

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

## **Formátování matematických elementů**

Používejte pomocníky formátování jen tam, kde objasňují vzorec. Například [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) umístí čáru nad matematický element.

![Matematický výraz ABC s přeškrtníčkou](powerpoint-math-equations_14.png)

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

### **Formátování textu v existující rovnici**

Pro formátování textu v celé existující rovnici projděte strom elementů každého matematického bloku. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) vrací jen přímé potomky, takže jej volejte rekurzivně, abyste se dostali k textu uvnitř zlomků, skriptů, odmocnin a dalších vnořených struktur. Zkontrolujte aktuální element i jeho potomky, aby byl zahrnut výchozí element, pokud je [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Tento příklad předpokládá, že `input.pptx` obsahuje rovnici jako `z = xᵢ / ∛y`, kde zlomek má dolní index v čitateli a odmocninu ve jmenovateli. Zpracování pouze elementů nejvyšší úrovně bloku by prošvihlo text uvnitř zlomku. Příklad najde matematické části v textových rámech snímků, přistoupí k jejich blokům přes [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a použije [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) k nastavení velikosti písma na 28 bodů pro každý textový element pomocí metody [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

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

Uložená prezentace obsahuje aktualizované formátování textu na každé úrovni každé zpracované rovnice, přičemž zachovává její textový obsah a matematickou strukturu.

## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Kombinovat elementy | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Vytvořit zlomky | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat horní nebo dolní index | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat odmocniny | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat limity | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat skripty na levé straně | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat součty a integrály | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Přidat pole rovnic | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat ohraničovače | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat čáry a rámečky | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Seskupit termíny | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), zavolejte [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a aktualizujte matematické bloky v tomto odstavci.

**Jsou rovnice uloženy jako editovatelná matematika v PowerPointu?**

Ano. Při ukládání do PPTX Aspose.Slides zapíše rovnici jako editovatelný obsah Office math.

**Mohu exportovat rovnice do LaTeXu?**

Ano. Získáte [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) rovnice z jejího [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) a zavoláte [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) pro přímý export. Kompletní příklad najdete v [Export Math Equations from Presentations in Node.js via Java](/slides/cs/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).