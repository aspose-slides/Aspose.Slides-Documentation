---
title: "PPT & PPTX naar PDF converteren in Python | Geavanceerde opties"
linktitle: "PowerPoint naar PDF"
type: docs
weight: 40
url: /nl/python-net/convert-powerpoint-to-pdf/
keywords:
  - "PowerPoint converteren"
  - "presentatie"
  - "PowerPoint naar PDF"
  - "PPT naar PDF"
  - "PPTX naar PDF"
  - "PowerPoint opslaan als PDF"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "Python"
  - "Aspose.Slides for Python"
description: "Stapsgewijze handleiding voor het converteren van PPT, PPTX en ODP naar hoogwaardige, WCAG‑conforme PDF's in Python met Aspose.Slides—bevat wachtwoordbeveiliging, selectie van dia's en regeling van beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP) naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het waarborgen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia's opneemt, PDF‑documenten met een wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia's selecteert voor conversie, en conformiteitsnormen toepast op de uitvoerdocumenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python geeft u simpelweg de bestandsnaam door als argument aan de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode. De [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse biedt de [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides voor Python schrijft direct API‑informatie en versienummer in de uitvoerdocumenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides voor Python het toepassingsveld in met de waarde '*Aspose.Slides*' en het PDF‑Producer‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Opmerking** dat u Aspose.Slides voor Python niet kunt instrueren om deze informatie uit de uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Volledige presentaties naar PDF te converteren
* Specifieke dia's in een presentatie naar PDF te converteren

Aspose.Slides exporteert presentaties naar PDF, waardoor de inhoud van de resulterende PDF‑bestanden nauw overeenkomt met de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaard PowerPoint‑naar‑PDF‑conversie wordt uitgevoerd met de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau. Deze Python‑code laat zien hoe u een PowerPoint naar PDF converteert:

_Stappen: PowerPoint‑naar‑PDF‑conversies in Python_

De volgende voorbeeldcode legt deze conversies uit met Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Stappen: PowerPoint naar PDF converteren met Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Stappen: PPT naar PDF converteren met Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Stappen: PPTX naar PDF converteren met Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Stappen: ODP naar PDF converteren met Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Stappen: PPS naar PDF converteren met Python via .NET</a></strong>

**Code‑stappen:**

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en geef deze het PowerPoint‑bestand.
  * _.ppt_ extensie om een **PPT**‑bestand te laden in de _Presentation_‑klasse.
  * _.pptx_ extensie om een **PPTX**‑bestand te laden in de _Presentation_‑klasse.
  * _.odp_ extensie om een **ODP**‑bestand te laden in de _Presentation_‑klasse.
  * _.pps_ extensie om een **PPS**‑bestand te laden in de _Presentation_‑klasse.
- Sla de _Presentation_ op in **PDF**‑formaat door de **Save**‑methode aan te roepen en de enumeratie **SaveFormat.PDF** te gebruiken.

```python
import aspose.slides as slides

# Maakt een instantie van de Presentation‑klasse die een PowerPoint‑bestand voorstelt
presentation = slides.Presentation("PowerPoint.ppt")

# Slaat de presentatie op als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversie‑proces van presentaties naar PDF demonstreert. Voor een live‑implementatie van de hier beschreven procedure kunt u een test uitvoeren met de converter.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides levert aangepaste opties — eigenschappen onder de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF te beveiligen met een wachtwoord, of zelfs het verloop van het conversie‑proces te bepalen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeur voor de kwaliteit van raster‑afbeeldingen instellen, bepalen hoe met metafiles omgegaan wordt, een compressieniveau voor tekst definiëren, DPI voor afbeeldingen instellen, enz.

Het code‑voorbeeld hieronder toont een bewerking waarbij een PowerPoint‑presentatie wordt geconverteerd naar PDF met verschillende aangepaste opties:

```python
import aspose.slides as slides

# Instantieert de PdfOptions-klasse
pdf_options = slides.export.PdfOptions()

# Stelt de kwaliteit in voor JPG-afbeeldingen
pdf_options.jpeg_quality = 90

# Stelt DPI in voor afbeeldingen
pdf_options.sufficient_resolution = 300

# Stelt het gedrag voor metafiles in
pdf_options.save_metafiles_as_png = True

# Stelt het compressieniveau voor tekstinhoud in
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definieert de PDF-conformiteitsmodus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instantieert de Presentation-klasse die een PowerPoint-document voorstelt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Slaat de presentatie op als een PDF-document
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Bevat een presentatie verborgen dia's, dan kunt u de aangepaste optie — de `show_hidden_slides`‑eigenschap van de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse — gebruiken om Aspose.Slides op te dragen de verborgen dia's als pagina's in het resulterende PDF‑bestand op te nemen.

