---
title: Lettertypen inbedden in presentaties in .NET
linktitle: Ingebedde lettertypen
type: docs
weight: 40
url: /nl/net/embedded-font/
keywords:
  - lettertype toevoegen
  - lettertype inbedden
  - inbedden van lettertypen
  - ingebed lettertype ophalen
  - ingebed lettertype toevoegen
  - ingebed lettertype verwijderen
  - ingebed lettertype comprimeren
  - PowerPoint
  - presentatie
  - .NET
  - C#
  - Aspose.Slides
description: "Beheer ingebedde lettertypen in PowerPoint met Aspose.Slides voor .NET. Gebruik C# om lettertypen toe te voegen, op te halen, te verwijderen en te comprimeren om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Lettertype‑inbedding slaat lettertypegegevens op in een PowerPoint‑presentatie. Wanneer een viewer ingebedde lettertypen ondersteunt, kan deze tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt om regeleinden, tekstafstand en de lay‑out van de dia te behouden.

Aspose.Slides for .NET stelt je in staat om ingebedde lettertypen op te halen, toe te voegen en te verwijderen via de [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/fontsmanager/) eigenschap van een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/). Je kunt de grootte van de ingebedde lettertype‑gegevens ook verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De voorbeelden hieronder werken met PPTX‑bestanden. Zorg er vóór het inbedden van een lettertype voor dat de lettertype‑gegevens beschikbaar zijn voor Aspose.Slides en dat de licentie het inbedden toestaat.

## **Ingebedde lettertypen ophalen en verwijderen**

Gebruik [GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) om de in een presentatie opgeslagen lettertypen weer te geven. Om er één te verwijderen, geef je een lettertype uit die lijst door aan [RemoveEmbeddedFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/removeembeddedfont/), en sla je de presentatie vervolgens op.

Het volgende voorbeeld geeft een lijst weer van de ingebedde lettertypen in `EmbeddedFonts.pptx` en verwijdert Calibri indien aanwezig:

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

Het verwijderen van een ingebed lettertype verwijdert de opgeslagen lettertype‑gegevens; het wijzigt niet het aan de tekst toegewezen lettertype. Als het lettertype op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders kan de weergave [lettertypevervanging](/slides/nl/net/font-substitution/) vereisen, wat de lay‑out kan beïnvloeden.

## **Lettertype‑gegevens en inbedrechten inspecteren**

