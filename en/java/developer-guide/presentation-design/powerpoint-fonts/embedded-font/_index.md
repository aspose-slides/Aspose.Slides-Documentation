---
title: Embed Fonts in Presentations in Java
linktitle: Embedded Fonts
type: docs
weight: 40
url: /java/embedded-font/
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
- Java
- Aspose.Slides
description: "Manage embedded fonts in PowerPoint with Aspose.Slides for Java. Add, retrieve, remove, and compress fonts to preserve text appearance and reduce file size."
---

## **Introduction**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for Java lets you retrieve, add, and remove embedded fonts through the [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) interface returned by [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

The examples below work with PPTX files. Before embedding a font, make sure its font data is available to Aspose.Slides and its license permits embedding.

## **Get and Remove Embedded Fonts**

Use [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) to list the fonts stored in a presentation. To remove one, pass a font from that list to [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), then save the presentation.

The following example lists the embedded fonts in `EmbeddedFonts.pptx` and removes Calibri if it is present:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Removing an embedded font removes its stored font data; it does not change the font assigned to the text. If the font is installed on the target system, the text can still use it. Otherwise, rendering may require [font substitution](/slides/java/font-substitution/), which can affect the layout.

## **Inspect Font Data and Embedding Permissions**

Use the [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) interface to inspect fonts before embedding them. Call [IFontsManager.getFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getFonts--) to retrieve the fonts used in the presentation. For each font, pass an [IFontData](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/fontstyletype/) value to [IFontsManager.getFontBytes](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). The method returns the binary data for that font style, or `null` when the requested font or style is unavailable. Do not pass a `null` result to [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), because that method requires a byte array.

[EmbeddingLevel](https://reference.aspose.com/slides/java/com.aspose.slides/embeddinglevel/) is a flags enumeration that reports the embedding restrictions stored in the font:

- `Installable` permits embedding and permanent installation on another system, subject to the font license.
- `Restricted` prohibits embedding unless permission is obtained from the font's legal owner when it is the only usage-permission flag.
- `PreviewPrint` permits temporary use for viewing and printing; a document containing the font must be read-only.
- `Editable` permits temporary use and allows the document to be edited and saved.
- `NoSubsetting` is an additional restriction that prohibits embedding only a subset of the glyphs. Embed all characters when this flag is present.
- `BitmapOnly` is an additional restriction that permits only bitmap strikes to be embedded, not outline data. If the font has no bitmap strikes, it cannot be embedded.

The first four values describe usage permission, while `NoSubsetting` and `BitmapOnly` can be combined with them. Check the modifiers with bitwise operations. Because `Installable` is zero, mask the usage-permission bits and compare the result with `Installable` instead of checking it as a flag. Current fonts should set at most one usage-permission bit. For compatibility with older fonts that set more than one, the helper below selects the least restrictive permission: `Editable`, then `PreviewPrint`, then `Restricted`.

The following example audits the regular, bold, italic, and bold-italic data available for every font returned by `getFonts`. It skips unavailable styles, restricted fonts, bitmap-only fonts, fonts limited to preview and print because the output remains editable, and fonts that are already embedded. If any available style has `NoSubsetting`, it embeds all characters for that font family.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

This inspection reports the restrictions encoded in each font file. It does not grant a license, prove that you obtained the font legally, or replace checking the font's license agreement before distributing an embedded copy.

## **Add Embedded Fonts**

Use [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) to embed a font. Its overloads accept either an [IFontData](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/) object or a byte array containing the font data. The [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) enumeration controls which characters are included:

- [All](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- [OnlyUsed](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

The following example uses [getFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getFonts--) to retrieve the fonts used in `Fonts.pptx` and embeds those that are not already embedded. The fonts to add must be available on the machine running the code. Existing embedded fonts retain their current character sets.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compress Embedded Fonts**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) reduces embedded font data by removing unused characters. It operates on fonts that are already embedded, so the size reduction depends on how much unused font data the presentation contains.

The following example compresses the fonts in `EmbeddedFonts.pptx` and saves the result as a separate file:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Keep the original file if recipients may need to add text later. Characters removed during compression are no longer available from the embedded font, even if you originally embedded all characters.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Call [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) in the environment where you render the presentation to see which fonts Aspose.Slides will replace. Also check [font substitution](/slides/java/font-substitution/) settings and [font fallback](/slides/java/fallback-font/) rules. Fallback handles missing characters, so embedding a font does not resolve characters that the font itself does not contain.

**Should I embed common fonts such as Arial and Calibri?**

Base the decision on the target environment. If the required fonts are available on every machine that opens or renders the presentation, embedding them may add unnecessary file size. If recipients or servers may lack those fonts, embedding them can help preserve the intended appearance, provided their licenses allow it.
