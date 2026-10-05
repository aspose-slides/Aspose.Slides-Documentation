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
- PPT naar PDF converteren
- PPTX naar PDF
- PPTX naar PDF converteren
- PowerPoint opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in Python via Java met Aspose.Slides, met snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF converteren in Python via Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en behoud van lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia’s selecteert voor conversie en nalevingsnormen toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met de [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode. De [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java voegt zijn API‑informatie en versienummer toe aan output‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit output‑documenten.

{{% /alert %}}

Aspose.Slides stelt u in staat om:

* gehele presentaties naar PDF te converteren
* specifieke dia’s uit een presentatie naar PDF te converteren

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaardconversie gebruikt de standaard PDF‑exportinstellingen. Gebruik aangepaste opties wanneer u de beeldkwaliteit, paginainhoud of PDF‑naleving moet regelen.

Installeer [Aspose.Slides for Python via Java](/slides/nl/python-java/installation/) en een compatibele Java‑runtime voordat u de voorbeelden uitvoert. Elk voorbeeld leest `presentation.pptx` uit de huidige werkmap; vervang dit door uw PPT‑, PPTX‑ of ODP‑bestand. Start de JVM één keer per Python‑proces.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard exportinstellingen.

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

{{% alert color="info" title="Note" %}}

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF‑bestand met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeur voor beeldkwaliteit instellen voor raster‑afbeeldingen, bepalen hoe metafiles worden verwerkt, een compressieniveau voor tekst definiëren, DPI voor afbeeldingen configureren, enzovoort.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Bevat een presentatie een ingesloten Excel‑werkmap, dan wilt u mogelijk dat PDF‑ontvangers zowel de data van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `True` om ingesloten OLE‑bestanden te behouden als bijlagen in het resulterende PDF‑bestand.

De standaardwaarde is `False`: de preview‑afbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingesloten bestand wordt niet als bijlage toegevoegd. Als de optie op `True` wordt gezet, wordt de bestandsdata bovendien toegevoegd. De preview blijft een visuele weergave; de bijlage laat ontvangers het ingesloten bestand afzonderlijk openen of opslaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die reeds een ingesloten Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de data te inspecteren, of open hem direct als de viewer dat toestaat. De preview op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}

De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkmappen. Dit zijn eisen van de normen, geen beperkingen die specifiek aan Aspose.Slides zijn verbonden. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, dan kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑methode van de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF‑bestand op te nemen.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia’s.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint naar een wachtwoord‑beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die geopend moet worden met het wachtwoord `password`. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype‑substituties tijdens het conversie‑proces van presentatie naar PDF kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en drukt waarschuwingen voor lettertype‑substituties af op de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export. Gebruik een JPype‑proxy om waarschuwing‑callbacks van de Java‑API te ontvangen. Converteer de Java‑beschrijvings‑string naar een Python‑string voordat u de prefix controleert:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/python-java/font-substitution/).

{{% /alert %}}

## **Selectieve dia’s uit PowerPoint naar PDF converteren**

Dia‑nummers die worden doorgegeven aan [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) zijn 1‑gebaseerd. Dit voorbeeld exporteert dia 1 en 3 wanneer beide bestaan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Dit voorbeeld exporteert de eerste dia op een pagina van 612 bij 792 punten (US Letter). Het kloont de dia naar een nieuwe presentatie met de opgegeven grootte en schaalt de dia‑inhoud zodat deze past.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Verwijder de lege dia die bij het maken van de nieuwe presentatie is aangemaakt.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint naar PDF converteren in notitiedia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities onder elke dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Bij het voorbereiden van toegankelijke PDF‑bestanden, raadpleeg de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gebruik [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) om een uitvoerstandaard te selecteren: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsnormen:

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

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de hele figuur geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversie‑proces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversie‑proces.

**Hoe kan ik verborgen dia’s in de PDF opnemen?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aan met `True` in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF‑bestand.

**Kan Aspose.Slides een hoge beeldkwaliteit behouden in de PDF?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om hoge‑kwaliteit afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), inclusief PDF/A1a, PDF/A1b en PDF/UA, voor toegankelijkheid of archivering. Kies de passende norm en controleer de output volgens uw vereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Python via Java Documentation](/slides/nl/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)