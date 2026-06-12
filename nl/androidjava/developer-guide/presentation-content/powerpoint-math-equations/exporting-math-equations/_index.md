---
title: Exporteer wiskundige formules uit presentaties op Android
linktitle: Exporteer formules
type: docs
weight: 30
url: /nl/androidjava/exporting-math-equations/
keywords:
- exporteer wiskundige formules
- MathML
- LaTeX
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontgrendel een naadloze export van wiskundige formules van PowerPoint naar MathML met Aspose.Slides voor Android via Java — behoud de opmaak en verbeter de compatibiliteit."
---
## **Inleiding**

Aspose.Slides for Android via Java maakt het mogelijk om wiskundige formules uit presentaties te exporteren. Bijvoorbeeld, u wilt mogelijk de wiskundige formules op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="primary" %}} 
U kunt formules exporteren naar MathML, een populair formaat of standaard voor wiskundige formules en soortgelijke inhoud die op het web en in vele applicaties wordt gebruikt. 
{{% /alert %}}

## **Wiskundige formules exporteren uit presentaties**

Hoewel mensen gemakkelijk de code kunnen schrijven voor sommige formuleformaten zoals LaTeX, vinden ze het moeilijk om de code voor MathML te schrijven, omdat dit laatste bedoeld is om automatisch door toepassingen te worden gegenereerd. Programma's lezen en parseren MathML gemakkelijk omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in vele vakgebieden. 

Deze voorbeeldcode toont hoe u een wiskundige formule vanuit een presentatie exporteert naar MathML:

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

**Wat wordt precies geëxporteerd naar MathML—een alinea of een afzonderlijk formuleblok?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/)) als een afzonderlijk blok ([MathBlock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathblock/)) naar MathML exporteren. Beide types bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en niet gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML vandaan in een presentatie—een PowerPoint-specifiek object of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML—het presentatiesubset van de standaard—dat breed wordt toegepast in diverse applicaties en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de originele presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatiebestand niet.