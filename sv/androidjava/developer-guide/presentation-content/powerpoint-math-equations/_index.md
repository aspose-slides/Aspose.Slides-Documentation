---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer på Android
linktitle: PowerPoint matematiska ekvationer
type: docs
weight: 80
url: /sv/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för Android, med stöd för OMML, formateringskontroller och tydliga Java-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för Android via Java kan du skapa samma typ av matematiskt innehåll programatiskt: bråk, rötter, funktioner, gränsvärden, N‑ära operatorer, matriser, arrayer och formaterade matematikblock.

I PowerPoint lägger användare normalt till ekvationer via **Infoga > Ekvation**:

![PowerPoint‑fliken Infoga med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet blir redigerbar mattext på bilden:

![En PowerPoint‑bild som innehåller en redigerbar matematikekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den mattexten genom tre huvudobjekt:

- En matform, skapad med [addMathShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathportion/) lagrar matematiskt innehåll i formens textram.
- [MathParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathparagraph/) innehåller en eller flera [MathBlock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathematicaltext/) och de flytande metoderna från [IMathElement](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Export Math Equations from Presentations on Android](/slides/sv/androidjava/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en matform och lägger till Pythagoras sats:

![Ekvationen c² = a² + b²](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

`addMathShape` skapar en form som redan innehåller ett mat‑paragraf. Få åtkomst till den första `MathPortion`, hämta dess `MathParagraph` och lägg till mat‑block eller mat‑element i den.

{{% /alert %}}

## **Lägg till bråk**

Använd `divide` för att skapa ett bråk. Du kan välja bråktyp med [MathFractionTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathfractiontypes/).

![Ett snett matematiskt bråk som visar ett dividerat med x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För ett staplat bråk, använd `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Lägg till rötter**

Använd `radical` för att skapa en kvadratrot, kubikrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n‑te rotuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till funktioner och gränsvärden**

Använd `asArgumentOfFunction` eller `function` för funktioner såsom `sin(x)`, `log(x)` eller egna funktionsnamn. För gränsvärden, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathlimit/) eller använd `setLowerLimit`.

![Gränsvärdet för x när x närmar sig oändligheten](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För ett eget funktionsnamn, gör funktionsnamnet till det aktuella elementet:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Lägg till N‑ära operatorer och integraler**

Använd `nary` för summor, unioner, snitt och andra stora operatorer. Använd `integral` för integraler. Båda metoderna låter dig ange nedre och övre gränser.

![En summa med nedre och övre gränser](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N‑ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och sammanfogas i uttrycket.

För en integral, använd `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathmatrix/) för rader och kolumner. Matriser inkluderar inte klamrar som standard, så omge matrisen med parenteser, hakparenteser eller måsvingar när du behöver dem.

![En matris med två rader och en tom cell](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till ekvationsarrayer**

Använd `toMathArray` när du behöver justerade ekvationer eller en vertikal stapling av uttryck.

![En vertikal matris med x över y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till trigonometriska funktioner**

Använd `asArgumentOfFunction` när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos applicerad på 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till index och exponenter**

Använd hjälpfunktionerna för index och exponenter. När indexen måste visas på vänster sida om basen, använd `setSubSuperscriptOnTheLeft`.

![En stor bokstav Y med vänster‑sida index 1 och exponent n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till avgränsare**

Använd `enclose` för att placera ett uttryck inom avgränsare. Du kan även ange ett separations­tecken för avgränsningsexpressioner som innehåller flera element.

![En avgränsnings­expression som innehåller x, y och z avgränsade med vertikala streck](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till en ramruta**

Använd `toBorderBox` när ekvationen själv ska rammas in.

![En inramad ekvation som visar c² = b² + a²](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gruppera termer**

Använd `group` för att placera ett grupperings­tecken ovanför eller nedanför ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x + y grupperat med etiketten någon text under](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatera matematiska element**

Använd formateringshjälpmedel bara där de klargör formeln. Till exempel placerar `overbar` ett streck ovanför ett matematiskt element.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa mattext | [MathematicalText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathematicaltext/) |
| Kombinera element | [IMathElement.join](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Skapa bråk | [IMathElement.divide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till exponent eller index | [setSuperscript](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till funktioner | [function](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till rötter | [IMathElement.radical](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till gränsvärden | [setLowerLimit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till vänster‑sida skript | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till summor och integraler | [nary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/mathmatrix/) |
| Lägg till ekvationsarrayer | [toMathArray](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till avgränsare | [enclose](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Lägg till streck och ramar | [overbar](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |
| Gruppera termer | [group](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imathelement/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta den form som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera mat‑blocken i det paragrafen.

**Sparas ekvationer som redigerbar PowerPoint‑mat?**

Ja. När du sparar som PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑matinnehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematikekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stödjer ditt mål‑LaTeX‑dialekt.