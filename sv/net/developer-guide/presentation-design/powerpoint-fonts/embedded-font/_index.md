---
title: Bädda in typsnitt i presentationer i .NET
linktitle: Inbäddade typsnitt
type: docs
weight: 40
url: /sv/net/embedded-font/
keywords:
- lägga till typsnitt
- bädda in typsnitt
- inbäddning av typsnitt
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera inbäddade typsnitt i PowerPoint med Aspose.Slides för .NET. Använd C# för att lägga till, hämta, ta bort och komprimera typsnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Att bädda in typsnitt lagrar typsnittsdata i en PowerPoint-presentation. När en visare stöder inbäddade typsnitt kan den visa text med dessa typsnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides for .NET låter dig hämta, lägga till och ta bort inbäddade typsnitt via egenskapen [FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/fontsmanager/) i en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). Du kan också minska storleken på inbäddade typsnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX-filer. Innan du bäddar in ett typsnitt, se till att dess typsnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade typsnitt**

Använd [GetEmbeddedFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getembeddedfonts/) för att lista de typsnitt som lagras i en presentation. För att ta bort ett, skicka ett typsnitt från den listan till [RemoveEmbeddedFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/removeembeddedfont/), och spara sedan presentationen.

Följande exempel listar de inbäddade typsnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat typsnitt tar bort dess lagrade typsnittsdata; det ändrar inte det typsnitt som tilldelats texten. Om typsnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/net/font-substitution/), vilket kan påverka layouten.

## **Inspektera typsnittsdata och inbäddningsbehörigheter**

Använd gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/) för att inspektera typsnitt innan de bäddas in. Anropa [IFontsManager.GetFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getfonts/) för att hämta de typsnitt som används i presentationen. För varje typsnitt, skicka ett [IFontData](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontdata/)‑objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/net/aspose.slides/fontstyletype/)‑värdet till [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getfontbytes/). Metoden returnerar de binära data för den typsnittsstilen, eller `null` när det begärda typsnittet eller stilen är otillgänglig. Skicka inte ett `null`‑resultat till [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/net/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar inbäddningsrestriktionerna som lagras i typsnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, med förbehåll för typsnittets licens.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från typsnittets juridiska ägare när det är det enda användnings‑behörighets‑flaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller typsnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och gör det möjligt att redigera och spara dokumentet.
- `NoSubsetting` är en extra restriktion som förbjuder att bara en delmängd av tecknen inbäddas. Bädda in alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en extra restriktion som endast tillåter bitmap‑strikes att bäddas in, inte konturdata. Om typsnittet saknar bitmap‑strikes kan det inte bäddas in.

De första fyra värdena beskriver användarbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, använd inte `HasFlag` för att upptäcka den; maskera användarbehörighets‑bitarna och jämför resultatet med `Installable`. Aktuella typsnitt bör sätta högst en användarbehörighets‑bit. För kompatibilitet med äldre typsnitt som sätter fler än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fetstil, kursiv och fet‑kursiva data som är tillgängliga för varje typsnitt som returneras av `GetFonts`. Det hoppar över otillgängliga stilar, begränsade typsnitt, endast‑bitmap‑typsnitt, typsnitt begränsade till förhandsgranskning och utskrift eftersom resultatet förblir redigerbart, samt typsnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddas alla tecken in för den typsnittsfamiljen.

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

Denna inspektion rapporterar de restriktioner som kodats i varje typsnittsfil. Den ger ingen licens, bevisar inte att du har skaffat typsnittet lagligt, eller ersätter kontrollen av typsnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade typsnitt**

Använd [AddEmbeddedFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/addembeddedfont/) för att bädda in ett typsnitt. Dess överlagringar accepterar antingen ett [IFontData](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontdata/)‑objekt eller en byte‑array som innehåller typsnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/net/aspose.slides.export/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/sv/net/aspose.slides.export/embedfontcharacters/) bäddar in alla tecken i typsnittet. Använd detta alternativ när mottagare behöver redigera presentationen och skriva in ny text.
- [OnlyUsed](https://reference.aspose.com/slides/sv/net/aspose.slides.export/embedfontcharacters/) bäddar in endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som huvudsakligen är avsedd för visning.

Följande exempel använder [GetFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getfonts/) för att hämta de typsnitt som används i `Fonts.pptx` och bäddar in de som ännu inte är inbäddade. De typsnitt som ska läggas till måste vara tillgängliga på maskinen som kör koden. Befintliga inbäddade typsnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade typsnitt**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/compressembeddedfonts/) minskar inbäddade typsnittsdata genom att ta bort oanvända tecken. Den arbetar på typsnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvända typsnittsdata presentationen innehåller.

Följande exempel komprimerar typsnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Behåll originalfilen om mottagare kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade typsnittet, även om du ursprungligen bäddade in alla tecken.

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat typsnitt fortfarande kommer att ersättas under rendering?**

Anropa [GetSubstitutions](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getsubstitutions/) i den miljö där du renderar presentationen för att se vilka typsnitt Aspose.Slides kommer att ersätta. Kontrollera även inställningarna för [font substitution](/slides/sv/net/font-substitution/) och [font fallback](/slides/sv/net/fallback-font/) regler. Fallback hanterar saknade tecken, så inbäddning av ett typsnitt löser inte tecken som typsnittet själv inte innehåller.

**Ska jag bädda in vanliga typsnitt såsom Arial och Calibri?**

Basera beslutet på målmiljön. Om de erforderliga typsnitten är tillgängliga på varje maskin som öppnar eller renderar presentationen kan inbäddning av dem öka filstorleken onödigt. Om mottagare eller servrar kan sakna dessa typsnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.