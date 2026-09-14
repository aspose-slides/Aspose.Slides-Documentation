---
title: Embed Fonts in Presentations in Python via Java
linktitle: Embedded Fonts
type: docs
weight: 40
url: /python-java/embedded-font/
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
- Python
- Java
- Aspose.Slides
description: "Manage embedded fonts in PowerPoint with Aspose.Slides for Python via Java. Add, retrieve, remove, and compress fonts to preserve text appearance and reduce file size."
---

## **Introduction**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for Python via Java lets you retrieve, add, and remove embedded fonts through the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) class returned by [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

The examples below work with PPTX files. Before embedding a font, make sure its font data is available to Aspose.Slides and its license permits embedding.

## **Get and Remove Embedded Fonts**

Use [getEmbeddedFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) to list the fonts stored in a presentation. To remove one, pass a font from that list to [removeEmbeddedFont](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), then save the presentation.

The following example lists the embedded fonts in `EmbeddedFonts.pptx` and removes Calibri if it is present:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Removing an embedded font removes its stored font data; it does not change the font assigned to the text. If the font is installed on the target system, the text can still use it. Otherwise, rendering may require font substitution, which can affect the layout.

## **Inspect Font Data and Embedding Permissions**

Use the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) class to inspect fonts before embedding them. Call [FontsManager.getFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getFonts) to retrieve the fonts used in the presentation. For each font, pass a [FontData](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/python-java/aspose.slides/fontstyletype/) value to [FontsManager.getFontBytes](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getFontBytes). The method returns the binary data for that font style, or `None` when the requested font or style is unavailable. Do not pass a `None` result to [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), because that method requires a byte array.

[EmbeddingLevel](https://reference.aspose.com/slides/python-java/aspose.slides/embeddinglevel/) is a flags enumeration that reports the embedding restrictions stored in the font:

- `Installable` permits embedding and permanent installation on another system, subject to the font license.
- `Restricted` prohibits embedding unless permission is obtained from the font's legal owner when it is the only usage-permission flag.
- `PreviewPrint` permits temporary use for viewing and printing; a document containing the font must be read-only.
- `Editable` permits temporary use and allows the document to be edited and saved.
- `NoSubsetting` is an additional restriction that prohibits embedding only a subset of the glyphs. Embed all characters when this flag is present.
- `BitmapOnly` is an additional restriction that permits only bitmap strikes to be embedded, not outline data. If the font has no bitmap strikes, it cannot be embedded.

The first four values describe usage permission, while `NoSubsetting` and `BitmapOnly` can be combined with them. Check the modifiers with bitwise operations. Because `Installable` is zero, mask the usage-permission bits and compare the result with `Installable` instead of checking it as a flag. Current fonts should set at most one usage-permission bit. For compatibility with older fonts that set more than one, the helper below selects the least restrictive permission: `Editable`, then `PreviewPrint`, then `Restricted`.

The following example audits the regular, bold, italic, and bold-italic data available for every font returned by `getFonts`. It skips unavailable styles, restricted fonts, bitmap-only fonts, fonts limited to preview and print because the output remains editable, and fonts that are already embedded. If any available style has `NoSubsetting`, it embeds all characters for that font family.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

This inspection reports the restrictions encoded in each font file. It does not grant a license, prove that you obtained the font legally, or replace checking the font's license agreement before distributing an embedded copy.

## **Add Embedded Fonts**

Use [addEmbeddedFont](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) to embed a font. Its overloads accept either a [FontData](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/) object or a byte array containing the font data. The [EmbedFontCharacters](https://reference.aspose.com/slides/python-java/aspose.slides/embedfontcharacters/) enumeration controls which characters are included:

- [All](https://reference.aspose.com/slides/python-java/aspose.slides/embedfontcharacters/) embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- [OnlyUsed](https://reference.aspose.com/slides/python-java/aspose.slides/embedfontcharacters/) embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

The following example uses [getFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getFonts) to retrieve the fonts used in `Fonts.pptx` and embeds those that are not already embedded. The fonts to add must be available on the machine running the code. Existing embedded fonts retain their current character sets.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Compress Embedded Fonts**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#compressEmbeddedFonts) reduces embedded font data by removing unused characters. It operates on fonts that are already embedded, so the size reduction depends on how much unused font data the presentation contains.

The following example compresses the fonts in `EmbeddedFonts.pptx` and saves the result as a separate file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Keep the original file if recipients may need to add text later. Characters removed during compression are no longer available from the embedded font, even if you originally embedded all characters.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Call [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) in the environment where you render the presentation to see which fonts Aspose.Slides will replace. Also check font substitution settings and font fallback rules. Fallback handles missing characters, so embedding a font does not resolve characters that the font itself does not contain.

**Should I embed common fonts such as Arial and Calibri?**

Base the decision on the target environment. If the required fonts are available on every machine that opens or renders the presentation, embedding them may add unnecessary file size. If recipients or servers may lack those fonts, embedding them can help preserve the intended appearance, provided their licenses allow it.
