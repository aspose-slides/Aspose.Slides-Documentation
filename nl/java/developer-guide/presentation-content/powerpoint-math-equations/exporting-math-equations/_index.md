---
title: Wiskundige vergelijkingen exporteren vanuit presentaties in Java
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/java/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- MathML
- LaTeX
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontgrendel naadloze export van wiskundige vergelijkingen van PowerPoint naar MathML met Aspose.Slides voor Java—behoud de opmaak en verbeter de compatibiliteit."
---
## **Introduction**

Aspose.Slides stelt u in staat om wiskundige vergelijkingen vanuit presentaties te exporteren. U wilt bijvoorbeeld de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 

U kunt vergelijkingen exporteren naar MathML, een veelgebruikt formaat of standaard voor wiskundige vergelijkingen en soortgelijke inhoud op het web en in vele applicaties. 

{{% /alert %}}

## **Save Math Equations as MathML**

Hoewel mensen gemakkelijk de code voor sommige vergelijkingformaten zoals LaTeX kunnen schrijven, hebben ze moeite met het schrijven van de code voor MathML, omdat dit laatste bedoeld is om automatisch door apps te worden gegenereerd. Programma's lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel vakgebieden. 

Deze voorbeeldcode toont hoe u een wiskundige vergelijking uit een presentatie kunt exporteren naar MathML:

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

**What exactly is exported to MathML—a paragraph or an individual formula block?**

U kunt een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) kunnen niet geëxporteerde formules zijn.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatiesubset van de standaard — die breed wordt toegepast in applicaties en op het web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint‑formules), dan worden ze geëxporteerd. Als een formule is ingevoegd als afbeelding, gebeurt dat niet.

**Does exporting to MathML modify the original presentation?**

Nee. Het wegschrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.