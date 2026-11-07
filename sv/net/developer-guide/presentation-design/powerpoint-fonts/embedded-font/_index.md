---
title: Inbädda teckensnitt i presentationer i .NET
linktitle: Inbäddade teckensnitt
type: docs
weight: 40
url: /sv/net/embedded-font/
keywords:
- lägg till teckensnitt
- inbädda teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägg till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för .NET. Använd C# för att lägga till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddade teckensnitt lagrar teckensnittsinformation i en PowerPoint-presentation. När en visare stödjer inbäddade teckensnitt kan den visa text med dessa teckensnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för .NET låter dig hämta, lägga till och ta bort inbäddade teckensnitt via egenskapen [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) för en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Du kan också minska storleken på inbäddade teckensnittsinformation genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX‑filer. Innan du inbäddar ett teckensnitt, se till att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) för att lista teckensnitten som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan renderingen kräva [teckensnittssubstitution](/slides/sv/net/font-substitution/), vilket kan påverka layouten.

## **Inspektera teckensnittsdata och inbäddningsbehörigheter**

Använd gränssnittet [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) för att inspektera teckensnitt innan de inbäddas. Anropa [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) för att hämta de teckensnitt som används i presentationen. För varje teckensnitt, skicka ett [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/)‑objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/)-värdet till [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Metoden returnerar de binära data för den teckensnittsstilen, eller `null` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `null`‑resultat till [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar inbäddningsrestriktionerna som lagras i teckensnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, i enlighet med teckensnittets licens.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från teckensnittets juridiska ägare när det är det enda användningsbehörighets‑flaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och möjliggör att dokumentet kan redigeras och sparas.
- `NoSubsetting` är en ytterligare restriktion som förbjuder att bara en delmängd av glyferna inbäddas. Inbädda alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en ytterligare restriktion som bara tillåter att bitmap‑strikes inbäddas, inte konturdata. Om teckensnittet saknar bitmap‑strikes kan det inte inbäddas.

De första fyra värdena beskriver användningsbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, använd inte `HasFlag` för att detektera den; maska användningsbehörighets‑bitarna och jämför resultatet med `Installable`. Aktuella teckensnitt bör sätta högst en användningsbehörighets‑bit. För kompatibilitet med äldre teckensnitt som sätter mer än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fet, kursiv och fet‑kursiv‑data som är tillgängliga för varje teckensnitt som returneras av `GetFonts`. Det hoppar över otillgängliga stilar, begränsade teckensnitt, bitmap‑endast teckensnitt, teckensnitt som är begränsade till förhandsvisning och utskrift eftersom utskriften förblir redigerbar, samt teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` inbäddas alla tecken för den teckensnittsfamiljen.

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

Denna inspektion rapporterar de restriktioner som är kodade i varje teckensnittsfil. Den beviljar ingen licens, bevisar inte att du skaffat teckensnittet lagligt, eller ersätter kontrollen av teckensnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade teckensnitt**

Använd [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) för att inbädda ett teckensnitt. Dess overload‑versioner accepterar antingen ett [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/)‑objekt eller en byte‑array som innehåller teckensnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) inbäddar alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och skriva in ny text.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) inbäddar endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som huvudsakligen är avsedd för visning.

Följande exempel använder [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) för att hämta teckensnitten som används i `Fonts.pptx` och inbäddar de som ännu inte är inbäddade. Teckensnitten som ska läggas till måste vara tillgängliga på maskinen som kör koden. Befintliga inbäddade teckensnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade teckensnitt**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) minskar inbäddade teckensnittsdata genom att ta bort oanvända tecken. Den fungerar på teckensnitt som redan är inbäddade, så storleksminskningen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen inbäddade alla tecken.

För att låta ett matchande registrerat teckensnitt ha prioritet vid export utan att ta bort det inbäddade teckensnittet, se [Föredra registrerade teckensnitt framför inbäddade teckensnitt](/slides/sv/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 eller senare).

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas under rendering?**

Anropa [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera även inställningarna för [teckensnittssubstitution](/slides/sv/net/font-substitution/) och reglerna för [teckensnittsfallback](/slides/sv/net/fallback-font/). Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som teckensnittet självt inte innehåller.

**Bör jag inbädda vanliga teckensnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de erforderliga teckensnitten är tillgängliga på varje maskin som öppnar eller renderar presentationen kan inbäddning öka filstorleken onödigt. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.