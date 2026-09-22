---
title: Presentatie‑informatie ophalen en bijwerken op Android
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/androidjava/examine-presentation/
keywords:
- presentatieformaat
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
description: "Ontdek dia’s, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met Java voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een compleet presentatie‑objectmodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opbouwen of eigenschappen wilt inspecteren voordat u beslist of u de presentatie‑inhoud wilt laden en verwerken.

Dit artikel toont lichtgewicht inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/).

## **Controleer een presentatieformaat**

Als u al een geladen presentatie heeft, zie [Bepaal het oorspronkelijke presentatieformaat](/slides/nl/androidjava/detect-presentation-source-format/) voor detectie na het laden en de beperkingen van legacy‑PPT-, PPS- en POT‑streams.

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie te maken. De [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) methode rapporteert het gedetecteerde formaat, zoals PPTX, PPT of ODP.

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

## **Maak een lichtgewicht presentatieninventaris**

Wanneer u veel presentatie‑bestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/)‑object te verkrijgen, en roept u vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aan om de documentmetadata te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie aan en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/) worden blootgelegd, bieden de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Totale aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Aantal dia's met notities. |
| [getParagraphs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Totale aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Totale aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Totale aantal audio‑ en videoclips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑object te maken en geeft een compacte inventaris weer. Het combineert bovendien [getHeadingPairs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) met [getTitlesOfParts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) om inhoudsgroepen zoals lettertypen, thema's en dia‑titels te tonen.

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

Elke [IHeadingPair](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iheadingpair/) levert een groepsnaam en het aantal items in die groep. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) retourneert een platte, geordende array, zodat u het aantal opeenvolgende titels consumeert dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen metadata en formatbeperkingen**

De inventaris‑eigenschappen die door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) worden geretourneerd, weerspiegelen de metadata die beschikbaar is in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden opnieuw te berekenen voor deze oproep. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand als laatste heeft opgeslagen de documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor tellingen van dia’s, notities, verborgen dia’s, alinea’s, woorden en multimedia‑clips, evenals heading‑pairs en part‑titles. De beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn weggeschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattende eigenschappen opslaan. Als een eigenschap afwezig is of niet door de documentproducent is ververst, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen op basis van de dia’s.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woordtelling, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia’s, notities‑dia’s, multimedia, heading‑pairs en part‑titles kan ontbreken, en de inventaris‑eigenschappen kunnen standaardwaarden teruggeven. Beschouw een nul‑waarde of een lege array niet als doorslaggevend bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichtgewicht metadata‑benadering voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat moet weergeven wat in het geheugen is gewijzigd of wanneer u de daadwerkelijke presentatiewaarde moet verifiëren.

## **Presentatie‑eigenschappen bijwerken**

De eigenschappen die door [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) worden geretourneerd, kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie te maken. Pas de wijzigingen toe met [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en schrijf vervolgens de gebonden presentatie met [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

De onderstaande afbeelding toont de oorspronkelijke documenteigenschappen.

![Oorspronkelijke documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

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

De onderstaande afbeelding toont de gewijzigde documenteigenschappen.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/androidjava/password-protected-presentation/)
- [Presentaties met schrijfbescherming beveiligen](/slides/nl/androidjava/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getFontsManager--). Roep [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aan om de ingesloten lettertypen te verkrijgen en [IFontsManager.getFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Wanneer opgeslagen documentmetadata voldoende is, lees [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Dit is geschikt voor een lichtgewicht inventaris. Als de presentatie in het geheugen is bewerkt, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u live‑waarden verifiëren door door [Presentation.getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--) te itereren en elke dia's [ISlide.getHidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getHidden--) methode te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie wordt gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en roep [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideSize--) aan. Gebruik [ISlideSize.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getSize--) en [ISlideSize.getOrientation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/#getOrientation--) om de huidige instellingen te vergelijken met de verwachte vooraf ingestelde waarden en afmetingen.

**Is er een snelle manier om te zien of diagrammen externe gegevensbronnen gebruiken?**

Ja. Lokaliseer elk [Chart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/) en roep [IChartData.getDataSourceType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) aan. Voor een externe werkmap, roep [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) aan. Het type gegevensbron en het pad identificeren een externe referentie, maar verifiëren of het doel beschikbaar is vereist een aparte resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die mogelijk het renderen of PDF‑export vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation.getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--) en elke dia's [IBaseSlide.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#getShapes--) collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve render of export voordat u een dia als bevestigd prestatie‑knelpunt beschouwt.