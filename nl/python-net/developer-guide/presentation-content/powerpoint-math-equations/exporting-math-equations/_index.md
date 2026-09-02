---
title: Exporteer wiskundige vergelijkingen uit presentaties in Python
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/python-net/exporting-math-equations/
keywords:
- exporteer wiskundige vergelijkingen
- exporteer vergelijkingen naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties rechtstreeks naar LaTeX of MathML met Aspose.Slides voor Python via .NET."
---
## **Introductie**

Aspose.Slides for Python via .NET maakt het mogelijk om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt vergelijkingen uit specifieke dia's halen en ze hergebruiken in een ander programma of platform.

{{% alert color="primary" %}}
U kunt vergelijkingen rechtstreeks exporteren naar LaTeX of naar MathML, een veelgebruikte standaard voor wiskundige inhoud op het web en in tal van toepassingen.
{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint-wiskundige vergelijking direct omzetten naar LaTeX; een tussenliggende MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige vergelijking wordt opgeslagen in een tekstframe als een [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/). Gebruik [MathPortion.math_paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) om een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) te verkrijgen, en roep vervolgens [MathParagraph.to_latex](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) aan. De methode retourneert een tekenreeks die u kunt opslaan, weergeven, naar een andere toepassing sturen of verder verwerken.

Het volgende voorbeeld doorzoekt elk tekstframe op elke dia, vindt alle wiskundige gedeelten en schrijft elke vergelijking naar een apart `.tex`‑bestand:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) retourneert alle tekstframes die op een dia zijn gevonden. De type‑controle van [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/) scheidt echte bewerkbare vergelijkingen van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando's, pakketten of Unicode‑tekens. Test de geretourneerde tekenreeks met de LaTeX‑engine die uw toepassing gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het dan in de geretourneerde tekenreeks door een projectspecifiek commando of sla de vergelijking over en noteer het probleem voor later onderzoek.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel mensen gemakkelijk LaTeX kunnen schrijven, wordt MathML meestal automatisch gegenereerd door toepassingen. Omdat MathML XML‑gebaseerd is, kunnen programma's het betrouwbaar lezen en parseren, waardoor het vaak wordt gebruikt als uitvoer‑ en afdrukformaat in veel sectoren.

De volgende voorbeeldcode toont hoe u een wiskundige vergelijking uit een presentatie kunt exporteren naar MathML:

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

## **FAQ**

**Wat wordt precies geëxporteerd naar MathML—een alinea of een afzonderlijk formulesegment?**

U kunt zowel een volledige wiskundige alinea ([MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/)) als een afzonderlijk blok ([MathBlock](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik herkennen dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/). Afbeeldingen en gewone tekstgedeelten zonder een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) kunnen niet worden geëxporteerd als formules.

**Waar komt de MathML in een presentatie vandaan—is het PowerPoint‑specifiek of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML — de presentatie‑subset van de standaard — die breed wordt toegepast in verschillende toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstgedeelten bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) (d.w.z. echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, gebeurt dat niet.

**Wijzigt exporteren naar MathML de originele presentatie?**

Nee. Het wegschrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentat‑bestand niet.