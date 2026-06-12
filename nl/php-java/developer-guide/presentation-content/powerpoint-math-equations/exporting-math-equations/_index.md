---
title: Exporteer wiskundige vergelijkingen uit presentaties in PHP
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/php-java/exporting-math-equations/
keywords:
- exporteer wiskundige vergelijkingen
- MathML
- LaTeX
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontgrendel naadloze export van wiskundige vergelijkingen van PowerPoint naar MathML met Aspose.Slides voor PHP via Java — behoud de opmaak en vergroot de compatibiliteit."
---
## **Introductie**

Aspose.Slides for PHP via Java maakt het mogelijk om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="primary" %}} 
U kunt vergelijkingen exporteren naar MathML, een populair formaat of standaard voor wiskundige vergelijkingen en soortgelijke inhoud die op het web en in veel applicaties wordt gezien. 
{{% /alert %}}

## **Bewaar wiskundige vergelijkingen als MathML**

Hoewel mensen gemakkelijk de code voor sommige vergelijkingsformaten zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML, omdat die laatste bedoeld is om automatisch door apps gegenereerd te worden. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

Deze voorbeeldcode toont hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat wordt er precies geëxporteerd naar MathML — een alinea of een afzonderlijk formuleblok?**

U kunt ofwel een volledige wiskunde‑alinea ([MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskunde‑formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstporties zonder een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML vandaan in een presentatie — is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatiesubset van de standaard — die breed wordt toegepast in applicaties en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstporties bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) (dat wil zeggen echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de originele presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het verandert het presentatie‑bestand niet.