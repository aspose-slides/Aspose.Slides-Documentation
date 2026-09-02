---
title: Wiskundige vergelijkingen exporteren uit presentaties in PHP
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/php-java/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- vergelijkingen exporteren naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint‑presentaties rechtstreeks naar LaTeX of MathML met Aspose.Slides voor PHP via Java."
---
## **Introductie**

Aspose.Slides for PHP via Java maakt het mogelijk om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="primary" %}} 

U kunt vergelijkingen rechtstreeks naar LaTeX of naar MathML exporteren, een veelgebruikt standaardformaat voor wiskundige inhoud op het web en in tal van applicaties.

{{% /alert %}}

## **Exporteer wiskundige vergelijkingen naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking direct omzetten naar LaTeX; een tussentijds MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/). Gebruik [MathPortion::getMathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/#getMathParagraph) om een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) op te halen, en roep vervolgens [MathParagraph::toLatex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/#toLatex) aan. De methode retourneert een tekenreeks die u kunt opslaan, weergeven, naar een andere applicatie sturen of verder verwerken.

Het volgende voorbeeld doorloopt elk tekstvak op elke dia, vindt alle wiskundige delen en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#getAllTextBoxes) retourneert alle tekstvakken die op een dia zijn gevonden. Het type‑checken van [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde tekenreeks met de LaTeX‑engine die uw applicatie gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervangt u het in de geretourneerde tekenreeks door een projectspecifiek commando of slaat u de vergelijking over en noteert u het probleem voor nadere controle.

## **Sla wiskundige vergelijkingen op als MathML**

Hoewel mensen gemakkelijk de code voor sommige formaat­vergelijkingen zoals LaTeX kunnen schrijven, vinden ze het moeilijk om de code voor MathML te schrijven omdat dit laatste bedoeld is om automatisch door apps te worden gegenereerd. Programma’s lezen en parseren MathML moeiteloos omdat de code in XML staat, zodat MathML vaak wordt gebruikt als output‑ en afdrukformaat in vele vakgebieden.

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

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

**Wat wordt er precies geëxporteerd naar MathML – een alinea of een afzonderlijk formulesegment?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/)) als een afzonderlijk segment ([MathBlock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathblock/)) exporteren naar MathML. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) kunnen niet als formules geëxporteerd worden.

**Waar komt de MathML vandaan in een presentatie – is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML – het presentatiesubset van de standaard – dat breed wordt toegepast in allerlei applicaties en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mathparagraph/) (dat wil zeggen echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.