Gebruik de [IFontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/) interface om lettertypen te inspecteren voordat je ze inbedt. Roep [IFontsManager.GetFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getfonts/) aan om de in de presentatie gebruikte lettertypen op te halen. Voor elk lettertype geef je een [IFontData](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontdata/) object en de benodigde [FontStyleType](https://reference.aspose.com/slides/nl/net/aspose.slides/fontstyletype/) waarde door aan [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getfontbytes/). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `null` wanneer het aangevraagde lettertype of de stijl niet beschikbaar is. Geef geen `null` resultaat door aan [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), omdat die methode een byte‑array vereist.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/net/aspose.slides/embeddinglevel/) is een flags‑enumeratie die de in het lettertype opgeslagen inbedrestricties rapporteert:
- `Installable` staat inbedden en permanente installatie op een ander systeem toe, onder voorbehoud van de lettertype‑licentie.
- `Restricted` verbiedt inbedden tenzij toestemming is verkregen van de wettelijke eigenaar van het lettertype wanneer dit de enige gebruiks‑toestemmingsvlag is.
- `PreviewPrint` staat tijdelijk gebruik toe voor bekijken en afdrukken; een document dat het lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een aanvullende restrictie die het inbedden van slechts een subset van de glyphs verbiedt. Wanneer deze vlag aanwezig is, moeten alle tekens worden ingebed.
- `BitmapOnly` is een aanvullende restrictie die alleen bitmap‑varianten toestaat om in te bedden, niet de outline‑data. Als het lettertype geen bitmap‑varianten heeft, kan het niet worden ingebed.

De eerste vier waarden beschrijven de gebruiks‑toestemming, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modifiërers met bitwise‑bewerkingen. Omdat `Installable` nul is, gebruik `HasFlag` niet om het te detecteren; mask de gebruiks‑toestemmingsbits en vergelijk het resultaat met `Installable`. Huidige lettertypen zouden maximaal één gebruiks‑toestemmingsbit moeten instellen. Voor compatibiliteit met oudere lettertypen die meer dan één bit zetten, selecteert de helper hieronder de minst beperkende toestemming: `Editable`, dan `PreviewPrint`, dan `Restricted`.

Het volgende voorbeeld controleert de gewone, vette, cursieve en vet‑cursieve gegevens die beschikbaar zijn voor elk lettertype dat door `GetFonts` wordt geretourneerd. Het slaat onbeschikbare stijlen, beperkte lettertypen, alleen‑bitmap‑lettertypen, lettertypen beperkt tot preview en afdrukken (omdat de uitvoer bewerkbaar blijft), en reeds ingebedde lettertypen over. Als een beschikbare stijl `NoSubsetting` heeft, worden alle tekens voor die lettertype‑familie ingebed.

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

Deze inspectie rapporteert de restricties die in elk lettertype‑bestand gecodeerd zijn. Het verleent geen licentie, bewijst niet dat je het lettertype legaal hebt verkregen, en vervangt niet het controleren van de licentieovereenkomst van het lettertype voordat je een ingebedde kopie verspreidt.

## **Ingebedde lettertypen toevoegen**

Gebruik [AddEmbeddedFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/addembeddedfont/) om een lettertype in te bedden. De overloads accepteren ofwel een [IFontData](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontdata/) object of een byte‑array met de lettertype‑gegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/net/aspose.slides.export/embedfontcharacters/) enumeratie bepaalt welke tekens worden opgenomen:
- [All](https://reference.aspose.com/slides/nl/net/aspose.slides.export/embedfontcharacters/) bedt alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/nl/net/aspose.slides.export/embedfontcharacters/) bedt alleen de tekens in die in de presentatie worden gebruikt om de bestandsgrootte te verkleinen. Kies deze optie voor een definitieve presentatie die vooral bedoeld is om bekeken te worden.

Het volgende voorbeeld gebruikt [GetFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getfonts/) om de in `Fonts.pptx` gebruikte lettertypen op te halen en bedt die in die nog niet ingebed zijn. De toe te voegen lettertypen moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande ingebedde lettertypen behouden hun huidige tekensets.

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

## **Ingebedde lettertypen comprimeren**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/compressembeddedfonts/) verkleint de gegevens van ingebedde lettertypen door ongebruikte tekens te verwijderen. Het werkt op al ingebedde lettertypen, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertype‑gegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Bewaar het originele bestand als ontvangers later tekst moeten toevoegen. Tekens die tijdens compressie zijn verwijderd, zijn niet langer beschikbaar vanuit het ingebedde lettertype, zelfs als je oorspronkelijk alle tekens had ingebed.

## **FAQ**

**Hoe kan ik controleren of een ingebed lettertype nog steeds wordt vervangen tijdens het renderen?**

Roep [GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getsubstitutions/) aan in de omgeving waarin je de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [lettertypevervanging](/slides/nl/net/font-substitution/) en de regels voor [font fallback](/slides/nl/net/fallback-font/). Fallback behandelt ontbrekende tekens, dus het inbedden van een lettertype lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik gangbare lettertypen zoals Arial en Calibri inbedden?**

Baseer de beslissing op de doenomgeving. Als de benodigde lettertypen op elke machine beschikbaar zijn die de presentatie opent of rendert, kan het inbedden ervan onnodige bestandsgrootte toevoegen. Als ontvangers of servers die lettertypen mogelijk niet hebben, kan het inbedden ze helpen de beoogde weergave te behouden, mits hun licenties dit toestaan.