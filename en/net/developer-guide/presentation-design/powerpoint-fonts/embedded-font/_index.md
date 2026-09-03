---
title: Embed Fonts in Presentations in .NET
linktitle: Embedded Fonts
type: docs
weight: 40
url: /net/embedded-font/
keywords:
- add font
- embed font
- font embedding
- get embedded font
- add embedded font
- remove embedded font
- compress embedded font
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage embedded fonts in PowerPoint with Aspose.Slides for .NET. Use C# to add, retrieve, remove, and compress fonts to preserve text appearance and reduce file size."
---

## **Introduction**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for .NET lets you retrieve, add, and remove embedded fonts through the [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) property of a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

The examples below work with PPTX files. Before embedding a font, make sure its font data is available to Aspose.Slides and its license permits embedding.

## **Get and Remove Embedded Fonts**

Use [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) to list the fonts stored in a presentation. To remove one, pass a font from that list to [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), then save the presentation.

The following example lists the embedded fonts in `EmbeddedFonts.pptx` and removes Calibri if it is present:

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

Removing an embedded font removes its stored font data; it does not change the font assigned to the text. If the font is installed on the target system, the text can still use it. Otherwise, rendering may require [font substitution](/slides/net/font-substitution/), which can affect the layout.

## **Inspect Font Data and Embedding Permissions**

Use the [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interface to inspect fonts before embedding them. Call [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) to retrieve the fonts used in the presentation. For each font, pass an [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) value to [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). The method returns the binary data for that font style, or `null` when the requested font or style is unavailable. Do not pass a `null` result to [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), because that method requires a byte array.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) is a flags enumeration that reports the embedding restrictions stored in the font:

- `Installable` permits embedding and permanent installation on another system, subject to the font license.
- `Restricted` prohibits embedding unless permission is obtained from the font's legal owner when it is the only usage-permission flag.
- `PreviewPrint` permits temporary use for viewing and printing; a document containing the font must be read-only.
- `Editable` permits temporary use and allows the document to be edited and saved.
- `NoSubsetting` is an additional restriction that prohibits embedding only a subset of the glyphs. Embed all characters when this flag is present.
- `BitmapOnly` is an additional restriction that permits only bitmap strikes to be embedded, not outline data. If the font has no bitmap strikes, it cannot be embedded.

The first four values describe usage permission, while `NoSubsetting` and `BitmapOnly` can be combined with them. Check the modifiers with bitwise operations. Because `Installable` is zero, do not use `HasFlag` to detect it; mask the usage-permission bits and compare the result with `Installable`. Current fonts should set at most one usage-permission bit. For compatibility with older fonts that set more than one, the helper below selects the least restrictive permission: `Editable`, then `PreviewPrint`, then `Restricted`.

The following example audits the regular, bold, italic, and bold-italic data available for every font returned by `GetFonts`. It skips unavailable styles, restricted fonts, bitmap-only fonts, fonts limited to preview and print because the output remains editable, and fonts that are already embedded. If any available style has `NoSubsetting`, it embeds all characters for that font family.

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

This inspection reports the restrictions encoded in each font file. It does not grant a license, prove that you obtained the font legally, or replace checking the font's license agreement before distributing an embedded copy.

## **Add Embedded Fonts**

Use [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) to embed a font. Its overloads accept either an [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) object or a byte array containing the font data. The [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) enumeration controls which characters are included:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

The following example uses [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) to retrieve the fonts used in `Fonts.pptx` and embeds those that are not already embedded. The fonts to add must be available on the machine running the code. Existing embedded fonts retain their current character sets.

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

## **Compress Embedded Fonts**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduces embedded font data by removing unused characters. It operates on fonts that are already embedded, so the size reduction depends on how much unused font data the presentation contains.

The following example compresses the fonts in `EmbeddedFonts.pptx` and saves the result as a separate file:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Keep the original file if recipients may need to add text later. Characters removed during compression are no longer available from the embedded font, even if you originally embedded all characters.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Call [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) in the environment where you render the presentation to see which fonts Aspose.Slides will replace. Also check [font substitution](/slides/net/font-substitution/) settings and [font fallback](/slides/net/fallback-font/) rules. Fallback handles missing characters, so embedding a font does not resolve characters that the font itself does not contain.

**Should I embed common fonts such as Arial and Calibri?**

Base the decision on the target environment. If the required fonts are available on every machine that opens or renders the presentation, embedding them may add unnecessary file size. If recipients or servers may lack those fonts, embedding them can help preserve the intended appearance, provided their licenses allow it.
