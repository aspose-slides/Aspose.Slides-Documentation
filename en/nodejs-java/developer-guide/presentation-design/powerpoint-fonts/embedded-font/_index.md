---
title: Embed Fonts in Presentations in JavaScript
linktitle: Embedded Fonts
type: docs
weight: 40
url: /nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Manage embedded fonts in PowerPoint with Aspose.Slides for Node.js via Java. Add, retrieve, remove, and compress fonts to preserve text appearance and reduce file size."
---

## **Introduction**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for Node.js via Java lets you retrieve, add, and remove embedded fonts through the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) class returned by [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

The examples below work with PPTX files. Before embedding a font, make sure its font data is available to Aspose.Slides and its license permits embedding.

## **Get and Remove Embedded Fonts**

Use [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) to list the fonts stored in a presentation. To remove one, pass a font from that list to [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), then save the presentation.

The following example lists the embedded fonts in `EmbeddedFonts.pptx` and removes Calibri if it is present:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Removing an embedded font removes its stored font data; it does not change the font assigned to the text. If the font is installed on the target system, the text can still use it. Otherwise, rendering may require [font substitution](/slides/nodejs-java/font-substitution/), which can affect the layout.

## **Inspect Font Data and Embedding Permissions**

Use the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) class to inspect fonts before embedding them. Call [FontsManager.getFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) to retrieve the fonts used in the presentation. For each font, pass a [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontstyletype/) value to [FontsManager.getFontBytes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). The method returns the binary data for that font style, or `null` when the requested font or style is unavailable. Do not pass a `null` result to [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), because that method requires a byte array. In Node.js, convert the returned JavaScript array to a Java byte array with `java.newArray` before passing it to `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embeddinglevel/) reports the embedding restrictions stored in the font as a set of flags:

- `Installable` permits embedding and permanent installation on another system, subject to the font license.
- `Restricted` prohibits embedding unless permission is obtained from the font's legal owner when it is the only usage-permission flag.
- `PreviewPrint` permits temporary use for viewing and printing; a document containing the font must be read-only.
- `Editable` permits temporary use and allows the document to be edited and saved.
- `NoSubsetting` is an additional restriction that prohibits embedding only a subset of the glyphs. Embed all characters when this flag is present.
- `BitmapOnly` is an additional restriction that permits only bitmap strikes to be embedded, not outline data. If the font has no bitmap strikes, it cannot be embedded.

The first four values describe usage permission, while `NoSubsetting` and `BitmapOnly` can be combined with them. Check the modifiers with bitwise operations. Because `Installable` is zero, mask the usage-permission bits and compare the result with `Installable` instead of checking it as a flag. Current fonts should set at most one usage-permission bit. For compatibility with older fonts that set more than one, the helper below selects the least restrictive permission: `Editable`, then `PreviewPrint`, then `Restricted`.

The following example audits the regular, bold, italic, and bold-italic data available for every font returned by `getFonts`. It skips unavailable styles, restricted fonts, bitmap-only fonts, fonts limited to preview and print because the output remains editable, and fonts that are already embedded. If any available style has `NoSubsetting`, it embeds all characters for that font family.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

This inspection reports the restrictions encoded in each font file. It does not grant a license, prove that you obtained the font legally, or replace checking the font's license agreement before distributing an embedded copy.

## **Add Embedded Fonts**

Use [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) to embed a font. Its overloads accept either a [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) object or a byte array containing the font data. [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) controls which characters are included:

- `All` embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- `OnlyUsed` embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

The following example uses [FontsManager.getFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) to retrieve the fonts used in `Fonts.pptx` and embeds those that are not already embedded. The fonts to add must be available on the machine running the code. Existing embedded fonts retain their current character sets.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compress Embedded Fonts**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/compressembeddedfonts/) reduces embedded font data by removing unused characters. It operates on fonts that are already embedded, so the size reduction depends on how much unused font data the presentation contains.

The following example compresses the fonts in `EmbeddedFonts.pptx` and saves the result as a separate file:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Keep the original file if recipients may need to add text later. Characters removed during compression are no longer available from the embedded font, even if you originally embedded all characters.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Call [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) in the environment where you render the presentation to see which fonts Aspose.Slides will replace. Also check [font substitution](/slides/nodejs-java/font-substitution/) settings and [font fallback](/slides/nodejs-java/fallback-font/) rules. Fallback handles missing characters, so embedding a font does not resolve characters that the font itself does not contain.

**Should I embed common fonts such as Arial and Calibri?**

Base the decision on the target environment. If the required fonts are available on every machine that opens or renders the presentation, embedding them may add unnecessary file size. If recipients or servers may lack those fonts, embedding them can help preserve the intended appearance, provided their licenses allow it.
