---
title: Ophalen en bijwerken van presentatie‑informatie in Python
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/python-net/examine-presentation/
keywords:
- presentatieformaat
- presentatie‑eigenschappen
- documenten‑eigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Python voor snellere inzichten en slimmer content‑audit."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata uitlezen zonder een volledig presentatie‑objectmodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opbouwen of eigenschappen moet inspecteren voordat u beslist of u de inhoud van de presentatie wilt laden en verwerken.

Dit artikel demonstreert een lichtgewicht inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/) en [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/), evenals gerichte updates via [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/).

## **Controleer een presentasie‑formaat**

Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie te maken. De eigenschap [PresentationInfo.load_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/load_format/) geeft het gedetecteerde formaat weer, zoals PPTX, PPT of ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Maak een lichtgewicht presentatie‑inventaris**

Wanneer u veel presentaties verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) om een [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/)‑object te verkrijgen, en vervolgens roep u [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/) aan om de documentmetadata uit te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie aan en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/) worden aangeboden, leveren de volgende inventariswaarden:

| Eigenschap | Inventariswaarde |
| --- | --- |
| [slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/slides/nl/) | Totaal aantal dia’s. |
| [hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/hidden_slides/) | Aantal verborgen dia’s. |
| [notes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/notes/) | Aantal dia’s met notities. |
| [paragraphs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/paragraphs/) | Totaal aantal alinea’s, indien beschikbaar. |
| [words](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/words/) | Totaal aantal woorden. |
| [multimedia_clips](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/multimedia_clips/) | Totaal aantal audio‑ en videoclips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert tevens [heading_pairs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/heading_pairs/) met [titles_of_parts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/titles_of_parts/) om inhoudsgroepen weer te geven, zoals lettertypen, thema’s en dia‑titels.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Elke [HeadingPair](https://reference.aspose.com/slides/nl/python-net/aspose.slides/headingpair/) levert een groepsnaam en het aantal items in die groep. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/titles_of_parts/) is een platte, geordende collectie, dus verwerk het aantal opeenvolgende titels dat door elk heading pair wordt opgegeven.

### **Opgeslagen metadata en formatbeperkingen**

De inventariseigenschappen die worden geretourneerd door [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/) weerspiegelen de metadata die beschikbaar is in het bron­document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden voor deze oproep opnieuw te berekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand laatst heeft opgeslagen de documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor aantallen dia’s, notities, verborgen dia’s, alinea’s, woorden en multimedia, evenals heading pairs en part‑titels. Beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn geschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattingseigenschappen opslaan. Als een eigenschap ontbreekt of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen op basis van de dia’s.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woordtellingen, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia’s, notities‑dia’s, multimedia, heading‑pair en part‑title kan ontbreken, en de inventariseigenschappen kunnen standaardwaarden retourneren. Beschouw geen nul‑waarde of een lege collectie als sluitend bewijs dat de overeenkomstige inhoud afwezig is.

Gebruik de lichtgewicht‑metadata‑aanpak voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de daadwerkelijke presentatie‑inhoud wilt verifiëren.

## **Eigenschappen van presentatie bijwerken**

De eigenschappen die worden geretourneerd door [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/) kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie te maken. Pas de wijzigingen toe met [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/update_document_properties/), en schrijf vervolgens de gekoppelde presentatie weg met [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

De onderstaande afbeelding toont de oorspronkelijke documenteigenschappen.

![Original document properties of the PowerPoint presentation](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatst‑opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

De onderstaande afbeelding toont de bijgewerkte documenteigenschappen.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Password-Protect Presentations](/slides/nl/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/nl/python-net/write-protected-presentation/)

## **Veelgestelde vragen**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.fonts_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/fonts_manager/). Roep [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) aan om de ingesloten lettertypen op te halen en [FontsManager.get_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk beide resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel zien of het bestand verborgen dia’s bevat en hoeveel?**

Wanneer opgeslagen documentmetadata voldoende is, lees [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/hidden_slides/) via [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) en [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/). Dit is geschikt voor een lichtgewicht inventaris. Als de presentatie in het geheugen is gewijzigd, kunnen de opgeslagen metadata ontbreken of verouderd zijn, of moet u live‑waarden verifiëren door door [Presentation.slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/) te itereren en elke dia’s [Slide.hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/)‑eigenschap te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en oriëntatie worden gebruikt, en of deze afwijken van de standaarden?**

Ja. Laad de presentatie en lees [Presentation.slide_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slide_size/). Inspecteer [SlideSize.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/size/) en [SlideSize.orientation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/orientation/) om de huidige instellingen te vergelijken met de verwachte presets en dimensies.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Zoek elke [Chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/) en inspecteer [ChartData.data_source_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/). Voor een extern werkboek lees [ChartData.external_workbook_path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Het type gegevensbron en het pad geven een externe referentie aan, maar verifiëren of het doel beschikbaar is vereist een aparte resource‑controle.

**Hoe kan ik ‘zware’ dia’s beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteitseigenschap. Doorloop [Presentation.slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/) en elke dia’s [BaseSlide.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/shapes/)‑collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screening‑signalen, en meet een representatieve render of export voordat u een dia beschouwt als een bevestigde prestatie‑knelpunt.