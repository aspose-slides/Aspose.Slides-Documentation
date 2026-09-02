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
description: "Verken dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met .NET voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een volledig presentatie‑objectmodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opbouwen of eigenschappen wilt inspecteren voordat u beslist of u de presentatie‑inhoud wilt laden en verwerken.

Dit artikel demonstreert lichtgewicht inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/).

## **Controleer een Presentatieformaat**

Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie te maken. De eigenschap [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/loadformat/) geeft het gedetecteerde formaat weer, zoals PPTX, PPT of ODP.

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

## **Bouw een Lichtgewicht Presentatie‑Inventaris**

Wanneer u veel presentatiebestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/)‑object te verkrijgen, en roept vervolgens [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) aan om de documentmetadata te lezen. Deze aanpak maakt geen [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie aan en vereist niet dat u het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) worden blootgelegd, bieden de volgende inventariswaarden:

| Eigenschap | Inventariswaarde |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/slides/nl/) | Totaal aantal dia's. |
| [HiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/hiddenslides/) | Aantal verborgen dia's. |
| [Notes](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/notes/) | Aantal dia's die notities bevatten. |
| [Paragraphs](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/paragraphs/) | Totaal aantal alinea's, wanneer beschikbaar. |
| [Words](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/words/) | Totaal aantal woorden. |
| [MultimediaClips](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/multimediaclips/) | Totaal aantal audio‑ en videoclips. |

Het onderstaande voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert tevens [HeadingPairs](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/headingpairs/) met [TitlesOfParts](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/titlesofparts/) om inhoudsgroepen zoals lettertypen, thema's en dia‑titels weer te geven.

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

Elke [IHeadingPair](https://reference.aspose.com/slides/nl/net/aspose.slides/iheadingpair/) levert een groepsnaam en het aantal items in die groep. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/titlesofparts/) is een vlak, geordend array, dus consumeer het aantal opeenvolgende titels dat door elk heading‑pair wordt opgegeven.

### **Opgeslagen Metadata en Formaatbeperkingen**

De inventariseereigenschappen die door [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) worden geretourneerd, weerspiegelen metadata die beschikbaar zijn in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet om deze waarden opnieuw te berekenen voor deze oproep. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand als laatste heeft opgeslagen diens document‑eigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor dia‑, notitie‑, verborgen‑dia‑, alinea‑, woord‑ en multimedia‑aantallen, evenals heading‑pairs en part‑titles. Beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn weggeschreven.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings­eigenschappen opslaan. Als een eigenschap ontbreekt of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen op basis van de dia's.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woord‑aantallen, maar deze waarden corresponderen niet met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notitiedia's, multimedia, heading‑pair en part‑title kunnen ontbreken, en de inventariseereigenschappen kunnen standaardwaarden retourneren. Beschouw geen nul‑waarde of een lege array als definitief bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichtgewicht metadata‑aanpak voor inventarissen en preliminaire controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de feitelijke presentatie‑inhoud moet verifiëren.

## **Werk Presentatie‑Eigenschappen Bij**

De eigenschappen die door [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) worden geretourneerd, kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie te maken. Pas de wijzigingen toe met [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), en schrijf vervolgens de gebonden presentatie met [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

De onderstaande afbeelding toont de oorspronkelijke documenteigenschappen.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

De onderstaande afbeelding toont de bijgewerkte documenteigenschappen.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Handige Links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Password-Protect Presentations](/slides/nl/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/nl/net/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke?**

Laad de presentatie en gebruik [Presentation.FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/fontsmanager/). Roep [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) aan om de ingesloten lettertypen te verkrijgen en [FontsManager.GetFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getfonts/) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel bepalen of het bestand verborgen dia's bevat en hoeveel?**

Wanneer opgeslagen documentmetadata voldoende is, lees [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/hiddenslides/) via [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) en [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Dit is geschikt voor een lichtgewicht inventaris. Als de presentatie in het geheugen is aangepast, kan de opgeslagen metadata ontbreken of verouderd zijn, of u moet live‑waarden verifiëren door te itereren over [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/) en iedere dia’s [Slide.Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/hidden/)‑eigenschap te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie wordt gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en lees [Presentation.SlideSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slidesize/). Inspecteer [ISlideSize.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/size/) en [ISlideSize.Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/orientation/) om de huidige instellingen te vergelijken met de verwachte preset en afmetingen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Lokaliseer elke [Chart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/) en inspecteer [ChartData.DataSourceType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/). Voor een extern werkboek, lees [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/). Het type gegevensbron en het pad identificeren een externe verwijzing, maar het verifiëren of het doel beschikbaar is vereist een gescheiden resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er is geen enkele complexiteit‑eigenschap. Doorloop [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/) en elke dia’s [IBaseSlide.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/shapes/)‑collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve weergave of export voordat u een dia als bevestigd prestatie‑knelpunt beschouwt.