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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in Python via Java met Aspose.Slides, met snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint-presentaties (PPT, PPTX, ODP, enz.) naar PDF-formaat in Python via Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de layout en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF-documenten kunt omzetten, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF-bestanden met een wachtwoord kunt beveiligen, lettertype-substituties kunt detecteren, specifieke dia's kunt selecteren voor conversie, en nalevingsstandaarden kunt toepassen op de uitvoer-documenten.

## **PowerPoint-naar-PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class en slaat u de presentatie vervolgens op als PDF met de [opslaan](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode. De [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class biedt de [opslaan](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Opmerking" %}}
Aspose.Slides for Python via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application in met "*Aspose.Slides*" en het PDF Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie uit uitvoer‑documenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Complete presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF's nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea-opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint omzetten naar PDF**

De standaardconversie gebruikt de standaard PDF-exportinstellingen. Gebruik aangepaste opties wanneer u de beeldkwaliteit, paginainhoud of PDF-naleving moet regelen.

Installeer [Aspose.Slides voor Python via Java](/slides/nl/python-java/installation/) en een compatibele Java‑runtime voordat u de voorbeelden uitvoert. Elk voorbeeld leest `presentation.pptx` uit de huidige werkmap; vervang dit door uw PPT-, PPTX- of ODP‑bestand. Start de JVM één keer per Python‑proces.

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
Aspose biedt een gratis online [PowerPoint-naar-PDF-conversie](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint omzetten naar PDF met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class—die u in staat stellen het resulterende PDF aan te passen, het PDF te vergrendelen met een wachtwoord, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint omzetten naar PDF met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles behandeld moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

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

### **PowerPoint omzetten naar PDF met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) methode van de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class gebruiken om de verborgen dia's als pagina's in de resulterende PDF op te nemen.

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

### **PowerPoint omzetten naar beveiligde PDF met wachtwoord**

Deze code toont hoe u een PowerPoint-presentatie naar een wachtwoord‑beveiligde PDF kunt converteren met behulp van de beveiligingsparameters uit de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class:

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

### **Lettertype-substituties detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setWarningCallback) methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class, waarmee u lettertype‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

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
Voor meer informatie over het ontvangen van callbacks voor lettertype‑substituties tijdens het renderen, zie [Waarschuwing-callbacks voor lettertype‑substitutie ontvangen](/slides/nl/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, zie het artikel [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/).
{{% /alert %}}

## **Geselecteerde dia's in PowerPoint omzetten naar PDF**

Dia‑nummers die aan [Presentatie.opslaan](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) worden doorgegeven, beginnen bij 1. Dit voorbeeld exporteert dia's 1 en 3 wanneer beide bestaan:

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

## **PowerPoint omzetten naar PDF met aangepaste dia-grootte**

Dit voorbeeld exporteert de eerste dia op een pagina van 612 bij 792 punten (US Letter). Het kloont de dia in een nieuwe presentatie met de opgegeven grootte:

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

## **PowerPoint omzetten naar PDF in notitie-dia-weergave**

Deze code toont hoe u een PowerPoint-presentatie naar een PDF kunt converteren die notities bevat:

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

## **Toegankelijkheids- en nalevingsstandaarden voor PDF**

Bij het voorbereiden van toegankelijke PDF's raadpleegt u de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gebruik [PdfOptions.setCompliance](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setCompliance) om een uitvoerstandaard te selecteren: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint-naar-PDF-conversieproces dat meerdere PDF's produceert op basis van verschillende nalevingsstandaarden:

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

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor de hele figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint-bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT- of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia's opnemen in de PDF?**

Gebruik de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) methode in de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides hoge beeldkwaliteit behouden in de PDF?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) class om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A-nalevingsstandaarden?**

Ja, Aspose.Slides stelt u in staat om PDF's te exporteren die voldoen aan [diverse standaarden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, voor toegankelijkheid of archivering. Kies de juiste standaard en controleer de output tegen uw eisen.

## **Aanvullende bronnen**

- [Aspose.Slides voor Python via Java-documentatie](/slides/nl/python-java/)
- [Aspose.Slides voor Python via Java API-referentie](https://reference.aspose.com/slides/nl/python-java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)