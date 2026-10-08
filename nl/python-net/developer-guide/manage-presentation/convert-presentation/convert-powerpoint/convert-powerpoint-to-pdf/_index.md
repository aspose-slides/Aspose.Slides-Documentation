---
title: Convert PPT & PPTX naar PDF in Python | Geavanceerde opties
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint converteren
- presentatie
- PowerPoint naar PDF
- PPT naar PDF
- PPTX naar PDF
- PowerPoint opslaan als PDF
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides voor Python
description: "Stapsgewijze handleiding voor het converteren van PPT, PPTX en ODP naar hoogwaardige, WCAG-conforme PDF-bestanden in Python met Aspose.Slides—bevat wachtwoordbeveiliging, selectie van dia's en controle van beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

Het omzetten van PowerPoint‑presentaties (PPT, PPTX, ODP) naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het waarborgen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia's opneemt, PDF‑documenten met een wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia's selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze indelingen naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python, hoeft u alleen de bestandsnaam als argument door te geven aan de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse en vervolgens de presentatie op te slaan als PDF met behulp van de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse maakt de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode beschikbaar, die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor Python voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides voor Python het veld Application met de '*Aspose.Slides*' waarde en het PDF‑Producer‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Let op** dat u Aspose.Slides voor Python niet kunt instrueren om deze informatie uit de uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* volledige presentaties naar PDF
* specifieke dia's in een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de inhoud van de resulterende PDF’s nauwkeurig overeenkomt met de originele presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop- en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint‑naar‑PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie te converteren naar PDF met optimale instellingen op het hoogste kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met de standaard exportinstellingen.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. Voor een live‑implementatie van de hier beschreven procedure kunt u een test doen met de converter.
{{% /alert %}}

## **PowerPoint‑naar‑PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse—die u in staat stellen het PDF (dat voortkomt uit het conversieproces) aan te passen, het PDF met een wachtwoord te beveiligen, of zelfs te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint‑naar‑PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurskwaliteit voor rasterafbeeldingen instellen, bepalen hoe metafiles worden verwerkt, een compressieniveau voor tekst opgeven, DPI voor afbeeldingen instellen, enz.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingsresolutie op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u mogelijk dat PDF‑ontvangers zowel de gegevens van het werkboek kunnen raadplegen als de dia's bekijken. Stel [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) in op `True` om ingesloten OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `False`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina gerenderd, maar het ingebedde bestand wordt niet toegevoegd als bijlage. Door de optie op `True` te zetten, wordt de bestandsdata eveneens opgenomen. Het voorbeeld blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingebedde bestand apart te openen of op te slaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebed Excel‑werkboek bevat en exporteert deze naar PDF met het werkboek als bijlage.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek het ingebedde werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer het toelaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑standaarden stellen beperkingen aan bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkboeken. Dit zijn vereisten van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint‑naar‑PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u een aangepaste optie gebruiken—de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) eigenschap van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse—om Aspose.Slides te instrueren de verborgen dia's op te nemen als pagina's in de resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint‑naar‑een‑wachtwoordbeveiligde‑PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken in hoge kwaliteit.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Lettertypen zonder een eigen vet typeface verwerken**

Een presentatie kan vette opmaak toepassen op tekst zelfs als het lettertype geen dedicated vette variant heeft. De tekst kan nog steeds vet lijken door synthetisch vetten, waarbij de gewone glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar oogt of anderszins afwijkt van de gewenste weergave in de PDF, probeer dan de [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) in te stellen op `True`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. De standaardwaarde is `False`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vette opmaak toegepast op hetzelfde lettertype, dat geen dedicated vette variant heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

De volgende voorbeeldweergaven tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere streken wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de streken lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`False`, standaard) | Optie ingeschakeld (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen de vette tekst een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen dedicated vette variant heeft. [Lettertype‑vervanging](/slides/nl/python-net/font-substitution/) kiest in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia's in PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia's 1 en 3 van een presentatie naar PDF. Dia‑nummers in dit array beginnen bij één, en de invoerpresentatie moet ten minste drie dia's bevatten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint‑naar‑PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia van een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Verwijder de lege dia die is aangemaakt bij de nieuwe presentatie.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint‑naar‑PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Toegankelijkheids‑ en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat om een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze Python‑code demonstreert een PowerPoint‑naar‑PDF‑conversie waarbij meerdere PDF‑bestanden op basis van verschillende nalevingsstandaarden worden verkregen:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
Aspose.Slides‑ondersteuning voor PDF‑conversie‑operaties stelt u in staat PDF naar de meest populaire bestandsformaten te converteren. U kunt [PDF naar HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Let op:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, grafieken en formules als één figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de volledige figuur geleverd.

## **FAQ**

**Kan Aspose.Slides voor Python de applicatie‑informatie uit de PDF verwijderen?**

Nee, Aspose.Slides voor Python voegt automatisch API‑informatie en het versienummer toe aan de uitgevoerde PDF. Deze informatie kan niet worden aangepast of verwijderd.

**Hoe kan ik alleen specifieke dia's opnemen in de PDF‑conversie?**

U kunt de dia‑indices die u wilt converteren specificeren door een array met dia‑posities door te geven aan de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode.

**Is het mogelijk om de PDF tijdens de conversie met een wachtwoord te beveiligen?**

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren met behulp van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse voordat u de presentatie opslaat als PDF.

**Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?**

Ja, Aspose.Slides ondersteunt het converteren van PDF‑bestanden naar formaten zoals HTML, afbeeldingformaten (JPG, PNG), SVG, TIFF en XML.

**Hoe kan ik ervoor zorgen dat mijn PDF voldoet aan toegankelijkheidsstandaarden?**

Stel de [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) in op standaarden zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te garanderen dat de PDF voldoet aan de toegankelijkheidsrichtlijnen.

**Kan ik verborgen dia's opnemen in de PDF-uitvoer?**

Ja, door de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) op `True` te zetten, worden verborgen dia's in de PDF opgenomen.

**Hoe pas ik de beeldkwaliteit en resolutie aan tijdens de conversie?**

Gebruik de [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) en [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) eigenschappen in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) om de beeldkwaliteit en resolutie in de gegenereerde PDF te regelen.

**Verwerkt Aspose.Slides automatisch lettertype‑vervangingen?**

Aspose.Slides detecteert lettertype‑vervangingen tijdens de conversie en u kunt ze afhandelen met de `warning_callback` eigenschap in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides voor Python via .NET Documentatie](/slides/nl/python-net/)
- [Aspose.Slides API‑referentie](https://reference.aspose.com/slides/python-net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)