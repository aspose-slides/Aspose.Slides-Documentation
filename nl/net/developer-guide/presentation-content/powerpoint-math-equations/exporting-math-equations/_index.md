---
title: Wiskundige vergelijkingen exporteren uit presentaties in .NET
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/net/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- vergelijkingen exporteren naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint‑presentaties rechtstreeks naar LaTeX of MathML met Aspose.Slides voor .NET."
---
## **Inleiding**

Aspose.Slides voor .NET stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt misschien de wiskundige vergelijkingen op dia’s (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform.

{{% alert color="primary" %}} 

U kunt vergelijkingen direct exporteren naar LaTeX of naar MathML, een veelgebruikte standaard voor wiskundige inhoud op het web en in talloze toepassingen.

{{% /alert %}}

## **Exporteer wiskundige vergelijkingen naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking rechtstreeks naar LaTeX converteren; een tussenliggende MathML‑file of een externe converter is niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstvak als een [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/). Gebruik [MathPortion.MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/mathparagraph/) om een [IMathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph.ToLatex](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/imathparagraph/tolatex/) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere applicatie kunt sturen of verder kunt verwerken.

Het volgende voorbeeld doorzoekt elk tekstvak op elke dia, vindt alle wiskundige delen, en schrijft elke vergelijking naar een apart `.tex`‑bestand:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextboxes/) retourneert alle tekstvakken die op een dia gevonden worden. De type‑check van [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die door uw toepassing wordt gebruikt. Als een symbool of Office‑Math‑element geen passende weergave heeft in die omgeving, vervang het dan in de geretourneerde string door een project‑specifiek commando of sla de vergelijking over en noteer het probleem voor controle.

## **Bewaar wiskundige vergelijkingen als MathML**

Hoewel mensen gemakkelijk code schrijven voor sommige vergelijkingsformaten zoals LaTeX, vinden ze het lastig om code te schrijven voor MathML omdat dat later automatisch door toepassingen moet worden gegenereerd. Programma’s lezen en parseren MathML eenvoudig omdat de code in XML staat, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in diverse domeinen.

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

## **FAQ**

**Wat wordt er precies geëxporteerd naar MathML – een alinea of een individueel formuleblok?**

U kunt ofwel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathblock/)) exporteren naar MathML. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule zit in een [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstonderdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) kunnen niet geëxporteerde formules zijn.

**Waar komt de MathML in een presentatie vandaan – is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML – de presentatiesubset van de standaard – die breed wordt toegepast in verschillende applicaties en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstonderdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) (dus echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule is ingebed als afbeelding, gebeurt dat niet.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het verandert het presentatie‑bestand niet.