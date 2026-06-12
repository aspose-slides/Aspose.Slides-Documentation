---
title: Exporteer wiskundige vergelijkingen uit presentaties in JavaScript
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/nodejs-java/exporting-math-equations/
keywords:
- exporteer wiskundige vergelijkingen
- MathML
- LaTeX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontgrendel naadloze export van wiskundige vergelijkingen van PowerPoint naar MathML met JavaScript en Aspose.Slides voor Node.js—behoud de opmaak en vergroot de compatibiliteit."
---
## **Inleiding**

Aspose.Slides stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 
U kunt vergelijkingen exporteren naar MathML, een populair formaat of standaard voor wiskundige vergelijkingen en vergelijkbare inhoud die op het web en in veel toepassingen wordt gezien. 
{{% /alert %}}

## **Bewaar wiskundige vergelijkingen als MathML**

Terwijl mensen gemakkelijk de code voor bepaalde vergelijkingsformaten zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML, omdat dit laatste automatisch door applicaties moet worden gegenereerd. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML is, waardoor MathML algemeen wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

Deze voorbeeldcode toont hoe u een wiskundige vergelijking uit een presentatie kunt exporteren naar MathML:

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

**Wat wordt er precies geëxporteerd naar MathML — een alinea of een afzonderlijk formuleblok?**

U kunt een volledige wiskunde‑alinea ([MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/)) of een afzonderlijk blok ([MathBlock](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstporties zonder een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/) kunnen niet geëxporteerd worden als formules.

**Waar komt de MathML vandaan in een presentatie — is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — het presentatiesubset van de standaard — dat breed wordt gebruikt in diverse applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstporties bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/mathparagraph/), (dwz echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.