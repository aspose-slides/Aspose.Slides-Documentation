---
title: "Exporteer wiskundige vergelijkingen uit presentaties in Java"
linktitle: "Exporteer vergelijkingen"
type: docs
weight: 30
url: /nl/java/exporting-math-equations/
keywords:
- "exporteer wiskundige vergelijkingen"
- "exporteer vergelijkingen naar LaTeX"
- "PowerPoint naar LaTeX"
- MathML
- LaTeX
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint‑presentaties rechtstreeks naar LaTeX of MathML met Aspose.Slides voor Java."
---
## **Inleiding**

Aspose.Slides stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet misschien de wiskundige vergelijkingen op dia&#39;s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="info" %}} 

U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in veel toepassingen wordt gebruikt.

{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking rechtstreeks converteren naar LaTeX; een tussenliggende MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [IMathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/). Gebruik [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/#getMathParagraph--) om een [IMathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph.toLatex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathparagraph/#toLatex--) aan. De methode retourneert een tekenreeks die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen of verder kunt verwerken.

Het volgende voorbeeld onderzoekt elk tekstvak op elke dia, vindt alle wiskundige delen en schrijft elke vergelijking naar een apart `.tex`‑bestand:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) retourneert alle tekstframes die op een dia worden gevonden. Het type‑checken van [IMathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documentsjablonen ondersteunen niet allemaal dezelfde commando&#39;s, pakketten of Unicode‑tekens. Test de geretourneerde tekenreeks met de LaTeX‑engine die uw toepassing gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervangt u het in de geretourneerde tekenreeks door een projectspecifiek commando of slaat u de vergelijking over en registreert u het probleem voor later onderzoek.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk de code kunnen schrijven voor sommige vergelijkingformaten zoals LaTeX, hebben ze moeite met het schrijven van de code voor MathML, omdat laatstgenoemde bedoeld is om automatisch door apps te worden gegenereerd. Programma&#39;s lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in vele vakgebieden. 

Deze voorbeeldcode toont hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**Wat wordt precies geëxporteerd naar MathML—een alinea of een individueel formuleblok?**

U kunt ofwel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathblock/)) exporteren naar MathML. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is in plaats van gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstonderdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML in een presentatie vandaan—een PowerPoint‑specifiek formaat of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML—de presentatiesubset van de standaard—die breed wordt toegepast in verschillende toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstonderdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.