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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Stapsgewijze handleiding voor het converteren van PPT, PPTX en ODP naar PDF‑bestanden van hoge kwaliteit en WCAG‑conformiteit in Python met Aspose.Slides — inclusief wachtwoordbeveiliging, selectie van dia's en controle van de beeldkwaliteit."
showReadingTime: true
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP) naar PDF‑formaat in Python biedt verschillende voordelen, waaronder het waarborgen van compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, diverse opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑documenten kunt beveiligen met een wachtwoord, lettertype‑vervangingen kunt detecteren, specifieke dia's voor conversie kunt selecteren en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **Installatie**

```bash
pip install aspose.slides
```

Het pakket bevat de benodigde runtime, zodat Microsoft PowerPoint niet op de machine die de conversie uitvoert geïnstalleerd hoeft te zijn.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in deze formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren in Python, hoeft u alleen de bestandsnaam als argument door te geven aan de [Presentatie](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse en vervolgens de presentatie op te slaan als PDF met behulp van de [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode. De [Presentatie](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse biedt de [Save](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/#methods)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python schrijft rechtstreeks API‑informatie en versienummer in de uitvoerdocumenten. Bijvoorbeeld, wanneer het een presentatie naar PDF converteert, vult Aspose.Slides for Python het toepassingsveld in met de '*Aspose.Slides*'‑waarde en het PDF‑producent‑veld met een waarde in de vorm '*Aspose.Slides v XX.XX*'. **Opmerking** dat u Aspose.Slides for Python niet kunt instrueren om deze informatie uit de uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's in een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de inhoud van de resulterende PDF's nauwkeurig overeenkomt met de originele presentaties. Elementen en attributen worden precies gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaard PowerPoint‑naar‑PDF‑conversie‑operatie wordt uitgevoerd met de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximale kwaliteitsniveaus. Deze Python‑code laat zien hoe u een PowerPoint naar PDF kunt converteren:

_Stappen: PowerPoint‑naar‑PDF‑conversies in Python_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Stappen: PowerPoint naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Stappen: PPT naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Stappen: PPTX naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Stappen: ODP naar PDF converteren met Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Stappen: PPS naar PDF converteren met Python via .NET</strong></a>

_Code‑stappen:_

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse aan en geef deze het PowerPoint‑bestand.
  * _.ppt_ extensie om een **PPT**‑bestand te laden in de _Presentatie_-klasse.
  * _.pptx_ extensie om een **PPTX**‑bestand te laden in de _Presentatie_-klasse.
  * _.odp_ extensie om een **ODP**‑bestand te laden in de _Presentatie_-klasse.
  * _.pps_ extensie om een **PPS**‑bestand te laden in de _Presentatie_-klasse.
- Sla de _Presentatie_ op in **PDF**‑formaat door de **Save**‑methode aan te roepen en de **SaveFormat.PDF**‑enumeratie te gebruiken.
  

```python
import aspose.slides as slides

# Instantieert een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.ppt")

# Slaat de presentatie op als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversie‑proces van presentatie naar PDF demonstreert. Voor een live implementatie van de hier beschreven procedure kunt u een test doen met de converter.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions]‑klasse—die u in staat stellen het PDF (dat voortkomt uit het conversieproces) aan te passen, het PDF met een wachtwoord te beveiligen, of zelfs te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen instellen, specificeren hoe metafiles moeten worden verwerkt, een compressieniveau voor teksten bepalen, DPI voor afbeeldingen instellen, enzovoort.

De code‑voorbeeld hieronder toont een operatie waarbij een PowerPoint‑presentatie wordt geconverteerd naar PDF met verschillende aangepaste opties:

```python
import aspose.slides as slides

# Instantieert de PdfOptions-klasse
pdf_options = slides.export.PdfOptions()

# Stelt de kwaliteit voor JPG-afbeeldingen in
pdf_options.jpeg_quality = 90

# Stelt de DPI voor afbeeldingen in
pdf_options.sufficient_resolution = 300

# Stelt het gedrag voor metafiles in
pdf_options.save_metafiles_as_png = True

# Stelt het compressieniveau voor tekstuele inhoud in
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definieert de PDF-conformiteitsmodus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instantieert de Presentation-klasse die een PowerPoint-document vertegenwoordigt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Slaat de presentatie op als PDF-document
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u een aangepaste optie—de eigenschap `show_hidden_slides` van de [PdfOptions]‑klasse—om Aspose.Slides te instrueren de verborgen dia's op te nemen als pagina's in het resulterende PDF.

Deze Python‑code laat zien hoe u een PowerPoint‑presentatie naar PDF kunt converteren met verborgen dia's inbegrepen:

```python
import aspose.slides as slides

# Instantieert een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Instantieert de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Voegt verborgen dia's toe
pdfOptions.show_hidden_slides = True

# Slaat de presentatie op als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint naar PDF converteren met wachtwoordbeveiliging**

Deze Python‑code laat zien hoe u een PowerPoint naar een wachtwoordbeveiligd PDF kunt converteren (met beveiligingsparameters uit de [PdfOptions]‑klasse):

```python
import aspose.slides as slides

# Instantieert een Presentation-object dat een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Instantieert de PdfOptions-klasse
pdfOptions = slides.export.PdfOptions()

# Stelt PDF-wachtwoord en toegangsrechten in
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Geselecteerde dia's in PowerPoint naar PDF converteren**

Deze Python‑code laat zien hoe u specifieke dia's in een PowerPoint‑presentatie naar PDF kunt converteren:

```python
import aspose.slides as slides

# Instantieert een Presentation-object dat een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("PowerPoint.pptx")

# Stelt een array met dia‑posities in
slides_array = [ 1, 3 ]

# Slaat de presentatie op als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze Python‑code laat zien hoe u een PowerPoint wanneer de dia‑grootte is gespecificeerd naar PDF kunt converteren:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instantieert de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Maak een nieuwe presentatie met een aangepaste dia-grootte.
    with slides.Presentation() as resized_presentation:

        # Stel de aangepaste dia-grootte in.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Kloon de eerste dia van de originele presentatie en verwijder de standaard lege dia.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Sla de vergrote presentatie op als PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint naar PDF converteren in de notities‑dia‑weergave**

Deze Python‑code laat zien hoe u een PowerPoint naar PDF‑notities kunt converteren:

```python
import aspose.slides as slides

# Instantieert een Presentation-klasse die een PowerPoint-bestand vertegenwoordigt
presentation = slides.Presentation("NotesFile.pptx")

# Configureert de PDF-opties met de notitie‑lay-out
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Slaat de presentatie op als PDF met notities
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met elk van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze Python‑code demonstreert een PowerPoint‑naar‑PDF‑conversie‑operatie waarin meerdere PDF’s op basis van verschillende nalevingsnormen worden verkregen:

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

De ondersteuning van Aspose.Slides voor PDF‑conversie‑operaties strekt zich uit tot het converteren van PDF naar de populairste bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/python-net/conversion/pdf-to-xml/)—worden ook ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de hele figuur verstrekt.

## **Veelgestelde vragen**

### Kan Aspose.Slides for Python de toepassingsinformatie uit het PDF verwijderen?

Nee, Aspose.Slides for Python voegt automatisch API‑informatie en het versienummer toe aan het uitgangs‑PDF. Deze informatie kan niet worden aangepast of verwijderd.

### Hoe kan ik alleen specifieke dia's opnemen in de PDF‑conversie?

U kunt de dia‑indices die u wilt converteren opgeven door een array met dia‑posities door te geven aan de `save`‑methode.

### Is het mogelijk om het PDF tijdens de conversie met een wachtwoord te beveiligen?

Ja, u kunt een wachtwoord instellen en toegangsrechten definiëren met behulp van de `PdfOptions`‑klasse voordat u de presentatie opslaat als PDF.

### Ondersteunt Aspose.Slides het converteren van PDF naar andere formaten?

Ja, Aspose.Slides ondersteunt het converteren van PDF’s naar formaten zoals HTML, afbeeldingsformaten (JPG, PNG), SVG, TIFF en XML.

### Hoe kan ik ervoor zorgen dat mijn PDF voldoet aan toegankelijkheidsnormen?

Stel de `compliance`‑eigenschap in `PdfOptions` in op normen zoals `PDF_A1A`, `PDF_A1B` of `PDF_UA` om te waarborgen dat het PDF voldoet aan de toegankelijkheidsrichtlijnen.

### Kan ik verborgen dia's opnemen in de PDF‑output?

Ja, door de `show_hidden_slides`‑eigenschap in `PdfOptions` op `True` te zetten, worden verborgen dia's opgenomen in het PDF.

### Hoe kan ik de beeldkwaliteit en resolutie tijdens de conversie aanpassen?

Gebruik de `jpeg_quality`‑ en `sufficient_resolution`‑eigenschappen in `PdfOptions` om de beeldkwaliteit en resolutie in het resulterende PDF te beheersen.

### Handelt Aspose.Slides automatisch lettertypevervangingen af?

Aspose.Slides detecteert lettertypevervangingen tijdens de conversie, en u kunt ze afhandelen met de `warning_callback`‑eigenschap in `SaveOptions` (momenteel beperkt).

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET-documentatie](https://docs.aspose.com/slides/nl/python-net/)
- [Aspose.Slides API‑referentie](https://reference.aspose.com/slides/nl/python-net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)