---
title: Presentatie-informatie ophalen en bijwerken in Java
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/java/examine-presentation/
keywords:
- presentatieformaat
- presentatie-eigenschappen
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
- Java
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Java voor snellere inzichten en slimmer inhoudsaudits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een compleet presentatie‑objectmodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opstellen of eigenschappen wilt inspecteren voordat u beslist of u de inhoud van de presentatie wilt laden en verwerken.

Dit artikel demonstreert een lichte inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/).

## **Controleren van een Presentatieformaat**

Als u al een geladen presentatie hebt, zie [Bepalen van het oorspronkelijke presentatieformaat](/slides/nl/java/detect-presentation-source-format/) voor detectie na het laden en de beperkingen van legacy PPT-, PPS- en POT‑streams.

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie te maken. De [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) methode geeft het gedetecteerde formaat terug, zoals PPTX, PPT of ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Een lichtgewicht presentatie‑inventaris opbouwen**

Wanneer u veel presentatie‑bestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/)‑object te verkrijgen, en daarna roept u [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aan om de documentmetadata te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie aan en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/) worden aangeboden, leveren de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getSlides--) | Totaal aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getNotes--) | Aantal dia's met notities. |
| [getParagraphs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Totaal aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getWords--) | Totaal aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Totaal aantal audio‑ en video‑clips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) object te maken en drukt een compacte inventaris af. Het combineert bovendien [getHeadingPairs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) met [getTitlesOfParts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) om inhoudsgroepen weer te geven zoals lettertypen, thema's en diatitels.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Elke [IHeadingPair](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iheadingpair/) levert een groepsnaam en het aantal items in die groep. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) retourneert een vlak, geordend array, dus gebruik het aantal opeenvolgende titels dat door elk heading‑pair wordt opgegeven.

### **Opgeslagen metadata en formaatbeperkingen**

De inventaris‑eigenschappen die worden geretourneerd door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) weerspiegelen de metadata die beschikbaar is in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden voor deze oproep opnieuw te berekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand het laatst opsloeg de documenteigenschappen niet bijwerkte.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor tellingen van dia's, notities, verborgen dia's, alinea's, woorden en multimedia, evenals heading‑pairs en part‑titles. Beschikbaarheid hangt af van welke eigenschappen zijn geschreven door de documentproducent.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings‑eigenschappen opslaan. Als een eigenschap ontbreekt of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen vanuit de dia's.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woordtelling, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notities, multimedia, heading‑pairs en part‑titles kan ontbreken, en de inventaris‑eigenschappen kunnen standaardwaarden retourneren. Beschouw een nulwaarde of een leeg array niet als sluitend bewijs dat de bijbehorende inhoud afwezig is.

Gebruik de lichte metadata‑aanpak voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat moet weerspiegelen wat er in het geheugen is gewijzigd of wanneer u de daadwerkelijke presentatie‑inhoud moet verifiëren.

## **Presentatie‑eigenschappen bijwerken**

De eigenschappen die worden geretourneerd door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie te maken. Pas de wijzigingen toe met [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en schrijf vervolgens de gekoppelde presentatie weg met [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

De volgende afbeelding toont de oorspronkelijke documenteigenschappen.

![Oorspronkelijke documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

De volgende afbeelding toont de bijgewerkte documenteigenschappen.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige Links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/java/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/java/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getFontsManager--). Roep [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aan om de ingesloten lettertypen te verkrijgen en [IFontsManager.getFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getFonts--) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor het renderen maar niet zijn ingesloten.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel het er zijn?**

Wanneer opgeslagen documentmetadata voldoende is, lees [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Dit is geschikt voor een lichte inventaris. Als de presentatie in het geheugen is gewijzigd, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u de live‑waarden verifiëren; doorloop dan [Presentation.getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--) en inspecteer voor elke dia de [ISlide.getHidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getHidden--) methode.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of ze verschillen van de standaardinstellingen?**

Ja. Laad de presentatie en roep [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlideSize--) aan. Gebruik [ISlideSize.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/#getSize--) en [ISlideSize.getOrientation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/#getOrientation--) om de huidige instellingen te vergelijken met de verwachte vooraf ingestelde waarden en afmetingen.

**Is er een snelle manier om te zien of grafieken verwijzen naar externe gegevensbronnen?**

Ja. Zoek elke [Chart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/) en roep [IChartData.getDataSourceType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getDataSourceType--) aan. Voor een externe werkmap roep je [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) aan. Het type gegevensbron en het pad identificeren een externe referentie, maar om te verifiëren of het doel beschikbaar is, is een aparte resource‑check nodig.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation.getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--) en voor elke dia de [IBaseSlide.getShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getShapes--) collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als indicatie, en meet een representatieve weergave of export voordat u een dia als een bevestigd prestatie‑knelpunt behandelt.