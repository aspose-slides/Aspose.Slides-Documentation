---
title: Voeg wiskundige vergelijkingen toe aan PowerPoint‑presentaties in PHP
linktitle: PowerPoint‑wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Voeg wiskundige vergelijkingen in PowerPoint PPT en PPTX in en bewerk ze met Aspose.Slides voor PHP via Java, met ondersteuning voor OMML, opmaakbesturingen en duidelijke PHP‑codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides voor PHP via Java kun je hetzelfde type wiskundige inhoud programmatically aanmaken: breuken, wortels, functies, limieten, N-ary operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Insert > Equation**:

![PowerPoint Insert-tab met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint-dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundevorm, gemaakt met [addMathShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addMathShape), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/) slaat wiskundige inhoud op in het tekstkader van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) bevat een of meer [MathBlock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathblock/) objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathematicaltext/) en de fluente methoden van [MathElementBase](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) om de code kort en leesbaar te houden.

Voor MathML-exportscenario's, zie [Export Math Equations from Presentations in PHP via Java](/slides/nl/php-java/exporting-math-equations/).

## **Een vergelijking maken**

Dit voorbeeld maakt een wiskundevorm aan en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` maakt een vorm die al een wiskundig alinea bevat. Toegang tot de eerste `MathPortion`, verkrijg zijn `MathParagraph` en voeg wiskundige blokken of wiskundige elementen toe.
{{% /alert %}}

## **Breuken toevoegen**

Gebruik [`divide`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x toont](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Voor een gestapelde breuk, gebruik `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Radicalen toevoegen**

Gebruik [`radical`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) om een vierkantswortel, derdemachtswortel of andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n-de machtswortel met x onder het wortelteken](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Functies en limieten toevoegen**

Gebruik [`asArgumentOfFunction`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) of [`function`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) voor functies zoals `sin(x)`, `log(x)`, of aangepaste functienamen. Voor limieten, plaats `lim` in een [MathLimit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathlimit/) of gebruik [`setLowerLimit`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/).

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Voor een aangepaste functienaam, maak de functienaam het huidige element:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary operatoren en integralen toevoegen**

Gebruik [`nary`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) voor sommaties, unies, doorsneden en andere grote operatoren. Gebruik [`integral`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) voor integralen. Beide methoden laten je onder- en bovengrenzen instellen.

![Een sommatie met onder- en bovengrens](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N-ary operatoren zijn voor grote operatoren met optionele grenzen. Simpele operatoren zoals `+`, `-` en `=` worden meestal als `MathematicalText` toegevoegd en aan de uitdrukking gekoppeld.

Voor een integraal, gebruik `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matrices toevoegen**

Gebruik [MathMatrix](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omring de matrix wanneer je ronde haakjes, vierkante haken of accolades nodig hebt.

![Een matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Vergelijkingsarrays toevoegen**

Gebruik [`toMathArray`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) wanneer je uitgelijnde vergelijkingen of een verticale stapel uitdrukkingen nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Trigonometrische functies toevoegen**

Gebruik [`asArgumentOfFunction`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) wanneer het argument het huidige element is en de functienaam bekend is.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Subscript- en superscript-tekens toevoegen**

Gebruik de subscript- en superscript-hulpmiddelen voor indexen en machtsverheffingen. Wanneer de indexen aan de linkerkant van de basis moeten verschijnen, gebruik [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/).

![Een hoofdletter Y met links subscript 1 en superscript n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Scheidingstekens toevoegen**

Gebruik [`enclose`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) om een uitdrukking binnen scheidingstekens te plaatsen. Je kunt ook een scheidingsteken definiëren voor delimiter-uitdrukkingen die meerdere elementen bevatten.

![Een delimiter-uitdrukking met x, y en z gescheiden door verticale strepen](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Een randvak toevoegen**

Gebruik [`toBorderBox`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) wanneer de vergelijking zelf moet worden omlijst.

![Een ingekaderde vergelijking die a kwadraat gelijk b kwadraat plus c kwadraat toont](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Termen groeperen**

Gebruik [`group`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) om een groepeerteken boven of onder een uitdrukking te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De uitdrukking x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Wiskundige elementen opmaken**

Gebruik opmaak-hulpmiddelen alleen waar ze de formule verduidelijken. Bijvoorbeeld, [`overbar`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) plaatst een balk boven een wiskundig element.

![Een wiskundige uitdrukking ABC met een overbalk](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Snelreferentie**

| Taak | Hoofd-API |
| --- | --- |
| Wiskundige tekst maken | [MathematicalText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathematicaltext/) |
| Elementen combineren | [join](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Breuken maken | [divide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Superscript of subscript toevoegen | [setSuperscript](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Functies toevoegen | [function](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Radicalen toevoegen | [radical](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Limieten toevoegen | [setLowerLimit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Scripts aan de linkerkant toevoegen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Sommaties en integralen toevoegen | [nary](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Matrices toevoegen | [MathMatrix](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathmatrix/) |
| Vergelijkingsarrays toevoegen | [toMathArray](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Scheidingstekens toevoegen | [enclose](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Balken en randen toevoegen | [overbar](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |
| Termen groeperen | [group](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, zoek de vorm die een `MathPortion` bevat, haal het `MathParagraph` op en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer je opslaat naar PPTX, schrijft Aspose.Slides de vergelijking weg als bewerkbare Office‑wiskunde‑inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal het [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) van de [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/) op, en roep [MathParagraph::toLatex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/#toLatex) aan om het direct te exporteren. Voor een volledig voorbeeld, zie [Export Math Equations from Presentations in PHP via Java](/slides/nl/php-java/exporting-math-equations/#export-math-equations-to-latex).