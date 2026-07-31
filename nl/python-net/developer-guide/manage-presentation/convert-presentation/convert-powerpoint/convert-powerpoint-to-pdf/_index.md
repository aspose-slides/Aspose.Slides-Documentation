---
title: "PPT & PPTX naar PDF converteren in Python | Geavanceerde opties"
linktitle: "PowerPoint naar PDF"
type: docs
weight: 40
url: /nl/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
description: "Stap‑voor‑stap gids voor het converteren van PPT, PPTX en ODP naar hoogwaardige, WCAG‑conforme PDF‑bestanden in Python met Aspose.Slides — inclusief wachtwoordbeveiliging, selectie van dia's en controle over beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP) converteren naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het garanderen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, diverse opties gebruikt om de beeldkwaliteit te regelen, verborgen dia's opneemt, PDF‑documenten beveiligt met een wachtwoord, lettertype‑substituties detecteert, specifieke dia's selecteert voor conversie en nalevingsnormen toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python, geeft u simpelweg de bestandsnaam als argument mee aan de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met een [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode. De [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse biedt de [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="OPMERKING"  color="warning"   %}} 

Aspose.Slides for Python schrijft rechtstreeks API‑informatie en versienummer in de uitvoer‑documenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides for Python het veld *Application* met de waarde '*Aspose.Slides*' en het PDF‑Producer‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Opmerking** dat u Aspose.Slides for Python niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit de uitvoer‑documenten.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Hele presentaties naar PDF
* Specifieke dia's in een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de inhoud van de resulterende PDF‑bestanden nauwkeurig overeenkomt met de oorspronkelijke presentaties. Elementen en attributen worden correct weergegeven tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaard PowerPoint‑naar‑PDF‑conversie wordt uitgevoerd met de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie te converteren naar PDF met optimale instellingen op het hoogste kwaliteitsniveau. Deze Python‑code toont hoe u een PowerPoint naar PDF converteert:

*Stappen: PowerPoint‑naar‑PDF‑conversies in Python*

De volgende voorbeeldcode verduidelijkt deze conversies met Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Stappen: PowerPoint naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Stappen: PPT naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Stappen: PPTX naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Stappen: ODP naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Stappen: PPS naar PDF converteren met Python via .NET</strong></a>

**Code‑stappen:**

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en geef het PowerPoint‑bestand door.
  * _.ppt_‑extensie om een **PPT**‑bestand te laden in de _Presentation_‑klasse.
  * _.pptx_‑extensie om een **PPTX**‑bestand te laden in de _Presentation_‑klasse.
  * _.odp_‑extensie om een **ODP**‑bestand te laden in de _Presentation_‑klasse.
  * _.pps_‑extensie om een **PPS**‑bestand te laden in de _Presentation_‑klasse.
- Sla de _Presentation_ op in **PDF**‑formaat door de **Save**‑methode aan te roepen en de enumeratie **SaveFormat.PDF** te gebruiken.

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.ppt")

# Slaat de presentatie op als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversie‑proces van presentatie naar PDF demonstreert. Voor een live‑implementatie van de hier beschreven procedure kunt u een test uitvoeren met de converter.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse — die u in staat stellen om het PDF (verkregen uit het conversie‑proces) aan te passen, het PDF te beveiligen met een wachtwoord, of zelfs te bepalen hoe het conversie‑proces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteit voor raster‑afbeeldingen instellen, bepalen hoe metafiles worden behandeld, een compressieniveau voor tekst opgeven, DPI voor afbeeldingen instellen, enzovoort.

Het onderstaande code‑voorbeeld toont een bewerking waarbij een PowerPoint‑presentatie wordt geconverteerd naar PDF met verschillende aangepaste opties:

