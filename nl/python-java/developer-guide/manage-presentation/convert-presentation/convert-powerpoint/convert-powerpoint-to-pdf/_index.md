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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Python via Java met Aspose.Slides, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) omzetten naar PDF‑formaat in Python via Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en behoud van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de afbeeldingskwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden beveiligt met een wachtwoord, lettertype‑substituties detecteert, specifieke dia’s selecteert voor conversie en regelgeving toepast op de gegenereerde documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentatie](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met de [opslaan](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode. De [Presentatie](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse biedt de [opslaan](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoer‑documenten te verwijderen of te wijzigen.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF’s nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

De standaardconversie gebruikt de standaardinstellingen voor PDF‑export. Gebruik aangepaste opties wanneer u de kwaliteit van afbeeldingen, paginainhoud of PDF‑conformiteit moet regelen.

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

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF‑bestand met een wachtwoord te beveiligen of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingsresolutie op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

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

### **Automatisch de afbeeldingscompressie selecteren**

Wanneer een presentatie veel foto’s of screenshots bevat, kan het verkleinen van de grootte van het geëxporteerde PDF‑bestand het e‑mailen of downloaden vergemakkelijken. Roep [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) aan met `True` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens de PDF‑export.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt automatische afbeeldingscompressie in en slaat deze op als PDF‑document. Alle andere PDF‑exportinstellingen behouden hun standaardwaarden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Deze optie selecteert een compressie‑algoritme voor elke afbeelding. Het verlagen van de waarde die aan [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) wordt doorgegeven, verlaagt in plaats daarvan de JPEG‑beeldkwaliteit, terwijl het verlagen van de waarde die aan [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) wordt doorgegeven, afbeeldingen naar een lagere resolutie downsamplet, wat details kan verminderen. Het inschakelen van automatische compressie‑selectie verlaagt deze instellingen zelf niet.

Het selecteren van compressie‑algoritmen vereist extra verwerkingstijd en geheugen. De grootte‑reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie is niet gegarandeerd voor elke presentatie.

### **Ingebedde OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebedde Excel‑werkmap bevat, wilt u mogelijk dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `True` om ingebedde OLE‑bestanden te behouden als bijlagen in het resulterende PDF‑bestand.

De standaardwaarde is `False`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingebedde bestand wordt niet opgenomen als bijlage. Het instellen van de optie op `True` voegt bovendien de bestandsgegevens toe. Het voorbeeld blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingebedde bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

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
2. Open het **Bijlagen**‑paneel van de viewer en zoek de ingebedde werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}

De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkmappen. Dit zijn eisen van de normen, geen beperkingen die specifiek aan Aspose.Slides zijn. Dit voorbeeld gebruikt de standaard PDF‑conformiteitsinstelling en toont geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑methode van de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF‑bestand op te nemen.

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

### **PowerPoint naar een wachtwoord‑beveiligd PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse, waarmee u tijdens het presentatie‑naar‑PDF‑conversieproces lettertype‑substituties kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype‑substituties naar de console. Een waarschuwing wordt alleen weergegeven wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen. Gebruik een JPype‑proxy om waarschuwing‑callbacks van de Java‑API te ontvangen. Converteer de Java‑beschrijvings‑string naar een Python‑string voordat u de prefix controleert:

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

Voor meer informatie over lettertype‑substitutie, zie het artikel [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/).

{{% /alert %}}

### **Omgaan met lettertypen zonder een eigen vette stijl**

Een presentatie kan vet opmaak toepassen op tekst zelfs wanneer het lettertype geen eigen vette stijl heeft. De tekst kan nog steeds vet verschijnen via synthetisch vette weergave, waarbij de reguliere glieven kunstmatig verdikt worden. Wanneer die vetgedrukte tekst te zwaar of anderszins afwijkt van de gewenste weergave in PDF, probeer dan [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) aan te roepen met `True`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. De standaardwaarde is `False`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vette opmaak toegepast op hetzelfde lettertype, dat geen eigen vette stijl heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in en exporteert deze naar PDF:

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

De onderstaande voorbeelden tonen de output met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vetgedrukte tekst dikkere streken wanneer de optie uitgeschakeld is. Met de optie ingeschakeld zijn de streken lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`False`, standaard) | Optie ingeschakeld (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vetgedrukte tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vette stijl heeft. [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

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

Dit voorbeeld exporteert de eerste dia op een pagina van 612 bij 792 punten (US Letter). Het dupliceert de dia in een nieuwe presentatie met de opgegeven grootte en schaalt de dia‑inhoud om te passen.

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

## **PowerPoint naar PDF in notitie‑dia‑weergave converteren**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van de spreker onder elke dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

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

## **Toegankelijkheid en conformiteitsnormen voor PDF**

Bij het maken van toegankelijke PDF’s, raadpleeg de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gebruik [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) om een uitvoerstandaard te selecteren: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s produceert op basis van verschillende conformiteitsnormen:

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

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de volledige afbeelding geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aan met `True` in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia’s in de resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge afbeeldingskwaliteit in de PDF behouden?**

Ja, u kunt de afbeeldingskwaliteit regelen door methoden zoals [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)‑klasse te gebruiken om hoogwaardige afbeeldingen in uw PDF te verzekeren.

**Ondersteunt Aspose.Slides PDF/A‑conformiteitsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, voor toegankelijkheid of archivering. Kies de gewenste norm en controleer de output ten opzichte van uw eisen.

## **Aanvullende bronnen**

- [Aspose.Slides for Python via Java Documentatie](/slides/nl/python-java/)
- [Aspose.Slides for Python via Java API‑referentie](https://reference.aspose.com/slides/python-java/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/conversion)