---
title: Animeer PowerPoint-tekst in Python
linktitle: Geanimeerde Tekst
type: docs
weight: 60
url: /nl/python-net/animated-text/
keywords:
- geanimeerde tekst
- tekstananimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak dynamische, geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET, met eenvoudige, geoptimaliseerde codevoorbeelden."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst in PowerPoint‑presentaties kunt animeren met Aspose.Slides voor Python. U leert effecten toe te voegen aan individuele alinea’s, triggers aan te passen en bestaande animatiereeksen uit te lezen. Aan het einde kunt u herbruikbare tekst‑animatiewerkstromen maken die exporteren naar een standaard PPTX en correct afspelen in PowerPoint.

## **Alinea‑animatie‑effecten toevoegen**

De [add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) methode van de [Sequence](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/) klasse stelt u in staat een animatie‑effect toe te passen op één alinea. De voorbeeldcode hieronder laat zien hoe u dit doet:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Selecteer de alinea om het effect toe te voegen.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Voeg een Fly‑animatie‑effect toe aan de geselecteerde alinea.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinea‑animatie‑effecten ophalen**

U wilt misschien bepalen welke animatie‑effecten op een alinea zijn toegepast — bijvoorbeeld wanneer u die effecten naar een andere alinea of vorm wilt kopiëren.

Aspose.Slides voor Python laat u alle animatie‑effecten ophalen die op de alinea’s in een tekst‑frame (vorm) zijn toegepast. De voorbeeldcode hieronder toont hoe u de animatie‑effecten van een alinea kunt krijgen:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**Hoe verschillen tekstanimaties van dia‑overgangen, en kunnen ze gecombineerd worden?**

Tekstanimaties regelen het gedrag van een object in de tijd op een dia, terwijl [transitions](/slides/nl/python-net/slide-transition/) bepalen hoe dia’s veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstanimaties bewaard bij exporteren naar PDF of afbeeldingen?**

Nee. PDF‑bestanden en rasterafbeeldingen zijn statisch, dus u ziet een enkele weergave van de dia zonder beweging. Om de beweging te behouden, gebruikt u export naar [video](/slides/nl/python-net/convert-powerpoint-to-video/) of [HTML](/slides/nl/python-net/export-to-html5/).

**Werken tekstanimaties in lay‑outs en de dia‑master?**

Effecten die op lay‑out‑/master‑objecten zijn toegepast, worden geërfd door dia’s, maar hun timing en interactie met animaties op dia‑niveau hangen af van de uiteindelijke reeks op de dia.