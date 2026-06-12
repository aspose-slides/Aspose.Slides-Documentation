---
title: Exporteren van wiskundige vergelijkingen uit presentaties in .NET
linktitle: Exporteren van vergelijkingen
type: docs
weight: 30
url: /nl/net/exporting-math-equations/
keywords:
- export wiskundige vergelijkingen
- MathML
- LaTeX
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontgrendel een naadloze export van wiskundige vergelijkingen van PowerPoint naar MathML met Aspose.Slides voor .NET—behoud de opmaak en verbeter de compatibiliteit."
---
## **Inleiding**

Aspose.Slides for .NET stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u moet mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="primary" %}} 
U kunt vergelijkingen exporteren naar MathML, een populair formaat of standaard voor wiskundige vergelijkingen en soortgelijke inhoud die op internet en in vele toepassingen wordt gezien. 
{{% /alert %}}

## **Wiskundige vergelijkingen opslaan als MathML**

Terwijl mensen gemakkelijk de code kunnen schrijven voor sommige vergelijkingsformaten zoals LaTeX, vinden ze het moeilijk om de code voor MathML te schrijven omdat die laatstgenoemde bedoeld is om automatisch door applicaties te worden gegenereerd. Programma's lezen en parseren MathML eenvoudig omdat de code in XML staat, zodat MathML veelvuldig wordt gebruikt als uitvoer‑ en afdrukformaat in diverse vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Veelgestelde vragen**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formulesegment?**

U kunt een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide types bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en niet gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) zijn geen exporteerbare formules.

**Waar komt de MathML in een presentatie vandaan—is het PowerPoint‑specifiek of een standaard?**

De export richt zich op de standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatie‑subset van de standaard — die breed wordt toegepast in verschillende toepassingen en op internet.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) (dus echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, gebeurt dat niet.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het genereren van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.