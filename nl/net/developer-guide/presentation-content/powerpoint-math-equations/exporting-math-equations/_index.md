---
title: Exporteer wiskundige vergelijkingen vanuit presentaties in .NET
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/net/exporting-math-equations/
keywords:
- export wiskundige vergelijkingen
- exporteer vergelijkingen naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties naar LaTeX of MathML direct met Aspose.Slides voor .NET."
---
## **Introductie**

Aspose.Slides for .NET stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. U kunt bijvoorbeeld de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="info" %}} 
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in veel toepassingen wordt gebruikt.
{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige vergelijking rechtstreeks naar LaTeX converteren; een tussenliggende MathML‑bestand en een externe converter zijn niet vereist. Een wiskundige vergelijking wordt in een tekstvak opgeslagen als een [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/). Gebruik [MathPortion.MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/mathparagraph/) om een [IMathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/imathparagraph/) te verkrijgen, en roep vervolgens [IMathParagraph.ToLatex](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/imathparagraph/tolatex/) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen of verder kunt verwerken.

Het volgende voorbeeld onderzoekt elk tekstvak op elke dia, vindt alle wiskundige gedeelten en schrijft elke vergelijking naar een afzonderlijk `.tex`‑bestand:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextboxes/) geeft alle tekstvakken terug die op een dia worden gevonden. De type‑check van [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando's, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die door uw toepassing wordt gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het dan in de geretourneerde string door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor nadere beoordeling.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen de code voor sommige vergelijkingsformaten zoals LaTeX gemakkelijk kunnen schrijven, worstelen ze met het schrijven van de code voor MathML omdat dit laatste bedoeld is om automatisch door apps te worden gegenereerd. Programma's lezen en parseren MathML gemakkelijk omdat de code in XML staat, waardoor MathML veel wordt gebruikt als uitvoer‑ en afdrukformaat in diverse vakgebieden. 

Deze voorbeeldcode laat zien hoe u een wiskundige vergelijking uit een presentatie exporteert naar MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

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

**Wat wordt er precies geëxporteerd naar MathML — een alinea of een individueel formuleblok?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/)) als een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide types bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen of een object op een dia een wiskundige formule is in plaats van gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML in een presentatie vandaan — is het specifiek voor PowerPoint of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatiesubset van de standaard — die breed wordt toegepast in verschillende toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten met een [MathParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides.mathtext/mathparagraph/) bevatten (dus echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, niet.

**Wijzigt het exporteren naar MathML de originele presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.