---
title: Efficiënt Presentaties Samenvoegen in .NET
linktitle: Presentaties Samenvoegen
type: docs
weight: 40
url: /nl/net/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt samenvoegen in .NET door dia's te klonen, masters en lay-outs te beheren, dia-inhoud te schalen, secties te behouden en beschermde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for .NET voegt presentaties samen door dia's te clonen van één [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) naar een andere. De hoofdoperatie is [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de doelpresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen terwijl de bronopmaak behouden blijft;
- geselecteerde dia's samenvoegen;
- een master uit de doelpresentatie toepassen;
- een specifieke lay‑out uit de doelpresentatie toepassen;
- verschillende diaformaten normaliseren vóór het samenvoegen;
- gekloonde dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, bronnen, notities, commentaren, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑gerelateerde zaken afhandelen.

## **Hoe Dia‑clonen Masters en Lay‑outs Beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de overload van het clonen die je kiest hoe de samengevoegde dia wordt geïntegreerd in de doelpresentatie.

Gebruik [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) op een van de volgende manieren:

- `AddClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de doelpresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet opnieuw klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel‑[IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op type of naam.
- `AddClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia rechtstreeks aan een specifieke doel‑[ILayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `AddClone`‑overload wordt doorgegeven, moet behoren tot de **doel**‑presentatie, niet tot de bron‑presentatie.

## **Volledige Presentaties Samenvoegen en Bronopmaak Behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de doel‑presentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doel‑presentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer de bronopmaak opzettelijk behouden wordt.

## **Geselecteerde Dia's Samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of een externe configuratie.

## **Dia's Samenvoegen met een Doel‑Master**

Gebruik de [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/)‑overload wanneer geïmporteerde dia's een master moeten volgen die al tot de doelpresentatie behoort.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te matchen. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als deze `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer je wilt dat de samenvoeging mislukt in plaats van een extra lay‑out in de doel‑master te introduceren.

## **Dia's Samenvoegen met een Specifieke Doel‑Lay‑out**

Gebruik de [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/)‑overload wanneer je precies weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Het toepassen van een doel‑lay‑out verandert de erfd lay‑outrelatie; het herschept de inhoud van de bron‑dia niet. Als de bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, controleer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties Met Verschillende Diaformaten Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia in een presentatie met een andere dia‑grootte herontwerpt de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te herschalen. De [SlideSize.SetSize](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesize/setsize/)‑methode kan bestaande inhoud schalen terwijl de dia‑dimensies worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gevraagde grootte past.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Schalen verandert het bron‑presentatie‑object in het geheugen. Als je de originele bron‑presentatie ongewijzigd nodig hebt voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's Samenvoegen in een Presentatie‑Sectie**

De basale dia‑cloningslus maakt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw. Als secties van belang zijn in de output, maak of selecteer dan secties in de doel‑presentatie en kloon dia's expliciet naar deze secties met [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

De gekloonde dia's worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, maak die secties opnieuw aan in de doel‑presentatie en ken elke bron‑dia toe aan de corresponderende doel‑sectie.

## **Meerdere Presentaties Veilig Samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Dit is een handige basis om de bronopmaak van geïmporteerde dia's te behouden. Als je output één enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `AddClone(slide)`‑aanroep door de juiste doel‑master‑ of doel‑lay‑out‑overload die eerder is getoond.

## **Praktische Overwegingen**

### **Masters, Lay‑outs en Opmaakgetrouwheid**

Standaard dia‑clonen kan automatisch een benodigde bron‑master in de doel‑presentatie brengen. Aspose.Slides houdt een interne registratie bij van automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt geklond. Handmatig gekloonde masters worden niet bijgehouden door die registratie, dus vermijd het vooraf klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet vanuit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een corporate‑template het uiteindelijke uiterlijk moet bepalen, kies dan expliciet een doel‑master of -lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en Commentaren**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook aparte API’s voor [presentation notes](https://docs.aspose.com/slides/nl/net/presentation-notes/) en [presentation comments](https://docs.aspose.com/slides/nl/net/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat note‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bronbestanden. Voor review‑workflows controleer ook de auteurs van commentaren en thread‑commentaren na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia’s kunnen verwijzen naar bronnen op presentatieniveau, zoals afbeeldingen, ingebedde audio, ingebedde video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare vormen te kopiëren, zodat Aspose.Slides de relaties van de dia met zijn bronnen kan behouden.

Ingesloten en gelinkte bronnen moeten anders behandeld worden. Een gelinkte audio‑, video‑, OLE‑object‑ of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt een externe link niet tot ingesloten inhoud. Test gelinkte pad‑ en URL‑referenties in de omgeving waar de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt expliciet automatisch gekloonde masters bij, maar dit moet niet gezien worden als een algemene garantie dat identieke binaire bronnen uit verschillende bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid van Lettertypen**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende machines, ga er niet vanuit dat het klonen van dia’s alleen garandeert dat elk vereist lettertype beschikbaar is in de doelomgeving. Je kunt ingesloten lettertypen inspecteren met [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) en het insluiten expliciet beheren zoals beschreven in [Embed Fonts in Presentations](https://docs.aspose.com/slides/nl/net/embedded-font/).

Controleer ook of je toestemming hebt om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Licenties kunnen het insluiten beperken.

### **Wachtwoordbeveiligde Presentaties**

Een wachtwoord‑beveiligde bron moet succesvol worden geopend voordat de dia’s kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Het openen van een versleutelde bron past de dezelfde bescherming niet automatisch toe op de doel‑presentatie. Configureer de output‑beveiliging afzonderlijk wanneer nodig.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/blobmanagementoptions/) biedt controle over BLOB‑verwerking en tijdelijk‑bestandgebruik. Zie [Manage Presentation BLOBs](https://docs.aspose.com/slides/nl/net/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden, laad bij voorkeur vanuit bestands­paden, maak elke bron‑presentatie onmiddellijk vrij zodra deze is samengevoegd, en vermijd het herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla op of kloon dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke presentatietoepassing beperkt tot één samenvoeg‑bewerking. Als je onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentatietoepassingen en volg de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/nl/net/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doel‑presentatie door, niet uit de bron. Aspose.Slides probeert elke bron‑dia aan een passende lay‑out onder die master te koppelen.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides kiest uit de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende diaformaten worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch herontworpen voor de doel‑dimensies. Schaal de bron‑presentatie eerst wanneer je voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize.SetSize](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties samenvoegen tot één bestand?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's naar één doel‑presentatie en sla de doel‑presentatie op in een ondersteund output‑formaat. Omdat presentaties verschillende functionaliteiten kunnen hebben, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/net/supported-file-formats/).

**Worden bron‑secties automatisch bewaard?**

Niet met een basale lus die alleen dia’s kloont. Maak de benodigde secties opnieuw aan in de doel‑presentatie en gebruik de sectie‑overload van [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en commentaren bewaard?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van note‑master‑styling, commentaarauteurs of thread‑review‑data, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑ als dia‑niveau‑structuren betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern; hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen uit elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑clonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de doel‑presentatie en beheer expliciet het insluiten of de beschikbaarheid van externe lettertypen wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**

Open het met het juiste [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/), kloon vervolgens de dia’s normaal. De output‑beveiliging wordt afzonderlijk geconfigureerd.

**Hoe ga ik om met zeer grote presentaties?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugengebruik domineren, laad grote bestanden bij voorkeur via pad‑namen, maak bron‑presentaties snel vrij en sla het uiteindelijke resultaat pas op wanneer dat nodig is.

**Kan ik dia’s vanuit meerdere threads samenvoegen?**

Gebruik geen enkele [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑bewerking geïsoleerd in eigen presentatietoepassingen.