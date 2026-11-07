---
title: Lettertypen insluiten in presentaties in .NET
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/net/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertypen
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor .NET. Gebruik C# om lettertypen toe te voegen, op te halen, te verwijderen en te comprimeren om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Introductie**

Lettertypen insluiten slaat lettertype‑gegevens op in een PowerPoint‑presentatie. Wanneer een viewer ingesloten lettertypen ondersteunt, kan hij tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt de regeleinden, tekstafstand en de indeling van de dia te behouden.

Aspose.Slides for .NET stelt je in staat om ingesloten lettertypen op te halen, toe te voegen en te verwijderen via de [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) eigenschap van een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Je kunt ook de grootte van ingesloten lettertype‑gegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De onderstaande voorbeelden werken met PPTX‑bestanden. Zorg er vóór het insluiten van een lettertype voor dat de lettertype‑gegevens beschikbaar zijn voor Aspose.Slides en dat de licentie insluiten toestaat.

## **Ingesloten lettertypen ophalen en verwijderen**

Gebruik [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) om de lettertypen die in een presentatie zijn opgeslagen op te sommen. Om er één te verwijderen, geef een lettertype uit die lijst door aan [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), en sla vervolgens de presentatie op.

Het volgende voorbeeld somt de ingesloten lettertypen op in `EmbeddedFonts.pptx` en verwijdert Calibri als dat aanwezig is:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Het verwijderen van een ingesloten lettertype verwijdert de opgeslagen lettertype‑gegevens; het verandert het aan de tekst toegewezen lettertype niet. Als het lettertype geïnstalleerd is op het doelsysteem, kan de tekst het nog steeds gebruiken. Anders kan rendering een [font substitution](/slides/nl/net/font-substitution/) vereisen, wat de lay-out kan beïnvloeden.

## **Lettertypegegevens en insluitrechten inspecteren**

Gebruik de [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interface om lettertypen te inspecteren voordat ze worden ingesloten. Roep [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) aan om de lettertypen op te halen die in de presentatie worden gebruikt. Voor elk lettertype geef je een [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) object en de vereiste [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) waarde door aan [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `null` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `null` resultaat door aan [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), omdat die methode een byte‑array vereist.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) is een vlag‑enumeratie die de insluitbeperkingen weergeeft die in het lettertype zijn opgeslagen:

- `Installable` staat insluiten en permanente installatie op een ander systeem toe, onder voorbehoud van de licentie van het lettertype.
- `Restricted` verbiedt insluiten tenzij toestemming is verkregen van de wettelijke eigenaar van het lettertype wanneer het de enige gebruiks‑toestemmingsvlag is.
- `PreviewPrint` staat tijdelijk gebruik voor bekijken en afdrukken toe; een document dat het lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra beperking die het insluiten van slechts een subset van de glyphs verbiedt. Voeg alle tekens in wanneer deze vlag aanwezig is.
- `BitmapOnly` is een extra beperking die alleen bitmap‑strikes toestaat om in te sluiten, niet outline‑gegevens. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven gebruiksrechten, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modifiers met bitwise‑bewerkingen. Omdat `Installable` nul is, gebruik `HasFlag` niet om het te detecteren; mask de gebruiks‑toestemmingsbits en vergelijk het resultaat met `Installable`. Huidige lettertypen zouden maximaal één gebruiks‑toestemmingsbit moeten hebben. Voor compatibiliteit met oudere lettertypen die meer dan één bit hebben ingesteld, selecteert de helper hieronder de minst beperkende toestemming: `Editable`, daarna `PreviewPrint`, daarna `Restricted`.

Het volgende voorbeeld controleert de reguliere, vet, cursief en vet‑cursief gegevens die beschikbaar zijn voor elk lettertype dat wordt geretourneerd door `GetFonts`. Het slaat onbeschikbare stijlen, beperkte lettertypen, alleen‑bitmap‑lettertypen, lettertypen beperkt tot preview en print (omdat de uitvoer bewerkbaar blijft) en al ingesloten lettertypen over. Als een beschikbare stijl `NoSubsetting` heeft, worden alle tekens voor die lettertypefamilie ingesloten.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Deze inspectie rapporteert de in elk lettertypebestand gecodeerde beperkingen. Het verleent geen licentie, bewijst niet dat je het lettertype legaal hebt verkregen, en vervangt niet de controle van de licentie­overeenkomst van het lettertype voordat je een ingesloten kopie verspreidt.

## **Ingesloten lettertypen toevoegen**

Gebruik [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) om een lettertype in te sluiten. De overloads accepteren ofwel een [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) object of een byte‑array die de lettertype‑gegevens bevat. De [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) enumeratie bepaalt welke tekens worden opgenomen:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) sluit alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) sluit alleen de tekens in die in de presentatie worden gebruikt om de bestandsgrootte te verkleinen. Kies deze optie voor een afgeronde presentatie die primair bedoeld is voor weergave.

Het volgende voorbeeld gebruikt [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) om de lettertypen op te halen die in `Fonts.pptx` worden gebruikt en voegt die toe die nog niet ingesloten zijn. De toe te voegen lettertypen moeten beschikbaar zijn op de machine waarop de code wordt uitgevoerd. Bestaande ingesloten lettertypen behouden hun huidige tekenverzamelingen.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Ingesloten lettertypen comprimeren**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) verkleint ingesloten lettertype‑gegevens door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al zijn ingesloten, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertype‑gegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Bewaar het originele bestand als ontvangers later tekst moeten kunnen toevoegen. Tekens die tijdens compressie worden verwijderd, zijn niet langer beschikbaar vanuit het ingesloten lettertype, zelfs als je oorspronkelijk alle tekens had ingesloten.

Om een overeenkomend geregistreerd lettertype prioriteit te laten krijgen tijdens export zonder het ingesloten lettertype te verwijderen, zie [Prefer Registered Fonts over Embedded Fonts](/slides/nl/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 of later).

## **FAQ**

**Hoe kan ik controleren of een ingesloten lettertype nog steeds wordt vervangen tijdens het renderen?**

Roep [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) aan in de omgeving waarin je de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [font substitution](/slides/nl/net/font-substitution/) en de regels voor [font fallback](/slides/nl/net/fallback-font/). Fallback handelt ontbrekende tekens af, dus het insluiten van een lettertype lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik algemene lettertypen zoals Arial en Calibri insluiten?**

Baseer de beslissing op de doelomgeving. Als de benodigde lettertypen op elke machine die de presentatie opent of rendert beschikbaar zijn, kan het insluiten onnodig de bestandsgrootte vergroten. Als ontvangers of servers die lettertypen mogelijk niet hebben, kan het insluiten helpen het beoogde uiterlijk te behouden, mits hun licenties dit toestaan.