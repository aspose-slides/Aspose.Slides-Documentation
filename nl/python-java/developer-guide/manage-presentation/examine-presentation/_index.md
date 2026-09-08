---
title: Presentatie-informatie ophalen en bijwerken in Python via Java
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/python-java/examine-presentation/
keywords:
- presentatieformaat
- presentatie-eigenschappen
- documenteigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX bekijken
- PPT bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Python via Java voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Aspose.Slides kan het bestandsformaat van een presentatie identificeren en de metagegevens van het document lezen zonder een volledig presentatie‑objectmodel te creëren. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opstellen of eigenschappen moet inspecteren voordat u beslist of u de presentatie‑inhoud moet laden en verwerken.

De voorbeelden vereisen Aspose.Slides voor Python via Java en een compatibele Java-runtime. Elk voorbeeld start de JVM als deze nog niet draait. Zorg voor bestaande presentatie‑bestanden op de paden die in de voorbeelden worden gebruikt.

Dit artikel demonstreert een lichte inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/) en [PresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/), evenals gerichte updates via [DocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/).

## **Controleer een presentatieformaat**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie te maken. De methode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#getLoadFormat) geeft het gedetecteerde formaat terug, zoals PPTX, PPT of ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Bouw een lichte presentatie‑inventaris**

Wanneer u veel presentaties‑bestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) om een [PresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/)‑object te verkrijgen, en roept u vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) aan om de document‑metadata te lezen. Deze aanpak creëert geen [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [DocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/) worden blootgesteld, bieden de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getSlides) | Totaal aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getNotes) | Aantal dia's die notities bevatten. |
| [getParagraphs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getParagraphs) | Totaal aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getWords) | Totaal aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Totaal aantal audio‑ en video‑clips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert tevens [getHeadingPairs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getHeadingPairs) met [getTitlesOfParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getTitlesOfParts) om inhoudsgroepen weer te geven, zoals lettertypen, thema's en dia‑titels.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Elke [HeadingPair](https://reference.aspose.com/slides/nl/python-java/aspose.slides/headingpair/) levert een groepsnaam en het aantal items in die groep. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getTitlesOfParts) retourneert een platte, geordende array, dus consumeer het aantal opeenvolgende titels dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen metadata en formaatbeperkingen**

De inventaris‑eigenschappen die worden geretourneerd door [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) weerspiegelen de metadata die beschikbaar is in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden voor deze oproep opnieuw te berekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand het laatst opsloeg de document‑eigenschappen niet bijwerkte.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor dia‑, notitie‑, verborgen‑dia‑, alinea‑, woord‑ en multimedia‑telling, evenals heading pairs en part titles. De beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn geschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings‑eigenschappen opslaan. Als een eigenschap ontbreekt of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze van de dia's te berekenen.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woord‑telling, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata over verborgen‑dia's, notitie‑dia's, multimedia, heading‑pair en part‑title kan ontbreken, en de inventaris‑eigenschappen kunnen standaardwaarden retourneren. Beschouw een nul‑waarde of een lege array niet als doorslaggevend bewijs dat de overeenkomstige inhoud afwezig is.

Gebruik de lichte metadata‑aanpak voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de daadwerkelijke presentatiewaarde moet verifiëren.

## **Werk presentatie‑eigenschappen bij**

De eigenschappen die worden geretourneerd door [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie te maken. Pas de wijzigingen toe met [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), en schrijf vervolgens de gekoppelde presentatie weg met [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

De volgende afbeelding toont de oorspronkelijke documenteigenschappen.

![Oorspronkelijke documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatste‑opslagtijd en schrijft het resultaat naar een nieuw bestand:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/python-java/password-protected-presentation/)
- [Presentaties met schrijfbescherming](/slides/nl/python-java/write-protected-presentation/)

## **Veelgestelde vragen**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getFontsManager). Roep [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) aan om de ingesloten lettertypen te verkrijgen en [FontsManager.getFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFonts) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel bepalen of het bestand verborgen dia's bevat en hoeveel?**

Wanneer de opgeslagen documentmetadata voldoende is, lees [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) en [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Dit is geschikt voor een lichte inventaris. Als de presentatie in het geheugen is gewijzigd, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u live waarden verifiëren door door [Presentation.getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides) te itereren en elke dia's [Slide.getHidden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getHidden)‑methode te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en roep [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlideSize) aan. Gebruik [SlideSize.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/#getSize) en [SlideSize.getOrientation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/#getOrientation) om de huidige instellingen te vergelijken met de verwachte voorinstelling en afmetingen.

**Is er een snelle manier om te zien of diagrammen externe gegevensbronnen refereren?**

Ja. Zoek elk [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/) op en roep [ChartData.getDataSourceType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getDataSourceType) aan. Voor een extern werkboek roept u [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) aan. Het type gegevensbron en het pad identificeren een externe referentie, maar om te verifiëren of het doel beschikbaar is, is een aparte resource‑controle vereist.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation.getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides) en de [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getShapes)‑collectie van elke dia. Gebruik het aantal shapes en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als signalen, en meet een representatieve weergave of export voordat u een dia als een bevestigd prestatie‑knelpunt beschouwt.