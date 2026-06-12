---
title: PowerPoint-presentaties converteren naar SWF‑Flash in Python
linktitle: PowerPoint naar SWF‑Flash
type: docs
weight: 80
url: /nl/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PowerPoint naar SWF
- presentatie naar SWF
- dia naar SWF
- PPT naar SWF
- PPTX naar SWF
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF‑Flash in Python met Aspose.Slides. Stapsgewijze codevoorbeelden, snelle kwaliteitsoutput, zonder PowerPoint‑automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar SWF converteert met Aspose.Slides. Het laat zien hoe u een presentatie opslaat als een SWF‑bestand met de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/)‑methode en hoe u de export configureert met [SwfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/), inclusief weergave‑instellingen en de lay‑out van notities of opmerkingen.

## **Presentaties converteren naar Flash**

De [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/)‑methode die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse kan worden gebruikt om de volledige presentatie om te zetten naar een SWF‑document. U kunt ook opmerkingen opnemen in de gegenereerde SWF door gebruik te maken van de [SWFOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/)‑klasse en de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse. Het volgende voorbeeld toont hoe u een presentatie converteert naar een SWF‑document met de opties die door de SWFOptions‑klasse worden geleverd.

```py
import aspose.slides as slides

# Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Opslaan van de presentatie en notitiepagina's
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Schakel de [show_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/show_hidden_slides/)‑optie in bij [SwfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF‑grootte beheersen?**

Gebruik de [compressed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/compressed/)‑vlag (standaard ingeschakeld) en pas [jpeg_quality](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/jpeg_quality/) aan om een balans te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'viewer_included' voor en wanneer moet ik het uitschakelen?**

[viewer_included](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/viewer_included/) voegt een ingebedde speler‑UI toe (navigatie‑besturingselementen, panelen, zoeken). Schakel het uit als u uw eigen speler wilt gebruiken of een kale SWF‑frame zonder UI nodig heeft.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides vervangt het lettertype dat u opgeeft via [default_regular_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/default_regular_font/) in [SwfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/swfoptions/) om een ongewenste fallback te voorkomen.