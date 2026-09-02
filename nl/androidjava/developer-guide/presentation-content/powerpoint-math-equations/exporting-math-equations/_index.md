---
title: Wiskundige vergelijkingen exporteren vanuit presentaties op Android
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
## **Inleiding**

Aspose.Slides for Android via Java stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt mogelijk de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="primary" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een veelgebruikte standaard voor wiskundige inhoud op het web en in tal van toepassingen.
{{% /alert %}}

## **Exporteer wiskundige vergelijkingen naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskunde‑vergelijking direct naar LaTeX converteren; een tussenliggende MathML‑file en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [IMathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/). Gebruik [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) om een [IMathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph.toLatex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathparagraph/#toLatex--) aan. De methode levert een string op die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen of verder verwerken.

Het volgende voorbeeld doorloopt elk tekstvak op elke dia, zoekt alle wiskundige delen en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) geeft alle tekstvakken terug die op een dia zijn gevonden. Het type‑checken van [IMathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documentsjablonen ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die uw toepassing gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het in de geretourneerde string door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor later onderzoek.

## **Opslaan van wiskundige vergelijkingen als MathML**

Hoewel mensen de code voor sommige vergelijkingsformaten zoals LaTeX eenvoudig kunnen schrijven, vinden ze het lastig om de code voor MathML te schrijven omdat laatstgenoemde bedoeld is om automatisch door apps te worden gegenereerd. Programma’s lezen en parseren MathML gemakkelijk omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑‑ en afdrukformaat in vele vakgebieden.

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie naar MathML exporteert:

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

## **FAQ**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formuleblok?**

U kunt ofwel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstonderdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML in een presentatie vandaan—een PowerPoint‑specifiek formaat of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatiesubset van de standaard — die breed wordt toegepast in toepassingen en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstonderdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingevoegd, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatiedocument niet.