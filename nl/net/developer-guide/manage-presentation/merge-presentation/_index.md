---
title: "Efficiënt Presentaties Samenvoegen in .NET"
linktitle: "Presentaties Samenvoegen"
type: docs
weight: 40
url: /nl/net/merge-presentation/
keywords:
- "PowerPoint samenvoegen"
- "presentaties samenvoegen"
- "dia's samenvoegen"
- "PPT samenvoegen"
- "PPTX samenvoegen"
- "ODP samenvoegen"
- "PowerPoint combineren"
- "presentaties combineren"
- "dia's combineren"
- "PPT combineren"
- "PPTX combineren"
- "ODP combineren"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in .NET kunt samenvoegen door dia's te klonen, masters en layout te beheren, dia-inhoud te schalen, secties te behouden en beveiligde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for .NET voegt presentaties samen door dia's te klonen van de ene [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) naar de andere. De belangrijkste bewerking is [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/), die de opmaak van de brondia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de bestemmingspresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia’s samenvoegen en de bronopmaak behouden;
- geselecteerde dia’s samenvoegen;
- een master uit de bestemmingspresentatie toepassen;
- een specifieke lay‑out uit de bestemmingspresentatie toepassen;
- verschillende diaformaten normaliseren vóór het samenvoegen;
- gekloonde dia’s aan een sectie toevoegen;
- meerdere presentaties in één end‑to‑end workflow samenvoegen;
- masters, bronnen, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe Slideklonen Invloed Heeft Op Masters en Layouts**

Een dia erft veel van haar uiterlijk van de lay‑out en master. Daarom bepaalt de overload die je kiest hoe de samengevoegde dia in de bestemmingspresentatie wordt geïntegreerd.

Gebruik [ISlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) op één van de volgende manieren:

