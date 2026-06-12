---
title: Wiskundige vergelijkingen exporteren vanuit presentaties in Python
linktitle: Vergelijkingen exporteren
type: docs
weight: 30
url: /nl/python-net/exporting-math-equations/
keywords:
- wiskundige vergelijkingen exporteren
- MathML
- LaTeX
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak naadloze export van wiskundige vergelijkingen vanuit PowerPoint naar MathML mogelijk met Aspose.Slides voor Python via .NET — behoud de opmaak en vergroot de compatibiliteit."
---
## **Inleiding**

Aspose.Slides voor Python via .NET stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt misschien vergelijkingen uit specifieke dia’s halen en ze hergebruiken in een ander programma of platform.

{{% alert color="primary" %}}
U kunt vergelijkingen exporteren naar MathML, een veelgebruikte standaard voor het vertegenwoordigen van wiskundige inhoud op het web en in vele toepassingen.
{{% /alert %}}

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk LaTeX kunnen schrijven, wordt MathML meestal automatisch gegenereerd door applicaties. Omdat MathML XML‑gebaseerd is, kunnen programma’s het betrouwbaar lezen en parseren, waardoor het veelal wordt gebruikt als output‑ en afdrukformaat in diverse vakgebieden.

De volgende voorbeeldcode laat zien hoe u een wiskundige vergelijking vanuit een presentatie kunt exporteren naar MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Veelgestelde vragen**

**Wat wordt er precies geëxporteerd naar MathML—een alinea of een individueel formule‑blok?**

U kunt een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe herken ik dat een object op een dia een wiskundige formule is en geen gewone tekst of een afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML in een presentatie vandaan—een PowerPoint‑specifieke implementatie of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatiesubset van de standaard — die breed wordt toegepast in applicaties en op het web.

**Wordt het exporteren van formules in tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingesloten, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de oorspronkelijke presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentatie‑bestand niet.