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
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides for Node.js via Java, podporující OMML, ovládací prvky formátování a přehledné ukázky kódu v JavaScriptu."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides for Node.js via Java můžete programově vytvářet stejný typ matematického obsahu: zlomky, kořeny, funkce, limity, N‑ary operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé běžně přidávají rovnice z **Vložit > Rovnice**:

![PowerPoint záložka Vložení s vybraným příkazem Rovnice](powerpoint-math-equations_1.png)

Výsledkem je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ukládá matematický obsah uvnitř textového rámečku tvaru.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Většina níže uvedených příkladů používá [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) a plynulé metody z [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) pro stručný a čitelný kód.

Pro scénáře exportu MathML viz [Export Math Equations from Presentations in Node.js via Java](/slides/cs/nodejs-java/exporting-math-equations/).

## **Vytvořit rovnici**

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

{{% alert color="info" title="Poznámka" %}}

[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) vytváří tvar, který již obsahuje matematický odstavec. Přistupte k první [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), zavolejte [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a přidejte do něj matematické bloky nebo prvky.

{{% /alert %}}

### **Kombinovat matematické bloky**

Když jsou části rovnice postaveny nezávisle jako objekty [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/), použijte [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) k jejich sloučení. Příklad vytváří `c² =` v levém bloku a `a² + b²` v pravém bloku. [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) vytváří editovatelné matematické horní indexy pro všechny tři mocniny.

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

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) vrací samotný `leftBlock`, nyní obsahující oba části v pořadí, a ponechává `rightBlock` prázdný. Kombinovaný blok přidejte do [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) jen jednou. Po opětovném otevření `equation.pptx` odstavec obsahuje jeden blok představující `c² = a² + b²`, přičemž všechny tři mocniny zůstávají zachovány jako matematické horní indexy.

Volání [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) jako `leftBlock.add(rightBlock)` se místo toho pokouší vložit jeden blok přímo do druhého a vyvolá `InvalidOperationException`.

## **Přidat zlomky**

Použijte [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) k vytvoření zlomku. Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Šikmý matematický zlomek ukazující jeden děleno x](powerpoint-math-equations_4.png)

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

Pro zlomky se svislým pruhom použijte [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Přidat kořeny**

Použijte [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) k vytvoření druhé odmocniny, třetí odmocniny nebo jiného kořene. Aktuální prvek se stane základem a argument se stane stupněm.

![Výraz n‑tého kořene s x pod znakem kořene](powerpoint-math-equations_5.png)

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

### **Zobrazit nebo skrýt stupeň druhé odmocniny**

Druhá odmocnina může zobrazovat explicitní 2 nebo používat konvenční zápis √x. Metoda [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) třídy [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) řídí, která forma se zobrazí. Obě formy zachovávají stupeň 2 a radikand x v editovatelné rovnici.

![Stejná druhá odmocnina se stupněm viditelným vlevo a skrytým vpravo](square-root-degree.png)

Příklad ukládá stejnou druhou odmocninu dvakrát. V `visible-degree.pptx` je 2 viditelná. V `hidden-degree.pptx` je skrytá.

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

## **Přidat funkce a limity**

Použijte [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) nebo [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) nebo použijte [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Limit x při x jdoucím k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce udělejte název funkce aktuálním prvkem a zavolejte [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) s jeho argumentem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Přidat N‑ary operátory a integrály**

Použijte [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) pro sumace, sjednocení, průniky a další velké operátory. Použijte [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) pro integrály. Obě metody umožňují nastavit dolní a horní mez.

![Sumace s dolní a horní mezí](powerpoint-math-equations_7.png)

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

N‑ary operátory slouží pro velké operátory s volitelnými mezemi. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) a spojují do výrazu.

Pro integrál použijte [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Přidat matice**

Použijte [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, proto je uzavřete, pokud potřebujete závorky, hranaté závorky nebo složené závorky.

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

### **Upravit existující matici**

Předpokládejme, že lekce lineární algebry začíná koeficientovou maticí v `matrix.pptx`, uloženou předchozím příkladem. Pro další cvičení zachovejte první rovnici, druhou nahraďte dvěma novými rovnicemi a upravte sadu proměnných. Otevřete existující matici pomocí [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) a zachovejte koeficienty, které stále platí.

![Původní matice koeficientů se dvěma řádky, položky 1, x a prázdná buňka v prvním řádku a x, 2, y ve druhém řádku](matrix-before-edit.png)

Indexy řádků a sloupců začínají nulou a odkazují na matici v okamžiku každého volání. Vložení řádku před index 1 posune původní druhý řádek na index 2. Vložení po indexu 2 pak přidá řádek. Smazání řádku 2 odstraní původní druhou rovnici a posune přidaný řádek nahoru o jednu pozici. Sloupce se posouvají stejným způsobem.

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

    // Nové buňky jsou zpočátku null. Nejprve nastavte nenulové koeficienty.
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

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) zarovnává první sloupec doleva. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) zarovnává tři po sobě jdoucí sloupce vpravo, počínaje indexem 1. V `updated-matrix.pptx` má matice tři rovnice a čtyři proměnné. Původní koeficienty v prvním řádku `1` a `x` se nyní objeví v prvním a třetím sloupci.

![Aktualizovaná matice se třemi řádky zobrazující řádky 1, 0, x, 0; 12, 1, 0, 0; a 0, 0, 10, 1](matrix-after-edit.png)

## **Přidat pole rovnic**

Použijte [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), když potřebujete zarovnané rovnice nebo svislý zásobník výrazů.

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

### **Zarovnat pole s okolními prvky**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) řídí vertikální zarovnání pole vůči matematickým prvkům vedle něj. Níže uvedený příklad porovnává zarovnání s prvním řádkem, středem pole a posledním řádkem.

Následující příklad vytváří tři identické pole, každé se třemi řádky a sousedními prvky `A=` a `=B`. Veškerý matematický text používá písmo Cambria Math o velikosti 24 pt. Pouze zarovnání pole se mění.

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

Následující srovnání ukazuje uloženou prezentaci v PowerPointu. Všimněte si pozice `A=` a `=B` vedle každého pole.

![Pole rovnic v PowerPointu se zarovnáním nahoru, na střed a dolů a identickými sousedními prvky](equation-array-alignment.png)

### **Nastavit rozestup řádků**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) vybírá pravidlo rozestupu řádků v poli. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) poskytuje číselnou hodnotu pro explicitní pravidlo rozestupu a je ignorována přednastavenými pravidly.

Pro přesný rozestup se hodnota měří v bodech. Pro proporcionální rozestup se měří v půlřádcích: hodnota `3` v příkladu značí 1,5 řádku. Nastavte obě vlastnosti, když specifikujete explicitní hodnotu; změna jen číselné hodnoty nevybírá pravidlo rozestupu.

Níže uvedený příklad ukládá pět prezentací se stejnými rovnicemi, zarovnáním a nastavením písma. První tři používají přednastavené hodnoty; poslední dvě ukazují explicitní hodnoty.

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

Rozestup řádků pole je oddělený od rozestupu odstavců. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) a [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) přidávají mezery kolem obsahujícího odstavce, nikoli mezi řádky pole. Podobně [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) umisťuje celý matematický odstavec horizontálně; nenahrazuje nastavení vertikálního zarovnání pole.

