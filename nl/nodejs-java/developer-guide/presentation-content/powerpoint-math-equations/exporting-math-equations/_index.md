---
title: Exporteer wiskundige vergelijkingen uit presentaties in JavaScript
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/nodejs-java/exporting-math-equations/
keywords:
- exporteer wiskundige vergelijkingen
- exporteer vergelijkingen naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties naar LaTeX of MathML rechtstreeks met Aspose.Slides voor Node.js via Java."
---
## **Inleiding**

Aspose.Slides maakt het mogelijk wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt mogelijk de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en ze gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 

U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een veelgebruikte standaard voor wiskundige inhoud op het web en in vele toepassingen.

{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskunde‑vergelijking direct naar LaTeX converteren; een tussenliggende MathML‑file en een externe converter zijn niet nodig. Een wiskunde‑vergelijking wordt opgeslagen in een tekstvak als een [MathPortion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathportion/). Gebruik [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) om een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/) op te halen, en roep vervolgens [MathParagraph.toLatex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/#toLatex--) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen of verder kunt verwerken.

Het volgende voorbeeld doorloopt elk tekstvak op elke dia, vindt alle wiskunde‑porties en schrijft elke vergelijking naar een apart `.tex`‑bestand:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) retourneert alle tekstvakken die op een dia worden gevonden. De [MathPortion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathportion/) type‑check scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die uw toepassing gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het dan in de geretourneerde string door een projectspecifiek commando of sla de vergelijking over en registreer het probleem voor latere beoordeling.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk code schrijven voor sommige vergelijkingsformaten zoals LaTeX, hebben ze moeite met het schrijven van code voor MathML omdat laatstgenoemde bedoeld is om automatisch door applicaties te worden gegenereerd. Programma’s lezen en parsen MathML gemakkelijk omdat de code in XML staat, dus wordt MathML vaak gebruikt als uitvoer‑ en afdrukformaat in vele vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskunde‑vergelijking uit een presentatie exporteert naar MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formuleblok?**  

U kunt ofwel een volledige wiskunde‑alinea ([MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**  

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstporties zonder een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML in een presentatie vandaan—een PowerPoint‑specifiek formaat of een standaard?**  

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — het presentatiesubset van de standaard — dat breed wordt ingezet in toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**  

Ja, als die objecten tekstporties bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/) (dus echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, gebeurt dat niet.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**  

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.