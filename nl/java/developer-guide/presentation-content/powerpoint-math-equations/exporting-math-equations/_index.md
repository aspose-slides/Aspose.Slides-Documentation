---
title: Wiskundige vergelijkingen exporteren uit presentaties in Java
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/java/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- vergelijkingen exporteren naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties direct naar LaTeX of MathML met Aspose.Slides voor Java."
---
## **Inleiding**

Aspose.Slides stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en ze gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in vele toepassingen wordt gebruikt.
{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint-wiskundige vergelijking rechtstreeks naar LaTeX converteren; een tussenliggende MathML-bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstframe als een [IMathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/). Gebruik [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/#getMathParagraph--) om een [IMathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph.toLatex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathparagraph/#toLatex--) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere applicatie sturen of verder verwerken.

Het volgende voorbeeld onderzoekt elk tekstframe op elke dia, vindt alle wiskundige delen, en schrijft elke vergelijking naar een afzonderlijk `.tex`-bestand:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) retourneert alle tekstframes die op een dia gevonden worden. De type-controle van [IMathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX-engines en documenttemplates ondersteunen niet allemaal dezelfde commando's, pakketten of Unicode-tekens. Test de geretourneerde string met de LaTeX-engine die door uw applicatie wordt gebruikt. Als een symbool of Office-Math-element geen geschikte weergave heeft in die omgeving, vervang het in de geretourneerde string door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor later onderzoek.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk de code kunnen schrijven voor sommige vergelijkingsformaten zoals LaTeX, hebben ze moeite met het schrijven van de code voor MathML omdat dat laatste bedoeld is om automatisch door applicaties te worden gegenereerd. Programma's lezen en parseren MathML gemakkelijk omdat de code in XML staat, waardoor MathML doorgaans wordt gebruikt als een uitvoer- en afdrukformaat in vele vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formuleblok?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/)) als een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) kunnen niet als formules worden geëxporteerd.

**Waar komt de MathML in een presentatie vandaan—is het PowerPoint-specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — het presentatiesubset van de standaard — dat breed wordt toegepast in diverse applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint-formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatiebestand niet.