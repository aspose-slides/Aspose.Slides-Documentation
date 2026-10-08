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
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Python via Java met Aspose.Slides, met snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in Python via Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia’s kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑vervangingen kunt detecteren, specifieke dia’s kunt selecteren voor conversie en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met de [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode. De [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het Application‑veld met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoer‑documenten te verwijderen of te wijzigen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Complete presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kopteksten en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaardconversie gebruikt de standaardinstellingen voor PDF‑export. Gebruik aangepaste opties wanneer u de beeldkwaliteit, paginainhoud of PDF‑naleving moet regelen.

Installeer [Aspose.Slides for Python via Java](/slides/nl/python-java/installation/) en een compatibele Java‑runtime voordat u de voorbeelden uitvoert. Elk voorbeeld leest `presentation.pptx` uit de huidige werkmap; vervang dit door uw PPT-, PPTX- of ODP‑bestand. Start de JVM één keer per Python‑proces.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard export‑instellingen.

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
Aspose biedt een gratis online [**PowerPoint naar PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF‑bestand met een wachtwoord te beveiligen of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

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

### **Ingebedde OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebedde Excel‑werkmap bevat, wilt u wellicht dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `True` om ingebedde OLE‑bestanden als bijlagen in de resulterende PDF te behouden.

Standaardwaarde is `False`: de preview‑afbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingebedde bestand wordt niet als bijlage toegevoegd. Door de optie op `True` te zetten wordt het bestand bovendien bijgevoegd. De preview blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingebedde bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebedde Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingebedde werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer het toestaat. De preview op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen stellen beperkingen op bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, inclusief Excel‑werkmappen. Dit zijn eisen van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑naleving en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑methode van de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in de resulterende PDF op te nemen.

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

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

### **Lettertypevervanging detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse, waarmee u lettertypevervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en drukt waarschuwingen over lettertypevervanging af naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen. Gebruik een JPype‑proxy om waarschuwing‑callbacks van de Java‑API te ontvangen. Converteer de Java‑beschrijvingsreeks naar een Python‑string voordat u de prefix controleert:

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
Voor meer informatie over lettertypevervanging, zie het artikel [Lettertypevervanging](/slides/nl/python-java/font-substitution/).
{{% /alert %}}

### **Lettertypen zonder een eigen vet‑typeface verwerken**

Een presentatie kan vet opmaak toepassen op tekst zelfs wanneer het gebruikte lettertype geen eigen vet‑typeface heeft. De tekst kan nog steeds vet lijken door synthetische vetmaking, die de gewone glyphs kunstmatig dikker maakt. Als die tekst te zwaar of anderszins afwijkt van de gewenste weergave in PDF, probeer dan [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) aan te roepen met `True`. Deze optie rendert de betrokken tekst als een bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. Standaardwaarde is `False`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opmaak toegepast op hetzelfde lettertype, dat geen eigen vet‑typeface heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde vet‑stijlen in en exporteert deze naar PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

De volgende voorbeelden tonen de uitgeschakelde en ingeschakelde uitvoer. In dit voorbeeld heeft de vetgedrukte tekst zwaardere strepen wanneer de optie uitgeschakeld is. Met de optie ingeschakeld zijn de strepen lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling kiest voor uw presentatie.

| Optie uitgeschakeld (`False`, de standaard) | Optie ingeschakeld (`True`) |
|---|---|
| ![PDF met rasterisatie van niet‑ondersteunde vetstijl uitgeschakeld](unsupported-bold-disabled.png) | ![PDF met rasterisatie van niet‑ondersteunde vetstijl ingeschakeld](unsupported-bold-enabled.png) |

In dit voorbeeld wordt bij inschakelen van de optie alleen de vetgedrukte tekst omgezet naar een bitmap: deze kan niet worden geselecteerd, gekopieerd of gezocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vet‑typeface heeft. [Lettertypevervanging](/slides/nl/python-java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Dia‑nummers die aan [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) worden doorgegeven, zijn 1‑gebaseerd. Dit voorbeeld exporteert dia 1 en 3 wanneer beide bestaan:

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

    # Verwijder de lege dia die bij het aanmaken van de nieuwe presentatie is toegevoegd.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker­notities onder elke dia worden geplaatst. Gebruik een presentatie met spreker­notities om het resultaat te zien.

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

## **Toegankelijkheids‑ en compliance‑normen voor PDF**

Bij het voorbereiden van toegankelijke PDF‑bestanden raadpleegt u de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gebruik [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) om een uitvoerstandaard te selecteren: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende compliance‑normen:

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

> **Opmerking:** Bij export naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aan met `True` in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om hoge‑kwaliteit afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides maakt het mogelijk om PDF‑bestanden te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, voor toegankelijkheid of archivering. Kies de juiste norm en controleer de uitvoer ten opzichte van uw eisen.

## **Aanvullende bronnen**

- [Aspose.Slides for Python via Java Documentation](/slides/nl/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)