- `AddClone(sourceSlide)` — behoudt de lay‑out en opmaak van de brondia. Indien nodig kan de brondia‑master automatisch in de bestemmingspresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia’s die dezelfde brondia‑master gebruiken die master niet telkens opnieuw klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke bestemming‑[IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/). Aspose.Slides zoekt een bijpassende lay‑out onder die master op basis van type of naam.
- `AddClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia rechtstreeks aan een specifieke bestemming‑[ILayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `AddClone`‑overload wordt doorgegeven moet behoren tot de **bestemmings**‑presentatie, niet tot de bronpresentatie.

## **Volledige Presentaties Samenvoegen en Bronopmaak Behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bronpresentatie naar de bestemmingspresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia’s hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en bestemmingspresentatie verschillende ontwerpen gebruiken. Dat is verwacht wanneer de bronopmaak bewust behouden blijft.

## **Geselecteerde Dia’s Samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bronpresentatie.

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

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia’s Samenvoegen Met Een Bestemmings‑Master**

Gebruik de overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) wanneer geïmporteerde dia’s een master moeten volgen die al tot de bestemmingspresentatie behoort.

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

Aspose.Slides selecteert een geschikte lay‑out onder de opgegeven master door het type of de naam van de bronlay‑out te matchen. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` `true` is, wordt de bronlay‑out gekloond zodat de dia kan worden toegevoegd. Als het `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer je wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de bestemmings‑master toe te voegen.

## **Dia’s Samenvoegen Met Een Specifieke Bestemmings‑Lay‑out**

Gebruik de overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) wanneer je precies weet welke bestemmings‑lay‑out de geïmporteerde dia’s moeten gebruiken.

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

Het toepassen van een bestemmings‑lay‑out wijzigt de geërfde lay‑outrelatie; het rediseigne de inhoud van de brondia niet. Als de bron‑ en bestemmings‑lay‑out verschillende plaatshouderstructuren hebben, controleer dan het resultaat om te bevestigen dat de geërfde opmaak en plaatshoudergedrag passend zijn.

## **Presentaties Met Verschillende Dia‑Groottes Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar een dia klonen naar een presentatie met een andere dia‑grootte rediseigne de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bronpresentatie vóór het klonen van grootte te veranderen. De methode [SlideSize.SetSize](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesize/setsize/) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden gewijzigd. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gewenste grootte past.

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

Het wijzigen van de grootte verandert het bronpresentatie‑object in het geheugen. Als je de oorspronkelijke bronpresentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia’s Samenvoegen In Een Presentatie‑Sectie**

De basis‑dia‑klonlus recreateert de sectiestructuur van de bronpresentatie niet. Als secties belangrijk zijn in de uitvoer, maak of selecteer dan secties in de bestemmingspresentatie en kloon dia’s expliciet daarin met [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/).

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

De gekloonde dia’s worden toegevoegd aan de opgegeven bestemmings‑sectie. Om meerdere bron‑secties te behouden, iterereer over [Presentation.Sections](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sections/), haal de huidige dia’s van elke bron‑sectie op met [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/getslideslistofsection/), maak de secties in de bestemming opnieuw aan en kloon elke opgehaalde dia naar de corresponderende bestemmings‑sectie. Zie [Manage Slide Sections](/slides/nl/net/slide-section/) voor een volledig voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere Presentaties Veilig Samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open terwijl deze wordt gekopieerd, en slaat het definitieve bestand één keer op.

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

Dit vormt een nuttige basis voor het behouden van de bronopmaak van geïmporteerde dia’s. Als je uitvoer één enkel bestemmings‑thema moet gebruiken, vervang dan de eenvoudige `AddClone(slide)`‑aanroep door de juiste bestemmings‑master‑ of bestemmings‑lay‑out‑overload die eerder werd getoond.

## **Praktische Overwegingen**

### **Masters, Layouts en Opmaak‑Fideliteit**

Standaard dia‑klonen kan automatisch een vereiste bron‑master in de bestemmingspresentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet in dat register bijgehouden, dus voorkom pre‑klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet vanuit dat twee masters of layouts met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template de uiteindelijke uitstraling moet bepalen, kies dan expliciet een bestemmings‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Sprekersnotities en dia‑opmerkingen zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API’s voor [presentation notes](/slides/nl/net/presentation-notes/) en [presentation comments](/slides/nl/net/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bronbestanden. Voor review‑workflows controleer ook de auteurs van opmerkingen en de threaded comments nadat bestanden van verschillende auteurs of templates zijn gecombineerd.

### **Afbeeldingen, Audio, Video, OLE‑Objecten en Externe Links**

Dia’s kunnen refereren naar bronnen op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de volledige dia in plaats van alleen de zichtbare vormen, zodat Aspose.Slides de relaties van de dia met haar bronnen kan behouden.

Ingesloten en gelinkte bronnen moeten verschillend worden behandeld. Een gelinkte audio, video, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia maakt van een externe link geen ingesloten inhoud. Test gelinkte pad‑ en URL‑locaties in de omgeving waarin de samengevoegde presentatie zal worden geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden opgevat als een algemene garantie dat identieke binaire bronnen uit ongerelateerde bron‑presentaties altijd worden gededupliceerd. Als de grootte van het uitvoerbestand belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid van Lettertypen**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er niet vanuit dat alleen dia‑klonen garandeert dat elk vereist lettertype beschikbaar is in de bestemmingsomgeving. Je kunt ingesloten lettertypen bekijken met [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) en expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/net/embedded-font/).

Controleer ook dat je toestemming hebt om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Licenties voor lettertypen kunnen het insluiten beperken.

### **Wachtwoord‑Beschermde Presentaties**

Een wachtwoord‑beveiligde bron moet eerst succesvol worden geopend voordat de dia’s kunnen worden gekloond. Lever het wachtwoord via [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Het openen van een versleutelde bron past niet automatisch dezelfde bescherming toe op de bestemmingspresentatie. Configureer de uitvoerbeveiliging afzonderlijk wanneer dat nodig is.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met afbeeldingen in hoge resolutie, audio, video of andere grote binaire objecten kunnen aanzienlijk geheugen verbruiken. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/blobmanagementoptions/) biedt controles voor BLOB‑beheer en het gebruik van tijdelijke bestanden. Zie [Manage Presentation BLOBs](/slides/nl/net/manage-blob/) voor strategieën bij grote bestanden.

Voor grote bestanden, laad bij voorkeur via bestandspaden, maak elke bronpresentatie zo snel mogelijk leeg nadat deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist.

### **Thread‑Safety**

Laad, wijzig, sla op of kloon dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke presentaties‑instantie beperkt tot één samenvoeg‑operatie. Als je onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentaties‑instanties en volg de [Aspose.Slides multithreading guidance](/slides/nl/net/multithreading/).

## **FAQ**

**Hoe houd ik het oorspronkelijke ontwerp van elke bronpresentatie intact?**

Gebruik [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) zonder een bestemmings‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer die nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia’s het bestemmings‑thema gebruiken?**

Gebruik de overload die een bestemmings‑master accepteert. Geef een master uit de bestemmingspresentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke bestemmings‑lay‑out gebruiken in plaats van een bestemmings‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides kiest tussen de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch opnieuw ontworpen voor de bestemmingsafmetingen. Wijzig eerst de grootte van de bronpresentatie wanneer je een voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize.SetSize](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/).


**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bronpresentatie, kloon de benodigde dia’s in één bestemming, en sla de bestemming op in een ondersteund uitvoerformaat. Omdat presentatie‑formaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](/slides/nl/net/supported-file-formats/).

**Worden bron‑secties automatisch bewaard?**

Niet door een eenvoudige lus die alleen dia’s kloont. Maak de benodigde secties in de bestemming aan en gebruik de sectie‑overload van [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en opmerkingen bewaard?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, auteurs van opmerkingen of threaded review‑data, controleer het samengevoegde resultaat omdat deze scenario’s zowel presentatieniveau‑structuren als dia‑niveau‑inhoud betrekken.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen uit elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor font‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer expliciet font‑insluiting of externe font‑beschikbaarheid wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beschermd bestand samen?**

Open het met het juiste [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/), kloon daarna de dia’s normaal. Uitvoerbeveiliging wordt afzonderlijk geconfigureerd.

**Hoe moet ik zeer grote presentaties afhandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen zwaar belasten, laad bij voorkeur via bestandspaden voor zeer grote bestanden, maak bron‑presentaties snel leeg, en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia’s vanaf meerdere threads samenvoegen?**

Gebruik geen enkele [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd in eigen presentaties‑instanties.