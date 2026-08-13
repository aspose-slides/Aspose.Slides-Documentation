---
title: Exporteren van wiskundige vergelijkingen uit presentaties op Android
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/androidjava/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- vergelijkingen exporteren naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties naar LaTeX of MathML rechtstreeks met Aspose.Slides voor Android via Java."
---
## **Introductie**

Aspose.Slides voor Android via Java stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="info" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in veel toepassingen wordt gebruikt.
{{% /alert %}}

## **Exporteer wiskundige vergelijkingen naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking rechtstreeks naar LaTeX converteren; een tussenliggende MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [IMathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/). Gebruik [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) om een [IMathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/) op te halen, en roep vervolgens [IMathParagraph.toLatex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/#toLatex--). De methode geeft een tekenreeks terug die u kunt opslaan, weergeven, naar een andere applicatie kunt sturen of verder kunt verwerken.

Het volgende voorbeeld doorzoekt elk tekstvak op elke dia, vindt alle wiskundige gedeelten en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) retourneert alle tekstvakken die op een dia worden gevonden. De type‑controle van [IMathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de teruggegeven tekenreeks met de LaTeX‑engine die uw applicatie gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het in de teruggegeven tekenreeks door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor later onderzoek.

## **Bewaar wiskundige vergelijkingen als MathML**

Hoewel mensen gemakkelijk de code voor sommige vergelijkingformaten zoals LaTeX kunnen schrijven, vinden ze het moeilijk om de code voor MathML te schrijven, omdat laatstgenoemde bedoeld is om automatisch door applicaties te worden gegenereerd. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

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

## **FAQ**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een afzonderlijk formulesegment?**

U kunt ofwel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/)) of een afzonderlijk blok ([MathBlock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en niet gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML in een presentatie vandaan—is het PowerPoint‑specifiek of een standaard?**

De export richt zich op de standaard MathML (XML). Aspose gebruikt Presentation MathML—de presentatiesubset van de standaard—die breed wordt toegepast in verschillende applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.