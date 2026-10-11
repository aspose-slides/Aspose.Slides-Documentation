---
title: Wijzig de notitiepaginasize en oriëntatie in Python
linktitle: Notitiepaginasize
type: docs
weight: 10
url: /nl/python-net/notes-size/
keywords:
- notitiepaginasize
- notitie-oriëntatie
- liggende notities
- staande notities
- handoutgrootte
- PowerPoint
- presentatie
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lees en wijzig notitiepaginasize in Aspose.Slides voor Python via .NET, wissel oriëntatie, verifieer opgeslagen groottes, en exporteer notities of handouts naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.notes_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/notes_size/) om de notitiepagina‑instellingen van de presentatie te benaderen. Het retourneert een [NotesSize](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notessize/)‑object waarvan de [size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notessize/size/)‑eigenschap schrijfbaar is. Hoewel het instellingenobject zelf alleen‑lezen is, kun je nieuwe afmetingen toewijzen aan de size‑eigenschap.

Breedte en hoogte worden opgegeven in **punten**, met 72 punten per inch. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8 ⅓ inch. Deze instellingen hebben betrekking op de presentatie, niet op de notities van een enkele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/notes_size/) | Regelt de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt bij het exporteren van hand-outs. |
| [Presentation.slide_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slide_size/) | Regelt de afmetingen van de gewone presentatiedia via [SlideSize](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/). |

Het wijzigen van de ene instelling wijzigt de andere niet automatisch. Het wijzigen van de oriëntatie van de notitiepagina roteert de gewone dia's ook niet. Zie [Slide Size](/slides/nl/python-net/slide-size/) om gewone dia’s van grootte te wijzigen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met minstens één dia die spreker‑notities bevat. Elk voorbeeld kan onafhankelijk uitgevoerd worden.

## **De grootte en oriëntatie van de notitiepagina lezen**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen in punten af, zonder een standaard papierformaat aan te nemen.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Omschakelen naar liggend zonder het papierformaat te wijzigen**

Om alleen de oriëntatie te wijzigen, verwissel je de bestaande breedte en hoogte. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De voorwaarde hieronder voorkomt dat een al liggende pagina wordt teruggeschakeld naar staand en laat een vierkante pagina onveranderd.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.width > size.height`. Vervang geen A4‑ of Letter‑afmetingen tenzij je ook het papierformaat wilt wijzigen.

## **Een aangepast notitiepaginasize instellen en verifiëren**

Wijs beide afmetingen tegelijk toe en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om de presentatie weg te schrijven. Dit voorbeeld stelt een liggende pagina van 900 × 600 punt in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de bewaarde waarden te controleren. De vergelijking laat een tolerantiedrempel van 0,01 punt toe voor zwevende‑kommagetallen; dit is geen garantie voor absolute precisie in elk bestandsformaat.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Het verwachte resultaat is `900 x 600 points` en `Size preserved: True`. Het controleren van een opnieuw geopende presentatie verifieert het opgeslagen bestand, niet alleen de in‑memory instellingen.

## **Notities en hand‑outs exporteren**

De paginagrootte definieert de beschikbare ruimte voor notities of hand‑out‑lay‑outs. Ze activeren die lay‑outs niet automatisch: configureer ook de exportopties. Export van gewone dia’s blijft de dia‑afmetingen gebruiken.

### **Notities exporteren naar PDF en PNG**

Ken [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/) toe aan [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) om notities in de PDF op te nemen. Dit voorbeeld rendert bovendien de eerste dia met notities naar PNG met behulp van [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) en [RenderingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/).

De modus [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notespositions/) houdt de notities op één pagina; notities die niet passen, worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punt. Bij de hieronder gebruikte afbeeldingsschaal van 1 × 1 is de PNG 900 × 600 pixel. Punten beschrijven de paginageometrie; pixels beschrijven de rasteroutput, waarvan de afmetingen ook afhangen van de renderschaal.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Voor PDF‑export met lange notities staat [BOTTOM_FULL](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notespositions/) extra pagina’s toe indien nodig. Gebruik die modus niet bij de enkel­‑dia‑afbeeldingsaanroep hierboven, die dit niet ondersteunt. Na het wijzigen van de grootte, inspecteer je de output op afgekapt notities en de plaatsing van bestaande notes‑master‑objecten; alleen de paginagrootte wijzigen is geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/python-net/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Hand‑outs exporteren naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punt in en gebruikt [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handouttype/) om tot vier dia’s per pagina te rangschikken. Het horizontale voorinstelling bepaalt de volgorde van de dia’s; de paginagrootte volgt uit de breedte en hoogte.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Het wijzigen van de paginagrootte verandert de beschikbare ruimte voor het hand‑out‑rooster zonder de afmetingen van de bron‑dia’s te wijzigen. Voor hand‑out‑afbeeldingen gebruik je [Presentation.get_images](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/) met de hand‑out‑lay‑out, in plaats van de afbeeldingsmethode van een individuele dia. In Aspose.Slides gebruikt de hand‑out‑rendering op presentatieniveau de notitiepagina‑afmetingen, terwijl de afbeelding‑aanroep van een enkele dia de hand‑out‑pagina niet produceert. Zie [Handout Mode](/slides/nl/python-net/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Paginagrootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiegrootte, de geëxporteerde paginagrootte en de afgedrukte papieren grootte gescheiden:

- **Presentatie‑viewers:** Een viewer kan notities weergeven of afdrukken volgens zijn eigen lay‑outrichtlijnen. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen opnieuw; de conversie van die applicatie kan ze normaliseren.
- **Exportformaten:** De notitie‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Raster‑afbeeldingen gebruiken gehele pixelafmetingen en een renderschaal, waardoor fractionele punt‑waarden kunnen worden afgerond in de afbeelding. Export van gewone dia’s past de grootte van de notitiepagina niet toe.
- **Printer‑drivers:** Papier‑selectie, automatische rotatie en passen‑op‑pagina‑instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat stem je de printerinstellingen af en controleer je de afdrukvoorbeeld.

## **FAQ**

**Kan ik de notitiegrootte voor slechts één dia instellen?**

De notitiepaginasize is een instelling op presentatieniveau. Individuele dia’s kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom veranderde het wijzigen van de notitie‑oriëntatie mijn dia’s niet?**

Notitiepagina’s en gewone dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia’s zelf wilt herschalen.

**Waarom heeft het opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die zijn gewijzigd, controleer dan of opslaan of converteren in een andere applicatie de paginainstellingen heeft aangepast. Als dat niet het geval is, controleer dan de export‑lay‑out, afbeeldingsschaal, viewer‑instellingen en de papierselectie van de printer.