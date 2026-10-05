---
title: Converteer PPT & PPTX naar PDF in Python | Geavanceerde opties
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
- Aspose.Slides for Python
description: "Stap-voor-stap gids voor het converteren van PPT, PPTX en ODP naar hoogwaardige, WCAG-conforme PDF-bestanden in Python met Aspose.Slides — omvat wachtwoordbeveiliging, selectie van dia's en controle van de beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP) naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het waarborgen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten kunt converteren, diverse opties kunt gebruiken om de beeldkwaliteit te beheersen, verborgen dia's kunt opnemen, PDF‑documenten met een wachtwoord kunt beveiligen, lettertype‑vervanging kunt detecteren, specifieke dia's voor conversie kunt selecteren, en nalevingsnormen op uitvoerdocumenten kunt toepassen.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python, hoeft u alleen de bestandsnaam als argument door te geven aan de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse en vervolgens de presentatie op te slaan als PDF met behulp van een [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse biedt de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides for Python het veld Application met de waarde '*Aspose.Slides*' en het PDF Producer‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Opmerking** dat u Aspose.Slides for Python niet kunt opdragen om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's in een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de inhoud van de resulterende PDF's nauwkeurig overeenkomt met de originele presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. Voor een live implementatie van de hier beschreven procedure kunt u een test doen met de converter.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides levert aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse — waarmee u de PDF (die uit het conversieproces ontstaat) kunt aanpassen, de PDF kunt beveiligen met een wachtwoord, of zelfs kunt aangeven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen instellen, aangeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen instellen, enz.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

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

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u mogelijk dat PDF‑ontvangers zowel de gegevens van het werkboek kunnen raadplegen als de dia's kunnen bekijken. Stel [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) in op `True` om ingesloten OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `False`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt weergeven op de PDF‑pagina, maar het ingesloten bestand wordt niet toegevoegd als bijlage. Door de optie op `True` te zetten wordt de bestanddata bovendien toegevoegd. Het voorbeeld blijft een visuele weergave; de bijlage laat ontvangers het ingesloten bestand afzonderlijk openen of opslaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

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
2. Open het **Bijlagen**‑paneel van de viewer en zoek het ingesloten werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op aan bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkboeken. Dit zijn vereisten van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en laat geen PDF/A‑export zien.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u een aangepaste optie – de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) eigenschap van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse – gebruiken om Aspose.Slides te instrueren de verborgen dia's als pagina's op te nemen in de resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief alle verborgen dia's.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint naar een met wachtwoord beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die een wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Geselecteerde dia's in PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia's 1 en 3 uit een presentatie naar PDF. Dia‑nummers in deze array beginnen bij één, en de invoerpresentatie moet ten minste drie dia's bevatten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enkele dia naar PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Verwijder de lege dia die bij het maken van de nieuwe presentatie werd toegevoegd.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke spreker onder de dia worden geplaatst. Gebruik een presentatie met spreker‑aantekeningen om het resultaat te zien.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat om een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met één van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze Python‑code demonstreert een PowerPoint‑naar‑PDF‑conversie‑operatie waarbij meerdere PDF’s op basis van verschillende nalevingsnormen worden verkregen:

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
Aspose.Slides‑ondersteuning voor PDF‑conversie‑operaties stelt u in staat PDF’s te converteren naar de populairste bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de gehele afbeelding verstrekt.

## **FAQ**

**Kan Aspose.Slides voor Python de toepassingsinformatie uit de PDF verwijderen?**

Nee, Aspose.Slides voor Python voegt automatisch API‑informatie en het versienummer toe aan de gegenereerde PDF. Deze informatie kan niet worden aangepast of verwijderd.

**Hoe kan ik alleen specifieke dia's opnemen in de PDF‑conversie?**

U kunt de dia‑indexen die u wilt converteren opgeven door een array met dia‑posities door te geven aan de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) methode.

**Is het mogelijk om de PDF te beveiligen met een wachtwoord tijdens de conversie?**

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren met behulp van de [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) klasse voordat u de presentatie als PDF opslaat.

**Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?**

Ja, Aspose.Slides ondersteunt het converteren van PDF's naar formaten zoals HTML, beeldformaten (JPG, PNG), SVG, TIFF en XML.

**Hoe kan ik ervoor zorgen dat mijn PDF voldoet aan toegankelijkheidsnormen?**

Stel de [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) in op normen zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te zorgen dat de PDF voldoet aan de toegankelijkheidsrichtlijnen.

**Kan ik verborgen dia's opnemen in de PDF‑output?**

Ja, door de [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) eigenschap in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) op `True` te zetten, worden verborgen dia's opgenomen in de PDF.

**Hoe pas ik de beeldkwaliteit en resolutie aan tijdens de conversie?**

Gebruik de [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) en [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) eigenschappen in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) om de beeldkwaliteit en resolutie in de resulterende PDF te regelen.

**Verwerkt Aspose.Slides lettertype‑vervangingen automatisch?**

Aspose.Slides detecteert lettertype‑vervangingen tijdens de conversie, en u kunt ze afhandelen met de `warning_callback` eigenschap in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides voor Python via .NET Documentatie](/slides/nl/python-net/)
- [Aspose.Slides API‑referentie](https://reference.aspose.com/slides/python-net/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/conversion)