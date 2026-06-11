---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i PHP
linktitle: PowerPoint matematiska ekvationer
type: docs
weight: 80
url: /sv/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för PHP via Java, med stöd för OMML, formateringskontroller och tydliga PHP-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för PHP via Java kan du programatiskt skapa samma typ av matematiskt innehåll: bråk, radikaler, funktioner, gränsvärden, N‑ära operatorer, matriser, arrayer och formaterade matematiska block.

I PowerPoint lägger användare normalt till ekvationer från **Insert > Equation**:

![PowerPoint Infoga-flik med kommandot Equation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar mattetext på bilden:

![En PowerPoint-bild som innehåller en redigerbar matematikekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den mattetexten genom tre huvudsakliga objekt:

- En matematikform, skapat med [addMathShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addMathShape), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/) lagrar matematiskt innehåll i formens textruta.
- [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathematicaltext/) och de flödande metoderna från [MathElementBase](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Export Math Equations from Presentations in PHP via Java](/slides/sv/php-java/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en matematikform och lägger till Pythagoras sats:

![Ekvationen c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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
`addMathShape` skapar en form som redan innehåller ett matematiskt stycke. Hämta den första `MathPortion`, få dess `MathParagraph` och lägg till matematiska block eller element i den.
{{% /alert %}}

## **Lägg till bråktal**

Använd [`divide`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för att skapa ett bråk. Du kan välja en bråkstil med [MathFractionTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathfractiontypes/).

![Ett snedvridet matematiskt bråk som visar ett delat med x](powerpoint-math-equations_4.png)

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

För ett staplat bråk, använd `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Lägg till radikaler**

Använd [`radical`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n‑te röttrakn uttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

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

## **Lägg till funktioner och gränsvärden**

Använd [`asArgumentOfFunction`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) eller [`function`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för funktioner såsom `sin(x)`, `log(x)` eller anpassade funktionsnamn. För gränsvärden, sätt `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathlimit/) eller använd [`setLowerLimit`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/).

![Gränsvärdet för x när x går mot oändligheten](powerpoint-math-equations_8.png)

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

För ett anpassat funktionsnamn, gör funktionsnamnet till det aktuella elementet:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Lägg till N‑ära operatorer och integraler**

Använd [`nary`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för summor, unioner, snitt och andra stora operatorer. Använd [`integral`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för integraler. Båda metoderna låter dig ange lägre och högre gränser.

![En summa med lägre och högre gränser](powerpoint-math-equations_7.png)

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

N‑ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och förenas i uttrycket.

För en integral, använd `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrisen när du behöver parenteser, hakparenteser eller måsvingar.

![En matris med två rader och en tom cell](powerpoint-math-equations_10.png)

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

## **Lägg till ekvationsarrayer**

Använd [`toMathArray`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matematisk matris med x ovanför y](powerpoint-math-equations_11.png)

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

## **Lägg till trigonometriska funktioner**

Använd [`asArgumentOfFunction`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos applicerad på 2x](powerpoint-math-equations_6.png)

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

## **Lägg till nedsänkta och upphöjda**

Använd hjälpmetoderna för nedsänkta och upphöjda index för indeks och potenser. När indexen måste visas på vänster sida av basen, använd [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/).

![En stor bokstav Y med nedsänkt index 1 på vänster sida och upphöjt n](powerpoint-math-equations_9.png)

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

## **Lägg till avgränsare**

Använd [`enclose`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för att placera ett uttryck inom avgränsare. Du kan också ange ett separator‑tecken för avgränsningsuttryck som innehåller flera element.

![Ett avgränsningsuttryck som innehåller x, y och z separerade med vertikala streck](powerpoint-math-equations_13.png)

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

## **Lägg till en ramruta**

Använd [`toBorderBox`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) när ekvationen själv ska ramas in.

![En inramad ekvation som visar a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

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

## **Gruppera termer**

Använd [`group`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) för att placera ett grupperingstecken ovanför eller nedanför ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten vilken text som helst nedanför](powerpoint-math-equations_15.png)

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

## **Formatera matematiska element**

Använd formateringshjälpmedel endast där de tydliggör formeln. Till exempel placerar [`overbar`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) en linje ovanför ett matematiskt element.

![Ett matematiskt uttryck ABC med en överlinje](powerpoint-math-equations_14.png)

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

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa mattetext | [MathematicalText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathematicaltext/) |
| Kombinera element | [join](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Skapa bråk | [divide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till upphöjt eller nedsänkt | [setSuperscript](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till funktioner | [function](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till radikaler | [radical](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till gränsvärden | [setLowerLimit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till skript på vänster sida | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till summationer och integraler | [nary](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathmatrix/) |
| Lägg till ekvationsarrayer | [toMathArray](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till avgränsare | [enclose](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Lägg till streck och ramar | [overbar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |
| Gruppera termer | [group](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathelementbase/) |

## **Vanliga frågor**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera de matematiska blocken i det stycket.

**Sparas ekvationer som redigerbar PowerPoint‑matematik?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑matematikinnehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematiska ekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stödjer ditt målspråk för LaTeX.