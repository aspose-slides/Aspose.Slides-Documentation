---
title: Presentatie‑informatie ophalen en bijwerken op Android
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/androidjava/examine-presentation/
keywords:
- presentatie‑formaat
- presentatie‑eigenschappen
- document‑eigenschappen
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
- Android
- Java
- Aspose.Slides
description: "Verken dia's, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met Java voor snellere inzichten en slimmere content‑audits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de document‑metadata lezen zonder een volledig presentatiemodel te maken. Dit is handig wanneer u bestanden wilt classificeren, een inventaris wilt opbouwen of eigenschappen wilt inspecteren voordat u beslist of u de presentatie‑inhoud wilt laden en verwerken.

Dit artikel toont een lichte inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/).

## **Controleer een presentatieformaat**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) instantie te maken. De methode [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) meldt het gedetecteerde formaat, zoals PPTX, PPT of ODP.

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

## **Bouw een lichtgewicht presentatiesinventaris**

Wanneer u veel presentatie‑bestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. Gebruik in dit scenario [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/) object te verkrijgen, en roep vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aan om de document‑metadata te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) instantie aan en vereist niet dat u het volledige presentatiemodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/) worden aangeboden, leveren de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Totaal aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Aantal dia's met notities. |
| [getParagraphs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Totaal aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Totaal aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Totaal aantal audio- en video-clips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) object te maken en drukt een compacte inventaris af. Het combineert bovendien [getHeadingPairs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) met [getTitlesOfParts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) om inhoudsgroepen weer te geven, zoals lettertypen, thema's en dia‑titels.

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

Elke [IHeadingPair](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iheadingpair/) levert een groepsnaam en het aantal items in die groep. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) retourneert een vlakke, geordende array, dus verwerk het aantal opeenvolgende titels dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen metadata en formatbeperkingen**

De inventariseereigenschappen die door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) worden geretourneerd, weerspiegelen de metadata die beschikbaar is in het bron‑document. Aspose.Slides laadt en doorloopt het presentatiemodel niet om deze waarden opnieuw te berekenen voor deze oproep. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand laatst heeft opgeslagen, haar document‑eigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor dia‑, notitie‑, verborgen‑dia‑, alinea‑, woord‑ en multimedia‑aantallen, evenals heading‑pairs en part‑titles. Beschikbaarheid hangt af van welke eigenschappen door de documentproducer zijn weggeschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings‑eigenschappen opslaan. Als een eigenschap afwezig is of niet is vernieuwd door de documentproducer, keert Aspose.Slides de opgeslagen of standaardwaarde terug in plaats van deze uit de dia's te berekenen.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woord‑aantallen, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen‑dia, notitie‑dia, multimedia, heading‑pair en part‑title kan ontbreken, en de inventariseereigenschappen kunnen standaardwaarden retourneren. Beschouw een nul‑waarde of een lege array niet als sluitend bewijs dat de bijbehorende inhoud afwezig is.

Gebruik de lichte metadata‑aanpak voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat moet weerspiegelen wat in het geheugen staat of wanneer u de feitelijke presentatie‑inhoud wilt verifiëren.

## **Werk presentatie‑eigenschappen bij**

De eigenschappen die door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) worden geretourneerd, kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) instantie te maken. Pas de wijzigingen toe met [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en schrijf vervolgens de gebonden presentatie weg met [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

De volgende afbeelding toont de originele documenteigenschappen van de PowerPoint‑presentatie.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatst‑opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

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

De volgende afbeelding toont de gewijzigde documenteigenschappen van de PowerPoint‑presentatie.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/androidjava/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/androidjava/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingebed en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getFontsManager--). Roep [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aan om de ingebedde lettertypen te verkrijgen en [IFontsManager.getFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk beide resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingebed.

**Hoe kan ik snel weten of het bestand verborgen dia's bevat en hoeveel?**

Wanneer de opgeslagen documentmetadata voldoende is, lees [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Dit is geschikt voor een lichte inventaris. Als de presentatie in het geheugen is aangepast, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u live‑waarden verifiëren door door [Presentation.getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--) te itereren en voor elke dia de methode [ISlide.getHidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getHidden--) te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie wordt gebruikt, en of deze afwijken van de standaardwaarden?**

Ja. Laad de presentatie en roep [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideSize--) aan. Gebruik [ISlideSize.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getSize--) en [ISlideSize.getOrientation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getOrientation--) om de huidige instellingen te vergelijken met de verwachte preset en dimensies.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Lokaliseer elke [Chart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/) en roep [IChartData.getDataSourceType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) aan. Voor een extern werkboek, roep [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) aan. Het type gegevensbron en het pad identificeren een externe verwijzing, maar verifiëren of het doel beschikbaar is vereist een aparte resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation.getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--) en voor elke dia de collectie [IBaseSlide.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#getShapes--). Gebruik aantallen vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screening‑signalen, en meet een representatieve render of export voordat u een dia als bevestigd prestatie‑knelpunt behandelt.