```python
import aspose.slides as slides

# Maakt een instantie van de PdfOptions-klasse
pdf_options = slides.export.PdfOptions()

# Stelt de kwaliteit voor JPG-afbeeldingen in
pdf_options.jpeg_quality = 90

# Stelt de DPI voor afbeeldingen in
pdf_options.sufficient_resolution = 300

# Stelt het gedrag voor metafiles in
pdf_options.save_metafiles_as_png = True

# Stelt het compressieniveau voor tekstinhoud in
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definieert de PDF-nalevingsmodus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Maakt een instantie van de Presentation-klasse die een PowerPoint-document vertegenwoordigt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Slaat de presentatie op als PDF-document
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Bevat een presentatie verborgen dia's, dan kunt u met de aangepaste optie — de eigenschap `show_hidden_slides` van de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse — Aspose.Slides instrueren om de verborgen dia's op te nemen als pagina's in het resulterende PDF.

Deze Python‑code toont hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia's inbegrepen:

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Maakt een instantie van de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Voegt verborgen dia's toe
pdfOptions.show_hidden_slides = True

# Slaat de presentatie op als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint naar wachtwoordbeveiligde PDF converteren**

Deze Python‑code toont hoe u een PowerPoint naar een wachtwoordbeveiligde PDF converteert (met bescherming‑parameters uit de [PdfOptions](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides.export/pdfoptions/)‑klasse):

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-object dat een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Maakt een instantie van de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Stelt het PDF-wachtwoord en de toegangsrechten in
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Selectieve dia's in PowerPoint naar PDF converteren**

Deze Python‑code toont hoe u specifieke dia's in een PowerPoint‑presentatie naar PDF converteert:

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-object dat een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Stelt een array met dia-posities in
slides_array = [ 1, 3 ]

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze Python‑code toont hoe u een PowerPoint waarvan de dia‑grootte is gespecificeerd, naar PDF converteert:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Maak een nieuwe presentatie met een aangepaste dia-grootte.
    with slides.Presentation() as resized_presentation:

        # Stel de aangepaste dia-grootte in.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Kloon de eerste dia van de oorspronkelijke presentatie.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Sla de vergrote presentatie op als PDF met notities.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren in notitiedia‑weergave**

Deze Python‑code toont hoe u een PowerPoint naar PDF‑notities converteert:

```python
import aspose.slides as slides

# Maakt een instantie van een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Slaat de presentatie op als PDF-notities
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides maakt het mogelijk om een conversie‑procedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze Python‑code demonstreert een PowerPoint‑naar‑PDF‑conversie waarbij meerdere PDF‑bestanden worden verkregen op basis van verschillende nalevingsnormen:

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

{{% alert title="Opmerking" color="warning" %}} 

Aspose.Slides‑ondersteuning voor PDF‑conversie‑bewerkingen strekt zich uit tot het converteren van PDF naar de meest populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversies naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de gehele afbeelding geleverd.

## **FAQ**

**Kan Aspose.Slides for Python de applicatie‑informatie uit de PDF verwijderen?**

Nee, Aspose.Slides for Python voegt automatisch API‑informatie en het versienummer toe aan de uitvoer‑PDF. Deze informatie kan niet worden aangepast of verwijderd.

**Hoe kan ik alleen bepaalde dia's opnemen in de PDF‑conversie?**

U kunt de gewenste dia‑indexen opgeven door een array met dia‑posities aan de `save`‑methode door te geven.

**Is het mogelijk om de PDF tijdens de conversie te beveiligen met een wachtwoord?**

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren met de `PdfOptions`‑klasse voordat u de presentatie opslaat als PDF.

**Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?**

Ja, Aspose.Slides ondersteunt het converteren van PDF naar formaten zoals HTML, afbeeldingsformaten (JPG, PNG), SVG, TIFF en XML.

**Hoe kan ik ervoor zorgen dat mijn PDF voldoet aan toegankelijkheidsnormen?**

Stel de eigenschap `compliance` in `PdfOptions` in op normen zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te voldoen aan de toegankelijkheidsrichtlijnen.

**Kan ik verborgen dia's opnemen in de PDF‑output?**

Ja, door de eigenschap `show_hidden_slides` in `PdfOptions` op `True` te zetten, worden verborgen dia's opgenomen in de PDF.

**Hoe pas ik de beeldkwaliteit en resolutie tijdens de conversie aan?**

Gebruik de eigenschappen `jpeg_quality` en `sufficient_resolution` in `PdfOptions` om de beeldkwaliteit en resolutie van de resulterende PDF te regelen.

**Detecteert Aspose.Slides automatisch font‑substituties?**

Aspose.Slides detecteert font‑substituties tijdens de conversie en u kunt ze afhandelen via de eigenschap `warning_callback` in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides for .NET Documentatie](https://docs.aspose.com/slides/nl/python-net/)
- [Aspose.Slides API‑referentie](https://reference.aspose.com/slides/nl/python-net/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)