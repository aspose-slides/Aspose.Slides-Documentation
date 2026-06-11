---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i JavaScript
linktitle: PowerPoint Matematiska Ekvationer
type: docs
weight: 80
url: /sv/nodejs-java/powerpoint-math-equations/
keywords:
- matematisk ekvation
- matematisk symbol
- matematisk formel
- matematisk text
- lägg till matematisk ekvation
- lägg till matematisk symbol
- lägg till matematisk formel
- lägg till matematisk text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för Node.js via Java, med stöd för OMML, formateringskontroller och tydliga JavaScript-exempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för Node.js via Java kan du programatiskt skapa samma typ av matematiskt innehåll: bråktal, rötter, funktioner, gränser, N-ära operatorer, matriser, arrayer och formaterade matematikblock.

I PowerPoint lägger användare normalt till ekvationer från **Infoga > Ekvation**:

![PowerPoint Flik Infoga med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint-bild som innehåller en redigerbar matematikekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiska texten genom tre huvudobjekt:

- En matematikform, skapad med [addMathShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addMathShape), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathportion/) lagrar matematiskt innehåll i formens textruta.
- [MathParagraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathblock/) objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathematicaltext/) och de flödesbaserade metoderna från [MathElementBase](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Exportera matteekvationer från presentationer i Node.js via Java](/slides/sv/nodejs-java/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en matematikform och lägger till Pythagoras sats:

![Ekvationen c kvadrat lika a kvadrat plus b kvadrat](powerpoint-math-equations_3.png)

```javascript
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

{{% alert color="primary" %}}
`addMathShape` skapar en form som redan innehåller ett matematikavsnitt. Hämta den första `MathPortion`, få dess `MathParagraph` och lägg till matematikblock eller math‑element i den.
{{% /alert %}}

## **Lägg till bråktal**

Använd [`divide`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för att skapa ett bråk. Du kan välja en bråkstil med [MathFractionTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathfractiontypes/).

![Ett snedställt matematiskt bråk som visar 1 delat med x](powerpoint-math-equations_4.png)

```javascript
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

För ett staplat bråk, använd `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Lägg till rötter**

Använd [`radical`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n:te rortuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

```javascript
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

## **Lägg till funktioner och gränser**

Använd [`asArgumentOfFunction`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) eller [`function`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för funktioner såsom `sin(x)`, `log(x)` eller egna funktionsnamn. För gränser, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathlimit/) eller använd [`setLowerLimit`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/).

![Gränsen för x när x närmar sig oändligheten](powerpoint-math-equations_8.png)

```javascript
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

För ett eget funktionsnamn, gör funktionsnamnet till det aktuella elementet:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Lägg till N-ära operatorer och integraler**

Använd [`nary`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för summor, unioner, snitt och andra stora operatorer. Använd [`integral`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för integraler. Båda metoderna låter dig ange lägre och övre gränser.

![En summa med lägre och övre gränser](powerpoint-math-equations_7.png)

```javascript
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

N-ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och sätts ihop i uttrycket.

För en integral, använd `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omslut matrisen när du behöver parenteser, hakparenteser eller måsvingar.

![En två‑raders matris med en tom cell](powerpoint-math-equations_10.png)

```javascript
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

Använd [`toMathArray`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matris med x ovanför y](powerpoint-math-equations_11.png)

```javascript
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

## **Lägg till trigonometriska funktioner**

Använd [`asArgumentOfFunction`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos tillämpad på 2x](powerpoint-math-equations_6.png)

```javascript
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

Använd hjälpfunktionerna för nedsänkta och upphöjda tecken för index och potenser. När indexen måste visas på vänster sida av basen, använd [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/).

![En versal Y med nedsänkt 1 på vänster sida och upphöjt n](powerpoint-math-equations_9.png)

```javascript
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

Använd [`enclose`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för att placera ett uttryck inom avgränsare. Du kan också ange ett separator‑tecken för avgränsningsuttryck som innehåller flera element.

![Ett avgränsningsuttryck som innehåller x, y och z separerade av vertikala streck](powerpoint-math-equations_13.png)

```javascript
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

## **Lägg till en ramruta**

Använd [`toBorderBox`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) när själva ekvationen ska ramas in.

![En inramad ekvation som visar a kvadrat lika b kvadrat plus c kvadrat](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gruppera termer**

Använd [`group`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) för att placera ett grupptecken ovanför eller under ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten någon text under](powerpoint-math-equations_15.png)

```javascript
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

Använd formateringshjälpmedel endast där de klargör formeln. Till exempel placerar [`overbar`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) ett streck över ett matematiskt element.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

```javascript
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

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa matematisk text | [MathematicalText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathematicaltext/) |
| Kombinera element | [join](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Skapa bråk | [divide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till upphöjt eller nedsänkt index | [setSuperscript](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till funktioner | [function](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till rötter | [radical](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till gränser | [setLowerLimit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till vänster‑sida script | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till summor och integraler | [nary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathmatrix/) |
| Lägg till ekvationsarrayer | [toMathArray](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till avgränsare | [enclose](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Lägg till streck och ramar | [overbar](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |
| Gruppera termer | [group](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera matematikblocken i det avsnittet.

**Sparas ekvationer som redigerbar PowerPoint‑matematik?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑matematikinnehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematikekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stödjer ditt mål‑LaTeX‑dialekt.