Deze Python‑code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia's inbegrepen:

```python
import aspose.slides as slides

# Maakt een instantie van de Presentation-klasse die een PowerPoint-bestand voorstelt
presentation = slides.Presentation("PowerPoint.pptx")

# Instantieert de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Voegt verborgen dia's toe
pdfOptions.show_hidden_slides = True

# Slaat de presentatie op als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint naar PDF converteren met wachtwoordbeveiliging**

Deze Python‑code laat zien hoe u een PowerPoint naar een wachtwoordbeveiligd PDF converteert (met beveiligingsparameters uit de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse):

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-object dat een PowerPoint-bestand voorstelt
presentation = slides.Presentation("PowerPoint.pptx")

# Instantieert de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Stelt PDF-wachtwoord en toegangsrechten in
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Specifieke dia's in PowerPoint naar PDF converteren**

Deze Python‑code laat zien hoe u geselecteerde dia's in een PowerPoint‑presentatie naar PDF converteert:

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-object dat een PowerPoint-bestand voorstelt
presentation = slides.Presentation("PowerPoint.pptx")

# Stelt een array met dia‑posities in
slides_array = [ 1, 3 ]

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze Python‑code laat zien hoe u een PowerPoint converteert naar PDF wanneer de dia‑grootte vooraf is gespecificeerd:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instantieert de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Maak een nieuwe presentatie met een aangepast diaformaat.
    with slides.Presentation() as resized_presentation:

        # Stel de aangepaste dia-grootte in.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Kloon de eerste dia van de originele presentatie.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Sla de aangepaste presentatie op als PDF met notities.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren in notitie‑diaweergave**

Deze Python‑code laat zien hoe u een PowerPoint naar PDF‑notities converteert:

```python
import aspose.slides as slides

# Instantieert een Presentation-klasse die een PowerPoint-bestand voorstelt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Slaat de presentatie op als PDF-notities
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Toegankelijkheids‑ en conformiteitsnormen voor PDF**

Aspose.Slides biedt een conversie‑procedure die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document naar PDF exporteren volgens een van deze conformiteitsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides‑ondersteuning voor PDF‑conversie‑bewerkingen strekt zich uit tot het omzetten van PDF naar de meest populaire bestandsformaten. U kunt PDF naar HTML, PDF naar afbeelding, PDF naar JPG en PDF naar PNG converteren. Andere gespecialiseerde conversies — PDF naar SVG, PDF naar TIFF en PDF naar XML — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele paden worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de volledige figuur geleverd.

## **FAQ**

**Kan Aspose.Slides voor Python de toepassingsinformatie uit het PDF‑bestand verwijderen?**

Nee, Aspose.Slides voor Python voegt automatisch API‑informatie en het versienummer toe aan het uiteindelijke PDF‑bestand. Deze informatie kan niet worden gewijzigd of verwijderd.

**Hoe kan ik alleen specifieke dia's opnemen in de PDF‑conversie?**

U kunt de gewenste dia‑indices opgeven door een array met dia‑posities door te geven aan de `save`‑methode.

**Is het mogelijk om het PDF‑bestand tijdens de conversie met een wachtwoord te beveiligen?**

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren via de `PdfOptions`‑klasse voordat u de presentatie als PDF opslaat.

**Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?**

Ja, Aspose.Slides ondersteunt het converteren van PDF‑bestanden naar formaten zoals HTML, afbeeldingsformaten (JPG, PNG), SVG, TIFF en XML.

**Hoe zorg ik ervoor dat mijn PDF voldoet aan toegankelijkheidsnormen?**

Stel de `compliance`‑eigenschap in `PdfOptions` in op normen zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te voldoen aan de toegankelijkheidsrichtlijnen.

**Kan ik verborgen dia's opnemen in de PDF‑uitvoer?**

Ja, door de `show_hidden_slides`‑eigenschap in `PdfOptions` op `True` te zetten, worden verborgen dia's in het PDF‑bestand opgenomen.

**Hoe pas ik de beeldkwaliteit en resolutie aan tijdens de conversie?**

Gebruik de eigenschappen `jpeg_quality` en `sufficient_resolution` in `PdfOptions` om de beeldkwaliteit en resolutie in het resulterende PDF te regelen.

**Detecteert Aspose.Slides automatisch lettertype‑substituties?**

Aspose.Slides detecteert lettertype‑substituties tijdens de conversie en u kunt ze afhandelen via de `warning_callback`‑eigenschap in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET‑documentatie](https://docs.aspose.com/slides/nl/python-net/)
- [Aspose.Slides API‑referentie](https://reference.aspose.com/slides/nl/python-net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)