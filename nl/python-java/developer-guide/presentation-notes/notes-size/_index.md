---
title: Wijzig notitiepagina-grootte en -oriëntatie in Python via Java
linktitle: Notitiepagina-grootte
type: docs
weight: 10
url: /nl/python-java/notes-size/
keywords:
- notitiepagina-grootte
- notitie-oriëntatie
- liggende notities
- staande notities
- handout-grootte
- PowerPoint
- presentatie
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lees en wijzig de afmetingen van de notitiepagina in Aspose.Slides voor Python via Java, wissel de oriëntatie, verifieer opgeslagen afmetingen, en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getNotesSize) om de notitiepagina‑instellingen van de presentatie te benaderen. Het retourneert een [NotesSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notessize/) object waarvan de [setSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notessize/#setSize) methode de paginagrootte instelt. Hoewel het instellingenobject zelf niet kan worden vervangen, kun je via deze methode nieuwe afmetingen toewijzen.

Breedte en hoogte worden gespecificeerd in **punten**, met 72 punten per inch. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8⅓ inch. Deze instellingen zijn van toepassing op de presentatie, niet op de notities van een enkele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getNotesSize) | Beheert de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt voor hand‑out‑export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlideSize) | Beheert de reguliere dia‑afmetingen van de presentatie via [SlideSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/). |

Het wijzigen van een van beide instellingen wijzigt de andere niet automatisch. Het wijzigen van de oriëntatie van de notitiepagina draait de reguliere dia's ook niet. Zie [Slide Size](/slides/nl/python-java/slide-size/) om reguliere dia's te herschalen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met ten minste één dia met spreker‑notities. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **Lees de afmetingen en oriëntatie van de notitiepagina**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen in punten af, zonder een standaard papierformaat aan te nemen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Schakel over naar liggend zonder het papierformaat te wijzigen**

Om alleen de oriëntatie te wijzigen, verwissel je de bestaande breedte en hoogte. Dit behoudt de afmetingen van beide zijden, inclusief die van een aangepast papierformaat. De onderstaande voorwaarde voorkomt dat een reeds liggende pagina weer naar staand wordt omgezet en laat een vierkante pagina ongewijzigd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.getWidth() > size.getHeight()`. Vervang de afmetingen van A4 of Letter niet, tenzij je ook het papierformaat wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en controleer deze**

Wijs beide afmetingen tegelijk toe en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om de presentatie op te slaan. Dit voorbeeld stelt een liggende pagina van 900 × 600 punt in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de bewaarde waarden te controleren. De vergelijking staat een tolerantiewaarde van 0,01 punt toe voor floating‑point‑waarden; het is geen garantie voor precisie voor elk bestandsformaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Het verwachte resultaat is `900.0 x 600.0 points` en `Size preserved: True`. Het controleren van een zojuist geopende presentatie verifieert het opgeslagen bestand, in plaats van alleen de instellingen in het geheugen.

## **Exporteer notities en hand‑outs**

De paginagrootte definieert het beschikbare gebied voor notities of hand‑out‑lay‑outs. Ze activeren die lay‑outs niet automatisch: configureer ook de exportopties. Export van reguliere dia's blijft de dia‑afmetingen gebruiken.

### **Exporteer notities naar PDF en PNG**

Wijs [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) toe aan [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) om notities in de PDF op te nemen. Dit voorbeeld rendert tevens de eerste dia met notities naar PNG met behulp van [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) en [RenderingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/).

De modus [BottomTruncated](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/) houdt de notities op één pagina; notities die niet passen kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punt. Bij de hieronder gebruikte beeldschaal van 1 × 1 is de PNG 900 × 600 pixels. Punten beschrijven de paginageometrie; pixels beschrijven de rasteroutput, waarvan de afmetingen ook afhangen van de renderingschaal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Voor PDF‑export met lange notities staat [BottomFull](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/) extra pagina’s toe indien nodig. Gebruik die modus niet met de bovenstaande single‑slide‑image‑aanroep, die dit niet ondersteunt. Na het aanpassen van de grootte, controleer de uitvoer op afgekapt notities en de plaatsing van bestaande notes‑master‑objecten; alleen de paginagrootte wijzigen biedt geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/python-java/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Exporteer hand‑outs naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punt in en gebruikt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handouttype/) om tot vier dia’s per pagina te rangschikken. Het horizontale preset bepaalt de volgorde van de dia’s; de paginoriëntatie komt voort uit de breedte en hoogte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Het wijzigen van de paginagrootte verandert het gebied dat beschikbaar is voor het hand‑out‑raster zonder de afmetingen van de bron‑dia’s te wijzigen. Voor hand‑out‑afbeeldingen gebruik je [Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met de hand‑out‑lay‑out, in plaats van de afbeelding‑methode van een enkele dia. In Aspose.Slides gebruikt de rendering van hand‑outs op presentatieniveau de notitiepagina‑afmetingen, terwijl de afbeelding‑aanroep van een individuele dia geen hand‑out‑pagina oplevert. Zie [Handout Mode](/slides/nl/python-java/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Pagina‑grootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiegrootte, de geëxporteerde paginagrootte en de afgedrukte papiergrootte apart:

- **Presentation viewers:** Een viewer kan notities weergeven of afdrukken volgens zijn eigen lay‑outrichtlijnen. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen opnieuw; de bestandsconversie van die applicatie kan ze normaliseren.
- **Export formats:** De bovenstaande notitie‑ en hand‑out‑PDF‑voorbeelden gebruiken de geconfigureerde paginagrootte. Rasterafbeeldingen gebruiken gehele pixelafmetingen en een renderingschaal, waardoor decimale puntwaarden kunnen worden afgerond in de afbeelding. Export van reguliere dia’s past de notitiepagina‑grootte niet toe.
- **Printer drivers:** Papierkeuze, automatische rotatie en passen‑op‑pagina‑instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen aan te passen. Voor een specifiek papierformaat stem je de printerinstellingen af en controleer je de afdrukvoorbeeld.

## **FAQ**

**Kan ik de notitiesgrootte alleen voor één dia instellen?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia’s kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom heeft het wijzigen van de oriëntatie van de notities mijn dia’s niet beïnvloed?**

Notitiepagina’s en reguliere dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia’s zelf wilt aanpassen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitieafmetingen. Als die zijn gewijzigd, controleer dan of het opslaan of converteren van het bestand in een andere applicatie de paginainstellingen heeft aangepast. Als dat niet het geval is, controleer dan de exportlay‑out, beeldschaal, viewer‑instellingen en de papierkeuze van de printer.