## **Přidat trigonometrické funkce**

Použijte [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), když je argumentem aktuální prvek a název funkce je známý.

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

## **Přidat dolní a horní indexy**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když mají být indexy zobrazeny na levé straně základu, použijte [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

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

## **Přidat ohraničovače**

Použijte [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) k vložení výrazu do ohraničovačů. Můžete také nastavit oddělovač pro výrazy, které obsahují několik prvků.

![Výraz ohraničovače obsahující x, y a z oddělené svislými pruhy](powerpoint-math-equations_13.png)

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

Předávejte `true` metodě [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), aby se závorky roztahovaly kolem vysokého operandu, nebo `false`, aby zůstaly normální velikosti. Použijte [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) s jednou ze dvou hodnot [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` centrovává závorky na matematické ose, která prochází středem rovná se. `Match` je zarovnává podle obsahu. Obě nastavení ovlivňují jen ohraničovače. Výraz uvnitř zůstává stejný.

Příklad umisťuje zlomek do exponentu `x`, takže výraz sahá výše nad základní linii než pod ní. Všechny čtyři rovnice používají stejné závorky a nastavení písma.

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

V PowerPointu porovnejte řádky a uvidíte efekt roztahování. V horním řádku se závorky roztahují tak, aby obklopily exponent a vypadají stejně pro oba tvary. V dolním řádku je roztahování vypnuto. Menší závorky vlevo (`Centered`) jsou zarovnány na rovná se, zatímco pravé (`Match`) jsou výše okolo výrazu.

![Čtyři rovnice v PowerPointu s povoleným roztahováním ohraničovačů nahoře a vypnutým dole, a `Centered` vlevo a `Match` vpravo](delimiter-sizing.png)

## **Přidat rámeček**

Zavolejte [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) na zlomek, abyste ohraničili celý výraz. Vrácený [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) zobrazuje všechny čtyři strany ve výchozím nastavení. Použijte [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) a [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) k odebrání jednotlivých stran.

Příklad umisťuje šest kopií stejného zlomku na jeden snímek. Pro zobrazení přeškrtnutí skryjte všechny čtyři strany a předávejte `true` metodě [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) pro ústupnou diagonálu (↗) nebo [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) pro sestupnou diagonálu (↘). Můžete také použít [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) nebo [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) s libovolnou kombinací viditelných stran.

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

![Šest editovatelných zlomků v PowerPointu. Horní řádek: plný rámeček, spodní a levá strana, ústupná diagonála. Dolní řádek: sestupná diagonála, horizontální přeškrtnutí, vertikální přeškrtnutí s plným rámečkem](border-box-fractions.png)

U tohoto zlomku se horizontální přeškrtnutí překrývá s pruhom zlomku. Vertikální přeškrtnutí protíná čitatel i jmenovatel, zatímco okolní rámeček zůstává viditelný. Tyto čáry ozdobí celý výraz. Běžné přeškrtnutí textu se vztahuje na znaky v textovém úseku. Po opětovném otevření prezentace v PowerPointu můžete i nadále samostatně upravovat čitatel i jmenovatel.

## **Řídit viditelnost a rozvržení pomocí phantom prvků**

Obalte výraz v [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/), aby jste řídili jeho viditelnost a prostor, který přispívá k rovnici, nezávisle. Metody [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) řídí následující:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | Předáním `false` skryjete výraz. Jeho rozměry stále přispívají k rozvržení, pokud níže uvedené metody nedostanou `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | Považuje vodorovnou šířku výrazu za nulu, což umožní sousedním prvkům se přiblížit. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | Považuje jeho výšku nad základní linii za nulu. To může snížit prostor nad sousedními prvky. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | Považuje jeho hloubku pod základní linii za nulu. To může posunout pruh zlomku nebo jiný obsah pod výraz blíže k sousedům. |

Základní linie je referenční čára, na které stojí běžné matematické znaky. Skrytí obsahu neodstraňuje jeho rozměry a považování rozměru za nulu neodstraňuje výraz. Podkladový výraz zůstává dostupný přes [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase). Předáním `true` metodě [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) jej opět zobrazíte; nastavení rozměrů zůstane nezměněno.

Níže uvedený příklad vytváří pět variant vedle sebe: viditelný zlomek, skrytý zlomek, který rezervuje místo, a tři skryté zlomky s jedním rozměrem nastaveným na nulu. Každá varianta používá stejný okolní výraz a Cambria Math o velikosti 24 pt. Všechny tvary rovnic mají stejnou horní pozici označenou šedým vodítkem. Umístění phantom prvku do čitatele vnějšího zlomku usnadňuje pozorování změn ve vertikálním rozvržení.

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

![Pět rovnic v PowerPointu porovnávající viditelný zlomek, skrytý zlomek, který rezervuje místo, a skryté zlomky s povoleným ZeroWidth, ZeroAsc nebo ZeroDesc](math-phantom.png)

## **Seskupit členy**

Použijte [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) k umístění seskupovacího znaku nad nebo pod výraz. Přidejte limitu pro označení seskupených členů.

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

## **Formátovat matematické prvky**

Používejte pomocníky formátování jen tam, kde objasňují vzorec. Například [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) umístí pruh nad matematický prvek.

![Matematický výraz ABC s přeškrtnutým pruhem nad ním](powerpoint-math-equations_14.png)

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

### **Formátovat text v existující rovnici**

Pro formátování textu v celé existující rovnici projděte strom prvků každého matematického bloku. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) vrací pouze okamžité potomky, takže jej zavolejte rekurzivně, abyste se dostali k textu uvnitř zlomků, skriptů, kořenů a dalších vnořených struktur. Kontrolujte aktuální prvek i jeho potomky, aby byl zahrnut i výchozí prvek, když je to [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Tento příklad předpokládá, že `input.pptx` obsahuje rovnici jako `z = xᵢ / ∛y`, se zlomkem obsahujícím dolní index v čitateli a kořenem v jmenovateli. Zpracování jen prvků nejvyšší úrovně bloku by minulo text uvnitř zlomku. Příklad najde matematické části v textových rámečcích snímků, získá jejich bloky přes [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a použije [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) k nastavení velikosti písma na 28 pt pro každý textový prvek pomocí jeho metody [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

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

Uložená prezentace obsahuje aktualizované formátování textu na každé úrovni každé zpracované rovnice, přičemž zachovává její textový obsah i matematickou strukturu.

## **Rychlý přehled**

| Task | Main API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Kombinovat prvky | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Vytvořit zlomky | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat horní nebo dolní index | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat kořeny | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat limity | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat skripty vlevo | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat sumace a integrály | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Přidat pole rovnic | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat ohraničovače | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Přidat pruhy a rámečky | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Seskupit členy | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **Často kladené otázky**

**Mohu editovat existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), zavolejte [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná PowerPointová matematika?**

Ano. Při uložení do PPTX Aspose.Slides zapisuje rovnici jako editovatelný obsah Office Math.

**Mohu exportovat rovnice do LaTeXu?**

Ano. Získejte [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) rovnice z jejího [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), a zavolejte [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) pro přímý export. Kompletní příklad najdete v [Export Math Equations from Presentations in Node.js via Java](/slides/cs/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).