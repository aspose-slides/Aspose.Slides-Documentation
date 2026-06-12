---
title: Wiskundige vergelijkingen toevoegen aan PowerPoint-presentaties in Java
linktitle: PowerPoint-wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Wiskundige vergelijkingen invoegen en bewerken in PowerPoint PPT en PPTX met Aspose.Slides voor Java, met ondersteuning voor OMML, opmaakbesturingen en duidelijke Java-codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides for Java kunt u dezelfde soort wiskundige inhoud programmatisch creëren: breuken, wortels, functies, limieten, N‑aire operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Invoegen > Vergelijking**:

![PowerPoint‑invoegtabblad met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint‑dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst op met drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [addMathShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathportion/) slaat wiskundige inhoud op binnen het tekstkader van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) bevat een of meer [MathBlock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathblock/)-objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathematicaltext/) en de fluent‑methoden van [IMathElement](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/) om de code kort en leesbaar te houden.

Voor MathML‑exportsituaties, zie [Exporteer wiskundige vergelijkingen uit presentaties in Java](/slides/nl/java/exporting-math-equations/).

## **Maak een vergelijking**

Dit voorbeeld maakt een wiskundige vorm aan en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` maakt een vorm aan die al een wiskundige alinea bevat. Toegang tot de eerste `MathPortion`, haal de `MathParagraph` op, en voeg wiskundige blokken of wiskunde‑elementen toe.
{{% /alert %}}

## **Voeg breuken toe**

Gebruik `divide` om een breuk te maken. U kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x weergeeft](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Voeg wortels toe**

Gebruik `radical` om een vierkantswortel, kubieke wortel of andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n‑de machtswortel met x onder het wortelteken](powerpoint-math-equations_5.png)

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

## **Voeg functies en limieten toe**

Gebruik `asArgumentOfFunction` of `function` voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten zet `lim` in een [MathLimit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathlimit/) of gebruik `setLowerLimit`.

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor een aangepaste functienaam, maak de functienaam het huidige element:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Voeg N‑aire operatoren en integralen toe**

Gebruik `nary` voor sommaties, unies, intersecties en andere grote operatoren. Gebruik `integral` voor integralen. Beide methoden laten u onder‑ en bovengrenzen instellen.

![Een som met onder- en bovengrens](powerpoint-math-equations_7.png)

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

N‑aire operatoren zijn bedoeld voor grote operatoren met optionele limieten. Simpele operatoren zoals `+`, `-` en `=` worden gewoonlijk toegevoegd als `MathematicalText` en in de expressie gekoppeld.

Voor een integraal, gebruik `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Voeg matrices toe**

Gebruik [MathMatrix](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omring de matrix met haakjes, vierkante haken of accolades wanneer dat nodig is.

![Een wiskundige matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

## **Voeg vergelijkings‑arrays toe**

Gebruik `toMathArray` wanneer u uitgelijnde vergelijkingen of een verticale stapel expressies nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

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

## **Voeg trigonometrische functies toe**

Gebruik `asArgumentOfFunction` wanneer het argument het huidige element is en de functienaam bekend.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

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

## **Voeg subscripten en superscripten toe**

Gebruik de hulpprogramma’s voor subscripten en superscripten voor indexen en machten. Wanneer de indexen links van de basis moeten staan, gebruik `setSubSuperscriptOnTheLeft`.

![Een hoofdletter Y met subscripte 1 en superscripte n aan de linkerkant](powerpoint-math-equations_9.png)

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

## **Voeg scheidingstekens toe**

Gebruik `enclose` om een expressie tussen scheidingstekens te plaatsen. U kunt ook een scheidingsteken‑teken zetten voor expressies die meerdere elementen bevatten.

![Een scheidingstekenexpressie met x, y en z gescheiden door verticale staven](powerpoint-math-equations_13.png)

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

## **Voeg een randvak toe**

Gebruik `toBorderBox` wanneer de vergelijking zelf omlijst moet worden.

![Een ingekaderde vergelijking die a² = b² + c² toont](powerpoint-math-equations_12.png)

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

## **Groepeer termen**

Gebruik `group` om een groeperingskarakter boven‑ of onder een expressie te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De expressie x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

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

## **Formatteer wiskunde‑elementen**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, `overbar` plaatst een streep boven een wiskundig element.

![Een wiskundige expressie ABC met een overstreep](powerpoint-math-equations_14.png)

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

## **Snelle referentie**

| Taak | Hoofd‑API |
| --- | --- |
| Maak wiskundige tekst | [MathematicalText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathematicaltext/) |
| Combineer elementen | [IMathElement.join](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Maak breuken | [IMathElement.divide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Voeg superscript of subscript toe | [setSuperscript](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Voeg functies toe | [function](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Voeg wortels toe | [IMathElement.radical](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Voeg limieten toe | [setLowerLimit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Voeg linkse scripts toe | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Voeg sommaties en integralen toe | [nary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Voeg matrices toe | [MathMatrix](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathmatrix/) |
| Voeg vergelijkings‑arrays toe | [toMathArray](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#toMathArray--) |
| Voeg scheidingstekens toe | [enclose](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Voeg streepjes en randen toe | [overbar](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Groepeer termen | [group](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, zoek de vorm die een `MathPortion` bevat, haal de `MathParagraph` op, en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer u opslaat als PPTX, schrijft Aspose.Slides de vergelijking weg als bewerkbare Office‑wiskundige inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Aspose.Slides exporteert wiskundige vergelijkingen naar MathML. Als u LaTeX nodig heeft, exporteer eerst naar MathML en converteer vervolgens MathML met een tool die uw gewenste LaTeX‑dialect ondersteunt.