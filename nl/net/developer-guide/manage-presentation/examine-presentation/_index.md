---
title: Presentatie-informatie ophalen en bijwerken in .NET
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met .NET voor snellere inzichten en slimmer inhoudsaudits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een volledig presentatiemodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opstellen of eigenschappen moet inspecteren voordat u beslist of u de presentatie‑inhoud wilt laden en verwerken.

Dit artikel toont lichtgewicht inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/).

## **Controleer een Presentatieformaat**

Als u al een geladen presentatie heeft, raadpleeg dan [Bepaal het oorspronkelijke presentatiefomaat](/slides/nl/net/detect-presentation-source-format/) voor detectie na het laden en de beperkingen van oude PPT-, PPS- en POT‑stromen.

Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie te maken. De eigenschap [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/loadformat/) geeft het gedetecteerde formaat weer, zoals PPTX, PPT of ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Maak een Lichtgewicht Presentatie‑inventaris**

Wanneer u veel presentatiebestanden verwerkt, kunt u een compacte inventaris nodig hebben voor validatie, indexering of een document‑beheersysteem. Gebruik in dit scenario [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/) object te verkrijgen, en roep vervolgens [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) aan om de documentmetadata te lezen. Deze benadering maakt geen [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie aan en vereist niet dat u het volledige presentatiemodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) worden aangeboden, leveren de volgende inventariswaarden:

| Eigenschap | Inventariswaarde |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/slides/nl/) | Totaal aantal dia's. |
| [HiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/hiddenslides/) | Aantal verborgen dia's. |
| [Notes](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/notes/) | Aantal dia's met notities. |
| [Paragraphs](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/paragraphs/) | Totaal aantal alinea's, indien beschikbaar. |
| [Words](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/words/) | Totaal aantal woorden. |
| [MultimediaClips](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/multimediaclips/) | Totaal aantal audio‑ en videoclips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) object te maken en drukt een compacte inventaris af. Het combineert ook [HeadingPairs](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/headingpairs/) met [TitlesOfParts](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/titlesofparts/) om inhoudsgroepen zoals lettertypen, thema's en dia‑titels weer te geven.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Elke [IHeadingPair](https://reference.aspose.com/slides/nl/net/aspose.slides/iheadingpair/) levert een groepsnaam en het aantal items in die groep. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/titlesofparts/) is een plat, geordend array, dus consumeer het aantal opeenvolgende titels dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen Metadata en Formaatbeperkingen**

De inventaris‑eigenschappen die worden geretourneerd door [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) weerspiegelen de metadata die beschikbaar zijn in het bron‑document. Aspose.Slides laadt en doorloopt het presentatiemodel niet om deze waarden voor deze oproep opnieuw te berekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand het laatst heeft opgeslagen de documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor dia‑, notitie‑, verborgen‑dia‑, alinea‑, woord‑ en multimedia‑telling, evenals heading‑pairs en deel‑titels. Beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn geschreven.
- **PPT:** Het binaire formaat kan overeenkomende document‑samenvattingseigenschappen opslaan. Als een eigenschap afwezig is of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen vanuit de dia's.
- **ODP:** OpenDocument-metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woordtelling, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notitiedia's, multimedia, heading‑pair en deel‑titel kan ontbreken, en de inventariseereigenschappen kunnen standaardwaarden retourneren. Beschouw een nul‑waarde of een lege array niet als overtuigend bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichtgewicht metadata‑benadering voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑model wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de daadwerkelijke presentatiewaarde moet verifiëren.

## **Werk Presentatie‑eigenschappen bij**

De eigenschappen die worden geretourneerd door [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie te maken. Pas de wijzigingen toe met [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), en schrijf vervolgens de gebonden presentatie met [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

De volgende afbeelding toont de originele documenteigenschappen van de PowerPoint‑presentatie.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatst‑opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

De volgende afbeelding toont de bijgewerkte documenteigenschappen van de PowerPoint‑presentatie.

![Bijgewerkte documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige Links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/net/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/net/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingebed en welke dit zijn?**

Laad de presentatie en gebruik [Presentation.FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/fontsmanager/). Roep [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) aan om de ingebedde lettertypen te verkrijgen en [FontsManager.GetFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getfonts/) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingebed.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Wanneer opgeslagen documentmetadata voldoende is, lees [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/hiddenslides/) via [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) en [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Dit is geschikt voor een lichtgewicht inventaris. Als de presentatie in‑memory is gewijzigd, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet u live‑waarden verifiëren door door [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/) te itereren en elke [Slide.Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/hidden/) eigenschap te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en lees [Presentation.SlideSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slidesize/). Inspecteer [ISlideSize.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/size/) en [ISlideSize.Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/orientation/) om de huidige instellingen te vergelijken met de verwachte preset en afmetingen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Zoek elke [Chart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/) en inspecteer [ChartData.DataSourceType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/). Voor een extern werkboek, lees [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/). Het type gegevensbron en pad identificeren een externe verwijzing, maar verifiëren of het doel beschikbaar is vereist een afzonderlijke resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteitseigenschap. Doorloop [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/) en elke [IBaseSlide.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/shapes/) collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve weergave of export voordat u een dia als een bevestigd prestatie‑knelpunt beschouwt.