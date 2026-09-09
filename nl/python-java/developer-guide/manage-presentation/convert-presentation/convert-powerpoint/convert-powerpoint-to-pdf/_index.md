---
title: Converteer PPT en PPTX naar PDF in Python via Java [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint converteren
- presentatie converteren
- PowerPoint naar PDF
- presentatie naar PDF
- PPT naar PDF
- PPT converteren naar PDF
- PPTX naar PDF
- PPTX converteren naar PDF
- PowerPoint opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Python via Java met Aspose.Slides, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in Python via Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia's opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia's selecteert voor conversie en nalevingsstandaarden toepast op de output‑documenten.

## **PowerPoint naar PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument door aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode. De [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse biedt de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides for Python via Java voegt zijn API‑informatie en versienummer toe aan output‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie uit output‑documenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Hele presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF’s nauwkeurig overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaardconversie gebruikt de standaard PDF‑exportinstellingen. Gebruik aangepaste opties wanneer u de beeldkwaliteit, paginainhoud of PDF‑naleving moet regelen.

Installeer [Aspose.Slides for Python via Java](/slides/nl/python-java/installation/) en een compatibele Java‑runtime voordat u de voorbeelden uitvoert. Elk voorbeeld leest `presentation.pptx` uit de huidige werkmap; vervang dit door uw PPT‑, PPTX‑ of ODP‑bestand. Start de JVM eenmaal per Python‑proces.

Deze code converteert een presentatie naar PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}

Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, specificeren hoe metafiles worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) methode van de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse gebruiken om de verborgen dia's als pagina's in het resulterende PDF op te nemen.

Deze code toont hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia's inbegrepen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint naar een met wachtwoord beveiligd PDF converteren**

Deze code toont hoe u een PowerPoint‑presentatie converteert naar een met wachtwoord beveiligd PDF met behulp van de beschermingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setWarningCallback) methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse, waarmee u lettertype‑vervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Gebruik een JPype‑proxy om waarschuwings‑callbacks van de Java‑API te ontvangen. Converteer de Java‑beschrijvings‑string naar een Python‑string voordat u de prefix controleert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}

Voor meer informatie over het ontvangen van callbacks voor lettertype‑vervangingen tijdens het renderingsproces, zie [Getting Warning Callbacks for Font Substitution](/slides/nl/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑vervanging, zie het artikel [Font Substitution](/slides/nl/python-java/font-substitution/).

{{% /alert %}}

## **Geselecteerde dia's in PowerPoint naar PDF converteren**

Dia‑nummers die worden doorgegeven aan [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) zijn 1‑gebaseerd. Dit voorbeeld exporteert dia’s 1 en 3 wanneer beide bestaan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Dit voorbeeld exporteert de eerste dia op een pagina van 612 bij 792 punten (US Letter). Het kloont de dia naar een nieuwe presentatie met de opgegeven grootte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Deze code toont hoe u een PowerPoint‑presentatie naar een PDF converteert dat notities bevat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Bij het voorbereiden van toegankelijke PDF’s, raadpleegt u de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gebruik [PdfOptions.setCompliance](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setCompliance) om een output‑standaard te selecteren: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s produceert op basis van verschillende nalevingsstandaarden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**  
Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?**  
Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in het PDF?**  
Gebruik de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) methode in de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides hoge beeldkwaliteit behouden in het PDF?**  
Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) klasse om hoge‑kwaliteit afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**  
Ja, Aspose.Slides maakt het mogelijk PDF’s te exporteren die voldoen aan [verschillende standaarden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, voor toegankelijkheid of archivering. Kies de gewenste standaard en controleer de output volgens uw eisen.

## **Aanvullende bronnen**

- [Aspose.Slides voor Python via Java Documentatie](/slides/nl/python-java/)
- [Aspose.Slides voor Python via Java API‑referentie](https://reference.aspose.com/slides/nl/python-java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)