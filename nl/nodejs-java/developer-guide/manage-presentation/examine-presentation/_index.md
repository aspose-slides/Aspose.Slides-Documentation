---
title: Informatie over presentaties ophalen en bijwerken in JavaScript
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/nodejs-java/examine-presentation/
keywords:
- presentatieformaat
- presentatie‑eigenschappen
- documenteigenschappen
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek dia’s, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met JavaScript voor snellere inzichten en slimmere content‑audits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een compleet presentatie‑objectmodel te maken. Dit is handig wanneer u bestanden wilt classificeren, een inventaris wilt opbouwen of eigenschappen wilt inspecteren voordat u beslist of de presentatieinhoud moet worden geladen en verwerkt.

Dit artikel demonstreert een lichte inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/) en [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/), evenals gerichte updates via [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/).

## **Controleer een presentatieformaat**

Als u al een geladen presentatie heeft, zie [Bepaal het oorspronkelijke presentatiefomat](/slides/nl/nodejs-java/detect-presentation-source-format/) voor detectie na het laden en de beperkingen van legacy PPT‑, PPS‑ en POT‑streams.

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instance te maken. De [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/getloadformat/) methode rapporteert het gedetecteerde formaat, zoals PPTX, PPT of ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Bouw een Lichte Presentatie‑Inventaris**

Wanneer u veel presentatiebestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. Gebruik in dit scenario [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) om een [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/)‑object te verkrijgen en roep vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) aan om de documentmetadata te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instance aan en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) worden blootgesteld, bieden de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getSlides) | Totaal aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getNotes) | Aantal dia's die notities bevatten. |
| [getParagraphs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Totaal aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getWords) | Totaal aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Totaal aantal audio‑ en videoclips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert bovendien [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) met [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) om inhoudsgroepen weer te geven, zoals lettertypen, thema's en diatitels.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Elke [HeadingPair](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/headingpair/) levert een groepsnaam via [HeadingPair.getName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/headingpair/#getName) en het aantal items in die groep via [HeadingPair.getCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) retourneert een platte, geordende array, dus consumeer je het aantal opeenvolgende titels dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen Metadata en Formaatbeperkingen**

De inventarie‑eigenschappen die door [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) worden geretourneerd, weerspiegelen de metadata die beschikbaar zijn in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden voor deze oproep opnieuw te berekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand als laatste heeft opgeslagen haar documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor aantallen dia's, notities, verborgen dia's, alinea's, woorden en multimedia, evenals heading‑pairs en onderdeel‑titels. Beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn weggeschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings‑eigenschappen opslaan. Als een eigenschap ontbreekt of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze vanuit de dia's te berekenen.
- **ODP:** OpenDocument-metadata biedt algemene documentstatistieken, zoals aantal pagina's, alinea's en woorden, maar deze waarden corresponderen niet met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notitie‑dia's, multimedia, heading‑pairs en onderdeel‑titels kan ontbreken, en de inventarie‑eigenschappen kunnen standaardwaarden retourneren. Beschouw geen nul‑waarde of een lege array als sluitend bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichte metadata‑aanpak voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de feitelijke presentatie‑inhoud moet verifiëren.

## **Werk Presentatie‑Eigenschappen Bij**

De eigenschappen die door [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) worden geretourneerd, kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instance te maken. Pas de wijzigingen toe met [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), en schrijf vervolgens de gekoppelde presentatie weg met [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

De volgende afbeelding toont de originele documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatst‑opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

De volgende afbeelding toont de gewijzigde documenteigenschappen.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige Links**

Voor verwante beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/nodejs-java/password-protected-presentation/)
- [Presentaties met schrijfbescherming](/slides/nl/nodejs-java/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Roep [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) aan om de ingesloten lettertypen te verkrijgen en [FontsManager.getFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Wanneer de opgeslagen documentmetadata voldoende is, lees dan [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) en [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Dit is geschikt voor een lichte inventaris. Als de presentatie in het geheugen is aangepast, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u live‑waarden verifiëren; loop dan door [Presentation.getSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslides/) en inspecteer voor elke dia de methode [Slide.getHidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/gethidden/).

**Kan ik detecteren of er aangepaste dia‑grootte en oriëntatie worden gebruikt, en of deze afwijken van de standaardwaarden?**

Ja. Laad de presentatie en roep [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslidesize/) aan. Gebruik [SlideSize.getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/getsize/), en [SlideSize.getOrientation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/getorientation/) om de huidige instellingen te vergelijken met de verwachte standaard en afmetingen.

**Is er een snelle manier om te zien of diagrammen verwijzen naar externe gegevensbronnen?**

Ja. Zoek elk [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/) op en roep [ChartData.getDataSourceType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) aan. Voor een externe werkmap roep je [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) aan. Het type gegevensbron en het pad identificeren een externe verwijzing, maar om te verifiëren of het doel beschikbaar is, is een afzonderlijke resource‑check vereist.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation.getSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslides/) en de [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getShapes)‑collectie van elke dia. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve weergave of export voordat u een dia als een bevestigd prestatie‑knelpunt beschouwt.