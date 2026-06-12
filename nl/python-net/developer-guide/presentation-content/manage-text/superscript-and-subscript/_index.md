---
title: Beheer superscript en subscript in Python
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/python-net/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor Python via .NET en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximaal effect."
---
## **Overzicht**

Aspose.Slides biedt functionaliteit om superscript‑ en subscripttekst in uw PowerPoint‑ (PPT, PPTX) en OpenDocument‑ (ODP) presentaties te integreren. Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt annoteren met voetnoten, deze gespecialiseerde opmaakopties helpen de duidelijkheid en precisie te behouden. In dit artikel leert u hoe u superscript‑ en subscriptstijlen moeiteloos toepast en gegarandeerd een professioneel resultaat per dia bereikt.

## **Superscript‑ en subscripttekst toevoegen**

U kunt superscript‑ en subscripttekst toevoegen aan elk alinea‑gedeelte. In Aspose.Slides gebruikt u de `escapement`‑eigenschap van de [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/)‑klasse om dit te regelen.

`escapement` is een percentage tussen **-100% en 100%**:

- **> 0** → superscript (bijv. 25% = lichte verhoging; 100% = volledige superscript)
- **0** → basislijn (geen super‑/subscript)
- **< 0** → subscript (bijv. -25% = lichte verlaging; -100% = volledige subscript)

Steps:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan en haal een dia op.
1. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe en krijg toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
1. Wis bestaande alinea's.
1. Voor superscript: maak een alinea en een gedeelte aan, stel `portion.portion_format.escapement` in op een waarde tussen **0 en 100**, zet de tekst, en voeg het gedeelte toe.
1. Voor subscript: maak een andere alinea en een gedeelte aan, stel `escapement` in op een waarde tussen **-100 en 0**, zet de tekst, en voeg het gedeelte toe.
1. Sla de presentatie op als PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Verkrijg een dia.
    slide = presentation.slides[0]

    # Maak een tekstvak.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Maak een alinea voor superscripttekst.
    superscript_paragraph = slides.Paragraph()

    # Maak een tekstgedeelte met gewone tekst.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Maak een tekstgedeelte met superscripttekst.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Maak een alinea voor de subscripttekst.
    subscript_paragraph = slides.Paragraph()

    # Maak een tekstgedeelte met gewone tekst.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Maak een tekstgedeelte met subscripttekst.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Voeg de alinea's toe aan het tekstvak.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik superscript/subscript toepassen in tabellen en andere containers, niet alleen in gewone tekstvakken?**

Ja. U kunt tekst als superscript of subscript opmaken binnen elk object dat een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) beschikbaar stelt (inclusief tabelcellen). De opmaak wordt toegepast op tekstgedeelten binnen dat frame.

**Zullen superscripts/subscripts behouden blijven bij export naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides behoudt de superscript‑ en subscriptopmaak bij het exporteren naar gangbare formaten zoals [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) en [raster images](/slides/nl/python-net/convert-powerpoint-to-png/) omdat de renderpipeline rekening houdt met opmaak op gedeelte‑niveau.

**Kan ik superscript/subscript combineren met hyperlinks in hetzelfde tekstfragment?**

Ja. [Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden toegewezen op het niveau van het gedeelte (fragment), zodat een gedeelte zowel een hyperlink als superscript‑ of subscriptopmaak kan hebben.