---
title: PPT & PPTX naar PDF converteren in Python | Geavanceerde opties
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
description: "Stapsgewijze gids voor het converteren van PPT, PPTX en ODP naar hoogwaardige, WCAG‑conforme PDF‑bestanden in Python met Aspose.Slides — inclusief wachtwoordbeveiliging, dia‑selectie en controle over beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP) naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het waarborgen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia’s kunt opnemen, PDF‑documenten met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia’s kunt selecteren voor conversie, en nalevingsnormen kunt toepassen op de uitvoerdocumenten.

## **PowerPoint naar PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python, hoeft u alleen de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑klasse door te geven en vervolgens de presentatie op te slaan als PDF met behulp van de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑methode. De [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides for Python het toepassingsveld in met de waarde '*Aspose.Slides*' en het PDF‑Producer‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Opmerking** dat u Aspose.Slides for Python niet kunt instrueren om deze informatie uit de uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides maakt het mogelijk:

* Gehele presentaties naar PDF
* Specifieke dia’s in een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de inhoud van de resulterende PDF‑bestanden nauwkeurig overeenkomt met de originele presentaties. Elementen en attributen worden tijdens de conversie nauwkeurig gerenderd, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het maximale kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met behulp van de standaard exportinstellingen.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. Voor een live implementatie van de hier beschreven procedure kunt u een test uitvoeren met de converter.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties – eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)‑klasse – waarmee u de PDF (die voortkomt uit het conversieproces) kunt aanpassen, de PDF met een wachtwoord kunt beveiligen, of zelfs kunt aangeven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen bepalen, aangeven hoe metafiles moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen instellen, enz.

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

### **Automatisch beeldcompressie selecteren**

Wanneer een presentatie veel foto’s of schermafbeeldingen bevat, kan het verkleinen van de grootte van de geëxporteerde PDF het eenvoudiger maken om per e‑mail te verzenden of te downloaden. Stel [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) in op `True` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens het exporteren naar PDF.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt de automatische selectie van beeldcompressie in, en slaat deze op als een PDF‑document. Alle andere PDF‑exportinstellingen behouden hun standaardwaarden.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Deze optie selecteert een compressie‑algoritme voor elke afbeelding. Het verlagen van [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) vermindert de JPEG‑beeldkwaliteit, terwijl het verlagen van [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) toestaat dat afbeeldingen worden gedowngesampled naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressieselectie verlaagt deze instellingen op zichzelf niet.

Het selecteren van beeldcompressie‑algoritmen vereist extra verwerkingstijd en geheugen. De grootte‑reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie wordt niet gegarandeerd voor elke presentatie.

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u misschien dat PDF‑ontvangers zowel de gegevens van het werkboek kunnen bekijken als de dia’s. Stel [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) in op `True` om ingesloten OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `False`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingesloten bestand wordt niet als bijlage toegevoegd. Het instellen van de optie op `True` voegt bovendien de bestandsdata toe. De voorbeeldweergave blijft een visuele representatie; de bijlage stelt ontvangers in staat het ingesloten bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

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
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. De voorbeeldweergave op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑standaarden leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen, inclusief Excel‑werkboeken, toe. Dit zijn vereisten van de standaarden, geen beperkingen die specifiek zijn voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u een aangepaste optie gebruiken – de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)‑eigenschap van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)‑klasse – om Aspose.Slides te instrueren de verborgen dia’s op te nemen als pagina’s in de resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia’s.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint naar een wachtwoord‑beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die een wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Lettertypen behandelen zonder een specifieke vet stijl**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het lettertype geen specifiek vette stijl heeft. De tekst kan alsnog vet lijken door synthetisch vetten, wat de reguliere glyphs kunstmatig verdikt. Wanneer die tekst te zwaar oogt of anderszins afwijkt van de gewenste weergave in PDF, probeer dan [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) in te stellen op `True`. Deze optie rendert de getroffen tekst als bitmap tijdens het exporteren naar PDF en kan de weergave voor bepaalde lettertypen verbeteren. De standaardwaarde is `False`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vette opmaak toegepast op hetzelfde lettertype, dat geen specifieke vetstijl heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

De volgende voorbeeldweergaven tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst dikkere lijnen wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de lijnen lichter; de gewone tekst blijft onveranderd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`False`, de standaard) | Optie ingeschakeld (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen de vette tekst een bitmap: deze kan niet worden geselecteerd, gekopieerd of als tekst worden doorzocht zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide tekenreeksen tekst.

Deze optie rastert tekst die als vet is opgemaakt wanneer het lettertype geen specifieke vetstijl heeft. [Lettertype‑substitutie](/slides/nl/python-net/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het originele niet beschikbaar is.

## **Geselecteerde dia’s in PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dianummers in deze array beginnen bij één, en de invoerpresentatie moet minimaal drie dia’s bevatten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enige dia naar PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Verwijder de lege dia die met de nieuwe presentatie is aangemaakt.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met behulp van een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

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
Aspose.Slides‑ondersteuning voor PDF‑conversie‑bewerkingen maakt het mogelijk PDF te converteren naar de meest populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten – [PDF naar SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) en [PDF naar XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) – worden eveneens ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de volledige afbeelding geleverd.

## **FAQ**

**Kan Aspose.Slides for Python de toepassingsinformatie uit de PDF verwijderen?**

Nee, Aspose.Slides for Python voegt automatisch API‑informatie en het versienummer toe aan de uitvoer‑PDF. Deze informatie kan niet worden gewijzigd of verwijderd.

**Hoe kan ik alleen specifieke dia’s opnemen bij de PDF‑conversie?**

U kunt de dia‑indexen die u wilt converteren specificeren door een array met dia‑posities door te geven aan de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑methode.

**Is het mogelijk om de PDF tijdens de conversie met een wachtwoord te beveiligen?**

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren met behulp van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)‑klasse voordat u de presentatie opslaat als PDF.

**Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?**

Ja, Aspose.Slides ondersteunt het converteren van PDF’s naar formaten zoals HTML, afbeeldingsformaten (JPG, PNG), SVG, TIFF en XML.

**Hoe kan ik ervoor zorgen dat mijn PDF voldoet aan toegankelijkheidsnormen?**

Stel de [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/)‑eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) in op normen zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te voldoen aan de richtlijnen voor toegankelijkheid.

**Kan ik verborgen dia’s opnemen in de PDF‑output?**

Ja, door de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)‑eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) op `True` te zetten, worden verborgen dia’s opgenomen in de PDF.

**Hoe pas ik de beeldkwaliteit en resolutie aan tijdens de conversie?**

Gebruik de [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)‑ en [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)‑eigenschappen in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) om de beeldkwaliteit en resolutie in de resulterende PDF te regelen.

**Behandelt Aspose.Slides lettertype‑substituties automatisch?**

Aspose.Slides detecteert lettertype‑substituties tijdens de conversie, en u kunt ze afhandelen via de `warning_callback`‑eigenschap in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides voor Python via .NET Documentatie](/slides/nl/python-net/)
- [Aspose.Slides API-referentie](https://reference.aspose.com/slides/python-net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)