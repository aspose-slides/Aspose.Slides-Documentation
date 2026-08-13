---
title: Wiskundige vergelijkingen toevoegen aan PowerPoint-presentaties op Android
linktitle: PowerPoint-wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Wiskundige vergelijkingen invoegen en bewerken in PowerPoint PPT en PPTX met Aspose.Slides voor Android, met ondersteuning voor OMML, opmaakopties en duidelijke Java-codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides voor Android via Java kunt u hetzelfde soort wiskundige inhoud programmatic creëren: breuken, wortels, functies, limieten, N‑ary‑operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen in via **Insert > Equation**:

![PowerPoint-invoegtabblad met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint-dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [addMathShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathportion/) slaat wiskundige inhoud op in het tekstvak van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) bevat een of meer [MathBlock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathblock/) objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathematicaltext/) en de fluente methoden van [IMathElement](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) om de code kort en leesbaar te houden.

Voor MathML‑exportsituaties, zie [Export Math Equations from Presentations on Android](/slides/nl/androidjava/exporting-math-equations/).

## **Een vergelijking maken**

Dit voorbeeld maakt een wiskundige vorm en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
`addMathShape` maakt een vorm die al een wiskundige alinea bevat. Verkrijg de eerste `MathPortion`, haal de bijbehorende `MathParagraph` op en voeg wiskundige blokken of wiskundige elementen toe.
{{% /alert %}}

## **Breuken toevoegen**

Gebruik `divide` om een breuk te maken. U kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathfractiontypes/).

![Een scheve wiskundige breuk die 1 gedeeld door x toont](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

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

Voor een gestapelde breuk, gebruik `MathFractionTypes.Bar`:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Radicalen toevoegen**

Gebruik `radical` om een vierkantswortel, kubuswortel of een andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n‑de wortel uitdrukking met x onder het radicaalteken](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

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

## **Functies en limieten toevoegen**

Gebruik `asArgumentOfFunction` of `function` voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten zet u `lim` in een [MathLimit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathlimit/) of gebruik `setLowerLimit`.

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

Voor een aangepaste functienaam maakt u de functienaam het huidige element:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N‑ary operatoren en integralen toevoegen**

Gebruik `nary` voor sommaties, unies, doorsnedes en andere grote operatoren. Gebruik `integral` voor integralen. Beide methoden laten u onder‑ en bovengrenzen instellen.

![Een sommatie met onder‑ en bovengrens](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

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

N‑ary‑operatoren zijn bedoeld voor grote operatoren met optionele grenzen. Simpele operatoren zoals `+`, `-` en `=` worden meestal toegevoegd als `MathematicalText` en aan de expressie gekoppeld.

Voor een integraal, gebruik `integral`:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrices toevoegen**

Gebruik [MathMatrix](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omkader de matrix wanneer u haakjes, vierkante haken of accolades nodig hebt.

![Een wiskundige matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

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

## **Vergelijkingsarrays toevoegen**

Gebruik `toMathArray` wanneer u uitgelijnde vergelijkingen of een verticale stapel uitdrukkingen nodig heeft.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

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

## **Trigonometische functies toevoegen**

Gebruik `asArgumentOfFunction` wanneer het argument het huidige element is en de functienaam bekend is.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

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

## **Subscript en superscript toevoegen**

Gebruik de subscript‑ en superscript‑helpers voor indexen en machten. Wanneer de indexen links van de basis moeten verschijnen, gebruik `setSubSuperscriptOnTheLeft`.

![Een hoofdletter Y met links een subscript 1 en een superscript n](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

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

## **Delimiteren toevoegen**

Gebruik `enclose` om een expressie tussen delimiters te plaatsen. U kunt ook een scheidingsteken instellen voor delimiter‑expressies die meerdere elementen bevatten.

![Een delimiter‑expressie met x, y en z gescheiden door verticale balken](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

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

## **Een randvak toevoegen**

Gebruik `toBorderBox` wanneer de vergelijking zelf omlijnd moet worden.

![Een omkaderde vergelijking met a² = b² + c²](powerpoint-math-equations_12.png)

```java
import com.aspose.slides.*;

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

## **Termen groeperen**

Gebruik `group` om een groeperingssymbool boven of onder een expressie te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De expressie x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

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

## **Wiskundige elementen opmaken**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, `overbar` plaatst een balk boven een wiskundig element.

![Een wiskundige expressie ABC met een overstreep](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

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

## **Snelle referentie**

| Taak | Hoofd‑API |
| --- | --- |
| Wiskundige tekst maken | [MathematicalText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathematicaltext/) |
| Elementen combineren | [IMathElement.join](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Breuken maken | [IMathElement.divide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Superscript of subscript toevoegen | [setSuperscript](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Functies toevoegen | [function](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Radicalen toevoegen | [IMathElement.radical](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Limieten toevoegen | [setLowerLimit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Links geplaatste scripts toevoegen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Sommaties en integralen toevoegen | [nary](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Matrices toevoegen | [MathMatrix](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathmatrix/) |
| Vergelijkingsarrays toevoegen | [toMathArray](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Delimiteren toevoegen | [enclose](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Strepen en randen toevoegen | [overbar](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |
| Termen groeperen | [group](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathelement/) |

## **Veelgestelde vragen**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, zoek de vorm die een `MathPortion` bevat, haal de bijbehorende `MathParagraph` op en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer u opslaat naar PPTX, schrijft Aspose.Slides de vergelijking weg als bewerkbare Office‑wiskundige inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal de [IMathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/) van de [IMathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/) op en roep [IMathParagraph.toLatex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/#toLatex--) aan om deze direct te exporteren. Voor een volledig voorbeeld, zie [Export Math Equations from Presentations in Android via Java](/slides/nl/androidjava/exporting-math-equations/#export-math-equations-to-latex).